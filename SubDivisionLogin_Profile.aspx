<%@ Page Title="" Language="C#" MasterPageFile="~/SubDivision.Master" AutoEventWireup="true" CodeBehind="SubDivisionLogin_Profile.aspx.cs" Inherits="PWdEEBudget.SubDivisionLogin_Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .navbar-default .navbar-nav > li > a.ProfilePage {
            display: block !important;
            /*background-color: gray !important;*/
            background: linear-gradient(#3b5998,#00C6D7) !important;
            color: white !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h3 style="text-align: center; color: darkblue">User Profile</h3>
    <div style="overflow-x: auto">

        <table id="material" class="table table-bordered mar" style="color: #000;">
            <tr>
                <td>
                    <asp:Label ID="lblImage" runat="server" Text="1) फोटो:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Image ID="imgPhoto" runat="server" Style="width: 115px;" /><br />
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="2) युझरचे नाव:-" Style="color: black;" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="3) कार्यालय:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblKaryalay" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="4) पदनाम:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPost" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>         
                                    
            <tr>
                <td>
                    <asp:Label ID="Label17" runat="server" Text="16) मोबईल नं:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMob" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label18" runat="server" Text="17) ई-मेल:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label19" runat="server" Text="17) युसर आयडी:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblUserId" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label20" runat="server" Text="17) पासवर्ड:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
