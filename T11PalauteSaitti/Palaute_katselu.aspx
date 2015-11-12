<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Palaute_katselu.aspx.cs" Inherits="Palaute_katselu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- Datasourcen määrittely -->
        <asp:XmlDataSource ID="srcKysely" DataFile="~/App_Data/Palaute.xml" runat="server"></asp:XmlDataSource>

        <asp:XmlDataSource ID="src" DataFile="~/App_Data/Palaute.xml" runat="server"></asp:XmlDataSource>

        <asp:Repeater ID="Repeater1" DataSourceID="srcKysely" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <td>Pvm</td>
                        <td>Nimi</td>
                        <td>Opittu</td>
                        <td>Haluan_oppia</td>
                        <td>Hyvää</td>
                        <td>Parannettavaa</td>
                        <td>Muuta</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# XPath("pvm") %></td>
                    <td><%# XPath("tekija") %></td>
                    <td><%# XPath("opittu") %></td>
                    <td><%# XPath("haluanoppia") %></td>
                    <td><%# XPath("hyvaa") %></td>
                    <td><%# XPath("parannettavaa") %></td>
                    <td><%# XPath("muuta") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
                <br />
                <a href="Palaute.aspx">Takaisin</a>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
