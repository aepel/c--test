using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.MedicalTreatments.Enums;
using Qualyt.Domain.Models.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface ITreatmentsService:IBaseService<Treatment>
    {
         long GetTreatmentsCount(DashboardFilter filter);
         long GetTreatmentsCountLastMonth(DashboardFilter filter);
        void UpdateTreatmentState(long treatmentId);
    }
    public class TreatmentsService : BaseService<Treatment>, ITreatmentsService
    {
        public IUsersRepository usersRepository;
        public TreatmentsService(ITreatmentsRepository repository, IUsersRepository _usersRepository) : base(repository)
        {
            usersRepository = _usersRepository;
        }

        public override IQueryable<Treatment> Query()
        {
            if(repo.HasRole("ADMIN"))
                return base.Query();
            else
            {
                var userPlans = usersRepository.GetPlans();
                return base.Query().Include(x => x.Patient).Where(x => userPlans.Any(y => y.PlanId == x.Patient.PlanId));
            }

        }

        public long GetTreatmentsCount(DashboardFilter filter) {
            return ((ITreatmentsRepository)repo).GetTreatmentsCount(filter); }
        public long GetTreatmentsCountLastMonth(DashboardFilter filter) {
            return ((ITreatmentsRepository)repo).GetTreatmentsCountLastMonth(filter); }

        public override Treatment GetById(long id)
        {
            return this.Query().Include(x=>x.Patient).Include(x=>x.ControlTrackings).Include(x=>x.Doctor).Include(x=>x.Pathology).FirstOrDefault(x=>x.Id==id);
        }

        public override void Add(Treatment entity)
        {
            entity.Doctor = null;
            entity.Patient = null;
            entity.State = TreatmentState.Pending;
            base.Add(entity);
        }

        public void UpdateTreatmentState(long treatmentId)
        {
            var treatment = GetById(treatmentId);
            var lastControl = treatment.ControlTrackings.OrderBy(x=>x.Id).LastOrDefault();
            var hasStart = treatment.ControlTrackings.Any(x => x.Type == ControlType.Start);
            switch (lastControl.Type)
            {
                case ControlType.End:
                    treatment.State = TreatmentState.Finalized;
                    break;
                case ControlType.Normal:
                    if (hasStart)
                        treatment.State = lastControl.FollowingTheTreatment.HasValue && lastControl.FollowingTheTreatment.Value ? TreatmentState.InTreatment : TreatmentState.Suspended;
                    else
                        treatment.State = TreatmentState.Pending;
                    break;
                case ControlType.Start:
                    treatment.State = TreatmentState.InTreatment;
                    break;
                default:
                    throw new Exception("El tipo de seguimiento es incorrecto");
            }
            Update(treatment);
        }
    }
}
