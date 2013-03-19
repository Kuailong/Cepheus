using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities
{
    [DataContract]
    public class Transaction
    {
        #region Properties

        [DataMember]
        public int TransactionId { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public DateTime TransactionDate { get; set; }
        
        [DataMember]
        public string UserTransaction { get; set; }

        [DataMember]
        public License License { get; set; }

        [DataMember]
        public virtual TransactionType TransactionType { get; set; }

        [DataMember]
        public virtual ICollection<TransactionData> TransactionData { get; set; }

        #endregion
    }
}