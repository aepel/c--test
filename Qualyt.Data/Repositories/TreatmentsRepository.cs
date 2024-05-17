using EFSecondLevelCache.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface ITreatmentsRepository : IRepository<Treatment>
    {
        long GetTreatmentsCount(DashboardFilter filter);
        long GetTreatmentsCountLastMonth(DashboardFilter filter);
        long GettreatmentsCountByLaboratory(string userId);
        long GettreatmentsCountByLaboratoryLastMonth(string userId);
    }
    public class TreatmentsRepository : Repository<Treatment>, ITreatmentsRepository
    {
        public TreatmentsRepository(MCADbContext db,IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        { }

        public override IQueryable<Treatment> Query()
        {
            return base.Query()
                .Include(x=>x.Pathology)
                .Include(x=>x.Patient)
                .Include(x=>x.Product)
                .Include(x=>x.Doctor);
        }
        public long GetTreatmentsCount(DashboardFilter filter)
        {
            var planIds = filter.SelectedPlanIds;
            var startHasValue = filter.Start.HasValue;
            var endHasValue = filter.End.HasValue;
            DateTimeOffset startValue, endValue;
            if (startHasValue)
                startValue = filter.Start.Value.Date;
            if (endHasValue)
                endValue = filter.End.Value.Date.AddDays(1).Date;
            var list = (from treatment in _entities
                        join patient in _context.Set<Patient>() on treatment.PatientId equals patient.Id
                        join plan in _context.Set<Plan>() on patient.PlanId equals plan.Id
                        select new { treatment, plan }).Cacheable().ToList();
            return (from item in list
                    join planId in planIds on item.plan.Id equals planId
                    where (startHasValue ? item.treatment.CreatedDate >= startValue : true)
                    && (endHasValue ? item.treatment.CreatedDate <= endValue : true)
                    select item).Count(x => x != null);
        }
        public long GetTreatmentsCountLastMonth(DashboardFilter filter)
        {
            filter.Start = DateTime.Now.AddMonths(-1);
            filter.End = DateTime.Now;
            return GetTreatmentsCount(filter);
        }
        public long GettreatmentsCountByLaboratory(string userId)
        {
            var laboratoryId = _context.ApplicationUsers.FirstOrDefault(x => x.Id == userId)?.LaboratoryId;
            return _entities.Include(x=>x.Pathology).
                Where(x => x.Pathology.LaboratoryId == laboratoryId)
                .Count();
        }
        public long GettreatmentsCountByLaboratoryLastMonth(string userId)
        {
            var laboratoryId = _context.ApplicationUsers.FirstOrDefault(x => x.Id == userId)?.LaboratoryId;
            return _entities.Include(x => x.Pathology).
                Where(x => x.Pathology.LaboratoryId == laboratoryId && x.CreatedDate.Month.Equals(DateTime.Now.Month))
                .Count();
        }
        public override void Update(Treatment entity)
        {
            if(entity.PatientId!=entity.Patient.Id)
                entity.Patient = null;
            if(entity.DoctorId!=entity.Doctor.Id)
                entity.Doctor = null;
            if(entity.PathologyId!=entity.Pathology.Id)
                entity.Pathology = null;
            if (entity.ProductId != entity.Product.Id)
                entity.Product = null;
            base.Update(entity);
        }
    }
}
