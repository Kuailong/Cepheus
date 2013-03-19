using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Promob.Entities
{
    [DataContract]
    public class Updates
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }
        [DataMember]
        public DateTime UpdateDate { get; set; }
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public string PublicationVersion { get; set; }
        [DataMember]
        public int AccountId { get; set; }
        [DataMember]
        public string LibraryId { get; set; }
    }
}
