using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gameBib.Data
{
    internal class AppDbContext : DbContext 
    {
        public DbSet<Game> Game { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "port=3306;" +
                "user=root;" +
                "password=;" +
                "database=csd_gameBib",
                ServerVersion.Parse("10.4.17-mariadb")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameGenre>()
                .HasKey(bg => new { bg.GameId, bg.GenreId });

            modelBuilder.Entity<GameGenre>()
                .HasOne(bg => bg.Game)
                .WithMany(b => b.GameGenres)
                .HasForeignKey(bg => bg.GameId);

            modelBuilder.Entity<GameGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.GameGenres)
                .HasForeignKey(bg => bg.GenreId);

            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Naam = "cod", Datum = "30-12-2011", Rating = 3 },
                new Game { Id = 2, Naam = "league of legends", Datum = "30-12-2012", Rating = 7 },
                new Game { Id = 3, Naam = "dota", Datum = "30-12-2013", Rating = 3 },
                new Game { Id = 4, Naam = "lethal company", Datum = "30-12-2014", Rating = 8 },
                new Game { Id = 5, Naam = "r6 siege", Datum = "30-12-2015", Rating = 6 },
                new Game { Id = 6, Naam = "cs go", Datum = "30-12-2016", Rating = 7 }
            );

            // Add data for Gebouwen
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Naam = "shooter"},
                new Genre { Id = 2, Naam = "moba"},
                new Genre { Id = 3, Naam = "first person"},
                new Genre { Id = 4, Naam = "adventure"},
                new Genre { Id = 5, Naam = "action"}
            );

            modelBuilder.Entity<GameGenre>().HasData(
                new GameGenre { GameId = 1, GenreId = 1 },
                new GameGenre { GameId = 1, GenreId = 5 },
                new GameGenre { GameId = 1, GenreId = 3 },
                new GameGenre { GameId = 2, GenreId = 2 },
                new GameGenre { GameId = 3, GenreId = 2 },
                new GameGenre { GameId = 4, GenreId = 4 },
                new GameGenre { GameId = 5, GenreId = 5 },
                new GameGenre { GameId = 5, GenreId = 1 },
                new GameGenre { GameId = 5, GenreId = 3 },
                new GameGenre { GameId = 6, GenreId = 3 },
                new GameGenre { GameId = 6, GenreId = 1 },
                new GameGenre { GameId = 6, GenreId = 5 }
            );
        }
    }
}
