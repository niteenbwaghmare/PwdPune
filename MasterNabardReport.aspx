<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="MasterNabardReport.aspx.cs" Inherits="PWdEEBudget.MasterNabardReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/css/elements.css" rel="stylesheet" />
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
            /*margin-left: 10%;
            margin-right: 10%;
            max-width: 80%;
            min-width: 79%;
            font-weight: bold;
            color: #000000;
            width: 100% !important;
            font-size: 18px;
            height: 38px !important;
            line-height: 38px !important;*/
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div id="ListMenu" runat="server" style="margin-top: 20px" class="ddlListHide">
                    <div class="row" style="border: 2px solid red; background-color: gray;">
                        <div class="col-md-12" style="text-align: center; color: #fff">
                            <h1>Nabard Master Report</h1>
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
                            <asp:RequiredFieldValidator ID="RFVArthYear" runat="server" ControlToValidate="ddlArthYear" ValidationGroup="rfvField"
                                ErrorMessage="अर्थसंकल्पीय वर्ष निवडा!" InitialValue="निवडा" ForeColor="red" Font-Size="Larger" Display="Dynamic" CssClass="blink_me" BackColor="Yellow"></asp:RequiredFieldValidator>

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
                            <asp:RequiredFieldValidator ID="RFVKamcheyear" runat="server" ControlToValidate="ddlKamacheyear" ValidationGroup="rfvField"
                                ErrorMessage="कामाचे वर्ष निवडा!" InitialValue="निवडा" ForeColor="red" Font-Size="Larger" Display="Dynamic" CssClass="blink_me" BackColor="Yellow"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnKamacheYear" runat="server" CssClass="form-control " Text="OK" OnClick="btnKamacheYear_Click" Width="100px" ValidationGroup="rfvField"/>
                        </div>
                    </div>

                    <div class="row" style="border-bottom: 2px solid; background-color: gray;">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="RIDF NO" Font-Bold="True" CssClass="form-control p"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-control p" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="ReportTypebtn" runat="server" OnClick="ReportTypebtn_Click" Text="OK" CssClass="form-control " Width="100px" ValidationGroup="rfvField"/>
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
                            <asp:Button ID="btnupvibhag" runat="server" CssClass="form-control " Text="OK" OnClick="btnupvibhag_Click" Width="100px" ValidationGroup="rfvField"/>
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
                            <asp:Button ID="btnjilha" runat="server" CssClass="form-control " Text="OK" OnClick="btnjilha_Click" Width="100px" ValidationGroup="rfvField"/>
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
                            <asp:Button ID="btntaluka" runat="server" CssClass="form-control " Text="OK" OnClick="btntaluka_Click" Width="100px" ValidationGroup="rfvField"/>
                        </div>
                    </div>
                    <div class="row" style="border-bottom: 2px solid; background-color: gray">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Label ID="lblno" runat="server" Text="वर्क आयडी" CssClass="form-control p" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlworkid" runat="server" AutoPostBack="True" CssClass="form-control p" ForeColor="Black">
                                <asp:ListItem>निवडा</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnworkid" runat="server" CssClass="form-control " Text="OK" OnClick="btnworkid_Click" Width="100px" ValidationGroup="rfvField"/>
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
                            <asp:Button ID="btnupabhiyanta" runat="server" CssClass="form-control " Text="OK" OnClick="btnupabhiyanta_Click" Width="100px" ValidationGroup="rfvField"/>
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
                            <asp:Button ID="btnamdar" runat="server" CssClass="form-control " Text="OK" OnClick="btnamdar_Click" Width="100px" ValidationGroup="rfvField"/>
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
                            <asp:Button ID="btnkhasdar" runat="server" CssClass="form-control " Text="OK" OnClick="btnkhasdar_Click" Width="100px" ValidationGroup="rfvField"/>
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
                            <asp:Button ID="btnthekedar" runat="server" CssClass="form-control " Text="OK" OnClick="btnthekedar_Click" Width="100px" ValidationGroup="rfvField"/>
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
                            <asp:Button ID="btnkamachistiti" runat="server" CssClass="form-control " Text="OK" OnClick="btnkamachistiti_Click" Width="100px" ValidationGroup="rfvField"/>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="ddlList col-lg-1">Show/Hide List</div>

            <hr />
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Double">

                <div style="overflow-x: auto">
                    <asp:CheckBoxList ID="chkBuilding" runat="server" BorderStyle="Solid" BorderWidth="4px" RepeatDirection="Horizontal" class="table-bordered" OnSelectedIndexChanged="chkBuilding_SelectedIndexChanged">

                        <asp:ListItem Selected="True" Value="a.[WorkId] as 'Work Id'" Enabled="false" runat="server">Work Id</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[RDF_NO] as 'RIDF NO'" Enabled="false" runat="server">RIDF NO</asp:ListItem>
                        <asp:ListItem Selected="True" Enabled="false" Value="a.[Arthsankalpiyyear] as 'Budget of Year'" runat="server">Budget of Year</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.Dist as 'District'" runat="server">District</asp:ListItem>
                        <asp:ListItem Selected="True" Enabled="false" Value="a.[Taluka] as 'Taluka'" runat="server">Taluka</asp:ListItem>

                        <asp:ListItem Selected="True" Value="a.[ArthsankalpiyBab] as 'Budget of Item'" runat="server">Budget of Item</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[KamacheName]as 'Name of Work'" runat="server">Name of Work</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[Kamachavav] as 'Scope of Work'" runat="server">Scope of Work</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[LekhaShirshName] as 'Headwise'" runat="server">Headwise</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[SubType] as 'Division'" runat="server">Division</asp:ListItem>
                        <asp:ListItem Selected="True" Enabled="false" Value="a.[Upvibhag] as 'Sub Division'" runat="server">Sub Division</asp:ListItem>
                        <asp:ListItem Selected="True" Value="convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'Sectional Engineer'" runat="server">Sectional Engineer</asp:ListItem>
                        <asp:ListItem Selected="True" Value="convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'Deputy Engineer'" runat="server">Deputy Engineer</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[AmdaracheName] as 'MLA'" runat="server">MLA</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[KhasdaracheName] as 'MP'" runat="server">MP</asp:ListItem>
                        <asp:ListItem Selected="True" Value="convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor'" runat="server">Contractor</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[PrashaskiyKramank] as 'Administrative No'" runat="server">Administrative No</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[PrashaskiyDate] as 'A A Date'" runat="server">A A Date</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[PIC_NO] as 'PIC No'" runat="server">PIC No</asp:ListItem>
                        <asp:ListItem Selected="True" Value="cast(a.[PrashaskiyAmt] as decimal(10,2)) as 'AA cost Rs in lakhs'" runat="server">AA cost Rs in lakhs</asp:ListItem>
                        <asp:ListItem Selected="True" Value="cast(a.[TrantrikAmt]as decimal(10,2))as 'Technical Sanction Cost Rs in Lakh'" runat="server">Technical Sanction Cost Rs in Lakh</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[TrantrikKrmank]+' '+a.[TrantrikDate] as 'Technical Sanction No and Date'" runat="server">Technical Sanction No and Date</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[NividaKrmank] as 'Tender No'" runat="server">Tender No</asp:ListItem>
                        <asp:ListItem Selected="True" Value="cast(a.[NividaAmt] as decimal(10,2)) as 'Tender Amount'" runat="server">Tender Amount</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[karyarambhadesh] as 'Work Order'" runat="server">Work Order</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[NividaDate] as 'Tender Date'" runat="server">Tender Date</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[kamachiMudat] as 'Work Order Date'" runat="server">Work Order Date</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[KamPurnDate] as 'Work Completion Date'" runat="server">Work Completion Date</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[MudatVadhiDate] as 'Extension Month'" runat="server">Extension Month</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[ManjurAmt] as 'Estimated Cost Approved'" runat="server">Estimated Cost Approved</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[MarchEndingExpn] as 'Expenditure up to MAR 2017'" runat="server">Expenditure up to MAR 2017</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[UrvaritAmt] as 'Remaining Cost'" runat="server">Remaining Cost</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[Chalukharch] as 'Current Cost'" runat="server">Current Cost</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[Magilkharch] as 'Previous Cost'" runat="server">Previous Cost</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[VarshbharatilKharch] as 'Expenditure up to 8/2016 during year 16-17 Rs in Lakhs'" runat="server">Expenditure up to 8/2016 during year 16-17 Rs in Lakhs</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[AikunKharch] as 'Total Expense'" runat="server">Total Expense</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[Takunone] as 'Budget Provision in 2017-18 Rs in Lakhs'" runat="server">Budget Provision in 2017-18 Rs in Lakhs</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[Takuntwo] as 'Second Provision'" runat="server">Second Provision</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[Takunthree] as 'Third Provision'" runat="server">Third Provision</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[Takunfour] as 'Fourth Provision'" runat="server">Fourth Provision</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[Tartud] as 'Total Provision'" runat="server">Total Provision</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[AkunAnudan] as 'Total Grand'" runat="server">Total Grand</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[Magni] as 'Demand for 2017-18 Rs in Lakhs'" runat="server">Demand for 2017-18 Rs in Lakhs </asp:ListItem>

                        <asp:ListItem Selected="True" Value="a.[PahaniMudye] as 'Observation Memo'" runat="server">Observation Memo</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[Pahanikramank] as 'Probable date of completion'" runat="server">Probable date of completion</asp:ListItem>
                        <asp:ListItem Selected="True" Value="b.[DeyakachiSadyasthiti] as 'Bill Status'" runat="server">Bill Status</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[Sadyasthiti] as 'Physical Progress of work'" runat="server">Physical Progress of work</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[Road_No] as 'Road Category'" runat="server">Road Category</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[LengthRoad] as 'Road Length'" runat="server">Road Length</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[RoadType] as 'Road Type'" runat="server">Road Type</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[WBMI_km] as 'WBMI Km'" runat="server">WBMI Km</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[WBMII_km] as 'WBMII Km'" runat="server">WBMII Km</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[WBMIII_km] as 'WBMIII Km'" runat="server">WBMIII Km</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[BBM_km] as 'BBM Km'" runat="server">BBM Km</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[Carpet_km] as 'Carpet Km'" runat="server">Carpet Km</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[Surface_km] as 'Surface Km'" runat="server">Surface Km</asp:ListItem>
                        <asp:ListItem Selected="True" Value="cast(a.[CD_Works_No] as decimal(10,2))  as 'CD_Works_No'" runat="server">CD_Works_No</asp:ListItem>
                        <asp:ListItem Selected="True" Value="a.[PCR] as 'PCR submitted or not'" runat="server">PCR submitted or not</asp:ListItem>

                           


                        <asp:ListItem Selected="True" Value="a.[Shera] as 'Remark'" runat="server">Remark</asp:ListItem>
                         <asp:ListItem Selected="True" Value="CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" runat="server">C</asp:ListItem>
                    <asp:ListItem Selected="True" Value="CAST(CASE WHEN a.[Sadyasthiti] = 'Inprogress'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" runat="server">P</asp:ListItem>
                    <asp:ListItem Selected="True" Value="CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" runat="server">NS</asp:ListItem>
                     <asp:ListItem Selected="True" Value="CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" runat="server">ES</asp:ListItem>  
                        <asp:ListItem Selected="True" Value="CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'" runat="server">ST</asp:ListItem> 
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
            </asp:Panel>

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
                    <asp:Panel ID="Panel2" runat="server">
                        <div align="center">
                            <asp:Label ID="Label3" runat="server" Text="" Style="font-weight: bold; font-size: 24px;"></asp:Label>
                            <br>

                            <asp:Label ID="Label5" runat="server" Style="font-weight: bold; font-size: 24px;"></asp:Label>
                        </div>
                    </asp:Panel>
                    <div class="Graph1" style="width: 100%">
                        <div style="overflow: hidden;" id="DivHeaderRow">
                        </div>

                        <div style="overflow: auto;" onscroll="OnScrollDiv(this)" id="DivMainContent">

                            <asp:GridView ID="GridView1" runat="server" DataKeyNames="Work Id" RowStyle-VerticalAlign="Top" Style="border: 2px solid" Width="100%" AutoGenerateEditButton="true" OnRowEditing="GridView1_RowEditing" AutoGenerateSelectButton="true" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" ShowFooter="true">

                                <Columns>
                                    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="blue" />
                                    <%-- <asp:TemplateField Visible="false">
                                        <FooterTemplate></FooterTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" ControlStyle-BackColor="Yellow">
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="false" HeaderText="Photo">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlLink" runat="server" ForeColor="blue"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-success btn-block" Text="Submit" OnClick="btnSubmit_Click" Style="margin-left: 0 !important;"/>
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
        <asp:Button ID="btnSendMail" runat="server" OnClick="btnSendMail_Click" class="btn btn-warning" Height="40px" Width="100px" Text="Send Mail" />
        <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" Height="40px" Width="100px" OnClick="BtnCancel_Click" />
        <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-default" BackColor="#660000" ForeColor="White" OnClientClick="JavaScript:window.history.back(1); return false;" Height="40px" Width="100px" />
    </div>


    <%-- <div class="container">
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" style="padding: 35px 50px;">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4><span class="glyphicon glyphicon-lock"></span>Password</h4>
                    </div>
                    <div class="modal-body" style="padding: 40px 50px;">
                        <form role="form">
                            <div class="form-group">
                                <label for="txtpassword"><span class="glyphicon glyphicon-eye-open"></span>Password</label>
                                <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" class="form-control" placeholder="Enter password"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-success btn-block" Text="Submit" OnClick="btnSubmit_Click" />
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-danger btn-default pull-left" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
                    </div>
                </div>

            </div>
        </div>
    </div>--%>
    <script type="text/javascript">
        function Navigate() {
            location.href = "SuperAdminPanel.aspx";
        }

    </script>
    <%-- <script>
        $(document).ready(function () {
            $("#myBtn").click(function () {
                $("#myModal").modal();
            });
        });
    </script>
    <script>
        $('.openmodal').click(function () {
            $('#myModal').modal('toggle');//.modal('show')/.modal('hide');
        });
    </script>--%>
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
                    DivHR.style.height = '124px';
                }
                else {                    
                    DivHR.style.height = '145px';                    
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
                    DivMC.style.top = -124 + 'px';                    
                }
                else {
                    DivMC.style.top = -145 + 'px';                    
                }                
                DivMC.style.zIndex = '1';

                ////*** Set divFooterRow Properties ****
                //DivFR.style.width = (parseInt(width) - 16) + 'px';
                //DivFR.style.position = 'relative';
                //DivFR.style.top = -headerHeight + 'px';
                //DivFR.style.verticalAlign = 'top';
                //DivFR.style.paddingtop = '2px';

                //if (isFooter) {
                //    var tblfr = tbl.cloneNode(true);
                //    tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
                //    var tblBody = document.createElement('tbody');
                //    tblfr.style.width = '100%';
                //    tblfr.cellSpacing = "0";
                //    tblfr.border = "0px";
                //    tblfr.rules = "none";
                //    //*****In the case of Footer Row *******
                //    tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
                //    tblfr.appendChild(tblBody);
                //    DivFR.appendChild(tblfr);
                //}
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
    <script src="Styles/js/my_js.js"></script>
</asp:Content>
