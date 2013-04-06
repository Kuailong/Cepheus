using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities.Configurations
{
    public class GameAndTypeConfig : EntityTypeConfiguration<GameAndType>
    {
        public GameAndTypeConfig()
        {
            this.ToTable("GameAndTypes");

            this.HasKey(e => e.GameAndTypeId);

            this.HasRequired(e => e.Game)
                .WithMany()
                .HasForeignKey(e => e.GameId);

            this.HasRequired(e => e.GameType)
                .WithMany()
                .HasForeignKey(e => e.GameTypeId);
        }
    }
}
