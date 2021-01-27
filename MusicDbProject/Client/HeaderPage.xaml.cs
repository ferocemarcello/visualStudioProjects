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
    /// Interaction logic for HeaderPage.xaml
    /// </summary>
    public partial class HeaderPage : Page
    {
        public HeaderPage()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.myframe.Navigate(new HomePage());
        }
        private void Operation_Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.myframe.Navigate(new OperationPage());
        }
    }
}
