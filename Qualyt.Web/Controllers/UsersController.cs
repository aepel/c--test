using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Validation;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Stats;
using Qualyt.Domain.Models.Users;
using Qualyt.Services.Services;
using Qualyt.Web.Helpers;
using Qualyt.Web.Validators;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class UsersController : DatatableController<ApplicationUser>
    {
        private IUsersService _service;
        private IRolesService _rolesService;
        public UsersController(IUsersService service,IRolesService rolesService) :base
            (service.Query())
        {
            _service = service;
            _rolesService = rolesService;
        }

        [HttpGet("[action]")]
        public virtual IEnumerable<ApplicationUserViewModel> Get()
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            var list = mapper.Map<List<ApplicationUserViewModel>>(_service.GetAll());
            list.ForEach(x => {
                x.Roles.Add(_rolesService.GetById(x.RolesCollection.FirstOrDefault().RoleId).Name);
            });
            return list;
        }
        [HttpGet("[action]/{id}")]
        public ApplicationUserViewModel Get(string id)
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            var value = mapper.Map<ApplicationUserViewModel>(_service.GetById(id));
            value.Roles.Add(_rolesService.GetById(value.RolesCollection.FirstOrDefault().RoleId).Name);
            return value;
        }

        [HttpPost("[action]")]
        public virtual ApplicationUserViewModel Post([FromBody] ApplicationUserViewModel value)
        {
            try
            {
                var mapper = AutoMapperConfiguration.GetMapper();
                value.RolesCollection.Add(
                    new IdentityUserRole<string>()
                    {
                        RoleId = _rolesService.GetByName(value.Roles.FirstOrDefault()).Id
                    }
                    );
                if (!String.IsNullOrWhiteSpace(value.PasswordChange))
                    HashPassword(value);
                var user = mapper.Map<ApplicationUser>(value);
                _service.Add(user);
                return mapper.Map<ApplicationUserViewModel>(user);
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("IX_AspNetUsers_Email"))
                    ModelState.AddModelError("", "Ya existe un usuario con este email");
                else if (e.Message.Contains("UserNameIndex"))
                    ModelState.AddModelError("", "Ya existe un usuario con este email");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado.");
                return null;
            }
        }

        [HttpPut("[action]")]
        public virtual void Put([FromBody] ApplicationUserViewModel value)
        {
            try
            {
                var mapper = AutoMapperConfiguration.GetMapper();
                value.RolesCollection.Clear();
                value.RolesCollection.Add(
                    new IdentityUserRole<string>()
                    {
                        RoleId = _rolesService.GetByName(value.Roles.FirstOrDefault()).Id,
                        UserId = value.Id
                    }
                    );
                if (!String.IsNullOrWhiteSpace(value.PasswordChange))
                    HashPassword(value);
                ApplicationUser user;
                if (value.LaboratoryId != 0)
                    user = mapper.Map<LaboratoryUser>(value);
                else
                    user = mapper.Map<ApplicationUser>(value);
                _service.Update(user);
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("IX_AspNetUsers_Email"))
                    ModelState.AddModelError("", "Ya existe un usuario con este email");
                else if (e.Message.Contains("UserNameIndex"))
                    ModelState.AddModelError("", "Ya existe un usuario con este email");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado.");
            }
        }

        private void HashPassword(ApplicationUserViewModel value)
        {
            byte[] salt;
            byte[] buffer2;
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(value.PasswordChange, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            value.PasswordHash=Convert.ToBase64String(dst);
        }

        [HttpDelete("[action]/{id}")]
        public void Delete(string id)
        {
            try
            {
                _service.Remove(id);
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("CONSTRAINT"))
                    ModelState.AddModelError("", "No se puede borrar porque existen entidades relacionadas con esta.");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado.");
            }
        }

        public override Expression<Func<ApplicationUser, bool>> Filter(string filterValue)
        {
            return (x) => 
                RemoveDiacritics(x.Email.ToLower()).Contains(filterValue) ||
                RemoveDiacritics(x.FullName.ToLower()).Contains(filterValue) ||
                (x.Enabled?"si".Contains(filterValue): "no".Contains(filterValue))
                ;
        }

        public override Expression<Func<ApplicationUser, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "email": return (x) => x.Email;
                case "fullName": return (x) => x.FullName;
                case "enabled": return (x) => x.Enabled;
                default: return (x) => x.Email;
            }
        }
    }
}
