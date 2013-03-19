using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities
{
    [DataContract]
    public class ComponentCriteria
    {
        #region Properties

        [DataMember]
        public int ComponentCriteriaId { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int SubGroupId { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public bool IsHignRelevant { get; set; }

        [DataMember]
        public int PublicationId { get; set; }

        [DataMember]
        public virtual Publication Publication { get; set; }

        #endregion
    }
}
