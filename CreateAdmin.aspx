<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="CreateAdmin.aspx.cs" Inherits="PWdEEBudget.CreateAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .c {
            font-weight: bold;
            color: #000000;
            width: 100% !important;
            font-size: 16px;
            height: 38px !important;
            line-height: 38px !important;
        }
    </style>
    <style type="text/css">
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            text-align: center;
        }
        tbody, tr, td {
           text-align: left;
       }
        .c {
            width: 100% !important;
            height: 100% !important;
            font-size: 16px;
        }

        .p {
            height: 100% !important;
            font-size: 16px;
        }

        th, td {
            padding: 5px;
            /*width: 100% !important;*/
        }

        th {
            background-color: #2c3e50;
            color: #fff;
            font-size:18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <link href="css/tblmargin.css" rel="stylesheet" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <div class="container" style="width:60%;">
                <table id="material" class="table table-bordered mar" style="color: #000;">
                    <tr>
                        <th colspan="4"><h2>ADD NEW USER</h2></th>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000">अधिकारी/कर्मचा-याचे नाव</td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control c" PlaceHolder="सभासदाचे नाव" required=""></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtUserMName" runat="server" CssClass="form-control c" PlaceHolder="वडिलाचे/पतीचे नाव"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtUserLName" runat="server" CssClass="form-control c" PlaceHolder="आडनाव"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000">मोबईल नं:</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control c" PlaceHolder="मोबाईल नं"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000">इ-मेल:</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control c" PlaceHolder="ई-मेल"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000">पदनाम:</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlpost" runat="server" CssClass="form-control c" OnSelectedIndexChanged="ddlpost_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem>Executive Engineer</asp:ListItem>
                                <asp:ListItem>Deputy Executive Engineer</asp:ListItem>
                                <asp:ListItem>Deputy Engineer</asp:ListItem>
                                <asp:ListItem>Sectional Engineer</asp:ListItem>
                                <asp:ListItem>Junior Engineer</asp:ListItem>
                                <asp:ListItem>Assistant Engineer Class-1</asp:ListItem>
                                <asp:ListItem>Assistant Engineer Class-2</asp:ListItem>
                                <asp:ListItem>Divisional Accountant</asp:ListItem>
                                <asp:ListItem>Senior Auditer</asp:ListItem>
                                <asp:ListItem>Senior Clerk</asp:ListItem>
                                <asp:ListItem>Junior Clerk</asp:ListItem>
                                <asp:ListItem>Contractor</asp:ListItem>
                                <asp:ListItem>Others</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000">कार्यालय:</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddloffice" runat="server" CssClass="form-control c" OnSelectedIndexChanged="ddloffice_SelectedIndexChanged " AutoPostBack="True">
                                <asp:ListItem Text="Select"></asp:ListItem>
                                <asp:ListItem>Division office</asp:ListItem>
                                <asp:ListItem>Sub-division office Baramati</asp:ListItem>
                                <asp:ListItem>Sub-division Medical office Baramati</asp:ListItem>
                                <asp:ListItem>Sub-division office Daund</asp:ListItem>
                                <asp:ListItem>Sub-division office Project Pune</asp:ListItem>
                                <asp:ListItem>Sub-division office No.4 Pune</asp:ListItem>
                                <asp:ListItem>Sub-division office Indapur</asp:ListItem>
                                <asp:ListItem>Sub-division office Bhigwan</asp:ListItem>
                                <asp:ListItem>Sub-division office Shirur</asp:ListItem>
                                <asp:ListItem>Sub-division office office building Daund</asp:ListItem>
                                <asp:ListItem>Others</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                 
                    <tr>
                        <td style="font-weight: bold; color: #000000">युझर नाव:</td>
                        <td colspan="3">
                            <asp:Label ID="lblUserId" runat="server" Text="Label"></asp:Label></td>

                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000">पासवर्ड:</td>
                        <td colspan="3">
                            <asp:Label ID="lblPassword" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>

    <asp:Button ID="Button1" runat="server" Text="संपादित करा" CssClass="btn btn-primary" Height="30px" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="रद्द करा" CssClass="btn btn-danger" Height="31px" CausesValidation="False" />
    <asp:Button ID="Button4" runat="server" Text="मागे" CssClass="btn btn-primary" Height="30px" OnClientClick="JavaScript:window.history.back(1); return false;" />
           
            
      </div>
               <hr />
   <span style="text-align:center;margin-left:60px"><asp:Label ID="lblStatus" runat="server" Font-Size="Large"></asp:Label></span>
            <br /><br />

    <div class="container-fluid" style="width:79%;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
                      <Columns>
                           <asp:TemplateField>
                               <ItemTemplate>
                                   <%# Container.DataItemIndex + 1 %>
                               </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="NO" Visible="false">

                                <EditItemTemplate>
                                    <asp:Label BorderStyle="Ridge" ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Name">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="txtName" Text='<%# Bind("Name") %>'></asp:TextBox>
                                     <asp:Label ID="oldNamelbl" runat="server" Text='<%# Bind("Name") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Mobile No">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="txtMobile" Text='<%# Bind("MobileNo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("MobileNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Email Id">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="txtEmail" Text='<%# Bind("Email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Post">
                                <EditItemTemplate>
                                    <asp:DropDownList runat="server" ID="DDLPost" SelectedValue='<%# Bind("Post") %>'>
                                        <asp:ListItem>Executive Engineer</asp:ListItem>
                                        <asp:ListItem>Deputy Executive Engineer</asp:ListItem>
                                        <asp:ListItem>Deputy Engineer</asp:ListItem>
                                        <asp:ListItem>Sectional Engineer</asp:ListItem>
                                        <asp:ListItem>Junior Engineer</asp:ListItem>
                                        <asp:ListItem>Assistant Engineer Class-1</asp:ListItem>
                                        <asp:ListItem>Assistant Engineer Class-2</asp:ListItem>
                                        <asp:ListItem>Divisional Accountant</asp:ListItem>
                                        <asp:ListItem>Senior Auditer</asp:ListItem>
                                        <asp:ListItem>Senior Clerk</asp:ListItem>
                                        <asp:ListItem>Junior Clerk</asp:ListItem>
                                        <asp:ListItem>Contractor</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="User Id">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="txtUserId" Text='<%# Bind("UserId") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("UserId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Password">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="txtPassword" Text='<%# Bind("Password") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                           
                        </Columns>
                </asp:GridView>
            </div>
         </ContentTemplate>
         </asp:UpdatePanel>
  </div>
    <br />
    <br />
    <script type="text/javascript">
        jQuery("a").filter(function () {
            return this.innerHTML.indexOf("Delete") == 0;
        }).click(function () {
            return confirm("Are you sure you want to delete this record?");
        });
    </script>
</asp:Content>
