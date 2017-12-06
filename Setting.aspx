<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="PWdEEBudget.Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .SettingHead {
            text-align: center;
            background-color: LIGHTGRAY;
            color: rgb(117, 15, 15);
            font-size: 30px;
            border: 1px solid #ddd;
            padding: 2%;
            line-height: 1.42857143;
            vertical-align: top;
        }

        .DivInside {
            text-align: center;
            padding: 10px 0px;
            border: 1px solid lightgray;
        }
        .RowDiv {
            padding-bottom: 1%;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <div class="container" style="color: #000; margin-top: 3%">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <h2 style="text-align: center" class="SettingHead">DBS Settings</h2>
                    </div>
                </div>
                <div class="row RowDiv">
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="dist" runat="server" Height="50px" ImageUrl="img/SettingImg/jilha.jpg" Width="150px" OnClick="dist_Click" />
                            <br />
                            &nbsp;<strong>District</strong></td>
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="taluka" runat="server" Height="50px" ImageUrl="img/SettingImg/taluka.png" Width="150px" OnClick="taluka_Click" />
                            <br />
                            <strong>Taluka</strong></td>
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="ImgUpvibhag" runat="server" Height="50px" ImageUrl="img/SettingImg/depert.png" Width="150px" OnClick="ImgUpvibhag_Click" />
                            <br />
                            Sub Division 
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="type" runat="server" Height="50px" ImageUrl="img/SettingImg/Upbhogtab%20Vibhag.png" Width="150px" OnClick="type_Click" />
                            <br />
                            <strong>Consumer Department</strong><br />
                        </div>
                    </div>
                </div>
                <div class="row RowDiv">
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="leader" runat="server" Height="50px" ImageUrl="img/SettingImg/Representative.jpg" Width="150px" OnClick="leader_Click" />
                            <br />
                            <strong>MLA/MP</strong>
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="lekhashirsh" runat="server" Height="50px" ImageUrl="img/SettingImg/lekhashirs.png" Width="150px" OnClick="lekhashirsh_Click" />
                            <br />
                            <strong>Head</strong>
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="portalsms" runat="server" Height="50px" ImageUrl="img/SettingImg/portalsms.jpg" Width="150px" OnClick="portalsms_Click" />
                            <br />
                            <strong>Portal SMS</strong>
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="sms" runat="server" Height="50px" ImageUrl="~/img/icon/sms.jpg" Width="150px" OnClick="sms_Click" />
                            <br />
                            <strong>SMS</strong>
                        </div>
                    </div>
                </div>
                <div class="row RowDiv">
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="userprofile" runat="server" Height="50px" ImageUrl="img/SettingImg/UserProfile.jpg" Width="150px" OnClick="userprofile_Click" />
                            <br />
                            View User Profile<br />
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="createadmin" runat="server" Height="50px" ImageUrl="~/img/newaccount.png" Width="150px" OnClick="createadmin_Click" />
                            <br />
                            Create Account
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="UpdateWorkID" runat="server" Height="50px" ImageUrl="~/img/iddd.png" Width="150px" OnClick="UpdateWorkID_Click" />
                            <br />
                            Update WorkID & Budget Year 
                        </div>
                    </div>
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="UploadImg" runat="server" Height="50px" ImageUrl="~/imgSli/512px-Icon_-_upload_photo.svg.png" Width="150px" OnClick="UploadImg_Click" />
                            <br />
                            UpLoad Image
                        </div>
                    </div>
               </div>
                <div class="row RowDiv">
                    <div class="col-sm-2 col-md-4 col-lg-3">
                        <div style="text-align: center" class="DivInside">
                            <asp:ImageButton ID="btnBillGenerate" runat="server" Height="50px" ImageUrl="~/img/SettingImg/Bill5.png" Width="150px" OnClick="btnBillGenerate_Click" />
                            <br />
                           Generate  New Bill<br />
                        </div>
                    </div>
                    </div>
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div style="text-align: left">
                            <asp:Button ID="Button4" runat="server" Text="Back" CssClass="btn btn-primary" Height="30px" OnClick="Button4_Click" />
                        </div>
                    </div>
                </div>


            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
