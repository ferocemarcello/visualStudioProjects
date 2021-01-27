using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Client
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        internal static MainServiceReference.MainServiceClient client;
        public HomePage()
        {
            InitializeComponent();
        }
        private void Localhost_Click(object sender, RoutedEventArgs e)
        {
            ConnectAndGo("localhost:1635");
        }

        private void ConnectAndGo(string host)
        {
            client = new MainServiceReference.MainServiceClient();
            client.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri("http://"+host+ "/MainService.svc"));
            NavigationService.Navigate(new OperationPage());
        }

        private void Customhost_Click(object sender, RoutedEventArgs e)
        {
            
            ConnectAndGo(ipbox.Text + ":" + portbox.Text);
        }
        
    }
}
