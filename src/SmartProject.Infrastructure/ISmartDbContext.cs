using System;
using Microsoft.EntityFrameworkCore;
using SmartProject.Domain.Features;

namespace SmartProject.Infrastructure
{
	public interface ISmartDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<Order> Orders { get; set; }
    }
}

