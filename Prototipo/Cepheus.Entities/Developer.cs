using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Game> Games { get; set; }
    }
}
