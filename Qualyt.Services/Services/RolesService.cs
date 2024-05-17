using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Stats;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface IRolesService : IBaseService<ApplicationRole>
    {
        ApplicationRole GetById(string roleId);
        ApplicationRole GetByName(string v);
    }
    public class RolesService : BaseService<ApplicationRole>, IRolesService
    {
        public RolesService(IRolesRepository repository):base(repository)
        {

        }

        public ApplicationRole GetById(string roleId)
        {
            return ((IRolesRepository)repo).Get(roleId);
        }

        public ApplicationRole GetByName(string v)
        {
            return ((IRolesRepository)repo).GetByName(v);
        }
    }
}
