<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="MasterBudgetGat_A.aspx.cs" Inherits="PWdEEBudget.MasterBudgetGat_A" %>

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
                <table id="Print" class="table table-bordered mar" style="border: 2px solid gray">

                    <tr style="text-align: center; background:linear-gradient(gray,white);">
                        <td style="font-weight: bold; color:black" colspan="30">
                            <asp:Label ID="Label10" runat="server" Text="सार्वजनिक बांधकाम (पूर्व) विभाग, पुणे गट अ जॉब नोंदवही / (AMC)" Height="70px" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">Work_ID</td>
                        <td style="font-weight: bold; color: #000000" colspan="5">
                            <asp:TextBox ID="txtWorkID" CssClass="form-control c" runat="server" required="" PlaceHolder="नंबर" AutoPostBack="True" TabIndex="1" OnTextChanged="txtWorkID_TextChanged"></asp:TextBox>
                            
                            <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtWorkID"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight">  
                </ajaxToolkit:AutoCompleteExtender>
                             <asp:RequiredFieldValidator ID="RFVtxtWorkID" runat="server" ControlToValidate="txtWorkID" ErrorMessage="वर्क आयडी निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> 
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="2" class="auto-style2">अर्थसंकल्पीय वर्ष</td>
                        <td style="font-weight: bold; color: #000000" colspan="7" class="auto-style2">
                            <asp:TextBox ID="txtarthsankalpiyyear" runat="server" AutoPostBack="True" CssClass="form-control c" MaxLength="4" PlaceHolder="वर्ष" required="" TabIndex="2" OnTextChanged="txtarthsankalpiyyear_TextChanged"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RFVtxtarthsankalpiyyear" runat="server" ControlToValidate="txtarthsankalpiyyear" ErrorMessage="अर्थसंकल्पीय वर्ष निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> 
                        </td>
                        <td colspan="4" style="font-weight: bold; color: #000000">अ.क्र:</td>
                        <td style="font-weight: bold; color: #000000" colspan="1">
                            <asp:Label ID="lblId" runat="server"></asp:Label>
                        </td>
                        <td colspan="2" style="font-weight: bold; color: #000000">योजनेचे नाव</td>
                        <td colspan="6" style="font-weight: bold; text-align: center; color: #000000">
                            <asp:Label ID="ddlType" runat="server" class="blink_me" ForeColor="Red" Text="Budget GAT A"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">जिल्हा </td>
                        <td colspan="5">
                            <asp:DropDownList ID="ddldist" runat="server" CssClass="form-control c" AutoPostBack="True" TabIndex="4">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVddldist" ControlToValidate="ddldist" runat="server" ErrorMessage="जिल्हा निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> 
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="2">तालुका</td>
                        <td colspan="7" style="font-weight: bold; color: #000000">
                            <asp:DropDownList ID="ddltaluka" runat="server" CssClass="form-control c" AutoPostBack="True" TabIndex="5">
                              
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RFVddltaluka" ControlToValidate="ddltaluka" runat="server" ErrorMessage="तालुका निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="2">अर्थसंकल्प बाब क्र./पृष्ठ क्र </td>
                        <td style="font-weight: bold; color: #000000" colspan="6">
                            <asp:TextBox ID="txtarthsankalpiybab" runat="server" CssClass="form-control c" PlaceHolder="पृष्ठ क्र." TabIndex="18">0</asp:TextBox></td>
                        <td style="font-weight: bold; color: #000000" colspan="1">उपविभाग
                        </td>
                        <td colspan="4" style="font-weight: bold; color: #000000">
                            <asp:DropDownList ID="ddlupvibhag" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="6">
                               
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RFVddlupvibhag" ControlToValidate="ddlupvibhag" runat="server" ErrorMessage="उपविभाग निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">&nbsp;<strong>लेखाशीर्ष</strong></td>
                        <td style="font-weight: bold; color: #000000" colspan="6">
                            <asp:DropDownList ID="ddllekhashirsh" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="15" OnSelectedIndexChanged="ddllekhashirsh_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="10" style="font-weight: bold; color: #000000">
                            <asp:Label ID="lblLekhaName" runat="server"></asp:Label>
                        </td>
                        <td colspan="6" style="font-weight: bold; color: #000000">उपभोक्ता विभाग</td>
                        <td style="font-weight: bold; color: #000000" colspan="5">
                            <asp:DropDownList ID="ddlsubtype" runat="server" CssClass="form-control c" Width="334px" AutoPostBack="True" TabIndex="16">
                               
                            </asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="RFVddlsubtype" ControlToValidate="ddlsubtype" runat="server" ErrorMessage="उपभोक्ता विभाग निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> --%>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">शाखा अभियंत्याचे नाव  
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="16">
                            <asp:DropDownList ID="ddlabhiyanta" runat="server" CssClass="form-control c selectableddl" Width="334px" AutoPostBack="True" TabIndex="7" OnSelectedIndexChanged="ddlabhiyanta_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="6">भ्रमणध्वनी क्रमांक</td>
                        <td style="font-weight: bold; color: #000000" colspan="5">
                            <asp:TextBox ID="txtabhiyantamobile" runat="server" CssClass="form-control c" PlaceHolder="भ्रमणध्वनी क्रमांक" TabIndex="8" MaxLength="10" TextMode="Phone"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">उपभियंत्याचे नाव </td>
                        <td style="font-weight: bold; color: #000000" colspan="16">
                            <asp:DropDownList ID="ddlupabhiyanta" runat="server" CssClass="form-control c selectableddl" Width="334px" AutoPostBack="True" TabIndex="9" OnSelectedIndexChanged="ddlupabhiyanta_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="6">भ्रमणध्वनी क्रमांक</td>
                        <td style="font-weight: bold; color: #000000" colspan="5">
                            <asp:TextBox ID="txtupabhiyantamobile" runat="server" CssClass="form-control c" PlaceHolder="भ्रमणध्वनी क्रमांक" TabIndex="10" MaxLength="10" TextMode="Phone"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">खासदारांचे नाव </td>
                        <td style="font-weight: bold; color: #000000" colspan="16">
                            <asp:DropDownList ID="ddlkhasdarachename" CssClass="form-control c selectableddl" runat="server" Width="334px" AutoPostBack="True" TabIndex="13">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="3">आमदारांचे नाव</td>
                        <td style="font-weight: bold; color: #000000" colspan="8">
                            <asp:DropDownList ID="ddlaamdarachename" runat="server" CssClass="form-control cselectableddl" Width="334px" AutoPostBack="True" TabIndex="14">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td colspan="27" style="font-weight: bold; color: #000000; font-size: 18px">प्रकल्प शाखा </td>
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="3">
                            <asp:TextBox ID="txtPrakalpPassword" AutoPostBack="true" OnTextChanged="txtPrakalpPassword_TextChanged" TextMode="Password" CssClass="form-control c" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">कामाचे नाव </td>
                        <td colspan="13">
                            <asp:TextBox ID="txtkamachenav" runat="server" CssClass="form-control" Style="font-size: 16px; font-weight: bold" Width="100%" PlaceHolder="कामाचे नाव" TabIndex="19" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td colspan="3" style="font-weight: bold; color: #000000">कामाचा वाव</td>
                        <td colspan="11">
                            <asp:TextBox ID="txtkamachavav" runat="server" CssClass="form-control" Style="font-size: 16px; font-weight: bold" Width="100%" PlaceHolder=" कामाचा वाव" TabIndex="26" TextMode="MultiLine">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">प्रशासकीय मान्यता क्रमांक </td>
                        <td style="font-weight: bold; color: #000000" colspan="9">
                            <asp:TextBox ID="txtprashaskiykramank" runat="server" CssClass="form-control c" PlaceHolder="मान्यता क्रमांक" TabIndex="20">0</asp:TextBox></td>
                        <td style="font-weight: bold; color: #000000; text-align: center" colspan="1">दिनांक </td>
                        <td style="font-weight: bold; color: #000000" colspan="9">
                            <asp:TextBox ID="txtprashaskiydinak" runat="server" CssClass="form-control c" PlaceHolder="दिनांक" TabIndex="21">0</asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" BehaviorID="CalendarExtender2" TargetControlID="txtprashaskiydinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="3">किंमत रु. लक्ष </td>
                        <td style="font-weight: bold; color: #000000" colspan="5">
                            <asp:TextBox ID="txtprashaskiykimat" runat="server" CssClass="form-control c" PlaceHolder="किंमत रु. लक्ष" TabIndex="22" >0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">तांत्रिक मान्यता क्रमांक </td>
                        <td style="font-weight: bold; color: #000000" colspan="9">
                            <asp:TextBox ID="txttantrikkramank" runat="server" CssClass="form-control c" PlaceHolder="मान्यता क्रमांक" TabIndex="23" >0</asp:TextBox></td>
                        <td style="font-weight: bold; color: #000000; text-align: center" colspan="1">दिनांक </td>
                        <td colspan="9">
                            <asp:TextBox ID="txttantarikdinak" runat="server" CssClass="form-control c" PlaceHolder="दिनांक" TabIndex="24">0</asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" BehaviorID="CalendarExtender3" TargetControlID="txttantarikdinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="3">किंमत रु. लक्ष </td>
                        <td colspan="5">
                            <asp:TextBox ID="txttantarikkimat" runat="server" CssClass="form-control c" PlaceHolder="किंमत रु. लक्ष" TabIndex="25">0</asp:TextBox>
                        </td>

                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="27">निविदा शाखा</td>
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="3">
                            <asp:TextBox ID="txtnividashakha" AutoPostBack="true" OnTextChanged="txtnividashakha_TextChanged" CssClass="form-control c" runat="server" TextMode="Password">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">ठेकेदाराचे नाव
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="16">
                            <asp:DropDownList ID="ddlThekedarName" CssClass="form-control c selectableddl" runat="server" AutoPostBack="True" Width="305px" TabIndex="27" OnSelectedIndexChanged="ddlThekedarName_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="6">ठेकेदाराचा भ्रमणध्वनी </td>
                        <td style="font-weight: bold; color: #000000" colspan="5">
                            <asp:Label ID="lblThekedarMobNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">करारनामा क्रमांक</td>
                        <td style="font-weight: bold; color: #000000" colspan="10">
                            <asp:TextBox ID="txtNividaKramank" runat="server" CssClass="form-control c" PlaceHolder="करारनामा क्रमांक" TabIndex="28">0</asp:TextBox>
                        </td>
                        <td colspan="3" style="font-weight: bold; color: #000000">करारनामा किंमत</td>
                        <td colspan="8" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtNividaKimat" runat="server" CssClass="form-control c" PlaceHolder="करारनामा किंमत" TabIndex="29">0</asp:TextBox>
                        </td>
                        <td colspan="3" style="font-weight: bold; color: #000000">कार्यारंभ आदेश</td>
                        <td colspan="3" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtkaryarambhaadesh" runat="server" CssClass="form-control c" PlaceHolder="कार्यारंभ आदेश" TabIndex="30">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">कार्यारंभ दिनांक </td>
                        <td style="font-weight: bold; color: #000000" colspan="10">
                            <asp:TextBox ID="txtkaryarambhdinak" CssClass="form-control c" runat="server" PlaceHolder="दिनांक" AutoPostBack="True" TabIndex="31" OnTextChanged="txtkaryarambhdinak_TextChanged"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" BehaviorID="CalendarExtender4" TargetControlID="txtkaryarambhdinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td colspan="3" style="font-weight: bold; color: #000000">कामाची मुदत </td>
                        <td colspan="8" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtkamachimudat" runat="server" AutoPostBack="True" CssClass="form-control c"  PlaceHolder="कामाची मुदत" TabIndex="32" onkeyup="checkDec(this);" OnTextChanged="txtkamachimudat_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="3" style="font-weight: bold; color: #000000">काम पूर्ण करण्याची दिनांक</td>
                        <td colspan="3" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtkampurndinak" runat="server" CssClass="form-control c" Enabled="False" PlaceHolder="काम पूर्ण करण्याची दिनांक"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="27">GAT_A</td>
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="3">
                            <asp:TextBox ID="txtGatASecPass" runat="server" CssClass="form-control c" AutoPostBack="True" TextMode="Password" OnTextChanged="txtGatASecPass_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">आदेश क्र.</td>
                        <td colspan="6" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtAadeshKramank" runat="server" CssClass="form-control c" TabIndex="33">0</asp:TextBox>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="3">उपशिर्ष</td>
                        <td colspan="6" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtUpshirsh" runat="server" CssClass="form-control c" TabIndex="33">0</asp:TextBox></td>
                        <td style="font-weight: bold; color: #000000" colspan="3">जॉब क्र.</td>
                        <td style="font-weight: bold; color: #000000" colspan="4">
                            <asp:TextBox ID="txtJobKramank" runat="server" CssClass="form-control c" PlaceHolder="जॉब क्र." TabIndex="33">0</asp:TextBox></td>
                        <td style="font-weight: bold; color: #000000" colspan="3">जॉब रक्कम रु.</td>
                        <td colspan="2" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtJobRakkam" runat="server" CssClass="form-control c" PlaceHolder="जॉब रक्कम रु." TabIndex="43" onkeyup="checkDec(this);" AutoPostBack="True">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">डांबरीचे परिमाण</td>
                        <td colspan="6" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtDambarichepariman" runat="server" CssClass="form-control c" TabIndex="33">0</asp:TextBox>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="3">डांबराची रक्कम</td>
                        <td colspan="6" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtDambarichiRakkm" runat="server" CssClass="form-control c" TabIndex="33">0</asp:TextBox></td>
                        <td style="font-weight: bold; color: #000000" colspan="3">दुरुस्तीचा प्रकार</td>
                        <td colspan="4" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtDurustichaPrakar" runat="server" CssClass="form-control c" PlaceHolder="दुरुस्तीचा प्रकार" TabIndex="43" AutoPostBack="True">0</asp:TextBox></td>
                        <td style="font-weight: bold; color: #000000" colspan="3">वापरडांबरीचे परिमाण</td>
                        <td colspan="2" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtVaprDambarichepariman" runat="server" CssClass="form-control c" PlaceHolder="जॉब रक्कम रु." TabIndex="43" onkeyup="checkDec(this);" AutoPostBack="True">0</asp:TextBox></td>
                    </tr>

                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="3">काम पूर्ण करण्याचा दिनांक</td>
                        <td style="font-weight: bold; color: #000000" colspan="6">
                            <asp:TextBox ID="txtKamPurnKaranyachaDinak" runat="server" CssClass="form-control c" PlaceHolder="दिनांक" TabIndex="33"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" BehaviorID="CalendarExtender6" TargetControlID="txtKamPurnKaranyachaDinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="3">काम पुर्ण झाल्याचा दिनांक </td>
                        <td style="font-weight: bold; color: #000000" colspan="6">
                            <asp:TextBox ID="txtKamPurnJhalyachaDinak" runat="server" CssClass="form-control c" PlaceHolder="दिनांक" TabIndex="33"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" BehaviorID="CalendarExtender5" TargetControlID="txtKamPurnJhalyachaDinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="3">विभागात देयक सादर केल्याचा दिनांक </td>
                        <td style="font-weight: bold; color: #000000" colspan="4">
                            <asp:TextBox ID="txtDeyakKelyachaDinak" runat="server" CssClass="form-control c" PlaceHolder="दिनांक" TabIndex="33"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" BehaviorID="CalendarExtender7" TargetControlID="txtDeyakKelyachaDinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="3">विभागात देयक पारित केल्याचा दिनांक </td>
                        <td style="font-weight: bold; color: #000000" colspan="2">
                            <asp:TextBox ID="txtDeyakParitDinak" runat="server" CssClass="form-control c" PlaceHolder="दिनांक" TabIndex="33"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" BehaviorID="CalendarExtender8" TargetControlID="txtDeyakParitDinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="12">लेखा शाखा </td>
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="15">
                            <asp:DropDownList ID="AuditDate" runat="server" CssClass="form-control " Style="font-size: 16px;" AutoPostBack="True" OnSelectedIndexChanged="AuditDate_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td style="font-weight: bold; color: #000000; font-size: 18px" colspan="3">
                            <asp:TextBox ID="txtsecurity" runat="server" CssClass="form-control c" AutoPostBack="True" TextMode="Password" OnTextChanged="txtsecurity_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000">कामाच्या मुदत वाढीचा दिनांक </td>
                        <td style="font-weight: bold; color: #000000" colspan="7">
                            <asp:TextBox ID="txtMudatVadhiDate" runat="server" CssClass="form-control c" PlaceHolder="मुदत वाढीचा दिनांक" TabIndex="33"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" BehaviorID="CalendarExtender9" TargetControlID="txtMudatVadhiDate" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        
                        <td style="font-weight: bold; color: #000000" >शिल्लक दायित्व रु. लक्ष</td>
                        <td colspan="4" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtShilakDayitv" runat="server" CssClass="form-control c" TabIndex="33">0</asp:TextBox>
                        </td>
                        <td colspan="2">मंजुर अंदाजित किंमत </td>
                        <td colspan="5">
                            <asp:TextBox ID="txtcost" runat="server" CssClass="form-control c" onkeyup="checkDec(this);" AutoPostBack="True" OnTextChanged="txtcost_TextChanged" required="">0</asp:TextBox>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="3">३१ मार्च
                       <asp:Label ID="lekhamarchkharch" runat="server"></asp:Label>
                            &nbsp;अखेरचा एकुण खर्च रु लक्ष</td>
                        <td colspan="4" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtmarchakherkharch" runat="server" CssClass="form-control c" PlaceHolder="मार्च अखेर खर्च" TabIndex="43" onkeyup="checkDec(this);" OnTextChanged="txtmarchakherkharch_TextChanged" AutoPostBack="True" >0</asp:TextBox>
                        </td>
                         <td colspan="2">उर्वरीत किमंत</td>
                        <td>
                            <asp:TextBox ID="txturvaritamt" CssClass="form-control c" runat="server" Enabled="False" onkeyup="checkDec(this);">0</asp:TextBox></td>

                    </tr>

                     <tr>
                         <td>सद्यस्थिती</td>
                        <td colspan="2">
                            <asp:TextBox ID="Billpayment" runat="server" CssClass="form-control c" TabIndex="33">0</asp:TextBox></td>
                       <td style="font-weight: bold; color: #000000" colspan="4">दायित्व आवश्यकता आहे /नाही</td>

                        <td style="font-weight: bold; color: #000000" colspan="16">
                            <asp:TextBox ID="txtDayitvAvshyak" runat="server" CssClass="form-control c" PlaceHolder="दायित्व आवश्यकता आहे /नाही"  TabIndex="49"></asp:TextBox>
                        </td>

                         <td colspan="3">दायित्व असल्यास रक्कम रु.</td>
             <td colspan="7"><asp:TextBox ID="txtDayitavAmt" runat="server" CssClass="form-control c"  PlaceHolder="दायित्व असल्यास रक्कम रु.">0.00</asp:TextBox></td>
                    </tr>

                    <tr>
                        <td colspan="10" style="font-weight: bold; color: #000000" rowspan="2">
                            <table class="table table-bordered">
                                <tr>
                                    <td colspan="2" style="font-weight: bold; color: #000000">वर्ष
                                   <asp:Label ID="lekhayeartartud" runat="server"></asp:Label>
                                        &nbsp;तरतूद</td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:DropDownList ID="ddlakun1" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="36">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtakun1" runat="server" PlaceHolder="मार्च अनुदान" TabIndex="37" CssClass="form-control c" onkeyup="checkDec(this);" AutoPostBack="True" OnTextChanged="txtakun1_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:DropDownList ID="ddlakun2" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="38">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtakun2" runat="server" TabIndex="39" onkeyup="checkDec(this);"  CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtakun2_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:DropDownList ID="ddlakun3" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="40">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtakun3" runat="server" TabIndex="41" onkeyup="checkDec(this);" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtakun3_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:DropDownList ID="ddlakun4" CssClass="form-control c" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtakun4" runat="server" onkeyup="checkDec(this);" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtakun4_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; color: #000000">वर्ष
                                   <asp:Label ID="lekhayearanudan" runat="server"></asp:Label>
                                        &nbsp;एकुण तरतूद</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txttartud" runat="server" CssClass="form-control c" PlaceHolder="तरतूद" TabIndex="35" onkeyup="checkDec(this);" Enabled="False">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="20" style="font-weight: bold; color: #000000">
                            <table class="table table-bordered" align="center">
                                <tr>
                                    <td style="font-weight: bold; color: #000000" colspan="8">
                                        <asp:Label ID="lekhamarchanudan" runat="server"></asp:Label>
                                        &nbsp; मधील वितरीत अनुदान</td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; color: #000000">जानेवारी</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtjan" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtjan_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">फेब्रुवारी</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtfeb" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtfeb_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">मार्च</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtmar" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtmar_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">एप्रिल</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtapr" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtapr_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; color: #000000">मे</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtmay" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtmay_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">जून</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtjun" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtjun_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">जुलै</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtjul" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtjul_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">ऑगस्ट</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtaug" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtaug_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; color: #000000">सेप्टेंबर</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtsep" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtsep_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">ऑक्टोबर</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtoct" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtoct_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">नोव्हेंबर</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtnov" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtnov_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; color: #000000">डिसेंबर</td>
                                    <td style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtdec" runat="server" onkeyup="checkDec(this);" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtdec_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="font-weight: bold; color: #000000">&nbsp;
                               <asp:Label ID="totalvitritanudan" runat="server"></asp:Label>
                                        &nbsp;मधील एकुण वितरीत अनुदान</td>
                                    <td colspan="4" style="font-weight: bold; color: #000000">
                                        <asp:TextBox ID="txtaikunanudan" runat="server" CssClass="form-control c" PlaceHolder="एकुण वितरीत अनुदान" TabIndex="42" onkeyup="checkDec(this);" Enabled="False">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="6" style="font-weight: bold; color: #000000">
                            <asp:Label ID="lekhayearmagil" runat="server"></asp:Label>
                            मधील मागील<asp:DropDownList ID="ddlmagilmonth" runat="server" CssClass="form-control c"></asp:DropDownList>
                            महिन्यापर्यंतचा खर्च</td>
                        <td colspan="7" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtmagilkharch" runat="server" AutoPostBack="True" CssClass="form-control c" PlaceHolder="वर्ष अखेर खर्च" TabIndex="44" onkeyup="checkDec(this);" OnTextChanged="txtmagilkharch_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="3" style="font-weight: bold; color: #000000">
                            <asp:Label ID="lekhayearchalu" runat="server"></asp:Label>
                            मधील चालू
                            <asp:DropDownList ID="ddlchalukharch" runat="server" CssClass="form-control c"></asp:DropDownList>
                            महिन्यातील खर्च</td>
                        <td colspan="4" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtchalukharch" runat="server" AutoPostBack="True" CssClass="form-control c" PlaceHolder="चालू महिन्यातील खर्च" onkeyup="checkDec(this);" OnTextChanged="txtchalukharch_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">विद्युतीकरण कामाची किंमत</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtVidyutprama" runat="server" CssClass="form-control c" onkeyup="checkDec(this);" AutoPostBack="True" OnTextChanged="txtVidyutprama_TextChanged">0</asp:TextBox></td>
                        <td colspan="6">विद्युतीकरणाचा खर्च</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtVidyutvitarit" runat="server" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtVidyutvitarit_TextChanged">0</asp:TextBox></td>
                        <td colspan="3">इतर खर्च</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtitarkhrch" runat="server" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtitarkhrch_TextChanged">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6" style="font-weight: bold; color: #000000">मागणी</td>
                        <td colspan="4" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtmagni" runat="server" CssClass="form-control c" PlaceHolder="मागणी" TabIndex="46"  onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="6" style="font-weight: bold; color: #000000">वर्ष
                    <asp:Label ID="lableyearaikunkharch" runat="server"></asp:Label>
                            &nbsp;मधील एकुण खर्च</td>
                        <td colspan="7" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtvarshbharatilkharch" runat="server" AutoPostBack="True" CssClass="form-control c" Enabled="False" PlaceHolder="वर्ष मधील ऐकून खर्च" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="3" style="font-weight: bold; color: #000000">कामावरील एकुण खर्च
                        </td>
                        <td colspan="4" style="font-weight: bold; color: #000000">
                            <asp:TextBox ID="txtaikunkharch" runat="server" AutoPostBack="True" CssClass="form-control c" Enabled="False" PlaceHolder="कामावरील ऐकून खर्च" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="5">कामाची सद्यस्थिती </td>
                        <td style="font-weight: bold; color: #000000" colspan="3">
                            <asp:DropDownList ID="ddlsadyasthiti" runat="server" TabIndex="47" CssClass="form-control c">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>चालू</asp:ListItem>
                                <asp:ListItem>अपूर्ण</asp:ListItem>
                                <asp:ListItem>पूर्ण</asp:ListItem>
                                <asp:ListItem>सुरू करणे</asp:ListItem>
                                <asp:ListItem>Not Started</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="font-weight: bold; color: #000000" colspan="5">पाहणी अहवाल क्रमांक</td>
                        <td style="font-weight: bold; color: #000000" colspan="7">
                            <asp:TextBox ID="txtpahnikramank" runat="server" CssClass="form-control c" TabIndex="48"></asp:TextBox></td>
                        
                        <td colspan="3">डांबरीचा खर्च</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtDambarichaExpens" runat="server" CssClass="form-control c">0</asp:TextBox></td>
                    </tr>
                    <tr>
                       <td style="font-weight: bold; color: #000000" colspan="4">पाहणी अहवाल मुद्ये</td>
                        <td style="font-weight: bold; color: #000000" colspan="16">
                            <asp:TextBox ID="txtpahnimudye" runat="server" CssClass="form-control" Style="font-size: 16px; font-weight: bold" Width="100%" PlaceHolder="पाहणी अहवाल मुद्ये" TextMode="MultiLine" TabIndex="49"></asp:TextBox>
                        </td>

                         <td colspan="3">दवगुनी ज्ञापने</td>
             <td colspan="7"><asp:TextBox ID="txtdnyapane" runat="server" CssClass="form-control c"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="7">शेरा</td>
                        <td style="font-weight: bold; color: #000000" colspan="23">
                            <asp:TextBox ID="txtshera" runat="server" CssClass="form-control" Style="font-size: 16px; font-weight: bold" Width="100%" PlaceHolder="शेरा" Height="40px" TextMode="MultiLine" TabIndex="50"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="font-weight: bold; color: #000000" colspan="30">&nbsp;</td>
                    </tr>
                </table>
            </div>
      <br />
   
</ContentTemplate>
        </asp:UpdatePanel>
    <div>
        <asp:Button ID="BtnSav" runat="server" CssClass="btnform" Text="संपादित करा" TabIndex="51" Height="10%" OnClick="BtnSav_Click" />
        <asp:Button ID="BtnCancel" runat="server" CssClass="btnform" Text="रद्द करा" TabIndex="52" Height="10%" OnClientClick="Navigate()" />
        <asp:Button ID="btnPrint" runat="server" CssClass="btnform" Text="प्रिंट" OnClientClick="printTbl()" TabIndex="53" Height="10%" />
        <asp:Button id="btnBack" runat="server" text="मागे जा" CssClass="btnform"  OnClientClick="JavaScript:window.history.back(1); return false;" TabIndex="54" Height="10%"/>
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
