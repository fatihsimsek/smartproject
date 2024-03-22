using System;
using SmartProject.Domain.Features;

namespace SmartProject.Infrastructure.Features
{
    public class UserRepository : EntityRepository<User>
    {
        public UserRepository(ISmartDbContext context) : base(context)
        {
        }
    }
}

