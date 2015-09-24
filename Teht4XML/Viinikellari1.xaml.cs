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
using System.Xml.Linq;

namespace Teht4XML
{
    /// <summary>
    /// Interaction logic for Viinikellari1.xaml
    /// </summary>
    public partial class Viinikellari1 : Window
    {

        public string Kayttaja { get; set; }

        public Viinikellari1()
        {
            InitializeComponent();
        }

        public List<string> haeMaa()
        {
            List<string> maat = new List<string>();

            XDocument doc = XDocument.Load("D://H3387/Viinit.xml");

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

        private void cmbCountry_Initialized(object sender, EventArgs e)
        {
            List<string> maat = new List<string>();

            maat = haeMaa();

            for (int nro = 0; nro != maat.Count; nro++)
            {
                cmbCountry.Items.Add(maat[nro]);
            }

            cmbCountry.SelectedItem = maat[0];
        }

        private void btnGetWines_Click(object sender, RoutedEventArgs e)
        {
            /*string rowFilter = string.Format("[{0}] = '{1}'", dgWines.Columns[1], cmbCountry.Text);
            (myDataGridView.DataSource as DataTable).DefaultView.RowFilter = rowFilter;*/
        }
    }
}
