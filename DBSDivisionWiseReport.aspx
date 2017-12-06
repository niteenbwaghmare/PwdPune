<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="DBSDivisionWiseReport.aspx.cs" Inherits="PWdEEBudget.DBSDivisionWiseReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        table {
            width:100%;

        }
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            text-align: center;
            
        }
        tbody, tr, td {
           text-align: left;
       }
        .c {
            width: 100% !important;
            height: 100% !important;
            font-size: 16px;
        }

        .p {
            height: 100% !important;
            font-size: 16px;
        }

        th, td {
            padding: 10px;
            /*width: 100% !important;*/
        }

        th {
            background-color: #2c3e50;
            color: #fff;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div align="center">
   <table>
       <tr>
           <th style="text-align:center">उपविभागा नुसार कामाची संख्या</th>
       </tr>
       <tr>
           <td>
               <asp:GridView runat="server" ID="GridView1"  AutoGenerateColumns="false" Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
                   <Columns>
                     <asp:TemplateField HeaderText="अ.क्र" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                        <asp:BoundField DataField="Upvibhag" HeaderText="उपविभाग"  ControlStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                         <asp:BoundField DataField="Count" HeaderText="कामाची संख्या"  ControlStyle-Font-Bold="true"></asp:BoundField>
                  
                   </Columns>

                    <RowStyle HorizontalAlign="Center" />
               </asp:GridView>
           </td>
       </tr>
   </table>
        <div align="center">
        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary" Height="40px" Width="100px" OnClick="btnPrint_Click"  />

        <asp:Button ID="BtnExcel" runat="server" Text="Excel" CssClass="btn btn-success" Height="40px" Width="100px" OnClick="BtnExcel_Click"  />
      
        <asp:Button ID="btnSendMail" runat="server"  class="btn btn-warning" Height="40px" Width="100px" Text="Send Mail" OnClick="btnSendMail_Click" />
      
        <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-default" BackColor="#660000" ForeColor="White"  Height="40px" Width="100px" OnClientClick="JavaScript:window.history.back(1); return false;" />
      
    </div>
    </div>




</asp:Content>
