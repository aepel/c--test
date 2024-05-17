using EFSecondLevelCache.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories.Interfaces;
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
    public interface IDoctorsRepository : IRepository<Doctor>
    {
        Doctor GetOneById(string id);
        long GetDoctorsCount(DashboardFilter filter);
        long GetDoctorsCountLastMonth(DashboardFilter filter);
        void Delete(string id);
    }
    public class DoctorsRepository : Repository<Doctor>, IDoctorsRepository
    {
        public DoctorsRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }

        public override IEnumerable<Doctor> GetAll()
        {
            var list= base.Query().Include(x=>x.Specialty).ToList();
            return list;
        }

        public Doctor GetOneById(string id)
        {
            return _entities
                .Include(x => x.AttentionPlace)
                .Include(x => x.Specialty)
                .Include(x => x.SalesContact)
                .Include(x => x.Country)
                .FirstOrDefault(x => x.Id == id);
        }
        public long GetDoctorsCount(DashboardFilter filter)
        {
            var planIds = filter.SelectedPlanIds;
            var startHasValue = filter.Start.HasValue;
            var endHasValue = filter.End.HasValue;
            DateTimeOffset startValue, endValue;
            if (startHasValue)
                startValue = filter.Start.Value.Date;
            if (endHasValue)
                endValue = filter.End.Value.Date.AddDays(1).Date;
            var list= (from doctor in _entities
                    join patient in _context.Set<Patient>() on doctor.Id equals patient.DoctorId
                    select new { doctor, patient }).Cacheable().ToList();

            return (from item in list
                    join planId in planIds on item.patient.PlanId equals planId
                    where (startHasValue ? item.doctor.CreatedDate >= startValue : true)
                    && (endHasValue ? item.doctor.CreatedDate <= endValue : true)
                    group item.doctor by item.doctor.Id into grouping
                    select grouping).Count(x => x != null);
        }
        public long GetDoctorsCountLastMonth(DashboardFilter filter)
        {
            filter.Start = DateTime.Now.AddMonths(-1);
            filter.End = DateTime.Now;
            return GetDoctorsCount(filter);
        }

        public override void Update(Doctor entity)
        {
            var doctor = GetOneById(entity.Id);
            _context.Entry(doctor).CurrentValues.SetValues(entity);
            doctor.Location = entity.Location;
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            _entities.Remove(GetOneById(id));
            _context.SaveChanges();
        }
    }
}
