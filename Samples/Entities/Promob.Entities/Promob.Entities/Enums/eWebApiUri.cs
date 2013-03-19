using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities.Enums
{
    [DataContractAttribute]
    public enum eWebApiUri
    {
        [EnumMember]
        Contract,
        [EnumMember]
        Product,
        [EnumMember]
        ERPProduct
    }
}