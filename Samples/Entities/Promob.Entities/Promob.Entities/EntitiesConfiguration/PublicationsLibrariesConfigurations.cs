using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Promob.Entities.EntitiesConfiguration
{
    public class PublicationsLibrariesConfigurations : EntityTypeConfiguration<PublicationLibrary>
    {
        public PublicationsLibrariesConfigurations()
        {
            this.ToTable("PublicationsLibraries");

            this.HasKey(e => e.PublicationLibraryId);

            this.Property(e => e.Name)
                .IsRequired();

            this.Property(e => e.Revision)
                .IsRequired();

            this.Property(e => e.Version)
                .IsRequired();

            this.HasRequired(e => e.Publication)
                .WithMany()
                .HasForeignKey(e => e.PublicationId);
        }
    }
}
