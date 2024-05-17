using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Stats;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface IRolesRepository : IRepository<ApplicationRole>
    {
        ApplicationRole Get(string roleId);
        ApplicationRole GetByName(string v);
    }
    public class RolesRepository : Repository<ApplicationRole>, IRolesRepository
    {
        public RolesRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }

        public ApplicationRole Get(string roleId)
        {
            return _entities.FirstOrDefault(x => x.Id == roleId);
        }

        public ApplicationRole GetByName(string v)
        {
            return _entities.FirstOrDefault(x => x.Name == v);
        }
    }
}
