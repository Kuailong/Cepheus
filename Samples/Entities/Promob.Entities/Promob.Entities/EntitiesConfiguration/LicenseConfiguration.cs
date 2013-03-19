using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class LicenseConfiguration : EntityTypeConfiguration<License>
    {
        public LicenseConfiguration()
        {
            this.ToTable("Licenses");

            this.HasKey(l => l.SerialNumber);

            this.Property(l => l.ERPProductId)
                .HasColumnName("ProductID")
                .IsRequired();

            this.Property(l => l.LastUpdate)
                .IsOptional();

            this.Property(l => l.ComputerName)
                .IsOptional();

            this.Property(l => l.PostponedEndDate)
                .HasColumnName("EndDatePostponed")
                .IsOptional();

            this.Property(l => l.ProductCode)
                .IsOptional();

            this.Property(l => l.IsSuspendedByFactory)
                .HasColumnName("SuspendedFactory")
                .IsOptional();

            this.Property(l => l.SuspensionReason)
                .IsOptional();

            this.Property(l => l.SuspensionDate)
                .IsOptional();

            this.Property(l => l.StatusID)
                .HasColumnName("StatusID")
                .IsOptional();

            this.Property(l => l.ActivationCode)
                .IsOptional();

            this.Property(l => l.FactorySerialNumber)
                .IsOptional();

            this.Property(l => l.VerificationDate)
                .IsOptional();

            this.Property(l => l.LastChangeOfSituation)
                .IsOptional();

            this.HasMany(l => l.Transactions)
                .WithRequired(l => l.License)
                .HasForeignKey(f => f.SerialNumber);

            this.HasRequired(l => l.CurrentContract)
                .WithMany()
                .HasForeignKey(l => l.ContractSerialNumber);

            this.Ignore(l => l.LicenseStatus);
            this.Ignore(l => l.Situation);
        }
    }
}