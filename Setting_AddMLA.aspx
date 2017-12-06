<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Setting_AddMLA.aspx.cs" Inherits="PWdEEBudget.Setting_AddMLA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .c {
            font-weight: bold;
            color: #000000;
            width: 100% !important;
            font-size: 16px;
            height: 38px !important;
            line-height: 38px !important;
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
            text-align: justify;
        }

        th {
            background-color: #2c3e50;
            color: #fff;
              text-align: center;
        }
    </style>
    <style>
        @media only screen and (min-width:768px) {
            /*desktop*/

        }

        @media only screen and (max-width:500px) {
         .btn {
                    width: 31% !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <%--<h4 style="padding-left: 300px"><b>Add Sabha</b> </h4>--%>
    <div class="container" style="width:50%;">
        <table class="table table-bordered mar" style="margin-top:4%">
            <tr>
                <th colspan="3"><h2>ADD MLA / MP</h2></th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblId1" runat="server" Text="ID"></asp:Label></td>
                <td colspan="2">
                    <asp:Label ID="lblId" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="MLA/MP"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlMLAType" runat="server" CssClass="form-control c" OnSelectedIndexChanged="ddlMLAType_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Choose</asp:ListItem>
                        <asp:ListItem>Amdar</asp:ListItem>
                        <asp:ListItem>Khasdar</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlsabha" runat="server" CssClass="form-control c" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="MLA/MP Name"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="txtName" runat="server" class="form-control c"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    <asp:Button ID="Button1" runat="server" Text="BACK" CssClass="btn btn-primary" OnClick="Button1_Click" />
                    <asp:Button ID="btnCancle" runat="server" Text="CANCEL" CssClass="btn btn-primary" OnClick="btnCancle_Click" />
                </td>
            </tr>
        </table>
 </div>
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>&nbsp;
    <div class="container" style="width:70%;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" AutoGenerateEditButton="true" DataKeyNames="AKrmank" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <%--<asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />--%>
                <asp:TemplateField HeaderText="AKrmank">
                    <ItemTemplate>
                        <asp:Label ID="lblAKrmank" runat="server" Text='<%# Eval("AKrmank")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MLAType">
                    <ItemTemplate>
                        <asp:Label ID="lblMLAType" runat="server" Text='<%# Eval("MLAType")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" TextMode="MultiLine" Text='<%# Eval("Name") %>' />
                        <asp:Label ID="oldNamelbl" runat="server" Text='<%# Eval("Name") %>' Visible="false"></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
   </div>

    <script>
        jQuery("a").filter(function () {
            return this.innerHTML.indexOf("Delete") == 0;
        }).click(function () {
            return confirm("Are you sure you want to delete this record?");
        });
    </script>
</asp:Content>
