<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="MasterReport.aspx.cs" Inherits="PWdEEBudget.MasterReport" %>

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
            font-size: 18px;
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
        <div><h3>Master HeadWise Report</h3></div><br />
        <asp:ImageButton ID="ImgBuildingMPR" class="butt button5" runat="server" value="BUILDING REPORT" Text="BUILDING REPORT" OnClick="ImgBuildingMPR_Click" />
        <asp:ImageButton ID="ImageGat_A" class="butt button5" runat="server" value="GAT_A REPORT" Text="GAT_A REPORT" OnClick="ImageGat_A_Click" />
        <asp:ImageButton ID="ImgCRF" class="butt button5" runat="server" value="CRF REPORT" Text="CRF REPORT" OnClick="ImgCRF_Click" /><br /><br />
        <asp:ImageButton ID="ImageGat_B" class="butt button5" runat="server" value="GAT_B REPORT" Text="GAT_B REPORT" OnClick="ImageGat_B_Click" /> 
        <asp:ImageButton ID="ImgNabard" class="butt button5" runat="server" value="NABARD REPORT" Text="NABARD REPORT" OnClick="ImgNabard_Click" />
        <asp:ImageButton ID="ImageGat_C" class="butt button5" runat="server" value="GAT_C REPORT" Text="GAT_C REPORT" OnClick="ImageGat_C_Click" /><br /><br />
        <asp:ImageButton ID="ImgRoad" class="butt button5" runat="server" value="SH & DOR Report" Text="SH & DOR Report" OnClick="ImgRoad_Click" />
        <asp:ImageButton ID="ImageGat_D" class="butt button5" runat="server" value="GAT_D REPORT" Text="GAT_D REPORT" OnClick="ImageGat_D_Click" />
        <asp:ImageButton ID="ImgDPDC" class="butt button5" runat="server" value="DPDC REPORT" Text="DPDC REPORT" OnClick="ImgDPDC_Click" /><br /><br />
        <asp:ImageButton ID="ImageGat_F" class="butt button5" runat="server" value="GAT_F REPORT" Text="GAT_F REPORT" OnClick="ImageGat_F_Click" />
        <asp:ImageButton ID="ImageMP" class="butt button5" runat="server" value="MP FUND REPORT" Text="MP FUND REPORT" OnClick="ImageMP_Click" />
        <asp:ImageButton ID="ImgDeposit" class="butt button5" runat="server" value="DEPOSIT FUND" Text="DEPOSIT FUND REPORT" OnClick="ImgDeposit_Click" /><br /><br />
        <asp:ImageButton ID="ImageMLA" class="butt button5" runat="server" value="MLA FUND REPORT" Text="MLA FUND REPORT" OnClick="ImageMLA_Click" />
        <asp:ImageButton ID="ImageAunty" class="butt button5" runat="server" value="ANNUITY REPORT" Text="ANNUITY REPORT" OnClick="ImageAunty_Click" />
        <asp:ImageButton ID="ImageResidentialBuliding" class="butt button5" runat="server" value="2216-Res.Building REPORT" Text="2216-Res.Building REPORT" OnClick="ImageResidentialBuliding_Click" /><br /><br />
        <asp:ImageButton ID="ImageNonResidentialBuliding" class="butt button5" runat="server" value="2059-NonRes.Building REPORT" Text="2059-NonRes.Building REPORT" OnClick="ImageNonResidentialBuliding_Click"  />
        <asp:ImageButton ID="ImageGramvikas" class="butt button5" runat="server" value="2515-REPORT" Text="2515-REPORT" OnClick="ImageGramvikas_Click"  />

    </div>

</asp:Content>
