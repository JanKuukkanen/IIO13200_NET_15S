using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public static class DBDemoxOy
    {
        public static DataTable GetDataSimple()
        {
            //DB-kerros
            //taulu
            DataTable dt = new DataTable();
            //sarakkeet
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            //tietueet eli rivit
            dt.Rows.Add("Kalle", "Isokallio");
            dt.Rows.Add("Matt", "Nickerson");
            return dt;
        }
        public static DataTable GetDataReal()
        {
            //DBkerros, haetaan Viini-tietokannasta taulun customer tietueet, palauttaa DataTablen
            try
            {
                string sql = "";
                sql = "SELECT firstname, lastname, address, city FROM customer"; // WHERE asioid='salesa'";
                
                //Haetaan connectionstring web.config tiedostosta
                System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Saitti");
                System.Configuration.ConnectionStringSettings _connStr;
                _connStr = rootWebConfig.ConnectionStrings.ConnectionStrings["ViiniConnectionString1"];

                using (SqlConnection conn = new SqlConnection(_connStr.ToString()))
                {
                    //avataan yhteys
                    conn.Open();
                    //luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "lasnaolot");
                        return ds.Tables["lasnaolot"];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
