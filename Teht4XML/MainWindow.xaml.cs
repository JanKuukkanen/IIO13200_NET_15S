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
using System.IO;
using System.Diagnostics;

namespace Teht4XML
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

        private void btnXml1_Click(object sender, RoutedEventArgs e)
        {
            //avataan uusi ikkuna
            Viinikellari1 vk = new Viinikellari1();
            vk.Kayttaja = "Janne Kuukkanen";
            vk.Show();
    }

        private void btnDataSet_Click(object sender, RoutedEventArgs e)
        {
            ViinikellariDataSet vk = new ViinikellariDataSet();
            vk.Show();
        }

        private void btnXml2_Click(object sender, RoutedEventArgs e)
        {
            try
            {   // Open the xml file.
                Process.Start("notepad.exe", @"D:\\H3387\Viinit.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
