using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.IO;

namespace PWdEEBudget
{
    public partial class ContractorMasterAllReport : System.Web.UI.Page
    {
        string UserName = string.Empty;
        string strSqlcommand = string.Empty;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            
            string UserId = Session["id"].ToString();
            string strGetNameQuery = "select Name from SCreateAdmin where UserId='" + UserId + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(strGetNameQuery, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    UserName = dr[0].ToString();
                }
            }
            if (!Page.IsPostBack)
            {
                BindddlYear();
                AllMethodsGrid();
            }
        }

        protected void BindddlYear()
        {
            ddlYear.Items.Clear();
            ddlYear.DataSource = allreport.ArthsankalpiyYear();
            ddlYear.DataTextField = "Arthsankalpiyyear";
            ddlYear.DataValueField = "Arthsankalpiyyear";
            ddlYear.DataBind();
            string arthyear=ddlYear.Items.FindByValue("2016-2017").ToString();
            
            if(arthyear!=null)
            ddlYear.Items.FindByValue("2016-2017").Selected=true;
        }

        public void AllMethodsGrid()
        {
            ViewState["Head"] = null;
            ViewState["WhereCond"] = " where a.[ThekedaarName]=N'" + UserName.ToString() + "' and b.[Arthsankalpiyyear]='" + ddlYear.SelectedItem.ToString() + "'  ";
            BindMasterBuildingReport();
            BindMasterCRFReport();
            BindMasterNabardReport();
            BindMasterRoadReport();
            BindMasterDPDCReport();
            BindMasterMLAReport();
            BindMasterMPReport();
            BindMasterGatAReport();
            BindMasterGatBReport();
            BindMasterGatCReport();
            BindMasterGatDReport();
            BindMasterGatFReport();
            BindMasterAnnuityReport();
            BindMasterDepositeReport();
            BindMasterRBReport();
            BindMasterNRBReport();
            BindMasterGramin2515Report();
            DisableNullGrid();
        }

        public void DisableNullGrid()
        {
            if (GridBuilding.Rows.Count == 0)
            {
                DivRoot.Visible = false;
            }
            else
            {
                DivRoot.Visible = true;
            }
            if (GridRoad.Rows.Count == 0)
            {
                DivRoot1.Visible = false;
            }
            else
            {
                DivRoot1.Visible = true;
            }
            if (GridCRF.Rows.Count == 0)
            {
                DivRootCRF.Visible = false;
            }
            else
            {
                DivRootCRF.Visible = true;
            }
            if (GridNabard.Rows.Count == 0)
            {
                DivRootNabard.Visible = false;
            }
            else
            {
                DivRootNabard.Visible = true;
            }
            if (GridDPDC.Rows.Count == 0)
            {
                DivRootDPDC.Visible = false;
            }
            else
            {
                DivRootDPDC.Visible = true;
            }
            if (GridMLA.Rows.Count == 0)
            {
                DivRootMLA.Visible = false;
            }
            else
            {
                DivRootMLA.Visible = true;
            }
            if (GridMP.Rows.Count == 0)
            {
                DivRootMP.Visible = false;
            }
            else
            {
                DivRootMP.Visible = true;
            }
            if (GridAunty.Rows.Count == 0)
            {
                DivRootAunty.Visible = false;
            }
            else
            {
                DivRootAunty.Visible = true;
            }
            if (GridDepositFund.Rows.Count == 0)
            {
                DivRootDepositFund.Visible = false;
            }
            else
            {
                DivRootDepositFund.Visible = true;
            }
            if (GridGatA.Rows.Count == 0)
            {
                DivRootGatA.Visible = false;
            }
            else
            {
                DivRootGatA.Visible = true;
            }
            if (GridGatD.Rows.Count == 0)
            {
                DivRootGatD.Visible = false;
            }
            else
            {
                DivRootGatD.Visible = true;
            }
            if (GridGatF.Rows.Count == 0)
            {
                DivRootGatF.Visible = false;
            }
            else
            {
                DivRootGatF.Visible = true;
            }
            if (GridGatB.Rows.Count == 0)
            {
                DivRootGatB.Visible = false;
            }
            else
            {
                DivRootGatB.Visible = true;
            }
            if (GridGatC.Rows.Count == 0)
            {
                DivRootGatC.Visible = false;
            }
            else
            {
                DivRootGatC.Visible = true;
            }
            if (GridResidentialBuilding.Rows.Count == 0)
            {
                DivRootResidentialBuilding.Visible = false;
            }
            else
            {
                DivRootResidentialBuilding.Visible = true;
            }
            if (GridNonResidentialbuilding.Rows.Count == 0)
            {
                DivRootNonResidentialbuilding.Visible = false;
            }
            else
            {
                DivRootNonResidentialbuilding.Visible = true;
            }
            if (Grid2515.Rows.Count == 0)
            {
                DivRoot2515.Visible = false;
            }
            else
            {
                DivRoot2515.Visible = true;
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
      
        public void BindMasterBuildingReport()
        {
            string from = " from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkId=b.WorkId  ";
            string GroupByOrderBy = " group by a.[LekhaShirshName] order by a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.Building(whereCondi, GroupByOrderBy, from);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridBuilding.DataSource = dt;
                GridBuilding.DataBind();
                lblBuilding.Text = "<h2>Building</h2>";
                btnBuildRep.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridBuilding.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
            else
            {
                btnBuildRep.Visible = false;
                GridBuilding.DataSource = null;
                GridBuilding.DataBind();
            }
            //Session["MasterBuildingRpt"] = GridView1;
        }

        public void BindMasterCRFReport()
        {
            string GroupByOrderBy = " group by a.[Arthsankalpiyyear] order by a.[Arthsankalpiyyear],a.Upvibhag desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.Crf(whereCondi, GroupByOrderBy);
            
            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridCRF.DataSource = null;
                GridCRF.DataBind();
            }
        }

        public void BindMasterNabardReport()
        {
            string GroupByOrderBy = " group by a.[RDF_SrNo] order by a.[RDF_SrNo],a.[Arthsankalpiyyear],a.[Upvibhag],a.taluka";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.Nabard(whereCondi, GroupByOrderBy);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridNabard.DataSource = null;
                GridNabard.DataBind();
            }
        }

        public void BindMasterRoadReport()
        {
            string GroupByOrderBy = "group by a.[LekhaShirshName] order by a.LekhaShirshName desc,a.[Arthsankalpiyyear],a.[Taluka],a.upvibhag";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.Road(whereCondi, GroupByOrderBy);
            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridRoad.DataSource = dt;
                GridRoad.DataBind();
                lblRoad.Text = "<h2>Road</h2>";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key2", "<script>MakeStaticHeader1('" + GridRoad.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_Road"] = GridRoad;
            }
            else
            {
                btnRoad.Visible = false;
                GridNabard.DataSource = null;
                GridNabard.DataBind();
            }
        }

        public void BindMasterDPDCReport()
        {
            string GroupByOrderBy = " group by a.[Arthsankalpiyyear], a.[Upvibhag]  ORDER BY a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka] desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.Dpdc(whereCondi, GroupByOrderBy);
            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridDPDC.DataSource = null;
                GridDPDC.DataBind();
            }
        }

        public void BindMasterMLAReport()
        {
            string whereCondi = ViewState["WhereCond"].ToString();
            string GroupByOrderBy = " group by  a.[AmdaracheName] order by a.[AmdaracheName], a.[Arthsankalpiyyear],a.[Taluka],a.[PageNo]";
            string CompleteQuery = allreport.Mla(whereCondi, GroupByOrderBy);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridMLA.DataSource = null;
                GridMLA.DataBind();
            }
        }

        public void BindMasterMPReport()
        {
            string GroupByOrderBy = " group by a.[KhasdaracheName] order by a.[KhasdaracheName] ,[PageNo] desc";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.Mp(whereCondi, GroupByOrderBy);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridMP.DataSource = null;
                GridMP.DataBind();
            }
        }

        public void BindMasterGatAReport()
        {
            string whereCondi = ViewState["WhereCond"].ToString();
            string GroupByOrderBy = " group by a.[Arthsankalpiyyear],[LekhaShirshName] order by a.[Arthsankalpiyyear], a.[ArthsankalpiyBab],a.[Upvibhag],a.taluka";
            string CompleteQuery = allreport.GatA(whereCondi, GroupByOrderBy);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridGatA.DataSource = null;
                GridGatA.DataBind();
            }
        }

        public void BindMasterGatBReport()
        {
            string GroupByOrderBy = " group by a.[Upvibhag]  order by a.[Upvibhag],a.[Arthsankalpiyyear],a.[Taluka] ";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.GatFBC(whereCondi, GroupByOrderBy);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridGatB.DataSource = null;
                GridGatB.DataBind();
            }
        }

        public void BindMasterGatCReport()
        {
            string GroupByOrderBy = " group by a.[Upvibhag]  order by a.[Upvibhag],a.[Arthsankalpiyyear],a.[Taluka] ";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.GatFBC(whereCondi, GroupByOrderBy);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridGatC.DataSource = null;
                GridGatC.DataBind();
            }
        }

        public void BindMasterGatDReport()
        {
            string GroupByOrderBy = " group by a.[Arthsankalpiyyear], a.[Upvibhag]  order by a.[Arthsankalpiyyear],a.[Upvibhag],a.[Taluka]desc ";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.GatD(whereCondi, GroupByOrderBy);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridGatD.DataSource = dt;
                GridGatD.DataBind();
                lblGatD.Text = "<h2>GAT D</h2>";
                btnGatD.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key8", "<script>MakeStaticHeaderGatD('" + GridGatD.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                Session["SReport_GATA"] = GridGatA;
                Session["SReport_GATD"] = GridGatD;
            }
            else
            {
                btnGatD.Visible = false;
                GridGatD.DataSource = null;
                GridGatD.DataBind();
            }
        }

        public void BindMasterGatFReport()
        {
            string GroupByOrderBy = " group by a.[Upvibhag]  order by a.[Upvibhag],a.[Arthsankalpiyyear],a.[Taluka]";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.GatFBC(whereCondi, GroupByOrderBy);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridGatF.DataSource = null;
                GridGatF.DataBind();
            }
        }

        public void BindMasterAnnuityReport()
        {
            string whereCondi = ViewState["WhereCond"].ToString();
            string GroupByOrderBy = " group by a.[Arthsankalpiyyear], a.[Upvibhag]  order by a.[Arthsankalpiyyear],a.[Upvibhag],a.[Taluka]desc";
            string CompleteQuery = allreport.Annuity(whereCondi, GroupByOrderBy);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridAunty.DataSource = null;
                GridAunty.DataBind();
            }
        }

        public void BindMasterDepositeReport()
        {
            string whereCondi = ViewState["WhereCond"].ToString();
            string GroupByOrderBy = " group by a.[Arthsankalpiyyear]  order by  a.[Arthsankalpiyyear],a.Upvibhag desc";
            string CompleteQuery = allreport.Deposite(whereCondi, GroupByOrderBy);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridDepositFund.DataSource = null;
                GridDepositFund.DataBind();
            }
        }

        public void BindMasterRBReport()
        {
            string GroupByOrderBy = " group by a.[LekhaShirshName] order by a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag] ";
            string from = " from BudgetMasterResidentialBuilding as a join ResidentialBuildingProvision as b on a.WorkId=b.WorkId  ";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.Building(whereCondi, GroupByOrderBy, from);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridResidentialBuilding.DataSource = null;
                GridResidentialBuilding.DataBind();
            }
        }

        public void BindMasterNRBReport()
        {
            string GroupByOrderBy = " group by a.[LekhaShirshName] order by a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]";
            string from = " from BudgetMasterNonResidentialBuilding as a join NonResidentialBuildingProvision as b on a.WorkId=b.WorkId  ";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.Building(whereCondi, GroupByOrderBy, from);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                GridNonResidentialbuilding.DataSource = null;
                GridNonResidentialbuilding.DataBind();
            }
        }

        public void BindMasterGramin2515Report()
        {
            string GroupByOrderBy = " group by a.[LekhaShirshName] order by a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]";
            string from = " from [BudgetMaster2515] as a join [2515Provision] as b on a.WorkId=b.WorkId  ";
            string whereCondi = ViewState["WhereCond"].ToString();
            string CompleteQuery = allreport.Building(whereCondi, GroupByOrderBy, from);

            SqlDataAdapter sda = new SqlDataAdapter(CompleteQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
                Grid2515.DataSource = null;
                Grid2515.DataBind();
            }
        }

        protected void GridBuilding_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                Session["ContPrevPage"] = "ContractorMasterAllReport.aspx";
                ((HyperLink)e.Row.FindControl("hlLink")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridBuilding.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=1&PrevMPage=Contractor&PrevPage=ContractorMasterAllReport.aspx";
                ((HyperLink)e.Row.FindControl("hlLink")).Text = "Photo";
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
                buildgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalbuild++;
                if (e.Row.Cells[buildgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[buildgrandtotal.Total_index - 1].Text = (totalbuild - 1).ToString();
                    grandbulid += totalbuild - 1;
                    totalbuild = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[4].Text = "";
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[buildgrandtotal.Total_index + 2].Text = "";

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
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        buildgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                    buildgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));

                    buildgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));

                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        buildgrandtotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालु खर्च"] != null)
                    {
                        buildgrandtotal.Chalukharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालु खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        buildgrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        buildgrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        buildgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        buildgrandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        buildgrandtotal.VidyutikarnPrama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        buildgrandtotal.Vidyutikarnvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        buildgrandtotal.OtherExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        buildgrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        buildgrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        buildgrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        buildgrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        buildgrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        buildgrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        buildgrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        buildgrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        buildgrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        buildgrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        buildgrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        buildgrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mar"));
                    }
                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        buildgrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        buildgrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        buildgrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        buildgrandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[buildgrandtotal.Total_index - 1].Text = "No Of Work = " + grandbulid.ToString();
                e.Row.Cells[buildgrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[buildgrandtotal.MarchAkher_Index].Text = buildgrandtotal.MarchAkher.ToString();
                e.Row.Cells[buildgrandtotal.ManjurAmt_index].Text = buildgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[buildgrandtotal.UrvaritAmt_index].Text = buildgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[buildgrandtotal.ArthsankalpTartud_Index].Text = buildgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[buildgrandtotal.VitritTartud_Index].Text = buildgrandtotal.VitritTartud.ToString();
                e.Row.Cells[buildgrandtotal.Chalukharch_index].Text = buildgrandtotal.Chalukharch.ToString();
                e.Row.Cells[buildgrandtotal.Magilkharch_index].Text = buildgrandtotal.Magilkharch.ToString();
                e.Row.Cells[buildgrandtotal.Magni_Index].Text = buildgrandtotal.Magni.ToString();
                e.Row.Cells[buildgrandtotal.EkunKamavarilKharch_Index].Text = buildgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[buildgrandtotal.YearExp_Index].Text = buildgrandtotal.YearExp.ToString();
                e.Row.Cells[buildgrandtotal.VidyutikarnPrama_Index].Text = buildgrandtotal.VidyutikarnPrama.ToString();
                e.Row.Cells[buildgrandtotal.Vidyutikarnvitarit_Index].Text = buildgrandtotal.Vidyutikarnvitarit.ToString();
                e.Row.Cells[buildgrandtotal.OtherExp_Index].Text = buildgrandtotal.OtherExp.ToString();
                e.Row.Cells[buildgrandtotal.Takunone_index].Text = buildgrandtotal.Takunone.ToString();
                e.Row.Cells[buildgrandtotal.Takuntwo_index].Text = buildgrandtotal.Takuntwo.ToString();
                e.Row.Cells[buildgrandtotal.TisriTartud_index].Text = buildgrandtotal.TisriTartud.ToString();
                e.Row.Cells[buildgrandtotal.ChothiTartud_index].Text = buildgrandtotal.ChothiTartud.ToString();
                e.Row.Cells[buildgrandtotal.NividaRakkam_index].Text = buildgrandtotal.NividaRakkam.ToString();

                e.Row.Cells[buildgrandtotal.Apr_index].Text = buildgrandtotal.Apr.ToString();
                e.Row.Cells[buildgrandtotal.May_index].Text = buildgrandtotal.May.ToString();
                e.Row.Cells[buildgrandtotal.Jun_index].Text = buildgrandtotal.Jun.ToString();
                e.Row.Cells[buildgrandtotal.Jul_index].Text = buildgrandtotal.Jul.ToString();
                e.Row.Cells[buildgrandtotal.Aug_index].Text = buildgrandtotal.Aug.ToString();
                e.Row.Cells[buildgrandtotal.sep_index].Text = buildgrandtotal.sep.ToString();
                e.Row.Cells[buildgrandtotal.Oct_index].Text = buildgrandtotal.Oct.ToString();
                e.Row.Cells[buildgrandtotal.Nov_index].Text = buildgrandtotal.Nov.ToString();
                e.Row.Cells[buildgrandtotal.Dec_index].Text = buildgrandtotal.Dec.ToString();
                e.Row.Cells[buildgrandtotal.Jan_index].Text = buildgrandtotal.Jan.ToString();
                e.Row.Cells[buildgrandtotal.Feb_index].Text = buildgrandtotal.Feb.ToString();
                e.Row.Cells[buildgrandtotal.Mar_index].Text = buildgrandtotal.Mar.ToString();
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

        protected void GridRoad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var data = e.Row.DataItem as DataRowView;

            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridRoad.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=10&PrevMPage=Contractor";
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
                roadgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalroad++;
                if (e.Row.Cells[roadgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[roadgrandtotal.Total_index - 1].Text = (totalroad - 1).ToString();
                    grandroad += totalroad - 1;
                    totalroad = 0;
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[roadgrandtotal.Total_index + 4].Text = "";
                    e.Row.Cells[roadgrandtotal.Total_index + 6].Text = "";
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
                    if (data.DataView.Table.Columns["2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017"] != null)
                    {
                        roadgrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017"));
                    }
                    if (data.DataView.Table.Columns["2017-18 मधील अर्थसंकल्पीय तरतूद जुलै 2017"] != null)
                    {
                        roadgrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 मधील अर्थसंकल्पीय तरतूद जुलै 2017"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        roadgrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        roadgrandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        roadgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        roadgrandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        roadgrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        roadgrandtotal.Chalukharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.DataView.Table.Columns["एकूण अर्थसंकल्पीय तरतूद"] != null)
                    {
                        roadgrandtotal.Tartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकूण अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["2017-18 मधील वितरीत तरतूद"] != null)
                    {
                        roadgrandtotal.AkunAnudan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 मधील वितरीत तरतूद"));
                    }
                    if (data.DataView.Table.Columns["२०१७-१८ मधील माहे ९/२०१७ अखेरचा"] != null)
                    {
                        roadgrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "२०१७-१८ मधील माहे ९/२०१७ अखेरचा"));
                    }
                    if (data.DataView.Table.Columns["2017-18 साठी मागणी"] != null)
                    {
                        roadgrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 साठी मागणी"));
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
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        roadgrandtotal.Vidyutprama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        roadgrandtotal.Vidyutvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        roadgrandtotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        roadgrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        roadgrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        roadgrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        roadgrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        roadgrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        roadgrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        roadgrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        roadgrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        roadgrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        roadgrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        roadgrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        roadgrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mar"));
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
                e.Row.Cells[roadgrandtotal.Total_index - 1].Text = "No Of Work = " + grandroad.ToString();
                e.Row.Cells[roadgrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[roadgrandtotal.ManjurAmt_index].Text = roadgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[roadgrandtotal.MarchEndingExpn_index].Text = roadgrandtotal.MarchEndingExpn.ToString();
                e.Row.Cells[roadgrandtotal.UrvaritAmt_index].Text = roadgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[roadgrandtotal.Takunone_index].Text = roadgrandtotal.Takunone.ToString();
                e.Row.Cells[roadgrandtotal.Takuntwo_index].Text = roadgrandtotal.Takuntwo.ToString();
                e.Row.Cells[roadgrandtotal.NividaRakkam_index].Text = roadgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[roadgrandtotal.TisriTartud_index].Text = roadgrandtotal.TisriTartud.ToString();
                e.Row.Cells[roadgrandtotal.ChothiTartud_index].Text = roadgrandtotal.ChothiTartud.ToString();
                e.Row.Cells[roadgrandtotal.Chalukharch_index].Text = roadgrandtotal.Chalukharch.ToString();
                e.Row.Cells[roadgrandtotal.YearExp_Index].Text = roadgrandtotal.YearExp.ToString();
                e.Row.Cells[roadgrandtotal.EkunKamavarilKharch_Index].Text = roadgrandtotal.EkunKamavarilKharch.ToString();

                e.Row.Cells[roadgrandtotal.Tartud_index].Text = roadgrandtotal.Tartud.ToString();
                e.Row.Cells[roadgrandtotal.AkunAnudan_index].Text = roadgrandtotal.AkunAnudan.ToString();
                e.Row.Cells[roadgrandtotal.Magilkharch_index].Text = roadgrandtotal.Magilkharch.ToString();
                e.Row.Cells[roadgrandtotal.Magni_Index].Text = roadgrandtotal.Magni.ToString();
                e.Row.Cells[roadgrandtotal.C_index].Text = roadgrandtotal.C.ToString();
                e.Row.Cells[roadgrandtotal.P_index].Text = roadgrandtotal.P.ToString();
                e.Row.Cells[roadgrandtotal.NS_index].Text = roadgrandtotal.NS.ToString();
                e.Row.Cells[roadgrandtotal.Vidyutprama_index].Text = roadgrandtotal.Vidyutprama.ToString();
                e.Row.Cells[roadgrandtotal.Vidyutvitarit_index].Text = roadgrandtotal.Vidyutvitarit.ToString();
                e.Row.Cells[roadgrandtotal.Itarkhrch_index].Text = roadgrandtotal.Itarkhrch.ToString();
                e.Row.Cells[roadgrandtotal.Apr_index].Text = roadgrandtotal.Apr.ToString();
                e.Row.Cells[roadgrandtotal.May_index].Text = roadgrandtotal.May.ToString();
                e.Row.Cells[roadgrandtotal.Jun_index].Text = roadgrandtotal.Jun.ToString();
                e.Row.Cells[roadgrandtotal.Jul_index].Text = roadgrandtotal.Jul.ToString();
                e.Row.Cells[roadgrandtotal.Aug_index].Text = roadgrandtotal.Aug.ToString();
                e.Row.Cells[roadgrandtotal.sep_index].Text = roadgrandtotal.sep.ToString();
                e.Row.Cells[roadgrandtotal.Oct_index].Text = roadgrandtotal.Oct.ToString();
                e.Row.Cells[roadgrandtotal.Nov_index].Text = roadgrandtotal.Nov.ToString();
                e.Row.Cells[roadgrandtotal.Dec_index].Text = roadgrandtotal.Dec.ToString();
                e.Row.Cells[roadgrandtotal.Jan_index].Text = roadgrandtotal.Jan.ToString();
                e.Row.Cells[roadgrandtotal.Feb_index].Text = roadgrandtotal.Feb.ToString();
                e.Row.Cells[roadgrandtotal.Mar_index].Text = roadgrandtotal.Mar.ToString();
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

        protected void GridCRF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridCRF.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=2&PrevMPage=Contractor";
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
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalcrf++;
                if (e.Row.Cells[crfgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[crfgrandtotal.Total_index - 1].Text = (totalcrf - 1).ToString();
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
                e.Row.Cells[crfgrandtotal.Total_index - 1].Text = "No Of Work = " + grandcrf.ToString();
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
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridNabard.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=7&PrevMPage=Contractor";
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
                grandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:

                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalNbard++;
                if (e.Row.Cells[grandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[grandtotal.Total_index - 1].Text = (totalNbard - 1).ToString();
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
                    if (data.DataView.Table.Columns["Budget Provision in 2017-18 Rs in Lakhs"] != null)
                    {
                        grandtotal.BudgetProvision += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Budget Provision in 2017-18 Rs in Lakhs"));
                    }
                    if (data.DataView.Table.Columns["Demand for 2017-18 Rs in Lakhs"] != null)
                    {
                        grandtotal.Demand += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Demand for 2017-18 Rs in Lakhs"));
                    }
                    if (data.DataView.Table.Columns["Expenditure up to 8/2016 during year 16-17 Rs in Lakhs"] != null)
                    {
                        grandtotal.ExpUpto_8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Expenditure up to 8/2016 during year 16-17 Rs in Lakhs"));
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
                    if (data.DataView.Table.Columns["WBMI Km"] != null)
                    {
                        grandtotal.Wbm1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WBMI Km"));
                    }
                    if (data.DataView.Table.Columns["WBMII Km"] != null)
                    {
                        grandtotal.Wbm2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WBMII Km"));
                    }
                    if (data.DataView.Table.Columns["WBMIII Km"] != null)
                    {
                        grandtotal.Wbm3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WBMIII Km"));
                    }
                    if (data.DataView.Table.Columns["BBM Km"] != null)
                    {
                        grandtotal.Bbm += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BBM Km"));
                    }
                    if (data.DataView.Table.Columns["Carpet Km"] != null)
                    {
                        grandtotal.Karpet += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Carpet Km"));
                    }
                    if (data.DataView.Table.Columns["Surface Km"] != null)
                    {
                        grandtotal.Surface += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Surface Km"));
                    }
                    if (data.DataView.Table.Columns["Second Provision"] != null)
                    {
                        grandtotal.SecPro += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Second Provision"));
                    }
                    if (data.DataView.Table.Columns["Third Provision"] != null)
                    {
                        grandtotal.TirdPro += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Third Provision"));
                    }
                    if (data.DataView.Table.Columns["Fourth Provision"] != null)
                    {
                        grandtotal.ForthPro += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fourth Provision"));
                    }
                    if (data.DataView.Table.Columns["Total Provision"] != null)
                    {
                        grandtotal.TotalPro += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Provision"));
                    }
                    if (data.DataView.Table.Columns["Total Grand"] != null)
                    {
                        grandtotal.AkunAnudan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Grand"));
                    }
                    if (data.DataView.Table.Columns["Current Cost"] != null)
                    {
                        grandtotal.Chalukharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Current Cost"));
                    }
                    if (data.DataView.Table.Columns["Previous Cost"] != null)
                    {
                        grandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Previous Cost"));
                    }
                    if (data.DataView.Table.Columns["Total Expense"] != null)
                    {
                        grandtotal.AkunKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Expense"));
                    }
                    if (data.DataView.Table.Columns["Tender Amount"] != null)
                    {
                        grandtotal.TenderAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Tender Amount"));
                    }
                    if (data.DataView.Table.Columns["CD_Works_No"] != null)
                    {
                        grandtotal.CdWork += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CD_Works_No"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[grandtotal.Total_index - 1].Text = "No Of Work = " + grandnabard.ToString();
                e.Row.Cells[grandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[grandtotal.AACost_Index - 1].Text = grandtotal.AACost.ToString();
                e.Row.Cells[grandtotal.TsCost_index - 1].Text = grandtotal.TsCost.ToString();
                e.Row.Cells[grandtotal.ManjurAmt_index - 1].Text = grandtotal.ManjurAmt.ToString();
                e.Row.Cells[grandtotal.Expmar_Index - 1].Text = grandtotal.ExpUptoMarch.ToString();
                e.Row.Cells[grandtotal.UrvaritAmt_index - 1].Text = grandtotal.UrvaritAmt.ToString();
                e.Row.Cells[grandtotal.Budget_Index - 1].Text = grandtotal.BudgetProvision.ToString();
                e.Row.Cells[grandtotal.Demand_Index - 1].Text = grandtotal.Demand.ToString();
                e.Row.Cells[grandtotal.Exp_8_index - 1].Text = grandtotal.ExpUpto_8.ToString();
                e.Row.Cells[grandtotal.Apr_index - 1].Text = grandtotal.Apr.ToString();
                e.Row.Cells[grandtotal.May_index - 1].Text = grandtotal.May.ToString();
                e.Row.Cells[grandtotal.Jun_index - 1].Text = grandtotal.Jun.ToString();
                e.Row.Cells[grandtotal.Jul_index - 1].Text = grandtotal.Jul.ToString();
                e.Row.Cells[grandtotal.Aug_index - 1].Text = grandtotal.Aug.ToString();
                e.Row.Cells[grandtotal.sep_index - 1].Text = grandtotal.sep.ToString();
                e.Row.Cells[grandtotal.Oct_index - 1].Text = grandtotal.Oct.ToString();
                e.Row.Cells[grandtotal.Nov_index - 1].Text = grandtotal.Nov.ToString();
                e.Row.Cells[grandtotal.Dec_index - 1].Text = grandtotal.Dec.ToString();
                e.Row.Cells[grandtotal.Jan_index - 1].Text = grandtotal.Jan.ToString();
                e.Row.Cells[grandtotal.Feb_index - 1].Text = grandtotal.Feb.ToString();
                e.Row.Cells[grandtotal.Mar_index - 1].Text = grandtotal.Mar.ToString();

                e.Row.Cells[grandtotal.Wbm1_index - 1].Text = grandtotal.Wbm1.ToString();
                e.Row.Cells[grandtotal.Wbm2_index - 1].Text = grandtotal.Wbm2.ToString();
                e.Row.Cells[grandtotal.Wbm3_index - 1].Text = grandtotal.Wbm3.ToString();
                e.Row.Cells[grandtotal.Bbm_index - 1].Text = grandtotal.Bbm.ToString();
                e.Row.Cells[grandtotal.Karpet_index - 1].Text = grandtotal.Karpet.ToString();
                e.Row.Cells[grandtotal.Surface_index - 1].Text = grandtotal.Surface.ToString();
                e.Row.Cells[grandtotal.SecPro_index - 1].Text = grandtotal.SecPro.ToString();
                e.Row.Cells[grandtotal.TirdPro_index - 1].Text = grandtotal.TirdPro.ToString();
                e.Row.Cells[grandtotal.ForthPro_index - 1].Text = grandtotal.ForthPro.ToString();
                e.Row.Cells[grandtotal.TotalPro_index - 1].Text = grandtotal.TotalPro.ToString();
                e.Row.Cells[grandtotal.AkunAnudan_index - 1].Text = grandtotal.AkunAnudan.ToString();
                e.Row.Cells[grandtotal.Chalukharch_index - 1].Text = grandtotal.Chalukharch.ToString();
                e.Row.Cells[grandtotal.Magilkharch_index - 1].Text = grandtotal.Magilkharch.ToString();
                e.Row.Cells[grandtotal.AkunKharch_index - 1].Text = grandtotal.AkunKharch.ToString();
                e.Row.Cells[grandtotal.TenderAmount_index - 1].Text = grandtotal.TenderAmount.ToString();
                e.Row.Cells[grandtotal.CdWork_Index - 1].Text = grandtotal.CdWork.ToString();
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

        protected void GridDPDC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridDPDC.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=4&PrevMPage=Contractor";
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
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;

                totalDpdc++;
                if (e.Row.Cells[dpdcgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[dpdcgrandtotal.Total_index - 1].Text = (totalDpdc - 1).ToString();
                    grandDpdc += totalDpdc - 1;
                    totalDpdc = 0;
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[8].Text = "";
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
                e.Row.Cells[dpdcgrandtotal.Total_index - 1].Text = "No Of Work = " + grandDpdc.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridMLA.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=5&PrevMPage=Contractor";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }
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

                mlagrnadtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;

                totalMla++;
                if (e.Row.Cells[mlagrnadtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[mlagrnadtotal.Total_index - 1].Text = (totalMla - 1).ToString();
                    // grandbulid += totalbuild - 1;
                    grandMla += totalMla - 1;
                    totalMla = 0;
                    e.Row.Cells[7].Text = "";
                    e.Row.Cells[mlagrnadtotal.Total_index + 1].Text = "";
                    e.Row.Cells[mlagrnadtotal.Total_index + 6].Text = "";
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
                    if (data.Row.Table.Columns["वितरीत तरतूद सन 2017-2018"] != null)
                    {
                        mlagrnadtotal.VitritTartud += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.VitritTartud_index].Text);
                    }
                    if (data.Row.Table.Columns["सन 2016 - 17  06/2016 अखेर खर्च"] != null)
                    {
                        mlagrnadtotal.KharchSan += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.KharchSan_index].Text);
                    }
                    if (data.Row.Table.Columns["मागणी 2017-18"] != null)
                    {
                        mlagrnadtotal.Magni += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Magni_index].Text);
                    }
                    if (data.Row.Table.Columns["पुर्ण"] != null)
                    {
                        mlagrnadtotal.Purn += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Purn_index].Text);
                    }
                    if (data.Row.Table.Columns["प्रगतीत"] != null)
                    {
                        mlagrnadtotal.Pragatit += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.Pragatit_index].Text);
                    }
                    if (data.Row.Table.Columns["निविदा स्तर"] != null)
                    {
                        mlagrnadtotal.NividaStar += Convert.ToDecimal(e.Row.Cells[mlagrnadtotal.NividaStar_index].Text);
                    }
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
                e.Row.Cells[mlagrnadtotal.Total_index - 1].Text = "No Of Work = " + grandMla.ToString();
                e.Row.Cells[mlagrnadtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[mlagrnadtotal.MarchAkher_index].Text = mlagrnadtotal.MarchAkher.ToString();
                e.Row.Cells[mlagrnadtotal.SanMadil_index].Text = mlagrnadtotal.SanMadil.ToString();
                e.Row.Cells[mlagrnadtotal.UrvritKimmat_index].Text = mlagrnadtotal.UrvritKimmat.ToString();
                e.Row.Cells[mlagrnadtotal.KamNihay_index].Text = mlagrnadtotal.KamNihay.ToString();
                e.Row.Cells[mlagrnadtotal.VitritTartud_index].Text = mlagrnadtotal.VitritTartud.ToString();
                e.Row.Cells[mlagrnadtotal.KharchSan_index].Text = mlagrnadtotal.KharchSan.ToString();
                e.Row.Cells[mlagrnadtotal.Magni_index].Text = mlagrnadtotal.Magni.ToString();
                e.Row.Cells[mlagrnadtotal.Purn_index].Text = mlagrnadtotal.Purn.ToString();
                e.Row.Cells[mlagrnadtotal.Pragatit_index].Text = mlagrnadtotal.Pragatit.ToString();
                e.Row.Cells[mlagrnadtotal.NividaStar_index].Text = mlagrnadtotal.NividaStar.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridMP.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=6&PrevMPage=Contractor";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }
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

                mpgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalMp++;
                if (e.Row.Cells[mpgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[mpgrandtotal.Total_index - 1].Text = (totalMp - 1).ToString();
                    grandMp += totalMp - 1;
                    totalMp = 0;
                    e.Row.Cells[3].Text = "";
                    e.Row.Cells[5].Text = "";
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
                    if (data.Row.Table.Columns["पुर्ण"] != null)
                    {
                        mpgrandtotal.Purn += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Purn_index].Text);
                    }
                    if (data.Row.Table.Columns["प्रगतीत"] != null)
                    {
                        mpgrandtotal.Pragatit += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.Pragatit_index].Text);
                    }
                    if (data.Row.Table.Columns["निविदा स्तर"] != null)
                    {
                        mpgrandtotal.NividaStar += Convert.ToDecimal(e.Row.Cells[mpgrandtotal.NividaStar_index].Text);
                    }
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
                e.Row.Cells[mpgrandtotal.Total_index - 1].Text = "No Of Work = " + grandMp.ToString();
                e.Row.Cells[mpgrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[mpgrandtotal.NividaKimmat_index].Text = mpgrandtotal.NividaKimmat.ToString();
                e.Row.Cells[mpgrandtotal.NividaRakkam_Index].Text = mpgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[mpgrandtotal.Anudan_index].Text = mpgrandtotal.Anudan.ToString();
                e.Row.Cells[mpgrandtotal.UplbdaAnudan_index].Text = mpgrandtotal.UplbdaAnudan.ToString();
                e.Row.Cells[mpgrandtotal.AkunAnudan_index].Text = mpgrandtotal.AkunAnudan.ToString();
                e.Row.Cells[mpgrandtotal.AkherKharch_index].Text = mpgrandtotal.AkherKharch.ToString();
                e.Row.Cells[mpgrandtotal.AkunKharch_index].Text = mpgrandtotal.AkunKharch.ToString();
                e.Row.Cells[mpgrandtotal.Magni_index].Text = mpgrandtotal.Magni.ToString();
                e.Row.Cells[mpgrandtotal.Purn_index].Text = mpgrandtotal.Purn.ToString();
                e.Row.Cells[mpgrandtotal.Pragatit_index].Text = mpgrandtotal.Pragatit.ToString();
                e.Row.Cells[mpgrandtotal.NividaStar_index].Text = mpgrandtotal.NividaStar.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridGatC.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=13&PrevMPage=Contractor";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }
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
                gatCgrandtotal.index(HeadrName);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalGatC++;
                if (e.Row.Cells[gatCgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[gatCgrandtotal.Total_index - 1].Text = (totalGatC - 1).ToString();
                    grandGatC += totalGatC - 1;
                    totalGatC = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[7].Text = "";
                    e.Row.Cells[gatCgrandtotal.Total_index + 2].Text = "";
                    e.Row.Cells[gatCgrandtotal.Total_index + 7].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;
                    if (data.DataView.Table.Columns["पीक व रोल"] != null)
                    {
                        gatCgrandtotal.PikRol += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "पीक व रोल"));
                    }
                    if (data.DataView.Table.Columns["नवीन खडीकरण"] != null)
                    {
                        gatCgrandtotal.NavinKhandikarnex += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "नवीन खडीकरण"));
                    }
                    if (data.DataView.Table.Columns["बी एम व कारपेट सिलकोट सह"] != null)
                    {
                        gatCgrandtotal.B_M_Karpet += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "बी एम व कारपेट सिलकोट सह"));
                    }
                    if (data.DataView.Table.Columns["20 मीमी कारपेटसिलकोट सह"] != null)
                    {
                        gatCgrandtotal.MM_20_Karpet += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "20 मीमी कारपेटसिलकोट सह"));
                    }
                    if (data.DataView.Table.Columns["सरफेस ड्रेसिंग"] != null)
                    {
                        gatCgrandtotal.SarfhesDresing += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सरफेस ड्रेसिंग"));
                    }
                    if (data.DataView.Table.Columns["रुंदी करण"] != null)
                    {
                        gatCgrandtotal.RundiKaran += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "रुंदी करण"));
                    }
                    if (data.DataView.Table.Columns["पूल/ मो-या"] != null)
                    {
                        gatCgrandtotal.PulMoYa += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "पूल/ मो-या"));
                    }
                    if (data.DataView.Table.Columns["दुरुस्तीचा प्रती खर्च"] != null)
                    {
                        gatCgrandtotal.DurusthichaPratiKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "दुरुस्तीचा प्रती खर्च"));
                    }
                    if (data.DataView.Table.Columns["अन्य"] != null)
                    {
                        gatCgrandtotal.OtherExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अन्य"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        gatCgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        gatCgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        gatCgrandtotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        gatCgrandtotal.ExpUp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        gatCgrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        gatCgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        gatCgrandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        gatCgrandtotal.VidyutikarnPrama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        gatCgrandtotal.Vidyutikarnvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        gatCgrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        gatCgrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        gatCgrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        gatCgrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        gatCgrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        gatCgrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        gatCgrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        gatCgrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        gatCgrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        gatCgrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        gatCgrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        gatCgrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        gatCgrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        gatCgrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        gatCgrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        gatCgrandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["अन्य"] != null)
                    {
                        gatCgrandtotal.Anya += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अन्य"));
                    }
                    if (data.DataView.Table.Columns["देयकाची सद्यस्थिती"] != null)
                    {
                        gatCgrandtotal.Deykachi += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "देयकाची सद्यस्थिती"));
                    }
                    if (data.DataView.Table.Columns["कामाची किंमत"] != null)
                    {
                        gatCgrandtotal.KamchiKimat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "कामाची किंमत"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        gatCgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        gatCgrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        gatCgrandtotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[gatCgrandtotal.Total_index - 1].Text = "No Of Work = " + grandGatC.ToString();
                e.Row.Cells[gatCgrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[gatCgrandtotal.PikRol_Index].Text = gatCgrandtotal.PikRol.ToString();
                e.Row.Cells[gatCgrandtotal.NavinKhandikarn_index].Text = gatCgrandtotal.NavinKhandikarnex.ToString();
                e.Row.Cells[gatCgrandtotal.B_M_Karpet_index].Text = gatCgrandtotal.B_M_Karpet.ToString();
                e.Row.Cells[gatCgrandtotal.MM_20_Karpet_index].Text = gatCgrandtotal.MM_20_Karpet.ToString();
                e.Row.Cells[gatCgrandtotal.SarfhesDresing_index].Text = gatCgrandtotal.SarfhesDresing.ToString();
                e.Row.Cells[gatCgrandtotal.RundiKaran_index].Text = gatCgrandtotal.RundiKaran.ToString();
                e.Row.Cells[gatCgrandtotal.PulMoYa_index].Text = gatCgrandtotal.PulMoYa.ToString();
                e.Row.Cells[gatCgrandtotal.DurusthichaPratiKharch_index].Text = gatCgrandtotal.DurusthichaPratiKharch.ToString();
                e.Row.Cells[gatCgrandtotal.OtherExp_Index].Text = gatCgrandtotal.OtherExp.ToString();
                e.Row.Cells[gatCgrandtotal.MarchAkher_Index].Text = gatCgrandtotal.MarchAkher.ToString();
                e.Row.Cells[gatCgrandtotal.VitritTartud_Index].Text = gatCgrandtotal.VitritTartud.ToString();
                e.Row.Cells[gatCgrandtotal.ExpUp_Index].Text = gatCgrandtotal.ExpUp.ToString();
                e.Row.Cells[gatCgrandtotal.Magni_Index].Text = gatCgrandtotal.Magni.ToString();
                e.Row.Cells[gatCgrandtotal.EkunKamavarilKharch_Index].Text = gatCgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[gatCgrandtotal.YearExp_Index].Text = gatCgrandtotal.YearExp.ToString();
                e.Row.Cells[gatCgrandtotal.VidyutikarnPrama_Index].Text = gatCgrandtotal.VidyutikarnPrama.ToString();
                e.Row.Cells[gatCgrandtotal.Vidyutikarnvitarit_Index].Text = gatCgrandtotal.Vidyutikarnvitarit.ToString();
                e.Row.Cells[gatCgrandtotal.Apr_index].Text = gatCgrandtotal.Apr.ToString();
                e.Row.Cells[gatCgrandtotal.May_index].Text = gatCgrandtotal.May.ToString();
                e.Row.Cells[gatCgrandtotal.Jun_index].Text = gatCgrandtotal.Jun.ToString();
                e.Row.Cells[gatCgrandtotal.Jul_index].Text = gatCgrandtotal.Jul.ToString();
                e.Row.Cells[gatCgrandtotal.Aug_index].Text = gatCgrandtotal.Aug.ToString();
                e.Row.Cells[gatCgrandtotal.sep_index].Text = gatCgrandtotal.sep.ToString();
                e.Row.Cells[gatCgrandtotal.Oct_index].Text = gatCgrandtotal.Oct.ToString();
                e.Row.Cells[gatCgrandtotal.Nov_index].Text = gatCgrandtotal.Nov.ToString();
                e.Row.Cells[gatCgrandtotal.Dec_index].Text = gatCgrandtotal.Dec.ToString();
                e.Row.Cells[gatCgrandtotal.Jan_index].Text = gatCgrandtotal.Jan.ToString();
                e.Row.Cells[gatCgrandtotal.Feb_index].Text = gatCgrandtotal.Feb.ToString();
                e.Row.Cells[gatCgrandtotal.Mar_index].Text = gatCgrandtotal.Mar.ToString();

                e.Row.Cells[gatCgrandtotal.Takunone_index].Text = gatCgrandtotal.Takunone.ToString();
                e.Row.Cells[gatCgrandtotal.Takuntwo_index].Text = gatCgrandtotal.Takuntwo.ToString();
                e.Row.Cells[gatCgrandtotal.TisriTartud_index].Text = gatCgrandtotal.TisriTartud.ToString();
                e.Row.Cells[gatCgrandtotal.ChothiTartud_index].Text = gatCgrandtotal.ChothiTartud.ToString();
                e.Row.Cells[gatCgrandtotal.Anya_index].Text = gatCgrandtotal.Anya.ToString();
                e.Row.Cells[gatCgrandtotal.Deykachi_index].Text = gatCgrandtotal.Deykachi.ToString();
                e.Row.Cells[gatCgrandtotal.KamchiKimat_index].Text = gatCgrandtotal.KamchiKimat.ToString();
                e.Row.Cells[gatCgrandtotal.NividaRakkam_index].Text = gatCgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[gatCgrandtotal.ArthsankalpTartud_Index].Text = gatCgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[gatCgrandtotal.Magilkharch_index].Text = gatCgrandtotal.Magilkharch.ToString();
                e.Row.Cells[gatCgrandtotal.Itarkhrch_index].Text = gatCgrandtotal.Itarkhrch.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridGatB.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=13&PrevMPage=Contractor";
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
                gatBgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalGatB++;
                if (e.Row.Cells[gatBgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[gatBgrandtotal.Total_index - 1].Text = (totalGatB - 1).ToString();
                    grandGatB += totalGatB - 1;
                    rowcount = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[gatBgrandtotal.Total_index + 2].Text = "";
                    e.Row.Cells[gatBgrandtotal.Total_index + 7].Text = "";
                    e.Row.Cells[7].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["पीक व रोल"] != null)
                    {
                        gatBgrandtotal.PikRol += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "पीक व रोल"));
                    }
                    if (data.DataView.Table.Columns["नवीन खडीकरण"] != null)
                    {
                        gatBgrandtotal.NavinKhandikarnex += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "नवीन खडीकरण"));
                    }
                    if (data.DataView.Table.Columns["बी एम व कारपेट सिलकोट सह"] != null)
                    {
                        gatBgrandtotal.B_M_Karpet += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "बी एम व कारपेट सिलकोट सह"));
                    }
                    if (data.DataView.Table.Columns["20 मीमी कारपेटसिलकोट सह"] != null)
                    {
                        gatBgrandtotal.MM_20_Karpet += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "20 मीमी कारपेटसिलकोट सह"));
                    }
                    if (data.DataView.Table.Columns["सरफेस ड्रेसिंग"] != null)
                    {
                        gatBgrandtotal.SarfhesDresing += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सरफेस ड्रेसिंग"));
                    }
                    if (data.DataView.Table.Columns["रुंदी करण"] != null)
                    {
                        gatBgrandtotal.RundiKaran += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "रुंदी करण"));
                    }
                    if (data.DataView.Table.Columns["पूल/ मो-या"] != null)
                    {
                        gatBgrandtotal.PulMoYa += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "पूल/ मो-या"));
                    }
                    if (data.DataView.Table.Columns["दुरुस्तीचा प्रती खर्च"] != null)
                    {
                        gatBgrandtotal.DurusthichaPratiKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "दुरुस्तीचा प्रती खर्च"));
                    }
                    if (data.DataView.Table.Columns["अन्"] != null)
                    {
                        gatBgrandtotal.OtherExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अन्"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        gatBgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        gatBgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        gatBgrandtotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        gatBgrandtotal.ExpUp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        gatBgrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        gatBgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        gatBgrandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        gatBgrandtotal.VidyutikarnPrama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        gatBgrandtotal.Vidyutikarnvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        gatBgrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        gatBgrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        gatBgrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        gatBgrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        gatBgrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        gatBgrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        gatBgrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        gatBgrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        gatBgrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        gatBgrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        gatBgrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        gatBgrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        gatBgrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        gatBgrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        gatBgrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        gatBgrandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["अन्य"] != null)
                    {
                        gatBgrandtotal.Anya += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अन्य"));
                    }
                    if (data.DataView.Table.Columns["देयकाची सद्यस्थिती"] != null)
                    {
                        gatBgrandtotal.Deykachi += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "देयकाची सद्यस्थिती"));
                    }
                    if (data.DataView.Table.Columns["कामाची किंमत"] != null)
                    {
                        gatBgrandtotal.KamchiKimat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "कामाची किंमत"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        gatBgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        gatBgrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        gatBgrandtotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[gatBgrandtotal.Total_index - 1].Text = "No Of Work = " + grandGatB.ToString();
                e.Row.Cells[gatBgrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[gatBgrandtotal.PikRol_Index].Text = gatBgrandtotal.PikRol.ToString();
                e.Row.Cells[gatBgrandtotal.Itarkhrch_index].Text = gatBgrandtotal.Itarkhrch.ToString();
                e.Row.Cells[gatBgrandtotal.NavinKhandikarn_index].Text = gatBgrandtotal.NavinKhandikarnex.ToString();
                e.Row.Cells[gatBgrandtotal.B_M_Karpet_index].Text = gatBgrandtotal.B_M_Karpet.ToString();
                e.Row.Cells[gatBgrandtotal.MM_20_Karpet_index].Text = gatBgrandtotal.MM_20_Karpet.ToString();
                e.Row.Cells[gatBgrandtotal.SarfhesDresing_index].Text = gatBgrandtotal.SarfhesDresing.ToString();
                e.Row.Cells[gatBgrandtotal.RundiKaran_index].Text = gatBgrandtotal.RundiKaran.ToString();
                e.Row.Cells[gatBgrandtotal.PulMoYa_index].Text = gatBgrandtotal.PulMoYa.ToString();
                e.Row.Cells[gatBgrandtotal.DurusthichaPratiKharch_index].Text = gatBgrandtotal.DurusthichaPratiKharch.ToString();
                e.Row.Cells[gatBgrandtotal.OtherExp_Index].Text = gatBgrandtotal.OtherExp.ToString();
                e.Row.Cells[gatBgrandtotal.MarchAkher_Index].Text = gatBgrandtotal.MarchAkher.ToString();
                e.Row.Cells[gatBgrandtotal.VitritTartud_Index].Text = gatBgrandtotal.VitritTartud.ToString();
                e.Row.Cells[gatBgrandtotal.ExpUp_Index].Text = gatBgrandtotal.ExpUp.ToString();
                e.Row.Cells[gatBgrandtotal.Magni_Index].Text = gatBgrandtotal.Magni.ToString();
                e.Row.Cells[gatBgrandtotal.EkunKamavarilKharch_Index].Text = gatBgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[gatBgrandtotal.YearExp_Index].Text = gatBgrandtotal.YearExp.ToString();
                e.Row.Cells[gatBgrandtotal.VidyutikarnPrama_Index].Text = gatBgrandtotal.VidyutikarnPrama.ToString();
                e.Row.Cells[gatBgrandtotal.Vidyutikarnvitarit_Index].Text = gatBgrandtotal.Vidyutikarnvitarit.ToString();
                e.Row.Cells[gatBgrandtotal.Apr_index].Text = gatBgrandtotal.Apr.ToString();
                e.Row.Cells[gatBgrandtotal.May_index].Text = gatBgrandtotal.May.ToString();
                e.Row.Cells[gatBgrandtotal.Jun_index].Text = gatBgrandtotal.Jun.ToString();
                e.Row.Cells[gatBgrandtotal.Jul_index].Text = gatBgrandtotal.Jul.ToString();
                e.Row.Cells[gatBgrandtotal.Aug_index].Text = gatBgrandtotal.Aug.ToString();
                e.Row.Cells[gatBgrandtotal.sep_index].Text = gatBgrandtotal.sep.ToString();
                e.Row.Cells[gatBgrandtotal.Oct_index].Text = gatBgrandtotal.Oct.ToString();
                e.Row.Cells[gatBgrandtotal.Nov_index].Text = gatBgrandtotal.Nov.ToString();
                e.Row.Cells[gatBgrandtotal.Dec_index].Text = gatBgrandtotal.Dec.ToString();
                e.Row.Cells[gatBgrandtotal.Jan_index].Text = gatBgrandtotal.Jan.ToString();
                e.Row.Cells[gatBgrandtotal.Feb_index].Text = gatBgrandtotal.Feb.ToString();
                e.Row.Cells[gatBgrandtotal.Mar_index].Text = gatBgrandtotal.Mar.ToString();

                e.Row.Cells[gatBgrandtotal.Takunone_index].Text = gatBgrandtotal.Takunone.ToString();
                e.Row.Cells[gatBgrandtotal.Takuntwo_index].Text = gatBgrandtotal.Takuntwo.ToString();
                e.Row.Cells[gatBgrandtotal.TisriTartud_index].Text = gatBgrandtotal.TisriTartud.ToString();
                e.Row.Cells[gatBgrandtotal.ChothiTartud_index].Text = gatBgrandtotal.ChothiTartud.ToString();
                e.Row.Cells[gatBgrandtotal.Anya_index].Text = gatBgrandtotal.Anya.ToString();
                e.Row.Cells[gatBgrandtotal.Deykachi_index].Text = gatBgrandtotal.Deykachi.ToString();
                e.Row.Cells[gatBgrandtotal.KamchiKimat_index].Text = gatBgrandtotal.KamchiKimat.ToString();
                e.Row.Cells[gatBgrandtotal.NividaRakkam_index].Text = gatBgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[gatBgrandtotal.ArthsankalpTartud_Index].Text = gatBgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[gatBgrandtotal.Magilkharch_index].Text = gatBgrandtotal.Magilkharch.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridGatF.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=13&PrevMPage=Contractor";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }
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
                gatFgrandtotal.index(HeadrName);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalGatF++;
                if (e.Row.Cells[gatFgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[gatFgrandtotal.Total_index - 1].Text = (totalGatF - 1).ToString();
                    grandGatF += totalGatF - 1;
                    totalGatF = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[gatFgrandtotal.Total_index + 2].Text = "";
                    e.Row.Cells[gatFgrandtotal.Total_index + 7].Text = "";
                    e.Row.Cells[7].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");

                    if (data.DataView.Table.Columns["पीक व रोल"] != null)
                    {
                        gatFgrandtotal.PikRol += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "पीक व रोल"));
                    }
                    if (data.DataView.Table.Columns["नवीन खडीकरण"] != null)
                    {
                        gatFgrandtotal.NavinKhandikarnex += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "नवीन खडीकरण"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        gatFgrandtotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    if (data.DataView.Table.Columns["बी एम व कारपेट सिलकोट सह"] != null)
                    {
                        gatFgrandtotal.B_M_Karpet += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "बी एम व कारपेट सिलकोट सह"));
                    }
                    if (data.DataView.Table.Columns["20 मीमी कारपेटसिलकोट सह"] != null)
                    {
                        gatFgrandtotal.MM_20_Karpet += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "20 मीमी कारपेटसिलकोट सह"));
                    }
                    if (data.DataView.Table.Columns["सरफेस ड्रेसिंग"] != null)
                    {
                        gatFgrandtotal.SarfhesDresing += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सरफेस ड्रेसिंग"));
                    }
                    if (data.DataView.Table.Columns["रुंदी करण"] != null)
                    {
                        gatFgrandtotal.RundiKaran += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "रुंदी करण"));
                    }
                    if (data.DataView.Table.Columns["पूल/ मो-या"] != null)
                    {
                        gatFgrandtotal.PulMoYa += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "पूल/ मो-या"));
                    }
                    if (data.DataView.Table.Columns["दुरुस्तीचा प्रती खर्च"] != null)
                    {
                        gatFgrandtotal.DurusthichaPratiKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "दुरुस्तीचा प्रती खर्च"));
                    }
                    if (data.DataView.Table.Columns["अन्"] != null)
                    {
                        gatFgrandtotal.OtherExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अन्"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च 2017"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        gatFgrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च 2017"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        gatFgrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        gatFgrandtotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        gatFgrandtotal.ExpUp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        gatFgrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        gatFgrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        gatFgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        gatFgrandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        gatFgrandtotal.VidyutikarnPrama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        gatFgrandtotal.Vidyutikarnvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        gatFgrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        gatFgrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        gatFgrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        gatFgrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        gatFgrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        gatFgrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        gatFgrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        gatFgrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        gatFgrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        gatFgrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        gatFgrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        gatFgrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        gatFgrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        gatFgrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        gatFgrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        gatFgrandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["अन्य"] != null)
                    {
                        gatFgrandtotal.Anya += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अन्य"));
                    }
                    if (data.DataView.Table.Columns["देयकाची सद्यस्थिती"] != null)
                    {
                        gatFgrandtotal.Deykachi += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "देयकाची सद्यस्थिती"));
                    }
                    if (data.DataView.Table.Columns["कामाची किंमत"] != null)
                    {
                        gatFgrandtotal.KamchiKimat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "कामाची किंमत"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        gatFgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        gatFgrandtotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[gatFgrandtotal.Total_index - 1].Text = "No Of Work = " + grandGatF.ToString();
                e.Row.Cells[gatFgrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[gatFgrandtotal.PikRol_Index].Text = gatFgrandtotal.PikRol.ToString();
                e.Row.Cells[gatFgrandtotal.Itarkhrch_index].Text = gatFgrandtotal.Itarkhrch.ToString();
                e.Row.Cells[gatFgrandtotal.NavinKhandikarn_index].Text = gatFgrandtotal.NavinKhandikarnex.ToString();
                e.Row.Cells[gatFgrandtotal.B_M_Karpet_index].Text = gatFgrandtotal.B_M_Karpet.ToString();
                e.Row.Cells[gatFgrandtotal.MM_20_Karpet_index].Text = gatFgrandtotal.MM_20_Karpet.ToString();
                e.Row.Cells[gatFgrandtotal.SarfhesDresing_index].Text = gatFgrandtotal.SarfhesDresing.ToString();
                e.Row.Cells[gatFgrandtotal.RundiKaran_index].Text = gatFgrandtotal.RundiKaran.ToString();
                e.Row.Cells[gatFgrandtotal.PulMoYa_index].Text = gatFgrandtotal.PulMoYa.ToString();
                e.Row.Cells[gatFgrandtotal.DurusthichaPratiKharch_index].Text = gatFgrandtotal.DurusthichaPratiKharch.ToString();
                e.Row.Cells[gatFgrandtotal.OtherExp_Index].Text = gatFgrandtotal.OtherExp.ToString();
                e.Row.Cells[gatFgrandtotal.MarchAkher_Index].Text = gatFgrandtotal.MarchAkher.ToString();
                e.Row.Cells[gatFgrandtotal.VitritTartud_Index].Text = gatFgrandtotal.VitritTartud.ToString();
                e.Row.Cells[gatFgrandtotal.ExpUp_Index].Text = gatFgrandtotal.ExpUp.ToString();
                e.Row.Cells[gatFgrandtotal.Magilkharch_index].Text = gatFgrandtotal.Magilkharch.ToString();
                e.Row.Cells[gatFgrandtotal.ArthsankalpTartud_Index].Text = gatFgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[gatFgrandtotal.Magni_Index].Text = gatFgrandtotal.Magni.ToString();
                e.Row.Cells[gatFgrandtotal.EkunKamavarilKharch_Index].Text = gatFgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[gatFgrandtotal.YearExp_Index].Text = gatFgrandtotal.YearExp.ToString();
                e.Row.Cells[gatFgrandtotal.VidyutikarnPrama_Index].Text = gatFgrandtotal.VidyutikarnPrama.ToString();
                e.Row.Cells[gatFgrandtotal.Vidyutikarnvitarit_Index].Text = gatFgrandtotal.Vidyutikarnvitarit.ToString();
                e.Row.Cells[gatFgrandtotal.Apr_index].Text = gatFgrandtotal.Apr.ToString();
                e.Row.Cells[gatFgrandtotal.May_index].Text = gatFgrandtotal.May.ToString();
                e.Row.Cells[gatFgrandtotal.Jun_index].Text = gatFgrandtotal.Jun.ToString();
                e.Row.Cells[gatFgrandtotal.Jul_index].Text = gatFgrandtotal.Jul.ToString();
                e.Row.Cells[gatFgrandtotal.Aug_index].Text = gatFgrandtotal.Aug.ToString();
                e.Row.Cells[gatFgrandtotal.sep_index].Text = gatFgrandtotal.sep.ToString();
                e.Row.Cells[gatFgrandtotal.Oct_index].Text = gatFgrandtotal.Oct.ToString();
                e.Row.Cells[gatFgrandtotal.Nov_index].Text = gatFgrandtotal.Nov.ToString();
                e.Row.Cells[gatFgrandtotal.Dec_index].Text = gatFgrandtotal.Dec.ToString();
                e.Row.Cells[gatFgrandtotal.Jan_index].Text = gatFgrandtotal.Jan.ToString();
                e.Row.Cells[gatFgrandtotal.Feb_index].Text = gatFgrandtotal.Feb.ToString();
                e.Row.Cells[gatFgrandtotal.Mar_index].Text = gatFgrandtotal.Mar.ToString();

                e.Row.Cells[gatFgrandtotal.Takunone_index].Text = gatFgrandtotal.Takunone.ToString();
                e.Row.Cells[gatFgrandtotal.Takuntwo_index].Text = gatFgrandtotal.Takuntwo.ToString();
                e.Row.Cells[gatFgrandtotal.TisriTartud_index].Text = gatFgrandtotal.TisriTartud.ToString();
                e.Row.Cells[gatFgrandtotal.ChothiTartud_index].Text = gatFgrandtotal.ChothiTartud.ToString();
                e.Row.Cells[gatFgrandtotal.Anya_index].Text = gatFgrandtotal.Anya.ToString();
                e.Row.Cells[gatFgrandtotal.Deykachi_index].Text = gatFgrandtotal.Deykachi.ToString();
                e.Row.Cells[gatFgrandtotal.KamchiKimat_index].Text = gatFgrandtotal.KamchiKimat.ToString();
                e.Row.Cells[gatFgrandtotal.NividaRakkam_index].Text = gatFgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[gatFgrandtotal.Itarkhrch_index].Text = gatFgrandtotal.Itarkhrch.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridGatD.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=12&PrevMPage=Contractor";
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
                gatDgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalGatD++;
                if (e.Row.Cells[gatDgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[gatDgrandtotal.Total_index - 1].Text = (totalGatD - 1).ToString();
                    grandGatD += totalGatD - 1;
                    totalGatD = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[6].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["अपघात प्रवण ठिकाण पर्यंत"] != null)
                    {
                        gatDgrandtotal.UpghatPrawanThikanParent += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अपघात प्रवण ठिकाण पर्यंत"));
                    }
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
                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        gatDgrandtotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        gatDgrandtotal.ExpUp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरण कामाची किंमत"] != null)
                    {
                        gatDgrandtotal.VidyutikarnKamchiKimat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरण कामाची किंमत"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणाचा खर्च"] != null)
                    {
                        gatDgrandtotal.VidyutiKarnchaKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणाचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च"] != null)
                    {
                        gatDgrandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        gatDgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        gatDgrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        gatDgrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        gatDgrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        gatDgrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        gatDgrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        gatDgrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        gatDgrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        gatDgrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        gatDgrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        gatDgrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        gatDgrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        gatDgrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        gatDgrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        gatDgrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        gatDgrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        gatDgrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        gatDgrandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        gatDgrandtotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        //gatDgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                        gatDgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        gatDgrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[gatDgrandtotal.Total_index - 1].Text = "No Of Work = " + grandGatD.ToString();
                e.Row.Cells[gatDgrandtotal.Total_index].Text = "Grand Total";

                e.Row.Cells[gatDgrandtotal.UpghatPrawanThikanParent_index].Text = gatDgrandtotal.UpghatPrawanThikanParent.ToString();
                e.Row.Cells[gatDgrandtotal.ManjurAmt_index].Text = gatDgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[gatDgrandtotal.MarchAkher_Index].Text = gatDgrandtotal.MarchAkher.ToString();
                e.Row.Cells[gatDgrandtotal.UrvaritAmt_index].Text = gatDgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[gatDgrandtotal.ArthsankalpTartud_Index].Text = gatDgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[gatDgrandtotal.VitritTartud_Index].Text = gatDgrandtotal.VitritTartud.ToString();
                e.Row.Cells[gatDgrandtotal.ExpUp_Index].Text = gatDgrandtotal.ExpUp.ToString();
                e.Row.Cells[gatDgrandtotal.ExpdFrom_index].Text = gatDgrandtotal.ExpdFrom.ToString();
                e.Row.Cells[gatDgrandtotal.VidyutikarnKamchiKimat_Index].Text = gatDgrandtotal.VidyutikarnKamchiKimat.ToString();
                e.Row.Cells[gatDgrandtotal.VidyutiKarnchaKharch_index].Text = gatDgrandtotal.VidyutiKarnchaKharch.ToString();
                e.Row.Cells[gatDgrandtotal.YearExp_Index].Text = gatDgrandtotal.YearExp.ToString();
                e.Row.Cells[gatDgrandtotal.EkunKamavarilKharch_Index].Text = gatDgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[gatDgrandtotal.Magni_Index].Text = gatDgrandtotal.Magni.ToString();

                e.Row.Cells[gatDgrandtotal.Apr_index].Text = gatDgrandtotal.Apr.ToString();
                e.Row.Cells[gatDgrandtotal.May_index].Text = gatDgrandtotal.May.ToString();
                e.Row.Cells[gatDgrandtotal.Jun_index].Text = gatDgrandtotal.Jun.ToString();
                e.Row.Cells[gatDgrandtotal.Jul_index].Text = gatDgrandtotal.Jul.ToString();
                e.Row.Cells[gatDgrandtotal.Aug_index].Text = gatDgrandtotal.Aug.ToString();
                e.Row.Cells[gatDgrandtotal.sep_index].Text = gatDgrandtotal.sep.ToString();
                e.Row.Cells[gatDgrandtotal.Oct_index].Text = gatDgrandtotal.Oct.ToString();
                e.Row.Cells[gatDgrandtotal.Nov_index].Text = gatDgrandtotal.Nov.ToString();
                e.Row.Cells[gatDgrandtotal.Dec_index].Text = gatDgrandtotal.Dec.ToString();
                e.Row.Cells[gatDgrandtotal.Jan_index].Text = gatDgrandtotal.Jan.ToString();
                e.Row.Cells[gatDgrandtotal.Feb_index].Text = gatDgrandtotal.Feb.ToString();
                e.Row.Cells[gatDgrandtotal.Mar_index].Text = gatDgrandtotal.Mar.ToString();

                e.Row.Cells[gatDgrandtotal.Takunone_index].Text = gatDgrandtotal.Takunone.ToString();
                e.Row.Cells[gatDgrandtotal.Takuntwo_index].Text = gatDgrandtotal.Takuntwo.ToString();
                e.Row.Cells[gatDgrandtotal.TisriTartud_index].Text = gatDgrandtotal.TisriTartud.ToString();
                e.Row.Cells[gatDgrandtotal.ChothiTartud_index].Text = gatDgrandtotal.ChothiTartud.ToString();
                e.Row.Cells[gatDgrandtotal.Itarkhrch_index].Text = gatDgrandtotal.Itarkhrch.ToString();
                e.Row.Cells[gatDgrandtotal.NividaRakkam_index].Text = gatDgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[gatDgrandtotal.Magilkharch_index].Text = gatDgrandtotal.Magilkharch.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridGatA.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=11&PrevMPage=Contractor";
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
                gatAgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;

                totalgatA++;
                if (e.Row.Cells[gatAgrandtotal.Total_index].Text == "Total")
                {
                    var data = e.Row.DataItem as DataRowView;
                    e.Row.Cells[gatAgrandtotal.Total_index - 1].Text = (totalgatA - 1).ToString();

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
                    if (data.DataView.Table.Columns["जॉब रक्कम"] != null)
                    {
                        gatAgrandtotal.JobAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "जॉब रक्कम"));
                    }
                    if (data.DataView.Table.Columns["डांबरीचे परिमाण"] != null)
                    {
                        gatAgrandtotal.DabrichePariman += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "डांबरीचे परिमाण"));
                    }
                    if (data.DataView.Table.Columns["डांबरीची रक्कम"] != null)
                    {
                        gatAgrandtotal.DabrichiAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "डांबरीची रक्कम"));
                    }
                    if (data.DataView.Table.Columns["शिल्लक दायित्व रु"] != null)
                    {
                        gatAgrandtotal.ShilakDayitv += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "शिल्लक दायित्व रु"));
                    }
                    if (data.DataView.Table.Columns["दायित्व असल्यास रक्कम रु"] != null)
                    {
                        gatAgrandtotal.DayitvAslyasAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "दायित्व असल्यास रक्कम रु"));
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
                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        gatAgrandtotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        gatAgrandtotal.ExpUp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरण कामाची किंमत"] != null)
                    {
                        gatAgrandtotal.VidyutikarnKamchiKimat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरण कामाची किंमत"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणाचा खर्च"] != null)
                    {
                        gatAgrandtotal.VidyutiKarnchaKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणाचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["डांबरीचा खर्च"] != null)
                    {
                        gatAgrandtotal.DabrichKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "डांबरीचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        gatAgrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        gatAgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च"] != null)
                    {
                        gatAgrandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च"));
                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        gatAgrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        gatAgrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        gatAgrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        gatAgrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        gatAgrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        gatAgrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        gatAgrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        gatAgrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        gatAgrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        gatAgrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        gatAgrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        gatAgrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mar"));
                    }
                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        gatAgrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        gatAgrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        gatAgrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        gatAgrandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        gatAgrandtotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        gatAgrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        gatAgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[gatAgrandtotal.Total_index - 1].Text = "No Of Work = " + grandgatA.ToString();
                e.Row.Cells[gatAgrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[gatAgrandtotal.JobAmt_Index].Text = gatAgrandtotal.JobAmt.ToString();
                e.Row.Cells[gatAgrandtotal.DabrichePariman_Index].Text = gatAgrandtotal.DabrichePariman.ToString();
                e.Row.Cells[gatAgrandtotal.DabrichiAmt_index].Text = gatAgrandtotal.DabrichiAmt.ToString();
                e.Row.Cells[gatAgrandtotal.ShilakDayitv_Index].Text = gatAgrandtotal.ShilakDayitv.ToString();
                e.Row.Cells[gatAgrandtotal.DayitvAslyasAmt_Index].Text = gatAgrandtotal.DayitvAslyasAmt.ToString();
                e.Row.Cells[gatAgrandtotal.ManjurAmt_index].Text = gatAgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[gatAgrandtotal.MarchAkher_Index].Text = gatAgrandtotal.MarchAkher.ToString();
                e.Row.Cells[gatAgrandtotal.UrvaritAmt_index].Text = gatAgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[gatAgrandtotal.ArthsankalpTartud_Index].Text = gatAgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[gatAgrandtotal.VitritTartud_Index].Text = gatAgrandtotal.VitritTartud.ToString();
                e.Row.Cells[gatAgrandtotal.ExpUp_Index].Text = gatAgrandtotal.ExpUp.ToString();
                e.Row.Cells[gatAgrandtotal.VidyutikarnKamchiKimat_Index].Text = gatAgrandtotal.VidyutikarnKamchiKimat.ToString();
                e.Row.Cells[gatAgrandtotal.VidyutiKarnchaKharch_index].Text = gatAgrandtotal.VidyutiKarnchaKharch.ToString();
                e.Row.Cells[gatAgrandtotal.DabrichKharch_index].Text = gatAgrandtotal.DabrichKharch.ToString();
                e.Row.Cells[gatAgrandtotal.Magni_Index].Text = gatAgrandtotal.Magni.ToString();
                e.Row.Cells[gatAgrandtotal.EkunKamavarilKharch_Index].Text = gatAgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[gatAgrandtotal.YearExp_Index].Text = gatAgrandtotal.YearExp.ToString();


                e.Row.Cells[gatAgrandtotal.Apr_index].Text = gatAgrandtotal.Apr.ToString();
                e.Row.Cells[gatAgrandtotal.May_index].Text = gatAgrandtotal.May.ToString();
                e.Row.Cells[gatAgrandtotal.Jun_index].Text = gatAgrandtotal.Jun.ToString();
                e.Row.Cells[gatAgrandtotal.Jul_index].Text = gatAgrandtotal.Jul.ToString();
                e.Row.Cells[gatAgrandtotal.Aug_index].Text = gatAgrandtotal.Aug.ToString();
                e.Row.Cells[gatAgrandtotal.sep_index].Text = gatAgrandtotal.sep.ToString();
                e.Row.Cells[gatAgrandtotal.Oct_index].Text = gatAgrandtotal.Oct.ToString();
                e.Row.Cells[gatAgrandtotal.Nov_index].Text = gatAgrandtotal.Nov.ToString();
                e.Row.Cells[gatAgrandtotal.Dec_index].Text = gatAgrandtotal.Dec.ToString();
                e.Row.Cells[gatAgrandtotal.Jan_index].Text = gatAgrandtotal.Jan.ToString();
                e.Row.Cells[gatAgrandtotal.Feb_index].Text = gatAgrandtotal.Feb.ToString();
                e.Row.Cells[gatAgrandtotal.Mar_index].Text = gatAgrandtotal.Mar.ToString();

                e.Row.Cells[gatAgrandtotal.Takunone_index].Text = gatAgrandtotal.Takunone.ToString();
                e.Row.Cells[gatAgrandtotal.Takuntwo_index].Text = gatAgrandtotal.Takuntwo.ToString();
                e.Row.Cells[gatAgrandtotal.TisriTartud_index].Text = gatAgrandtotal.TisriTartud.ToString();
                e.Row.Cells[gatAgrandtotal.ChothiTartud_index].Text = gatAgrandtotal.ChothiTartud.ToString();
                e.Row.Cells[gatAgrandtotal.Itarkhrch_index].Text = gatAgrandtotal.Itarkhrch.ToString();
                e.Row.Cells[gatAgrandtotal.Magilkharch_index].Text = gatAgrandtotal.Magilkharch.ToString();
                e.Row.Cells[gatAgrandtotal.NividaRakkam_index].Text = gatAgrandtotal.NividaRakkam.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridDepositFund.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=3&PrevMPage=Contractor";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }
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
                depositegrandtotal.index(HeadrName);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalDeposite++;
                if (e.Row.Cells[depositegrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[depositegrandtotal.Total_index - 1].Text = (totalDeposite - 1).ToString();
                    grandDeposite += totalDeposite - 1;
                    totalDeposite = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[6].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

                    if (data.DataView.Table.Columns["2017-18 मधील शिल्लक ठेव"] != null)
                    {
                        depositegrandtotal.Madhil_16_17ShilakTev += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 मधील शिल्लक ठेव"));
                    }
                    if (data.DataView.Table.Columns["2017-18 वितरीत ठेव"] != null)
                    {
                        depositegrandtotal.VitaritThev += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 वितरीत ठेव"));
                    }
                    if (data.DataView.Table.Columns["मंजूर अंदाजित किंमत"] != null)
                    {
                        depositegrandtotal.ManjurAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मंजूर अंदाजित किंमत"));
                    }
                    if (data.DataView.Table.Columns["मार्च अखेर खर्च"] != null)
                    {
                        //index = data.Row.Table.Columns["AA cost Rs in lakhs"].Ordinal;
                        depositegrandtotal.MarchAkher += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मार्च अखेर खर्च"));
                    }
                    if (data.DataView.Table.Columns["उर्वरित किंमत"] != null)
                    {
                        depositegrandtotal.UrvaritAmt += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "उर्वरित किंमत"));
                    }
                    if (data.DataView.Table.Columns["अर्थसंकल्पीय तरतूद"] != null)
                    {
                        depositegrandtotal.ArthsankalpTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        depositegrandtotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        depositegrandtotal.ExpUp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        depositegrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        depositegrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        depositegrandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        depositegrandtotal.VidyutikarnPrama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        depositegrandtotal.Vidyutikarnvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        depositegrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        depositegrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        depositegrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        depositegrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        depositegrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        depositegrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        depositegrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        depositegrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        depositegrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        depositegrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        depositegrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        depositegrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        depositegrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        depositegrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        depositegrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        depositegrandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        depositegrandtotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    //if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    //{
                    //    depositegrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    //}
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        depositegrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[depositegrandtotal.Total_index - 1].Text = "No Of Work = " + grandDeposite.ToString();
                e.Row.Cells[depositegrandtotal.Total_index].Text = "Grand Total";

                e.Row.Cells[depositegrandtotal.Madhil_16_17ShilakTev_index].Text = depositegrandtotal.Madhil_16_17ShilakTev.ToString();
                e.Row.Cells[depositegrandtotal.VitaritThev_index].Text = depositegrandtotal.VitaritThev.ToString();
                e.Row.Cells[depositegrandtotal.ManjurAmt_index].Text = depositegrandtotal.ManjurAmt.ToString();
                e.Row.Cells[depositegrandtotal.UrvaritAmt_index].Text = depositegrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[depositegrandtotal.MarchAkher_Index].Text = depositegrandtotal.MarchAkher.ToString();
                e.Row.Cells[depositegrandtotal.ArthsankalpTartud_Index].Text = depositegrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[depositegrandtotal.VitritTartud_Index].Text = depositegrandtotal.VitritTartud.ToString();
                e.Row.Cells[depositegrandtotal.ExpUp_Index].Text = depositegrandtotal.ExpUp.ToString();
                e.Row.Cells[depositegrandtotal.ExpdFrom_index].Text = depositegrandtotal.ExpdFrom.ToString();
                e.Row.Cells[depositegrandtotal.Magni_Index].Text = depositegrandtotal.Magni.ToString();
                e.Row.Cells[depositegrandtotal.EkunKamavarilKharch_Index].Text = depositegrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[depositegrandtotal.YearExp_Index].Text = depositegrandtotal.YearExp.ToString();
                e.Row.Cells[depositegrandtotal.VidyutikarnPrama_Index].Text = depositegrandtotal.VidyutikarnPrama.ToString();
                e.Row.Cells[depositegrandtotal.Vidyutikarnvitarit_Index].Text = depositegrandtotal.Vidyutikarnvitarit.ToString();

                e.Row.Cells[depositegrandtotal.Apr_index].Text = depositegrandtotal.Apr.ToString();
                e.Row.Cells[depositegrandtotal.May_index].Text = depositegrandtotal.May.ToString();
                e.Row.Cells[depositegrandtotal.Jun_index].Text = depositegrandtotal.Jun.ToString();
                e.Row.Cells[depositegrandtotal.Jul_index].Text = depositegrandtotal.Jul.ToString();
                e.Row.Cells[depositegrandtotal.Aug_index].Text = depositegrandtotal.Aug.ToString();
                e.Row.Cells[depositegrandtotal.sep_index].Text = depositegrandtotal.sep.ToString();
                e.Row.Cells[depositegrandtotal.Oct_index].Text = depositegrandtotal.Oct.ToString();
                e.Row.Cells[depositegrandtotal.Nov_index].Text = depositegrandtotal.Nov.ToString();
                e.Row.Cells[depositegrandtotal.Dec_index].Text = depositegrandtotal.Dec.ToString();
                e.Row.Cells[depositegrandtotal.Jan_index].Text = depositegrandtotal.Jan.ToString();
                e.Row.Cells[depositegrandtotal.Feb_index].Text = depositegrandtotal.Feb.ToString();
                e.Row.Cells[depositegrandtotal.Mar_index].Text = depositegrandtotal.Mar.ToString();

                e.Row.Cells[depositegrandtotal.Takunone_index].Text = depositegrandtotal.Takunone.ToString();
                e.Row.Cells[depositegrandtotal.Takuntwo_index].Text = depositegrandtotal.Takuntwo.ToString();
                e.Row.Cells[depositegrandtotal.TisriTartud_index].Text = depositegrandtotal.TisriTartud.ToString();
                e.Row.Cells[depositegrandtotal.ChothiTartud_index].Text = depositegrandtotal.ChothiTartud.ToString();
                e.Row.Cells[depositegrandtotal.Itarkhrch_index].Text = depositegrandtotal.Itarkhrch.ToString();

                //e.Row.Cells[depositegrandtotal.NividaRakkam_index].Text = depositegrandtotal.NividaRakkam.ToString();               
                e.Row.Cells[depositegrandtotal.Magilkharch_index].Text = depositegrandtotal.Magilkharch.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridAunty.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=0&PrevMPage=Contractor";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }
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
                anutygrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalAnuty++;
                if (e.Row.Cells[anutygrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[anutygrandtotal.Total_index - 1].Text = (totalAnuty - 1).ToString();
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
                    if (data.Row.Table.Columns["2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017"] != null)
                    {
                        anutygrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017"));
                    }
                    if (data.Row.Table.Columns["2016-17 मधील अर्थसंकल्पीय तरतूद जुलै 2016"] != null)
                    {
                        anutygrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2016-17 मधील अर्थसंकल्पीय तरतूद जुलै 2016"));
                    }
                    if (data.Row.Table.Columns["एकूण अर्थसंकल्पीय तरतूद"] != null)
                    {
                        anutygrandtotal.Tartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकूण अर्थसंकल्पीय तरतूद"));
                    }
                    if (data.Row.Table.Columns["2017-18 मधील वितरीत तरतूद"] != null)
                    {
                        anutygrandtotal.AkunAnudan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2017-18 मधील वितरीत तरतूद"));
                    }
                    if (data.Row.Table.Columns["मागील खर्च"] != null)
                    {
                        anutygrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.Row.Table.Columns["2016-17 साठी मागणी"] != null)
                    {
                        anutygrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "2016-17 साठी मागणी"));
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
                    if (data.Row.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        anutygrandtotal.Vidyutprama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.Row.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        anutygrandtotal.Vidyutvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.Row.Table.Columns["इतर खर्च"] != null)
                    {
                        anutygrandtotal.Itarkhrch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    if (data.Row.Table.Columns["Apr"] != null)
                    {
                        anutygrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.Row.Table.Columns["May"] != null)
                    {
                        anutygrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.Row.Table.Columns["Jun"] != null)
                    {
                        anutygrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.Row.Table.Columns["Jul"] != null)
                    {
                        anutygrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.Row.Table.Columns["Aug"] != null)
                    {
                        anutygrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.Row.Table.Columns["Sep"] != null)
                    {
                        anutygrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.Row.Table.Columns["Oct"] != null)
                    {
                        anutygrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.Row.Table.Columns["Nov"] != null)
                    {
                        anutygrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.Row.Table.Columns["Dec"] != null)
                    {
                        anutygrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.Row.Table.Columns["Jan"] != null)
                    {
                        anutygrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.Row.Table.Columns["Feb"] != null)
                    {
                        anutygrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.Row.Table.Columns["Mar"] != null)
                    {
                        anutygrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mar"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        anutygrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        anutygrandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालु खर्च"] != null)
                    {
                        anutygrandtotal.Chalukharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालु खर्च"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        anutygrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        anutygrandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        anutygrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[anutygrandtotal.Total_index - 1].Text = "No Of Work = " + grandAnuty.ToString();
                e.Row.Cells[anutygrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[anutygrandtotal.ManjurAmt_index].Text = anutygrandtotal.ManjurAmt.ToString();
                e.Row.Cells[anutygrandtotal.MarchEndingExpn_index].Text = anutygrandtotal.MarchEndingExpn.ToString();
                e.Row.Cells[anutygrandtotal.UrvaritAmt_index].Text = anutygrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[anutygrandtotal.Takunone_index].Text = anutygrandtotal.Takunone.ToString();
                e.Row.Cells[anutygrandtotal.Takuntwo_index].Text = anutygrandtotal.Takuntwo.ToString();
                e.Row.Cells[anutygrandtotal.Tartud_index].Text = anutygrandtotal.Tartud.ToString();
                e.Row.Cells[anutygrandtotal.AkunAnudan_index].Text = anutygrandtotal.AkunAnudan.ToString();
                e.Row.Cells[anutygrandtotal.Magilkharch_index].Text = anutygrandtotal.Magilkharch.ToString();
                e.Row.Cells[anutygrandtotal.Magni_Index].Text = anutygrandtotal.Magni.ToString();
                e.Row.Cells[anutygrandtotal.C_index].Text = anutygrandtotal.C.ToString();
                e.Row.Cells[anutygrandtotal.P_index].Text = anutygrandtotal.P.ToString();
                e.Row.Cells[anutygrandtotal.NS_index].Text = anutygrandtotal.NS.ToString();
                e.Row.Cells[anutygrandtotal.Vidyutprama_index].Text = anutygrandtotal.Vidyutprama.ToString();
                e.Row.Cells[anutygrandtotal.Vidyutvitarit_index].Text = anutygrandtotal.Vidyutvitarit.ToString();
                e.Row.Cells[anutygrandtotal.Itarkhrch_index].Text = anutygrandtotal.Itarkhrch.ToString();
                e.Row.Cells[anutygrandtotal.Apr_index].Text = anutygrandtotal.Apr.ToString();
                e.Row.Cells[anutygrandtotal.May_index].Text = anutygrandtotal.May.ToString();
                e.Row.Cells[anutygrandtotal.Jun_index].Text = anutygrandtotal.Jun.ToString();
                e.Row.Cells[anutygrandtotal.Jul_index].Text = anutygrandtotal.Jul.ToString();
                e.Row.Cells[anutygrandtotal.Aug_index].Text = anutygrandtotal.Aug.ToString();
                e.Row.Cells[anutygrandtotal.sep_index].Text = anutygrandtotal.sep.ToString();
                e.Row.Cells[anutygrandtotal.Oct_index].Text = anutygrandtotal.Oct.ToString();
                e.Row.Cells[anutygrandtotal.Nov_index].Text = anutygrandtotal.Nov.ToString();
                e.Row.Cells[anutygrandtotal.Dec_index].Text = anutygrandtotal.Dec.ToString();
                e.Row.Cells[anutygrandtotal.Jan_index].Text = anutygrandtotal.Jan.ToString();
                e.Row.Cells[anutygrandtotal.Feb_index].Text = anutygrandtotal.Feb.ToString();
                e.Row.Cells[anutygrandtotal.Mar_index].Text = anutygrandtotal.Mar.ToString();

                e.Row.Cells[anutygrandtotal.TisriTartud_index].Text = anutygrandtotal.TisriTartud.ToString();
                e.Row.Cells[anutygrandtotal.ChothiTartud_index].Text = anutygrandtotal.ChothiTartud.ToString();
                e.Row.Cells[anutygrandtotal.EkunKamavarilkharch_index].Text = anutygrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[anutygrandtotal.YearExp_index].Text = anutygrandtotal.YearExp.ToString();
                e.Row.Cells[anutygrandtotal.Chalukharch_index].Text = anutygrandtotal.Chalukharch.ToString();
                e.Row.Cells[anutygrandtotal.NividaRakkam_index].Text = anutygrandtotal.NividaRakkam.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridNonResidentialbuilding.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=9&PrevMPage=Contractor";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }
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
                nonresibuilgranddtotal.index(HeadrName);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalnonresibuild++;
                if (e.Row.Cells[nonresibuilgranddtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[nonresibuilgranddtotal.Total_index - 1].Text = (totalnonresibuild - 1).ToString();
                    grandnonresibuild += totalnonresibuild - 1;
                    totalnonresibuild = 0;
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[6].Text = "";
                    //e.Row.Cells[4].ColumnSpan = 5;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                    e.Row.Attributes.CssStyle.Add("border", "none");
                    //this.GridView1.BorderStyle = 0;

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
                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        nonresibuilgranddtotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालु खर्च"] != null)
                    {
                        nonresibuilgranddtotal.Chalukharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालु खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        nonresibuilgranddtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        nonresibuilgranddtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        nonresibuilgranddtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        nonresibuilgranddtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        nonresibuilgranddtotal.VidyutikarnPrama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        nonresibuilgranddtotal.Vidyutikarnvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        nonresibuilgranddtotal.OtherExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        nonresibuilgranddtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        nonresibuilgranddtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        nonresibuilgranddtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        nonresibuilgranddtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        nonresibuilgranddtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        nonresibuilgranddtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        nonresibuilgranddtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        nonresibuilgranddtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        nonresibuilgranddtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        nonresibuilgranddtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        nonresibuilgranddtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        nonresibuilgranddtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        nonresibuilgranddtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        nonresibuilgranddtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        nonresibuilgranddtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        nonresibuilgranddtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        nonresibuilgranddtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[nonresibuilgranddtotal.Total_index - 1].Text = "No Of Work = " + grandnonresibuild.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[nonresibuilgranddtotal.ManjurAmt_index].Text = nonresibuilgranddtotal.ManjurAmt.ToString(); e.Row.Cells[nonresibuilgranddtotal.MarchAkher_Index].Text = nonresibuilgranddtotal.MarchAkher.ToString();
                e.Row.Cells[nonresibuilgranddtotal.UrvaritAmt_index].Text = nonresibuilgranddtotal.UrvaritAmt.ToString();
                e.Row.Cells[nonresibuilgranddtotal.ArthsankalpTartud_Index].Text = nonresibuilgranddtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[nonresibuilgranddtotal.VitritTartud_Index].Text = nonresibuilgranddtotal.VitritTartud.ToString();
                e.Row.Cells[nonresibuilgranddtotal.ExpUp_Index].Text = nonresibuilgranddtotal.ExpUp.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Magni_Index].Text = nonresibuilgranddtotal.Magni.ToString();
                e.Row.Cells[nonresibuilgranddtotal.EkunKamavarilKharch_Index].Text = nonresibuilgranddtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[nonresibuilgranddtotal.YearExp_Index].Text = nonresibuilgranddtotal.YearExp.ToString();
                e.Row.Cells[nonresibuilgranddtotal.VidyutikarnPrama_Index].Text = nonresibuilgranddtotal.VidyutikarnPrama.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Vidyutikarnvitarit_Index].Text = nonresibuilgranddtotal.Vidyutikarnvitarit.ToString();
                e.Row.Cells[nonresibuilgranddtotal.OtherExp_Index].Text = nonresibuilgranddtotal.OtherExp.ToString();

                e.Row.Cells[nonresibuilgranddtotal.Apr_index].Text = nonresibuilgranddtotal.Apr.ToString();
                e.Row.Cells[nonresibuilgranddtotal.May_index].Text = nonresibuilgranddtotal.May.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Jun_index].Text = nonresibuilgranddtotal.Jun.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Jul_index].Text = nonresibuilgranddtotal.Jul.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Aug_index].Text = nonresibuilgranddtotal.Aug.ToString();
                e.Row.Cells[nonresibuilgranddtotal.sep_index].Text = nonresibuilgranddtotal.sep.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Oct_index].Text = nonresibuilgranddtotal.Oct.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Nov_index].Text = nonresibuilgranddtotal.Nov.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Dec_index].Text = nonresibuilgranddtotal.Dec.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Jan_index].Text = nonresibuilgranddtotal.Jan.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Feb_index].Text = nonresibuilgranddtotal.Feb.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Mar_index].Text = nonresibuilgranddtotal.Mar.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Magilkharch_index].Text = nonresibuilgranddtotal.Magilkharch.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Takunone_index].Text = nonresibuilgranddtotal.Takunone.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Takuntwo_index].Text = nonresibuilgranddtotal.Takuntwo.ToString();
                e.Row.Cells[nonresibuilgranddtotal.TisriTartud_index].Text = nonresibuilgranddtotal.TisriTartud.ToString();
                e.Row.Cells[nonresibuilgranddtotal.ChothiTartud_index].Text = nonresibuilgranddtotal.ChothiTartud.ToString();
                e.Row.Cells[nonresibuilgranddtotal.Chalukharch_index].Text = nonresibuilgranddtotal.Chalukharch.ToString();
                e.Row.Cells[nonresibuilgranddtotal.NividaRakkam_index].Text = nonresibuilgranddtotal.NividaRakkam.ToString();

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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridResidentialBuilding.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=8&PrevMPage=Contractor";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
            }
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
                resibuildgrandtotal.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                totalresibulid++;
                if (e.Row.Cells[resibuildgrandtotal.Total_index].Text == "Total")
                {
                    e.Row.Cells[resibuildgrandtotal.Total_index - 1].Text = (totalresibulid - 1).ToString();
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
                    if (data.DataView.Table.Columns["वितरित तरतूद"] != null)
                    {
                        resibuildgrandtotal.VitritTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "वितरित तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चालू खर्च"] != null)
                    {
                        resibuildgrandtotal.ExpUp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चालू खर्च"));
                    }
                    if (data.DataView.Table.Columns["मागणी"] != null)
                    {
                        resibuildgrandtotal.Magni += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागणी"));
                    }
                    if (data.DataView.Table.Columns["एकुण कामावरील खर्च"] != null)
                    {
                        resibuildgrandtotal.EkunKamavarilKharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "एकुण कामावरील खर्च"));
                    }
                    if (data.DataView.Table.Columns["सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"] != null)
                    {
                        resibuildgrandtotal.YearExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील प्रमा"] != null)
                    {
                        resibuildgrandtotal.VidyutikarnPrama += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील प्रमा"));
                    }
                    if (data.DataView.Table.Columns["विद्युतीकरणावरील वितरित"] != null)
                    {
                        resibuildgrandtotal.Vidyutikarnvitarit += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "विद्युतीकरणावरील वितरित"));
                    }
                    if (data.DataView.Table.Columns["इतर खर्च"] != null)
                    {
                        resibuildgrandtotal.OtherExp += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "इतर खर्च"));
                    }
                    if (data.DataView.Table.Columns["Apr"] != null)
                    {
                        resibuildgrandtotal.Apr += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Apr"));
                    }
                    if (data.DataView.Table.Columns["May"] != null)
                    {
                        resibuildgrandtotal.May += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "May"));
                    }
                    if (data.DataView.Table.Columns["Jun"] != null)
                    {
                        resibuildgrandtotal.Jun += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jun"));
                    }
                    if (data.DataView.Table.Columns["Jul"] != null)
                    {
                        resibuildgrandtotal.Jul += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jul"));
                    }
                    if (data.DataView.Table.Columns["Aug"] != null)
                    {
                        resibuildgrandtotal.Aug += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Aug"));
                    }
                    if (data.DataView.Table.Columns["Sep"] != null)
                    {
                        resibuildgrandtotal.sep += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sep"));
                    }
                    if (data.DataView.Table.Columns["Oct"] != null)
                    {
                        resibuildgrandtotal.Oct += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Oct"));
                    }
                    if (data.DataView.Table.Columns["Nov"] != null)
                    {
                        resibuildgrandtotal.Nov += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nov"));
                    }
                    if (data.DataView.Table.Columns["Dec"] != null)
                    {
                        resibuildgrandtotal.Dec += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dec"));
                    }
                    if (data.DataView.Table.Columns["Jan"] != null)
                    {
                        resibuildgrandtotal.Jan += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jan"));
                    }
                    if (data.DataView.Table.Columns["Feb"] != null)
                    {
                        resibuildgrandtotal.Feb += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }
                    if (data.DataView.Table.Columns["Mar"] != null)
                    {
                        resibuildgrandtotal.Mar += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Feb"));
                    }

                    if (data.DataView.Table.Columns["प्रथम तिमाही तरतूद"] != null)
                    {
                        resibuildgrandtotal.Takunone += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "प्रथम तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["द्वितीय तिमाही तरतूद"] != null)
                    {
                        resibuildgrandtotal.Takuntwo += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "द्वितीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["तृतीय तिमाही तरतूद"] != null)
                    {
                        resibuildgrandtotal.TisriTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "तृतीय तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["चतुर्थ तिमाही तरतूद"] != null)
                    {
                        resibuildgrandtotal.ChothiTartud += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "चतुर्थ तिमाही तरतूद"));
                    }
                    if (data.DataView.Table.Columns["निविदा रक्कम % कमी / जास्त"] != null)
                    {
                        resibuildgrandtotal.NividaRakkam += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "निविदा रक्कम % कमी / जास्त"));
                    }
                    if (data.DataView.Table.Columns["मागील खर्च"] != null)
                    {
                        resibuildgrandtotal.Magilkharch += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "मागील खर्च"));
                    }

                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;
                e.Row.Cells[resibuildgrandtotal.Total_index - 1].Text = "No Of Work = " + grandresibuild.ToString();
                e.Row.Cells[resibuildgrandtotal.Total_index].Text = "Grand Total";
                e.Row.Cells[resibuildgrandtotal.ManjurAmt_index].Text = resibuildgrandtotal.ManjurAmt.ToString();
                e.Row.Cells[resibuildgrandtotal.MarchAkher_Index].Text = resibuildgrandtotal.MarchAkher.ToString();
                e.Row.Cells[resibuildgrandtotal.UrvaritAmt_index].Text = resibuildgrandtotal.UrvaritAmt.ToString();
                e.Row.Cells[resibuildgrandtotal.ArthsankalpTartud_Index].Text = resibuildgrandtotal.ArthsankalpTartud.ToString();
                e.Row.Cells[resibuildgrandtotal.VitritTartud_Index].Text = resibuildgrandtotal.VitritTartud.ToString();
                e.Row.Cells[resibuildgrandtotal.ExpUp_Index].Text = resibuildgrandtotal.ExpUp.ToString();
                e.Row.Cells[resibuildgrandtotal.Magni_Index].Text = resibuildgrandtotal.Magni.ToString();
                e.Row.Cells[resibuildgrandtotal.EkunKamavarilKharch_Index].Text = resibuildgrandtotal.EkunKamavarilKharch.ToString();
                e.Row.Cells[resibuildgrandtotal.YearExp_Index].Text = resibuildgrandtotal.YearExp.ToString();
                e.Row.Cells[resibuildgrandtotal.VidyutikarnPrama_Index].Text = resibuildgrandtotal.VidyutikarnPrama.ToString();
                e.Row.Cells[resibuildgrandtotal.Vidyutikarnvitarit_Index].Text = resibuildgrandtotal.Vidyutikarnvitarit.ToString();
                e.Row.Cells[resibuildgrandtotal.OtherExp_Index].Text = resibuildgrandtotal.OtherExp.ToString();


                e.Row.Cells[resibuildgrandtotal.Apr_index].Text = resibuildgrandtotal.Apr.ToString();
                e.Row.Cells[resibuildgrandtotal.May_index].Text = resibuildgrandtotal.May.ToString();
                e.Row.Cells[resibuildgrandtotal.Jun_index].Text = resibuildgrandtotal.Jun.ToString();
                e.Row.Cells[resibuildgrandtotal.Jul_index].Text = resibuildgrandtotal.Jul.ToString();
                e.Row.Cells[resibuildgrandtotal.Aug_index].Text = resibuildgrandtotal.Aug.ToString();
                e.Row.Cells[resibuildgrandtotal.sep_index].Text = resibuildgrandtotal.sep.ToString();
                e.Row.Cells[resibuildgrandtotal.Oct_index].Text = resibuildgrandtotal.Oct.ToString();
                e.Row.Cells[resibuildgrandtotal.Nov_index].Text = resibuildgrandtotal.Nov.ToString();
                e.Row.Cells[resibuildgrandtotal.Dec_index].Text = resibuildgrandtotal.Dec.ToString();
                e.Row.Cells[resibuildgrandtotal.Jan_index].Text = resibuildgrandtotal.Jan.ToString();
                e.Row.Cells[resibuildgrandtotal.Feb_index].Text = resibuildgrandtotal.Feb.ToString();
                e.Row.Cells[resibuildgrandtotal.Mar_index].Text = resibuildgrandtotal.Mar.ToString();

                e.Row.Cells[resibuildgrandtotal.Takunone_index].Text = resibuildgrandtotal.Takunone.ToString();
                e.Row.Cells[resibuildgrandtotal.Takuntwo_index].Text = resibuildgrandtotal.Takuntwo.ToString();
                e.Row.Cells[resibuildgrandtotal.TisriTartud_index].Text = resibuildgrandtotal.TisriTartud.ToString();
                e.Row.Cells[resibuildgrandtotal.ChothiTartud_index].Text = resibuildgrandtotal.ChothiTartud.ToString();
                e.Row.Cells[resibuildgrandtotal.NividaRakkam_index].Text = resibuildgrandtotal.NividaRakkam.ToString();
                e.Row.Cells[resibuildgrandtotal.Magilkharch_index].Text = resibuildgrandtotal.Magilkharch.ToString();
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + Grid2515.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=14&PrevMPage=Contractor";
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
                grand2515total.index(HeadrName);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem as DataRowView;
                // do your stuffs here, for example if column risk is your third column:
                e.Row.Cells[0].BackColor = System.Drawing.Color.LightYellow;
                total2515++;
                if (e.Row.Cells[grand2515total.Total_index].Text == "Total")
                {
                    e.Row.Cells[grand2515total.Total_index - 1].Text = (total2515 - 1).ToString();
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
                e.Row.Cells[grand2515total.Total_index - 1].Text = "No Of Work = " + grand2515.ToString();
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

        protected void Button4_Click(object sender, EventArgs e)
        {
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
                GridBuilding.DataBind();
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
                GridCRF.DataBind();
                lblCRF.Text = "<h2>CRF</h2>";
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
                GridNabard.DataBind();
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
                GridRoad.DataBind();
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
                GridDPDC.DataBind();
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
                GridMLA.DataBind();
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
                GridMP.DataBind();
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
                GridAunty.DataBind();
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
                GridDepositFund.DataBind();
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
                GridGatA.DataBind();
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
                GridGatD.DataBind();
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
                GridGatF.DataBind();
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
                GridGatB.DataBind();
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
                GridGatC.DataBind();
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
                Grid2515.DataBind();
                lbl2515.Text = "<h2>GramVikas 2515</h2>";
            }
            AllMethodsGrid();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllMethodsGrid();
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