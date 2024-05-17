using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface ICountriesService : IBaseService<Country>
    {
        IEnumerable<Country> GetAllByUser();
    }
    public class CountriesService : BaseService<Country>, ICountriesService
    {
        public CountriesService(ICountriesRepository repository):base(repository)
        {

        }

        public IEnumerable<Country> GetAllByUser()
        {
            return ((ICountriesRepository)repo).GetAllByUser();
        }
    }
}
