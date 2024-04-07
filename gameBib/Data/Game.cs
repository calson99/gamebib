using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameBib.Data
{
    internal class Game
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Datum { get; set; }
        public int Rating { get; set; }
        public List<Genre> Genres { get; set; }
        public List<GameGenre> GameGenres { get; set; }
    }
}
