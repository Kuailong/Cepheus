using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Promob.Entities
{
    [DataContract]
    public class PublicationsComponentsCompatibilities
    {
        [DataMember]
        public int CompatibilityId { get; set; }
        [DataMember]
        public int PublicationId { get; set; }
        [DataMember]
        public virtual Publication Publication { get; set; }
        [DataMember]
        public int CompatibleComponentId { get; set; }
        [DataMember]
        public virtual Component Component { get; set; }
        [DataMember]
        public string CompatibilityVersion { get; set; }
    }
}
