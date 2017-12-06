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
    public partial class MasterRoadReport : System.Web.UI.Page
    {
        ReportGrandTotal grandtotal = new ReportGrandTotal();
        int RowCount = 0, TotalWork = 0;
        string pName;
        string strSqlCommand = string.Empty;
        string strSqlCommand1 = string.Empty;
        SqlCommand cmd2 = null;
        string strSqlCommand2 = String.Empty;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataAdapter da;
        string strcmd = string.Empty;
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

                    foreach (var item in chkBuilding.Items.Cast<ListItem>().Where(li => li.Value == "a.[WorkId] as 'वर्क आयडी'" || li.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'" || li.Value == "a.[KamacheName] as 'कामाचे नाव'" || li.Value == "a.[LekhaShirshName] as 'लेखाशीर्ष नाव'" ||  li.Value == "a.[Upvibhag] as 'उपविभाग'" || li.Value == "a.[Taluka] as 'तालुका'" || li.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || li.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || li.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश'" || li.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'"  || li.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'"  || li.Value == "a.[Kamachevav] as 'कामाचा वाव'" || li.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'" || li.Value == "b.[ManjurAmt] as 'मंजूर अंदाजित किंमत'" || li.Value == "b.[MarchEndingExpn] as 'सुरवाती पासून मार्च 2017 अखेरचा खर्च'" || li.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत'" || li.Value == "b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद'" || li.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'" || li.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'"))
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
                if (previousPageName == "MasterBudgetRoad.aspx" || previousPageName == "Send_sms.aspx" || previousPageName == "UploadImage.aspx")
                {
                    if (Session["MasterRoadRpt"] != null)
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterRoadReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterDPDCReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = (SqlDataAdapter)Session["sda"];
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
                    }
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                }
            }
            ListMenu.Style.Add("display", "block");
        }

        public void ArthsankalpiyYear()
        {
            ddlArthYear.Items.Clear();
            ddlArthYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from RoadProvision Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from BudgetMasterRoad Group By Arthsankalpiyyear", con);
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
            if (ddlKamacheyear.SelectedItem.Text == "संपूर्ण")
            {
                strcmd = "select [LekhaShirshName] from BudgetMasterRoad  Group By(LekhaShirshName)";
            }
            else
            {
                strcmd = "select [LekhaShirshName] from BudgetMasterRoad where [Arthsankalpiyyear]='" + ddlKamacheyear.SelectedItem.ToString() + "' Group By(LekhaShirshName)";
            }
            ddlLekhashirsh.Items.Clear();
            ddlLekhashirsh.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter(strcmd, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlLekhashirsh.Items.Add(dr["LekhaShirshName"].ToString());
            }
            ddlLekhashirsh.Items.Add("सार्वजनिक बांधकाम पूर्व विभाग,पुणे");
            strcmd = string.Empty;
        }


        //This Method Binding All DropDwonList On Form of Mastert Head Wise Report
        public void BindAllddl()
        {
            //Create Array of DropDownList IDs
            DropDownList[] ddlIds = { ddlworkid, ddlJilha, ddlTaluka, ddlUpvibhag, ddlShakhaAbhiyanta, ddlShakhUpAbhiyanta, ddlKhasdar, ddlAmdar, ddlThekedarecheName, ddlKamachiSadyStiti };

            DataTable dt = new DataTable();
            if ((dt = (ObjsqlQueryOrCon.Bind_MasterReport_ddl("[BudgetMasterRoad]", ddlLekhashirsh.SelectedItem.ToString()))).Rows.Count > 0)
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
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName]ORDER BY a.LekhaShirshName desc,a.[Arthsankalpiyyear],a.[Taluka],a.[upvibhag]) as 'अ.क्र', ";
            unionquery = "union select isNULL ('','')as'अ.क्र', ";
            isSelected = chkBuilding.Items.Cast<ListItem>().Count(i => i.Selected == true) > 0;
            if (!isSelected)
            {
                chkBuilding.Items[0].Selected = true;
            }
            foreach (ListItem item in chkBuilding.Items)
            {
                if (item.Selected)
                {
                    if (item.Value == "a.[WorkId] as 'वर्क आयडी'" || item.Value == "a.PageNo as 'पान क्र'" || item.Value == "a.ArthsankalpiyBab as 'बाब क्र'" || item.Value == "a.JulyBab as 'जुलै/ बाब क्र./पान क्र.'" || item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'" || item.Value == "a.[KamacheName] as 'कामाचे नाव'" || item.Value == "a.[LekhaShirshName] as 'लेखाशीर्ष नाव'" || item.Value == "a.[SubType] as 'विभाग'" || item.Value == "a.[Upvibhag] as 'उपविभाग'" || item.Value == "a.[Taluka] as 'तालुका'" || item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव'" || item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव'" || item.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'" || item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'" || item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश'" || item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || item.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'" || item.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'" || item.Value == "b.[Vidyutprama] as 'विद्युतीकरणावरील प्रमा'" || item.Value == "b.[Vidyutvitarit] as 'विद्युतीकरणावरील वितरित'" || item.Value == "b.[Itarkhrch] as 'इतर खर्च'" || item.Value == "b.[Dviguni] as 'दवगुनी ज्ञापने'" || item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'" || item.Value == "a.[Kamachevav] as 'कामाचा वाव'" || item.Value == "a.[Pahanikramank] as 'पाहणी क्रमांक'" || item.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "a.[WorkId] as 'वर्क आयडी'")
                        {
                            unionquery += "'Total' as 'वर्क आयडी',";
                        }
                        if (item.Value == "a.PageNo as 'पान क्र'")
                        {
                            unionquery += "isNULL ('','') as 'पान क्र',";
                        }
                        if (item.Value == "a.ArthsankalpiyBab as 'बाब क्र'")
                        {
                            unionquery += "isNULL ('','') as 'बाब क्र',";
                        }
                        if (item.Value == "a.JulyBab as 'जुलै/ बाब क्र./पान क्र.'")
                        {
                            unionquery += "isNULL ('','') as 'जुलै/ बाब क्र./पान क्र.',";
                        }
                        if (item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष'")
                        {
                            unionquery += "isNULL ('Total','') as 'अर्थसंकल्पीय वर्ष',";
                        }
                        if (item.Value == "a.[KamacheName] as 'कामाचे नाव'")
                        {
                            unionquery += "isNULL ('','') as 'कामाचे नाव',";
                        }
                        if (item.Value == "a.[LekhaShirshName] as 'लेखाशीर्ष नाव'")
                        {
                            unionquery += " a.[LekhaShirshName] as 'लेखाशीर्ष नाव',";
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
                            unionquery += "isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',";
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

                        if (item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'")
                        {
                            unionquery += "isNULL ('','') as 'पाहणीमुद्ये',";
                        }
                        if (item.Value == "a.[Kamachevav] as 'कामाचा वाव'")
                        {
                            unionquery += "isNULL ('','') as 'कामाचा वाव',";
                        }
                        if (item.Value == "a.[Pahanikramank] as 'पाहणी क्रमांक'")
                        {
                            unionquery += "isNULL ('','') as 'पाहणी क्रमांक',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'")
                        {
                            unionquery += "isNULL ('','') as 'शेरा',";
                        }
                        isSelected = true;
                    }
                    if (item.Value == "b.[ManjurAmt] as 'मंजूर अंदाजित किंमत'" || item.Value == "b.[MarchEndingExpn] as 'सुरवाती पासून मार्च 2017 अखेरचा खर्च'" || item.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत'" || item.Value == "b.[Takunone] as'2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017'" || item.Value == "b.[Takuntwo] as '2017-18 मधील अर्थसंकल्पीय तरतूद जुलै 2017'" || item.Value == "b.[Takunthree] as'तृतीय तिमाही तरतूद'" || item.Value == "b.[Takunfour] as 'चतुर्थ तिमाही तरतूद'" || item.Value == "b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद'" || item.Value == "b.[AkunAnudan] as '2017-18 मधील वितरीत तरतूद'" || item.Value == "b.[Magilkharch] as 'मागील खर्च'" || item.Value == "b.[Magni] as '2017-18 साठी मागणी'" || item.Value == "b.[Chalukharch] as 'चालू खर्च'" || item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'" || item.Value == "b.[VarshbharatilKharch] as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च'" || item.Value == "CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत'" || item.Value == "b.[Apr] as 'Apr'" || item.Value == "b.[May] as 'May'" || item.Value == "b.[Jun] as 'Jun'" || item.Value == "b.[Jul] as 'Jul'" || item.Value == "b.[Aug] as 'Aug'" || item.Value == "b.[Sep] as 'Sep'" || item.Value == "b.[Oct] as 'Oct'" || item.Value == "b.[Nov] as 'Nov'" || item.Value == "b.[Dec] as 'Dec'" || item.Value == "b.[Jan] as 'Jan'" || item.Value == "b.[Feb] as 'Feb'" || item.Value == "b.[Mar] as 'Mar'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "b.[ManjurAmt] as 'मंजूर अंदाजित किंमत'")
                        {
                            unionquery += "sum(b.[ManjurAmt]) as 'मंजूर अंदाजित किंमत',";
                        }
                        if (item.Value == "b.[MarchEndingExpn] as 'सुरवाती पासून मार्च 2017 अखेरचा खर्च'")
                        {
                            unionquery += "sum(b.[MarchEndingExpn]) as 'सुरवाती पासून मार्च 2017 अखेरचा खर्च',";
                        }
                        if (item.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत'")
                        {
                            unionquery += "sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',";
                        }
                        if (item.Value == "b.[Takunone] as'2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017'")
                        {
                            unionquery += "sum(b.[Takunone]) as'2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017',";
                        }
                        if (item.Value == "b.[Takuntwo] as '2017-18 मधील अर्थसंकल्पीय तरतूद जुलै 2017'")
                        {
                            unionquery += "sum(b.[Takuntwo]) as '2017-18 मधील अर्थसंकल्पीय तरतूद जुलै 2017',";
                        }
                        if (item.Value == "b.[Takunthree] as'तृतीय तिमाही तरतूद'")
                        {
                            unionquery += "sum(b.[Takunthree]) as'तृतीय तिमाही तरतूद',";
                        }
                        if (item.Value == "b.[Takunfour] as 'चतुर्थ तिमाही तरतूद'")
                        {
                            unionquery += "sum(b.[Takunfour]) as 'चतुर्थ तिमाही तरतूद',";
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
                            unionquery += "sum(b.[Magilkharch]) as 'मागील खर्च ',";
                        }
                        if (item.Value == "b.[Magni] as '2017-18 साठी मागणी'")
                        {
                            unionquery += "sum(b.[Magni]) as '2017-18 साठी मागणी',";
                        }

                        if (item.Value == "b.[Chalukharch] as 'चालू खर्च'")
                        {
                            unionquery += "sum(b.[Chalukharch]) as 'चालू खर्च',";
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
            dt = ObjBindGrid.BindGrid(year, lekha, ddl, value, ddlArthYear.Text, query, unionquery, "BudgetMasterRoad", "RoadProvision");
            Session["MasterRoadReportSda"] = ObjBindGrid.SessionQuery;
            
            GridView1.DataSource = dt;

            GridView1.DataBind();
            GridView1.Columns[1].Visible = false;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            Session["MasterRoadRpt"] = GridView1;
            ListMenu.Style.Add("display", "none");
            GraphicsReport(ObjBindGrid.WhereCondition);
        }


        protected void btnlekhashirsh_Click(object sender, EventArgs e)
        {

            txtno.Text = "1";
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";
            BindGrid();
            Label5.Text = "लेखाशीर्ष:- " + ddlLekhashirsh.SelectedItem.ToString();


        }

        protected void btnupvibhag_Click(object sender, EventArgs e)
        {
            txtno.Text = "2";
            Session["ddl"] = "a.[upvibhag]=N";
            Session["ddlvalue"] = ddlUpvibhag.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:- " + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "उपविभाग:- " + ddlUpvibhag.SelectedItem.ToString();
        }

        protected void btnjilha_Click(object sender, EventArgs e)
        {
            txtno.Text = "3";
            Session["ddl"] = "a.[Dist]=N";
            Session["ddlvalue"] = ddlJilha.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:- " + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "जिल्हा:- " + ddlJilha.SelectedItem.ToString();
        }

        protected void btntaluka_Click(object sender, EventArgs e)
        {
            txtno.Text = "4";
            Session["ddl"] = "a.[Taluka]=N";
            Session["ddlvalue"] = ddlTaluka.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:- " + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "तालुका:- " + ddlTaluka.SelectedItem.ToString();
        }


        protected void btnworkid_Click(object sender, EventArgs e)
        {
            txtno.Text = "5";
            Session["ddl"] = "a.[WorkId]=N";
            Session["ddlvalue"] = ddlworkid.Text;
            BindGrid();
            Label5.Text = "लेखाशीर्ष:- " + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "Work_ID:-" + ddlworkid.SelectedItem.ToString();
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
        }

        protected void chkBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }


        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MasterRoadReport.xls");
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

            Session["filename"] = "MasterRoadReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "MasterRoadReport.xls");
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
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridView1.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=10&PrevPage=MasterRoadReport.aspx";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[grandtotal.Total_index - 1].Text = "No Of Work: " + TotalWork.ToString();
                e.Row.Cells[grandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[grandtotal.ManjurAmt_index].Text = grandtotal.ManjurAmt.ToString();

                e.Row.Cells[grandtotal.PrashaskiyAmt_index].Text = grandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[grandtotal.TantrikAmt_index].Text = grandtotal.TantrikAmt.ToString();

                e.Row.Cells[grandtotal.MarchEndingExpn_index].Text = grandtotal.MarchEndingExpn.ToString();
                e.Row.Cells[grandtotal.UrvaritAmt_index].Text = grandtotal.UrvaritAmt.ToString();
                e.Row.Cells[grandtotal.Takunone_index].Text = grandtotal.Takunone.ToString();
                e.Row.Cells[grandtotal.Takuntwo_index].Text = grandtotal.Takuntwo.ToString();
                e.Row.Cells[grandtotal.NividaRakkam_index].Text = grandtotal.NividaRakkam.ToString();

                e.Row.Cells[grandtotal.TisriTartud_index].Text = grandtotal.TisriTartud.ToString();
                e.Row.Cells[grandtotal.ChothiTartud_index].Text = grandtotal.ChothiTartud.ToString();
                e.Row.Cells[grandtotal.Chalukharch_index].Text = grandtotal.Chalukharch.ToString();
                e.Row.Cells[grandtotal.YearExp_Index].Text = grandtotal.YearExp.ToString();
                e.Row.Cells[grandtotal.EkunKamavarilKharch_Index].Text = grandtotal.EkunKamavarilKharch.ToString();

                e.Row.Cells[grandtotal.Tartud_index].Text = grandtotal.Tartud.ToString();
                e.Row.Cells[grandtotal.AkunAnudan_index].Text = grandtotal.AkunAnudan.ToString();
                e.Row.Cells[grandtotal.Magilkharch_index].Text = grandtotal.Magilkharch.ToString();
                e.Row.Cells[grandtotal.Magni_Index].Text = grandtotal.Magni.ToString();               
                e.Row.Cells[grandtotal.Vidyutprama_index].Text = grandtotal.Vidyutprama.ToString();
                e.Row.Cells[grandtotal.Vidyutvitarit_index].Text = grandtotal.Vidyutvitarit.ToString();
                e.Row.Cells[grandtotal.Itarkhrch_index].Text = grandtotal.Itarkhrch.ToString();
                //CPNS
                e.Row.Cells[grandtotal.C_index].Text = grandtotal.C.ToString();
                e.Row.Cells[grandtotal.P_index].Text = grandtotal.P.ToString();
                e.Row.Cells[grandtotal.NS_index].Text = grandtotal.NS.ToString();
                e.Row.Cells[grandtotal.ES_index].Text = grandtotal.ES.ToString();
                e.Row.Cells[grandtotal.TS_index].Text = grandtotal.TS.ToString();
                //End CPNS

                e.Row.Cells[grandtotal.Apr_index].Text = grandtotal.Apr.ToString();
                e.Row.Cells[grandtotal.May_index].Text = grandtotal.May.ToString();
                e.Row.Cells[grandtotal.Jun_index].Text = grandtotal.Jun.ToString();
                e.Row.Cells[grandtotal.Jul_index].Text = grandtotal.Jul.ToString();
                e.Row.Cells[grandtotal.Aug_index].Text = grandtotal.Aug.ToString();
                e.Row.Cells[grandtotal.sep_index].Text = grandtotal.sep.ToString();
                e.Row.Cells[grandtotal.Oct_index].Text = grandtotal.Oct.ToString();
                e.Row.Cells[grandtotal.Nov_index].Text = grandtotal.Nov.ToString();
                e.Row.Cells[grandtotal.Dec_index].Text = grandtotal.Dec.ToString();
                e.Row.Cells[grandtotal.Jan_index].Text = grandtotal.Jan.ToString();
                e.Row.Cells[grandtotal.Feb_index].Text = grandtotal.Feb.ToString();
                e.Row.Cells[grandtotal.Mar_index].Text = grandtotal.Mar.ToString();
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

            if (e.Row.RowType == DataControlRowType.Header)
            {
                string[] HeadrName = new string[e.Row.Cells.Count];
                for (int RowHeader_Index = 0; RowHeader_Index < e.Row.Cells.Count; RowHeader_Index++)
                {
                    HeadrName[RowHeader_Index] = e.Row.Cells[RowHeader_Index].Text;
                }
                grandtotal.index(HeadrName);
            }

            //DataRow
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var data = e.Row.DataItem as DataRowView;
                RowCount++;
                // do your stuffs here, for example if column risk is your third column:
                if (e.Row.Cells[grandtotal.Total_index].Text == "Total")
                {
                    //Total Indivisual group work (Group by total)
                    e.Row.Cells[grandtotal.Total_index - 1].Text = (RowCount - 1).ToString();
                    // Total No of Works
                    TotalWork += RowCount - 1;
                    RowCount = 0;
                    e.Row.Cells[grandtotal.Total_index + 4].Text = "";
                    e.Row.Cells[grandtotal.Total_index + 6].Text = "";
                    e.Row.Cells[grandtotal.Total_index - 2].Text = "";
                    //Set Color to  Row(Name=Total) 
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;
                    //Check column is in List or Not(checkbox checked or not)
                    if (data.DataView.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        grandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }

                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        grandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        grandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }


                    if (data.DataView.Table.Columns["सुरवाती पासून मार्च 2017 अखेरचा खर्च"] != null)
                    {
                        grandtotal.MarchEndingExpn += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सुरवाती पासून मार्च 2017 अखेरचा खर्च"));

                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        grandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                    }

                    if (data.DataView.Table.Columns["2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017"] != null)
                    {
                        grandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017"));

                    }
                    if (data.DataView.Table.Columns["2017-18 मधील अर्थसंकल्पीय तरतूद जुलै 2017"] != null)
                    {
                        grandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 मधील अर्थसंकल्पीय तरतूद जुलै 2017"));

                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        grandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        grandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        grandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        grandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        grandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        grandtotal.Chalukharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }

                    if (data.DataView.Table.Columns["एकूण अर्थसंकल्पीय तरतूद"] != null)
                    {
                        grandtotal.Tartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकूण अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["2017-18 मधील वितरीत तरतूद"] != null)
                    {
                        grandtotal.AkunAnudan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 मधील वितरीत तरतूद"));

                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        grandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));

                    }
                    if (data.DataView.Table.Columns["2017-18 साठी मागणी"] != null)
                    {
                        grandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 साठी मागणी"));

                    }
                    //CPNS
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        grandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));

                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        grandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));

                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        grandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));

                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        grandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        grandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    //End CPNS
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        grandtotal.Vidyutprama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));

                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        grandtotal.Vidyutvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));

                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        grandtotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));

                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        grandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));

                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        grandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));

                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        grandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));

                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        grandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));

                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        grandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));

                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        grandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));

                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        grandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));

                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        grandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));

                    }

                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        grandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));

                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        grandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));

                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        grandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));

                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        grandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mar"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        grandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
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
            Response.Redirect("MasterBudgetRoad.aspx?WorkID=" + pName + "");
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterRoadReportSda"].ToString(), con);
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterRoadReportSda"].ToString(), con);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.Columns[1].Visible = false;

                }
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            else
            {
                myBtn2.Checked = false;
                //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterBuildingReportSda"];
                SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterRoadReportSda"].ToString(), con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Columns[1].Visible = false;

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,false); </script>", false);
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
            strSqlCommand = "Delete From [BudgetMasterRoad] Where [WorkId]='" + WorkId + "'";
            strSqlCommand1 = "Delete From [RoadProvision] Where [WorkId]='" + WorkId + "'";
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            con.Close();
        }

        public void GraphicsReport(string WhereCondition)
        {
            string[] arr1 = { "Completed", "Incomplete", "Inprogress", "Tender Stage", "Estimated Stage", "Not Started", "Estimated Cost", "T.S Cost", "Budget Provision", "Expenditure" };
          
            objGraph.GraphicsReports("[BudgetMasterRoad]", "[RoadProvision]", WhereCondition);

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