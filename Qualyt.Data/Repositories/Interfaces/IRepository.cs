using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Qualyt.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        bool HasRole(string role);
        string GetUserId();

        void Remove(TEntity entity);
        void Remove(long id);
        void RemoveRange(IEnumerable<TEntity> entities);

        long Count();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Query();

        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(long id);
        Task SaveChangesAsync();
    }

}
