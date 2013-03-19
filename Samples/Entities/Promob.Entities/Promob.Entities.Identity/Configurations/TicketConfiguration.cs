using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.Identity.Configurations
{
    public class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        #region Constructor

        public TicketConfiguration()
        {
            this.ToTable("Tickets");

            this.HasKey(t => t.TicketID)
                .Property(t => t.TicketID)
                .HasColumnName("TicketID");

            this.HasRequired(t => t.Account)
                .WithMany()
                .HasForeignKey(t => t.AccountID);

            this.HasOptional(t => t.Usage)
                .WithMany()
                .HasForeignKey(t => t.TicketUsageID);

            this.Ignore(t => t.Status);
        }

        #endregion
    }
}