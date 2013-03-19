using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.Identity.Configurations
{
    public class PasswordRequestConfiguration : EntityTypeConfiguration<PasswordRequest>
    {
        #region Constructor

        public PasswordRequestConfiguration()
        {
            this.ToTable("PasswordRequests");

            this.HasKey(pr => pr.PasswordRequestID)
                .Property(pr => pr.PasswordRequestID)
                .HasColumnName("PasswordRequestID");

            this.HasRequired(pr => pr.User)
                .WithMany()
                .HasForeignKey(pr => pr.UserID);
        }

        #endregion
    }
}
