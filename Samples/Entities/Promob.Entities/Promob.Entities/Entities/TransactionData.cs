using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities
{
    [DataContract]
    public class TransactionData
    {
        #region Properties

        [DataMember]
        public int TransactionDataId { get; set; }

        [DataMember]
        public string Information { get; set; }

        [DataMember]
        public virtual Transaction Transaction { get; set; }

        [DataMember]
        public virtual TransactionInformationType InformationType { get; set; }

        #endregion
    }
}