using Microsoft.Phone.Controls;
using SQLite.Net;
using SQLite.Net.Attributes;
using SQLite.Net.Platform.WindowsPhone8;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Windows.Storage;

namespace PhoneApp2
{
    public class Author
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var sqliteconnection = new SQLiteConnection(new SQLitePlatformWP8(), Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "cache.sqlite")));
            var authors = new List<Author>();
            authors.Add(new Author
            {
                Id = "eugenio-estrada",
                Name = "Eugenio Estrada"
            });
            authors.Add(new Author
            {
                Id = "difoosion",
                Name = "Difoosion"
            });
            sqliteconnection.CreateTable<Author>();
            sqliteconnection.InsertOrReplaceAll(authors);
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}