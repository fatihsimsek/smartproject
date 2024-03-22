using System;
using SmartProject.Domain.Features;

namespace SmartProject.Infrastructure.Features
{
    public class OrderRepository : EntityRepository<Order>
    {
        public OrderRepository(ISmartDbContext context) : base(context)
        {
        }
    }
}

