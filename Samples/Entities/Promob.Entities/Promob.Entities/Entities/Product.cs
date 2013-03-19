using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using Promob.Entities.ERP;
using System.ComponentModel.DataAnnotations;

namespace Promob.Entities
{
    [DataContract]
    public class Product
    {
        #region Properties

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsContract { get; set; }

        [DataMember]
        public string ImageThumb { get; set; }

        public string ImageThumbAbsoluteUri
        {
            get
            {
                return string.Format("insert uri here {0}", this.ImageThumb);
            }
        }

        [DataMember]
        public string ImageBig { get; set; }

        public string ImageBigAbsoluteUri
        {
            get
            {
                return string.Format("insert uri here {0}", this.ImageBig);
            }
        }

        [DataMember]
        public string ProductKey { get; set; }

        [DataMember]
        public ERPProduct ERPProduct { get; set; }

        [DataMember]
        public virtual ICollection<Product> ProductComponents { get; set; }

        [DataMember]
        public virtual ICollection<ProductsUseRight> ProductUseRights { get; set; }

        #endregion
    }
}
