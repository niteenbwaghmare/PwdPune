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
using System.Drawing;

namespace PWdEEBudget
{
    public partial class SubDivisionUpdateReport : System.Web.UI.Page
    {
        string UserName = string.Empty;
        string strSqlcommand = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        string pName;
        string GridName;
        int tempcounter = 0;
        int rowcount = 0;
        string query = string.Empty;
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
            query += "SELECT  [WorkId] as 'वर्क आयडी',[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',[KamacheName] as 'कामाचे नाव',[Shera] as 'शेरा' ";
           
            if (!Page.IsPostBack)
            {
                AllMethodsGrid();
            }
        }

        public void AllMethodsGrid()
        {
            ViewState["Head"] = null;
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

        public void BindMasterBuildingReport()
        {
            strSqlcommand = query + " from BudgetMasterBuilding   where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridBuilding.DataSource = dt;
                GridBuilding.DataBind();
                lblBuilding.Text = "<h2>Building</h2>";
                btnBuildRep.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridBuilding.ClientID + "',  750, 100 , 100  ,false); </script>", false);
            }
            else
            {
                btnBuildRep.Visible = false;
            }
            //Session["MasterBuildingRpt"] = GridView1;
        }
        public void BindMasterCRFReport()
        {
            strSqlcommand = "SELECT [WorkId] as 'WorkId', [Arthsankalpiyyear] as 'Budget of Year', [KamacheName] as 'Name of Work', [Shera] as 'Remark' from BudgetMasterCRF where  ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridCRF.DataSource = dt;
                GridCRF.DataBind();
                lblCRF.Text = "<h2>CRF</h2>";
                btnCrf.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key16", "<script>MakeStaticHeaderCRF('" + GridCRF.ClientID + "',  750, 100 , 100  ,false); </script>", false);
                Session["SReport_CRF"] = GridCRF;
            }
            else
            { btnCrf.Visible = false; }
        }
        public void BindMasterNabardReport()
        {
            strSqlcommand = "SELECT [WorkId] as 'Work Id' , [Arthsankalpiyyear] as 'Budget of Year', [KamacheName]as 'Name of Work', [Shera] as 'Remark' from BudgetMasterNABARD  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or[UpabhyantaName]=N'" + UserName.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridNabard.DataSource = dt;
                GridNabard.DataBind();
                lblNabard.Text = "<h2>Nabard</h2>";
                btnNabard.Visible = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key15", "<script>MakeStaticHeaderNabard('" + GridNabard.ClientID + "',  750, 100 , 100  ,false); </script>", false);
                Session["SReport_Nabard"] = GridNabard;
            }
            else
            {
                btnNabard.Visible = false;
            }
        }
        public void BindMasterRoadReport()
        {
            strSqlcommand = query + " from BudgetMasterRoad  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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
        public void BindMasterDPDCReport()
        {
            strSqlcommand = query + " from BudgetMasterDPDC  Where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterMLAReport()
        {
            strSqlcommand = query + " from BudgetMasterMLA  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterMPReport()
        {
            strSqlcommand = query + " from BudgetMasterMP  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "'  ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterGatAReport()
        {
            strSqlcommand = query + " from BudgetMasterGAT_A  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterGatBReport()
        {
            strSqlcommand = query + " from BudgetMasterGAT_FBC  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "'  and Type=N'गट बी' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterGatCReport()
        {
            strSqlcommand = query + " from BudgetMasterGAT_FBC  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "'  and  [Type]=N'गट सी' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterGatDReport()
        {
            strSqlcommand = query + " from BudgetMasterGAT_D  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterGatFReport()
        {
            strSqlcommand = query + " from BudgetMasterGAT_FBC  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "'  and [Type]=N'गट एफ' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterAnnuityReport()
        {
            strSqlcommand = query + " from BudgetMasterAunty  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterDepositeReport()
        {

            strSqlcommand = query + " from BudgetMasterDepositFund  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterRBReport()
        {
            strSqlcommand = query + " from BudgetMasterResidentialBuilding  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterNRBReport()
        {
            strSqlcommand = query + " from BudgetMasterNonResidentialBuilding  where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }
        public void BindMasterGramin2515Report()
        {
            strSqlcommand = query + " from [BudgetMaster2515]   where ShakhaAbhyantaName=N'" + UserName.ToString() + "' or [UpabhyantaName]=N'" + UserName.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(strSqlcommand, con);
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
            }
        }

        protected void GridBuilding_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                Session["SubDivPrevPage"] = "SubDivisionUpdateReport.aspx";
                ((HyperLink)e.Row.FindControl("hlLink")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridBuilding.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=1&PrevMPage=SubDivision&PrevPage=SubDivisionUpdateReport.aspx";
                ((HyperLink)e.Row.FindControl("hlLink")).Text = "Photo";
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridCRF.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=2&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
        protected void GridRoad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridRoad.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=10&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
        protected void GridNabard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridNabard.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=7&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridDPDC.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=4&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridMLA.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=5&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridMP.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=6&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridGatC.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=13&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridGatB.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=13&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridGatF.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=13&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridGatD.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=12&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridGatA.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=11&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridDepositFund.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=3&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridAunty.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=0&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridNonResidentialbuilding.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=9&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
            var data = e.Row.DataItem as DataRowView;
            if (e.Row.RowIndex > -1)
            {
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + GridResidentialBuilding.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=8&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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
                ((HyperLink)e.Row.FindControl("hlLInk")).NavigateUrl = "/UploadImage.aspx?WorkID=" + Grid2515.DataKeys[e.Row.RowIndex].Value.ToString() + "&index=14&PrevMPage=SubDivision";
                ((HyperLink)e.Row.FindControl("hlLInk")).Text = "Photo";
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

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            con.Open();
            string tblfrom = string.Empty;
            if (lblType.Text == "Building")
            {
                tblfrom = " [BudgetMasterBuilding]";
            }
            else if (lblType.Text == "Road")
            {
                tblfrom = " [BudgetMasterRoad]";
            }
            else if (lblType.Text == "2515_GramVikas")
            {
                tblfrom = " [BudgetMaster2515]";

            }
            else if (lblType.Text == "CRF")
            {
                tblfrom = " [BudgetMasterCRF]";
            }
            else if (lblType.Text == "Deposit Fund")
            {
                tblfrom = " [BudgetMasterDepositFund]";
            }
            else if (lblType.Text == "DPDC")
            {
                tblfrom = " [BudgetMasterDPDC]";
            }
            else if (lblType.Text == "GAT_A")
            {
                tblfrom = " [BudgetMasterGAT_A]";
            }
            else if (lblType.Text == "GAT_D")
            {
                tblfrom = " [BudgetMasterGAT_D]";
            }
            else if (lblType.Text == "गट एफ" || lblType.Text == "गट बी" || lblType.Text == "गट एफ")
            {
                tblfrom = " [BudgetMasterGAT_FBC]";
            }
            else if (lblType.Text == "MLA")
            {
                tblfrom = " [BudgetMasterMLA]";
            }
            else if (lblType.Text == "पुणे / राज्य सभा सदस्य" || lblType.Text == "पुणे / खासदारांचा स्थानिक विकास कार्यक्रम")
            {
                tblfrom = " [BudgetMasterMP]";
            }
            else if (lblType.Text == "Nabard")
            {
                tblfrom = " [BudgetMasterNABARD]";
            }
            else if (lblType.Text == " NonResidential_Building")
            {
                tblfrom = " [BudgetMasterNonResidentialBuilding]";
            }
            else if (lblType.Text == "  Residential_Building")
            {
                tblfrom = " [BudgetMasterResidentialBuilding]";
            }
            cmd = new SqlCommand("Update " + tblfrom + " set [Shera]=N'" + txtShera.Text + "' where Workid='" + lblWorkid.Text + "'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                this.ModalPopupExtender1.Hide();
                string message = "Your details have been saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            con.Close();
            AllMethodsGrid();
        }

        protected void btnUpBuild_Click(object sender, EventArgs e)
        {
            // string type;
            Button btndetails = sender as Button;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            lblWorkid.Text = gvrow.Cells[2].Text;
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter sdaa = new SqlDataAdapter("SELECT coalesce(B.Type, C.Type, N.Type, R.Type, G_A.Type, G_FBC.Type, G_D.Type, D.Type, DP.Type, MLA.Type,MP.Type,An.Type,GramV.Type,RB.Type,NRB.Type)as Type,coalesce(B.KamacheName, C.KamacheName, N.KamacheName, R.KamacheName, G_A.KamacheName, G_FBC.KamacheName, G_D.KamacheName, D.KamacheName, DP.KamacheName, MLA.KamacheName,MP.KamacheName,An.KamacheName,GramV.KamacheName,RB.KamacheName,NRB.KamacheName)as KamacheName,coalesce(B.[Shera], C.[Shera], N.[Shera], R.[Shera], G_A.[Shera], G_FBC.[Shera], G_D.[Shera], D.[Shera], DP.[Shera], MLA.[Shera],MP.[Shera],An.[Shera],GramV.[Shera],RB.[Shera],NRB.[Shera])as [Shera] FROM BudgetMasterBuilding B FULL OUTER JOIN BudgetMasterCRF C ON B.WorkID=C.WorkID full outer join BudgetMasterNABARD N ON B.WorkID=N.WorkID full outer join BudgetMasterRoad R on B.WorkID=R.WorkID full outer join BudgetMasterGAT_A G_A on B.WorkID=G_A.WorkID full outer join BudgetMasterGAT_FBC G_FBC on B.WorkID=G_FBC.WorkID full outer join BudgetMasterGAT_D G_D on B.WorkID=G_D.WorkID  full outer join BudgetMasterDepositFund D on B.WorkID=D.WorkID  full outer join BudgetMasterDPDC DP on B.WorkID=DP.WorkID  full outer join BudgetMasterMLA MLA on B.WorkID=MLA.WorkID  full outer join BudgetMasterMP MP on B.WorkID=MP.WorkID full outer join BudgetMasterAunty An on B.WorkID=An.WorkID full outer join BudgetMaster2515 GramV on B.Workid=GramV.Workid full outer join BudgetMasterNonResidentialBuilding NRB on B.Workid=NRB.workid full outer join BudgetMasterResidentialBuilding RB on B.Workid=RB.workid where B.WorkID = '" + lblWorkid.Text + "' or C.workID = '" + lblWorkid.Text + "' or N.workID  = '" + lblWorkid.Text + "' or R.workID = '" + lblWorkid.Text + "'  or G_A.workID = '" + lblWorkid.Text + "' or G_FBC.workID = '" + lblWorkid.Text + "' or G_D.workID = '" + lblWorkid.Text + "'  or D.workID = '" + lblWorkid.Text + "'  or DP.workID = '" + lblWorkid.Text + "'  or MLA.workID = '" + lblWorkid.Text + "'  or MP.workID = '" + lblWorkid.Text + "' or An.WorkID = '" + lblWorkid.Text + "' or GramV.Workid = '" + lblWorkid.Text + "' or NRB.Workid = '" + lblWorkid.Text + "' or RB.Workid = '" + lblWorkid.Text + "' ", con);
            sdaa.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lblType.Text = (dr["Type"].ToString());
                lblKamcheNav.Text = (dr["KamacheName"].ToString());
                txtShera.Text = (dr["Shera"].ToString());
            }
            this.ModalPopupExtender1.Show();
            AllMethodsGrid();
            con.Close();
        }

        protected void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            BindMasterBuildingReport();
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