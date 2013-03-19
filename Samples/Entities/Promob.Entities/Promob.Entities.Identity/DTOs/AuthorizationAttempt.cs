using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Promob.Entities.Identity.Enums;

namespace Promob.Entities.Identity.DTOs
{
    [DataContract]
    public class AuthorizationAttempt
    {
        #region Constructor

        public AuthorizationAttempt(eAuthorizationStatus status, Guid accessTicketId, List<Account> availableAccounts = null)
        {
            this.Status = status;
            this.AvailableAccounts = availableAccounts;
            this.AccessTicketId = accessTicketId;
        }

        #endregion

        #region Properties

        public bool IsAuthorized
        {
            get
            {
                if (this.Status == eAuthorizationStatus.Established || this.Status == eAuthorizationStatus.Maintained)
                    return true;

                return false;
            }
        }

        [DataMember]
        public eAuthorizationStatus Status { get; set; }
        [DataMember]
        public Guid AccessTicketId { get; set; }
        [DataMember]
        public List<Account> AvailableAccounts { get; set; }

        #endregion
    }
}
