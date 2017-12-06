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
    public partial class MasterDPDCReport : System.Web.UI.Page
    {
        string pName;
        string strSqlCommand = string.Empty;
        string strSqlCommand1 = string.Empty;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2 = null;
        string strSqlCommand2 = String.Empty;
        int RowCount = 0, TotalWork = 0;
        DpdcGrandTotal dpdcgrandtotal = new DpdcGrandTotal();
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

                    foreach (var item in chkBuilding.Items.Cast<ListItem>().Where(li => li.Value == "a.[WorkId] as 'वर्क आयडी'" || li.Value == "a.[LekhaShirshName] as 'योजनेचे नाव'" || li.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'" || li.Value == "a.[KamacheName] as 'योजनेचे / कामाचे नांव'" || li.Value == "a.[Upvibhag] as 'उपविभाग'" || li.Value == "a.[Taluka] as 'तालुका'" || li.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || li.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || li.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक'" || li.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || li.Value == "a.[karyarambhadesh] as 'कार्यारंभ आदेश'" || li.Value == "a.[Kamachevav] as 'कामाचा वाव'" || li.Value == "a.[KamPurnDate] as 'काम पूर्ण होण्याचा अपेक्षित दिनांक'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'पुर्ण'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'प्रगतीत'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'निविदा स्तर'" || li.Value == "a.[Shera] as 'शेरा'" || li.Value == "b.[ManjurAmt] as 'एकूण अंदाजित किंमत (अलिकडील सुधारित)'" || li.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'" || li.Value == "b.[UrvaritAmt] as 'सन 2017-2018 मधील अपेक्षित खर्च'" || li.Value == "b.[Tartud] as '2017-2018 करीता प्रस्तावित तरतूद'" || li.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'"))
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
                if (previousPageName == "MasterBudgetDPDC.aspx" || previousPageName == "Send_sms.aspx" || previousPageName == "UploadImage.aspx")
                {
                    if (Session["MasterDPDCRpt"] != null)
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterDPDCReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterDPDCReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterDPDCReportSda"];
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

        public void ArthsankalpiyYear()
        {
            ddlArthYear.Items.Clear();
            ddlArthYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from DPDCProvision Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from BudgetMasterDPDC Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select [LekhaShirshName] from BudgetMasterDPDC where [Arthsankalpiyyear]='" + ddlKamacheyear.SelectedItem.ToString() + "' Group By(LekhaShirshName)", con);
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
            if ((dt = (ObjsqlQueryOrCon.Bind_MasterReport_ddl("[BudgetMasterDPDC]", ddlLekhashirsh.SelectedItem.ToString()))).Rows.Count > 0)
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
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear], a.[Upvibhag] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka]desc) as 'SrNo', ";
            unionquery = "union select isNULL ('','')as'SrNo', ";
            isSelected = chkBuilding.Items.Cast<ListItem>().Count(i => i.Selected == true) > 0;
            if (!isSelected)
            {
                chkBuilding.Items[0].Selected = true;
            }
            foreach (ListItem item in chkBuilding.Items)
            {
                if (item.Selected)
                {
                    if (item.Value == "a.[WorkId] as 'वर्क आयडी'" || item.Value == "a.[LekhaShirshName] as 'योजनेचे नाव'" || item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'" || item.Value == "a.[KamacheName] as 'योजनेचे / कामाचे नांव'" || item.Value == "a.[SubType] as 'विभाग'" || item.Value == "a.[Upvibhag] as 'उपविभाग'" || item.Value == "a.[Taluka] as 'तालुका'" || item.Value == "a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब'" || item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव'" || item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव'" || item.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'" || item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'" || item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक'" || item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || item.Value == "a.[karyarambhadesh] as 'कार्यारंभ आदेश'" || item.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'" || item.Value == "a.[Kamachevav] as 'कामाचा वाव'" || item.Value == "convert(nvarchar(max),a.[NividaAmt])+' '+convert(nvarchar(max),b.[MudatVadhiDate]) as 'सुधारित अंदाजित किंमतीचा दिनांक'" || item.Value == "a.[KamPurnDate] as 'काम पूर्ण होण्याचा अपेक्षित दिनांक'" || item.Value == "CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN '0.00' END as nvarchar(max)) as 'मागणी 2017-2018'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'" || item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'" || item.Value == "CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN '1' END as nvarchar(max)) as 'एकूण कामे'" || item.Value == "a.[Shera] as 'शेरा'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "a.[WorkId] as 'वर्क आयडी'")
                        {
                            unionquery += " 'Total' as 'वर्क आयडी',";
                        }
                        if (item.Value == "a.[LekhaShirshName] as 'योजनेचे नाव'")
                        {
                            unionquery += " isNULL ('','') as 'योजनेचे नाव',";
                        }
                        if (item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'")
                        {
                            unionquery += "isNULL (a.[Arthsankalpiyyear],'') as 'अर्थसंकल्पीय वर्ष',";
                        }
                        if (item.Value == "a.[KamacheName] as 'योजनेचे / कामाचे नांव'")
                        {
                            unionquery += "isNULL ('','') as 'योजनेचे / कामाचे नांव',";
                        }
                        if (item.Value == "a.[SubType] as 'विभाग'")
                        {
                            unionquery += "isNULL ('','') as 'विभाग',";
                        }
                        if (item.Value == "a.[Upvibhag] as 'उपविभाग'")
                        {
                            unionquery += " isNULL (a.[Upvibhag],'') as 'उपविभाग',";
                        }
                        if (item.Value == "a.[Taluka] as 'तालुका'")
                        {
                            unionquery += " isNULL ('','') as 'तालुका',";
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
	
                        if (item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'")
                        {
                            unionquery += " isNULL ('','')as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'")
                        {
                            unionquery += " isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',";
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
                        if (item.Value == "convert(nvarchar(max),a.[NividaAmt])+' '+convert(nvarchar(max),b.[MudatVadhiDate]) as 'सुधारित अंदाजित किंमतीचा दिनांक'")
                        {
                            unionquery += " isNULL ('','') as 'सुधारित अंदाजित किंमतीचा दिनांक',";
                        }
                        if (item.Value == "a.[KamPurnDate] as 'काम पूर्ण होण्याचा अपेक्षित दिनांक'")
                        {
                            unionquery += " isNULL ('','') as 'काम पूर्ण होण्याचा अपेक्षित दिनांक',";
                        }
                        if (item.Value == "a.[Kamachevav] as 'कामाचा वाव'")
                        {
                            unionquery += "isNULL ('','') as 'कामाचा वाव',";
                        }

                        if (item.Value == "CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN '0.00' END as nvarchar(max)) as 'मागणी 2017-2018'")
                        {
                            unionquery += " isNULL ('','')  as 'मागणी 2017-2018',";
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
                        
                        if (item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'")
                        {
                            unionquery += "isNULL ('','') as 'पाहणीमुद्ये',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN '1' END as nvarchar(max)) as 'एकूण कामे'")
                        {
                            unionquery += "isNULL ('','') as 'एकूण कामे',";
                        }
                        if (item.Value == "a.[Shera] as 'शेरा'")
                        {
                            unionquery += " isNULL ('','') as 'शेरा',";
                        }
                        isSelected = true;
                    }
                    if (item.Value == "b.[ComputerCRC] as 'सीआरसी (संगणक) संकेतांक'" || item.Value == "b.[ObjectCode] as 'उद्यीष्ट संकेतांक(ऑब्जेक्ट कोड)'" || item.Value == "b.[DeyakachiSadyasthiti] as 'देयकाची सद्यस्थिती'" || item.Value == "b.[ManjurAmt] as 'एकूण अंदाजित किंमत (अलिकडील सुधारित)'" || item.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'" || item.Value == "b.[UrvaritAmt] as 'सन 2017-2018 मधील अपेक्षित खर्च'" || item.Value == "b.[Takunone] as 'उर्वरित किंमत (6-(8+9))'" || item.Value == "b.[Takuntwo] as 'द्वितीय तिमाही तरतूद'" || item.Value == "b.[Takunthree] as 'तृतीय तिमाही तरतूद'" || item.Value == "b.[Takunfour] as 'चतुर्थ तिमाही तरतूद'" || item.Value == "b.[Tartud] as '2017-2018 करीता प्रस्तावित तरतूद'" || item.Value == "b.[AkunAnudan] as 'वितरित तरतूद'" || item.Value == "b.[Tartud]as 'काम निहाय तरतूद सन 2017-2018'" || item.Value == "b.[Jun] as 'वितरीत तरतूद सन 2017-2018'" || item.Value == "b.[Magilkharch] as 'मागील खर्च'" || item.Value == "b.[Chalukharch] as 'चालू खर्च'" || item.Value == "b.[Magni] as 'मागणी 2017-2018'" || item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'" || item.Value == "b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च'" || item.Value == "b.[Vidyutprama] as 'विद्युतीकरणावरील प्रमा'" || item.Value == "b.[Vidyutvitarit] as 'विद्युतीकरणावरील वितरित'" || item.Value == "b.[Itarkhrch] as 'इतर खर्च'" || item.Value == "b.[Dviguni] as 'दवगुनी ज्ञापने'" || item.Value == "b.[Apr] as 'Apr'" || item.Value == "b.[May] as 'May'" || item.Value == "b.[Jun] as 'Jun'" || item.Value == "b.[Jul] as 'Jul'" || item.Value == "b.[Aug] as 'Aug'" || item.Value == "b.[Sep] as 'Sep'" || item.Value == "b.[Oct] as 'Oct'" || item.Value == "b.[Nov] as 'Nov'" || item.Value == "b.[Dec] as 'Dec'" || item.Value == "b.[Jan] as 'Jan'" || item.Value == "b.[Feb] as 'Feb'" || item.Value == "b.[Mar] as 'Mar'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "b.[ComputerCRC] as 'सीआरसी (संगणक) संकेतांक'")
                        {
                            unionquery += "isNULL ('','') as 'सीआरसी (संगणक) संकेतांक',";
                        }
                        if (item.Value == "b.[ObjectCode] as 'उद्यीष्ट संकेतांक(ऑब्जेक्ट कोड)'")
                        {
                            unionquery += "isNULL ('','') as 'उद्यीष्ट संकेतांक(ऑब्जेक्ट कोड)',";
                        }
                        if (item.Value == "b.[DeyakachiSadyasthiti] as 'देयकाची सद्यस्थिती'")
                        {
                            unionquery += "isNULL ('','') as 'देयकाची सद्यस्थिती',";
                        }
                        if (item.Value == "b.[ManjurAmt] as 'एकूण अंदाजित किंमत (अलिकडील सुधारित)'")
                        {
                            unionquery += "sum(b.[ManjurAmt]) as 'एकूण अंदाजित किंमत (अलिकडील सुधारित)',";
                        }
                        if (item.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'")
                        {
                            unionquery += "sum(b.[MarchEndingExpn]) as 'मार्च अखेर खर्च 2017',";
                        }
                        if (item.Value == "b.[UrvaritAmt] as 'सन 2017-2018 मधील अपेक्षित खर्च'")
                        {
                            unionquery += " sum(b.[UrvaritAmt]) as 'सन 2017-2018 मधील अपेक्षित खर्च',";
                        }
                        if (item.Value == "b.[Takunone] as 'उर्वरित किंमत (6-(8+9))'")
                        {
                            unionquery += "sum(b.[Takunone]) as 'उर्वरित किंमत (6-(8+9))',";
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
                        if (item.Value == "b.[Tartud] as '2017-2018 करीता प्रस्तावित तरतूद'")
                        {
                            unionquery += " sum(b.[Tartud]) as '2017-2018 करीता प्रस्तावित तरतूद',";
                        }
                        if (item.Value == "b.[Tartud]as 'काम निहाय तरतूद सन 2017-2018'")
                        {
                            unionquery += " sum(b.[Tartud]) as 'काम निहाय तरतूद सन 2017-2018',";
                        }
                        if (item.Value == "b.[AkunAnudan] as 'वितरित तरतूद'")
                        {
                            unionquery += "sum(b.[AkunAnudan]) as 'वितरित तरतूद',";
                        }
                        if (item.Value == "b.[Jun] as 'वितरीत तरतूद सन 2017-2018'")
                        {
                            unionquery += "sum(b.[Jun]) as 'वितरीत तरतूद सन 2017-2018',";
                        }
                        if (item.Value == "b.[Magilkharch] as 'मागील खर्च'")
                        {
                            unionquery += " sum(b.[Magilkharch]) as 'मागील खर्च',";
                        }
                        if (item.Value == "b.[Chalukharch] as 'चालू खर्च'")
                        {
                            unionquery += "sum(b.[Chalukharch])as 'चालू खर्च',";
                        }
                        if (item.Value == "b.[Magni] as 'मागणी 2017-2018'")
                        {
                            unionquery += " sum(b.[Magni]) as 'मागणी 2017-2018',";
                        }
                        if (item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'")
                        {
                            unionquery += "sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',";
                        }
                        if (item.Value == "b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च'")
                        {
                            unionquery += "sum(b.[VarshbharatilKharch]) as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च',";
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
            dt = ObjBindGrid.BindGrid(year, lekha, ddl, value, ddlArthYear.Text, query, unionquery, "BudgetMasterDPDC", "DPDCProvision");
            Session["MasterDPDCReportSda"] = ObjBindGrid.SessionQuery;
            // da.Fill(dt);
            GridView1.DataSource = dt;

            GridView1.DataBind();
            GridView1.Columns[1].Visible = false;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            Session["MasterDPDCRpt"] = GridView1;
            ListMenu.Style.Add("display", "none");
            GraphicsReport(ObjBindGrid.WhereCondition);
        }

        protected void btnlekhashirsh_Click(object sender, EventArgs e)
        {

            txtno.Text = "1";
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";
            BindGrid();
            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString();
        }

        protected void btnupvibhag_Click(object sender, EventArgs e)
        {
            txtno.Text = "2";
            Session["ddl"] = "a.[upvibhag]=N";
            Session["ddlvalue"] = ddlUpvibhag.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "उपविभाग:-" + ddlUpvibhag.SelectedItem.ToString();
        }

        protected void btnjilha_Click(object sender, EventArgs e)
        {
            txtno.Text = "3";
            Session["ddl"] = "a.[Dist]=N";
            Session["ddlvalue"] = ddlJilha.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "जिल्हा:-" + ddlJilha.SelectedItem.ToString();
        }

        protected void btntaluka_Click(object sender, EventArgs e)
        {
            txtno.Text = "4";
            Session["ddl"] = "a.[Taluka]=N";
            Session["ddlvalue"] = ddlTaluka.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "तालुका:-" + ddlTaluka.SelectedItem.ToString();
        }

        protected void btnworkid_Click(object sender, EventArgs e)
        {
            txtno.Text = "5";
            Session["ddl"] = "a.[WorkId]=N";
            Session["ddlvalue"] = ddlworkid.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "Work_ID:-" + ddlworkid.SelectedItem.ToString();
        }

        protected void btnabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "6";
            Session["ddl"] = "a.[ShakhaAbhyantaName]=N";
            Session["ddlvalue"] = ddlShakhaAbhiyanta.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "शाखा अभियंता:-" + ddlShakhaAbhiyanta.SelectedItem.ToString();
        }

        protected void btnupabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "7";
            Session["ddl"] = "a.[UpabhyantaName]=N";
            Session["ddlvalue"] = ddlShakhUpAbhiyanta.Text;
            BindGrid();

            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "शाखा उपभियांता:-" + ddlShakhUpAbhiyanta.SelectedItem.ToString();
        }

        protected void btnamdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "8";
            Session["ddl"] = "a.[AmdaracheName]=N";
            Session["ddlvalue"] = ddlAmdar.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "आमदार:-" + ddlAmdar.SelectedItem.ToString();
        }

        protected void btnkhasdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "9";
            Session["ddl"] = "a.[KhasdaracheName]=N";
            Session["ddlvalue"] = ddlKhasdar.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "खासदार:-" + ddlKhasdar.SelectedItem.ToString();
        }

        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            txtno.Text = "10";
            Session["ddl"] = "a.[ThekedaarName]=N";
            Session["ddlvalue"] = ddlThekedarecheName.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "ठेकेदाराचे नाव:-" + ddlThekedarecheName.SelectedItem.ToString();
        }

        protected void btnkamachistiti_Click(object sender, EventArgs e)
        {
            txtno.Text = "11";
            Session["ddl"] = "a.[Sadyasthiti]=N";
            Session["ddlvalue"] = ddlKamachiSadyStiti.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "कामाची सद्यस्थिती:-" + ddlKamachiSadyStiti.SelectedItem.ToString();
        }

        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            txtno.Text = "12";
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";
            BindGrid();
            Label3.Text = "कामाचे वर्ष :- " + ddlKamacheyear.Text.Split('-')[0];
        }

        protected void chkBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MasterDPDCReport.xls");
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

            Session["filename"] = "MasterDPDCReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "MasterDPDCReport.xls");
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
            // for Image Upload
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridView1.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=4&PrevPage=MasterDPDCReport.aspx";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                string[] HeadrName = new string[e.Row.Cells.Count];
                for (int RowHeader_Index = 0; RowHeader_Index < e.Row.Cells.Count; RowHeader_Index++)
                {


                    HeadrName[RowHeader_Index] = e.Row.Cells[RowHeader_Index].Text;
                    //dt_index[i] = e.Row.Cells[i].Text;
                    //if (e.Row.Cells[i].Text == "AA cost Rs in lakhs")
                    //{
                    //    //e.Row.Cells[i].Text = "Finded";
                    //}
                }
                dpdcgrandtotal.index(HeadrName);


            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RowCount++;
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column Total is your third column:
                // e.Row.Cells[3].BackColor = System.Drawing.Color.Pink;
                if (e.Row.Cells[dpdcgrandtotal.Total_index].Text == "Total")
                {

                    e.Row.Cells[dpdcgrandtotal.Total_index - 1].Text = (RowCount - 1).ToString();
                    TotalWork += RowCount - 1;
                    RowCount = 0;
                    e.Row.Cells[dpdcgrandtotal.Total_index + 4].Text = "";
                    e.Row.Cells[dpdcgrandtotal.Total_index + 7].Text = "";
                    e.Row.Cells[dpdcgrandtotal.Total_index - 2].Text = "";
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    if (data.DataView.Table.Columns["एकूण अंदाजित किंमत (अलिकडील सुधारित)"] != null)
                    {
                        dpdcgrandtotal.AkunAndajit += Convert.ToDecimal(e.Row.Cells[dpdcgrandtotal.AkunAndajit_index].Text);
                        // dpdcgrandtotal.AkunAndajit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकूण अंदाजित किंमत (अलिकडील सुधारित)"));
                    }

                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017 "] != null)
                    {
                        dpdcgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017 "));
                    }
                    if (data.DataView.Table.Columns["सन 2017-2018 मधील अपेक्षित खर्च"] != null)
                    {
                        dpdcgrandtotal.SanMadil += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-2018 मधील अपेक्षित खर्च"));
                    }

                    if (data.DataView.Table.Columns["उर्वरित किंमत (6-(8+9))"] != null)
                    {
                        dpdcgrandtotal.UrvritKimmat += Convert.ToDecimal(e.Row.Cells[dpdcgrandtotal.UrvritKimmat_index].Text);
                        //dpdcgrandtotal.UrvritKimmat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत (6-(8+9))"));

                    }
                    if (data.DataView.Table.Columns["2017-2018 करीता प्रस्तावित तरतूद"] != null)
                    {
                        dpdcgrandtotal.KaritaPrasta += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-2018 करीता प्रस्तावित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["काम निहाय तरतूद सन 2017-2018"] != null)
                    {
                        dpdcgrandtotal.KamNihay += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "काम निहाय तरतूद सन 2017-2018"));
                    }
                    if (data.DataView.Table.Columns["वितरीत तरतूद सन 2017-2018"] != null)
                    {
                        dpdcgrandtotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरीत तरतूद सन 2017-2018"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        dpdcgrandtotal.KharchSan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी 2017-2018"] != null)
                    {
                        dpdcgrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी 2017-2018"));
                    }
                    if (data.DataView.Table.Columns["पुर्ण"] != null)
                    {
                        dpdcgrandtotal.Purn += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "पुर्ण"));
                    }
                    if (data.DataView.Table.Columns["प्रगतीत"] != null)
                    {
                        dpdcgrandtotal.Pragatit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रगतीत"));
                    }
                    if (data.DataView.Table.Columns["निविदा स्तर"] != null)
                    {
                        dpdcgrandtotal.NividaStar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा स्तर"));
                    }

                    //New Column
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {

                        dpdcgrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {

                        dpdcgrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    //End new Column
                    //CPNS
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        dpdcgrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        dpdcgrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        dpdcgrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        dpdcgrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        dpdcgrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    //End CPNS
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        dpdcgrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        dpdcgrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        dpdcgrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        dpdcgrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        dpdcgrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        dpdcgrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        dpdcgrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        dpdcgrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        dpdcgrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        dpdcgrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        dpdcgrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        dpdcgrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mar"));
                    }


                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        dpdcgrandtotal.DusriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        dpdcgrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        dpdcgrandtotal.chothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }

                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        dpdcgrandtotal.VitritTar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        dpdcgrandtotal.ExpUp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        dpdcgrandtotal.AkunKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        dpdcgrandtotal.VarshKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        dpdcgrandtotal.VidyuatPram += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        dpdcgrandtotal.VidyutVitrit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        dpdcgrandtotal.Itarkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        dpdcgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[dpdcgrandtotal.Total_index - 1].Text = "No Of Work: " + TotalWork.ToString();
                e.Row.Cells[dpdcgrandtotal.Total_index].Text = "Grand Total";

                e.Row.Cells[dpdcgrandtotal.AkunAndajit_index].Text = dpdcgrandtotal.AkunAndajit.ToString();
                e.Row.Cells[dpdcgrandtotal.MarchAkher_index].Text = dpdcgrandtotal.MarchAkher.ToString();
                e.Row.Cells[dpdcgrandtotal.SanMadil_index].Text = dpdcgrandtotal.SanMadil.ToString();
                e.Row.Cells[dpdcgrandtotal.UrvritKimmat_index].Text = dpdcgrandtotal.UrvritKimmat.ToString();
                e.Row.Cells[dpdcgrandtotal.KaritaPrasta_index].Text = dpdcgrandtotal.KaritaPrasta.ToString();
                e.Row.Cells[dpdcgrandtotal.KamNihay_index].Text = dpdcgrandtotal.KamNihay.ToString();
                e.Row.Cells[dpdcgrandtotal.VitritTartud_index].Text = dpdcgrandtotal.VitritTartud.ToString();
                e.Row.Cells[dpdcgrandtotal.KharchSan_index].Text = dpdcgrandtotal.KharchSan.ToString();
                e.Row.Cells[dpdcgrandtotal.Magni_index].Text = dpdcgrandtotal.Magni.ToString();
                e.Row.Cells[dpdcgrandtotal.Purn_index].Text = dpdcgrandtotal.Purn.ToString();
                e.Row.Cells[dpdcgrandtotal.Pragatit_index].Text = dpdcgrandtotal.Pragatit.ToString();
                e.Row.Cells[dpdcgrandtotal.NividaStar_index].Text = dpdcgrandtotal.NividaStar.ToString();

                //New Column
                e.Row.Cells[dpdcgrandtotal.PrashaskiyAmt_index].Text = dpdcgrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[dpdcgrandtotal.TantrikAmt_index].Text = dpdcgrandtotal.TantrikAmt.ToString();
                //End New Column
                //CPNS
                e.Row.Cells[dpdcgrandtotal.C_index].Text = dpdcgrandtotal.C.ToString();
                e.Row.Cells[dpdcgrandtotal.P_index].Text = dpdcgrandtotal.P.ToString();
                e.Row.Cells[dpdcgrandtotal.NS_index].Text = dpdcgrandtotal.NS.ToString();
                e.Row.Cells[dpdcgrandtotal.ES_index].Text = dpdcgrandtotal.ES.ToString();
                e.Row.Cells[dpdcgrandtotal.TS_index].Text = dpdcgrandtotal.TS.ToString();
                //End CPNS
                e.Row.Cells[dpdcgrandtotal.Apr_index].Text = dpdcgrandtotal.Apr.ToString();
                e.Row.Cells[dpdcgrandtotal.May_index].Text = dpdcgrandtotal.May.ToString();
                e.Row.Cells[dpdcgrandtotal.Jun_index].Text = dpdcgrandtotal.Jun.ToString();
                e.Row.Cells[dpdcgrandtotal.Jul_index].Text = dpdcgrandtotal.Jul.ToString();
                e.Row.Cells[dpdcgrandtotal.Aug_index].Text = dpdcgrandtotal.Aug.ToString();
                e.Row.Cells[dpdcgrandtotal.sep_index].Text = dpdcgrandtotal.sep.ToString();
                e.Row.Cells[dpdcgrandtotal.Oct_index].Text = dpdcgrandtotal.Oct.ToString();
                e.Row.Cells[dpdcgrandtotal.Nov_index].Text = dpdcgrandtotal.Nov.ToString();
                e.Row.Cells[dpdcgrandtotal.Dec_index].Text = dpdcgrandtotal.Dec.ToString();
                e.Row.Cells[dpdcgrandtotal.Jan_index].Text = dpdcgrandtotal.Jan.ToString();
                e.Row.Cells[dpdcgrandtotal.Feb_index].Text = dpdcgrandtotal.Feb.ToString();
                e.Row.Cells[dpdcgrandtotal.Mar_index].Text = dpdcgrandtotal.Mar.ToString();

                e.Row.Cells[dpdcgrandtotal.DusriTartud_index].Text = dpdcgrandtotal.DusriTartud.ToString();
                e.Row.Cells[dpdcgrandtotal.TisriTartud_index].Text = dpdcgrandtotal.TisriTartud.ToString();
                e.Row.Cells[dpdcgrandtotal.chothiTartud_index].Text = dpdcgrandtotal.chothiTartud.ToString();
                e.Row.Cells[dpdcgrandtotal.VitritTar_index].Text = dpdcgrandtotal.VitritTar.ToString();
                e.Row.Cells[dpdcgrandtotal.ExpUp_index].Text = dpdcgrandtotal.ExpUp.ToString();
                e.Row.Cells[dpdcgrandtotal.AkunKharch_index].Text = dpdcgrandtotal.AkunKharch.ToString();
                e.Row.Cells[dpdcgrandtotal.VarshKharch_index].Text = dpdcgrandtotal.VarshKharch.ToString();
                e.Row.Cells[dpdcgrandtotal.VidyuatPram_index].Text = dpdcgrandtotal.VidyuatPram.ToString();
                e.Row.Cells[dpdcgrandtotal.VidyutVitrit_index].Text = dpdcgrandtotal.VidyutVitrit.ToString();
                e.Row.Cells[dpdcgrandtotal.Itarkharch_index].Text = dpdcgrandtotal.Itarkharch.ToString();
                e.Row.Cells[dpdcgrandtotal.NividaRakkam_index].Text = dpdcgrandtotal.NividaRakkam.ToString();
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

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            pName = GridView1.DataKeys[e.NewSelectedIndex].Values["वर्क आयडी"].ToString();
            Response.Redirect("Send_sms.aspx?WorkID=" + pName + "");
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pName = GridView1.DataKeys[e.NewEditIndex].Values["वर्क आयडी"].ToString();
            Response.Redirect("MasterBudgetDPDC.aspx?WorkID=" + pName + "");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }
        protected void ddlKamacheyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lekhashirsh();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (myBtn2.Checked == true)
            {
                if (txtpassword.Text == "PwdPuneEast")
                {
                    //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterDPDCReportSda"].ToString(), con);
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterDPDCReportSda"].ToString(), con);
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
                SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterDPDCReportSda"].ToString(), con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Columns[1].Visible = false;

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string WorkId = e.Keys["वर्क आयडी"].ToString();

            strSqlCommand = "Delete From [BudgetMasterDPDC] Where [WorkId]='" + WorkId + "'";
            strSqlCommand1 = "Delete From [DPDCProvision] Where [WorkId]='" + WorkId + "'";
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
            //decimal[] arr = new decimal[10];

            objGraph.GraphicsReports("[BudgetMasterDPDC]", "[DPDCProvision]", WhereCondition);

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

      