using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Promob.Entities.Enums;

namespace Promob.Entities
{
    public class Contract
    {
        public Int16 ContractItemId { get; set; }

        public int ContractId { get; set; }

        public string LicenseSerialNumber { get; set; }

        public string SerialNumber { get; set; }

        public virtual License License { get; set; }

        public string CATSStatus { get; set; }

        public int ERPProductID { get; set; }

        public string ERPProductKey { get; set; }

        public string ProductType { get; set; }

        public string CustomerId { get; set; }

        public string LicenseUserId { get; set; }

        public int? AccountId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsCancelled { get; set; }

        public bool? FactorySerialNumber { get; set; }

        public string TerminateReason { get; set; }

        public string CancellationId { get; set; }

        public string CancellationReason { get; set; }

        public string ChargeContract { get; set; }

        public bool IsOptionalCATS { get; set; }
    }
}
