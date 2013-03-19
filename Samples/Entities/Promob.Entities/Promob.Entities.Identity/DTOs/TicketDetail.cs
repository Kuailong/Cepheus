using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Promob.Entities.Identity.Enums;

namespace Promob.Entities.Identity.DTOs
{
    public class TicketDetail
    {
        public int TicketID { get; set; }
        public eTicketStatus TicketStatus { get; set; }
        public Nullable<DateTime> StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }
        public int UserID { get; set; }
        public string ComputerName { get; set; }
        public string ComputerIP { get; set; }
    }
}