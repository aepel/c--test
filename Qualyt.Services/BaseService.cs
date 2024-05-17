using Qualyt.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Remove(long id);
        List<TEntity> GetAll();
        TEntity GetById(long id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        IQueryable<TEntity> Query();
    }
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected IRepository<TEntity> repo;
        public BaseService(IRepository<TEntity> _repo)
        {
            repo = _repo;
        }
        public virtual void Add(TEntity entity)
        {
            repo.Add(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public virtual TEntity GetById(long id)
        {
            return repo.Get(id);
        }

        public virtual IQueryable<TEntity> Query()
        {
            return repo.Query();
        }

        public virtual void Remove(long id)
        {
            repo.Remove(id);
        }

        public virtual void Update(TEntity entity)
        {
            repo.Update(entity);
        }
    }
}
