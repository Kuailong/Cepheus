using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promob.Entities
{
    public class ProductsUseRight
    {
        public int ProductsUseRightId { get; set; }

        public int UseRightProductId { get; set; }

        public int? ProductId { get; set; }

        public int? SubGroupId { get; set; }

        public int? AccountId { get; set; }

        public virtual Product ProductUseRight { get; set; }

        public virtual Product Product { get; set; }
    }
}
