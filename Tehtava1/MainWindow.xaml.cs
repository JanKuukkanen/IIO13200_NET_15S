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

namespace Tehtävä1
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

        private void btnCountAreaAndRadius_Click(object sender, RoutedEventArgs e)
        {
            double WindowWidth = Double.Parse(txtWindowWidth.Text);
            double WindowHeight = Double.Parse(txtWindowHeight.Text);
            double FrameWidth = Double.Parse(txtFrameWidth.Text);

            if (WindowWidth == 0 || WindowHeight == 0 || FrameWidth == 0)
            {
                MessageBox.Show("Please insert values higher than 0 to all available textboxes");
            }
            else
            {
                // ikkunan lasiosan pinta-ala
                double result1 = (WindowWidth - FrameWidth * 2) * (WindowHeight - FrameWidth * 2);

                // karmin piiri
                double result2 = 2 * (WindowWidth + WindowHeight);

                // karmin pinta-ala (koko ikkunan pinta-ala josta on poistettu lasiosan pinta-ala)
                double result3 = WindowWidth * WindowHeight - result1;

                txtResult1.Text = result1.ToString();
                txtResult2.Text = result2.ToString();
                txtResult3.Text = result3.ToString();
            }
        }

        private bool isOkay(string syote, TextBox sender)
        {
            double luku = Double.Parse(syote);
            if (luku >= 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Invalid argument");
                return false;
            }

        }

        private void txtWindowWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            //tarkistetaan käyttäjän syötteen kelpoisuus
            try
            {
                int length = txtWindowWidth.Text.Length;
                if (length >= 3)
                {
                    bool CheckArgument = isOkay(txtWindowWidth.Text, sender as TextBox);
                }
                else if (length <= 2)
                {
                    // tarkistetaan ettei käyttäjä ole syöttänyt negatiivisia arvoja
                    Regex pattern = new Regex("^(-+[0-9])");
                    if (!pattern.IsMatch(txtWindowWidth.Text))
                    {
                        bool CheckArgument = isOkay(txtWindowWidth.Text, sender as TextBox);
                    }
                    else
                    {
                        MessageBox.Show("Can't accept negative values");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid input!");
            }
        }

        private void txtWindowHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            //tarkistetaan käyttäjän syötteen kelpoisuus
            try
            {
                int length = txtWindowHeight.Text.Length;
                if (length >= 3)
                {
                    bool CheckArgument = isOkay(txtWindowHeight.Text, sender as TextBox);
                }
                else if (length <= 2)
                {
                    // tarkistetaan ettei käyttäjä ole syöttänyt negatiivisia arvoja
                    Regex pattern = new Regex("^(-+[0-9])");
                    if (!pattern.IsMatch(txtWindowHeight.Text))
                    {
                        bool CheckArgument = isOkay(txtWindowHeight.Text, sender as TextBox);
                    }
                    else
                    {
                        MessageBox.Show("Can't accept negative values");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid input!");
            }
        }

        private void txtFrameWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            //tarkistetaan käyttäjän syötteen kelpoisuus
            try
            {
                int length = txtFrameWidth.Text.Length;
                if (length >= 3)
                {
                    bool CheckArgument = isOkay(txtFrameWidth.Text, sender as TextBox);
                }
                else if (length <= 2)
                {
                    // tarkistetaan ettei käyttäjä ole syöttänyt negatiivisia arvoja
                    Regex pattern = new Regex("^(-+[0-9])");
                    if (!pattern.IsMatch(txtFrameWidth.Text))
                    {
                        bool CheckArgument = isOkay(txtFrameWidth.Text, sender as TextBox);
                    }
                    else
                    {
                        MessageBox.Show("Can't accept negative values");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid input!");
            }
        }
    }
}
