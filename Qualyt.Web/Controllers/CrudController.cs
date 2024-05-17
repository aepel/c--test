using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qualyt.Services;
using Qualyt.Web.Helpers;
using Qualyt.Web.Validators;

namespace Qualyt.Web.Controllers
{
    [ValidateModel]
    public abstract class CrudController<T> : DatatableController<T> where T:class
    {
        public CrudController(IQueryable<T> queryable, IBaseService<T> baseService):base(queryable)
        {
            this._service = baseService;
        }

        private IBaseService<T> _service;

        [HttpGet("[action]")]
        public virtual IEnumerable<T> Get()
        {
            return _service.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public T Get(long id)
        {
            var objeto = _service.GetById(id);
            return objeto;
        }

        [HttpPost("[action]")]
        public virtual T Post([FromBody] T value)
        {
            _service.Add(value);
            return value;
        }

        [HttpPut("[action]")]
        public virtual void Put([FromBody] T value)
        {
            _service.Update(value);
        }

        [HttpDelete("[action]/{id}")]
        public void Delete(long id)
        {
            try
            {
                _service.Remove(id);
            }
            catch(Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("CONSTRAINT"))
                    ModelState.AddModelError("", "No se puede borrar porque existen entidades relacionadas con esta.");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado.");
            }
        }

    }

}