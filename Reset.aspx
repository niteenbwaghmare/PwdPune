<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="PWdEEBudget.Reset" %>

<!DOCTYPE HTML>
<html>
<head>
<title>EEPwdEastPuneBudget</title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Augment Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
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
<!-- //lined-icons -->
<script src="js/jquery-1.10.2.min.js"></script>
<!--clock init-->
</head> 
<body>
								<!--/login-->
								
									   <div class="error_page">
												<!--/login-top-->
												
													<div class="error-top" style="margin-top: 247px;">
													<h4 class="inner-tittle page">EEPwdEastPuneBudget</h4>
													     <form id="frm" runat="server">
															 <table class="table table-bordered mar" style="width:350px">
        
           <tr>
               
               <td style="font-weight: bold; color: #000000">New Password  </td>
              
               <td >
                   <asp:TextBox ID="txtnewPswd" CssClass="form-control"  runat="server"></asp:TextBox>
                  
               </td>
              
           </tr>
            <tr>
                
               <td style="font-weight: bold; color: #000000">Confirm New Password  </td>
               
               <td >
                   <asp:TextBox ID="txtConfirmNPswd" CssClass="form-control"  runat="server"></asp:TextBox>
               </td>
               
           </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="OK" OnClick="btnSubmit_Click" />
                   
                    <asp:Label ID="Label1" runat="server"  Visible="False"></asp:Label>
                   
               </td>
            </tr>
               
            
        </table>	
                                                             </form>
														</div>

														
													</div>
													
													
												<!--//login-top-->
										  
						
										  	<!--//login-->
										    <!--footer section start-->
										<div class="footer">
												<div class="error-btn">
															<a class="read fourth" href="Login.aspx">Return to Home</a>
															</div>
										   <p>&copy 2016 Augment . All Rights Reserved | Design by <a href="www.sghitech.co.in" target="_blank">SGHITECH</a></p>
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

