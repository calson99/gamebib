using gameBib.Data;
using Microsoft.EntityFrameworkCore;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace gameBib
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddGameWindow : Window
    {
        AppDbContext db = null;
        List<Genre> genres = null;
        public AddGameWindow()
        {
            this.InitializeComponent();

            using (db = new AppDbContext())
            {
                genres = db.Genre.ToList();
                lbGenres.ItemsSource = db.Genre.ToList();
            }
        }

        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            // Get values from UI elements
            string gameName = txtGameName.Text;
            int rating = int.Parse(((ComboBoxItem)cmbRating.SelectedItem).Content.ToString());
            string releaseDate = (dpReleaseDate.SelectedDate).ToString();
            /*string inputDateString = "12/10/2023 12:08:00 PM +01:00";
            DateTime inputDate = DateTime.ParseExact(inputDateString, "MM/dd/yyyy hh:mm:ss tt zzz", null);
            string outputDateString = inputDate.ToString("yyyy/MM/dd");*/
            int GenreId;
            

            using (var db = new AppDbContext())
            {
                db.Game.Add(new Game
                {
                    Naam = gameName,
                    Rating = rating,
                    Datum = releaseDate,
                });
                db.SaveChanges();

                var game = db.Game
                    .Where(x => x.Naam == gameName)
                    .Select(x => x.Id)
                    .ToList();

                int gameId = game[0];

                

                foreach (Genre item in lbGenres.SelectedItems)
                {
                    db.GameGenres.Add(new GameGenre
                    {
                        GameId = gameId,
                        GenreId = item.Id
                    });
                    db.SaveChanges();
                }
                
            }

            this.Close();
            GameWindow GameWindow = new GameWindow();
            GameWindow.Activate();
        }
    }
}
