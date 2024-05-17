using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.MedicalTreatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface IControlTrackingsRepository:IRepository<ControlTracking>
    {

    }
    public class ControlTrackingsRepository : Repository<ControlTracking>, IControlTrackingsRepository
    {
        public ControlTrackingsRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        { }

        public override ControlTracking Get(long id)
        {
            return Query().Include(x => x.CreatedByUser).FirstOrDefault(x => x.Id == id);
        }
    }
}
