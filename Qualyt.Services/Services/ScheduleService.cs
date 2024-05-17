using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface IScheduleService
    {
        List<Treatment> GetEmailsToNotifyTomorrowControls();
    }
    public class ScheduleService : IScheduleService
    {
        IScheduleRepository _repo;
        public ScheduleService(IScheduleRepository repository)
        {
            _repo = repository;
        }

        public List<Treatment> GetEmailsToNotifyTomorrowControls()
        {
            return _repo.GetEmailsToNotifyTomorrowControls();
        }
    }
}
