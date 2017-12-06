<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="PWdEEBudget.Help" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .navbar-default .navbar-nav > li > a.HelpPage {
            display: block !important;
            /*background-color: gray !important;*/
            background: linear-gradient(#3b5998,#00C6D7) !important;
            color: white !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="border: 5px solid black; Width: 100%">
         <tr>
             <td>
 <div class="col-sm-6 col-md-3 col-lg-3" style="width: 100%;text-align: -webkit-center;">
                    <div >
                        <h4><span>SGHI-TECH SOFTWARE COMPANY,PUNE.</span></h4>
                    </div>
                    <div >
                       
                            <p><strong>Address</strong>: SGHI-TECH Swedaganga Society, Pasaydan Building, Warje Pune, 411058</p>
                            <p><strong>Phone 1</strong>: (+91) 9096408111</p>
                            <p><strong>Phone 2</strong>:  (+91) 9975408111</p>

                           <p><strong>Email</strong>:info@sghitech.co.in</p>
                            <p><strong>Web:</strong>www.sghitech.co.in <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"  CssClass="btn btn-primary" Height="23px" Width="50px"> Link</asp:LinkButton></p>
                           
                    </div>
                </div>
             </td>
         </tr>
         </table>
</asp:Content>
