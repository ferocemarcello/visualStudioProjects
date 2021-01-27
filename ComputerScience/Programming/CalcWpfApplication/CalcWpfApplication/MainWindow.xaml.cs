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

namespace CalcWpfApplication
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CalcServiceReference.RegneWcfServiceClient calcService = new CalcServiceReference.RegneWcfServiceClient();
            int result = calcService.Add(5, 8);
            Console.WriteLine("result: "+result);
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            CalcServiceReference.RegneWcfServiceClient calcService = new CalcServiceReference.RegneWcfServiceClient();
            int result = calcService.Add(5, 8);
            Console.WriteLine("result: " + result);
        }
    }
}
