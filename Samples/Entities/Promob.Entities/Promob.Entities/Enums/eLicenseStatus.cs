using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Promob.Entities.Enums
{
    [DataContractAttribute]
    public enum eLicenseStatus
    {
        [EnumMember]
        FreeForTransference = 1,
        [EnumMember]
        Active = 2,
        [EnumMember]
        Inactive = 3,
        [EnumMember]
        WaitingActivation = 4,
        [EnumMember]
        TransferibleWithoutCreatingContract = 5,
        [EnumMember]
        WaintingPaymentVersion4i = 6 //Caso especifico para Promob 4
    }
}