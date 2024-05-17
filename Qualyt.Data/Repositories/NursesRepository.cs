using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface INursesRepository:IRepository<Nurse>
    {

    }
    public class NursesRepository : Repository<Nurse>, INursesRepository
    {
        public NursesRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }

        public override Nurse Get(long id)
        {
            return base.Query().Include(x=>x.Country).FirstOrDefault(x=>x.Id==id);
        }
    }
}
