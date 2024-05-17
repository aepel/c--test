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
    public interface IUsersService : IBaseService<ApplicationUser>
    {
        ApplicationUser GetById(string id);
        void Remove(string id);
    }
    public class UsersService : BaseService<ApplicationUser>, IUsersService
    {
        public UsersService(IUsersRepository repository):base(repository)
        {

        }

        public ApplicationUser GetById(string id)
        {
            return ((IUsersRepository)repo).GetById(id);
        }

        public void Remove(string id)
        {
            ((IUsersRepository)repo).Remove(id);
        }
    }
}
