<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="BillStatusReport.aspx.cs" Inherits="PWdEEBudget.BillStatusReport" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
         table {
             width: 100%;
         }

         table, th, td {
             border: 1px solid black;
             border-collapse: collapse;
             text-align: center;
         }

         tbody, tr, td {
             text-align: left;
         }

         .c {
             width: 100% !important;
             height: 100% !important;
             font-size: 16px;
         }

         .p {
             height: 100% !important;
             font-size: 16px;
         }

         th, td {
             padding: 10px;
             /*width: 100% !important;*/
         }

         th {
             background-color: #2c3e50;
             color: #fff;
         }

         .EmptyData > td {
             background-color: yellow;
             color: red;
             text-align: center!important;
         }

         .ExcelDwnld {
             width: 41%;
             margin-left: 55%;
             background-color: white!important;
             background: linear-gradient(white,white)!important;
         }
     </style>


    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            
     <div class="container">
                <div id="ListMenu" runat="server" style="margin-top: 20px" class="ddlListHide">
                    <div class="row" style="border: 2px solid red; background-color: gray;">
                        <div class="col-md-12" style="text-align: center; color: #fff">
                            <h1>Bill Status</h1>
                        </div>
                    </div>

                    <div class="row" style="border: 2px solid; background-color: gray; margin-top: 2px"">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblArthYear" runat="server" CssClass="form-control p" Text="Budget Year:" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList runat="server" ID="ddlArthYear" CssClass="form-control p"  ForeColor="Black"> 
                   </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVArthYear" runat="server" ControlToValidate="ddlArthYear"
                ErrorMessage="अर्थसंकल्पीय वर्ष निवडा!" InitialValue="0" ForeColor="red"  Font-Size="Larger" Display="Dynamic" CssClass="blink_me" BackColor="Yellow"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                          
                        <asp:Button ID="btnArthYear" runat="server" Text="OK"  CssClass="form-control" Width="100px"  OnClick="btnArthYear_Click"/>
                        </div>

                    </div>

                    <div class="row" style="border: 2px solid; background-color: gray;" >
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblHeadName" runat="server" CssClass="form-control p" Text="Select Head:" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                                  <asp:DropDownList ID="ddlHeadName" runat="server" CssClass="form-control">
                            <asp:ListItem>निवडा</asp:ListItem>
                            <asp:ListItem>Annuity</asp:ListItem>
                            <asp:ListItem>Building</asp:ListItem>
                            <asp:ListItem>CRF</asp:ListItem>
                            <asp:ListItem>DepositFund</asp:ListItem>
                            <asp:ListItem>DPDC</asp:ListItem>
                            <asp:ListItem>Gat_A</asp:ListItem>
                            <asp:ListItem>Gat_FBC</asp:ListItem>
                            <asp:ListItem>Gat_D</asp:ListItem>
                            <asp:ListItem>Gramvikas(2515)</asp:ListItem>
                            <asp:ListItem>MLA</asp:ListItem>
                            <asp:ListItem>MP</asp:ListItem>
                            <asp:ListItem>Nabard</asp:ListItem>
                            <asp:ListItem>NonResidentialBuilding(2059)</asp:ListItem>
                            <asp:ListItem>ResidentialBuilding(2216)</asp:ListItem>
                            <asp:ListItem>SH & DOR</asp:ListItem>
                        </asp:DropDownList>
               </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnHeadName" runat="server" CssClass="form-control " Text="OK"  Width="100px" OnClick="btnHeadName_Click"/>
                        </div>
                    </div>

                    <div class="row" style="border: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblBillType" runat="server" Text="Bill Type:" CssClass="form-control p" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlBillType" runat="server" CssClass="form-control p"  ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                                <asp:ListItem Value=",[Bill_1_Amt]as'1st Bill Amt',[Bill_1_Date]as'1st Bill Date'">1st</asp:ListItem>
                                <asp:ListItem Value=",[Bill_2_Amt]as'2nd Bill Amt',[Bill_2_Date]as'2nd Bill Date'">2nd</asp:ListItem>
                                <asp:ListItem Value=",[Bill_3_Amt]as'3rd Bill Amt',[Bill_3_Date]as'3rd Bill Date'">3rd</asp:ListItem>
                                <asp:ListItem Value=",[Bill_4_Amt]as'4th Bill Amt',[Bill_4_Date]as'4th Bill Date'">4th</asp:ListItem>
                                <asp:ListItem Value=",[Bill_5_Amt]as'5th Bill Amt',[Bill_5_Date]as'5th Bill Date'">5th</asp:ListItem>
                                <asp:ListItem Value=",[Bill_6_Amt]as'6th Bill Amt',[Bill_6_Date]as'6th Bill Date'">6th</asp:ListItem>
                                <asp:ListItem Value=",[Bill_7_Amt]as'7th Bill Amt',[Bill_7_Date]as'7th Bill Date'">7th</asp:ListItem>
                                <asp:ListItem Value=",[Bill_8_Amt]as'8th Bill Amt',[Bill_8_Date]as'8th Bill Date'">8th</asp:ListItem>
                                <asp:ListItem Value=",[Bill_9_Amt]as'9th Bill Amt',[Bill_9_Date]as'9th Bill Date'">9th</asp:ListItem>                               
                                <asp:ListItem Value=",[Bill_final_Amt]as'Final Bill Amt',[Bill_final_Date]as'Final Bill Date'">Final</asp:ListItem>

                            </asp:DropDownList>
                          
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnBillType" runat="server" CssClass="form-control " Text="OK"  Width="100px" OnClick="btnBillType_Click" />
                        </div>

                    </div>

               </div>
           </div> 

    <br />
    <hr />
            </ContentTemplate>

            </asp:UpdatePanel>
              <div style="float:right">
   
        <%--<asp:ImageButton runat="server" ID="btnImgExcel" ImageUrl="~/logo/green-download-button-mid.png" OnClick="btnImgExcel_Click" CssClass="ExcelDwnld" BackColor="White"/>--%>
                     <div class="DownloadExcel"><img src="logo/green-download-button-mid.png" class="ExcelDwnld" /></div>
        </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="excel">    
                         <asp:Label runat="server" ID="lbl">
     <div align="center">
   <table>
       <tr>
           <th style="text-align:center">Bill Status</th>
       </tr>
       <tr>
           <td>
               
               <asp:GridView runat="server" ID="GridView1"   AutoGenerateColumns="true" Font-Bold="true" AllowSorting="true" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" >
                   <Columns>
                       
                     <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                         
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                     
                 
                   </Columns>
                   <EmptyDataTemplate>
                     
                       <asp:Label runat="server" Text="No Data Found"></asp:Label>
                   </EmptyDataTemplate>
                   <RowStyle HorizontalAlign="Center" />
                   <EmptyDataRowStyle  BorderStyle="Groove"  CssClass="EmptyData blink_me"/>
               </asp:GridView>
           </td>
       </tr>
   </table>
         </asp:Label>
                </div>
       
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <script type="text/javascript">
        $(".DownloadExcel").click(function (e) {
           
            window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('#excel').html())); // content is the id of the DIV element  
            e.preventDefault();   
        });   
            
        
    </script>
</asp:Content>
