using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using DataLayer;


namespace PWdEEBudget
{
    public partial class Master2515Report : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        static SqlQueryOrConnection ObjsqlQueryOrCon = new SqlQueryOrConnection();

        string pName;
        SqlCommand cmd = null;
        string strSqlCommand = String.Empty;
        SqlCommand cmd1 = null;
        string strSqlCommand1 = String.Empty;
        SqlCommand cmd2 = null;
        string strSqlCommand2 = String.Empty;

        int RowCount = 0, TotalWork = 0;
        ReportGrandTotal grand2515total = new ReportGrandTotal();
        clsGraphicsReport objGraph = new clsGraphicsReport();
        MasterReportGridBind ObjBindGrid = new MasterReportGridBind();
        string query = string.Empty;
        string unionquery = string.Empty;
        bool isSelected;
        string year = string.Empty, lekha = string.Empty, ddl = string.Empty, value = string.Empty;

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
                    foreach (var item in chkBuilding.Items.Cast<ListItem>().Where(li => li.Value == "a.[WorkId] as 'वर्क आयडी'" || li.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'" || li.Value == "a.[KamacheName] as 'कामाचे नाव'" || li.Value == "a.[LekhaShirshName] as 'लेखाशीर्ष नाव'" || li.Value == "a.[Upvibhag] as 'उपविभाग'" || li.Value == "a.[Taluka] as 'तालुका'" || li.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || li.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || li.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक'" || li.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || li.Value == "a.[karyarambhadesh] as 'कार्यारंभ आदेश'" || li.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'" || li.Value == "a.[Kamachevav] as 'कामाचा वाव'" || li.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'" || li.Value == "b.[ManjurAmt] as 'मंजूर किंमत'" || li.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत'" || li.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'" || li.Value == "b.[Tartud]as 'अर्थसंकल्पीय तरतूद'" || li.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'" || li.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'" ||li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर ' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'" ))
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

                //tab1.Visible = false;
                //  lblLekha.Text = ddlLekhashirsh.SelectedItem.ToString();




            }
            if (Request.UrlReferrer != null)
            {
                string previousPageUrl = Request.UrlReferrer.AbsoluteUri;
                string previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);
                if (previousPageName == "MasterBudget2515.aspx" || previousPageName == "Send_sms.aspx" || previousPageName == "UploadImage.aspx")
                {

                    if (Session["Master2515Rpt"] != null)
                    {
                        //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                        SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterBuildingReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterBuildingReportSda"].ToString(), con);
                        DataTable dt = new DataTable();
                        sda1.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        CheckBox1.Checked = true;
                        //GridView1_RowDataBound();
                        //GridView1_RowDataBound(null,null);

                        GridViewRow row = GridView1.Rows[0];
                        ////row.Visible = true;
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
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 120 ,true); </script>", false);

                    }
                }
            }
            ListMenu.Style.Add("display", "block");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Add Fake Delay to simulate long running process.
           // System.Threading.Thread.Sleep(5000);
            // LoadCustomers();
        }

        public void ArthsankalpiyYear()
        {
            ddlArthYear.Items.Clear();
            ddlArthYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from [2515Provision] Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from [BudgetMaster2515] Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select [LekhaShirshName] from [BudgetMaster2515] where [Arthsankalpiyyear]='" + ddlKamacheyear.SelectedItem.ToString() + "' Group By (LekhaShirshName)", con);
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
            if ((dt = (ObjsqlQueryOrCon.Bind_MasterReport_ddl("[BudgetMaster2515]", ddlLekhashirsh.SelectedItem.ToString()))).Rows.Count > 0)
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
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka] desc) as 'SrNo', ";
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
                    if (item.Value == "a.[WorkId] as 'वर्क आयडी'" || item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'" || item.Value == "a.[KamacheName] as 'कामाचे नाव'" || item.Value == "a.[LekhaShirshName] as 'लेखाशीर्ष नाव'" || item.Value == "a.[SubType] as 'विभाग'" || item.Value == "a.[Upvibhag] as 'उपविभाग'" || item.Value == "a.[Taluka] as 'तालुका'" || item.Value == "a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब'" || item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव'" || item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव'" || item.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'" || item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'" || item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || item.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक'" || item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || item.Value == "a.[karyarambhadesh] as 'कार्यारंभ आदेश'" || item.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'" || item.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'" || item.Value == "a.[Kamachevav] as 'कामाचा वाव'" || item.Value == "a.[Pahanikramank] as 'पाहणी क्रमांक'" || item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'" || item.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर ' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'")
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
                        if (item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'")
                        {
                            unionquery += "sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'")
                        {
                            unionquery += "isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'")
                        {
                            unionquery += "sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक'")
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

                        //C P NS
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर ' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर '  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',";
                        }
                        //End CPNS
                        isSelected = true;
                    }
                    if (item.Value == "b.[DeyakachiSadyasthiti] as 'देयकाची सद्यस्थिती'" || item.Value == "b.[ManjurAmt] as 'मंजूर किंमत'" || item.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत'" || item.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'" || item.Value == "b.[Takunone] as 'प्रथम तिमाही तरतूद'" || item.Value == "b.[Takuntwo] as 'द्वितीय तिमाही तरतूद'" || item.Value == "b.[Takunthree] as 'तृतीय तिमाही तरतूद'" || item.Value == "b.[Takunfour] as 'चतुर्थ तिमाही तरतूद'" || item.Value == "b.[Tartud]as 'अर्थसंकल्पीय तरतूद'" || item.Value == "b.[AkunAnudan] as 'वितरित तरतूद'" || item.Value == "b.[Magilkharch] as 'मागील खर्च'" || item.Value == "b.[Chalukharch] as 'चालू खर्च'" || item.Value == "b.[Magni] as 'मागणी'" || item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'" || item.Value == "b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च'" || item.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'" || item.Value == "b.[Vidyutprama] as 'विद्युतीकरणावरील प्रमा'" || item.Value == "b.[Vidyutvitarit] as 'विद्युतीकरणावरील वितरित'" || item.Value == "b.[Itarkhrch] as 'इतर खर्च'" || item.Value == "b.[Dviguni] as 'दवगुनी ज्ञापने'" || item.Value == "b.[Apr] as 'Apr'" || item.Value == "b.[May] as 'May'" || item.Value == "b.[Jun] as 'Jun'" || item.Value == "b.[Jul] as 'Jul'" || item.Value == "b.[Aug] as 'Aug'" || item.Value == "b.[Sep] as 'Sep'" || item.Value == "b.[Oct] as 'Oct'" || item.Value == "b.[Nov] as 'Nov'" || item.Value == "b.[Dec] as 'Dec'" || item.Value == "b.[Jan] as 'Jan'" || item.Value == "b.[Feb] as 'Feb'" || item.Value == "b.[Mar] as 'Mar'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "b.[DeyakachiSadyasthiti] as 'देयकाची सद्यस्थिती'")
                        {
                            unionquery += "isNULL ('','') as 'देयकाची सद्यस्थिती',";
                        }
                        if (item.Value == "b.[ManjurAmt] as 'मंजूर किंमत'")
                        {
                            unionquery += "sum(b.[ManjurAmt])as 'मंजूर किंमत',";
                        }
                        if (item.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत'")
                        {
                            unionquery += "sum(b.[UrvaritAmt])as 'उर्वरित किंमत',";
                        }
                        if (item.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'")
                        {
                            unionquery += "sum(b.[MarchEndingExpn])as 'मार्च अखेर खर्च 2017',";
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
                        if (item.Value == "b.[Magilkharch] as 'मागील खर्च'")
                        {
                            unionquery += "sum(b.[Magilkharch])as 'मागील खर्च',";
                        }
                        if (item.Value == "b.[Chalukharch] as 'चालू खर्च'")
                        {
                            unionquery += "sum(b.[Chalukharch])as 'चालू खर्च',";
                        }
                        if (item.Value == "b.[Magni] as 'मागणी'")
                        {
                            unionquery += "sum(b.[Magni]) as 'मागणी',";
                        }
                        if (item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'")
                        {
                            unionquery += "sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',";
                        }
                        if (item.Value == "b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च'")
                        {
                            unionquery += "sum(b.[VarshbharatilKharch]) as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च',";
                        }
                        if (item.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'")
                        {
                            unionquery += "isNULL ('','') as 'मुदतवाढ बाबत',";
                        }
                        if (item.Value == "b.[Vidyutprama] as 'विद्युतीकरणावरील प्रमा'")
                        {
                            unionquery += "sum(b.[Vidyutprama]) as 'प्रमा',";
                        }
                        if (item.Value == "b.[Vidyutvitarit] as 'विद्युतीकरणावरील वितरित'")
                        {
                            unionquery += "sum(b.[Vidyutvitarit]) as 'वितरित',";
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
            dt = ObjBindGrid.BindGrid(year, lekha, ddl, value, ddlArthYear.Text, query, unionquery, "[BudgetMaster2515]", "[2515Provision]");
            Session["MasterBuildingReportSda"] = ObjBindGrid.SessionQuery;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Columns[1].Visible = false;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 120 ,true); </script>", false);
            Session["Master2515Rpt"] = GridView1;
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
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";

            BindGrid();
            // Loader();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString();
            //// ListMenu.Visible = false;


        }

        protected void btnupvibhag_Click(object sender, EventArgs e)
        {
            txtno.Text = "2";
            Session["ddl"] = "a.[upvibhag]=N";
            Session["ddlvalue"] = ddlUpvibhag.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "उपविभाग:-" + ddlUpvibhag.SelectedItem.ToString();
            //// ListMenu.Visible = false;
        }

        protected void btnjilha_Click(object sender, EventArgs e)
        {
            txtno.Text = "3";
            Session["ddl"] = "a.[Dist]=N";
            Session["ddlvalue"] = ddlJilha.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "जिल्हा:-" + ddlJilha.SelectedItem.ToString();
            //// ListMenu.Visible = false;
        }

        protected void btntaluka_Click(object sender, EventArgs e)
        {
            txtno.Text = "4";
            Session["ddl"] = "a.[Taluka]=N";
            Session["ddlvalue"] = ddlTaluka.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "तालुका:-" + ddlTaluka.SelectedItem.ToString();
            // ListMenu.Visible = false;
        }

        protected void btnworkid_Click(object sender, EventArgs e)
        {
            txtno.Text = "5";
            Session["ddl"] = "a.[WorkId]=N";
            Session["ddlvalue"] = ddlworkid.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "Work_ID:-" + ddlworkid.SelectedItem.ToString();
            // ListMenu.Visible = false;
        }

        protected void btnabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "6";
            Session["ddl"] = "a.[ShakhaAbhyantaName]=N";
            Session["ddlvalue"] = ddlShakhaAbhiyanta.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "शाखा अभियंता:-" + ddlShakhaAbhiyanta.SelectedItem.ToString();
            // ListMenu.Visible = false;
        }

        protected void btnupabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "7";
            Session["ddl"] = "a.[UpabhyantaName]=N";
            Session["ddlvalue"] = ddlShakhUpAbhiyanta.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "शाखा उपभियांता:-" + ddlShakhUpAbhiyanta.SelectedItem.ToString();
        }

        protected void btnamdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "8";
            Session["ddl"] = "a.[AmdaracheName]=N";
            Session["ddlvalue"] = ddlAmdar.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "आमदार:-" + ddlAmdar.SelectedItem.ToString();
            // ListMenu.Visible = false;
        }

        protected void btnkhasdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "9";
            Session["ddl"] = "a.[KhasdaracheName]=N";
            Session["ddlvalue"] = ddlKhasdar.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "खासदार:-" + ddlKhasdar.SelectedItem.ToString();
            // ListMenu.Visible = false;
        }

        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            txtno.Text = "10";
            Session["ddl"] = "a.[ThekedaarName]=N";
            Session["ddlvalue"] = ddlThekedarecheName.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "ठेकेदाराचे नाव:-" + ddlThekedarecheName.SelectedItem.ToString();
            // ListMenu.Visible = false;
        }

        protected void btnkamachistiti_Click(object sender, EventArgs e)
        {
            txtno.Text = "11";
            Session["ddl"] = "a.[Sadyasthiti]=N";
            Session["ddlvalue"] = ddlKamachiSadyStiti.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "कामाची सद्यस्थिती:-" + ddlKamachiSadyStiti.SelectedItem.ToString();
            // ListMenu.Visible = false;
        }
        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            txtno.Text = "12";
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";
            BindGrid();
            Label3.Text = "कामाचे वर्ष " + ddlKamacheyear.Text.Split('-')[0];
            // ListMenu.Visible = false;

        }
        protected void chkBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindReport();
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
            Response.AddHeader("content-disposition", "attachment; filename=Master2515Report.xls");
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

            Session["filename"] = "Master2515Report.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "Master2515Report.xls");
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
        int tempcounter = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridView1.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=14&PrevPage=Master2515Report.aspx";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                string[] HeadrName = new string[e.Row.Cells.Count];
                for (int RowHeader_Index = 0; RowHeader_Index < e.Row.Cells.Count; RowHeader_Index++)
                {


                    HeadrName[RowHeader_Index] = e.Row.Cells[RowHeader_Index].Text;

                }
                grand2515total.index(HeadrName);


            }



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                RowCount++;
                // do your stuffs here, for example if column risk is your third column:
                if (e.Row.Cells[grand2515total.Total_index].Text == "Total")
                {
                    e.Row.Cells[grand2515total.Total_index - 1].Text = (RowCount - 1).ToString();
                    TotalWork += RowCount - 1;
                    RowCount = 0;
                    e.Row.Cells[grand2515total.Total_index + 1].Text = "";
                    e.Row.Cells[grand2515total.Total_index + 5].Text = "";
                    e.Row.Cells[grand2515total.Total_index - 2].Text = "";

                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.Row.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {

                        grand2515total.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.Row.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        grand2515total.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.Row.Table.Columns["वितरित तरतूद"] != null)
                    {
                        grand2515total.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.Row.Table.Columns["चालू खर्च"] != null)
                    {
                        grand2515total.ExpUp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.Row.Table.Columns["मागील खर्च"] != null)
                    {
                        grand2515total.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.Row.Table.Columns["मागणी"] != null)
                    {
                        grand2515total.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.Row.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        grand2515total.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.Row.Table.Columns["सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च"] != null)
                    {
                        grand2515total.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च"));
                    }
                    if (data.Row.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        grand2515total.VidyutikarnPrama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.Row.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        grand2515total.Vidyutikarnvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.Row.Table.Columns["इतर खर्च"] != null)
                    {
                        grand2515total.OtherExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }

                    //New Column
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {

                        grand2515total.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {

                        grand2515total.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    //End new Column

                    //cpns
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        grand2515total.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        grand2515total.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        grand2515total.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        grand2515total.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        grand2515total.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    //End CPNS
					

                    if (data.Row.Table.Columns["Apr"] != null)
                    {
                        grand2515total.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.Row.Table.Columns["May"] != null)
                    {
                        grand2515total.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.Row.Table.Columns["Jun"] != null)
                    {
                        grand2515total.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.Row.Table.Columns["Jul"] != null)
                    {
                        grand2515total.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.Row.Table.Columns["Aug"] != null)
                    {
                        grand2515total.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.Row.Table.Columns["Sep"] != null)
                    {
                        grand2515total.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.Row.Table.Columns["Oct"] != null)
                    {
                        grand2515total.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.Row.Table.Columns["Nov"] != null)
                    {
                        grand2515total.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.Row.Table.Columns["Dec"] != null)
                    {
                        grand2515total.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.Row.Table.Columns["Jan"] != null)
                    {
                        grand2515total.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.Row.Table.Columns["Feb"] != null)
                    {
                        grand2515total.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.Row.Table.Columns["Mar"] != null)
                    {
                        grand2515total.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mar"));
                    }

                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        grand2515total.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        grand2515total.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        grand2515total.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        grand2515total.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }

                    if (data.DataView.Table.Columns["मंजूर किंमत"] != null)
                    {
                        grand2515total.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर किंमत"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        grand2515total.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                        //int index1111 = data.DataView.Table.Columns["उर्वरित किंमत"].Ordinal; we need to + 4 for index number
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        grand2515total.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[grand2515total.Total_index - 1].Text = "No Of Work: " + TotalWork.ToString();
                e.Row.Cells[grand2515total.Total_index].Text = "Grand Total";
                e.Row.Cells[grand2515total.MarchAkher_Index].Text = grand2515total.MarchAkher.ToString();
                e.Row.Cells[grand2515total.ArthsankalpTartud_Index].Text = grand2515total.ArthsankalpTartud.ToString();
                e.Row.Cells[grand2515total.VitritTartud_Index].Text = grand2515total.VitritTartud.ToString();
                e.Row.Cells[grand2515total.ExpUp_Index].Text = grand2515total.ExpUp.ToString();
                e.Row.Cells[grand2515total.Magilkharch_index].Text = grand2515total.Magilkharch.ToString();

                e.Row.Cells[grand2515total.Magni_Index].Text = grand2515total.Magni.ToString();
                e.Row.Cells[grand2515total.EkunKamavarilKharch_Index].Text = grand2515total.EkunKamavarilKharch.ToString();
                e.Row.Cells[grand2515total.YearExp_Index].Text = grand2515total.YearExp.ToString();
                e.Row.Cells[grand2515total.VidyutikarnPrama_Index].Text = grand2515total.VidyutikarnPrama.ToString();
                e.Row.Cells[grand2515total.Vidyutikarnvitarit_Index].Text = grand2515total.Vidyutikarnvitarit.ToString();
                e.Row.Cells[grand2515total.OtherExp_Index].Text = grand2515total.OtherExp.ToString();

                //New Column
                e.Row.Cells[grand2515total.PrashaskiyAmt_index].Text = grand2515total.PrashaskiyAmt.ToString();
                e.Row.Cells[grand2515total.TantrikAmt_index].Text = grand2515total.TantrikAmt.ToString();
                //End New Column
                //CPNS
                e.Row.Cells[grand2515total.C_index].Text = grand2515total.C.ToString();
                e.Row.Cells[grand2515total.P_index].Text = grand2515total.P.ToString();
                e.Row.Cells[grand2515total.NS_index].Text = grand2515total.NS.ToString();
                e.Row.Cells[grand2515total.ES_index].Text = grand2515total.ES.ToString();
                e.Row.Cells[grand2515total.TS_index].Text = grand2515total.TS.ToString();
                //End CPNS
                e.Row.Cells[grand2515total.Apr_index].Text = grand2515total.Apr.ToString();
                e.Row.Cells[grand2515total.May_index].Text = grand2515total.May.ToString();
                e.Row.Cells[grand2515total.Jun_index].Text = grand2515total.Jun.ToString();
                e.Row.Cells[grand2515total.Jul_index].Text = grand2515total.Jul.ToString();
                e.Row.Cells[grand2515total.Aug_index].Text = grand2515total.Aug.ToString();
                e.Row.Cells[grand2515total.sep_index].Text = grand2515total.sep.ToString();
                e.Row.Cells[grand2515total.Oct_index].Text = grand2515total.Oct.ToString();
                e.Row.Cells[grand2515total.Nov_index].Text = grand2515total.Nov.ToString();
                e.Row.Cells[grand2515total.Dec_index].Text = grand2515total.Dec.ToString();
                e.Row.Cells[grand2515total.Jan_index].Text = grand2515total.Jan.ToString();
                e.Row.Cells[grand2515total.Feb_index].Text = grand2515total.Feb.ToString();
                e.Row.Cells[grand2515total.Mar_index].Text = grand2515total.Mar.ToString();

                e.Row.Cells[grand2515total.Takunone_index].Text = grand2515total.Takunone.ToString();
                e.Row.Cells[grand2515total.Takuntwo_index].Text = grand2515total.Takuntwo.ToString();
                e.Row.Cells[grand2515total.TisriTartud_index].Text = grand2515total.TisriTartud.ToString();
                e.Row.Cells[grand2515total.ChothiTartud_index].Text = grand2515total.ChothiTartud.ToString();
                e.Row.Cells[grand2515total.UrvaritAmt_index].Text = grand2515total.UrvaritAmt.ToString();
                e.Row.Cells[grand2515total.ManjurAmt_index].Text = grand2515total.ManjurAmt.ToString();
                e.Row.Cells[grand2515total.NividaRakkam_index].Text = grand2515total.NividaRakkam.ToString();

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
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pName = GridView1.DataKeys[e.NewEditIndex].Values["वर्क आयडी"].ToString();
            Response.Redirect("MasterBudget2515.aspx?WorkID=" + pName + "");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            pName = GridView1.DataKeys[e.NewSelectedIndex].Values["वर्क आयडी"].ToString();
            Response.Redirect("Send_sms.aspx?WorkID=" + pName + "");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx", false);
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterBuildingReportSda"].ToString(), con);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                    GridView1.Columns[1].Visible = true;

                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 120 ,true); </script>", false);
                }
                else
                {
                    myBtn2.Checked = false;
                    //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterBuildingReportSda"].ToString(), con);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    GridViewRow row = GridView1.Rows[0];
                    GridView1.Columns[1].Visible = false;
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
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 120 ,true); </script>", false);
                }
            }
            else
            {
                myBtn2.Checked = false;
                //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterBuildingReportSda"].ToString(), con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                GridViewRow row = GridView1.Rows[0];
                GridView1.Columns[1].Visible = false;
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
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 120 ,true); </script>", false);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string WorkId = e.Keys["वर्क आयडी"].ToString();
            strSqlCommand = "Delete From [BudgetMaster2515] Where [WorkId]='" + WorkId + "'";
            strSqlCommand1 = "Delete From [2515Provision] Where [WorkId]='" + WorkId + "'";
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
                BindReport();
                GridView1.Columns[1].Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deletion Failed')", true);
                BindReport();
                GridView1.Columns[1].Visible = true;
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 120 ,true); </script>", false);
            con.Close();
        }

        public void GraphicsReport(string WhereCondition)
        {
            string[] arr1 = { "Completed", "Incomplete", "Inprogress", "Tender Stage", "Estimated Stage", "Not Started", "Estimated Cost", "T.S Cost", "Budget Provision", "Expenditure" };

            objGraph.GraphicsReports("[BudgetMaster2515]", "[2515Provision]", WhereCondition);

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








