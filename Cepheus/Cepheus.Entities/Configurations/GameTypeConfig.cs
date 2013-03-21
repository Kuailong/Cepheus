using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities.Configurations
{
    public class GameTypeConfig : EntityTypeConfiguration<GameType>
    {
        public GameTypeConfig()
        {
            this.ToTable("GameTypes");

            this.HasKey(e => e.GameTypeId);

            this.Property(e => e.Description)
                .IsRequired();

            this.Property(e => e.Type)
                .IsRequired();
        }
    }
}
