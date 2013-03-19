using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.Identity.Configurations
{
    public class TicketUsageConfiguration : EntityTypeConfiguration<TicketUsage>
    {
        #region Constructor

        public TicketUsageConfiguration()
        {
            this.ToTable("TicketsUsage");

            this.HasKey(t => t.TicketUsageID)
                .Property(t => t.TicketUsageID)
                .HasColumnName("TicketUsageID");

            this.HasRequired(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserID);
        }

        #endregion
    }
}