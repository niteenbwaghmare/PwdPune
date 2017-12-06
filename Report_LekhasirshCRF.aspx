<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Report_LekhasirshCRF.aspx.cs" Inherits="PWdEEBudget.Report_LekhasirshCRF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #CalendarExtender1 {
            padding: 0px 0px;
        }

        .c {
            font-weight: bold;
            color: #000000;
            width: 100% !important;
            font-size: 16px;
            height: 38px !important;
            line-height: 38px !important;
        }

        th {
            font-weight: bold;
            color: #fff;
            background-color: #2c3e50;
            font-size: 20px;
            text-align: center;
        }

        td {           
            font-size: 18px;
            text-align: left;
        }

        tr {
            vertical-align: top;
        }
    </style>

    <style>
         @media only screen and (min-width:768px) {
             /*desktop*/

         }

         @media only screen and (max-width:500px) {           

             .btnform {
                 width: 18% !important;
                 height: 28px !important;
             }
             .c {
                font-weight: bold !important;
                color: #000000 !important;
                width: 100% !important;
                font-size: 12px !important;
                height: 28px !important;
                line-height: 20px !important;
            }
         }
     </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
        <ProgressTemplate>
            <div class="loading" align="center">
                <img alt="progress" src="loader.gif" />
                <br />
                <b>Processing....</b>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="container">
              <div id="ListMenu" runat="server" style="margin-top: 20px" class="ddlListHide">

            <asp:Label ID="lblshirsh" runat="server" Visible="false"></asp:Label>
            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-12" style="text-align: center; color: #fff">
                    <h1>CRF Report</h1>
                </div>
            </div>

            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="lblArthYear" runat="server" CssClass="form-control c" Text="अर्थसंकल्पीय वर्ष:"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlArthYear" runat="server" CssClass="form-control c">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                </div>
            </div>

            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="lblKamacheyear" runat="server" CssClass="form-control c" Text="कामाचे वर्ष:"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlkamacheYear" runat="server" CssClass="form-control c">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnKamacheYear" runat="server" CssClass="form-control p btnform" Text="OK" OnClick="btnKamacheYear_Click" Width="100px"  />
                     <div class="col-md-1"></div>
                </div>
            </div>

            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="CRF No" Font-Bold="True" CssClass="form-control c"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-control c" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" AutoPostBack="true" Style="width: 100%;" ForeColor="Black">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="ReportTypebtn" runat="server" OnClick="ReportTypebtn_Click" Text="OK" CssClass="form-control btnform" Width="100px" />
                </div>
                 <div class="col-md-1"></div>
            </div>
            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="उपविभाग" CssClass="form-control c"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlUpvibhag" runat="server" CssClass="form-control c">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnUpvibhag" runat="server" OnClick="btnUpvibhag_Click" Text="OK" CssClass="form-control btnform" Width="100px"  />
                </div>
                 <div class="col-md-1"></div>
            </div>

            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="उपअभियंता" CssClass="form-control c"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlshakhaabhiyanta" runat="server" CssClass="form-control c">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnShakhaAbhiyanta" runat="server" OnClick="btnShakhaAbhiyanta_Click" Text="OK" CssClass="form-control btnform" Width="100px" />
                </div>
                 <div class="col-md-1"></div>
            </div>
            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="Label4" runat="server" ForeColor="Black" Text="वर्क आयडी" CssClass="form-control c"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlworkId" runat="server" CssClass="form-control c">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnWorkId" runat="server" Text="OK" OnClick="btnWorkId_Click" CssClass="form-control btnform" Width="100px" />
                </div>
                 <div class="col-md-1"></div>
            </div>
            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="Label5" runat="server" ForeColor="Black" Text="ठेकेदाराचे नाव" CssClass="form-control c"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlthekedar" runat="server" CssClass="form-control c">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnthekedar" runat="server" Text="OK" OnClick="btnthekedar_Click" CssClass="form-control btnform" Width="100px" />
                </div>
                 <div class="col-md-1"></div>
            </div>
            <div class="row" style="border: 2px solid; background-color: gray;" >
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Text="कामाची सद्यस्थिती" CssClass="form-control c"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlsadyasthiti" runat="server" CssClass="form-control c">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnkamachisadyasthiti" runat="server" Text="OK" OnClick="btnkamachisadyasthiti_Click" CssClass="form-control btnform" Width="100px" />
                </div>
                 <div class="col-md-1"></div>
            </div>
                 </div>
         </div>

            <br />
            <%--<asp:Button runat="server" Text="Show/Hide" ID="btnHideList" OnClick="btnHideList_Click"/>--%>
            <div class="ddlList col-lg-1">Show/Hide List</div>

           
            <br />
            <div id="DivRoot" align="left">
                <div style="overflow: hidden;" id="DivHeaderRow">
                </div>

                <div style="overflow: scroll;" onscroll="OnScrollDiv(this)" id="DivMainContent">
                
                    <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" RowStyle-VerticalAlign="Top" Style="border: 2px solid" CssClass="Grid" DataKeyNames="WorkID"
                        OnRowDataBound="gvCustomers_RowDataBound" OnRowCreated="gvCustomers_RowCreated">

                        <Columns>                            
                            <asp:BoundField DataField="WorkIDl" HeaderText="1" />
                            <asp:BoundField DataField="Dist" HeaderText="2" />
                            <asp:BoundField DataField="Name of work" HeaderText="3" />
                            <asp:BoundField DataField="Job No" HeaderText="4" />
                            <asp:BoundField DataField="SanctionAmt" HeaderText="5" />
                            <asp:BoundField DataField="RoadLength" HeaderText="6" />
                            <asp:BoundField DataField="OBP" HeaderText="7" />
                            <asp:BoundField DataField="Eduringmon" HeaderText="8" />
                            <asp:BoundField DataField="CExpndrmonth" HeaderText="9" />
                            <asp:BoundField DataField="Demand" HeaderText="10" />
                            <asp:BoundField HeaderText="11" />
                            <asp:BoundField HeaderText="12" />
                            <asp:TemplateField>
                                <HeaderTemplate>13</HeaderTemplate>
                                <ItemTemplate>
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="A"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="APhysicalScope" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="B"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="BPhysicalScope" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="C"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="CPhysicalScope" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="D"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="DPhysicalScope" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="E"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="EPhysicalScope" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>14</HeaderTemplate>
                                <ItemTemplate>
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <asp:Label ID="ACommulative" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="BCommulative" runat="server" Text=""></asp:Label></td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="CCommulative" runat="server" Text=""></asp:Label></td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="DCommulative" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="ECommulative" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>15</HeaderTemplate>
                                <ItemTemplate>
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <asp:Label ID="ATarget" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="BTarget" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="CTarget" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="DTarget" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="ETarget" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>16</HeaderTemplate>
                                <ItemTemplate>
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <asp:Label ID="AAchievement" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="BAchievement" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="CAchievement" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="DAchievement" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="EAchievement" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Dateofstarting" HeaderText="17" />
                            <asp:BoundField DataField="Dateofcompletion" HeaderText="18" />
                            <asp:BoundField DataField="NameofAgency" HeaderText="19" />
                            <asp:BoundField DataField="Awardbelow" HeaderText="20" />
                            <asp:BoundField DataField="Tenderedamount" HeaderText="21" />
                            <asp:BoundField DataField="submissiontoMORTH" HeaderText="22" />
                            <asp:BoundField DataField="CompletionMORTH" HeaderText="23" />
                            <asp:BoundField DataField="Reasons" HeaderText="24" />
                            <asp:BoundField DataField="Remarks" HeaderText="25" />

                        </Columns>
                          <EmptyDataTemplate >
                            No Matching Record Found....!!!!!
                        </EmptyDataTemplate>
                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                    </asp:GridView>

                    <br />
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
    <div align="center">
        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary btnform" Height="40px" Width="100px" OnClick="btnPrint_Click1" />
        <asp:Button ID="BtnExcel" runat="server" Text="Excel" CssClass="btn btn-success btnform" Height="40px" Width="100px" OnClick="BtnExcel_Click1" />
        <%--<asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-info" Height="40px" Width="100px" OnClientClick="PrintGrid()" />--%>
        <asp:Button ID="btnSendMail" runat="server" OnClick="btnSendMail_Click" class="btn btn-warning btnform" Height="40px" Width="100px" Text="Send Mail" />
        <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-danger btnform" Text="Cancel" Height="40px" Width="100px" OnClick="BtnCancel_Click" />
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default btnform" BackColor="#660000"  OnClientClick="JavaScript:window.history.back(1); return false;" Height="40px" Width="100px" />
    </div>
    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=gvCustomers.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>
    <script lang="javascript" type="text/javascript">

        function PrintGrid() {
            var prtGrid = document.getElementById('Print');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=0,top=0,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);

        }
    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRow');
                var DivMC = document.getElementById('DivMainContent');
                var DivFR = document.getElementById('DivFooterRow');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '363px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '10';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -363 + 'px';
                DivMC.style.zIndex = '1';
                DivHR.appendChild(tbl.cloneNode(true));
            }
        }


        function OnScrollDiv(Scrollablediv) {
            document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
        }
    </script>
</asp:Content>
