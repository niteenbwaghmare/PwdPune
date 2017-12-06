<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Report_LekhasirshNabard.aspx.cs" Inherits="PWdEEBudget.Report_LekhasirshNabard" %>

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
                    <h1>NABARD Report</h1>
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
                <div class="col-md-2">
                    <asp:Button ID="btnKamacheYear" runat="server" CssClass="form-control p btnform" Text="OK" OnClick="btnKamacheYear_Click" Width="100px" />
                </div>
            </div>

            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="RIDF NO" Font-Bold="True" CssClass="form-control c"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-control c" Style="width: 100%;" ForeColor="Black" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="ReportTypebtn" runat="server" OnClick="ReportTypebtn_Click" Text="OK" CssClass="form-control btnform" Width="100px" />
                </div>
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
                <div class="col-md-2">
                    <asp:Button ID="btnUpvibhag" runat="server" OnClick="btnUpvibhag_Click" Text="OK" CssClass="form-control btnform" Width="100px" />
                </div>
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
                <div class="col-md-2">
                    <asp:Button ID="btnShakhaAbhiyanta" runat="server" OnClick="btnShakhaAbhiyanta_Click" Text="OK" CssClass="form-control" Width="100px" />
                </div>
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
                <div class="col-md-2">
                    <asp:Button ID="btnWorkId" runat="server" Text="OK" OnClick="btnWorkId_Click" CssClass="form-control btnform" Width="100px" />
                </div>
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
                <div class="col-md-2">
                    <asp:Button ID="btnthekedar" runat="server" Text="OK" OnClick="btnthekedar_Click" CssClass="form-control btnform" Width="100px" />
                </div>
            </div>
            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Text="कामाची सद्यस्थिती" CssClass="form-control c"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlsadyasthiti" runat="server" CssClass="form-control c">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnkamachisadyasthiti" runat="server" Text="OK" OnClick="btnkamachisadyasthiti_Click" CssClass="form-control btnform" Width="100px" />
                </div>
            </div>
             </div>
               </div>
            <br />
             <%-- <asp:Button runat="server" Text="Show/Hide" ID="btnHideList" OnClick="btnHideList_Click"/>--%>
<div class="ddlList col-lg-1">Show/Hide List</div>
            <Hr />
           
            <div id="DivRoot" align="left">
                <div style="overflow: hidden;" id="DivHeaderRow">
                </div>

                <div style="overflow: scroll;" onscroll="OnScrollDiv(this)" id="DivMainContent">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowSorting="True" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <%--SELECT ROW_NUMBER() OVER(PARTITION BY a.[RDF_NO] ORDER BY a.[Taluka]) as 'Sr.No'
	  ,a.[RDF_NO] as 'RIDF'
      ,a.[Dist] as 'District' 
      ,a.[Taluka] as 'Taluka'
      ,a.[KamacheName] as 'Name of Work'
      ,a.[PIC_NO] as 'PIC.No'
      ,a.[PrashaskiyAmt] as 'AA Cost Rs in lakhs'
      ,a.[TrantrikAmt] as 'Ts Cost Rs in lakhs'
      ,convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'Ts No and Date'
      ,b.[MarchEndingExpn] as 'Expenditure up to MAr 2016 in Lakhs'
      ,b.[Tartud] as 'Budget Provision in 16-17 Rs in lakhs'
      ,b.[Magni] as 'Demand for 2016-17 Rs in lakhs'
      ,b.[Magilkharch] as 'Expenditure up to /2016 during year 16-17 Rs n Lakhs'
      ,a.[Sadyasthiti] as 'Physical progress of work'
      ,a.[Pahanikramank] as 'Probable of date of completion' 
      ,a.[PCR] as 'PCR submitted or not'
      ,a.[Shera] as 'Remark' 
      
      from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID
                            --%>
                            <asp:BoundField DataField="Sr.No" HeaderText="1"></asp:BoundField>
                            <asp:BoundField DataField="District" HeaderText="2"></asp:BoundField>
                            <asp:BoundField DataField="Taluka" HeaderText="3"></asp:BoundField>
                            <asp:BoundField DataField="Name of Work" HeaderText="4"></asp:BoundField>
                            <asp:BoundField DataField="PIC.No" HeaderText="5"></asp:BoundField>
                            <asp:BoundField DataField="AA Cost Rs in lakhs" HeaderText="6"></asp:BoundField>
                            <asp:BoundField DataField="Ts Cost Rs in lakhs" HeaderText="7"></asp:BoundField>
                            <asp:BoundField DataField="Ts No and Date" HeaderText="8"></asp:BoundField>
                            <asp:BoundField DataField="MarchEndingExpn" HeaderText="9"></asp:BoundField>
                            <asp:BoundField DataField="Tartud" HeaderText="10"></asp:BoundField>
                            <asp:BoundField DataField="Magni" HeaderText="11"></asp:BoundField>
                            <asp:BoundField DataField="Magilkharch" HeaderText="12"></asp:BoundField>
                            <asp:BoundField DataField="Physical progress of work" HeaderText="13"></asp:BoundField>
                            <asp:BoundField DataField="Probable of date of completion" HeaderText="14"></asp:BoundField>
                            <asp:BoundField DataField="PCR submitted or not" HeaderText="15"></asp:BoundField>
                            <asp:BoundField DataField="Remark" HeaderText="16"></asp:BoundField>
                        </Columns>
                          <EmptyDataTemplate >
                            No Matching Record Found....!!!!!
                        </EmptyDataTemplate>
                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                    </asp:GridView>
                    <%--</asp:Panel>--%>
                </div>
            </div>         

        </ContentTemplate>
    </asp:UpdatePanel>
    <div align="center">
        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary btnform" Height="40px" Width="100px" OnClick="btnPrint_Click1" />
        <asp:Button ID="BtnExcel" runat="server" Text="Excel" CssClass="btn btn-success btnform" Height="40px" Width="100px" OnClick="BtnExcel_Click" />
       <%-- <asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-info" Height="40px" Width="100px" OnClientClick="PrintGrid()" />--%>
        <asp:Button ID="btnSendMail" runat="server" OnClick="btnSendMail_Click" CssClass="btn btn-warning btnform" Height="40px" Width="100px" Text="Send Mail" />
        <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-danger btnform" Text="Cancel" Height="40px" Width="100px" OnClick="BtnCancel_Click" />
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default btnform" BackColor="#660000"  OnClientClick="JavaScript:window.history.back(1); return false;" Height="40px" Width="100px" />
    </div>
    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=GridView1.ClientID %>');
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
                DivHR.style.height = '156px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '10';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -156 + 'px';
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
