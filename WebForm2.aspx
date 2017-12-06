<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="PWdEEBudget.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div>
        <h1>Online User List</h1>
        <asp:GridView runat="server" ID="gridOnlineUser"></asp:GridView>
    </div>
</asp:Content>
