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
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace T08Palaute
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet ds;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSeeReview_Click(object sender, RoutedEventArgs e)
        {
            PalautteetXML PalauteIkkuna = new PalautteetXML();
            PalauteIkkuna.Show();

            statPalaute.Items.Clear();
            statPalaute.Items.Add("Palauteikkuna avattu");
        }

        private void statPalaute_Initialized(object sender, EventArgs e)
        {
            statPalaute.Items.Clear();

            try
            {
                //luetaan XML-tiedosto (Testipalaute on lokaali testaukseen tarkoitettu xml tiedosto, virallinen palautustiedosto on PalautusTiedostoXML)
                string tiedosto = T08Palaute.Properties.Settings.Default.TestiPalaute;
                ds = new DataSet();

                ds.ReadXml(tiedosto);

                statPalaute.Items.Add("succesfully connected to XML file");
            }
            catch
            {
                statPalaute.Items.Add("Failed to connect to XML file");
            }
        }

        private void btnSendReview_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtDate.Text != "" && txtLearned.Text != "" && txtToLearn.Text != "" && txtGood.Text != "" && txtBad.Text != "" && txtOther.Text != "")
            {
                //tehdään validointi tekstilaatikoiden sisällölle
                bool success = validateInputs();

                //lähetetään palaute xml tiedostoon
                if (success == true)
                {
                    lahetaPalaute();
                }
            }
            else
            {
                statPalaute.Items.Clear();
                statPalaute.Items.Add("Täytä kaikki laatikot");
                MessageBox.Show("Täytä kaikki laatikot");
            }
        }

        private void lahetaPalaute()
        {
            try
            {
                string tiedosto = T08Palaute.Properties.Settings.Default.TestiPalaute;

                XDocument doc = XDocument.Load(tiedosto);



                XElement palautteet = doc.Element("palautteet");
                palautteet.Add(new XElement("palaute",
                   new XElement("pvm", txtDate.Text),
                   new XElement("tekija", txtName.Text),
                   new XElement("opittu", txtLearned.Text),
                   new XElement("haluanoppia", txtToLearn.Text),
                   new XElement("hyvaa", txtGood.Text),
                   new XElement("parannettavaa", txtBad.Text),
                   new XElement("muuta", txtOther.Text)
                   ));

                doc.Save(tiedosto);

                statPalaute.Items.Clear();
                statPalaute.Items.Add("palaute tallennettu xml tiedostoon");
            }
            catch
            {
                statPalaute.Items.Clear();
                statPalaute.Items.Add("Failed to write to xml file");
                MessageBox.Show("Failed to write to xml file");
            }
        }

        private bool validateInputs()
        {
            bool success = true;
            //nimi
            Regex regex = new Regex(@"\d");
            if (regex.Match(txtName.Text).Success)
            {
                MessageBox.Show("No numbers");
                success = false;
            }
            //päivämäärä
            regex = new Regex(@"^(\d{1,2}\.\d{1,2}\.\d{4})$");
            if (!regex.Match(txtDate.Text).Success)
            {
                MessageBox.Show("Anna päivämäärä muodossa. dd.mm.yyyy");
                success = false;
            }
            //opitut asiat
            regex = new Regex(@"\d");
            if (regex.Match(txtLearned.Text).Success || regex.Match(txtToLearn.Text).Success)
            {
                MessageBox.Show("No numbers");
                success = false;
            }
            //hyvät ja huonot
            regex = new Regex(@"\d");
            if (regex.Match(txtGood.Text).Success || regex.Match(txtBad.Text).Success)
            {
                MessageBox.Show("No numbers");
                success = false;
            }

            return success;
        }
    }
}
