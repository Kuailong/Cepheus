using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class TransactionInformationTypeConfiguration : EntityTypeConfiguration<TransactionInformationType>
    {
        public TransactionInformationTypeConfiguration()
        {
            this.ToTable("TransactionInformationType");

            this.HasKey(e => e.InformationTypeId);

            this.Property(e => e.InformationTypeId)
                .HasColumnName("InformationTypeID");

            this.Property(e => e.Description)
                .IsRequired();
        }
    }
}
