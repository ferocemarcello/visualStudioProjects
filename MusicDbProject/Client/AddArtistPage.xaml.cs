using Client.MainServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for AddArtistPage.xaml
    /// </summary>
    public partial class AddArtistPage : Page
    {
        public ObservableCollection<BoolStringClass> TheList { get; set; }
        public AddArtistPage()
        {
            List<Genre> allGenres = HomePage.client.GetAllGenres().ToList();
            CreateCheckBoxList();
            InitializeComponent();
        }
        private void CreateCheckBoxList()
        {
            TheList = new ObservableCollection<BoolStringClass>();
            TheList.Add(new BoolStringClass { TheText = "EAST", TheValue = 1 });
            TheList.Add(new BoolStringClass { TheText = "WEST", TheValue = 2 });
            TheList.Add(new BoolStringClass { TheText = "NORTH", TheValue = 3 });
            TheList.Add(new BoolStringClass { TheText = "SOUTH", TheValue = 4 });
            this.DataContext = this;
        }
        public class BoolStringClass
        {
            public string TheText { get; set; }
            public int TheValue { get; set; }
        }
        private void InsertArtist_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = new CheckBox();
            System.Windows.MessageBox.Show(HomePage.client.GetRandomString());
        }
    }
}
