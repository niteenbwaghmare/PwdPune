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
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class Report_LekhasirshRoad : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        string pri = string.Empty;
        //New Code Add
        MasterReportGridBind ObjMPRGridBind = new MasterReportGridBind();
        string whereColumn = string.Empty, WhereColumnValue = string.Empty, query = string.Empty;
        string Btnkam = string.Empty, OrderBy = string.Empty;
        string ddlist = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                subtype();
                KamacheYear();
                ArthsankalpiyYear();
            }
            ListMenu.Style.Add("display", "block");

        }
        //private void helper_GroupSummary(string groupName, object[] values, GridViewRow row)
        //{
        //    row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
        //    row.Cells[0].Text = "एकुण रक्कम";
        //}
        private void helper_Bug(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == null) return;
            row.BackColor = Color.Bisque;
            row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            row.Cells[0].Text = "एकुण रक्कम";
        }
        public void subtype()
        {
            ddlReportType.Items.Clear();
            ddlReportType.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select LekhaShirsh from SettingLekhaShirsh where Type='Road'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlReportType.Items.Add(dr[0].ToString());
            }
            ddlReportType.Items.Add("संपूर्ण");
        }
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "Road_MPR_Report.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "Road_MPR_Report.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }

            Response.Redirect("SendMail.aspx");
        }
     
        public void KamacheYear()
        {
            ddlkamacheYear.Items.Clear();
            ddlkamacheYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterRoad", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlkamacheYear.Items.Add(dr[0].ToString());
            }
            ddlkamacheYear.Items.Add("संपूर्ण");
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
        protected void ddlArthsankalpiyYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void lekha()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select lekhaShirsh from BudgetMasterRoad where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lblshirsh.Text = dr["lekhaShirsh"].ToString();
            }
        }
      

        public void nullgridview()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        public void dataload()
        {
            DataTable dt = new DataTable();
            lekha();
            if (pri != "print") 
            nullgridview();
            GridViewHelper helper = new GridViewHelper(this.GridView1);
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY [lekhashirsh] ORDER BY [SubType]) as 'SrNo',a.[SubType] ,a.[Upvibhag] as 'Upvibhag',a.[LekhaShirshName] as 'LekhaShirshName',a.PageNo as 'पेज क्र',a.ArthsankalpiyBab as 'बाब क्र',a.JulyBab as 'जुलै/ बाब क्र./पान क्र.',a.[KamacheName] as 'कामाचे नाव',b.[ManjurAmt] as ManjurAmt,b.[MarchEndingExpn] as MarchEndingExpn,b.[UrvaritAmt] as UrvaritAmt,b.[Takunone] as Takunone,b.[Takuntwo] as Takuntwo,b.[Tartud] as Tartud,b.[AkunAnudan] as AkunAnudan,b.[Magilkharch] as Magilkharch,b.[Magni] as Magni,CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(18,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(18,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(18,0)) as 'NS',a.[Shera] as 'शेरा' FROM BudgetMasterRoad as a join RoadProvision as b on a.Workid=b.Workid where b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";
           
            if (Btnkam == "संपूर्ण")
            {
                if (ddlReportType.SelectedItem.Text == "संपूर्ण" || ddlkamacheYear.Text == "संपूर्ण")
                {
                    string[] cols = new string[2];
                    cols[0] = "LekhaShirshName";
                    cols[1] = "Upvibhag";
                    helper.RegisterGroup(cols, true, true);
                    helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum);
                    helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum);
                    helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum);
                    helper.RegisterSummary("Takunone", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("Takunone", SummaryOperation.Sum);
                    helper.RegisterSummary("Takuntwo", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("Takuntwo", SummaryOperation.Sum);
                    helper.RegisterSummary("Tartud", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("Tartud", SummaryOperation.Sum);
                    helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum);
                    helper.RegisterSummary("Magilkharch", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("Magilkharch", SummaryOperation.Sum);
                    helper.RegisterSummary("Magni", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("Magni", SummaryOperation.Sum);
                    helper.RegisterSummary("C", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("C", SummaryOperation.Sum);
                    helper.RegisterSummary("P", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("P", SummaryOperation.Sum);
                    helper.RegisterSummary("NS", SummaryOperation.Sum, "LekhaShirshName+Upvibhag");
                    helper.RegisterSummary("NS", SummaryOperation.Sum);
                    helper.GroupSummary += new GroupEvent(helper_Bug);
                    helper.ApplyGroupSort();
                    dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterRoad");
                    foreach (DataRow dr in dt.Rows)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                    }
                }

            }
            else
            {
                helper.RegisterGroup("LekhaShirshName", true, true);
                helper.RegisterGroup("Upvibhag", true, true);

                helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum);
                helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum);
                helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum);
                helper.RegisterSummary("Takunone", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("Takunone", SummaryOperation.Sum);
                helper.RegisterSummary("Takuntwo", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("Takuntwo", SummaryOperation.Sum);
                helper.RegisterSummary("Tartud", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("Tartud", SummaryOperation.Sum);
                helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum);
                helper.RegisterSummary("Magilkharch", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("Magilkharch", SummaryOperation.Sum);
                helper.RegisterSummary("Magni", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("Magni", SummaryOperation.Sum);
                helper.RegisterSummary("C", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("C", SummaryOperation.Sum);
                helper.RegisterSummary("P", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("P", SummaryOperation.Sum);
                helper.RegisterSummary("NS", SummaryOperation.Sum, "Upvibhag");
                helper.RegisterSummary("NS", SummaryOperation.Sum);

                helper.GroupSummary += new GroupEvent(helper_Bug);
                dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterRoad");
                foreach (DataRow dr in dt.Rows)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 101 , 100 ,false); </script>", false);
            Session["Report_LekhasirshRoad"] = GridView1;          
        }
       
        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            //kamacheyeardataload();
            Btnkam = ddlkamacheYear.Text == "संपूर्ण" ? "संपूर्ण" : ddlkamacheYear.Text;
            OrderBy = "संपूर्ण";
            whereColumn = "संपूर्ण";
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            pri = "print";
           Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Road_MPR_Report.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            BindWhereColumnNameValue();
            dataload();
            //Change the Header Row back to white color
            //GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
            ////Applying stlye to gridview header cells
            //for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
            //{
            //    GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
            //}
            GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Tell the compiler that the control is rendered
             * explicitly by overriding the VerifyRenderingInServerForm event.*/
        }
        private void BindWhereColumnNameValue()
        {
            if (ddlkamacheYear.SelectedItem.Text != "निवडा")
            {
                Btnkam = ddlkamacheYear.Text == "संपूर्ण" ? "संपूर्ण" : ddlkamacheYear.Text;
                OrderBy = "संपूर्ण";
                whereColumn = "संपूर्ण";
            }
            else if (ddlReportType.SelectedItem.Text != "निवडा")
            {
                Btnkam = ddlReportType.Text == "संपूर्ण" ? "संपूर्ण" : ddlReportType.Text;
                OrderBy = "संपूर्ण";
                whereColumn = "संपूर्ण";
            }
            else if (ddlUpvibhag.SelectedItem.Text != "निवडा")
            {
                whereColumn = "a.[Upvibhag]=N";
                WhereColumnValue = ddlUpvibhag.Text;
            }
            else if (ddlshakhaabhiyanta.SelectedItem.Text != "निवडा")
            {
                whereColumn = "a.[UpabhyantaName]=N";
                WhereColumnValue = ddlshakhaabhiyanta.Text;
            }
            else if (ddlworkId.SelectedItem.Text != "निवडा")
            {
                whereColumn = "a.[WorkId]=N";
                WhereColumnValue = ddlworkId.Text;
            }
            else if (ddlthekedar.SelectedItem.Text != "निवडा")
            {
                whereColumn = "a.[ThekedaarName]=N";
                WhereColumnValue = ddlthekedar.Text;
            }
            else if (ddlsadyasthiti.SelectedItem.Text != "निवडा")
            {
                whereColumn = "a.[Sadyasthiti]=N";
                WhereColumnValue = ddlsadyasthiti.Text;
            }
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();
                //Cell_Header.Text = "अ.क्र";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.ForeColor = Color.White;
                //Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                //Cell_Header.ColumnSpan = 1;
                //HeaderRow.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                Cell_Header.Text = "पेज क्र";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "बाब क्र";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "जुलै/16 बाब क्र./ पान क्र.";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "कामाचे नाव";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "मंजुर अंदाजित किंमत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "सुरवाती पासून मार्च " + ddlkamacheYear.SelectedValue.Substring(0, 4) + " अखेरचा खर्च";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "उर्वरित किंमत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " मधील अर्थसंकल्पीय तरतूद मार्च" + ddlkamacheYear.SelectedValue.Substring(0, 4);
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " मधील अर्थसंकल्पीय तरतूद जुलै " + ddlkamacheYear.SelectedValue.Substring(0, 4);
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "एकूण अर्थसंकल्पीय तरतूद";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " मधील वितरित तरतूद";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " मधील माहे 9/" + ddlkamacheYear.SelectedValue.Substring(0, 4) + " अखेरचा खर्च";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " साठी मागणी";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "C";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "P";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                 HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "NS";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
               HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "शेरा";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                GridView1.Controls[0].Controls.AddAt(0, HeaderRow);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[2].Visible = false;
        }

        protected void ReportTypebtn_Click(object sender, EventArgs e)
        {
            Btnkam = ddlReportType.Text == "संपूर्ण" ? "संपूर्ण" : ddlReportType.Text;
            //OrderBy = "संपूर्ण";
            whereColumn = "संपूर्ण";
            dataload();
            ListMenu.Style.Add("display", "none");

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            dataload();
        }
       
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }

        protected void btnPrint_Click1(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "PrintGridData()", true);
            pri = "print";
            BindWhereColumnNameValue();
            dataload();
        }
        public void Upvibhag()
        {
            ddlUpvibhag.Items.Clear();
            ddlUpvibhag.Items.Add("निवडा");
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select Upvibhag FROM BudgetMasterRoad  Group By Upvibhag" : "select a.Upvibhag FROM BudgetMasterRoad as a join RoadProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Upvibhag";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            //SqlDataAdapter sda = new SqlDataAdapter("select Upvibhag from BudgetMasterRoad where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' Group By Upvibhag", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlUpvibhag.Items.Add(dr["Upvibhag"].ToString());
            }
            //ddlUpvibhag.Items.Add("संपूर्ण");
        }
        public void Shakhabhiyanta()
        {
            ddlshakhaabhiyanta.Items.Clear();
            ddlshakhaabhiyanta.Items.Add("निवडा");
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  UpabhyantaName FROM BudgetMasterRoad  Group By UpabhyantaName" : "select a.UpabhyantaName FROM BudgetMasterRoad as a join RoadProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By UpabhyantaName";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
           // SqlDataAdapter sda = new SqlDataAdapter("select ShakhaAbhyantaName from BudgetMasterRoad where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' Group By ShakhaAbhyantaName", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlshakhaabhiyanta.Items.Add(dr["UpabhyantaName"].ToString());
            }
            //ddlshakhaabhiyanta.Items.Add("संपूर्ण");
        }
        public void WorkId()
        {
            ddlworkId.Items.Clear();
            ddlworkId.Items.Add("निवडा");
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select WorkId FROM BudgetMasterRoad" : "select a.WorkId FROM BudgetMasterRoad as a join RoadProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlworkId.Items.Add(dr["WorkId"].ToString());
            }
           // ddlworkId.Items.Add("संपूर्ण");

        }
        public void Tekedar()
        {
            ddlthekedar.Items.Clear();
            ddlthekedar.Items.Add("निवडा");
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select ThekedaarName FROM BudgetMasterRoad Group By ThekedaarName" : "select a.ThekedaarName FROM BudgetMasterRoad as a join RoadProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By ThekedaarName";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            //SqlDataAdapter sda = new SqlDataAdapter("select ThekedaarName from BudgetMasterRoad where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' Group By ThekedaarName", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlthekedar.Items.Add(dr["ThekedaarName"].ToString());
            }
            //ddlthekedar.Items.Add("संपूर्ण");

        }
        public void Sadyasthithi()
        {
            ddlsadyasthiti.Items.Clear();
            ddlsadyasthiti.Items.Add("निवडा");
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  Sadyasthiti FROM BudgetMasterRoad  Group By Sadyasthiti" : "select a.Sadyasthiti FROM BudgetMasterRoad as a join RoadProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Sadyasthiti";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
           // SqlDataAdapter sda = new SqlDataAdapter("select Sadyasthiti from BudgetMasterRoad where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' Group By Sadyasthiti", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlsadyasthiti.Items.Add(dr["Sadyasthiti"].ToString());
            }
           // ddlsadyasthiti.Items.Add("संपूर्ण");

        }

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Upvibhag();
            Shakhabhiyanta();
            WorkId();
            Tekedar();
            Sadyasthithi();

        }
        protected void btnUpvibhag_Click(object sender, EventArgs e)
        {
           // UpVibhag1();
            whereColumn = "a.[Upvibhag]=N";
            WhereColumnValue = ddlUpvibhag.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnShakhaAbhiyanta_Click(object sender, EventArgs e)
        {
            //Shakhaabiyanta1();
            whereColumn = "a.[UpabhyantaName]=N";
            WhereColumnValue = ddlshakhaabhiyanta.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnWorkId_Click(object sender, EventArgs e)
        {
            //WorkID1();
            whereColumn = "a.[WorkId]=N";
            WhereColumnValue = ddlworkId.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            //Thekedar1();
            whereColumn = "a.[ThekedaarName]=N";
            WhereColumnValue = ddlthekedar.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnkamachisadyasthiti_Click(object sender, EventArgs e)
        {
            //Sayasthiti1();
            whereColumn = "a.[Sadyasthiti]=N";
            WhereColumnValue = ddlsadyasthiti.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }

      
    }
}
