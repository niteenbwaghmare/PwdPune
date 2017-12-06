<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Setting_Sms.aspx.cs" Inherits="PWdEEBudget.Setting_Sms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
         tbody, tr, td {
           text-align: left;
       }
        th {
            text-align:center;
        }
    </style>
     <style>
        @media only screen and (min-width:768px) {
            /*desktop*/

        }

        @media only screen and (max-width:500px) {
         .btn {
                    width: 32% !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
     <%--<h4 style="text-align: -webkit-center; font-weight: bold;">SMS</h4>--%>
    <div class="container">
          <table id="material" class="table table-bordered mar" style="color:#000;margin-top:5%">
              <tr>
                  <th colspan="2"><h2>SMS</h2></th>
              </tr>
           
               <tr>
                <td style="font-weight: bold; color: #000000" >Name:</td>
                <td >
                    <asp:Label ID="lblName" runat="server" ></asp:Label></td>
               
                </tr>
               <tr>
                <td style="font-weight: bold; color: #000000" >Post:</td>
                <td >
                    <asp:Label ID="lblPost" runat="server" ></asp:Label></td>
                
            </tr>
              <tr>
                <td style="font-weight: bold; color: #000000" >Date:</td>
                <td ><asp:TextBox ID="txtDate" runat="server" CssClass="form-control" PlaceHolder="Date" ></asp:TextBox></td>
                
            </tr>
                <tr>
                <td style="font-weight: bold; color: #000000" >SMS:</td>
                <td ><asp:TextBox ID="txtSMS" runat="server" CssClass="form-control" PlaceHolder="SMS" TextMode="MultiLine"></asp:TextBox></td>
                
            </tr>
              
             <tr>
                 <td></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="पाठवा" CssClass="btn btn-primary"   Height="30px" OnClick="Button1_Click" />
                   <asp:Button ID="Button2" runat="server"   Text="रद्द करा" CssClass="btn btn-danger" Height="31px"  CausesValidation="False"  />
                     <asp:Button ID="Button4" runat="server" Text="मागे" CssClass="btn btn-primary"   Height="30px" OnClick="Button4_Click" />
                </td>
             </tr>
            </table>


        </div>
             </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>
