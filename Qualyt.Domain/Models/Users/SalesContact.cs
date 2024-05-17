using Qualyt.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Users
{
    public class SalesContact:IAuditableEntity
    {
        public long Id { get; set; }
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
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
    }
}
