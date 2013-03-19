using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfiguration()
        {
            this.ToTable("Transactions");

            this.HasKey(e => e.TransactionId);

            this.Property(e => e.TransactionId)
                .HasColumnName("TransactionID");

            this.Property(e => e.TransactionDate)
                .IsRequired();

            this.Property(e => e.UserTransaction)
                .IsOptional();

            this.HasRequired(e => e.TransactionType)
                .WithMany()
                .Map(m => m.MapKey("TransactionTypeID"));

            this.HasMany(e => e.TransactionData)
                .WithRequired(f => f.Transaction)
                .Map(m => m.MapKey("TransactionID"));

            this.HasRequired(e => e.License)
                .WithMany()
                .HasForeignKey(f => f.SerialNumber);
        }
    }
}
