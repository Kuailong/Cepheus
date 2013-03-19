using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class PublicationConfiguration : EntityTypeConfiguration<Publication>
    {
        public PublicationConfiguration()
        {
            this.ToTable("Publications");

            this.HasKey(e => e.PublicationId);

            this.Property(e => e.PublicationDate)
                .IsRequired();

            this.Property(e => e.Active)
                .IsRequired();

            this.Property(e => e.Deleted)
                .IsRequired();
            
            this.Property(e => e.Description)
                .HasMaxLength(200)
                .IsRequired();

            this.Property(e => e.StorageUri)
                .HasMaxLength(200)
                .IsRequired();

            this.Property(e => e.StorageRelativeFilesPath)
                .HasMaxLength(200)
                .IsRequired();

            this.Property(e => e.Version)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(e => e.Lenght)
                .HasMaxLength(50)
                .IsOptional();
            
            this.HasRequired(e => e.Component)
                .WithMany()
                .HasForeignKey(e => e.ComponentId);

            this.HasMany(e => e.PublicationLibraries)
                .WithRequired(e => e.Publication)
                .HasForeignKey(e => e.PublicationId);

            this.Ignore(e => e.FilesPathUri);
            this.Ignore(e => e.PackagePathUri);
        }
    }
}
