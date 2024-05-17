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
    public interface ILaboratoryUsersRepository : IRepository<LaboratoryUser>
    {
        LaboratoryUser GetOneById(string id);
    }
    public class LaboratoryUsersRepository : Repository<LaboratoryUser>, ILaboratoryUsersRepository
    {
        public LaboratoryUsersRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }

        public LaboratoryUser GetOneById(string id)
        {
            return Query().Include(x => x.Laboratory).FirstOrDefault(x => x.Id == id);
        }
    }
}
