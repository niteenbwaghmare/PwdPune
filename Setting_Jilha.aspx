<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Setting_Jilha.aspx.cs" Inherits="PWdEEBudget.Setting_Jilha" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        th {
            color: white;
        }

        .Background {
            background-color: Gray;
            filter: alpha(opacity=40);
            opacity: 0.4;
        }

        .Pnl {
            position: static;
            top: 10%;
            left: 10px;
            width: 300px;
            height: 100px;
            text-align: center;
            background-color: White;
            border: solid 3px black;
        }
    </style>
    <style type="text/css">
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
            padding: 5px;
            /*width: 100% !important;*/
        }

        th {
            background-color: #2c3e50;
            color: #fff;
           
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <link href="css/tblmargin.css" rel="stylesheet" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <h4 style="text-align: -webkit-center; font-weight: bold;"></h4>
            <div class="container">
                <table class="table table-bordered mar">
                    <tr><th colspan="2"><h2>District (जिल्हा)</h2></th></tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAKramak1" runat="server" Text="अ.क्र"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblAKramak" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblType" runat="server" Text="जिल्हा"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtjilha" runat="server" class="form-control" Height="44px" Width="240px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="btn btn-primary" OnClick="btnSave_Click" />

                            <asp:Button ID="btnCancle" runat="server" Text="CANCLE" CssClass="btn btn-primary" OnClientClick="JavaScript:window.history.back(1); return false;" />
                            <asp:Button ID="Button4" runat="server" Text="BACK" CssClass="btn btn-primary" Height="30px" OnClick="Button4_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">


                            <asp:GridView ID="GridDist" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" GridLines="None" AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                AlternatingRowStyle-CssClass="alt"
                                Width="40%" OnRowCancelingEdit="GridDist_RowCancelingEdit" OnRowDeleting="GridDist_RowDeleting" OnRowEditing="GridDist_RowEditing" OnRowUpdating="GridDist_RowUpdating">
                                <Columns>
                                    <asp:CommandField  ShowEditButton="true" ShowDeleteButton="true"/>
                                    <asp:TemplateField HeaderText="अ.क्र">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAKrmank" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="जिल्हा">
                                        <ItemTemplate>
                                            <asp:Label ID="txtjilha" runat="server" Text='<%# Eval("Jilha")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtjilha" runat="server" TextMode="MultiLine" CssClass="form-control c" Text='<%# Eval("Jilha") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="lblMessage" runat="server" Text="" />

                            <%--<asp:GridView ID="GridView1" runat="server"  BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false" Font-Names="Arial" Font-Size="11pt" AlternatingRowStyle-BackColor="#D3D3D3" HeaderStyle-BackColor="#2c3e50"
                        CaptionAlign="Top">
                        <HeaderStyle BorderColor="black" BorderStyle="Solid" />
                        <Columns>
                            <asp:BoundField ItemStyle-Width="50px" HeaderText="अ.क्र" DataField="AKrmank" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black" />
                            <asp:BoundField ItemStyle-Width="50px" HeaderText="जिल्हा" DataField="Jilha" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black" />
                           

                        </Columns>
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /> 
                    </asp:GridView>--%>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        jQuery("a").filter(function () {
            return this.innerHTML.indexOf("Delete") == 0;
        }).click(function () {
            return confirm("Are you sure you want to delete this record?");
        });
    </script>
    <script type="text/javascript">
        function Navigate() {
            location.href = "SuperAdminPanel.aspx";
        }

    </script>
</asp:Content>
