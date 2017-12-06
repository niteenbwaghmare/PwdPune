<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="UploadImage.aspx.cs" Inherits="PWdEEBudget.UploadImage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pageCenter {
            margin-left: auto;
            margin-right: auto;
        }

        .c {
            font-weight: bold;
            color: #000000;
            width: 75% !important;
            font-size: 16px;
            height: 38px !important;
            line-height: 38px !important;
        }

        td {
            text-align: center;
        }

        th {
            font-size: 20px;
        }
    </style>
    <style>
        .image {
  display: inline-block;
  height: 100%;
  width: 100%;
  background:white;
  position: relative;
  overflow:hidden;
  padding:15px;
}
.image img {
  height: 100%;
  width: 100%;
}
.image .tooltip {
  position: absolute;
  transform: translate(100%);
  bottom: 0;
  width: 100%;
  color: red;
  /*background: rgba(0, 0, 0, 0.5);*/
  transition: all 0.8s;
  opacity:0;
  font-size:18px;
   margin-bottom:15px;
}
.image:hover .tooltip {
  position: absolute;
  transform: translate(0);
  opacity:1;
  background-color:white;
}
.tooltip:hover ~ .this{
  width:300px;
  }
.lbltooltipclass{
   
    visibility:hidden;
}
.image:hover .lbltooltipclass {
  visibility:visible;
 
}
    </style>
     <style>
        .navbar-default .navbar-nav > li > a.uploadImagePage {
            display: block !important;
            /*background-color: gray !important;*/
            background: linear-gradient(#3b5998,#00C6D7) !important;
            color: white !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <table class="table table-bordered" style="color: #000; margin-top: 5%">
            <tr>
                <th colspan="4" style="text-align: center">
                    <h2>Upload Image</h2>
                </th>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl" runat="server" Text="Select Type"></asp:Label></td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control c" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                        
                        <asp:ListItem Text="Annuity" Value="BudgetMasterAunty"></asp:ListItem>
                        <asp:ListItem Text="Building" Value="BudgetMasterBuilding"></asp:ListItem>
                        <asp:ListItem Text="CRF" Value="BudgetMasterCRF"></asp:ListItem>
                        <asp:ListItem Text="Deposit" Value="BudgetMasterDepositFund"></asp:ListItem>
                        <asp:ListItem Text="DPDC" Value="BudgetMasterDPDC"></asp:ListItem>
                        <asp:ListItem Text="MLA" Value="BudgetMasterMLA"></asp:ListItem>
                        <asp:ListItem Text="MP" Value="BudgetMasterMP"></asp:ListItem>
                        <asp:ListItem Text="Nabard" Value="BudgetMasterNABARD"></asp:ListItem>
                        <asp:ListItem Text="Residential_Building" Value="BudgetMasterResidentialBuilding"></asp:ListItem>
                        <asp:ListItem Text=" NonResidential_Building" Value="BudgetMasterNonResidentialBuilding"></asp:ListItem>
                        <asp:ListItem Text="Road" Value="BudgetMasterRoad"></asp:ListItem>
                        <asp:ListItem Text="3054_Gat_A" Value="BudgetMasterGAT_A"></asp:ListItem>
                        <asp:ListItem Text="3054_Gad_D" Value="BudgetMasterGAT_D"></asp:ListItem>
                        <asp:ListItem Text="3054_Gat_FBC" Value="BudgetMasterGAT_FBC"></asp:ListItem>
                        <asp:ListItem Text="2515_GramVikas" Value="BudgetMaster2515"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl1" runat="server" Text="WorkID"></asp:Label></td>
                <td colspan="2">
                    <asp:UpdatePanel runat="server" ID="uppanel11">
                        <ContentTemplate>
                    <asp:TextBox ID="txtoldWorkID" runat="server" CssClass="form-control c" AutoPostBack="true" OnTextChanged="txtoldWorkID_TextChanged" required=""></asp:TextBox>
                    <ajaxtoolkit:autocompleteextender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtoldWorkID"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
                    </ajaxtoolkit:autocompleteextender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl3" runat="server" Text="Select Image"></asp:Label>
                </td>

                <td colspan="2">
                    <asp:FileUpload runat="server" ID="FileUpload1" CssClass="fileUpload"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FileUpload1" ValidationGroup="UploadClick" ErrorMessage="Please Select Image." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:CustomValidator ID="CustomValidator1" ValidationGroup="UploadClick" runat="server" 
 ClientValidationFunction="ValidateFileUpload" ErrorMessage="Please select Correct Image format." ForeColor="Red"></asp:CustomValidator>
                   <%-- <asp:RegularExpressionValidator id="REV1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please Select Correct Image Format" ForeColor="Red" ValidationExpression="/^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpeg|.JPEG|.gif|.GIF|.png|.PNG|.JPG|.jpg|.bitmap|.BITMAP)$/" SetFocusOnError="true">

                    </asp:RegularExpressionValidator>--%>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl4" runat="server" Text="Work Status"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtImgDesc" runat="server" CssClass="form-control c"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td colspan="3">
                     <asp:Button ID="btnUplodImg" runat="server" Text="Upload" BackColor="#FFFFCC" ValidationGroup="UploadClick" BorderColor="#CCCCFF" BorderStyle="Solid" OnClick="btnUplodImg_Click"  CssClass="fa-folder" style="float:left;" />  
                    <asp:Button ID="btnBack" runat="server" BackColor="#FFFFCC" ValidationGroup="NoValidation" CausesValidation="false" BorderColor="#CCCCFF" BorderStyle="Solid" OnClick="btnBack_Click" UseSubmitBehavior="false" CssClass="fa-folder" Text="Back To Report" style="border-radius: 5px;background: linear-gradient(gray,white);font-weight: 700;color: black;font-size: 0.9em;padding: 0.4em 1em;float:left;"/>
                     
                </td>
            </tr>

        </table>
    </div>
    <div style="overflow-x: auto;" align="center" class="b">
        <br />&nbsp;&nbsp;
        <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
            <ProgressTemplate>
                <div class="loading" align="center">
                    <img alt="progress" src="loader.gif" />
                    <br />
                    <b>Processing....</b>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <br />
        <asp:Button runat="server" Text="Download All Images" ID="btnDownloadAllImages" OnClick="btnDownloadAllImages_Click" />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

                <asp:Label ID="lblStatus" runat="server"></asp:Label>&nbsp;
                <asp:Label runat="server" ID="lblWorkid" Font-Bold="true" Font-Size="Large"></asp:Label>
                <br />
                <asp:Label runat="server" ID="lblKamacheName" Font-Bold="true" Font-Size="Large"></asp:Label>
                <br />
                
                <hr />
                <div style="height: 500px; width: 100%; overflow: Auto">
                    <asp:DataList runat="server" ID="DataList1" RepeatDirection="Horizontal" RepeatColumns="2" Width="97%" ItemStyle-Width="800">
                        <ItemTemplate>
                            <div class="image" style="padding:15px">
                                <asp:Image ID="GallaryImg" runat="server" Height="100%" Width="100%" AlternateText="Image Not Load Proparly Please Refresh Page" BorderStyle="Groove" ImageUrl='<%# "Handler.ashx?WorkId=" + Eval("ImageId")%>' />
                                <div class="tooltip" runat="server">
                                    कामाचे नाव :-
                                    <asp:Label ID="lblWorkName" runat="server" style="color:green;"></asp:Label><br />
                                    कामाची स्थिती :-
                                    <asp:Label ID="lbltooltip" runat="server" CssClass="lbltooltipclass" Text='<%# Eval("Description")%>' style="margin-bottom:-1%; color:green" />
                                    <asp:Label ID="lblImageId" runat="server" Visible="false" Text='<%#Eval("ImageId") %>' />
                                    <asp:ImageButton id="delImg" runat="server" AlternateText="delete" ImageUrl="~/logo/delete butt.png" Height="33px" Width="37px" style="margin-left:5%;  margin-bottom:-2%;" OnClick="delImg_Click"/> 
                                    <asp:ImageButton id="ImgDown" runat="server" AlternateText="Download" Height="33px" Width="40px" style="margin-left:5%; margin-bottom:-2%;" ImageUrl="~/logo/download but.png" OnClick="ImgDown_Click"/>
                                </div>
                            </div>
                        </ItemTemplate>
                        <ItemStyle BorderStyle="Double" />
                    </asp:DataList>
                </div>
            </ContentTemplate>
           <Triggers>
               <asp:PostBackTrigger ControlID="DataList1"/>
             
           </Triggers>
        </asp:UpdatePanel>
        
    </div>
     <script lang="javascript" type="text/javascript">
         function ValidateFileUpload(Source, args) {
             var fuData = document.getElementById('<%= FileUpload1.ClientID %>');
             var FileUploadPath = fuData.value;

             if (FileUploadPath == '') {
                 // There is no file selected 
                 args.IsValid = false;
             }
             else {
                 var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

                 if (Extension == "jpg" || Extension == "jpeg" || Extension == "png" || Extension == "gif" || Extension == "bmp" || Extension == "tif" || Extension == "jpe" || Extension == "tiff" || Extension == "jfif" || Extension == "bib") {
                     args.IsValid = true; // Valid file type
                 }
                 else {
                     args.IsValid = false; // Not valid file type
                 }
             }
         }
</script> 
</asp:Content>
