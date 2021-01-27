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

namespace WcfPersonsWpfApplication
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

        private void GetAllPersons_Click(object sender, RoutedEventArgs e)
        {
            PersonsServiceReference.PersonDTO[] persons;
            PersonsServiceReference.IPersonWcfService service = new PersonsServiceReference.PersonWcfServiceClient();
            persons =service.GetAllePersoner();
            textBox.Clear();
            foreach (var p in persons)
            {
                textBox.AppendText(p.Efternavn+", "+p.Fornavn + ", " + p.Distrikt + ", " +p.Adresse+", "+p.Personnr + ", " +p.Postnr + ", " +p.Postnr+", " +p.Tlfnr + ", " +p.Version+Environment.NewLine);
            }
        }

        private void GetAllPersonsName_Click(object sender, RoutedEventArgs e)
        {
            PersonsServiceReference.IPersonWcfService service = new PersonsServiceReference.PersonWcfServiceClient();
            PersonsServiceReference.PersonDTO[] persons=service.GetAllePersoner();
            LinkedList<string> names = new LinkedList<string>();
            textBox.Clear();
            foreach(PersonsServiceReference.PersonDTO p in persons)
            {
                names.AddLast(p.Fornavn);
                textBox.AppendText(p.Fornavn+Environment.NewLine);
            }
        }
        private void GetAllPersonsPostN_Click(object sender, RoutedEventArgs e)
        {
            PersonsServiceReference.IPersonWcfService service = new PersonsServiceReference.PersonWcfServiceClient();
            PersonsServiceReference.PersonDTO[] persons = service.GetAllePersoner();
            LinkedList<int> pn = new LinkedList<int>();
            textBox.Clear();
            foreach (PersonsServiceReference.PersonDTO p in persons)
            {
                pn.AddLast(p.Postnr);
                textBox.AppendText(p.Postnr.ToString() + Environment.NewLine);
            }
        }
        private void GetAllPersonsPersonN_Click(object sender, RoutedEventArgs e)
        {
            PersonsServiceReference.IPersonWcfService service = new PersonsServiceReference.PersonWcfServiceClient();
            PersonsServiceReference.PersonDTO[] persons = service.GetAllePersoner();
            LinkedList<int> pn = new LinkedList<int>();
            textBox.Clear();
            foreach (PersonsServiceReference.PersonDTO p in persons)
            {
                pn.AddLast(p.Personnr);
                textBox.AppendText(p.Personnr.ToString() + Environment.NewLine);
            }
            
        }
    }
}
