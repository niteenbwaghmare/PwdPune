<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="StatisticsReport.aspx.cs" Inherits="PWdEEBudget.StatisticsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .mydatagrid {
            width: 100%;
            border: solid 2px black;
            min-width: 80%;
        }

        .header {
            background-color: #646464;
            font-family: Arial;
            color: White;
            /*border: none 0px transparent;*/
            height: 25px;
            text-align: center;
            font-size: 16px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            text-align: left;
            /*border: transparent;*/
        }

            .rows:hover {
                background-color: #ff8000;
                font-family: Arial;
                color: #fff;
                text-align: left;
            }

        .selectedrow {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            font-weight: bold;
            text-align: left;
        }

        .mydatagrid a /** FOR THE PAGING ICONS  **/ {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

            .mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/ {
                background-color: #000;
                color: #fff;
            }

        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: #c9c9c9;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .pager {
            background-color: #646464;
            font-family: Arial;
            color: White;
            height: 30px;
            text-align: left;
        }

        .mydatagrid td {
            padding: 5px;
        }

        .mydatagrid th {
            padding: 5px;
        }
        .lbl {
            background-color:lightyellow;
            color:red;
            

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width:30%; background:linear-gradient(#ccc,#fae8bd); border-radius:2%;">
        <span style="font-size: xx-large;color: #e61240;margin-left: 31%;">Statistics</span>
        <hr />
        <table class="table" style="margin-left: 15%;" >
            <tr>
                <td>
                      <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                     <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </td>
            </tr>
           
            <tr>
                <td >
                    <asp:Label ID="Label1" runat="server" Text="Has Header ?"></asp:Label>
                    <br />
             
                     <asp:RadioButtonList ID="rbHDR" runat="server">
                         <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                         <asp:ListItem Text="No" Value="No"></asp:ListItem>
                     </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
           <td>
               <asp:Label ID="Label2" runat="server" Text="Please Select Statistics For" CssClass="lbl"></asp:Label>
           </td>
            </tr>
            <tr>
                <td >
                <asp:RadioButtonList runat="server" ID="rdbtype">
                    <asp:ListItem Text="Building" Value="BuildingStatistic.xls" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Road" Value="RoadStatistic.xls"></asp:ListItem>
                </asp:RadioButtonList>
                    </td>
            </tr>
        </table>
    </div>
    <div class="container" style="width:70%;">
        <asp:GridView ID="GridView1" runat="server" GridLines="Both" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" OnPageIndexChanging="PageIndexChanging" AllowPaging="true">
        </asp:GridView>
    </div>
   
</asp:Content>
