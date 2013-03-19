using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class TransactionTypeConfiguration : EntityTypeConfiguration<TransactionType>
    {
        public TransactionTypeConfiguration()
        {
            this.ToTable("TransactionType");

            this.HasKey(e => e.TransactionTypeId);

            this.Property(e => e.TransactionTypeId)
                .HasColumnName("TransactionTypeID");

            this.Property(e => e.Description)
                .IsRequired();
        }
    }
}
