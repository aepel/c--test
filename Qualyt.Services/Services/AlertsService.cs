using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface IAlertsService
    {
        List<Patient> PatientsWithoutConsent();
        List<Treatment> TodayControls();
    }
    public class AlertsService : IAlertsService
    {
        IAlertsRepository _repo;
        IUsersRepository usersRepository;
        public AlertsService(IAlertsRepository repository, IUsersRepository _usersRepository)
        {
            _repo = repository;
            usersRepository = _usersRepository;
        }

        public List<Patient> PatientsWithoutConsent()
        {
            if(usersRepository.HasRole("ADMIN"))
                return _repo.PatientsWithoutConsent();
            else
            {
                var userPlans = usersRepository.GetPlans();
                return _repo.PatientsWithoutConsent().Where(x => userPlans.Any(y => y.PlanId == x.PlanId)).ToList();
            }
        }

        public List<Treatment> TodayControls()
        {
            var treatmentsToTrack = _repo.TreatmentsToTrackToday();
            if (usersRepository.HasRole("ADMIN"))
                return treatmentsToTrack;
            else
            {
                var userPlans = usersRepository.GetPlans();
                return treatmentsToTrack.Where(x => userPlans.Any(y => y.PlanId == x.Patient.PlanId)).ToList();
            }
        }
    }
}
