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
using System.Text.RegularExpressions;

namespace PWdEEBudget
{
    public partial class MLAMP_Dashboard : System.Web.UI.Page
    {
        clsNotification notificationObj = new clsNotification();
        clsSMS_CRUD objChartBind = new clsSMS_CRUD();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        SqlDataAdapter sda;
        DataTable dt;
        string UserName = string.Empty;
        string strcmd = string.Empty;
        string getworkid = string.Empty;
        string Upvibhag = string.Empty;
        string Type = string.Empty;
        string count = string.Empty;
        string post = string.Empty;
        string notification_Id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            string strGetNameQuery;
            string UserId = Session["id"] != null ? Session["id"].ToString() : "";
            if (UserId != null)
            {
            ViewState["UserId"] = UserId;
            strGetNameQuery = "select Name from SCreateAdmin where UserId='" + UserId + "'";
            }
            else
            {
                strGetNameQuery = "select Name from SCreateAdmin where UserId='" + ViewState["UserId"].ToString() + "'";
            }
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
            if (!IsPostBack)
            {
                GetUserName();
                BindColumnChart();
                BindddlYear();
                BindGridview();

            }
        }
        string p;

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public void GetUserName()
        {
            string UserId = string.Empty;
            if (Session["id"] != null)
            {
                UserId = Session["id"].ToString();
            }
            else
            {
                UserId = ViewState["UserId"].ToString();
            }
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
        protected void BindColumnChart()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            strcmd = "select (select  count(type) from BudgetMasterBuilding where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "')as Building,(select  count(type)from  BudgetMasterCRF where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as CRF,(select  count(type) from BudgetMasterAunty where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "')as Annuity,(select  count(type) from BudgetMasterDepositFund where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "')as Deposit, (select  count(type)from  BudgetMasterDPDC where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as DPDC,(select  count(type)from  BudgetMasterGAT_A where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as Gat_A,(select  count(type)from  BudgetMasterGAT_D where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as Gat_D,(select  count(type)from  BudgetMasterGAT_FBC where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as Gat_BCF,(select  count(type)from  BudgetMasterMLA where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as MLA,(select  count(type)from  BudgetMasterMP where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as MP,(select  count(type)from  BudgetMasterNABARD where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as Nabard,(select  count(type)from  BudgetMasterRoad where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as Road,(select  count(type)from  BudgetMasterNonResidentialBuilding where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as NRB2059,(select  count(type)from  BudgetMasterResidentialBuilding where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as RB2216 ,(select count(type)from [BudgetMaster2515] where KhasdaracheName=N'" + UserName.ToString() + "' or AmdaracheName=N'" + UserName.ToString() + "') as GramVikas";
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
                int y = Convert.ToInt32(dt.Rows[0][i]);
                if (dt.Columns[i].ToString() == "NRB2059")
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = "2059";

                }
                else if (dt.Columns[i].ToString() == "RB2216")
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = "2216";
                }
                else if (dt.Columns[i].ToString() == "GramVikas")
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = "2515";
                }
                else
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = dt.Columns[i].ToString();
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
        DataTable Dumy_dt = new DataTable();
        protected void BindGridview()
        {

            Dumy_dt.Columns.Add("Head Name ");
            Dumy_dt.Columns.Add("Completed");
            Dumy_dt.Columns.Add("Incomplete");
            Dumy_dt.Columns.Add("Inprogress");
            Dumy_dt.Columns.Add("Tender Stage");
            Dumy_dt.Columns.Add("Estimated Stage");
            Dumy_dt.Columns.Add("Not Started");
            Dumy_dt.Columns.Add("No Status");
            Dumy_dt.Columns.Add("No.of.works");
            Dumy_dt.Columns.Add("Estimated Cost " + ddlYear.SelectedItem.ToString());
            Dumy_dt.Columns.Add("T.S Cost " + ddlYear.SelectedItem.ToString());
            Dumy_dt.Columns.Add("Budget Provision " + ddlYear.SelectedItem.ToString());
            Dumy_dt.Columns.Add("Expenditure " + ddlYear.SelectedItem.ToString());

            if (con.State != ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME LIKE '%BudgetMaster%' AND TABLE_CATALOG='EEPwdEastPune'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            DataRow dr1 = ds.NewRow();
            dr1["TABLE_NAME"] = "Total Head Abstract Report " + ddlYear.SelectedItem.ToString();
            ds.Rows.Add(dr1);
            con.Close();
            gvParentGrid.DataSource = ds;
            gvParentGrid.DataBind();

            //if (ParentFlag)
            //{
            //    ChildFlag = true;
            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("Total Head Abstract Report");
            //    gvParentGrid.DataSource = dt;
            //    gvParentGrid.DataBind();
            //}

        }
        protected void BindddlYear()
        {

            ddlYear.Items.Add("2015-2016");
            ddlYear.Items.Add("2016-2017");
            ddlYear.Items.Add("2017-2018");
            ddlYear.SelectedIndex = 1;
        }
        string provisionTbl = string.Empty;
        Boolean ParentFlag = false, ChildFlag = false;
        string HeadName = string.Empty;
        protected void gvParentGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                GridView gv = (GridView)e.Row.FindControl("gvChildGrid");
                //gv.DataSource = null;
                //gv.DataBind();
                //gv.Columns.Clear();
                string FromTbl = e.Row.Cells[1].Text;
                if (FromTbl.Trim() == "BudgetMasterBuilding")
                {
                    e.Row.Cells[1].Text = "Building";
                    provisionTbl = "BuildingProvision";
                    HeadName = "Building";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterNABARD")
                {
                    e.Row.Cells[1].Text = "Nabard";
                    provisionTbl = "NABARDProvision";
                    HeadName = "Nabard";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMaster2515")
                {
                    e.Row.Cells[1].Text = "2515";
                    FromTbl = "[BudgetMaster2515]";
                    provisionTbl = "[2515Provision]";
                    HeadName = "2515";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterRoad")
                {
                    e.Row.Cells[1].Text = "SH & DOR";
                    provisionTbl = "RoadProvision";
                    HeadName = "SH & DOR";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterAunty")
                {
                    e.Row.Cells[1].Text = "Annuity";
                    provisionTbl = "AuntyProvision";
                    HeadName = "Annuity";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterCRF")
                {
                    e.Row.Cells[1].Text = "CRF";
                    provisionTbl = "CRFProvision";
                    HeadName = "CRF";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterMLA")
                {
                    e.Row.Cells[1].Text = "MLA";
                    provisionTbl = "MLAProvision";
                    HeadName = "MLA";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterMP")
                {
                    e.Row.Cells[1].Text = "MP";
                    provisionTbl = "MPProvision";
                    HeadName = "MP";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterDPDC")
                {
                    e.Row.Cells[1].Text = "DPDC";
                    provisionTbl = "DPDCProvision";
                    HeadName = "DPDC";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterGAT_A")
                {
                    e.Row.Cells[1].Text = "Gat_A";
                    provisionTbl = "GAT_AProvision";
                    HeadName = "Gat_A";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterGAT_FBC")
                {
                    e.Row.Cells[1].Text = "Gat_BCF";
                    provisionTbl = "GAT_FBCProvision";
                    HeadName = "Gat_BCF";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterDepositFund")
                {
                    e.Row.Cells[1].Text = "Deposit";
                    provisionTbl = "DepositFundProvision";
                    HeadName = "Deposit";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterGAT_D")
                {
                    e.Row.Cells[1].Text = "Gat_D";
                    provisionTbl = "GAT_DProvision";
                    HeadName = "Gat_D";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterResidentialBuilding")
                {
                    e.Row.Cells[1].Text = "2216";
                    provisionTbl = "ResidentialBuildingProvision";
                    HeadName = "2216";
                    Session["Errortbl"] = provisionTbl;
                }
                else if (FromTbl.Trim() == "BudgetMasterNonResidentialBuilding")
                {
                    e.Row.Cells[1].Text = "2059";
                    provisionTbl = "NonResidentialBuildingProvision";
                    HeadName = "2059";
                    Session["Errortbl"] = provisionTbl;
                    ParentFlag = true;
                }
                else if (FromTbl.Trim() == "Total Head Abstract Report " + ddlYear.SelectedItem.ToString())
                {
                    ChildFlag = true;

                }
                if (ChildFlag)
                {
                    gv.DataSource = Dumy_dt;
                    gv.DataBind();
                }
                else
                {


                    SqlCommand cmd = new SqlCommand("SELECT a.[Sadyasthiti]as 'Work Status', Count(a.[Sadyasthiti])as'Total Work',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'Estimated Cost',sum(cast(a.[TrantrikAmt]as decimal(10,2)))as 'T.S Cost',sum(cast(b.[Tartud]as decimal(10,2))) as 'Budget Provision " + ddlYear.SelectedItem.ToString() + "',sum(cast(b.[AikunKharch]as decimal(10,2))) as 'Expenditure " + ddlYear.SelectedItem.ToString() + "' FROM " + FromTbl + " a full outer join " + provisionTbl + "  b on a.workid=b.workid where a.[Sadyasthiti]IS NOT NULL and b.Arthsankalpiyyear='" + ddlYear.SelectedItem.ToString() + "' and a.KhasdaracheName=N'" + UserName.ToString() + "' or a.AmdaracheName=N'" + UserName.ToString() + "'  GROUP BY a.[Sadyasthiti] order by case a.[Sadyasthiti] when N'पूर्ण' then 1 when N'Completed' then 1 when N'Incomplete' then 2 when N'अपूर्ण' then 2 when N'प्रगतीत' then 3 when N'Inprogress' then 3 when N'Processing' then 3 when N'Current' then 3 when N'चालू' then 3  when N'Tender Stage' then 4 when N'निविदा स्तर' then 4 when N'Estimated Stage' then 5 when N'अंदाजपत्रकिय स्थर' then 5 when N'अंदाजपत्रकीय स्तर' then 5 when N'Not Started' then 6 when N'सुरु न झालेली' then 6 when N'सुरू करणे' then 7 when N'' then 8 end", con);
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
        }
        int com, inc, inp, TS, ES, NS, NoStatus, No_OF_Works;
        decimal TotalWork = 0;
        decimal AACost = 0;
        decimal TSCost = 0;
        decimal TotalProvision = 0;
        decimal TotalExp = 0;
        Boolean flag = true;
        decimal[] arr = new decimal[10];
        string[] arr1 = { "Completed", "Incomplete", "Inprogress", "Tender Stage", "Estimated Stage", "Not Started", "Estimated Cost", "T.S Cost", "Budget Provision", "Expenditure" };
        DataRow dr;

        protected void gvChildGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (ChildFlag)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    
                    string errortbl = Session["Errortbl"].ToString();
                    com += Convert.ToInt32(e.Row.Cells[1].Text != "&nbsp;" ? e.Row.Cells[1].Text : e.Row.Cells[1].Text = "0");

                    if (e.Row.Cells[2].Text != "&nbsp;")
                        inc += Convert.ToInt32(e.Row.Cells[2].Text);
                    else e.Row.Cells[2].Text = "0";
                    if (e.Row.Cells[3].Text != "&nbsp;")
                        inp += Convert.ToInt32(e.Row.Cells[3].Text);
                    else e.Row.Cells[3].Text = "0";
                    if (e.Row.Cells[4].Text != "&nbsp;")
                        TS += Convert.ToInt32(e.Row.Cells[4].Text);
                    else e.Row.Cells[4].Text = "0";
                    if (e.Row.Cells[5].Text != "&nbsp;")
                        ES += Convert.ToInt32(e.Row.Cells[5].Text);
                    else e.Row.Cells[5].Text = "0";
                    if (e.Row.Cells[6].Text != "&nbsp;")
                        NS += Convert.ToInt32(e.Row.Cells[6].Text);
                    else e.Row.Cells[6].Text = "0";
                    NoStatus += Convert.ToInt32(e.Row.Cells[7].Text != "&nbsp;" ? e.Row.Cells[7].Text : e.Row.Cells[7].Text = "0");
                    No_OF_Works += Convert.ToInt32(e.Row.Cells[8].Text);
                    AACost += Convert.ToDecimal(e.Row.Cells[9].Text);
                    TSCost += Convert.ToDecimal(e.Row.Cells[10].Text);
                    TotalProvision += Convert.ToDecimal(e.Row.Cells[11].Text);
                    TotalExp += Convert.ToDecimal(e.Row.Cells[12].Text);

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    string errortbl = Session["Errortbl"].ToString();
                    e.Row.Cells[0].Text = "Total";


                    e.Row.Cells[1].Text = com.ToString();
                    e.Row.Cells[2].Text = inc.ToString();
                    e.Row.Cells[3].Text = inp.ToString();
                    e.Row.Cells[4].Text = TS.ToString();
                    e.Row.Cells[5].Text = ES.ToString();
                    e.Row.Cells[6].Text = NS.ToString();
                    e.Row.Cells[7].Text = NoStatus.ToString();
                    e.Row.Cells[8].Text = No_OF_Works.ToString();
                    e.Row.Cells[9].Text = AACost.ToString();
                    e.Row.Cells[10].Text = TSCost.ToString();
                    e.Row.Cells[11].Text = TotalProvision.ToString();
                    e.Row.Cells[12].Text = TotalExp.ToString();
                }

            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string errortbl = Session["Errortbl"].ToString();
                    if (flag)
                    {
                        dr = Dumy_dt.NewRow();
                    }
                    flag = false;

                    dr[0] = HeadName;
                    if (e.Row.Cells[0].Text.Trim() == "Completed" || e.Row.Cells[0].Text.Trim() == "पूर्ण")
                    {
                        e.Row.Cells[0].Text = "पूर्ण";
                        arr[0] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[1] = e.Row.Cells[1].Text;
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Incomplete" || e.Row.Cells[0].Text.Trim() == "अपूर्ण")
                    {
                        e.Row.Cells[0].Text = "अपूर्ण";
                        arr[1] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[2] = e.Row.Cells[1].Text;
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Inprogress" || e.Row.Cells[0].Text.Trim() == "Processing" || e.Row.Cells[0].Text.Trim() == "Current" || e.Row.Cells[0].Text.Trim() == "चालू" || e.Row.Cells[0].Text.Trim() == "प्रगतीत")
                    {
                        e.Row.Cells[0].Text = "प्रगतीत";
                        arr[2] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[3] = e.Row.Cells[1].Text;
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Tender Stage" || e.Row.Cells[0].Text.Trim() == "निविदा स्तर")
                    {
                        e.Row.Cells[0].Text = "निविदा स्तर";
                        arr[3] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[4] = e.Row.Cells[1].Text;
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Estimated Stage" || e.Row.Cells[0].Text.Trim() == "अंदाजपत्रकिय स्थर" || e.Row.Cells[0].Text.Trim() == "अंदाजपत्रकिय स्तर")
                    {
                        e.Row.Cells[0].Text = "अंदाजपत्रकिय स्थर";
                        arr[4] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[5] = e.Row.Cells[1].Text;
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Not Started" || e.Row.Cells[0].Text.Trim() == "सुरू करणे" || e.Row.Cells[0].Text.Trim() == "सुरु न झालेली")
                    {
                        e.Row.Cells[0].Text = "सुरु न झालेली";
                        arr[5] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[6] = e.Row.Cells[1].Text;
                    }

                    else
                    {
                        e.Row.Cells[0].Text = "सध्यास्तिथी उपलब्ध नाही";
                        dr[7] = e.Row.Cells[1].Text;

                    }

                    //e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                    TotalWork += Convert.ToDecimal(e.Row.Cells[1].Text);
                    AACost += Convert.ToDecimal(e.Row.Cells[2].Text);
                    TSCost += Convert.ToDecimal(e.Row.Cells[3].Text);
                    TotalProvision += Convert.ToDecimal(e.Row.Cells[4].Text);
                    TotalExp += Convert.ToDecimal(e.Row.Cells[5].Text);
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    string errortbl = Session["Errortbl"].ToString();
                    dr[8] = TotalWork.ToString();
                    dr[9] = AACost.ToString();
                    dr[10] = TSCost.ToString();
                    dr[11] = TotalProvision.ToString();
                    dr[12] = TotalExp.ToString();
                    Dumy_dt.Rows.Add(dr);
                    flag = true;
                    e.Row.Cells[0].Text = "एकूण";
                    e.Row.Cells[1].Text = TotalWork.ToString();
                    e.Row.Cells[2].Text = AACost.ToString();
                    e.Row.Cells[3].Text = TSCost.ToString();
                    e.Row.Cells[4].Text = TotalProvision.ToString();
                    e.Row.Cells[5].Text = TotalExp.ToString();
                    arr[6] += AACost;
                    arr[7] += TSCost;
                    arr[8] += TotalProvision;
                    arr[9] += TotalExp;
                }
            }
        }
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindGridview();

        }


        protected void BtnExcel_Click1(object sender, ImageClickEventArgs e)
        {

            gvParentGrid.AllowPaging = false;
            var gvChildGrid = new GridView();
            for (var i = 0; i < gvParentGrid.Rows.Count; i++)
            {
                gvChildGrid = (GridView)gvParentGrid.Rows[i].FindControl("gvChildGrid");
                gvChildGrid.AllowPaging = false;
                // BindGrid(SortField);
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Upvibhag" + DateTime.Now + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvChildGrid.AllowPaging = false;
                //this.BindGrid(SortField);
                gvChildGrid.Font.Name = "Times New Roman";
                gvChildGrid.BackColor = Color.Transparent;
                gvChildGrid.GridLines = GridLines.Both;


                gvChildGrid.RenderControl(hw);
                Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase));

                Response.Flush();
                Response.End();
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}