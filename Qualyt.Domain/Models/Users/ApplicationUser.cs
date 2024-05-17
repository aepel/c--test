using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.Mails;
using Qualyt.Domain.Models.Mails.Interfaces;

namespace Qualyt.Domain.Models.Users
{
    public class ApplicationUser : IdentityUser, IAuditableEntity,IMaileable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MothersSurname { get; set; }
        public string FullName
        {
            get
            {
                return Name + " " + Surname + " " + MothersSurname;
            }
        }
        public bool Active { get; set; }
        public bool Enabled { get; set; }
        public bool IsLockedOut => this.LockoutEnabled && this.LockoutEnd >= DateTimeOffset.UtcNow;

        public virtual Laboratory Laboratory { get; set; }
        public long? LaboratoryId { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }

        public List<UserCountry> Countries { get; set; }
        public List<UserPlan> Plans { get; set; }



        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        [NotMapped]
        public virtual List<string> RolesList { get; set; }

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public object Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
        public   List<Tag> getTags() 
        {
             List<Tag> tags = new List<Tag>();
            tags.Add(new Tag("{FULLNAME}", this.Name + " " + this.Surname));
            
            return tags;
        }
    }
}
