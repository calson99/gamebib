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
    /// int 
    public sealed partial class AllGenreWindow : Window
    {
        AppDbContext db = null;
        int geselecteerdeGenreId;
        public AllGenreWindow()
        {
            this.InitializeComponent();

            using (db = new AppDbContext())
            {
                GenresListView.ItemsSource = db.Genre.ToList();
            }
        }

        private void GenreSelectieButton_Click(object sender, ItemClickEventArgs e)
        {
            var selectedItem = (Genre)e.ClickedItem;
            geselecteerdeGenreId = selectedItem.Id;
            EditGenreButton.Visibility = Visibility.Visible;
            DeleteGenreButton.Visibility = Visibility.Visible;

            using (db = new AppDbContext())
            {
                var GameGenre = db.GameGenres
                    .Include(bg => bg.Game)
                    .Where(x => x.GenreId == geselecteerdeGenreId)
                    .Select(x => x.Game)
                    .ToList();

                GamesListView.ItemsSource = GameGenre;
            }
        }

        private void AddGenreButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddGenreWindow AddGenreWindow = new AddGenreWindow();
            AddGenreWindow.Activate();
        }

        private void EditGenreButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            EditGenreWindow editGenreWindow = new EditGenreWindow(geselecteerdeGenreId);
            editGenreWindow.Activate();
        }

        private void DeleteGenreButton_Click(object sender, RoutedEventArgs e)
        {
            using (db = new AppDbContext())
            {
                var Genre =  db.Genre.Single(b => b.Id == geselecteerdeGenreId);
                db.Genre.Remove(Genre);

                var GameGenre = db.GameGenres
                    .Where(x => x.GenreId == geselecteerdeGenreId)
                    .ToList();

                foreach(var item in GameGenre)
                {
                    db.GameGenres.Remove(item);
                }

                db.SaveChanges();
                this.Close();
                AllGenreWindow AllGenres = new AllGenreWindow();
                AllGenres.Activate();
            }
        }
    }
}
