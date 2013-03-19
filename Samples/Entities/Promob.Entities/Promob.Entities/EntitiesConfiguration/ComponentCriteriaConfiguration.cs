using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class ComponentCriteriaConfiguration : EntityTypeConfiguration<ComponentCriteria>
    {
        public ComponentCriteriaConfiguration()
        {
            this.ToTable("ComponentCriterias");

            this.HasKey(e => e.ComponentCriteriaId);

            this.HasRequired(e => e.Publication)
                .WithMany()
                .HasForeignKey(e => e.PublicationId);

            this.Property(e => e.IsHignRelevant)
                .HasColumnName("HighRelevant")
                .IsRequired();
        }
    }
}
