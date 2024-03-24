using System;
using Microsoft.EntityFrameworkCore;
using SmartProject.Domain.Common;
using SmartProject.Domain.Features;
using SmartProject.Infrastructure.Configurations;

namespace SmartProject.Infrastructure
{
	public sealed class SmartDbContext : DbContext, ISmartDbContext
	{
        public SmartDbContext(DbContextOptions<SmartDbContext> options)
             : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<DomainEvent>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);
        }
    }
}

