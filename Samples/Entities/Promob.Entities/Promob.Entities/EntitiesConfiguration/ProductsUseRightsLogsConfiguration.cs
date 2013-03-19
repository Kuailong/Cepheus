using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Promob.Entities.EntitiesConfiguration
{
    public class ProductsUseRightsLogsConfiguration : EntityTypeConfiguration<ProductsUseRightsLog>
    {
        public ProductsUseRightsLogsConfiguration ()
	    {
            this.ToTable("ProductsUseRightsLogs");

            this.HasKey(e => e.ProductsUseRightLogId);

            this.Property(e => e.ProductsUseRightId)
                .IsRequired();

            this.Property(e => e.AccountId)
                .IsOptional();

            this.Property(e => e.SubGroupId)
                .IsOptional();

            this.Property(e => e.ProductId)
                .IsOptional();

            this.Property(e => e.UseRightProductId)
                .IsRequired();

            this.Property(e => e.Action)
                .IsRequired();

            this.Property(e => e.Date)
                .IsRequired();
	    }
        
    }
}
