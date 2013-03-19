using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Promob.Entities.ERP
{
    [DataContract]
    public class SubGroup
    {
        #region Properties
        [DataMember]
        public string SubGroupId { get; set; }
        [DataMember]
        public string Name { get; set; }

        #endregion
    }
}