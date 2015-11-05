<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoXML.aspx.cs" Inherits="DemoSQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XMLDataSource testi</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--1. XMLDataSourcen määrittely -->
        <asp:XmlDataSource ID="srcMuuvit"
            DataFile="~/App_Data/Movies.xml"
            runat="server"></asp:XmlDataSource>

    <!--1b. XMLDataSourcen määrittely Xpathilla -->
        <asp:XmlDataSource ID="srcLevyt"
            DataFile="~/App_Data/LevykauppaX.xml"
            XPath="Records/genre[@name='Pop']/record"
            runat="server"></asp:XmlDataSource>

    <!--2. DataKontrolli datan esittämistä varten -->
        <h2>KinnFino ylpeänä esittää XML-muuveja</h2>
        <asp:GridView ID="gvMuuvit"
            DataSourceID="srcMuuvit"
            runat="server"></asp:GridView>

    <!--2b. Vaihtoehtoinen tapa esittää käyttäen repeater kontrollia -->
        <h2>Kinnfino toisen kerran ylpeänä esittää Repeater-lla</h2>
        <asp:Repeater ID="Repeater1" DataSourceID="srcMuuvit" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <td>Nimi</td>
                        <td>Maa</td>
                        <td>Ohjaaja</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Country") %></td>
                    <td><%# Eval("Director") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <!--2c. Erilaista syntaksia -->
        <h2>Kinnfino kolmannen kerran ylpeänä esittää Repeater-lla</h2>
        <asp:Repeater ID="Repeater2" DataSourceID="srcMuuvit" runat="server">
            <ItemTemplate>
                <b> <%# Eval("Name") %></b> directed by <%# Eval("director") %> <br />
            </ItemTemplate>
        </asp:Repeater>

        <!--2c. levyjä repeater-lla -->
        <h2>Levykaupan erikoistarjoukset vain tänään Repeater-lla</h2>
        <asp:Repeater ID="Repeater3" DataSourceID="srcLevyt" runat="server">
            <ItemTemplate>
                <img alt="kansikuva" src='<%# "Images/" + Eval("ISBN") + ".jpg" %>' />
                <b> <%# Eval("Artist") %></b> presents <%# Eval("Title") %>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
