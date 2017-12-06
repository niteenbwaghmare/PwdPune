<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PWdEEBudget.demo" %>

<!DOCTYPE html>

<html>
<head>
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/custom.css" rel="stylesheet" />
    <link href="css/custom.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="css1/normalize.css">
    <link rel="stylesheet" href="css1/foundation.min.css" type="text/css">
    <link rel="stylesheet" href="css1/superfish.css">
    <link rel="stylesheet" href="css1/style.css" type="text/css">
    <link rel="stylesheet" href="js1/slider/flexslider.css" type="text/css" media="screen">

    <link rel="stylesheet" href="js1/slider/testimonialslider.css" type="text/css" media="screen">
    <link href='http://fonts.googleapis.com/css?family=PT+Sans+Caption|Open+Sans' rel='stylesheet' type='text/css'>
    <script src="js1/vendor/custom.modernizr.js"></script>
    <%--Style for Horizontal MenuBar--%>
    <link href="css/IndexStyles/ie10-viewport-bug-workaround.css" rel="stylesheet" />
    <script src="css/IndexStyles/ie-emulation-modes-warning.js"></script>
    <script src="css/IndexStyles/ie10-viewport-bug-workaround.js"></script>
    <%-- End Of Menu--%>
    <script>
        Modernizr.load({
            // test if browser understands media queries
            test: Modernizr.mq('only all'),
            // if not load ie8-grid
            nope: 'css/ie8-grid-foundation-4.css'
        });
    </script>
    <!--Start of Zopim Live Chat Script-->
    <script type="text/javascript">
        window.$zopim || (function (d, s) {
            var z = $zopim = function (c) { z._.push(c) }, $ = z.s =
            d.createElement(s), e = d.getElementsByTagName(s)[0]; z.set = function (o) {
                z.set.
                _.push(o)
            }; z._ = []; z.set._ = []; $.async = !0; $.setAttribute("charset", "utf-8");
            $.src = "//v2.zopim.com/?42996fovzfnLu9ih0AOhEfwPvZjn8yuZ"; z.t = +new Date; $.
            type = "text/javascript"; e.parentNode.insertBefore($, e)
        })(document, "script");
    </script>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Public Works (East) Division, Pune</title>
    <style>
        html {
            background: #fae8bd !important;
        }
    </style>
    <style>
        .navbar-default .navbar-nav > .active > a, .navbar-default .navbar-nav > .active > a:focus, .navbar-default .navbar-nav > .active > a:hover {
            font-family: Arial, Helvetica, sans-serif !important;
            font-size: 18px !important;
            color: #FFFFFF !important;
            font-weight: bold !important;
        }

        .navbar-default .navbar-nav > li > a {
            font-family: Arial, Helvetica, sans-serif !important;
            font-size: 18px !important;
            color: #FFFFFF !important;
            font-weight: bold !important;
        }

        .navbar-default .navbar-nav > .active > a, .navbar-default .navbar-nav > .active > a:focus, .navbar-default .navbar-nav > .active > a:hover {
            color: #FFFFFF !important;
            background-color: #00C6D7 !important;
        }

        .navbar-nav .open .dropdown-menu {
            width: 126px !important;
        }

        .dropdown-menu {
            min-width: 126px !important;
        }

        .container-fluid > .navbar-collapse, .container-fluid > .navbar-header, .container > .navbar-collapse, .container > .navbar-header {
            /* margin-right: 0; */
            margin-left: 28% !important;
        }

        .navbar-header {
            background: #80c3d1 !important;
        }

        .dropdown li a {
            font-family: Arial, Helvetica, sans-serif !important;
            font-size: 18px !important;
            font-weight: bold !important;
            text-transform: none !important;
        }

        #Notif_Ul {
            margin: -4.5px -28px !important;
            list-style: none;
        }



        .notification {
            margin: -55px -7px !important;
        }

        #notifications {
            width: 257px !important;
            position: absolute;
            top: 9px;
            height: 452px;
            left: 3px;
            display: none;
        }

        

        .btn-glyphicon {
            padding: 8px;
            background: #ffffff;
            margin-right: 4px;
        }

        .icon-btn {
            padding: 1px 15px 3px 2px;
            border-radius: 50px;
        }

    </style>

</head>
<body style="background: linear-gradient(#ccc,#fae8bd) !important; padding: 0px; margin: 0px; font-family: helvetica, arial, verdana, sans-serif">


    <div class="row" style="width: 100%; background: linear-gradient(#ccc,#fae8bd)">
        <div class="col-sm-12 col-md-2 col-lg-2">
            <img src="Images/21.png" style="width: 85%; height: 129px; margin-top: 20px;" class="img-responsive hidden-sm hidden-xs" />
            <%--<asp:Image ID="Image1" runat="server" CssClass="img-responsive hidden-sm hidden-xs" ImageUrl="~/logo/cenLogo.gif" />--%>
        </div>
        <div class="col-sm-12 col-sm-12 col-md-8 col-lg-8 text-center" style="margin-top: 30px">
            <h5 style="text-align: -webkit-center; color: black;">GOVT. OF MAHARASHTRA
            </h5>
            <h4 style="text-align: -webkit-center; color: black;">Public Works (East) Division, Pune
            </h4>
            <h5 style="text-align: -webkit-center; color: black;">EEPwdEastPuneBudget
            </h5>
            <%--<img src="logo/Title.png" class="img-responsive" style="height:100%;width:100%"/>--%>
        </div>
        <div class="col-sm-12 col-md-2 col-lg-2">
            <img src="Images/dbsnew10.png" style="height: 162px; width: 100%;" class="img-responsive hidden-sm hidden-xs" />
            <%-- <asp:Image ID="Image2" CssClass="img-responsive" runat="server" ImageUrl="~/Images/DBSnew.png" style="height:100%"/>--%>
        </div>
    </div>


    <form runat="server" id="form11">
        <!-- Static navbar -->
        <div align="center">
            <nav class="navbar navbar-default navbar-static-top" style="background-color: #00C6D7 !important; border-color: #e7e7e7 !important;">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>

                    </div>
                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav" align="center">
                            <li class="active"><a href="#">Home</a></li>
                            <li class="dropdown" style="width: 126px !important;">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Statistics <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                    <li style="width: 126px !important;"><a href="BuildingStatistics.aspx" target="_blank">Building</a></li>
                                    <li style="width: 126px !important;"><a href="RoadStatistics.aspx" target="_blank">Road</a></li>
                                </ul>
                            </li>
                            <li class="dropdown" style="width: 126px !important;">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Maps <span class="caret"></span></a>
                                <ul class="dropdown-menu">

                                    <li style="width: 126px !important;"><a href="/PDF/Ambegaon.pdf" target="_blank">Ambegoan</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/BARAMATI.pdf" target="_blank">Baramati</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/BHOR.pdf" target="_blank">Bhor</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/DHOUND.pdf" target="_blank">Daund</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/HAVELI.pdf" target="_blank">Haveli</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/INDAPUR.pdf" target="_blank">Indapur</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/JUNNUR.pdf" target="_blank">Junnar</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/KHED.pdf" target="_blank">Khed</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/MAVAL.pdf" target="_blank">Maval</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/Mulshi.pdf" target="_blank">Mulshi</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/PURANDAR.pdf" target="_blank">Purandar</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/SHIRUR.pdf" target="_blank">Shirur</a></li>
                                    <li style="width: 126px !important;"><a href="/PDF/WEHELE.pdf" target="_blank">Wehele</a></li>

                                </ul>
                            </li>
                            <li><a href="#contact">Contact</a></li>
                            <li><a href="Login.aspx">Login</a></li>
                            <li id="li_App" style="position: absolute; left: 81%; top: 126%;">

                                <div class="pull-right">
                                    <span>
                                        <ul class="nav navbar-nav notification">
                                            <li class="nav navbar-nav">
                                                <ul id="Notif_Ul">
                                                    <li id="notif_li">

                                                        <!--A CIRCLE LIKE BUTTON TO DISPLAY NOTIFICATION DROPDOWN.-->
                                                        <div id="noti_Button" style="width: 100px;">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/mobile_icon_1.gif" Height="50px" Style="margin-top: -11%;" />
                                                        </div>
                                                        <!--THE NOTIFICAIONS DROPDOWN BOX.-->
                                                        <div id="notifications" style="background-image: url(../img/i_phone_app.png)">

                                                            <div style="height: 100%; overflow-x: auto" id="noti_disp" runat="server">
                                                                <div id="div_sendLink" style="position: absolute;width: 84%;left: 8%;top: 42%;">
                                                                    <table id="tblsendLink" style="position: absolute; top: 44px; width: 100%;">
                                                                        <tbody>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox runat="server" ID="txtMobileNo" placeholder="+91xxxxxxxx" CssClass="form-control" Font-Size="1.875em"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <a class="btn icon-btn btn-info" href="#"><span class="glyphicon btn-glyphicon glyphicon-send img-circle text-info"></span>
                                                <asp:Button runat="server" ID="btnsendLink" Text="Send Link" OnClick="btnsendLink_Click" Style="border: none; background-color: rgba(255, 0, 0, 0);" /></a>
                                                                                </td>
                                                                            </tr>
                                                                            <%-- <tr>
                                                                                <td>
                                                                                    <asp:ImageButton ID="Img_btn_downloadApp" Style="height: 40px; height: 40px;" runat="server" CssClass="img-responsive img-circle" OnClick="Img_btn_downloadApp_Click" AlternateText="Download App" ImageUrl="~/Images/Download (3).png" />
                                                                                </td>
                                                                            </tr>--%>
                                                                        </tbody>
                                                                    </table>
                                                                    <a class="btn icon-btn btn-default" href="AndroidApplication/DBS.apk" style="position: relative; top: 173px; width: 92%;"><span class="glyphicon btn-glyphicon glyphicon-save img-circle text-muted"></span>Download</a>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </li>

                                                </ul>
                                            </li>
                                        </ul>
                                    </span>

                                </div>
                            </li>

                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
            </nav>
        </div>

    </form>


    <!-- #region Jssor Slider Begin -->
    <!-- Generator: Jssor Slider Maker -->
    <!-- Source: http://www.jssor.com -->
    <!-- This is deep minimized code which works independently. -->
    <%--<script src="http://localhost:2797/jsSli/jquery-1.11.3.min.js"></script>
    <script src="http://localhost:2797/jsSli/jssor.slider-21.1.6.debug.js"></script>
    <script src="http://localhost:2797/jsSli/jssor.slider-21.1.6.min.js"></script>
    <script src="http://localhost:2797/jsSli/jssor.slider-21.1.6.mini.js"></script>--%>
    <script type="text/javascript" src="Scripts/indexpage.js"></script>

    <style>
        .jssora05l, .jssora05r {
            display: block;
            position: absolute;
            width: 40px;
            height: 40px;
            cursor: pointer;
            background: url('imgSli/a17.png') no-repeat;
            overflow: hidden;
        }

        .jssora05l {
            background-position: -10px -40px;
        }

        .jssora05r {
            background-position: -70px -40px;
        }

        .jssora05l:hover {
            background-position: -130px -40px;
        }

        .jssora05r:hover {
            background-position: -190px -40px;
        }

        .jssora05l.jssora05ldn {
            background-position: -250px -40px;
        }

        .jssora05r.jssora05rdn {
            background-position: -310px -40px;
        }

        .jssora05l.jssora05lds {
            background-position: -10px -40px;
            opacity: .3;
            pointer-events: none;
        }

        .jssora05r.jssora05rds {
            background-position: -70px -40px;
            opacity: .3;
            pointer-events: none;
        }

        .jssort01 .p {
            position: absolute;
            top: 0;
            left: 0;
            width: 72px;
            height: 72px;
        }

        .jssort01 .t {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            border: none;
        }

        .jssort01 .w {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
        }

        .jssort01 .c {
            position: absolute;
            top: 0;
            left: 0;
            width: 68px;
            height: 68px;
            border: #000 2px solid;
            box-sizing: content-box;
            background: url('img/t01.png') -800px -800px no-repeat;
            _background: none;
        }

        .jssort01 .pav .c {
            top: 2px;
            _top: 0;
            left: 2px;
            _left: 0;
            width: 68px;
            height: 68px;
            border: #000 0 solid;
            _border: #fff 2px solid;
            background-position: 50% 50%;
        }

        .jssort01 .p:hover .c {
            top: 0;
            left: 0;
            width: 70px;
            height: 70px;
            border: #fff 1px solid;
            background-position: 50% 50%;
        }

        .jssort01 .p.pdn .c {
            background-position: 50% 50%;
            width: 68px;
            height: 68px;
            border: #000 2px solid;
        }

        * html .jssort01 .c, * html .jssort01 .pdn .c, * html .jssort01 .pav .c {
            width: 72px;
            height: 72px;
        }

        .auto-style3 {
            text-align: center;
            width: 868px;
            margin-left: 75px;
        }

        .auto-style5 {
            text-align: center;
            width: 867px;
        }

        .auto-style7 {
            float: right;
            width: 230px;
            height: 29px;
        }

        .auto-style8 {
            width: 41px;
        }

        .auto-style9 {
            height: 226px;
        }

        .auto-style10 {
            background: url(../images/header-bg.png) repeat-x;
            background: url('images/header-bg.png') repeat-x;
            height: 176px;
        }

        .row {
            width: 100%;
            margin-left: auto;
            margin-right: auto;
            margin-top: 0;
            margin-bottom: 0;
            max-width: 100% !important;
        }
    </style>


    <%--<div style="position: fixed; right: 0;">
            
        </div>--%>
    <%--  <div class="pull-right" style="margin-top: 0%; margin-right: 12%;">
            <span>
                <ul class="nav navbar-nav notification">
                    <li class="nav navbar-nav">
                        <ul id="Notif_Ul">
                            <li id="notif_li">

                                <!--A CIRCLE LIKE BUTTON TO DISPLAY NOTIFICATION DROPDOWN.-->
                                <div id="noti_Button">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Download (3).png" Height="50px" Style="margin-top: 25%;" />
                                </div>
                                <!--THE NOTIFICAIONS DROPDOWN BOX.-->
                                <div id="notifications">

                                    <div style="height: 300px; overflow-x: auto" id="noti_disp" runat="server">
                                        <asp:ImageButton ID="Img_btn_downloadApp" Style="height: 40px; height: 40px; margin-top: -16px; margin-right: 75px;" runat="server" CssClass="img-responsive img-circle" OnClick="Img_btn_downloadApp_Click" AlternateText="Download App" ImageUrl="~/Images/Download (3).png" />
                                    </div>

                                </div>
                            </li>

                        </ul>
                    </li>
                </ul>
            </span>

        </div>--%>
    <%--</form>--%>



    <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 800px; height: 456px; overflow: hidden; visibility: hidden; background-color: white;">
        <!-- Loading Screen -->
        <div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
            <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
            <div style="position: absolute; display: block; background: url('img/loading.gif') no-repeat center center; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
        </div>
        <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 800px; height: 356px; overflow: hidden;">
            <div data-p="144.50">
                <img data-u="image" src="imgSli/pwd-maharashtra_.jpg" />
                <img data-u="thumb" src="imgSli/pwd-maharashtra_.jpg" />
            </div>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/Baramati_Rto_1.jpg" />
                <img data-u="thumb" src="imgSli/Baramati_Rto_1.jpg" />
            </div>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/Baramati_Rto_.jpg" />
                <img data-u="thumb" src="imgSli/Baramati_Rto_.jpg" />
            </div>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/Mumbia_Pune eway.jpg" />
                <img data-u="thumb" src="imgSli/Mumbia_Pune eway.jpg" />
            </div>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/Shirur _Office.JPG" />
                <img data-u="thumb" src="imgSli/Shirur _Office.JPG" />
            </div>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/Iadies_Hostel Baramati.jpg" />
                <img data-u="thumb" src="imgSli/Iadies_Hostel Baramati.jpg" />
            </div>
            <a data-u="any" href="http://www.jssor.com" style="display: none">Image Gallery</a>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/Rto Baramati_2.JPG" />
                <img data-u="thumb" src="imgSli/Rto Baramati_2.JPG" />
            </div>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/Pargaon_Bridge .JPG" />
                <img data-u="thumb" src="imgSli/Pargaon_Bridge .JPG" />
            </div>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/Shirur_.JPG" />
                <img data-u="thumb" src="imgSli/Shirur_.JPG" />
            </div>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/Daund Admin 1.JPG" />
                <img data-u="thumb" src="imgSli/Daund Admin 1.JPG" />
            </div>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/100_Bedded_Ladies_Hospital_Baramati_.png" />
                <img data-u="thumb" src="imgSli/100_Bedded_Ladies_Hospital_Baramati_.png" />
            </div>
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="imgSli/Pwd_mage_.JPG" />
                <img data-u="thumb" src="imgSli/Pwd_mage_.JPG" />
            </div>
        </div>
        <!-- Thumbnail Navigator -->
        <div data-u="thumbnavigator" class="jssort01" style="position: absolute; left: 0px; bottom: 0px; width: 800px; height: 100px;" data-autocenter="1">
            <!-- Thumbnail Item Skin Begin -->
            <div data-u="slides" style="cursor: default;">
                <div data-u="prototype" class="p">
                    <div class="w">
                        <div data-u="thumbnailtemplate" class="t"></div>
                    </div>
                    <div class="c"></div>
                </div>
            </div>
            <!-- Thumbnail Item Skin End -->
        </div>
        <!-- Arrow Navigator -->
        <span data-u="arrowleft" class="jssora05l" style="top: 158px; left: 8px; width: 40px; height: 40px;"></span>
        <span data-u="arrowright" class="jssora05r" style="top: 158px; right: 8px; width: 40px; height: 40px;"></span>
    </div>




    <script type="text/javascript">jssor_1_slider_init();</script>

    <%--Script For Notification--%>
    <script type="text/javascript">
        // ANIMATEDLY DISPLAY THE NOTIFICATION COUNTER.
        $(document).ready(function () {
            //$('#notifications').hide();
           
            $('#Image1').mouseover(function () {

                // (SHOW OR HIDE) NOTIFICATION WINDOW.
                $('#notifications').show('fast', 'linear', function () {
                   
                });               
            });

            // HIDE NOTIFICATIONS WHEN CLICKED ANYWHERE ON THE PAGE.
            $('#li_App').mouseleave(function () {
                $('#notifications').hide();

            });
            $('#txtMobileNo').mouseenter(function () {
                $('#notifications').show();

            });
        });


    </script>
    <!-- #endregion Jssor Slider End -->

    <div class="footer" style="margin-top: -46px; background-color: #fae8bd !important;">
        <%--<div class="row">
    <div class="large-12 twelve columns">
      <div class="row">
        <div class="large-4 four small-12 columns">
            <div >
                <h3 class="text" style="color: white;">Main Office Address:</h3>
                <hr />
                 <h6 class="text" style="color: white;"> Public Works (East) Division,</h6>
                <h6 class="text" style="color: white;">Central Building, Camp, Pune, Maharashtra 411001.</h6>
                <h6 class="text" style="color: white;">Email :info@eepwdeastpunebudget.com</h6>
                <h6 class="text" style="color: white;">Phone No. 020-26122457 </h6>
            </div>
       
                           <a href="http://www.reliablecounter.com" target="_blank"><img src="http://www.reliablecounter.com/count.php?page=www.pwdpatansthalatur.com&digit=style/plain/12/&reloads=0" alt="www.reliablecounter.com" title="www.reliablecounter.com" style="height:30px;width:80px" border="0"></a><br /><a href="http://www.analogmix.com/mastering.html" target="_blank" style="font-family: Geneva, Arial; font-size: 9px; color: #330010; text-decoration: none;"></a>  
      
              </div>
       
      </div>
    </div>
  </div>--%>
        <div class="theme-credits">
            <p style="color: #FFEB3B;">&copy;  All rights reserved by <a href="#" style="color: white;">Public Works (East) Division, Pune</a> Design by: <a href="http://www.sghitech.co.in/" style="color: white;">SGHI-TECH</a></p>
        </div>
    </div>
</body>
</html>
