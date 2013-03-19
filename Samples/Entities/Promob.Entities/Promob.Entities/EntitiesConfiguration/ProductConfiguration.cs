using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            this.ToTable("PortalProduct");

            this.HasKey(e => e.ProductId);

            this.Property(e => e.ProductId)
                .HasColumnName("productID");

            this.Property(e => e.Name)
                .HasColumnName("description")
                .HasMaxLength(200)
                .IsRequired();

            this.Property(e => e.ProductKey)
                .HasColumnName("productKeyRmDefault")
                .IsOptional();

            this.Property(e => e.IsActive)
                .HasColumnName("active")
                .IsRequired();

            this.Property(e => e.IsContract)
                .HasColumnName("isContract")
                .IsRequired();

            this.Property(e => e.ImageThumb)
                .HasColumnName("imageThumb")
                .HasMaxLength(250)
                .IsOptional();

            this.Property(e => e.ImageBig)
                .HasColumnName("imageBig")
                .HasMaxLength(250)
                .IsOptional();

            this.HasOptional(e => e.ERPProduct)
                .WithMany()
                .HasForeignKey(e => e.ProductKey);

            this.HasMany(e => e.ProductUseRights)
                .WithRequired(e => e.ProductUseRight)
                .HasForeignKey(e => e.UseRightProductId);

            this.Ignore(e => e.ProductComponents);
            //this.Ignore(e => e.ProductsUseRight);
            this.Ignore(e => e.ImageBigAbsoluteUri);
            this.Ignore(e => e.ImageThumbAbsoluteUri);
        }
    }
}
