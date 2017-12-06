<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="DBSIndividualHeadReport.aspx.cs" Inherits="PWdEEBudget.DBSIndividualHeadReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ExcelDwnld {
            /*width: 41%;
            margin-left: 55%;*/
            background-color: white !important;
            background: linear-gradient(white,white) !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label runat="server" ID="lbl">


        <asp:Panel ID="Panel1" runat="server">
            <table id="UpVibhag1" border="1" style="text-align: center; width: 100%" runat="server">
                <tr>
                    <th colspan="11" style="text-align: center">सार्वजनिक बांधकाम पूर्व विभाग पुणे</th>
                </tr>
                <tr>
                    <th class="freq" style="text-align: center"></th>
                    <th class="freq" style="text-align: center">बारामती</th>
                    <th class="freq" style="text-align: center">उपविभाग, बारामती</th>
                    <th class="freq" style="text-align: center">दौंड</th>
                    <th class="freq" style="text-align: center">दौंड (ईमारती) </th>
                    <th class="freq" style="text-align: center">इंदापूर </th>
                    <th class="freq" style="text-align: center">भिगवण</th>
                    <th class="freq" style="text-align: center">शिरुर</th>
                    <%--<th class="freq">शिरुर, आंबेगाव</th>--%>
                    <th class="freq" style="text-align: center">प्रकल्प (खा), पुणे</th>
                    <th class="freq" style="text-align: center">क्र. 4, पुणे</th>

                </tr>

                <tr>
                    <td class="dir">CRF</td>
                    <td id="CBarmati" runat="server" class="data">0</td>
                    <td id="CUpBaramati" runat="server" class="data">0</td>
                    <td id="CDound" runat="server" class="data">0</td>
                    <td id="CDoundEmart" runat="server" class="data">0</td>
                    <td id="CIndapur" runat="server" class="data">0</td>
                    <td id="CBhig" runat="server" class="data">0</td>
                    <td id="CShirur" runat="server" class="data">0</td>
                    <%--<td id="CShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="CPrakalp" runat="server" class="data">0</td>
                    <td id="CKramank" runat="server" class="data">0</td>

                </tr>
                <tr>
                    <td class="dir">Deposit </td>
                    <td id="DFBarmati" runat="server" class="data">0</td>
                    <td id="DFUpBaramati" runat="server" class="data">0</td>
                    <td id="DFDound" runat="server" class="data">0</td>
                     <td id="DFDoundEmart" runat="server" class="data">0</td>
                    <td id="DFIndapur" runat="server" class="data">0</td>
                    <td id="DFBhig" runat="server" class="data">0</td>
                    <td id="DFShirur" runat="server" class="data">0</td>
                    <%--<td id="DFShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="DFPrakalp" runat="server" class="data">0</td>
                    <td id="DFKramank" runat="server" class="data">0</td>
                   
                </tr>
                <tr>
                    <td class="dir">MP</td>
                    <td id="MPBarmati" runat="server" class="data">0 </td>
                    <td id="MPUpBaramati" runat="server" class="data">0 </td>
                    <td id="MPDound" runat="server" class="data">0 </td>
                     <td id="MPDoundEmart" runat="server" class="data">0</td>
                    <td id="MPIndapur" runat="server" class="data">0 </td>
                    <td id="MPBhig" runat="server" class="data">0 </td>
                    <td id="MPShirur" runat="server" class="data">0 </td>
                    <%-- <td id="MPShirurAm"   runat="server" class="data">0 </td>--%>
                    <td id="MPPrakalp" runat="server" class="data">0 </td>
                    <td id="MPKramank" runat="server" class="data">0 </td>
                   
                </tr>
                <tr>
                    <td class="dir">MLA</td>
                    <td id="MLABarmati" runat="server" class="data">0</td>
                    <td id="MLAUpBaramati" runat="server" class="data">0</td>
                    <td id="MLADound" runat="server" class="data">0</td>
                     <td id="MLADoundEmart" runat="server" class="data">0</td>
                    <td id="MLAIndapur" runat="server" class="data">0</td>
                    <td id="MLABhig" runat="server" class="data">0</td>
                    <td id="MLAShirur" runat="server" class="data">0</td>
                    <%-- <td id="MLAShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="MLAPrakalp" runat="server" class="data">0</td>
                    <td id="MLAKramank" runat="server" class="data">0</td>
                   
                </tr>
                <tr>
                    <td class="dir">Nabard</td>
                    <td id="NABarmati" runat="server" class="data">0</td>
                    <td id="NAUpBaramati" runat="server" class="data">0</td>
                    <td id="NADound" runat="server" class="data">0</td>
                    <td id="NADoundEmart" runat="server" class="data">0</td>
                    <td id="NAIndapur" runat="server" class="data">0</td>
                    <td id="NABhig" runat="server" class="data">0</td>
                    <td id="NAShirur" runat="server" class="data">0</td>
                    <%--<td id="NAShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="NAPrakalp" runat="server" class="data">0</td>
                    <td id="NAKramank" runat="server" class="data">0</td>
                    

                </tr>
                <tr>
                    <td class="dir">Building</td>
                    <td runat="server" id="BBarmati" class="data">0</td>
                    <td runat="server" id="BUpBaramati" class="data">0</td>
                    <td runat="server" id="BDound" class="data">0></td>
                     <td id="BDoundEmart" runat="server" class="data">0</td>
                    <td runat="server" id="BIndapur" class="data">0</td>
                    <td runat="server" id="BBhig" class="data">0</td>
                    <td runat="server" id="BShirur" class="data">0</td>
                    <%--<td runat="server" id="BShirurAm"   class="data">0</td>--%>
                    <td runat="server" id="BPrakalp" class="data">0</td>
                    <td runat="server" id="BKramank" class="data">0</td>
                   

                </tr>
                <tr>
                    <td class="dir">Annuity</td>
                    <td id="ANBarmati" runat="server" class="data">0</td>
                    <td id="ANUpBaramati" runat="server" class="data">0</td>
                    <td id="ANDound" runat="server" class="data">0</td>
                     <td id="ANDoundEmart" runat="server" class="data">0</td>
                    <td id="ANIndapur" runat="server" class="data">0</td>
                    <td id="ANBhig" runat="server" class="data">0</td>
                    <td id="ANShirur" runat="server" class="data">0</td>
                    <%--   <td id="ANShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="ANPrakalp" runat="server" class="data">0</td>
                    <td id="ANKramank" runat="server" class="data">0</td>
                   

                </tr>
                <tr>
                    <td class="dir">Gat_A</td>
                    <td id="GABarmati" runat="server" class="data">0</td>
                    <td id="GAUpBaramati" runat="server" class="data">0</td>
                    <td id="GADound" runat="server" class="data">0</td>
                      <td id="GADoundEmart" runat="server" class="data">0</td>
                    <td id="GAIndapur" runat="server" class="data">0</td>
                    <td id="GABhig" runat="server" class="data">0</td>
                    <td id="GAShirur" runat="server" class="data">0</td>
                    <%-- <td id="GAShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="GAPrakalp" runat="server" class="data">0</td>
                    <td id="GAKramank" runat="server" class="data">0</td>
                  

                </tr>
                <tr>
                    <td class="dir">Gat_D</td>
                    <td id="GDBarmati" runat="server" class="data">0</td>
                    <td id="GDUpBaramati" runat="server" class="data">0</td>
                    <td id="GDDound" runat="server" class="data">0</td>
                     <td id="GDDoundEmart" runat="server" class="data">0</td>
                    <td id="GDIndapur" runat="server" class="data">0</td>
                    <td id="GDBhig" runat="server" class="data">0</td>
                    <td id="GDShirur" runat="server" class="data">0</td>
                    <%--<td id="GDShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="GDPrakalp" runat="server" class="data">0</td>
                    <td id="GDKramank" runat="server" class="data">0</td>
                   

                </tr>
                <tr>
                    <td class="dir">Gat_BCF</td>
                    <td id="GFBCBarmati" runat="server" class="data">0</td>
                    <td id="GFBCUpBaramati" runat="server" class="data">0</td>
                    <td id="GFBCDound" runat="server" class="data">0</td>
                    <td id="GFBCDoundEmart" runat="server" class="data">0</td>
                    <td id="GFBCIndapur" runat="server" class="data">0</td>
                    <td id="GFBCBhig" runat="server" class="data">0</td>
                    <td id="GFBCShirur" runat="server" class="data">0</td>
                    <%--<td id="GFBCShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="GFBCPrakalp" runat="server" class="data">0</td>
                    <td id="GFBCKramank" runat="server" class="data">0</td>
                    

                </tr>
                <tr>
                    <td class="dir">SH_DOR</td>
                    <td id="ROBarmati" runat="server" class="data">0</td>
                    <td id="ROUpBaramati" runat="server" class="data">0</td>
                    <td id="RODound" runat="server" class="data">0</td>
                     <td id="RODoundEmart" runat="server" class="data">0</td>
                    <td id="ROIndapur" runat="server" class="data">0</td>
                    <td id="ROBhig" runat="server" class="data">0</td>
                    <td id="ROShirur" runat="server" class="data">0</td>
                    <%--<td id="ROShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="ROPrakalp" runat="server" class="data">0</td>
                    <td id="ROKramank" runat="server" class="data">0 </td>
                   



                </tr>
                <tr>
                    <td class="dir">DPDC</td>
                    <td id="DPBarmati" runat="server" class="data">0</td>
                    <td id="DPUpBaramati" runat="server" class="data">0</td>
                    <td id="DPDound" runat="server" class="data">0</td>
                     <td id="DPDoundEmart" runat="server" class="data">0</td>
                    <td id="DPIndapur" runat="server" class="data">0</td>
                    <td id="DPBhig" runat="server" class="data">0</td>
                    <td id="DPShirur" runat="server" class="data">0</td>
                    <%--<td id="DPShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="DPPrakalp" runat="server" class="data">0</td>
                    <td id="DPKramank" runat="server" class="data">0 </td>
                   

                </tr>
                <tr>
                    <td class="dir">2059</td>
                    <td id="NRBBarmati" runat="server" class="data">0</td>
                    <td id="NRBUpBaramati" runat="server" class="data">0</td>
                    <td id="NRBDound" runat="server" class="data">0</td>
                     <td id="NRBDoundEmart" runat="server" class="data">0</td>
                    <td id="NRBIndapur" runat="server" class="data">0</td>
                    <td id="NRBBhig" runat="server" class="data">0</td>
                    <td id="NRBShirur" runat="server" class="data">0</td>
                    <%--<td id="NRBShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="NRBPrakalp" runat="server" class="data">0</td>
                    <td id="NRBKramank" runat="server" class="data">0</td>
                   

                </tr>
                <tr>
                    <td class="dir">2216</td>
                    <td id="RBBarmati" runat="server" class="data">0</td>
                    <td id="RBUpBaramati" runat="server" class="data">0</td>
                    <td id="RBDound" runat="server" class="data">0</td>
                     <td id="RBDoundEmart" runat="server" class="data">0</td>
                    <td id="RBIndapur" runat="server" class="data">0</td>
                    <td id="RBBhig" runat="server" class="data">0</td>
                    <td id="RBShirur" runat="server" class="data">0</td>
                    <%--<td id="RBShirurAm"   runat="server" class="data">0</td>--%>
                    <td id="RBPrakalp" runat="server" class="data">0</td>
                    <td id="RBKramank" runat="server" class="data">0</td>
                   

                </tr>
                <tr>
                    <td class="dir">2515</td>
                    <td id="GramVBarmati" runat="server" class="data">0</td>
                    <td id="GramVUpBaramati" runat="server" class="data">0</td>
                    <td id="GramVDound" runat="server" class="data">0</td>
                     <td id="GramVDoundEmart" runat="server" class="data">0</td>
                    <td id="GramVIndapur" runat="server" class="data">0</td>
                    <td id="GramVBhig" runat="server" class="data">0</td>
                    <td id="GramVShirur" runat="server" class="data">0</td>
                    <%--<td id="GramVShirurAm" runat="server" class="data">0</td>--%>
                    <td id="GramVPrakalp" runat="server" class="data">0</td>
                    <td id="GramVKramank" runat="server" class="data">0</td>
                   

                </tr>


            </table>
        </asp:Panel>
    </asp:Label>
    <br />
    <div style="float: right">
        <%--<asp:Button runat="server" ID="btnExcel" OnClick="btnExcel_Click" Text="Excel" />--%>

        <asp:ImageButton runat="server" ID="btnImgExcel" ImageUrl="~/logo/green-download-button-mid.png" Height="40px" OnClick="btnImgExcel_Click" CssClass="ExcelDwnld" BackColor="White" />
        <asp:ImageButton runat="server" ID="btnImgSendMail" ImageUrl="~/logo/sendmail.png" Height="40px" OnClick="btnImgSendMail_Click" Style="padding: 4px" CssClass="ExcelDwnld" BackColor="White" />
        <asp:ImageButton runat="server" ID="btnBack" ImageUrl="~/logo/Go-back.ico" AlternateText="Back" Height="40px" Style="padding: 4px" CssClass="ExcelDwnld" BackColor="White" OnClientClick="JavaScript:window.history.back(1); return false;" />
        <%-- <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-default" BackColor="#660000" ForeColor="White"  Height="40px" Width="100px" OnClientClick="JavaScript:window.history.back(1); return false;" />--%>
    </div>

</asp:Content>
