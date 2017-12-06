<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor.Master" AutoEventWireup="true" CodeBehind="ThekedarPanel.aspx.cs" Inherits="PWdEEBudget.ThekedarPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .navbar-default .navbar-nav > li > a.adminPage {
            display: block !important;
            /*background-color: gray !important;*/
            background: linear-gradient(#3b5998,#00C6D7) !important;
            color: white !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div style="overflow-x:auto">
        
        <!--//weather-charts-->
                <div class="graph-visualization">
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div style="height:100%;width:100%;">
                            <asp:Chart ID="Chart1" runat="server" Width="660px" Height="440px" Compression="1" CssClass="p1">
                                <Series>
                                    <asp:Series Name="DBS" YValuesPerPoint="6"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" Area3DStyle-PointGapDepth="1" Area3DStyle-Rotation="40" BackImageTransparentColor="WhiteSmoke" IsSameFontSizeForAllAxes="true" >
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
                </div>
        <asp:UpdatePanel runat="server" ID="upda1">
            <ContentTemplate>
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div style="height:100%;width:100%;">
                            <div style="background-color:ActiveBorder">
                                <asp:Label runat="server" Text="अर्थसंकल्पीय वर्ष" BackColor="LightYellow" ForeColor="Red"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlYear" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CssClass="form-control c" AutoPostBack="true">
                                    <asp:ListItem Text="2015-2016" Value="2015-2016"></asp:ListItem>
                                    <asp:ListItem Selected="True" Text="2016-2017" Value="2016-2017"></asp:ListItem>
                                    <asp:ListItem Text="2017-2018" Value="2017-2018"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div style ="height:550px; width:690px; overflow:auto; scrollbar-highlight-color:ActiveBorder">
                                <asp:GridView ID="gvParentGrid" runat="server" DataKeyNames="TABLE_NAME" Width="100%" AutoGenerateColumns="false" OnRowDataBound="gvParentGrid_RowDataBound" GridLines="None" BorderStyle="Solid" BorderWidth="1px"  BorderColor="#df5015" Height="200" >
                                    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                    <RowStyle BackColor="#E1E1E1" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="30px">
                                            <ItemTemplate>
                                                <a href="JavaScript:divexpandcollapse('div<%# Eval("TABLE_NAME") %>');">
                                                    <img id='imgdiv<%# Eval("TABLE_NAME") %>' width="18px" border="0" src="Images/plus.png" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TABLE_NAME" HeaderText="Head Wise Abstract Report" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <tr>
                                                    <td colspan="100%">
                                                        <div id='div<%# Eval("TABLE_NAME") %>' style="display: none; position: relative; left: 15px; overflow: auto">
                                                            <asp:GridView ID="gvChildGrid" runat="server" AutoGenerateColumns="false" BorderStyle="Double"  BorderColor="#df5015"  Width="98%" CssClass="Grid1" ShowFooter="true" OnRowDataBound="gvChildGrid_RowDataBound">
                                                                <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                                                <RowStyle BackColor="#E1E1E1" />
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Work Status" HeaderText="Work Status" HeaderStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField DataField="Total Work" HeaderText="Total Work" HeaderStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField DataField="AA cost Rs in lakhs" HeaderText="AA cost Rs in lakhs" HeaderStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField DataField="Technical Sanction Cost Rs in Lakh" HeaderText="Technical Sanction Cost Rs in Lakh" HeaderStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField DataField="Total Provision Rs in Lakh" HeaderText="Total Provision Rs in Lakh" HeaderStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField DataField="Total Expense Rs in Lakh" HeaderText="Total Expense Rs in Lakh" HeaderStyle-HorizontalAlign="Left" />
                                                                </Columns>
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
                    </div>
            </contenttemplate>
            <triggers>
                <asp:postbacktrigger controlid="gvparentgrid" />
            </triggers>
        </asp:updatepanel>
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
</asp:Content>
