using AllupOnion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllupOnion.Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ProductCode).IsRequired().HasColumnType("char(10)");
            builder.Property(p => p.IsAvailable).IsRequired();
            builder.Property(p=>p.Price).IsRequired().HasColumnType("decimal(6,2)");
        }
    }
}
