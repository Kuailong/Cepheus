using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class TransactionDataConfiguration : EntityTypeConfiguration<TransactionData>
    {
        public TransactionDataConfiguration()
        {
            this.ToTable("TransactionData");

            this.HasKey(e => e.TransactionDataId);

            this.Property(e => e.TransactionDataId)
                .HasColumnName("TransactionDataID");

            this.HasRequired(e => e.Transaction)
                .WithMany()
                .Map(m => m.MapKey("TransactionID"));

            this.HasRequired(e => e.InformationType)
                .WithMany()
                .Map(m => m.MapKey("InformationTypeID"));
        }
    }
}
