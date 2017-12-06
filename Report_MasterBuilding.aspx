<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Report_MasterBuilding.aspx.cs" Inherits="PWdEEBudget.Report_MasterBuilding" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .trrr tr:hover {
            background-color: #75becb;
        }



        /*th {
            color: #fff;
            background-color: #2c3e50;
        }

        td {
            border: 1px solid;
        }*/

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
            /*text-align: center;*/
            padding: 3px;
        }


        tr {
            vertical-align: top;
        }

        /*.p {
            margin-left: 10%;
            margin-right: 10%;
            font-size: 18px;
            max-width: 80%;
            min-width: 79%;
        }*/

        /*.k {
            border-right: 1px solid #ddd;
        }*/

        @media print {
            input {
                display: none;
            }
        }
    </style>

    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }
    </style>
    <style>
        @media only screen and (min-width:768px) {
            /*desktop*/

        }

        @media only screen and (max-width:500px) {
            .DivDDL {
                /*height:0% !important;*/
            }

            #ContentPlaceHolder1_UpdatePanel2 {
                margin-right: -3% !important;
            }

            gridtbl {
                width: 200px;
                height: 400px;
                overflow: auto;
            }
            .loading {
                left: 25% !important;
            }
            #ContentPlaceHolder1_up > div  {
                overflow-x:auto !important;
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
            <%--  <link href="css/tblmargin.css" rel="stylesheet" />--%>
            <div class="container">
                <div class="row" style="border: 3px solid; background-color: gray; margin-top: 10px">
                    <div class="col-md-12" style="text-align: center; color: #fff">
                        <h1>Building Abstract Report</h1>
                    </div>
                </div>

                <div class="row" style="border-bottom: 2px solid; background-color: gray;">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblarthsankalpiyyear" runat="server" CssClass="form-control " Text="अर्थसंकल्पीय वर्ष:" Font-Bold="True" ForeColor="Black"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlArthsankalpiyYear" runat="server" Style="width: 100%;" CssClass="form-control p" ForeColor="Black">
                            <asp:ListItem>निवडा</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <%-- <div class="col-md-2">
            <asp:Button ID="btnworkid" runat="server" CssClass="form-control p" Text="OK" />
        </div>--%>
                </div>

                <div class="row" style="border-bottom: 2px solid; background-color: gray;">
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
                        <%--<asp:Button ID="btnworkid" runat="server" CssClass="form-control p" Text="OK" />--%>
                    </div>
                </div>
                <div class="row" style="border-bottom: 2px solid; background-color: gray;">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="लेखाशीर्ष " Font-Bold="True" CssClass="form-control "></asp:Label>
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

            <%--  <div id="DivRoot" align="left" style="width: 100%">--%>
            <div style="width: 100%">
                <%-- <div style="overflow: hidden; width: 100%" id="DivHeaderRow">
                    </div>--%>

                <%--<div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">--%>


                <div id="Print" runat="server">
                    <div class="col-md-12" style="text-align: center; color: #443030">
                        <h3 style="font-size: 24px;">Building Abstract Report</h3>
                    </div>
                    <asp:UpdatePanel ID="up" runat="server">
                        <ContentTemplate>
                            <div align="center">
                                <asp:Label ID="lblPrintLehasirsh" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />
                                <asp:Label ID="lblPrintKamcacheyr" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />
                                <asp:Label ID="lblPrintArthSanalpYr" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />
                                <br />
                            </div>
                            <%-- <div style ="height:130px; width:500px; overflow:auto;" >--%>
                            <asp:GridView ID="GridView1" CssClass="gridtbl" runat="server" RowStyle-VerticalAlign="Top" Width="100%" Caption='' EmptyDataText="No Record Found" style="overflow-x:auto" AutoGenerateColumns="false" ShowHeader="true" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">
                                <HeaderStyle BorderStyle="Solid" />
                                <Columns>

                                    <asp:TemplateField HeaderText="अ.क्र" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderTemplate>
                                            लेखाशीर्ष
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbllekhasirshName" runat="server" Text='<%# Eval("lekhasirshName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <%--<asp:Label ID="lblSadhyasisthAstar1" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <HeaderTemplate>
                                            उपशीर्ष
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblupsirsh" runat="server" Text='<%# Eval("upsirsh") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <%--<asp:Label ID="lblSadhyasisthAstar1" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderTemplate>
                                            विभाग
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblvibhagName" runat="server" Text='<%# Eval("vibhagName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>एकूण</b>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            एकूण कामे
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoOfWorks" runat="server" Text='<%# Eval("NoOfWorks") %>'></asp:Label>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalWork" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            अंदाजपत्रकिय स्तर
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAStar" runat="server" Text="0"></asp:Label>
                                            <%--<asp:Label ID="lblSadhyasisthAstar11" runat="server" Text="अंदाजपत्रकिय स्थर" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthAstar1" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            निविदा स्तर
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblNStar" runat="server" Text="0"></asp:Label>
                                                    <asp:Label ID="lblSadhyasisthNStar" runat="server" Text="निविदा स्तर" Style="display: none;"></asp:Label>--%>

                                            <asp:Label ID="lblNS" runat="server" Text="0"></asp:Label>
                                            <%-- <asp:Label ID="lblSadhyasisthNS11" runat="server" Text="निविदा स्तर" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthNS1" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            प्रगतीत
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblPragatit" runat="server" Text="0"></asp:Label>
                                                    <asp:Label ID="lblSadhyasisthPragatit" runat="server" Text="चालू" Style="display: none;"></asp:Label>--%>

                                            <asp:Label ID="lblP" runat="server" Text="0"></asp:Label>
                                            <%--<asp:Label ID="lblSadhyasisthP11" runat="server" Text="प्रगतीत" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthP1" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            पूर्ण
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblPurn" runat="server" Text="0"></asp:Label>
                                                    <asp:Label ID="lblSadhyasisthPurn" runat="server" Text="पूर्ण" Style="display: none;"></asp:Label>--%>
                                            <asp:Label ID="lblC" runat="server" Text="0"></asp:Label>
                                            <%-- <asp:Label ID="lblSadhyasisthC11" runat="server" Text="पूर्ण" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthC1" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Not Started कामे
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNOTS" runat="server" Text="0"></asp:Label>
                                            <%--<asp:Label ID="lblSadhyasisthNOTS11" runat="server" Text="सुरू करणे" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthNOTS1" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="left" />
                                        <HeaderTemplate>
                                            शेरा
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblShera" runat="server" Text='<%# Eval("Shera") %>'></asp:Label> --%>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                                <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
                            </asp:GridView>
                            <%--   </div>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


                <%-- </div>--%>
            </div>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="float: left; margin-left: 40px;">
        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary" Height="40px" Width="100px" OnClientClick="PrintGridData()" />
        <%--<asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-info" Height="40px" Width="100px" OnClick="Button1_Click" />--%>
        <asp:Button ID="BtnExcel" runat="server" Text="Excel" CssClass="btn btn-success" Height="40px" Width="100px" OnClick="BtnExcel_Click" />
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
            var prtGrid = document.getElementById('<%=Print.ClientID %>');
            prtGrid.border = 1;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1,align=center');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>
    <script lang="javascript" type="text/javascript">

        function PrintGrid() {
            var prtGrid = document.getElementById('<%=Print.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=0,top=0,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);

        }
    </script>

</asp:Content>
