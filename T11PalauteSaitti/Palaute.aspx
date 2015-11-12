<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Palaute.aspx.cs" Inherits="Palaute" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Anna palautetta</h1>
        <asp:Label ID="lblPvm" runat="server" Text="Pvm"></asp:Label>
        <asp:TextBox ID="txtPvm" runat="server" style="margin-left: 10px" Width="160px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please input the date as follows: dd.mm.yyyy" ControlToValidate="txtPvm"
         ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"></asp:RegularExpressionValidator>
        <br />

        <asp:Label ID="lblName" runat="server" Text="Name" style="margin-left: 41px"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" style="margin-left: 10px" Width="160px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Input your name in the field" ControlToValidate="txtName"></asp:RequiredFieldValidator>
        <br />
        <br />

        <asp:Label ID="lblOpitut" runat="server" Text="Tärkeimmät opitut asiat"></asp:Label>
        <asp:TextBox ID="txtOpitut" runat="server" style="margin-left: 10px" Width="160px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required Field" ControlToValidate="txtOpitut"></asp:RequiredFieldValidator>
        <br />
        <br />

        <asp:Label ID="lblOpittavaa" runat="server" Text="Mitä haluan vielä oppia"></asp:Label>
        <asp:TextBox ID="txtOpittavaa" runat="server" style="margin-left: 10px" Width="160px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required Field" ControlToValidate="txtOpittavaa"></asp:RequiredFieldValidator>
        <br />
        <br />

        <asp:Label ID="lblHyvaa" runat="server" Text="Hyvät"></asp:Label>
        <asp:TextBox ID="txtHyvaa" runat="server" style="margin-left: 10px" Width="160px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required Field" ControlToValidate="txtHyvaa"></asp:RequiredFieldValidator>
        <br />
        <br />

        <asp:Label ID="lblHuonot" runat="server" Text="Parannettavaa"></asp:Label>
        <asp:TextBox ID="txtHuonot" runat="server" style="margin-left: 10px" Width="160px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required Field" ControlToValidate="txtHuonot"></asp:RequiredFieldValidator>
        <br />
        <br />

        <asp:Label ID="lblMuut" runat="server" Text="Muita huomioita"></asp:Label>
        <asp:TextBox ID="txtMuut" runat="server" style="margin-left: 10px" Width="160px"></asp:TextBox>
        <br />
        <br />

        <asp:Button ID="btnLaheta" runat="server" Text="Lähetä palaute" OnClick="btnLaheta_Click" />
        <br />
        <br />
        <a href="Palaute_katselu.aspx">Katsele XML-tiedostoa</a>

    </div>
    </form>
</body>
</html>
