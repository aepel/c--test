using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface ILaboratoryUsersService : IBaseService<LaboratoryUser>
    {
        LaboratoryUser GetOneById(string id);
    }
    public class LaboratoryUsersService : BaseService<LaboratoryUser>, ILaboratoryUsersService
    {
        public LaboratoryUsersService(ILaboratoryUsersRepository repository):base(repository)
        {

        }

        public LaboratoryUser GetOneById(string id)
        {
            return ((ILaboratoryUsersRepository)repo).GetOneById(id);
        }
    }
}
