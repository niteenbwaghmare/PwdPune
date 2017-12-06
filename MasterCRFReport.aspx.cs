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

using DataLayer;


namespace PWdEEBudget
{
    public partial class MasterCRFReport : System.Web.UI.Page
    {
        string pName;
        string strSqlCommand = string.Empty;
        string strSqlCommand1 = string.Empty;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2 = null;
        string strSqlCommand2 = String.Empty;
        CRFGrandTotal crfgrandtotal = new CRFGrandTotal();
        int RowCount = 0, Totalwork = 0;
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
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "MyAction", "f1();", true);
            if (!IsPostBack)
            {
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
                    chkcrf.ClearSelection();
                    foreach (var item in chkcrf.Items.Cast<ListItem>().Where(li => li.Value == "a.[WorkId] as 'WorkId'" || li.Value == "" || li.Value == "a.[Arthsankalpiyyear] as 'Budget of Year'" || li.Value == "a.[KamacheName] as 'Name of Work'" || li.Value == "a.[LekhaShirshName] as 'Headwise'" || li.Value == "a.[Upvibhag] as 'Sub Division'" || li.Value == "a.[Taluka] as 'Taluka'" || li.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor'" || li.Value == "a.[PrashaskiyKramank] as 'Administrative No'" || li.Value == "a.[PrashaskiyDate] as 'A A Date'" || li.Value == "a.[PrashaskiyAmt] as 'A A Amount'" || li.Value == "a.[TrantrikKrmank] as 'Technical Sanction No'" || li.Value == "a.[TrantrikDate] as 'T S Date'" || li.Value == "a.[TrantrikAmt] as 'T S Amount'" || li.Value == "a.[Kamachavav] as 'Scope of Work'" || li.Value == "a.[karyarambhadesh] as 'Work Order'" || li.Value == "a.[kamachiMudat] as 'Work Order Date'" || li.Value == "a.[KamPurnDate] as 'Work Completion Date'" || li.Value == "b.[MudatVadhiDate] as 'Extension Month'" || li.Value == "b.[ManjurAmt] as 'Estimated Cost Approved'" || li.Value == "b.[MarchEndingExpn] as 'MarchEndingExpn'" || li.Value == "b.[UrvaritAmt] as 'Remaining Cost'" || li.Value == "b.[AikunKharch] as 'Total Expense'" || li.Value == "b.[Tartud] as 'Grand Provision'" || li.Value == "a.[Sadyasthiti] as 'Status'" || li.Value == "a.[Shera] as 'Remark'" || li.Value == "a.[NividaDate] as 'Tender Date'" || li.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'Tender Amount'" || li.Value == "a.[NividaKrmank] as 'Tender No'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || li.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'"))
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
                if (previousPageName == "MasterBudgetCRF.aspx" || previousPageName == "Send_sms.aspx" || previousPageName == "UploadImage.aspx")
                {
                    if (Session["MasterCRFRpt"] != null)
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterCRFReportSda"].ToString(), con);
                        //SqlDataAdapter sda1 = (SqlDataAdapter)Session["MasterCRFReportSda"];
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from CRFProvision Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from BudgetMasterCRF Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select [LekhaShirshName] from BudgetMasterCRF where [Arthsankalpiyyear]='" + ddlKamacheyear.SelectedItem.ToString() + "' Group By([LekhaShirshName])", con);
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
            if ((dt = (ObjsqlQueryOrCon.Bind_MasterReport_ddl("[BudgetMasterCRF]", ddlLekhashirsh.SelectedItem.ToString()))).Rows.Count > 0)
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
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag]desc) as 'SrNo', ";
            unionquery = "union select isNULL ('','')as'SrNo', ";
            isSelected = chkcrf.Items.Cast<ListItem>().Count(i => i.Selected == true) > 0;
            if (!isSelected)
            {
                chkcrf.Items[0].Selected = true;
            }
            foreach (ListItem item in chkcrf.Items)
            {
                if (item.Selected)
                {
                    if (item.Value == "a.[WorkId] as 'WorkId'" || item.Value == "a.[Arthsankalpiyyear] as 'Budget of Year'" || item.Value == "a.[Type] as 'Type'" || item.Value == "a.[Dist] as 'Dist'" || item.Value == "a.[Taluka] as 'Taluka'" || item.Value == "a.[ArthsankalpiyBab] as 'Budget of Item'" || item.Value == "a.[Upvibhag] as 'Sub Division'" || item.Value == "a.[LekhaShirsh] as 'Head'" || item.Value == "a.[LekhaShirshName] as 'Headwise'" || item.Value == "a.[SubType] as 'SubType'" || item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'Sectional Engineer'" || item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'Deputy Engineer'" || item.Value == "a.[KhasdaracheName] as 'MP'" || item.Value == "a.[AmdaracheName] as 'MLA'" || item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor'" || item.Value == "a.[KamacheName] as 'Name of Work'" || item.Value == "a.[Kamachavav] as 'Scope of Work'" || item.Value == "a.[PrashaskiyKramank] as 'Administrative No'" || item.Value == "a.[PrashaskiyDate] as 'A A Date'" || item.Value == "a.[PrashaskiyAmt] as 'A A Amount'" || item.Value == "a.[TrantrikKrmank] as 'Technical Sanction No'" || item.Value == "a.[TrantrikDate] as 'T S Date'" || item.Value == "a.[TrantrikAmt] as 'T S Amount'" || item.Value == "a.[NividaKrmank] as 'Tender No'" || item.Value == "cast(a.[NividaAmt] as decimal(10,2)) as 'Tender Amount'" || item.Value == "a.[karyarambhadesh] as 'Work Order'" || item.Value == "a.[NividaDate] as 'Tender Date'" || item.Value == "a.[kamachiMudat] as 'Work Order Date'" || item.Value == "a.[KamPurnDate] as 'Work Completion Date'" || item.Value == "a.[JobNo] as 'JobNo'" || item.Value == "a.[RoadNo] as 'Road Category'" || item.Value == "a.[RoadLength] as 'RoadLength'" || item.Value == "a.[SanctionDate] as 'SanctionDate'" || item.Value == "a.[SanctionAmount] as 'SanctionAmount'" || item.Value == "a.[APhysicalScope] as 'W.B.M Wide Phy Scope'" || item.Value == "a.[ACommulative] as 'W.B.M Wide Commulative'" || item.Value == "a.[ATarget] as 'W.B.M Wide Target'" || item.Value == "a.[AAchievement] as 'W.B.M Wide Achievement'" || item.Value == "a.[BPhysicalScope] as 'B.T Phy Scope'" || item.Value == "a.[BCommulative] as 'B.T Commulative'" || item.Value == "a.[BTarget] as 'B.T Target'" || item.Value == "a.[BAchievement] as 'B.T Achievement'" || item.Value == "a.[CPhysicalScope] as 'C.D Phy Scope'" || item.Value == "a.[CCommulative] as 'C.D Commulative'" || item.Value == "a.[CTarget] as 'C.D Target'" || item.Value == "a.[CAchievement] as 'C.D Achievement'" || item.Value == "a.[DPhysicalScope] as 'Minor Bridges Phy Scope(Nos)'" || item.Value == "a.[DCommulative] as 'Minor Bridges Commulative(Nos)'" || item.Value == "a.[DTarget] as 'Minor Bridges Target(Nos)'" || item.Value == "a.[DAchievement] as 'Minor Bridges Achievement(Nos)'" || item.Value == "a.[EPhysicalScope] as 'Major Bridges Phy Scope(Nos)'" || item.Value == "a.[ECommulative] as 'Major Bridges Commulative(Nos)'" || item.Value == "a.[ETarget] as 'Major Bridges Target(Nos)'" || item.Value == "a.[EAchievement] as 'Major Bridges Achievement(Nos)'" || item.Value == "a.[Pahanikramank] as 'Observation No'" || item.Value == "a.[PahaniMudye] as 'Observation Memo'" || item.Value == "a.[Shera] as 'Remark'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES'" || item.Value == "CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS'")
                    {
                        query += item.Value + ",";
                        if (item.Value == "a.[WorkId] as 'WorkId'")
                        {
                            unionquery += "'Total' as 'WorkId',";
                        }
                        if (item.Value == "a.[Arthsankalpiyyear] as 'Budget of Year'")
                        {
                            unionquery += "isNULL (a.[Arthsankalpiyyear],'') as 'Arthsankalpiyyear',";
                        }
                        if (item.Value == "a.[Type] as 'Type'")
                        {
                            unionquery += "isNULL ('','') as 'Type',";
                        }
                        if (item.Value == "a.[Dist] as 'Dist'")
                        {
                            unionquery += "isNULL ('','') as 'Dist',";
                        }
                        if (item.Value == "a.[Taluka] as 'Taluka'")
                        {
                            unionquery += "isNULL ('','') as 'Taluka',";
                        }
                        if (item.Value == "a.[ArthsankalpiyBab] as 'Budget of Item'")
                        {
                            unionquery += "isNULL ('','') as 'Budget of Item',";
                        }
                        if (item.Value == "a.[Upvibhag] as 'Sub Division'")
                        {
                            unionquery += "isNULL ('','') as 'Sub Division',";
                        }
                        if (item.Value == "a.[LekhaShirsh] as 'Head'")
                        {
                            unionquery += "isNULL ('','') as 'Head',";
                        }
                        if (item.Value == "a.[LekhaShirshName] as 'Headwise'")
                        {
                            unionquery += "isNULL ('','') as 'Headwise',";
                        }
                        if (item.Value == "a.[SubType] as 'SubType'")
                        {
                            unionquery += "isNULL ('','') as 'SubType',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'Sectional Engineer'")
                        {
                            unionquery += "isNULL ('','') as 'Sectional Engineer',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'Deputy Engineer'")
                        {
                            unionquery += "isNULL ('','') as 'Deputy Engineer',";
                        }
                        if (item.Value == "a.[KhasdaracheName] as 'MP'")
                        {
                            unionquery += "isNULL ('','') as 'MP',";
                        }
                        if (item.Value == "a.[AmdaracheName] as 'MLA'")
                        {
                            unionquery += "isNULL ('','') as 'MLA',";
                        }
                        if (item.Value == "convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor'")
                        {
                            unionquery += "isNULL ('','') as 'Contractor',";
                        }
                        if (item.Value == "a.[KamacheName] as 'Name of Work'")
                        {
                            unionquery += "isNULL ('','') as 'Name of Work',";
                        }
                        if (item.Value == "a.[Kamachavav] as 'Scope of Work'")
                        {
                            unionquery += "isNULL ('','') as 'Scope of Work',";
                        }
                        if (item.Value == "a.[PrashaskiyKramank] as 'Administrative No'")
                        {
                            unionquery += "isNULL ('','') as 'Administrative No',";
                        }
                        if (item.Value == "a.[PrashaskiyDate] as 'A A Date'")
                        {
                            unionquery += "isNULL ('','') as 'A A Date',";
                        }
                        if (item.Value == "a.[PrashaskiyAmt] as 'A A Amount'")
                        {
                            unionquery += "sum(cast(a.[PrashaskiyAmt] as decimal(10,0))) as 'A A Amount',";
                        }
                        if (item.Value == "a.[TrantrikKrmank] as 'Technical Sanction No'")
                        {
                            unionquery += "isNULL ('','') as 'Technical Sanction No',";
                        }
                        if (item.Value == "a.[TrantrikDate] as 'T S Date'")
                        {
                            unionquery += "isNULL ('','') as 'T S Date',";
                        }
                        if (item.Value == "a.[TrantrikAmt] as 'T S Amount'")
                        {
                            unionquery += "sum(cast(a.[TrantrikAmt]as decimal(10,0))) as 'T S Amount',";
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
                        if (item.Value == "a.[JobNo] as 'JobNo'")
                        {
                            unionquery += "isNULL ('','') as 'JobNo',";
                        }
                        if (item.Value == "a.[RoadNo] as 'Road Category'")
                        {
                            unionquery += "isNULL ('','') as 'Road Category',";
                        }
                        if (item.Value == "a.[RoadLength] as 'RoadLength'")
                        {
                            unionquery += "isNULL ('','') as 'RoadLength',";
                        }
                        if (item.Value == "a.[SanctionDate] as 'SanctionDate'")
                        {
                            unionquery += "isNULL ('','') as 'SanctionDate',";
                        }
                        if (item.Value == "a.[SanctionAmount] as 'SanctionAmount'")
                        {
                            unionquery += "sum(a.[SanctionAmount]) as 'SanctionAmount',";
                        }

                        /* Newly Added columns*/
                        if (item.Value == "a.[APhysicalScope] as 'W.B.M Wide Phy Scope'")
                        {
                            unionquery += "sum(a.[APhysicalScope]) as 'W.B.M Wide Phy Scope',";
                        }
                        if (item.Value == "a.[ACommulative] as 'W.B.M Wide Commulative'")
                        {
                            unionquery += "sum(a.[ACommulative]) as 'W.B.M Wide Commulative',";
                        }
                        if (item.Value == "a.[ATarget] as 'W.B.M Wide Target'")
                        {
                            unionquery += "sum(a.[ATarget]) as 'W.B.M Wide Target',";
                        }
                        if (item.Value == "a.[AAchievement] as 'W.B.M Wide Achievement'")
                        {
                            unionquery += "sum(a.[AAchievement]) as 'W.B.M Wide Achievement',";
                        }
                        if (item.Value == "a.[BPhysicalScope] as 'B.T Phy Scope'")
                        {
                            unionquery += "sum(a.[BPhysicalScope]) as 'B.T Phy Scope',";
                        }
                        if (item.Value == "a.[BCommulative] as 'B.T Commulative'")
                        {
                            unionquery += "sum(a.[BCommulative]) as 'B.T Commulative',";
                        }
                        if (item.Value == "a.[BTarget] as 'B.T Target'")
                        {
                            unionquery += "sum(a.[BTarget]) as 'B.T Target',";
                        }
                        if (item.Value == "a.[BAchievement] as 'B.T Achievement'")
                        {
                            unionquery += "sum(a.[BAchievement]) as 'B.T Achievement',";
                        }
                        if (item.Value == "a.[CPhysicalScope] as 'C.D Phy Scope'")
                        {
                            unionquery += "sum(a.[CPhysicalScope]) as 'C.D Phy Scope',";
                        }
                        if (item.Value == "a.[CCommulative] as 'C.D Commulative'")
                        {
                            unionquery += "sum(a.[CCommulative]) as 'C.D Commulative',";
                        }
                        if (item.Value == "a.[CTarget] as 'C.D Target'")
                        {
                            unionquery += "sum(a.[CTarget]) as 'C.D Target',";
                        }
                        if (item.Value == "a.[CAchievement] as 'C.D Achievement'")
                        {
                            unionquery += "sum(a.[CAchievement]) as 'C.D Achievement',";
                        }
                        if (item.Value == "a.[DPhysicalScope] as 'Minor Bridges Phy Scope(Nos)'")
                        {
                            unionquery += "sum(a.[DPhysicalScope]) as 'Minor Bridges Phy Scope(Nos)',";
                        }
                        if (item.Value == "a.[DCommulative] as 'Minor Bridges Commulative(Nos)'")
                        {
                            unionquery += "sum(a.[DCommulative]) as 'Minor Bridges Commulative(Nos)',";
                        }
                        if (item.Value == "a.[DTarget] as 'Minor Bridges Target(Nos)'")
                        {
                            unionquery += "sum(a.[DTarget]) as 'Minor Bridges Target(Nos)',";
                        }
                        if (item.Value == "a.[DAchievement] as 'Minor Bridges Achievement(Nos)'")
                        {
                            unionquery += "sum(a.[DAchievement]) as 'Minor Bridges Achievement(Nos)',";
                        }
                        if (item.Value == "a.[EPhysicalScope] as 'Major Bridges Phy Scope(Nos)'")
                        {
                            unionquery += "sum(a.[EPhysicalScope]) as 'Major Bridges Phy Scope(Nos)',";
                        }
                        if (item.Value == "a.[ECommulative] as 'Major Bridges Commulative(Nos)'")
                        {
                            unionquery += "sum(a.[ECommulative]) as 'Major Bridges Commulative(Nos)',";
                        }
                        if (item.Value == "a.[ETarget] as 'Major Bridges Target(Nos)'")
                        {
                            unionquery += "sum(a.[ETarget]) as 'Major Bridges Target(Nos)',";
                        }
                        if (item.Value == "a.[EAchievement] as 'Major Bridges Achievement(Nos)'")
                        {
                            unionquery += "sum(a.[EAchievement]) as 'Major Bridges Achievement(Nos)',";
                        }
                        /* End of Newly Added columns*/


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
                        if (item.Value == "a.[Pahanikramank] as 'Observation No'")
                        {
                            unionquery += "isNULL ('','') as 'Observation No',";
                        }
                        if (item.Value == "a.[PahaniMudye] as 'Observation Memo'")
                        {
                            unionquery += "isNULL ('','') as 'Observation Memo',";
                        }
                        if (item.Value == "a.[Shera] as 'Remark'")
                        {
                            unionquery += "isNULL ('','') as 'Remark',";
                        }
                        isSelected = true;
                    }
                    if (item.Value == "b.[MudatVadhiDate] as 'Extension Month'" || item.Value == "b.[DeyakachiSadyasthiti] as 'Bill Status'" || item.Value == "b.[ManjurAmt] as 'Estimated Cost Approved'" || item.Value == "b.[MarchEndingExpn] as 'MarchEndingExpn'" || item.Value == "b.[UrvaritAmt] as 'Remaining Cost'" || item.Value == "b.[DTakunone] as 'First Provision Month'" || item.Value == "b.[Takunone] as 'First Provision'" || item.Value == "b.[DTakuntwo] as 'Second Provision Month'" || item.Value == "b.[Takuntwo] as 'Second Provision'" || item.Value == "b.[DTakunthree] as 'Third Provision Month'" || item.Value == "b.[Takunthree] as 'Third Provision'" || item.Value == "b.[DTakunfour] as 'Fourth Provision Month'" || item.Value == "b.[Takunfour] as 'Fourth Provision'" || item.Value == "b.[Tartud] as 'Grand Provision'" || item.Value == "b.[AkunAnudan] as 'Total Grand'" || item.Value == "b.[Chalumonth] as 'Current Month'" || item.Value == "b.[Chalukharch] as 'Current Cost'" || item.Value == "b.[Magilmonth] as 'Previous Month'" || item.Value == "b.[Magilkharch] as 'Previous Cost'" || item.Value == "b.[OtherExpen] as 'Other Expense'" || item.Value == "b.[ExpenCost] as 'Electricity Cost'" || item.Value == "b.[ExpenExpen] as 'Electricity Expense'" || item.Value == "b.[Magni] as 'Demand'" || item.Value == "b.[VarshbharatilKharch] as 'Annual Expense'" || item.Value == "b.[AikunKharch] as 'Total Expense'" || item.Value == "b.[Apr] as 'Apr'" || item.Value == "b.[May] as 'May'" || item.Value == "b.[Jun] as 'Jun'" || item.Value == "b.[Jul] as 'Jul'" || item.Value == "b.[Aug] as 'Aug'" || item.Value == "b.[Sep] as 'Sep'" || item.Value == "b.[Oct] as 'Oct'" || item.Value == "b.[Nov] as 'Nov'" || item.Value == "b.[Dec] as 'Dec'" || item.Value == "b.[Jan] as 'Jan'" || item.Value == "b.[Feb] as 'Feb'" || item.Value == "b.[Mar] as 'Mar'" || item.Value == "b.[Magni] as 'Demand for 2016-17 Rs in Lakhs'" || item.Value == "b.[VarshbharatilKharch] as 'Expenditure up to 8/2016 during year 16-17 Rs in Lakhs'")
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
                        if (item.Value == "b.[MarchEndingExpn] as 'MarchEndingExpn'")
                        {
                            unionquery += "sum(b.[MarchEndingExpn]) as 'MarchEndingExpn',";
                        }
                        if (item.Value == "b.[UrvaritAmt] as 'Remaining Cost'")
                        {
                            unionquery += "sum(b.[UrvaritAmt]) as 'Remaining Cost',";
                        }
                        if (item.Value == "b.[DTakunone] as 'First Provision Month'")
                        {
                            unionquery += "isNULL ('','') as 'First Provision Month',";
                        }
                        if (item.Value == "b.[Takunone] as 'First Provision'")
                        {
                            unionquery += "sum(b.[Takunone]) as 'First Provision',";
                        }
                        if (item.Value == "b.[DTakuntwo] as 'Second Provision Month'")
                        {
                            unionquery += "isNULL ('','') as 'Second Provision Month',";
                        }
                        if (item.Value == "b.[Takuntwo] as 'Second Provision'")
                        {
                            unionquery += "sum(b.[Takuntwo]) as 'Second Provision',";
                        }
                        if (item.Value == "b.[DTakunthree] as 'Third Provision Month'")
                        {
                            unionquery += "isNULL ('','') as 'Third Provision Month',";
                        }
                        if (item.Value == "b.[Takunthree] as 'Third Provision'")
                        {
                            unionquery += "sum(b.[Takunthree]) as 'Third Provision',";
                        }
                        if (item.Value == "b.[DTakunfour] as 'Fourth Provision Month'")
                        {
                            unionquery += "isNULL ('','') as 'Fourth Provision Month',";
                        }
                        if (item.Value == "b.[Takunfour] as 'Fourth Provision'")
                        {
                            unionquery += "sum(b.[Takunfour]) as 'Fourth Provision',";
                        }
                        if (item.Value == "b.[Tartud] as 'Grand Provision'")
                        {
                            unionquery += "sum(b.[Tartud]) as 'Grand Provision',";
                        }
                        if (item.Value == "b.[AkunAnudan] as 'Total Grand'")
                        {
                            unionquery += "sum(b.[AkunAnudan]) as 'Total Grand',";
                        }
                        if (item.Value == "b.[Chalumonth] as 'Current Month'")
                        {
                            unionquery += "isNULL ('','') as 'Current Month',";
                        }
                        if (item.Value == "b.[Chalukharch] as 'Current Cost'")
                        {
                            unionquery += "sum(b.[Chalukharch]) as 'Current Cost',";
                        }
                        if (item.Value == "b.[Magilmonth] as 'Previous Month'")
                        {
                            unionquery += "isNULL ('','') as 'Previous Month',";
                        }
                        if (item.Value == "b.[Magilkharch] as 'Previous Cost'")
                        {
                            unionquery += "sum(b.[Magilkharch]) as 'Previous Cost',";
                        }
                        /* Newly added columns*/
                        if (item.Value == "b.[OtherExpen] as 'Other Expense'")
                        {
                            unionquery += "sum(b.[OtherExpen]) as 'Other Expense',";
                        }
                        if (item.Value == "b.[ExpenCost] as 'Electricity Cost'")
                        {
                            unionquery += "sum(b.[ExpenCost]) as 'Electricity Cost',";
                        }
                        if (item.Value == "b.[ExpenExpen] as 'Electricity Expense'")
                        {
                            unionquery += "sum(b.[ExpenExpen]) as 'Electricity Expense',";
                        }
                        /* End of newly added columns*/
                        if (item.Value == "b.[Magni] as 'Demand'")
                        {
                            unionquery += "sum(b.[Magni]) as 'Demand',";
                        }
                        if (item.Value == "b.[VarshbharatilKharch] as 'Annual Expense'")
                        {
                            unionquery += "sum(b.[VarshbharatilKharch]) as 'Annual Expense',";
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
                        if (item.Value == "b.[Magni] as 'Demand for 2016-17 Rs in Lakhs'")
                        {
                            unionquery += "sum(b.[Magni]) as 'Demand for 2016-17 Rs in Lakhs',";
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
            //Place In BindGrid()

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
            dt = ObjBindGrid.BindGrid(year, lekha, ddl, value, ddlArthYear.Text, query, unionquery, "BudgetMasterCRF", "CRFProvision");
            Session["MasterCRFReportSda"] = ObjBindGrid.SessionQuery;
            // da.Fill(dt);
            GridView1.DataSource = dt;

            GridView1.DataBind();
            GridView1.Columns[1].Visible = false;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            Session["MasterCRFRpt"] = GridView1;
            ListMenu.Style.Add("display", "none");
            GraphicsReport(ObjBindGrid.WhereCondition);

        }


        protected void btnlekhashirsh_Click(object sender, EventArgs e)
        {

            txtno.Text = "1";
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";
            BindGrid();
            //BindReport();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString();
        }

        protected void btnupvibhag_Click(object sender, EventArgs e)
        {
            txtno.Text = "2";
            Session["ddl"] = "a.[upvibhag]=N";
            Session["ddlvalue"] = ddlUpvibhag.Text;
            BindGrid();
            // BindReport();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "उपविभाग:-" + ddlUpvibhag.SelectedItem.ToString();
        }

        protected void btnjilha_Click(object sender, EventArgs e)
        {
            txtno.Text = "3";
            Session["ddl"] = "a.[Dist]=N";
            Session["ddlvalue"] = ddlJilha.Text;
            BindGrid();
            //BindReport();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "जिल्हा:-" + ddlJilha.SelectedItem.ToString();
        }

        protected void btntaluka_Click(object sender, EventArgs e)
        {
            txtno.Text = "4";
            Session["ddl"] = "a.[Taluka]=N";
            Session["ddlvalue"] = ddlTaluka.Text;
            BindGrid();
            //BindReport();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "तालुका:-" + ddlTaluka.SelectedItem.ToString();
        }

        protected void btnworkid_Click(object sender, EventArgs e)
        {
            txtno.Text = "5";
            Session["ddl"] = "a.[WorkId]=N";
            Session["ddlvalue"] = ddlworkid.Text;
            BindGrid();
            //BindReport();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "Work_ID:-" + ddlworkid.SelectedItem.ToString();
        }

        protected void btnabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "6";
            Session["ddl"] = "a.[ShakhaAbhyantaName]=N";
            Session["ddlvalue"] = ddlShakhaAbhiyanta.Text;
            BindGrid();
            //BindReport();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "शाखा अभियंता:-" + ddlShakhaAbhiyanta.SelectedItem.ToString();
        }

        protected void btnupabhiyanta_Click(object sender, EventArgs e)
        {
            txtno.Text = "7";
            Session["ddl"] = "a.[UpabhyantaName]=N";
            Session["ddlvalue"] = ddlShakhUpAbhiyanta.Text;
            BindGrid();
            //BindReport();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "शाखा उपभियांता:-" + ddlShakhUpAbhiyanta.SelectedItem.ToString();
        }

        protected void btnamdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "8";
            Session["ddl"] = "a.[AmdaracheName]=N";
            Session["ddlvalue"] = ddlAmdar.Text;
            BindGrid();
            // BindReport();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "आमदार:-" + ddlAmdar.SelectedItem.ToString();
        }

        protected void btnkhasdar_Click(object sender, EventArgs e)
        {
            txtno.Text = "9";
            Session["ddl"] = "a.[KhasdaracheName]=N";
            Session["ddlvalue"] = ddlKhasdar.Text;
            BindGrid();
            // BindReport();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "खासदार:-" + ddlKhasdar.SelectedItem.ToString();
        }

        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            txtno.Text = "10";
            Session["ddl"] = "a.[ThekedaarName]=N";
            Session["ddlvalue"] = ddlThekedarecheName.Text;
            BindGrid();
            //BindReport();
            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "ठेकेदाराचे नाव:-" + ddlThekedarecheName.SelectedItem.ToString();
        }

        protected void btnkamachistiti_Click(object sender, EventArgs e)
        {
            txtno.Text = "11";
            Session["ddl"] = "a.[Sadyasthiti]=N";
            Session["ddlvalue"] = ddlKamachiSadyStiti.Text;
            BindGrid();

            Label3.Text = "लेखाशीर्ष:-" + ddlLekhashirsh.SelectedItem.ToString() + "<br> " + "कामाची सद्यस्थिती:-" + ddlKamachiSadyStiti.SelectedItem.ToString();
        }
        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            txtno.Text = "12";
            Session["ddl"] = "संपूर्ण";
            Session["ddlvalue"] = "संपूर्ण";
            BindGrid();
            Label3.Text = "कामचे वर्ष :- " + ddlKamacheyear.Text.Split('-')[0];
            //  BindGrid();
        }
        protected void chkBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MasterCRFReport.xls");
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

            Session["filename"] = "MasterCRFReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "MasterCRFReport.xls");
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
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridView1.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=2&PrevPage=MasterCRFReport.aspx";
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
                crfgrandtotal.index(HeadrName);
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var data = e.Row.DataItem as DataRowView;
                RowCount++;
                // do your stuffs here, for example if column Total as workId is your third column: compaire Total Key Word
                //e.Row.Cells[3].BackColor = System.Drawing.Color.Pink;
                if (e.Row.Cells[crfgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[crfgrandtotal.Total_index - 1].Text = (RowCount - 1).ToString();
                    Totalwork += RowCount - 1;
                    RowCount = 0;
                    e.Row.Cells[crfgrandtotal.Total_index + 1].Text = "";
                    e.Row.Cells[crfgrandtotal.Total_index - 2].Text = "";
                    e.Row.BackColor = System.Drawing.Color.Bisque;

                    //Check column is in List or Not(checkbox checked or not)
                    if (data.DataView.Table.Columns["A A Amount"] != null)
                    {
                        crfgrandtotal.AAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "A A Amount"));
                    }

                    if (data.DataView.Table.Columns["T S Amount"] != null)
                    {
                        crfgrandtotal.TSAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "T S Amount"));
                    }
                    if (data.DataView.Table.Columns["SanctionAmount"] != null)
                    {
                        crfgrandtotal.SantionAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SanctionAmount"));
                    }
                    if (data.DataView.Table.Columns["Estimated Cost Approved"] != null)
                    {
                        crfgrandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Estimated Cost Approved"));
                    }

                    if (data.DataView.Table.Columns["MarchEndingExpn"] != null)
                    {
                        crfgrandtotal.MarchEnding += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MarchEndingExpn"));
                    }
                    if (data.DataView.Table.Columns["Remaining Cost"] != null)
                    {
                        crfgrandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Remaining Cost"));
                    }
                    if (data.DataView.Table.Columns["First Provision"] != null)
                    {
                        crfgrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "First Provision"));
                    }
                    if (data.DataView.Table.Columns["Second Provision"] != null)
                    {
                        crfgrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Second Provision"));
                    }
                    if (data.DataView.Table.Columns["Third Provision"] != null)
                    {
                        crfgrandtotal.Takunthree += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Third Provision"));
                    }
                    if (data.DataView.Table.Columns["Fourth Provision"] != null)
                    {
                        crfgrandtotal.Takunfour += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fourth Provision"));
                    }
                    if (data.DataView.Table.Columns["Grand Provision"] != null)
                    {
                        crfgrandtotal.Tartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Grand Provision"));
                    }
                    if (data.DataView.Table.Columns["Total Grand"] != null)
                    {
                        crfgrandtotal.Akunanudan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Grand"));
                    }
                    if (data.DataView.Table.Columns["Current Cost"] != null)
                    {
                        crfgrandtotal.Chalukharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Current Cost"));
                    }
                    if (data.DataView.Table.Columns["Previous Cost"] != null)
                    {
                        crfgrandtotal.Maghilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Previous Cost"));
                    }
                    if (data.DataView.Table.Columns["Demand"] != null)
                    {
                        crfgrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Demand"));
                    }
                    if (data.DataView.Table.Columns["Annual Expense"] != null)
                    {
                        crfgrandtotal.VarshbharatilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Annual Expense"));
                    }
                    if (data.DataView.Table.Columns["Total Expense"] != null)
                    {
                        crfgrandtotal.AikunKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Expense"));
                    }
                    //CPNS
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        crfgrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        crfgrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        crfgrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        crfgrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        crfgrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    //End CPNS

                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        crfgrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        crfgrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        crfgrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        crfgrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        crfgrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        crfgrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        crfgrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        crfgrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        crfgrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        crfgrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        crfgrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        crfgrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mar"));
                    }


                    if (data.DataView.Table.Columns["W.B.M Wide Phy Scope"] != null)
                    {
                        //crfgrandtotal.WideScope += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "W.B.M Wide Phy Scope"));
                        crfgrandtotal.WideScope += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.WideScope_index].Text);
                    }
                    if (data.DataView.Table.Columns["W.B.M Wide Commulative"] != null)
                    {
                        //crfgrandtotal.WideCommulative += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "W.B.M Wide Commulative"));
                        crfgrandtotal.WideCommulative += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.WideCommulative_index].Text);
                    }
                    if (data.DataView.Table.Columns["W.B.M Wide Target"] != null)
                    {
                        //crfgrandtotal.WideTarget += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "W.B.M Wide Target"));
                        crfgrandtotal.WideTarget += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.WideTarget_index].Text);
                    }
                    if (data.DataView.Table.Columns["W.B.M Wide Achievement"] != null)
                    {
                        //crfgrandtotal.WideAchivement += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "W.B.M Wide Achievement"));
                        crfgrandtotal.WideAchivement += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.WideAchivement_index].Text);
                    }

                    if (data.DataView.Table.Columns["B.T Phy Scope"] != null)
                    {
                        //crfgrandtotal.BTScope += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "B.T Phy Scope"));
                        crfgrandtotal.BTScope += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.BTScope_index].Text);
                    }
                    if (data.DataView.Table.Columns["B.T Commulative"] != null)
                    {
                        //crfgrandtotal.BTCommulative += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "B.T Commulative"));
                        crfgrandtotal.BTCommulative += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.BTCommulative_index].Text);
                    }
                    if (data.DataView.Table.Columns["B.T Target"] != null)
                    {
                        //crfgrandtotal.BTTarget += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "B.T Target"));
                        crfgrandtotal.BTTarget += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.BTTarget_index].Text);
                    }
                    if (data.DataView.Table.Columns["B.T Achievement"] != null)
                    {
                        //crfgrandtotal.BTAchivement += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "B.T Achievement"));
                        crfgrandtotal.BTAchivement += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.BTAchivement_index].Text);
                    }

                    if (data.DataView.Table.Columns["C.D Phy Scope"] != null)
                    {
                        //crfgrandtotal.CDScope += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C.D Phy Scope"));
                        crfgrandtotal.CDScope += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.CDScope_index].Text);
                    }
                    if (data.DataView.Table.Columns["C.D Commulative"] != null)
                    {
                        //crfgrandtotal.CDCommulative += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C.D Commulative"));
                        crfgrandtotal.CDCommulative += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.CDCommulative_index].Text);
                    }
                    if (data.DataView.Table.Columns["C.D Target"] != null)
                    {
                        // crfgrandtotal.CDTarget += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C.D Target"));
                        crfgrandtotal.CDTarget += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.CDTarget_index].Text);
                    }
                    if (data.DataView.Table.Columns["C.D Achievement"] != null)
                    {
                        //crfgrandtotal.CDAchivement += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C.D Achievement"));
                        crfgrandtotal.CDAchivement += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.CDAchivement_index].Text);
                    }

                    if (data.DataView.Table.Columns["Minor Bridges Phy Scope(Nos)"] != null)
                    {
                        //crfgrandtotal.MinorScope += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Minor Bridges Phy Scope(Nos)"));
                        crfgrandtotal.MinorScope += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.MinorScope_index].Text);
                    }
                    if (data.DataView.Table.Columns["Minor Bridges Commulative(Nos)"] != null)
                    {
                        //crfgrandtotal.MinorCommulative += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Minor Bridges Commulative(Nos)"));
                        crfgrandtotal.MinorCommulative += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.MinorCommulative_index].Text);
                    }
                    if (data.DataView.Table.Columns["Minor Bridges Target(Nos)"] != null)
                    {
                        //crfgrandtotal.MinorTarget += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Minor Bridges Target(Nos)"));
                        crfgrandtotal.MinorTarget += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.MinorTarget_index].Text);
                    }
                    if (data.DataView.Table.Columns["Minor Bridges Achievement(Nos)"] != null)
                    {
                        //crfgrandtotal.MinorAchivement += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Minor Bridges Achievement(Nos)"));
                        crfgrandtotal.MinorAchivement += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.MinorAchivement_index].Text);
                    }

                    if (data.DataView.Table.Columns["Major Bridges Phy Scope(Nos)"] != null)
                    {
                        //crfgrandtotal.MjorScope += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Major Bridges Phy Scope(Nos)"));
                        crfgrandtotal.MjorScope += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.MjorScope_index].Text);
                    }
                    if (data.DataView.Table.Columns["Major Bridges Commulative(Nos)"] != null)
                    {
                        //crfgrandtotal.MajorCommulative += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Major Bridges Commulative(Nos)"));
                        crfgrandtotal.MajorCommulative += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.MajorCommulative_index].Text);
                    }
                    if (data.DataView.Table.Columns["Major Bridges Target(Nos)"] != null)
                    {
                        //crfgrandtotal.MajorTarget += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Major Bridges Target(Nos)"));
                        crfgrandtotal.MajorTarget += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.MajorTarget_index].Text);
                    }
                    if (data.DataView.Table.Columns["Major Bridges Achievement(Nos)"] != null)
                    {
                        //crfgrandtotal.MajorAchivement+= Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Major Bridges Achievement(Nos)"));
                        crfgrandtotal.MajorAchivement += Convert.ToDecimal(e.Row.Cells[crfgrandtotal.MajorAchivement_index].Text);
                    }

                    if (data.DataView.Table.Columns["Other Expense"] != null)
                    {
                        crfgrandtotal.OtherExpen += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Other Expense"));
                    }
                    if (data.DataView.Table.Columns["Electricity Cost"] != null)
                    {
                        crfgrandtotal.ElectriCost += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Electricity Cost"));
                    }
                    if (data.DataView.Table.Columns["Electricity Expense"] != null)
                    {
                        crfgrandtotal.ElectriExpen += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Electricity Expense"));
                    }
                    if (data.DataView.Table.Columns["Tender Amount"] != null)
                    {
                        crfgrandtotal.TenderAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Tender Amount"));
                    }

                }
            }



            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[crfgrandtotal.Total_index - 1].Text = "No Of Work = " + Totalwork.ToString();
                e.Row.Cells[crfgrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[crfgrandtotal.AAmount_index].Text = crfgrandtotal.AAmount.ToString();
                e.Row.Cells[crfgrandtotal.TSAmount_index].Text = crfgrandtotal.TSAmount.ToString();
                e.Row.Cells[crfgrandtotal.SantionAmount_index].Text = crfgrandtotal.SantionAmount.ToString();
                e.Row.Cells[crfgrandtotal.ManjurAmt_index].Text = crfgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[crfgrandtotal.MarchEnding_index].Text = crfgrandtotal.MarchEnding.ToString();
                e.Row.Cells[crfgrandtotal.UrvaritAmt_index].Text = crfgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[crfgrandtotal.Takunone_index].Text = crfgrandtotal.Takunone.ToString();
                e.Row.Cells[crfgrandtotal.Takuntwo_index].Text = crfgrandtotal.Takuntwo.ToString();
                e.Row.Cells[crfgrandtotal.Takunthree_index].Text = crfgrandtotal.Takunthree.ToString();
                e.Row.Cells[crfgrandtotal.Takunfour_index].Text = crfgrandtotal.Takunfour.ToString();
                e.Row.Cells[crfgrandtotal.Tartud_index].Text = crfgrandtotal.Tartud.ToString();
                e.Row.Cells[crfgrandtotal.Akunanudan_index].Text = crfgrandtotal.Akunanudan.ToString();
                e.Row.Cells[crfgrandtotal.Chalukharch_index].Text = crfgrandtotal.Chalukharch.ToString();
                e.Row.Cells[crfgrandtotal.Maghilkharch_index].Text = crfgrandtotal.Maghilkharch.ToString();
                e.Row.Cells[crfgrandtotal.Magni_index].Text = crfgrandtotal.Magni.ToString();
                e.Row.Cells[crfgrandtotal.VarshbharatilKharch_index].Text = crfgrandtotal.VarshbharatilKharch.ToString();
                e.Row.Cells[crfgrandtotal.AikunKharch_index].Text = crfgrandtotal.AikunKharch.ToString();
                //CPNS
                e.Row.Cells[crfgrandtotal.C_index].Text = crfgrandtotal.C.ToString();
                e.Row.Cells[crfgrandtotal.P_index].Text = crfgrandtotal.P.ToString();
                e.Row.Cells[crfgrandtotal.NS_index].Text = crfgrandtotal.NS.ToString();
                e.Row.Cells[crfgrandtotal.ES_index].Text = crfgrandtotal.ES.ToString();
                e.Row.Cells[crfgrandtotal.TS_index].Text = crfgrandtotal.TS.ToString();
                //End CPNS


                e.Row.Cells[crfgrandtotal.Apr_index].Text = crfgrandtotal.Apr.ToString();
                e.Row.Cells[crfgrandtotal.May_index].Text = crfgrandtotal.May.ToString();
                e.Row.Cells[crfgrandtotal.Jun_index].Text = crfgrandtotal.Jun.ToString();
                e.Row.Cells[crfgrandtotal.Jul_index].Text = crfgrandtotal.Jul.ToString();
                e.Row.Cells[crfgrandtotal.Aug_index].Text = crfgrandtotal.Aug.ToString();
                e.Row.Cells[crfgrandtotal.sep_index].Text = crfgrandtotal.sep.ToString();
                e.Row.Cells[crfgrandtotal.Oct_index].Text = crfgrandtotal.Oct.ToString();
                e.Row.Cells[crfgrandtotal.Nov_index].Text = crfgrandtotal.Nov.ToString();
                e.Row.Cells[crfgrandtotal.Dec_index].Text = crfgrandtotal.Dec.ToString();
                e.Row.Cells[crfgrandtotal.Jan_index].Text = crfgrandtotal.Jan.ToString();
                e.Row.Cells[crfgrandtotal.Feb_index].Text = crfgrandtotal.Feb.ToString();
                e.Row.Cells[crfgrandtotal.Mar_index].Text = crfgrandtotal.Mar.ToString();

                e.Row.Cells[crfgrandtotal.WideScope_index].Text = crfgrandtotal.WideScope.ToString();
                e.Row.Cells[crfgrandtotal.WideCommulative_index].Text = crfgrandtotal.WideCommulative.ToString();
                e.Row.Cells[crfgrandtotal.WideTarget_index].Text = crfgrandtotal.WideTarget.ToString();
                e.Row.Cells[crfgrandtotal.WideAchivement_index].Text = crfgrandtotal.WideAchivement.ToString();
                e.Row.Cells[crfgrandtotal.BTScope_index].Text = crfgrandtotal.BTScope.ToString();
                e.Row.Cells[crfgrandtotal.BTCommulative_index].Text = crfgrandtotal.BTCommulative.ToString();
                e.Row.Cells[crfgrandtotal.BTTarget_index].Text = crfgrandtotal.BTTarget.ToString();
                e.Row.Cells[crfgrandtotal.BTAchivement_index].Text = crfgrandtotal.BTAchivement.ToString();
                e.Row.Cells[crfgrandtotal.CDScope_index].Text = crfgrandtotal.CDScope.ToString();
                e.Row.Cells[crfgrandtotal.CDCommulative_index].Text = crfgrandtotal.CDCommulative.ToString();
                e.Row.Cells[crfgrandtotal.CDTarget_index].Text = crfgrandtotal.CDTarget.ToString();
                e.Row.Cells[crfgrandtotal.CDAchivement_index].Text = crfgrandtotal.CDAchivement.ToString();
                e.Row.Cells[crfgrandtotal.MinorScope_index].Text = crfgrandtotal.MinorScope.ToString();
                e.Row.Cells[crfgrandtotal.MinorCommulative_index].Text = crfgrandtotal.MinorCommulative.ToString();
                e.Row.Cells[crfgrandtotal.MinorTarget_index].Text = crfgrandtotal.MinorTarget.ToString();
                e.Row.Cells[crfgrandtotal.MinorAchivement_index].Text = crfgrandtotal.MinorAchivement.ToString();
                e.Row.Cells[crfgrandtotal.MjorScope_index].Text = crfgrandtotal.MjorScope.ToString();
                e.Row.Cells[crfgrandtotal.MajorCommulative_index].Text = crfgrandtotal.MajorCommulative.ToString();
                e.Row.Cells[crfgrandtotal.MajorTarget_index].Text = crfgrandtotal.MajorTarget.ToString();
                e.Row.Cells[crfgrandtotal.MajorAchivement_index].Text = crfgrandtotal.MajorAchivement.ToString();

                e.Row.Cells[crfgrandtotal.OtherExpen_index].Text = crfgrandtotal.OtherExpen.ToString();
                e.Row.Cells[crfgrandtotal.ElectriCost_index].Text = crfgrandtotal.ElectriCost.ToString();
                e.Row.Cells[crfgrandtotal.ElectriExpen_index].Text = crfgrandtotal.ElectriExpen.ToString();
                e.Row.Cells[crfgrandtotal.TenderAmount_index].Text = crfgrandtotal.TenderAmount.ToString();
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
            pName = GridView1.DataKeys[e.NewSelectedIndex].Values["WorkId"].ToString();
            Response.Redirect("Send_sms.aspx?WorkID=" + pName + "");
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            pName = GridView1.DataKeys[e.NewEditIndex].Values["WorkId"].ToString();
            Response.Redirect("MasterBudgetCRF.aspx?WorkId=" + pName + "");
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterCRFReportSda"].ToString(), con);
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
                    SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterCRFReportSda"].ToString(), con);
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
                SqlDataAdapter sda1 = new SqlDataAdapter(Session["MasterCRFReportSda"].ToString(), con);
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
            string WorkId = e.Keys["WorkId"].ToString();

            strSqlCommand = "Delete From [BudgetMasterCRF] Where [WorkId]='" + WorkId + "'";
            strSqlCommand1 = "Delete From [CRFProvision] Where [WorkId]='" + WorkId + "'";
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
            // decimal[] arr = new decimal[10];
            //send Three parameter to GraphicsReport(Master Table, Provision Table, Where Condition) //
            objGraph.GraphicsReports("[BudgetMasterCRF]", "[CRFProvision]", WhereCondition);

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