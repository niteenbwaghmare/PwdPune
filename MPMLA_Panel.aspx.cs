using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.SessionState;
using System.Drawing;
using PWdEEBudget.SMS_CRUD;

using System.Web.UI.DataVisualization.Charting;

namespace PWdEEBudget
{
    public partial class MPMLA_Panel : System.Web.UI.Page
    {
        clsNotification notificationObj = new clsNotification();
        clsSMS_CRUD objChartBind = new clsSMS_CRUD();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        SqlDataAdapter sda;
        DataTable dt;
        string strcmd = string.Empty;
        string Type = string.Empty;
        string count = string.Empty;
        string userName = string.Empty;
        string post = string.Empty;
        string colname = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserName();
                BindColChart();
                BindGridview();
                //  BindddlYear();
                if (Session["id"] != null)
                {
                    Label1.Text = Session["id"].ToString();
                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
                Session["id"] = Label1.Text;
            }
            //datafetch();
        }
        public void GetUserName()
        {
            string UserId = Session["id"].ToString();
            string strGetNameQuery = "select Name,Post from SCreateAdmin where UserId='" + UserId + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(strGetNameQuery, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    ViewState["Name"] = dr["Name"].ToString();
                    post = dr["Post"].ToString();
                }
                if (post.Trim() == "MP")
                {
                    ViewState["colName"] = "KhasdaracheName";
                }
                

            }
        }
        protected void BindColChart()
        {
            userName = ViewState["Name"].ToString();
            colname = ViewState["colName"].ToString();
            strcmd = "select  (select  count(*) from BudgetMasterBuilding where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + ")as Building ,(select  count(*) from  BudgetMasterCRF where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + " )as CRF ,(select  count(*) from BudgetMasterAunty where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + "  )as Annuity,(select  count(*) from BudgetMasterDepositFund where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + " )as Deposit, (select  count(*) from  BudgetMasterDPDC where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + " )as DPDC , (select  count(*) from  BudgetMasterGAT_A where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + " )as Gat_A , (select  count(*) from  BudgetMasterGAT_D where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + " )as Gat_D , (select  count(*) from  BudgetMasterGAT_FBC where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + "  ) as Gat_BCF, (select  count(*) from  BudgetMasterMLA where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + "  )as MLA , (select  count(*) from  BudgetMasterMP where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + " ) as MP, (select  count(*) from  BudgetMasterNABARD where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + " )as Nabard , (select  count(*) from  BudgetMasterRoad where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + " )as Road , (select  count(*) from  BudgetMasterNonResidentialBuilding where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + " )as NRB2059 , (select  count(*) from  BudgetMasterResidentialBuilding where " + colname + "=N'" + userName.ToString() + "'  group by " + colname + " )as RB2216  , (select count(*) from [BudgetMaster2515] where " + colname + "=N'" + userName.ToString() + "' group by " + colname + " )as GramVikas ";
            sda = new SqlDataAdapter(strcmd, con);
            dt = new DataTable();
            sda.Fill(dt);
            //Series series = new Series();

            string[] x1 = new string[dt.Columns.Count];
            int[] y1 = new int[dt.Columns.Count];
            string[] x2 = new string[dt.Columns.Count];

            //series.ChartType = SeriesChartType.Pie;
            // int index = 0;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                //int y = Convert.ToInt32(dt.Rows[0][i]);
                if (dt.Columns[i].ToString() == "NRB2059" && !DBNull.Value.Equals(dt.Rows[0][i]))
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = "2059";

                }
                else if (dt.Columns[i].ToString() == "RB2216" && !DBNull.Value.Equals(dt.Rows[0][i]))
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = "2216";
                }
                else if (dt.Columns[i].ToString() == "GramVikas" && !DBNull.Value.Equals(dt.Rows[0][i]))
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = "2515";
                }
                else
                {
                    if (!DBNull.Value.Equals(dt.Rows[0][i]))
                    {
                        x2[i] = dt.Rows[0][i].ToString();
                        y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                        x1[i] = dt.Columns[i].ToString();
                    }

                }



            }
            foreach (Series s in Chart1.Series)
            {
                s.ToolTip = "State: #VALX\nTotalWork: #VALY\nPercentage: #PERCENT";

                //s.LegendText = x2.ToString();

            }
            Chart1.Series[0].Points.DataBindXY(x1, y1);
            Chart1.Series[0].Label = "#VALY";
            //Chart1.Series[0].Label= "#VALX";

            Chart1.Series[0].IsValueShownAsLabel = true;
            //Chart1.Series[0].LabelForeColor = System.Drawing.Color.Green;
            Chart1.ChartAreas[0].AxisX.Interval = 1;
            //Chart1.ChartAreas[0].AxisX.Crossing = 30;

            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -42;

            Chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Verdana", 11f);

            Chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Red;


            Chart1.Series[0].SmartLabelStyle.Enabled = false;// Remove auto property first

            Chart1.Series[0].LabelAngle = 20; // Can vary from -90 to 90;
            //Chart1.ChartAreas[0].Area3DStyle.Rotation = 10;
            Chart1.Series[0].LabelForeColor = Color.Red;
            Chart1.Series[0].Font = new Font("Verdana", 11f);
            Chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
            Chart1.Series[0].CustomProperties = "DrawingStyle=Cylinder, MaxPixelPointWidth=20";
        }

        protected void BindGridview()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME LIKE '%BudgetMaster%' AND TABLE_CATALOG='EEPwdEastPune'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            gvParentGrid.DataSource = ds;
            gvParentGrid.DataBind();

        }

        string provisionTbl = string.Empty;
        protected void gvParentGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            userName = ViewState["Name"].ToString();
            colname = ViewState["colName"].ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                GridView gv = (GridView)e.Row.FindControl("gvChildGrid");
                string FromTbl = e.Row.Cells[1].Text;
                if (FromTbl.Trim() == "BudgetMasterBuilding")
                {
                    e.Row.Cells[1].Text = "Building";
                    provisionTbl = "BuildingProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterNABARD")
                {
                    e.Row.Cells[1].Text = "Nabard";
                    provisionTbl = "NABARDProvision";
                }
                else if (FromTbl.Trim() == "BudgetMaster2515")
                {
                    e.Row.Cells[1].Text = "2515";
                    FromTbl = "[BudgetMaster2515]";
                    provisionTbl = "[2515Provision]";
                }
                else if (FromTbl.Trim() == "BudgetMasterRoad")
                {
                    e.Row.Cells[1].Text = "SH & DOR";
                    provisionTbl = "RoadProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterAunty")
                {
                    e.Row.Cells[1].Text = "Annuity";
                    provisionTbl = "AuntyProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterCRF")
                {
                    e.Row.Cells[1].Text = "CRF";
                    provisionTbl = "CRFProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterMLA")
                {
                    e.Row.Cells[1].Text = "MLA";
                    provisionTbl = "MLAProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterMP")
                {
                    e.Row.Cells[1].Text = "MP";
                    provisionTbl = "MPProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterDPDC")
                {
                    e.Row.Cells[1].Text = "DPDC";
                    provisionTbl = "DPDCProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterGAT_A")
                {
                    e.Row.Cells[1].Text = "Gat_A";
                    provisionTbl = "GAT_AProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterGAT_FBC")
                {
                    e.Row.Cells[1].Text = "Gat_BCF";
                    provisionTbl = "GAT_FBCProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterDepositFund")
                {
                    e.Row.Cells[1].Text = "Deposit";
                    provisionTbl = "DepositFundProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterGAT_D")
                {
                    e.Row.Cells[1].Text = "Gat_D";
                    provisionTbl = "GAT_DProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterResidentialBuilding")
                {
                    e.Row.Cells[1].Text = "2216";
                    provisionTbl = "ResidentialBuildingProvision";
                }
                else if (FromTbl.Trim() == "BudgetMasterNonResidentialBuilding")
                {
                    e.Row.Cells[1].Text = "2059";
                    provisionTbl = "NonResidentialBuildingProvision";
                }
                SqlCommand cmd = new SqlCommand("SELECT a.[Sadyasthiti]as 'Work Status', Count(a.[Sadyasthiti])as'Total Work',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'AA cost Rs in lakhs',sum(cast(a.[TrantrikAmt]as decimal(10,2)))as 'Technical Sanction Cost Rs in Lakh',sum(cast(b.[Tartud]as decimal(10,2))) as 'Total Provision Rs in Lakh',sum(cast(b.[AikunKharch]as decimal(10,2))) as 'Total Expense Rs in Lakh' FROM " + FromTbl + " a full outer join " + provisionTbl + "  b on a.workid=b.workid where a.[Sadyasthiti]!='' and " + colname + "=N'" + userName.ToString() + "' and b.Arthsankalpiyyear='" + ddlYear.SelectedItem.ToString() + "' GROUP BY a.[Sadyasthiti]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                TotalWork = 0;
                AACost = 0;
                TSCost = 0;
                TotalProvision = 0;
                TotalExp = 0;
                da.Fill(ds);
                con.Close();
                gv.DataSource = ds;
                gv.DataBind();
            }
        }
        decimal TotalWork = 0;
        decimal AACost = 0;
        decimal TSCost = 0;
        decimal TotalProvision = 0;
        decimal TotalExp = 0;
        protected void gvChildGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                TotalWork += Convert.ToDecimal(e.Row.Cells[1].Text);
                AACost += Convert.ToDecimal(e.Row.Cells[2].Text);
                TSCost += Convert.ToDecimal(e.Row.Cells[3].Text);
                TotalProvision += Convert.ToDecimal(e.Row.Cells[4].Text);
                TotalExp += Convert.ToDecimal(e.Row.Cells[5].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = TotalWork.ToString();
                e.Row.Cells[2].Text = AACost.ToString();
                e.Row.Cells[3].Text = TSCost.ToString();
                e.Row.Cells[4].Text = TotalProvision.ToString();
                e.Row.Cells[5].Text = TotalExp.ToString();
            }
        }

        protected void BindddlYear()
        {
            ddlYear.Items.Add("2015-2016");
            ddlYear.Items.Add("2016-2017");
            ddlYear.Items.Add("2017-2018");
            ddlYear.SelectedIndex = 1;
        }
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridview();
        }
    }
}