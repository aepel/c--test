using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface IDoctorSpecialtiesService:IBaseService<DoctorSpecialty>
    {
    }
    public class DoctorSpecialtiesService : BaseService<DoctorSpecialty>, IDoctorSpecialtiesService
    {
        public DoctorSpecialtiesService(IDoctorSpecialtiesRepository repository):base(repository)
        {

        }
    }
}
