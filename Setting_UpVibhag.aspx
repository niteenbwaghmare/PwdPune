<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Setting_UpVibhag.aspx.cs" Inherits="PWdEEBudget.Setting_UpVibhag" %>

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
        }
    </style>
    <style>
        @media only screen and (min-width:768px) {
            /*desktop*/

        }

        @media only screen and (max-width:500px) {
            .h2, h2 {
                font-size: 14px !important;
            }
            .btn {
                width:32% !important;
                margin: 1px 0px 1px 0px !important;
            }
            .table td, .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
                font-size: 11px !important;
            }

            .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
                padding: 0 !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>

            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            <div class="container" style="width:50%;">
                <table class="table table-bordered mar">
                    <tr>
                        <th colspan="2">
                            <h2>उपविभागाचे नाव </h2>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAKramak1" runat="server" Text="अ.क्र"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblAKramak" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPVibhagName" runat="server" Text="उपविभागाचे नाव"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPVibhagName" runat="server" class="form-control" Height="44px" Width="240px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                            <asp:Button ID="Button1" runat="server" Text="CANCEL" CssClass="btn btn-primary" OnClick="Button1_Click" />

                            <asp:Button ID="Button4" runat="server" Text="BACK" CssClass="btn btn-primary"  OnClick="Button4_Click" />
                        </td>
                    </tr>

                </table>
            </div>
            <br />
            <div class="container" style="width:70%;">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="AKrmank" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" Width="100%">
                <Columns>
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                    <asp:TemplateField HeaderText="अ.क्र">
                        <ItemTemplate>
                            <asp:Label ID="lblAKrmank" runat="server" Text='<%# Eval("AKrmank")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="उपविभागाचे नाव">
                        <ItemTemplate>
                            <asp:Label ID="txtUpVibhagacheName" runat="server" Text='<%# Eval("UpVibhagacheName")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtUpVibhagacheName" runat="server" TextMode="MultiLine" CssClass="form-control c" Text='<%# Eval("UpVibhagacheName") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>

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
</asp:Content>
