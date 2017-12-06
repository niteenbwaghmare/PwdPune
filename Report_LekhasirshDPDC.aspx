﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Report_LekhasirshDPDC.aspx.cs" Inherits="PWdEEBudget.Report_LekhasirshDPDC" %>

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
            <div class="container" style="margin-top:20px">
              <div id="ListMenu" runat="server" style="margin-top: 20px" class="ddlListHide">
   
            <asp:Label ID="lblshirsh" runat="server" Visible="false"></asp:Label>
            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-12" style="text-align: center; color: #fff">
                    <h1>DPDC Report</h1>
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
                    <asp:Button ID="btnKamacheYear" runat="server" CssClass="form-control p btnform" Text="OK" OnClick="btnKamacheYear_Click" Width="100px" />
                </div>
                  <div class="col-md-1"></div>
            </div>

            <div class="row" style="border: 2px solid; background-color: gray;">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="लेखाशीर्ष " Font-Bold="True" CssClass="form-control c"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-control c" Style="width: 100%;" ForeColor="Black" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" AutoPostBack="true">
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
                    <asp:Button ID="btnUpvibhag" runat="server" OnClick="btnUpvibhag_Click" Text="OK" CssClass="form-control btnform" Width="100px" />
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

            <hr />
            <%-- <div style="overflow-x: auto;">
                <div id="Print">
                    <asp:Panel ID="Panel1" runat="server">--%>

            <%--            <asp:Label ID="lekhashirshcode" runat="server" onsorting="GridView1_Sorting" Visible="true"></asp:Label>--%>
            <%-- <div align="center">
                            <asp:Label ID="lekhashirshcode" Style="font-weight: bold; font-size: 30px;" runat="server"></asp:Label>
                        </div>--%>
            <div id="DivRoot" align="left">
                <div style="overflow: hidden;" id="DivHeaderRow">
                </div>

                <div style="overflow: auto;" onscroll="OnScrollDiv(this)" id="DivMainContent">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowSorting="True" OnSorting="GridView1_Sorting" Style="border: 2px solid" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <%-- SELECT  ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as 'अ.क्र',a.[LekhaShirshName] as 'योजनेचे नाव',
b.[ComputerCRC] as 'सीआरसी (संगणक) संकेतांक', b.[ObjectCode] as 'उद्यीष्ट संकेतांक(ऑब्जेक्ट कोड)',
a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'योजनेचे / कामाचे नांव', 
 b.[ManjurAmt] as 'एकूण अंदाजित किंमत (अलिकडील सुधारित)',convert(nvarchar(max),a.[NividaAmt])+' '+
 convert(nvarchar(max),b.[MudatVadhiDate]) as 'सुधारित अंदाजित किंमतीचा दिनांक',
 b.[MarchEndingExpn] as 'मार्च 2016  अखेर पर्यंतचा एकूण खर्च',b.[ManjurAmt]
 as 'सन 2016-17 मधील अपेक्षित खर्च',b.[UrvaritAmt] as 'उर्वरित किंमत',
 b.[Tartud] as '2016-17 करीता प्रस्तावित तरतूद',a.[KamPurnDate] as 'काम पूर्ण होण्याचा अपेक्षित दिनांक',
 b.[Tartud]as 'काम निहाय तरतूद सन 2016-17',b.[AkunAnudan] as 'वितरीत तरतूद सन 2016-17',
 b.[Magilkharch] as 'खर्च सन 2016 - 17 06/16 अखेर',b.[Magni] as 'मागणी 2016-17',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN '1' ELSE N'0' END as nvarchar(max)) as 'पुर्ण',
 CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN '1' ELSE N'0' END as nvarchar(max)) as 'प्रगतीत',
 CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN '1' ELSE N'0' END as nvarchar(max)) as 'निविदा स्तर',a.[Shera] as 'शेरा'
 FROM BudgetMasterDPDC as a join DPDCProvision as b on a.Workid=b.Workid--%>
                            <asp:BoundField DataField="अर्थसंकल्पीय वर्ष" HeaderText="अर्थसंकल्पीय वर्ष"></asp:BoundField>
                            <asp:BoundField DataField="तालुका" HeaderText="तालुका"></asp:BoundField>
                            <asp:BoundField DataField="अ.क्र" HeaderText="1"></asp:BoundField>
                            <asp:BoundField DataField="योजनेचे नाव" HeaderText="2"></asp:BoundField>
                            <asp:BoundField DataField="सीआरसी (संगणक) संकेतांक" HeaderText="3"></asp:BoundField>
                            <asp:BoundField DataField="उद्यीष्ट संकेतांक(ऑब्जेक्ट कोड)" HeaderText="4"></asp:BoundField>
                            <asp:BoundField DataField="योजनेचे / कामाचे नांव" HeaderText="4"></asp:BoundField>
                            <asp:BoundField DataField="एकूण अंदाजित किंमत" HeaderText="5"></asp:BoundField>
                            <asp:BoundField DataField="सुधारित अंदाजित किंमतीचा दिनांक" HeaderText="6"></asp:BoundField>
                            <asp:BoundField DataField="MarchEndingExpn" HeaderText="7"></asp:BoundField>
                            <asp:BoundField DataField="ManjurAmt" HeaderText="8"></asp:BoundField>
                            <asp:BoundField DataField="UrvaritAmt" HeaderText="9"></asp:BoundField>
                            <asp:BoundField DataField="Tartud" HeaderText="10"></asp:BoundField>
                            <asp:BoundField DataField="काम पूर्ण होण्याचा अपेक्षित दिनांक" HeaderText="11"></asp:BoundField>
                            <asp:BoundField DataField="Tartud" HeaderText="12"></asp:BoundField>
                            <asp:BoundField DataField="AkunAnudan" HeaderText="13"></asp:BoundField>
                            <asp:BoundField DataField="Magilkharch" HeaderText="14"></asp:BoundField>
                            <asp:BoundField DataField="Magni" HeaderText="15"></asp:BoundField>
                            <asp:BoundField DataField="पुर्ण" HeaderText="16"></asp:BoundField>
                            <asp:BoundField DataField="प्रगतीत" HeaderText="17"></asp:BoundField>
                            <asp:BoundField DataField="निविदा स्तर" HeaderText="18"></asp:BoundField>
                            <asp:BoundField DataField="शेरा" HeaderText="19"></asp:BoundField>
                            <asp:BoundField HeaderText="20"></asp:BoundField>
                        </Columns>
                      <EmptyDataTemplate >
                           No Matching Record Found....!!!!!
                        </EmptyDataTemplate>
                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                    </asp:GridView>
                    
                    <%--</asp:Panel>--%>
                </div>
            </div>
            <br />

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
                DivHR.style.height = '186px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '10';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -186 + 'px';
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
