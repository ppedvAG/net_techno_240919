using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Windows;

namespace BooksUndTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LadenBücher(object sender, RoutedEventArgs e)
        {
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={suchTb.Text}");

                //newtonsoft
                var result = JsonConvert.DeserializeObject<BooksResult>(json);

                //core 3.0
                var result2 = System.Text.Json.JsonSerializer.Deserialize<BooksResult>(json);

                myGrid.ItemsSource = result2.items.Select(x => x.volumeInfo);

            }
        }
    }
}
