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
    public interface ISalesContactsRepository:IRepository<SalesContact>
    {

    }
    public class SalesContactsRepository : Repository<SalesContact>, ISalesContactsRepository
    {
        public SalesContactsRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }
    }
}
