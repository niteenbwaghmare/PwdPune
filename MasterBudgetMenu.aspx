<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="MasterBudgetMenu.aspx.cs" Inherits="PWdEEBudget.MasterBudgetMenu" %>
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
    width:300px;height:60px;
}


.button5 {
    /*background-color: #56244d;*/ 
      background-color: rgba(44, 62, 80, 0.89) ;
      color: white;
      border: 2px solid #555555;
}

.button5:hover {
        background-color: #ffebcd;
        /*color: white;*/
      /*color: #c1e7ef;*/
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
        <div><h3>Budget Form</h3></div><br />
        <asp:ImageButton ID="ImgBuildingMPR" class="butt button5" runat="server" value="BUILDING" Text="BUILDING" OnClick="ImgBuildingMPR_Click" />
        <asp:ImageButton ID="ImgCRF" class="butt button5" runat="server" value="CRF" Text="CRF"  OnClick="ImgCRF_Click"/>
        <asp:ImageButton ID="ImgNabard" class="butt button5" runat="server" value="NABARD" Text="NABARD"  OnClick="ImgNabard_Click" /><br /><br />
        <asp:ImageButton ID="ImgRoad" class="butt button5" runat="server" value="SH & DOR" Text="SH & DOR"  OnClick="ImgRoad_Click" />
        <asp:ImageButton ID="ImgDPDC" class="butt button5" runat="server" value="DPDC" Text="DPDC" OnClick="ImgDPDC_Click" />
        <asp:ImageButton ID="ImageMLA" class="butt button5" runat="server" value="MLA FUND" Text="MLA FUND" OnClick="ImageMLA_Click"  /> <br/><br />
        <asp:ImageButton ID="ImageMP" class="butt button5" runat="server" value="MP FUND" Text="MP FUND" OnClick="ImageMP_Click"/>
        <asp:ImageButton ID="ImgDeposit" class="butt button5" runat="server" value="DEPOSIT FUND" Text="DEPOSIT Fund" OnClick="ImgDeposit_Click" />
         <asp:ImageButton ID="ImageGat_A" class="butt button5" runat="server" value="GAT A / (AMC)" Text="GAT A / (AMC)" OnClick="ImageGat_A_Click" /> <br/> <br/>
        <asp:ImageButton ID="ImageGat_FBC" class="butt button5" runat="server" value="GAT F/B/C" Text="GAT F/B/C" OnClick="ImageGat_FBC_Click" /> 
        <asp:ImageButton ID="ImageGat_D" class="butt button5" runat="server" value="GAT D" Text="GAT D" OnClick="ImageGat_D_Click" />
        <asp:ImageButton ID="ImageAunty" class="butt button5" runat="server" value="ANNUITY" Text="ANNUITY" OnClick="ImageAunty_Click"/> <br /> <br />
        <asp:ImageButton ID="ImageResidentialBuilding" class="butt button5" runat="server" value="2216-Res.Building" Text="2216-Res.Building" OnClick="ImageResidentialBuilding_Click" />
        <asp:ImageButton ID="ImageNonResidentialBuilding" class="butt button5" runat="server" value="2059-NonRes.Building" Text="2059-NonRes.Building" OnClick="ImageNonResidentialBuilding_Click"/> 
        <asp:ImageButton ID="ImageGamvikas" class="butt button5" runat="server" value="2515-Gramvikas" Text="2515-Gramvikas" OnClick="ImageGamvikas_Click"/> 
   
         </div>

</asp:Content>
