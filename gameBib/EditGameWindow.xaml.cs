using gameBib.Data;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace gameBib
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditGameWindow : Window
    {
        int GameId = 0;
        private AppDbContext db;
        private List<Genre> genres;

        public EditGameWindow(int geselecteerdeGameId)
        {
            this.InitializeComponent();
            GameId = geselecteerdeGameId;
            using (db = new AppDbContext())
            {
                genres = db.Genre.ToList();
                lbGenres.ItemsSource = db.Genre.ToList();
            }
        }
        private void EditGame_Click(object sender, RoutedEventArgs e)
        {
            string gameName = txtGameName.Text;
            int rating = int.Parse(((ComboBoxItem)cmbRating.SelectedItem).Content.ToString());
            string releaseDate = (dpReleaseDate.SelectedDate).ToString();
            /*DateTime inputDate = DateTime.ParseExact(inputDateString, "MM/dd/yyyy hh:mm:ss tt zzz", null);
            string releaseDate = inputDate.ToString("dd-MM-yyyy");*/

            using (var db = new AppDbContext())
            {
                var Game = db.Game.Single(b => b.Id == GameId);
                Game.Naam = txtGameName.Text;
                Game.Rating = rating;
                Game.Datum = releaseDate;
                db.SaveChanges();

                var game = db.Game
                    .Where(x => x.Naam == gameName)
                    .Select(x => x.Id)
                    .ToList();

                int gameId = game[0];

                var gameGenre = db.GameGenres
                    .Where(x => x.GameId == gameId)
                    .ToList();

                foreach (GameGenre GameGenre in gameGenre) {
                    db.GameGenres.Remove(GameGenre);
                }

                foreach (Genre item in lbGenres.SelectedItems)
                {
                    db.GameGenres.Add(new GameGenre
                    {
                        GameId = gameId,
                        GenreId = item.Id
                    });
                }


                db.SaveChanges();
            }

            this.Close();
            GameWindow GameWindow = new GameWindow();
            GameWindow.Activate();
        }
    }
}
