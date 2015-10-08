using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace T08Palaute
{
    /// <summary>
    /// Interaction logic for PalautteetXML.xaml
    /// </summary>
    public partial class PalautteetXML : Window
    {
        DataSet ds;
        DataTable dt;
        DataView dv;
        public PalautteetXML()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgPalautteet_Initialized(object sender, EventArgs e)
        {
            try
            {
                //luetaan XML-tiedosto datasettiin
                string tiedosto = T08Palaute.Properties.Settings.Default.TestiPalaute;
                ds = new DataSet();
                dt = new DataTable();
                dv = new DataView();

                //asetetaan dataview itemsourceksi
                ds.ReadXml(tiedosto);
                dt = ds.Tables[0];
                dv = dt.DefaultView;
                dgPalautteet.ItemsSource = dv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnShowReviews_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //luetaan XML-tiedosto datasettiin
                string tiedosto = T08Palaute.Properties.Settings.Default.TestiPalaute;
                ds = new DataSet();
                dt = new DataTable();
                dv = new DataView();

                //asetetaan dataview itemsourceksi
                ds.ReadXml(tiedosto);
                dt = ds.Tables[0];
                dv = dt.DefaultView;
                dgPalautteet.ItemsSource = dv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
