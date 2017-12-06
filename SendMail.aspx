<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="PWdEEBudget.WebForm1" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="js/jquery.ui.core.js" type="text/javascript"></script>
    <script src="js/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="js/jquery.ui.button.js" type="text/javascript"></script>
    <script src="js/jquery.ui.position.js" type="text/javascript"></script>
    <script src="js/jquery.ui.autocomplete.js" type="text/javascript"></script>
    <script src="js/jquery.ui.combobox.js" type="text/javascript"></script>
    <script src="js/jquery-1.8.2.min.js"></script>
   
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>--%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <%--<script src="content/js/jquery-1.12.1.min.js.js"></script>
    <script src="content/js/bootstrap.min.js"></script>
    <link href="content/css/bootstrap.min.css" rel="stylesheet" />--%>
    <style>
        .Custom_DDL {
            display: block;
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

        .modal-header, h4, .close {
            background-color: #5cb85c;
            color: white !important;
            text-align: center;
            font-size: 30px;
        }

        .modal-footer {
            background-color: #f9f9f9;
        }

        .navbar-default {
            background-color: black;
            border-color: #e7e7e7;
        }

        a {
            color: #337ab7;
            font-weight: 400;
        }

        .nav > li > a {
            position: relative;
            display: block;
            padding: 10px 15px;
        }

        a {
            background-color: transparent;
        }

        * {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }

        .Inlineform-control {
            display: block !important;
            width: 100% !important;
            height: 34px !important;
            padding: 6px 12px !important;
            font-size: 14px !important;
            line-height: 1.42857143 !important;
            background-color: #fff !important;
            background-image: none !important;
            border: 1px solid #ccc !important;
            border-radius: 4px !important;
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075) !important;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s !important;
        }
    </style>
    <style>
         @media only screen and (min-width:768px) {
             /*desktop*/

         }

         @media only screen and (max-width:500px) {           

             .btnform {
                 width: 45% !important;                 
             }
            #btnAdd {
                margin: 5px 0px 0px -18px !important;
            }
             
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <asp:Label ID="lblSaveStatus" runat="server"></asp:Label>
    <div style="width: 100px; align: center;"></div>
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header" style="padding: 35px 50px;">
                <h4><span class="glyphicon glyphicon-envelope"></span>&nbsp;Send Mail</h4>
            </div>
            <div class="modal-body" style="padding: 40px 50px;">
                <form role="form">
                    <div class="form-group">
                        <label for="usrname"><span class="glyphicon glyphicon-user"></span>&nbsp;From</label>
                        <asp:TextBox ID="usrnameFrom" runat="server" Class="form-control" Text="eepwdeastpune@gmail.com" ReadOnly="true" OnTextChanged="usrnameFrom_TextChanged" />
                        <%--<input type="text" class="form-control" id="usrname" placeholder="Enter email" value="eepwdeastpune@gmail.com" readonly="true" />--%>
                    </div>
                    <div class="form-group">
                        <label for="psw"><span class="glyphicon glyphicon-eye-open"></span>&nbsp;Password</label>
                        <asp:TextBox ID="psw" runat="server" TextMode="Password" EnableViewState="true" Class="form-control" placeholder="Enter Password" />
                        <%--<input type="password" class="form-control" id="psw" placeholder="Enter password"/>--%>
                    </div>
                    <div class="form-group">
                        <label for="txtSubject"><span class="glyphicon glyphicon-th"></span>&nbsp;Subject</label>
                        <asp:TextBox ID="txtSubject" runat="server" Class="form-control" placeholder="Enter Subject" />
                    </div>
                    <div class="form-group">
                        <label for="DropDownCheckBoxes1"><span class="glyphicon glyphicon-th-list"></span>&nbsp;Select</label><br />
                        <%--<asp:TextBox ID="ddlAvailableEmail" runat="server" Class="form-control" />--%>
                        <%-- <asp:DropDownList ID="ddlAvailableEmail" runat="server" Class="form-control"></asp:DropDownList>
                                &nbsp;&nbsp;--%>
                        <asp:DropDownCheckBoxes ID="DropDownCheckBoxes1" runat="server"
                            AddJQueryReference="True" UseButtons="False" UseSelectAllNode="True" CssClass="Inlineform-control">
                            <Style SelectBoxWidth="200" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                            <Texts SelectBoxCaption="Select Email" />
                        </asp:DropDownCheckBoxes>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />--%>
                        <input type="button" id="btnAdd" value="Add" onclick="updateTextArea()" />
                        <%--<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" />--%>
                        <%--<input type="text" class="form-control" id="usrnameTo" placeholder="Enter email"/>--%>
                    </div>
                    <div class="form-group">
                        <label for="usrnameTo"><span class="glyphicon glyphicon-user"></span>To</label>
                        <asp:TextBox ID="usrnameTo" runat="server" Class="form-control" placeholder="Enter Email" />
                        <%--<input type="text" class="form-control" id="usrnameTo" placeholder="Enter email"/>--%>
                    </div>
                    <div class="form-group">
                        <label for="txtMessage"><span class="glyphicon glyphicon-comment"></span>&nbsp;Message</label>
                        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Style="resize: none;" Class="form-control" placeholder="Enter Message" />
                        <%--<input type="text" class="form-control" id="usrnameTo" placeholder="Enter email"/>--%>
                    </div>
                    <div class="form-group">
                        <label for="FileUpload1"><span class="glyphicon glyphicon-paperclip"></span>&nbsp;Attachment</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="true" Class="form-control" placeholder="Enter Message" />
                    </div>
                    <%-- <button type="submit" onclick="btnSendMail_Click" runat="server" class="btn btn-success btn-block"><span class="glyphicon glyphicon-off"></span>Send Mail</button>--%>
                    <asp:Button ID="btnSendMail" runat="server" Class="btn btn-success btn-default pull-left btnform" Text="Send Via Mail" OnClick="btnSendMail_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger btn-default pull-left btnform" Style="margin-left: 10px;" OnClientClick="JavaScript:window.history.back(1); return false;" />
                    <br />
                </form>
            </div>
        </div>
    </div>


    <script>
      
        function updateTextArea() {
            var allVals = [];            
            $('[id*=DropDownCheckBoxes1] :checked').each(function () {
                allVals.push($(this).val());
            });
            $('[id*=usrnameTo]').val(allVals);
        };
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ddlAvailableEmail").change(function () {
                $("#usrnameTo").val($(this).val());
            })
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
            $('[id*=usrnameTo]').val(allVals);
        };
    </script>
   
</asp:Content>
