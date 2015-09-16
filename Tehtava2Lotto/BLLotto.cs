using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtävä2Lotto
{
    public class Lotto
    {
        private string Tyyppi;
        private int SuurinNro;
        private int PieninNro;
        private int NroLkm;
        //private List<int> Arvot = new List<int>();

        public Lotto()
        {
            Tyyppi = "";
            SuurinNro = 0;
            PieninNro = 0;
            NroLkm = 0;
        }

        public Lotto(string arvonta)
        {
            Tyyppi = arvonta;

            if (Tyyppi == "Suomi")
            {
                SuurinNro = 39;
                PieninNro = 0;
                NroLkm = 7;
            }
            else if (Tyyppi == "Viking Lotto")
            {
                SuurinNro = 48;
                PieninNro = 0;
                NroLkm = 6;
            }
            else if (Tyyppi == "Eurojackpot")
            {
                SuurinNro = 50;
                PieninNro = 1;
                NroLkm = 7;
            }
        }

        public List<int> ArvoRivi(int draws)
        {

            Random random = new Random();
            List<int> Arvot = new List<int>();

            for (int nro = 0; nro != NroLkm; nro++)
            {
                int randomNumber = 0;

                if (Tyyppi == "Eurojackpot" && nro == 5)
                {
                    SuurinNro = 10;
                }
                randomNumber = random.Next(PieninNro, SuurinNro);
                Arvot.Add(randomNumber);
            }
            return Arvot;
        }
    }
}
