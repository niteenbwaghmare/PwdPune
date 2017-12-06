<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="ScheduleSms.aspx.cs" Inherits="PWdEEBudget.ScheduleSms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <link href="css/tblmargin.css" rel="stylesheet" />
     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div style="overflow-x:auto">
     <table id="Table2" class="table table-bordered mar" style="color:#000" >
         <tr>
                <td style="text-align:center">
                    <asp:GridView ID="GridView1" runat="server"  BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" AlternatingRowStyle-BackColor = "#D3D3D3"  HeaderStyle-BackColor = "#15317E"
CaptionAlign="Top" >
                        
                    </asp:GridView>
                   </td>
          </tr>
            

         
    </table>
        <asp:Button ID="Button4" runat="server" Text="Send" CssClass="btn btn-primary"   Height="30px" OnClick="Button4_Click"/>
        </div>
</asp:Content>
