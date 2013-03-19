using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class GeneralComponentConfiguration : EntityTypeConfiguration<GeneralComponent>
    {
        public GeneralComponentConfiguration()
        {
            this.Map(m => m.Requires("Type").HasValue("General"))
                .ToTable("Components");
        }
    }
}
