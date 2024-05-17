using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Patients.Enums;
using Qualyt.Domain.Models.Stats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Qualyt.Services.Services
{
    public interface IPatientsService:IBaseService<Patient>
    {
        List<Patient> GetByDoctor(string id);
        void AcceptTerms(long id);
        void AcceptTerms(IFormFile file, long id);
        List<AttachedFile> GetAcceptedTerms(long id);
        byte[] GetFile(long id);
        Patient GetWithoutFiles(long id);
        IQueryable<Patient> GetPatients();
        long GetPatientsCount(DashboardFilter filter);
        long GetPatientsCountLastMonth(DashboardFilter filter);
        Patient GetHashed(string hash, string number);
        bool TermsAcceptmentIsRequired(Patient value);
        void TermsSended(long id);
        void SetAllEmailSendedsToFalse();
        void ToggleActive(long id);
        void RemoveFile(long fileId);
    }
    public class PatientsService : BaseService<Patient>, IPatientsService
    {
        ITermsAndConditionsRepository termsRepo;
        IUsersRepository usersRepo;

        public PatientsService(IPatientsRepository repository, ITermsAndConditionsRepository _termsRepo, IUsersRepository _usersRepository) :base(repository)
        {
            termsRepo = _termsRepo;
            usersRepo = _usersRepository;
        }

        public override void Update(Patient entity)
        {
            var basePatient = GetById(entity.Id);
            entity.State = basePatient.State;
            if (basePatient.Email != entity.Email && (basePatient.AcceptedTerms.Count()==0))
                entity.EmailSended = false;
            base.Update(entity);
        }

        public override void Add(Patient entity)
        {
            entity.State = PatientState.Preregistered;
            base.Add(entity);
        }

        public override List<Patient> GetAll()
        {
            return ((IPatientsRepository)repo).GetPatients()
                .Include(x => x.Doctor)
                .Include(x => x.PatientPathologies)
                .Include(x => x.Country)
                .Include(x => x.HealthInsurance)
                .ToList();
        }
        public long GetPatientsCount(DashboardFilter filter)
        {
            return ((IPatientsRepository)repo).GetPatientsCount(filter);
        }
        public long GetPatientsCountLastMonth(DashboardFilter filter)
        {
            return ((IPatientsRepository)repo).GetPatientsCountLastMonth(filter);
        }
        public IQueryable<Patient> GetPatients()
        {
            if(usersRepo.GetRole()=="ADMIN")
                return ((IPatientsRepository)repo).GetPatients();
            else
            {
                var userCountries = usersRepo.GetCountries();
                var userPlans = usersRepo.GetPlans();
                return ((IPatientsRepository)repo).GetPatients().Where(
                    x=> userCountries.Any(y=>y.CountryId==x.CountryId)
                        && userPlans.Any(y=>y.PlanId==x.PlanId));
            }
        }

        public override Patient GetById(long id)
        {
            return repo.Get(id);
        }

        public Patient GetWithoutFiles(long id)
        {
            return ((IPatientsRepository)repo).GetWithoutFiles(id);
        }

        public List<Patient> GetByDoctor(string id)
        {
            return ((IPatientsRepository)repo).GetByDoctor(id);
        }

        public void AcceptTerms(long id)
        {
            var patient = ((IPatientsRepository)repo).Get(id);
            SetLastTerms(patient);
        }

        private void SetLastTerms(Patient patient)
        {
            var terms = termsRepo.GetLastPublished();
            if (patient.PatientTermsAndConditions == null)
                patient.PatientTermsAndConditions = new List<PatientTermsAndConditions>();
            if (!patient.PatientTermsAndConditions.Any(x => x.TermsAndConditionsId == terms.Id))
                patient.PatientTermsAndConditions.Add(new PatientTermsAndConditions()
                {
                    PatientId = patient.Id,
                    TermsAndConditionsId = terms.Id
                });
            patient.EmailSended = false;
            patient.State = PatientState.Registered;
            Update(patient);
        }

        public void AcceptTerms(IFormFile file, long id)
        {
            byte[] bytes;
            var patient = ((IPatientsRepository)repo).Query()
                .Include(x=>x.PatientTermsAndConditions)
                .Include(x=>x.AcceptedTerms)
                .Include(x=>x.PatientPathologies)
                .FirstOrDefault(x=>x.Id==id);
            using (MemoryStream ms = new MemoryStream())
            {
                var input = file.OpenReadStream();
                input.CopyTo(ms);
                bytes = ms.ToArray();
                var attached=new AttachedFile()
                {
                    File = bytes,
                    PatientId=patient.Id,
                    Name=file.Name,
                    Size=(int)file.Length,
                    Type=file.ContentType,
                    FileName=file.FileName,
                    TermsAndConditionsId= termsRepo.GetLastPublished()?.Id
                };
                ((IPatientsRepository)repo).AddAttachedFile(attached);
            }
            SetLastTerms(patient);
        }

        public List<AttachedFile> GetAcceptedTerms(long id)
        {
            return ((IPatientsRepository)repo).GetAcceptedTerms(id);
        }

        public byte[] GetFile(long id)
        {
            return ((IPatientsRepository)repo).GetFile(id);
        }

        public Patient GetHashed(string hash, string number)
        {
            MD5 hs = MD5.Create();
            byte[] db = hs.ComputeHash(System.Text.Encoding.UTF8.GetBytes(number));
            string result = Convert.ToBase64String(db);
            if (result == hash)
                return GetById(Convert.ToInt64(number));
            return null;
        }

        public bool TermsAcceptmentIsRequired(Patient value)
        {
            var lastTerms = termsRepo.GetLastPublished();
            if (lastTerms == null)
                return false;
            var lastTermsAccepted = ((IPatientsRepository)repo).LastTermsAccepted(value.Id);
            if (lastTermsAccepted == null || lastTermsAccepted.Version < lastTerms.Version)
                return !value.EmailSended;
            return false;
        }

        public void TermsSended(long id)
        {
            ((IPatientsRepository)repo).TermsSended(id);
        }

        public void SetAllEmailSendedsToFalse()
        {
            ((IPatientsRepository)repo).SetAllEmailSendedsToFalse();
        }

        public void ToggleActive(long id)
        {
            ((IPatientsRepository)repo).ToggleActive(id);
        }

        public void RemoveFile(long fileId)
        {
            var file=((IPatientsRepository)repo).GetAttachedFile(fileId);
            var patientId = file.PatientId;
            ((IPatientsRepository)repo).RemoveFile(file);
            var patient=GetById(patientId);
            var lastTermsPublishedId = termsRepo.GetLastPublished()?.Id;
            if (!patient.AcceptedTerms.Any(x => x.TermsAndConditionsId == lastTermsPublishedId))
                patient.State = PatientState.Preregistered;
            Update(patient);
        }
    }
}
