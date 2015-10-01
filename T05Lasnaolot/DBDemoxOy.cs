﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
            //rivit
            dt.Rows.Add("Kalle", "Isokallio");
            dt.Rows.Add("Matt", "Nickerson");

            return dt;
        }

        public static DataTable GetDataReal()
        {
            //DB-kerros, haetaan DemoxOy-tietokannasta taulun lasnaolot tietueet, palauttaa DataTablen
            try
            {
                string sql = "";
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot"; // WHERE asioid='H3387'";
                string connStr = T05Lasnaolot.Properties.Settings.Default.yhteys;
                using (SqlConnection conn = new SqlConnection(connStr))
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
