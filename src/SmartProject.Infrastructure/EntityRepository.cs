using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartProject.Domain;
using SmartProject.Domain.Common;

namespace SmartProject.Infrastructure
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ISmartDbContext _context;
        private readonly DbSet<TEntity> _entitySet;

        public EntityRepository(ISmartDbContext context)
        {
            _context = context;
            _entitySet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Table => this._entitySet; 

        public IQueryable<TEntity> GetAll(bool noTracking = true)
        {
            var set = _entitySet;

            if(noTracking)
                return set.AsNoTracking();

            return set;
        }

        public TEntity? GetById(long id)
        {
            return _entitySet.Find(id);
        }

        public async Task<TEntity?> GetByIdAsync(long id)
        {
            return await _entitySet.FindAsync(id);
        }

        public IEnumerable<TEntity> GetByIds(IEnumerable<long> ids)
        {
            return _entitySet.Where(x => ids.Contains(x.Id)).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<long> ids)
        {
            return await _entitySet.Where(x => ids.Contains(x.Id)).AsNoTracking().ToListAsync();
        }

        public void Insert(TEntity entity)
        {
            _entitySet.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            _entitySet.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _entitySet.Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            _entitySet.RemoveRange(entities);
        }
    }
}

