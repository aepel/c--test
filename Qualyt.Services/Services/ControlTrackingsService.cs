using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.MedicalTreatments.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface IControlTrackingsService:IBaseService<ControlTracking>
    {
    }
    public class ControlTrackingsService : BaseService<ControlTracking>, IControlTrackingsService
    {
        ITreatmentsService treatmentsService;
        public ControlTrackingsService(IControlTrackingsRepository repository, 
            ITreatmentsService _treatmentsService) :base(repository)
        {
            treatmentsService = _treatmentsService;
        }
        public override ControlTracking GetById(long id)
        {
            return ((IControlTrackingsRepository)repo).Get(id);
        }
        public override void Add(ControlTracking entity)
        {
            base.Add(entity);
            treatmentsService.UpdateTreatmentState(entity.TreatmentId);
        }
        public override void Update(ControlTracking entity)
        {
            base.Update(entity);
            treatmentsService.UpdateTreatmentState(entity.TreatmentId);
        }
        public override void Remove(long id)
        {
            var treatmentId = GetById(id).TreatmentId;
            base.Remove(id);
            treatmentsService.UpdateTreatmentState(treatmentId);
        }
    }
}
