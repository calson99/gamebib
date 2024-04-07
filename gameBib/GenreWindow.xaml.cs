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
    public sealed partial class GenreWindow : Window
    {
        public int gameId { get; set; }
        public GenreWindow(int GameId)
        {
            this.InitializeComponent();

            gameId = gameId;

            using (var db = new AppDbContext())
            {
                var game = db.Game.Find(GameId);

                var GameGenre = db.GameGenres
                    .Include(bg => bg.Genre)
                    .Where(x => x.GameId == GameId)
                    .Select(x => x.Genre)
                    .ToList();
                gebouwenListView.ItemsSource = GameGenre;
            }

        }

    }
}
