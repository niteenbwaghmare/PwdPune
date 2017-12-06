<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="SUpdate.aspx.cs" Inherits="PWdEEBudget.SUpdate" %>
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
    width:300px;
    height:60px;
}


.button5 {
   background-color: rgba(44, 62, 80, 0.89) ;
    color: white;
    border: 2px solid #555555;
}

.button5:hover {
    background-color: #ffebcd;
    color:#716f6f;
}
.block {
    position:relative;
    width:100%;
    height:auto;
    background-color:#FFF;
    margin:10px;
    float:left;
    left:-10px;
    text-align: center;
    padding:10px;
    border:solid 1px #CCC;
    font-size:small;
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

      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
       
    <div class="block" style="padding:80px">
        <div><h3>HeadWise Abstract Report</h3></div><br />
        <asp:ImageButton ID="ImgBuildingMPR" class="butt button5" runat="server" value="BUILDING REPORT" Text=" BUILDING REPORT" OnClick="ImgBuildingMPR_Click" />
        <asp:ImageButton ID="ImgCRF" class="butt button5" runat="server" value="CRF REPORT" Text=" CRF REPORT" OnClick="ImgCRF_Click"  />
        <asp:ImageButton ID="ImgNabard" class="butt button5" runat="server" value="NABARD PCR REPORT" Text="NABARD PCR REPORT" OnClick="ImgNabard_Click"  /><br /><br />
        <asp:ImageButton ID="ImgRoad" class="butt button5" runat="server" value="ROAD REPORT" Text="ROAD REPORT" OnClick="ImgRoad_Click" />
        <asp:ImageButton ID="ImgDPDC" class="butt button5" runat="server" value="DPDC REPORT" Text="DPDC REPORT" OnClick="ImgDPDC_Click"  /> 
         <asp:ImageButton ID="ImageMLA" class="butt button5" runat="server" value="MLA REPORT" Text="MLA REPORT" OnClick="ImageMLA_Click"  /><br /><br />
        <asp:ImageButton ID="ImageMP" class="butt button5" runat="server" value="MP REPORT" Text="MP REPORT" OnClick="ImageMP_Click" /> 
        <asp:ImageButton ID="ImgDeposit" class="butt button5" runat="server" value="DEPOSIT FUND" Text="DEPOSIT FUND REPORT" OnClick="ImgDeposit_Click"/>
         <asp:ImageButton ID="ImageGat_A" class="butt button5" runat="server" value="GAT_A REPORT" Text="GAT_A REPORT" OnClick="ImageGat_A_Click"/> <br /><br />
        <asp:ImageButton ID="ImageGat_B" class="butt button5" runat="server" value="GAT_B REPORT" Text="GAT_B REPORT" OnClick="ImageGat_B_Click" />        <asp:ImageButton ID="ImageGat_C" class="butt button5" runat="server" value="GAT_C REPORT" Text="GAT_C REPORT" OnClick="ImageGat_C_Click" />       
        <asp:ImageButton ID="ImageGat_D" class="butt button5" runat="server" value="GAT_D REPORT" Text="GAT_D REPORT" OnClick="ImageGat_D_Click"/><br /><br />  
        <asp:ImageButton ID="ImageGat_F" class="butt button5" runat="server" value="GAT_F REPORT" Text="GAT_F REPORT" OnClick="ImageGat_F_Click" />
        <asp:ImageButton ID="ImageAunty" class="butt button5" runat="server" value="ANNUITY REPORT" Text="ANNUITY REPORT" OnClick="ImageAunty_Click"/>
        <asp:ImageButton ID="ImageNRB" class="butt button5" runat="server" value="NonResidential Building REPORT" Text="NonResidential Building REPORT" OnClick="ImageNR_Click" /><br /><br />

        <asp:ImageButton ID="ImageRB" class="butt button5" runat="server" value="Residential Building REPORT" Text="Residential Building REPORT" OnClick="ImageRB_Click" />   
         <asp:ImageButton ID="ImageNabardMain" class="butt button5" runat="server" value="NABARD REPORT" Text="NABARD REPORT" OnClick="ImageNabardMain_Click"  />   
         <asp:ImageButton ID="ImageGramVikas2515" class="butt button5" runat="server" value="GramVikas 2515 REPORT" Text="GramVikas 2515 REPORT" OnClick="ImageGramVikas2515_Click"  />       
       
    </div>
            
</asp:Content>
