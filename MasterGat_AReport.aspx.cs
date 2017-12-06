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
    public partial class MasterGat_AReport : System.Web.UI.Page
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
        int RowCount = 0;
        int TotalWork = 0;

        string query = string.Empty;
        string unionquery = string.Empty;
        bool isSelected;
        string year = string.Empty, lekha = string.Empty, ddl = string.Empty, value = string.Empty;
        //ReportGrandTotal GrandTotal = new ReportGrandTotal();
        //int rowCount = 0;
        //int TotalWork = 0;
        SqlDataAdapter da;
        SqlDataAdapter da1;
        clsGraphicsReport objGraph = new clsGraphicsReport();
        MasterReportGridBind ObjBindGrid = new MasterReportGridBind();
        ReportGrandTotal GrandTotal = new ReportGrandTotal();
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
                    foreach (var item in chkBuilding.Items.Cast<ListItem>().Where(li => li.Value == "a.[WorkId] as 'वर्क आयडी'"
                        || li.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'"
                        || li.Value == "a.[KamacheName] as 'कामाचे नाव'"
                        || li.Value == "a.[LekhaShirshName] as 'लेखाशीर्ष नाव'"
                        || li.Value == "a.[Upvibhag] as 'उपविभाग'"
                        || li.Value == "a.[Taluka] as 'तालुका'"
                        || li.Value == "a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब'"
                        || li.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'"
                        || li.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'"
                        || li.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'"
                        || li.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'"
                        || li.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश'"
                        || li.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'"
                        || li.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'"
                        || li.Value == "a.[GAadeshKramank] as 'आदेश क्र'"
                        || li.Value == "a.[GJobKramank] as 'जॉब क्र'"
                        || li.Value == "a.[Kamachevav] as 'कामाचा वाव'"
                        || li.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'" || li.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'"
                        || li.Value == "b.[ManjurAmt] as 'मंजूर अंदाजित किंमत'"
                        || li.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'"
                        || li.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत'"
                        || li.Value == "b.[Tartud]as 'अर्थसंकल्पीय तरतूद'"
                        || li.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'"
                        || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'"
                        || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'चालू'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'"
                        || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'"
                        || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकीय स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'"
                        || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'"))
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
                if (previousPageName == "MasterBudgetGat_A.aspx" || previousPageName == "Send_sms.aspx" || previousPageName == "UploadImage.aspx")
                {
                    if (Session["MasterGat_ARpt"] != null)
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterGat_AReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterGat_AReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterGat_AReportSda"];
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from GAT_AProvision Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from BudgetMasterGAT_A Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select [LekhaShirshName] from [BudgetMasterGAT_A] where [Arthsankalpiyyear]='" + ddlKamacheyear.SelectedItem.ToString() + "' Group By([LekhaShirshName])", con);
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
            if ((dt = (ObjsqlQueryOrCon.Bind_MasterReport_ddl("[BudgetMasterGAT_A]", ddlLekhashirsh.SelectedItem.ToString()))).Rows.Count > 0)
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
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear] ORDER BY a.[Arthsankalpiyyear],    CASE WHEN ISNUMERIC(a.[ArthsankalpiyBab]) = 1 THEN 0 ELSE 1 END,    CASE WHEN ISNUMERIC(a.[ArthsankalpiyBab]) = 1 THEN CAST(a.[ArthsankalpiyBab] AS INT) ELSE 0 END,a.[ArthsankalpiyBab],a.[Upvibhag],a.taluka) as 'अ क्र', ";

            unionquery = "  union select isNULL ('','')as'अ क्र', ";
            isSelected = chkBuilding.Items.Cast<ListItem>().Count(i => i.Selected == true) > 0;
            if (!isSelected)
            {
                chkBuilding.Items[0].Selected = true;

            }
            foreach (ListItem item in chkBuilding.Items)
            {
                if (item.Selected)
                {
                    if (item.Value == "a.[WorkId] as 'वर्क आयडी'"
                        || item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'"
                        || item.Value == "a.[KamacheName] as 'कामाचे नाव'"
                        || item.Value == "a.[LekhaShirshName] as 'लेखाशीर्ष नाव'"
                        || item.Value == "a.[SubType] as 'विभाग'"
                        || item.Value == "a.[Upvibhag] as 'उपविभाग'"
                        || item.Value == "a.[Taluka] as 'तालुका'"
                        || item.Value == "a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब'"
                        || item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव'"
                        || item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव'"
                        || item.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'"
                        || item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'"
                        || item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'"
                        || item.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" 
                        || item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'"
                        || item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'"
                        || item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश'"
                        || item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'"
                        || item.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'"
                        || item.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'"
                        || item.Value == "a.[GAadeshKramank] as 'आदेश क्र'"
                        || item.Value == "a.[GUpshirsh] as 'उपशिर्ष'"
                        || item.Value == "a.[GJobKramank] as 'जॉब क्र'"
                        || item.Value == "a.[GJobRakkam] as 'जॉब रक्कम'"
                        || item.Value == "a.[GDambarichePariman] as 'डांबरीचे परिमाण'"
                        || item.Value == "a.[GDambarichiRakkam] as 'डांबरीची रक्कम'"
                        || item.Value == "a.[GDurustichaprakar] as 'दुरुस्तीचा प्रकार'"
                        || item.Value == "cast(a.[GVaperDambarichePariman] as decimal(10,2)) as 'वापर डांबरीचे परिमाण'"
                        || item.Value == "a.[GKampurnKarnyachaDinak] as 'डांबरीचे काम पूर्ण दिनांक'"
                        || item.Value == "a.[GKampurnJhalyachaDinak] as 'डांबरीचे काम पूर्ण झाल्याच्या दिनांक'"
                        || item.Value == "a.[GDeyakSadarKelyachaDinak] as 'विभागात देयक सादर दिनांक'"
                        || item.Value == "a.[GParitKelyachaDinak] as 'विभागात देयक पारित दिनांक'"
                        || item.Value == "a.[Pahanikramank] as 'पाहणीक्रमांक'"
                        || item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'"
                        || item.Value == "a.[Kamachevav] as 'कामाचा वाव'"
                        || item.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'"
                        || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" 
                        || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'चालू'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'"
                        || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" 
                        || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकीय स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" 
                        || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "a.[WorkId] as 'वर्क आयडी'")
                        {
                            unionquery += "'Total' as 'वर्क आयडी',";
                        }
                        if (item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'")
                        {
                            unionquery += "isNULL (a.[Arthsankalpiyyear],'') as 'अर्थसंकल्पीय वर्ष',";
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
                            unionquery += "isNULL ('','') as 'उपविभाग',";
                        }
                        if (item.Value == "a.[Taluka] as 'तालुका'")
                        {
                            unionquery += "isNULL ('','') as 'तालुका',";
                        }
                        if (item.Value == "a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब'")
                        {
                            unionquery += "sum( cast(a.[ArthsankalpiyBab] as int)) as 'अर्थसंकल्पीय बाब',";
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

                        if (item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश'")
                        {
                            unionquery += "isNULL ('','') as 'कार्यारंभ आदेश',";
                        }
                        if (item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'")
                        {
                            unionquery += "sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',";
                        }
                        if (item.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'")
                        {
                            unionquery += "isNULL ('','') as 'बांधकाम कालावधी',";
                        }
                        if (item.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'")
                        {
                            unionquery += "isNULL ('','') as 'काम पूर्ण तारीख',";
                        }
                        if (item.Value == "a.[GAadeshKramank] as 'आदेश क्र'")
                        {
                            unionquery += "isNULL ('','') as 'आदेश क्र',";
                        }
                        if (item.Value == "a.[GUpshirsh] as 'उपशिर्ष'")
                        {
                            unionquery += "isNULL ('','') as 'उपशिर्ष',";
                        }
                        if (item.Value == "a.[GJobKramank] as 'जॉब क्र'")
                        {
                            unionquery += "isNULL ('','') as 'जॉब क्र',";
                        }
                        if (item.Value == "a.[GJobRakkam] as 'जॉब रक्कम'")
                        {
                            unionquery += "sum(a.[GJobRakkam]) as 'जॉब रक्कम',";
                        }
                        if (item.Value == "a.[GDambarichePariman] as 'डांबरीचे परिमाण'")
                        {
                            unionquery += "sum(a.[GDambarichePariman]) as 'डांबरीचे परिमाण',";
                        }
                        if (item.Value == "a.[GDambarichiRakkam] as 'डांबरीची रक्कम'")
                        {
                            unionquery += "sum(a.[GDambarichiRakkam]) as 'डांबरीची रक्कम',";
                        }
                        if (item.Value == "a.[GDurustichaprakar] as 'दुरुस्तीचा प्रकार'")
                        {
                            unionquery += "isNULL ('','') as 'दुरुस्तीचा प्रकार',";
                        }
                        if (item.Value == "cast(a.[GVaperDambarichePariman] as decimal(10,2)) as 'वापर डांबरीचे परिमाण'")
                        {
                            unionquery += "sum(cast(a.[GVaperDambarichePariman] as decimal(10,2))) as 'वापर डांबरीचे परिमाण',";
                        }
                        if (item.Value == "a.[GKampurnKarnyachaDinak] as 'डांबरीचे काम पूर्ण दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'डांबरीचे काम पूर्ण दिनांक',";
                        }
                        if (item.Value == "a.[GKampurnJhalyachaDinak] as 'डांबरीचे काम पूर्ण झाल्याच्या दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'डांबरीचे काम पूर्ण झाल्याच्या दिनांक',";
                        }
                        if (item.Value == "a.[GDeyakSadarKelyachaDinak] as 'विभागात देयक सादर दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'विभागात देयक सादर दिनांक',";
                        }
                        if (item.Value == "a.[GParitKelyachaDinak] as 'विभागात देयक पारित दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'विभागात देयक पारित दिनांक',";
                        }
                        if (item.Value == "a.[Pahanikramank] as 'पाहणीक्रमांक'")
                        {
                            unionquery += "isNULL ('','') as 'पाहणीक्रमांक',";
                        }
                        if (item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'")
                        {
                            unionquery += "isNULL ('','') as 'पाहणीमुद्ये',";
                        }
                        if (item.Value == "a.[Kamachevav] as 'कामाचा वाव'")
                        {
                            unionquery += "isNULL ('','') as 'कामाचा वाव',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'")
                        {
                            unionquery += "isNULL ('','') as 'शेरा',";
                        }
                        //CPNS

                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'चालू'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = N'चालू'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकीय स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकीय स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',";
                        }
                        //End CPNS

                        isSelected = true;
                    }
                    if (item.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'"
                        || item.Value == "b.[ShilakDayitvAmt] as 'शिल्लक दायित्व रु'"
                        || item.Value == "b.[DayitvAvshyakYesNo] as 'दायित्व आवश्यकता आहे / नाही'"
                        || item.Value == "b.[DayitvAmt] as 'दायित्व असल्यास रक्कम रु'"
                        || item.Value == "b.[ManjurAmt] as 'मंजूर अंदाजित किंमत'"
                        || item.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'"
                        || item.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत'"
                        || item.Value == "b.[Takunone] as 'प्रथम तिमाही तरतूद'"
                        || item.Value == "b.[Takuntwo] as 'द्वितीय तिमाही तरतूद'"
                        || item.Value == "b.[Takunthree] as 'तृतीय तिमाही तरतूद'"
                        || item.Value == "b.[Takunfour] as 'चतुर्थ तिमाही तरतूद'"
                        || item.Value == "b.[Tartud]as 'अर्थसंकल्पीय तरतूद'"
                        || item.Value == "b.[AkunAnudan] as 'वितरित तरतूद'"
                        || item.Value == "b.[Chalukharch] as 'चालू खर्च'"
                        || item.Value == "b.[VidyutikaranAmt] as 'विद्युतीकरण कामाची किंमत'"
                        || item.Value == "b.[VidyutikaranExpen] as 'विद्युतीकरणाचा खर्च'"
                        || item.Value == "b.[DambarichaExpen] as 'डांबरीचा खर्च'"
                        || item.Value == "b.[Itarkhrch] as 'इतर खर्च'"
                        || item.Value == "b.[Dviguni] as 'द्वीगुणी'"
                        || item.Value == "b.[Magni] as 'मागणी'"
                        || item.Value == "b.[Magilkharch] as 'मागील खर्च'"
                        || item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'"
                        || item.Value == "b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च'"
                        || item.Value == "b.[Apr] as 'Apr'" || item.Value == "b.[May] as 'May'" || item.Value == "b.[Jun] as 'Jun'" || item.Value == "b.[Jul] as 'Jul'"
                        || item.Value == "b.[Aug] as 'Aug'" || item.Value == "b.[Sep] as 'Sep'" || item.Value == "b.[Oct] as 'Oct'" || item.Value == "b.[Nov] as 'Nov'"
                        || item.Value == "b.[Dec] as 'Dec'" || item.Value == "b.[Jan] as 'Jan'" || item.Value == "b.[Feb] as 'Feb'" || item.Value == "b.[Mar] as 'Mar'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'")
                        {
                            unionquery += "isNULL ('','') as 'मुदतवाढ बाबत',";
                        }
                        if (item.Value == "b.[ShilakDayitvAmt] as 'शिल्लक दायित्व रु'")
                        {
                            unionquery += "sum(b.[ShilakDayitvAmt]) as 'शिल्लक दायित्व रु',";
                        }
                        if (item.Value == "b.[DayitvAvshyakYesNo] as 'दायित्व आवश्यकता आहे / नाही'")
                        {
                            unionquery += "isNULL ('','') as 'दायित्व आवश्यकता आहे / नाही',";
                        }
                        if (item.Value == "b.[DayitvAmt] as 'दायित्व असल्यास रक्कम रु'")
                        {
                            unionquery += "sum(b.[DayitvAmt]) as 'दायित्व असल्यास रक्कम रु',";
                        }
                        if (item.Value == "b.[ManjurAmt] as 'मंजूर अंदाजित किंमत'")
                        {
                            unionquery += "sum(b.[ManjurAmt]) as 'मंजूर अंदाजित किंमत',";
                        }
                        if (item.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'")
                        {
                            unionquery += "sum(b.[MarchEndingExpn])as 'मार्च अखेर खर्च 2017',";
                        }
                        if (item.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत'")
                        {
                            unionquery += "sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',";
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
                            unionquery += "sum(b.[Tartud])as 'अर्थसंकल्पीय तरतूद',";
                        }
                        if (item.Value == "b.[AkunAnudan] as 'वितरित तरतूद'")
                        {
                            unionquery += "sum(b.[AkunAnudan]) as 'वितरित तरतूद',";
                        }
                        if (item.Value == "b.[Chalukharch] as 'चालू खर्च'")
                        {
                            unionquery += "sum(b.[Chalukharch])as 'चालू खर्च',";
                        }
                        if (item.Value == "b.[VidyutikaranAmt] as 'विद्युतीकरण कामाची किंमत'")
                        {
                            unionquery += "sum(b.[VidyutikaranAmt]) as 'विद्युतीकरण कामाची किंमत',";
                        }
                        if (item.Value == "b.[VidyutikaranExpen] as 'विद्युतीकरणाचा खर्च'")
                        {
                            unionquery += "sum(b.[VidyutikaranExpen]) as 'विद्युतीकरणाचा खर्च',";
                        }
                        if (item.Value == "b.[DambarichaExpen] as 'डांबरीचा खर्च'")
                        {
                            unionquery += "sum(b.[DambarichaExpen]) as 'डांबरीचा खर्च',";
                        }
                        if (item.Value == "b.[Itarkhrch] as 'इतर खर्च'")
                        {
                            unionquery += "sum(b.[Itarkhrch]) as 'इतर खर्च',";
                        }
                        if (item.Value == "b.[Dviguni] as 'द्वीगुणी'")
                        {
                            unionquery += "isNULL ('','') as 'द्वीगुणी',";
                        }
                        if (item.Value == "b.[Magni] as 'मागणी'")
                        {
                            unionquery += "sum(b.[Magni]) as 'मागणी',";
                        }
                        if (item.Value == "b.[Magilkharch] as 'मागील खर्च'")
                        {
                            unionquery += "sum(b.[Magilkharch]) as 'मागील खर्च',";
                        }
                        if (item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'")
                        {
                            unionquery += "sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',";
                        }
                        if (item.Value == "b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च'")
                        {
                            unionquery += "sum(b.[VarshbharatilKharch]) as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च',";
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
                    lekha = "सार्वजनिक बांधकाम पूर्व विभाग,पुणे";
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
            DataTable dt = new DataTable();
            dt = ObjBindGrid.BindGrid(year, lekha, ddl, value, ddlArthYear.Text, query, unionquery, "BudgetMasterGAT_A", "GAT_AProvision");
            Session["MasterGat_AReportSda"] = ObjBindGrid.SessionQuery;
            // da.Fill(dt);
            GridView1.DataSource = dt;

            GridView1.DataBind();
            GridView1.Columns[1].Visible = false;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            Session["MasterGat_ARpt"] = GridView1;
            ListMenu.Style.Add("display", "none");
            GraphicsReport(ObjBindGrid.WhereCondition);
        }
        public void Loader()
        {
            //System.Threading.Thread.Sleep(3000);
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
            Response.AddHeader("content-disposition", "attachment; filename=MasterGat_AReport.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        protected void SendEmail(object sender, EventArgs e)
        {
            //using (StringWriter sw = new StringWriter())
            //{
            //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            //    {
            //        GridView1.RenderControl(hw);
            //        StringReader sr = new StringReader(sw.ToString());
            //        MailMessage mm = new MailMessage("gayatridhande01@gmail.com", "swapnilgadgade1@gmail.com");
            //        mm.Subject = "GridView Email";
            //        mm.Body = "GridView:<hr />" + sw.ToString(); ;
            //        mm.IsBodyHtml = true;
            //        SmtpClient smtp = new SmtpClient();
            //        smtp.Host = "smtp.gmail.com";
            //        smtp.EnableSsl = true;
            //        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            //        NetworkCred.UserName = "gayatridhande01@gmail.com";
            //        NetworkCred.Password = "";
            //        smtp.UseDefaultCredentials = true;
            //        smtp.Credentials = NetworkCred;
            //        smtp.Port = 587;
            //        smtp.Send(mm);
            //    }
            //}
            //tab1.Visible = true;

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

        protected void bnsend_Click(object sender, EventArgs e)
        {


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

            Session["filename"] = "MasterGat_AReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "MasterGat_AReport.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }
            Response.Redirect("SendMail.aspx");
        }



        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // BindReport();
            BindGrid();
        }
        int tempcounter = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            // for upload Image
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridView1.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=11&PrevPage=MasterGat_AReport.aspx";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
                RowCount++;
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                //e.Row.Cells[3].BackColor = System.Drawing.Color.Pink;
                if (e.Row.Cells[GrandTotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[4].Text = "";
                    e.Row.Cells[GrandTotal.Total_index - 2].Text = "";
                    e.Row.Cells[GrandTotal.Total_index - 1].Text = (RowCount - 1).ToString();
                    TotalWork += RowCount - 1;
                    RowCount = 0;

                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;
                    //Check column is in List or Not(checkbox checked or not)
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय बाब"] != null)
                    {
                        e.Row.Cells[GrandTotal.ArthsankalpBab_index].Text = "";

                    }

                    if (data.DataView.Table.Columns["जॉब रक्कम"] != null)
                    {

                        GrandTotal.JobAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "जॉब रक्कम"));
                    }
                    if (data.DataView.Table.Columns["डांबरीचे परिमाण"] != null)
                    {

                        GrandTotal.DabrichePariman += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "डांबरीचे परिमाण"));
                    }
                    if (data.DataView.Table.Columns["डांबरीची रक्कम"] != null)
                    {

                        GrandTotal.DabrichiAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "डांबरीची रक्कम"));
                    }
                    if (data.DataView.Table.Columns["शिल्लक दायित्व रु"] != null)
                    {

                        GrandTotal.ShilakDayitv += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "शिल्लक दायित्व रु"));
                    }
                    if (data.DataView.Table.Columns["दायित्व असल्यास रक्कम रु"] != null)
                    {

                        GrandTotal.DayitvAslyasAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "दायित्व असल्यास रक्कम रु"));
                    }
                    if (data.DataView.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        GrandTotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {

                        GrandTotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        GrandTotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
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
                    if (data.DataView.Table.Columns["विद्युतीकरण कामाची किंमत"] != null)
                    {

                        GrandTotal.VidyutikarnKamchiKimat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरण कामाची किंमत"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणाचा खर्च"] != null)
                    {

                        GrandTotal.VidyutiKarnchaKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणाचा खर्च"));
                    }


                    if (data.DataView.Table.Columns["डांबरीचा खर्च"] != null)
                    {

                        GrandTotal.DabrichKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "डांबरीचा खर्च"));
                    }

                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        GrandTotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        GrandTotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च"] != null)
                    {
                        GrandTotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च"));
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
                        GrandTotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mar"));
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
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        GrandTotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        GrandTotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        GrandTotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //Set Grand Total To Footer 
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[GrandTotal.Total_index - 1].Text = "No of works: " + TotalWork.ToString();
                e.Row.Cells[GrandTotal.Total_index].Text = "Grand Total";

                e.Row.Cells[GrandTotal.JobAmt_Index].Text = GrandTotal.JobAmt.ToString();
                e.Row.Cells[GrandTotal.DabrichePariman_Index].Text = GrandTotal.DabrichePariman.ToString();

                e.Row.Cells[GrandTotal.DabrichiAmt_index].Text = GrandTotal.DabrichiAmt.ToString();
                e.Row.Cells[GrandTotal.ShilakDayitv_Index].Text = GrandTotal.ShilakDayitv.ToString();

                e.Row.Cells[GrandTotal.DayitvAslyasAmt_Index].Text = GrandTotal.DayitvAslyasAmt.ToString();
                e.Row.Cells[GrandTotal.ManjurAmt_index].Text = GrandTotal.ManjurAmt.ToString();
                e.Row.Cells[GrandTotal.MarchAkher_Index].Text = GrandTotal.MarchAkher.ToString();
                e.Row.Cells[GrandTotal.UrvaritAmt_index].Text = GrandTotal.UrvaritAmt.ToString();
                e.Row.Cells[GrandTotal.ArthsankalpTartud_Index].Text = GrandTotal.ArthsankalpTartud.ToString();

                e.Row.Cells[GrandTotal.VitritTartud_Index].Text = GrandTotal.VitritTartud.ToString();
                e.Row.Cells[GrandTotal.ExpUp_Index].Text = GrandTotal.ExpUp.ToString();

                e.Row.Cells[GrandTotal.VidyutikarnKamchiKimat_Index].Text = GrandTotal.VidyutikarnKamchiKimat.ToString();
                e.Row.Cells[GrandTotal.VidyutiKarnchaKharch_index].Text = GrandTotal.VidyutiKarnchaKharch.ToString();

                e.Row.Cells[GrandTotal.DabrichKharch_index].Text = GrandTotal.DabrichKharch.ToString();

                e.Row.Cells[GrandTotal.Magni_Index].Text = GrandTotal.Magni.ToString();
                e.Row.Cells[GrandTotal.EkunKamavarilKharch_Index].Text = GrandTotal.EkunKamavarilKharch.ToString();

                e.Row.Cells[GrandTotal.YearExp_Index].Text = GrandTotal.YearExp.ToString();
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
                e.Row.Cells[GrandTotal.Itarkhrch_index].Text = GrandTotal.Itarkhrch.ToString();
                e.Row.Cells[GrandTotal.Magilkharch_index].Text = GrandTotal.Magilkharch.ToString();
                e.Row.Cells[GrandTotal.NividaRakkam_index].Text = GrandTotal.NividaRakkam.ToString();

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
            //BindReport();
            BindGrid();
        }

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            pName = GridView1.DataKeys[e.NewSelectedIndex].Values["वर्क आयडी"].ToString();
            Response.Redirect("Send_sms.aspx?WorkID=" + pName + "");
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pName = GridView1.DataKeys[e.NewEditIndex].Values["वर्क आयडी"].ToString();
            Response.Redirect("MasterBudgetGat_A.aspx?WorkID=" + pName + "");
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterGat_AReportSda"].ToString(), con);
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterGat_AReportSda"].ToString(), con);
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
                SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterGat_AReportSda"].ToString(), con);
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
            strSqlCommand = "Delete From [BudgetMasterGAT_A] Where [WorkId]='" + ID + "'";
            strSqlCommand1 = "Delete From [GAT_AProvision] Where [WorkId]='" + ID + "'";
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(strSqlCommand, con);
            cmd1 = new SqlCommand(strSqlCommand1, con);
            if (cmd.ExecuteNonQuery() > 0 && cmd1.ExecuteNonQuery() > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
                //Refresh GridView             
                // BindReport();
                BindGrid();
                GridView1.Columns[1].Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deletion Failed')", true);
            }
            con.Close();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string WorkId = e.Keys["वर्क आयडी"].ToString();
            strSqlCommand = "Delete From [BudgetMasterGAT_A] Where [WorkId]='" + WorkId + "'";
            strSqlCommand1 = "Delete From [GAT_AProvision] Where [WorkId]='" + WorkId + "'";
            strSqlCommand2 = "Delete From [SendSms_tbl] Where [WorkId]='" + WorkId + "'";
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(strSqlCommand, con);
            cmd1 = new SqlCommand(strSqlCommand1, con);
            if (cmd.ExecuteNonQuery() > 0 && cmd1.ExecuteNonQuery() > 0 && cmd2.ExecuteNonQuery() > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
                //Refresh GridView             
                // BindReport();
                BindGrid();
                GridView1.Columns[1].Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deletion Failed')", true);
                // BindReport();
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

            objGraph.GraphicsReports("[BudgetMasterGAT_A]", "[GAT_AProvision]", WhereCondition);

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
