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
using System.Windows.Shapes;
using System.Data;
using System.Xml.Linq;

namespace Teht4XML
{
    /// <summary>
    /// Interaction logic for ViinikellariDataSet.xaml
    /// </summary>
    public partial class ViinikellariDataSet : Window
    {
        DataSet ds;
        DataTable dt;
        DataView dv;
        public ViinikellariDataSet()
        {
            InitializeComponent();
        }

        private void btnHaeViinit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //luetaan koko XML DataSettiin
                //DataSe in memory database
                string filu = @"D:\\H3387\Viinit.xml";
                ds = new DataSet();
                dt = new DataTable();
                dv = new DataView();

                ds.ReadXml(filu);
                dt = ds.Tables[0];
                dv = dt.DefaultView;
                dgViinit.ItemsSource = dv;

                //haetaan maat ComboBoxiin
                List<string> maat = new List<string>();

                maat = haeMaa();

                for (int nro = 0; nro != maat.Count; nro++)
                {
                    cmbMaat.Items.Add(maat[nro]);
                }

                //cmbMaat.SelectedItem = maat[0];
                /*maat = new List<string>();
                dv.ToTable(true, dgViinit.Columns[1].Header.ToString());*/
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<string> haeMaa()
        {
            List<string> maat = new List<string>();

            XDocument doc = XDocument.Load(@"D:\\H3387\Viinit.xml");

            var Countries = doc.Descendants("maa");

            foreach (var country in Countries)
            {
                if (!maat.Contains(country.Value))
                {
                    maat.Add(country.Value);
                }
            }

            return maat;
        }

        private void cmbMaat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // asetetaan Filter dataviewllä
            dv.RowFilter = "maa = '" + cmbMaat.SelectedValue.ToString() + "'";
        }
    }
}
