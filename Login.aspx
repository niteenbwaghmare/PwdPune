<%@ Page Language="C#" AutoEventWireup="true" Inherits="PWdEEBudget.Login" CodeBehind="Login.aspx.cs" %>


<!--
Author: W3layouts
Author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>
<html>
<head>
    <title>EEPwdEastPuneBudget</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="css/EE.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <!-- Graph CSS -->
    <!-- jQuery -->
    <link href='//fonts.googleapis.com/css?family=Roboto:700,500,300,100italic,100,400' rel='stylesheet' type='text/css'>
    <!-- lined-icons -->
    <link href="css/icon-font.min.css" rel="stylesheet" />
    <script src="js/jquery-1.10.2.min.js"></script>
    <style>
        h1, h5 {
            color: white;
            text-shadow: 2px 2px 4px #000000;
        }
    </style>


    <style>
        @media only screen and (min-width:768px) {
            /*desktop*/
            .RememberMeCbDiv {
                font-size: 10px;
                float: left;
            }

            #chkRememberMe {
                width: 15%;
            }
        }

        @media only screen and (max-width:500px) {
            .RememberMeCbDiv {
                font-size: 10px;
                float: left;
            }

            #chkRememberMe {
                width: 15%;
            }

            .DivHeader {
                margin-top: -34% !important;
            }

                .DivHeader h1 {
                    margin-top: -34% !important;
                    font-size: 18px !important;
                }

            .error-top {
                margin: 7em auto !important;
                width: 84% !important;
                padding: 0em 1em !important;
                position: absolute !important;
                left: 8% !important;
                top: -12% !important;
            }

            .error_page {
                position: relative !important;
                padding: 9em 0 3em 0 !important;
                /*width: 84% !important;*/
                width: 100% !important;
            }

            .footer {
                text-align: center !important;
                margin: 15em 0 0em 0 !important;
            }

            .error-btn {
                margin-left: 28% !important;
            }

            .footer {
                font-size: 0.75em !important;
                text-align: left !important;
                margin-left: 11% !important;
                clear: both !important;
                padding-top: 17% !important;
            }

            body {
                overflow: hidden !important;
            }

            .footer p {
                font-size: 0.85em !important;
                line-height: 1.9em !important;
            }
        }

        /*.pwdhead {
            margin-top: 20px;
            margin-bottom: 10px;
        }*/
    </style>

</head>
<body>
    <!--/login-->

    <!--/login-->

    <div class="error_page">
        <!--/login-top-->
        <div style="text-align: center; margin-top: -150px;" class="DivHeader">
            <h1>Welcome to Division Budget Software</h1>
            <h5>P.W East Division Pune</h5>
        </div>
        <div class="error-top">
            <h4 class="inner-tittle page">EEPwdEastPuneBudget</h4>

            <div class="login">
                <h3 class="inner-tittle t-inner">Login</h3>
                <div class="buttons login">
                    <ul>
                        <li><a href="https://www.facebook.com" class="hvr-sweep-to-right">Facebook</a></li>
                        <li class="lost"><a href="https://twitter.com" class="hvr-sweep-to-left">Twitter</a> </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <form id="form1" runat="server">
                    <asp:TextBox ID="txtUserId" runat="server" placeholder="username"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="password"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Please Enter Password" ID="rfvtxtpass" runat="server" ControlToValidate="txtPassword" SetFocusOnError="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator><br />
                    <div class="checkbox RememberMeCbDiv">
                        <label>
                            <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember Me" />

                        </label>
                    </div>

                    <div class="submit">
                        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                    </div>

                    <div class="new">
                        <a href="ResetPassword.aspx">Forgot Password ?</a><p class="sign">Do not have an account ? Sign Up</p>
                    </div>

                </form>
            </div>
        </div>


    </div>
    <br />


    <!--//login-top-->


    <!--//login-->
    <!--footer section start-->
    <div class="footer">
        <div class="error-btn">
            <a class="read fourth">Return to Home</a>
        </div>
        <p>&copy 2016 Augment . All Rights Reserved | Design by <a href="https://www.sghitech.co.in" target="_blank">SGHITECH</a></p>
    </div>
    <!--footer section end-->
    <!--/404-->
    <!--js -->
    <script src="js/jquery.nicescroll.js"></script>
    <script src="js/scripts.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
</body>

</html>
