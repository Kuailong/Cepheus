using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promob.Entities.Identity
{
    public class PasswordRequest
    {
        #region Properties

        public int PasswordRequestID { get; set; }
        public string Token { get; set; }
        public bool Used { get; set; }

        public DateTime RequestDate { get; set; }
        public DateTime? UsageDate { get; set; }

        public string RequestIP { get; set; }
        public string UsageIP { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Constructor

        public PasswordRequest()
        {

        }

        #endregion
    }
}
