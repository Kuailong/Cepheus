using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities.Configurations
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            this.ToTable("Users");

            this.HasKey(e => e.NameUser);

            this.Property(e => e.Key)
                .IsRequired();
        }
    }
}
