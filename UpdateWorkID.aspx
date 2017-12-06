<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="UpdateWorkID.aspx.cs" Inherits="PWdEEBudget.UpdateWorkID" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pageCenter {
            margin-left: auto;
            margin-right: auto;
        }

        .c {
            font-weight: bold;
            color: #000000;
            width: 100% !important;
            font-size: 16px;
            height: 38px !important;
            line-height: 38px !important;
        }

        td {
            text-align: center;
        }
        th {
            font-size:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <table class="table table-bordered" style="color: #000; margin-top:5%">
            <tr>
                <th colspan="4"  style="text-align:center"><h2>Update WorkID & Budget Year</h2></th>       
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl" runat="server" Text="Select Type"></asp:Label></td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control c" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl1" runat="server" Text="WorkID"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="txtoldWorkID" runat="server" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtoldWorkID_TextChanged" required=""></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10" CompletionSetCount="1" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="GetCompletionList" TargetControlID="txtoldWorkID">
                    </ajaxToolkit:AutoCompleteExtender>
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Edit WorkID" AutoPostBack="True" Checked="True" GroupName="A" OnCheckedChanged="RadioButton1_CheckedChanged" />
                </td>
                <td colspan="2">
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Edit Budget Year" AutoPostBack="True" GroupName="A" OnCheckedChanged="RadioButton2_CheckedChanged" />
                </td>
            </tr>

            <tr>
                <td rowspan="2">
                    <asp:Label ID="lbl3" runat="server" Text="New WorK_ID"></asp:Label>
                </td>
                <td rowspan="2">
                    <asp:TextBox ID="txtNewWorkID" runat="server" CssClass="form-control c"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Old Budget Year"></asp:Label>
                </td>
                <td>

                    <asp:TextBox ID="txtOldYear" runat="server" CssClass="form-control c" MaxLength="4" PlaceHolder="वर्ष" AutoPostBack="True" OnTextChanged="txtOldYear_TextChanged"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="New Budget Year"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNewYear" runat="server" CssClass="form-control c" MaxLength="4" PlaceHolder="वर्ष" AutoPostBack="True" OnTextChanged="txtNewYear_TextChanged"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="4">
                    <asp:Button ID="btnWorkid" runat="server" Text="Update" BackColor="#FFFFCC" BorderColor="#CCCCFF" BorderStyle="Solid" OnClick="btnWorkid_Click" /></td>
            </tr>

        </table>
    </div>
    <div style="overflow-x: auto;" align="center" class="b">

        <br />        
        &nbsp;&nbsp;
        <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
            <ProgressTemplate>
                <div class="loading" align="center">
                    <img alt="progress" src="loader.gif" />
                    <br />
                    <b>Processing....</b>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblStatus" runat="server"></asp:Label>&nbsp;
                <asp:GridView ID="GridView1" runat="server">
                    <HeaderStyle Font-Bold="True" Font-Names="Bell MT" Font-Size="8px" />
                </asp:GridView>

            </ContentTemplate>

        </asp:UpdatePanel>
    </div>
</asp:Content>
