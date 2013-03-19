using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Promob.Entities.Enums
{
    [DataContractAttribute]
    public enum eComponentType
    {
        [EnumMember]
        Program = 1,
        [EnumMember]
        System = 2,
        [EnumMember]
        Installer = 3,
        [EnumMember]
        Plugin = 4,
        [EnumMember]
        Library = 5,
        [EnumMember]
        AuthRequiredLibrary = 6
    }
}
