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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace gameBib
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        AppDbContext db = null;
        public MainWindow()
        {
            this.InitializeComponent();

            using (db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            /*var selectedItem = (Game)e.ClickedItem;*/
            /*int geselecteerdeBewonerId = selectedItem.Id;*/
            GameWindow ThirdPage = null;
            
            ThirdPage = new GameWindow();
            ThirdPage.Activate();
        }
        private void GenreButton_Click(object sender, RoutedEventArgs e)
        {
            AllGenreWindow AllGenres = null;
            AllGenres = new AllGenreWindow();
            AllGenres.Activate();
        }
    }
}
