<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Levyntiedot.aspx.cs" Inherits="Levyntiedot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- Datasourcen määrittely -->
        <asp:XmlDataSource ID="srcLevyt"
            DataFile="~/App_Data/LevykauppaX.xml"
            runat="server"></asp:XmlDataSource>

        <asp:XmlDataSource ID="srcBiisit"
            DataFile="~/App_Data/LevykauppaX.xml"
            runat="server"></asp:XmlDataSource>

        <asp:Repeater ID="Repeater1" DataSourceID="srcLevyt" runat="server">
            <ItemTemplate>
                <img alt="kansikuva" src='<%# "Images/" + Eval("ISBN") + ".jpg" %>' /> <br />
                <h2><%# Eval("Artist") %> : <%# Eval("Title") %></h2> <br />
                <b>ISBN:</b> <%# Eval("ISBN") %> <br />
                <b>Hinta:</b> <%# Eval("Price") %> <br />
            </ItemTemplate>
        </asp:Repeater>

        <asp:Repeater ID="Repeater2" DataSourceID="srcBiisit" runat="server">
            <HeaderTemplate>
                <b>Levyn Biisit: </b> <br />
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("name") %> <br />
            </ItemTemplate>
            <FooterTemplate>
                <br />
                <a href="Levykauppa.aspx">Takaisin</a>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
