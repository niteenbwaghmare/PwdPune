<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="MPR Report.aspx.cs" Inherits="PWdEEBudget.MPR_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*.wid {
         width:30%;height:60px;
         text-align:center;
         margin-top:5%;
         }
     .wid :hover { 
    border:5px solid #0ff;
}*/
        .butt {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 12px 24px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 20px;
            margin: 4px 2px;
            -webkit-transition-duration: 0.4s; /* Safari */
            transition-duration: 0.4s;
            cursor: pointer;
            width: 300px;
            height: 60px;
        }


        .button5 {
            background-color: rgba(44, 62, 80, 0.89);
            color: white;
            border: 2px solid #555555;
        }

            .button5:hover {
                background-color: #ffebcd;
                color: #716f6f;
            }

        .block {
            position: relative;
            width: 100%;
            height: auto;
            background-color: #FFF;
            margin: 10px;
            float: left;
            left: -10px;
            text-align: center;
            padding: 10px;
            border: solid 1px #CCC;
            font-size: small;
        }
          h3 {
    color: brown;
    font-size: 36px;
    text-shadow: 2px 2px 4px rgb(166, 157, 157);
        }
    </style>
    <style>
        @media only screen and (min-width:768px) {
            /*desktop*/
            
        }

        @media only screen and (max-width:500px) {
         .block {
             padding:0 !important;
         }            
        }

        /*.pwdhead {
            margin-top: 20px;
            margin-bottom: 10px;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="block" style="padding: 80px">
        <div><h3>MPR Report</h3></div><br />
        <asp:ImageButton ID="ImgBuildingMPR" class="butt button5" runat="server" value="BUILDING MPR" Text="BUILDING MPR" OnClick="ImgBuildingMPR_Click" />
        <asp:ImageButton ID="ImgCRF" class="butt button5" runat="server" value="CRF MPR" Text="CRF MPR" OnClick="ImgCRF_Click" />
        <asp:ImageButton ID="ImgNabard" class="butt button5" runat="server" value="NABARD MPR" Text="NABARD MPR" OnClick="ImgNabard_Click" /><br />
        <br />
        <asp:ImageButton ID="ImgRoad" class="butt button5" runat="server" value="SH & DOR MPR" Text="SH & DOR MPR" OnClick="ImgRoad_Click" />
        <asp:ImageButton ID="ImgDPDC" class="butt button5" runat="server" value="DPDC MPR" Text="DPDC MPR" OnClick="ImgDPDC_Click" />
        <asp:ImageButton ID="ImageMLA" class="butt button5" runat="server" value="MLA FUND MPR" Text="MLA FUND MPR" OnClick="ImageMLA_Click" /><br />
        <br />
        <asp:ImageButton ID="ImageMP" class="butt button5" runat="server" value="MP FUND MPR" Text="MP FUND MPR" OnClick="ImageMP_Click" />
        <asp:ImageButton ID="ImgDeposit" class="butt button5" runat="server" value="DEPOSIT FUND MPR" Text="DEPOSIT FUND MPR" OnClick="ImgDeposit_Click" />
        <asp:ImageButton ID="ImageGat_A" class="butt button5" runat="server" value="GAT_A MPR" Text="GAT_A MPR" OnClick="ImageGat_A_Click" /><br />
        <br />
        <asp:ImageButton ID="ImageGat_B" class="butt button5" runat="server" value="GAT_B MPR" Text="GAT_B MPR" OnClick="ImageGat_B_Click" />
        <asp:ImageButton ID="ImageGat_C" class="butt button5" runat="server" value="GAT_C MPR" Text="GAT_C MPR" OnClick="ImageGat_C_Click" />
        <asp:ImageButton ID="ImageGat_D" class="butt button5" runat="server" value="GAT_D MPR" Text="GAT_D MPR" OnClick="ImageGat_D_Click" /><br />
        <br />
        <asp:ImageButton ID="ImageGat_F" class="butt button5" runat="server" value="GAT_F MPR" Text="GAT_F MPR" OnClick="ImageGat_F_Click" />
        <asp:ImageButton ID="ImageAunty" class="butt button5" runat="server" value="ANNUITY MPR" Text="ANNUITY MPR" OnClick="ImageAunty_Click" />
        <asp:ImageButton ID="ImageResidentialBuliding" class="butt button5" runat="server" value="2216-Res.Building MPR" Text="2216-Res.Building MPR" OnClick="ImageResidentialBuliding_Click"  /><br />
        <br />
        <asp:ImageButton ID="ImageNonResidentialBuliding" class="butt button5" runat="server" value="2059-NonRes.Building MPR" Text="2059-NonRes.Building MPR" OnClick="ImageNonResidentialBuliding_Click" /> 
        <asp:ImageButton ID="ImageGramvikas" class="butt button5" runat="server" value="2515-Gramvikas MPR" Text="2515-Gramvikas MPR" OnClick="ImageGramvikas_Click" />

    </div>

</asp:Content>
