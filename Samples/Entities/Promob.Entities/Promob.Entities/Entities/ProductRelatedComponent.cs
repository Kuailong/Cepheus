using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities
{
    [DataContract]
    public class ProductRelatedComponent : Component
    {
        #region Properties

        [DataMember]
        public int ProductId { get; set; }

        #endregion
    }
}
