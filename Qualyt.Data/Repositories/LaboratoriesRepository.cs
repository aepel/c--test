using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Data.Repositories
{
    public interface ILaboratoriesRepository : IRepository<Laboratory>
    {
        IQueryable<Laboratory> GetLaboratoriesWithoutIcon();
    }
    public class LaboratoriesRepository : Repository<Laboratory>, ILaboratoriesRepository
    {
        public LaboratoriesRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {
        }

        public IQueryable<Laboratory> GetLaboratoriesWithoutIcon()
        {
            var query= (from labo in _entities
                    select new Laboratory()
                    {
                        Active=labo.Active,
                        Color=labo.Color,
                        CreatedBy=labo.CreatedBy,
                        CreatedDate=labo.CreatedDate,
                        IconType=labo.IconType,
                        UpdatedBy=labo.UpdatedBy,
                        UpdatedDate=labo.UpdatedDate,
                        Id=labo.Id,
                        Name=labo.Name
                    });
            return query;
        }
    }
}
