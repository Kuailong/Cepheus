using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities
{
    public class GameTypes
    {
        public int GameTypeId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int TypeId { get; set; }
        public Types GameType { get; set; }
    }
}
