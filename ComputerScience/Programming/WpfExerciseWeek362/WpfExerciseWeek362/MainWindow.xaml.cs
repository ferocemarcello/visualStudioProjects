using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WpfExerciseWeek362
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Client c;
        public MainWindow()
        {
            InitializeComponent();
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            this.c=new Client(ip, 11000);
            
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Receive(object sender, ExecutedRoutedEventArgs e)
        {
            string text = c.ReceiveMessage();
            this.textBox.AppendText(c.ReceiveMessage());
        }
        private void SendCommand(object sender, ExecutedRoutedEventArgs e)
        {
            string text = this.textBox.Text;
            c.SendMessage(text);
        }
    }

}
