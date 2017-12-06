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
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class MasterMLAReport : System.Web.UI.Page, IHttpHandler, IRequiresSessionState
    {
        string pName;
        string strSqlCommand = string.Empty;
        string strSqlCommand1 = string.Empty;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2 = null;
        string strSqlCommand2 = String.Empty;   
        int RowCount = 0, TotalWork = 0;       
        MlaGrandTotal mlagrnadtotal = new MlaGrandTotal();
        string Sampurn = string.Empty;
        SqlDataAdapter da1;
        SqlDataAdapter da;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        static SqlQueryOrConnection ObjsqlQueryOrCon = new SqlQueryOrConnection();
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
                    foreach (var item in chkBuilding.Items.Cast<ListItem>().Where(li => li.Value == "a.[WorkId] as 'वर्क आयडी'" || li.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष'" || li.Value == "a.[Taluka] as 'तालुका'" || li.Value == "a.[KamacheName] as 'कामाचे नाव'" || li.Value == "a.[Upvibhag] as 'उपविभाग'" || li.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || li.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || li.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || li.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || li.Value == "a.[Kamachevav] as 'कामाचा वाव'" || li.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यांरभ आदेश/दिनांक'" || li.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'" || li.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'" || li.Value == "b.[MudatVadhiDate] as 'मुदतवाढ दिनांक'" || li.Value == "b.[ManjurAmt] as 'सन 2017-2018 मधील अपेक्षित खर्च'" || li.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'" || li.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत (6-(8+9))'" || li.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'" || li.Value == "b.[Tartud] as 'काम निहाय तरतूद सन 2017-2018'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'पुर्ण'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'प्रगतीत'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'निविदा स्तर'" || li.Value == "a.[Shera] as 'शेरा'" || li.Value == "a.[PageNo] as 'प्रकार'" || li.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'"))
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
                if (previousPageName == "MasterBudgetMLA.aspx" || previousPageName == "Send_sms.aspx" || previousPageName == "UploadImage.aspx")
                {
                    if (Session["MasterMLARpt"] != null)
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterMLAReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterMLAReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterMLAReportSda"];
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from MLAProvision Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from BudgetMasterMLA Group By Arthsankalpiyyear", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlKamacheyear.Items.Add(dr["Arthsankalpiyyear"].ToString());
            }
            ddlKamacheyear.Items.Add("संपूर्ण");
        }
            
        public void Amdar()
        {
            if (ddlKamacheyear.SelectedItem.Text == "संपूर्ण")
            {
                da1 = new SqlDataAdapter("select AmdaracheName from BudgetMasterMLA  Group By(AmdaracheName)", con);
            }
            else
            {
                da1 = new SqlDataAdapter("select AmdaracheName from BudgetMasterMLA Where Arthsankalpiyyear='" + ddlKamacheyear.SelectedItem.ToString() + "' Group By(AmdaracheName)", con);
            }
            ddlAmdar.Items.Clear();
            ddlAmdar.Items.Add("निवडा");
            
            DataTable dt = new DataTable();
            if (da1.SelectCommand.CommandText.Length>0)
            {
                da1.Fill(dt);
            }
           
            foreach (DataRow dr in dt.Rows)
            {
                ddlAmdar.Items.Add(dr["AmdaracheName"].ToString());
            }
            ddlAmdar.Items.Add("संपूर्ण");
            da1.SelectCommand.CommandText = string.Empty;
        }


        //This Method Binding All DropDwonList On Form of Mastert Head Wise Report
        public void BindAllddl()
        {
            //Create Array of DropDownList IDs
            DropDownList[] ddlIds = { ddlworkid, ddlJilha, ddlTaluka, ddlUpvibhag, ddlShakhaAbhiyanta, ddlShakhUpAbhiyanta, ddlKhasdar, ddlAmdar, ddlThekedarecheName, ddlKamachiSadyStiti };

            DataTable dt = new DataTable();
            if ((dt = (ObjsqlQueryOrCon.Bind_MasterReport_ddl("[BudgetMasterMLA]", ddlAmdar.SelectedItem.ToString()))).Rows.Count > 0)
            {
                //Get ID Of DropDownList Control from ddlIds[i] And Bind 
                for (int i = 0; i < ddlIds.Length; i++)
                {
                    if (i == 7) i++;
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
             query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[AmdaracheName] order by  a.[AmdaracheName],a.[Arthsankalpiyyear],a.[Taluka],a.[PageNo]) as 'SrNo', ";
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
                    if (item.Value == "a.[WorkId] as 'वर्क आयडी'" || item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष'" || item.Value == "a.[PageNo] as 'प्रकार'" || item.Value == "a.[Taluka] as 'तालुका'" || item.Value == "a.[KamacheName] as 'कामाचे नाव'" || item.Value == "a.[Upvibhag] as 'उपविभाग'" || item.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'" || item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'" || item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'" || item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव'" || item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव'" || item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम'" || item.Value == "convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक'" || item.Value == "convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक'" || item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त'" || item.Value == "convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यांरभ आदेश/दिनांक'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'पुर्ण'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'प्रगतीत'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'निविदा स्तर'" || item.Value == "CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN 1 ELSE 0 END as decimal(10,0)) as 'एकूण कामे'" || item.Value == "a.[kamachiMudat] as 'बांधकाम कालावधी'" || item.Value == "a.[KamPurnDate] as 'काम पूर्ण तारीख'" || item.Value == "a.[Kamachevav] as 'कामाचा वाव'" || item.Value == "a.[Pahanikramank] as 'पाहणी क्रमांक'" || item.Value == "a.[PahaniMudye] as 'पाहणीमुद्ये'" || item.Value == "a.[Shera] as 'शेरा'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "a.[WorkId] as 'वर्क आयडी'")
                        {
                            unionquery += "'Total' as 'वर्क आयडी',";
                        }
                        if (item.Value == "a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष'")
                        {
                            unionquery += "'Total' as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष',";
                        }
                        if (item.Value == "a.[PageNo] as 'प्रकार'")
                        {
                            unionquery += "isNULL ('','') as 'प्रकार',";

                        }
                        if (item.Value == "a.[Taluka] as 'तालुका'")
                        {
                            unionquery += "isNULL ('','') as 'तालुका',";

                        }
                        if (item.Value == "a.[KamacheName] as 'कामाचे नाव'")
                        {
                            unionquery += "isNULL ('','') as 'कामाचे नाव',";
                        }
                        if (item.Value == "a.[Upvibhag] as 'उपविभाग'")
                        {
                            unionquery += "isNULL ('','') as 'उपविभाग',";
                        }
                        if (item.Value == "a.[AmdaracheName] as 'आमदारांचे नाव'")
                        {
                            unionquery += "isNULL (a.[AmdaracheName],'') as 'आमदारांचे नाव',";
                        }
                        if (item.Value == "a.[KhasdaracheName] as 'खासदारांचे नाव'")
                        {
                            unionquery += "isNULL ('','') as 'खासदारांचे नाव',";
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
                    if (item.Value == "b.[MudatVadhiDate] as 'मुदतवाढ दिनांक'" || item.Value == "b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017'" || item.Value == "b.[Takunone] as 'प्रथम तिमाही तरतूद'" || item.Value == "b.[Takuntwo] as 'द्वितीय तिमाही तरतूद'" || item.Value == "b.[Takunthree] as 'तृतीय तिमाही तरतूद'" || item.Value == "b.[Takunfour] as 'चतुर्थ तिमाही तरतूद'"
                        || item.Value == "b.[Chalukharch] as 'एकुण उपलब्ध अनुदान'" || item.Value == "b.[ManjurAmt] as 'सन 2017-2018 मधील अपेक्षित खर्च'" || item.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत (6-(8+9))'" || item.Value == "b.[Tartud] as 'काम निहाय तरतूद सन 2017-2018'" || item.Value == "b.[AkunAnudan] as 'वितरीत तरतूद सन 2017-2018'" || item.Value == "b.[Magilkharch] as 'सन 2016 - 17  06/2016 अखेर खर्च'" || item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'" || item.Value == "b.[VarshbharatilKharch] as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च'" || item.Value == "b.[Vidyutprama] as 'विद्युतप्रमा'" || item.Value == "b.[Vidyutvitarit] as 'विद्युत वितरीत'" || item.Value == "b.[Itarkhrch] as 'इतर खर्च'" || item.Value == "b.[Dviguni] as 'द्वीगुणी'" || item.Value == "b.[Magni] as 'मागणी 2017-2018'" || item.Value == "b.[Apr] as 'Apr'" || item.Value == "b.[May] as 'May'" || item.Value == "b.[Jun] as 'Jun'" || item.Value == "b.[Jul] as 'Jul'" || item.Value == "b.[Aug] as 'Aug'" || item.Value == "b.[Sep] as 'Sep'" || item.Value == "b.[Oct] as 'Oct'" || item.Value == "b.[Nov] as 'Nov'" || item.Value == "b.[Dec] as 'Dec'" || item.Value == "b.[Jan] as 'Jan'" || item.Value == "b.[Feb] as 'Feb'" || item.Value == "b.[Mar] as 'Mar'")
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
                        if (item.Value == "b.[ManjurAmt] as 'सन 2017-2018 मधील अपेक्षित खर्च'")
                        {
                            unionquery += "sum(b.[ManjurAmt] )as 'सन 2017-2018 मधील अपेक्षित खर्च',";
                        }
                        if (item.Value == "b.[UrvaritAmt] as 'उर्वरित किंमत (6-(8+9))'")
                        {
                            unionquery += "sum(b.[UrvaritAmt]) as 'उर्वरित किंमत (6-(8+9))',";
                        }
                        if (item.Value == "b.[Tartud] as 'काम निहाय तरतूद सन 2017-2018'")
                        {
                            unionquery += "sum(b.[Tartud]) as 'काम निहाय तरतूद सन 2017-2018',";
                        }
                        if (item.Value == "b.[AkunAnudan] as 'वितरीत तरतूद सन 2017-2018'")
                        {
                            unionquery += "sum(b.[AkunAnudan]) as 'वितरीत तरतूद सन 2017-2018',";
                        }
                        if (item.Value == "b.[Magilkharch] as 'सन 2016 - 17  06/2016 अखेर खर्च'")
                        {
                            unionquery += "sum(b.[Magilkharch]) as 'सन 2016 - 17  06/2016 अखेर खर्च',";
                        }
                        if (item.Value == "b.[AikunKharch] as 'एकुण कामावरील खर्च'")
                        {
                            unionquery += "sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',";
                        }
                        if (item.Value == "b.[VarshbharatilKharch] as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च'")
                        {
                            unionquery += "sum(b.[VarshbharatilKharch]) as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च',";
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
                        if (item.Value == "b.[Magni] as 'मागणी 2017-2018'")
                        {
                            unionquery += "sum(b.[Magni]) as 'मागणी 2017-2018',";
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
            ViewState["query"] = query;
            ViewState["unionquery"] = unionquery;

           
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
                    lekha = ddlAmdar.Text;
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
                lekha = ddlAmdar.Text;
                ddl = Session["ddl"].ToString();
                value = Session["ddlvalue"].ToString();
            }
            DataTable dt = new DataTable();

            dt = ObjBindGrid.BindGrid(year, lekha, ddl, value, ddlArthYear.Text, query, unionquery, "BudgetMasterMLA", "MLAProvision");
            Session["MasterMLAReportSda"] = ObjBindGrid.SessionQuery;
            
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Columns[1].Visible = false;

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);

            Session["MasterMLARpt"] = GridView1;
            ListMenu.Style.Add("display", "none");

            GraphicsReport(ObjBindGrid.WhereCondition);
        }

    

        protected void btnupvibhag_Click(object sender, EventArgs e)
        {
            txtno.Text = "2";
            Session["ddl"] = "a.[upvibhag]=N";
            Session["ddlvalue"] = ddlUpvibhag.Text;
            BindGrid();

            Label5.Text = "आमदार:- " + ddlAmdar.SelectedItem.ToString() + ", उपविभाग:- " + ddlUpvibhag.SelectedItem.ToString();
        }

        protected void btnjilha_Click(object sender, EventArgs e)
        {
            txtno.Text = "3";
            Session["ddl"] = "a.[Dist]=N";
            Session["ddlvalue"] = ddlJilha.Text;
            BindGrid();
            Label5.Text = "आमदार:- " + ddlAmdar.SelectedItem.ToString() + ", जिल्हा:- " + ddlJilha.SelectedItem.ToString();
        }

        protected void btntaluka_Click(object sender, EventArgs e)
        {
            
            txtno.Text = "4";
            Session["ddl"] = "a.[Taluka]=N";
            Session["ddlvalue"] = ddlTaluka.Text;
            BindGrid();
            Label5.Text = "आमदार:- " + ddlAmdar.SelectedItem.ToString() + ", तालुका:- " + ddlTaluka.SelectedItem.ToString();
        }

        protected void btnworkid_Click(object sender, EventArgs e)
        {
            txtno.Text = "5";
            Session["ddl"] = "a.[WorkId]=N";
            Session["ddlvalue"] = ddlworkid.Text;
            BindGrid();
            Label5.Text = "आमदार:- " + ddlAmdar.SelectedItem.ToString() + ", वर्क आयडी:- " + ddlworkid.SelectedItem.ToString();
        }

        protected void btnabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "6";
            Session["ddl"] = "a.[ShakhaAbhyantaName]=N";
            Session["ddlvalue"] = ddlShakhaAbhiyanta.Text;
            BindGrid();
            Label5.Text = "आमदार:- " + ddlAmdar.SelectedItem.ToString() + ", शाखा अभियंता:- " + ddlShakhaAbhiyanta.SelectedItem.ToString();
        }

        protected void btnupabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "7";
            Session["ddl"] = "a.[UpabhyantaName]=N";
            Session["ddlvalue"] = ddlShakhUpAbhiyanta.Text;
            BindGrid();
            Label5.Text = "आमदार:- " + ddlAmdar.SelectedItem.ToString() + ", उपअभियंता:- " + ddlShakhUpAbhiyanta.SelectedItem.ToString();
        }

        protected void btnamdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "1";
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";

            BindGrid();
            Label5.Text = "आमदार:- " + ddlAmdar.SelectedItem.ToString();
        }

        protected void btnkhasdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "8";
            Session["ddl"] = "a.[KhasdaracheName]=N";
            Session["ddlvalue"] = ddlKhasdar.Text;
            BindGrid();
            Label5.Text = "आमदार:- " + ddlAmdar.SelectedItem.ToString() + ", खासदार:- " + ddlKhasdar.SelectedItem.ToString();
        }

        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            txtno.Text = "9";            
            Session["ddl"] = "a.[ThekedaarName]=N";
            Session["ddlvalue"] = ddlThekedarecheName.Text;
            BindGrid();
            Label5.Text = "आमदार:- " + ddlAmdar.SelectedItem.ToString() + ", ठेकेदार:- " + ddlThekedarecheName.SelectedItem.ToString();
        }

        protected void btnkamachistiti_Click(object sender, EventArgs e)
        {
            txtno.Text = "10";
            Session["ddl"] = "a.[Sadyasthiti]=N";
            Session["ddlvalue"] = ddlKamachiSadyStiti.Text;
            BindGrid();
            Label5.Text = "आमदार:- " + ddlAmdar.SelectedItem.ToString() + ", कामाची सद्यस्थिती:- " + ddlKamachiSadyStiti.SelectedItem.ToString();
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
        protected void ddlKamacheyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Amdar();
        }

        protected void ddlAmdar_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAllddl();
        }

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MasterMLAReport.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            // GridView1.Add.Default.Font.Name = "Arial";
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

            Session["filename"] = "MasterMLAReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "MasterMLAReport.xls");
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
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridView1.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=5&PrevPage=MasterMLAReport.aspx";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                string[] HeadrName = new string[e.Row.Cells.Count];
                for (int RowHeader_Index = 0; RowHeader_Index < e.Row.Cells.Count; RowHeader_Index++)
                {
                    HeadrName[RowHeader_Index] = e.Row.Cells[RowHeader_Index].Text;
                }
                mlagrnadtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RowCount++;
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                //e.Row.Cells[3].BackColor = System.Drawing.Color.Pink;
                if (e.Row.Cells[mlagrnadtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[mlagrnadtotal.Total_index + 6].Text = string.Empty;
                    e.Row.Cells[mlagrnadtotal.Total_index + 1].Text = string.Empty;
                    e.Row.Cells[mlagrnadtotal.Total_index - 1].Text = (RowCount - 1).ToString();
                    TotalWork += RowCount - 1;
                    RowCount = 0;
                    e.Row.Cells[mlagrnadtotal.Total_index + 5].Text = "";
                    e.Row.Cells[mlagrnadtotal.Total_index - 2].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                   
                    //this.GridView1.BorderStyle = 0;
                    if (data.Row.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        mlagrnadtotal.MarchAkher += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.MarchAkher_index].Text);
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {

                        mlagrnadtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {

                        mlagrnadtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    if (data.Row.Table.Columns["सन 2017-2018 मधील अपेक्षित खर्च"] != null)
                    {
                        mlagrnadtotal.SanMadil += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.SanMadil_index].Text);
                    }
                    if (data.Row.Table.Columns["उर्वरित किंमत (6-(8+9))"] != null)
                    {
                        mlagrnadtotal.UrvritKimmat += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.UrvritKimmat_index].Text);
                    }
                    if (data.Row.Table.Columns["काम निहाय तरतूद सन 2017-2018"] != null)
                    {
                        mlagrnadtotal.KamNihay += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.KamNihay_index].Text);
                    }
                    if (data.Row.Table.Columns["वितरीत तरतूद सन 2017-2018"] != null)
                    {
                        mlagrnadtotal.VitritTartud += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.VitritTartud_index].Text);
                    }
                    if (data.Row.Table.Columns["सन 2016 - 17  06/2016 अखेर खर्च"] != null)
                    {
                        mlagrnadtotal.KharchSan += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.KharchSan_index].Text);
                    }
                    if (data.Row.Table.Columns["मागणी 2017-2018"] != null)
                    {
                        mlagrnadtotal.Magni += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Magni_index].Text);
                    }
                    //CPNS
                    if (data.Row.Table.Columns["पुर्ण"] != null || data.Row.Table.Columns["C"] != null)
                    {
                        mlagrnadtotal.Purn += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Purn_index].Text);
                    }
                    if (data.Row.Table.Columns["प्रगतीत"] != null || data.Row.Table.Columns["P"] != null)
                    {
                        mlagrnadtotal.Pragatit += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Pragatit_index].Text);
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        mlagrnadtotal.NotStarted += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        mlagrnadtotal.Estimated += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["निविदा स्तर"] != null || data.Row.Table.Columns["TS"] != null)
                    {
                        mlagrnadtotal.NividaStar += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.NividaStar_index].Text);
                    }
                    //End CPNS
                    if (data.Row.Table.Columns["एकूण कामे"] != null)
                    {
                        mlagrnadtotal.AkunKame += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.AkunKame_index].Text);
                    }
                    //New Column
                     
                    if (data.Row.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        mlagrnadtotal.TakunOne += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.TakunOne_index].Text);
                    }
                    if (data.Row.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        mlagrnadtotal.NividaRakkam += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.NividaRakkam_Index].Text);
                    }
                    if (data.Row.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        mlagrnadtotal.TakunTow += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.TakunTow_index].Text);
                    }
                    if (data.Row.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        mlagrnadtotal.TakunTree += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.TakunTree_index].Text);
                    }
                    if (data.Row.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        mlagrnadtotal.TakunFour += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.TakunFour_index].Text);
                    }
                    if (data.Row.Table.Columns["एकुण उपलब्ध अनुदान"] != null)
                    {
                        mlagrnadtotal.ChaluKharch += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.ChaluKharch_index].Text);
                    }
                    if (data.Row.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        mlagrnadtotal.AkunKamavarilKharch += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.AkunKamavarilKharch_index].Text);
                    }
                    if (data.Row.Table.Columns["सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        mlagrnadtotal.YearExp += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.YearExp_index].Text);
                    }
                    if (data.Row.Table.Columns["विद्युतप्रमा"] != null)
                    {
                        mlagrnadtotal.VidyutiPrma += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.VidyutiPrma_index].Text);
                    }
                    if (data.Row.Table.Columns["विद्युत वितरीत"] != null)
                    {
                        mlagrnadtotal.VidyutiVitarit += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.VidyutiVitarit_index].Text);
                    }
                    if (data.Row.Table.Columns["इतर खर्च"] != null)
                    {
                        mlagrnadtotal.ItarKharch += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.ItarKharch_index].Text);
                    }
                    

                    if (data.Row.Table.Columns["Apr"] != null)
                    {
                        mlagrnadtotal.Apr += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Apr_index].Text);
                    }
                    if (data.Row.Table.Columns["May"] != null)
                    {
                        mlagrnadtotal.May += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.May_index].Text);
                    }
                    if (data.Row.Table.Columns["Jun"] != null)
                    {
                        mlagrnadtotal.Jun += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Jun_index].Text);
                    }
                    if (data.Row.Table.Columns["Jul"] != null)
                    {
                        mlagrnadtotal.Jul += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Jul_index].Text);
                    }
                    if (data.Row.Table.Columns["Aug"] != null)
                    {
                        mlagrnadtotal.Aug += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Aug_index].Text);
                    }
                    if (data.Row.Table.Columns["Sep"] != null)
                    {
                        mlagrnadtotal.sep += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.sep_index].Text);
                    }
                    if (data.Row.Table.Columns["Oct"] != null)
                    {
                        mlagrnadtotal.Oct += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Oct_index].Text);
                    }
                    if (data.Row.Table.Columns["Nov"] != null)
                    {
                        mlagrnadtotal.Nov += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Nov_index].Text);
                    }
                    if (data.Row.Table.Columns["Dec"] != null)
                    {
                        mlagrnadtotal.Dec += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Dec_index].Text);
                    }
                    if (data.Row.Table.Columns["Jan"] != null)
                    {
                        mlagrnadtotal.Jan += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Jan_index].Text);
                    }
                    if (data.Row.Table.Columns["Feb"] != null)
                    {
                        mlagrnadtotal.Feb += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Feb_index].Text);
                    }
                    if (data.Row.Table.Columns["Mar"] != null)
                    {
                        mlagrnadtotal.Mar += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Mar_index].Text);
                    }

                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[mlagrnadtotal.Total_index - 1].Text = "No Of Work: " + TotalWork.ToString();
                e.Row.Cells[mlagrnadtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[mlagrnadtotal.MarchAkher_index].Text = mlagrnadtotal.MarchAkher.ToString();
                e.Row.Cells[mlagrnadtotal.SanMadil_index].Text = mlagrnadtotal.SanMadil.ToString();
                e.Row.Cells[mlagrnadtotal.UrvritKimmat_index].Text = mlagrnadtotal.UrvritKimmat.ToString();
                e.Row.Cells[mlagrnadtotal.KamNihay_index].Text = mlagrnadtotal.KamNihay.ToString();
                e.Row.Cells[mlagrnadtotal.VitritTartud_index].Text = mlagrnadtotal.VitritTartud.ToString();
                e.Row.Cells[mlagrnadtotal.KharchSan_index].Text = mlagrnadtotal.KharchSan.ToString();
                e.Row.Cells[mlagrnadtotal.Magni_index].Text = mlagrnadtotal.Magni.ToString();
                //CPNS
                e.Row.Cells[mlagrnadtotal.Purn_index].Text = mlagrnadtotal.Purn.ToString();
                e.Row.Cells[mlagrnadtotal.Pragatit_index].Text = mlagrnadtotal.Pragatit.ToString();               
                e.Row.Cells[mlagrnadtotal.NotStarted_index].Text = mlagrnadtotal.NividaStar.ToString();
                e.Row.Cells[mlagrnadtotal.Estimated_index].Text = mlagrnadtotal.Estimated.ToString();
                e.Row.Cells[mlagrnadtotal.NividaStar_index].Text = mlagrnadtotal.NividaStar.ToString();
                //End CPNS
              

                e.Row.Cells[mlagrnadtotal.AkunKame_index].Text = mlagrnadtotal.AkunKame.ToString();
                //New Column
                e.Row.Cells[mlagrnadtotal.TakunOne_index].Text = mlagrnadtotal.TakunOne.ToString();
                e.Row.Cells[mlagrnadtotal.TakunTow_index].Text = mlagrnadtotal.TakunTow.ToString();
                e.Row.Cells[mlagrnadtotal.TakunTree_index].Text = mlagrnadtotal.TakunTree.ToString();
                e.Row.Cells[mlagrnadtotal.TakunFour_index].Text = mlagrnadtotal.TakunFour.ToString();
                e.Row.Cells[mlagrnadtotal.ChaluKharch_index].Text = mlagrnadtotal.ChaluKharch.ToString();
                e.Row.Cells[mlagrnadtotal.YearExp_index].Text = mlagrnadtotal.YearExp.ToString();
                e.Row.Cells[mlagrnadtotal.AkunKamavarilKharch_index].Text = mlagrnadtotal.AkunKamavarilKharch.ToString();
                e.Row.Cells[mlagrnadtotal.VidyutiPrma_index].Text = mlagrnadtotal.VidyutiPrma.ToString();
                e.Row.Cells[mlagrnadtotal.VidyutiVitarit_index].Text = mlagrnadtotal.VidyutiVitarit.ToString();
                e.Row.Cells[mlagrnadtotal.ItarKharch_index].Text = mlagrnadtotal.ItarKharch.ToString();
                e.Row.Cells[mlagrnadtotal.NividaKimmat_index].Text = mlagrnadtotal.NividaKimmat.ToString();
                e.Row.Cells[mlagrnadtotal.NividaRakkam_Index].Text = mlagrnadtotal.NividaRakkam.ToString();
                e.Row.Cells[mlagrnadtotal.PrashaskiyAmt_index].Text = mlagrnadtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[mlagrnadtotal.TantrikAmt_index].Text = mlagrnadtotal.TantrikAmt.ToString();

                e.Row.Cells[mlagrnadtotal.Apr_index].Text = mlagrnadtotal.Apr.ToString();
                e.Row.Cells[mlagrnadtotal.May_index].Text = mlagrnadtotal.May.ToString();
                e.Row.Cells[mlagrnadtotal.Jun_index].Text = mlagrnadtotal.Jun.ToString();
                e.Row.Cells[mlagrnadtotal.Jul_index].Text = mlagrnadtotal.Jul.ToString();
                e.Row.Cells[mlagrnadtotal.Aug_index].Text = mlagrnadtotal.Aug.ToString();
                e.Row.Cells[mlagrnadtotal.sep_index].Text = mlagrnadtotal.sep.ToString();
                e.Row.Cells[mlagrnadtotal.Oct_index].Text = mlagrnadtotal.Oct.ToString();
                e.Row.Cells[mlagrnadtotal.Nov_index].Text = mlagrnadtotal.Nov.ToString();
                e.Row.Cells[mlagrnadtotal.Dec_index].Text = mlagrnadtotal.Dec.ToString();
                e.Row.Cells[mlagrnadtotal.Jan_index].Text = mlagrnadtotal.Jan.ToString();
                e.Row.Cells[mlagrnadtotal.Feb_index].Text = mlagrnadtotal.Feb.ToString();
                e.Row.Cells[mlagrnadtotal.Mar_index].Text = mlagrnadtotal.Mar.ToString();
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
            Response.Redirect("MasterBudgetMLA.aspx?WorkID=" + pName + "");
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterMLAReportSda"].ToString(), con);
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterMLAReportSda"].ToString(), con);
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
                SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterMLAReportSda"].ToString(), con);
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
            strSqlCommand = "Delete From [BudgetMasterMLA] Where [WorkId]='" + WorkId + "'";
            strSqlCommand1 = "Delete From [MLAProvision] Where [WorkId]='" + WorkId + "'";
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
            decimal[] arr = new decimal[10];
            
            objGraph.GraphicsReports("[BudgetMasterMLA]", "[MLAProvision]", WhereCondition);

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