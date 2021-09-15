<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanetsPage.aspx.cs" Inherits="Planets_WebApp.PlanetsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="PLANETS DATA" Font-Bold="True" ForeColor="#003399" Font-Italic="True" Font-Underline="True"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Number of Orphan Planets :" Font-Bold="True" ForeColor="#003399"></asp:Label>
        <asp:Label ID="lblOrphanCount" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="Label6" runat="server" Text="Hottest Star :" Font-Bold="True" ForeColor="#003399"></asp:Label>
        <asp:Label ID="lblHottestStar" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Planet Timeline Data" Font-Bold="True" ForeColor="#003399"></asp:Label>
        <br />
        <asp:GridView ID="gvPlanets" runat="server">
        </asp:GridView>
  
    </form>
</body>
</html>
