<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="SettingSMS.aspx.cs" Inherits="PWdEEBudget.SettingSMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
    </style>
    <style>
        @media only screen and (min-width:768px) {
            /*desktop*/

        }

        @media only screen and (max-width:500px) {
            .table {
                width: 100% !important;
            }

            #topcontrol {
                right: 20px !important;
            }
            .btn {
                    width: 46% !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background: linear-gradient(#ccc,#fae8bd);width: 40%;margin-left: 30%;border: 1px solid;border-radius: 7px;">

        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <table class="table mar"  style=" text-align:center;">
            <tr>
                <th colspan="2" style=" text-align: center;">
                    <h2>Send SMS</h2>
                    <hr />
                </th>
            </tr>
            <tr>
                <td colspan="2" style="padding-left: 24%;">
                    <asp:DropDownList ID="ddltransroute" runat="server" style="width: 70%;" CssClass="form-control">
                        <asp:ListItem Text="Transaction Route"></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                
                <td colspan="2" style="width: 150px; font-weight: bold; color: #000000;">Sender Id  :
                    <asp:Label ID="lblsenderId" runat="server" Text=" EEesPN"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 150px; font-weight: bold; color: #000000;" colspan="2">Mobile No:<br />
                    <asp:TextBox ID="txtmobileno" runat="server" PlaceHolder="Type Your No Here" TextMode="MultiLine" Style="width: 338px; height: 133px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 150px; font-weight: bold; color: #000000;" colspan="2">Description:<br />
                    <asp:TextBox ID="txtdescription" runat="server" PlaceHolder="Type Your Message Here" TextMode="MultiLine" Style="width: 338px; height: 133px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td colspan="2" style="    text-align: center;">
                    <asp:Button ID="Button1" runat="server" Text="SEND" OnClick="Button1_Click" CssClass="btn btn-info" />
                    <asp:Button ID="Button4" runat="server" Text="BACK" OnClick="Button4_Click" CssClass="btn btn-danger" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

