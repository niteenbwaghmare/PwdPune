<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="AutoSMSReport.aspx.cs" Inherits="PWdEEBudget.AutoSMSReport" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            font-size: 17px;
            padding: 3px;
            text-align: center;
        }

        td {
            color: #0e0505;
            font-size: 15px;
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
        table:first-child tr > th {
            font-size: 17px!important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <table class="table table-bordered" style="color: #000; margin-top:5%">
            <tr>
                <th colspan="8"  style="text-align:center"><h2>SMS Report</h2></th>       
            </tr>
        </table>
    </div>
     <div id="DivRoot" align="left" runat="server" style="width: 100%; padding:27px;">
                            <div style="width: 100%">
                                <div style="overflow: hidden; width: 100%" id="DivHeaderRow">
                                </div>
                                <div style="overflow: scroll; width: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                                    <asp:GridView ID="GridSMS" runat="server" Width="100%" Font-Size="16px" Style="border: 2px solid" CaptionAlign="Top" OnRowDataBound="GridSMS_RowDataBound">
                                        <EmptyDataTemplate>
                                            No Matching Record Found....!!!!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" Font-Size="Medium" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
    <script lang="javascript" type="text/javascript">
        function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRow');
                var DivMC = document.getElementById('DivMainContent');
                
                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                DivHR.style.height = '78px';
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
                DivMC.style.top = -78 + 'px';
                DivMC.style.zIndex = '1';


                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv(Scrollablediv) {
            document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
        }

    </script>
</asp:Content>
