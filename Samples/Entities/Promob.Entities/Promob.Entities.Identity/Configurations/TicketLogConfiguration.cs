using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.Identity.Configurations
{
    public class TicketLogConfiguration : EntityTypeConfiguration<TicketLog>
    {
        #region Constructor

        public TicketLogConfiguration()
        {
            this.ToTable("TicketsLogs");

            this.HasKey(t => t.TicketLogID)
                .Property(t => t.TicketLogID)
                .HasColumnName("TicketLogID");

            this.HasRequired(t => t.Account)
                .WithMany()
                .HasForeignKey(t => t.AccountID);

            this.HasRequired(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserID);
        }

        #endregion
    }
}