using Microsoft.AspNetCore.Http;
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
    public interface IProductsRepository:IRepository<Product>
    {
        List<Product> GetByLaboratory(long id);
    }
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        public ProductsRepository(MCADbContext db, IHttpContextAccessor httpAccessor) : base(db, httpAccessor)
        {

        }

        public List<Product> GetByLaboratory(long id)
        {
            return this.Query().Where(x=>x.LaboratoryId==id).ToList();
        }
    }
}
