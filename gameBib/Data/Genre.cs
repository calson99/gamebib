using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameBib.Data
{
    internal class Genre
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<GameGenre> GameGenres { get; set; }
    }
}
