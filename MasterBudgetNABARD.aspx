<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" Inherits="PWdEEBudget.MasterCRF1" CodeBehind="MasterBudgetNABARD.aspx.cs" %>

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
                <table id="Print" class="table table-bordered" style="border: 2px solid gray">

                    <tr style="text-align: center; background:linear-gradient(gray,white);">
                        <td colspan="32" style="color:black">
                            <asp:Label ID="Label10" runat="server" Text="Master Budget NABARD" Height="70px" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
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
                            <asp:RequiredFieldValidator ID="RFVtxtWorkID" runat="server" ControlToValidate="txtWorkID" ErrorMessage="Please select WorkId" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> 
                        </td>
                        <td colspan="3">Budget Year</td>
                        <td colspan="11">
                            <asp:TextBox ID="txtarthsankalpiyyear" runat="server" AutoPostBack="True" CssClass="form-control c" MaxLength="4" OnTextChanged="txtarthsankalpiyyear_TextChanged" PlaceHolder="Year" required="" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVtxtarthsankalpiyyear" runat="server" ControlToValidate="txtarthsankalpiyyear" ErrorMessage="Please select Budget year" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="1">SR.No</td>
                        <td colspan="2">
                            <asp:Label ID="lblId" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">Name of Scheme</td>
                        <td colspan="2" style="text-align: center;">
                            <asp:Label ID="ddlType" runat="server" class="blink_me" ForeColor="Red" Text="Budget NABARD"></asp:Label>
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
                             <%--<asp:RequiredFieldValidator ID="RFVddltaluka" ControlToValidate="ddltaluka" runat="server" ErrorMessage="Please Select Taluka" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> --%>
                        </td>
                        <td colspan="2">Budget SR.No </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtarthsankalpiybab" runat="server" CssClass="form-control c" PlaceHolder="SR.No" TabIndex="17" onkeyup="checkDec(this);"></asp:TextBox></td>
                        <td colspan="2">Sub-Division </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlupvibhag" runat="server" AutoPostBack="True" PlaceHolder="Select" CssClass="form-control c" TabIndex="5">
                               
                            </asp:DropDownList>
                           <%-- <asp:RequiredFieldValidator ID="RFVddlupvibhag" ControlToValidate="ddlupvibhag" runat="server" ErrorMessage="Please select Sub-Division" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
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
                             <%--<asp:RequiredFieldValidator ID="RFVddlsubtype" ControlToValidate="ddlsubtype" runat="server" ErrorMessage="Please select Sub-Division" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
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
                        <td colspan="29">Work Completed In km . No</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtWorkCompletedPass" AutoPostBack="true" OnTextChanged="txtWorkCompletedPass_TextChanged" TextMode="Password" CssClass="form-control c" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3">RIDF No</td>
                        <td colspan="7">
                            <%--<asp:TextBox ID="txtRDFNo" CssClass="form-control c" PlaceHolder="RIDF_NO" runat="server"></asp:TextBox></td>--%>
                            <asp:DropDownList ID="ddlRIDFNo" runat="server" AutoPostBack="True" PlaceHolder="Select" CssClass="form-control c selectableddl">     
                                <asp:ListItem>Select</asp:ListItem>                   
                                <asp:ListItem Text="XV" Value="15"></asp:ListItem>
                                <asp:ListItem Text="XVI" Value="16"></asp:ListItem>
                                <asp:ListItem Text="XVII" Value="17"></asp:ListItem>
                                <asp:ListItem Text="XVIII" Value="18"></asp:ListItem>
                                <asp:ListItem Text="XIX" Value="19"></asp:ListItem>
                                <asp:ListItem Text="XX" Value="20"></asp:ListItem>
                                <asp:ListItem Text="XXI" Value="21"></asp:ListItem>
                                <asp:ListItem Text="XXII" Value="22"></asp:ListItem>
                                <asp:ListItem Text="XXIII" Value="23"></asp:ListItem>
                                <asp:ListItem Text="XXIV" Value="24"></asp:ListItem>
                                <asp:ListItem Text="XXV" Value="25"></asp:ListItem>
                                <asp:ListItem Text="XXVI" Value="26"></asp:ListItem>
                                <asp:ListItem Text="XXVII" Value="27"></asp:ListItem>
                                <asp:ListItem Text="XXVIII" Value="28"></asp:ListItem>
                                <asp:ListItem Text="XXIX" Value="29"></asp:ListItem>
                                <asp:ListItem Text="XXX" Value="30"></asp:ListItem>
                                <asp:ListItem Text="XXXI" Value="31"></asp:ListItem>
                                <asp:ListItem Text="XXXII" Value="32"></asp:ListItem>
                                <asp:ListItem Text="XXXIII" Value="33"></asp:ListItem>
                                <asp:ListItem Text="XXXIV" Value="34"></asp:ListItem>
                                <asp:ListItem Text="XXXV" Value="35"></asp:ListItem>
                                <asp:ListItem Text="XXXVI" Value="36"></asp:ListItem>
                                <asp:ListItem Text="XXXVII" Value="37"></asp:ListItem>
                                <asp:ListItem Text="XXXVIII" Value="38"></asp:ListItem>
                                <asp:ListItem Text="XXXIX" Value="39"></asp:ListItem>
                                <asp:ListItem Text="XL" Value="40"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlRIDFNo" runat="server" ErrorMessage="Please select RIDF NO" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                        <td colspan="4">PIC No</td>
                        <td colspan="9">
                            <asp:TextBox ID="txtpicno" CssClass="form-control c" PlaceHolder="PIC_NO" runat="server"></asp:TextBox></td>
                        <td colspan="3">PCR </td>
                        <td colspan="6">
                            <asp:DropDownList ID="txtpcr" runat="server" PlaceHolder="select" CssClass="form-control c">
                                <asp:ListItem> </asp:ListItem>
                                <asp:ListItem>Submitted</asp:ListItem>
                                <asp:ListItem>Pending</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="3">Road No </td>
                        <td colspan="7">
                            <asp:TextBox ID="txtroadno" PlaceHolder="Road_No" CssClass="form-control c" runat="server"></asp:TextBox></td>
                        <td colspan="4">Length of Road km</td>
                        <td colspan="12">
                            <asp:TextBox ID="txtlengthroad" PlaceHolder="LengthRoad" runat="server" CssClass="form-control c" TabIndex="51">0</asp:TextBox></td>
                        <td colspan="6">
                            <asp:DropDownList ID="Roadtype" runat="server" CssClass="form-control c">
                                <asp:ListItem> </asp:ListItem>
                                <asp:ListItem>Road</asp:ListItem>
                                <asp:ListItem>Bridge</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">W.B.M I km</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtwbmikm" runat="server" PlaceHolder="WBM I" CssClass="form-control c" TabIndex="56" TextMode="Number">0</asp:TextBox></td>
                        <td colspan="2">W.B.M II km</td>
                        <td colspan="9">
                            <asp:TextBox ID="txtwbmiikm" runat="server" PlaceHolder="WBM II" CssClass="form-control c" TabIndex="57" TextMode="Number">0</asp:TextBox></td>
                        <td colspan="2">W.B.M III km</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtwbmiiikm" runat="server" PlaceHolder="WBM III" CssClass="form-control c" TabIndex="58" TextMode="Number">0</asp:TextBox></td>
                        <td colspan="3">Surface Dressing Km</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtsurfacekm" runat="server" PlaceHolder="Surface" CssClass="form-control c" TabIndex="59" TextMode="Number">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3">B.B.M Km</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtbbmkm" runat="server" PlaceHolder="BBM" CssClass="form-control c" TabIndex="60" TextMode="Number">0</asp:TextBox></td>
                        <td colspan="4">Carpet Km</td>
                        <td colspan="9">
                            <asp:TextBox ID="txtcarpetkm" runat="server" PlaceHolder="Carpet" CssClass="form-control c" TabIndex="61" TextMode="Number">0</asp:TextBox></td>
                        <td colspan="3">C.D Works No.</td>
                        <td colspan="6">
                            <asp:TextBox ID="txtcdworksno" runat="server" PlaceHolder="CD Works" CssClass="form-control c" TabIndex="61">0</asp:TextBox></td>
                    </tr>

                    <tr style="background-color: #dbd7d7">


                        <td colspan="12" style="font-size: 18px">Accounting Auditor Information </td>
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="17">
                            <asp:DropDownList ID="AuditDate" runat="server" CssClass="form-control " Style="font-size: 16px;" AutoPostBack="True" OnSelectedIndexChanged="AuditDate_SelectedIndexChanged"></asp:DropDownList>
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
                        <td colspan="4">
                            <asp:TextBox ID="Billpayment" runat="server" CssClass="form-control c" PlaceHolder="Bill Status" TabIndex="33"></asp:TextBox>
                        </td>
                        <td colspan="2">Estimated Cost Approved </td>
                        <td colspan="5">
                            <asp:TextBox ID="txtcost" runat="server" CssClass="form-control c" onkeyup="checkDec(this);" AutoPostBack="True" required="" OnTextChanged="txtcost_TextChanged">0</asp:TextBox>
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
                                    <td colspan="8">Grant Release&nbsp;<asp:Label ID="lekhamarchanudan" runat="server"></asp:Label>
                                        &nbsp;</td>
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
                        <td colspan="4">Expendr Upto month<asp:DropDownList ID="ddlmagilmonth" runat="server" CssClass="form-control c">
                        </asp:DropDownList>
                            <asp:Label ID="lekhayearmagil" runat="server"></asp:Label>
                        </td>
                        <td colspan="9">
                            <asp:TextBox ID="txtmagilkharch" runat="server" AutoPostBack="True" CssClass="form-control c" PlaceHolder="Expendr. Upto" required="" TabIndex="57" onkeyup="checkDec(this);" OnTextChanged="txtmagilkharch_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="3">Expendr during month
                            <asp:DropDownList ID="ddlchalukharch" runat="server" CssClass="form-control c">
                            </asp:DropDownList>
                            <asp:Label ID="lekhayearchalu" runat="server"></asp:Label>
                        </td>
                        <td colspan="6">
                            <asp:TextBox ID="txtchalukharch" runat="server" AutoPostBack="True" CssClass="form-control c" PlaceHolder="Expendr. During" required="" TabIndex="56" onkeyup="checkDec(this);" OnTextChanged="txtchalukharch_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Demand</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtmagni" runat="server" CssClass="form-control c" PlaceHolder="मागणी" required="" TabIndex="58" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="4">Total Expenditure in year&nbsp;<asp:Label ID="lableyearaikunkharch" runat="server"></asp:Label>
                            &nbsp;</td>
                        <td colspan="9">
                            <asp:TextBox ID="txtvarshbharatilkharch" runat="server" AutoPostBack="True" CssClass="form-control c" Enabled="False" PlaceHolder="Total Expendr." onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="3">The Total Cost of Work</td>
                        <td colspan="6">
                            <asp:TextBox ID="txtaikunkharch" runat="server" AutoPostBack="True" CssClass="form-control c" Enabled="False" PlaceHolder="कामावरील ऐकून खर्च" Style="font-weight: bold; color: #000000" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>

                    <tr>


                        <td colspan="3">Work Status </td>
                        <td colspan="7">
                            <asp:DropDownList ID="ddlsadyasthiti" runat="server" PlaceHolder="Select" TabIndex="64" CssClass="form-control c">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Inprogress</asp:ListItem>
                                <asp:ListItem>Incomplete</asp:ListItem>
                                <asp:ListItem>Completed</asp:ListItem>
                                <asp:ListItem>Not Started</asp:ListItem>
                                <asp:ListItem>Tender Stage</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="4">Work Completed Date</td>
                        <td colspan="9">
                            <asp:TextBox ID="txtpahnikramank" runat="server" CssClass="form-control c" TabIndex="65" PlaceHolder="Date"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" BehaviorID="CalendarExtender1" TargetControlID="txtpahnikramank" Format="dd/MM/yyyy" />
                        </td>
                        <td colspan="3">Reasons for delay </td>
                        <td colspan="6">
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
      
    <br />
</ContentTemplate>
         </asp:UpdatePanel>
    <div>
        <asp:Button ID="BtnSav" runat="server" CssClass="btn btn-success btnform" Text="SUBMIT" TabIndex="51" Height="10%" OnClick="BtnSav_Click" />
        <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-danger btnform" Text="CANCEL" TabIndex="52" Height="10%" OnClientClick="Navigate()" />
        <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary btnform" Text="PRINT" OnClientClick="printTbl()" TabIndex="53" Height="10%" />
        <asp:Button id="btnBack" runat="server" text="BACK" class="btn btn-info btnform"  OnClientClick="JavaScript:window.history.back(1); return false;" TabIndex="54" Height="10%"/>
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
