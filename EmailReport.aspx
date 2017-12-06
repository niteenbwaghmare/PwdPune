<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="EmailReport.aspx.cs" Inherits="PWdEEBudget.EmailReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        th {
            font-size: 18px;
            text-align: center;
        }

        td {
            text-align: left;
        }


    </style>
    <style>
        @media only screen and (min-width:768px) {
            /*desktop*/
           
        }

        @media only screen and (max-width:500px) {
           
            #test {
                width: 57% !important;
                height: auto !important;
                position: fixed !important;
                left: -45% !important;
                background: linear-gradient(rgb(204, 204, 204), rgb(250, 232, 189)) !important;
                display: block !important;
            }

        }

        /*.pwdhead {
            margin-top: 20px;
            margin-bottom: 10px;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: #2c3e50; color: white; text-align: center; font-family: Tahoma; font-style: inherit; font-size: 25px; padding: 5px">Sent Mail Report </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" PageSize="20" AllowSorting="true" AllowPaging="true" EmptyDataText="No Employee Data Available!!!" Width="100%" BackColor="White" GridLines="Both" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
            <Columns>
                <%--<asp:CommandField ShowEditButton="true" ItemStyle-Width="3%" />
                    <asp:CommandField ShowDeleteButton="true" ItemStyle-Width="5%" />--%>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" SortExpression="ID" ItemStyle-Width="5%" />
                <asp:BoundField DataField="Mail_From" HeaderText="Mail From" SortExpression="Mail_From" ItemStyle-Width="30%" />
                <asp:BoundField DataField="Mail_To" HeaderText="Mail To" SortExpression="Mail_To" ItemStyle-Width="20%" />
                <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" ItemStyle-Width="20%" />
                <asp:BoundField DataField="Message" HeaderText="Message" SortExpression="Message" ItemStyle-Width="20%" />
                <asp:BoundField DataField="DateTime" HeaderText="Date&Time" SortExpression="DateTime" ItemStyle-Width="17%" />

            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EmptyDataRowStyle BorderColor="Red" BorderStyle="Solid" ForeColor="Red" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#2c3e50" Font-Bold="true" Font-Size="12px" ForeColor="White" HorizontalAlign="Left" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />

    </div>
</asp:Content>
