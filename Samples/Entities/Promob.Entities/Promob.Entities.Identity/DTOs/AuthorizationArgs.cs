using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities.Identity.DTOs
{
    [DataContract]
    public struct AuthorizationArgs
    {
        [DataMember]
        public string Library { get; set; }
        [DataMember]
        public string ComputerName { get; set; }
        [DataMember]
        public string ComputerIP { get; set; }
        [DataMember]
        public Guid AccessTicketId { get; set; }
        [DataMember]
        public Nullable<int> AccountId { get; set; }
    }
}
