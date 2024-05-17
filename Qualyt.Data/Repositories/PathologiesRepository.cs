using EFSecondLevelCache.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface IPathologiesRepository : IRepository<Pathology>
    {
        List<Pathology> GetByPatient(long id);
        long GetPathologiesCount(DashboardFilter filter);
        long GetPathologiesCountLastMonth(DashboardFilter filter);
        long GetPathologiesCountByLaboratory(string userId);
        long GetPathologiesCountByLaboratoryLastMonth(string userId);
    }
    public class PathologiesRepository:Repository<Pathology>,IPathologiesRepository
    {
        private IPatientsRepository _patientsRepo;
        public PathologiesRepository(MCADbContext db, IPatientsRepository patientsRepo, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {
            _patientsRepo = patientsRepo;
        }

        public List<Pathology> GetByPatient(long id)
        {
            return _patientsRepo
                .Query()
                .Include(x => x.PatientPathologies)
                .ThenInclude(y=>y.Pathology)
                .FirstOrDefault(x => x.Id == id)
                .PatientPathologies.Select(x=>x.Pathology)
                .ToList();
        }
        public long GetPathologiesCount(DashboardFilter filter)
        {
            var planIds = filter.SelectedPlanIds;
            var startHasValue = filter.Start.HasValue;
            var endHasValue = filter.End.HasValue;
            DateTimeOffset startValue, endValue;
            if (startHasValue)
                startValue = filter.Start.Value.Date;
            if (endHasValue)
                endValue = filter.End.Value.Date.AddDays(1).Date;
            var list = (from pathology in _entities
                        join planPathology in _context.Set<PlanPathology>() on pathology.Id equals planPathology.PathologyId
                        join plan in _context.Set<Plan>() on planPathology.PlanId equals plan.Id
                        select new { pathology, plan }).Cacheable().ToList();

            return (from item in list
                    join planId in planIds on item.plan.Id equals planId
                    where (startHasValue ? item.pathology.CreatedDate >= startValue : true)
                    && (endHasValue ? item.pathology.CreatedDate <= endValue : true)
                    group item.pathology by item.pathology.Id into grouping
                    select grouping).Count(x => x != null);



        }

        public long GetPathologiesCountLastMonth(DashboardFilter filter)
        {
            filter.Start = DateTime.Now.AddMonths(-1);
            filter.End = DateTime.Now;
            return GetPathologiesCount(filter);
        }

        public long GetPathologiesCountByLaboratory(string userId)
        {
            var laboratoryId = _context.ApplicationUsers.FirstOrDefault(x => x.Id == userId)?.LaboratoryId;
            return _context.Pathologies
                .Where(x => x.LaboratoryId == laboratoryId)
                .Count();
        }
        public long GetPathologiesCountByLaboratoryLastMonth(string userId)
        {
            var laboratoryId = _context.ApplicationUsers.FirstOrDefault(x => x.Id == userId)?.LaboratoryId;
            return _context.Pathologies
                .Where(x => x.LaboratoryId == laboratoryId && x.CreatedDate.Month.Equals(DateTime.Now.Month))
                .Count();
        }
    }
}
