<%@ Page Title="" Language="C#" MasterPageFile="~/MPMLA.Master" AutoEventWireup="true" CodeBehind="MLAMP_Dashboard.aspx.cs" Inherits="PWdEEBudget.MLAMP_Dashboard" %>

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
     <style>
        .navbar-default .navbar-nav > li > a.DashBoard {
            display: block !important;
            /*background-color: gray !important;*/
            background: linear-gradient(#3b5998,#00C6D7) !important;
            color: white !important;
        }
    </style>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <style type="text/css">
        /*${ 
                demo.css

            }*/
    </style>
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
            position: absolute!important;
            right: 3%!important;
            width: 20px!important;
            margin-top: 2px!important;
            border-radius: 15px!important;
            background-color: #d3d3d3!important;
        }

            .excel img {
                width: 43px!important;
            }
    </style>


    <%--past in body tag--%>

    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/highcharts-more.js"></script>
    <script src="https://code.highcharts.com/modules/data.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>



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
            <div class="col-lg-6 col-md-6 col-sm-12 p1" style="height: 450px;">
                <div style="height:100%;width: 100%;">
                    <asp:UpdatePanel runat="server" ID="upda1">
                        <ContentTemplate>
                            <div style="background-color: ActiveBorder">
                                <asp:Label ID="Label2" runat="server" Text="अर्थसंकल्पीय वर्ष" BackColor="LightYellow" ForeColor="Red"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlYear" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CssClass="form-control c" AutoPostBack="true"></asp:DropDownList>

                            </div>


                            <div style="height: 365px; width: 669px; overflow: auto; scrollbar-highlight-color: ActiveBorder;">

                                <asp:GridView ID="gvParentGrid" runat="server" DataKeyNames="TABLE_NAME" Width="98%" AutoGenerateColumns="false" OnRowDataBound="gvParentGrid_RowDataBound" GridLines="None" BorderStyle="Solid" BorderWidth="1px" BorderColor="#df5015" Height="200">

                                    <HeaderStyle BackColor="#d3d3d3" Font-Bold="true" ForeColor="White" />

                                    <RowStyle BackColor="#E1E1E1" />

                                    <AlternatingRowStyle BackColor="White" />

                                    <%--<HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />--%>

                                    <Columns>

                                        <asp:TemplateField ItemStyle-Width="30px">
                                            <ItemTemplate>
                                                <a href="JavaScript:divexpandcollapse('div<%# Eval("TABLE_NAME") %>');">
                                                    <img id='imgdiv<%# Eval("TABLE_NAME") %>' width="19" border="0" src="Images/plus.png" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="TABLE_NAME" HeaderText="Head Wise Abstract Report" HeaderStyle-HorizontalAlign="Center" />
                                        <%--<asp:BoundField HeaderText="Excel" HeaderStyle-HorizontalAlign="Right" HeaderStyle-CssClass="excel" HeaderImageUrl="~/Images/Excel.png"  />--%>
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
                                                                    <asp:Label ID="Label3" runat="server" Text="No Data Found!!!!!" CssClass="blink_me"></asp:Label>
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

                        </ContentTemplate>

                        <Triggers>
                            <asp:PostBackTrigger ControlID="gvParentGrid" />
                        </Triggers>
                    </asp:UpdatePanel>


                </div>
            </div>
            
        </div>

        <div class="row" style="margin-top: 5px">
            <%--style="margin-top: 5px"--%>
            

        </div>


        <script language="javascript" type="text/javascript">
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
