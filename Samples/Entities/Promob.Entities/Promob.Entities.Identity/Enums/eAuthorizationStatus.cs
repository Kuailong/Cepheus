using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities.Identity.Enums
{
    [DataContract]
    public enum eAuthorizationStatus
    {
        [EnumMember]
        Rejected,
        [EnumMember]
        Established,
        [EnumMember]
        Maintained,
        [EnumMember]
        RequiresAccount
    }
}
