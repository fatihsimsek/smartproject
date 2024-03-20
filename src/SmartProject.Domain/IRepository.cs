using System;
using System.Linq.Expressions;
using SmartProject.Domain.Common;

namespace SmartProject.Domain
{
	public interface IRepository<TEntity> where TEntity : Entity
	{
		Task<TEntity?> GetByIdAsync(long id);

		TEntity? GetById(long id);

		Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<long> ids);

        IEnumerable<TEntity> GetByIds(IEnumerable<long> ids);

        IQueryable<TEntity> GetAll(bool noTracking = true);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        IQueryable<TEntity> Table { get; }
    }
}

