<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="BillStatus.aspx.cs" Inherits="PWdEEBudget.BillStatus"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="loading" align="center">
                <img alt="progress" src="loader.gif" />
                <br />
                <b>Processing....</b>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
        <ContentTemplate>
            <div class="container" style="margin-top: 20px">
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                <h3 style="text-align: center; color: green; font-size: 22px">Bill Status</h3>
                <div class="row" style="margin-bottom: 1%;">
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Select Head</label>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <asp:DropDownList ID="ddlHeadType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHeadType_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Annuity</asp:ListItem>
                            <asp:ListItem>Building</asp:ListItem>
                            <asp:ListItem>CRF</asp:ListItem>
                            <asp:ListItem>DepositFund</asp:ListItem>
                            <asp:ListItem>DPDC</asp:ListItem>
                            <asp:ListItem>Gat_A</asp:ListItem>
                            <asp:ListItem>Gat_FBC</asp:ListItem>
                            <asp:ListItem>Gat_D</asp:ListItem>
                            <asp:ListItem>Gramvikas(2515)</asp:ListItem>
                            <asp:ListItem>MLA</asp:ListItem>
                            <asp:ListItem>MP</asp:ListItem>
                            <asp:ListItem>Nabard</asp:ListItem>
                            <asp:ListItem>NonResidentialBuilding(2059)</asp:ListItem>
                            <asp:ListItem>ResidentialBuilding(2216)</asp:ListItem>
                            <asp:ListItem>SH & DOR</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Select WorkId</label>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <asp:DropDownList ID="ddlWorkId" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlWorkId_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Budget Year</label>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <asp:DropDownList ID="ddlBudgetYear" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBudgetYear_SelectedIndexChanged1"></asp:DropDownList>
                    </div>

                </div>
                <div class="row" style="margin-bottom: 1%;">
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Work Name</label>
                    </div>
                    <div class="col-sm-12 col-md-10 col-lg-10">
                        <asp:TextBox ID="txtWorkName" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 1%;">
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Sanction Date</label>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <asp:TextBox ID="txtSanctionDate" runat="server" ReadOnly="true" CssClass="form-control" ></asp:TextBox>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Extention in Month</label>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <asp:TextBox ID="txtExtention" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Work Complete Date</label>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <asp:TextBox ID="txtWorkCompleteDate" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 1%;">
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">AA Cost</label>
                    </div>
                    <div class="col-sm-12 col-md-4 col-lg-4">
                        <asp:TextBox ID="txtAAcost" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Total Expenditure</label>
                    </div>
                    <div class="col-sm-12 col-md-4 col-lg-4">
                        <asp:TextBox ID="txtTotalExpenditure" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 1%;">
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Bill To</label>
                    </div>
                    <div class="col-sm-12 col-md-4 col-lg-4">
                        <asp:DropDownList ID="ddlBillTo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBillTo_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Mobile Number</label>
                    </div>
                    <div class="col-sm-12 col-md-4 col-lg-4">
                        <asp:TextBox ID="BilToMobileNumber" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 1%;">
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Bill By</label>
                    </div>
                    <div class="col-sm-12 col-md-2 col-lg-2">
                        <asp:DropDownList ID="ddlBillByPost" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBillByPost_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-sm-12 col-md-4 col-lg-4">
                        <asp:DropDownList ID="ddlBillByName" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBillByName_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <%--<div class="col-sm-12 col-md-2 col-lg-2">
                        <label class="form-control">Mobile Number</label>
                    </div>--%>
                    <div class="col-sm-12 col-md-4 col-lg-4">
                        <asp:TextBox ID="txtBillByNumber" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>


                <div class="row" style="margin-bottom: 1%;">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-lg-12">

                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th style="text-align: center; background-color: #eae8e8; border-radius: 27px;">Bill</th>
                                        <th style="text-align: center; background-color: #eae8e8; border-radius: 27px;">Amount</th>
                                        <th style="text-align: center; background-color: #eae8e8; border-radius: 27px;">Date</th>
                                        <th style="text-align: center; background-color: #eae8e8; border-radius: 27px;">Bill By</th>
                                        <th style="text-align: center; background-color: #eae8e8; border-radius: 27px;">Bill To</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <label class="form-control">First Bill</label></td>
                                        <td>
                                            <asp:TextBox ID="txtBill1Amt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBill1Amt_TextChanged"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill1Date" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill1By" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill1To" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="form-control">Second Bill</label></td>
                                        <td>
                                            <asp:TextBox ID="txtBill2Amt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBill2Amt_TextChanged"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill2Date" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill2By" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill2To" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="form-control">Third Bill</label></td>
                                        <td>
                                            <asp:TextBox ID="txtBill3Amt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBill3Amt_TextChanged"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill3Date" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill3By" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill3To" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="form-control">Fourth Bill</label></td>
                                        <td>
                                            <asp:TextBox ID="txtBill4Amt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBill4Amt_TextChanged"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill4Date" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill4By" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill4To" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="form-control">Fifth Bill</label></td>
                                        <td>
                                            <asp:TextBox ID="txtBill5Amt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBill5Amt_TextChanged"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill5Date" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill5By" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill5To" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="JavaScript:divexpandcollapse('showtr');">
                                                <img id='imgdiv' width="19" border="0" src="Images/plus.png" />
                                            </a>
                                        </td>

                                    </tr>

                                    <tr id="showtr" style="display: none">
                                        <td>
                                            <label class="form-control">Sixth Bill</label></td>
                                        <td>
                                            <asp:TextBox ID="txtBill6Amt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBill6Amt_TextChanged"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill6Date" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill6By" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill6To" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr id="showtr7" style="display: none">
                                        <td>
                                            <label class="form-control">Seventh Bill</label></td>
                                        <td>
                                            <asp:TextBox ID="txtBill7Amt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBill7Amt_TextChanged"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill7Date" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill7By" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill7To" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr id="showtr8" style="display: none">
                                        <td>
                                            <label class="form-control">Eight Bill</label></td>
                                        <td>
                                            <asp:TextBox ID="txtBill8Amt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBill8Amt_TextChanged"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill8Date" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill8By" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill8To" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr id="showtr9" style="display: none">
                                        <td>
                                            <label class="form-control">Nineth Bill</label></td>
                                        <td>
                                            <asp:TextBox ID="txtBill9Amt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBill9Amt_TextChanged"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill9Date" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill9By" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBill9To" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    </tr>                                   


                                    <tr>
                                        <td>
                                            <label class="form-control">Final Bill</label></td>
                                        <td>
                                            <asp:TextBox ID="txtBillFAmt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBillFAmt_TextChanged"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBillFDate" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBillFBy" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBillFTo" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="form-control">Total Amount</label></td>
                                        <td>
                                            <asp:TextBox ID="txtTotalAmt" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <hr style="color: black" />
                        </div>
                    </div>

                </div>
                <div class="row" style="margin-bottom: 1%;">
                    <div class="row">
                        <div class="col-sm-12 col-md-2 col-lg-2">
                            <label class="form-control">Work Status</label>
                        </div>
                        <div class="col-sm-12 col-md-10 col-lg-10">
                            <asp:TextBox ID="txtWorkStatus" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-2 col-lg-2">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="btnSubmit_Click" />
                        </div>                        
                    </div>
                </div>
                <script lang="javascript" type="text/javascript">
                    function divexpandcollapse(divname) {
                        //var div = document.getElementById(divname);
                        var div = document.getElementById(divname);
                        var img = document.getElementById(imgdiv);

                        if (div.style.display == "none") {
                            $(showtr).show();
                            $(showtr7).show();
                            $(showtr8).show();
                            $(showtr9).show();
                            $(showtr10).show();
                            //div.style.display = "inline";
                            //document.getElementById('showtr').style.display = "block";
                            img.src = "Images/minus.png";
                        } else {
                            div.style.display = "none";
                            $(showtr).hide();
                            $(showtr7).hide();
                            $(showtr8).hide();
                            $(showtr9).hide();
                            $(showtr10).hide();
                            img.src = "Images/plus.png";
                        }
                    }
                </script>
                <script>
                    function showDiv() {
                        document.getElementById('welcomeDiv').style.display = "block";
                    }
                </script>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
