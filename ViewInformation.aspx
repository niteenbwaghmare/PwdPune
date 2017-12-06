<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="ViewInformation.aspx.cs" Inherits="PWdEEBudget.ViewInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .searching
         {
            width: 80%;
            margin-left:10px;
            box-sizing: border-box;
            border: 2px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
            background-color: white;
            background-image: url('img/searchicon.png');
            background-position: 10px 10px;
            background-repeat: no-repeat;
            padding: 12px 20px 12px 40px;
            -webkit-transition: width 0.4s ease-in-out;
            transition: width 0.4s ease-in-out;
           
        }
        /*.p {
                margin-left: 5%;
                font-size:18px;
        }*/
        .pj {
            font-size: 50px;
            color: #0e0505;
        }
        th {
            color:#fff;
            background-color:#2c3e50;
        }
         tr {
             vertical-align: top;
         }
        .p {
            margin-left: 10%;
            margin-right: 10%;
            font-size:18px;
            max-width:50%;
            min-width:49%;
           }
        .k {
            border-right: 1px solid #ddd;
        }   
        
    @media print
        {
            input
            {
                display: none;
            }
        }

     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
       <link href="css/tblmargin.css" rel="stylesheet" />
     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="txtno" runat="server" Text=""></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div style="overflow-x:auto">
        
        <div align="center">
            <h1> Master & MPR Report</h1>
        <table class="table-bordered trrr"  style="color:black; text-align :center;font-weight:bold;border: 6px solid black; font-size:18px;  width:100%;height:300px">
          
            <tr><td colspan="3">
               <b> <asp:RadioButton ID="rdofiftytwo" runat="server" style="width: 20em; height: 20em;font-weight:bold" AutoPostBack="True" Checked="True" GroupName="ppppp" OnCheckedChanged="rdofiftytwo_CheckedChanged" Text="Master budget" Font-Bold="True" ForeColor="Black" /></b>
                </td><td colspan="3">
                    <b><asp:RadioButton ID="rdothirtyfive" runat="server" style="width: 20em; height: 20em;font-weight:bold" AutoPostBack="True" GroupName="ppppp" OnCheckedChanged="rdothirtyfive_CheckedChanged" Text="Budget MPR" /></b>
                </td>

            </tr>
            <tr>
                <td colspan="3"><b>प्रकार </b></td>
                <td colspan="3">
                    <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True" cssclass="form-control p" ForeColor="Black" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3"><b> विभाग </b></td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlvibhag" runat="server" AutoPostBack="True" cssclass="form-control p" ForeColor="Black" OnSelectedIndexChanged="ddlvibhag_SelectedIndexChanged">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3"><b>उपविभाग </b></td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlupvibhag" runat="server" AutoPostBack="True" cssclass="form-control p" ForeColor="Black" OnSelectedIndexChanged="ddlupvibhag_SelectedIndexChanged">
                        <asp:ListItem>निवडा</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr><td colspan="3">
                     <b><asp:Label ID="lblno" runat="server" Text="Work_ID"  Font-Bold="True" ForeColor="Black"></asp:Label></b>
                     <br />
                  </td>
                <td colspan="2">
                      <asp:DropDownList ID="ddlworkid" runat="server" AutoPostBack="True" cssclass="form-control" style="font-size:18px;margin-left:10%" ForeColor="Black" OnSelectedIndexChanged="ddlworkid_SelectedIndexChanged">
                   <asp:ListItem>निवडा</asp:ListItem>
                </asp:DropDownList>
                  </td>
                <td colspan="1">
                    <asp:TextBox ID="txtsearch" runat="server" class="searching" placeholder="Enter Work ID" cssclass="form-control p" AutoPostBack="True" OnTextChanged="txtsearch_TextChanged"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtsearch"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">  
                </ajaxToolkit:AutoCompleteExtender> 
                </td>
            </tr>
             </table></div>
        </div>
         <br />
            <asp:Panel ID="Panel1" runat="server">
           <div style="overflow-x:auto">
              <div id="Print">
              <table>
                    
                    <tr>
                          <%-- SELECT Top 1 ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo,
   a.WorkId,b.Arthsankalpiyyear,a.Akrmank,a.Type,a.Upvibhag,a.LekhaShirsh,a.KamacheName,
   a.ThekedaarName,a.NividaKrmank,a.NividaAmt,a.NividaDate,a.KamPurnDate,b.DeyakachiSadyasthiti,
   b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.MagilKharch,
   b.Magni,b.VarshbharatilKharch,b.AikunKharch,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,
   a.Shera,a.Img1,a.Img2,a.Img3
     FROM BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID  order by SrNo desc --%>
                        <asp:GridView ID="GridView2" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false" Caption='<h1>इमारत बांधकाम अहवालाची माहिती</h1>'>
                           <Columns>
                            <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्क आयडी" ControlStyle-ForeColor="Black" ItemStyle-Width="50px"  >  </asp:BoundField>
                            <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="अर्थसंकल्पीय वर्ष" ControlStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="पृष्ठ क्र/बाब" ControlStyle-ForeColor="Black" ItemStyle-Width="50px" >  </asp:BoundField>
                            <asp:BoundField DataField="Type" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रकार" ControlStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="Upvibhag" HeaderStyle-HorizontalAlign="Center" HeaderText="उपविभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="LekhaShirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="ThekedaarName" HeaderStyle-HorizontalAlign="Center" HeaderText="ठेकेदाराचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="NividaKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="NividaAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा रक्कम" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="NividaDate" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="KamPurnDate" HeaderStyle-HorizontalAlign="Center" HeaderText="काम पूर्ण तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="DeyakachiSadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="देयकाची सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="मार्च अखेर खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="AkunAnudan" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण अनुदान" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="Chalumonth" HeaderStyle-HorizontalAlign="Center" HeaderText="चालू महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Chalukharch" HeaderStyle-HorizontalAlign="Center" HeaderText="चालू खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="Magilmonth" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="MagilKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="मागणी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="VarshbharatilKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्षभरातील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="AikunKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="Pahanikramank" HeaderStyle-HorizontalAlign="Center" HeaderText="पाहणी क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="PahaniMudye" HeaderStyle-HorizontalAlign="Center" HeaderText="पाहणी मुदये" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="शेरा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो 1"></asp:ImageField>
                            <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो 2"></asp:ImageField>
                            <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो 3"> </asp:ImageField>
                        </Columns>
                     </asp:GridView>
           
           <asp:GridView ID="GridView1" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false" Caption='<h1>इमारत बांधकाम अहवालाची माहिती</h1>'>
                        
                          <Columns>
                            <%--  select top 1 ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,
  a.Akrmank,a.Type,a.Dist,a.Taluka,a.Upvibhag,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,
  a.UpabhyantaName,a.UpAbhiyantaMobile,a.JuniorEngineerName,JuniorEngineerMobile,a.KhasdaracheName,
  a.AmdaracheName,a.SubType,a.LekhaShirsh,a.LekhaShirshName,a.ArthsankalpiyBab,a.KamacheName,
  a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.TrantrikAmt,
  a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,
  a.NividaDate,a.KamachiMudat,a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,
  b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.Magilkharch,
  b.VarshbharatilKharch,b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,a.Shera 
   from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID 
   where a.SubType=N'महसूल व वन विभाग' order by SrNo desc--%>
                            <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्क आयडी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="अर्थसंकल्पीय वर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="पृष्ठ क्र/बाब" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Type" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रकार" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Dist" HeaderStyle-HorizontalAlign="Center" HeaderText="जिल्हा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Taluka" HeaderStyle-HorizontalAlign="Center" HeaderText="तालुका" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Upvibhag" HeaderStyle-HorizontalAlign="Center" HeaderText="उपविभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ShakhaAbhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="शाखा अभियंताचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ShakhaAbhiyantMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल नंबर" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="UpabhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="उपभियंताचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="UpAbhiyantaMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल नंबर" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KhasdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="खासदारांचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="AmdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="आमदारांचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="SubType" HeaderStyle-HorizontalAlign="Center" HeaderText="विभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="LekhaShirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="LekhaShirshName" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PrashaskiyKramank" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PrashaskiyDate" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PrashaskiyAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="TrantrikKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="TrantrikDate" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="TrantrikAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Kamachevav" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचा वाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ThekedaarName" HeaderStyle-HorizontalAlign="Center" HeaderText="ठेकेदाराचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ThekedarMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल नंबर" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा किमंत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="karyarambhadesh" HeaderStyle-HorizontalAlign="Center" HeaderText="कार्यारंभ आदेश" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaDate" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="kamachiMudat" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाची मुदत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KamPurnDate" HeaderStyle-HorizontalAlign="Center" HeaderText="काम पूर्ण तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="MudatVadhiDate" HeaderStyle-HorizontalAlign="Center" HeaderText="मुदत वाढीची तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DeyakachiSadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="देयकाची सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="मार्च अखेर खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="AkunAnudan" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण अनुदान" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Chalumonth" HeaderStyle-HorizontalAlign="Center" HeaderText="चालू महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Chalukharch" HeaderStyle-HorizontalAlign="Center" HeaderText="चालू खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magilmonth" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magilkharch" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="मागणी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="VarshbharatilKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्षभरातील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="AikunKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Pahanikramank" HeaderStyle-HorizontalAlign="Center" HeaderText="पाहणीक्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PahaniMudye" HeaderStyle-HorizontalAlign="Center" HeaderText="पाहणी मुदये" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="शेरा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो 1"/>
                            <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो 2"/>
                            <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो 3"/>
                        </Columns>
                   </asp:GridView>
            
             
                     <%-- select ROW_NUMBER() over  (order by b.WorkId)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],
                         a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[LekhaShirsh],
                         a.[KamacheName],a.[JobNo],a.[RoadNo],a.[RoadLength],a.[SanctionDate]
                        ,a.[SanctionAmount],b.[MarchEndingExpn],b.[Tartud],b.[Chalukharch],b.[Magilkharch],
                        b.[Magni],a.[NividaDate],a.[KamPurnDate],a.[NividaKrmank],a.[karyarambhadesh],
                        a.[NividaAmt], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera],a.[Img1],a.[Img2],a.[Img3]from [BudgetMasterCRF] as a join CRFProvision as b on a.WorkID=b.WorkID  order by SrNo --%>
                      <asp:GridView ID="crfmpr" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false" Caption='<h1>Central Road Fund Report</h1>'>
                         
                          <Columns>
                            <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="Work_ID" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="Budget Year" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Dist" HeaderStyle-HorizontalAlign="Center" HeaderText="Dist" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Taluka" HeaderStyle-HorizontalAlign="Center" HeaderText="Taluka" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="PageNo" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="LekhaShirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="Account Head" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="Work Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="JobNo" HeaderStyle-HorizontalAlign="Center" HeaderText="Job No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="RoadNo" HeaderStyle-HorizontalAlign="Center" HeaderText="Road No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="RoadLength" HeaderStyle-HorizontalAlign="Center" HeaderText="Road Length" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="SanctionDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Sanction Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="SanctionAmount" HeaderStyle-HorizontalAlign="Center" HeaderText="Sanction Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="March Ending Expdr." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="OBP" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Chalukharch" HeaderStyle-HorizontalAlign="Center" HeaderText="During Month Expedr." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magilkharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Upto Month Expedr." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="Demand" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Tender Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KamPurnDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Work Completion" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="Tender No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="karyarambhadesh" HeaderStyle-HorizontalAlign="Center" HeaderText="Work Order" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="Tender Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="Status of Work" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Pahanikramank" HeaderStyle-HorizontalAlign="Center" HeaderText="Survey No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PahaniMudye" HeaderStyle-HorizontalAlign="Center" HeaderText="Survey Points" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="Remarks" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 1"/>
                            <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 2"/>
                            <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 3"/>
                          </Columns>
                      </asp:GridView>
                 
                          <asp:GridView ID="crfmaster" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false" Caption='<h1>Central Road Fund</h1>'>
                         
                          <Columns>
                                                          
                            <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="Work_ID" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="Budget Year" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Dist" HeaderStyle-HorizontalAlign="Center" HeaderText="Dist" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Taluka" HeaderStyle-HorizontalAlign="Center" HeaderText="Taluka" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="Page No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Upvibhag" HeaderStyle-HorizontalAlign="Center" HeaderText="Division" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="LekhaShirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="Account Head" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="LekhaShirshName" HeaderStyle-HorizontalAlign="Center" HeaderText="Head_Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="SubType" HeaderStyle-HorizontalAlign="Center" HeaderText="Type" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ShakhaAbhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="Branch Engineer" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ShakhaAbhiyantMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="Mobile" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="UpabhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="Deputy Engineer" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="UpAbhiyantaMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="Mobile" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KhasdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="MP Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="AmdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="MLA Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="Work_Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Kamachavav" HeaderStyle-HorizontalAlign="Center" HeaderText="Scope Of Work" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PrashaskiyKramank" HeaderStyle-HorizontalAlign="Center" HeaderText="Administrative No." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PrashaskiyDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Administrative Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PrashaskiyAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="Administrative Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="TrantrikKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="Technical No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="TrantrikDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Technical Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="TrantrikAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="Technical Amount" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ThekedaarName" HeaderStyle-HorizontalAlign="Center" HeaderText="Contractor Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ThekedarMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="Mobile" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="Tender No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="Tender Amt in_Lakh" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="karyarambhadesh" HeaderStyle-HorizontalAlign="Center" HeaderText="Work Order" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Tender Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="kamachiMudat" HeaderStyle-HorizontalAlign="Center" HeaderText="Term Work" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KamPurnDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Complete Work Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="JobNo" HeaderStyle-HorizontalAlign="Center" HeaderText="JobNo" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="RoadNo" HeaderStyle-HorizontalAlign="Center" HeaderText="RoadNo" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="RoadLength" HeaderStyle-HorizontalAlign="Center" HeaderText="RoadLength" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="SanctionDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Sanction Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="SanctionAmount" HeaderStyle-HorizontalAlign="Center" HeaderText="Sanction Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="APhysicalScope" HeaderStyle-HorizontalAlign="Center" HeaderText="Physical Scope" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ACommulative" HeaderStyle-HorizontalAlign="Center" HeaderText="Commulative" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ATarget" HeaderStyle-HorizontalAlign="Center" HeaderText="Target" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="AAchievement" HeaderStyle-HorizontalAlign="Center" HeaderText="AAchievement" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <%--<asp:BoundField DataField="BPhysicalScope" HeaderStyle-HorizontalAlign="Center" HeaderText="Sanction_Amount" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="BCommulative" HeaderStyle-HorizontalAlign="Center" HeaderText="WBM_Wide PhysicalScope" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="BTarget" HeaderStyle-HorizontalAlign="Center" HeaderText="WBM_Wide Commulative" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="BAchievement" HeaderStyle-HorizontalAlign="Center" HeaderText="WBM_Wide Target" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="CPhysicalScope" HeaderStyle-HorizontalAlign="Center" HeaderText="WBM_Wide Achievement" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="CCommulative" HeaderStyle-HorizontalAlign="Center" HeaderText="B.T.(kms) PhysicalScope" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="CTarget" HeaderStyle-HorizontalAlign="Center" HeaderText="WBM_Wide Achievement" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="CAchievement" HeaderStyle-HorizontalAlign="Center" HeaderText="WBM_Wide Achievement" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DPhysicalScope" HeaderStyle-HorizontalAlign="Center" HeaderText="WBM_Wide Achievement" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DCommulative" HeaderStyle-HorizontalAlign="Center" HeaderText="B.T.(kms) Commulative" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DTarget" HeaderStyle-HorizontalAlign="Center" HeaderText="B.T.(kms) Target" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DAchievement" HeaderStyle-HorizontalAlign="Center" HeaderText="B.T.(kms) Achievement" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="EPhysicalScope" HeaderStyle-HorizontalAlign="Center" HeaderText="C.D.Works(Nos.) PhysicalScope" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ECommulative" HeaderStyle-HorizontalAlign="Center" HeaderText="C.D.Works(Nos.) Commulative" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ETarget" HeaderStyle-HorizontalAlign="Center" HeaderText="C.D.Works(Nos.) Target" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="EAchievement" HeaderStyle-HorizontalAlign="Center" HeaderText="C.D.Works(Nos.) Achievement" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />--%>
                            <asp:BoundField DataField="MudatVadhiDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Growth Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DeyakachiSadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="Payment Status" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="March Ending Expdr." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DTakunone" HeaderStyle-HorizontalAlign="Center" HeaderText="First Grant" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Takunone" HeaderStyle-HorizontalAlign="Center" HeaderText="Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DTakuntwo" HeaderStyle-HorizontalAlign="Center" HeaderText="Second Grant" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Takuntwo" HeaderStyle-HorizontalAlign="Center" HeaderText="Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                           <%-- <asp:BoundField DataField="DTakunthree" HeaderStyle-HorizontalAlign="Center" HeaderText="Majorbridges(Nos) Achievement" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Takunthree" HeaderStyle-HorizontalAlign="Center" HeaderText="Provision" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DTakunfour" HeaderStyle-HorizontalAlign="Center" HeaderText="First_Grant" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Takunfour" HeaderStyle-HorizontalAlign="Center" HeaderText="First_Grant_Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            --%><asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="Provision" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="AkunAnudan" HeaderStyle-HorizontalAlign="Center" HeaderText="Total Grant" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Chalumonth" HeaderStyle-HorizontalAlign="Center" HeaderText="During Month" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Chalukharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magilmonth" HeaderStyle-HorizontalAlign="Center" HeaderText="Upto Month" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magilkharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="Demand" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="VarshbharatilKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Year Expndr." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="AikunKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Total Expndr." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="Status" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Pahanikramank" HeaderStyle-HorizontalAlign="Center" HeaderText="Survey No." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PahaniMudye" HeaderStyle-HorizontalAlign="Center" HeaderText="Deal With Issue" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Jan" HeaderStyle-HorizontalAlign="Center" HeaderText="Jan" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Feb" HeaderStyle-HorizontalAlign="Center" HeaderText="Feb" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Mar" HeaderStyle-HorizontalAlign="Center" HeaderText="Mar" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Apr" HeaderStyle-HorizontalAlign="Center" HeaderText="Apr" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="May" HeaderStyle-HorizontalAlign="Center" HeaderText="May" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Jun" HeaderStyle-HorizontalAlign="Center" HeaderText="Jun" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Jul" HeaderStyle-HorizontalAlign="Center" HeaderText="Jul" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Aug" HeaderStyle-HorizontalAlign="Center" HeaderText="Aug" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Sep" HeaderStyle-HorizontalAlign="Center" HeaderText="Sep" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Oct" HeaderStyle-HorizontalAlign="Center" HeaderText="Oct" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Nov" HeaderStyle-HorizontalAlign="Center" HeaderText="Nov" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Dec" HeaderStyle-HorizontalAlign="Center" HeaderText="Dec" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="Shera" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 1"/>
                            <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 2"/>
                            <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 3"/>
                           
                          </Columns>
                      </asp:GridView>
                    <asp:GridView ID="nabardmpr" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false"  Caption='<h1>Budget NABARD Report</h1>'>
                          
                          <Columns>
                                <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="Work_ID" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="Budget Year" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="PageNo" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Dist" HeaderStyle-HorizontalAlign="Center" HeaderText="Dist" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Taluka" HeaderStyle-HorizontalAlign="Center" HeaderText="Taluka" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="Work Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="RDF_NO" HeaderStyle-HorizontalAlign="Center" HeaderText="RIDF_NO" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="PIC_NO" HeaderStyle-HorizontalAlign="Center" HeaderText="PIC_NO" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="PrashaskiyAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="AA cost Rs in lakhs" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="TrantrikAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="Ts cost Rs in lakhs" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="TrantrikKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="Ts No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="TrantrikDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Ts Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="Expenditure up to MAR" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="Budget Provision in lakhs" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="Demand in lakhs" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Chalumonth" HeaderStyle-HorizontalAlign="Center" HeaderText="Expendr. Up to Month" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Chalukharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Expendr." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Magilmonth" HeaderStyle-HorizontalAlign="Center" HeaderText="Expendr. During Month" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Magilkharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Expendr." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="Status of Work" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Pahanikramank" HeaderStyle-HorizontalAlign="Center" HeaderText="Date of Completion" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="PCR" HeaderStyle-HorizontalAlign="Center" HeaderText="PCR Status" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="Remark" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 1"/>
                                <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 2"/>
                                <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 3"/>
                          </Columns>
                      </asp:GridView>
                     <asp:GridView ID="nabardmaster" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false"  Caption='<h1>Budget NABARD Report</h1>'>
                          
                          <Columns>
  <%--select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type],a.[Dist],
      a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[Lekhashirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],
      a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],
      a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],
      a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],
      a.[kamachiMudat],a.[KamPurnDate],a.[RDF_NO],a.[PIC_NO],a.[PCR],a.[Road_No],a.[LengthRoad],a.[RoadType],a.[WBMI_km],
      a.[WBMII_km],a.[WBMIII_km],a.[BBM_km],a.[Carpet_km],a.[Surface_km],a.[CD_Works_No] ,b.[MudatVadhiDate],
      b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo] ,b.[Takuntwo],b.[DTakunthree],
      b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],
      b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],
      b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera],a.[Img1],a.[Img2],
      a.[Img3] from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID--%>
                            <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="Work_ID" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="Budget Year" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Type" HeaderStyle-HorizontalAlign="Center" HeaderText="Type" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Dist" HeaderStyle-HorizontalAlign="Center" HeaderText="District" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Taluka" HeaderStyle-HorizontalAlign="Center" HeaderText="Taluka" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="PageNo." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Upvibhag" HeaderStyle-HorizontalAlign="Center" HeaderText="Division" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Lekhashirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="Account_Head" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="LekhaShirshName" HeaderStyle-HorizontalAlign="Center" HeaderText="Head_Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="SubType" HeaderStyle-HorizontalAlign="Center" HeaderText="Sub-Division" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ShakhaAbhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="Branch_Engineer" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ShakhaAbhiyantMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="Mobile_No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="UpabhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="Deputy_Engineer" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="UpAbhiyantaMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="Mobile_No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KhasdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="MP Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="AmdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="MLA Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="Work Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Kamachavav" HeaderStyle-HorizontalAlign="Center" HeaderText="Scope_Of_Work" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PrashaskiyKramank" HeaderStyle-HorizontalAlign="Center" HeaderText="Administrative_No." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PrashaskiyDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Administrative_Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PrashaskiyAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="Administrative_Amount" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="TrantrikKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="Technical_No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="TrantrikDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Technical_Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="TrantrikAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="Technical_Amount" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ThekedaarName" HeaderStyle-HorizontalAlign="Center" HeaderText="Contractor_Name" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="ThekedarMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="Mobile_No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="Tender_No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="Tender_Amt_in_Lakh" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="karyarambhadesh" HeaderStyle-HorizontalAlign="Center" HeaderText="Work_Order" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="NividaDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Tender_Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="kamachiMudat" HeaderStyle-HorizontalAlign="Center" HeaderText="Term Work" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="KamPurnDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Complete_Work_Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="RDF_NO" HeaderStyle-HorizontalAlign="Center" HeaderText="RIDF_No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PIC_NO" HeaderStyle-HorizontalAlign="Center" HeaderText="PIC_NO" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PCR" HeaderStyle-HorizontalAlign="Center" HeaderText="PCR" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Road_No" HeaderStyle-HorizontalAlign="Center" HeaderText="Road_No" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="LengthRoad" HeaderStyle-HorizontalAlign="Center" HeaderText="Length_Road" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="RoadType" HeaderStyle-HorizontalAlign="Center" HeaderText="Type" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="WBMI_km" HeaderStyle-HorizontalAlign="Center" HeaderText="WBM_I" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="WBMII_km" HeaderStyle-HorizontalAlign="Center" HeaderText="WBM_II" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="WBMIII_km" HeaderStyle-HorizontalAlign="Center" HeaderText="WBM_III" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="BBM_km" HeaderStyle-HorizontalAlign="Center" HeaderText="BBM" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Carpet_km" HeaderStyle-HorizontalAlign="Center" HeaderText="Carpet_km" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Surface_km" HeaderStyle-HorizontalAlign="Center" HeaderText="Surface_km" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="CD_Works_No" HeaderStyle-HorizontalAlign="Center" HeaderText="CD_WorksNo" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="MudatVadhiDate" HeaderStyle-HorizontalAlign="Center" HeaderText="Growth Date" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DeyakachiSadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="PaymentStatus" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="March Ending" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DTakunone" HeaderStyle-HorizontalAlign="Center" HeaderText="First_Grant" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Takunone" HeaderStyle-HorizontalAlign="Center" HeaderText="First_Grant_Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DTakuntwo" HeaderStyle-HorizontalAlign="Center" HeaderText="Second_Grant" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Takuntwo" HeaderStyle-HorizontalAlign="Center" HeaderText="Second_Grant_Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DTakunthree" HeaderStyle-HorizontalAlign="Center" HeaderText="Third_Grant" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Takunthree" HeaderStyle-HorizontalAlign="Center" HeaderText="Third_Grant_Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="DTakunfour" HeaderStyle-HorizontalAlign="Center" HeaderText="Year_Grant" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="Provision" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Jan" HeaderStyle-HorizontalAlign="Center" HeaderText="Jan" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Feb" HeaderStyle-HorizontalAlign="Center" HeaderText="Feb" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Mar" HeaderStyle-HorizontalAlign="Center" HeaderText="Mar" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Apr" HeaderStyle-HorizontalAlign="Center" HeaderText="Apr" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="May" HeaderStyle-HorizontalAlign="Center" HeaderText="May" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Jun" HeaderStyle-HorizontalAlign="Center" HeaderText="Jun" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Jul" HeaderStyle-HorizontalAlign="Center" HeaderText="Jul" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Aug" HeaderStyle-HorizontalAlign="Center" HeaderText="Aug" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Sep" HeaderStyle-HorizontalAlign="Center" HeaderText="Sep" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Oct" HeaderStyle-HorizontalAlign="Center" HeaderText="Oct" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Nov" HeaderStyle-HorizontalAlign="Center" HeaderText="Nov" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Dec" HeaderStyle-HorizontalAlign="Center" HeaderText="Dec" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="AkunAnudan" HeaderStyle-HorizontalAlign="Center" HeaderText="Total Grant" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Chalumonth" HeaderStyle-HorizontalAlign="Center" HeaderText="PresentMonth" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Chalukharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magilmonth" HeaderStyle-HorizontalAlign="Center" HeaderText="PreviousMonth" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magilkharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Amt" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="Demand" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="VarshbharatilKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Year Cost" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="AikunKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="Total Expdr." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="Work Status" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Pahanikramank" HeaderStyle-HorizontalAlign="Center" HeaderText="Date of Completion" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="PahaniMudye" HeaderStyle-HorizontalAlign="Center" HeaderText="Survey Points" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="Remarks" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                            <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 1"/>     
                            <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 2"/>
                            <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "Photo 3"/>
                       </Columns>
                      </asp:GridView>
                    <asp:GridView ID="roadmpr" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false" Caption='<h1>Budget Road Report</h1>'>
                          
                          <Columns>
                                <%-- [WorkId],[Arthsankalpiyyear] ,[Akrmank] ,[Type],[Dist],[Taluka],[Upvibhag],[PageNo],[ArthsankalpiyBab]
      ,[JulyBab],[LekhaShirsh],[LekhaShirshName],[SubType],[ShakhaAbhyantaName],[ShakhaAbhiyantMobile]
      ,[UpabhyantaName],[UpAbhiyantaMobile],[KhasdaracheName],[AmdaracheName],[KamacheName],[PrashaskiyKramank]
      ,[PrashaskiyDate],[PrashaskiyAmt],[TrantrikKrmank],[TrantrikDate],[TrantrikAmt],[Kamachevav],[ThekedaarName]
      ,[ThekedarMobile],[NividaKrmank],[NividaAmt],[karyarambhadesh],[NividaDate],[kamachiMudat],[KamPurnDate]
      ,[Sadyasthiti],[Pahanikramank],[PahaniMudye],[Shera],[Img1],[Img2],[Img3]
            
            [WorkId],[Arthsankalpiyyear],[MudatVadhiDate],[DeyakachiSadyasthiti],[ManjurAmt],[MarchEndingExpn],[UrvaritAmt],[DTakunone]
            ,[Takunone],[DTakuntwo],[Takuntwo],[DTakunthree],[Takunthree],[DTakunfour],[Takunfour],[Tartud],[Jan],[Feb],[Mar]
            ,[Apr],[May],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec],[AkunAnudan],[Chalumonth],[Chalukharch],[Magilmonth]
            ,[Magilkharch],[Magni],[VarshbharatilKharch],[AikunKharch]      --%>

                                <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्क आयडी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="अर्थसंकल्पीय वर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="PageNo" HeaderStyle-HorizontalAlign="Center" HeaderText="पेज क्र." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="बाब क्र." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="JulyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="जुलै २०१६ बाब क्र./पान क्र." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Type" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रकार" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Upvibhag" HeaderStyle-HorizontalAlign="Center" HeaderText="उपविभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="SubType" HeaderStyle-HorizontalAlign="Center" HeaderText="विभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="LekhaShirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="ManjurAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="मंजूर अंदाजित किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="मार्च अखेर खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="UrvaritAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="उर्वरीत किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Takunone" HeaderStyle-HorizontalAlign="Center" HeaderText="मार्च अर्थसंकल्पीय तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Takuntwo" HeaderStyle-HorizontalAlign="Center" HeaderText="जुलै अर्थसंकल्पीय तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण अर्थसंकल्पीय तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="AkunAnudan" HeaderStyle-HorizontalAlign="Center" HeaderText="वितरित तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="मागणी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="शेरा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" />
                                <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो १"/>
                                <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो २"/>
                                <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो ३"/>
                          </Columns>
                      </asp:GridView>
                      <%--select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],
  a.[Type],a.[Dist],a.[Taluka],a.[Upvibhag],a.[PageNo],a.[ArthsankalpiyBab],[JulyBab],a.[Lekhashirsh],a.[LekhaShirshName],
  a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],
  a.[AmdaracheName],a.[KamacheName],[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],
  a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],
  a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[ManjurAmt],
  b.[MarchEndingExpn],b.[UrvaritAmt],b.[DTakunone],  b.[Takunone],b.[DTakuntwo] ,b.[Takuntwo],b.[DTakunthree],
  b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],  b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],
  b.[Jul],b.[Aug], b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan], b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],
  b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],
  a.[Shera], a.[Img1],a.[Img2],a.[Img3] from BudgetMasterRoad as a  join RoadProvision as b on a.WorkID=b.WorkID--%>
                      <asp:GridView ID="roadmaster" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false"  Caption='<h1>Budget Road Report</h1>'>
                          
                           <Columns>
                            <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्क आयडी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="अर्थसंकल्पीय  वर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="Type" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रकार" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                            <asp:BoundField DataField="Dist" HeaderStyle-HorizontalAlign="Center" HeaderText="जिल्हा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Taluka" HeaderStyle-HorizontalAlign="Center" HeaderText="तालुका" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="PageNo" HeaderStyle-HorizontalAlign="Center" HeaderText="पेज क्र." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="अर्थसंकल्पीय बाब" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="JulyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="जुलै बाब" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Lekhashirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="LekhaShirshName" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्षकाचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="SubType" HeaderStyle-HorizontalAlign="Center" HeaderText="विभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="ShakhaAbhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="शाखा अभियंता नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="ShakhaAbhiyantMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="UpabhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="उपअभियंता नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="UpAbhiyantaMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="KhasdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="खासदारांचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="AmdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="आमदारांचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Kamachevav" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचा वाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="PrashaskiyKramank" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="PrashaskiyDate" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="PrashaskiyAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="TrantrikKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="TrantrikDate" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="TrantrikAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="ThekedaarName" HeaderStyle-HorizontalAlign="Center" HeaderText="ठेकेदार नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="ThekedarMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाईल" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="NividaKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="NividaAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा रक्कम" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="karyarambhadesh" HeaderStyle-HorizontalAlign="Center" HeaderText="कार्यारंभ आदेश" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="NividaDate" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="kamachiMudat" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाची मुदत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="KamPurnDate" HeaderStyle-HorizontalAlign="Center" HeaderText="काम पूर्ण तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="MudatVadhiDate" HeaderStyle-HorizontalAlign="Center" HeaderText="मुदत वाढ दिनांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="DeyakachiSadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="देयकाची सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="ManjurAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="मंजूर किमंत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="मार्च अखेर खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="UrvaritAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="उर्वरीत किमंत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="DTakunone" HeaderStyle-HorizontalAlign="Center" HeaderText="तरतूद महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Takunone" HeaderStyle-HorizontalAlign="Center" HeaderText="किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="DTakuntwo" HeaderStyle-HorizontalAlign="Center" HeaderText="तरतूद महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Takuntwo" HeaderStyle-HorizontalAlign="Center" HeaderText="किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Jan" HeaderStyle-HorizontalAlign="Center" HeaderText="जानेवारी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Feb" HeaderStyle-HorizontalAlign="Center" HeaderText="फेब्रुवारी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Mar" HeaderStyle-HorizontalAlign="Center" HeaderText="मार्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Apr" HeaderStyle-HorizontalAlign="Center" HeaderText="एप्रिल" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="May" HeaderStyle-HorizontalAlign="Center" HeaderText="मे" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Jun" HeaderStyle-HorizontalAlign="Center" HeaderText="जून" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Jul" HeaderStyle-HorizontalAlign="Center" HeaderText="जुलै" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Aug" HeaderStyle-HorizontalAlign="Center" HeaderText="ऑगस्ट" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Sep" HeaderStyle-HorizontalAlign="Center" HeaderText="सेप्टेंबर" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Oct" HeaderStyle-HorizontalAlign="Center" HeaderText="ओक्टोंबर" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Nov" HeaderStyle-HorizontalAlign="Center" HeaderText="नोव्हेंबर" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Dec" HeaderStyle-HorizontalAlign="Center" HeaderText="डिसेंबर" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="AkunAnudan" HeaderStyle-HorizontalAlign="Center" HeaderText="एकूण अनुदान" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Chalumonth" HeaderStyle-HorizontalAlign="Center" HeaderText="चालू महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Chalukharch" HeaderStyle-HorizontalAlign="Center" HeaderText="चालू खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Magilmonth" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Magilkharch" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="मागणी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="VarshbharatilKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्षभरातील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="AikunKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Pahanikramank" HeaderStyle-HorizontalAlign="Center" HeaderText="पाहणी क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="PahaniMudye" HeaderStyle-HorizontalAlign="Center" HeaderText="पाहणी मुदये" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="शेरा " ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                            <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो १">
                                <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                            <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो २">
                                <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                            <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो ३">
                                <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                           </Columns>
                      </asp:GridView>
                        <%--  WorkId,Arthsankalpiyyear,ArthsankalpiyBab,Type,Upvibhag,SubType,LekhaShirsh,KamacheName,
              PrashaskiyAmt, TrantrikKrmank,TrantrikDate,NividaKrmank,NividaDate,ManjurAmt,MarchEndingExpn,
             UrvaritAmt,Tartud,Magilkharch,AkunAnudan,Magni,Sadyasthiti,Shera --%>
                        <asp:GridView ID="MLAMPR" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false"  Caption='<h1>Budget MLA Report</h1>'>
                             <Columns>
                                <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्क आयडी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="अर्थसंकल्पीय  वर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="बाब क्र." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="Type" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रकार" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Upvibhag" HeaderStyle-HorizontalAlign="Center" HeaderText="उपविभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="SubType" HeaderStyle-HorizontalAlign="Center" HeaderText="विभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="LekhaShirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PrashaskiyAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="TrantrikKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="TrantrikDate" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक दिनांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaDate" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ManjurAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="अपेक्षित खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="मार्च अखेर खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="UrvaritAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="उर्वरित किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Magilkharch" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="AkunAnudan" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण अनुदान" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="मागणी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="शेरा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
             
                               <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो १">
                               <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                            <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो २">
                                <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                            <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो ३">
                                <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                           </Columns>
                            </asp:GridView>
                        <%--select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,
   a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka, a.Upvibhag,a.PageNo,a.JulyBab,
    a.LekhaShirsh,a.LekhaShirshName, a.SubType,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,
   a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.KamacheName,
  a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank, a.TrantrikDate,
  a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,
  a.Karyarambhadesh,a.NividaDate,a.KamachiMudat, a.KamPurnDate,b.MudatVadhiDate,
 b.DeyakachiSadyasthiti,b.ManjurAmt, b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.AkunAnudan,
 b.Chalumonth, b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch, b.AikunKharch,
b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye, a.Shera,a.Img1,a.Img2,a.Img3,b.Jan,b.Feb,
 b.Mar,b.Apr,b.May,b.Jun,b.Jul,b.Aug,b.Sep,b.Oct,b.Nov,b.Dec from BudgetMasterMLA as 
             a join MLAProvision as b on a.WorkID=b.WorkID --%>
                         <asp:GridView ID="MLAmaster" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false"  Caption='<h1>Budget MLA Report</h1>'>
                             <Columns>
                                <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्क आयडी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="अर्थसंकल्पीय  वर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="बाब क्र." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="Type" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रकार" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Dist" HeaderStyle-HorizontalAlign="Center" HeaderText="जिल्हा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Taluka" HeaderStyle-HorizontalAlign="Center" HeaderText="तालुका" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Upvibhag" HeaderStyle-HorizontalAlign="Center" HeaderText="उपविभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PageNo" HeaderStyle-HorizontalAlign="Center" HeaderText="पेज नं." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <%--<asp:BoundField DataField="JulyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>--%>
                                <asp:BoundField DataField="LekhaShirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="LekhaShirshName" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="SubType" HeaderStyle-HorizontalAlign="Center" HeaderText="विभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ShakhaAbhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="शाखा अभियंता" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ShakhaAbhiyantMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="UpabhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="उपभियंता" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="UpAbhiyantaMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="KhasdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="खासदाराचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="AmdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="आमदाराचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PrashaskiyKramank" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PrashaskiyDate" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PrashaskiyAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="TrantrikKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="TrantrikDate" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="TrantrikAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="Kamachevav" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचा वाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ThekedaarName" HeaderStyle-HorizontalAlign="Center" HeaderText="ठेकेदार नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ThekedarMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Karyarambhadesh" HeaderStyle-HorizontalAlign="Center" HeaderText="कार्यारंभ आदेश" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaDate" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="KamachiMudat" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाची मुदत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="KamPurnDate" HeaderStyle-HorizontalAlign="Center" HeaderText="काम पूर्ण तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="MudatVadhiDate" HeaderStyle-HorizontalAlign="Center" HeaderText="मुदतवाढी तारीख " ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="DeyakachiSadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="देयकाची सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ManjurAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="मंजूर किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="मार्च अखेर खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="UrvaritAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="उर्वरित किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="AkunAnudan" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण अनुदान" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Chalumonth" HeaderStyle-HorizontalAlign="Center" HeaderText="चालू महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Chalukharch" HeaderStyle-HorizontalAlign="Center" HeaderText="चालू खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Magilmonth" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Magilkharch" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="VarshbharatilKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्षभरातील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="AikunKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="मागणी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Pahanikramank" HeaderStyle-HorizontalAlign="Center" HeaderText="पाहणी क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PahaniMudye" HeaderStyle-HorizontalAlign="Center" HeaderText="पाहणी मुदये" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="शेरा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Jan" HeaderStyle-HorizontalAlign="Center" HeaderText="Jan" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Feb" HeaderStyle-HorizontalAlign="Center" HeaderText="Feb" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Mar" HeaderStyle-HorizontalAlign="Center" HeaderText="Mar" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Apr" HeaderStyle-HorizontalAlign="Center" HeaderText="Apr" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="May" HeaderStyle-HorizontalAlign="Center" HeaderText="May" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Jun" HeaderStyle-HorizontalAlign="Center" HeaderText="Jun" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Jul" HeaderStyle-HorizontalAlign="Center" HeaderText="Jul" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Aug" HeaderStyle-HorizontalAlign="Center" HeaderText="Aug" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Sep" HeaderStyle-HorizontalAlign="Center" HeaderText="Sep" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Oct" HeaderStyle-HorizontalAlign="Center" HeaderText="Oct" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Nov" HeaderStyle-HorizontalAlign="Center" HeaderText="Nov" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Dec" HeaderStyle-HorizontalAlign="Center" HeaderText="Dec" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                               <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो १">
                               <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                               <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो २">
                               <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                               <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो ३">
                               <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                           </Columns>
                            </asp:GridView>
                        <%--WorkId,Arthsankalpiyyear,ArthsankalpiyBab,Type,Upvibhag,SubType,LekhaShirsh,KamacheName,
            PrashaskiyKramank,PrashaskiyDate,PrashaskiyAmt,TrantrikKrmank,TrantrikDate,TrantrikAmt,
            NividaAmt,NividaKrmank,NividaDate,ManjurAmt,MarchEndingExpn,UrvaritAmt,Tartud,
            Magilkharch,AkunAnudan,Magni,Sadyasthiti,Shera --%>
                         <asp:GridView ID="MPMPR" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false"  Caption='<h1>Budget MP Report</h1>'>
                             <Columns>
                                <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्क आयडी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="अर्थसंकल्पीय  वर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="बाब क्र." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="Type" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रकार" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Upvibhag" HeaderStyle-HorizontalAlign="Center" HeaderText="उपविभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="SubType" HeaderStyle-HorizontalAlign="Center" HeaderText="विभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="LekhaShirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PrashaskiyKramank" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय क्र." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PrashaskiyDate" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PrashaskiyAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="TrantrikKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="TrantrikDate" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक दिनांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="TrantrikAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaDate" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ManjurAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="अपेक्षित खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="मार्च अखेर खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="UrvaritAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="उर्वरित किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Magilkharch" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="AkunAnudan" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण अनुदान" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="मागणी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="शेरा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
             
                               <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो १">
                               <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                            <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो २">
                                <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                            <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो ३">
                                <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                           </Columns>
                            </asp:GridView>
                         <asp:GridView ID="MPmaster" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%" AutoGenerateColumns="false"  Caption='<h1>Budget MP Report</h1>'>
                          <Columns>
                                 <asp:BoundField DataField="WorkId" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्क आयडी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="Arthsankalpiyyear" HeaderStyle-HorizontalAlign="Center" HeaderText="अर्थसंकल्पीय  वर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="ArthsankalpiyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="बाब क्र." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="Type" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रकार" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Dist" HeaderStyle-HorizontalAlign="Center" HeaderText="जिल्हा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Taluka" HeaderStyle-HorizontalAlign="Center" HeaderText="तालुका" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Upvibhag" HeaderStyle-HorizontalAlign="Center" HeaderText="उपविभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PageNo" HeaderStyle-HorizontalAlign="Center" HeaderText="पेज नं." ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <%--<asp:BoundField DataField="JulyBab" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>--%>
                                <asp:BoundField DataField="LekhaShirsh" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="LekhaShirshName" HeaderStyle-HorizontalAlign="Center" HeaderText="लेखाशीर्ष नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="SubType" HeaderStyle-HorizontalAlign="Center" HeaderText="विभाग" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ShakhaAbhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="शाखा अभियंता" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ShakhaAbhiyantMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="UpabhyantaName" HeaderStyle-HorizontalAlign="Center" HeaderText="उपभियंता" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="UpAbhiyantaMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="KhasdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="खासदाराचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="AmdaracheName" HeaderStyle-HorizontalAlign="Center" HeaderText="आमदाराचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="KamacheName" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचे नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PrashaskiyKramank" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PrashaskiyDate" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PrashaskiyAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="प्रशासकीय किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="TrantrikKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="TrantrikDate" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="TrantrikAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="तांत्रिक किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" > </asp:BoundField>
                                <asp:BoundField DataField="Kamachevav" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाचा वाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ThekedaarName" HeaderStyle-HorizontalAlign="Center" HeaderText="ठेकेदार नाव" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ThekedarMobile" HeaderStyle-HorizontalAlign="Center" HeaderText="मोबाइल" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaKrmank" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Karyarambhadesh" HeaderStyle-HorizontalAlign="Center" HeaderText="कार्यारंभ आदेश" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="NividaDate" HeaderStyle-HorizontalAlign="Center" HeaderText="निविदा तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="KamachiMudat" HeaderStyle-HorizontalAlign="Center" HeaderText="कामाची मुदत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="KamPurnDate" HeaderStyle-HorizontalAlign="Center" HeaderText="काम पूर्ण तारीख" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="MudatVadhiDate" HeaderStyle-HorizontalAlign="Center" HeaderText="मुदतवाढी तारीख " ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="DeyakachiSadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="देयकाची सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="ManjurAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="मंजूर किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="MarchEndingExpn" HeaderStyle-HorizontalAlign="Center" HeaderText="मार्च अखेर खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="UrvaritAmt" HeaderStyle-HorizontalAlign="Center" HeaderText="उर्वरित किंमत" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Tartud" HeaderStyle-HorizontalAlign="Center" HeaderText="तरतूद" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="AkunAnudan" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण अनुदान" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Chalumonth" HeaderStyle-HorizontalAlign="Center" HeaderText="चालू महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Chalukharch" HeaderStyle-HorizontalAlign="Center" HeaderText="चालू खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Magilmonth" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील महिना" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Magilkharch" HeaderStyle-HorizontalAlign="Center" HeaderText="मागील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="VarshbharatilKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="वर्षभरातील खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="AikunKharch" HeaderStyle-HorizontalAlign="Center" HeaderText="एकुण खर्च" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Magni" HeaderStyle-HorizontalAlign="Center" HeaderText="मागणी" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Sadyasthiti" HeaderStyle-HorizontalAlign="Center" HeaderText="सद्यस्थिती" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Pahanikramank" HeaderStyle-HorizontalAlign="Center" HeaderText="पाहणी क्रमांक" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="PahaniMudye" HeaderStyle-HorizontalAlign="Center" HeaderText="पाहणी मुदये" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Shera" HeaderStyle-HorizontalAlign="Center" HeaderText="शेरा" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Jan" HeaderStyle-HorizontalAlign="Center" HeaderText="Jan" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Feb" HeaderStyle-HorizontalAlign="Center" HeaderText="Feb" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Mar" HeaderStyle-HorizontalAlign="Center" HeaderText="Mar" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Apr" HeaderStyle-HorizontalAlign="Center" HeaderText="Apr" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="May" HeaderStyle-HorizontalAlign="Center" HeaderText="May" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Jun" HeaderStyle-HorizontalAlign="Center" HeaderText="Jun" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Jul" HeaderStyle-HorizontalAlign="Center" HeaderText="Jul" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Aug" HeaderStyle-HorizontalAlign="Center" HeaderText="Aug" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Sep" HeaderStyle-HorizontalAlign="Center" HeaderText="Sep" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Oct" HeaderStyle-HorizontalAlign="Center" HeaderText="Oct" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Nov" HeaderStyle-HorizontalAlign="Center" HeaderText="Nov" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                                <asp:BoundField DataField="Dec" HeaderStyle-HorizontalAlign="Center" HeaderText="Dec" ItemStyle-ForeColor="Black" ItemStyle-Width="50px" ></asp:BoundField>
                               <asp:ImageField DataImageUrlField="Img1" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो १">
                               <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                               <asp:ImageField DataImageUrlField="Img2" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो २">
                               <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                               <asp:ImageField DataImageUrlField="Img3" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText = "फोटो ३">
                               <ControlStyle Height="100px" Width="100px" />
                               </asp:ImageField>
                           </Columns>
                            </asp:GridView>

                  </tr>
                  <asp:GridView ID="datasearch" runat="server" RowStyle-VerticalAlign="Top" BorderStyle="Solid" BorderWidth="1px" Width="100%">
                  </asp:GridView>
                  </table>
                  </div>
               </div>
        </asp:Panel>
             </ContentTemplate>
        </asp:UpdatePanel>
     <br>
               <div>
                        <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary" Text="Print" Height="40px" Width="100px" OnClick="Print" TabIndex="77"  />
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-danger" Text="Back" Height="40px" Width="100px" TabIndex="78"/>
                        <asp:Button ID="BtnExcel" runat="server" CssClass="btn-success" Text="Excel"   Height="40px" Width="100px" TabIndex="79" OnClick="BtnExcel_Click"/>
                   <asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-info"    Height="40px" Width="100px" OnClientClick="PrintGrid()"/>
               </div>
             </ContentTemplate>
         </asp:UpdatePanel>
    <script lang="javascript" type ="text/javascript" >

        function PrintGrid() {
            var prtGrid = document.getElementById('Print');
             prtGrid.border = 0;
             var prtwin = window.open('', 'PrintGridViewData', 'left=0,top=0,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
             prtwin.document.write(prtGrid.outerHTML);

         }
</script>
    
</asp:Content>
