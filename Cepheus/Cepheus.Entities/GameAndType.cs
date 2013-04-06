using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities
{
    public class GameAndType
    {
        public int GameAndTypeId { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int GameTypeId { get; set; }
        public virtual GameType GameType { get; set; }
    }
}
