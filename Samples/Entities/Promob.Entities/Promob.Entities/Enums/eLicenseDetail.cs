using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities.Enums
{
    [DataContractAttribute]
    public enum eLicenseDetail
    {
        [EnumMember]
        Active = 1,
        [EnumMember]
        ActiveAndSubscriptionExpired = 2,
        [EnumMember]
        FreeForActivate = 3,
        [EnumMember]
        SubscriptionPendingRenewalRequired = 4,
        [EnumMember]
        CancelledSubscription = 5,
        [EnumMember]
        SuspendedByFactory = 6,
        [EnumMember]
        Pending = 7,
        [EnumMember]
        PendingAndContractCancelled = 9,
        [EnumMember]
        Undefined = 8
    }
}
