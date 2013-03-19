using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Promob.Entities.Identity
{    
    public class User
    {
        #region Properties
        
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public int? DefaultAccountID { get; set; }
        public virtual Account DefaultAccount { get; set; }
        
        public virtual ICollection<Account> Accounts { get; set; }

        #endregion

        #region Constructor

        public User()
        {

        }

        #endregion
    }
}