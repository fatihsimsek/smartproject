using System;
using Microsoft.EntityFrameworkCore;
using SmartProject.Domain.Features;

namespace SmartProject.Infrastructure
{
	public sealed class SmartDbContext : DbContext, ISmartDbContext
	{
        public SmartDbContext(DbContextOptions<SmartDbContext> options)
             : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}

