<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="DateWiseRerport.aspx.cs" Inherits="PWdEEBudget.DateWiseRerport" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media print {
            input {
                display: none;
            }
        }
    </style>
    <style type="text/css">
        .trrr tr:hover {
            background-color: #75becb;
        }

        .pj {
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
            text-align: left;
            padding: 3px;
        }

        tr {
            vertical-align: top;
        }

        .p {
            margin-left: 10%;
            margin-right: 10%;
            max-width: 80%;
            min-width: 79%;
            font-weight: bold;
            color: #000000;
            /*width: 100% !important;*/
            font-size: 18px;
            height: 38px !important;
            line-height: 38px !important;
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
            <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                <ProgressTemplate>
                    <div class="loading" align="center">
                        <img alt="progress" src="loader.gif" />
                        <br />
                        <b>Processing....</b>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>


            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="lblsadysthiti" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="lblsadyProcess" runat="server" Text="Label" Visible="false"></asp:Label>
            

              <div id="ListMenu" class="container" style="margin-top: 10px;" runat="server">

                <table class="table table-bordered" style="border: 2px groove">
                    <tr>
                        <th colspan="3">
                            <h2>Date Wise Report</h2>
                        </th>
                    </tr>


                    <tr>
                        <td>
                            <asp:Label ID="Label23" runat="server" Text="अर्थसंकल्पीय वर्ष:" Font-Bold="True"
                                ForeColor="Black"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlArthsankalpiyYear" runat="server" Style="width: 50%" CssClass="form-control p">
                                <asp:ListItem>Select</asp:ListItem>
                            </asp:DropDownList>

                             <asp:RequiredFieldValidator ID="RFVArthYear" runat="server" ControlToValidate="ddlArthsankalpiyYear"
                ErrorMessage="अर्थसंकल्पीय वर्ष निवडा!" InitialValue="Select" ForeColor="red"  Font-Size="Larger" Display="Dynamic" CssClass="blink_me" BackColor="Yellow"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 30%">
                            <asp:Label ID="Label2" runat="server" Text="दिनांक :" Font-Bold="True" ForeColor="Black"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text="पासुन :" Font-Bold="True" ForeColor="Black" Style="margin-left: 70%;"></asp:Label>
                        </td>
                        <td style="width: 40%">
                            <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" OnTextChanged="txtStartDate_TextChanged" AutoPostBack="true" CssClass="form-control p"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldStdate" runat="server" ControlToValidate="txtStartDate"
           ErrorMessage="दिनांक टाका..!"  ForeColor="red"   Display="Dynamic" CssClass="blink_me" BackColor="Yellow"></asp:RequiredFieldValidator>
                        </td>
                         </tr>
                        <tr>
                        <td style="width: 30%">
                            <asp:Label ID="Label3" runat="server" Text=" पर्यंत : " Font-Bold="True" ForeColor="Black" Style="margin-left: 88%;"></asp:Label>
                        </td>
                         <td style="width: 40%">
                            <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" OnTextChanged="txtEndDate_TextChanged" AutoPostBack="true" CssClass="form-control p"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldEndDate" runat="server" ControlToValidate="txtEndDate"
              ErrorMessage="दिनांक टाका..!" ForeColor="red" Display="Dynamic" CssClass="blink_me" BackColor="Yellow"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 10%">
                            <asp:Button ID="typebtn" runat="server" OnClick="typebtn_Click" Text="OK" CssClass="form-control" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div id="Showhidefixed" class="row"  style="height:100px">
                <asp:Button runat="server" Text="Show/Hide List" ID="btnHideList" OnClick="btnHideList_Click" />
            <br />            
           </div>
        <hr />
             <div ID="divAllHeadBtn" runat="server" class="btn-group" align="center" style="padding: 1% 0% 1% 0%;width: 100%;background: linear-gradient(#ccc,#fae8bd);">
                 <marquee scrollamount="5" width="40">&lt;&lt;&lt;</marquee><span style="color: #740f0f;font-size: large;"> View Report and Download Excel </span><marquee scrollamount="5" direction="right" width="40">&gt;&gt;&gt;</marquee>
                <hr  style="margin: 1% 1% 0% -3%;"/>
               <asp:Button id="btnBuildRep" runat="server" Text="BUILDING" class=" bs" OnClick="btnBuildRep_Click"/>
                <asp:Button id="btnRoad" runat="server" Text="ROAD" class=" bs" OnClick="btnRoad_Click"/>
                <asp:Button id="btnCrf" runat="server" Text="CRF" class=" bs" OnClick="btnCrf_Click"/>
                <asp:Button id="btnNabard" runat="server" Text="NABARD" class=" bs" OnClick="btnNabard_Click"/>
                <asp:Button id="btnDpdc" runat="server" Text="DPDC" class=" bs" OnClick="btnDpdc_Click"/>
                <asp:Button id="btnMla" runat="server" Text="MLA FUND" class=" bs" OnClick="btnMla_Click"/>
                <asp:Button id="btnMp" runat="server" Text="MP FUND" class=" bs" OnClick="btnMp_Click"/>
                <asp:Button id="btnDeposit" runat="server" Text="DEPOSIT FUND" class=" bs" OnClick="btnDeposit_Click"/>
                <asp:Button id="btnGatA" runat="server" Text="GAT A" class=" bs" OnClick="btnGatA_Click"/>
                <asp:Button id="btnGatFbc" runat="server" Text="GAT F" class=" bs" OnClick="btnGatFbc_Click"/>
                <asp:Button id="btnGAtB" runat="server" Text="GAT B" class=" bs" OnClick="btnGAtB_Click"/>
                <asp:Button id="BtnGATC" runat="server" Text="GAT C" class=" bs" OnClick="BtnGATC_Click"/>
                <asp:Button id="btnGatD" runat="server" Text="GAT D" class=" bs" OnClick="btnGatD_Click"/>
                <asp:Button id="btnAnnuity" runat="server" Text="ANNUITY" class=" bs" OnClick="btnAnnuity_Click"/>
                <asp:Button id="btn2216" runat="server" Text="2216" class=" bs" OnClick="btn2216_Click"/>
                 <asp:Button id="btn2059" runat="server" Text="2059" class=" bs" OnClick="btn2059_Click"/>
                <asp:Button id="btn2515" runat="server" Text="2515" class=" bs" OnClick="btn2515_Click"/>
            </div>
            <hr />
            <div id="Print">
                <asp:Panel ID="Panel1" runat="server">
                    <div style="overflow-x: auto">
                        <div align="center">
                            <asp:Label ID="Label17" runat="server" Style="font-weight: bold; font-size: 24px;"></asp:Label><br />
                        </div>
                        <asp:Label ID="lblBuilding" runat="server"></asp:Label>
                        <div id="DivRoot" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRow">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                                    <asp:GridView ID="GridBuilding" runat="server" Width="100%" ShowFooter="true"  Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridBuilding_RowDataBound">

                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblRoad" runat="server"></asp:Label>
                        <div id="DivRoot1" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRow1">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv2(this)" id="DivMainContent1">
                                    <asp:GridView ID="GridRoad" runat="server" Width="100%"  Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridRoad_RowDataBound" ShowFooter="true">
                                        <Columns>

                                            <%-- <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblCRF" runat="server"></asp:Label>
                        <div id="DivRootCRF" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowCRF">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv3(this)" id="DivMainContentCRF">
                                    <asp:GridView ID="GridCRF" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridCRF_RowDataBound" ShowFooter="true">
                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblNabard" runat="server"></asp:Label>
                        <div id="DivRootNabard" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowNabard">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv4(this)" id="DivMainContentNabard">
                                    <asp:GridView ID="GridNabard" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridNabard_RowDataBound" ShowFooter="true">
                                        <Columns>

                                            <%--<asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblDPDC" runat="server"></asp:Label>
                        <div id="DivRootDPDC" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowDPDC">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv5(this)" id="DivMainContentDPDC">
                                    <asp:GridView ID="GridDPDC" runat="server" Width="100%"  Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridDPDC_RowDataBound" ShowFooter="true">
                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblMLA" runat="server"></asp:Label>
                        <div id="DivRootMLA" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowMLA">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv6(this)" id="DivMainContentMLA">
                                    <asp:GridView ID="GridMLA" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridMLA_RowDataBound" ShowFooter="true">
                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblMP" runat="server"></asp:Label>
                        <div id="DivRootMP" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowMP">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv7(this)" id="DivMainContentMP">
                                    <asp:GridView ID="GridMP" runat="server" Width="100%"   Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridMP_RowDataBound" ShowFooter="true">
                                        <%-- <Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblAnnuity" runat="server"></asp:Label>
                        <div id="DivRootAunty" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowAunty">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv8(this)" id="DivMainContentAunty">
                                    <asp:GridView ID="GridAunty" runat="server" Width="100%"     Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridAunty_RowDataBound" ShowFooter="true">
                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblDepositFund" runat="server"></asp:Label>
                        
                            <div id="DivRootDepositFund" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowDepositFund">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv1(this)"  id="DivMainContentDepositFund">
                                    <asp:GridView ID="GridDepositFund" runat="server" Width="100%"     Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridDepositFund_RowDataBound" ShowFooter="true">
                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                     
                        

                         <asp:Label ID="lblGATA" runat="server"></asp:Label>
                        <div id="DivRootGatA" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowGatA">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv9(this)" id="DivMainContentGatA">
                                    <asp:GridView ID="GridGatA" runat="server" Width="100%" ShowFooter="true"     Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridGatA_RowDataBound" >
                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblGatD" runat="server"></asp:Label>
                        <div id="DivRootGatD" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowGatD">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv10(this)" id="DivMainContentGatD">
                                    <asp:GridView ID="GridGatD" runat="server" Width="100%"     Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridGatD_RowDataBound" ShowFooter="true">
                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblGatF" runat="server"></asp:Label>
                        <div id="DivRootGatF" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowGatF">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv11(this)" id="DivMainContentGatF">
                                    <asp:GridView ID="GridGatF" runat="server" Width="100%"     Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridGatF_RowDataBound" ShowFooter="true">
                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblGatB" runat="server"></asp:Label>
                        <div id="DivRootGatB" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowGatB">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv12(this)" id="DivMainContentGatB">
                                    <asp:GridView ID="GridGatB" runat="server" Width="100%"     Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridGatB_RowDataBound" ShowFooter="true">
                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblGatC" runat="server"></asp:Label>
                        <div id="DivRootGatC" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowGatC">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv13(this)" id="DivMainContentGatC">
                                    <asp:GridView ID="GridGatC" runat="server" Width="100%"     Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridGatC_RowDataBound" ShowFooter="true">
                                        <%--<Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblResBuilding" runat="server"></asp:Label>
                        <div id="DivRootResidentialBuilding" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowResidentialBuilding">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv14(this)" id="DivMainContentResidentialBuilding">
                                    <asp:GridView ID="GridResidentialBuilding" Width="100%" runat="server" ShowFooter="true"     Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridResidentialBuilding_RowDataBound" >
                                        <%--<Columns>
                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lblNonResBuilding" runat="server"></asp:Label>
                        <div id="DivRootNonResidentialbuilding" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowNonResidentialbuilding">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv15(this)" id="DivMainContentNonResidentialbuilding">
                                    <asp:GridView ID="GridNonResidentialbuilding" Width="100%" runat="server" ShowFooter="true"     Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridNonResidentialbuilding_RowDataBound" >
                                        <%--<Columns>
                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>--%>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                         <asp:Label ID="lbl2515" runat="server"></asp:Label>
                        <div id="DivRoot2515" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRow2515">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv16(this)" id="DivMainContent2515">
                                    <asp:GridView ID="Grid2515" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="Grid2515_RowDataBound" ShowFooter="true">

                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>


                    </div>
                </asp:Panel>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>

    <div align="center">
        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary" Height="40px" Width="100px" OnClick="btnPrint_Click" />
        <asp:Button ID="BtnExcel" runat="server" Text="Excel" CssClass="btn btn-success" Height="40px" Width="100px" OnClick="BtnExcel_Click" />
        <asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-info" Height="40px" Width="100px" OnClientClick="PrintGrid()" />
        <asp:Button ID="btnSendMail" runat="server" OnClick="btnSendMail_Click" class="btn btn-warning" Height="40px" Width="100px" Text="Send Mail" />
        <asp:Button ID="Button2" runat="server" Text="Back" CssClass="btn btn-danger" Height="40px" Width="100px" />

    </div>
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
                DivHR.style.height = '119px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -119 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv(Scrollablediv) {
            document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeader1(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRow1');
                var DivMC = document.getElementById('DivMainContent1');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '172px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -172 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv2(Scrollablediv) {
            document.getElementById('DivHeaderRow1').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderCRF(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowCRF');
                var DivMC = document.getElementById('DivMainContentCRF');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '122px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -122 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv3(Scrollablediv) {
            document.getElementById('DivHeaderRowCRF').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderNabard(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowNabard');
                var DivMC = document.getElementById('DivMainContentNabard');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '145px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -145 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv4(Scrollablediv) {
            document.getElementById('DivHeaderRowNabard').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderDPDC(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowDPDC');
                var DivMC = document.getElementById('DivMainContentDPDC');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '172px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -172 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv5(Scrollablediv) {
            document.getElementById('DivHeaderRowDPDC').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderMLA(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowMLA');
                var DivMC = document.getElementById('DivMainContentMLA');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '160px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -160 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv6(Scrollablediv) {
            document.getElementById('DivHeaderRowMLA').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderMP(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowMP');
                var DivMC = document.getElementById('DivMainContentMP');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '226px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -226 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv7(Scrollablediv) {
            document.getElementById('DivHeaderRowMP').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderAunty(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowAunty');
                var DivMC = document.getElementById('DivMainContentAunty');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '180px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -180 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv8(Scrollablediv) {
            document.getElementById('DivHeaderRowAunty').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderDepositFund(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowDepositFund');
                var DivMC = document.getElementById('DivMainContentDepositFund');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '117px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -117 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv1(Scrollablediv) {
            document.getElementById('DivHeaderRowDepositFund').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderGatA(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowGatA');
                var DivMC = document.getElementById('DivMainContentGatA');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '120px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -120 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv9(Scrollablediv) {
            document.getElementById('DivHeaderRowGatA').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderGatD(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowGatD');
                var DivMC = document.getElementById('DivMainContentGatD');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '145px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -145 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv10(Scrollablediv) {
            document.getElementById('DivHeaderRowGatD').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderGatF(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowGatF');
                var DivMC = document.getElementById('DivMainContentGatF');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '145px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -145 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv11(Scrollablediv) {
            document.getElementById('DivHeaderRowGatF').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderGatB(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowGatB');
                var DivMC = document.getElementById('DivMainContentGatB');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '150px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -150 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv12(Scrollablediv) {
            document.getElementById('DivHeaderRowGatB').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderGatC(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowGatC');
                var DivMC = document.getElementById('DivMainContentGatC');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '145px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -145 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv13(Scrollablediv) {
            document.getElementById('DivHeaderRowGatC').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderResidentialBuilding(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowResidentialBuilding');
                var DivMC = document.getElementById('DivMainContentResidentialBuilding');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '145px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -145 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv14(Scrollablediv) {
            document.getElementById('DivHeaderRowResidentialBuilding').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeaderNonResidentialbuilding(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRowNonResidentialbuilding');
                var DivMC = document.getElementById('DivMainContentNonResidentialbuilding');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '124px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -124 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv15(Scrollablediv) {
            document.getElementById('DivHeaderRowNonResidentialbuilding').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeader2515(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRow2515');
                var DivMC = document.getElementById('DivMainContent2515');
                var DivFR = document.getElementById('DivFooterRow1');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '151px';
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -151 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv16(Scrollablediv) {
            document.getElementById('DivHeaderRow2515').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow1').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
</asp:Content>
