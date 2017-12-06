<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="SuperAdminPanel.aspx.cs" Inherits="PWdEEBudget.SuperAdminPanel" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        .p1 {
            padding: 15px;
            background-color: pink;
            /*border-radius: 40px;*/
            margin-top: 6px;
        }
    </style>
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>--%>
    <script type="text/javascript" src="js/jquery-1.8.2.min.js"></script>

    <script type="text/javascript">


        $(function () {

            // Parse the data from an inline table using the Highcharts Data plugin
            Highcharts.chart('container', {
                data: {
                    table: 'UpVibhag',
                    startRow: 1,
                    endRow: 18,
                    endColumn: 11
                },

                chart: {
                    polar: true,
                    type: 'column'
                },

                title: {
                    text: 'Division Budget Software P.W.(East) Division Pune'
                },

                subtitle: {
                    text: 'उपविभाग नुसार कामे'
                },

                pane: {
                    size: '84%'
                },

                legend: {
                    align: 'right',
                    verticalAlign: 'top',
                    y: 92,
                    layout: 'vertical'
                },

                xAxis: {
                    tickmarkPlacement: 'on'
                },

                yAxis: {
                    min: 0,
                    endOnTick: false,
                    showLastLabel: true,
                    title: {
                        text: 'DBS'
                    },
                    labels: {
                        formatter: function () {
                            return this.value;
                        }
                    },
                    reversedStacks: false
                },

                tooltip: {
                    valueSuffix: ' कामे'
                },

                plotOptions: {
                    series: {
                        stacking: 'normal',
                        shadow: false,
                        groupPadding: 0,
                        pointPlacement: 'on'
                    }
                }
            });
        });

    </script>
    <style type="text/css">
        .excel {
            position: absolute !important;
            right: 3% !important;
            width: 20px !important;
            margin-top: 2px !important;
            border-radius: 15px !important;
            background-color: #d3d3d3 !important;
        }

            .excel img {
                width: 43px !important;
            }
    </style>
    <style>
        @media only screen and (min-width:768px) {
            /*desktop*/

            .p1 {
                height: 536px !important;
                /*width: 100% !important;*/
                border-width: 0px !important;
                padding: 5px !important;
            }

            .highcharts-root {
                width: 100% !important;
            }

            #ContentPlaceHolder1_Chart1 {
                height: 100% !important;
                width: 100% !important;
            }

            #gvParentGridDiv {
                width: 100% !important;
            }
        }

        @media only screen and (max-width:500px) {

            .p1 {
                height: 450px !important;
                width: 100% !important;
                border-width: 0px !important;
                padding: 2px !important;
            }

            .highcharts-root {
                width: 100% !important;
            }

            #ContentPlaceHolder1_Chart1 {
                height: 100% !important;
                width: 105% !important;
            }

            #gvParentGridDiv {
                width: 100% !important;
            }

            .btnForm {
                width: 48% !important;
            }

            .marqueeDivHeader {
                position: relative !important;
                left: 0 !important;
                width: 100% !important;
                color: #750f0f !important;
                font-size: 15px !important;
            }

            .marqueeDiv {
                border: 2px solid pink !important;
            }
        }
    </style>


    <%--past in body tag--%>

    <%--<script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/highcharts-more.js"></script>
    <script src="https://code.highcharts.com/modules/data.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>--%>
    <script src="css/highcharts/highcharts.js"></script>
    <script src="css/highcharts/highcharts-more.js"></script>
    <script src="css/highcharts/modules/data.js"></script>
    <script src="css/highcharts/modules/exporting.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <asp:Label ID="Label1" runat="server"></asp:Label>

        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12">
                <div style="height: 100%; width: 100%;">
                    <asp:Chart ID="Chart1" runat="server" Width="670px" Height="450px" Compression="1" CssClass="p1">

                        <Series>
                            <asp:Series Name="DBS" YValuesPerPoint="6"></asp:Series>

                        </Series>

                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" Area3DStyle-PointGapDepth="1" Area3DStyle-Rotation="40" BackImageTransparentColor="WhiteSmoke" IsSameFontSizeForAllAxes="true">
                                <Area3DStyle Enable3D="True" PointGapDepth="1"></Area3DStyle>
                            </asp:ChartArea>
                        </ChartAreas>
                        <Titles>
                            <asp:Title Name="DBS" Text="Division Budget Software Head Wise No Of Work" Font="Bold" BorderWidth="2" TextStyle="Default">
                            </asp:Title>
                        </Titles>
                    </asp:Chart>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-12">
                <div style="height: 100%; width: 100%;">
                    <div id="container" style="height: 100% !important; width: 100%;" class="p1"></div>

                    <div style="display: none">

                        <table id="UpVibhag" border="0" cellspacing="0" cellpadding="0">
                            <tr nowrap bgcolor="#CCCCFF">
                                <th colspan="11" class="hdr"></th>
                            </tr>
                            <tr nowrap bgcolor="#CCCCFF">
                                <th class="freq">Direction</th>
                                <th class="freq">सा.बां.उपविभाग, बारामती</th>
                                <th class="freq">सा.बां.(वैद्यकीय) उपविभाग, बारामती</th>
                                <th class="freq">सा.बां.उपविभाग, दौंड</th>
                                <th class="freq">सा.बां.उपविभाग, इंदापूर </th>
                                <th class="freq">सा.बां.उपविभाग, भिगवण</th>
                                <th class="freq">सा.बां.उपविभाग, शिरुर</th>
                                <%--<th class="freq">सा.बां.उपविभाग, शिरुर, आंबेगाव</th>--%>
                                <th class="freq">सा.बां.उपविभाग, प्रकल्प (खा), पुणे</th>
                                <th class="freq">सा.बां.उपविभाग, क्र. 4, पुणे</th>
                                <th class="freq">सा.बां.उपविभाग, दौंड (ईमारती) </th>


                            </tr>

                            <tr nowrap bgcolor="#DDDDDD">
                                <td class="dir">CRF</td>
                                <td id="CBarmati" runat="server" class="data"></td>
                                <td id="CUpBaramati" runat="server" class="data"></td>
                                <td id="CDound" runat="server" class="data"></td>
                                <td id="CIndapur" runat="server" class="data"></td>
                                <td id="CBhig" runat="server" class="data"></td>
                                <td id="CShirur" runat="server" class="data"></td>
                                <%-- <td id="CShirurAm" runat="server" class="data"></td>--%>
                                <td id="CPrakalp" runat="server" class="data"></td>
                                <td id="CKramank" runat="server" class="data"></td>
                                <td id="CDoundEmart" runat="server" class="data"></td>
                            </tr>
                            <tr nowrap>
                                <td class="dir">Deposit </td>
                                <td id="DFBarmati" runat="server" class="data"></td>
                                <td id="DFUpBaramati" runat="server" class="data"></td>
                                <td id="DFDound" runat="server" class="data"></td>
                                <td id="DFIndapur" runat="server" class="data"></td>
                                <td id="DFBhig" runat="server" class="data"></td>
                                <td id="DFShirur" runat="server" class="data"></td>
                                <%--<td id="DFShirurAm" runat="server" class="data"></td>--%>
                                <td id="DFPrakalp" runat="server" class="data"></td>
                                <td id="DFKramank" runat="server" class="data"></td>
                                <td id="DFDoundEmart" runat="server" class="data"></td>
                            </tr>
                            <tr nowrap bgcolor="#DDDDDD">
                                <td class="dir">MP</td>
                                <td id="MPBarmati" runat="server" class="data"></td>
                                <td id="MPUpBaramati" runat="server" class="data"></td>
                                <td id="MPDound" runat="server" class="data"></td>
                                <td id="MPIndapur" runat="server" class="data"></td>
                                <td id="MPBhig" runat="server" class="data"></td>
                                <td id="MPShirur" runat="server" class="data"></td>
                                <%--<td id="MPShirurAm" runat="server" class="data"></td>--%>
                                <td id="MPPrakalp" runat="server" class="data"></td>
                                <td id="MPKramank" runat="server" class="data"></td>
                                <td id="MPDoundEmart" runat="server" class="data"></td>
                            </tr>
                            <tr nowrap>
                                <td class="dir">MLA</td>
                                <td id="MLABarmati" runat="server" class="data"></td>
                                <td id="MLAUpBaramati" runat="server" class="data"></td>
                                <td id="MLADound" runat="server" class="data"></td>
                                <td id="MLAIndapur" runat="server" class="data"></td>
                                <td id="MLABhig" runat="server" class="data"></td>
                                <td id="MLAShirur" runat="server" class="data"></td>
                                <%-- <td id="MLAShirurAm" runat="server" class="data"></td>--%>
                                <td id="MLAPrakalp" runat="server" class="data"></td>
                                <td id="MLAKramank" runat="server" class="data"></td>
                                <td id="MLADoundEmart" runat="server" class="data"></td>
                            </tr>
                            <tr nowrap bgcolor="#DDDDDD">
                                <td class="dir">Nabard</td>
                                <td id="NABarmati" runat="server" class="data"></td>
                                <td id="NAUpBaramati" runat="server" class="data"></td>
                                <td id="NADound" runat="server" class="data"></td>
                                <td id="NAIndapur" runat="server" class="data"></td>
                                <td id="NABhig" runat="server" class="data"></td>
                                <td id="NAShirur" runat="server" class="data"></td>
                                <%-- <td id="NAShirurAm" runat="server" class="data"></td>--%>
                                <td id="NAPrakalp" runat="server" class="data"></td>
                                <td id="NAKramank" runat="server" class="data"></td>
                                <td id="NADoundEmart" runat="server" class="data"></td>

                            </tr>
                            <tr nowrap>
                                <td class="dir">Building</td>
                                <td runat="server" id="BBarmati" class="data"></td>
                                <td runat="server" id="BUpBaramati" class="data"></td>
                                <td runat="server" id="BDound" class="data"></td>
                                <td runat="server" id="BIndapur" class="data"></td>
                                <td runat="server" id="BBhig" class="data"></td>
                                <td runat="server" id="BShirur" class="data"></td>
                                <%-- <td runat="server" id="BShirurAm" class="data"></td>--%>
                                <td runat="server" id="BPrakalp" class="data"></td>
                                <td runat="server" id="BKramank" class="data"></td>
                                <td id="BDoundEmart" runat="server" class="data"></td>

                            </tr>
                            <tr nowrap bgcolor="#DDDDDD">
                                <td class="dir">Annuity</td>
                                <td id="ANBarmati" runat="server" class="data"></td>
                                <td id="ANUpBaramati" runat="server" class="data"></td>
                                <td id="ANDound" runat="server" class="data"></td>
                                <td id="ANIndapur" runat="server" class="data"></td>
                                <td id="ANBhig" runat="server" class="data"></td>
                                <td id="ANShirur" runat="server" class="data"></td>
                                <%-- <td id="ANShirurAm" runat="server" class="data"></td>--%>
                                <td id="ANPrakalp" runat="server" class="data"></td>
                                <td id="ANKramank" runat="server" class="data"></td>
                                <td id="ANDoundEmart" runat="server" class="data"></td>

                            </tr>
                            <tr nowrap>
                                <td class="dir">Gat_A</td>
                                <td id="GABarmati" runat="server" class="data"></td>
                                <td id="GAUpBaramati" runat="server" class="data"></td>
                                <td id="GADound" runat="server" class="data"></td>
                                <td id="GAIndapur" runat="server" class="data"></td>
                                <td id="GABhig" runat="server" class="data"></td>
                                <td id="GAShirur" runat="server" class="data"></td>
                                <%--<td id="GAShirurAm" runat="server" class="data"></td>--%>
                                <td id="GAPrakalp" runat="server" class="data"></td>
                                <td id="GAKramank" runat="server" class="data"></td>
                                <td id="GADoundEmart" runat="server" class="data"></td>

                            </tr>
                            <tr nowrap bgcolor="#DDDDDD">
                                <td class="dir">Gat_D</td>
                                <td id="GDBarmati" runat="server" class="data"></td>
                                <td id="GDUpBaramati" runat="server" class="data"></td>
                                <td id="GDDound" runat="server" class="data"></td>
                                <td id="GDIndapur" runat="server" class="data"></td>
                                <td id="GDBhig" runat="server" class="data"></td>
                                <td id="GDShirur" runat="server" class="data"></td>
                                <%-- <td id="GDShirurAm" runat="server" class="data"></td>--%>
                                <td id="GDPrakalp" runat="server" class="data"></td>
                                <td id="GDKramank" runat="server" class="data"></td>
                                <td id="GDDoundEmart" runat="server" class="data"></td>

                            </tr>
                            <tr nowrap>
                                <td class="dir">Gat_BCF</td>
                                <td id="GFBCBarmati" runat="server" class="data"></td>
                                <td id="GFBCUpBaramati" runat="server" class="data"></td>
                                <td id="GFBCDound" runat="server" class="data"></td>
                                <td id="GFBCIndapur" runat="server" class="data"></td>
                                <td id="GFBCBhig" runat="server" class="data"></td>
                                <td id="GFBCShirur" runat="server" class="data"></td>
                                <%--<td id="GFBCShirurAm" runat="server" class="data"></td>--%>
                                <td id="GFBCPrakalp" runat="server" class="data"></td>
                                <td id="GFBCKramank" runat="server" class="data"></td>
                                <td id="GFBCDoundEmart" runat="server" class="data"></td>

                            </tr>
                            <tr nowrap>
                                <td class="dir">SH_DOR</td>
                                <td id="ROBarmati" runat="server" class="data"></td>
                                <td id="ROUpBaramati" runat="server" class="data"></td>
                                <td id="RODound" runat="server" class="data"></td>
                                <td id="ROIndapur" runat="server" class="data"></td>
                                <td id="ROBhig" runat="server" class="data"></td>
                                <td id="ROShirur" runat="server" class="data"></td>
                                <%--  <td id="ROShirurAm" runat="server" class="data"></td>--%>
                                <td id="ROPrakalp" runat="server" class="data"></td>
                                <td id="ROKramank" runat="server" class="data"></td>
                                <td id="RODoundEmart" runat="server" class="data"></td>



                            </tr>
                            <tr nowrap>
                                <td class="dir">DPDC</td>
                                <td id="DPBarmati" runat="server" class="data"></td>
                                <td id="DPUpBaramati" runat="server" class="data"></td>
                                <td id="DPDound" runat="server" class="data"></td>
                                <td id="DPIndapur" runat="server" class="data"></td>
                                <td id="DPBhig" runat="server" class="data"></td>
                                <td id="DPShirur" runat="server" class="data"></td>
                                <%-- <td id="DPShirurAm" runat="server" class="data"></td>--%>
                                <td id="DPPrakalp" runat="server" class="data"></td>
                                <td id="DPKramank" runat="server" class="data"></td>
                                <td id="DPDoundEmart" runat="server" class="data"></td>

                            </tr>
                            <tr nowrap bgcolor="#DDDDDD">
                                <td class="dir">2059</td>
                                <td id="NRBBarmati" runat="server" class="data"></td>
                                <td id="NRBUpBaramati" runat="server" class="data"></td>
                                <td id="NRBDound" runat="server" class="data"></td>
                                <td id="NRBIndapur" runat="server" class="data"></td>
                                <td id="NRBBhig" runat="server" class="data"></td>
                                <td id="NRBShirur" runat="server" class="data"></td>
                                <%-- <td id="NRBShirurAm" runat="server" class="data"></td>--%>
                                <td id="NRBPrakalp" runat="server" class="data"></td>
                                <td id="NRBKramank" runat="server" class="data"></td>
                                <td id="NRBDoundEmart" runat="server" class="data"></td>

                            </tr>
                            <tr nowrap>
                                <td class="dir">2216</td>
                                <td id="RBBarmati" runat="server" class="data"></td>
                                <td id="RBUpBaramati" runat="server" class="data"></td>
                                <td id="RBDound" runat="server" class="data"></td>
                                <td id="RBIndapur" runat="server" class="data"></td>
                                <td id="RBBhig" runat="server" class="data"></td>
                                <td id="RbShirur" runat="server" class="data"></td>
                                <%--<td id="RBShirurAm" runat="server" class="data"></td>--%>
                                <td id="RBPrakalp" runat="server" class="data"></td>
                                <td id="RBKramank" runat="server" class="data"></td>
                                <td id="RBDoundEmart" runat="server" class="data"></td>

                            </tr>
                            <tr nowrap>
                                <td class="dir">2515</td>
                                <td id="GramVBarmati" runat="server" class="data"></td>
                                <td id="GramVUpBaramati" runat="server" class="data"></td>
                                <td id="GramVDound" runat="server" class="data"></td>
                                <td id="GramVIndapur" runat="server" class="data"></td>
                                <td id="GramVBhig" runat="server" class="data"></td>
                                <td id="GramVShirur" runat="server" class="data"></td>
                                <%-- <td id="GramVShirurAm" runat="server" class="data"></td>--%>
                                <td id="GramVPrakalp" runat="server" class="data"></td>
                                <td id="GramVKramank" runat="server" class="data"></td>
                                <td id="GramVDoundEmart" runat="server" class="data"></td>

                            </tr>

                        </table>
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top: 5px">
            <%--style="margin-top: 5px"--%>
            <asp:UpdatePanel runat="server" ID="upda1" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="col-lg-6 col-md-6 col-sm-6 p1" style="height: 450px; margin-left: 15px!important; width: 48%;">
                        <div style="background-color: ActiveBorder">
                            <table class="table table-bordered">
                                <tr>
                                    <td colspan="6">
                                        <asp:Label runat="server" Text="अर्थसंकल्पीय वर्ष" BackColor="LightYellow" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td colspan="6">
                                        <asp:DropDownList runat="server" ID="ddlYear" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CssClass="form-control c" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Label ID="Label2" runat="server" Text="उपविभाग" BackColor="LightYellow" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td colspan="6">
                                        <asp:DropDownList runat="server" ID="ddlupvibhag" OnSelectedIndexChanged="ddlupvibhag_SelectedIndexChanged" CssClass="form-control c" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Label ID="Label3" runat="server" Text="शाखा अभियंता" BackColor="LightYellow" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td colspan="6">
                                        <asp:DropDownList runat="server" ID="ddlSecEng" OnSelectedIndexChanged="ddlSecEng_SelectedIndexChanged" CssClass="form-control c" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>


                        <div id="gvParentGridDiv" style="height: 365px; width: 669px; overflow: auto; scrollbar-highlight-color: ActiveBorder; margin-top: -2%;">

                            <asp:GridView ID="gvParentGrid" runat="server" DataKeyNames="TABLE_NAME" Width="98%" AutoGenerateColumns="false" OnRowDataBound="gvParentGrid_RowDataBound" GridLines="None" BorderStyle="Solid" BorderWidth="1px" BorderColor="#df5015" Height="200">

                                <HeaderStyle BackColor="#d3d3d3" Font-Bold="true" ForeColor="White" />

                                <RowStyle BackColor="#E1E1E1" />

                                <AlternatingRowStyle BackColor="White" />

                                <Columns>

                                    <asp:TemplateField ItemStyle-Width="30px">
                                        <ItemTemplate>
                                            <a href="JavaScript:divexpandcollapse('div<%# Eval("TABLE_NAME") %>');">
                                                <img id='imgdiv<%# Eval("TABLE_NAME") %>' width="19" border="0" src="Images/plus.png" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="TABLE_NAME" HeaderText="Head Wise Abstract Report" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:TemplateField HeaderStyle-CssClass="excel">
                                        <HeaderTemplate>
                                            <asp:ImageButton runat="server" ID="BtnExcel" ImageUrl="~/Images/Download (1).png" CssClass="excel" OnClick="BtnExcel_Click1" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <tr>
                                                <td colspan="100%">
                                                    <div id='div<%# Eval("TABLE_NAME") %>' style="display: none; position: relative; left: 15px; overflow: auto">
                                                        <asp:GridView ID="gvChildGrid" runat="server" AutoGenerateColumns="true" BorderStyle="Double" BorderColor="#df5015" Width="98%" CssClass="Grid1" ShowFooter="true" OnRowDataBound="gvChildGrid_RowDataBound">
                                                            <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                                            <RowStyle BackColor="#E1E1E1" HorizontalAlign="Center" />
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />

                                                            <EmptyDataTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text="No Data Found!!!!!" CssClass="blink_me"></asp:Label>
                                                            </EmptyDataTemplate>

                                                        </asp:GridView>

                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>


                        </div>
                    </div>

                    <div class="col-lg-6 col-md-6 col-sm-6" style="margin-left: 12px;">
                        <div style="height: 100%; width: 100%;">


                            <asp:Chart ID="Chart2" runat="server" Height="450px" Width="669px" Compression="1" CssClass="p1" Palette="None">

                                <Series>
                                    <asp:Series Name="DBS" YValuesPerPoint="6" ChartType="StepLine"></asp:Series>

                                </Series>

                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" Area3DStyle-PointGapDepth="1" Area3DStyle-Rotation="40" BackImageTransparentColor="WhiteSmoke" IsSameFontSizeForAllAxes="true">
                                        <Area3DStyle Enable3D="True" PointGapDepth="1"></Area3DStyle>
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Titles>
                                    <asp:Title Name="DBS" Text="Total Abstract Report" Font="Bold">
                                    </asp:Title>
                                </Titles>
                            </asp:Chart>

                        </div>
                    </div>
                </ContentTemplate>

                <Triggers>
                    <asp:PostBackTrigger ControlID="gvParentGrid" />
                </Triggers>
            </asp:UpdatePanel>

        </div>

        <div class="row">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="col-lg-12 col-md-12 col-sm-12" style="margin-top: 11px;">
                        <div style="height: 100%; width: 100%;">
                            <div class="col-md-12 col-sm-12 marqueeDiv" style="background-color: white; border: 15px solid pink;">
                                <h3 class="marqueeDivHeader" style="position: relative; left: 40%; width: 25%; color: #750f0f!important; font-size: 18px;">Headwise All WorkID and Work</h3>

                                <asp:Button ID="btnBuilding" runat="server" Text="Building" OnClick="btnBuilding_Click" class="btn btnForm" />
                                <asp:Button ID="btnResidentialB" runat="server" Text="2216" class="btn btnForm" OnClick="btnResidentialB_Click" />
                                <asp:Button ID="btnNonResidentialB" runat="server" Text="2059" class="btn btnForm" OnClick="btnNonResidentialB_Click" />
                                <asp:Button ID="btnCRF" runat="server" Text=" CRF " OnClick="btnCRF_Click" class="btn btnForm" />
                                <asp:Button ID="btnDFund" runat="server" Text="Deposit" class="btn btnForm" OnClick="btnDFund_Click" />
                                <asp:Button ID="btnDPDC" runat="server" Text="DPDC" class="btn btnForm" OnClick="btnDPDC_Click" />

                                <asp:Button ID="btnAunty" runat="server" Text="Annuity" OnClick="btnAunty_Click" class="btn btnForm" />

                                <asp:Button ID="btnRoad" runat="server" Text="SH&DOR" class="btn btnForm" OnClick="btnRoad_Click" />

                                <asp:Button ID="btnNabard" runat="server" Text="Nabard" class="btn btnForm" OnClick="btnNabard_Click" />
                                <asp:Button ID="btnGataA" runat="server" Text="Gat_A  " class="btn btnForm" OnClick="btnGataA_Click" />
                                <asp:Button ID="btnGataFBC" runat="server" Text="Gat_BCF" class="btn btnForm" OnClick="btnGataFBC_Click" />
                                <asp:Button ID="btnGataD" runat="server" Text="Gat_D  " class="btn btnForm" OnClick="btnGataD_Click" />

                                <asp:Button ID="btnMLA" runat="server" Text="MLA " class="btn btnForm" OnClick="btnMLA_Click" />
                                <asp:Button ID="btnMP" runat="server" Text="MP " class="btn btnForm" OnClick="btnMP_Click" />
                                <asp:Button ID="btnGramvikas" runat="server" Text="2515" class="btn btnForm" OnClick="btnGramvikas_Click" />

                                <div class="col-sm-12" style="border: outset">

                                    <marquee id="marquee1" runat="server" style="text-align: center" direction="up" height="300" scrollamount="3" loop="1" onmouseover="this.stop()" onmouseout="this.start()">
                <asp:Label ID="lblHeader" runat="server" Text="Building" Font-Size="X-Large" ForeColor="#800000"></asp:Label>
                <asp:Literal ID="lt1" runat="server"></asp:Literal></marquee>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


        <script lang="javascript" type="text/javascript">
            function divexpandcollapse(divname) {
                var div = document.getElementById(divname);
                var img = document.getElementById('img' + divname);
                if (div.style.display == "none") {
                    div.style.display = "inline";
                    img.src = "Images/minus.png";
                } else {
                    div.style.display = "none";
                    img.src = "Images/plus.png";
                }
            }
        </script>
    </div>

</asp:Content>

