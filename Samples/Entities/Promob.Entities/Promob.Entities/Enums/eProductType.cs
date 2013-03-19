using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities.Enums
{
    [DataContractAttribute]
    public enum eProductType
    {
        [EnumMember]
        Promob4,
        [EnumMember]
        Promob5,
        [EnumMember]
        Plugin,
        [EnumMember]
        PromobSW,
        [EnumMember]
        PromobExpress,
        [EnumMember]
        PromobHome,
        [EnumMember]
        Manager,
        [EnumMember]
        Other,
        [EnumMember]
        Library
    }
}
