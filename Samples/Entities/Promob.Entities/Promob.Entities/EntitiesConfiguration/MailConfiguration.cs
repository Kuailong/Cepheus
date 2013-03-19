using System.Data.Entity.ModelConfiguration;
using Promob.Entities;

namespace Promob.Entities.EntitiesConfiguration
{
    public class MailConfiguration : EntityTypeConfiguration<Mail>
    {
        #region Constructor

        public MailConfiguration()
        {
            this.ToTable("MailQueue");

            this.HasKey(m => m.MailID)
                .Property(m => m.MailID)
                .HasColumnName("Id");

            this.Ignore(m => m.CultureInfo);
            this.Ignore(m => m.MailTemplate);
            this.Ignore(m => m.MailPriority);
        }
       
        #endregion
    }
}