using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Promob.Entities.ERP;

namespace Promob.Entities.ERPConfiguration
{
    public class ERPProductConfiguration : EntityTypeConfiguration<ERPProduct>
    {
        public ERPProductConfiguration()
        {
            this.ToTable("View_Products");

            this.HasKey(e => e.ProductKey);

            this.Property(e => e.ProductID)
                .HasColumnName("productID");

            this.Property(e => e.ProductKey)
                .HasColumnName("productKey");

            this.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            this.Property(e => e.Library)
                .HasColumnName("library")
                .IsOptional();

            this.Property(e => e.PromobVersion)
                .HasColumnName("promobVersion")
                .IsOptional();

            this.Property(e => e.DeveloperId)
                .HasColumnName("developerID")
                .IsOptional();

            this.Property(e => e.ProductType)
                .HasColumnName("productType")
                .IsRequired();

            this.HasOptional(e => e.SubGroup)
                .WithMany()
                .Map(m => m.MapKey("subGroupID"));

            this.Property(e => e.GroupId)
                .HasColumnName("groupID")
                .IsRequired();

            this.Property(e => e.IsWildcardProduct)
                .HasColumnName("isWildcardProduct");

            this.Property(e => e.WildcardProductKey)
                .HasColumnName("wildcardProductKey")
                .IsOptional();

            this.Property(e => e.IsOptionalCATS)
                .HasColumnName("optionalCats")
                .IsRequired();

            this.Property(e => e.Active)
                .HasColumnName("Active")
                .IsOptional();

            this.Property(e => e.ProcadUpdateVersion)
                .IsOptional();
        }
    }
}
