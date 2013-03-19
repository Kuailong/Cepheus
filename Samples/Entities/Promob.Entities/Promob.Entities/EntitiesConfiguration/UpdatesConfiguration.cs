using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Promob.Entities.EntitiesConfiguration
{
    public class UpdatesConfiguration : EntityTypeConfiguration<Updates>
    {
        public UpdatesConfiguration()
        {
            this.ToTable("Updates");

            this.HasKey(e => e.Id);

            this.Property(e => e.SerialNumber)
                .IsRequired();

            this.Property(e => e.UpdateDate)
                .IsRequired();

            this.Property(e => e.PublicationVersion)
                .IsRequired();

            this.Property(e => e.ComponentId)
                .IsRequired();

            this.Property(e => e.AccountId)
                .IsRequired();

            this.Property(e => e.LibraryId)
                .IsRequired();

        }
    }
}
