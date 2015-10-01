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
using System.Data;

namespace T05Lasnaolot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataView dv;
        //app.config tiedostoon tallennettuihin tietoihin voi päästä käsiksi joko nimiavaruuden kautta tai käyttämällä ConfigurationManager Class:n kautta
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetDataTable_Click(object sender, RoutedEventArgs e)
        {
            dv = new DataView();
            dv = JAMK.IT.DBDemoxOy.GetDataReal().DefaultView;
            dgData.ItemsSource = dv;
            //dgData.DataContext = JAMK.IT.DBDemoxOy.GetDataReal();
        }

        private void btnGetPresentDataTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dv.RowFilter = "asioid LIKE '%" + txtWordFilter.Text + "%'";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
