using System;
using Promob.Entities.Identity.Enums;

namespace Promob.Entities.Identity
{
    public class Ticket
    {
        #region Properties

        public int TicketID { get; set; }
        public string Library { get; set; }
        public int ProductID { get; set; }

        public Guid? TicketUsageID { get; set; }
        public virtual TicketUsage Usage { get; set; }

        public int AccountID { get; set; }
        public virtual Account Account { get; set; }

        public eTicketStatus Status
        {
            get
            {
                if (this.TicketUsageID.HasValue && this.TicketUsageID.Value != Guid.Empty)
                    return eTicketStatus.InUse;
                else
                    return eTicketStatus.Free;
            }
        }

        #endregion

        #region Constructor

        public Ticket()
        {

        }

        #endregion
    }
}