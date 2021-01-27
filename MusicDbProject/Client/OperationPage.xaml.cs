using System;
using System.Collections.Generic;
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
    /// Interaction logic for OperationPage.xaml
    /// </summary>
    public partial class OperationPage : Page
    {
        public OperationPage()
        {
            InitializeComponent();
        }

        private void allArtists_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewAllArtistsPage());
        }

        private void addArtist_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddArtistPage());
        }
    }
}
