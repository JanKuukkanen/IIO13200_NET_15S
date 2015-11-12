using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;

public partial class Palaute : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtPvm.Text = DateTime.Today.Day.ToString() + "." + DateTime.Today.Month.ToString() + "." + DateTime.Today.Year;
    }

    public void OpenXml(Kysely palaute)
    {
        string appdatafolder = Server.MapPath("~/App_Data/Palaute.xml");

        XDocument doc = XDocument.Load(appdatafolder);
        XElement kyselyt = doc.Element("palautteet");
        kyselyt.Add(new XElement("palaute",
                new XElement("pvm", palaute.Pvm),
                new XElement("tekija", palaute.Name),
                new XElement("opittu", palaute.Oppinut),
                new XElement("haluanoppia", palaute.Opetellaan),
                new XElement("hyvaa", palaute.Hyva),
                new XElement("parannettavaa", palaute.Parannukset),
                new XElement("muuta", palaute.Muu)));
        doc.Save(appdatafolder);
    }

    protected void btnLaheta_Click(object sender, EventArgs e)
    {
        Kysely palaute = new Kysely(
            txtName.Text.ToString(),
            txtPvm.Text.ToString(),
            txtOpitut.Text.ToString(),
            txtOpittavaa.Text.ToString(),
            txtHyvaa.Text.ToString(),
            txtHuonot.Text.ToString(),
            txtMuut.Text.ToString()
            );

        OpenXml(palaute);
    }
}