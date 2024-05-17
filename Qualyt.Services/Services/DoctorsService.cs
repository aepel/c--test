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
    public interface IDoctorsService : IBaseService<Doctor>
    {
        Doctor GetOneById(string id);
        long GetDoctorsCount(DashboardFilter filter);
        long GetDoctorsCountLastMonth(DashboardFilter filter);
        void Delete(string id);
    }
    public class DoctorsService : BaseService<Doctor>, IDoctorsService
    {
        public DoctorsService(IDoctorsRepository repository):base(repository)
        {

        }

        public void Delete(string id)
        {
            ((IDoctorsRepository)repo).Delete(id);
        }

        public long GetDoctorsCount(DashboardFilter filter) {
            return ((IDoctorsRepository)repo).GetDoctorsCount(filter);
        }
        public long GetDoctorsCountLastMonth(DashboardFilter filter) {
            
            return ((IDoctorsRepository)repo).GetDoctorsCountLastMonth(filter);
        }
        public Doctor GetOneById(string id)
        {
            return ((IDoctorsRepository)repo).GetOneById(id);
        }
    }
}
