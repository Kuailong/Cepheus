using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities.Configurations
{
    public class TypesConfig : EntityTypeConfiguration<Types>
    {
        public TypesConfig()
        {
            this.ToTable("Types");

            this.HasKey(e => e.TypeId);

            this.Property(e => e.Description)
                .IsRequired();

            this.Property(e => e.Name)
                .IsRequired();
        }
    }
}
