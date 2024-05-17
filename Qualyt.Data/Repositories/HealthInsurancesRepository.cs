using Microsoft.AspNetCore.Http;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface IHealthInsurancesRepository:IRepository<HealthInsurance>
    {

    }
    public class HealthInsurancesRepository : Repository<HealthInsurance>, IHealthInsurancesRepository
    {
        public HealthInsurancesRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }
    }
}
