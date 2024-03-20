using System;
using Microsoft.EntityFrameworkCore;

namespace SmartProject.Infrastructure
{
	public sealed class SmartDbContext : DbContext
	{
        public SmartDbContext(DbContextOptions<SmartDbContext> options)
             : base(options)
        {
        }
    }
}

