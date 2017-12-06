using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class SReport17Columns : System.Web.UI.Page
    {
        int totalroad = 0;
        int totalNbard = 0;
        int totalbuild = 0;
        int totalresibulid = 0;
        int totalnonresibuild = 0;
        int totalcrf = 0;
        int totalgatA = 0;
        int totalDpdc = 0;
        int totalMla = 0;
        int totalMp = 0;
        int total2515 = 0;
        int totalGatD = 0;
        int totalGatF = 0;
        int totalGatB = 0;
        int totalGatC = 0;
        int totalDeposite = 0;
        int totalAnuty = 0;


        // for GrandCount
        int grandroad = 0;
        int grandnabard = 0;
        int grandbulid = 0;
        int grandresibuild = 0;
        int grandnonresibuild = 0;
        int grandcrf = 0;
        int grandgatA = 0;
        int grandDpdc = 0;
        int grandMla = 0;
        int grandMp = 0;
        int grand2515 = 0;
        int grandGatD = 0;
        int grandGatF = 0;
        int grandGatB = 0;
        int grandGatC = 0;
        int grandDeposite = 0;
        int grandAnuty = 0;


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        string pName;
        string GridName;
        int tempcounter = 0;
        int rowcount = 0;
        ReportGrandTotal grandtotal = new ReportGrandTotal();
        ReportGrandTotal roadgrandtotal = new ReportGrandTotal();
        ReportGrandTotal buildgrandtotal = new ReportGrandTotal();
        ReportGrandTotal resibuildgrandtotal = new ReportGrandTotal();
        ReportGrandTotal nonresibuilgranddtotal = new ReportGrandTotal();
        ReportGrandTotal gatAgrandtotal = new ReportGrandTotal();
        CRFGrandTotal crfgrandtotal = new CRFGrandTotal();
        DpdcGrandTotal dpdcgrandtotal = new DpdcGrandTotal();
        MlaGrandTotal mlagrnadtotal = new MlaGrandTotal();
        MpGrandTotal mpgrandtotal = new MpGrandTotal();
        ReportGrandTotal grand2515total = new ReportGrandTotal();
        ReportGrandTotal gatDgrandtotal = new ReportGrandTotal();
        ReportGrandTotal gatFgrandtotal = new ReportGrandTotal();
        ReportGrandTotal gatCgrandtotal = new ReportGrandTotal();
        ReportGrandTotal gatBgrandtotal = new ReportGrandTotal();
        ReportGrandTotal depositegrandtotal = new ReportGrandTotal();
        RoadGrandTotal anutygrandtotal = new RoadGrandTotal();
        AllHeadReportClass allreport = new AllHeadReportClass();
        ListItem litem = new ListItem();
        ListItem Upv = new ListItem();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    Label1.Text = Session["id"].ToString();
                    Amdar();
                    upvibhag();
                    lekhashirsh();
                    Abhyanta();
                    UpAbhyanta();
                    Khasdar();
                    ThekadarName();
                    Type();
                    ArthsankalpiyYear();
                    divAllHeadBtn.Visible = false;
                    if (Request.QueryString["Year"] != null)
                    {
                       
                        string arthyear = Request.QueryString["Year"].ToString();
                        int UpVibhagIndex = Convert.ToInt32(Request.QueryString["UpV"].ToString());
                        litem = ddlArthsankalpiyYear.Items.FindByText(arthyear);
                        if (litem != null)
                        {
                            ddlArthsankalpiyYear.Items.FindByText(arthyear).Selected = true;
                        }
                        if (UpVibhagIndex > 0)
                        {
                            ddlUpvibhag.SelectedIndex = UpVibhagIndex;
                            Label1.Text = "lblUpvibhag";
                        }
                        else
                        {
                            Label1.Text = "lblArthsankalpiyYear";
                        }
                        AllMethodsGrid();
                    }
                }
            }
        }

        public void Loader()
        {
            // System.Threading.Thread.Sleep(3000);
        }

        public void Amdar()
        {
            ddlAmdar.Items.Clear();
            ddlAmdar.Items.Add("Select");
            SqlDataAdapter sda = new SqlDataAdapter("select Name from SettingAddMLA where MLAType='Amdar'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlAmdar.Items.Add(dr["Name"].ToString());
            }
        }

        public void upvibhag()
        {
            ddlUpvibhag.Items.Clear();
            ddlUpvibhag.Items.Add("Select");
            SqlDataAdapter sda = new SqlDataAdapter("select UpVibhagacheName from SettingUpVibhag", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlUpvibhag.Items.Add(dr["UpVibhagacheName"].ToString());
            }
        }

        public void lekhashirsh()
        {
            ddlLekhashirsh.Items.Clear();
            ddlLekhashirsh.Items.Add("Select");
            SqlDataAdapter sda = new SqlDataAdapter("select code from SettingLekhaShirsh", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlLekhashirsh.Items.Add(dr["code"].ToString());
            }
        }

        public void Abhyanta()
        {
            ddlShakhaAbhiyanta.Items.Clear();
            ddlShakhaAbhiyanta.Items.Add("Select");
            SqlDataAdapter sda = new SqlDataAdapter("select Name from ScreateAdmin where Post='Sectional Engineer'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlShakhaAbhiyanta.Items.Add(dr["Name"].ToString());
            }
        }

        public void UpAbhyanta()
        {
            ddlShakhUpAbhiyanta.Items.Clear();
            ddlShakhUpAbhiyanta.Items.Add("Select");
            SqlDataAdapter sda = new SqlDataAdapter("select Name from ScreateAdmin where Post=' Deputy Engineer'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlShakhUpAbhiyanta.Items.Add(dr["Name"].ToString());
            }
        }

        public void Khasdar()
        {
            ddlKhasdar.Items.Clear();
            ddlKhasdar.Items.Add("Select");
            SqlDataAdapter sda = new SqlDataAdapter("select Name from SettingAddMLA where MLAType='Khasdar'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlKhasdar.Items.Add(dr["Name"].ToString());
            }
        }

        public void ThekadarName()
        {
            try
            {
                ddlThekedarecheName.Items.Clear();
                ddlThekedarecheName.Items.Add("Select");
                SqlDataAdapter sda = new SqlDataAdapter("Select Name from SCreateAdmin Where Post=N'Contractor'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    ddlThekedarecheName.Items.Add(dr["Name"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DisableNullGrid()
        {
            if (GridBuilding.Rows.Count == 0)
            {
                DivRoot.Visible = false;
            }
            if (GridRoad.Rows.Count == 0)
            {
                DivRoot1.Visible = false;
            }
            if (GridCRF.Rows.Count == 0)
            {
                DivRootCRF.Visible = false;
            }
            if (GridNabard.Rows.Count == 0)
            {
                DivRootNabard.Visible = false;
            }
            if (GridDPDC.Rows.Count == 0)
            {
                DivRootDPDC.Visible = false;
            }
            if (GridMLA.Rows.Count == 0)
            {
                DivRootMLA.Visible = false;
            }
            if (GridMP.Rows.Count == 0)
            {
                DivRootMP.Visible = false;
            }
            if (GridAunty.Rows.Count == 0)
            {
                DivRootAunty.Visible = false;
            }
            if (GridDepositFund.Rows.Count == 0)
            {
                DivRootDepositFund.Visible = false;
            }
            if (GridGatA.Rows.Count == 0)
            {
                DivRootGatA.Visible = false;
            }
            if (GridGatD.Rows.Count == 0)
            {
                DivRootGatD.Visible = false;
            }
            if (GridGatF.Rows.Count == 0)
            {
                DivRootGatF.Visible = false;
            }
            if (GridGatB.Rows.Count == 0)
            {
                DivRootGatB.Visible = false;
            }
            if (GridGatC.Rows.Count == 0)
            {
                DivRootGatC.Visible = false;
            }
            if (GridResidentialBuilding.Rows.Count == 0)
            {
                DivRootResidentialBuilding.Visible = false;
            }
            if (GridNonResidentialbuilding.Rows.Count == 0)
            {
                DivRootNonResidentialbuilding.Visible = false;
            }
            if (Grid2515.Rows.Count == 0)
            {
                DivRoot2515.Visible = false;
            }
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            if (GridBuilding.Rows.Count == 0)
            {
                DivRoot.Visible = false;
                lblBuilding.Text = string.Empty;
            }
            if (GridRoad.Rows.Count == 0)
            {
                DivRoot1.Visible = false;
                lblRoad.Text = string.Empty;
            }
            if (GridCRF.Rows.Count == 0)
            {
                DivRootCRF.Visible = false;
                lblCRF.Text = string.Empty;
            }
            if (GridNabard.Rows.Count == 0)
            {
                DivRootNabard.Visible = false;
                lblNabard.Text = string.Empty;
            }
            if (GridDPDC.Rows.Count == 0)
            {
                DivRootDPDC.Visible = false;
                lblDPDC.Text = string.Empty;
            }
            if (GridMLA.Rows.Count == 0)
            {
                DivRootMLA.Visible = false;
                lblMLA.Text = string.Empty;
            }
            if (GridMP.Rows.Count == 0)
            {
                DivRootMP.Visible = false;
                lblMP.Text = string.Empty;
            }
            if (GridAunty.Rows.Count == 0)
            {
                DivRootAunty.Visible = false;
                lblAnnuity.Text = string.Empty;
            }
            if (GridDepositFund.Rows.Count == 0)
            {
                DivRootDepositFund.Visible = false;
                lblDepositFund.Text = string.Empty;
            }
            if (GridGatA.Rows.Count == 0)
            {
                DivRootGatA.Visible = false;
                lblGATA.Text = string.Empty;
            }
            if (GridGatD.Rows.Count == 0)
            {
                DivRootGatD.Visible = false;
                lblGatD.Text = string.Empty;
            }
            if (GridGatF.Rows.Count == 0)
            {
                DivRootGatF.Visible = false;
                lblGatF.Text = string.Empty;
            }
            if (GridGatB.Rows.Count == 0)
            {
                DivRootGatB.Visible = false;
                lblGatB.Text = string.Empty;
            }
            if (GridGatC.Rows.Count == 0)
            {
                DivRootGatC.Visible = false;
                lblGatC.Text = string.Empty;
            }
            if (GridResidentialBuilding.Rows.Count == 0)
            {
                DivRootResidentialBuilding.Visible = false;
                lblResBuilding.Text = string.Empty;
            }
            if (GridNonResidentialbuilding.Rows.Count == 0)
            {
                DivRootNonResidentialbuilding.Visible = false;
                lblNonResBuilding.Text = string.Empty;
            }
            if (Grid2515.Rows.Count == 0)
            {
                DivRoot2515.Visible = false;
                lbl2515.Text = string.Empty;
            }
            base.OnSaveStateComplete(e);

            if (ViewState["Head"] != null)
            {
                lblBuilding.Text = string.Empty;
                lblCRF.Text = string.Empty;
                lblAnnuity.Text = string.Empty;
                lblRoad.Text = string.Empty;
                lblNabard.Text = string.Empty;
                lblMLA.Text = string.Empty;
                lblMP.Text = string.Empty;
                lblGATA.Text = string.Empty;
                lblGatB.Text = string.Empty;
                lblGatC.Text = string.Empty;
                lblGatD.Text = string.Empty;
                lblDepositFund.Text = string.Empty;
                lblResBuilding.Text = string.Empty;
                lblNonResBuilding.Text = string.Empty;
                lbl2515.Text = string.Empty;
                lblGatF.Text = string.Empty;
                lblDPDC.Text = string.Empty;


                DivRoot.Visible = false;
                DivRoot1.Visible = false;
                DivRootCRF.Visible = false;
                DivRootNabard.Visible = false;
                DivRootDPDC.Visible = false;
                DivRootMLA.Visible = false;
                DivRootMP.Visible = false;
                DivRootDepositFund.Visible = false;
                DivRootGatA.Visible = false;
                DivRootGatF.Visible = false;
                DivRootGatB.Visible = false;
                DivRootGatC.Visible = false;
                DivRootGatD.Visible = false;
                DivRootAunty.Visible = false;
                DivRootResidentialBuilding.Visible = false;
                DivRootNonResidentialbuilding.Visible = false;
                DivRoot2515.Visible = false;


                if (ViewState["Head"].ToString() == "Building")
                {
                    DivRoot.Visible = true;
                    lblBuilding.Text = "<h2>Building</h2>";
                }
                if (ViewState["Head"].ToString() == "Road")
                {
                    DivRoot1.Visible = true;
                    lblRoad.Text = "<h2>Road</h2>";
                }
                if (ViewState["Head"].ToString() == "Crf")
                {
                    DivRootCRF.Visible = true;
                    lblCRF.Text = "<h2>CRF</h2>";
                }
                if (ViewState["Head"].ToString() == "Nabard")
                {
                    DivRootNabard.Visible = true;
                    lblNabard.Text = "<h2>Nabard</h2>";
                }
                if (ViewState["Head"].ToString() == "Dpdc")
                {
                    DivRootDPDC.Visible = true;
                    lblDPDC.Text = "<h2>Dpdc</h2>";
                }
                if (ViewState["Head"].ToString() == "MLA")
                {
                    DivRootMLA.Visible = true;
                    lblMLA.Text = "<h2>MLA</h2>";
                }
                if (ViewState["Head"].ToString() == "MP")
                {
                    DivRootMP.Visible = true;
                    lblMP.Text = "<h2>MP</h2>";
                }
                if (ViewState["Head"].ToString() == "Deposit")
                {
                    DivRootDepositFund.Visible = true;
                    lblDepositFund.Text = "<h2>Deposit</h2>";
                }
                if (ViewState["Head"].ToString() == "GatA")
                {
                    DivRootGatA.Visible = true;
                    lblGATA.Text = "<h2>GatA</h2>";
                }
                if (ViewState["Head"].ToString() == "GatFbc")
                {
                    DivRootGatF.Visible = true;
                    lblGatF.Text = "<h2>Gat F</h2>";
                }
                if (ViewState["Head"].ToString() == "GATB")
                {
                    DivRootGatB.Visible = true;
                    lblGatB.Text = "<h2>Gat B</h2>";
                }
                if (ViewState["Head"].ToString() == "GATC")
                {
                    DivRootGatC.Visible = true;
                    lblGatC.Text = "<h2>Gat C</h2>";
                }
                if (ViewState["Head"].ToString() == "GatD")
                {
                    DivRootGatD.Visible = true;
                    lblGatD.Text = "<h2>Gat D</h2>";
                }
                if (ViewState["Head"].ToString() == "Annuity")
                {
                    DivRootAunty.Visible = true;
                    lblAnnuity.Text = "<h2>Annuity</h2>";
                }
                if (ViewState["Head"].ToString() == "2216")
                {
                    DivRootResidentialBuilding.Visible = true;
                    lblResBuilding.Text = "<h2>2216</h2>";
                }
                if (ViewState["Head"].ToString() == "2059")
                {
                    DivRootNonResidentialbuilding.Visible = true;
                    lblNonResBuilding.Text = "<h2>2059</h2>";
                }
                if (ViewState["Head"].ToString() == "2515")
                {
                    DivRoot2515.Visible = true;
                    lbl2515.Text = "<h2>2515</h2>";
                }
            }
            //base.OnPreRender(e);
            ViewState["Head"] = null;
        }

        public void Type()
        {
            ddltype.Items.Clear();
            ddltype.Items.Add("Select");
            SqlDataAdapter sda = new SqlDataAdapter("select VarishtType from SettingVarishtType", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddltype.Items.Add(dr["VarishtType"].ToString());
            }
        }

        public void ArthsankalpiyYear()
        {
            ddlArthsankalpiyYear.Items.Clear();
            ddlArthsankalpiyYear.DataSource = allreport.ArthsankalpiyYear();
            ddlArthsankalpiyYear.DataTextField = "Arthsankalpiyyear";
            ddlArthsankalpiyYear.DataValueField = "Arthsankalpiyyear";
            ddlArthsankalpiyYear.DataBind();
            ddlArthsankalpiyYear.Items.Insert(0, new ListItem("Select"));
        }

        public void Building()
        {
            GridBuilding.DataSource = null;
            GridBuilding.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName] ORDER BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]) as 'SrNo', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश दिनांक',a.[NividaAmt] as 'निविदा रक्कम % कमी / जास्त',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा / कामाची सद्यस्थिती',CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर ' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS' from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'SrNo', 'Total' as 'वर्क आयडी',isNULL ('Total','') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'कामाचे नाव',isNULL (a.[LekhaShirshName],'') as 'लेखाशीर्ष नाव',isNULL ('','') as 'उपविभाग',isNULL ('','0') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश दिनांक',isNULL ('','') as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[ManjurAmt]) as 'मंजूर अंदाजित किंमत',sum(b.[MarchEndingExpn])as 'मार्च अखेर खर्च 2017',sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud])as 'अर्थसंकल्पीय तरतूद',isNULL ('','') as 'शेरा / कामाची सद्यस्थिती',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर '  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS' from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[LekhaShirshName] order by a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportBuildingSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridBuilding.DataSource = dt;
                GridBuilding.DataBind();
                lblBuilding.Text = "<h2>Building</h2>";
                btnBuildRep.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridBuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_Building"] = GridBuilding;
            }
            else
            {
                btnBuildRep.Visible = false;
            }
        }

        public void CRF()
        {
            GridCRF.DataSource = null;
            GridCRF.DataBind();
            lblCRF.Text = "<h2>CRF</h2>";
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag]desc) as 'SrNo', a.[WorkId] as 'WorkId',a.[Arthsankalpiyyear] as 'Budget of Year',a.[KamacheName] as 'Name of Work',a.[LekhaShirshName] as 'Headwise',a.[Upvibhag] as 'Sub Division',a.[Taluka] as 'Taluka',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor',a.[PrashaskiyKramank] as 'Administrative No',a.[PrashaskiyDate] as 'A A Date',a.[PrashaskiyAmt] as 'A A Amount',a.[TrantrikKrmank] as 'Technical Sanction No',a.[TrantrikDate] as 'T S Date',a.[TrantrikAmt] as 'T S Amount',a.[Kamachavav] as 'Scope of Work',a.[karyarambhadesh] as 'Work Order',a.[NividaKrmank] as 'Tender No',cast(a.[NividaAmt] as decimal(10,2)) as 'Tender Amount',a.[NividaDate] as 'Tender Date',a.[kamachiMudat] as 'Work Order Date',a.[KamPurnDate] as 'Work Completion Date',b.[MudatVadhiDate] as 'Extension Month',b.[ManjurAmt] as 'Estimated Cost Approved',b.[MarchEndingExpn] as 'MarchEndingExpn',b.[UrvaritAmt] as 'Remaining Cost',b.[AikunKharch] as 'Total Expense',b.[Tartud] as 'Grand Provision',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS',a.[Shera] as 'Remark' from BudgetMasterCRF as a join CRFProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'SrNo', 'Total' as 'WorkId',isNULL (a.[Arthsankalpiyyear],'') as 'Arthsankalpiyyear',isNULL ('','') as 'Name of Work',isNULL ('','') as 'Headwise',isNULL ('','') as 'Sub Division',isNULL ('','') as 'Taluka',isNULL ('','') as 'Contractor',isNULL ('','') as 'Administrative No',isNULL ('','') as 'A A Date',sum(cast(a.[PrashaskiyAmt] as decimal(10,0))) as 'A A Amount',isNULL ('','') as 'Technical Sanction No',isNULL ('','') as 'T S Date',sum(cast(a.[TrantrikAmt]as decimal(10,0))) as 'T S Amount',isNULL ('','') as 'Scope of Work',isNULL ('','') as 'Work Order',isNULL ('','') as 'Tender No',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'Tender Amount',isNULL ('','') as 'Tender Date',isNULL ('','') as 'Work Order Date',isNULL ('','') as 'Work Completion Date',isNULL ('','') as 'Extension Month',sum(b.[ManjurAmt]) as 'Estimated Cost Approved',sum(b.[MarchEndingExpn]) as 'MarchEndingExpn',sum(b.[UrvaritAmt]) as 'Remaining Cost',sum(b.[AikunKharch]) as 'Total Expense', sum(b.[Tartud]) as 'Grand Provision',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',isNULL ('','') as 'Remark' from BudgetMasterCRF as a join CRFProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[Arthsankalpiyyear] order by a.[Arthsankalpiyyear],a.Upvibhag desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportCRFSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridCRF.DataSource = dt;
                GridCRF.DataBind();
                lblCRF.Text = "<h2>CRF</h2>";
                btnCrf.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key16", "<script>MakeStaticHeaderCRF('" + GridCRF.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_CRF"] = GridCRF;
            }
            else
            {
                btnCrf.Visible = false;
            }
        }

        public void Nabard()
        {
            GridNabard.DataSource = null;
            GridNabard.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[RDF_SrNo] ORDER BY a.[Upvibhag]) as 'SrNo', a.[WorkId] as 'Work Id',a.[RDF_NO] as 'RIDF NO', a.[RDF_SrNo] as 'srno',a.[Arthsankalpiyyear] as 'Budget of Year',a.[Taluka] as 'Taluka',a.[KamacheName]as 'Name of Work',a.[Kamachavav] as 'Scope of Work',a.[LekhaShirshName] as 'Headwise',a.[Upvibhag] as 'Sub Division',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor',a.[PrashaskiyKramank] as 'Administrative No',a.[PrashaskiyDate] as 'A A Date',cast(a.[PrashaskiyAmt] as decimal(10,2)) as 'AA cost Rs in lakhs',cast(a.[TrantrikAmt]as decimal(10,2))as 'Technical Sanction Cost Rs in Lakh',a.[TrantrikKrmank]+' '+a.[TrantrikDate] as 'Technical Sanction No and Date',a.[NividaKrmank] as 'Tender No',cast(a.[NividaAmt] as decimal(10,2)) as 'Tender Amount',a.[NividaDate] as 'Tender Date',a.[karyarambhadesh] as 'Work Order',a.[kamachiMudat] as 'Work Order Date',a.[KamPurnDate] as 'Work Completion Date',b.[MudatVadhiDate] as 'Extension Month',b.[ManjurAmt] as 'Estimated Cost Approved',b.[MarchEndingExpn] as 'Expenditure up to MAR 2017',b.[UrvaritAmt] as 'Remaining Cost',b.[AikunKharch] as 'Total Expense',b.[Tartud] as 'Total Provision',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS',a.[Shera] as 'Remark' from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL (a.[RDF_SrNo],'')as'SrNo',isNULL ('Total','') as 'Work Id',isNULL ('','')as 'RIDF NO', cast(a.[RDF_SrNo] as int) as 'srno',isNULL ('Total','')as 'Budget of Year',isNULL ('','') as 'Taluka',isNULL ('','')as 'Name of Work',isNULL ('','') as 'Scope of Work',isNULL ('','')as 'Headwise',isNULL ('','') as 'Sub Division',isNULL ('','') as 'Contractor',isNULL ('','') as 'Administrative No',isNULL ('','') as 'A A Date',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'AA cost Rs in lakhs',sum(cast(a.[TrantrikAmt]as decimal(10,2)))as 'Technical Sanction Cost Rs in Lakh',isNULL ('','') as 'Technical Sanction No and Date',isNULL ('','') as 'Tender No',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'Tender Amount',isNULL ('','') as 'Tender Date',isNULL ('','') as 'Work Order',isNULL ('','') as 'Work Order Date',isNULL ('','') as 'Work Completion Date',isNULL ('','') as 'Extension Month',sum(b.[ManjurAmt]) as 'Estimated Cost Approved',sum(b.[MarchEndingExpn]) as 'Expenditure up to MAR 2017',sum(b.[UrvaritAmt]) as 'Remaining Cost',sum(b.[AikunKharch]) as 'Total Expense', sum(b.[Tartud]) as 'Total Provision',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',isNULL ('','')as 'Remark' from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[RDF_SrNo] order by a.[RDF_SrNo],a.[Arthsankalpiyyear],a.[Upvibhag],a.taluka";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportNabardSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridNabard.DataSource = dt;
                GridNabard.DataBind();
                lblNabard.Text = "<h2>Nabard</h2>";
                btnNabard.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key15", "<script>MakeStaticHeaderNabard('" + GridNabard.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_Nabard"] = GridNabard;
            }
            else
            {
                btnNabard.Visible = false;
            }
        }

        public void Road()
        {
            GridRoad.DataSource = null;
            GridRoad.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName]ORDER BY a.LekhaShirshName desc,a.[Arthsankalpiyyear],a.[Taluka],a.[upvibhag]) as 'अ.क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'सुरवाती पासून मार्च 2017 अखेरचा खर्च',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterRoad as a join RoadProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'अ.क्र', 'Total' as 'वर्क आयडी',isNULL ('Total','') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'कामाचे नाव', a.[LekhaShirshName] as 'लेखाशीर्ष नाव',isNULL ('','') as 'उपविभाग',isNULL ('','') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[ManjurAmt]) as 'मंजूर अंदाजित किंमत',sum(b.[MarchEndingExpn]) as 'सुरवाती पासून मार्च 2017 अखेरचा खर्च',sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud]) as 'एकूण अर्थसंकल्पीय तरतूद',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',isNULL ('','') as 'शेरा' from BudgetMasterRoad as a join RoadProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = "group by a.[LekhaShirshName] order by a.LekhaShirshName desc,a.[Arthsankalpiyyear],a.[Taluka],a.upvibhag";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportRoadSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridRoad.DataSource = dt;
                GridRoad.DataBind();
                lblRoad.Text = "<h2>Road</h2>";
                btnRoad.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key2", "<script>MakeStaticHeader1('" + GridRoad.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_Road"] = GridRoad;
            }
            else
            {
                btnRoad.Visible = false;
            }
        }

        public void DPDC()
        {
            GridDPDC.DataSource = null;
            GridDPDC.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear], a.[Upvibhag] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka]desc) as 'SrNo', a.[WorkId] as 'वर्क आयडी',a.[LekhaShirshName] as 'योजनेचे नाव',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'योजनेचे / कामाचे नांव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',a.[karyarambhadesh] as 'कार्यारंभ आदेश',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[KamPurnDate] as 'काम पूर्ण होण्याचा अपेक्षित दिनांक',b.[ManjurAmt] as 'एकूण अंदाजित किंमत (अलिकडील सुधारित)',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud] as '2017-2018 करीता प्रस्तावित तरतूद',CAST(CASE WHEN a.[Sadyasthiti] = N'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = N'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर ' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS',a.[Shera] as 'शेरा' from BudgetMasterDPDC as a join DPDCProvision as b on a.WorkId=b.WorkId  ";
            string unionQuery = " union select isNULL ('','')as'SrNo',  'Total' as 'वर्क आयडी', isNULL ('','') as 'योजनेचे नाव',isNULL (a.[Arthsankalpiyyear],'') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'योजनेचे / कामाचे नांव', isNULL (a.[Upvibhag],'') as 'उपविभाग', isNULL ('','') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम', isNULL ('','')as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम', isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',isNULL ('','') as 'निविदा क्र/दिनांक',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त', isNULL ('','') as 'काम पूर्ण होण्याचा अपेक्षित दिनांक',sum(b.[ManjurAmt]) as 'एकूण अंदाजित किंमत (अलिकडील सुधारित)',sum(b.[MarchEndingExpn]) as 'मार्च अखेर खर्च 2017', sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च', sum(b.[Tartud]) as '2017-2018 करीता प्रस्तावित तरतूद',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर '  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS', isNULL ('','') as 'शेरा' from BudgetMasterDPDC as a join DPDCProvision as b on a.WorkId=b.WorkId  ";

            string GroupByOrderBy = " group by a.[Arthsankalpiyyear], a.[Upvibhag]  ORDER BY a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka] desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportDPDCSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridDPDC.DataSource = dt;
                GridDPDC.DataBind();
                lblDPDC.Text = "<h2>DPDC</h2>";
                btnDpdc.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key14", "<script>MakeStaticHeaderDPDC('" + GridDPDC.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_DPDC"] = GridDPDC;
            }
            else
            {
                btnDpdc.Visible = false;
            }
        }

        public void MLA()
        {
            GridMLA.DataSource = null;
            GridMLA.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[AmdaracheName] order by  a.[AmdaracheName],a.[Arthsankalpiyyear],a.[Taluka],a.[PageNo]) as 'SrNo', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष',a.[PageNo] as 'प्रकार',a.[Taluka] as 'तालुका',a.[KamacheName] as 'कामाचे नाव',a.[Upvibhag] as 'उपविभाग',a.[AmdaracheName] as 'आमदारांचे नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यांरभ आदेश/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',b.[MudatVadhiDate] as 'मुदतवाढ दिनांक',b.[ManjurAmt] as 'सन 2017-2018 मधील अपेक्षित खर्च',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत (6-(8+9))',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud] as 'काम निहाय तरतूद सन 2017-2018',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS',a.[Shera] as 'शेरा' from BudgetMasterMLA as a join MLAProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'SrNo', 'Total' as 'वर्क आयडी','Total' as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष',isNULL ('','') as 'प्रकार',isNULL ('','') as 'तालुका',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'उपविभाग',isNULL (a.[AmdaracheName],'') as 'आमदारांचे नाव',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','')as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','')as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यांरभ आदेश/दिनांक',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'बांधकाम कालावधी',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ दिनांक',sum(b.[ManjurAmt] )as 'सन 2017-2018 मधील अपेक्षित खर्च',sum(b.[MarchEndingExpn]) as 'मार्च अखेर खर्च 2017',sum(b.[UrvaritAmt]) as 'उर्वरित किंमत (6-(8+9))',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud]) as 'काम निहाय तरतूद सन 2017-2018',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',isNULL ('','') as 'शेरा' from BudgetMasterMLA as a join MLAProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by  a.[AmdaracheName] order by a.[AmdaracheName], a.[Arthsankalpiyyear],a.[Taluka],a.[PageNo]";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportMLASda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridMLA.DataSource = dt;
                GridMLA.DataBind();
                lblMLA.Text = "<h2>MLA</h2>";
                btnMla.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key13", "<script>MakeStaticHeaderMLA('" + GridMLA.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_MLA"] = GridMLA;
            }
            else
            {
                btnMla.Visible = false;
            }
        }

        public void MP()
        {
            GridMP.DataSource = null;
            GridMP.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[KhasdaracheName] order by a.[KhasdaracheName],a.[Arthsankalpiyyear],a.[Taluka],a.[PageNo] ) as 'SrNo', a.[WorkId] as 'वर्क आयडी',a.[Taluka] as 'तालुका',a.[KhasdaracheName] as 'खासदारांचे नाव',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष',a.[PageNo] as 'प्रकार',a.[KamacheName] as 'कामाचे नाव',a.[Upvibhag] as 'उपविभाग',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यांरभ आदेश/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',b.[MudatVadhiDate] as 'मुदतवाढ दिनांक',b.[ManjurAmt] as 'सन 2017-18 मधील अपेक्षित खर्च',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत (6-(8+9))',b.[AikunKharch] as 'एकुण खर्च',b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS',a.[Shera] as 'शेरा' from BudgetMasterMP as a join MPProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'SrNo', 'Total' as 'वर्क आयडी',isNULL ('','') as 'तालुका',isNULL (a.[KhasdaracheName],'') as 'खासदारांचे नाव',isNULL ('Total','') as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष',isNULL ('','') as 'प्रकार',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'उपविभाग',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','')as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','')as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यांरभ आदेश/दिनांक',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'बांधकाम कालावधी',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ दिनांक',sum(b.[ManjurAmt] )as 'सन 2017-18 मधील अपेक्षित खर्च',sum(b.[MarchEndingExpn]) as 'मार्च अखेर खर्च 2017',sum(b.[UrvaritAmt]) as 'उर्वरित किंमत (6-(8+9))',sum(b.[AikunKharch]) as 'एकुण खर्च',sum(b.[Tartud]) as 'एकूण अर्थसंकल्पीय तरतूद',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',isNULL ('','') as 'शेरा' from BudgetMasterMP as a join MPProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[KhasdaracheName] order by a.[KhasdaracheName] ,[PageNo] desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportMPSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridMP.DataSource = dt;
                GridMP.DataBind();
                lblMP.Text = "<h2>MP</h2>";
                btnMp.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key12", "<script>MakeStaticHeaderMP('" + GridMP.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_MP"] = GridMP;
            }
            else
            {
                btnMp.Visible = false;
            }
        }

        public void Aunty()
        {
            GridAunty.DataSource = null;
            GridAunty.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka] desc) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[karyarambhadesh] as 'कार्यारंभ आदेश',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS' from BudgetMasterAunty as a join AuntyProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'अ क्र', 'Total' as 'वर्क आयडी',isNULL (a.[Arthsankalpiyyear],'') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'लेखाशीर्ष नाव',isNULL (a.[Upvibhag],'') as 'उपविभाग',isNULL ('','') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'निविदा क्र/दिनांक',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'कार्यारंभ आदेश',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[ManjurAmt]) as 'मंजूर अंदाजित किंमत',sum(b.[MarchEndingExpn]) as 'मार्च अखेर खर्च 2017',sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud]) as 'एकूण अर्थसंकल्पीय तरतूद',isNULL ('','') as 'शेरा',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS' from BudgetMasterAunty as a join AuntyProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[Arthsankalpiyyear], a.[Upvibhag]  order by a.[Arthsankalpiyyear],a.[Upvibhag],a.[Taluka]desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportAuntySda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridAunty.DataSource = dt;
                GridAunty.DataBind();
                lblAnnuity.Text = "<h2>Annuity</h2>";
                btnAnnuity.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key5", "<script>MakeStaticHeaderAunty('" + GridAunty.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_Aunty"] = GridAunty;
            }
            else
            {
                btnAnnuity.Visible = false;
            }
        }

        public void DepositeFund()
        {
            GridDepositFund.DataSource = null;
            GridDepositFund.DataBind();
            lblDepositFund.Text = "<h2>DepositFund</h2>";
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag]desc) as 'SrNo', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश',a.[NividaAmt] as 'निविदा रक्कम % कमी / जास्त',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा',CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर ' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS' from BudgetMasterDepositFund as a join DepositFundProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'SrNo', 'Total' as 'वर्क आयडी',isNULL (a.[Arthsankalpiyyear],'') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'लेखाशीर्ष नाव',isNULL ('','') as 'उपविभाग',isNULL ('','0') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',isNULL ('','') as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[ManjurAmt]) as 'मंजूर अंदाजित किंमत',sum(b.[MarchEndingExpn])as 'मार्च अखेर खर्च 2017',sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud])as 'अर्थसंकल्पीय तरतूद',isNULL ('','') as 'शेरा',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर '  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS' from BudgetMasterDepositFund as a join DepositFundProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[Arthsankalpiyyear]  order by  a.[Arthsankalpiyyear],a.Upvibhag desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportDepositefundSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridDepositFund.DataSource = dt;
                GridDepositFund.DataBind();
                lblDepositFund.Text = "<h2>DepositFund</h2>";
                btnDeposit.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key6", "<script>MakeStaticHeaderDepositFund('" + GridDepositFund.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_DepositeFund"] = GridDepositFund;
            }
            else
            {
                btnDeposit.Visible = false;
            }
        }

        public void GATA()
        {
            GridGatA.DataSource = null;
            GridGatA.DataBind();
            lblGATA.Text = "<h2>GAT A</h2>";
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear] ORDER BY a.[Arthsankalpiyyear],    CASE WHEN ISNUMERIC(a.[ArthsankalpiyBab]) = 1 THEN 0 ELSE 1 END,    CASE WHEN ISNUMERIC(a.[ArthsankalpiyBab]) = 1 THEN CAST(a.[ArthsankalpiyBab] AS INT) ELSE 0 END,a.[ArthsankalpiyBab],a.[Upvibhag],a.taluka) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',a.[GAadeshKramank] as 'आदेश क्र',a.[GJobKramank] as 'जॉब क्र',CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = N'चालू'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकीय स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterGAT_A as a join GAT_AProvision as b on a.WorkId=b.WorkId  ";
            string unionQuery = " union select isNULL ('','')as'अ क्र', isNULL ('Total','') as 'वर्क आयडी',isNULL ('Total','') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'लेखाशीर्ष नाव',isNULL ('Total','') as 'उपविभाग',isNULL ('','') as 'तालुका',sum( cast(a.[ArthsankalpiyBab] as int)) as 'अर्थसंकल्पीय बाब',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[ManjurAmt]) as 'मंजूर अंदाजित किंमत',sum(b.[MarchEndingExpn])as 'मार्च अखेर खर्च 2017',sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud])as 'अर्थसंकल्पीय तरतूद',isNULL ('','') as 'आदेश क्र',isNULL ('','') as 'जॉब क्र',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'चालू'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकीय स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',isNULL ('','') as 'शेरा' from BudgetMasterGAT_A as a join GAT_AProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[Arthsankalpiyyear],[LekhaShirshName] order by a.[Arthsankalpiyyear], a.[ArthsankalpiyBab],a.[Upvibhag],a.taluka";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;
            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportGATASda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridGatA.DataSource = dt;
                GridGatA.DataBind();
                lblGATA.Text = "<h2>GAT A</h2>";
                btnGatA.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key7", "<script>MakeStaticHeaderGatA('" + GridGatA.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_GATA"] = GridGatA;
            }
            else
            {
                btnGatA.Visible = false;
            }
        }

        public void GATD()
        {
            GridGatD.DataSource = null;
            GridGatD.DataBind();
            lblGatD.Text = "<h2>GAT D</h2>";
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka]desc) as 'SrNo', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',a.[karyarambhadesh] as 'कार्यारंभ आदेश',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर ' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterGAT_D as a join GAT_DProvision as b on a.WorkId=b.WorkId  ";
            string unionQuery = " union select isNULL ('','')as'SrNo', 'Total' as 'वर्क आयडी',isNULL (a.[Arthsankalpiyyear],'') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'लेखशीर्ष नाव',isNULL (a.[Upvibhag],'') as 'उपविभाग',isNULL ('','0') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',isNULL ('','') as 'निविदा क्र/दिनांक',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[ManjurAmt]) as 'मंजूर अंदाजित किंमत',sum(b.[MarchEndingExpn])as 'मार्च अखेर खर्च 2017',sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud])as 'अर्थसंकल्पीय तरतूद',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर '  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',isNULL ('','') as 'शेरा' from BudgetMasterGAT_D as a join GAT_DProvision as b on a.WorkId=b.WorkId  ";

            string GroupByOrderBy = " group by a.[Arthsankalpiyyear], a.[Upvibhag]  order by a.[Arthsankalpiyyear],a.[Upvibhag],a.[Taluka]desc ";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportGATDSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridGatD.DataSource = dt;
                GridGatD.DataBind();
                lblGatD.Text = "<h2>GAT D</h2>";
                btnGatD.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key8", "<script>MakeStaticHeaderGatD('" + GridGatD.ClientID + "', 750, 100 , 100 ,false); </script>", false);

                Session["SReport_GATD"] = GridGatD;
            }
            else
            {
                btnGatD.Visible = false;
            }
        }

        public void GATF()
        {
            GridGatF.DataSource = null;
            GridGatF.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.Type as 'योजनेचे नाव',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate]) as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate]) as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',a.[karyarambhadesh] as 'कार्यारंभ आदेश',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate]) as 'निविदा क्र/दिनांक',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[KamachiKimat] as 'कामाची किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'अ क्र', 'Total' as 'वर्क आयडी',isNULL ('Total','') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'योजनेचे नाव',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'लेखाशीर्ष नाव',isNULL (a.[Upvibhag],'') as 'उपविभाग',isNULL ('','0') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'निविदा क्र/दिनांक',isNULL ('','') as 'बांधकाम कालावधी',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[KamachiKimat]) as 'कामाची किंमत',sum(b.[MarchEndingExpn]) as 'मार्च अखेर खर्च 2017',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud]) as 'अर्थसंकल्पीय तरतूद',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',isNULL ('','') as 'शेरा' from BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[Upvibhag]  order by a.[Upvibhag],a.[Arthsankalpiyyear],a.[Taluka]";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + "  and Type=N'गट एफ'  " + unionQuery + whereCondi + "  and Type=N'गट एफ'  " + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportGATFSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridGatF.DataSource = dt;
                GridGatF.DataBind();
                lblGatF.Text = "<h2>GAT F</h2>";
                btnGatFbc.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key9", "<script>MakeStaticHeaderGatF('" + GridGatF.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_GATF"] = GridGatF;
            }
            else
            {
                btnGatFbc.Visible = false;
            }
        }

        public void GATB()
        {
            GridGatB.DataSource = null;
            GridGatB.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.Type as 'योजनेचे नाव',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate]) as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate]) as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',a.[karyarambhadesh] as 'कार्यारंभ आदेश',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate]) as 'निविदा क्र/दिनांक',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[KamachiKimat] as 'कामाची किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'अ क्र', 'Total' as 'वर्क आयडी',isNULL ('Total','') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'योजनेचे नाव',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'लेखाशीर्ष नाव',isNULL (a.[Upvibhag],'') as 'उपविभाग',isNULL ('','0') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'निविदा क्र/दिनांक',isNULL ('','') as 'बांधकाम कालावधी',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[KamachiKimat]) as 'कामाची किंमत',sum(b.[MarchEndingExpn]) as 'मार्च अखेर खर्च 2017',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud]) as 'अर्थसंकल्पीय तरतूद',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',isNULL ('','') as 'शेरा' from BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[Upvibhag]  order by a.[Upvibhag],a.[Arthsankalpiyyear],a.[Taluka] ";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + "  and Type=N'गट बी'  " + unionQuery + whereCondi + "  and Type=N'गट बी'  " + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportGATBPSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridGatB.DataSource = dt;
                GridGatB.DataBind();
                lblGatB.Text = "<h2>GAT B</h2>";
                btnGAtB.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key10", "<script>MakeStaticHeaderGatB('" + GridGatB.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_GATB"] = GridGatB;
            }
            else
            {
                btnGAtB.Visible = false;
            }
        }

        public void GATC()
        {
            GridGatC.DataSource = null;
            GridGatC.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.Type as 'योजनेचे नाव',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate]) as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate]) as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',a.[karyarambhadesh] as 'कार्यारंभ आदेश',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate]) as 'निविदा क्र/दिनांक',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[KamachiKimat] as 'कामाची किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage' THEN 1 ELSE 0 END as decimal(10,0)) as'TS',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'अ क्र', 'Total' as 'वर्क आयडी',isNULL ('Total','') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'योजनेचे नाव',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'लेखाशीर्ष नाव',isNULL (a.[Upvibhag],'') as 'उपविभाग',isNULL ('','0') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'निविदा क्र/दिनांक',isNULL ('','') as 'बांधकाम कालावधी',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[KamachiKimat]) as 'कामाची किंमत',sum(b.[MarchEndingExpn]) as 'मार्च अखेर खर्च 2017',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud]) as 'अर्थसंकल्पीय तरतूद',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Estimated Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = 'Tender Stage'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS',isNULL ('','') as 'शेरा' from BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[Upvibhag]  order by a.[Upvibhag],a.[Arthsankalpiyyear],a.[Taluka]";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + "  and Type=N'गट सी'  " + unionQuery + whereCondi + "  and Type=N'गट सी'  " + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReportGATCSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridGatC.DataSource = dt;
                GridGatC.DataBind();
                lblGatC.Text = "<h2>GAT C</h2>";
                BtnGATC.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key11", "<script>MakeStaticHeaderGatC('" + GridGatC.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_GATC"] = GridNabard;
            }
            else
            {
                BtnGATC.Visible = false;
            }
        }

        public void ResidentialBuilding()
        {
            GridResidentialBuilding.DataSource = null;
            GridResidentialBuilding.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear],[Upvibhag] ORDER BY a.[Arthsankalpiyyear], [Upvibhag]) as 'SrNo',a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',b.[DeyakachiSadyasthiti] as 'देयकाची सद्यस्थिती',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा',CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर ' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS' from BudgetMasterResidentialBuilding as a join ResidentialBuildingProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'SrNo', 'Total' as 'वर्क आयडी',isNULL (a.[Arthsankalpiyyear],'') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'लेखाशीर्ष नाव',isNULL (a.[Upvibhag],'') as 'उपविभाग',isNULL ('','') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[ManjurAmt]) as 'मंजूर अंदाजित किंमत',sum(b.[MarchEndingExpn])as 'मार्च अखेर खर्च 2017',sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud])as 'अर्थसंकल्पीय तरतूद',isNULL ('','') as 'देयकाची सद्यस्थिती',isNULL ('','') as 'शेरा',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर '  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS' from BudgetMasterResidentialBuilding as a join ResidentialBuildingProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[Arthsankalpiyyear],a.[Upvibhag]  order by a.[Arthsankalpiyyear],a.[Upvibhag],a.[Taluka] desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["MasterResidentialBuildingReportSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridResidentialBuilding.DataSource = dt;
                GridResidentialBuilding.DataBind();
                lblResBuilding.Text = "<h2>Residential Building</h2>";
                btn2216.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key3", "<script>MakeStaticHeaderResidentialBuilding('" + GridResidentialBuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_ResidentialBuilding"] = GridResidentialBuilding;
            }
            else
            {
                btn2216.Visible = false;
            }
        }

        public void NonResidentialBuilding()
        {
            GridNonResidentialbuilding.DataSource = null;
            GridNonResidentialbuilding.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear],[Upvibhag] ORDER BY a.[Arthsankalpiyyear], [Upvibhag]) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा',CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर ' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS' from BudgetMasterNonResidentialBuilding as a join NonResidentialBuildingProvision as b on a.WorkId=b.WorkId ";
            string unionQuery = " union select isNULL ('','')as'अ क्र', 'Total' as 'वर्क आयडी',isNULL (a.[Arthsankalpiyyear],'') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'लेखाशीर्ष नाव',isNULL (a.[Upvibhag],'') as 'उपविभाग',isNULL ('','0') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[ManjurAmt]) as 'मंजूर अंदाजित किंमत',sum(b.[MarchEndingExpn])as 'मार्च अखेर खर्च 2017',sum(b.[UrvaritAmt]) as 'उर्वरित किंमत',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud])as 'अर्थसंकल्पीय तरतूद',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'शेरा',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर '  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS' from BudgetMasterNonResidentialBuilding as a join NonResidentialBuildingProvision as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[Arthsankalpiyyear],a.[Upvibhag]  order by a.[Arthsankalpiyyear],a.[Upvibhag],a.[Taluka] desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["MasterNonResidentialBuildingReportSda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                GridNonResidentialbuilding.DataSource = dt;
                GridNonResidentialbuilding.DataBind();
                lblNonResBuilding.Text = "<h2>NonResidential Building</h2>";
                btn2059.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key4", "<script>MakeStaticHeaderNonResidentialbuilding('" + GridNonResidentialbuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_NonResidentialBuilding"] = GridNonResidentialbuilding;
            }
            else
            {
                btn2059.Visible = false;
            }
        }

        public void Gramvikas2515()
        {
            Grid2515.DataSource = null;
            Grid2515.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            string query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka] desc) as 'SrNo', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyAmt])as 'प्रशासकीय मान्यता रक्कम',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikAmt])as 'तांत्रिक मान्यता रक्कम',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',a.[karyarambhadesh] as 'कार्यारंभ आदेश',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा',CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर ' THEN 1 ELSE 0 END as decimal(10,0)) as'ES',CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर' THEN 1 ELSE 0 END as decimal(10,0)) as'TS' from [BudgetMaster2515] as a join [2515Provision] as b on a.WorkId=b.WorkId  ";
            string unionQuery = " union select isNULL ('','')as'SrNo', 'Total' as 'वर्क आयडी',isNULL (a.[Arthsankalpiyyear],'') as 'अर्थसंकल्पीय वर्ष',isNULL ('','') as 'कामाचे नाव',isNULL ('','') as 'लेखाशीर्ष नाव',isNULL (a.[Upvibhag],'') as 'उपविभाग',isNULL ('','0') as 'तालुका',isNULL ('','') as 'ठेकेदार नाव',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'प्रशासकीय मान्यता रक्कम',isNULL ('','') as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',sum(cast(a.[TrantrikAmt] as decimal(10,2))) as 'तांत्रिक मान्यता रक्कम',isNULL ('','') as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक ',isNULL ('','') as 'कामाचा वाव',isNULL ('','') as 'कार्यारंभ आदेश',isNULL ('','') as 'निविदा क्र/दिनांक',sum(cast(a.[NividaAmt] as decimal(10,2))) as 'निविदा रक्कम % कमी / जास्त',isNULL ('','') as 'काम पूर्ण तारीख',isNULL ('','') as 'मुदतवाढ बाबत',sum(b.[ManjurAmt])as 'मंजूर किंमत',sum(b.[MarchEndingExpn])as 'मार्च अखेर खर्च 2017',sum(b.[UrvaritAmt])as 'उर्वरित किंमत',sum(b.[AikunKharch]) as 'एकुण कामावरील खर्च',sum(b.[Tartud])as 'अर्थसंकल्पीय तरतूद',isNULL ('','') as 'शेरा',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,0))) as 'C',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,0))) as 'P',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'Not Started'  THEN 1 ELSE 0 END as decimal(10,0))) as 'NS',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'अंदाजपत्रकिय स्थर '  THEN 1 ELSE 0 END as decimal(10,0))) as 'ES',sum(CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,0))) as 'TS' from [BudgetMaster2515] as a join [2515Provision] as b on a.WorkId=b.WorkId ";

            string GroupByOrderBy = " group by a.[Arthsankalpiyyear], a.[upvibhag] order by a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka] desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = query + whereCondi + unionQuery + whereCondi + GroupByOrderBy;

            sda = new SqlDataAdapter(CompleteQuery, con);
            Session["SReport2515Sda"] = sda;
            sda.Fill(dt);

            if (dt.Rows.Count > 1)
            {
                Grid2515.DataSource = dt;
                Grid2515.DataBind();
                lbl2515.Text = "<h2>GramVikas 2515</h2>";
                btn2515.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key22", "<script>MakeStaticHeader2515('" + Grid2515.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_2515"] = Grid2515;
            }
            else
            {
                btn2515.Visible = false;
            }
        }

        public void AllMethodsGrid()
            {
            ViewState["WhereCond"] = null;
            if (Label1.Text == "lblAmdar")
            {
                ViewState["WhereCond"] = " where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and a.[AmdaracheName]=N'" + ddlAmdar.SelectedItem.ToString() + "' ";
            }
            else if (Label1.Text == "lblShakhaAbhiyanta")
            {
                ViewState["WhereCond"] = "  where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and a.[ShakhaAbhyantaName]=N'" + ddlShakhaAbhiyanta.SelectedItem.ToString() + "' ";
            }
            else if (Label1.Text == "lblKhasdar")
            {
                ViewState["WhereCond"] = " where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and a.[KhasdaracheName]=N'" + ddlKhasdar.SelectedItem.ToString() + "'";
            }
            else if (Label1.Text == "lblKamachiSadyStiti")
            {
                ViewState["WhereCond"] = " where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and a.[Sadyasthiti]=N'" + ddlKamachiSadyStiti.SelectedItem.ToString() + "' ";
            }
            else if (Label1.Text == "lbltype")
            {
                ViewState["WhereCond"] = " where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and a.[SubType]=N'" + ddltype.SelectedItem.ToString() + "' ";
            }
            else if (Label1.Text == "lblShakhUpAbhiyanta")
            {
                ViewState["WhereCond"] = " where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and a.[UpabhyantaName]=N'" + ddlShakhUpAbhiyanta.SelectedItem.ToString() + "' ";
            }
            else if (Label1.Text == "lblThekedarecheName")
            {
                ViewState["WhereCond"] = " where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and a.[ThekedaarName]=N'" + ddlThekedarecheName.SelectedItem.ToString() + "' ";
            }
            else if (Label1.Text == "lblUpvibhag")
            {
                ViewState["WhereCond"] = " where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and a.[Upvibhag]=N'" + ddlUpvibhag.SelectedItem.ToString() + "' ";
            }
            else if (Label1.Text == "lblLekhashirsh")
            {
                ViewState["WhereCond"] = " where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and a.LekhaShirsh=N'" + ddlLekhashirsh.SelectedItem.ToString() + "' ";
            }
            else if (Label1.Text == "lblArthsankalpiyYear")
            {
                ViewState["WhereCond"] = " where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' ";
            }
            else if (Label1.Text == "lblTaluka")
            {
                ViewState["WhereCond"] = " where b.Arthsankalpiyyear='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and a.[Taluka]=N'" + ddlTaluka.SelectedItem.ToString() + "' ";
            }
            divAllHeadBtn.Visible = true;
            ViewState["Head"] = null;
            Building();
            CRF();
            Nabard();
            Road();
            DPDC();
            MLA();
            MP();
            Aunty();
            DepositeFund();
            GATA();
            GATD();
            GATF();
            GATB();
            GATC();
            ResidentialBuilding();
            NonResidentialBuilding();
            Gramvikas2515();
            Session["SReportPanel"] = Panel1;
        }

        protected void ddlLekhashirsh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Label1.Text = "lblLekhashirsh";
            // AllMethodsGrid();
            // System.Threading.Thread.Sleep(5000);
            // Label17.Text = "सार्वजनिक बांधकाम मंडळ, पुणे  \n" + ddlLekhashirsh.SelectedItem.ToString();
        }

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MasterReport" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            // BindGridAll();
            if (ViewState["Head"] != null)
            {
                if (ViewState["Head"].ToString() == "Building")
                {
                    if (DivRoot.Visible == true)
                    {
                        DivRoot.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "Road")
                {
                    if (DivRoot1.Visible == true)
                    {
                        DivRoot1.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "Crf")
                {
                    if (DivRootCRF.Visible == true)
                    {
                        DivRootCRF.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "Nabard")
                {
                    if (DivRootNabard.Visible == true)
                    {
                        DivRootNabard.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "Dpdc")
                {
                    if (DivRootDPDC.Visible == true)
                    {
                        DivRootDPDC.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "MLA")
                {
                    if (DivRootMLA.Visible == true)
                    {
                        DivRootMLA.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "MP")
                {
                    if (DivRootMP.Visible == true)
                    {
                        DivRootMP.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "Deposit")
                {
                    if (DivRootDepositFund.Visible == true)
                    {
                        DivRootDepositFund.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "GatA")
                {
                    if (DivRootGatA.Visible == true)
                    {
                        DivRootGatA.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "GatFbc")
                {
                    if (DivRootGatF.Visible == true)
                    {
                        DivRootGatF.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "GATB")
                {
                    if (DivRootGatB.Visible == true)
                    {
                        DivRootGatB.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "GATC")
                {
                    if (DivRootGatC.Visible == true)
                    {
                        DivRootGatC.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "GatD")
                {
                    if (DivRootGatD.Visible == true)
                    {
                        DivRootGatD.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "Annuity")
                {
                    if (DivRootAunty.Visible == true)
                    {
                        DivRootAunty.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "2216")
                {
                    if (DivRootResidentialBuilding.Visible == true)
                    {
                        DivRootResidentialBuilding.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "2059")
                {
                    if (DivRootNonResidentialbuilding.Visible == true)
                    {
                        DivRootNonResidentialbuilding.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
                else if (ViewState["Head"].ToString() == "2515")
                {
                    if (DivRoot2515.Visible == true)
                    {
                        DivRoot2515.RenderControl(htw);
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry Data Not Found...!!!')</script>");
                    }
                }
            }
            else
            {
                Panel1.RenderControl(htw);
            }
            //GridView1.RenderControl(htw);
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
            Session["filename"] = "SReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "SReport.xls");
                    //RenderAllGrid(sw, htw);
                    Panel1.RenderControl(htw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }
            Response.Redirect("SendMail.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            AllMethodsGrid();
        }

        protected void GridBuilding_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                buildgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalbuild++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalbuild - 1).ToString();
                    grandbulid += totalbuild - 1;
                    totalbuild = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[4].Text = "";

                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");

                    if (data.DataView.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        buildgrandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        buildgrandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                    }
                    //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                    buildgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));

                    buildgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));

                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        buildgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        buildgrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        buildgrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        buildgrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        buildgrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.DataView.Table.Columns["ES"] != null)
                    {
                        buildgrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.DataView.Table.Columns["TS"] != null)
                    {
                        buildgrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        buildgrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandbulid.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[buildgrandtotal.MarchAkher_Index].Text = buildgrandtotal.MarchAkher.ToString();
                e.Row.Cells[buildgrandtotal.ManjurAmt_index].Text = buildgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[buildgrandtotal.UrvaritAmt_index].Text = buildgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[buildgrandtotal.ArthsankalpTartud_Index].Text = buildgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[buildgrandtotal.EkunKamavarilKharch_Index].Text = buildgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[buildgrandtotal.PrashaskiyAmt_index].Text = buildgrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[buildgrandtotal.TantrikAmt_index].Text = buildgrandtotal.TantrikAmt.ToString();
                e.Row.Cells[buildgrandtotal.C_index].Text = buildgrandtotal.C.ToString();
                e.Row.Cells[buildgrandtotal.P_index].Text = buildgrandtotal.P.ToString();
                e.Row.Cells[buildgrandtotal.ES_index].Text = buildgrandtotal.ES.ToString();
                e.Row.Cells[buildgrandtotal.TS_index].Text = buildgrandtotal.TS.ToString();
                e.Row.Cells[buildgrandtotal.NS_index].Text = buildgrandtotal.NS.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridBuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridCRF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var data = e.Row.DataItem as DataRowView;
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
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalcrf++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalcrf - 1).ToString();
                    grandcrf += totalcrf - 1;
                    totalcrf = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[7].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["A A Amount"] != null)
                    {
                        crfgrandtotal.AAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "A A Amount"));
                    }
                    if (data.DataView.Table.Columns["T S Amount"] != null)
                    {
                        crfgrandtotal.TSAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "T S Amount"));
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
                    if (data.DataView.Table.Columns["Grand Provision"] != null)
                    {
                        crfgrandtotal.Tartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Grand Provision"));
                    }
                    if (data.DataView.Table.Columns["Total Expense"] != null)
                    {
                        crfgrandtotal.AikunKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Expense"));
                    }
                    if (data.DataView.Table.Columns["Tender Amount"] != null)
                    {
                        crfgrandtotal.TenderAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Tender Amount"));
                    }
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        crfgrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        crfgrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        crfgrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.DataView.Table.Columns["ES"] != null)
                    {
                        crfgrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.DataView.Table.Columns["TS"] != null)
                    {
                        crfgrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandcrf.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[crfgrandtotal.AAmount_index].Text = crfgrandtotal.AAmount.ToString();
                e.Row.Cells[crfgrandtotal.TSAmount_index].Text = crfgrandtotal.TSAmount.ToString();
                e.Row.Cells[crfgrandtotal.ManjurAmt_index].Text = crfgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[crfgrandtotal.MarchEnding_index].Text = crfgrandtotal.MarchEnding.ToString();
                e.Row.Cells[crfgrandtotal.UrvaritAmt_index].Text = crfgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[crfgrandtotal.Tartud_index].Text = crfgrandtotal.Tartud.ToString();
                e.Row.Cells[crfgrandtotal.AikunKharch_index].Text = crfgrandtotal.AikunKharch.ToString();
                e.Row.Cells[crfgrandtotal.TenderAmount_index].Text = crfgrandtotal.TenderAmount.ToString();
                e.Row.Cells[crfgrandtotal.C_index].Text = crfgrandtotal.C.ToString();
                e.Row.Cells[crfgrandtotal.P_index].Text = crfgrandtotal.P.ToString();
                e.Row.Cells[crfgrandtotal.ES_index].Text = crfgrandtotal.ES.ToString();
                e.Row.Cells[crfgrandtotal.TS_index].Text = crfgrandtotal.TS.ToString();
                e.Row.Cells[crfgrandtotal.NS_index].Text = crfgrandtotal.NS.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key16", "<script>MakeStaticHeaderCRF('" + GridCRF.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridNabard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                grandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalNbard++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalNbard - 1).ToString();
                    grandnabard += totalNbard - 1;
                    totalNbard = 0;
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.Cells[4].Text = "";
                    e.Row.Cells[20].Text = "";
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;
                    if (data.DataView.Table.Columns["AA cost Rs in lakhs"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        grandtotal.AACost += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AA cost Rs in lakhs"));
                    }
                    if (data.DataView.Table.Columns["Technical Sanction Cost Rs in Lakh"] != null)
                    {
                        grandtotal.TsCost += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Technical Sanction Cost Rs in Lakh"));
                    }
                    if (data.DataView.Table.Columns["Estimated Cost Approved"] != null)
                    {
                        grandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Estimated Cost Approved"));
                    }
                    if (data.DataView.Table.Columns["Expenditure up to MAR 2017"] != null)
                    {
                        grandtotal.ExpUptoMarch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Expenditure up to MAR 2017"));
                    }
                    if (data.DataView.Table.Columns["Remaining Cost"] != null)
                    {
                        grandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Remaining Cost"));
                    }
                    if (data.DataView.Table.Columns["Total Provision"] != null)
                    {
                        grandtotal.TotalPro += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Provision"));
                    }
                    if (data.DataView.Table.Columns["Total Expense"] != null)
                    {
                        grandtotal.AkunKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Expense"));
                    }
                    if (data.DataView.Table.Columns["Tender Amount"] != null)
                    {
                        grandtotal.TenderAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Tender Amount"));
                    }
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
                    if (data.DataView.Table.Columns["ES"] != null)
                    {
                        grandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.DataView.Table.Columns["TS"] != null)
                    {
                        grandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandnabard.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[grandtotal.AACost_Index - 1].Text = grandtotal.AACost.ToString();
                e.Row.Cells[grandtotal.TsCost_index - 1].Text = grandtotal.TsCost.ToString();
                e.Row.Cells[grandtotal.ManjurAmt_index - 1].Text = grandtotal.ManjurAmt.ToString();
                e.Row.Cells[grandtotal.Expmar_Index - 1].Text = grandtotal.ExpUptoMarch.ToString();
                e.Row.Cells[grandtotal.UrvaritAmt_index - 1].Text = grandtotal.UrvaritAmt.ToString();
                e.Row.Cells[grandtotal.TotalPro_index - 1].Text = grandtotal.TotalPro.ToString();
                e.Row.Cells[grandtotal.AkunKharch_index - 1].Text = grandtotal.AkunKharch.ToString();
                e.Row.Cells[grandtotal.TenderAmount_index - 1].Text = grandtotal.TenderAmount.ToString();
                e.Row.Cells[grandtotal.C_index - 1].Text = grandtotal.C.ToString();
                e.Row.Cells[grandtotal.P_index - 1].Text = grandtotal.P.ToString();
                e.Row.Cells[grandtotal.NS_index - 1].Text = grandtotal.NS.ToString();
                e.Row.Cells[grandtotal.ES_index - 1].Text = grandtotal.ES.ToString();
                e.Row.Cells[grandtotal.TS_index - 1].Text = grandtotal.TS.ToString();
            }

            if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.DataRow)
            {
                //  e.Row.Controls[5].Visible = false;// column5
                e.Row.Controls[3].Visible = false;// column3
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key15", "<script>MakeStaticHeaderNabard('" + GridNabard.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridRoad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                roadgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalroad++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalroad - 1).ToString();
                    grandroad += totalroad - 1;
                    totalroad = 0;
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[7].Text = "";
                    e.Row.Cells[4].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;
                    if (data.DataView.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        roadgrandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }
                    if (data.DataView.Table.Columns["सुरवाती पासून मार्च 2017 अखेरचा खर्च"] != null)
                    {
                        roadgrandtotal.MarchEndingExpn += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सुरवाती पासून मार्च 2017 अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        roadgrandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        roadgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["एकूण अर्थसंकल्पीय तरतूद"] != null)
                    {
                        roadgrandtotal.Tartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकूण अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        roadgrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        roadgrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        roadgrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        roadgrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        roadgrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        roadgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandroad.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[roadgrandtotal.ManjurAmt_index].Text = roadgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[roadgrandtotal.MarchEndingExpn_index].Text = roadgrandtotal.MarchEndingExpn.ToString();
                e.Row.Cells[roadgrandtotal.UrvaritAmt_index].Text = roadgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[roadgrandtotal.PrashaskiyAmt_index].Text = roadgrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[roadgrandtotal.TantrikAmt_index].Text = roadgrandtotal.TantrikAmt.ToString();
                e.Row.Cells[roadgrandtotal.NividaRakkam_index].Text = roadgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[roadgrandtotal.EkunKamavarilKharch_Index].Text = roadgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[roadgrandtotal.Tartud_index].Text = roadgrandtotal.Tartud.ToString();
                e.Row.Cells[roadgrandtotal.C_index].Text = roadgrandtotal.C.ToString();
                e.Row.Cells[roadgrandtotal.P_index].Text = roadgrandtotal.P.ToString();
                e.Row.Cells[roadgrandtotal.NS_index].Text = roadgrandtotal.NS.ToString();

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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key2", "<script>MakeStaticHeader1('" + GridRoad.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridDPDC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;

                totalDpdc++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalDpdc - 1).ToString();
                    grandDpdc += totalDpdc - 1;
                    totalDpdc = 0;
                    e.Row.Cells[5].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["एकूण अंदाजित किंमत (अलिकडील सुधारित)"] != null)
                    {
                        dpdcgrandtotal.AkunAndajit += Convert.ToDecimal(e.Row.Cells[dpdcgrandtotal.AkunAndajit_index].Text);
                        // dpdcgrandtotal.AkunAndajit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकूण अंदाजित किंमत (अलिकडील सुधारित)"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        dpdcgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        dpdcgrandtotal.UrvritKimmat += Convert.ToDecimal(e.Row.Cells[dpdcgrandtotal.UrvritKimmat_index].Text);
                        //dpdcgrandtotal.UrvritKimmat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत (6-(8+9))"));
                    }
                    if (data.DataView.Table.Columns["2017-2018 करीता प्रस्तावित तरतूद"] != null)
                    {
                        dpdcgrandtotal.KaritaPrasta += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-2018 करीता प्रस्तावित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        dpdcgrandtotal.AkunKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        dpdcgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        dpdcgrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        dpdcgrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        dpdcgrandtotal.Purn += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        dpdcgrandtotal.Pragatit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        dpdcgrandtotal.NotStarted += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.DataView.Table.Columns["ES"] != null)
                    {
                        dpdcgrandtotal.Estimated += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.DataView.Table.Columns["TS"] != null)
                    {
                        dpdcgrandtotal.NividaStar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandDpdc.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[dpdcgrandtotal.AkunAndajit_index].Text = dpdcgrandtotal.AkunAndajit.ToString();
                e.Row.Cells[dpdcgrandtotal.MarchAkher_index].Text = dpdcgrandtotal.MarchAkher.ToString();
                e.Row.Cells[dpdcgrandtotal.UrvritKimmat_index].Text = dpdcgrandtotal.UrvritKimmat.ToString();
                e.Row.Cells[dpdcgrandtotal.KaritaPrasta_index].Text = dpdcgrandtotal.KaritaPrasta.ToString();
                e.Row.Cells[dpdcgrandtotal.AkunKharch_index].Text = dpdcgrandtotal.AkunKharch.ToString();
                e.Row.Cells[dpdcgrandtotal.NividaRakkam_index].Text = dpdcgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[dpdcgrandtotal.TantrikAmt_index].Text = dpdcgrandtotal.TantrikAmt.ToString();
                e.Row.Cells[dpdcgrandtotal.PrashaskiyAmt_index].Text = dpdcgrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[dpdcgrandtotal.Purn_index].Text = dpdcgrandtotal.Purn.ToString();
                e.Row.Cells[dpdcgrandtotal.Pragatit_index].Text = dpdcgrandtotal.Pragatit.ToString();
                e.Row.Cells[dpdcgrandtotal.NotStarted_index].Text = dpdcgrandtotal.NotStarted.ToString();
                e.Row.Cells[dpdcgrandtotal.Estimated_index].Text = dpdcgrandtotal.Estimated.ToString();
                e.Row.Cells[dpdcgrandtotal.NividaStar_index].Text = dpdcgrandtotal.NividaStar.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key14", "<script>MakeStaticHeaderDPDC('" + GridDPDC.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridMLA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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

                mlagrnadtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;

                totalMla++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalMla - 1).ToString();
                    // grandbulid += totalbuild - 1;
                    grandMla += totalMla - 1;
                    totalMla = 0;
                    e.Row.Cells[7].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.Row.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        mlagrnadtotal.MarchAkher += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.MarchAkher_index].Text);
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
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        mlagrnadtotal.Purn += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Purn_index].Text);
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        mlagrnadtotal.Pragatit += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Pragatit_index].Text);
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        mlagrnadtotal.NotStarted += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.NotStarted_index].Text);
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        mlagrnadtotal.Estimated += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Estimated_index].Text);
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        mlagrnadtotal.NividaStar += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.NividaStar_index].Text);
                    }
                    if (data.Row.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        mlagrnadtotal.NividaRakkam += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.NividaRakkam_Index].Text);
                    }
                    if (data.Row.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        mlagrnadtotal.AkunKamavarilKharch += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.AkunKamavarilKharch_index].Text);
                    }
                    if (data.Row.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        mlagrnadtotal.PrashaskiyAmt += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.PrashaskiyAmt_index].Text);
                    }
                    if (data.Row.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        mlagrnadtotal.TantrikAmt += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.TantrikAmt_index].Text);
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandMla.ToString();
                e.Row.Cells[1].Text = "Grand Total";

                e.Row.Cells[mlagrnadtotal.MarchAkher_index].Text = mlagrnadtotal.MarchAkher.ToString();
                e.Row.Cells[mlagrnadtotal.SanMadil_index].Text = mlagrnadtotal.SanMadil.ToString();
                e.Row.Cells[mlagrnadtotal.UrvritKimmat_index].Text = mlagrnadtotal.UrvritKimmat.ToString();
                e.Row.Cells[mlagrnadtotal.KamNihay_index].Text = mlagrnadtotal.KamNihay.ToString();
                e.Row.Cells[mlagrnadtotal.Purn_index].Text = mlagrnadtotal.Purn.ToString();
                e.Row.Cells[mlagrnadtotal.Pragatit_index].Text = mlagrnadtotal.Pragatit.ToString();
                e.Row.Cells[mlagrnadtotal.NividaStar_index].Text = mlagrnadtotal.NividaStar.ToString();
                e.Row.Cells[mlagrnadtotal.Estimated_index].Text = mlagrnadtotal.Estimated.ToString();
                e.Row.Cells[mlagrnadtotal.NotStarted_index].Text = mlagrnadtotal.NotStarted.ToString();
                e.Row.Cells[mlagrnadtotal.AkunKamavarilKharch_index].Text = mlagrnadtotal.AkunKamavarilKharch.ToString();
                e.Row.Cells[mlagrnadtotal.NividaRakkam_Index].Text = mlagrnadtotal.NividaRakkam.ToString();
                e.Row.Cells[mlagrnadtotal.PrashaskiyAmt_index].Text = mlagrnadtotal.TantrikAmt.ToString();
                e.Row.Cells[mlagrnadtotal.TantrikAmt_index].Text = mlagrnadtotal.PrashaskiyAmt.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key13", "<script>MakeStaticHeaderMLA('" + GridMLA.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridMP_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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

                mpgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalMp++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalMp - 1).ToString();
                    grandMp += totalMp - 1;
                    totalMp = 0;
                    e.Row.Cells[3].Text = "";
                    e.Row.Cells[5].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.Row.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        mpgrandtotal.Anudan += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Anudan_index].Text);
                    }
                    if (data.Row.Table.Columns["एकुण खर्च"] != null)
                    {
                        mpgrandtotal.AkunKharch += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.AkunKharch_index].Text);
                    }
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        mpgrandtotal.Purn += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        mpgrandtotal.Pragatit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        mpgrandtotal.NividaStar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        mpgrandtotal.Estimated += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        mpgrandtotal.NotStarted += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
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
                    if (data.Row.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        mpgrandtotal.NividaRakkam += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.NividaRakkam_Index].Text);
                    }
                    if (data.Row.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        mpgrandtotal.PrashaskiyAmt += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.PrashaskiyAmt_index].Text);
                    }
                    if (data.Row.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        mpgrandtotal.TantrikAmt += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.TantrikAmt_index].Text);
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandMp.ToString();
                e.Row.Cells[1].Text = "Grand Total";

                e.Row.Cells[mpgrandtotal.NividaRakkam_Index].Text = mpgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[mpgrandtotal.Anudan_index].Text = mpgrandtotal.Anudan.ToString();
                e.Row.Cells[mpgrandtotal.AkunKharch_index].Text = mpgrandtotal.AkunKharch.ToString();
                e.Row.Cells[mpgrandtotal.Purn_index].Text = mpgrandtotal.Purn.ToString();
                e.Row.Cells[mpgrandtotal.Pragatit_index].Text = mpgrandtotal.Pragatit.ToString();
                e.Row.Cells[mpgrandtotal.NividaStar_index].Text = mpgrandtotal.NividaStar.ToString();
                e.Row.Cells[mpgrandtotal.NotStarted_index].Text = mpgrandtotal.NotStarted.ToString();
                e.Row.Cells[mpgrandtotal.Estimated_index].Text = mpgrandtotal.Estimated.ToString();
                e.Row.Cells[mpgrandtotal.ArthsankalpTartud_index].Text = mpgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[mpgrandtotal.ApekshitKharch_index].Text = mpgrandtotal.ApekshitKharch.ToString();
                e.Row.Cells[mpgrandtotal.UrvritKimmat_index].Text = mpgrandtotal.UrvritKimmat.ToString();
                e.Row.Cells[mpgrandtotal.PrashaskiyAmt_index].Text = mpgrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[mpgrandtotal.TantrikAmt_index].Text = mpgrandtotal.TantrikAmt.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key12", "<script>MakeStaticHeaderMP('" + GridMP.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridGatC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                gatCgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalGatC++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalGatC - 1).ToString();
                    grandGatC += totalGatC - 1;
                    totalGatC = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[7].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        gatCgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        gatCgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        gatCgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["कामाची किंमत"] != null)
                    {
                        gatCgrandtotal.KamchiKimat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "कामाची किंमत"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        gatCgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        gatCgrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        gatCgrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        gatCgrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        gatCgrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        gatCgrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.DataView.Table.Columns["ES"] != null)
                    {
                        gatCgrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.DataView.Table.Columns["TS"] != null)
                    {
                        gatCgrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandGatC.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.BackColor = System.Drawing.Color.LightYellow;

                e.Row.Cells[gatCgrandtotal.MarchAkher_Index].Text = gatCgrandtotal.MarchAkher.ToString();
                e.Row.Cells[gatCgrandtotal.EkunKamavarilKharch_Index].Text = gatCgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[gatCgrandtotal.KamchiKimat_index].Text = gatCgrandtotal.KamchiKimat.ToString();
                e.Row.Cells[gatCgrandtotal.NividaRakkam_index].Text = gatCgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[gatCgrandtotal.ArthsankalpTartud_Index].Text = gatCgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[gatCgrandtotal.PrashaskiyAmt_index].Text = gatCgrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[gatCgrandtotal.TantrikAmt_index].Text = gatCgrandtotal.TantrikAmt.ToString();
                e.Row.Cells[gatCgrandtotal.C_index].Text = gatCgrandtotal.C.ToString();
                e.Row.Cells[gatCgrandtotal.P_index].Text = gatCgrandtotal.P.ToString();
                e.Row.Cells[gatCgrandtotal.NS_index].Text = gatCgrandtotal.NS.ToString();
                e.Row.Cells[gatCgrandtotal.ES_index].Text = gatCgrandtotal.ES.ToString();
                e.Row.Cells[gatCgrandtotal.TS_index].Text = gatCgrandtotal.TS.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key11", "<script>MakeStaticHeaderGatC('" + GridGatC.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridGatB_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                gatBgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalGatB++;
                if (e.Row.Cells[1].Text == "Total")
                {

                    e.Row.Cells[0].Text = (totalGatB - 1).ToString();
                    grandGatB += totalGatB - 1;
                    rowcount = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[7].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        gatBgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        gatBgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        gatBgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["कामाची किंमत"] != null)
                    {
                        gatBgrandtotal.KamchiKimat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "कामाची किंमत"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        gatBgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        gatBgrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        gatBgrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        gatBgrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        gatBgrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        gatBgrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.DataView.Table.Columns["ES"] != null)
                    {
                        gatBgrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.DataView.Table.Columns["TS"] != null)
                    {
                        gatBgrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandGatB.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[gatBgrandtotal.MarchAkher_Index].Text = gatBgrandtotal.MarchAkher.ToString();
                e.Row.Cells[gatBgrandtotal.EkunKamavarilKharch_Index].Text = gatBgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[gatBgrandtotal.KamchiKimat_index].Text = gatBgrandtotal.KamchiKimat.ToString();
                e.Row.Cells[gatBgrandtotal.NividaRakkam_index].Text = gatBgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[gatBgrandtotal.ArthsankalpTartud_Index].Text = gatBgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[gatBgrandtotal.PrashaskiyAmt_index].Text = gatBgrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[gatBgrandtotal.TantrikAmt_index].Text = gatBgrandtotal.TantrikAmt.ToString();
                e.Row.Cells[gatBgrandtotal.C_index].Text = gatBgrandtotal.C.ToString();
                e.Row.Cells[gatBgrandtotal.P_index].Text = gatBgrandtotal.P.ToString();
                e.Row.Cells[gatBgrandtotal.NS_index].Text = gatBgrandtotal.NS.ToString();
                e.Row.Cells[gatBgrandtotal.ES_index].Text = gatBgrandtotal.ES.ToString();
                e.Row.Cells[gatBgrandtotal.TS_index].Text = gatCgrandtotal.TS.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key10", "<script>MakeStaticHeaderGatB('" + GridGatB.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridGatF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                gatFgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalGatF++;
                if (e.Row.Cells[1].Text == "Total")
                {

                    e.Row.Cells[0].Text = (totalGatF - 1).ToString();
                    grandGatF += totalGatF - 1;
                    totalGatF = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[7].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        gatFgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        gatFgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        gatFgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["कामाची किंमत"] != null)
                    {
                        gatFgrandtotal.KamchiKimat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "कामाची किंमत"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        gatFgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        gatFgrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        gatFgrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        gatFgrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        gatFgrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        gatFgrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.DataView.Table.Columns["ES"] != null)
                    {
                        gatFgrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.DataView.Table.Columns["TS"] != null)
                    {
                        gatBgrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandGatF.ToString();
                e.Row.Cells[1].Text = "Grand Total";

                e.Row.Cells[gatFgrandtotal.MarchAkher_Index].Text = gatFgrandtotal.MarchAkher.ToString();
                e.Row.Cells[gatFgrandtotal.EkunKamavarilKharch_Index].Text = gatFgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[gatFgrandtotal.KamchiKimat_index].Text = gatFgrandtotal.KamchiKimat.ToString();
                e.Row.Cells[gatFgrandtotal.NividaRakkam_index].Text = gatFgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[gatFgrandtotal.ArthsankalpTartud_Index].Text = gatFgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[gatFgrandtotal.PrashaskiyAmt_index].Text = gatFgrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[gatFgrandtotal.TantrikAmt_index].Text = gatFgrandtotal.TantrikAmt.ToString();
                e.Row.Cells[gatFgrandtotal.C_index].Text = gatFgrandtotal.C.ToString();
                e.Row.Cells[gatFgrandtotal.P_index].Text = gatFgrandtotal.P.ToString();
                e.Row.Cells[gatFgrandtotal.NS_index].Text = gatFgrandtotal.NS.ToString();
                e.Row.Cells[gatFgrandtotal.ES_index].Text = gatFgrandtotal.ES.ToString();
                e.Row.Cells[gatFgrandtotal.TS_index].Text = gatFgrandtotal.TS.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key9", "<script>MakeStaticHeaderGatF('" + GridGatF.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridGatD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var data = e.Row.DataItem as DataRowView;
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
                gatDgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalGatD++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalGatD - 1).ToString();
                    grandGatD += totalGatD - 1;
                    totalGatD = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[6].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        gatDgrandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        gatDgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        gatDgrandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        gatDgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        gatDgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        //gatDgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                        gatDgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        gatDgrandtotal.C += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Purn_index].Text);
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        gatDgrandtotal.P += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Pragatit_index].Text);
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        gatDgrandtotal.NS += Convert.ToDecimal(e.Row.Cells[gatDgrandtotal.NS_index].Text);
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        gatDgrandtotal.ES += Convert.ToDecimal(e.Row.Cells[gatDgrandtotal.ES_index].Text);
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        gatDgrandtotal.TS += Convert.ToDecimal(e.Row.Cells[gatDgrandtotal.TS_index].Text);
                    }
                    if (data.Row.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        gatDgrandtotal.PrashaskiyAmt += Convert.ToDecimal(e.Row.Cells[gatDgrandtotal.PrashaskiyAmt_index].Text);
                    }
                    if (data.Row.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        gatDgrandtotal.TantrikAmt += Convert.ToDecimal(e.Row.Cells[gatDgrandtotal.TantrikAmt_index].Text);
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandGatD.ToString();
                e.Row.Cells[1].Text = "Grand Total";

                e.Row.Cells[gatDgrandtotal.ManjurAmt_index].Text = gatDgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[gatDgrandtotal.MarchAkher_Index].Text = gatDgrandtotal.MarchAkher.ToString();
                e.Row.Cells[gatDgrandtotal.UrvaritAmt_index].Text = gatDgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[gatDgrandtotal.ArthsankalpTartud_Index].Text = gatDgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[gatDgrandtotal.EkunKamavarilKharch_Index].Text = gatDgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[gatDgrandtotal.NividaRakkam_index].Text = gatDgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[gatDgrandtotal.C_index].Text = gatDgrandtotal.C.ToString();
                e.Row.Cells[gatDgrandtotal.P_index].Text = gatDgrandtotal.P.ToString();
                e.Row.Cells[gatDgrandtotal.NS_index].Text = gatDgrandtotal.NS.ToString();
                e.Row.Cells[gatDgrandtotal.ES_index].Text = gatDgrandtotal.ES.ToString();
                e.Row.Cells[gatDgrandtotal.TS_index].Text = gatDgrandtotal.TS.ToString();
                e.Row.Cells[gatDgrandtotal.TantrikAmt_index].Text = gatDgrandtotal.TantrikAmt.ToString();
                e.Row.Cells[gatDgrandtotal.PrashaskiyAmt_index].Text = gatDgrandtotal.PrashaskiyAmt.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key8", "<script>MakeStaticHeaderGatD('" + GridGatD.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridGatA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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

                gatAgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;

                totalgatA++;
                if (e.Row.Cells[1].Text == "Total")
                {

                    var data = e.Row.DataItem as DataRowView;
                    e.Row.Cells[0].Text = (totalgatA - 1).ToString();

                    grandgatA += totalgatA - 1;
                    totalgatA = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[6].Text = "";
                    e.Row.Cells[8].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["अर्थसंकल्पीय बाब"] != null)
                    {
                        e.Row.Cells[gatAgrandtotal.ArthsankalpBab_index].Text = "";
                    }
                    if (data.DataView.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        gatAgrandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        gatAgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        gatAgrandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        gatAgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        gatAgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        gatAgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        gatAgrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        gatAgrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        gatAgrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        gatAgrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        gatAgrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.DataView.Table.Columns["ES"] != null)
                    {
                        gatAgrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.DataView.Table.Columns["TS"] != null)
                    {
                        gatAgrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandgatA.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[gatAgrandtotal.ManjurAmt_index].Text = gatAgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[gatAgrandtotal.MarchAkher_Index].Text = gatAgrandtotal.MarchAkher.ToString();
                e.Row.Cells[gatAgrandtotal.UrvaritAmt_index].Text = gatAgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[gatAgrandtotal.ArthsankalpTartud_Index].Text = gatAgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[gatAgrandtotal.EkunKamavarilKharch_Index].Text = gatAgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[gatAgrandtotal.NividaRakkam_index].Text = gatAgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[gatAgrandtotal.C_index].Text = gatAgrandtotal.C.ToString();
                e.Row.Cells[gatAgrandtotal.P_index].Text = gatAgrandtotal.P.ToString();
                e.Row.Cells[gatAgrandtotal.NS_index].Text = gatAgrandtotal.NS.ToString();
                e.Row.Cells[gatAgrandtotal.ES_index].Text = gatAgrandtotal.ES.ToString();
                e.Row.Cells[gatAgrandtotal.TS_index].Text = gatAgrandtotal.TS.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key7", "<script>MakeStaticHeaderGatA('" + GridGatA.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridDepositFund_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                depositegrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalDeposite++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalDeposite - 1).ToString();
                    grandDeposite += totalDeposite - 1;
                    totalDeposite = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[6].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        depositegrandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        depositegrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        depositegrandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        depositegrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        depositegrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        depositegrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        depositegrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        depositegrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        depositegrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        depositegrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.DataView.Table.Columns["ES"] != null)
                    {
                        depositegrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.DataView.Table.Columns["TS"] != null)
                    {
                        depositegrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }

                    //if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    //{
                    //    depositegrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    //}
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandDeposite.ToString();
                e.Row.Cells[1].Text = "Grand Total";

                e.Row.Cells[depositegrandtotal.ManjurAmt_index].Text = depositegrandtotal.ManjurAmt.ToString();
                e.Row.Cells[depositegrandtotal.UrvaritAmt_index].Text = depositegrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[depositegrandtotal.MarchAkher_Index].Text = depositegrandtotal.MarchAkher.ToString();
                e.Row.Cells[depositegrandtotal.ArthsankalpTartud_Index].Text = depositegrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[depositegrandtotal.EkunKamavarilKharch_Index].Text = depositegrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[depositegrandtotal.TantrikAmt_index].Text = depositegrandtotal.TantrikAmt.ToString();
                e.Row.Cells[depositegrandtotal.PrashaskiyAmt_index].Text = depositegrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[depositegrandtotal.C_index].Text = depositegrandtotal.C.ToString();
                e.Row.Cells[depositegrandtotal.P_index].Text = depositegrandtotal.P.ToString();
                e.Row.Cells[depositegrandtotal.TS_index].Text = depositegrandtotal.TS.ToString();
                e.Row.Cells[depositegrandtotal.ES_index].Text = depositegrandtotal.ES.ToString();
                e.Row.Cells[depositegrandtotal.NS_index].Text = depositegrandtotal.NS.ToString();
                //e.Row.Cells[depositegrandtotal.NividaRakkam_index].Text = depositegrandtotal.NividaRakkam.ToString();               
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key6", "<script>MakeStaticHeaderDepositFund('" + GridDepositFund.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridAunty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                anutygrandtotal.index(HeadrName);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalAnuty++;
                if (e.Row.Cells[1].Text == "Total")
                {

                    e.Row.Cells[0].Text = (totalAnuty - 1).ToString();
                    grandAnuty += totalAnuty - 1;
                    totalAnuty = 0;
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[9].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.Row.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        anutygrandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }
                    if (data.Row.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        anutygrandtotal.MarchEndingExpn += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.Row.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        anutygrandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                    }
                    if (data.Row.Table.Columns["एकूण अर्थसंकल्पीय तरतूद"] != null)
                    {
                        anutygrandtotal.Tartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकूण अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        anutygrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        anutygrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        anutygrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        anutygrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        anutygrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        anutygrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        anutygrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        anutygrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        anutygrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandAnuty.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[anutygrandtotal.ManjurAmt_index].Text = anutygrandtotal.ManjurAmt.ToString();
                e.Row.Cells[anutygrandtotal.MarchEndingExpn_index].Text = anutygrandtotal.MarchEndingExpn.ToString();
                e.Row.Cells[anutygrandtotal.UrvaritAmt_index].Text = anutygrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[anutygrandtotal.Tartud_index].Text = anutygrandtotal.Tartud.ToString();
                e.Row.Cells[anutygrandtotal.C_index].Text = anutygrandtotal.C.ToString();
                e.Row.Cells[anutygrandtotal.P_index].Text = anutygrandtotal.P.ToString();
                e.Row.Cells[anutygrandtotal.NS_index].Text = anutygrandtotal.NS.ToString();
                e.Row.Cells[anutygrandtotal.ES_index].Text = anutygrandtotal.ES.ToString();
                e.Row.Cells[anutygrandtotal.TS_index].Text = anutygrandtotal.TS.ToString();
                e.Row.Cells[anutygrandtotal.EkunKamavarilkharch_index].Text = anutygrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[anutygrandtotal.NividaRakkam_index].Text = anutygrandtotal.NividaRakkam.ToString();
                e.Row.Cells[anutygrandtotal.PrashaskiyAmt_index].Text = anutygrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[anutygrandtotal.TantrikAmt_index].Text = anutygrandtotal.TantrikAmt.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key5", "<script>MakeStaticHeaderAunty('" + GridAunty.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridNonResidentialbuilding_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                nonresibuilgranddtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalnonresibuild++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalnonresibuild - 1).ToString();
                    grandnonresibuild += totalnonresibuild - 1;
                    totalnonresibuild = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[6].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;
                    //Check column is in List or Not(checkbox checked or not)
                    if (data.DataView.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        nonresibuilgranddtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        nonresibuilgranddtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        nonresibuilgranddtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        nonresibuilgranddtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        nonresibuilgranddtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        nonresibuilgranddtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        nonresibuilgranddtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        nonresibuilgranddtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        nonresibuilgranddtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        nonresibuilgranddtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        nonresibuilgranddtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    if (data.Row.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        nonresibuilgranddtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.Row.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        nonresibuilgranddtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandnonresibuild.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[nonresibuilgranddtotal.ManjurAmt_index].Text = nonresibuilgranddtotal.ManjurAmt.ToString(); e.Row.Cells[nonresibuilgranddtotal.MarchAkher_Index].Text = nonresibuilgranddtotal.MarchAkher.ToString();
                e.Row.Cells[nonresibuilgranddtotal.UrvaritAmt_index].Text = nonresibuilgranddtotal.UrvaritAmt.ToString();
                e.Row.Cells[nonresibuilgranddtotal.ArthsankalpTartud_Index].Text = nonresibuilgranddtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[nonresibuilgranddtotal.EkunKamavarilKharch_Index].Text = nonresibuilgranddtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[nonresibuilgranddtotal.NividaRakkam_index].Text = nonresibuilgranddtotal.NividaRakkam.ToString();
                e.Row.Cells[nonresibuilgranddtotal.C_index].Text = nonresibuilgranddtotal.C.ToString();
                e.Row.Cells[nonresibuilgranddtotal.P_index].Text = nonresibuilgranddtotal.P.ToString();
                e.Row.Cells[nonresibuilgranddtotal.NS_index].Text = nonresibuilgranddtotal.NS.ToString();
                e.Row.Cells[nonresibuilgranddtotal.ES_index].Text = nonresibuilgranddtotal.ES.ToString();
                e.Row.Cells[nonresibuilgranddtotal.TS_index].Text = nonresibuilgranddtotal.TS.ToString();
                e.Row.Cells[nonresibuilgranddtotal.TantrikAmt_index].Text = nonresibuilgranddtotal.TantrikAmt.ToString();
                e.Row.Cells[nonresibuilgranddtotal.PrashaskiyAmt_index].Text = nonresibuilgranddtotal.PrashaskiyAmt.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key4", "<script>MakeStaticHeaderNonResidentialbuilding('" + GridNonResidentialbuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void GridResidentialBuilding_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                resibuildgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalresibulid++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (totalresibulid - 1).ToString();
                    grandresibuild += totalresibulid - 1;
                    totalresibulid = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[6].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        resibuildgrandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        resibuildgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        resibuildgrandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        resibuildgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        resibuildgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        resibuildgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.Row.Table.Columns["C"] != null)
                    {
                        resibuildgrandtotal.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.Row.Table.Columns["P"] != null)
                    {
                        resibuildgrandtotal.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.Row.Table.Columns["NS"] != null)
                    {
                        resibuildgrandtotal.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.Row.Table.Columns["ES"] != null)
                    {
                        resibuildgrandtotal.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.Row.Table.Columns["TS"] != null)
                    {
                        resibuildgrandtotal.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                    if (data.Row.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        resibuildgrandtotal.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.Row.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        resibuildgrandtotal.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grandresibuild.ToString();
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[resibuildgrandtotal.ManjurAmt_index].Text = resibuildgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[resibuildgrandtotal.MarchAkher_Index].Text = resibuildgrandtotal.MarchAkher.ToString();
                e.Row.Cells[resibuildgrandtotal.UrvaritAmt_index].Text = resibuildgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[resibuildgrandtotal.ArthsankalpTartud_Index].Text = resibuildgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[resibuildgrandtotal.EkunKamavarilKharch_Index].Text = resibuildgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[resibuildgrandtotal.YearExp_Index].Text = resibuildgrandtotal.YearExp.ToString();
                e.Row.Cells[resibuildgrandtotal.NividaRakkam_index].Text = resibuildgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[resibuildgrandtotal.C_index].Text = resibuildgrandtotal.C.ToString();
                e.Row.Cells[resibuildgrandtotal.P_index].Text = resibuildgrandtotal.P.ToString();
                e.Row.Cells[resibuildgrandtotal.NS_index].Text = resibuildgrandtotal.NS.ToString();
                e.Row.Cells[resibuildgrandtotal.ES_index].Text = resibuildgrandtotal.ES.ToString();
                e.Row.Cells[resibuildgrandtotal.TS_index].Text = resibuildgrandtotal.TS.ToString();
                e.Row.Cells[resibuildgrandtotal.PrashaskiyAmt_index].Text = resibuildgrandtotal.PrashaskiyAmt.ToString();
                e.Row.Cells[resibuildgrandtotal.TantrikAmt_index].Text = resibuildgrandtotal.TantrikAmt.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key3", "<script>MakeStaticHeaderResidentialBuilding('" + GridResidentialBuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void Grid2515_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                grand2515total.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                total2515++;
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.Cells[0].Text = (total2515 - 1).ToString();
                    grand2515 += total2515 - 1;
                    total2515 = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[6].Text = "";

                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");

                    if (data.Row.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        grand2515total.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.Row.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        grand2515total.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.Row.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        grand2515total.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
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
                    if (data.DataView.Table.Columns["प्रशासकीय मान्यता रक्कम"] != null)
                    {
                        grand2515total.PrashaskiyAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रशासकीय मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["तांत्रिक मान्यता रक्कम"] != null)
                    {
                        grand2515total.TantrikAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तांत्रिक मान्यता रक्कम"));
                    }
                    if (data.DataView.Table.Columns["C"] != null)
                    {
                        grand2515total.C += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "C"));
                    }
                    if (data.DataView.Table.Columns["P"] != null)
                    {
                        grand2515total.P += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "P"));
                    }
                    if (data.DataView.Table.Columns["NS"] != null)
                    {
                        grand2515total.NS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NS"));
                    }
                    if (data.DataView.Table.Columns["ES"] != null)
                    {
                        grand2515total.ES += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ES"));
                    }
                    if (data.DataView.Table.Columns["TS"] != null)
                    {
                        grand2515total.TS += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[0].Text = "No Of Work = " + grand2515.ToString();
                e.Row.Cells[1].Text = "Grand Total";

                e.Row.Cells[grand2515total.MarchAkher_Index].Text = grand2515total.MarchAkher.ToString();
                e.Row.Cells[grand2515total.ArthsankalpTartud_Index].Text = grand2515total.ArthsankalpTartud.ToString();
                e.Row.Cells[grand2515total.EkunKamavarilKharch_Index].Text = grand2515total.EkunKamavarilKharch.ToString();
                e.Row.Cells[grand2515total.UrvaritAmt_index].Text = grand2515total.UrvaritAmt.ToString();
                e.Row.Cells[grand2515total.ManjurAmt_index].Text = grand2515total.ManjurAmt.ToString();
                e.Row.Cells[grand2515total.TantrikAmt_index].Text = grand2515total.TantrikAmt.ToString();
                e.Row.Cells[grand2515total.PrashaskiyAmt_index].Text = grand2515total.PrashaskiyAmt.ToString();
                e.Row.Cells[grand2515total.NividaRakkam_index].Text = grand2515total.NividaRakkam.ToString();
                e.Row.Cells[grand2515total.C_index].Text = grand2515total.C.ToString();
                e.Row.Cells[grand2515total.P_index].Text = grand2515total.P.ToString();
                e.Row.Cells[grand2515total.NS_index].Text = grand2515total.NS.ToString();
                e.Row.Cells[grand2515total.ES_index].Text = grand2515total.ES.ToString();
                e.Row.Cells[grand2515total.TS_index].Text = grand2515total.TS.ToString();
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key22", "<script>MakeStaticHeader2515('" + Grid2515.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void lekhashirshbtn_Click(object sender, EventArgs e)
        {
            Label1.Text = "lblLekhashirsh";
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddlLekhashirsh.SelectedItem.ToString();
            ListMenu.Visible = false;
        }

        protected void typebtn_Click(object sender, EventArgs e)
        {
            Label1.Text = "lbltype";
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddltype.SelectedItem.ToString();
            ListMenu.Visible = false;
        }

        protected void Upvibhagbtn_Click(object sender, EventArgs e)
        {
            Label1.Text = "lblUpvibhag";
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddlUpvibhag.SelectedItem.ToString();
            ListMenu.Visible = false;
        }

        protected void ShakhaAbhiyantabtn_Click(object sender, EventArgs e)
        {
            Label1.Text = "lblShakhaAbhiyanta";
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddlShakhaAbhiyanta.SelectedItem.ToString();
            ListMenu.Visible = false;
        }

        protected void ShakhUpAbhiyanta_Click(object sender, EventArgs e)
        {
            Label1.Text = "lblShakhUpAbhiyanta";
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddlShakhUpAbhiyanta.SelectedItem.ToString();
            ListMenu.Visible = false;
        }

        protected void Talukabtn_Click(object sender, EventArgs e)
        {
            Label1.Text = "lblTaluka";
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddlTaluka.SelectedItem.ToString();
            ListMenu.Visible = false;
        }

        protected void Amdarbtn_Click(object sender, EventArgs e)
        {
            Label1.Text = "lblAmdar";
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddlAmdar.SelectedItem.ToString();
            ListMenu.Visible = false;
        }

        protected void ThekedarecheNamebtn_Click(object sender, EventArgs e)
        {
            Label1.Text = "lblThekedarecheName";
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddlThekedarecheName.SelectedItem.ToString();
            ListMenu.Visible = false;
        }

        protected void ArthsankalpiyYearbtn_Click(object sender, EventArgs e)
        {
            Label1.Text = "lblArthsankalpiyYear";
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddlArthsankalpiyYear.SelectedItem.ToString();
            ListMenu.Visible = false;
        }

        protected void KamachiSadyStiti_Click(object sender, EventArgs e)
        {
            Label1.Text = "lblKamachiSadyStiti";
            if (ddlKamachiSadyStiti.SelectedItem.Text == "चालू")
            {
                lblsadysthiti.Text = "Processing";
            }
            else if (ddlKamachiSadyStiti.SelectedItem.Text == "अपूर्ण")
            {
                lblsadysthiti.Text = "Incomplete";
            }
            else if (ddlKamachiSadyStiti.SelectedItem.Text == "पूर्ण")
            {
                lblsadysthiti.Text = "Completed";
            }
            else if (ddlKamachiSadyStiti.SelectedItem.Text == "सुरु करणे")
            {
                lblsadysthiti.Text = "Not Started";
            }
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddlKamachiSadyStiti.SelectedItem.ToString();
        }

        protected void Khasdarbtn_Click(object sender, EventArgs e)
        {
            Label1.Text = "lblKhasdar";
            AllMethodsGrid();
            //System.Threading.Thread.Sleep(5000);
            Label17.Text = ddlKhasdar.SelectedItem.ToString();
        }

        protected void btnHideList_Click(object sender, EventArgs e)
        {
            if (ListMenu.Visible == true)
            {
                ListMenu.Visible = false;
            }
            else
            {
                ListMenu.Visible = true;
            }
            if (Session["SReport_Building"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyBuild11", "<script>MakeStaticHeader('" + GridBuilding.ClientID + "', 750, 100 , 100 ,true); </script>", false);
            }
            if (Session["SReport_CRF"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyCRF11", "<script>MakeStaticHeaderCRF('" + GridCRF.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_Nabard"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyNabard11", "<script>MakeStaticHeaderNabard('" + GridNabard.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_Road"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyRoad11", "<script>MakeStaticHeader1('" + GridRoad.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_DPDC"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyDPDC11", "<script>MakeStaticHeaderDPDC('" + GridDPDC.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }

            if (Session["SReport_MLA"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyMLA11", "<script>MakeStaticHeaderMLA('" + GridMLA.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_MP"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyMP11", "<script>MakeStaticHeaderMP('" + GridMP.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_Anuty"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyAnnuity11", "<script>MakeStaticHeaderAunty('" + GridAunty.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_DepositeFund"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyDepositFund11", "<script>MakeStaticHeaderDepositFund('" + GridDepositFund.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_GATA"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyGatA11", "<script>MakeStaticHeaderGatA('" + GridGatA.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_GATD"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyGatD11", "<script>MakeStaticHeaderGatD('" + GridGatD.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_GATF"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyGatF11", "<script>MakeStaticHeaderGatF('" + GridGatF.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_GATB"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyGatB11", "<script>MakeStaticHeaderGatB('" + GridGatB.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_GATC"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyGatC11", "<script>MakeStaticHeaderGatC('" + GridGatC.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_ResidentialBuilding"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyResBuild11", "<script>MakeStaticHeaderResidentialBuilding('" + GridResidentialBuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_NonResidentialBuilding"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "KeyNonResBuild11", "<script>MakeStaticHeaderNonResidentialbuilding('" + GridNonResidentialbuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            if (Session["SReport_2515"] != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key2515", "<script>MakeStaticHeader2515('" + Grid2515.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string gridHTML = string.Empty;
            if (GridBuilding.Rows.Count != 0)
            {
                GridBuilding.UseAccessibleHeader = true;
                GridBuilding.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridBuilding.FooterRow.TableSection = TableRowSection.TableFooter;
                GridBuilding.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridBuilding.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridBuilding.RenderControl(hw);
                string Header = "<h2>Building</h2>";
                Session["BuildGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                //string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");

                lblBuilding.Text = "<h2>Building</h2>";
            }

            if (GridCRF.Rows.Count != 0)
            {
                GridCRF.UseAccessibleHeader = true;
                GridCRF.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridCRF.FooterRow.TableSection = TableRowSection.TableFooter;
                GridCRF.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridCRF.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridCRF.RenderControl(hw);
                string Header = "<h2>CRF</h2>";
                //string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["CRFGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
            }
            if (GridNabard.Rows.Count != 0)
            {
                GridNabard.UseAccessibleHeader = true;
                GridNabard.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridNabard.FooterRow.TableSection = TableRowSection.TableFooter;
                GridNabard.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridNabard.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridNabard.RenderControl(hw);
                string Header = "<h2>Nabard</h2>";
                //string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["NabardGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblNabard.Text = "<h2>Nabard</h2>";
            }

            if (GridRoad.Rows.Count != 0)
            {
                GridRoad.UseAccessibleHeader = true;
                GridRoad.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridRoad.FooterRow.TableSection = TableRowSection.TableFooter;
                GridRoad.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridRoad.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridRoad.RenderControl(hw);
                string Header = "<h2>Road</h2>";
                //string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["RoadGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblRoad.Text = "<h2>Road</h2>";
            }

            if (GridDPDC.Rows.Count != 0)
            {
                GridDPDC.UseAccessibleHeader = true;
                GridDPDC.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridDPDC.FooterRow.TableSection = TableRowSection.TableFooter;
                GridDPDC.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridDPDC.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridDPDC.RenderControl(hw);
                string Header = "<h2>DPDC</h2>";
                // string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["DPDCGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblDPDC.Text = "<h2>DPDC</h2>";
            }

            if (GridMLA.Rows.Count != 0)
            {
                GridMLA.UseAccessibleHeader = true;
                GridMLA.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridMLA.FooterRow.TableSection = TableRowSection.TableFooter;
                GridMLA.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridMLA.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridMLA.RenderControl(hw);
                string Header = "<h2>MLA</h2>";
                // string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["MLAGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblMLA.Text = "<h2>MLA</h2>";
            }

            if (GridMP.Rows.Count != 0)
            {
                GridMP.UseAccessibleHeader = true;
                GridMP.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridMP.FooterRow.TableSection = TableRowSection.TableFooter;
                GridMP.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridMP.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridMP.RenderControl(hw);
                string Header = "<h2>MP</h2>";
                //string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["MPGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblMP.Text = "<h2>MP</h2>";
            }

            if (GridAunty.Rows.Count != 0)
            {
                GridAunty.UseAccessibleHeader = true;
                GridAunty.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridAunty.FooterRow.TableSection = TableRowSection.TableFooter;
                GridAunty.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridAunty.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridAunty.RenderControl(hw);
                string Header = "<h2>Annuity</h2>";
                //string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["AuntyGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblAnnuity.Text = "<h2>Annuity</h2>";
            }

            if (GridDepositFund.Rows.Count != 0)
            {
                GridDepositFund.UseAccessibleHeader = true;
                GridDepositFund.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridDepositFund.FooterRow.TableSection = TableRowSection.TableFooter;
                GridDepositFund.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridDepositFund.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridDepositFund.RenderControl(hw);
                string Header = "<h2>DepositFund</h2>";
                // string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["DepositFundGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblDepositFund.Text = "<h2>DepositFund</h2>";
            }

            if (GridGatA.Rows.Count != 0)
            {
                GridGatA.UseAccessibleHeader = true;
                GridGatA.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridGatA.FooterRow.TableSection = TableRowSection.TableFooter;
                GridGatA.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridGatA.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridGatA.RenderControl(hw);
                string Header = "<h2>Gat A</h2>";
                //string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["GatAGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblGATA.Text = "<h2>GAT A</h2>";
            }

            if (GridGatD.Rows.Count != 0)
            {
                GridGatD.UseAccessibleHeader = true;
                GridGatD.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridGatD.FooterRow.TableSection = TableRowSection.TableFooter;
                GridGatD.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridGatD.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridGatD.RenderControl(hw);
                string Header = "<h2>Gat D</h2>";
                // string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["GatDGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblGatD.Text = "<h2>GAT D</h2>";
            }

            if (GridGatF.Rows.Count != 0)
            {
                GridGatF.UseAccessibleHeader = true;
                GridGatF.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridGatF.FooterRow.TableSection = TableRowSection.TableFooter;
                GridGatF.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridGatF.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridGatF.RenderControl(hw);
                //string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                string Header = "<h2>GAT F</h2>";
                Session["GatFGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblGatF.Text = "<h2>GAT F</h2>";
            }

            if (GridGatB.Rows.Count != 0)
            {
                GridGatB.UseAccessibleHeader = true;
                GridGatB.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridGatB.FooterRow.TableSection = TableRowSection.TableFooter;
                GridGatB.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridGatB.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridGatB.RenderControl(hw);
                string Header = "<h2>Gat B</h2>";
                // string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["GatBGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblGatB.Text = "<h2>GAT B</h2>";
            }

            if (GridGatC.Rows.Count != 0)
            {
                GridGatC.UseAccessibleHeader = true;
                GridGatC.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridGatC.FooterRow.TableSection = TableRowSection.TableFooter;
                GridGatC.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in GridGatC.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridGatC.RenderControl(hw);
                string Header = "<h2>Gat C</h2>";
                // string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["GatCGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lblGatC.Text = "<h2>GAT C</h2>";
            }

            if (Grid2515.Rows.Count != 0)
            {
                Grid2515.UseAccessibleHeader = true;
                Grid2515.HeaderRow.TableSection = TableRowSection.TableHeader;
                Grid2515.FooterRow.TableSection = TableRowSection.TableFooter;
                Grid2515.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in Grid2515.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                Grid2515.RenderControl(hw);
                string Header = "<h2>GramVikas 2515</h2>";
                //string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                Session["GramVikas2515GridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                lbl2515.Text = "<h2>GramVikas 2515</h2>";

            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            string style = "<style type = 'text/css'>thead {display:table-header-group;} tfoot{display:table-footer-group;}</style>";
            sb.Append(style + Session["BuildGridHTML"] + Session["CRFGridHTML"] + Session["NabardGridHTML"] + Session["RoadGridHTML"] + Session["DPDCGridHTML"] + Session["MLAGridHTML"] + Session["MPGridHTML"] + Session["AuntyGridHTML"] + Session["DepositFundGridHTML"] + Session["GatAGridHTML"] + Session["GatDGridHTML"] + Session["GatFGridHTML"] + Session["GatBGridHTML"] + Session["GatCGridHTML"] + Session["GramVikas2515GridHTML"]);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();");
            sb.Append("};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            Session["BuildGridHTML"] = null;
            Session["CRFGridHTML"] = null;
            Session["NabardGridHTML"] = null;
            Session["RoadGridHTML"] = null;
            Session["DPDCGridHTML"] = null;
            Session["MLAGridHTML"] = null;
            Session["MPGridHTML"] = null;
            Session["AuntyGridHTML"] = null;
            Session["DepositFundGridHTML"] = null;
            Session["GatAGridHTML"] = null;
            Session["GatDGridHTML"] = null;
            Session["GatFGridHTML"] = null;
            Session["GatBGridHTML"] = null;
            Session["GatCGridHTML"] = null;
            Session["GramVikas2515GridHTML"] = null;
            sb.Clear();

            if (GridBuilding.Rows.Count != 0)
            {
                GridBuilding.DataBind();
            }
            if (GridCRF.Rows.Count != 0)
            {
                GridCRF.DataBind();
            }
            if (GridNabard.Rows.Count != 0)
            {
                GridNabard.DataBind();
            }
            if (GridRoad.Rows.Count != 0)
            {
                GridRoad.DataBind();
            }
            if (GridDPDC.Rows.Count != 0)
            {
                GridDPDC.DataBind();
            }
            if (GridMLA.Rows.Count != 0)
            {
                GridMLA.DataBind();
            }
            if (GridMP.Rows.Count != 0)
            {
                GridMP.DataBind();
            }
            if (GridAunty.Rows.Count != 0)
            {
                GridAunty.DataBind();
            }
            if (GridDepositFund.Rows.Count != 0)
            {
                GridDepositFund.DataBind();
            }
            if (GridGatA.Rows.Count != 0)
            {
                GridGatA.DataBind();
            }
            if (GridGatD.Rows.Count != 0)
            {
                GridGatD.DataBind();
            }
            if (GridGatF.Rows.Count != 0)
            {
                GridGatF.DataBind();
            }
            if (GridGatB.Rows.Count != 0)
            {
                GridGatB.DataBind();
            }
            if (GridGatC.Rows.Count != 0)
            {
                GridGatC.DataBind();
            }
            if (Grid2515.Rows.Count != 0)
            {
                Grid2515.DataBind();
            }
            AllMethodsGrid();
        }

        protected void btnBuildRep_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "Building";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridBuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnRoad_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "Road";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key2", "<script>MakeStaticHeader1('" + GridRoad.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnCrf_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "Crf";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key16", "<script>MakeStaticHeaderCRF('" + GridCRF.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnNabard_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "Nabard";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key15", "<script>MakeStaticHeaderNabard('" + GridNabard.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnDpdc_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "Dpdc";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key14", "<script>MakeStaticHeaderDPDC('" + GridDPDC.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnMla_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "MLA";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key13", "<script>MakeStaticHeaderMLA('" + GridMLA.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnMp_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "MP";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key12", "<script>MakeStaticHeaderMP('" + GridMP.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnDeposit_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "Deposit";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key6", "<script>MakeStaticHeaderDepositFund('" + GridDepositFund.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnGatA_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "GatA";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key7", "<script>MakeStaticHeaderGatA('" + GridGatA.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnGatFbc_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "GatFbc";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key9", "<script>MakeStaticHeaderGatF('" + GridGatF.ClientID + "', 750, 100 , 100 ,false); </script>", false);

        }

        protected void btnGatD_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "GatD";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key8", "<script>MakeStaticHeaderGatD('" + GridGatD.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnAnnuity_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "Annuity";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key5", "<script>MakeStaticHeaderAunty('" + GridAunty.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btn2216_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "2216";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key3", "<script>MakeStaticHeaderResidentialBuilding('" + GridResidentialBuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btn2059_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "2059";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key4", "<script>MakeStaticHeaderNonResidentialbuilding('" + GridNonResidentialbuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btn2515_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "2515";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key22", "<script>MakeStaticHeader2515('" + Grid2515.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void btnGAtB_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "GATB";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key10", "<script>MakeStaticHeaderGatB('" + GridGatB.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

        protected void BtnGATC_Click(object sender, EventArgs e)
        {
            ViewState["Head"] = "GATC";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key11", "<script>MakeStaticHeaderGatC('" + GridGatC.ClientID + "', 750, 100 , 100 ,false); </script>", false);
        }

    }
}