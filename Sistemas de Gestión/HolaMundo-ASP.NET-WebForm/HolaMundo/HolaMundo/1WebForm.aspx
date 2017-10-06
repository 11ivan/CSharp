<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1WebForm.aspx.cs" Inherits="HolaMundo._1WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <p>
                    <asp:Label ID="idNombre" runat="server" Text="Nombre:"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    <asp:Label ID="idErrorNombre" runat="server" Text="" ForeColor="Red" Font-Bold="true" Visible="true"></asp:Label>
                </p>
                <p>
                <asp:Label ID="idApellido" runat="server" Text="Apellidos:"></asp:Label>
                <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
                <asp:Label ID="idErrorApellido" runat="server" Text="" ForeColor="Red" Font-Bold="true" Visible="true"></asp:Label>
                </p>
                <p>
                    <asp:Button runat="server" Text="Enviar" OnClick="btnEnviar" />
                </p>
                <p>
                    <asp:Label ID="idGood" runat="server" Text="" Visible="true"></asp:Label>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </p>
        </div>
    </form>
</body>
</html>
