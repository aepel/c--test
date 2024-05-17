using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface IHealthInsurancesService:IBaseService<HealthInsurance>
    {
    }
    public class HealthInsurancesService : BaseService<HealthInsurance>, IHealthInsurancesService
    {
        public HealthInsurancesService(IHealthInsurancesRepository repository):base(repository)
        {

        }
    }
}
