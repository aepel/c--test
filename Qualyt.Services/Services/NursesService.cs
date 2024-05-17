using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface INursesService:IBaseService<Nurse>
    {
    }
    public class NursesService : BaseService<Nurse>, INursesService
    {
        public NursesService(INursesRepository repository):base(repository)
        {

        }
    }
}
