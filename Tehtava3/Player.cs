using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtävä3
{
    class Player
    {
        private string Etunimi;
        private string Sukunimi;
        private string KokoNimi;
        private string Seura;
        private double Siirtohinta;

        public Player(string enimi, string snimi, string team, double price)
        {
            Etunimi = enimi;
            Sukunimi = snimi;
            Seura = team;
            Siirtohinta = price;

            KokoNimi = Etunimi + " " + Sukunimi + ", " + Seura;
        }

        public string Get_KokoNimi()
        {
            return KokoNimi;
        }

        public string Get_EtuNimi()
        {
            return Etunimi;
        }

        public string Get_SukuNimi()
        {
            return Sukunimi;
        }

        public double Get_Hinta()
        {
            return Siirtohinta;
        }

        public string Get_Seura()
        {
            return Seura;
        }
    }
}
