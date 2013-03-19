using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepheus.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public virtual List<GameType> GameTypes { get; set; }
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public string ImagePath { get; set; }
    }
}
