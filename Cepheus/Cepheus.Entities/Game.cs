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
        public string Description { get; set; }
        public virtual ICollection<GameTypes> GameTypes { get; set; }
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public byte[] Image { get; set; }
    }
}
