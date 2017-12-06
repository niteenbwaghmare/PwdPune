<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Send_sms.aspx.cs" Inherits="PWdEEBudget.Send_sms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .c {
            font-weight: bold;
            color: gray;
            width: 87%;
            font-size: 16px;
            height: 38px !important;
            line-height: 38px !important;
        }
        #caption {
            height: 70%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
             <div style="    background: linear-gradient(#ccc,#fae8bd);width: 40%;margin-left: 30%;border: 1px solid;border-radius: 7px;">
                 <div style="height:29px;">
                     <h4 style="padding-left: 36%;font-size: xx-large;">Send SMS</h4><br />
                     <asp:Label ID="lblStatus" runat="server"></asp:Label>
                 </div>
                 <hr />
                 <div style="width: 62%;margin-left: 21%;">
                     <table class="table  mar" style="width:400px; height:500px">
                         <tr>
                             <td><asp:DropDownList ID="ddltransroute" runat="server" CssClass="form-control c">
                                 <asp:ListItem >Transaction Route</asp:ListItem>
                                 </asp:DropDownList></td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:150px;font-weight: bold; color: #000000;">Sender Id :
                                 <asp:Label ID="lblsenderId" runat="server" Text="EEesPN"></asp:Label></td>
                         </tr>
                         <tr>
                              <td colspan="2">
                                  <asp:Label ID="Label1" runat="server" Text="Select Mobile Number"></asp:Label><br />
                                  <asp:DropDownCheckBoxes ID="DropDownCheckBoxes1" runat="server" AddJQueryReference="True" UseButtons="False" UseSelectAllNode="True" CssClass="form-control c" Style="width: 60% !important;">
                                      <Style SelectBoxWidth="280" DropDownBoxBoxWidth="150" DropDownBoxBoxHeight="200" />
                                  </asp:DropDownCheckBoxes>
                                  <input type="button" id="btnAdd" value="Add" onclick="updateTextArea()" />
                              </td>
                         </tr>
                         <tr>
                             <td style="width:150px;font-weight: bold; color: #000000;" colspan="2">Mobile No:<br />
                                 <asp:TextBox ID="txtmobileno" runat="server" PlaceHolder="Type Your No Here" TextMode="MultiLine" style="width:338px; height:120px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td style="width:150px;font-weight: bold; color: #000000;" colspan="2">Description:<br />
                                 <asp:TextBox ID="txtdescription" runat="server" PlaceHolder="Type Your Message Here" TextMode="MultiLine" style="width:338px; height:120px"></asp:TextBox>
                             </td>
                         </tr>
                     </table>
                 </div>
                 <hr />
                 <div style="    width: 40%;margin-left: 33%;margin-bottom: 3%;">
                     <asp:Button ID="Button1" runat="server" Text="Send" CssClass="btn btn-primary" OnClick="Button1_Click" />
                     <asp:Button ID="Button4" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="Button4_Click" />
                 </div>
                 </div>
             </ContentTemplate>
         </asp:UpdatePanel>
    <script>
        $('#Button1').click(
    function () {
        var inputString = $('#txtmobileno').val();
        if (inputString.charAt(inputString.length - 1) == ',') {
            var shortenedString = inputString.substr(0, (inputString.length - 1));
            alert("Plese Remove Last comma(,) from number");
            $('#idOfInput').val(shortenedString);
        }
        return false;
    });
    </script>
    <script>

        function updateTextArea() {
            var allVals = [];
            $('[id*=DropDownCheckBoxes1] :checked').each(function () {
                allVals.push($(this).val());
                //alert($(this).val());
                
            });
            //code to check if on is added in array then remove it and then bind that value to txtmobileno
            if ($.inArray('on', allVals) > -1) {
                var itemtoRemove = "on";
                allVals.splice($.inArray(itemtoRemove, allVals), 1);
            }
            $('[id*=txtmobileno]').val(allVals);
        };
    </script>
    </asp:Content>