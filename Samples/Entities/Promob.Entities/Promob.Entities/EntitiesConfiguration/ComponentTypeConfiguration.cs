using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class ComponentTypeConfiguration : EntityTypeConfiguration<ComponentType>
    {
        public ComponentTypeConfiguration()
        {
            this.ToTable("ComponentTypes");

            this.HasKey(e => e.ComponentTypeId);

            this.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(e => e.MaxPublications)
                .IsRequired();

            this.Property(e => e.RequiresCompatibility)
                .IsRequired();

            this.Property(e => e.IsVisibleOnUI)
                .HasColumnName("VisibleOnUI")
                .IsOptional();

            this.HasMany(e => e.Components)
                .WithRequired(e => e.ComponentType)
                .HasForeignKey(e => e.ComponentTypeId);

            this.Ignore(e => e.eComponentType);
        }
    }
}
