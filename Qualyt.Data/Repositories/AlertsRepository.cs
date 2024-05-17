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
    public interface IAlertsRepository
    {
        List<Patient> PatientsWithoutConsent();
        List<Treatment> TreatmentsToTrackToday();
    }
    public class AlertsRepository : IAlertsRepository
    {
        private MCADbContext _db;
        private IPatientsRepository _patientsRepository;
        private IControlTrackingsRepository _controlTrackingsRepository;
        private ITreatmentsRepository _treatmentsRepository;
        public AlertsRepository(MCADbContext db, IPatientsRepository patientsRepository,
            IControlTrackingsRepository controlTrackingsRepository, ITreatmentsRepository treatmentsRepository)
        {
            _db = db;
            _patientsRepository = patientsRepository;
            _controlTrackingsRepository = controlTrackingsRepository;
            _treatmentsRepository = treatmentsRepository;
        }

        public List<Patient> PatientsWithoutConsent()
        {
            var fecha = DateTimeOffset.Now.AddDays(-2);
            var list=_patientsRepository.GetPatients()
                .Include(x=>x.AcceptedTerms)
                .Where(x=> x.Active && 
                !(x.AcceptedTerms!=null && x.AcceptedTerms.Any()) && x.CreatedDate < fecha
                ).ToList()
                .Where(x => !x.LastTermsAccepted).ToList();
            return list;
        }

        public List<Treatment> TreatmentsToTrackToday()
        {
            var today = DateTimeOffset.Now.Date;
            var tomorrow = DateTimeOffset.Now.AddDays(1).Date;
            var treatments = from treatment in _treatmentsRepository.Query()
                             join cont in _db.ControlTrackings on treatment.Id equals cont.TreatmentId into c
                             from control in c.OrderByDescending(c => c.Id).Take(1)
                             where control.NextControl<=tomorrow
                             select treatment;
            return treatments.ToList();
        }
    }
}
