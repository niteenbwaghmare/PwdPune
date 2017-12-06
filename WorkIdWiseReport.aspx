<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="WorkIdWiseReport.aspx.cs" Inherits="PWdEEBudget.WorkIdWiseReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pageCenter {
            margin-left: auto;
            margin-right: auto;
        }

        .c {
            font-weight: bold;
            color: #000000;
            width: 100% !important;
            font-size: 16px;
            height: 38px !important;
            line-height: 38px !important;
        }

        td {
            text-align: center;
        }

        th {
            font-size: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <table class="table table-bordered" style="color: #000; margin-top: 5%">
            <tr>
                <th colspan="8" style="text-align: center">
                    <h2>Work Id Wise Report</h2>
                </th>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="अर्थसंकल्पीय वर्ष :"></asp:Label>
                </td>
                <td colspan="4">
                    <asp:DropDownList ID="ddlArthsankalpiyYear" runat="server" Style="width: 50%" CssClass="form-control p">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVArthYear" runat="server" ControlToValidate="ddlArthsankalpiyYear" ErrorMessage="अर्थसंकल्पीय वर्ष निवडा!" InitialValue="Select" ForeColor="red" Font-Size="Larger" Display="Dynamic" CssClass="blink_me" BackColor="Yellow">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl" runat="server" Text="प्रकार:"></asp:Label>
                </td>
                <td colspan="4">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control c" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl1" runat="server" Text="वर्क आयडी:"></asp:Label></td>
                <td colspan="4">
                    <asp:TextBox ID="txtoldWorkID" runat="server" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtoldWorkID_TextChanged" required=""></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10" CompletionSetCount="1" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="GetCompletionList" TargetControlID="txtoldWorkID">
                    </ajaxToolkit:AutoCompleteExtender>
                </td>
            </tr>
        </table>
    </div>
    <div style="overflow-x: auto;" align="center" class="b">
        <br />
        &nbsp;&nbsp;
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
                <asp:Label ID="lblStatus" runat="server"></asp:Label>&nbsp;
                 <asp:Panel ID="Panel1" runat="server">
                     <asp:GridView ID="GridView1" runat="server">
                         <HeaderStyle Font-Bold="True" Font-Names="Bell MT" Font-Size="8px" />
                     </asp:GridView>
                 </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
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

