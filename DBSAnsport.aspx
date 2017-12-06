<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBSAnsport.aspx.cs" Inherits="PWdEEBudget.DBSAnsport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DBS Answer Portal</title>

    <style type="text/css">
        #Heading {
            color: #e6120e;
           
            font-weight: 500;
            font-size: 36px;
            margin-top: 1%;
            margin-bottom: 1%;
            display: inline-block;
            max-width: 100%;
            font-weight: 700;
        }
        .Grid:first-child tr > th
        {
            background-color: lightgray;
            color: rgb(117, 15, 15);
            font-size: 20px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">

    <table id="tblAnsReport" class="table table-bordered mar" style="border: 2px solid gray;margin-top:1%;width:100%; ">
        <tr>
            <th style="background: linear-gradient(rgb(204, 204, 204), rgb(250, 232, 189));">
                <asp:Label runat="server" ID="Heading" Text="सार्वजनिक बांधकाम पूर्व विभाग पुणे"></asp:Label>
                 <a href="Login.aspx" style="float: right; margin-right: 2%; margin-top: 1%;">Login</a>
            </th>
           
        </tr>
        <tr>
            <td>
       <asp:GridView runat="server" ID="GridAns"  AutoGenerateColumns="false" DataKeyNames="Complaint_Id" CssClass="Grid" Width="100%">
           <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name"  />
                <asp:BoundField DataField="MenuType" HeaderText="Menu Type" />
                <asp:BoundField DataField="Error_PageName" HeaderText="Error Page Name" />
                <asp:BoundField DataField="Error_PageUrl" HeaderText="Error Url" />
                <asp:BoundField DataField="Error_Description" HeaderText="Error Description" />
                <asp:BoundField DataField="ComplaintDate" HeaderText="Date of Complaint" />
                <asp:BoundField DataField="Error_Ans" HeaderText="Ans Description" />
                <asp:BoundField DataField="Ans_ByName" HeaderText="Ans By" />
                <asp:BoundField DataField="Ans_Date" HeaderText="Date of Ans"  />
               
               
            </Columns>
           <EmptyDataTemplate>
               <asp:Label ID="Label1" runat="server" Text="No Data Found....Invalid complaint Id" CssClass="blink_me"></asp:Label>
           </EmptyDataTemplate>
           <EmptyDataRowStyle BackColor="Yellow" ForeColor="Red" />
           <HeaderStyle HorizontalAlign="Center" />
       </asp:GridView>                
            </td>           
        </tr>
    </table>
  
    </form>
</body>
</html>
