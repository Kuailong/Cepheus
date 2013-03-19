using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.Identity.Configurations
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        #region Constructor

        public AccountConfiguration()
        {
            this.ToTable("Accounts");

            this.HasKey(a => a.AccountID)
                .Property(a => a.AccountID)
                .HasColumnName("AccountID");
        }

        #endregion
    }
}