using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Qualyt.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MCADbContext _context;
        protected readonly DbSet<TEntity> _entities;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public Repository(MCADbContext context,
            IHttpContextAccessor httpAccessor)
        {
            _httpContextAccessor = httpAccessor;
            _context = context;
            _entities = context.Set<TEntity>();
            _context.CurrentUserId = httpAccessor?.HttpContext?.User?.Identities?.FirstOrDefault()?.FindFirst("sub")?.Value;
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
            _context.SaveChanges();
        }


        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
            _context.SaveChanges();
        }



        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Remove(long id)
        {
            _entities.Remove(Get(id));
            _context.SaveChanges();
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
            _context.SaveChanges();
        }


        public virtual long Count()
        {
            return _entities.Count();
        }


        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public virtual TEntity Get(long id)
        {
            return _entities.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public virtual IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public bool HasRole(string role)
        {
            var user = _context.ApplicationUsers.Include(x=>x.Roles).FirstOrDefault(x => x.Id == _context.CurrentUserId);
            return user.Roles.Any(x => x.RoleId == _context.Roles.FirstOrDefault(y => y.NormalizedName == role)?.Id);
        }

        public string GetUserId()
        {
            return _context.CurrentUserId;
        }

        public Task<List<TEntity>> GetAllAsync() => _entities.ToListAsync();

        public Task<TEntity> GetByIdAsync(long id)
        {
            return this._entities.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await this._context.Set<TEntity>().AddAsync(entity);
            await this.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this._context.Set<TEntity>().Update(entity);
            await this.SaveChangesAsync();
        }

        public async Task RemoveAsync(long id)
        {
            TEntity entity = this.Get(id);
            this._context.Set<TEntity>().Remove(entity);
            await this.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}   
