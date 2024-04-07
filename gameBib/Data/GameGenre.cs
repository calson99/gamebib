using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameBib.Data
{
    internal class GameGenre
    {
        public int GameId { get; set; }
        public int GenreId { get; set; }
        public Game Game { get; set; } = null!;
        public Genre Genre { get; set; } = null!;
    }
}
