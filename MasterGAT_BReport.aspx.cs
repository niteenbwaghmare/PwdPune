using DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class MasterGAT_BReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        static SqlQueryOrConnection ObjsqlQueryOrCon = new SqlQueryOrConnection();
        string pName;
        string strSqlCommand = string.Empty;
        string strSqlCommand1 = string.Empty;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2 = null;
        string strSqlCommand2 = String.Empty;
        int RowCount = 0, TotalWork = 0;
        clsGraphicsReport objGraph = new clsGraphicsReport();
        ReportGrandTotal GrandTotal = new ReportGrandTotal();
        MasterReportGridBind ObjBindGrid = new MasterReportGridBind();
        SqlDataAdapter da;
        string query = string.Empty;
        string unionquery = string.Empty;
        string year = string.Empty, lekha = string.Empty, ddl = string.Empty, value = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KamacheYear();
                ArthsankalpiyYear();

                if (Request.QueryString["Year"] != null)
                {
                    string arthyear = Request.QueryString["Year"].ToString();
                    ListItem litem = ddlArthYear.Items.FindByText(arthyear);
                    if (litem != null)
                    {
                        ddlArthYear.Items.FindByText(arthyear).Selected = true;
                    }                 
                    
                    ddlKamacheyear.Items.FindByText("संपूर्ण").Selected = true;
                    chkBuilding.ClearSelection();

                    foreach (var item in chkBuilding.Items.Cast<ListItem>().Where(li => li.Value == "a.[WorkId] as 'वर्क आयडी'" || li.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'" || li.Value == "a.[KamacheName] as 'कामाचे नाव'" || li.Value == "a.[LekhaShirshName] as 'लेखाशीर्ष नाव'" || li.Value == "a.[Upvibhag] as 'उपविभाग'" || li.Value == "a.[Taluka] as 'तालुका'" || li.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate]) as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || li.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate]) as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || li.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate]) as 'निविदा क्र/दिनांक'" || li.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || li.Value == "a.[karyarambhadesh] as 'कार्यारंभ आदेश'" || li.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'" || li.Value == "a.[Kamachevav] as 'कामाचा वाव'" || li.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'" || li.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'" || li.Value == "b.[Tartud]as 'अर्थसंकल्पीय तरतूद'"  || li.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'" || li.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'"))
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
                if (previousPageName == "MasterBudgetGat_FBC.aspx" || previousPageName == "Send_sms.aspx" || previousPageName == "UploadImage.aspx")
                {
                    if (Session["MasterGat_BRpt"] != null)
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterGat_BReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterGat_BReportSda"].ToString(), con);
                        // SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterGat_BReportSda"];
                        DataTable dt = new DataTable();
                        sda1.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Add Fake Delay to simulate long running process.
            System.Threading.Thread.Sleep(5000);
            // LoadCustomers();
        }


        public void ArthsankalpiyYear()
        {
            ddlArthYear.Items.Clear();
            ddlArthYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from GAT_FBCProvision Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from BudgetMasterGAT_FBC Group By Arthsankalpiyyear", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlKamacheyear.Items.Add(dr["Arthsankalpiyyear"].ToString());
            }
            ddlKamacheyear.Items.Add("संपूर्ण");
        }
        public void lekhashirsh()
        {
            ddlLekhashirsh.Items.Clear();
            ddlLekhashirsh.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select [LekhaShirshName] from BudgetMasterGAT_FBC where Type=N'गट बी' and [Arthsankalpiyyear]='" + ddlKamacheyear.SelectedItem.ToString() + "' Group By([LekhaShirshName])", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlLekhashirsh.Items.Add(dr["LekhaShirshName"].ToString());
            }
            ddlLekhashirsh.Items.Add("सार्वजनिक बांधकाम पूर्व विभाग,पुणे");
        }



        //This Method Binding All DropDwonList On Form of Mastert Head Wise Report
        public void BindAllddl()
        {
            //Create Array of DropDownList IDs
            DropDownList[] ddlIds = { ddlworkid, ddlJilha, ddlTaluka, ddlUpvibhag, ddlShakhaAbhiyanta, ddlShakhUpAbhiyanta, ddlKhasdar, ddlAmdar, ddlThekedarecheName, ddlKamachiSadyStiti };

            DataTable dt = new DataTable();


            if ((dt = (ObjsqlQueryOrCon.Bind_MasterReport_ddl("[BudgetMasterGAT_FBC]", ddlLekhashirsh.SelectedItem.ToString() + "' and Type=N'गट बी"))).Rows.Count > 0)
            {

                //Get ID Of DropDownList Control from ddlIds[i] And Bind 
                for (int i = 0; i < ddlIds.Length; i++)
                {
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
            BindAllddl();

        }


        public void BindReport()
        {
             query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]) as 'अ क्र', ";
             unionquery = " union select isNULL ('','')as'अ क्र', ";
            bool isSelected = chkBuilding.Items.Cast<ListItem>().Count(i => i.Selected == true) > 0;
            if (!isSelected)
            {
                chkBuilding.Items[0].Selected = true;

            }
            foreach (ListItem item in chkBuilding.Items)
            {
                if (item.Selected)
                {
                    if (item.Value == "a.[WorkId] as 'वर्क आयडी'" || item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'" || item.Value == "a.Type as 'योजनेचे नाव'" || item.Value == "a.[KamacheName] as 'कामाचे नाव'" || item.Value == "a.[LekhaShirshName] as 'लेखाशीर्ष नाव'" || item.Value == "a.[SubType] as 'विभाग'" || item.Value == "a.[Upvibhag] as 'उपविभाग'" || item.Value == "a.[Taluka] as 'तालुका'" || item.Value == "a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब'" || item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव'" || item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव'" || item.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'" || item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'" || item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate]) as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate]) as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate]) as 'निविदा क्र/दिनांक'" || item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || item.Value == "a.[karyarambhadesh] as 'कार्यारंभ आदेश'" || item.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'" || item.Value == "a.[GJobKramank] as 'जॉब क्रमांक'" || item.Value == "a.[GRoadKramank] as 'रस्ता संवर्ग/ क्रमांक'" || item.Value == "a.[GRoadPrushthbhag] as 'अस्तीत्वातील रस्त्याचा पृष्ठभाग'" || item.Value == "a.[GRoll] as 'पीक व रोल'" || item.Value == "a.[GlengthStarted] as 'लांबी किमी. पासून'" || item.Value == "a.[GlengthUpto] as 'लांबी किमी. पर्यंत'" || item.Value == "a.[GlengthTotal] as 'लांबी किमी. एकूण'" || item.Value == "a.[GNewKhadikaran] as 'नवीन खडीकरण'" || item.Value == "a.[GBM_Carpet] as 'बी एम व कारपेट सिलकोट सह'" || item.Value == "a.[G20_MM] as '20 मीमी कारपेटसिलकोट सह'" || item.Value == "a.[GSurface] as 'सरफेस ड्रेसिंग'" || item.Value == "a.[GRundikaran] as 'रुंदी करण'" || item.Value == "a.[GBridge_Morya] as 'पूल/ मो-या'" || item.Value == "a.[GRepairExpn] as 'दुरुस्तीचा प्रती खर्च'" || item.Value == "a.[GAnya] as 'अन्य'" || item.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'" || item.Value == "a.[Kamachevav] as 'कामाचा वाव'" || item.Value == "a.[Pahanikramank] as 'पाहणी क्रमांक'" || item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'" || item.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "a.[WorkId] as 'वर्क आयडी'")
                        {
                            unionquery += "'Total' as 'वर्क आयडी',";
                        }
                        if (item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'")
                        {
                            unionquery += "isNULL ('Total','') as 'अर्थसंकल्पीय वर्ष',";
                        }
                        if (item.Value == "a.Type as 'योजनेचे नाव'")
                        {
                            unionquery += "isNULL ('','') as 'योजनेचे नाव',";
                        }
                        if (item.Value == "a.[KamacheName] as 'कामाचे नाव'")
                        {
                            unionquery += "isNULL ('','') as 'कामाचे नाव',";
                        }

                        if (item.Value == "a.[LekhaShirshName] as 'लेखाशीर्ष नाव'")
                        {
                            unionquery += "isNULL ('','') as 'लेखाशीर्ष नाव',";
                        }
                        if (item.Value == "a.[SubType] as 'विभाग'")
                        {
                            unionquery += "isNULL ('','') as 'विभाग',";
                        }
                        if (item.Value == "a.[Upvibhag] as 'उपविभाग'")
                        {
                            unionquery += "isNULL (a.[Upvibhag],'') as 'उपविभाग',";
                        }
                        if (item.Value == "a.[Taluka] as 'तालुका'")
                        {
                            unionquery += "isNULL ('','0') as 'तालुका',";
                        }
                        if (item.Value == "a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब'")
                        {
                            unionquery += "isNULL ('','') as 'अर्थसंकल्पीय बाब',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव'")
                        {
                            unionquery += "isNULL ('','') as 'शाखा अभियंता नाव',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव'")
                        {
                            unionquery += "isNULL ('','') as 'उपअभियंता नाव',";
                        }

                        if (item.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'")
                        {
                            unionquery += "isNULL ('','') as 'आमदारांचे नाव',";
                        }
                        if (item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'")
                        {
                            unionquery += "isNULL ('','') as 'खासदारांचे नाव',";
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

                        if (item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate]) as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate]) as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate]) as 'निविदा क्र/दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'निविदा क्र/दिनांक',";
                        }
                        if (item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'")
                        {
                            unionquery += "sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',";
                        }
                        if (item.Value == "a.[karyarambhadesh] as 'कार्यारंभ आदेश'")
                        {
                            unionquery += "isNULL ('','') as 'कार्यारंभ आदेश',";
                        }
                        if (item.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'")
                        {
                            unionquery += "isNULL ('','') as 'बांधकाम कालावधी',";
                        }
                        if (item.Value == "a.[GJobKramank] as 'जॉब क्रमांक'")
                        {
                            unionquery += "isNULL ('','') as 'जॉब क्रमांक',";
                        }
                        if (item.Value == "a.[GRoadKramank] as 'रस्ता संवर्ग/ क्रमांक'")
                        {
                            unionquery += "isNULL ('','') as 'रस्ता संवर्ग/ क्रमांक',";
                        }
                        if (item.Value == "a.[GRoadPrushthbhag] as 'अस्तीत्वातील रस्त्याचा पृष्ठभाग'")
                        {
                            unionquery += "isNULL ('','') as 'अस्तीत्वातील रस्त्याचा पृष्ठभाग',";
                        }
                        if (item.Value == "a.[GRoll] as 'पीक व रोल'")
                        {
                            unionquery += "sum(a.[GRoll]) as 'पीक व रोल',";
                        }
                        if (item.Value == "a.[GlengthStarted] as 'लांबी किमी. पासून'")
                        {
                            unionquery += "isNULL ('','') as 'लांबी किमी. पासून',";
                        }
                        if (item.Value == "a.[GlengthUpto] as 'लांबी किमी. पर्यंत'")
                        {
                            unionquery += "isNULL ('','') as 'लांबी किमी. पर्यंत',";
                        }
                        if (item.Value == "a.[GlengthTotal] as 'लांबी किमी. एकूण'")
                        {
                            unionquery += "isNULL ('','') as 'लांबी किमी. एकूण',";
                        }
                        if (item.Value == "a.[GNewKhadikaran] as 'नवीन खडीकरण'")
                        {
                            unionquery += "sum(a.[GNewKhadikaran]) as 'नवीन खडीकरण',";
                        }
                        if (item.Value == "a.[GBM_Carpet] as 'बी एम व कारपेट सिलकोट सह'")
                        {
                            unionquery += "sum(a.[GBM_Carpet]) as 'बी एम व कारपेट सिलकोट सह',";
                        }
                        if (item.Value == "a.[G20_MM] as '20 मीमी कारपेटसिलकोट सह'")
                        {
                            unionquery += "sum(a.[G20_MM]) as '20 मीमी कारपेटसिलकोट सह',";
                        }
                        if (item.Value == "a.[GSurface] as 'सरफेस ड्रेसिंग'")
                        {
                            unionquery += "sum(a.[GSurface]) as 'सरफेस ड्रेसिंग',";
                        }
                        if (item.Value == "a.[GRundikaran] as 'रुंदी करण'")
                        {
                            unionquery += "sum(a.[GRundikaran]) as 'रुंदी करण',";
                        }
                        if (item.Value == "a.[GBridge_Morya] as 'पूल/ मो-या'")
                        {
                            unionquery += "sum(a.[GBridge_Morya]) as 'पूल/ मो-या',";
                        }
                        if (item.Value == "a.[GRepairExpn] as 'दुरुस्तीचा प्रती खर्च'")
                        {
                            unionquery += "sum(a.[GRepairExpn]) as 'दुरुस्तीचा प्रती खर्च',";
                        }
                        if (item.Value == "a.[GAnya] as 'अन्य'")
                        {
                            unionquery += "sum(a.[GAnya]) as 'अन्य',";
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
                        if (item.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'")
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
                    if (item.Value == "b.[Sadyasthiti] as 'देयकाची सद्यस्थिती'" || item.Value == "b.[KamachiKimat] as 'कामाची किंमत'" || item.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'" || item.Value == "b.[Takunone] as 'प्रथम तिमाही तरतूद'" || item.Value == "b.[Takuntwo] as 'द्वितीय तिमाही तरतूद'" || item.Value == "b.[Takunthree] as 'तृतीय तिमाही तरतूद'" || item.Value == "b.[Takunfour] as 'चतुर्थ तिमाही तरतूद'" || item.Value == "b.[Tartud]as 'अर्थसंकल्पीय तरतूद'" || item.Value == "b.[AkunAnudan] as 'वितरित तरतूद'" || item.Value == "b.[Magilkharch] as 'मागील खर्च'" || item.Value == "b.[Chalukharch] as 'चालू खर्च'" || item.Value == "b.[Magni] as 'मागणी'" || item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'" || item.Value == "b.[VarshbharatilKharch] as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च'" || item.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'" || item.Value == "b.[VidyutikaranAmt] as 'विद्युतीकरणावरील प्रमा'" || item.Value == "b.[VidyutikaranExpen] as 'विद्युतीकरणावरील वितरित'" || item.Value == "b.[Itarkhrch] as 'इतर खर्च'" || item.Value == "b.[Dviguni] as 'दवगुनी ज्ञापने'" || item.Value == "b.[Apr] as 'Apr'" || item.Value == "b.[May] as 'May'" || item.Value == "b.[Jun] as 'Jun'" || item.Value == "b.[Jul] as 'Jul'" || item.Value == "b.[Aug] as 'Aug'" || item.Value == "b.[Sep] as 'Sep'" || item.Value == "b.[Oct] as 'Oct'" || item.Value == "b.[Nov] as 'Nov'" || item.Value == "b.[Dec] as 'Dec'" || item.Value == "b.[Jan] as 'Jan'" || item.Value == "b.[Feb] as 'Feb'" || item.Value == "b.[Mar] as 'Mar'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "b.[Sadyasthiti] as 'देयकाची सद्यस्थिती'")
                        {
                            unionquery += "sum(b.[Sadyasthiti]) as 'देयकाची सद्यस्थिती',";
                        }
                        if (item.Value == "b.[KamachiKimat] as 'कामाची किंमत'")
                        {
                            unionquery += "sum(b.[KamachiKimat]) as 'कामाची किंमत',";
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
                        if (item.Value == "b.[Tartud]as 'अर्थसंकल्पीय तरतूद'")
                        {
                            unionquery += "sum(b.[Tartud]) as 'अर्थसंकल्पीय तरतूद',";
                        }
                        if (item.Value == "b.[AkunAnudan] as 'वितरित तरतूद'")
                        {
                            unionquery += "sum(b.[AkunAnudan]) as 'वितरित तरतूद',";
                        }
                        if (item.Value == "b.[Magilkharch] as 'मागील खर्च'")
                        {
                            unionquery += "sum(b.[Magilkharch]) as 'मागील खर्च',";
                        }
                        if (item.Value == "b.[Chalukharch] as 'चालू खर्च'")
                        {
                            unionquery += "sum(b.[Chalukharch]) as 'चालू खर्च',";
                        }
                        if (item.Value == "b.[Magni] as 'मागणी'")
                        {
                            unionquery += "sum(b.[Magni]) as 'मागणी',";
                        }
                        if (item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'")
                        {
                            unionquery += "sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',";
                        }
                        if (item.Value == "b.[VarshbharatilKharch] as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च'")
                        {
                            unionquery += "sum(b.[VarshbharatilKharch]) as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च',";
                        }
                        if (item.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'")
                        {
                            unionquery += "isNULL ('','') as 'मुदतवाढ बाबत',";
                        }
                        if (item.Value == "b.[VidyutikaranAmt] as 'विद्युतीकरणावरील प्रमा'")
                        {
                            unionquery += "sum(b.[VidyutikaranAmt]) as 'विद्युतीकरणावरील प्रमा',";
                        }
                        if (item.Value == "b.[VidyutikaranExpen] as 'विद्युतीकरणावरील वितरित'")
                        {
                            unionquery += "sum(b.[VidyutikaranExpen]) as 'विद्युतीकरणावरील वितरित',";
                        }
                        if (item.Value == "b.[Itarkhrch] as 'इतर खर्च'")
                        {
                            unionquery += "sum(b.[Itarkhrch]) as 'इतर खर्च',";
                        }
                        if (item.Value == "b.[Dviguni] as 'दवगुनी ज्ञापने'")
                        {
                            unionquery += "isNULL ('','') as 'दवगुनी ज्ञापने',";
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
                   
                    year = ddlKamacheyear.Text;
                    lekha = "सार्वजनिक बांधकाम पूर्व विभाग,पुणे";
                    chkBuilding.Style.Add("display", "none");

                }
                else
                {
                    year = ddlKamacheyear.Text;
                    lekha = ddlLekhashirsh.Text;
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
                lekha = ddlLekhashirsh.Text;
                ddl = Session["ddl"].ToString();
                value = Session["ddlvalue"].ToString();
            }
            //ObjBindGrid.TypeFBC = " and a.[Type]=N'गट सी'";
            string ArthYear_type = ddlArthYear.Text + "' and Type=N'गट बी";
            DataTable dt = new DataTable();
            dt = ObjBindGrid.BindGrid(year, lekha, ddl, value, ArthYear_type, query, unionquery, "BudgetMasterGAT_FBC", "GAT_FBCProvision");
            Session["MasterGat_BReportSda"] = ObjBindGrid.SessionQuery;
            // da.Fill(dt);
            GridView1.DataSource = dt;

            GridView1.DataBind();
            GridView1.Columns[1].Visible = false;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            Session["MasterGat_BRpt"] = GridView1;
            ListMenu.Style.Add("display", "none");
            GraphicsReport(ObjBindGrid.WhereCondition);
        }

        public void Loader()
        {
            System.Threading.Thread.Sleep(3000);
        }

        protected void btnlekhashirsh_Click(object sender, EventArgs e)
        {
            txtno.Text = "1";
            //BindReport();
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";

            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString();
            
        }

        protected void btnupvibhag_Click(object sender, EventArgs e)
        {
            txtno.Text = "2";
            //BindReport();

            Session["ddl"] = "a.[upvibhag]=N";
            Session["ddlvalue"] = ddlUpvibhag.Text;
            BindGrid();

            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "उपविभाग:-" + ddlUpvibhag.SelectedItem.ToString();
        }

        protected void btnjilha_Click(object sender, EventArgs e)
        {
            txtno.Text = "3";
            //BindReport();

            Session["ddl"] = "a.[Dist]=N";
            Session["ddlvalue"] = ddlJilha.Text;
            BindGrid();

            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "जिल्हा:-" + ddlJilha.SelectedItem.ToString();
        }

        protected void btntaluka_Click(object sender, EventArgs e)
        {
            txtno.Text = "4";
            //BindReport();
            Session["ddl"] = "a.[Taluka]=N";
            Session["ddlvalue"] = ddlTaluka.Text;
            BindGrid();

            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "तालुका:-" + ddlTaluka.SelectedItem.ToString();
        }

        protected void btnworkid_Click(object sender, EventArgs e)
        {
            txtno.Text = "5";
            //BindReport();
            Session["ddl"] = "a.[WorkId]=N";
            Session["ddlvalue"] = ddlworkid.Text;
            BindGrid();

            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "Work_ID:-" + ddlworkid.SelectedItem.ToString();
        }

        protected void btnabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "6";
            //BindReport();
            Session["ddl"] = "a.[ShakhaAbhyantaName]=N";
            Session["ddlvalue"] = ddlShakhaAbhiyanta.Text;
            BindGrid();

            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "शाखा अभियंता:-" + ddlShakhaAbhiyanta.SelectedItem.ToString();
        }

        protected void btnupabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "7";
            //   BindReport();
            Session["ddl"] = "a.[UpabhyantaName]=N";
            Session["ddlvalue"] = ddlShakhUpAbhiyanta.Text;
            BindGrid();

            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "शाखा उपभियांता:-" + ddlShakhUpAbhiyanta.SelectedItem.ToString();
        }

        protected void btnamdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "8";
            //BindReport();
            Session["ddl"] = "a.[AmdaracheName]=N";
            Session["ddlvalue"] = ddlAmdar.Text;
            BindGrid();

            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "आमदार:-" + ddlAmdar.SelectedItem.ToString();
        }

        protected void btnkhasdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "9";
            //BindReport();
            Session["ddl"] = "a.[KhasdaracheName]=N";
            Session["ddlvalue"] = ddlKhasdar.Text;
            BindGrid();


            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "खासदार:-" + ddlKhasdar.SelectedItem.ToString();
        }

        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            txtno.Text = "10";
            //BindReport();
            Session["ddl"] = "a.[ThekedaarName]=N";
            Session["ddlvalue"] = ddlThekedarecheName.Text;
            BindGrid();

            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "ठेकेदाराचे नाव:-" + ddlThekedarecheName.SelectedItem.ToString();
        }

        protected void btnkamachistiti_Click(object sender, EventArgs e)
        {
            txtno.Text = "11";
            //BindReport();
            Session["ddl"] = "a.[Sadyasthiti]=N";
            Session["ddlvalue"] = ddlKamachiSadyStiti.Text;
            BindGrid();

            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "कामाची सद्यस्थिती:-" + ddlKamachiSadyStiti.SelectedItem.ToString();
        }
        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            txtno.Text = "12";
            //BindReport();

            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";
            BindGrid();
            Label3.Text = "कामाचे वर्ष :-" + ddlKamacheyear.Text.Split('-')[0];
        }
        protected void chkBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindReport();
            BindGrid();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddlArthsankalpiyYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnExcel_Click(object sender, EventArgs e)
        {


            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MasterGat_BReport.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        protected void SendEmail(object sender, EventArgs e)
        {



        }

        private string GridViewtoHtml(GridView GridView1)
        {
            StringBuilder objStringBuilder = new StringBuilder();
            StringWriter objStringWriter = new StringWriter(objStringBuilder);
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            GridView1.RenderControl(objHtmlTextWriter);
            return objStringBuilder.ToString();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "MasterGat_BReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "MasterGat_BReport.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }
            Response.Redirect("SendMail.aspx");
        }



        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //BindReport();
            BindGrid();
        }
        int tempcounter = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridView1.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=13&PrevPage=MasterGAT_BReport.aspx";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //Set Grand Total To Footer 
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[GrandTotal.Total_index - 1].Text = "No of works: " + TotalWork.ToString();
                e.Row.Cells[GrandTotal.Total_index].Text = "Grand Total";

                e.Row.Cells[GrandTotal.PikRol_Index].Text = GrandTotal.PikRol.ToString();
                e.Row.Cells[GrandTotal.NavinKhandikarn_index].Text = GrandTotal.NavinKhandikarnex.ToString();
                e.Row.Cells[GrandTotal.B_M_Karpet_index].Text = GrandTotal.B_M_Karpet.ToString();
                e.Row.Cells[GrandTotal.MM_20_Karpet_index].Text = GrandTotal.MM_20_Karpet.ToString();
                e.Row.Cells[GrandTotal.SarfhesDresing_index].Text = GrandTotal.SarfhesDresing.ToString();
                e.Row.Cells[GrandTotal.RundiKaran_index].Text = GrandTotal.RundiKaran.ToString();
                e.Row.Cells[GrandTotal.PulMoYa_index].Text = GrandTotal.PulMoYa.ToString();
                e.Row.Cells[GrandTotal.DurusthichaPratiKharch_index].Text = GrandTotal.DurusthichaPratiKharch.ToString();
                e.Row.Cells[GrandTotal.OtherExp_Index].Text = GrandTotal.OtherExp.ToString();
                e.Row.Cells[GrandTotal.MarchAkher_Index].Text = GrandTotal.MarchAkher.ToString();
                e.Row.Cells[GrandTotal.VitritTartud_Index].Text = GrandTotal.VitritTartud.ToString();
                e.Row.Cells[GrandTotal.ExpUp_Index].Text = GrandTotal.ExpUp.ToString();
                e.Row.Cells[GrandTotal.Magni_Index].Text = GrandTotal.Magni.ToString();
                e.Row.Cells[GrandTotal.EkunKamavarilKharch_Index].Text = GrandTotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[GrandTotal.YearExp_Index].Text = GrandTotal.YearExp.ToString();
                e.Row.Cells[GrandTotal.VidyutikarnPrama_Index].Text = GrandTotal.VidyutikarnPrama.ToString();
                e.Row.Cells[GrandTotal.Vidyutikarnvitarit_Index].Text = GrandTotal.Vidyutikarnvitarit.ToString();

                //New Column
                e.Row.Cells[GrandTotal.PrashaskiyAmt_index].Text = GrandTotal.PrashaskiyAmt.ToString();
                e.Row.Cells[GrandTotal.TantrikAmt_index].Text = GrandTotal.TantrikAmt.ToString();
                //End New Column
                //CPNS
                e.Row.Cells[GrandTotal.C_index].Text = GrandTotal.C.ToString();
                e.Row.Cells[GrandTotal.P_index].Text = GrandTotal.P.ToString();
                e.Row.Cells[GrandTotal.NS_index].Text = GrandTotal.NS.ToString();
                e.Row.Cells[GrandTotal.ES_index].Text = GrandTotal.ES.ToString();
                e.Row.Cells[GrandTotal.TS_index].Text = GrandTotal.TS.ToString();
                //End CPNS
                e.Row.Cells[GrandTotal.Apr_index].Text = GrandTotal.Apr.ToString();
                e.Row.Cells[GrandTotal.May_index].Text = GrandTotal.May.ToString();
                e.Row.Cells[GrandTotal.Jun_index].Text = GrandTotal.Jun.ToString();
                e.Row.Cells[GrandTotal.Jul_index].Text = GrandTotal.Jul.ToString();
                e.Row.Cells[GrandTotal.Aug_index].Text = GrandTotal.Aug.ToString();
                e.Row.Cells[GrandTotal.sep_index].Text = GrandTotal.sep.ToString();
                e.Row.Cells[GrandTotal.Oct_index].Text = GrandTotal.Oct.ToString();
                e.Row.Cells[GrandTotal.Nov_index].Text = GrandTotal.Nov.ToString();
                e.Row.Cells[GrandTotal.Dec_index].Text = GrandTotal.Dec.ToString();
                e.Row.Cells[GrandTotal.Jan_index].Text = GrandTotal.Jan.ToString();
                e.Row.Cells[GrandTotal.Feb_index].Text = GrandTotal.Feb.ToString();
                e.Row.Cells[GrandTotal.Mar_index].Text = GrandTotal.Mar.ToString();

                e.Row.Cells[GrandTotal.Takunone_index].Text = GrandTotal.Takunone.ToString();
                e.Row.Cells[GrandTotal.Takuntwo_index].Text = GrandTotal.Takuntwo.ToString();
                e.Row.Cells[GrandTotal.TisriTartud_index].Text = GrandTotal.TisriTartud.ToString();
                e.Row.Cells[GrandTotal.ChothiTartud_index].Text = GrandTotal.ChothiTartud.ToString();
                e.Row.Cells[GrandTotal.Anya_index].Text = GrandTotal.Anya.ToString();
                e.Row.Cells[GrandTotal.Deykachi_index].Text = GrandTotal.Deykachi.ToString();
                e.Row.Cells[GrandTotal.KamchiKimat_index].Text = GrandTotal.KamchiKimat.ToString();
                e.Row.Cells[GrandTotal.NividaRakkam_index].Text = GrandTotal.NividaRakkam.ToString();
                e.Row.Cells[GrandTotal.ArthsankalpTartud_Index].Text = GrandTotal.ArthsankalpTartud.ToString();
                e.Row.Cells[GrandTotal.Magilkharch_index].Text = GrandTotal.Magilkharch.ToString();
            }



            //Creat String Array for stord Column header NAME and get  particular column index no. 
            string[] HeadrName = new string[e.Row.Cells.Count];

            if (e.Row.RowType == DataControlRowType.Header)
            {
                //for loop : increment the row cell by one and stor in string headrname
                for (int RowHeader_Index = 0; RowHeader_Index < e.Row.Cells.Count; RowHeader_Index++)
                {
                    HeadrName[RowHeader_Index] = e.Row.Cells[RowHeader_Index].Text;

                }

                // index(ColumnName) method of cls ReportGrandTotal
                GrandTotal.index(HeadrName);

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                RowCount++;
                // do your stuffs here, for example if column Total is your third column:
                //s e.Row.Cells[3].BackColor = System.Drawing.Color.Pink;
                if (e.Row.Cells[GrandTotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[GrandTotal.Total_index - 1].Text = (RowCount - 1).ToString();
                    TotalWork += RowCount - 1;
                    RowCount = 0;
                    e.Row.Cells[GrandTotal.Total_index + 1].Text = "";
                    e.Row.Cells[GrandTotal.Total_index + 6].Text = "";
                    e.Row.Cells[GrandTotal.Total_index - 2].Text = "";

                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    //e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;


                    //Check column is in List or Not(checkbox checked or not)

                    if (data.DataView.Table.Columns["पीक व रोल"] != null)
                    {
                        GrandTotal.PikRol += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "पीक व रोल"));
                    }
                    if (data.DataView.Table.Columns["नवीन खडीकरण"] != null)
                    {
                        GrandTotal.NavinKhandikarnex += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "नवीन खडीकरण"));
                    }
                    if (data.DataView.Table.Columns["बी एम व कारपेट सिलकोट सह"] != null)
                    {
                        GrandTotal.B_M_Karpet += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "बी एम व कारपेट सिलकोट सह"));
                    }
                    if (data.DataView.Table.Columns["20 मीमी कारपेटसिलकोट सह"] != null)
                    {
                        GrandTotal.MM_20_Karpet += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "20 मीमी कारपेटसिलकोट सह"));
                    }
                    if (data.DataView.Table.Columns["सरफेस ड्रेसिंग"] != null)
                    {
                        GrandTotal.SarfhesDresing += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सरफेस ड्रेसिंग"));
                    }
                    if (data.DataView.Table.Columns["रुंदी करण"] != null)
                    {
                        GrandTotal.RundiKaran += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "रुंदी करण"));
                    }
                    if (data.DataView.Table.Columns["पूल/ मो-या"] != null)
                    {
                        GrandTotal.PulMoYa += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "पूल/ मो-या"));
                    }
                    if (data.DataView.Table.Columns["दुरुस्तीचा प्रती खर्च"] != null)
                    {
                        GrandTotal.DurusthichaPratiKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "दुरुस्तीचा प्रती खर्च"));
                    }

                    if (data.DataView.Table.Columns["अन्"] != null)
                    {
                        GrandTotal.OtherExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अन्"));
                    }

                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        GrandTotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }

                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        GrandTotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        GrandTotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        GrandTotal.ExpUp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        GrandTotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        GrandTotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        GrandTotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        GrandTotal.VidyutikarnPrama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        GrandTotal.Vidyutikarnvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }


                    //New Column
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {

                        GrandTotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {

                        GrandTotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    //End new Column
                    //CPNS
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        GrandTotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        GrandTotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        GrandTotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        GrandTotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        GrandTotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    //End CPNS
					
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        GrandTotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        GrandTotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        GrandTotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        GrandTotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        GrandTotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        GrandTotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        GrandTotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        GrandTotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        GrandTotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        GrandTotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        GrandTotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        GrandTotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }

                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        GrandTotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        GrandTotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        GrandTotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        GrandTotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["अन्य"] != null)
                    {
                        GrandTotal.Anya += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अन्य"));
                    }
                    if (data.DataView.Table.Columns["देयकाची सद्यस्थिती"] != null)
                    {
                        GrandTotal.Deykachi += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "देयकाची सद्यस्थिती"));
                    }
                    if (data.DataView.Table.Columns["कामाची किंमत"] != null)
                    {
                        GrandTotal.KamchiKimat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "कामाची किंमत"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        GrandTotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        GrandTotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                }


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
           // BindReport();
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
            Response.Redirect("MasterBudgetGat_FBC.aspx?BWorkID=" + pName + "");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }

        protected void ddlKamacheyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lekhashirsh();
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            if (myBtn2.Checked == true)
            {
                if (txtpassword.Text == "PwdPuneEast")
                {
                    //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterGat_BReportSda"].ToString(), con);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.Columns[1].Visible = true;
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
                }
                else
                {
                    myBtn2.Checked = false;
                    //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterGat_BReportSda"].ToString(), con);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.Columns[1].Visible = false;
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
                }
            }
            else
            {
                myBtn2.Checked = false;
                //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterGat_BReportSda"].ToString(), con);
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
            string ID = GridView1.Rows[0].Cells[4].Text;
            //Prepare Sql Delete Command         

        }



        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string WorkId = e.Keys["वर्क आयडी"].ToString();
            strSqlCommand = "Delete From [BudgetMasterGAT_FBC] Where [WorkId]='" + WorkId + "'";
            strSqlCommand1 = "Delete From [GAT_FBCProvision] Where [WorkId]='" + WorkId + "'";
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
                //BindReport();
                BindGrid();
                GridView1.Columns[1].Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deletion Failed')", true);
                //

                BindGrid();
                GridView1.Columns[1].Visible = true;
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            con.Close();
        }

        public void GraphicsReport(string WhereCondition)
        {
            string[] arr1 = { "Completed", "Incomplete", "Inprogress", "Tender Stage", "Estimated Stage", "Not Started", "Estimated Cost", "T.S Cost", "Budget Provision", "Expenditure" };
            decimal[] arr = new decimal[10];

            objGraph.GraphicsReports("[BudgetMasterGAT_FBC]", "[GAT_FBCProvision]", WhereCondition);

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