using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class ComponentConfiguration : EntityTypeConfiguration<Component>
    {
        public ComponentConfiguration()
        {
            this.ToTable("Components");

            this.HasKey(e => e.ComponentId);

            this.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            this.HasRequired(e => e.ComponentType)
                .WithMany()
                .HasForeignKey(e => e.ComponentTypeId);

            this.HasMany(e => e.Publications)
                .WithRequired(e => e.Component)
                .HasForeignKey(e => e.ComponentId);
        }
    }
}
