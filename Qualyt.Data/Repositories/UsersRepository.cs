using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Stats;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface IUsersRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetById(string id);
        void Remove(string id);
        string GetRole();
        List<UserCountry> GetCountries();
        List<UserPlan> GetPlans();
    }
    public class UsersRepository : Repository<ApplicationUser>, IUsersRepository
    {
        public UsersRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }

        public override IEnumerable<ApplicationUser> GetAll()
        {
            return base.Query()
                .Include(x => x.Roles)
                .Include(x => x.Countries)
                    .ThenInclude(y=>y.Country)
                .Include(x => x.Plans)
                    .ThenInclude(y=>y.Plan)
                .ToList() ;
        }

        public ApplicationUser GetById(string id)
        {
            return _entities
                .Include(x => x.Roles)
                .Include(x => x.Laboratory)
                .Include(x => x.Countries)
                    .ThenInclude(y => y.Country)
                .Include(x => x.Plans)
                    .ThenInclude(y => y.Plan)
                .FirstOrDefault(x => x.Id == id);
        }

        public override void Update(ApplicationUser entity)
        {
            var user=Query()
                .Include(x => x.Countries)
                .Include(x => x.Plans)
                .Include(x => x.Roles)
                .FirstOrDefault(x => x.Id == entity.Id);
            user.Countries.Clear();
            user.Plans.Clear();
            user.Roles.Clear();
            _context.Entry(user).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            user.Countries = entity.Countries;
            user.Plans = entity.Plans;
            user.Roles = entity.Roles;
            _context.SaveChanges();
        }

        public void Remove(string id)
        {
            _entities.Remove(GetById(id));
            _context.SaveChanges();
        }

        public string GetRole()
        {
            var roleId= _entities.Include(x=>x.Roles).FirstOrDefault(x => x.Id == _context.CurrentUserId).Roles.FirstOrDefault().RoleId;
            return _context.Roles.FirstOrDefault(x => x.Id == roleId).Name;
        }

        public List<UserCountry> GetCountries()
        {
            return _entities.Include(x=>x.Countries).FirstOrDefault(x => x.Id == _context.CurrentUserId).Countries;
        }

        public List<UserPlan> GetPlans()
        {
            return _entities.Include(x => x.Plans).FirstOrDefault(x => x.Id == _context.CurrentUserId).Plans;
        }
    }
}
