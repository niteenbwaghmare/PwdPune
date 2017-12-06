<%@ Page Title="Complaint" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="ComplaintForm.aspx.cs" Inherits="PWdEEBudget.ComplaintForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery.responsiveText.js"></script>
    <script type="text/javascript">
    
    </script>

    <style>
        @media only screen and (min-width:768px) {
            /*desktop*/

        }

        @media only screen and (max-width:500px) {
            #Print {
                width: 1200px !important;
            }

            .btnform {
                width: 22% !important;
            }
        }

        .tdwidth {
            width: 10%;
        }

        .controlwidth {
            width: 40%!important;
        }

        .ddlMenu1 > tbody > tr > td > label {
            font-size: small!important;
        }

        .ComplaintId {
            margin: 0px -36px 0 -11px!important;
            border-left: none!important;
            padding-left: 0px!important;
            width: 20%!important;
        }

        .Grid > tbody > tr > td, th {
            text-align: center!important;
        }

        .Grid > tbody > tr > td {
            font-size: 14px!important;
        }

        .Grid > tbody > tr > th {
            font-size: 15px!important;
        }

        .mask {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 4;
            opacity: 0.4;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=40)"; /* first!*/
            filter: alpha(opacity=40); /* second!*/
            background-color: gray;
            display: none;
            width: 100%;
            height: 100%;
        }

        .popup-content-box {
            position: fixed;
            left: 50%;
            top: 50%;
            background-color: White;
            padding: 5px;
            border: outset 2px gray;
            -ms-transform: translate(-50%,-50%);
            -moz-transform: translate(-50%,-50%);
            -webkit-transform: translate(-50%,-50%);
            transform: translate(-50%,-50%);
        }

        .Emptydata > td {
            width: 17%!IMPORTANT;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>

            <div style="overflow: auto;">
                <br />


                <table id="tblInput" class="table table-bordered mar" style="border: 2px solid gray">

                    <tr style="text-align: center; background: linear-gradient(gray,white)">
                        <td style="font-weight: bold; color: black" colspan="3">
                            <asp:Label ID="Label10" runat="server" Text="Register Your Complaint" Font-Bold="True" Font-Size="XX-Large" Height="70px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 40%; border-left: none; border-right: none;">
                            <asp:RadioButtonList runat="server" ID="rdbReportType" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdbReportType_SelectedIndexChanged" CssClass="rdbComplaintType">
                                <asp:ListItem Selected="True">Register Complaint</asp:ListItem>
                                <asp:ListItem>See Answer Report</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="width: 40%; border-left: none; border-right: none;">Enter Your Complaint Id :
                        
                            <div class="input-group">
                                <span class="input-group-addon Complaint" style="background-color: white"><b>SGPEDBS_00</b></span>
                                <asp:TextBox runat="server" ID="txtComplaintId" CssClass="form-control ComplaintId" AutoPostBack="true" OnTextChanged="txtComplaintId_TextChanged"></asp:TextBox>

                            </div>

                        </td>
                        <td style="width: 14%; border-left: none; border-right: none;">
                            <div runat="server" id="DivPwd" style="display: none">
                                Enter Password For Answer
                             
                <asp:TextBox runat="server" ID="txtPwd" CssClass="form-control" TextMode="Password" AutoPostBack="true" OnTextChanged="txtPwd_TextChanged"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="Print" class="table table-bordered mar" style="border: 2px solid gray" runat="server">
                    <tr>
                        <td style="font-weight: bold;" class="tdwidth">Selct Your Post </td>

                        <td style="font-weight: bold;">
                            <asp:DropDownList ID="ddlPost" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="7" Width="334px" OnSelectedIndexChanged="ddlPost_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td rowspan="4">
                            <img id="img1" src="img/complaint_box_logo.png" style="margin-left: 20%; height: 80%;" class="blink_me" />
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold;" class="tdwidth">Select Your Name </td>

                        <td style="font-weight: bold;">
                            <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="9" Width="334px" OnSelectedIndexChanged="ddlName_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <%-- <td></td>--%>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; font-size: larger; font: bold">OR</td>
                        <%-- <td></td>--%>
                    </tr>
                    <tr>
                        <td style="font-weight: bold;" class="tdwidth">Enter Your Name</td>

                        <td style="font-weight: bold;">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control c"></asp:TextBox>
                        </td>
                        <%-- <td></td>--%>
                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td class="c" colspan="3" style="font-weight: bold; color: black; font-size: 18px">ABOUT YOUR QUERY / COMPLAINT</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="font-weight: bold; color: gray">
                            <h3>Select Below Option Any One</h3>
                        </td>
                        <td style="text-align: right;">
                            <h3>Query / Complaint Date:-
                            <asp:Label ID="lblQueryDate" runat="server">01/09/2017</asp:Label>
                            </h3>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="font-weight: bold;">
                            <asp:RadioButtonList runat="server" ID="rdbMenuTag" RepeatDirection="Horizontal" RepeatColumns="7" CssClass="ddlMenu ddlMenu1" Font-Size="Small">
                                <asp:ListItem Selected="True">Master Budget Form (Input Form)</asp:ListItem>
                                <asp:ListItem>MPR Report</asp:ListItem>
                                <asp:ListItem>Master HeadWise Report</asp:ListItem>
                                <asp:ListItem>Master Indivisual Report</asp:ListItem>
                                <asp:ListItem>17 Column Indivisual Report</asp:ListItem>
                                <asp:ListItem>Mail Report</asp:ListItem>
                                <asp:ListItem>HeadWise Abstract</asp:ListItem>
                                <asp:ListItem>Master HeadWise Report</asp:ListItem>
                                <asp:ListItem>DBS Report</asp:ListItem>
                                <asp:ListItem>Setting</asp:ListItem>

                            </asp:RadioButtonList>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="font-weight: bold; color: gray">
                            <hr />
                        </td>

                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td colspan="3" style="font-weight: bold; color: black; font-size: 18px">
                            <asp:Label runat="server" Text="Specifice Error Page Name :" ID="lblErrorPage"></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="3" style="font-weight: bold; color: gray" id="tdErrorPageReport">

                            <asp:RadioButtonList runat="server" ID="rdbErrorPageHead" RepeatDirection="Horizontal" RepeatColumns="17" CssClass="ddlMenu1" Font-Size="Small">
                                <asp:ListItem Selected="True">Building</asp:ListItem>
                                <asp:ListItem>CRF</asp:ListItem>
                                <asp:ListItem>Nabard</asp:ListItem>
                                <asp:ListItem>Road</asp:ListItem>
                                <asp:ListItem>Annuity</asp:ListItem>
                                <asp:ListItem>DPDC</asp:ListItem>
                                <asp:ListItem>Deposite Fund</asp:ListItem>
                                <asp:ListItem>Residencial Building</asp:ListItem>
                                <asp:ListItem>Non Residencial Building</asp:ListItem>
                                <asp:ListItem>Gat_A</asp:ListItem>
                                <asp:ListItem>Gat_B</asp:ListItem>
                                <asp:ListItem>Gat_C</asp:ListItem>
                                <asp:ListItem>Gat_D</asp:ListItem>
                                <asp:ListItem>Gat_F</asp:ListItem>
                                <asp:ListItem>MLA</asp:ListItem>
                                <asp:ListItem>MP</asp:ListItem>
                                <asp:ListItem>2515</asp:ListItem>

                            </asp:RadioButtonList>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="3" style="font-weight: bold; color: gray; display: none" id="tdDBSReport">
                            <asp:RadioButtonList runat="server" ID="rdbDBSReport" RepeatDirection="Horizontal" RepeatColumns="11" CssClass="ddlMenu1" Font-Size="Small">
                                <asp:ListItem Selected="True">Sub Division Wise Report</asp:ListItem>
                                <asp:ListItem>All Head wise report</asp:ListItem>
                                <asp:ListItem>Indivisual Head Wise Report</asp:ListItem>
                                <asp:ListItem>Statistics</asp:ListItem>
                                <asp:ListItem>Month Wise Report</asp:ListItem>
                                <asp:ListItem>Date Wise Report</asp:ListItem>
                                <asp:ListItem>Cost Wise Report</asp:ListItem>
                                <asp:ListItem>WorkId Wise Report</asp:ListItem>
                                <asp:ListItem>SmS Report</asp:ListItem>
                                <asp:ListItem>User Cred Report</asp:ListItem>
                                <asp:ListItem>Bill Status</asp:ListItem>


                            </asp:RadioButtonList>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="3" style="font-weight: bold; color: gray; display: none" id="tdSetting">
                            <asp:RadioButtonList runat="server" ID="rdbErrorPageSetting" RepeatDirection="Horizontal" RepeatColumns="11" CssClass="ddlMenu1" Font-Size="Small">
                                <asp:ListItem Selected="True">Distict</asp:ListItem>
                                <asp:ListItem>Taluka</asp:ListItem>
                                <asp:ListItem>Sub Division</asp:ListItem>
                                <asp:ListItem>Consumer Department</asp:ListItem>
                                <asp:ListItem>MLA/MP</asp:ListItem>
                                <asp:ListItem>Head (लेखाशिर्ष)</asp:ListItem>
                                <asp:ListItem>Portal SMS</asp:ListItem>
                                <asp:ListItem>SMS</asp:ListItem>
                                <asp:ListItem>View User Profile</asp:ListItem>
                                <asp:ListItem>Create Account</asp:ListItem>
                                <asp:ListItem>Update WorkID & Budget Year</asp:ListItem>
                                <asp:ListItem>UpLoad Image</asp:ListItem>
                                <asp:ListItem>Generate New Bill</asp:ListItem>

                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td colspan="3" style="font-weight: bold; color: black; font-size: 18px" class="c">Error Description </td>


                    </tr>
                    <tr>
                        <td class="tdwidth">Description </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control c" PlaceHolder="Description" TabIndex="33" TextMode="MultiLine"></asp:TextBox>

                        </td>
                        <td></td>

                    </tr>
                    <tr>
                        <td class="tdwidth">Enter Error Page Url:
                        </td>
                        <td>
                            <asp:TextBox ID="txtErrorPageUrl" runat="server" CssClass="form-control c" PlaceHolder="Enter Error Page URL"></asp:TextBox>

                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="tdwidth">Upload Error Image:-
                        </td>
                        <td>
                            <asp:FileUpload runat="server" ID="ErrorImgUpload" />
                        </td>
                        <td></td>
                    </tr>



                    <tr>
                        <td colspan="3" style="font-weight: bold; color: gray">&nbsp;</td>
                    </tr>


                </table>
            </div>


            <br />
            <div id="DivBtn" runat="server" class="DivBtn">
                <asp:Button ID="BtnSav" CssClass="btnform" runat="server" Text="Submit" TabIndex="51" Height="10%" OnClick="BtnSav_Click" />
                <asp:Button ID="BtnCancel" runat="server" CssClass="btnform" Text="Cancel" TabIndex="52" Height="10%" OnClientClick="Navigate()" />
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnform" OnClientClick="JavaScript:window.history.back(1); return false;" TabIndex="54" Height="10%" />

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="Print">
                <div id="DivRoot" align="left" style="width: 100%">
                    <div style="overflow: hidden; width: 100%;" id="DivHeaderRow">
                    </div>

                    <div style="overflow: auto; width: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                        <asp:GridView runat="server" ID="GridAns" AutoGenerateColumns="false" OnRowCommand="GridAns_RowCommand1" DataKeyNames="Complaint_Id" HeaderStyle-HorizontalAlign="Center" CssClass="Grid" Width="100%" Style="border: 2px solid; display: none">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="5%" HeaderStyle-Width="5%" />
                                <asp:BoundField DataField="MenuType" HeaderText="Menu Type" ItemStyle-Width="5%" HeaderStyle-Width="5%" />
                                <asp:BoundField DataField="Error_PageName" HeaderText="Error Page Name" ItemStyle-Width="3%" HeaderStyle-Width="3%" />
                                <asp:BoundField DataField="Error_PageUrl" HeaderText="Error Url" ItemStyle-Width="5%" HeaderStyle-Width="5%" />
                                <asp:BoundField DataField="Error_Description" HeaderText="Error Description" ItemStyle-Width="40%" HeaderStyle-Width="40%" />
                                <asp:BoundField DataField="ComplaintDate" HeaderText="Date of Complaint" ItemStyle-Width="4%" HeaderStyle-Width="4%" />
                                <asp:BoundField DataField="Error_Ans" HeaderText="Ans Description" ItemStyle-Width="30%" HeaderStyle-Width="30%" />
                                <asp:BoundField DataField="Ans_ByName" HeaderText="Ans By" ItemStyle-Width="3%" HeaderStyle-Width="3%" />
                                <asp:BoundField DataField="Ans_Date" HeaderText="Date of Ans" ItemStyle-Width="5%" HeaderStyle-Width="5%" />

                                <asp:TemplateField HeaderText="Edit Ans" SortExpression="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="ShowPopup"
                                            CommandArgument='<%#Eval("Complaint_Id") %>' CssClass="popupComplaint">Edit Ans</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label runat="server" Text="No Data Found....Enter Valid Complaint Id" CssClass="blink_me"></asp:Label>
                            </EmptyDataTemplate>

                            <EmptyDataRowStyle BackColor="Yellow" ForeColor="Red" HorizontalAlign="Center" Width="100%" CssClass="Emptydata" />
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div id="mask" runat="server" class="mask">
            </div>
            <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="300px"
                Width="700px" Style="z-index: 111; display: none" CssClass="popup-content-box">
                <table width="100%" style="width: 100%; height: 100%;" cellpadding="0" cellspacing="5">
                    <div>
                        <tr style="background: linear-gradient(#ccc,#fae8bd)">
                            <td colspan="4" style="color: red; font-weight: bold; font-size: 1.2em; padding: 3px"
                                align="center">Your Answer <a id="closebtn" style="color: Red; float: right; text-decoration: none" class="btnClose" href="#">X</a>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 24%; padding-left: 3%; text-align: left;">
                                <b>Complaint Id:</b>
                            </td>
                            <td style="width: 50%;">SGPEDBS_00
                        <asp:Label ID="lblComplaintId" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <b>Ans Date:  </b>
                            </td>
                            <td>
                                <asp:Label ID="lblAnsDate" runat="server" />
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: left; padding-left: 3%;">
                                <b>Error Page Name:</b>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lblErorPage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; padding-left: 3%;">
                                <b>Error Descripton:</b>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lblErrorDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; padding-left: 3%;">
                                <b>Your Ans:</b>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtAns" runat="server" TextMode="MultiLine" CssClass="form-control" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; padding-left: 3%;">
                                <b>Your Name:</b>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtAnsBy" runat="server" CssClass="form-control" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: center;">
                                <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                <input type="button" class="btnClose" value="Cancel" />
                                <asp:HiddenField runat="server" ID="hiddenFieldMob" />
                            </td>
                        </tr>
                    </div>
                </table>
            </asp:Panel>


        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function Navigate() {
            location.href = "SuperAdminPanel.aspx";
        }

    </script>

    <script src="Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            var isPostBack1 = '<%=this.Page.IsPostBack ? "true" : "false" %>';

            HidePopup();
            $(".popupComplaint").live('click', function () {

                ShowPopup();
            });
            function ShowPopup() {
                $('#<%=mask.ClientID %>').show('fade');
                $('#<%=pnlpopup.ClientID %>').show('fade');

            }
            function HidePopup() {
                $('#<%=mask.ClientID %>').hide('shake');

                $('#<%=pnlpopup.ClientID %>').hide('shake');
            }
            $(".btnClose").live('click', function () {
                HidePopup();
            });


            //new

            $(".rdbComplaintType").live('click', function () {
                MakeStaticHeader('#<%=GridAns.ClientID%>', 750, 100, 120, true, false);
                Divbtn()

            });
            $('#<%=txtComplaintId.ClientID%>').blur(function () {

                Divbtn();
            });
            function Divbtn() {

                var complaintType = $('input[id*=rdbReportType]:checked').val();
                if (complaintType == "See Answer Report") {
                    $("[id*=txtComplaintId]").val("");
                    $("#DivBtn").hide();
                }
                else {

                    $("#DivBtn").show();

                }
            }
            //This Script Code FOr ComplaintForm hide or show table td

            $(".ddlMenu").live('click', function () {

                var MenuType = $('input[id*=rdbMenuTag]:checked').val();

                if (MenuType == "Setting") {
                    $("[id*=tdErrorPageReport]").hide();
                    $("[id*=tdDBSReport]").hide();
                    $("[id*=tdSetting]").show();


                }
                else if (MenuType == "DBS Report") {
                    $("[id*=tdErrorPageReport]").hide();
                    $("[id*=tdDBSReport]").show();
                    $("[id*=tdSetting]").hide();

                }
                else {
                    $("[id*=tdErrorPageReport]").show();
                    $("[id*=tdDBSReport]").hide();
                    $("[id*=tdSetting]").hide();

                }
            });
            $(".Complaint").live('click', function () {
                $("[id*=txtComplaintId]").focus();
            });


        });

    </script>
    <script lang="javascript" type="text/javascript">
        function pageLoad() {
            $(document).ready(function () {


            });
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
                DivHR.style.height = '68px';
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
                DivMC.style.top = -68 + 'px';
                DivMC.style.zIndex = '1';

                //****Copy Header in divHeaderRow****
                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv(Scrollablediv) {
            document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
        }


    </script>
    <%--<script type="text/javascript" src="js/jquery-1.8.2.min.js"></script>--%>
</asp:Content>
