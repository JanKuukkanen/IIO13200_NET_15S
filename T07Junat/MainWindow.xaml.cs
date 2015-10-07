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
using Newtonsoft.Json; // newtonsoft package downloaded from the internet
using System.Net; // for WebClient-class

namespace T07Junat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string json = "";
        List<Asema> asemat;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void JsonStationManager()
        {
            //haetaan JSON data netistä ja täytetään combobox asemadatalla
            json = GetStationJson();
            //muutetaan data olioiksi
            asemat = JsonConvert.DeserializeObject<List<Asema>>(json);

            for (int nro = 0; nro < asemat.Count; nro++)
            {
                cmbAsemat.Items.Add(asemat[nro].stationName);
            }
        }

        private void JsonTrainManager()
        {
            string station = cmbAsemat.SelectedValue.ToString();
            string shortCode = "";

            for (int nro = 0; nro < asemat.Count; nro++)
            {
                if (asemat[nro].stationName.Equals(station))
                {
                    shortCode = asemat[nro].stationShortCode;
                }
            }

            //haetaan JSON data webistä
            json = GetTrainJson(shortCode);
            //muutetaan data olioiksi
            List<Juna> junat = JsonConvert.DeserializeObject<List<Juna>>(json);
            dgJunat.DataContext = junat;

        }

        private string GetStationJson()
        {
            try
            {
                string url = string.Format("http://rata.digitraffic.fi/api/v1/metadata/station");

                using (WebClient wc = new WebClient())
                {
                    var retval = wc.DownloadString(url);
                    return retval;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetTrainJson(string shortCode)
        {
            try
            {
                string url = string.Format("http://rata.digitraffic.fi/api/v1/live-trains?station=" + shortCode);

                using (WebClient wc = new WebClient())
                {
                    var retval = wc.DownloadString(url);
                    return retval;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnHaeLahtevatJunat_Click(object sender, RoutedEventArgs e)
        {
            JsonStationManager();
            if (cmbAsemat.SelectedValue != null)
            {
                JsonTrainManager();
            }
        }
    }
}
