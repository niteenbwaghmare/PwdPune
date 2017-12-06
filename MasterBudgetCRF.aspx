<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="MasterBudgetCRF.aspx.cs" Inherits="PWdEEBudget.MasterBudgetCRF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery.responsiveText.js"></script>

    <style type="text/css">
        #CalendarExtender1 {
            padding: 0px 0px;
        }

        .c {
           
            font-weight: bold;
            color: #000000;
            width: 100% !important;
            font-size: 16px;
            height: 38px !important;
            line-height: 38px !important;
        }
    </style>
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
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
            <asp:Label ID="lbl1" runat="server" Visible="False"></asp:Label>
            <div style="overflow: auto;">
                <br />
                <table id="Print" class="table table-bordered" style="border: 2px solid gray">

                    <tr style="text-align: center; background:linear-gradient(gray,white);">
                        <td colspan="32" style="color:black">
                            
                            <asp:Label ID="Label10" runat="server" Text="Master Budget Central Road Fund " Height="70px" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Work_ID </td>
                        <td colspan="8">
                            <asp:TextBox ID="txtWorkID" CssClass="form-control c" runat="server" required="" PlaceHolder="Work_ID" AutoPostBack="True" TabIndex="1" OnTextChanged="txtWorkID_TextChanged"></asp:TextBox>
                            
                             <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtWorkID"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight">  
                </ajaxToolkit:AutoCompleteExtender>
                             <asp:RequiredFieldValidator ID="RFVtxtWorkID" runat="server" ControlToValidate="txtWorkID" ErrorMessage="Please Enter WorkId" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="3">Budget Year</td>
                        <td colspan="11">
                            <asp:TextBox ID="txtarthsankalpiyyear" runat="server" AutoPostBack="True" CssClass="form-control c" MaxLength="4" OnTextChanged="txtarthsankalpiyyear_TextChanged" PlaceHolder="Year" required="" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVtxtarthsankalpiyyear" runat="server" ControlToValidate="txtarthsankalpiyyear" ErrorMessage="Please select Budget Year" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> 
                        </td>
                        <td colspan="1">SR.No</td>
                        <td colspan="2">
                            <asp:Label ID="lblId" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">Name of Scheme</td>
                        <td colspan="2" style="text-align: center;">
                            <asp:Label ID="ddlType" runat="server" class="blink_me" ForeColor="Red" Text="Central Road Fund"></asp:Label>
                        </td>
                       
                    </tr>

                    <tr>
                        <td colspan="3">District </td>
                        <td colspan="8">
                            <asp:DropDownList ID="ddldist" runat="server" CssClass="form-control c" PlaceHolder="Select" AutoPostBack="True" OnSelectedIndexChanged="ddldist_SelectedIndexChanged" TabIndex="3">
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RFVddldist" ControlToValidate="ddldist" runat="server" ErrorMessage="Please select District" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> 
                        </td>
                        <td colspan="3">Taluka</td>
                        <td colspan="8">
                            <asp:DropDownList ID="ddltaluka" runat="server" CssClass="form-control c" PlaceHolder="Select" AutoPostBack="True" TabIndex="4">
                              
                            </asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="RFVddltaluka" ControlToValidate="ddltaluka" runat="server" ErrorMessage="Please select Taluka" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> --%>
                        </td>
                        <td colspan="2">Budget SR.No </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtarthsankalpiybab" runat="server" CssClass="form-control c" PlaceHolder="SR.No" TabIndex="17"></asp:TextBox></td>
                        <td colspan="2">Sub-Division </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlupvibhag" runat="server" AutoPostBack="True" PlaceHolder="Select" CssClass="form-control c" TabIndex="5">
                               
                            </asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="RFVddlupvibhag" ControlToValidate="ddlupvibhag" runat="server" ErrorMessage="Please select Sub-Division" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> --%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3"><strong>Head of Account</strong></td>
                        <td colspan="8">
                            <asp:DropDownList ID="ddllekhashirsh" runat="server" CssClass="form-control c" PlaceHolder="Select" AutoPostBack="True" TabIndex="14" OnSelectedIndexChanged="ddllekhashirsh_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td colspan="14">
                            <asp:Label ID="lblLekhaName" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">Name of Department</td>
                        <td colspan="5">
                            <asp:DropDownList ID="ddlsubtype" runat="server" AutoPostBack="True" PlaceHolder="Select" CssClass="form-control c" TabIndex="15">
                              
                            </asp:DropDownList>
                             <%--<asp:RequiredFieldValidator ID="RFVddlsubtype" ControlToValidate="ddlsubtype" runat="server" ErrorMessage="Please select Department name" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%> 
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Sectional Engineer 
                        </td>
                        <td colspan="18">
                            <asp:DropDownList ID="ddlabhiyanta" runat="server" CssClass="form-control c selectableddl" PlaceHolder="Select" AutoPostBack="True" TabIndex="6" OnSelectedIndexChanged="ddlabhiyanta_SelectedIndexChanged">
                                <asp:ListItem> </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td colspan="4">Mobile No</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtabhiyantamobile" runat="server" CssClass="form-control c" PlaceHolder="Mobile No" TabIndex="7" MaxLength="10" TextMode="Phone"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Deputy Engineer</td>
                        <td colspan="18">
                            <asp:DropDownList ID="ddlupabhiyanta" runat="server" CssClass="form-control c selectableddl" PlaceHolder="Select" AutoPostBack="True" TabIndex="8" OnSelectedIndexChanged="ddlupabhiyanta_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td colspan="4">Mobile No</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtupabhiyantamobile" runat="server" CssClass="form-control c" PlaceHolder="Mobile No" TabIndex="9" MaxLength="10" TextMode="Phone"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">MP Name</td>
                        <td colspan="18">
                            <asp:DropDownList ID="ddlkhasdarachename" CssClass="form-control c selectableddl" runat="server" PlaceHolder="Select" AutoPostBack="True" TabIndex="12">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td colspan="4">MLA Name</td>
                        <td colspan="7">
                            <asp:DropDownList ID="ddlaamdarachename" runat="server" CssClass="form-control c selectableddl" PlaceHolder="Select" AutoPostBack="True" TabIndex="13">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td colspan="29" style="font-size: 18px">Department Engineer </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDeptEngPassword" AutoPostBack="true" OnTextChanged="txtDeptEngPassword_TextChanged" TextMode="Password" CssClass="form-control c" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3">Work Name </td>
                        <td colspan="17">
                            <asp:TextBox ID="txtkamachenav" runat="server" CssClass="form-control" Style="font-size: 16px; font-weight: bold" Width="100%" PlaceHolder="Work Name" TextMode="MultiLine" TabIndex="18"></asp:TextBox>
                        </td>
                        <td colspan="2">Scope of Work </td>
                        <td colspan="10">
                            <asp:TextBox ID="txtkamachavav" runat="server" CssClass="form-control" Style="font-size: 16px; font-weight: bold" Width="100%" PlaceHolder="Scope" TextMode="MultiLine" TabIndex="19"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="3">Administrative Approval No. </td>
                        <td colspan="10">
                            <asp:TextBox ID="txtprashaskiykramank" runat="server" CssClass="form-control c" PlaceHolder="Approval No." TabIndex="20"></asp:TextBox></td>
                        <td colspan="3">Date </td>
                        <td colspan="10">
                            <asp:TextBox ID="txtprashaskiydinak" runat="server" CssClass="form-control c" PlaceHolder="Date" TabIndex="21"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" BehaviorID="CalendarExtender2" TargetControlID="txtprashaskiydinak" Format="dd/MM/yyyy" />
                        </td>
                        <td colspan="2">Rs. in Lakh </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtprashaskiykimat" runat="server" CssClass="form-control c" PlaceHolder="Cost" TabIndex="22" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Technical Approval No</td>
                        <td colspan="10">
                            <asp:TextBox ID="txttantrikkramank" runat="server" CssClass="form-control c" PlaceHolder="Approval No" TabIndex="23"></asp:TextBox></td>
                        <td colspan="3">Date</td>
                        <td colspan="10">
                            <asp:TextBox ID="txttantarikdinak" runat="server" CssClass="form-control c" PlaceHolder="Date" TabIndex="24"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" BehaviorID="CalendarExtender3" TargetControlID="txttantarikdinak" Format="dd/MM/yyyy" />
                        </td>
                        <td colspan="2">Rs in Lakh </td>
                        <td colspan="4">
                            <asp:TextBox ID="txttantarikkimat" runat="server" CssClass="form-control c" PlaceHolder="Cost" TabIndex="25" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>

                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td style="font-size: 18px" colspan="29">Tender Information</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtTenderPassword" AutoPostBack="true" OnTextChanged="txtTenderPassword_TextChanged" TextMode="Password" CssClass="form-control c" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3">Contractor Name
                        </td>
                        <td colspan="19">
                            <asp:DropDownList ID="ddlThekedarName" runat="server" AutoPostBack="True" PlaceHolder="Select" CssClass="form-control c selectableddl" OnSelectedIndexChanged="ddlThekedarName_SelectedIndexChanged" TabIndex="26">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="3">Mobile No </td>
                        <td colspan="7">
                            <asp:Label ID="lblThekedarMobNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Agreement No.</td>
                        <td colspan="8">
                            <asp:TextBox ID="txtNividaKramank" runat="server" CssClass="form-control c" PlaceHolder="Tender No." TabIndex="27"></asp:TextBox>
                        </td>
                        <td colspan="3">Tender Amount in Lakh</td>
                        <td colspan="8">
                            <asp:TextBox ID="txtNividaKimat" runat="server" CssClass="form-control c" PlaceHolder="Tender Cost" TabIndex="28">0</asp:TextBox>
                        </td>
                        <td colspan="3">Work Order</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtkaryarambhaadesh" runat="server" CssClass="form-control c" PlaceHolder="Work Order" TabIndex="29"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Starting Date</td>
                        <td colspan="8">
                            <asp:TextBox ID="txtkaryarambhdinak" CssClass="form-control c" runat="server" PlaceHolder="Date" AutoPostBack="True" OnTextChanged="txtkaryarambhdinak_TextChanged" TabIndex="30"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" BehaviorID="CalendarExtender4" TargetControlID="txtkaryarambhdinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td colspan="3">Time Limit</td>
                        <td colspan="8">
                            <asp:TextBox ID="txtkamachimudat" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtkamachimudat_TextChanged" PlaceHolder="Term Work" TabIndex="31" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="5">Completion Date</td>
                        <td colspan="5">
                            <asp:TextBox ID="txtkampurndinak" runat="server" CssClass="form-control c" Enabled="False" PlaceHolder="Date" TabIndex="32"></asp:TextBox>
                        </td>
                    </tr>

                    <tr style="background-color: #dbd7d7">
                        <td style="font-size: 18px" colspan="29">Physical Target /Achivement</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtPhyTargetPass" AutoPostBack="true" OnTextChanged="txtPhyTargetPass_TextChanged" TextMode="Password" CssClass="form-control c" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3">Job No</td>
                        <td colspan="8">
                            <asp:TextBox ID="txtjobno" runat="server" CssClass="form-control c" TabIndex="59"></asp:TextBox></td>
                        <td colspan="2">Date Of Sanction</td>
                        <td colspan="12">
                            <asp:TextBox ID="txtsanctiondate" runat="server" CssClass="form-control c" TabIndex="60"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="sancitondate" runat="server" BehaviorID="txtsanctiondate" TargetControlID="txtsanctiondate"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td colspan="3">Amount Original/ Revised Road</span></td>
                        <td colspan="4">
                            <asp:TextBox ID="txtsanctionAmt" runat="server" CssClass="form-control c" TabIndex="61" onkeyup="checkDec(this);">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3">Road No</td>
                        <td colspan="8">
                            <asp:TextBox ID="txtRoadNo" runat="server" CssClass="form-control c" TabIndex="62"></asp:TextBox></td>
                        <td colspan="14">Road Length (Kms) Bridge(Nos.)</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtRoadLength" runat="server" CssClass="form-control c" TabIndex="63"></asp:TextBox></td>
                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td colspan="7">&nbsp;</td>
                        <td colspan="7">Physical Scope of Work</td>
                        <td colspan="11">Cumulative achievement
                    <br />
                            as on 31 March
                    <asp:Label ID="lblcumulative" runat="server"></asp:Label>
                        </td>
                        <td colspan="4">Target
                    <asp:Label ID="lbltarget" runat="server"></asp:Label>
                        </td>
                        <td colspan="3">Achievement
                    <asp:Label ID="lblachievement" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" style="background-color: #dbd7d7">A) WBM Wide. (kms.) </td>
                        <td colspan="7">
                            <asp:TextBox ID="txtAPhysical" runat="server" CssClass="form-control c" TabIndex="64" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="11">
                            <asp:TextBox ID="txtACumulative" runat="server" CssClass="form-control c" TabIndex="65" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtATarget" runat="server" CssClass="form-control c" TabIndex="66" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtAAchievement" runat="server" CssClass="form-control c" TabIndex="67" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" style="background-color: #dbd7d7">B) B.T. (kms) </td>
                        <td colspan="7">
                            <asp:TextBox ID="txtBPhysical" runat="server" CssClass="form-control c" TabIndex="68" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="11">
                            <asp:TextBox ID="txtBCumulative" runat="server" CssClass="form-control c" TabIndex="69" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtBTarget" runat="server" CssClass="form-control c" TabIndex="70" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtBAchievement" runat="server" CssClass="form-control c" TabIndex="71" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" style="background-color: #dbd7d7">C)C.D. Works (Nos.)</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtCPhysical" runat="server" CssClass="form-control c" TabIndex="72" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="11">
                            <asp:TextBox ID="txtCCumulative" runat="server" CssClass="form-control c" TabIndex="73" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtCTarget" runat="server" CssClass="form-control c" TabIndex="74" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtCAchievement" runat="server" CssClass="form-control c" TabIndex="75" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" style="background-color: #dbd7d7">&nbsp;D) Minor Bridges(Nos) </td>
                        <td colspan="7">
                            <asp:TextBox ID="txtDPhysical" runat="server" CssClass="form-control c" TabIndex="76" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="11">
                            <asp:TextBox ID="txtDCumulative" runat="server" CssClass="form-control c" TabIndex="77" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtDTarget" runat="server" CssClass="form-control c" TabIndex="78" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDAchievement" runat="server" CssClass="form-control c" TabIndex="79" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" style="background-color: #dbd7d7">E) Major bridges (Nos.) </td>
                        <td colspan="7">
                            <asp:TextBox ID="txtEMajor" runat="server" CssClass="form-control c" TabIndex="80" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="11">
                            <asp:TextBox ID="txtECumulative" runat="server" CssClass="form-control c" TabIndex="81" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtETarget" runat="server" CssClass="form-control c" TabIndex="82" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtEAchievement" runat="server" CssClass="form-control c" TabIndex="83" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color: #dbd7d7">

                        <td colspan="12" style="font-size: 18px">Accounting Auditor Information </td>
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="17">
                            <asp:DropDownList ID="AuditDate" runat="server" CssClass="form-control " Style="font-size: 16px;" AutoPostBack="True" OnSelectedIndexChanged="AuditDate_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label ID="lblbillno" runat="server" Text="0" Visible="False"></asp:Label>
                        </td>
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="3">
                            <asp:TextBox ID="txtsecurity" runat="server" PlaceHolder="Security Code" CssClass="form-control c" AutoPostBack="True" TextMode="Password" OnTextChanged="txtsecurity_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">The date of the work term growth </td>
                        <td colspan="5">
                            <asp:TextBox ID="txtmudatvadhdinak" runat="server" CssClass="form-control c" PlaceHolder="Date" TabIndex="33"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" BehaviorID="CalendarExtender6" TargetControlID="txtmudatvadhdinak" Format="dd/MM/yyyy" />
                        </td>
                        <td colspan="3">Bill Status</td>
                        <td colspan="5">
                            <asp:DropDownList ID="Billpayment" runat="server" CssClass="form-control c" PlaceHolder="Bill Status" AutoPostBack="True" OnSelectedIndexChanged="Billpayment_SelectedIndexChanged"></asp:DropDownList>

                        </td>
                        <td colspan="2">Estimated Cost Approved </td>
                        <td colspan="5">
                            <asp:TextBox ID="txtcost" runat="server" CssClass="form-control c" onkeyup="checkDec(this);" AutoPostBack="True" OnTextChanged="txtcost_TextChanged" required="">0</asp:TextBox>
                        </td>
                        <td colspan="3">Cumulative Expendr. up to 31 March
                    <asp:Label ID="lekhamarchkharch" runat="server"></asp:Label>
                            &nbsp;</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtmarchakherkharch" runat="server" AutoPostBack="True" CssClass="form-control c" PlaceHolder="Expendr. 31 March" required="" TabIndex="35" onkeyup="checkDec(this);" OnTextChanged="txtmarchakherkharch_TextChanged">0</asp:TextBox>
                        </td>
                         <td >Remaining Cost</td>
                        <td>
                            <asp:TextBox ID="txturvaritamt" CssClass="form-control c" runat="server" Enabled="False" onkeyup="checkDec(this);">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="10" rowspan="2">
                            <table class="table table-bordered">
                                <tr>
                                    <td colspan="10">Budget Provision&nbsp;
                                <asp:Label ID="lekhayeartartud" runat="server"></asp:Label>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:DropDownList ID="ddlakun1" runat="server" AutoPostBack="True" PlaceHolder="Select" CssClass="form-control c" TabIndex="36">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtakun1" runat="server" AutoPostBack="True" CssClass="form-control c" PlaceHolder="Month Provision" required="" TabIndex="37" onkeyup="checkDec(this);" OnTextChanged="txtakun1_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:DropDownList ID="ddlakun2" runat="server" PlaceHolder="Select" AutoPostBack="True" CssClass="form-control c" TabIndex="38">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtakun2" runat="server" AutoPostBack="True" CssClass="form-control c" required="" TabIndex="39" onkeyup="checkDec(this);" OnTextChanged="txtakun2_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:DropDownList ID="ddlakun3" runat="server" PlaceHolder="Select" AutoPostBack="True" CssClass="form-control c" TabIndex="40">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtakun3" runat="server" AutoPostBack="True" CssClass="form-control c" required="" TabIndex="41" onkeyup="checkDec(this);" OnTextChanged="txtakun3_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:DropDownList ID="ddlakun4" runat="server" PlaceHolder="Select" CssClass="form-control c" TabIndex="42">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtakun4" runat="server" AutoPostBack="True" CssClass="form-control c" required="" TabIndex="43" onkeyup="checkDec(this);" OnTextChanged="txtakun4_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">Total Provision&nbsp;
                                        <asp:Label ID="lekhayearanudan" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttartud" runat="server" colspan="5" CssClass="form-control c" Enabled="False" PlaceHolder="Provision" required="" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="22">
                            <table align="center" class="table table-bordered">
                                <tr>
                                    <td colspan="2" rowspan="2" align="center">Grant Release&nbsp;<asp:Label ID="lekhamarchanudan" runat="server"></asp:Label> &nbsp;</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtfirst" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtfirst_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtsecond" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtsecond_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtthird" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtthird_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                            <td colspan="2">Bill No:<asp:DropDownList ID="ddlbillone" runat="server" CssClass="form-control c">
                                                    </asp:DropDownList>
                                    </td>
                            <td colspan="2">Bill No:<asp:DropDownList ID="ddlbilltwo" runat="server" CssClass="form-control c">
                                                    </asp:DropDownList>
                                    </td>
                            <td colspan="2">Bill No:<asp:DropDownList ID="ddlbillthree" runat="server" CssClass="form-control c">
                                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>JAN</td>
                                    <td>
                                        <asp:TextBox ID="txtjan" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="44" onkeyup="checkDec(this);" OnTextChanged="txtjan_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td>FEB</td>
                                    <td>
                                        <asp:TextBox ID="txtfeb" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="45" onkeyup="checkDec(this);" OnTextChanged="txtfeb_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td>MAR</td>
                                    <td>
                                        <asp:TextBox ID="txtmar" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="46" onkeyup="checkDec(this);" OnTextChanged="txtmar_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td>APR</td>
                                    <td>
                                        <asp:TextBox ID="txtapr" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="47" onkeyup="checkDec(this);" OnTextChanged="txtapr_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>MAY</td>
                                    <td>
                                        <asp:TextBox ID="txtmay" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="48" onkeyup="checkDec(this);" OnTextChanged="txtmay_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td>JUN</td>
                                    <td>
                                        <asp:TextBox ID="txtjun" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="49" onkeyup="checkDec(this);" OnTextChanged="txtjun_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td>JUL</td>
                                    <td>
                                        <asp:TextBox ID="txtjul" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="50" onkeyup="checkDec(this);" OnTextChanged="txtjul_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td>AUG</td>
                                    <td>
                                        <asp:TextBox ID="txtaug" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="51" onkeyup="checkDec(this);" OnTextChanged="txtaug_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>SEP</td>
                                    <td>
                                        <asp:TextBox ID="txtsep" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="52" onkeyup="checkDec(this);" OnTextChanged="txtsep_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td>OCT</td>
                                    <td>
                                        <asp:TextBox ID="txtoct" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="53" onkeyup="checkDec(this);" OnTextChanged="txtoct_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td>NOV</td>
                                    <td>
                                        <asp:TextBox ID="txtnov" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="54" onkeyup="checkDec(this);" OnTextChanged="txtnov_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td>DEC</td>
                                    <td>
                                        <asp:TextBox ID="txtdec" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="55" onkeyup="checkDec(this);" OnTextChanged="txtdec_TextChanged">0</asp:TextBox>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">&nbsp;Total Grants are distributed in
                                <asp:Label ID="totalvitritanudan" runat="server"></asp:Label>
                                        &nbsp;</td>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtaikunanudan" runat="server" CssClass="form-control c" Enabled="False" PlaceHolder="Total Grants" TabIndex="42" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="10">Expendr Upto month<asp:DropDownList ID="ddlmagilmonth" runat="server" CssClass="form-control c">
                        </asp:DropDownList>
                            <asp:Label ID="lekhayearmagil" runat="server"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtmagilkharch" runat="server" AutoPostBack="True" CssClass="form-control c" PlaceHolder="Expendr. Upto" required="" TabIndex="57" onkeyup="checkDec(this);" OnTextChanged="txtmagilkharch_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="5">Expendr during month
                            <asp:DropDownList ID="ddlchalukharch" runat="server" CssClass="form-control c">
                            </asp:DropDownList>
                            <asp:Label ID="lekhayearchalu" runat="server"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtchalukharch" runat="server" AutoPostBack="True" CssClass="form-control c" PlaceHolder="Expendr. During" required="" TabIndex="56" onkeyup="checkDec(this);" OnTextChanged="txtchalukharch_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Demand</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtmagni" Font-Names="English" runat="server" CssClass="form-control c" PlaceHolder="मागणी" required="" TabIndex="58" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="10">Other Expendr</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtOtherExp" runat="server" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtOtherExp_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox></td>
                        <td colspan="5">Total Expenditure in year&nbsp;<asp:Label ID="lableyearaikunkharch" runat="server"></asp:Label>
                            &nbsp;</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtvarshbharatilkharch" runat="server" AutoPostBack="True" CssClass="form-control c" Enabled="False" PlaceHolder="Total Expendr." onkeyup="checkDec(this);" OnTextChanged="txtvarshbharatilkharch_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Electricity Cost</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtElectCost" runat="server" CssClass="form-control c" AutoPostBack="True" onkeyup="checkDec(this);">0</asp:TextBox></td>
                        <td colspan="10">Electricity Expendr</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtElectExpen" runat="server" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtElectExpen_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox></td>
                        <td colspan="5">The Total Cost of Work</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtaikunkharch" runat="server" AutoPostBack="True" CssClass="form-control c" Enabled="False" PlaceHolder="कामावरील ऐकून खर्च" Style="font-weight: bold; color: #000000" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>

                    <tr>


                        <td colspan="3">Work Status </td>
                        <td colspan="7">
                            <asp:DropDownList ID="ddlsadyasthiti" runat="server" PlaceHolder="Select" TabIndex="64" CssClass="form-control c">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Current</asp:ListItem>
                                <asp:ListItem>Incomplete</asp:ListItem>
                                <asp:ListItem>Complete</asp:ListItem>
                                <asp:ListItem>Not Started</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="10">Work Completed Date</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtpahnikramank" runat="server" CssClass="form-control c" TabIndex="65" PlaceHolder="Date"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" BehaviorID="CalendarExtender1" TargetControlID="txtpahnikramank" Format="dd/MM/yyyy" />
                        </td>
                        <td colspan="5">Reasons for delay </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtpahnimudye" runat="server" CssClass="form-control" Style="font-size: 16px; font-weight: bold" Width="100%" PlaceHolder="Deal With Issues" TabIndex="66" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Remarks</td>
                        <td colspan="29">
                            <asp:TextBox ID="txtshera" runat="server" CssClass="form-control" Style="font-size: 16px; font-weight: bold" Width="100%" PlaceHolder="Remark" TabIndex="67" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
       </ContentTemplate>
         </asp:UpdatePanel>
    <br />
    <div>
        <asp:Button ID="BtnSav" runat="server" Text="SUBMIT" TabIndex="51" Height="10%" OnClick="BtnSav_Click" CssClass="recordsave btnform" />
        <asp:Button ID="BtnCancel" runat="server"  Text="CANCEL" TabIndex="52" Height="10%" CssClass="btnform" />
        <asp:Button ID="btnPrint" runat="server"  Text="PRINT" OnClientClick="printTbl()" CssClass="btnform" TabIndex="53" Height="10%" />
        <asp:Button id="btnBack" runat="server" text="BACK" CssClass="btnform"   OnClientClick="JavaScript:window.history.back(1); return false;" TabIndex="54" Height="10%"/>
    </div>
    <br />

    <script lang="javascript" type="text/javascript">


        function printTbl() {
            var TableToPrint = document.getElementById('Print');
            newWin = window.open("");
            newWin.document.write(TableToPrint.outerHTML);
            newWin.print();
            newWin.close();
        }
    </script>
      <script type="text/javascript">
          function Navigate() {
              location.href = "SuperAdminPanel.aspx";
          }

    </script>
    <br />


    <br />
    <br />
</asp:Content>
