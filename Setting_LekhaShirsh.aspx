<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Setting_LekhaShirsh.aspx.cs" Inherits="PWdEEBudget.Setting_LekhaShirsh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            font-size: 18px;
        }
    </style>
    <%--<style>
        @media only screen and (min-width:768px) {
            /*desktop*/

        }

        @media only screen and (max-width:500px) {
            .h2, h2 {
                font-size: 14px !important;
            }

            .btn {
                width: 32% !important;
                margin: 1px 0px 1px 0px !important;
            }

            .table td, .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
                font-size: 11px !important;
            }

            .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
                padding: 0 !important;
            }
        }
    </style>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/tblmargin.css" rel="stylesheet" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <%--     <h4 style="text-align: -webkit-center; font-weight: bold;">लेखाशिर्ष</h4>--%>
    <div class="container" style="width:70%;">
        <table class="table table-bordered mar" style="color: #000;">
            <tr>
                <%--<td colspan="3" style="font-weight: bold; color: #000000; text-align: center"></td>--%>
                <th colspan="2">
                    <h2>लेखाशिर्ष</h2>
                </th>
            </tr>
            <tr>
                <td style="font-weight: bold; color: #000000">
                    <asp:Label ID="Lblid" runat="server" Text="अ.क्र"></asp:Label></td>
                <td>
                    <asp:Label ID="lblAKrmank" runat="server"></asp:Label>
                </td>
                <%-- <td rowspan="4">
                <asp:GridView ID="GridView1" runat="server" Width="248px">
                </asp:GridView>
            </td>--%>
            </tr>
            <tr>
                <td style="font-weight: bold; color: #000000">प्रकार </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: #000000">संगणक संकेतांक क्रमांक</td>
                <td>
                    <asp:TextBox ID="txtcode" runat="server" CssClass="form-control" Height="33px" Width="241px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: #000000">लेखाशिर्ष</td>
                <td>
                    <asp:TextBox ID="Txttype" runat="server" CssClass="form-control" Height="40px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Btnsub" runat="server" Text="संपादित करा" OnClick="Btnsub_Click" CssClass="btn btn-success" Height="30px" Width="100px" />
                    <asp:Button ID="BtnCancel" runat="server" Text="बदल करणे" CssClass="btn btn-info" Height="30px" Width="100px" />
                    <asp:Button ID="Btncan" runat="server" Text="रद्द करा" CssClass="btn btn-danger" Height="30px" Width="100px" />
                    <asp:Button ID="Button4" runat="server" Text="मागे" OnClick="Button4_Click" CssClass="btn btn-warning" Height="30px" Width="100px" />
                </td>
                <%-- <td>&nbsp;</td>--%>
            </tr>
        </table>
    </div>
    <br />
    <span style="font-size: 20px; margin-left: 450px"></span>
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <div class="container" style="width:90%;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:CommandField ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton="true" />
                <asp:TemplateField HeaderText="अ.क्र">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="प्रकार">
                    <ItemTemplate>
                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="संगणक संकेतांक क्रमांक">
                    <ItemTemplate>
                        <asp:Label ID="txtcode" runat="server" Text='<%# Eval("code")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtcode" runat="server" CssClass="form-control c" Text='<%# Eval("code") %>' />
                        <asp:Label ID="oldLekhaCodelbl" runat="server" Text='<%# Bind("code") %>' Visible="false"></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="लेखाशिर्ष">
                    <ItemTemplate>
                        <asp:Label ID="txtLekhaShirsh" runat="server" Text='<%# Eval("LekhaShirsh")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLekhaShirsh" runat="server" CssClass="form-control c" Text='<%# Eval("LekhaShirsh") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

    </div>
    <br />
    <br />
</asp:Content>
