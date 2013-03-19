using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Promob.Entities.EntitiesConfiguration
{
    public class ProductComponentsConfiguration : EntityTypeConfiguration<ProductComponents>
    {
        public ProductComponentsConfiguration()
        {
            this.ToTable("PortalProductComponents");

            this.HasKey(e => new { e.ProductComponentId, e.ProductId });

            this.Property(e => e.StartRelationDate)
                .HasColumnName("startRelationDate")
                .IsRequired();

            this.Property(e => e.EndRelationDate)
                .HasColumnName("endRelationDate")
                .IsOptional();

            this.Property(e => e.IsExportToRm)
                .HasColumnName("exportToRM")
                .IsRequired();

            this.Property(e => e.ProductKey)
                .HasColumnName("productKeyRM")
                .IsOptional();

            this.Property(e => e.ProductId)
                .HasColumnName("productID")
                .IsRequired();

            this.Property(e => e.ProductComponentId)
                .HasColumnName("productComponentID")
                .IsRequired();

            this.HasRequired(e => e.ProductComponent)
                .WithMany()
                .HasForeignKey(e => e.ProductComponentId);
        }
    }
}
