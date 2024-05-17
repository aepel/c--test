using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface ITermsAndConditionsRepository : IRepository<TermsAndConditions>
    {
        TermsAndConditions GetLastPublished();
    }
    public class TermsAndConditionsRepository : Repository<TermsAndConditions>, ITermsAndConditionsRepository
    {
        public TermsAndConditionsRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        { }

        public TermsAndConditions GetLastPublished()
        {
            return _context.Set<TermsAndConditions>().FirstOrDefault(x => x.Active);
        }
    }
}
