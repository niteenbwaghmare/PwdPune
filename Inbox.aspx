<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="PWdEEBudget.Inbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
      th {
          color:white
      }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
       <link href="css/tblmargin.css" rel="stylesheet" />
     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div style="overflow-x:auto">
     <table id="Table2" class="table table-bordered mar" style="color:#000" >
         <tr>
                <td style="text-align:center">
                    <asp:GridView ID="GridView1" runat="server"  BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" AlternatingRowStyle-BackColor = "#D3D3D3"  HeaderStyle-BackColor = "#2c3e50"
CaptionAlign="Top" >
                        <HeaderStyle BorderColor="black" BorderStyle="Solid" />
                       <Columns>
            <asp:BoundField  ItemStyle-Width = "50px" HeaderText="No" DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black" />
              <asp:BoundField  ItemStyle-Width = "50px" HeaderText="Name" DataField="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black"/>
            <asp:BoundField  ItemStyle-Width = "50px" HeaderText="Post" DataField="Post" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black"/>
              <asp:BoundField  ItemStyle-Width = "50px" HeaderText="Date" DataField="Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black"/>
             <asp:BoundField  ItemStyle-Width = "50px" HeaderText="SMS" DataField="SMS" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black"/>
        </Columns>
                    </asp:GridView>
                   </td>
          </tr>
            
    </table>
          </div>
        <asp:Button ID="Button4" runat="server" Text="Back" CssClass="btn btn-primary" Height="40px" Width="100px"  OnClick="Button4_Click" />
        <asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-info" Height="40px" Width="100px" OnClientClick="PrintGrid()" />
    <asp:Button ID="btnSendMail" runat="server" OnClick="btnSendMail_Click" class="btn btn-warning" Height="40px" Width="100px"  Text="Send Mail" />


   

    <script lang="javascript" type="text/javascript">

        function PrintGrid() {
            var prtGrid = document.getElementById('Print');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=0,top=0,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);

        }
    </script>
      </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>
