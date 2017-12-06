<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Report_MasterNabard.aspx.cs" Inherits="PWdEEBudget.Report_MasterNabard" %>

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
                        <h1>Master Nabard PCR Report</h1>
                    </div>
                </div>

                <div class="row" style="border-bottom: 2px solid; background-color: gray;">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblarthsankalpiyyear" runat="server" CssClass="form-control " Text="अर्थसंकल्पीय वर्ष:"
                            Font-Bold="True" ForeColor="Black"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlArthsankalpiyYear" runat="server" Style="width: 100%;" CssClass="form-control p"
                            ForeColor="Black">
                            <asp:ListItem>निवडा</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <%--   <asp:Button ID="btnworkid" runat="server" CssClass="form-control" Text="OK" OnClick="btnworkid_Click" />--%>
                    </div>
                </div>
                <div class="row" style="border-bottom: 2px solid; background-color: gray;">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblkamacheYr" runat="server" CssClass="form-control" Text="कामाचे वर्ष:" Font-Bold="True" ForeColor="Black"></asp:Label>
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



                <div class="row" style="border-bottom: 2px solid; background-color: gray;">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="RIDF No.:" Font-Bold="True" CssClass="form-control "></asp:Label>
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
                <div class="col-md-12" style="text-align: center; color: #443030;">
                    <h3 style="font-size: 24px">Master Nabard PCR Report</h3>
                </div>
                <div align="center">

                    <asp:Label ID="lblPrintUpvibhag" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />
                    <asp:Label ID="lblPrintKamcacheyr" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />
                    <asp:Label ID="lblPrintArthSanalpYr" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label><br />
                    <br />
                </div>
                <div id="DivRoot" align="left" style="width: 100%">
                    <div style="width: 100%; height: auto;">
                        <div style="overflow: hidden; width: 100%" id="DivHeaderRow">
                        </div>

                        <div style="overflow: auto; width: 100%; height: auto;" onscroll="OnScrollDiv(this)" id="DivMainContent">

                            <asp:GridView ID="GridView1" runat="server" RowStyle-VerticalAlign="Top" Width="100%" Caption='' AutoGenerateColumns="false" EmptyDataText="No Record Found" ShowHeader="true" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">

                                <HeaderStyle BorderStyle="Solid" />
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
                                        <HeaderTemplate>
                                            <asp:Label ID="lbllekha" runat="server" Text="RDF_NO"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%--<%#Eval("RDF_NO")%>--%>
                                            <asp:Label ID="lblRIDF" runat="server" Text='<%#Eval("RDF_NO")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="left" />
                                        <HeaderTemplate>
                                            District
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblAACost" runat="server" Text='<%# Eval("AA cost") %>' />--%>
                                            <asp:Label ID="lblDist" runat="server" Text='<%# Eval("District") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblGrandTotal" runat="server" Font-Bold="true" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>No. of Road works as per Nabard</HeaderTemplate>
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblNoWorks" runat="server" Text='<%#Eval("no of works") %>'></asp:Label>--%>

                                            <asp:Label ID="lblNoRoadWorks" Text="0" runat="server"></asp:Label>
                                            <%--<asp:Label ID="lblTypeRoad" runat="server" Text="Road" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalRoadWorks" Text="0" runat="server" />
                                            <%--<asp:Label ID="lblTotalNoWorks" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>No. of Bridge works as per Nabard</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoBridgeWorks" Text="0" runat="server"></asp:Label>
                                            <%--<asp:Label ID="lblTypeBridge" runat="server" Text="Bridge" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalNoBridgeWorks" Text="0" runat="server" />
                                            <%--<asp:Label ID="lblTotalNoWorks" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>Total No of works</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoWorks" runat="server" Text='<%#Eval("no of works") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalNoWorks" Text="0" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Completed
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblC" runat="server" Text="0"></asp:Label>
                                           <%-- <asp:Label ID="lblSadhyasisthC" runat="server" Text="Completed" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthC1" Text="0" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Inprogress
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblP" runat="server" Text="0"></asp:Label>
                                           <%-- <asp:Label ID="lblSadhyasisthP" runat="server" Text="Processing" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthP1" Text="0" runat="server" />
                                        </FooterTemplate>

                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField>
                                         <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Not Started
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNS" runat="server" Text="0"></asp:Label>
                                            <%--<asp:Label ID="lblSadhyasisthNS" runat="server" Text="Not Started" Style="display: none;"></asp:Label>--%>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthNS1" Text="0" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Incomplete
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIncomplete" runat="server" Text="0"></asp:Label>
                                           <%-- <asp:Label ID="lblSadhyasisthIncomplete" runat="server" Text="Incomplete" Style="display: none;"></asp:Label>--%>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthIncomplete1" Text="0" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            Tender Stage
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTenderStage" runat="server" Text="0"></asp:Label>
                                            <%--<asp:Label ID="lblSadhyasisthTenderStage" runat="server" Text="Tender Stage" Style="display: none;"></asp:Label>--%>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblSadhyasisthTenderStage1" Text="0" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblWBMI" Text="W B M I  Km" runat="server"></asp:Label>
                                            <%-- <asp:Label ID="lblmar" runat="server"></asp:Label>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCntWBMI" runat="server" Text='<%# Eval("W B M I  Km") %>' />
                                            <%--<asp:Label ID="lblExpMar" runat="server" Text='<%# Eval("W B M I  Km") %>' />--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalWBMIKm" Text="0.00" runat="server" />
                                            <%--<asp:Label ID="lblTotalExpMar" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblWBMII" Text="W B M II  Km" runat="server"></asp:Label>
                                            <%-- <asp:Label ID="lblmar" runat="server"></asp:Label>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCntWBMII" runat="server" Text='<%# Eval("W B M II  Km") %>' />
                                            <%--<asp:Label ID="lblExpMar" runat="server" Text='<%# Eval("W B M I  Km") %>' />--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalWBMIIKm" Text="0.00" runat="server" />
                                            <%--<asp:Label ID="lblTotalExpMar" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblWBMIII" Text="W B M III Km" runat="server"></asp:Label>
                                            <%-- <asp:Label ID="lblmar" runat="server"></asp:Label>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCntWBMIII" runat="server" Text='<%# Eval("W B M III Km") %>' />
                                            <%--<asp:Label ID="lblExpMar" runat="server" Text='<%# Eval("W B M I  Km") %>' />--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalWBMIIIKm" Text="0.00" runat="server" />
                                            <%--<asp:Label ID="lblTotalExpMar" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblSurfaceDressingKm" Text="Surface Dressing Km" runat="server"></asp:Label>
                                            <%-- <asp:Label ID="lblmar" runat="server"></asp:Label>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCntSurfaceDressingKm" runat="server" Text='<%# Eval("Surface Dressing Km") %>' />
                                            <%--<asp:Label ID="lblExpMar" runat="server" Text='<%# Eval("W B M I  Km") %>' />--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSurfaceDressingKm" Text="0.00" runat="server" />
                                            <%--<asp:Label ID="lblTotalExpMar" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblBBMKm" Text="B B M Km" runat="server"></asp:Label>
                                            <%-- <asp:Label ID="lblmar" runat="server"></asp:Label>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCntBBMKm" runat="server" Text='<%# Eval("B B M Km") %>' />
                                            <%--<asp:Label ID="lblExpMar" runat="server" Text='<%# Eval("W B M I  Km") %>' />--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalBBMKm" Text="0.00" runat="server" />
                                            <%--<asp:Label ID="lblTotalExpMar" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCarpetKm" Text="Carpet Km" runat="server"></asp:Label>
                                            <%-- <asp:Label ID="lblmar" runat="server"></asp:Label>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCntCarpetKm" runat="server" Text='<%# Eval("Carpet Km") %>' />
                                            <%--<asp:Label ID="lblExpMar" runat="server" Text='<%# Eval("W B M I  Km") %>' />--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCarpetKm" Text="0.00" runat="server" />
                                            <%--<asp:Label ID="lblTotalExpMar" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCDwork" Text="C D Works Nos" runat="server"></asp:Label>
                                            <%-- <asp:Label ID="lblmar" runat="server"></asp:Label>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCntCDwork" runat="server" Text='<%# Eval("C D Works Nos") %>' />
                                            <%--<asp:Label ID="lblExpMar" runat="server" Text='<%# Eval("W B M I  Km") %>' />--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCDwork" Text="0" runat="server" />
                                            <%--<asp:Label ID="lblTotalExpMar" runat="server" />--%>
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
                                            <asp:Label ID="lblTotalExpMar" Text="0.00" runat="server" />
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
                                            <asp:Label ID="lblTotalMarProvi" Text="0.00" runat="server" />
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
                                            <asp:Label ID="lblTotalDemnd1" Text="0.00" runat="server" />
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
                                            <asp:Label ID="lblTotalexp9" Text="0.00" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>No of PCRs submitted</HeaderTemplate>
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblNoWorks" runat="server" Text='<%#Eval("no of works") %>'></asp:Label>--%>

                                            <asp:Label ID="lblNoPCRSubmitted" Text="0" runat="server"></asp:Label>
                                           <%-- <asp:Label ID="lblPCRSubmitted" runat="server" Text="Submitted" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPCRSubmitted" Text="0" runat="server" />
                                            <%--<asp:Label ID="lblTotalNoWorks" runat="server" />--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>No  of  PCRs pending</HeaderTemplate>
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblNoWorks" runat="server" Text='<%#Eval("no of works") %>'></asp:Label>--%>

                                            <asp:Label ID="lblNoPCRpending" Text="0" runat="server"></asp:Label>
                                          <%--  <asp:Label ID="lblPCRpending" runat="server" Text="Pending" Style="display: none;"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPCRpending" Text="0" runat="server" />
                                            <%--<asp:Label ID="lblTotalNoWorks" runat="server" />--%>
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
