using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.Identity.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        #region Constructor

        public UserConfiguration()
        {
            this.ToTable("Users");

            this.HasKey(u => u.UserID)
                .Property(u => u.UserID)
                .HasColumnName("UserID");

            this.HasOptional(u => u.DefaultAccount)
                .WithMany()
                .HasForeignKey(u => u.DefaultAccountID);

            this.HasMany(u => u.Accounts)
                .WithMany(a => a.Users)
                .Map(m =>
                {
                    m.MapLeftKey("UserID");
                    m.MapRightKey("AccountID");
                    m.ToTable("UsersAccounts");
                });
        }

        #endregion
    }
}