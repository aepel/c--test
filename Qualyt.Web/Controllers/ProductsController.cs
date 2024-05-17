using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Validation;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.Laboratories.Enums;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Services.Services;
using Qualyt.Web.Helpers;
using Qualyt.Web.Validators;
using Qualyt.Web.ViewModels;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class ProductsController : DatatableController<Product>
    {
        private IProductsService _service;
        public ProductsController(IProductsService service) : base(service.Query().Include(x => x.Laboratory))
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public virtual IEnumerable<Product> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("[action]/{id}")]
        public Product Get(long id)
        {
            var objeto = _service.GetById(id);
            return objeto;
        }

        [HttpPost("[action]")]
        public virtual ProductViewModel Post([FromBody] ProductViewModel value)
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            Product product;
            if (value.ProductType == ProductType.Medicine)
                product = mapper.Map<Medicine>(value);
            else
                product = mapper.Map<Device>(value);
            _service.Add(product);
            return value;
        }

        [HttpPut("[action]")]
        public virtual void Put([FromBody] ProductViewModel value)
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            Product product;
            if (value.ProductType == ProductType.Medicine)
            {
                product = mapper.Map<Medicine>(value);
            }
            else
                product = mapper.Map<Device>(value);
            _service.Update(product);
        }

        [HttpDelete("[action]/{id}")]
        public void Delete(long id)
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

        public override Expression<Func<Product, bool>> Filter(string filterValue)
        {
            return (x) => 
                RemoveDiacritics(x.Name.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.Laboratory.Name.ToLower()).Contains(filterValue)
                || (x is Medicine? RemoveDiacritics(((Medicine)x).ActiveSubstance.ToLower()).Contains(filterValue): RemoveDiacritics(((Device)x).DeviceType.ToLower()).Contains(filterValue))
                ;
        }

        public override Expression<Func<Product, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "name": return (x) => x.Name;
                case "laboratory.name": return (x) => x.Laboratory.Name;
                case "activeSubstance": return (x) => ((Medicine)x).ActiveSubstance;
                case "deviceType": return (x) => ((Device)x).DeviceType;
                default: return (x) => x.Name;
            }
        }
    }
}
