using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Promob.Entities.ERP;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.ERPConfiguration
{
    public class SubGroupConfiguration : EntityTypeConfiguration<SubGroup>
    {
        public SubGroupConfiguration()
        {
            this.ToTable("View_SubGroups");

            this.HasKey(e => e.SubGroupId);
            this.Property(e => e.SubGroupId)
                .HasColumnName("subGroupID");

            this.Property(e => e.Name)
                .HasColumnName("description")
                .IsOptional();
        }
    }
}
