using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promob.Entities
{
    public class ProductsUseRightsLog
    {
        public int ProductsUseRightLogId { get; set; }

        public DateTime Date { get; set; }

        public string Action { get; set; }

        public int ProductsUseRightId { get; set; }

        public int UseRightProductId { get; set; }

        public int? ProductId { get; set; }

        public int? SubGroupId { get; set; }

        public int? AccountId { get; set; }

    }
}
