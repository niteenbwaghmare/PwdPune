<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Report_MasterGAT_F.aspx.cs" Inherits="PWdEEBudget.Report_MasterGAT_F" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .trrr tr:hover {
            background-color: #75becb;
        }

        .pj {
            /*text-shadow: 0 1px 0 #ccc,
                            0 2px 0 #c9c9c9,
                            0 3px 0 #bbb,
                            0 4px 0 #b9b9b9,
                            0 5px 0 #aaa,
                            0 6px 1px rgba(0,0,0,.1),
                            0 0 5px rgba(0,0,0,.1),
                            0 1px 3px rgba(0,0,0,.3),
                            0 3px 5px rgba(0,0,0,.2),
                            0 5px 10px rgba(0,0,0,.25),
                            0 10px 10px rgba(0,0,0,.2),
                            0 20px 20px rgba(0,0,0,.15);*/
            font-size: 50px;
            color: #0e0505;
        }

        th {
            color: #fff;
            background-color: #2c3e50;
            font-weight: bold;
            font-size: 20px;
            padding: 3px;
            text-align: center;
        }

        td {
            color: #0e0505;
            font-size: 18px;
            /*text-align:center;*/
            padding: 3px;
        }

        tr {
            vertical-align: top;
        }

        .p {
            margin-left: 10%;
            margin-right: 10%;
            font-size: 18px;
            max-width: 80%;
            min-width: 79%;
        }

        .k {
            border-right: 1px solid #ddd;
        }

        @media print {
            input {
                display: none;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <link href="css/tblmargin.css" rel="stylesheet" />
            <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                <ProgressTemplate>
                    <div class="loading" align="center">
                        <img alt="progress" src="loader.gif" />
                        <br />
                        <b>Processing....</b>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="container">
                <div class="row" style="border: 2px solid; background-color: gray; margin-top: 10px">
                    <div class="col-md-12" style="text-align: center; color: #fff">
                        <h1>GAT_F Abstract Report</h1>
                    </div>
                </div>


                <div class="row" style="border: 2px solid; background-color: gray;">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblarthsankalpiyyear" runat="server" CssClass="form-control " Text="अर्थसंकल्पीय वर्ष:" Font-Bold="True" ForeColor="Black"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlArthsankalpiyYear" runat="server" Style="width: 100%;" CssClass="form-control p" ForeColor="Black">
                            <asp:ListItem>निवडा</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <%--   <asp:Button ID="btnworkid" runat="server" CssClass="form-control" Text="OK" OnClick="btnworkid_Click" />--%>
                    </div>
                </div>

                <div class="row" style="border: 2px solid; background-color: gray;">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblkamacheYr" runat="server" CssClass="form-control " Text="कामाचे वर्ष:" Font-Bold="True" ForeColor="Black"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlKamacheYr" runat="server" Style="width: 100%;" CssClass="form-control p" ForeColor="Black">
                            <asp:ListItem>निवडा</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <%-- <asp:Button ID="btnworkid" runat="server" CssClass="form-control" Text="OK" />--%>
                    </div>
                </div>

                <div class="row" style="border: 2px solid; background-color: gray;">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="उपविभाग:" Font-Bold="True" CssClass="form-control "></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-control p" Style="width: 100%;" ForeColor="Black">
                            <asp:ListItem>निवडा</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="ReportTypebtn" runat="server" OnClick="ReportTypebtn_Click" Text="OK" CssClass="form-control" Width="100px" />
                    </div>
                </div>
            </div>
            <br />
            <hr />
            <div id="PrintDiv" runat="server">
                <div class="col-md-12" style="text-align: center; color: #443030">
                    <h3 style="font-size: 24px;">GAT_F Abstract Report</h3>
                </div>
                <div align="center">

                    <asp:Label ID="lblPrintUpvibhag" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />
                    <asp:Label ID="lblPrintKamcacheyr" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />
                    <asp:Label ID="lblPrintArthSanalpYr" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />
                    <br />
                </div>
                <div id="DivRoot" align="left" style="width: 100%">
                    <div style="width: 100%">
                        <div style="overflow: hidden; width: 100%" id="DivHeaderRow">
                        </div>

                        <div style="overflow: auto; width: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                            <asp:GridView ID="GridView1" runat="server" RowStyle-VerticalAlign="Top" Width="100%" Caption='' AutoGenerateColumns="false" EmptyDataText="No Record Found" ShowHeader="true" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">

                                <HeaderStyle BorderColor="#908d8d" BorderStyle="Solid" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>No of works</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoWorks" runat="server" Text='<%#Eval("no of works") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalNoWorks" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="left" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lbllekha" runat="server" Text="Upvibhag"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            <asp:Label ID="lbllupvibhag" runat="server" Text='<%#Eval("Division")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblGrandTotal" runat="server" Font-Bold="true" Text="एकूण"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            AA cost
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAACost" runat="server" Text='<%# Eval("AA cost") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalAACost" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblmar" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpMar" runat="server" Text='<%# Eval("Expend Up to March") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalExpMar" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Balance Cost
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblBalCost" runat="server" Text='<%# Eval("Balance Cost") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalBalCost" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblProvision3" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarProvi" runat="server" Text='<%# Eval("Budget Provision") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalMarProvi" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Budget Relessed
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRelessed" runat="server" Text='<%# Eval("Relessed") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalRelessed" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblExpenditure9" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblExp9" runat="server" Text='<%# Eval("Expend up to sept") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalexp9" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblDemand" runat="server">Demand</asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDemnd" runat="server" Text='<%# Eval("Demand") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalDemnd1" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            C
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblC" runat="server" Text="0"></asp:Label>
                                           <%-- <asp:Label ID="lblSadhyasisthC" runat="server" Text="Completed" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthC1" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            P
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblP" runat="server" Text="0"></asp:Label>
                                           <%-- <asp:Label ID="lblSadhyasisthP" runat="server" Text="Processing" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthP1" runat="server" />
                                        </FooterTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            NS
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNS" runat="server" Text="0"></asp:Label>
                                           <%-- <asp:Label ID="lblSadhyasisthNS" runat="server" Text="Not Started" Style="display: none;"></asp:Label>--%>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthNS1" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="left" />
                                        <HeaderTemplate>
                                            Remarks
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Apr
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblApr" runat="server" Text='<%# Eval("Apr") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalApr" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            May
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMay" runat="server" Text='<%# Eval("May") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalMay" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Jun
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblJun" runat="server" Text='<%# Eval("Jun") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalJun" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Jul
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblJul" runat="server" Text='<%# Eval("Jul") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalJul" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Aug
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAug" runat="server" Text='<%# Eval("Aug") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalAug" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Sep
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSep" runat="server" Text='<%# Eval("Sep") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSep" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Oct
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOct" runat="server" Text='<%# Eval("Oct") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalOct" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Nov
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNov" runat="server" Text='<%# Eval("Nov") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalNov" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Dec
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDec" runat="server" Text='<%# Eval("Dec") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalDec" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Jan
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblJan" runat="server" Text='<%# Eval("Jan") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalJan" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Feb
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFeb" runat="server" Text='<%# Eval("Feb") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalFeb" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Mar
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMar1" runat="server" Text='<%# Eval("Mar") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalMar1" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Total
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalTotal" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <br />
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="float: left; margin-left: 40px;">
        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary" Height="40px" Width="100px" OnClientClick="PrintGridData()" />
        <asp:Button ID="BtnExcel" runat="server" Text="Excel" CssClass="btn btn-success" Height="40px" Width="100px" OnClick="BtnExcel_Click" />
        <%-- <asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-info" Height="40px" Width="100px" OnClientClick="PrintGrid()" />--%>
        <asp:Button ID="btnSendMail" runat="server" OnClick="btnSendMail_Click" class="btn btn-warning" Height="40px" Width="100px" Text="Send Mail" />
        <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" Height="40px" Width="100px" OnClick="BtnCancel_Click" />
        <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-default" BackColor="#660000" ForeColor="White" OnClientClick="JavaScript:window.history.back(1); return false;" Height="40px" Width="100px" />
    </div>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRow');
                var DivMC = document.getElementById('DivMainContent');
                var DivFR = document.getElementById('DivFooterRow');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '100px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'Black';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = '';
                DivMC.style.position = 'relative';
                DivMC.style.top = -headerHeight + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv(Scrollablediv) {
            document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=PrintDiv.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>
    <script type="text/javascript">

        function PrintGrid() {
            var prtGrid = document.getElementById('<%=PrintDiv.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=0,top=0,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);

        }
    </script>
</asp:Content>
