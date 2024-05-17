using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface ISalesContactsService:IBaseService<SalesContact>
    {
    }
    public class SalesContactsService : BaseService<SalesContact>, ISalesContactsService
    {
        public SalesContactsService(ISalesContactsRepository repository):base(repository)
        {

        }
    }
}
