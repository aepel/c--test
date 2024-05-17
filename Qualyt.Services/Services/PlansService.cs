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
    public interface IPlansService:IBaseService<Plan>
    {
        List<PivotTableData> GetPivotTableData(DashboardFilter filter);
        IEnumerable<Plan> GetAllByUser();
        IEnumerable<Plan> GetActivesByUser();
    }
    public class PlansService : BaseService<Plan>, IPlansService
    {
        IUsersRepository usersRepository;
        public PlansService(IPlansRepository repository, IUsersRepository _usersRepository):base(repository)
        {
            usersRepository = _usersRepository;
        }

        public IEnumerable<Plan> GetActivesByUser()
        {
            if (usersRepository.GetRole() == "ADMIN")
                return ((IPlansRepository)repo).GetActives();
            else
                return ((IPlansRepository)repo).GetActivesByUser();
        }

        public IEnumerable<Plan> GetAllByUser()
        {
            if(usersRepository.GetRole()=="ADMIN")
                return ((IPlansRepository)repo).GetAll();
            else
                return ((IPlansRepository)repo).GetAllByUser();
        }

        public List<PivotTableData> GetPivotTableData(DashboardFilter filter)
        {
            return ((IPlansRepository)repo).GetPivotTableData(filter);
        }
    }
}
