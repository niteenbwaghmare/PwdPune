<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildingStatistics.aspx.cs" Inherits="PWdEEBudget.BuildingStatistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="css/CSS_Statistics_Report.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
     

    <div>
        
        <br />
        <asp:Label ID="Label1" runat="server" Text="Has Header ?" Visible="false"></asp:Label>
        <asp:RadioButtonList ID="rbHDR" runat="server" Visible="false">
            <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
            <asp:ListItem Text="No" Value="No"></asp:ListItem>
            
        </asp:RadioButtonList>
        
        <asp:GridView ID="GridView1" runat="server" GridLines="Both" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" OnPageIndexChanging="PageIndexChanging" AllowPaging="true">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
