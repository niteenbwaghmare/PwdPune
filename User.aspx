<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="PWdEEBudget.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        th {
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <h3 style="text-align:center;color:darkblue">Admin Profile</h3>
    <div style="overflow-x:auto">
     <table id="material" class="table table-bordered mar" style="color:#000" >
          
         <tr>
                <td style="font-weight: bold; color: #000000">युझरचा क्र:</td>
                <td colspan="3"><asp:TextBox ID="txtid" runat="server"  CssClass="form-control" AutoPostBack="True" OnTextChanged="txtid_TextChanged" ></asp:TextBox></td>
               

           </tr>
            <tr>
                <td style="font-weight: bold; color: #000000">युझरचे नाव:</td>
                <td>
                    <asp:Label ID="lblFName" runat="server" Text="Label"></asp:Label></td>
                <td>
                    <asp:Label ID="lblMName" runat="server" Text="Label"></asp:Label></td>
                <td>
                    <asp:Label ID="lblLName" runat="server" Text="Label"></asp:Label></td>

           </tr>
       <tr>
            <td style="font-weight: bold; color: #000000">कार्यालय:</td>
                <td>
                    <asp:TextBox ID="txtOffice" runat="server" CssClass="form-control" ></asp:TextBox>
                   </td>
            <td style="font-weight: bold; color: #000000">पदनाम:</td>
                <td>
                    <asp:TextBox ID="txtPost" runat="server" CssClass="form-control"></asp:TextBox> </td>

       </tr>
          <tr>
            <td style="font-weight: bold; color: #000000">कार्यालय पत्ता:</td>
                <td colspan="3">
                    <asp:Label ID="lblOffAdd" runat="server" Text="Label"></asp:Label>
                   </td>
             
       </tr>
          <tr>
            <td style="font-weight: bold; color: #000000">कायमचा पत्ता:</td>
                <td colspan="3">
                    <asp:Label ID="lblPerAdd" runat="server" Text="Label"></asp:Label>
                   </td>
              
            
       </tr>
         <tr>
            <td style="font-weight: bold; color: #000000">सध्याचा पत्ता:</td>
                <td colspan="3">
                    <asp:Label ID="lbllocalAddress" runat="server" Text="Label"></asp:Label>
                   </td>
              
       </tr>
          <tr>
            <td style="font-weight: bold; color: #000000">जन्म दिनांक:</td>
                <td>
                    <asp:Label ID="lblDOB" runat="server" Text="Label"></asp:Label>
                    </td>
              <td style="font-weight: bold; color: #000000">नोंदणी दिनांक:</td>
               <td>
                   <asp:Label ID="lblNDate" runat="server" Text="Label"></asp:Label>
                    </td>
       </tr>
          <tr>
            <td style="font-weight: bold; color: #000000">लिंग:</td>
                <td>
                        <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label>
                   </td>
              <td style="font-weight: bold; color: #000000">स्टेट्स:</td>
                <td>
                        <asp:Label ID="lblSatus" runat="server" Text="Label"></asp:Label>
                    </td>
       </tr>
         <tr>
            <td style="font-weight: bold; color: #000000">गाव:</td>
                <td>
                    <asp:Label ID="lblVillage" runat="server" Text="Label"></asp:Label> </td>
             <td style="font-weight: bold; color: #000000">तालुका:</td>
                <td>
                    <asp:Label ID="lblTaluka" runat="server" Text="Label"></asp:Label>   </td>
       </tr>
         
          <tr>
            <td style="font-weight: bold; color: #000000">जिल्हा:</td>
                <td>
                    <asp:Label ID="lblDist" runat="server" Text="Label"></asp:Label> </td>
              <td style="font-weight: bold; color: #000000">राष्ट्रीयत्व:</td>
                <td>
                    <asp:Label ID="lblRastiyatv" runat="server" Text="Label"></asp:Label></td>
       </tr>
            <tr>
                <td style="font-weight: bold; color: #000000">मोबईल नं:</td>
                <td>
                    <asp:Label ID="lblMobNo" runat="server" Text="Label"></asp:Label>  </td>
                <td style="font-weight: bold; color: #000000">इ-मेल:</td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label> </td>
            </tr>
         
        <tr>
                
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" Text="संपादित करा" CssClass="btn btn-primary"   Height="30px" OnClick="Button1_Click"/>
                   <asp:Button ID="Button2" runat="server"   Text="रद्द करा" CssClass="btn btn-danger" Height="31px"  CausesValidation="False"  />
                      <asp:Button ID="Button4" runat="server" Text="मागे" CssClass="btn btn-primary"   Height="30px" OnClick="Button4_Click" />
                </td>
           
                  </tr>
            </table>
        <table class="table table-bordered mar">
                     <tr>
                <td style="text-align: center" >
                    <asp:GridView ID="GridView1" runat="server" BorderStyle="Solid" AutoGenerateEditButton="true" AutoGenerateDeleteButton="True" BorderWidth="1px" Width="100%" AutoGenerateColumns="false" Font-Names="Arial" Font-Size="11pt" DataKeyNames="ID" AlternatingRowStyle-BackColor="#D3D3D3" HeaderStyle-BackColor="#2c3e50"
                        CaptionAlign="Top" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound1">
                        <HeaderStyle BorderColor="black" BorderStyle="Solid" />
                        <Columns>

                            <asp:TemplateField HeaderText="अ.क्र">
                                <ItemTemplate>
                                    <asp:Label ID="lblAKrmank" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="युझरचे नाव">
                                <ItemTemplate>
                                    <%#Eval("Name")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtUname" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="कार्यालय">
                                <ItemTemplate>
                                    <%#Eval("Office")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtKaryalay" runat="server" Text='<%#Eval("Office") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="पदनाम">
                                <ItemTemplate>
                                    <%#Eval("Post")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPost" runat="server" Text='<%#Eval("Post") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="कार्यालय पत्ता">
                                <ItemTemplate>
                                    <%#Eval("OfficeAddress")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtkaryalayAdd" runat="server" Text='<%#Eval("OfficeAddress") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="कायमचा पत्ता">
                                <ItemTemplate>
                                    <%#Eval("PermanemtAddress")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPeradd" runat="server" Text='<%#Eval("PermanemtAddress") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="सध्याचा पत्ता">
                                <ItemTemplate>
                                    <%#Eval("LocalAddress")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLocaladd" runat="server" Text='<%#Eval("LocalAddress") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="जन्म दिनांक">
                                <ItemTemplate>
                                    <%#Eval("DOB")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBirthDate" runat="server" Text='<%#Eval("DOB") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="नोंदणी दिनांक">
                                <ItemTemplate>
                                    <%#Eval("NDate")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNdate" runat="server" Text='<%#Eval("NDate") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="लिंग">
                                <ItemTemplate>
                                    <%#Eval("Gender")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGender" runat="server" Text='<%#Eval("Gender") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="स्टेट्स">
                                <ItemTemplate>
                                    <%#Eval("Status")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStatus" runat="server" Text='<%#Eval("Status") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="गाव">
                                <ItemTemplate>
                                    <%#Eval("Village")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtVillage" runat="server" Text='<%#Eval("Village") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="तालुका">
                                <ItemTemplate>
                                    <%#Eval("Taluka")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTaluka" runat="server" Text='<%#Eval("Taluka") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="जिल्हा">
                                <ItemTemplate>
                                    <%#Eval("Dist")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDist" runat="server" Text='<%#Eval("Dist") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="राष्ट्रीयत्व">
                                <ItemTemplate>
                                    <%#Eval("Nationality")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRastiyatv" runat="server" Text='<%#Eval("Nationality") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="मोबईल नं">
                                <ItemTemplate>
                                    <%#Eval("MobileNo")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMobNo" runat="server" Text='<%#Eval("MobileNo") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="इ-मेल">
                                <ItemTemplate>
                                    <%#Eval("EmailId")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmailId" runat="server" Text='<%#Eval("EmailId") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
                         </tr>
                     </table>
    </div>

    <div>
    </div>
             </ContentTemplate>
         </asp:UpdatePanel>
    <script>
        jQuery("a").filter(function () {
            return this.innerHTML.indexOf("Delete") == 0;
        }).click(function () {
            return confirm("Are you sure you want to delete this record?");
        });
    </script>
   
</asp:Content>
