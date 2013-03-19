using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Promob.Entities;

namespace Promob.Entities.EntitiesConfiguration
{
    public class PublicationsComponentsCompatibilitiesConfiguration : EntityTypeConfiguration<PublicationsComponentsCompatibilities>
    {
        public PublicationsComponentsCompatibilitiesConfiguration()
        {
            this.ToTable("PublicationsComponentsCompatibilities");

            this.HasKey(e => e.CompatibilityId);

            this.HasRequired(e => e.Publication)
                .WithMany()
                .HasForeignKey(e => e.PublicationId);

            this.HasRequired(e => e.Component)
                .WithMany()
                .HasForeignKey(e => e.CompatibleComponentId)
                .WillCascadeOnDelete(false);

            this.Property(e => e.CompatibilityVersion)
                .IsRequired();
        }
    }
}
