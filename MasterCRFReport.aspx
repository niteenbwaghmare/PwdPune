<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="MasterCRFReport.aspx.cs" Inherits="PWdEEBudget.MasterCRFReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/css/elements.css" rel="stylesheet" />
    <style>
        @media print {
            input {
                display: none;
            }
        }
    </style>
    <style type="text/css">
        .trrr tr:hover {
            background-color: #75becb;
        }

        .pj {
            /*text-shadow: 0 1px 0 #ccc,
                            0 2px 0 #c9c9c9,
                            0 3px 0 #bbb,
                            0 4px 0 #b9b9b9,
                            0 5px 0 #aaa,
                            0 6px 1px rgba(0,0,0,.1),
                            0 0 5px rgba(0,0,0,.1),
                            0 1px 3px rgba(0,0,0,.3),
                            0 3px 5px rgba(0,0,0,.2),
                            0 5px 10px rgba(0,0,0,.25),
                            0 10px 10px rgba(0,0,0,.2),
                            0 20px 20px rgba(0,0,0,.15);*/
            font-size: 50px;
            color: #0e0505;
        }

        th {
            color: #fff;
            background-color: #2c3e50;
            font-weight: bold;
            font-size: 20px;
            padding: 3px;
            text-align: center;
        }

        td {
            color: #0e0505;
            font-size: 18px;
            text-align: left;
            padding: 3px;
        }

        tr {
            vertical-align: top;
        }

        .p {
            font-weight: bold;
            color: #000000;
            width: 100% !important;
            font-size: 16px;
            height: 38px !important;
            line-height: 38px !important;
        }

        .k {
            border-right: 1px solid #ddd;
        }

        @media print {
            input {
                display: none;
            }
        }
    </style>
    <style>
        .form-control {
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
    </style>
    <style>
        .fade {
            opacity: 0;
            -webkit-transition: opacity .15s linear;
            -o-transition: opacity .15s linear;
            transition: opacity .15s linear;
        }

            .fade.in {
                opacity: 1;
            }

        .btn-group-vertical > .modal-footer:after, .modal-footer:before {
            display: table;
            content: " ";
        }

        .btn-group-vertical > .modal-footer:after {
            clear: both;
        }

        .modal-open {
            overflow: hidden;
        }

        .modal {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: 1050;
            display: none;
            overflow: hidden;
            -webkit-overflow-scrolling: touch;
            outline: 0;
        }

            .modal.fade .modal-dialog {
                -webkit-transition: -webkit-transform .3s ease-out;
                -o-transition: -o-transform .3s ease-out;
                transition: transform .3s ease-out;
                -webkit-transform: translate(0,-25%);
                -ms-transform: translate(0,-25%);
                -o-transform: translate(0,-25%);
                transform: translate(0,-25%);
            }

            .modal.in .modal-dialog {
                -webkit-transform: translate(0,0);
                -ms-transform: translate(0,0);
                -o-transform: translate(0,0);
                transform: translate(0,0);
            }

        .modal-open .modal {
            overflow-x: hidden;
            overflow-y: auto;
        }

        .modal-dialog {
            position: relative;
            width: auto;
            margin: 10px;
        }

        .modal-content {
            position: relative;
            background-color: #fff;
            -webkit-background-clip: padding-box;
            background-clip: padding-box;
            border: 1px solid #999;
            border: 1px solid rgba(0,0,0,.2);
            border-radius: 6px;
            outline: 0;
            -webkit-box-shadow: 0 3px 9px rgba(0,0,0,.5);
            box-shadow: 0 3px 9px rgba(0,0,0,.5);
        }

        .modal-backdrop {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: 1040;
            background-color: #000;
        }

            .modal-backdrop.fade {
                filter: alpha(opacity=0);
                opacity: 0;
            }

            .modal-backdrop.in {
                filter: alpha(opacity=50);
                opacity: .5;
            }

        .modal-header {
            min-height: 16.43px;
            padding: 15px;
            border-bottom: 1px solid #e5e5e5;
        }

            .modal-header .close {
                margin-top: -2px;
            }

        .modal-title {
            margin: 0;
            line-height: 1.42857143;
        }

        .modal-body {
            position: relative;
            padding: 15px;
        }

        .modal-footer {
            padding: 15px;
            text-align: right;
            border-top: 1px solid #e5e5e5;
        }

            .modal-footer .btn + .btn {
                margin-bottom: 0;
                margin-left: 5px;
            }

            .modal-footer .btn-group .btn + .btn {
                margin-left: -1px;
            }

            .modal-footer .btn-block + .btn-block {
                margin-left: 0;
            }

        .modal-scrollbar-measure {
            position: absolute;
            top: -9999px;
            width: 50px;
            height: 50px;
            overflow: scroll;
        }

        @media (min-width:768px) {
            .modal-dialog {
                width: 600px;
                margin: 30px auto;
            }

            .modal-content {
                -webkit-box-shadow: 0 5px 15px rgba(0,0,0,.5);
                box-shadow: 0 5px 15px rgba(0,0,0,.5);
            }

            .modal-sm {
                width: 300px;
            }
        }

        @media (min-width:992px) {
            .modal-lg {
                width: 900px;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/tblmargin.css" rel="stylesheet" />
    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="txtno" runat="server" Text=""></asp:Label>
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
            <div class="container">
                <div id="ListMenu" runat="server" style="margin-top: 20px;" class="ddlListHide">
                    <script type="text/javascript" lang="javascript">
                        Sys.Application.add_load(BootSideMenu);
                    </script>
                    <div class="row" style="border: 2px solid red; background-color: gray;">
                        <div class="col-md-12" style="text-align: center; color: #fff">
                            <h1>CRF Master Report</h1>
                        </div>
                    </div>


                    <div class="row" style="border-bottom: 2px solid; background-color: gray; margin-top: 2px">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblArthYear" runat="server" CssClass="form-control p" Text="अर्थसंकल्पीय वर्ष:" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlArthYear" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVArthYear" runat="server" ControlToValidate="ddlArthYear"
                                ErrorMessage="अर्थसंकल्पीय वर्ष निवडा!" InitialValue="निवडा" ForeColor="red" Font-Size="Larger" Display="Dynamic" CssClass="blink_me" BackColor="Yellow" ValidationGroup="rfvField"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            <%-- <strong>
                        <asp:Button ID="btnworkidview" runat="server" Text="View" Style="border: 2px solid; font-size: 1.1em; color: darkblue" Font-Bold="True" CssClass="form-control p" OnClientClick="PrintGrid()" /></strong>--%>
                        </div>
                    </div>

                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblKamacheyear" runat="server" CssClass="form-control p" Text="कामाचे वर्ष:" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlKamacheyear" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="ddlKamacheyear_SelectedIndexChanged">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVKamcheyear" runat="server" ControlToValidate="ddlKamacheyear"
                                ErrorMessage="कामाचे वर्ष निवडा!" InitialValue="निवडा" ForeColor="red" Font-Size="Larger" Display="Dynamic" CssClass="blink_me" BackColor="Yellow" ValidationGroup="rfvField"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnKamacheYear" runat="server" CssClass="form-control " Text="OK" OnClick="btnKamacheYear_Click" Width="100px" ValidationGroup="rfvField" />
                        </div>
                    </div>



                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lbllekhashirsh" runat="server" Text="लेखाशीर्ष:" CssClass="form-control p" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlLekhashirsh" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="ddlLekhashirsh_SelectedIndexChanged">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnlekhashirsh" runat="server" CssClass="form-control " Text="OK" OnClick="btnlekhashirsh_Click" Width="100px" ValidationGroup="rfvField"/>
                        </div>
                    </div>


                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblupvibhag" runat="server" CssClass="form-control p" Text="उपविभाग:" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlUpvibhag" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnupvibhag" runat="server" CssClass="form-control " Text="OK" OnClick="btnupvibhag_Click" Width="100px" ValidationGroup="rfvField" />
                        </div>
                    </div>
                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1 "></div>
                        <div class="col-md-3">
                            <asp:Label ID="lbljilha" runat="server" Text="जिल्हा:" CssClass="form-control p" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlJilha" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnjilha" runat="server" CssClass="form-control " Text="OK" OnClick="btnjilha_Click" Width="100px" ValidationGroup="rfvField" />
                        </div>
                    </div>
                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lbltaluka" runat="server" Text="तालुका:" CssClass="form-control p" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlTaluka" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btntaluka" runat="server" CssClass="form-control " Text="OK" OnClick="btntaluka_Click" Width="100px" ValidationGroup="rfvField" />
                        </div>
                    </div>
                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblno" runat="server" Text="Work_ID" CssClass="form-control p" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlworkid" runat="server" AutoPostBack="True" CssClass="form-control p" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnworkid" runat="server" CssClass="form-control " Text="OK" OnClick="btnworkid_Click" Width="100px" ValidationGroup="rfvField" />
                        </div>

                    </div>
                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblabhiyanta" runat="server" Text="शाखा अभियंता:" CssClass="form-control p" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlShakhaAbhiyanta" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnabhiyanta" runat="server" CssClass="form-control " Text="OK" OnClick="btnabhiyanta_Click" Width="100px" ValidationGroup="rfvField"/>
                        </div>
                    </div>
                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblupabhiyanta" runat="server" Text="उपअभियंता:" CssClass="form-control p" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlShakhUpAbhiyanta" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnupabhiyanta" runat="server" CssClass="form-control " Text="OK" OnClick="btnupabhiyanta_Click" Width="100px" ValidationGroup="rfvField" />
                        </div>
                    </div>
                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblamdar" runat="server" Text="आमदार:" CssClass="form-control p" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlAmdar" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnamdar" runat="server" CssClass="form-control " Text="OK" OnClick="btnamdar_Click" Width="100px" ValidationGroup="rfvField" />
                        </div>
                    </div>
                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1 "></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblkhasdar" runat="server" CssClass="form-control p" Text="खासदार:" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlKhasdar" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnkhasdar" runat="server" CssClass="form-control " Text="OK" OnClick="btnkhasdar_Click" Width="100px" ValidationGroup="rfvField" />
                        </div>
                    </div>
                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblthekedarname" runat="server" CssClass="form-control p" Text="ठेकेदाराचे नाव:" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlThekedarecheName" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnthekedar" runat="server" CssClass="form-control " Text="OK" OnClick="btnthekedar_Click" Width="100px" ValidationGroup="rfvField" />
                        </div>
                    </div>

                    <div class="row" style="border-bottom: 2px solid; background-color: gray; height: 50px">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblkamachisadyastiti" runat="server" CssClass="form-control p" Text="कामाची सद्यस्थिती:" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlKamachiSadyStiti" runat="server" CssClass="form-control p" AutoPostBack="True" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnkamachistiti" runat="server" CssClass="form-control " Text="OK" OnClick="btnkamachistiti_Click" Width="100px" ValidationGroup="rfvField" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="ddlList col-lg-1">Show/Hide List</div>
            <hr />

            <div style="overflow-x: auto; border: double">
                <asp:CheckBoxList ID="chkcrf" runat="server" BorderStyle="Solid" BorderWidth="4px" RepeatDirection="Horizontal" class="table-bordered" OnSelectedIndexChanged="chkBuilding_SelectedIndexChanged">

                    <asp:ListItem Selected="True" Value="a.[WorkId] as 'WorkId'" runat="server">WorkId</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[ArthsankalpiyBab] as 'Budget of Item'" runat="server">Budget of Item</asp:ListItem>
                    <asp:ListItem Selected="True" Enabled="false" Value="a.[Arthsankalpiyyear] as 'Budget of Year'" runat="server">Budget of Year</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[KamacheName] as 'Name of Work'" runat="server">Name of Work</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[LekhaShirsh] as 'Head'" runat="server">Head</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[LekhaShirshName] as 'Headwise'" runat="server">Headwise</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[Type] as 'Type'" runat="server">Type</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[SubType] as 'SubType'" runat="server">SubType</asp:ListItem>
                    <asp:ListItem Selected="True" Enabled="false" Value="a.[Upvibhag] as 'Sub Division'" runat="server">Sub Division</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[Taluka] as 'Taluka'" runat="server">Taluka</asp:ListItem>
                    <asp:ListItem Selected="True" Value="convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'Sectional Engineer'" runat="server">Sectional Engineer</asp:ListItem>
                    <asp:ListItem Selected="True" Value="convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'Deputy Engineer'" runat="server">Deputy Engineer</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[AmdaracheName] as 'MLA'" runat="server">MLA</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[KhasdaracheName] as 'MP'" runat="server">MP</asp:ListItem>
                    <asp:ListItem Selected="True" Value="convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor'" runat="server">Contractor</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[PrashaskiyKramank] as 'Administrative No'" runat="server">Administrative No</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[PrashaskiyDate] as 'A A Date'" runat="server">A A Date</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[PrashaskiyAmt] as 'A A Amount'" runat="server">A A Amount</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[TrantrikKrmank] as 'Technical Sanction No'" runat="server">Technical Sanction No</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[TrantrikDate] as 'T S Date'" runat="server">T S Date</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[TrantrikAmt] as 'T S Amount'" runat="server">T S Amount</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[Kamachavav] as 'Scope of Work'" runat="server">Scope of Work</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[karyarambhadesh] as 'Work Order'" runat="server">Work Order</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[NividaKrmank] as 'Tender No'" runat="server">Tender No</asp:ListItem>
                    <asp:ListItem Selected="True" Value="cast(a.[NividaAmt] as decimal(10,2)) as 'Tender Amount'" runat="server">Tender Amount</asp:ListItem>
                    <%--<asp:ListItem Selected="True" Value="a.[Dist] as 'Dist'" runat="server">Dist</asp:ListItem>--%>
                    <asp:ListItem Selected="True" Value="a.[NividaDate] as 'Tender Date'" runat="server">Tender Date</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[kamachiMudat] as 'Work Order Date'" runat="server">Work Order Date</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[KamPurnDate] as 'Work Completion Date'" runat="server">Work Completion Date</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[MudatVadhiDate] as 'Extension Month'" runat="server">Extension Month</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[SanctionDate] as 'SanctionDate'" runat="server">SanctionDate</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[SanctionAmount] as 'SanctionAmount'" runat="server">SanctionAmount</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[ManjurAmt] as 'Estimated Cost Approved'" runat="server">Estimated Cost Approved</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[MarchEndingExpn] as 'MarchEndingExpn'" runat="server">MarchEndingExpn</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[UrvaritAmt] as 'Remaining Cost'" runat="server">Remaining Cost</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[VarshbharatilKharch] as 'Annual Expense'" runat="server">Annual Expense</asp:ListItem>

                    <asp:ListItem Selected="True" Value="b.[Magilmonth] as 'Previous Month'" runat="server">Previous Month</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Magilkharch] as 'Previous Cost'" runat="server">Previous Cost</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Chalumonth] as 'Current Month'" runat="server">Current Month</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Chalukharch] as 'Current Cost'" runat="server">Current Cost</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[AikunKharch] as 'Total Expense'" runat="server">Total Expense</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[DTakunone] as 'First Provision Month'" runat="server">First Provision Month</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Takunone] as 'First Provision'" runat="server">First Provision</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[DTakuntwo] as 'Second Provision Month'" runat="server">Second Provision Month</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Takuntwo] as 'Second Provision'" runat="server">Second Provision</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[DTakunthree] as 'Third Provision Month'" runat="server">Third Provision Month</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Takunthree] as 'Third Provision'" runat="server">Third Provision</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[DTakunfour] as 'Fourth Provision Month'" runat="server">Fourth Provision Month</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Takunfour] as 'Fourth Provision'" runat="server">Fourth Provision</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Tartud] as 'Grand Provision'" runat="server">Grand Provision</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[AkunAnudan] as 'Total Grand'" runat="server">Total Grand</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Magni] as 'Demand'" runat="server">Demand</asp:ListItem>

                    <%--Newly Added checkboxes --%>
                    <asp:ListItem Selected="True" Value="b.[OtherExpen] as 'Other Expense'" runat="server">Other Expense</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[ExpenCost] as 'Electricity Cost'" runat="server">Electricity Cost</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[ExpenExpen] as 'Electricity Expense'" runat="server">Electricity Expense</asp:ListItem>
                    <%--End Newly Added checkboxes --%>

                    <asp:ListItem Selected="True" Value="a.[JobNo] as 'JobNo'" runat="server">JobNo</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[RoadNo] as 'Road Category'" runat="server">Road Category</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[RoadLength] as 'RoadLength'" runat="server">RoadLength</asp:ListItem>

                    <%--Newly Added checkboxes --%>

                    <asp:ListItem Selected="True" Value="a.[APhysicalScope] as 'W.B.M Wide Phy Scope'" runat="server">W.B.M Wide Phy Scope</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[ACommulative] as 'W.B.M Wide Commulative'" runat="server">W.B.M Wide Commulative</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[ATarget] as 'W.B.M Wide Target'" runat="server">W.B.M Wide Target</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[AAchievement] as 'W.B.M Wide Achievement'" runat="server">W.B.M Wide Achievement</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[BPhysicalScope] as 'B.T Phy Scope'" runat="server">B.T Phy Scope</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[BCommulative] as 'B.T Commulative'" runat="server">B.T Commulative</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[BTarget] as 'B.T Target'" runat="server">B.T Target</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[BAchievement] as 'B.T Achievement'" runat="server">B.T Achievement</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[CPhysicalScope] as 'C.D Phy Scope'" runat="server">C.D Phy Scope</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[CCommulative] as 'C.D Commulative'" runat="server">C.D Commulative</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[CTarget] as 'C.D Target'" runat="server">C.D Target</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[CAchievement] as 'C.D Achievement'" runat="server">C.D Achievement</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[DPhysicalScope] as 'Minor Bridges Phy Scope(Nos)'" runat="server">Minor Bridges Phy Scope(Nos)</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[DCommulative] as 'Minor Bridges Commulative(Nos)'" runat="server">Minor Bridges Commulative(Nos)</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[DTarget] as 'Minor Bridges Target(Nos)'" runat="server">Minor Bridges Target(Nos)</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[DAchievement] as 'Minor Bridges Achievement(Nos)'" runat="server">Minor Bridges Achievement(Nos)</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[EPhysicalScope] as 'Major Bridges Phy Scope(Nos)'" runat="server">Major Bridges Phy Scope(Nos)</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[ECommulative] as 'Major Bridges Commulative(Nos)'" runat="server">Major Bridges Commulative(Nos)</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[ETarget] as 'Major Bridges Target(Nos)'" runat="server">Major Bridges Target(Nos)</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[EAchievement] as 'Major Bridges Achievement(Nos)'" runat="server">Major Bridges Achievement(Nos)</asp:ListItem>

                    <%--End Newly Added checkboxes --%>

                    <asp:ListItem Selected="True" Value="b.[DeyakachiSadyasthiti] as 'Bill Status'" runat="server">Bill Status</asp:ListItem>

                    <asp:ListItem Selected="True" Value="a.[Pahanikramank] as 'Observation No'" runat="server">Observation No</asp:ListItem>
                    <asp:ListItem Selected="True" Value="a.[PahaniMudye] as 'Observation Memo'" runat="server">Observation Memo</asp:ListItem>
                   
                     <asp:ListItem Selected="True" Value="CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" runat="server">C</asp:ListItem>
                    <asp:ListItem Selected="True" Value="CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" runat="server">P</asp:ListItem>
                    <asp:ListItem Selected="True" Value="CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" runat="server">NS</asp:ListItem>
                     <asp:ListItem Selected="True" Value="CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" runat="server">ES</asp:ListItem>  
                        <asp:ListItem Selected="True" Value="CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'" runat="server">ST</asp:ListItem>    



                    <asp:ListItem Selected="True" Value="a.[Shera] as 'Remark'" runat="server">Remark</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Apr] as 'Apr'" runat="server">Apr</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[May] as 'May'" runat="server">May</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Jun] as 'Jun'" runat="server">Jun</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Jul] as 'Jul'" runat="server">Jul</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Aug] as 'Aug'" runat="server">Aug</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Sep] as 'Sep'" runat="server">Sep</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Oct] as 'Oct'" runat="server">Oct</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Nov] as 'Nov'" runat="server">Nov</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Dec] as 'Dec'" runat="server">Dec</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Jan] as 'Jan'" runat="server">Jan</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Feb] as 'Feb'" runat="server">Feb</asp:ListItem>
                    <asp:ListItem Selected="True" Value="b.[Mar] as 'Mar'" runat="server">Mar</asp:ListItem>
                    
                </asp:CheckBoxList>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
    <br />
    <div align="center">
        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="Edit(Update Record)/Select(Send SMS)" Style="color: black;" OnCheckedChanged="CheckBox1_CheckedChanged" />
        <asp:CheckBox ID="myBtn2" runat="server" Text="Delete Record" Style="color: black; border-radius: 25%;" onclick="return div_show();" />
    </div>
     <div class="Graph3 col-lg-4">Graphics Report</div>
    <hr />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="Print">
                <div id="DivRoot" align="left">
                    <asp:Panel ID="Panel1" runat="server">
                        <div align="center">
                            <asp:Label ID="Label3" runat="server" Text="" Style="font-weight: bold; font-size: 24px;"></asp:Label><br />
                            <asp:Label ID="lblYear" runat="server" Style="font-weight: bold; font-size: 24px;"></asp:Label><br />
                            <asp:Label ID="lblLekha" runat="server" Style="font-weight: bold; font-size: 24px;"></asp:Label>
                            <asp:Label ID="Label5" runat="server" Style="font-weight: bold; font-size: 24px;"></asp:Label>

                        </div>
                    </asp:Panel>

                    <div class="Graph1" style="width: 100%">
                    <div style="overflow: hidden;" id="DivHeaderRow">
                    </div>
                    <div style="overflow: auto;" onscroll="OnScrollDiv(this)" id="DivMainContent">
                        <asp:GridView ID="GridView1" runat="server" DataKeyNames="WorkId" RowStyle-VerticalAlign="Top" Style="border: 2px solid" Width="100%" AutoGenerateEditButton="true" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" AutoGenerateSelectButton="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDataBound="GridView1_RowDataBound" ShowFooter="true">

                            <RowStyle VerticalAlign="Top" />
                            <Columns>
                                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="blue" />
                                <asp:TemplateField Visible="false">
                                    <FooterTemplate></FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlLink" runat="server" ForeColor="blue"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>

                        </div>


                </div>
            </div>
            <div id="abc" class="modal fade" style="opacity: 3.95 !important;">

                <!-- Popup Div Starts Here -->
                <div id="popupContact">
                    <!-- Contact Us Form -->
                    <form id="formpop">
                        <div class="modal-header" style="padding: 35px 50px;">
                            <button type="button" id="close" class="close" onclick="div_hide()" data-dismiss="modal">&times;</button>
                            <h4><span class="glyphicon glyphicon-lock"></span>Password</h4>
                        </div>
                        <div class="modal-body" style="padding: 40px 50px; background: linear-gradient(#ccc,#fae8bd);">
                            <div class="form-group">
                                <label for="txtpassword"><span class="glyphicon glyphicon-eye-open"></span>Password</label>
                                <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" class="form-control" placeholder="Enter password"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-success btn-block" Text="Submit" OnClick="btnSubmit_Click" Style="margin-left: 0 !important;" />
                        </div>
                    </form>

                </div>
                <!-- Popup Div Ends Here -->
            </div>
               <div class="Graph2 col-lg-12 col-md-12 col-sm-12" style="text-align: center;">
                        <div style="height: 100%; width: 100%;">


                            <asp:Chart ID="Chart2" runat="server" Height="500px" Width="800px" Compression="1" CssClass="img-responsive MasterRptChart p1" Palette="None">

                                <Series>
                                    <asp:Series Name="DBS" YValuesPerPoint="6"></asp:Series>

                                </Series>

                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" Area3DStyle-PointGapDepth="1" Area3DStyle-Rotation="40" BackImageTransparentColor="WhiteSmoke" IsSameFontSizeForAllAxes="true">
                                        <Area3DStyle Enable3D="True" PointGapDepth="1"></Area3DStyle>
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Titles>
                                    <asp:Title Name="DBS" Text="Total Abstract Report" Font="Bold">
                                    </asp:Title>
                                </Titles>
                            </asp:Chart>

                        </div>
                    </div>
        </ContentTemplate>

    </asp:UpdatePanel>
    <div align="center">
        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary" Height="40px" Width="100px" OnClick="btnPrint_Click" />
        <asp:Button ID="BtnExcel" runat="server" Text="Excel" CssClass="btn btn-success" Height="40px" Width="100px" OnClick="BtnExcel_Click" />
        <%--<asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-info" Height="40px" Width="100px" OnClientClick="PrintGrid()" />--%>
        <%--<asp:Button ID="btnSendEmail" runat="server" Text="Send email" OnClick="SendEmail" />--%>
        <asp:Button ID="btnSendMail" runat="server" OnClick="btnSendMail_Click" class="btn btn-warning" Height="40px" Width="100px" Text="Send Mail" />
        <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" Height="40px" Width="100px" OnClick="BtnCancel_Click" />
        <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-default" BackColor="#660000" ForeColor="White" OnClientClick="JavaScript:window.history.back(1); return false;" Height="40px" Width="100px" />
    </div>

    <script lang="javascript" type="text/javascript">
        function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var qrStr = window.location.search;
                var spQrStr = qrStr.substring(1);
                var arrQrStr = new Array();
                var arr = spQrStr.split('&');
                var str = arr.slice(0, 4).toString();               
                
                var DivHR = document.getElementById('DivHeaderRow');
                var DivMC = document.getElementById('DivMainContent');
                var DivFR = document.getElementById('DivFooterRow');

                //*** Set divheaderRow Properties ****
                //DivHR.style.height = headerHeight + 'px';
                if (str.slice(0, 4).toString() == "Year") {
                    DivHR.style.height = '94px';
                }
                else {
                    DivHR.style.height = '118px';
                }
                
                DivHR.style.width = (parseInt(width)) + '%';
                DivHR.style.backgroundColor = 'rgb(255, 249, 249)';
                DivHR.style.color = 'white';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '50';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****

                DivMC.style.width = width + '%';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                if (str.slice(0, 4).toString() == "Year") {
                    DivMC.style.top = -94 + 'px';
                }
                else {
                    DivMC.style.top = -118 + 'px';
                }                
                DivMC.style.zIndex = '1';                
                //****Copy Header in divHeaderRow****
                DivHR.appendChild(tbl.cloneNode(true));

            }
        }



        function OnScrollDiv(Scrollablediv) {
            document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
            document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
        }


    </script>
    <script lang="javascript" type="text/javascript">

        function PrintGrid() {
            var prtGrid = document.getElementById('Print');
            prtGrid.border = 0;

            var prtwin = window.open('', 'PrintGridViewData', 'left=0,top=0,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);

        }
    </script>
    <script lang="javascript" type="text/javascript">

        function PrintGrid1() {
            var prtGrid = document.getElementById('Print');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=0,top=0,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.print();
        }
    </script>
    <script lang="javascript" type="text/javascript">
        function Navigate() {
            location.href = "SuperAdminPanel.aspx";
        }

    </script>
    <%--<script>
        $(document).ready(function () {
            $("#myBtn").click(function () {
                $("#myModal").modal();
            });
        });
    </script>--%>
    <script>
        $('.openmodal').click(function () {
            $('#myModal').modal('toggle');//.modal('show')/.modal('hide');
        });
    </script>
    <script src="Styles/js/my_js.js"></script>

</asp:Content>
