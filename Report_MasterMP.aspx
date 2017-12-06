<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Report_MasterMP.aspx.cs" Inherits="PWdEEBudget.Report_MasterMP" %>

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

        /*.p {
             margin-left: 10%;
            margin-right: 10%;
            font-size: 18px;
            max-width: 80%;
            min-width: 79%;
        }*/

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
            <%--  <link href="css/tblmargin.css" rel="stylesheet" />--%>
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
                <div class="row" style="border: 3px solid; background-color: gray; margin-top: 10px">
                    <div class="col-md-12" style="text-align: center; color: #fff">
                        <h1>MP Abstract Report</h1>
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
                    <div class="col-md-2">
                        <%--  <asp:Button ID="ArthsankalpiyYearbtn" runat="server" OnClick="ArthsankalpiyYearbtn_Click" Text="OK" CssClass="form-control" />--%>
                    </div>
                </div>
                <div class="row" style="border-bottom: 2px solid; background-color: gray;">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="खासदार" Font-Bold="True" CssClass="form-control"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlKhasdar" runat="server" CssClass="form-control p" Style="width: 100%;" ForeColor="Black">
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
            <div id="Print" runat="server">
                <div class="col-md-12" style="text-align: center; color: #443030">
                    <h3 style="font-size: 24px;">MP Abstract Report</h3>
                </div>
                 <div align="center">

                    <asp:Label ID="lblPrintKhasdar" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />                  
                    <asp:Label ID="lblPrintArthSanalpYr" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />
                    <br />
                </div>
                <div id="DivRoot" align="left" style="width: 100%">
                    <div style="width: 100%">
                        <div style="overflow: hidden; width: 100%" id="DivHeaderRow">
                        </div>

                        <div style="overflow: auto; width: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                            <asp:GridView ID="GridView1" runat="server" RowStyle-VerticalAlign="Top" Width="100%" Caption='' EmptyDataText="No Record Found" AutoGenerateColumns="false" ShowHeader="true" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">

                                <HeaderStyle BorderColor="#908d8d" BorderStyle="Solid" />
                                <Columns>
                                    <asp:TemplateField HeaderText="अ.क्र" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            वर्ष
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblyear" runat="server" Text='<%# Eval("Arthsankalpiyyear") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblGrandTotal" runat="server" Font-Bold="true" Text="एकूण"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderTemplate>
                                            खासदार
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMPName" runat="server" Text='<%# Eval("MPName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                           <asp:Label ID="lblMpHeader" runat="server" Font-Bold="true" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="left" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lbllekha" runat="server" Text="उपविभाग"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                              <asp:Label ID="lbllupvibhag" runat="server" Text='<%#Eval("Division")%>'></asp:Label>
                                           <%-- <%#Eval("Division")%>
                                            <asp:Label ID="lbllupvibhag" runat="server" Text='<%#Eval("Division")%>' Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            एकूण कामांची संख्या
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdd" runat="server" Text="0"></asp:Label>
                                           <%-- <asp:Label ID="lblSadhyasisthAdd" runat="server" Text="Lbladd" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblAddTotal" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>एकूण कामे</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoWorks" runat="server" Text='<%#Eval("PageNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalNoWorks" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <%-- <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lbllekha" runat="server" Text="4515 MLA"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#Eval("Division")%>
                                        <asp:Label ID="lbllupvibhag" runat="server" Text='<%#Eval("Division")%>' Style="display: none;"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblGrandTotal" runat="server" Text="एकूण"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>--%>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPrashAmt" runat="server" Text="प्र.मा.किंमत रु लक्ष" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrashAmt" runat="server" Text='<%# Eval("PrashaskiyAmt") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPrashAmt" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            ता.मा.किंमत रु लक्ष
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTantriAmt" runat="server" Text='<%# Eval("TrantrikAmt") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalTantriAmt" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            निविदा किंमत
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNividaAmt" runat="server" Text='<%# Eval("NividaAmt") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalNividaAmt" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            वर्ष २०१६-२०१७ मधील उपलब्ध अनुदान लक्ष
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarProvi" runat="server" Text='<%# Eval("MarchEndingExpn") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalMarProvi" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            वर्ष मधील चालू महिन्या अखेर
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRelessed" runat="server" Text='<%# Eval("Chalukharch") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalRelessed" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblExpenditure9" runat="server" Text="एकूण उपलब्ध अनुदान"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblExp9" runat="server" Text='<%# Eval("AkunAnudan") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalexp9" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblDemand" runat="server" Text="वर्ष मधील चालू महिन्या"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDemnd" runat="server" Text='<%# Eval("Magilkharch") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalDemnd1" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblAkunKarch" runat="server" Text="एकूण खर्च"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAkunKarch" runat="server" Text='<%# Eval("AikunKharch") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalAkunKarch" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblMagni" runat="server" Text="२०१६-२०१७ मागणी रु खर्च"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMagni" runat="server" Text='<%# Eval("Magni") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalMagni" runat="server" />
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
                                           <%-- <asp:Label ID="lblSadhyasisthC" runat="server" Text="Complited" Style="display: none;"></asp:Label>--%>
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
                                            एप्रिल
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
                                            मे
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
                                            जून
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
                                            जुलै
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
                                            ऑगस्ट
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
                                            सप्टेंबर
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
                                            ऑक्टोबर
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
                                            नोव्हेंबर
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
                                            डिसेंबर
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
                                            जानेवारी
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
                                            फेब्रुवारी
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
                                            मार्च
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
                                            एकूण
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalTotal" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />
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
            var prtGrid = document.getElementById('<%=Print.ClientID %>');
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
            var prtGrid = document.getElementById('<%=Print.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=0,top=0,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);

        }
    </script>
</asp:Content>
