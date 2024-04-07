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
    public sealed partial class AddGenreWindow : Window
    {
        AppDbContext db = null;
        public AddGenreWindow()
        {
            this.InitializeComponent();
        }

        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            // Get values from UI elements
            string genreName = txtGenreName.Text;

            using (var db = new AppDbContext())
            {
                db.Genre.Add(new Genre
                {
                    Naam = genreName
                });
                db.SaveChanges();
            }

            this.Close();
            AllGenreWindow AllGenreWindow = new AllGenreWindow();
            AllGenreWindow.Activate();
        }
    }
}
