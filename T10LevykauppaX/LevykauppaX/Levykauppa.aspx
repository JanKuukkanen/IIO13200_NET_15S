<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Levykauppa.aspx.cs" Inherits="Levykauppa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--Levykaupan etusivu-->
        <!--1b. XMLDataSourcen määrittely Xpathilla -->
        <asp:XmlDataSource ID="srcLevyt"
            DataFile="~/App_Data/LevykauppaX.xml"
            XPath="Records/genre[@name='Pop']/record"
            runat="server"></asp:XmlDataSource>

        <!--Näytetään data selaimessa-->
        <h1>Levykauppa X</h1>
        <asp:Repeater ID="Repeater3" DataSourceID="srcLevyt" runat="server">
            <HeaderTemplate>
                <table border="0">
                    <tr></tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><img alt="kansikuva" src='<%# "Images/" + Eval("ISBN") + ".jpg" %>' /></td>
                    <td>
                        <h2> <%# Eval("Artist") %> : <%# Eval("Title") %></h2><br />

                        <b>ISBN: <a href="Levyntiedot.aspx?ISBN=<%# Eval("ISBN") %>"><%# Eval("ISBN") %></a> </b> <br />

                        <b>Hinta: <%# Eval("Price") %></b>
                   

                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
