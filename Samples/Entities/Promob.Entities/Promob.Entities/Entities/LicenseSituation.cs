using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Promob.Entities.Enums;
using System.Runtime.Serialization;
using Promob.Entities.ERP;

namespace Promob.Entities
{
    [DataContractAttribute]
    public class LicenseSituation
    {
        #region Private Members

        private eLicenseSituation _situation;
        private eLicenseDetail _detail;

        #endregion

        #region Properties

        [DataMemberAttribute]
        public eLicenseSituation Situation
        {
            get
            {
                return this._situation;
            }
        }

        [DataMemberAttribute]
        public eLicenseDetail Detail
        {
            get
            {
                return this._detail;
            }
        }

        #endregion

        #region Constructor

        public LicenseSituation(License license)
        {
            if (license == null || license.CurrentContract == null)
            {
                this._situation = eLicenseSituation.Undefined;
                this._detail = eLicenseDetail.Undefined;
            }

            else if (license.IsSuspendedByFactory)
            {
                this._situation = eLicenseSituation.Inactive;
                this._detail = eLicenseDetail.SuspendedByFactory;
            }

            else if (license.LicenseStatus == eLicenseStatus.Inactive)
            {
                if (license.CurrentContract.IsCancelled)
                {
                    this._situation = eLicenseSituation.Inactive;
                    this._detail = eLicenseDetail.PendingAndContractCancelled;
                }
                else
                {
                    this._situation = eLicenseSituation.Inactive;
                    this._detail = eLicenseDetail.Pending;
                }
            }

            else if (license.LicenseStatus == eLicenseStatus.Active && license.CurrentContract.CATSStatus.Equals(eLicenseStatus.Active.ToString()))
            {
                this._situation = eLicenseSituation.Active;
                this._detail = eLicenseDetail.Active;
            }

            else if (license.LicenseStatus == eLicenseStatus.FreeForTransference ||
                license.LicenseStatus == eLicenseStatus.TransferibleWithoutCreatingContract ||
                license.LicenseStatus == eLicenseStatus.WaitingActivation)
            {
                this._situation = eLicenseSituation.FreeForActivate;
                this._detail = eLicenseDetail.FreeForActivate;
            }

            else if (license.CurrentContract.CATSStatus.Equals(eContractStatus.Inactive.ToString()) && license.LicenseStatus == eLicenseStatus.Active)
            {
                if (license.CurrentContract.IsOptionalCATS)
                {
                    this._situation = eLicenseSituation.RequiresAttention;
                    this._detail = eLicenseDetail.ActiveAndSubscriptionExpired;
                }
                else if (license.CurrentContract.IsCancelled)
                {
                    this._situation = eLicenseSituation.Inactive;
                    this._detail = eLicenseDetail.CancelledSubscription;
                }
                else
                {
                    this._situation = eLicenseSituation.Inactive;
                    this._detail = eLicenseDetail.SubscriptionPendingRenewalRequired;
                }
            }
            else
            {
                this._situation = eLicenseSituation.Undefined;
                this._detail = eLicenseDetail.Undefined;
            }
        }

        #endregion
    }
}