using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Kysely
/// </summary>
public class Kysely
{
    public string Name { get; set; }
    public string Pvm { get; set; }
    public string Oppinut { get; set; }
    public string Opetellaan { get; set; }
    public string Hyva { get; set; }
    public string Parannukset { get; set; }
    public string Muu { get; set; }

    public Kysely(string name, string pvm, string oppinut, string opetellaan, string hyva, string parannukset, string muu)
	{
        this.Name = name;
        this.Pvm = pvm;
        this.Oppinut = oppinut;
        this.Opetellaan = opetellaan;
        this.Hyva = hyva;
        this.Parannukset = parannukset;
        this.Muu = muu;
	}
}