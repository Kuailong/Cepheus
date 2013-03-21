using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities.Configurations
{
    public class DeveloperConfig : EntityTypeConfiguration<Developer>
    {
        public DeveloperConfig()
        {
            this.ToTable("Developers");

            this.HasKey(e => e.DeveloperId);

            this.Property(e => e.Name)
                .IsRequired();

            this.Property(e => e.Description)
                .IsRequired();

            this.HasMany(e => e.Games)
                .WithRequired(e => e.Developer)
                .HasForeignKey(e => e.DeveloperId);

        }
    }
}
