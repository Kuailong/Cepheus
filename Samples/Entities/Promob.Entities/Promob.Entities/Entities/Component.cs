using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Promob.Entities
{
    [DataContract]
    public class Component
    {
        #region Properties

        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public int ComponentId { get; set; }

        [DataMember]
        public int ComponentTypeId { get; set; }

        [DataMember]
        public virtual ComponentType ComponentType { get; set; }

        [DataMember]
        public virtual ICollection<Publication> Publications { get; set; }

        #endregion
    }
}
