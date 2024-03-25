using System;
using Microsoft.EntityFrameworkCore;
using SmartProject.Domain.Features;

namespace SmartProject.Infrastructure
{
	public interface ISmartDbContext
    {
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<Order> Orders { get; set; }
    }
}

