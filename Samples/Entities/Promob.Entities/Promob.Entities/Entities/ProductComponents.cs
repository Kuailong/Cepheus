using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Promob.Entities
{
    [DataContract]
    public class ProductComponents
    {
        #region Properties

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductKey { get; set; }

        [DataMember]
        public bool IsExportToRm { get; set; }

        [DataMember]
        public DateTime StartRelationDate { get; set; }

        [DataMember]
        public DateTime? EndRelationDate { get; set; }

        [DataMember]
        public int ProductComponentId { get; set; }

        [DataMember]
        public Product ProductComponent { get; set; }

        #endregion
    }
}