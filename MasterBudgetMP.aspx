<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="MasterBudgetMP.aspx.cs" Inherits="PWdEEBudget.MasterBudgetMP" %>

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
                        <td colspan="23" style="color:black">
                            <asp:Label ID="Label10" runat="server" Text="Master Budget MP" Height="70px" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Work_ID</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtWorkID" CssClass="form-control c" runat="server" required="" PlaceHolder="नंबर" AutoPostBack="True" OnTextChanged="txtWorkID_TextChanged" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtWorkID"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight">  
                </ajaxToolkit:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RFVtxtWorkID" runat="server" ControlToValidate="txtWorkID" ErrorMessage="वर्क आयडी निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> 
                        </td>
                        <td colspan="2">अर्थसंकल्पीय वर्ष</td>
                        <td colspan="5">
                            <asp:TextBox ID="txtarthsankalpiyyear" runat="server" AutoPostBack="True" CssClass="form-control c" MaxLength="4" OnTextChanged="txtarthsankalpiyyear_TextChanged" PlaceHolder="वर्ष" required="" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVtxtarthsankalpiyyear" runat="server" ControlToValidate="txtarthsankalpiyyear" ErrorMessage="अर्थसंकल्पीय वर्ष निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="4">अ.क्र:</td>
                        <td colspan="1">
                            <asp:Label ID="lblId" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">योजनेचे नाव</td>
                        <td colspan="4" style="text-align: center;">
                            <asp:DropDownList ID="ddltyp" runat="server" CssClass="form-control c">
                                <asp:ListItem>पुणे / राज्य सभा सदस्य</asp:ListItem>
                                <asp:ListItem>पुणे / खासदारांचा स्थानिक विकास कार्यक्रम</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>जिल्हा </td>
                        <td colspan="4">
                            <asp:DropDownList ID="ddldist" runat="server" CssClass="form-control c" AutoPostBack="True" OnSelectedIndexChanged="ddldist_SelectedIndexChanged" TabIndex="4">
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RFVddldist" ControlToValidate="ddldist" runat="server" ErrorMessage="जिल्हा निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="2">तालुका</td>
                        <td colspan="7">
                            <asp:DropDownList ID="ddltaluka" runat="server" CssClass="form-control c" AutoPostBack="True" TabIndex="5">
                              
                            </asp:DropDownList>
                             <%--<asp:RequiredFieldValidator ID="RFVddltaluka" ControlToValidate="ddltaluka" runat="server" ErrorMessage="तालुका निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> --%>
                        </td>
                        <%--  <td style="font-weight: bold; color: #000000" colspan="2">अर्थसंकल्प बाब क्र./पृष्ठ क्र </td>
                   <td style="font-weight: bold; color: #000000" colspan="6"><asp:TextBox ID="txtarthsankalpiybab" runat="server" CssClass="form-control c" PlaceHolder="पृष्ठ क्र." TabIndex="18" required=""></asp:TextBox></td>--%>
                        <td colspan="6">उपविभाग
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlupvibhag" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="6">
                                
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RFVddlupvibhag" ControlToValidate="ddlupvibhag" runat="server" ErrorMessage="उपविभाग निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>प्रकार</td>
                        <td colspan="9">
                            <asp:DropDownList ID="prakar" runat="server" CssClass="form-control c">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>इमारती</asp:ListItem>
                                <asp:ListItem>रस्ते</asp:ListItem>
                            </asp:DropDownList></td>
                        <td colspan="2">बाब क्र॰</td>
                        <td colspan="8">
                            <asp:TextBox ID="txtarthsankalpiybab" CssClass="form-control c" runat="server"></asp:TextBox></td>
                        <td colspan="1">जुलै २०१६. बाब क्र॰ / पेज क्र॰</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtjulybab" CssClass="form-control c" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>&nbsp;<strong>लेखाशीर्ष</strong></td>
                        <td colspan="5">
                            <asp:DropDownList ID="ddllekhashirsh" runat="server" AutoPostBack="True" CssClass="form-control c" OnSelectedIndexChanged="ddllekhashirsh_SelectedIndexChanged" TabIndex="15">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="8">
                            <asp:Label ID="lblLekhaName" runat="server"></asp:Label>
                            <asp:Label ID="lblname" runat="server"></asp:Label>
                        </td>
                        <td colspan="6">उपभोक्ता विभाग</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlsubtype" runat="server" CssClass="form-control c" Width="334px" AutoPostBack="True" TabIndex="16">
                              
                            </asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="RFVddlsubtype" ControlToValidate="ddlsubtype" runat="server" ErrorMessage="उपभोक्ता विभाग निवडा" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>शाखा अभियंत्याचे नाव  
                        </td>
                        <td colspan="13">
                            <asp:DropDownList ID="ddlabhiyanta" runat="server" CssClass="form-control c selectableddl" Width="334px" OnSelectedIndexChanged="ddlabhiyanta_SelectedIndexChanged" AutoPostBack="True" TabIndex="7">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td colspan="6">भ्रमणध्वनी क्रमांक</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtabhiyantamobile" runat="server" CssClass="form-control c" PlaceHolder="भ्रमणध्वनी क्रमांक" TabIndex="8" MaxLength="10" TextMode="Phone"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>उपभियंत्याचे नाव </td>
                        <td colspan="13">
                            <asp:DropDownList ID="ddlupabhiyanta" runat="server" CssClass="form-control c selectableddl" Width="334px" OnSelectedIndexChanged="ddlupabhiyanta_SelectedIndexChanged" AutoPostBack="True" TabIndex="9">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td colspan="6">भ्रमणध्वनी क्रमांक</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtupabhiyantamobile" runat="server" CssClass="form-control c" PlaceHolder="भ्रमणध्वनी क्रमांक" TabIndex="10" MaxLength="10" TextMode="Phone"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>खासदार नाव </td>
                        <td colspan="13">
                            <asp:DropDownList ID="ddlkhasdarachename" CssClass="form-control c selectableddl" runat="server" Width="334px" OnSelectedIndexChanged="ddlsubtype2_SelectedIndexChanged" AutoPostBack="True" TabIndex="13">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td colspan="6">आमदार नाव</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlaamdarachename" runat="server" CssClass="form-control c selectableddl" Width="334px" AutoPostBack="True" TabIndex="14">
                                <asp:ListItem></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td colspan="22" style="font-size: 18px">प्रकल्प शाखा </td>
                        <td>
                            <asp:TextBox ID="txtPrakalpPassword" AutoPostBack="true" OnTextChanged="txtPrakalpPassword_TextChanged" CssClass="form-control c" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>कामाचे नाव </td>
                        <td colspan="10">
                            <asp:TextBox ID="txtkamachenav" runat="server" CssClass="form-control" style="font-size:16px;font-weight:bold" Width="100%" PlaceHolder="कामाचे नाव" TabIndex="19" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td colspan="3">कामाचा वाव</td>
                        <td colspan="9">
                            <asp:TextBox ID="txtkamachavav" runat="server" CssClass="form-control" style="font-size:16px;font-weight:bold" Width="100%" PlaceHolder=" कामाचा वाव" TabIndex="26" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>प्रशासकीय मान्यता क्रमांक </td>
                        <td colspan="7">
                            <asp:TextBox ID="txtprashaskiykramank" runat="server" CssClass="form-control c" PlaceHolder="मान्यता क्रमांक" TabIndex="20"></asp:TextBox></td>
                        <td colspan="1">दिनांक </td>
                        <td colspan="8">
                            <asp:TextBox ID="txtprashaskiydinak" runat="server" CssClass="form-control c" PlaceHolder="दिनांक" TabIndex="21"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" BehaviorID="CalendarExtender2" TargetControlID="txtprashaskiydinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td colspan="3">किंमत रु. लक्ष </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtprashaskiykimat" runat="server" CssClass="form-control c" PlaceHolder="किंमत रु. लक्ष" TabIndex="22" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>तांत्रिक मान्यता क्रमांक </td>
                        <td colspan="7">
                            <asp:TextBox ID="txttantrikkramank" runat="server" CssClass="form-control c" PlaceHolder="मान्यता क्रमांक" TabIndex="23" onkeyup="checkDec(this);"></asp:TextBox></td>
                        <td colspan="1">दिनांक </td>
                        <td colspan="8">
                            <asp:TextBox ID="txttantarikdinak" runat="server" CssClass="form-control c" PlaceHolder="दिनांक" TabIndex="24"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" BehaviorID="CalendarExtender3" TargetControlID="txttantarikdinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td colspan="3">किंमत रु. लक्ष </td>
                        <td colspan="3">
                            <asp:TextBox ID="txttantarikkimat" runat="server" CssClass="form-control c" PlaceHolder="किंमत रु. लक्ष" TabIndex="25" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>

                    </tr>
                    <tr style="background-color: #dbd7d7">
                        <td style="font-size: 18px" colspan="22">निविदा शाखा</td>
                        <td>
                            <asp:TextBox ID="txtnividashakha" AutoPostBack="true" OnTextChanged="txtnividashakha_TextChanged" CssClass="form-control c" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>ठेकेदाराचे नाव
                        </td>
                        <td colspan="13">
                            <asp:DropDownList ID="ddlThekedarName" CssClass="form-control c selectableddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlThekedarName_SelectedIndexChanged" Width="305px" TabIndex="27">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="6">ठेकेदाराचा भ्रमणध्वनी </td>
                        <td colspan="3">
                            <asp:Label ID="lblThekedarMobNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>करारनामा क्रमांक</td>
                        <td colspan="8">
                            <asp:TextBox ID="txtNividaKramank" runat="server" CssClass="form-control c" PlaceHolder="करारनामा क्रमांक" TabIndex="28"></asp:TextBox>
                        </td>
                        <td colspan="2">करारनामा किंमत</td>
                        <td colspan="8">
                            <asp:TextBox ID="txtNividaKimat" runat="server" CssClass="form-control c" PlaceHolder="करारनामा किंमत" TabIndex="29">0</asp:TextBox>
                        </td>
                        <td colspan="3">कार्यारंभ आदेश</td>
                        <td>
                            <asp:TextBox ID="txtkaryarambhaadesh" runat="server" CssClass="form-control c" PlaceHolder="कार्यारंभ आदेश" TabIndex="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>कार्यारंभ दिनांक </td>
                        <td colspan="8">
                            <asp:TextBox ID="txtkaryarambhdinak" CssClass="form-control c" runat="server" PlaceHolder="दिनांक" AutoPostBack="True" OnTextChanged="txtkaryarambhdinak_TextChanged" TabIndex="31"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" BehaviorID="CalendarExtender4" TargetControlID="txtkaryarambhdinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td colspan="2">कामाची मुदत </td>
                        <td colspan="8">
                            <asp:TextBox ID="txtkamachimudat" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtkamachimudat_TextChanged" PlaceHolder="करारनामा क्रमांक" TabIndex="32" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="3">काम पूर्ण करण्याची दिनांक</td>
                        <td>
                            <asp:TextBox ID="txtkampurndinak" runat="server" CssClass="form-control c" Enabled="False" PlaceHolder="करारनामा क्रमांक"></asp:TextBox>
                        </td>
                    </tr>

                    <tr style="background-color: #dbd7d7">
                        <td style="font-size: 18px" colspan="8">लेखा शाखा </td>
                        <td colspan="14">
                            <asp:DropDownList ID="AuditDate" runat="server" CssClass="form-control c" Style="font-size: 16px;" AutoPostBack="True" OnSelectedIndexChanged="AuditDate_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsecurity" runat="server" CssClass="form-control c" AutoPostBack="True" TextMode="Password" OnTextChanged="txtsecurity_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>कामाच्या मुदत वाढीचा दिनांक </td>
                        <td colspan="5">
                            <asp:TextBox ID="txtmudatvadhdinak" runat="server" CssClass="form-control c" PlaceHolder="मुदत वाढीचा दिनांक" TabIndex="33"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" BehaviorID="CalendarExtender6" TargetControlID="txtmudatvadhdinak" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td colspan="2">वर्ष <asp:Label ID="lblanudan" runat="server" Text=""></asp:Label> मधील उपलब्ध अनुदान लक्ष</td>
                        <td colspan="5">
                            <asp:TextBox ID="txtcost" runat="server" CssClass="form-control c" onkeyup="checkDec(this);" AutoPostBack="True" required="" OnTextChanged="txtcost_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="3">वर्ष
                       <asp:Label ID="lekhamarchkharch" runat="server"></asp:Label>
                            &nbsp;चालू महिन्या अखेर उपलब्ध अनुदान</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtmarchakherkharch" runat="server" CssClass="form-control c" PlaceHolder="मार्च अखेर खर्च" required="" TabIndex="43" onkeyup="checkDec(this);" AutoPostBack="True" OnTextChanged="txtmarchakherkharch_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">एकुण उपलब्ध अनुदान</td>
                        <td>
                            <asp:TextBox ID="txturvaritamt"  runat="server" CssClass="form-control c" required="" onkeyup="checkDec(this);">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>सद्यस्थिती</td>
                        <td colspan="6">
                            <asp:TextBox ID="Billpayment" runat="server" CssClass="form-control c" TabIndex="33">0</asp:TextBox></td>
                        <td colspan="16" rowspan="2">
                            <table align="center" class="table table-bordered">
                                <tr>
                                    <td colspan="8">
                                        <asp:Label ID="lekhamarchanudan" runat="server"></asp:Label>
                                        &nbsp; मधील वितरीत अनुदान</td>
                                </tr>
                                <tr>
                                    <td>जानेवारी</td>
                                    <td>
                                        <asp:TextBox ID="txtjan" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtjan_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td>फेब्रुवारी</td>
                                    <td>
                                        <asp:TextBox ID="txtfeb" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtfeb_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td>मार्च</td>
                                    <td>
                                        <asp:TextBox ID="txtmar" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtmar_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td>एप्रिल</td>
                                    <td>
                                        <asp:TextBox ID="txtapr" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtapr_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>मे</td>
                                    <td>
                                        <asp:TextBox ID="txtmay" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtmay_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td>जून</td>
                                    <td>
                                        <asp:TextBox ID="txtjun" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtjun_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td>जुलै</td>
                                    <td>
                                        <asp:TextBox ID="txtjul" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtjul_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td>ऑगस्ट</td>
                                    <td>
                                        <asp:TextBox ID="txtaug" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtaug_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>सेप्टेंबर</td>
                                    <td>
                                        <asp:TextBox ID="txtsep" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtsep_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td>ऑक्टोबर</td>
                                    <td>
                                        <asp:TextBox ID="txtoct" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtoct_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td>नोव्हेंबर</td>
                                    <td>
                                        <asp:TextBox ID="txtnov" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtnov_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                    <td>डिसेंबर</td>
                                    <td>
                                        <asp:TextBox ID="txtdec" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtdec_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">&nbsp;
                                  <asp:Label ID="totalvitritanudan" runat="server"></asp:Label>
                                        &nbsp;मधील एकुण वितरीत अनुदान</td>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtaikunanudan" runat="server" CssClass="form-control c" Enabled="False" PlaceHolder="ऐकून वितरीत अनुदान" TabIndex="42" onkeyup="checkDec(this);">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" rowspan="2">
                            <table class="table table-bordered">
                                <tr>
                                    <td colspan="2" class="profile_picture">वर्ष
                                   <asp:Label ID="lekhayeartartud" runat="server"></asp:Label>
                                        &nbsp;तरतूद</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlakun1" runat="server" AutoPostBack="True" CssClass="form-control c" OnSelectedIndexChanged="ddlakun1_SelectedIndexChanged" TabIndex="36">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtakun1" runat="server" PlaceHolder="मार्च अनुदान" TabIndex="37" CssClass="form-control c" onkeyup="checkDec(this);" required="" AutoPostBack="True" OnTextChanged="txtakun1_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlakun2" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="38">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtakun2" runat="server" TabIndex="39" onkeyup="checkDec(this);" required="" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtakun2_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlakun3" runat="server" AutoPostBack="True" CssClass="form-control c" TabIndex="40">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtakun3" runat="server" TabIndex="41" onkeyup="checkDec(this);" CssClass="form-control c" required="" AutoPostBack="True" OnTextChanged="txtakun3_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlakun4" CssClass="form-control c" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtakun4" runat="server" onkeyup="checkDec(this);" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtakun4_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>वर्ष
                                   <asp:Label ID="lekhayearanudan" runat="server"></asp:Label>
                                        &nbsp;एकुण तरतूद</td>
                                    <td>
                                        <asp:TextBox ID="txttartud" runat="server" CssClass="form-control c" PlaceHolder="तरतूद" required="" TabIndex="35" onkeyup="checkDec(this);" Enabled="False">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lekhayearmagil" runat="server"></asp:Label>
                            मधील मागील<asp:DropDownList ID="ddlmagilmonth" runat="server" CssClass="form-control c"></asp:DropDownList>
                            महिन्यापर्यंतचा खर्च</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtmagilkharch" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtmagilkharch_TextChanged" PlaceHolder="वर्ष अखेर खर्च" required="" TabIndex="44" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="3">वर्ष
                            <asp:Label ID="lekhayearchalu" runat="server"></asp:Label>
                            मधील चालू
                            <asp:DropDownList ID="ddlchalukharch" runat="server" CssClass="form-control c"></asp:DropDownList>
                            महिन्यातील खर्च लक्ष</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtchalukharch" runat="server" AutoPostBack="True" CssClass="form-control c" OnTextChanged="txtchalukharch_TextChanged" PlaceHolder="चालू महिन्यातील खर्च" required="" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">मागणी</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtmagni" runat="server" CssClass="form-control c" PlaceHolder="मागणी" required="" TabIndex="46" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="4">वर्ष
                    <asp:Label ID="lableyearaikunkharch" runat="server"></asp:Label>
                            &nbsp;मधील एकुण खर्च</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtvarshbharatilkharch" runat="server" AutoPostBack="True" CssClass="form-control c" Enabled="False" PlaceHolder="वर्ष मधील ऐकून खर्च" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                        <td colspan="3">कामावरील एकुण खर्च
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtaikunkharch" runat="server" AutoPostBack="True" CssClass="form-control c" Enabled="False" PlaceHolder="कामावरील ऐकून खर्च" onkeyup="checkDec(this);">0</asp:TextBox>
                        </td>
                    </tr>
                      <tr>
             <td >विद्युतीकरण कामाची किंमत</td>
             <td colspan="4"><asp:TextBox ID="txtVidyutprama" runat="server" CssClass="form-control c" onkeyup="checkDec(this);" AutoPostBack="True" OnTextChanged="txtVidyutprama_TextChanged">0</asp:TextBox></td>
             <td colspan="3">विद्युतीकरणाचा खर्च</td>
             <td colspan="4"><asp:TextBox ID="txtVidyutvitarit" runat="server" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtVidyutvitarit_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox></td>
              <td colspan="3">इतर खर्च</td>
             <td ><asp:TextBox ID="txtitarkhrch" runat="server" CssClass="form-control c" AutoPostBack="True" OnTextChanged="txtitarkhrch_TextChanged" onkeyup="checkDec(this);">0</asp:TextBox></td>
                          <td colspan="4">दवगुनी ज्ञापने</td>
             <td colspan="3"><asp:TextBox ID="txtdnyapane" runat="server" CssClass="form-control c"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td colspan="2">कामाची सद्यस्थिती </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlsadyasthiti" runat="server" TabIndex="47" CssClass="form-control c">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Completed</asp:ListItem>
                                <asp:ListItem>Processing</asp:ListItem>
                                <asp:ListItem>Not Started</asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td colspan="4">पाहणी अहवाल क्रमांक</td>
                        <td colspan="6">
                            <asp:TextBox ID="txtpahnikramank" runat="server" CssClass="form-control c" PlaceHolder="पाहणी अहवाल क्रमांक" TabIndex="48"></asp:TextBox>
                        </td>
                        <td colspan="3">पाहणी अहवाल मुद्ये</td>
                        <td colspan="5">
                            <asp:TextBox ID="txtpahnimudye" runat="server" CssClass="form-control" style="font-size:16px;font-weight:bold;" Width="100%" PlaceHolder="पाहणी अहवाल मुद्ये" TextMode="MultiLine" TabIndex="49"></asp:TextBox>
                        </td>

                    </tr>

                    <tr>
                        <td colspan="4">शेरा</td>
                        <td colspan="19">
                            <asp:TextBox ID="txtshera" runat="server" CssClass="form-control" style="font-size:16px;font-weight:bold" Width="100%" PlaceHolder="शेरा" Height="40px" TextMode="MultiLine" TabIndex="50"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="23">&nbsp;</td>
                    </tr>

                </table>
            </div>
      <br /></ContentTemplate>
        </asp:UpdatePanel>

   <div>
        <asp:Button ID="BtnSav" runat="server"  Text="संपादित करा" TabIndex="51" CssClass="btnform" Height="10%" OnClick="BtnSav_Click" />
        <asp:Button ID="BtnCancel" runat="server"  Text="रद्द करा" TabIndex="52" CssClass="btnform" Height="10%" OnClientClick="Navigate()" />
        <asp:Button ID="btnPrint" runat="server" Text="प्रिंट" OnClientClick="printTbl()" CssClass="btnform" TabIndex="53" Height="10%" />
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
