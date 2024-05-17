using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Patients.Enums;
using Qualyt.Domain.Models.Stats;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface IPlansRepository:IRepository<Plan>
    {
        IEnumerable<Plan> GetAllByUser();
        List<PivotTableData> GetPivotTableData(DashboardFilter filter);
        IEnumerable<Plan> GetActivesByUser();
        IEnumerable<Plan> GetActives();
    }
    public class PlansRepository : Repository<Plan>, IPlansRepository
    {
        public PlansRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }

        public override IEnumerable<Plan> GetAll()
        {
            return base.Query()
                .Include(x=>x.Laboratory)
                .Include(x=>x.Country)
                .Include(x => x.PlanPathologies)
                    .ThenInclude(y => y.Pathology)
                .Include(x => x.PlanProducts)
                    .ThenInclude(y => y.Product)
                .ToList();
        }

        public override Plan Get(long id)
        {
            return Query()
                .Include(x => x.Laboratory)
                .Include(x => x.Country)
                .Include(x=>x.PlanPathologies)
                    .ThenInclude(y=>y.Pathology)
                .Include(x=>x.PlanProducts)
                    .ThenInclude(y=>y.Product)
                .FirstOrDefault(x => x.Id == id);
        }
        public override void Update(Plan entity)
        {
            var plan = Query()
                .Include(x => x.PlanPathologies)
                .Include(x => x.PlanProducts)
                .FirstOrDefault(x => x.Id == entity.Id);
            plan.PlanPathologies.Clear();
            plan.PlanProducts.Clear();
            _context.Entry(plan).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            plan.PlanPathologies = entity.PlanPathologies;
            plan.PlanProducts = entity.PlanProducts;
            _context.SaveChanges();
        }
        public List<PivotTableData> GetPivotTableData(DashboardFilter filter)
        {
            var isLaboratory = HasRole("LABORATORIO");

            var planIds = filter.SelectedPlanIds.ToArray();
            var startHasValue = filter.Start.HasValue;
            var endHasValue = filter.End.HasValue;
            DateTimeOffset startValue, endValue;
            if (startHasValue)
                startValue = filter.Start.Value.Date;
            else
                startValue = DateTime.MinValue;

            if (endHasValue)
                endValue = filter.End.Value.Date.AddDays(1).Date;
            else
                endValue = DateTime.MaxValue;
            var subquery = from Pati in _context.Set<Patient>().Include(x=>x.Location)
                           join n in _context.Set<Nurse>()
                       on Pati.NurseId equals n.Id into nurseouter
                       from Nurse in nurseouter.DefaultIfEmpty()
                           join Doctor in _context.Set<Doctor>().Include(x=>x.AttentionPlace)
                               on Pati.DoctorId equals Doctor.Id
                           join SalesContact in _context.Set<SalesContact>() on Doctor.SalesContactId equals SalesContact.Id
                           join Trea in _context.Set<Treatment>() on Pati.Id equals Trea.PatientId into tr
                           from Treatment in tr.DefaultIfEmpty()
                           join p in _context.Set<Pathology>() on Treatment.PathologyId equals p.Id into pathologyOuter
                           from Pathology in pathologyOuter.DefaultIfEmpty()
                           join pp in _context.Set<Product>() on Treatment.ProductId equals pp.Id into productOuter
                           from Product in productOuter.DefaultIfEmpty()
                           join Cont in _context.Set<ControlTracking>() on Treatment.Id equals Cont.TreatmentId
                               into co

                           from Control in co.Where(x => x.CreatedDate>=startValue 
                                     && x.CreatedDate <= endValue
                                   ).DefaultIfEmpty()
                           select new
                           {
                               Patient=Pati,
                               Doctor=Doctor,
                               Nurse=Nurse,
                               Treatment=Treatment,
                               Control=Control,
                               Pathology=Pathology,
                               Product=Product,
                               SalesContact=SalesContact,
                               Planid = Pati.PlanId,
                                
                           };

            var subquery2= from Plan in _context.Set<Plan>()
                           join Laboratory in _context.Set<Laboratory>()
                               on Plan.LaboratoryId equals Laboratory.Id
                           join Country in _context.Set<Country>()
                               on Plan.CountryId equals Country.Id
                           where planIds.Contains(Plan.Id)
                           select new
                           {
                               IsLaboratory = isLaboratory,
                               PlanName = Plan.Name,
                               PlanId = Plan.Id,
                               LaboratoryName = Laboratory.Name,
                               CountryName = Country.Name,
                           };

            var sublist = subquery.Distinct().ToList();
            var sublist2 = subquery2;
            var list = from subl2 in sublist2
                       join sub in sublist on subl2.PlanId equals sub.Planid
                       where planIds.Contains(subl2.PlanId)
                       select new PivotTableData()
                       {
                           IsLaboratory = isLaboratory,
                           PlanName = subl2.PlanName,
                           LaboratoryName = subl2.LaboratoryName,
                           CountryName = subl2.CountryName,
                           PatientHasValue = sub != null && sub.Patient != null,
                           PatientId = sub.Patient != null ? sub.Patient.Id : (long?)null,
                           PatientLocationHasValue = sub != null && sub.Patient != null && sub.Patient.Location != null,
                           PatientLocationAddress = sub.Patient != null && sub.Patient.Location != null ? sub.Patient.Location.Address : null,
                           PatientMothersSurname = sub != null ? sub.Patient.MothersSurname : null,
                           PatientName = sub != null ? sub.Patient.Name : null,
                           PatientPlanId = sub.Patient != null ? sub.Patient.PlanId : (long?)null,
                           PatientStateEnum = sub.Patient != null ? sub.Patient.State :  (PatientState?) null,
                           PatientSurname = sub != null ? sub.Patient.Surname : null,
                           Patient = sub != null ? sub.Patient : null,
                           Doctor = sub != null ? sub.Doctor : null,
                           SalesContact = sub != null ? sub.SalesContact : null,
                           Nurse = sub != null ? sub.Nurse : null,
                           Treatment = sub != null ? sub.Treatment : null,
                           ControlTracking = sub != null ? sub.Control : null,
                           Pathology = sub != null ? sub.Pathology : null,
                           Product = sub != null ? sub.Product : null,
                       };
            var rv = list.ToList();
            return rv;
        }

        public IEnumerable<Plan> GetAllByUser()
        {
            var query = from User in _context.Set<ApplicationUser>()
                        join UsPl in _context.Set<UserPlan>() on User.Id equals UsPl.UserId
                        join Plan in _context.Set<Plan>() on UsPl.PlanId equals Plan.Id
                        where User.Id == _context.CurrentUserId
                        select Plan;
            return query
                .Include(x => x.Laboratory)
                .Include(x => x.Country)
                .Include(x => x.PlanPathologies)
                    .ThenInclude(y => y.Pathology)
                .Include(x => x.PlanProducts)
                    .ThenInclude(y => y.Product)
                .ToList();
        }

        public IEnumerable<Plan> GetActivesByUser()
        {
            var query = from User in _context.Set<ApplicationUser>()
                        join UsPl in _context.Set<UserPlan>() on User.Id equals UsPl.UserId
                        join Plan in _context.Set<Plan>() on UsPl.PlanId equals Plan.Id
                        join UsCo in _context.Set<UserCountry>() on User.Id equals UsCo.UserId
                        where User.Id == _context.CurrentUserId
                        && Plan.Start <= DateTimeOffset.Now
                        && Plan.End >= DateTimeOffset.Now
                        && Plan.CountryId==UsCo.CountryId
                        select Plan;
            return query
                .Include(x => x.Laboratory)
                .Include(x => x.Country)
                .Include(x => x.PlanPathologies)
                    .ThenInclude(y => y.Pathology)
                .Include(x => x.PlanProducts)
                    .ThenInclude(y => y.Product)
                .ToList();
        }

        public IEnumerable<Plan> GetActives()
        {
            var query = from Plan in _context.Set<Plan>()
                        where Plan.Start <= DateTimeOffset.Now
                        && Plan.End >= DateTimeOffset.Now
                        select Plan;
            return query
                .Include(x => x.Laboratory)
                .Include(x => x.Country)
                .Include(x => x.PlanPathologies)
                    .ThenInclude(y => y.Pathology)
                .Include(x => x.PlanProducts)
                    .ThenInclude(y => y.Product)
                .ToList();
        }
    }
}
