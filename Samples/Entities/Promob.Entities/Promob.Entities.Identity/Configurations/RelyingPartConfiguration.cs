using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.Identity.Configurations
{
    public class RelyingPartConfiguration : EntityTypeConfiguration<RelyingPart>
    {
        #region Constructor

        public RelyingPartConfiguration()
        {
            this.ToTable("RelyingParts");

            this.HasKey(rp => rp.RelyingPartID)
                .Property(rp => rp.RelyingPartID)
                .HasColumnName("RelyingPartID");
        }

        #endregion
    }
}