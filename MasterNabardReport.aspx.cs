
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
    public partial class MasterNabardReport : System.Web.UI.Page
    {
        ReportGrandTotal grandTotal = new ReportGrandTotal();
        int rowcount = 0;
        int totalrowcount = 0;
        string pName;
        string strSqlCommand = string.Empty;
        string strSqlCommand1 = string.Empty;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2 = null;
        string strSqlCommand2 = String.Empty;
        string[] drindex = new string[70];
        decimal total = 0;
        int index = 0;
        clsGraphicsReport objGraph = new clsGraphicsReport();
        MasterReportGridBind ObjBindGrid = new MasterReportGridBind();
        string query = string.Empty;
        string unionquery = string.Empty;
        bool isSelected;
        string year = string.Empty, lekha = string.Empty, ddl = string.Empty, value = string.Empty;
        SqlDataAdapter da;
        SqlDataAdapter da1;
        string kamacheyear1 = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        static SqlQueryOrConnection ObjsqlQueryOrCon = new SqlQueryOrConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                subtype();
                KamacheYear();
                ArthsankalpiyYear();
                //Redirect from Home Page
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
                    foreach (var item in chkBuilding.Items.Cast<ListItem>().Where(li => li.Value == "a.[WorkId] as 'Work Id'" || li.Value == "a.[RDF_NO] as 'RIDF NO'" || li.Value == "a.[Arthsankalpiyyear] as 'Budget of Year'" || li.Value == "a.[Taluka] as 'Taluka'" || li.Value == "a.[KamacheName]as 'Name of Work'" || li.Value == "a.[Kamachavav] as 'Scope of Work'" || li.Value == "a.[LekhaShirshName] as 'Headwise'" || li.Value == "a.[Upvibhag] as 'Sub Division'" || li.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor'" || li.Value == "a.[PrashaskiyKramank] as 'Administrative No'" || li.Value == "a.[PrashaskiyDate] as 'A A Date'" || li.Value == "cast(a.[PrashaskiyAmt] as decimal(10,2)) as 'AA cost Rs in lakhs'" || li.Value == "cast(a.[TrantrikAmt]as decimal(10,2))as 'Technical Sanction Cost Rs in Lakh'" || li.Value == "a.[TrantrikKrmank]+' '+a.[TrantrikDate] as 'Technical Sanction No and Date'" || li.Value == "a.[karyarambhadesh] as 'Work Order'" || li.Value == "a.[kamachiMudat] as 'Work Order Date'" || li.Value == "a.[KamPurnDate] as 'Work Completion Date'" || li.Value == "b.[MudatVadhiDate] as 'Extension Month'" || li.Value == "b.[ManjurAmt] as 'Estimated Cost Approved'" || li.Value == "b.[MarchEndingExpn] as 'Expenditure up to MAR 2017'" || li.Value == "b.[UrvaritAmt] as 'Remaining Cost'" || li.Value == "b.[AikunKharch] as 'Total Expense'" || li.Value == "" || li.Value == "b.[Tartud] as 'Total Provision'" || li.Value == "a.[Sadyasthiti] as 'Physical Progress of work'" || li.Value == "a.[Shera] as 'Remark'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Inprogress'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'"))
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
                if (previousPageName == "MasterBudgetNABARD.aspx" || previousPageName == "Send_sms.aspx" || previousPageName == "UploadImage.aspx")
                {
                    if (Session["MasterNabardRpt"] != null)
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterNabardReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterNabardReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterNabardReportSda"];
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

        public void subtype()
        {
            ddlReportType.Items.Clear();
            ddlReportType.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT RDF_NO from BudgetMasterNABARD", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlReportType.Items.Add(dr[0].ToString());
            }
            ddlReportType.Items.Add("संपूर्ण");
        }
        public void ArthsankalpiyYear()
        {
            ddlArthYear.Items.Clear();
            ddlArthYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from NABARDProvision Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from BudgetMasterNABARD Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select [LekhaShirshName] from BudgetMasterNABARD where [Arthsankalpiyyear]='" + ddlKamacheyear.SelectedItem.ToString() + "' Group By(LekhaShirshName)", con);
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
            if ((dt = (ObjsqlQueryOrCon.Bind_MasterReport_ddl("[BudgetMasterNABARD]", ddlLekhashirsh.SelectedItem.ToString()))).Rows.Count > 0)
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
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[RDF_SrNo] ORDER BY a.[Upvibhag]) as 'SrNo', ";
            unionquery = "union select isNULL (a.[RDF_SrNo],'')as'SrNo',";
            isSelected = chkBuilding.Items.Cast<ListItem>().Count(i => i.Selected == true) > 0;
            if (!isSelected)
            {
                chkBuilding.Items[0].Selected = true;
            }
            foreach (ListItem item in chkBuilding.Items)
            {
                if (item.Selected)
                {
                    if (item.Value == "a.[WorkId] as 'Work Id'" || item.Value == "a.[RDF_NO] as 'RIDF NO'" || item.Value == "a.[Arthsankalpiyyear] as 'Budget of Year'" || item.Value == "a.Dist as 'District'" || item.Value == "a.[Taluka] as 'Taluka'" || item.Value == "a.[ArthsankalpiyBab] as 'Budget of Item'" || item.Value == "a.[KamacheName]as 'Name of Work'" || item.Value == "a.[Kamachavav] as 'Scope of Work'" || item.Value == "a.[LekhaShirshName] as 'Headwise'" || item.Value == "a.[SubType] as 'Division'" || item.Value == "a.[Upvibhag] as 'Sub Division'" || item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'Sectional Engineer'" || item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'Deputy Engineer'" || item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor'" || item.Value == "a.[AmdaracheName] as 'MLA'" || item.Value == "a.[KhasdaracheName] as 'MP'" || item.Value == "a.[PrashaskiyKramank] as 'Administrative No'" || item.Value == "a.[PrashaskiyDate] as 'A A Date'" || item.Value == "a.[PIC_NO] as 'PIC No'" || item.Value == "cast(a.[PrashaskiyAmt] as decimal(10,2)) as 'AA cost Rs in lakhs'" || item.Value == "cast(a.[TrantrikAmt]as decimal(10,2))as 'Technical Sanction Cost Rs in Lakh'" || item.Value == "a.[TrantrikKrmank]+' '+a.[TrantrikDate] as 'Technical Sanction No and Date'" || item.Value == "a.[NividaKrmank] as 'Tender No'" || item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'Tender Amount'" || item.Value == "a.[karyarambhadesh] as 'Work Order'" || item.Value == "a.[NividaDate] as 'Tender Date'" || item.Value == "a.[kamachiMudat] as 'Work Order Date'" || item.Value == "a.[KamPurnDate] as 'Work Completion Date'" || item.Value == "a.[Road_No] as 'Road Category'" || item.Value == "a.[LengthRoad] as 'Road Length'" || item.Value == "a.[RoadType] as 'Road Type'" || item.Value == "a.[WBMI_km] as 'WBMI Km'" || item.Value == "a.[WBMII_km] as 'WBMII Km'" || item.Value == "a.[WBMIII_km] as 'WBMIII Km'" || item.Value == "a.[BBM_km] as 'BBM Km'" || item.Value == "a.[Carpet_km] as 'Carpet Km'" || item.Value == "a.[Surface_km] as 'Surface Km'" || item.Value == "cast(a.[CD_Works_No] as decimal(10,2))  as 'CD_Works_No'" || item.Value == "a.[Sadyasthiti] as 'Physical Progress of work'" || item.Value == "a.[Pahanikramank] as 'Probable date of completion'" || item.Value == "a.[PahaniMudye] as 'Observation Memo'" || item.Value == "a.[PCR] as 'PCR submitted or not'" || item.Value == "a.[Shera] as 'Remark'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Inprogress'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "a.[WorkId] as 'Work Id'")
                        {
                            unionquery += "isNULL ('Total','') as 'Work Id',";
                            //unionquery += "'Total' as 'Work Id',";
                        }
                        if (item.Value == "a.[RDF_NO] as 'RIDF NO'")
                        {
                            unionquery += "isNULL ('','')as 'RIDF NO',";
                            unionquery += " cast(a.[RDF_SrNo] as int) as 'srno',";
                            query += " a.[RDF_SrNo] as 'srno',";
                        }
                        if (item.Value == "a.[Arthsankalpiyyear] as 'Budget of Year'")
                        {
                            unionquery += "isNULL ('Total','')as 'Budget of Year',";
                        }
                        if (item.Value == "a.Dist as 'District'")
                        {
                            unionquery += "isNULL ('','') as 'District',";
                        }
                        if (item.Value == "a.[Taluka] as 'Taluka'")
                        {
                            unionquery += "isNULL ('','') as 'Taluka',";
                        }
                        if (item.Value == "a.[ArthsankalpiyBab] as 'Budget of Item'")
                        {
                            unionquery += "isNULL ('','') as 'Budget of Item',";
                        }
                        if (item.Value == "a.[KamacheName]as 'Name of Work'")
                        {
                            unionquery += "isNULL ('','')as 'Name of Work',";
                        }
                        if (item.Value == "a.[Kamachavav] as 'Scope of Work'")
                        {
                            unionquery += "isNULL ('','') as 'Scope of Work',";
                        }
                        if (item.Value == "a.[LekhaShirshName] as 'Headwise'")
                        {
                            unionquery += "isNULL ('','')as 'Headwise',";
                        }
                        if (item.Value == "a.[SubType] as 'Division'")
                        {
                            unionquery += "isNULL ('','') as 'Division',";
                        }
                        if (item.Value == "a.[Upvibhag] as 'Sub Division'")
                        {
                            unionquery += "isNULL ('','') as 'Sub Division',";
                        }

                        if (item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'Sectional Engineer'")
                        {
                            unionquery += "isNULL ('','') as 'Sectional Engineer',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'Deputy Engineer'")
                        {
                            unionquery += "isNULL ('','') as 'Deputy Engineer',";
                        }

                        if (item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor'")
                        {
                            unionquery += "isNULL ('','') as 'Contractor',";
                        }
                        if (item.Value == "a.[AmdaracheName] as 'MLA'")
                        {
                            unionquery += "isNULL ('','') as 'MLA',";
                        }
                        if (item.Value == "a.[KhasdaracheName] as 'MP'")
                        {
                            unionquery += "isNULL ('','') as 'MP',";
                        }
                        if (item.Value == "a.[PrashaskiyKramank] as 'Administrative No'")
                        {
                            unionquery += "isNULL ('','') as 'Administrative No',";
                        }
                        if (item.Value == "a.[PrashaskiyDate] as 'A A Date'")
                        {
                            unionquery += "isNULL ('','') as 'A A Date',";
                        }
                        if (item.Value == "a.[PIC_NO] as 'PIC No'")
                        {
                            unionquery += "'Total' as 'PIC No',";
                        }
                        if (item.Value == "cast(a.[PrashaskiyAmt] as decimal(10,2)) as 'AA cost Rs in lakhs'")
                        {
                            unionquery += "sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'AA cost Rs in lakhs',";
                        }
                        if (item.Value == "cast(a.[TrantrikAmt]as decimal(10,2))as 'Technical Sanction Cost Rs in Lakh'")
                        {
                            unionquery += "sum(cast(a.[TrantrikAmt]as decimal(10,2)))as 'Technical Sanction Cost Rs in Lakh',";
                        }
                        if (item.Value == "a.[TrantrikKrmank]+' '+a.[TrantrikDate] as 'Technical Sanction No and Date'")
                        {
                            unionquery += "isNULL ('','') as 'Technical Sanction No and Date',";
                        }
                        if (item.Value == "a.[NividaKrmank] as 'Tender No'")
                        {
                            unionquery += "isNULL ('','') as 'Tender No',";
                        }
                        if (item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'Tender Amount'")
                        {
                            unionquery += "sum(cast(a.[NividaAmt] as decimal(10,2))) as 'Tender Amount',";
                        }
                        if (item.Value == "a.[karyarambhadesh] as 'Work Order'")
                        {
                            unionquery += "isNULL ('','') as 'Work Order',";
                        }
                        if (item.Value == "a.[NividaDate] as 'Tender Date'")
                        {
                            unionquery += "isNULL ('','') as 'Tender Date',";
                        }
                        if (item.Value == "a.[kamachiMudat] as 'Work Order Date'")
                        {
                            unionquery += "isNULL ('','') as 'Work Order Date',";
                        }
                        if (item.Value == "a.[KamPurnDate] as 'Work Completion Date'")
                        {
                            unionquery += "isNULL ('','') as 'Work Completion Date',";
                        }
                        if (item.Value == "a.[Road_No] as 'Road Category'")
                        {
                            unionquery += "isNULL ('','') as 'Road Category',";
                        }
                        if (item.Value == "a.[LengthRoad] as 'Road Length'")
                        {
                            unionquery += "isNULL ('','') as 'Road Length',";
                        }
                        if (item.Value == "a.[RoadType] as 'Road Type'")
                        {
                            unionquery += "isNULL ('','') as 'Road Type',";
                        }
                        if (item.Value == "a.[WBMI_km] as 'WBMI Km'")
                        {
                            unionquery += "sum(a.[WBMI_km]) as 'WBMI Km',";
                        }
                        if (item.Value == "a.[WBMII_km] as 'WBMII Km'")
                        {
                            unionquery += "sum(a.[WBMII_km]) as 'WBMII Km',";
                        }
                        if (item.Value == "a.[WBMIII_km] as 'WBMIII Km'")
                        {
                            unionquery += "sum(a.[WBMIII_km]) as 'WBMIII Km',";
                        }
                        if (item.Value == "a.[BBM_km] as 'BBM Km'")
                        {
                            unionquery += "sum(a.[BBM_km]) as 'BBM Km',";
                        }
                        if (item.Value == "a.[Carpet_km] as 'Carpet Km'")
                        {
                            unionquery += "sum(a.[Carpet_km]) as 'Carpet Km',";
                        }
                        if (item.Value == "a.[Surface_km] as 'Surface Km'")
                        {
                            unionquery += "sum(a.[Surface_km]) as 'Surface Km',";
                        }
                        if (item.Value == "cast(a.[CD_Works_No] as decimal(10,2))  as 'CD_Works_No'")
                        {
                            unionquery += "sum(cast(a.[CD_Works_No] as decimal(10,2)))  as 'CD_Works_No',";
                        }
                        if (item.Value == "a.[Sadyasthiti] as 'Physical Progress of work'")
                        {
                            unionquery += "isNULL ('','') as 'Physical Progress of work',";
                        }
                        if (item.Value == "a.[Pahanikramank] as 'Probable date of completion'")
                        {
                            unionquery += "isNULL ('','') as 'Probable date of completion',";
                        }
                        if (item.Value == "a.[PahaniMudye] as 'Observation Memo'")
                        {
                            unionquery += "isNULL ('','') as 'Observation Memo',";
                        }
                        if (item.Value == "a.[PCR] as 'PCR submitted or not'")
                        {
                            unionquery += "isNULL ('','') as 'PCR submitted or not',";
                        }
                        if (item.Value == "a.[Shera] as 'Remark'")
                        {
                            unionquery += "isNULL ('','')as 'Remark',";
                        }

                        //CPNS
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',";
                        }
                        if (item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Inprogress'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'")
                        {
                            unionquery += "sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Inprogress'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',";
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
                    if (item.Value == "b.[MudatVadhiDate] as 'Extension Month'" || item.Value == "b.[DeyakachiSadyasthiti] as 'Bill Status'" || item.Value == "b.[ManjurAmt] as 'Estimated Cost Approved'" || item.Value == "b.[MarchEndingExpn] as 'Expenditure up to MAR 2017'" || item.Value == "b.[UrvaritAmt] as 'Remaining Cost'" || item.Value == "b.[Takunone] as 'Budget Provision in 2017-18 Rs in Lakhs'" || item.Value == "b.[Takuntwo] as 'Second Provision'" || item.Value == "b.[Takunthree] as 'Third Provision'" || item.Value == "b.[Takunfour] as 'Fourth Provision'" || item.Value == "b.[Tartud] as 'Total Provision'" || item.Value == "b.[AkunAnudan] as 'Total Grand'" || item.Value == "b.[Chalukharch] as 'Current Cost'" || item.Value == "b.[Magilkharch] as 'Previous Cost'" || item.Value == "b.[AikunKharch] as 'Total Expense'" || item.Value == "b.[Apr] as 'Apr'" || item.Value == "b.[May] as 'May'" || item.Value == "b.[Jun] as 'Jun'" || item.Value == "b.[Jul] as 'Jul'" || item.Value == "b.[Aug] as 'Aug'" || item.Value == "b.[Sep] as 'Sep'" || item.Value == "b.[Oct] as 'Oct'" || item.Value == "b.[Nov] as 'Nov'" || item.Value == "b.[Dec] as 'Dec'" || item.Value == "b.[Jan] as 'Jan'" || item.Value == "b.[Feb] as 'Feb'" || item.Value == "b.[Mar] as 'Mar'" || item.Value == "b.[Magni] as 'Demand for 2017-18 Rs in Lakhs'" || item.Value == "b.[VarshbharatilKharch] as 'Expenditure up to 8/2016 during year 16-17 Rs in Lakhs'")
                    {
                        if (item.Value == "b.[MudatVadhiDate] as 'Extension Month'")
                        {
                            unionquery += "isNULL ('','') as 'Extension Month',";
                        }
                        if (item.Value == "b.[DeyakachiSadyasthiti] as 'Bill Status'")
                        {
                            unionquery += "isNULL ('','') as 'Bill Status',";
                        }
                        if (item.Value == "b.[ManjurAmt] as 'Estimated Cost Approved'")
                        {
                            unionquery += "sum(b.[ManjurAmt]) as 'Estimated Cost Approved',";
                        }
                        if (item.Value == "b.[MarchEndingExpn] as 'Expenditure up to MAR 2017'")
                        {
                            unionquery += "sum(b.[MarchEndingExpn]) as 'Expenditure up to MAR 2017',";
                        }
                        if (item.Value == "b.[UrvaritAmt] as 'Remaining Cost'")
                        {
                            unionquery += "sum(b.[UrvaritAmt]) as 'Remaining Cost',";
                        }
                        if (item.Value == "b.[Takunone] as 'Budget Provision in 2017-18 Rs in Lakhs'")
                        {
                            unionquery += "sum(b.[Takunone]) as 'Budget Provision in 2017-18 Rs in Lakhs',";
                        }
                        if (item.Value == "b.[Takuntwo] as 'Second Provision'")
                        {
                            unionquery += "sum(b.[Takuntwo]) as 'Second Provision',";
                        }

                        if (item.Value == "b.[Takunthree] as 'Third Provision'")
                        {
                            unionquery += "sum(b.[Takunthree]) as 'Third Provision',";
                        }

                        if (item.Value == "b.[Takunfour] as 'Fourth Provision'")
                        {
                            unionquery += "sum(b.[Takunfour]) as 'Fourth Provision',";
                        }
                        if (item.Value == "b.[Tartud] as 'Total Provision'")
                        {
                            unionquery += "sum(b.[Tartud]) as 'Total Provision',";
                        }
                        if (item.Value == "b.[AkunAnudan] as 'Total Grand'")
                        {
                            unionquery += "sum(b.[AkunAnudan]) as 'Total Grand',";
                        }
                        if (item.Value == "b.[Chalukharch] as 'Current Cost'")
                        {
                            unionquery += "sum(b.[Chalukharch]) as 'Current Cost',";
                        }
                        if (item.Value == "b.[Magilkharch] as 'Previous Cost'")
                        {
                            unionquery += "sum(b.[Magilkharch]) as 'Previous Cost',";
                        }
                        if (item.Value == "b.[AikunKharch] as 'Total Expense'")
                        {
                            unionquery += "sum(b.[AikunKharch]) as 'Total Expense', ";
                        }
                        if (item.Value == "b.[Apr] as 'Apr'")
                        {
                            unionquery += "sum(b.[Apr]) as 'Apr',";
                        }
                        if (item.Value == "b.[May] as 'May'")
                        {
                            unionquery += "sum(b.[May]) as 'May',";
                        }
                        if (item.Value == "b.[Jun] as 'Jun'")
                        {
                            unionquery += "sum(b.[Jun]) as 'Jun',";
                        }
                        if (item.Value == "b.[Jul] as 'Jul'")
                        {
                            unionquery += "sum(b.[Jul]) as 'Jul',";
                        }
                        if (item.Value == "b.[Aug] as 'Aug'")
                        {
                            unionquery += "sum(b.[Aug]) as 'Aug',";
                        }
                        if (item.Value == "b.[Sep] as 'Sep'")
                        {
                            unionquery += "sum(b.[Sep]) as 'Sep',";
                        }
                        if (item.Value == "b.[Oct] as 'Oct'")
                        {
                            unionquery += "sum(b.[Oct]) as 'Oct',";
                        }
                        if (item.Value == "b.[Nov] as 'Nov'")
                        {
                            unionquery += "sum(b.[Nov]) as 'Nov',";
                        }
                        if (item.Value == "b.[Dec] as 'Dec'")
                        {
                            unionquery += "sum(b.[Dec]) as 'Dec',";
                        }
                        if (item.Value == "b.[Jan] as 'Jan'")
                        {
                            unionquery += "sum(b.[Jan]) as 'Jan',";
                        }
                        if (item.Value == "b.[Feb] as 'Feb'")
                        {
                            unionquery += "sum(b.[Feb]) as 'Feb',";
                        }
                        if (item.Value == "b.[Mar] as 'Mar'")
                        {
                            unionquery += "sum(b.[Mar]) as 'Mar',";
                        }
                        if (item.Value == "b.[Magni] as 'Demand for 2017-18 Rs in Lakhs'")
                        {
                            unionquery += "sum(b.[Magni]) as 'Demand for 2017-18 Rs in Lakhs',";
                        }
                        if (item.Value == "b.[VarshbharatilKharch] as 'Expenditure up to 8/2016 during year 16-17 Rs in Lakhs'")
                        {
                            unionquery += "sum(b.[VarshbharatilKharch]) as 'Expenditure up to 8/2016 during year 16-17 Rs in Lakhs',";
                        }

                        query += item.Value + ",";
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
                if (kamacheyear1 == "संपूर्ण")
                {
                    lekha = "निवडा";
                }
                else
                {
                    lekha = ddlReportType.Text;
                }

                ddl = Session["ddl"].ToString();
                value = Session["ddlvalue"].ToString();
            }
            DataTable dt = new DataTable();
            dt = ObjBindGrid.BindGrid(year, lekha, ddl, value, ddlArthYear.Text, query, unionquery, "BudgetMasterNABARD", "NABARDProvision");
            Session["MasterNabardReportSda"] = ObjBindGrid.SessionQuery;
            // da.Fill(dt);
            GridView1.DataSource = dt;

            GridView1.DataBind();
            GridView1.Columns[1].Visible = false;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            Session["MasterNabardRpt"] = GridView1;
            ListMenu.Style.Add("display", "none");
            GraphicsReport(ObjBindGrid.WhereCondition);
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
            // BindReport();
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
            //  BindReport();

            Session["ddl"] = "a.[ShakhaAbhyantaName]=N";
            Session["ddlvalue"] = ddlShakhaAbhiyanta.Text;
            BindGrid();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "शाखा अभियंता:-" + ddlShakhaAbhiyanta.SelectedItem.ToString();
        }

        protected void btnupabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "7";
            //BindReport();

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
            // BindReport();
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
            kamacheyear1 = "संपूर्ण";
            BindGrid();
            Label3.Text = "कामाचे वर्ष:- " + ddlKamacheyear.Text.Split('-')[0];
        }
        protected void chkBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindReport();
            BindGrid();
        }
        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MasterNabardReport.xls");
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

            Session["filename"] = "MasterNabardReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "MasterNabardReport.xls");
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
            //e.Row.Cells[3].BackColor = System.Drawing.Color.Pink;

            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridView1.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=7&PrevPage=MasterNabardReport.aspx";
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

            //.Header For Check Headr column Name,Index
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[7].Visible = false;
                //for loop : increment the row cell by one and stor in string headrname
                for (int RowHeader_Index = 0; RowHeader_Index < e.Row.Cells.Count; RowHeader_Index++)
                {


                    HeadrName[RowHeader_Index] = e.Row.Cells[RowHeader_Index].Text;
                    //dt_index[i] = e.Row.Cells[i].Text;
                    //if (e.Row.Cells[i].Text == "AA cost Rs in lakhs")
                    //{
                    //    //e.Row.Cells[i].Text = "Finded";
                    //}
                }

                // index(ColumnName) method of cls ReportgrandTotal
                grandTotal.index(HeadrName);

            }
            //DataRow
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                rowcount++;
                var data = e.Row.DataItem as DataRowView;

                e.Row.Cells[grandTotal.Total_index + 2].Visible = false;

                // do your stuffs here, for example if column risk is your third column:
                if (e.Row.Cells[grandTotal.Total_index].Text == "Total")
                {
                    //Total Indivisual group work (Group by total)
                    e.Row.Cells[grandTotal.Total_index - 1].Text = (rowcount - 1).ToString();
                    e.Row.Cells[grandTotal.Total_index - 2].Text = "";
                    // Total No of Works
                    totalrowcount += rowcount - 1;
                    rowcount = 0;
                    //Set Color to  Row(Name=Total) 
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Cells[6].Text = "";


                    //Check column is in List or Not(checkbox checked or not)
                    if (data.DataView.Table.Columns["AA cost Rs in lakhs"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        grandTotal.AACost += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AA cost Rs in lakhs"));
                    }

                    if (data.DataView.Table.Columns["Technical Sanction Cost Rs in Lakh"] != null)
                    {
                        grandTotal.TsCost += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Technical Sanction Cost Rs in Lakh"));
                    }
                    if (data.DataView.Table.Columns["Estimated Cost Approved"] != null)
                    {
                        grandTotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Estimated Cost Approved"));
                    }
                    if (data.DataView.Table.Columns["Expenditure up to MAR 2017"] != null)
                    {
                        grandTotal.ExpUptoMarch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Expenditure up to MAR 2017"));
                    }
                    if (data.DataView.Table.Columns["Remaining Cost"] != null)
                    {
                        grandTotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Remaining Cost"));
                    }
                    if (data.DataView.Table.Columns["Budget Provision in 2017-18 Rs in Lakhs"] != null)
                    {
                        grandTotal.BudgetProvision += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Budget Provision in 2017-18 Rs in Lakhs"));
                    }
                    else
                    {
                        grandTotal.Budget_Index = 1;
                    }
                    if (data.DataView.Table.Columns["Demand for 2017-18 Rs in Lakhs"] != null)
                    {
                        grandTotal.Demand += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Demand for 2017-18 Rs in Lakhs"));
                    }
                    else
                    {
                        grandTotal.Demand_Index = 1;
                    }
                    if (data.DataView.Table.Columns["Expenditure up to 8/2016 during year 16-17 Rs in Lakhs"] != null)
                    {
                        grandTotal.ExpUpto_8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Expenditure up to 8/2016 during year 16-17 Rs in Lakhs"));
                    }
                    else
                    {
                        grandTotal.Exp_8_index = 1;
                    }
                    //CPNS
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        grandTotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        grandTotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        grandTotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        grandTotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        grandTotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    //End CPNS
					



                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        grandTotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    else
                    {
                        grandTotal.Apr_index = 1;
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        grandTotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    else
                    {
                        grandTotal.May_index = 1;
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        grandTotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    else
                    {
                        grandTotal.Jun_index = 1;
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        grandTotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    else
                    {
                        grandTotal.Jul_index = 1;
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        grandTotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    else
                    {
                        grandTotal.Aug_index = 1;
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        grandTotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    else
                    {
                        grandTotal.sep_index = 1;
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        grandTotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    else
                    {
                        grandTotal.Oct_index = 1;
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        grandTotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    else
                    {
                        grandTotal.Nov_index = 1;
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        grandTotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    else
                    {
                        grandTotal.Dec_index = 1;
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        grandTotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    else
                    {
                        grandTotal.Jan_index = 1;
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        grandTotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    else
                    {
                        grandTotal.Feb_index = 1;
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        grandTotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mar"));
                    }
                    else
                    {
                        grandTotal.Mar_index = 1;
                    }
                    if (data.DataView.Table.Columns["WBMI Km"] != null)
                    {
                        grandTotal.Wbm1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WBMI Km"));
                    }
                    else
                    {
                        grandTotal.Wbm1_index = 1;
                    }
                    if (data.DataView.Table.Columns["WBMII Km"] != null)
                    {
                        grandTotal.Wbm2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WBMII Km"));
                    }
                    else
                    {
                        grandTotal.Wbm2_index = 1;
                    }
                    if (data.DataView.Table.Columns["WBMIII Km"] != null)
                    {
                        grandTotal.Wbm3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WBMIII Km"));
                    }
                    else
                    {
                        grandTotal.Wbm3_index = 1;
                    }
                    if (data.DataView.Table.Columns["BBM Km"] != null)
                    {
                        grandTotal.Bbm += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BBM Km"));
                    }
                    else
                    {
                        grandTotal.Bbm_index = 1;
                    }
                    if (data.DataView.Table.Columns["Carpet Km"] != null)
                    {
                        grandTotal.Karpet += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Carpet Km"));
                    }
                    else
                    {
                        grandTotal.Karpet_index = 1;
                    }
                    if (data.DataView.Table.Columns["Surface Km"] != null)
                    {
                        grandTotal.Surface += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Surface Km"));
                    }
                    else
                    {
                        grandTotal.Surface_index = 1;
                    }
                    if (data.DataView.Table.Columns["Second Provision"] != null)
                    {
                        grandTotal.SecPro += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Second Provision"));
                    }
                    else
                    {
                        grandTotal.SecPro_index = 1;
                    }
                    if (data.DataView.Table.Columns["Third Provision"] != null)
                    {
                        grandTotal.TirdPro += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Third Provision"));
                    }
                    else
                    {
                        grandTotal.TirdPro_index = 1;
                    }
                    if (data.DataView.Table.Columns["Fourth Provision"] != null)
                    {
                        grandTotal.ForthPro += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fourth Provision"));
                    }
                    else
                    {
                        grandTotal.ForthPro_index = 1;
                    }
                    if (data.DataView.Table.Columns["Total Provision"] != null)
                    {
                        grandTotal.TotalPro += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Provision"));
                    }
                    else
                    {
                        grandTotal.TotalPro_index = 1;
                    }
                    if (data.DataView.Table.Columns["Total Grand"] != null)
                    {
                        grandTotal.AkunAnudan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Grand"));
                    }
                    else
                    {
                        grandTotal.AkunAnudan_index = 1;
                    }
                    if (data.DataView.Table.Columns["Current Cost"] != null)
                    {
                        grandTotal.Chalukharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Current Cost"));
                    }
                    else
                    {
                        grandTotal.Chalukharch_index = 1;
                    }
                    if (data.DataView.Table.Columns["Previous Cost"] != null)
                    {
                        grandTotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Previous Cost"));
                    }
                    else
                    {
                        grandTotal.Magilkharch_index = 1;
                    }
                    if (data.DataView.Table.Columns["Total Expense"] != null)
                    {
                        grandTotal.AkunKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Expense"));
                    }
                    else
                    {
                        grandTotal.AkunKharch_index = 1;
                    }
                    if (data.DataView.Table.Columns["Tender Amount"] != null)
                    {
                        grandTotal.TenderAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Tender Amount"));
                    }
                    else
                    {
                        grandTotal.TenderAmount_index = 1;
                    }
                    if (data.DataView.Table.Columns["CD_Works_No"] != null)
                    {
                        grandTotal.CdWork += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CD_Works_No"));
                    }
                    else
                    {
                        grandTotal.CdWork_Index = 1;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //Set Grand Total To Footer 
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[grandTotal.Total_index - 1].Text = "No of works: " + totalrowcount.ToString();
                e.Row.Cells[grandTotal.Total_index].Text = "Grand Total";
                e.Row.Cells[grandTotal.AACost_Index - 1].Text = grandTotal.AACost.ToString();
                e.Row.Cells[grandTotal.TsCost_index - 1].Text = grandTotal.TsCost.ToString();
                e.Row.Cells[grandTotal.ManjurAmt_index - 1].Text = grandTotal.ManjurAmt.ToString();
                e.Row.Cells[grandTotal.Expmar_Index - 1].Text = grandTotal.ExpUptoMarch.ToString();
                e.Row.Cells[grandTotal.UrvaritAmt_index - 1].Text = grandTotal.UrvaritAmt.ToString();
                e.Row.Cells[grandTotal.Budget_Index - 1].Text = grandTotal.BudgetProvision.ToString();
                e.Row.Cells[grandTotal.Demand_Index - 1].Text = grandTotal.Demand.ToString();
                e.Row.Cells[grandTotal.Exp_8_index - 1].Text = grandTotal.ExpUpto_8.ToString();

                //CPNS
                e.Row.Cells[grandTotal.C_index-1].Text = grandTotal.C.ToString();
                e.Row.Cells[grandTotal.P_index-1].Text = grandTotal.P.ToString();
                e.Row.Cells[grandTotal.NS_index-1].Text = grandTotal.NS.ToString();
                e.Row.Cells[grandTotal.ES_index-1].Text = grandTotal.ES.ToString();
                e.Row.Cells[grandTotal.TS_index-1].Text = grandTotal.TS.ToString();
                //End CPNS

                e.Row.Cells[grandTotal.Apr_index - 1].Text = grandTotal.Apr.ToString();
                e.Row.Cells[grandTotal.May_index - 1].Text = grandTotal.May.ToString();
                e.Row.Cells[grandTotal.Jun_index - 1].Text = grandTotal.Jun.ToString();
                e.Row.Cells[grandTotal.Jul_index - 1].Text = grandTotal.Jul.ToString();
                e.Row.Cells[grandTotal.Aug_index - 1].Text = grandTotal.Aug.ToString();
                e.Row.Cells[grandTotal.sep_index - 1].Text = grandTotal.sep.ToString();
                e.Row.Cells[grandTotal.Oct_index - 1].Text = grandTotal.Oct.ToString();
                e.Row.Cells[grandTotal.Nov_index - 1].Text = grandTotal.Nov.ToString();
                e.Row.Cells[grandTotal.Dec_index - 1].Text = grandTotal.Dec.ToString();
                e.Row.Cells[grandTotal.Jan_index - 1].Text = grandTotal.Jan.ToString();
                e.Row.Cells[grandTotal.Feb_index - 1].Text = grandTotal.Feb.ToString();
                e.Row.Cells[grandTotal.Mar_index - 1].Text = grandTotal.Mar.ToString();

                e.Row.Cells[grandTotal.Wbm1_index - 1].Text = grandTotal.Wbm1.ToString();
                e.Row.Cells[grandTotal.Wbm2_index - 1].Text = grandTotal.Wbm2.ToString();
                e.Row.Cells[grandTotal.Wbm3_index - 1].Text = grandTotal.Wbm3.ToString();
                e.Row.Cells[grandTotal.Bbm_index - 1].Text = grandTotal.Bbm.ToString();
                e.Row.Cells[grandTotal.Karpet_index - 1].Text = grandTotal.Karpet.ToString();
                e.Row.Cells[grandTotal.Surface_index - 1].Text = grandTotal.Surface.ToString();
                e.Row.Cells[grandTotal.SecPro_index - 1].Text = grandTotal.SecPro.ToString();
                e.Row.Cells[grandTotal.TirdPro_index - 1].Text = grandTotal.TirdPro.ToString();
                e.Row.Cells[grandTotal.ForthPro_index - 1].Text = grandTotal.ForthPro.ToString();
                e.Row.Cells[grandTotal.TotalPro_index - 1].Text = grandTotal.TotalPro.ToString();
                e.Row.Cells[grandTotal.AkunAnudan_index - 1].Text = grandTotal.AkunAnudan.ToString();
                e.Row.Cells[grandTotal.Chalukharch_index - 1].Text = grandTotal.Chalukharch.ToString();
                e.Row.Cells[grandTotal.Magilkharch_index - 1].Text = grandTotal.Magilkharch.ToString();
                e.Row.Cells[grandTotal.AkunKharch_index - 1].Text = grandTotal.AkunKharch.ToString();
                e.Row.Cells[grandTotal.TenderAmount_index - 1].Text = grandTotal.TenderAmount.ToString();
                e.Row.Cells[grandTotal.CdWork_Index - 1].Text = grandTotal.CdWork.ToString();
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
            pName = GridView1.DataKeys[e.NewSelectedIndex].Values["Work Id"].ToString();
            Response.Redirect("Send_sms.aspx?WorkID=" + pName + "");
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pName = GridView1.DataKeys[e.NewEditIndex].Values["Work Id"].ToString();
            Response.Redirect("MasterBudgetNABARD.aspx?WorkId=" + pName + "");
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterNabardReportSda"].ToString(), con);
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterNabardReportSda"].ToString(), con);
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
                SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterNabardReportSda"].ToString(), con);
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



        protected void ReportTypebtn_Click(object sender, EventArgs e)
        {
            txtno.Text = "13";
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = ddlReportType.Text;
            BindGrid();
            //BindReport();
            Label3.Text = "RIDF NO:- " + ddlReportType.Text;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string WorkId = e.Keys["Work Id"].ToString();
            strSqlCommand = "Delete From [BudgetMasterNABARD] Where [WorkId]='" + WorkId + "'";
            strSqlCommand1 = "Delete From [NABARDProvision] Where [WorkId]='" + WorkId + "'";
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
                //BindReport();
                BindGrid();
                GridView1.Columns[1].Visible = true;
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            con.Close();
        }

        public void GraphicsReport(string WhereCondition)
        {
            string[] arr1 = { "Completed", "Incomplete", "Inprogress", "Tender Stage", "Estimated Stage", "Not Started", "Estimated Cost", "T.S Cost", "Budget Provision", "Expenditure" };
           // decimal[] arr = new decimal[10];
           
            objGraph.GraphicsReports("[BudgetMasterNABARD]", "[NABARDProvision]", WhereCondition);

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