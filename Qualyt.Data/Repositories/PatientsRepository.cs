using EFSecondLevelCache.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Stats;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface IPatientsRepository:IRepository<Patient>
    {
        List<Patient> GetByDoctor(string id);
        List<AttachedFile> GetAcceptedTerms(long id);
        byte[] GetFile(long id);
        Patient GetWithoutFiles(long id);
        AttachedFile GetAttachedFile(long id);
        IQueryable<Patient> GetPatients();
        TermsAndConditions LastTermsAccepted(long id);
        long GetPatientsCount(DashboardFilter filter);
        long GetPatientsCountLastMonth(DashboardFilter filter);
        long GetPatientsCountByLaboratory(string userId);
        long GetPatientsCountByLaboratoryLastMonth(string userId);
        void SetAllEmailSendedsToFalse();
        void TermsSended(long id);
        void ToggleActive(long id);
        void RemoveFile(AttachedFile file);
        void AddAttachedFile(AttachedFile attached);
    }
    public class PatientsRepository : Repository<Patient>, IPatientsRepository
    {
        ITermsAndConditionsRepository _termsRepo;
        public PatientsRepository(MCADbContext db, ITermsAndConditionsRepository termsRepo, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {
            _termsRepo = termsRepo;
        }
        public long GetPatientsCount(DashboardFilter filter)
        {
            var planIds = filter.SelectedPlanIds;
            var startHasValue = filter.Start.HasValue;
            var endHasValue = filter.End.HasValue;
            DateTimeOffset startValue, endValue;
            if (startHasValue)
                startValue = filter.Start.Value.Date;
            if (endHasValue)
                endValue = filter.End.Value.Date.AddDays(1).Date;
            var list=(from patient in _entities
                    select patient).Cacheable().ToList();

            return (from patient in list
                    join planId in planIds on patient.PlanId equals planId
                    where (startHasValue ? patient.CreatedDate >= startValue : true)
                    && (endHasValue ? patient.CreatedDate <= endValue : true)
                    select patient).Count();
        }
        public long GetPatientsCountLastMonth(DashboardFilter filter)
        {
            filter.Start = DateTime.Now.AddMonths(-1);
            filter.End = DateTime.Now;
            return GetPatientsCount(filter);
        }
        public List<AttachedFile> GetAcceptedTerms(long id)
        {
            return (from ent in _context.Set<AttachedFile>()
                   where ent.PatientId == id
                   select new AttachedFile()
                   {
                       FileName=ent.FileName,
                       Id=ent.Id,
                       Name=ent.Name,
                       PatientId=ent.PatientId,
                       Size=ent.Size,
                       Type=ent.Type
                   }).ToList();
        }

        public List<Patient> GetByDoctor(string id)
        {
            var query = from patient in _entities
                        join treatment in _context.Treatments on patient.Id equals treatment.PatientId into t
                        from treatment in t.DefaultIfEmpty()
                        join userplans in _context.Set<UserPlan>() on patient.PlanId equals userplans.PlanId
                        where userplans.UserId==_context.CurrentUserId
                        && patient.DoctorId == id
                        && treatment == null
                        select patient;
            return query.ToList();
        }

        public Patient GetWithoutFiles(long id)
        {
            return Query()
                .Include(x => x.Doctor)
                .Include(x => x.Plan)
                .Include(x => x.PatientPathologies)
                .Include(x => x.Country)
                .FirstOrDefault(x => x.Id == id);
        }

        public override Patient Get(long id)
        {
            return Query()
                .Include(x => x.Doctor)
                .Include(x => x.Plan)
                .Include(x => x.PatientPathologies)
                .Include("PatientPathologies.Pathology")
                .Include(x => x.AcceptedTerms)
                    .ThenInclude(y => y.TermsAndConditions)
                .Include(x=>x.Country)
                .FirstOrDefault(x=>x.Id==id);
        }

        public byte[] GetFile(long id)
        {
            return _context.Set<AttachedFile>().FirstOrDefault(x => x.Id == id).File;
        }

        public IQueryable<Patient> GetPatients()
        {
            var lastVersion = _termsRepo.GetLastPublished()?.Version;
            return (from ent in _context.Set<Patient>()
                    join patientterms in _context.Set<PatientTermsAndConditions>() on ent.Id equals patientterms.PatientId
                    into pt
                    from patientterms in pt.DefaultIfEmpty()
                    join terms in _context.Set<TermsAndConditions>() on patientterms.TermsAndConditionsId equals terms.Id
                    into te
                    from terms in te.DefaultIfEmpty()
                    join doctors in _context.Set<Doctor>() on ent.DoctorId equals doctors.Id
                    join plans in _context.Set<Plan>() on ent.PlanId equals plans.Id
                    join countries in _context.Set<Country>() on ent.CountryId equals countries.Id
                    join healthinsurances in _context.Set<HealthInsurance>() on ent.HealthInsuranceId equals healthinsurances.Id
                    join patientpathologies in _context.Set<PatientPathology>() on ent.Id equals patientpathologies.PatientId
                    into pp
                    from patientpathologies in pp.DefaultIfEmpty()
                    group new { terms.Version, doctors, countries, healthinsurances, pp, plans, ent } by ent.Id into g
                    select new Patient(g.FirstOrDefault().ent)
                    {
                        LastTermsAccepted = lastVersion != null ? lastVersion == g.Max(x => x.Version) : true,
                        Doctor = g.FirstOrDefault().doctors,
                        Country = g.FirstOrDefault().countries,
                        HealthInsurance = g.FirstOrDefault().healthinsurances,
                        Plan = g.FirstOrDefault().plans,
                        PatientPathologies = g.FirstOrDefault().pp.ToList()
                    });
        }

        public TermsAndConditions LastTermsAccepted(long id)
        {
            var acceptedVersions=from ent in _context.Set<Patient>()
            join patientterms in _context.Set<PatientTermsAndConditions>() on ent.Id equals patientterms.PatientId
            //into pt
            //from patientterms in pt.DefaultIfEmpty()
            join terms in _context.Set<TermsAndConditions>() on patientterms.TermsAndConditionsId equals terms.Id
            //into te
            //from terms in te.DefaultIfEmpty()
            where ent.Id==id
            select terms;
            if (!acceptedVersions.Any())
                return null;
            var lastVersionAccepted=acceptedVersions.Max(x=>x.Version.Value);
            return acceptedVersions.FirstOrDefault(x => x.Version == lastVersionAccepted);
        }

        public override void Update(Patient entity)
        {
            var patient = Query().Include(x=>x.PatientPathologies).FirstOrDefault(x=>x.Id==entity.Id);
            patient.ClinicalHistory = entity.ClinicalHistory;
            patient.Location = entity.Location;
            var patientPathologiesIds = entity.PatientPathologies.Select(x => new { x.PathologyId, x.PatientId });
            patient.PatientPathologies = patient.PatientPathologies.Where(x => patientPathologiesIds.Any(y => y.PathologyId == x.PathologyId && y.PatientId == x.PatientId)).ToList();
            var newPatientPathologies = patientPathologiesIds.Where(x => !patient.PatientPathologies.Any(y => y.PathologyId == x.PathologyId && y.PatientId == x.PatientId)).ToList();
            foreach (var item in newPatientPathologies)
            {
                patient.PatientPathologies.Add(new PatientPathology() { PathologyId = item.PathologyId, PatientId = item.PatientId });
            }
            _context.Entry(patient).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public long GetPatientsCountByLaboratory(string userId)
        {
            var laboratoryId = _context.ApplicationUsers.FirstOrDefault(x => x.Id == userId)?.LaboratoryId;
            return _context.Patients
                .Include(x => x.PatientPathologies)
                    .ThenInclude(y => y.Pathology)
                .Where(x => x.PatientPathologies.Any(y => y.Pathology.LaboratoryId == laboratoryId))
                .Count();
        }
        public long GetPatientsCountByLaboratoryLastMonth(string userId)
        {
            var laboratoryId = _context.ApplicationUsers.FirstOrDefault(x => x.Id == userId)?.LaboratoryId;
            return _context.Patients
                .Include(x => x.PatientPathologies)
                    .ThenInclude(y => y.Pathology)
                .Where(x => x.PatientPathologies.Any(y => y.Pathology.LaboratoryId == laboratoryId) && x.CreatedDate.Month.Equals(DateTime.Now.Month))
                .Count();
        }

        public void SetAllEmailSendedsToFalse()
        {
            string query = "Update patients Set EmailSended = false";
            _context.Database.ExecuteSqlCommandAsync(query);
        }

        public void TermsSended(long id)
        {
            string query = "Update patients Set EmailSended = true where id=@Id";
            _context.Database.ExecuteSqlCommand(query,new MySql.Data.MySqlClient.MySqlParameter("@Id", id));
        }

        public void ToggleActive(long id)
        {
            var patient = Get(id);
            patient.Active = !patient.Active;
            Update(patient);
        }

        public AttachedFile GetAttachedFile(long fileId)
        {
            return _context.Set<AttachedFile>().FirstOrDefault(x => x.Id == fileId);
        }

        public void RemoveFile(AttachedFile file)
        {
            _context.Set<AttachedFile>().Remove(file);
            _context.SaveChanges();
        }

        public void AddAttachedFile(AttachedFile attached)
        {
            _context.Set<AttachedFile>().Add(attached);
            _context.SaveChanges();
        }
    }
}
