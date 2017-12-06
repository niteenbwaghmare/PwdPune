using DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class MasterMPReport : System.Web.UI.Page
    {
        string pName;
        string strSqlCommand = string.Empty;
        string strSqlCommand1 = string.Empty;
        string strDllBind = string.Empty;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2 = null;
        string strSqlCommand2 = String.Empty;   
        int RowCount = 0, TotalWork = 0;
        MpGrandTotal mpgrandtotal = new MpGrandTotal();
        SqlDataAdapter da1;
        SqlDataAdapter da;
        clsGraphicsReport objGraph = new clsGraphicsReport();
        MasterReportGridBind ObjBindGrid = new MasterReportGridBind();
        string query = string.Empty;
        string unionquery = string.Empty;
        bool isSelected;
        string year = string.Empty, lekha = string.Empty, ddl = string.Empty, value = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        static SqlQueryOrConnection ObjsqlQueryOrCon = new SqlQueryOrConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KamacheYear();
                ArthsankalpiyYear();
                if (Request.QueryString["Year"] != null)
                {
                    //ddlArthYear.SelectedValue = "संपूर्ण";
                    string arthyear = Request.QueryString["Year"].ToString();
                    ListItem litem = ddlArthYear.Items.FindByText(arthyear);
                    if (litem != null)
                    {
                        ddlArthYear.Items.FindByText(arthyear).Selected = true;
                    }
                    ddlKamacheyear.Items.FindByText("संपूर्ण").Selected = true;
                    chkBuilding.ClearSelection();
                    foreach (var item in chkBuilding.Items.Cast<ListItem>().Where(li => li.Value == "a.[WorkId] as 'वर्क आयडी'" || li.Value == "a.[Taluka] as 'तालुका'" || li.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'" || li.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष'" || li.Value == "a.[PageNo] as 'प्रकार'" || li.Value == "a.[KamacheName] as 'कामाचे नाव'" || li.Value == "a.[Upvibhag] as 'उपविभाग'" || li.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || li.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || li.Value == "a.[Kamachevav] as 'कामाचा वाव'" || li.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यांरभ आदेश/दिनांक'" || li.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'" || li.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'" || li.Value == "b.[MudatVadhiDate] as 'मुदतवाढ दिनांक'" || li.Value == "b.[ManjurAmt] as 'सन 2017-18 मधील अपेक्षित खर्च'" || li.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'" || li.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत (6-(8+9))'" || li.Value == "b.[AikunKharch] as 'एकुण खर्च'" || li.Value == "b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'पुर्ण'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'प्रगतीत'" || li.Value == "" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'निविदा स्तर'" || li.Value == "a.[Shera] as 'शेरा'" || li.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'"))
                    {
                        item.Selected = true;
                    }
                    if (Session["SAP_Upvibhag"] != null)
                    {
                        Session["ddl"] = "a.[upvibhag]=N";
                        Session["ddlvalue"] = Session["SAP_Upvibhag"].ToString();
                        Label3.Text = "उपविभाग:-" + Session["SAP_Upvibhag"].ToString();

                    }
                    if (Session["SAP_ShakhaAbhiyanta"] != null)
                    {
                        Session["ddl"] = "a.[ShakhaAbhyantaName]=N";
                        Session["ddlvalue"] = Session["SAP_ShakhaAbhiyanta"].ToString();
                        Label3.Text = "शाखा अभियंता:-" + Session["SAP_ShakhaAbhiyanta"].ToString();

                    }
                    BindGrid();
                }
            }
            if (Request.UrlReferrer != null)
            {
                string previousPageUrl = Request.UrlReferrer.AbsoluteUri;
                string previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);
                if (previousPageName == "MasterBudgetMP.aspx" || previousPageName == "Send_sms.aspx" || previousPageName == "UploadImage.aspx")
                {
                    if (Session["MasterMPRpt"] != null)
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterMPReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterMPReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterMPReportSda"];
                        DataTable dt = new DataTable();
                        sda1.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
                        CheckBox1.Checked = true;
                        GridViewRow row = GridView1.Rows[0];
                        row.Cells[0].Visible = true;
                        row.Cells[0].ForeColor = System.Drawing.Color.Blue;
                        row.Cells[0].BorderColor = System.Drawing.Color.Black;

                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            tempcounter = tempcounter + 1;
                            if (tempcounter == 10)
                            {
                                row.Attributes.Add("style", "page-break-after: always;");
                                tempcounter = 0;
                            }
                        }

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
                    }
                }
            }
            ListMenu.Style.Add("display", "block");
        }

      
        public void ArthsankalpiyYear()
        {
            ddlArthYear.Items.Clear();
            ddlArthYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from MPProvision Group By Arthsankalpiyyear", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlArthYear.Items.Add(dr["Arthsankalpiyyear"].ToString());
            }

        }

        public void KamacheYear()
        {
            ddlKamacheyear.Items.Clear();
            ddlKamacheyear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from BudgetMasterMP Group By Arthsankalpiyyear", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlKamacheyear.Items.Add(dr["Arthsankalpiyyear"].ToString());
            }
            ddlKamacheyear.Items.Add("संपूर्ण");
        }

        public void Khasdar()
        {
            if (ddlKamacheyear.SelectedItem.Text=="संपूर्ण")
            {
                da1 = new SqlDataAdapter("select KhasdaracheName from BudgetMasterMP  Group By(KhasdaracheName)", con);
            }
            else
            {
                da1 = new SqlDataAdapter("select KhasdaracheName from BudgetMasterMP Where Arthsankalpiyyear='" + ddlKamacheyear.SelectedItem.ToString() + "' Group By(KhasdaracheName)", con);
            }

            ddlKhasdar.Items.Clear();
            ddlKhasdar.Items.Add("निवडा");
            
            DataTable dt = new DataTable();
            if (da1.SelectCommand.CommandText.Length>0)
            {
                da1.Fill(dt);
            }
           
            foreach (DataRow dr in dt.Rows)
            {
                ddlKhasdar.Items.Add(dr["KhasdaracheName"].ToString());
            }
            ddlKhasdar.Items.Add("संपूर्ण");
            da1.SelectCommand.CommandText = string.Empty;
        }

       


        //This Method Binding All DropDwonList On Form of Mastert Head Wise Report
        public void BindAllddl()
        {
            //Create Array of DropDownList IDs
            DropDownList[] ddlIds = { ddlworkid, ddlJilha, ddlTaluka, ddlUpvibhag, ddlShakhaAbhiyanta, ddlShakhUpAbhiyanta, ddlKhasdar, ddlAmdar, ddlThekedarecheName, ddlKamachiSadyStiti };

            DataTable dt = new DataTable();
            if ((dt = (ObjsqlQueryOrCon.Bind_MasterReport_ddl("[BudgetMasterMP]", ddlKhasdar.SelectedItem.ToString()))).Rows.Count > 0)
            {
                //Get ID Of DropDownList Control from ddlIds[i] And Bind 
                for (int i = 0; i < ddlIds.Length; i++)
                {
                    if (i == 6)
                        i++;

                    DataTable dt1 = new DataTable();
                    dt1 = dt.AsEnumerable().GroupBy(r => r.Field<string>(dt.Columns[i].ToString())).Select(g => g.First()).CopyToDataTable();
                    ddlIds[i].Items.Clear();
                    ddlIds[i].DataSource = dt1;
                    ddlIds[i].DataTextField = dt.Columns[i].ToString();
                    ddlIds[i].DataValueField = dt.Columns[i].ToString();
                    ddlIds[i].DataBind();
                    ddlIds[i].Items.Insert(0, new ListItem("निवडा", "निवडा"));
                }
            }
            else
            {
                for (int i = 0; i < ddlIds.Length; i++)
                {
                    ddlIds[i].Items.Clear();
                    ddlIds[i].Items.Insert(0, new ListItem("निवडा", "निवडा"));
                }
            }
        }
        protected void ddlLekhashirsh_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        public void BindReport()
        {
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[KhasdaracheName] order by a.[KhasdaracheName],a.[Arthsankalpiyyear],a.[Taluka],a.[PageNo] ) as 'SrNo', ";
            unionquery = " union select isNULL ('','')as'SrNo', ";
             isSelected = chkBuilding.Items.Cast<ListItem>().Count(i => i.Selected == true) > 0;
            if (!isSelected)
            {
                chkBuilding.Items[0].Selected = true;
            }
            foreach (ListItem item in chkBuilding.Items)
            {
                if (item.Selected)
                {
                    if (item.Value == "a.[WorkId] as 'वर्क आयडी'" || item.Value == "a.[Taluka] as 'तालुका'" || item.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'" || item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'" || item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष'" || item.Value == "a.[PageNo] as 'प्रकार'" || item.Value == "a.[Type] as 'जिल्हा/योजना'" || item.Value == "a.[KamacheName] as 'कामाचे नाव'" || item.Value == "a.[Upvibhag] as 'उपविभाग'" || item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव'" || item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव'" || item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यांरभ आदेश/दिनांक'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'पुर्ण'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'प्रगतीत'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'निविदा स्तर'" || item.Value == "CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN 1 ELSE 0 END as decimal(10,0)) as 'एकूण कामे'" || item.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'" || item.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'" || item.Value == "a.[Kamachevav] as 'कामाचा वाव'" || item.Value == "a.[Pahanikramank] as 'पाहणी क्रमांक'" || item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'" || item.Value == "a.[Shera] as 'शेरा'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "a.[WorkId] as 'वर्क आयडी'")
                        {
                            unionquery += "'Total' as 'वर्क आयडी',";
                        }
                        if (item.Value == "a.[Taluka] as 'तालुका'")
                        {
                            unionquery += "isNULL ('','') as 'तालुका',";
                        }
                        if (item.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'")
                        {
                            unionquery += "isNULL ('','') as 'आमदारांचे नाव',";
                        }
                        if (item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'")
                        {
                            unionquery += "isNULL (a.[KhasdaracheName],'') as 'खासदारांचे नाव',";
                        }
                        if (item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष'")
                        {
                            unionquery += "isNULL ('Total','') as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष',";
                        }
                        if (item.Value == "a.[PageNo] as 'प्रकार'")
                        {
                            unionquery += "isNULL ('','') as 'प्रकार',";

                        }
                        if (item.Value == "a.[Upvibhag] as 'उपविभाग'")
                        {
                            unionquery += "isNULL ('','') as 'उपविभाग',";
                        }
                        if (item.Value == "a.[Type] as 'जिल्हा/योजना'")
                        {
                            unionquery += "isNULL ('','') as 'जिल्हा/योजना',";
                        }
                        if (item.Value == "a.[KamacheName] as 'कामाचे नाव'")
                        {
                            unionquery += "isNULL ('','') as 'कामाचे नाव',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव'")
                        {
                            unionquery += "isNULL ('','') as 'शाखा अभियंता नाव',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव'")
                        {
                            unionquery += "isNULL ('','') as 'उपअभियंता नाव',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'")
                        {
                            unionquery += "isNULL ('','') as 'ठेकेदार नाव',";
                        }

                        if (item.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'")
                        {
                            unionquery += "sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',";
                        }

                        if (item.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'")
                        {
                            unionquery += "sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',";
                        }

                        if (item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'")
                        {
                            unionquery += "isNULL ('','')as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'")
                        {
                            unionquery += "isNULL ('','')as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',";
                        }
                        if (item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'")
                        {
                            unionquery += "sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यांरभ आदेश/दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'कार्यांरभ आदेश/दिनांक',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'पुर्ण'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'पुर्ण',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'प्रगतीत'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'प्रगतीत',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'निविदा स्तर'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'निविदा स्तर',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN 1 ELSE 0 END as decimal(10,0)) as 'एकूण कामे'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN 1 ELSE 0 END as decimal(10,0))) as 'एकूण कामे',";
                        }
                        if (item.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'")
                        {
                            unionquery += "isNULL ('','') as 'बांधकाम कालावधी',";
                        }
                        if (item.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'")
                        {
                            unionquery += "isNULL ('','') as 'काम पूर्ण तारीख',";
                        }
                        if (item.Value == "a.[Kamachevav] as 'कामाचा वाव'")
                        {
                            unionquery += "isNULL ('','') as 'कामाचा वाव',";
                        }

                        if (item.Value == "a.[Pahanikramank] as 'पाहणी क्रमांक'")
                        {
                            unionquery += "isNULL ('','') as 'पाहणी क्रमांक',";
                        }
                        if (item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'")
                        {
                            unionquery += "isNULL ('','') as 'पाहणीमुद्ये',";
                        }
                        if (item.Value == "a.[Shera] as 'शेरा'")
                        {
                            unionquery += "isNULL ('','') as 'शेरा',";
                        }
                        //CPNS
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',";
                        }
                        //End CPNS

                        isSelected = true;
                    }
                    if (item.Value == "b.[MudatVadhiDate] as 'मुदतवाढ दिनांक'" || item.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'"
                        || item.Value == "b.[Takunone] as 'प्रथम तिमाही तरतूद'" || item.Value == "b.[Takuntwo] as 'द्वितीय तिमाही तरतूद'" || item.Value == "b.[Takunthree] as 'तृतीय तिमाही तरतूद'" || item.Value == "b.[Takunfour] as 'चतुर्थ तिमाही तरतूद'"
                        || item.Value == "b.[Chalukharch] as 'एकुण उपलब्ध अनुदान'" || item.Value == "b.[ManjurAmt] as 'सन 2017-18 मधील अपेक्षित खर्च'" || item.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत (6-(8+9))'" || item.Value == "b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद'" || item.Value == "b.[AkunAnudan] as '2017-18 मधील वितरीत तरतूद'" || item.Value == "b.[Magilkharch] as 'मागील खर्च'"
                        || item.Value == "b.[AikunKharch] as 'एकुण खर्च'" || item.Value == "b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च'" || item.Value == "b.[Vidyutprama] as 'विद्युतप्रमा'" || item.Value == "b.[Vidyutvitarit] as 'विद्युत वितरीत'" || item.Value == "b.[Itarkhrch] as 'इतर खर्च'" || item.Value == "b.[Dviguni] as 'द्वीगुणी'" || item.Value == "b.[Magni] as 'मागणी  2017-18'" || item.Value == "b.[Apr] as 'Apr'" || item.Value == "b.[May] as 'May'" || item.Value == "b.[Jun] as 'Jun'" || item.Value == "b.[Jul] as 'Jul'" || item.Value == "b.[Aug] as 'Aug'" || item.Value == "b.[Sep] as 'Sep'" || item.Value == "b.[Oct] as 'Oct'" || item.Value == "b.[Nov] as 'Nov'" || item.Value == "b.[Dec] as 'Dec'" || item.Value == "b.[Jan] as 'Jan'" || item.Value == "b.[Feb] as 'Feb'" || item.Value == "b.[Mar] as 'Mar'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "b.[MudatVadhiDate] as 'मुदतवाढ दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'मुदतवाढ दिनांक',";
                        }
                        if (item.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'")
                        {
                            unionquery += "sum(b.[MarchEndingExpn]) as 'मार्च अखेर खर्च 2017',";
                        }
                        if (item.Value == "b.[Takunone] as 'प्रथम तिमाही तरतूद'")
                        {
                            unionquery += "sum(b.[Takunone]) as 'प्रथम तिमाही तरतूद',";
                        }
                        if (item.Value == "b.[Takuntwo] as 'द्वितीय तिमाही तरतूद'")
                        {
                            unionquery += "sum(b.[Takuntwo]) as 'द्वितीय तिमाही तरतूद',";
                        }
                        if (item.Value == "b.[Takunthree] as 'तृतीय तिमाही तरतूद'")
                        {
                            unionquery += "sum(b.[Takunthree]) as 'तृतीय तिमाही तरतूद',";
                        }
                        if (item.Value == "b.[Takunfour] as 'चतुर्थ तिमाही तरतूद'")
                        {
                            unionquery += "sum(b.[Takunfour]) as 'चतुर्थ तिमाही तरतूद',";
                        }
                        if (item.Value == "b.[Chalukharch] as 'एकुण उपलब्ध अनुदान'")
                        {
                            unionquery += "sum(b.[Chalukharch]) as 'एकुण उपलब्ध अनुदान',";
                        }
                        if (item.Value == "b.[ManjurAmt] as 'सन 2017-18 मधील अपेक्षित खर्च'")
                        {
                            unionquery += "sum(b.[ManjurAmt] )as 'सन 2017-18 मधील अपेक्षित खर्च',";
                        }
                        if (item.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत (6-(8+9))'")
                        {
                            unionquery += "sum(b.[UrvaritAmt]) as 'उर्वरित किंमत (6-(8+9))',";
                        }
                        if (item.Value == "b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद'")
                        {
                            unionquery += "sum(b.[Tartud]) as 'एकूण अर्थसंकल्पीय तरतूद',";
                        }
                        if (item.Value == "b.[AkunAnudan] as '2017-18 मधील वितरीत तरतूद'")
                        {
                            unionquery += "sum(b.[AkunAnudan]) as '2017-18 मधील वितरीत तरतूद',";
                        }
                        if (item.Value == "b.[Magilkharch] as 'मागील खर्च'")
                        {
                            unionquery += "sum(b.[Magilkharch]) as 'मागील खर्च',";
                        }
                        if (item.Value == "b.[AikunKharch] as 'एकुण खर्च'")
                        {
                            unionquery += "sum(b.[AikunKharch]) as 'एकुण खर्च',";
                        }
                        if (item.Value == "b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च'")
                        {
                            unionquery += "sum(b.[VarshbharatilKharch]) as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च',";
                        }
                        if (item.Value == "b.[Vidyutprama] as 'विद्युतप्रमा'")
                        {
                            unionquery += "sum(b.[Vidyutprama]) as 'विद्युतप्रमा',";
                        }
                        if (item.Value == "b.[Vidyutvitarit] as 'विद्युत वितरीत'")
                        {
                            unionquery += "sum(b.[Vidyutvitarit]) as 'विद्युत वितरीत',";
                        }
                        if (item.Value == "b.[Itarkhrch] as 'इतर खर्च'")
                        {
                            unionquery += "sum(b.[Itarkhrch]) as 'इतर खर्च',";
                        }
                        if (item.Value == "b.[Dviguni] as 'द्वीगुणी'")
                        {
                            unionquery += "isNULL ('','') as 'द्वीगुणी',";
                        }
                        if (item.Value == "b.[Magni] as 'मागणी  2017-18'")
                        {
                            unionquery += "sum(b.[Magni]) as 'मागणी  2017-18',";
                        }
                        if (item.Value == "b.[Apr] as 'Apr'")
                        {
                            unionquery += "sum (b.[Apr]) as [Apr],";
                        }
                        if (item.Value == "b.[May] as 'May'")
                        {
                            unionquery += "sum (b.[May]) as [May],";
                        }
                        if (item.Value == "b.[Jun] as 'Jun'")
                        {
                            unionquery += "sum (b.[Jun]) as [Jun],";
                        }
                        if (item.Value == "b.[Jul] as 'Jul'")
                        {
                            unionquery += "sum (b.[Jul]) as [Jul],";
                        }
                        if (item.Value == "b.[Aug] as 'Aug'")
                        {
                            unionquery += "sum (b.[Aug]) as [Aug],";
                        }
                        if (item.Value == "b.[Sep] as 'Sep'")
                        {
                            unionquery += "sum (b.[Sep]) as [Sep],";
                        }
                        if (item.Value == "b.[Oct] as 'Oct'")
                        {
                            unionquery += "sum (b.[Oct]) as [Oct],";
                        }
                        if (item.Value == "b.[Nov] as 'Nov'")
                        {
                            unionquery += "sum (b.[Nov]) as [Nov],";
                        }
                        if (item.Value == "b.[Dec] as 'Dec'")
                        {
                            unionquery += "sum (b.[Dec]) as [Dec],";
                        }
                        if (item.Value == "b.[Jan] as 'Jan'")
                        {
                            unionquery += "sum (b.[Jan]) as [Jan],";
                        }
                        if (item.Value == "b.[Feb] as 'Feb'")
                        {
                            unionquery += "sum (b.[Feb]) as [Feb],";
                        }
                        if (item.Value == "b.[Mar] as 'Mar'")
                        {
                            unionquery += "sum (b.[Mar]) as [Mar],";
                        }

                        isSelected = true;
                    }
                }
            }
            unionquery = unionquery.Substring(0, unionquery.Length - 1);
            query = query.Substring(0, query.Length - 1);

        }
        public void BindGrid()
        {
            BindReport();
            if (!IsPostBack)
            {


                if (Request.QueryString["Year"] != null)
                {
                    //year = Request.QueryString["Year"].ToString();
                    year = ddlKamacheyear.Text;
                    lekha = "संपूर्ण";
                }
                else
                {
                    year = ddlKamacheyear.Text;
                    lekha = ddlKhasdar.Text;
                }
                if ((Session["SAP_Upvibhag"] == null) && (Session["SAP_ShakhaAbhiyanta"] == null))
                {
                    if (Request.QueryString["CPNS"] != null)
                    {
                        string kamchisadystiti = Request.QueryString["CPNS"].ToString();

                        ddl = "a.[Sadyasthiti]=N";
                        value = kamchisadystiti;
                    }
                    else
                    {
                        Session["ddl"] = "संपूर्ण";
                        Session["ddlvalue"] = "संपूर्ण";
                        ddl = Session["ddl"].ToString();
                        value = Session["ddlvalue"].ToString();
                    }
                }
                else
                {
                    if (Request.QueryString["CPNS"] != null)
                    {
                        value = Session["ddlvalue"].ToString();
                        string kamchisadystiti = string.Empty;
                        if (value == "निवडा")
                        {
                            kamchisadystiti = Request.QueryString["CPNS"].ToString();
                            //ddlKamachiSadyStiti.Items.FindByText(kamchisadystiti).Selected = true;
                            ddl = "a.[Sadyasthiti]=N";
                            value = kamchisadystiti;
                        }
                        else
                        {


                            kamchisadystiti = Request.QueryString["CPNS"].ToString();
                            //ddlKamachiSadyStiti.Items.FindByText(kamchisadystiti).Selected = true;
                            ddl = "a.[Sadyasthiti]=N'" + kamchisadystiti + "' and  ";
                            //value = kamchisadystiti;
                            ddl += Session["ddl"].ToString();
                        }
                    }
                    else
                    {
                        ddl = Session["ddl"].ToString();
                        value = Session["ddlvalue"].ToString();
                    }
                }
            }
            else
            {

                year = ddlKamacheyear.Text;
                lekha = ddlKhasdar.SelectedItem.ToString();
                ddl = Session["ddl"].ToString();
                value = Session["ddlvalue"].ToString();
            }
            DataTable dt = new DataTable();
            
            dt = ObjBindGrid.BindGrid(year, lekha, ddl, value, ddlArthYear.Text, query, unionquery, "BudgetMasterMP", "MPProvision");
            Session["MasterMPReportSda"] = ObjBindGrid.SessionQuery;

            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Columns[1].Visible = false;

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);

            Session["MasterMPRpt"] = GridView1;
            ListMenu.Style.Add("display", "none");

            GraphicsReport(ObjBindGrid.WhereCondition);
        }
        
        protected void btnupvibhag_Click(object sender, EventArgs e)
        {
            txtno.Text = "2";
            Session["ddl"] = "a.[upvibhag]=N";
            Session["ddlvalue"] = ddlUpvibhag.Text;
            BindGrid();
            Label5.Text = "खासदार:- " + ddlKhasdar.SelectedItem.ToString() + ", उपविभाग:- " + ddlUpvibhag.SelectedItem.ToString();
        }

        protected void btnjilha_Click(object sender, EventArgs e)
        {
            txtno.Text = "3";
            Session["ddl"] = "a.[Dist]=N";
            Session["ddlvalue"] = ddlJilha.Text;
            BindGrid();
            Label5.Text = "खासदार:- " + ddlKhasdar.SelectedItem.ToString() + ",  जिल्हा:- " + ddlJilha.SelectedItem.ToString();
        }

        protected void btntaluka_Click(object sender, EventArgs e)
        {
            txtno.Text = "4";
            Session["ddl"] = "a.[Taluka]=N";
            Session["ddlvalue"] = ddlTaluka.Text;
            BindGrid();
            Label5.Text = "खासदार:- " + ddlKhasdar.SelectedItem.ToString() + ",  तालुका:- " + ddlTaluka.SelectedItem.ToString();
        }

        protected void btnworkid_Click(object sender, EventArgs e)
        {
            txtno.Text = "5";
            Session["ddl"] = "a.[WorkId]=N";
            Session["ddlvalue"] = ddlworkid.Text;
            BindGrid();

            Label5.Text = "खासदार:- " + ddlKhasdar.SelectedItem.ToString() + ", वर्क आयडी:- " + ddlworkid.SelectedItem.ToString();

        }

        protected void btnabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "6";
            Session["ddl"] = "a.[ShakhaAbhyantaName]=N";
            Session["ddlvalue"] = ddlShakhaAbhiyanta.Text;
            BindGrid();
            Label5.Text = "खासदार:- " + ddlKhasdar.SelectedItem.ToString() + ", शाखा अभियंता:- " + ddlShakhaAbhiyanta.SelectedItem.ToString();
        }

        protected void btnupabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "7";
            Session["ddl"] = "a.[UpabhyantaName]=N";
            Session["ddlvalue"] = ddlShakhUpAbhiyanta.Text;
            BindGrid();
            Label5.Text = "खासदार:- " + ddlKhasdar.SelectedItem.ToString() + ", उपअभियंता:- " + ddlShakhUpAbhiyanta.SelectedItem.ToString();
        }

        protected void btnamdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "8";
            Session["ddl"] = "a.[AmdaracheName]=N";
            Session["ddlvalue"] = ddlAmdar.Text;
            BindGrid();
            Label5.Text = "खासदार:- " + ddlKhasdar.SelectedItem.ToString() + ", आमदार:- " + ddlAmdar.SelectedItem.ToString(); 
        }

        protected void btnkhasdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "1";
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";

            BindGrid();
            Label5.Text = "खासदार:- " + ddlKhasdar.SelectedItem.ToString();
        }

        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            txtno.Text = "9";
            Session["ddl"] = "a.[ThekedaarName]=N";
            Session["ddlvalue"] = ddlThekedarecheName.Text;
            BindGrid();
            Label5.Text = "खासदार:- " + ddlKhasdar.SelectedItem.ToString() + ", ठेकेदार:- " + ddlThekedarecheName.SelectedItem.ToString();
        }

        protected void btnkamachistiti_Click(object sender, EventArgs e)
        {
            txtno.Text = "10";
            Session["ddl"] = "a.[Sadyasthiti]=N";
            Session["ddlvalue"] = ddlKamachiSadyStiti.Text;
            BindGrid();
            Label5.Text = "खासदार:- " + ddlKhasdar.SelectedItem.ToString() + ", कामाची सद्यस्थिती:- " + ddlKamachiSadyStiti.SelectedItem.ToString();
        }
        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            txtno.Text = "11";
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";
            BindGrid();
            Label5.Text = "कामाचे वर्ष:- " + ddlKamacheyear.SelectedItem.ToString();

        }
        protected void chkBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
        int tempcounter = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridView1.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=6&PrevPage=MasterMPReport.aspx";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                string[] HeadrName = new string[e.Row.Cells.Count];
                for (int RowHeader_Index = 0; RowHeader_Index < e.Row.Cells.Count; RowHeader_Index++)
                {
                    HeadrName[RowHeader_Index] = e.Row.Cells[RowHeader_Index].Text;
                }

                mpgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                RowCount++;
                // do your stuffs here, for example if column risk is your third column:
                if (e.Row.Cells[mpgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[mpgrandtotal.Total_index - 1].Text = (RowCount - 1).ToString();
                    TotalWork += RowCount - 1;
                    RowCount = 0;
                    e.Row.Cells[mpgrandtotal.Total_index + 3].Text = "";
                    e.Row.Cells[mpgrandtotal.Total_index + 4].Text = "";
                    e.Row.Cells[mpgrandtotal.Total_index - 2].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;
                    if (data.Row.Table.Columns["निविदा किंमत"] != null)
                    {
                        mpgrandtotal.NividaKimmat += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.NividaKimmat_index].Text);
                    }
                    if (data.Row.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        mpgrandtotal.Anudan += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Anudan_index].Text);
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {

                        mpgrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {

                        mpgrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }

                   
                    if (data.Row.Table.Columns["वर्ष 2016-17 मधील चालु महिन्या  अखेर उपलब्ध अनुदान"] != null)
                    {
                        mpgrandtotal.UplbdaAnudan += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.UplbdaAnudan_index].Text);
                    }
                    if (data.Row.Table.Columns["एकुण उपलब्ध अनुदान"] != null)
                    {
                        mpgrandtotal.AkunAnudan += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.AkunAnudan_index].Text);
                    }
                    if (data.Row.Table.Columns["मागील खर्च"] != null)
                    {
                        mpgrandtotal.AkherKharch += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.AkherKharch_index].Text);
                    }
                    if (data.Row.Table.Columns["एकुण खर्च"] != null)
                    {
                        mpgrandtotal.AkunKharch += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.AkunKharch_index].Text);
                    }
                    if (data.Row.Table.Columns["मागणी  2017-18"] != null)
                    {
                        mpgrandtotal.Magni += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Magni_index].Text);
                    }
                    //CPNS
                    if (data.Row.Table.Columns["पुर्ण"] != null || data.Row.Table.Columns["C"] != null)
                    {
                        mpgrandtotal.Purn += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Purn_index].Text);
                    }
                    if (data.Row.Table.Columns["प्रगतीत"] != null || data.Row.Table.Columns["P"] != null)
                    {
                        mpgrandtotal.Pragatit += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Pragatit_index].Text);
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        mpgrandtotal.NotStarted += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        mpgrandtotal.Estimated += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["निविदा स्तर"] != null || data.Row.Table.Columns["TS"] != null)
                    {
                        mpgrandtotal.NividaStar += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.NividaStar_index].Text);
                    }
                    //End CPNS
                    if (data.Row.Table.Columns["एकूण कामे"] != null)
                    {
                        mpgrandtotal.AkunKame += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.AkunKame_index].Text);
                    }
                    //New Column
                    if (data.Row.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        mpgrandtotal.TakunOne += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.TakunOne_index].Text);
                    }
                    if (data.Row.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        mpgrandtotal.TakunTwo += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.TakunTwo_index].Text);
                    }
                   
                    if (data.Row.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        mpgrandtotal.TakunTree += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.TakunTree_index].Text);
                    }
                    if (data.Row.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        mpgrandtotal.TakunFour += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.TakunFour_index].Text);
                    }
                    if (data.Row.Table.Columns["एकूण अर्थसंकल्पीय तरतूद"] != null)
                    {
                        mpgrandtotal.ArthsankalpTartud += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.ArthsankalpTartud_index].Text);
                    }
                     if (data.Row.Table.Columns["सन 2017-18 मधील अपेक्षित खर्च"] != null)
                    {
                        mpgrandtotal.ApekshitKharch += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.ApekshitKharch_index].Text);
                    }
                     if (data.Row.Table.Columns["उर्वरित किंमत (6-(8+9))"] != null)
                    {
                        mpgrandtotal.UrvritKimmat += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.UrvritKimmat_index].Text);
                    }

                    if (data.Row.Table.Columns["2017-18 मधील वितरीत तरतूद"] != null)
                    {
                        mpgrandtotal.VitaritTartud += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.VitaritTartud_index].Text);
                    }
                    if (data.Row.Table.Columns["सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        mpgrandtotal.YearExp += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.YearExp_index].Text);
                    }
                    if (data.Row.Table.Columns["विद्युतप्रमा"] != null)
                    {
                        mpgrandtotal.VidyutiPrma += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.VidyutiPrma_index].Text);
                    }
                    if (data.Row.Table.Columns["विद्युत वितरीत"] != null)
                    {
                        mpgrandtotal.VidyutVitarit += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.VidyutVitarit_index].Text);
                    }
                    if (data.Row.Table.Columns["इतर खर्च"] != null)
                    {
                        mpgrandtotal.ItarKharch += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.ItarKharch_index].Text);
                    }
                    

                    if (data.Row.Table.Columns["Apr"] != null)
                    {
                        mpgrandtotal.Apr += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Apr_index].Text);
                    }
                    if (data.Row.Table.Columns["May"] != null)
                    {
                        mpgrandtotal.May += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.May_index].Text);
                    }
                    if (data.Row.Table.Columns["Jun"] != null)
                    {
                        mpgrandtotal.Jun += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Jun_index].Text);
                    }
                    if (data.Row.Table.Columns["Jul"] != null)
                    {
                        mpgrandtotal.Jul += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Jul_index].Text);
                    }
                    if (data.Row.Table.Columns["Aug"] != null)
                    {
                        mpgrandtotal.Aug += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Aug_index].Text);
                    }
                    if (data.Row.Table.Columns["Sep"] != null)
                    {
                        mpgrandtotal.sep += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.sep_index].Text);
                    }
                    if (data.Row.Table.Columns["Oct"] != null)
                    {
                        mpgrandtotal.Oct += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Oct_index].Text);
                    }
                    if (data.Row.Table.Columns["Nov"] != null)
                    {
                        mpgrandtotal.Nov += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Nov_index].Text);
                    }
                    if (data.Row.Table.Columns["Dec"] != null)
                    {
                        mpgrandtotal.Dec += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Dec_index].Text);
                    }
                    if (data.Row.Table.Columns["Jan"] != null)
                    {
                        mpgrandtotal.Jan += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Jan_index].Text);
                    }
                    if (data.Row.Table.Columns["Feb"] != null)
                    {
                        mpgrandtotal.Feb += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Feb_index].Text);
                    }
                    if (data.Row.Table.Columns["Mar"] != null)
                    {
                        mpgrandtotal.Mar += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Mar_index].Text);
                    }
                    if (data.Row.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        mpgrandtotal.NividaRakkam += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.NividaRakkam_Index].Text);
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[mpgrandtotal.Total_index - 1].Text = "No Of Work: " + TotalWork.ToString();
                e.Row.Cells[mpgrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[mpgrandtotal.NividaKimmat_index].Text = mpgrandtotal.NividaKimmat.ToString();
                e.Row.Cells[mpgrandtotal.NividaRakkam_Index].Text = mpgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[mpgrandtotal.Anudan_index].Text = mpgrandtotal.Anudan.ToString();
                e.Row.Cells[mpgrandtotal.UplbdaAnudan_index].Text = mpgrandtotal.UplbdaAnudan.ToString();
                e.Row.Cells[mpgrandtotal.AkunAnudan_index].Text = mpgrandtotal.AkunAnudan.ToString();
                e.Row.Cells[mpgrandtotal.AkherKharch_index].Text = mpgrandtotal.AkherKharch.ToString();
                e.Row.Cells[mpgrandtotal.AkunKharch_index].Text = mpgrandtotal.AkunKharch.ToString();
                e.Row.Cells[mpgrandtotal.Magni_index].Text = mpgrandtotal.Magni.ToString();

                //CPNS
                e.Row.Cells[mpgrandtotal.Purn_index].Text = mpgrandtotal.Purn.ToString();
                e.Row.Cells[mpgrandtotal.Pragatit_index].Text = mpgrandtotal.Pragatit.ToString();
                e.Row.Cells[mpgrandtotal.NotStarted_index].Text = mpgrandtotal.NividaStar.ToString();
                e.Row.Cells[mpgrandtotal.Estimated_index].Text = mpgrandtotal.Estimated.ToString();
                e.Row.Cells[mpgrandtotal.NividaStar_index].Text = mpgrandtotal.NividaStar.ToString();
                //End CPNS
                e.Row.Cells[mpgrandtotal.AkunKame_index].Text = mpgrandtotal.AkunKame.ToString();

                e.Row.Cells[mpgrandtotal.TakunOne_index].Text = mpgrandtotal.TakunOne.ToString();
                e.Row.Cells[mpgrandtotal.TakunTwo_index].Text = mpgrandtotal.TakunTwo.ToString();
                e.Row.Cells[mpgrandtotal.TakunTree_index].Text = mpgrandtotal.TakunTree.ToString();
                e.Row.Cells[mpgrandtotal.TakunFour_index].Text = mpgrandtotal.TakunFour.ToString();
                e.Row.Cells[mpgrandtotal.ArthsankalpTartud_index].Text = mpgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[mpgrandtotal.ApekshitKharch_index].Text = mpgrandtotal.ApekshitKharch.ToString();
                e.Row.Cells[mpgrandtotal.UrvritKimmat_index].Text = mpgrandtotal.UrvritKimmat.ToString();


                e.Row.Cells[mpgrandtotal.VitaritTartud_index].Text = mpgrandtotal.VitaritTartud.ToString();
                e.Row.Cells[mpgrandtotal.YearExp_index].Text = mpgrandtotal.YearExp.ToString();
                e.Row.Cells[mpgrandtotal.VidyutiPrma_index].Text = mpgrandtotal.VidyutiPrma.ToString();
                e.Row.Cells[mpgrandtotal.VidyutVitarit_index].Text = mpgrandtotal.VidyutVitarit.ToString();
                e.Row.Cells[mpgrandtotal.ItarKharch_index].Text = mpgrandtotal.ItarKharch.ToString();

                e.Row.Cells[mpgrandtotal.PrashaskiyAmt_index].Text = mpgrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[mpgrandtotal.TantrikAmt_index].Text = mpgrandtotal.TantrikAmt.ToString();


                e.Row.Cells[mpgrandtotal.Apr_index].Text = mpgrandtotal.Apr.ToString();
                e.Row.Cells[mpgrandtotal.May_index].Text = mpgrandtotal.May.ToString();
                e.Row.Cells[mpgrandtotal.Jun_index].Text = mpgrandtotal.Jun.ToString();
                e.Row.Cells[mpgrandtotal.Jul_index].Text = mpgrandtotal.Jul.ToString();
                e.Row.Cells[mpgrandtotal.Aug_index].Text = mpgrandtotal.Aug.ToString();
                e.Row.Cells[mpgrandtotal.sep_index].Text = mpgrandtotal.sep.ToString();
                e.Row.Cells[mpgrandtotal.Oct_index].Text = mpgrandtotal.Oct.ToString();
                e.Row.Cells[mpgrandtotal.Nov_index].Text = mpgrandtotal.Nov.ToString();
                e.Row.Cells[mpgrandtotal.Dec_index].Text = mpgrandtotal.Dec.ToString();
                e.Row.Cells[mpgrandtotal.Jan_index].Text = mpgrandtotal.Jan.ToString();
                e.Row.Cells[mpgrandtotal.Feb_index].Text = mpgrandtotal.Feb.ToString();
                e.Row.Cells[mpgrandtotal.Mar_index].Text = mpgrandtotal.Mar.ToString();
            }
                      
            if (CheckBox1.Checked == false)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[3].Visible = false;
            }
            else
            {
                e.Row.Cells[0].ForeColor = System.Drawing.Color.Blue;
                e.Row.Cells[0].BorderColor = System.Drawing.Color.Black;
                e.Row.Cells[3].Visible = true;
            }
            if (myBtn2.Checked == false)
            {
                e.Row.Cells[1].Visible = false;
            }
            else
            {
                GridView1.Columns[1].Visible = true;
                e.Row.Cells[1].Visible = true;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tempcounter = tempcounter + 1;
                if (tempcounter == 10)
                {
                    e.Row.Attributes.Add("style", "page-break-after: always;");
                    tempcounter = 0;
                }
            }
        }

        protected void ddlKamacheyear_SelectedIndexChanged(object sender, EventArgs e)
        {           
               Khasdar();       
           
        }

        protected void ddlKhasdar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlKhasdar.Text == "संपूर्ण")
            {
                BindAllddl();
            }
            else if (ddlKhasdar.Text == "निवडा")
            {
                //clear all dropdownlist
                ddlUpvibhag.Items.Clear();
                ddlJilha.Items.Clear();
                ddlTaluka.Items.Clear();
                ddlworkid.Items.Clear();
                ddlShakhaAbhiyanta.Items.Clear();
                ddlShakhUpAbhiyanta.Items.Clear();
                ddlAmdar.Items.Clear();
                ddlThekedarecheName.Items.Clear();
                ddlKamachiSadyStiti.Items.Clear();
                //Pleace निवडा value at 0 index
                ddlUpvibhag.Items.Add("निवडा");
                ddlJilha.Items.Add("निवडा");
                ddlTaluka.Items.Add("निवडा");
                ddlworkid.Items.Add("निवडा");
                ddlShakhaAbhiyanta.Items.Add("निवडा");
                ddlShakhUpAbhiyanta.Items.Add("निवडा");
                ddlAmdar.Items.Add("निवडा");
                ddlThekedarecheName.Items.Add("निवडा");
                ddlKamachiSadyStiti.Items.Add("निवडा");


            }
            else
            {
                BindAllddl();
            }
        }


        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MasterMPReport.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "MasterMPReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "MasterMPReport.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }
            Response.Redirect("SendMail.aspx");
        }

       

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
            GridView1.Attributes["style"] = "border-collapse:separate";
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                {
                    row.Attributes["style"] = "page-break-after:always;";
                }
            }
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            string style = "<style type = 'text/css'>thead {display:table-header-group;} tfoot{display:table-footer-group;}</style>";
            sb.Append(style + gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();");
            sb.Append("};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            pName = GridView1.DataKeys[e.NewSelectedIndex].Values["वर्क आयडी"].ToString();
            Response.Redirect("Send_sms.aspx?WorkID=" + pName + "");
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pName = GridView1.DataKeys[e.NewEditIndex].Values["वर्क आयडी"].ToString();
            Response.Redirect("MasterBudgetMP.aspx?WorkID=" + pName + "");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (myBtn2.Checked == true)
            {
                if (txtpassword.Text == "PwdPuneEast")
                {
                    //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterMPReportSda"].ToString(), con);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.Columns[1].Visible = true;
                    
                }
                else
                {
                    myBtn2.Checked = false;
                    //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterMPReportSda"].ToString(), con);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.Columns[1].Visible = false;
                    
                }
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            }
            else
            {
                myBtn2.Checked = false;
                //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterMPReportSda"].ToString(), con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Columns[1].Visible = false;

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            } 
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string ID = GridView1.Rows[0].Cells[3].Text;
            //Prepare Sql Delete Command         
           
        }

      

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string WorkId = e.Keys["वर्क आयडी"].ToString();
            strSqlCommand = "Delete From [BudgetMasterMP] Where [WorkId]='" + WorkId + "'";
            strSqlCommand1 = "Delete From [MPProvision] Where [WorkId]='" + WorkId + "'";
            strSqlCommand2 = "Delete From [SendSms_tbl] Where [WorkId]='" + WorkId + "'";
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(strSqlCommand, con);
            cmd1 = new SqlCommand(strSqlCommand1, con);
            cmd2 = new SqlCommand(strSqlCommand2, con);
            if (cmd.ExecuteNonQuery() > 0 && cmd1.ExecuteNonQuery() > 0 && cmd2.ExecuteNonQuery() > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
                //Refresh GridView             
                BindGrid();
                GridView1.Columns[1].Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deletion Failed')", true);
                BindGrid();
                GridView1.Columns[1].Visible = true;
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            con.Close();
        }

        public void GraphicsReport(string WhereCondition)
        {
            string[] arr1 = { "Completed", "Incomplete", "Inprogress", "Tender Stage", "Estimated Stage", "Not Started", "Estimated Cost", "T.S Cost", "Budget Provision", "Expenditure" };

            objGraph.GraphicsReports("[BudgetMasterMP]", "[MPProvision]", WhereCondition);

            Chart2.Series[0].Points.DataBindXY(arr1, objGraph.arr);
            Chart2.Series[0].Label = "#VALY";
            Chart2.Series[0].IsValueShownAsLabel = true;
            Chart2.ChartAreas[0].AxisX.Interval = 1;
            Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -42;
            Chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Verdana", 11f);
            Chart2.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Red;
            Chart2.Series[0].SmartLabelStyle.Enabled = false;// Remove auto property first
            Chart2.Series[0].LabelAngle = 20; // Can vary from -90 to 90;
            //Chart1.ChartAreas[0].Area3DStyle.Rotation = 10;
            Chart2.Series[0].LabelForeColor = Color.Red;
            Chart2.Series[0].Font = new Font("Verdana", 11f);
            Chart2.Series[0].MarkerStyle = MarkerStyle.Circle;
            Chart2.Series[0].CustomProperties = "DrawingStyle=Cylinder, MaxPixelPointWidth=20";



        }
    }
}