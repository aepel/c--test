using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface ITermsAndConditionsService : IBaseService<TermsAndConditions>
    {
        TermsAndConditions GetLastPublished();
        void Publish(int id, string user_id);
    }
    public class TermsAndConditionsService : BaseService<TermsAndConditions>, ITermsAndConditionsService
    {
        IPatientsService patientsService;
        public TermsAndConditionsService(ITermsAndConditionsRepository repository, IPatientsService _patientsService):base(repository)
        {
            patientsService = _patientsService;
        }

        public TermsAndConditions GetLastPublished()
        {
            return ((ITermsAndConditionsRepository)repo).GetLastPublished();
        }

        public void Publish(int id, string user_id)
        {
            var entity = repo.Get(id);
            entity.PublishedDate = DateTimeOffset.Now;
            entity.PublishedBy = user_id;
            entity.Published = true;
            entity.Active = true;
            var active=GetLastPublished();
            if (active != null)
            {
                active.Active = false;
                entity.Version = active.Version + 1;
                Update(active);
            }
            else
                entity.Version = 1;
            Update(entity);
            patientsService.SetAllEmailSendedsToFalse();
        }
    }
}
