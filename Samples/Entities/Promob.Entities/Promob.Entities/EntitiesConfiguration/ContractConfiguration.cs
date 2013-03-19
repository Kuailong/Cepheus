using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class ContractConfiguration : EntityTypeConfiguration<Contract>
    {
        public ContractConfiguration()
        {
            this.ToTable("View_ContractsLicensesService");

            this.HasKey(e => e.SerialNumber);

            this.Property(e => e.ContractId)
                .HasColumnName("contractID")
                .IsRequired();

            this.Property(e => e.ContractItemId)
                .HasColumnName("contractItemID")
                .IsRequired();

            this.Property(e => e.CATSStatus)
                .HasColumnName("catsStatus")
                .IsRequired();

            this.Property(e => e.ProductType)
                .HasColumnName("productType")
                .IsRequired();

            this.Property(e => e.StartDate)
                .HasColumnName("startDate")
                .IsOptional();

            this.Property(e => e.EndDate)
                .HasColumnName("endDate")
                .IsOptional();

            this.Property(e => e.IsActive)
                .HasColumnName("activeContract")
                .IsOptional();

            this.Property(e => e.IsCancelled)
                .HasColumnName("cancelledContract")
                .IsOptional();

            this.Property(e => e.TerminateReason)
                .HasColumnName("terminateReason")
                .IsOptional();

            this.Property(e => e.FactorySerialNumber)
                .HasColumnName("factorySerialNumber")
                .IsOptional();

            this.Property(e => e.CancellationId)
                .HasColumnName("cancellationID")
                .IsRequired();

            this.Property(e => e.CancellationReason)
                .HasColumnName("cancellationReason")
                .IsOptional();

            this.Property(e => e.LicenseUserId)
                .HasColumnName("licenseUserID")
                .IsOptional();

            this.Property(e => e.ERPProductKey)
                .HasColumnName("ContractProductKey")
                .IsOptional();

            this.Property(e => e.ERPProductID)
                .HasColumnName("productID")
                .IsOptional();

            this.Property(e => e.ChargeContract)
                .HasColumnName("chargeContract")
                .IsRequired();

            this.Property(e => e.AccountId)
                .HasColumnName("accountID")
                .IsOptional();

            this.Property(e => e.IsOptionalCATS)
                .HasColumnName("optionalCATS")
                .IsOptional();

            this.HasRequired(e => e.License)
                .WithMany()
                .HasForeignKey(e => e.LicenseSerialNumber);
        }
    }
}
