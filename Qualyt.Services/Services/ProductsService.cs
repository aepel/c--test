using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface IProductsService:IBaseService<Product>
    {
        List<Product> GetByLaboratory(long id);
    }
    public class ProductsService : BaseService<Product>, IProductsService
    {
        public ProductsService(IProductsRepository repository):base(repository)
        {

        }

        public List<Product> GetByLaboratory(long id)
        {
            return ((IProductsRepository)repo).GetByLaboratory(id);
        }
    }
}
