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
using System.Text.RegularExpressions;

namespace Tehtävä2Lotto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<int> tulokset = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmbArvonta_Initialized(object sender, EventArgs e)
        {
            cmbArvonta.Items.Add("Suomi");
            cmbArvonta.Items.Add("Viking Lotto");
            cmbArvonta.Items.Add("Eurojackpot");
            cmbArvonta.SelectedItem = "Suomi";
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDraws.Text == "")
                {
                    MessageBox.Show("Please specify a number higher than 0 for the draws");
                }
                else
                {
                    int drawsNro = int.Parse(txtDraws.Text);

                    for (int rep = 0; rep != drawsNro; rep++)
                    {
                        if (rep >= 1 || !lsbNumbers.Items.IsEmpty)
                        {
                            lsbNumbers.Items.Add("Next draw");
                        }

                        Lotto lotto = new Lotto(cmbArvonta.Text);

                        tulokset = lotto.ArvoRivi(drawsNro);

                        for (int nro = 0; nro < tulokset.Count; nro++)
                        {
                            lsbNumbers.Items.Add(tulokset[nro]);
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Invalid input: " + er);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lsbNumbers.Items.Clear();
        }

        private void txtDraws_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex pattern = new Regex("^[1-9]+$");
            if (!pattern.IsMatch(txtDraws.Text))
            {
                MessageBox.Show("Please specify a number higher than 0 for the draws");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
