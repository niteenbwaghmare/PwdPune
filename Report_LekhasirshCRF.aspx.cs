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
    public partial class Report_LekhasirshCRF : System.Web.UI.Page
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
        private void helper_GroupSummary(string groupName, object[] values, GridViewRow row)
        {

        }
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
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT [ArthsankalpiyBab] from BudgetMasterCRF", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlReportType.Items.Add(dr[0].ToString());
            }
            ddlReportType.Items.Add("संपूर्ण");
        }

        public void KamacheYear()
        {
            ddlkamacheYear.Items.Clear();
             ddlkamacheYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterCRF", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from CRFProvision Group By Arthsankalpiyyear", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select ArthsankalpiyBab from BudgetMasterCRF where ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lblshirsh.Text = dr["ArthsankalpiyBab"].ToString();
            }
        }


        public void nullgridview()
        {
            gvCustomers.DataSource = null;
            gvCustomers.DataBind();
        }
        public void dataload()
        {
            DataTable dt = new DataTable();
            lekha();
            if (pri != "print")
                nullgridview();
            GridViewHelper helper = new GridViewHelper(this.gvCustomers);
            query = "SELECT a.WorkID,row_number() over(order by a.WorkID)as 'WorkIDl',a.[Dist] as 'Dist',a.[ArthsankalpiyBab] as 'SrNo',a.[KamacheName] as 'Name of work',convert(nvarchar(max),a.[JobNo])+' - '+convert(nvarchar(max),a.[SanctionDate]) as 'Job No',a.[SanctionAmount] as 'SanctionAmt',a.[RoadLength] as 'RoadLength',b.[Tartud] as 'OBP',b.[Chalukharch] as 'Eduringmon',b.[MarchEndingExpn] as 'CExpndrmonth',b.[Magni] as 'Demand',a.[NividaDate]  as 'Dateofstarting' ,a.[KamPurnDate]  as 'Dateofcompletion' ,a.[ThekedaarName]  as 'NameofAgency' ,a.[karyarambhadesh]  as 'Awardbelow' ,a.[NividaAmt]  as 'Tenderedamount' ,convert(nvarchar(max),b.[Tartud])+' | '+convert(nvarchar(max),b.[Chalukharch]) as 'submissiontoMORTH' ,convert(nvarchar(max),a.[NividaAmt])+' | '+convert(nvarchar(max),a.[KamPurnDate]) as 'CompletionMORTH' ,a.[PahaniMudye]as 'Reasons',a.[Shera] as 'Remarks' FROM BudgetMasterCRF as a join CRFProvision as b on a.WorkID=b.WorkID where b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";
            if (Btnkam == "संपूर्ण")
            {
                if (ddlReportType.SelectedItem.Text == "संपूर्ण" || ddlkamacheYear.Text == "संपूर्ण")
                {
                    helper.RegisterGroup("SrNo", true, true);
                    helper.RegisterSummary("SanctionAmt", SummaryOperation.Sum, "SrNo");
                    helper.RegisterSummary("SanctionAmt", SummaryOperation.Sum);
                    helper.RegisterSummary("OBP", SummaryOperation.Sum, "SrNo");
                    helper.RegisterSummary("OBP", SummaryOperation.Sum);
                    helper.RegisterSummary("Eduringmon", SummaryOperation.Sum, "SrNo");
                    helper.RegisterSummary("Eduringmon", SummaryOperation.Sum);
                    helper.RegisterSummary("CExpndrmonth", SummaryOperation.Sum, "SrNo");
                    helper.RegisterSummary("CExpndrmonth", SummaryOperation.Sum);
                    helper.RegisterSummary("Demand", SummaryOperation.Sum, "SrNo");
                    helper.RegisterSummary("Demand", SummaryOperation.Sum);
                    helper.GroupSummary += new GroupEvent(helper_Bug);
                    //helper.ApplyGroupSort();
                    dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterCRF");
                    foreach (DataRow dr in dt.Rows)
                    {
                        gvCustomers.DataSource = dt;
                        gvCustomers.DataBind();

                    }
                }

            }
            else
            {
                helper.RegisterGroup("SrNo", true, true);
                helper.RegisterSummary("SanctionAmt", SummaryOperation.Sum);
                helper.RegisterSummary("OBP", SummaryOperation.Sum);
                helper.RegisterSummary("Eduringmon", SummaryOperation.Sum);
                helper.RegisterSummary("CExpndrmonth", SummaryOperation.Sum);
                helper.RegisterSummary("Demand", SummaryOperation.Sum);
                helper.GroupSummary += new GroupEvent(helper_Bug);
                //helper.ApplyGroupSort();
                dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterCRF");
                foreach (DataRow dr in dt.Rows)
                {
                    gvCustomers.DataSource = dt;
                    gvCustomers.DataBind();
                }
            }

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + gvCustomers.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            Session["Report_LekhasirshCRF"] = gvCustomers;
        }
        

        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            //KamacheYearData();
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "CRF_MPR_Report.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvCustomers.AllowPaging = false;
            dataload();
            //Change the Header Row back to white color
            //GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
            ////Applying stlye to gridview header cells
            //for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
            //{
            //    GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
            //}
            gvCustomers.RenderControl(htw);
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
        protected void gvCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl1 = (Label)e.Row.FindControl("APhysicalScope");
                Label lbl2 = (Label)e.Row.FindControl("ACommulative");
                Label lbl3 = (Label)e.Row.FindControl("ATarget");
                Label lbl4 = (Label)e.Row.FindControl("AAchievement");
                Label lbl5 = (Label)e.Row.FindControl("BPhysicalScope");
                Label lbl6 = (Label)e.Row.FindControl("BCommulative");
                Label lbl7 = (Label)e.Row.FindControl("BTarget");
                Label lbl8 = (Label)e.Row.FindControl("BAchievement");
                Label lbl9 = (Label)e.Row.FindControl("CPhysicalScope");
                Label lbl10 = (Label)e.Row.FindControl("CCommulative");
                Label lbl11 = (Label)e.Row.FindControl("CTarget");
                Label lbl12 = (Label)e.Row.FindControl("CAchievement");
                Label lbl13 = (Label)e.Row.FindControl("DPhysicalScope");
                Label lbl14 = (Label)e.Row.FindControl("DCommulative");
                Label lbl15 = (Label)e.Row.FindControl("DTarget");
                Label lbl16 = (Label)e.Row.FindControl("DAchievement");
                Label lbl17 = (Label)e.Row.FindControl("EPhysicalScope");
                Label lbl18 = (Label)e.Row.FindControl("ECommulative");
                Label lbl19 = (Label)e.Row.FindControl("ETarget");
                Label lbl20 = (Label)e.Row.FindControl("EAchievement");

                string WorkID = gvCustomers.DataKeys[e.Row.RowIndex].Value.ToString();
                SqlDataAdapter sda = new SqlDataAdapter("select APhysicalScope,BPhysicalScope,CPhysicalScope,DPhysicalScope,EPhysicalScope,ACommulative,BCommulative,CCommulative,DCommulative,ECommulative,ATarget,BTarget,CTarget,DTarget,ETarget,AAchievement,BAchievement,CAchievement,DAchievement,EAchievement  from BudgetMasterCRF where WorkID=N'" + WorkID + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lbl1.Text = dr["APhysicalScope"].ToString();
                    lbl2.Text = dr["ACommulative"].ToString();
                    lbl3.Text = dr["ATarget"].ToString();
                    lbl4.Text = dr["AAchievement"].ToString();
                    lbl5.Text = dr["BPhysicalScope"].ToString();
                    lbl6.Text = dr["BCommulative"].ToString();
                    lbl7.Text = dr["BTarget"].ToString();
                    lbl8.Text = dr["BAchievement"].ToString();
                    lbl9.Text = dr["CPhysicalScope"].ToString();
                    lbl10.Text = dr["CCommulative"].ToString();
                    lbl11.Text = dr["CTarget"].ToString();
                    lbl12.Text = dr["CAchievement"].ToString();
                    lbl13.Text = dr["DPhysicalScope"].ToString();
                    lbl14.Text = dr["DCommulative"].ToString();
                    lbl15.Text = dr["DTarget"].ToString();
                    lbl16.Text = dr["DAchievement"].ToString();
                    lbl17.Text = dr["EPhysicalScope"].ToString();
                    lbl18.Text = dr["ECommulative"].ToString();
                    lbl19.Text = dr["ETarget"].ToString();
                    lbl20.Text = dr["EAchievement"].ToString();
                }
            }
        }
        protected void gvCustomers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Sr.No";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Dist";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Name of work";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Job No / Date of sanction original / Revised";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Sanction amount original/ Revised";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Road Length (Km) / M (for Bridges)";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Expenditure During " + ddlkamacheYear.SelectedItem.Text;
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Cumulative Expenditure. up to 31 March " + ddlkamacheYear.SelectedItem.Text;
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = ddlArthYear.SelectedItem.Text;
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                Cell_Header.ColumnSpan = 4;
                headerRow1.Cells.Add(Cell_Header);

                TableCell headerCell1 = new TableCell();
                headerCell1.Text = "OBP " + ddlkamacheYear.SelectedItem.Text;
                headerCell1.HorizontalAlign = HorizontalAlign.Center;
                headerCell1.ForeColor = Color.White;
                headerCell1.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell1);

                TableCell headerCell2 = new TableCell();
                headerCell2.Text = "Expenditure During Month " + ddlkamacheYear.SelectedItem.Text;
                headerCell2.HorizontalAlign = HorizontalAlign.Center;
                headerCell2.ForeColor = Color.White;
                headerCell2.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell2);

                TableCell headerCell3 = new TableCell();
                headerCell3.Text = "Cumulative Expenditure upto Sept 2016 in 2016-2017";
                headerCell3.HorizontalAlign = HorizontalAlign.Center;
                headerCell3.ForeColor = Color.White;
                headerCell3.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell3);

                TableCell headerCell4 = new TableCell();
                headerCell4.Text = "Demand " + ddlkamacheYear.SelectedItem.Text;
                headerCell4.HorizontalAlign = HorizontalAlign.Center;
                headerCell4.ForeColor = Color.White;
                headerCell4.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell4);


                Cell_Header = new TableCell();
                Cell_Header.Text = "Physical Target Scope";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                Cell_Header.ColumnSpan = 1;
                headerRow1.Cells.Add(Cell_Header);

                TableCell headerCell5 = new TableCell();
                headerCell5.Text = "A) WBM Wide. (kms.) <br>  B) B.T. (kms) C)C.D.    Works (Nos.)   D) Minor Bridges(Nos)     E) Major bridges   (Nos.)";
                headerCell5.HorizontalAlign = HorizontalAlign.Center;
                headerCell5.ForeColor = Color.White;
                headerCell5.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell5);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Physical Target / Achievement";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                Cell_Header.ColumnSpan = 3;
                headerRow1.Cells.Add(Cell_Header);

                TableCell headerCell6 = new TableCell();
                headerCell6.Text = "Cumulative achievement as on 31 March " + ddlkamacheYear.SelectedItem.Text;
                headerCell6.HorizontalAlign = HorizontalAlign.Center;
                headerCell6.ForeColor = Color.White;
                headerCell6.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell6);

                TableCell headerCell7 = new TableCell();
                headerCell7.Text = "Target " + ddlkamacheYear.SelectedItem.Text;
                headerCell7.HorizontalAlign = HorizontalAlign.Center;
                headerCell7.ForeColor = Color.White;
                headerCell7.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell7);

                TableCell headerCell8 = new TableCell();
                headerCell8.Text = "Achievement " + ddlkamacheYear.SelectedItem.Text;
                headerCell8.HorizontalAlign = HorizontalAlign.Center;
                headerCell8.ForeColor = Color.White;
                headerCell8.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell8);


                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Date of starting";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Date of completion as per tender/revised date of completion";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Name of Agency";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Award of contract% above/%  below";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Tendered amount in lakh";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Utilisation Cert.of expenditure  amount & date of submission to MORTH";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Completion certificate duly vetted by audit & submitted to MORTH amount & date of submission to MORTH";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Reasons for delay in completion (L.A.contractors fault etc.)";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Remarks";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);


                gvCustomers.Controls[0].Controls.AddAt(0, headerRow2);
                gvCustomers.Controls[0].Controls.AddAt(0, headerRow1);
            }
        }
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "CRF_MPR_Report.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "CRF_MPR_Report.xls");
                    gvCustomers.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }

            Response.Redirect("SendMail.aspx");
        }

        protected void ReportTypebtn_Click(object sender, EventArgs e)
        {
            

            Btnkam = ddlReportType.Text == "संपूर्ण" ? "संपूर्ण" : ddlReportType.Text;
            //OrderBy = "संपूर्ण";
            whereColumn = "संपूर्ण";
            dataload();
            ListMenu.Style.Add("display", "none");

        }


        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        protected void BtnExcel_Click1(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MPR_CRF_Report.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvCustomers.AllowPaging = false;
            BindWhereColumnNameValue();
            dataload();
            gvCustomers.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            Response.Redirect("Report_LekhasirshCRF.aspx");
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select Upvibhag FROM BudgetMasterCRF  Group By Upvibhag" : "select a.Upvibhag FROM BudgetMasterCRF as a join CRFProvision as b on a.Workid=b.Workid where a.ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Upvibhag";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            //SqlDataAdapter sda = new SqlDataAdapter("select Upvibhag from ArthsankalpiyBab where ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' Group By Upvibhag", con);
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  UpabhyantaName FROM BudgetMasterCRF  Group By UpabhyantaName" : "select a.UpabhyantaName FROM BudgetMasterCRF as a join CRFProvision as b on a.Workid=b.Workid where a.ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By UpabhyantaName";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            // SqlDataAdapter sda = new SqlDataAdapter("select ShakhaAbhyantaName from BudgetMasterCRF where ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' Group By ShakhaAbhyantaName", con);
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select WorkId FROM BudgetMasterCRF" : "select a.WorkId FROM BudgetMasterCRF as a join CRFProvision as b on a.Workid=b.Workid where a.ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            // SqlDataAdapter sda = new SqlDataAdapter("select WorkId from BudgetMasterCRF where ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' Group By WorkId", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlworkId.Items.Add(dr["WorkId"].ToString());
            }
            //ddlworkId.Items.Add("संपूर्ण");

        }
        public void Tekedar()
        {
            ddlthekedar.Items.Clear();
            ddlthekedar.Items.Add("निवडा");
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select ThekedaarName FROM BudgetMasterCRF Group By ThekedaarName" : "select a.ThekedaarName FROM BudgetMasterCRF as a join CRFProvision as b on a.Workid=b.Workid where a.ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By ThekedaarName";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            // SqlDataAdapter sda = new SqlDataAdapter("select ThekedaarName from BudgetMasterCRF where ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' Group By ThekedaarName", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlthekedar.Items.Add(dr["ThekedaarName"].ToString());
            }
            // ddlthekedar.Items.Add("संपूर्ण");

        }
        public void Sadyasthithi()
        {
            ddlsadyasthiti.Items.Clear();
            ddlsadyasthiti.Items.Add("निवडा");
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  Sadyasthiti FROM BudgetMasterCRF  Group By Sadyasthiti" : "select a.Sadyasthiti FROM BudgetMasterCRF as a join CRFProvision as b on a.Workid=b.Workid where a.ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Sadyasthiti";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            //       SqlDataAdapter sda = new SqlDataAdapter("select Sadyasthiti from BudgetMasterCRF where ArthsankalpiyBab=N'" + ddlReportType.SelectedItem.Text + "' Group By Sadyasthiti", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlsadyasthiti.Items.Add(dr["Sadyasthiti"].ToString());
            }
            //ddlsadyasthiti.Items.Add("संपूर्ण");

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
            //UpvibhagData();
            //ListMenu.Style.Add("display", "none");
            whereColumn = "a.[Upvibhag]=N";
            WhereColumnValue = ddlUpvibhag.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnShakhaAbhiyanta_Click(object sender, EventArgs e)
        {
            //ShakhaabhiyantaData();
            //ListMenu.Style.Add("display", "none");
            whereColumn = "a.[UpabhyantaName]=N";
            WhereColumnValue = ddlshakhaabhiyanta.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnWorkId_Click(object sender, EventArgs e)
        {
            //WorkIdData(); 
            //ListMenu.Style.Add("display", "none");
            whereColumn = "a.[WorkId]=N";
            WhereColumnValue = ddlworkId.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            //Thekedardata();
            //ListMenu.Style.Add("display", "none");
            whereColumn = "a.[ThekedaarName]=N";
            WhereColumnValue = ddlthekedar.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnkamachisadyasthiti_Click(object sender, EventArgs e)
        {
            //SayasthitiData();
            //ListMenu.Style.Add("display", "none");
            whereColumn = "a.[Sadyasthiti]=N";
            WhereColumnValue = ddlsadyasthiti.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }






    }
}