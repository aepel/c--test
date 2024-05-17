using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface IScheduleRepository
    {
        List<Treatment> GetEmailsToNotifyTomorrowControls();
    }
    public class ScheduleRepository : IScheduleRepository
    {
        private MCADbContext _db;
        public ScheduleRepository(MCADbContext db)
        {
            _db = db;
        }

        public List<Treatment> GetEmailsToNotifyTomorrowControls()
        {
            var tomorrow= DateTimeOffset.Now.Date.AddDays(1);
            var afterTomorrow= DateTimeOffset.Now.Date.AddDays(2);
            return (from trea in _db.Treatments
                        .Include(x => x.Patient)
                            .ThenInclude(y => y.Plan)
                        .Include(x => x.ControlTrackings)
                        .Include(x => x.Doctor)
                            .ThenInclude(y=>y.AttentionPlace)
                    join cont in _db.ControlTrackings on trea.Id equals cont.TreatmentId
                    group new { cont,trea } by trea.Id into g
                    where g.FirstOrDefault(x => x.cont.Id == g.Max(y => y.cont.Id)).cont.NextDoctorVisit != null
                    && g.FirstOrDefault(x => x.cont.Id == g.Max(y => y.cont.Id)).cont.NextDoctorVisit >= tomorrow
                    && g.FirstOrDefault(x => x.cont.Id == g.Max(y => y.cont.Id)).cont.NextDoctorVisit < afterTomorrow
                    select g.FirstOrDefault().trea).ToList();
        }
    }
}
