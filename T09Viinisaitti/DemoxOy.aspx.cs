﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DemoxOy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ladataan asiakastiedot tietokannasta
        GetRealData();
    }

    protected void GetDemoData()
    {
        //täytetään GridView
        DataTable dt = JAMK.IT.DBDemoxOy.GetDataSimple();
        gvCustomers.DataSource = dt;
        gvCustomers.DataBind();
    }

    protected void GetRealData()
    {
        try
        {
            DataTable dt = JAMK.IT.DBDemoxOy.GetDataReal();
            gvCustomers.DataSource = dt;
            gvCustomers.DataBind();

        }
        catch (Exception ex)
        {
            lblNotes.Text = ex.Message;
        }
    }
}