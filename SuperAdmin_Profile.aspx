<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="SuperAdmin_Profile.aspx.cs" Inherits="PWdEEBudget.SuperAdmin_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <h3 style="text-align: center; color: darkblue">User Profile</h3>
    <div style="overflow-x: auto">

        <table id="material" class="table table-bordered mar" style="color: #000;">
            <tr>
                <td>
                    <asp:Label ID="Label19" runat="server" Text="1) फोटो:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Image ID="imgPhoto" runat="server" Style="width: 115px;" /><br />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="1) युझरचा क्र:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblID" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
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
                    <asp:Label ID="Label6" runat="server" Text="5) कार्यालय पत्ता:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblKarAdd" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="6) कायमचा पत्ता:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblkaymchaAdd" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="7) सध्याचा पत्ता:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLocalAdd" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="8) जन्म दिनांक:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDoB" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="9) नोंदणी दिनांक:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblNodaniDate" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="10) जेन्डर:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblFemale" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="11) स्टेट्स:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="12) गाव:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblVilage" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="13) तालुका:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTaluka" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="14) जिल्हा:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblJila" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label16" runat="server" Text="15) राष्ट्रीयत्व:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lablRastiyatv" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
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
                    <asp:Label ID="Label18" runat="server" Text="17) इ-मेल:-" Style="color: black;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Style="color: black;" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
