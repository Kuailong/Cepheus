using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Promob.Entities.Enums;

namespace Promob.Entities
{
    [DataContract]
    public class License
    {
        [DataMember]
        public string ContractSerialNumber { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public int? ERPProductId { get; set; }

        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public DateTime? LastUpdate { get; set; }

        [DataMember]
        public DateTime? PostponedEndDate { get; set; }

        [DataMember]
        public string ComputerName { get; set; }

        [DataMember]
        public bool FactorySerialNumber { get; set; }

        [DataMember]
        public bool IsSuspendedByFactory { get; set; }

        [DataMember]
        public int? StatusID { get; set; }

        [DataMember]
        public eLicenseStatus LicenseStatus
        {
            get
            {
                if (StatusID == 1)
                    return eLicenseStatus.FreeForTransference;
                if (StatusID == 2)
                    return eLicenseStatus.Active;
                if (StatusID == 3)
                    return eLicenseStatus.Inactive;
                if (StatusID == 4)
                    return eLicenseStatus.WaitingActivation;
                if (StatusID == 5)
                    return eLicenseStatus.TransferibleWithoutCreatingContract;
                else
                    return eLicenseStatus.Inactive;

            }
        }

        [DataMember]
        public string SuspensionReason { get; set; }

        [DataMember]
        public DateTime? SuspensionDate { get; set; }

        [DataMember]
        public DateTime? VerificationDate { get; set; }

        [DataMember]
        public DateTime? LastChangeOfSituation { get; set; }

        [DataMember]
        public string ActivationCode { get; set; }

        [DataMember]
        public virtual ICollection<Transaction> Transactions { get; set; }

        [DataMember]
        public virtual Contract CurrentContract { get; set; }

        [DataMember]
        public virtual eLicenseSituation Situation
        {
            get
            {
                return new LicenseSituation(this).Situation;
            }
        }

        [DataMember]
        public virtual eLicenseDetail LicenseDetail
        {
            get
            {
                return new LicenseSituation(this).Detail;
            }
        }
    }
}