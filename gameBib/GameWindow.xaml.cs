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
using Windows.Gaming.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace gameBib
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameWindow : Window
    {
        int geselecteerdeBewonerId;
        AppDbContext db = null;
        public GameWindow()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                /*var GameGenre = db.GameGenres
                    .Include(bg => bg.Game)
                    .Select(x => x.Game)
                    .ToList();*/

                bewonerListView.ItemsSource = db.Game.ToList();
            }
        }
        private void FilterGameButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext())
            {
                if (((ComboBoxItem)cmbRating.SelectedItem != null))
                {
                    int rating = int.Parse(((ComboBoxItem)cmbRating.SelectedItem).Content.ToString());

                    var GamesList = db.Game
                        .Where(x => x.Rating == rating)
                        .ToList();
                    bewonerListView.ItemsSource = GamesList;
                }
                else
                {
                    bewonerListView.ItemsSource = db.Game.ToList();
                }
            }
            /*string releaseDate = (dpReleaseDate.SelectedDate).ToString();
            if (releaseDate != null || releaseDate == "") {
                DateTime inputDate = DateTime.ParseExact(releaseDate, "MM/dd/yyyy hh:mm:ss tt zzz", null);
                releaseDate = inputDate.ToString("dd-MM-yyyy");
            }*/


            /*if (releaseDate != null || rating != null)
            {
                var GamesList = db.Game
                    .Where(x => x.Rating == rating && x.Datum == releaseDate)
                    .ToList();
                bewonerListView.ItemsSource = GamesList;
            }
            else if(releaseDate == null && rating != null)
            {
                var GamesList = db.Game
                    .Where(x => x.Rating == rating)
                    .ToList();
                bewonerListView.ItemsSource = GamesList;
            }
            else if (releaseDate != null && rating == null)
            {
                var GamesList = db.Game
                    .Where(x => x.Datum == releaseDate)
                    .ToList();
                bewonerListView.ItemsSource = GamesList;
            }*/




        }

        private void BewonerSelectieButton_Click(object sender, ItemClickEventArgs e)
        {
            var selectedItem = (Game)e.ClickedItem;
            geselecteerdeBewonerId = selectedItem.Id;
            EditGameButton.Visibility = Visibility.Visible;
            DeleteGameButton.Visibility = Visibility.Visible;
        }


        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddGameWindow addGameWindow = new AddGameWindow();
            addGameWindow.Activate();
        }

        private void EditGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            EditGameWindow EditGameWindow = new EditGameWindow(geselecteerdeBewonerId);
            EditGameWindow.Activate();
        }

        private void DeleteGameButton_Click(object sender, RoutedEventArgs e)
        {
            using (db = new AppDbContext())
            {
                var Game = db.Game.Single(b => b.Id == geselecteerdeBewonerId);
                db.Game.Remove(Game);

                var GameGenre = db.GameGenres
                    .Where(x => x.GameId == geselecteerdeBewonerId)
                    .ToList();

                foreach (var item in GameGenre)
                {
                    db.GameGenres.Remove(item);
                }

                db.SaveChanges();
                this.Close();
                GameWindow AllGames = new GameWindow();
                AllGames.Activate();
            }
        }
    }
}
