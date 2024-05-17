using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface IAttentionPlacesService:IBaseService<AttentionPlace>
    {
    }
    public class AttentionPlacesService : BaseService<AttentionPlace>, IAttentionPlacesService
    {
        public AttentionPlacesService(IAttentionPlacesRepository repository):base(repository)
        {

        }
    }
}
