<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="DBSReport.aspx.cs" Inherits="PWdEEBudget.DBSReport" %>

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
            /*background-color: #56244d;*/
            background-color: rgba(44, 62, 80, 0.89);
            color: white;
            border: 2px solid #555555;
        }

            .button5:hover {
                background-color: #ffebcd;
                /*color: white;*/
                /*color: #c1e7ef;*/
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
    </style>
    <style>
        @media only screen and (min-width:768px) {
            /*desktop*/

        }

        @media only screen and (max-width:500px) {
            .block {
                padding: 0 !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="block" style="padding: 80px">
        <asp:ImageButton ID="ImgDBSDivisionReport" class="butt button5" runat="server" value="Sub Division Wise Report" Text="Division Report" OnClick="ImgDBSDivisionReport_Click" />
        <asp:ImageButton ID="ImgDBSAllHead" class="butt button5" runat="server" value="All Head Wise Report" Text="All Head Report" OnClick="ImgDBSAllHead_Click" />
        <asp:ImageButton ID="ImgDBSIndividualReport" class="butt button5" runat="server" value="Individual Head Report" Text="Individual Head Report" OnClick="ImgDBSIndividualReport_Click" /><br />
        <br />
        <asp:ImageButton ID="ImgDBSStatistics" class="butt button5" runat="server" value="Statistics" Text="Statistics"
            OnClick="ImgDBSStatistics_Click" />
       
        <asp:ImageButton ID="ImgMontWiseReport" class="butt button5" runat="server" value="Month Wise Report" Text="Month Wise Report" OnClick="ImgMontWiseReport_Click" />
        <asp:ImageButton ID="ImageBetDateWiseReport" class="butt button5" runat="server" value="Date Wise Report" Text="Date Wise Report" OnClick="ImageBetDateWiseReport_Click" /><br />
        <br />
        <asp:ImageButton ID="ImageCostWiseReport" class="butt button5" runat="server" value="Cost Wise Report" Text="Cost Wise Report" OnClick="ImageCostWiseReport_Click" />
        <asp:ImageButton ID="ImageWorkIdWiseReport" class="butt button5" runat="server" value="WorkID Wise Report" Text="Work Id Wise Report" OnClick="ImageWorkIdWiseReport_Click" />
        <asp:ImageButton ID="ImageSMSReport" class="butt button5" runat="server" value="SMS Report" Text="SMS Report" OnClick="ImageSMSReport_Click" />
        <br />
        <br />
        <asp:ImageButton ID="ImageUserCred" class="butt button5" runat="server" value="User Cred Report" Text="User Credetial Report" OnClick="ImageUserCred_Click" />
       
        <asp:ImageButton ID="ImageBillStatus" class="butt button5" runat="server" value="Bill Status" Text="User Credetial Report" OnClick="ImageBillStatus_Click"/>
        
        <asp:ImageButton ID="ImageComplaint" class="butt button5" runat="server" value="Complaint" Text="User Credetial Report" OnClick="ImageComplaint_Click"/>
    </div>

</asp:Content>
