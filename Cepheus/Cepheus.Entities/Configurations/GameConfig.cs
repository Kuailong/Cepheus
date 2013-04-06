using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities.Configurations
{
    public class GameConfig : EntityTypeConfiguration<Game>
    {
        public GameConfig()
        {
            this.ToTable("Games");

            this.HasKey(e => e.GameId);

            this.Property(e => e.Name)
                .IsRequired();

            this.Property(e => e.Image)
                .IsOptional();

            this.Property(e => e.Description)
                .IsOptional();

            this.HasRequired(e => e.Developer)
                .WithMany()
                .HasForeignKey(e => e.DeveloperId);

            this.HasMany(e => e.GameAndTypes)
                .WithRequired(e => e.Game)
                .HasForeignKey(e => e.GameId);
        }
    }
}
