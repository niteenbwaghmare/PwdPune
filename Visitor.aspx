<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Visitor.aspx.cs" Inherits="PWdEEBudget.Visitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
     <h3 style="text-align:center;color:darkblue">Visitor Information</h3>
    <div style="overflow-x:auto">
<table id="material" class="table table-bordered mar" style="color:#000" >
       <tr>
          <td style="font-weight: bold; color: #000000">Name:</td>
          <td><asp:TextBox ID="Txtnm" runat="server" CssClass="form-control" PlaceHolder="Name" ></asp:TextBox></td>
      </tr>
       <tr>
          <td style="font-weight: bold; color: #000000">Designation</td>
          <td><asp:TextBox ID="Txtdesig" runat="server" CssClass="form-control" PlaceHolder="Designation"></asp:TextBox></td>
      </tr>
       <tr>
          <td style="font-weight: bold; color: #000000">Address</td>
          <td><asp:TextBox ID="Txtadd" runat="server" TextMode="MultiLine" CssClass="form-control" PlaceHolder="Address" ></asp:TextBox></td>
      </tr>
       <tr>
          <td style="font-weight: bold; color: #000000">Mobile</td>
          <td><asp:TextBox ID="Txtmob" runat="server" CssClass="form-control" PlaceHolder="Mobile" ></asp:TextBox></td>
      </tr>
       <tr>
          <td style="font-weight: bold; color: #000000">Office</td>
          <td><asp:TextBox ID="Txtoff" runat="server" CssClass="form-control" PlaceHolder="Office" ></asp:TextBox></td>
      </tr>
       <tr>
          <td style="font-weight: bold; color: #000000">Work</td>
          <td><asp:TextBox ID="Txtwork" runat="server" CssClass="form-control" PlaceHolder="Work"></asp:TextBox></td>
       </tr>
       <tr>
           <td style="font-weight: bold; color: #000000">Consultant person</td>
           <td><asp:TextBox ID="Txtcp" runat="server" CssClass="form-control" PlaceHolder="Consultant person" ></asp:TextBox></td>
       </tr>
       <tr>
           <td style="font-weight: bold; color: #000000">Consultant designation</td>
           <td><asp:TextBox ID="Txtcd" runat="server" CssClass="form-control" PlaceHolder="Consultant designation"></asp:TextBox></td>
       </tr>
        <tr>
            <td style="font-weight: bold; color: #000000">Day</td>
            <td><asp:TextBox ID="Txtday" runat="server" CssClass="form-control" PlaceHolder="Day"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="font-weight: bold; color: #000000">Time</td>
            <td><asp:TextBox ID="Txttime" runat="server" CssClass="form-control" PlaceHolder="Time" ></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="Btnok" runat="server" Text="OK" CssClass="btn btn-primary" Height="30px" OnClick="Btnok_Click1" />
                <asp:Button ID="Btncancel" runat="server" Text="Cancel" CssClass="btn btn-primary" Height="31px" />
                  <asp:Button ID="Button4" runat="server" Text="मागे" CssClass="btn btn-primary"   Height="30px" OnClick="Button4_Click" />
            </td>
        
       </tr>
  </table>
        </div>

             </ContentTemplate>
          </asp:UpdatePanel>
</asp:Content>
