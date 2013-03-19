using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Promob.Entities.Enums;

namespace Promob.Entities
{
    public class LicenseSummary
    {
        public eLicenseSituation Situation { get; set; }
        public int Quantity { get; set; }
    }
}
