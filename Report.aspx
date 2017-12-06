<%@ Page Title="" Language="C#" MasterPageFile="~/MPMLA.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="PWdEEBudget.Report" %>

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

        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
    <style>
        .navbar-default .navbar-nav > li > a.MasterAllPage {
            display: block !important;
            /*background-color: gray !important;*/
            background: linear-gradient(#3b5998,#00C6D7) !important;
            color: white !important;
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
            <asp:Label ID="lbl1" runat="server" Text="All Head Report" Font-Bold="true" Style="margin-left: 47%" Font-Size="X-Large"></asp:Label>
            <br />
            <hr />
            <div id="Print">
                <%--<asp:Label ID="lblresult" runat="server"/>
                            <asp:Button ID="btnShowPopup" runat="server"  style="display:none" />
                            
                            <asp:Panel runat="server" ID="pnlpopup" BackColor="White" Height="350px" Width="400px" style="display:none"> 

                                <table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%; background-color:white" cellpadding="0" cellspacing="0" height="100%">
                                    <tr style="background-color:#D55500">
                                        <td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">
                                            Update Remark
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style=" width:30%">
                                            Work Id:- 
                                        </td>
                                        <td>
                                            <asp:Label ID="lblWorkid" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" >
                                            Type:-
                                        </td>
                                        <td>
                                            <asp:Label ID="lblType" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Work Name:-
                                        </td>
                                        <td>
                                            <asp:Label ID="lblKamcheNav" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Remark:-
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtShera" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                        </td>
                                        <td>
                                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Height="25" Width="65" Font-Size="12px" style="margin-right:16%"/> 
                                            <asp:Button id="btnCancel" runat="server" Text="Cancel" Height="25" Width="65" Font-Size="12px"/>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>--%>
                <asp:Panel ID="Panel1" runat="server">
                    <div style="overflow-x: auto">
                        <div align="center">
                            <asp:Label ID="Label17" runat="server" Style="font-weight: bold; font-size: 24px;"></asp:Label><br />
                        </div>
                        <div style="background-color: ActiveBorder" id="divArthYear" runat="server">

                            <asp:Label ID="Label1" runat="server" Text="अर्थसंकल्पीय वर्ष" BackColor="LightYellow" ForeColor="Red"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddlYear" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CssClass="form-control c" AutoPostBack="true" Style="width: 30%"></asp:DropDownList>

                        </div>
                        <asp:Label ID="lblBuilding" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="chkBuildUpdate" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRoot" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRow">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                                    <asp:GridView ID="GridBuilding" runat="server" Width="100%" ShowFooter="True" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridBuilding_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Update">
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpBuild" runat="server" OnClick="btnUpBuild_Click" Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>

                        </div>

                        <asp:Label ID="lblRoad" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkRoad" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRoot1" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRow1">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv2(this)" id="DivMainContent1">
                                    <asp:GridView ID="GridRoad" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridRoad_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <Columns>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpRoad" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblCRF" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkCRF" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootCRF" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowCRF">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv3(this)" id="DivMainContentCRF">
                                    <asp:GridView ID="GridCRF" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridCRF_RowDataBound" DataKeyNames="WorkId">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%--    <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpCRF" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblNabard" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkNabard" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootNabard" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowNabard">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv4(this)" id="DivMainContentNabard">
                                    <asp:GridView ID="GridNabard" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridNabard_RowDataBound" DataKeyNames="Work Id">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%--   <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpNabard" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblDPDC" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkDpdc" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootDPDC" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowDPDC">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv5(this)" id="DivMainContentDPDC">
                                    <asp:GridView ID="GridDPDC" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridDPDC_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%--   <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpDPDC" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblMLA" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%-- <asp:CheckBox id="ChkMla" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootMLA" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowMLA">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv6(this)" id="DivMainContentMLA">
                                    <asp:GridView ID="GridMLA" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridMLA_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpMLA" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblMP" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkMp" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootMP" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowMP">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv7(this)" id="DivMainContentMP">
                                    <asp:GridView ID="GridMP" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridMP_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpMP" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblAnnuity" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkAnnuty" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootAunty" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowAunty">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv8(this)" id="DivMainContentAunty">
                                    <asp:GridView ID="GridAunty" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridAunty_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpAnnuity" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblDepositFund" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkDeposit" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootDepositFund" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowDepositFund">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv1(this)" id="DivMainContentDepositFund">
                                    <asp:GridView ID="GridDepositFund" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridDepositFund_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpDeposit" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblGATA" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%-- <asp:CheckBox id="ChkGatA" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootGatA" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowGatA">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv9(this)" id="DivMainContentGatA">
                                    <asp:GridView ID="GridGatA" runat="server" Width="100%" ShowFooter="true" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridGatA_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnGatA" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblGatD" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkGatD" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootGatD" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowGatD">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv10(this)" id="DivMainContentGatD">
                                    <asp:GridView ID="GridGatD" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridGatD_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%--  <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpGatD" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblGatF" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkGatF" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootGatF" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowGatF">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv11(this)" id="DivMainContentGatF">
                                    <asp:GridView ID="GridGatF" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridGatF_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpGatF" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblGatB" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkGatB" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootGatB" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowGatB">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv12(this)" id="DivMainContentGatB">
                                    <asp:GridView ID="GridGatB" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridGatB_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpGatB" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblGatC" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkGatC" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootGatC" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowGatC">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv13(this)" id="DivMainContentGatC">
                                    <asp:GridView ID="GridGatC" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="GridGatC_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%--  <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpGatC" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblResBuilding" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkRB" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootResidentialBuilding" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowResidentialBuilding">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv14(this)" id="DivMainContentResidentialBuilding">
                                    <asp:GridView ID="GridResidentialBuilding" Width="100%" runat="server" ShowFooter="true" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridResidentialBuilding_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpRB" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lblNonResBuilding" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="ChkNRB" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRootNonResidentialbuilding" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRowNonResidentialbuilding">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv15(this)" id="DivMainContentNonResidentialbuilding">
                                    <asp:GridView ID="GridNonResidentialbuilding" Width="100%" runat="server" ShowFooter="true" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridNonResidentialbuilding_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%--  <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpNRB" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="lbl2515" runat="server" Style="margin-left: 10%"></asp:Label>
                        <%--<asp:CheckBox id="Chk2515" runat="server" Text="Edit Remark and Upload Photo"  Style="margin-left:50%" Visible="false"/>--%>
                        <div id="DivRoot2515" align="left" runat="server" style="width: 100%">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRow2515">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv16(this)" id="DivMainContent2515">
                                    <asp:GridView ID="Grid2515" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" ShowFooter="true" OnRowDataBound="Grid2515_RowDataBound" DataKeyNames="वर्क आयडी">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                        <%-- <Columns>
                                            <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hlLink" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button id="btnUpGramVikas" runat="server" OnClick="btnUpBuild_Click"  Height="25" Width="65" Text="Update" Font-Size="12px"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>--%>
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
        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary" Height="40px" Width="100px" OnClick="Button4_Click" />
        <asp:Button ID="BtnExcel" runat="server" Text="Excel" CssClass="btn btn-success" Height="40px" Width="100px" OnClick="BtnExcel_Click" />
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

    <%-- <script type="text/javascript" language="javascript">
         var $table = $('.HideColumn').clone();

         $table = filterNthColumn($table, 1); //remove Action column

         function filterNthColumn($table, n) {
             return $table.find('td:nth-child(' + n + '), th:nth-child(' + n + ')').remove();
         }
        </script>--%>
</asp:Content>
