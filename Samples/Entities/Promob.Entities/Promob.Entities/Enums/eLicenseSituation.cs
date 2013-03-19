using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities.Enums
{
    [DataContractAttribute]
    public enum eLicenseSituation
    {
        [EnumMember]
        Active = 1,
        [EnumMember]
        Inactive = 2,
        [EnumMember]
        FreeForActivate = 3,
        [EnumMember]
        RequiresAttention = 4,
        [EnumMember]
        Undefined = 5
    }
}
