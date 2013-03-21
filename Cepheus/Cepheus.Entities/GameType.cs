using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities
{
    public class GameType
    {
        public int GameTypeId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
