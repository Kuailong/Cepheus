using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Promob.Entities.EntitiesConfiguration
{
    public class ProductsUseRightConfiguration : EntityTypeConfiguration<ProductsUseRight>
    {
        public ProductsUseRightConfiguration()
        {
            this.ToTable("ProductsUseRights");

            this.HasKey(e => e.ProductsUseRightId);

            this.Property(e => e.AccountId)
                .IsOptional();

            this.Property(e => e.SubGroupId)
                .IsOptional();

            this.Property(e => e.ProductId)
                .IsOptional();

            this.Property(e => e.UseRightProductId)
                .IsRequired();

            this.HasRequired(e => e.ProductUseRight)
                .WithMany(e => e.ProductUseRights)
                .HasForeignKey(e => e.UseRightProductId);

            this.HasOptional(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId);
        }
    }
}
