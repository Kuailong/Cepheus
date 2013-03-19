using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Promob.Entities.EntitiesConfiguration
{
    public class FileConfiguration : EntityTypeConfiguration<File>
    {
        public FileConfiguration()
        {
            this.ToTable("Files");

            this.HasKey(e => e.MD5);
        }
    }
}
