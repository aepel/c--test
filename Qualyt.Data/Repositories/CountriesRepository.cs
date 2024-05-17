using Microsoft.AspNetCore.Http;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface ICountriesRepository : IRepository<Country>
    {
        IEnumerable<Country> GetAllByUser();
    }
    public class CountriesRepository : Repository<Country>, ICountriesRepository
    {
        public CountriesRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }

        public IEnumerable<Country> GetAllByUser()
        {
            return (from user in _context.ApplicationUsers
                    join usercountry in _context.Set<UserCountry>() on user.Id equals usercountry.UserId
                    join country in _context.Set<Country>() on usercountry.CountryId equals country.Id
                    where user.Id==_context.CurrentUserId
                    select country
                    ).ToList();
        }
    }
}
