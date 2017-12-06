<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="PWdEEBudget.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/font-awesome.css" rel="stylesheet" />
  
    <style>

        .separator {
    border-right: 1px solid #dfdfe0; 
}
.icon-btn-save {
    padding-top: 0;
    padding-bottom: 0;
}
.input-group {
    margin-bottom:10px; 
}
.btn-save-label {
    position: relative;
    left: -12px;
    display: inline-block;
    padding: 6px 12px;
    background: rgba(0,0,0,0.15);
    border-radius: 3px 0 0 3px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <asp:Label ID="lblSaveStatus" runat="server"></asp:Label>
    <div style="width: 100px; align: center;"></div>       
               
    

    <div class="container bootstrap snippet">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-6 col-md-offset-2">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <span class="glyphicon glyphicon-th"></span>
                        Change password   
                    </h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-6 separator social-login-box"> <br>
                           <%--<img alt="" class="img-thumbnail" src="http://bootdey.com/img/Content/avatar/avatar1.png">--%>
                            <img alt="" class="img-thumbnail" src="logo/Change-Password.png">                        
                        </div>                        
                        <div style="margin-top:60px;" class="col-xs-6 col-sm-6 col-md-6 login-box">
                         <div class="form-group">
                            <div class="input-group">
                              <div class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></div>
                                <asp:TextBox ID="psw" runat="server" TextMode="Password" AutoPostBack="true" EnableViewState="true" Class="form-control" placeholder="Enter old Password" OnTextChanged="psw_TextChanged" />                              
                            </div>
                          </div>
                          <div class="form-group">
                            <div class="input-group">
                              <div class="input-group-addon"><span class="glyphicon glyphicon-log-in"></span></div>
                                <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" EnableViewState="true" Class="form-control" placeholder="Enter New Password" Enabled="false" />                              
                            </div>
                          </div>
                            <div class="form-group">
                            <div class="input-group">
                              <div class="input-group-addon"><span class="glyphicon glyphicon-log-in"></span></div>                                
                               <asp:TextBox ID="txtReEnterPass" runat="server" TextMode="Password" EnableViewState="true" Class="form-control" Enabled="false" placeholder="Re-Enter Password" />
                                <asp:CompareValidator ID="comparepass" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtReEnterPass" Type="String" Operator="Equal" SetFocusOnError="true" ErrorMessage="Password didn't Match!!" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                            </div>
                          </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-6"></div>
                        <div class="col-xs-6 col-sm-6 col-md-6">                            
                                <asp:Button CssClass="btn icon-btn-save btn-success" ID="btnChangePass" runat="server" OnClick="btnChangePass_Click" Text="Save" Enabled="false"/>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
    
</asp:Content>
