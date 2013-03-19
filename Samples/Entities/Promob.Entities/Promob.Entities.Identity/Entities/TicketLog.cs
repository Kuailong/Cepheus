using System;

namespace Promob.Entities.Identity
{
    public class TicketLog
    {
        #region Properties

        public int TicketLogID { get; set; }
        public string Library { get; set; }
        public int ProductID { get; set; }
        public string ComputerName { get; set; }
        public string ComputerIP { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int AccountID { get; set; }
        public virtual Account Account { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Constructor

        public TicketLog()
        {

        }

        #endregion
    }
}