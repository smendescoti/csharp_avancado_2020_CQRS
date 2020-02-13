using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.InfraStructure.Data.Configurations
{
    public class ProductConfiguration
        : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(map => map.Id);

            builder.HasOne(map => map.Stock)
                .WithMany(map => map.Products)
                .HasForeignKey(map => map.StockId);
        }
    }
}
