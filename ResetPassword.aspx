<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="PWdEEBudget.ResetPassword" %>

<!DOCTYPE HTML>
<html lang="en">
<head>
    <title>EEPwdEastPuneBudget</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">

    <style>
        h1, h5 {
            color: white;
            text-shadow: 2px 2px 4px #000000;
            font-family: 'Roboto', sans-serif;
        }

        h1 {
            font-size: 36px;
        }

        h5 {
            font-size: 14px;
        }
    </style>

</head>
<body>
    <div class="form-gap" style="padding-top: 70px; background: linear-gradient(#ccc,#fae8bd); padding: 11em 0;"></div>
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="error_page" style="margin: -23em auto;">
                    <!--/login-top-->
                    <div style="text-align: center; margin-top: -150px;" class="DivHeader">
                        <h1>Welcome to Division Budget Software</h1>
                        <h5>P.W East Division Pune</h5>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="text-center">
                                <h3><i class="fa fa-lock fa-4x"></i></h3>
                                <h2 class="text-center">Forgot Password?</h2>
                                <p>You can get your password from here.</p>
                                <div class="panel-body">

                                    <form id="form1" runat="server" role="form" autocomplete="off" class="form">
                                        <div id="DivSendOTP" runat="server">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope color-blue"></i></span>
                                                    <asp:TextBox ID="txtUserId" runat="server" placeholder="userid" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUserId_TextChanged" />

                                                </div>
                                                <div class="input-group" style="padding-top: 2%;">
                                                    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope color-blue"></i></span>
                                                    <asp:TextBox ID="txtMobileNumber" runat="server" placeholder="mobile number" CssClass="form-control" />
                                                </div>
                                                <%--<div class="input-group" style="padding-top: 2%;">
                                                    <asp:RadioButtonList ID="rbType" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Alphanumeric" Value="1" Selected="True" />
                                                        <asp:ListItem Text="Numeric" Value="2" />
                                                    </asp:RadioButtonList>
                                                </div>--%>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnGetOTP" CssClass="btn btn-lg btn-primary btn-block" Text="Get OTP" runat="server" OnClick="btnGetOTP_Click" />
                                            </div>
                                        </div>
                                        <div id="DivValidateOTP" runat="server" style="display: none;">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope color-blue"></i></span>
                                                    <asp:TextBox ID="txtOTP" runat="server" placeholder="enter OTP" CssClass="form-control" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnSubmitOTP" CssClass="btn btn-lg btn-primary btn-block" Text="Submit OTP" runat="server" OnClick="btnSubmitOTP_Click" />
                                            </div>
                                        </div>

                                        <input type="hidden" class="hide" name="token" id="token" value="">
                                    </form>

                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</body>
</html>



