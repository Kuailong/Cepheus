using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Promob.Entities.Identity
{    
    public class Account
    {
        #region Properties

        public int AccountID { get; set; }        
        public string Name { get; set; }
        
        public virtual ICollection<User> Users { get; set; }

        #endregion

        #region Constructor

        public Account()
        {
        }

        #endregion
    }
}