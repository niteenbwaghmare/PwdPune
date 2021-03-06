﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Stting_UpAbhiyanta.aspx.cs" Inherits="PWdEEBudget.Stting_UpAbhiyanta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <h3 style="text-align: center; color: darkblue">कार्यकारी उपअभियंता</h3>
            <div style="overflow-x: auto">
                <table id="material" class="table table-bordered mar" style="color: #000; width: 1150px">
                    <tr>
                        <td style="font-weight: bold; color: #000000">
                            <asp:Label ID="Lblno" runat="server" Text="अ.क्र."></asp:Label></td>
                        <td>
                            <asp:TextBox ID="Txtno" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; color: #000000">
                            <asp:Label ID="Lblnm" runat="server" Text="नाव"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="Txtnm" runat="server" CssClass="form-control" PlaceHolder="नाव"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Button ID="Btnsave" runat="server" Text="संपादित करा" CssClass="btn btn-primary" Height="30px" OnClick="Btnsave_Click" />

                            <asp:Button ID="Btnupdate" runat="server" Text="माहिती बदलने" CssClass="btn btn-primary" Height="30px" /></td>

                        <td>
                            <asp:Button ID="Btndelete" runat="server" Text="हाटवा" CssClass="btn btn-primary" Height="30px" />

                            <asp:Button ID="Btncancel" runat="server" Text="रद्द करा" CssClass="btn btn-primary" Height="30px" />
                            <asp:Button ID="Button4" runat="server" Text="मागे" CssClass="btn btn-primary" Height="30px" OnClick="Button4_Click" />
                        </td>
                    </tr>
                </table>
                <table class="table table-bordered mar">
                    <tr>
                        <td style="text-align: center">
                            <asp:GridView ID="GridView1" runat="server" BorderStyle="Solid" AutoGenerateEditButton="true" AutoGenerateDeleteButton="True" BorderWidth="1px" Width="100%" AutoGenerateColumns="false" Font-Names="Arial" Font-Size="11pt" DataKeyNames="AKrmank" AlternatingRowStyle-BackColor="#D3D3D3" HeaderStyle-BackColor="#2c3e50"
                                CaptionAlign="Top" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound1">
                                <HeaderStyle BorderColor="black" BorderStyle="Solid" />
                                <Columns>

                                    <%-- <asp:TemplateField HeaderText="अ.क्र" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1%>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="अ.क्र">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAKrmank" runat="server" Text='<%# Eval("AKrmank")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="नाव">
                                        <ItemTemplate>
                                            <%#Eval("Jilha")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtjilha" runat="server" Text='<%#Eval("Jilha") %>'></asp:TextBox>
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
