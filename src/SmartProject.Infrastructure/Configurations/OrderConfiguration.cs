using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartProject.Domain.Features;

namespace SmartProject.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.Id).IsRequired();

            builder.Property(e => e.CustomerId).IsRequired();

            builder.Property(e => e.ProductId).IsRequired();

            builder.Property(e => e.Quantity).IsRequired();

            builder.Property(e => e.Amount).IsRequired();

            builder.Property(e => e.OrderDate).IsRequired();
        }
    }
}

