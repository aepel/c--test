using Microsoft.AspNetCore.Http;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface IAttentionPlacesRepository:IRepository<AttentionPlace>
    {

    }
    public class AttentionPlacesRepository : Repository<AttentionPlace>, IAttentionPlacesRepository
    {
        public AttentionPlacesRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }
    }
}
