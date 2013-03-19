using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Promob.Entities.Enums;

namespace Promob.Entities
{
    [DataContract]
    public class ComponentType
    {
        #region Properties
        [DataMember]
        public int ComponentTypeId { get; set; }
        [DataMember]
        public int MaxPublications { get; set; }
        [DataMember]
        public eComponentType eComponentType
        {
            get
            {
                return (eComponentType)Enum.ToObject(typeof(eComponentType), ComponentTypeId);
            }
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool RequiresCompatibility { get; set; }
        [DataMember]
        public bool IsVisibleOnUI { get; set; }
        [DataMember]
        public virtual ICollection<Component> Components { get; set; }

        #endregion
    }
}
