using System;

namespace Promob.Entities.Identity
{
    public class TicketUsage
    {
        #region Properties

        public Guid TicketUsageID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ComputerName { get; set; }
        public string ComputerIP { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
        
        #endregion

        #region Constructor

        public TicketUsage()
        {
        }

        #endregion
    }
}