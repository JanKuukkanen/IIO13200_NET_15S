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
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace Tehtävä3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //PlayerCollection Players = new PlayerCollection();
        List<Player> Players = new List<Player>();
        string saveEnimi = "";
        string saveLnimi = "";
        string saveSeura = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmbTeam_Loaded(object sender, RoutedEventArgs e)
        {
            cmbTeam.Items.Add("Tappara");
            cmbTeam.Items.Add("TPS");
            cmbTeam.Items.Add("Lukko");
            cmbTeam.Items.Add("Ässät");
            cmbTeam.Items.Add("HIFK");
            cmbTeam.Items.Add("Blues");
            cmbTeam.Items.Add("HPK");
            cmbTeam.Items.Add("Ilves");
            cmbTeam.Items.Add("Sport");
            cmbTeam.Items.Add("Pelicans");
            cmbTeam.Items.Add("KooKoo");
            cmbTeam.Items.Add("Saipa");
            cmbTeam.Items.Add("Kärpät");
            cmbTeam.Items.Add("JYP");
            cmbTeam.Items.Add("KalPa");
        }

        private void btnCreateNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            int checkPlayer = 0;
            int fault = 1;

            Regex reg = new Regex("(^[1-9]+$)");
            Regex pattern = new Regex("(^[a-ö]+$)");

            if (!reg.IsMatch(txtPrice.Text) || !pattern.IsMatch(txtFname.Text) || !pattern.IsMatch(txtLname.Text))
            {
                fault = 0;
            }

            // tarkistetaan että käyttäjä on täyttänyt kaikki tarvittavat kentät ja että pelaajaa ei ole ennestään rekisterissä
            if (txtFname.Text != "" && txtLname.Text != "" && txtPrice.Text != "" && cmbTeam.Text != "" && fault == 1)
            {
                Player pelaaja = new Player(txtFname.Text, txtLname.Text, cmbTeam.Text, Double.Parse(txtPrice.Text));

                if (Players.Count != 0)
                {
                    for (int num = 0; num != Players.Count; num++)
                    {
                        if (Players[num].Get_KokoNimi() == pelaaja.Get_KokoNimi())
                        {
                            MessageBox.Show("Tämä pelaaja on jo olemassa!");
                            checkPlayer = 1;
                        }
                    }

                    if (checkPlayer == 0)
                    {
                        Players.Add(pelaaja);

                        lsbShowPlayers.Items.Add(pelaaja.Get_KokoNimi());

                        tbStatus.Items.Add("Player added");
                    }
                }
                else
                {
                    Players.Add(pelaaja);

                    lsbShowPlayers.Items.Add(pelaaja.Get_KokoNimi());

                    tbStatus.Items.Add("Player added");
                }
            }
            else
            {
                if (txtFname.Text == "" || txtLname.Text == "" || txtPrice.Text == "" || cmbTeam.Text == "")
                {
                    MessageBox.Show("Täytä kaikki tiedot");
                }
                else
                {
                    MessageBox.Show("Invalid input");
                }
            }
        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            for (int nro = 0; nro != Players.Count;)
            {
                string Enimi = Players[nro].Get_EtuNimi();
                string Snimi = Players[nro].Get_SukuNimi();
                string seura = Players[nro].Get_Seura();

                if (txtFname.Text == Enimi && txtLname.Text == Snimi && cmbTeam.Text == seura)
                {
                    lsbShowPlayers.Items.RemoveAt(nro);
                    Players.RemoveAt(nro);
                    nro = Players.Count;
                }
                else
                {
                    nro++;
                }
            }

            tbStatus.Items.Add("Player Deleted");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void lsbShowPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsbShowPlayers.SelectedItem != null)
            {
                string separateText = lsbShowPlayers.SelectedItem.ToString();
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

                string[] separatedString = separateText.Split(delimiterChars);

                txtFname.Text = separatedString[0];
                txtLname.Text = separatedString[1];
                cmbTeam.Text = separatedString[3];

                //otetaan ylös pelaajan nimi ja seura tallennusta varten
                saveEnimi = separatedString[0];
                saveLnimi = separatedString[1];
                saveSeura = separatedString[3];

                for (int nro = 0; nro != Players.Count; nro++)
                {
                    string Enimi = Players[nro].Get_EtuNimi();
                    string Snimi = Players[nro].Get_SukuNimi();
                    string seura = Players[nro].Get_Seura();

                    if (txtFname.Text == Enimi && txtLname.Text == Snimi && cmbTeam.Text == seura)
                    {
                        txtPrice.Text = Players[nro].Get_Hinta().ToString();
                    }
                }
            }
        }

        private void btnSavePlayer_Click(object sender, RoutedEventArgs e)
        {
            string Enimi = "";
            string Snimi = "";
            string Seura = "";
            int checkPlayer = 0;

            if (saveEnimi == "" && saveLnimi == "" && saveSeura == "")
            {
                MessageBox.Show("Valitse pelaaja oikealta");
            }
            else
            {
                for (int nro = 0; nro != Players.Count; )
                {
                    Enimi = Players[nro].Get_EtuNimi();
                    Snimi = Players[nro].Get_SukuNimi();
                    Seura = Players[nro].Get_Seura();

                    if (saveEnimi == Enimi && saveLnimi == Snimi && saveSeura == Seura)
                    {
                        lsbShowPlayers.Items.RemoveAt(nro);
                        Players.RemoveAt(nro);
                        nro = Players.Count;
                    }
                    else
                    {
                        nro++;
                    }
                }

                // tarkistetaan että käyttäjä on täyttänyt kaikki tarvittavat kentät ja että pelaajaa ei ole ennestään rekisterissä
                if (txtFname.Text != "" && txtLname.Text != "" && txtPrice.Text != "" && cmbTeam.Text != "")
                {
                    Player pelaaja = new Player(txtFname.Text, txtLname.Text, cmbTeam.Text, Double.Parse(txtPrice.Text));

                    if (Players.Count != 0)
                    {
                        for (int num = 0; num != Players.Count; num++)
                        {
                            if (Players[num].Get_KokoNimi() == pelaaja.Get_KokoNimi())
                            {
                                MessageBox.Show("Tämä pelaaja on jo olemassa!");
                                checkPlayer = 1;
                            }
                        }

                        if (checkPlayer == 0)
                        {
                            Players.Add(pelaaja);

                            lsbShowPlayers.Items.Add(pelaaja.Get_KokoNimi());
                        }
                    }
                    else
                    {
                        Players.Add(pelaaja);

                        lsbShowPlayers.Items.Add(pelaaja.Get_KokoNimi());
                    }
                }
                else
                {
                    MessageBox.Show("Täytä kaikki tiedot");
                }

                saveEnimi = "";
                saveLnimi = "";
                saveSeura = "";

                tbStatus.Items.Add("Player edited");
            }
        }

        private void btnWritePlayers_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "HockeyPlayerList.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog().ToString().Equals("True"))
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                for (int i = 0; i < lsbShowPlayers.Items.Count; i++)
                {
                    writer.WriteLine(lsbShowPlayers.Items[i]);
                }
                writer.Dispose();
                writer.Close();
            }

            tbStatus.Items.Add("File saved");
        }
    }
}
