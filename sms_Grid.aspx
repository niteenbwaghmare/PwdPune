<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="sms_Grid.aspx.cs" Inherits="PWdEEBudget.sms_Grid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div >
    <asp:GridView ID="gdvshow" runat="server" DataKeyNames="Id" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" AlternatingRowStyle-BackColor = "#D3D3D3"  HeaderStyle-BackColor = "#00008B"
CaptionAlign="Top">
            <Columns>
                <asp:TemplateField HeaderText="SenderId" >
                    <ItemTemplate >
                        <asp:Label ID="lblsenderid" runat="server" Text='<%#Eval("SenderId") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MobileNo" >
                    <ItemTemplate>
                        <asp:Label ID="lblmobileno" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lbldescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

  <asp:Button ID="Button4" runat="server" Text="मागे" CssClass="btn btn-primary"   Height="30px" OnClick="Button4_Click"  />
             </ContentTemplate>
          </asp:UpdatePanel>
</asp:Content>
