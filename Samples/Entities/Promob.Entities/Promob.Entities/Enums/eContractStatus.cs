using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities.Enums
{
    [DataContractAttribute]
    public enum eContractStatus
    {
        [EnumMember]
        Active,
        [EnumMember]
        Inactive
    }
}