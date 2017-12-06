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
    public partial class Report_LekhasirshNabard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        string pri = string.Empty;
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
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "Nabard_MPR_Report.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "Nabard_MPR_Report.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }

            Response.Redirect("SendMail.aspx");
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
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT RDF_NO from BudgetMasterNABARD", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterNABARD", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from NABARDProvision Group By Arthsankalpiyyear", con);
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
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[RDF_NO] ORDER BY a.[Taluka]) as 'Sr.No',a.[RDF_NO] as 'RIDF',a.[Dist] as 'District',a.[Taluka] as 'Taluka' ,a.[KamacheName] as 'Name of Work',a.[PIC_NO] as 'PIC.No',cast(a.[PrashaskiyAmt] as decimal(18,2)) as 'AA Cost Rs in lakhs',cast(a.[TrantrikAmt] as decimal(18,2)) as 'Ts Cost Rs in lakhs' ,convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'Ts No and Date' ,b.[MarchEndingExpn] as 'MarchEndingExpn' ,b.[Tartud] as 'Tartud' ,b.[Magni] as 'Magni' ,b.[Magilkharch] as 'Magilkharch' ,a.[Sadyasthiti] as 'Physical progress of work' ,a.[Pahanikramank] as 'Probable of date of completion' ,a.[PCR] as 'PCR submitted or not' ,a.[Shera] as 'Remark' from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID where b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";
            if (Btnkam == "संपूर्ण")
            {
                if (ddlReportType.SelectedItem.Text == "संपूर्ण" || ddlkamacheYear.Text == "संपूर्ण")
                {
                    helper.RegisterGroup("RIDF", true, true);
                    helper.RegisterSummary("AA Cost Rs in lakhs", SummaryOperation.Sum, "RIDF");
                    helper.RegisterSummary("AA Cost Rs in lakhs", SummaryOperation.Sum);
                    helper.RegisterSummary("Ts Cost Rs in lakhs", SummaryOperation.Sum, "RIDF");
                    helper.RegisterSummary("Ts Cost Rs in lakhs", SummaryOperation.Sum);
                    helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum, "RIDF");
                    helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum);
                    helper.RegisterSummary("Tartud", SummaryOperation.Sum, "RIDF");
                    helper.RegisterSummary("Tartud", SummaryOperation.Sum);
                    helper.RegisterSummary("Magni", SummaryOperation.Sum, "RIDF");
                    helper.RegisterSummary("Magni", SummaryOperation.Sum);
                    helper.RegisterSummary("Magilkharch", SummaryOperation.Sum, "RIDF");
                    helper.RegisterSummary("Magilkharch", SummaryOperation.Sum);

                    helper.GroupSummary += new GroupEvent(helper_Bug);
                    helper.ApplyGroupSort();
                    dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterNABARD");
                    foreach (DataRow dr in dt.Rows)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                    }
                }

            }                
            else
            {
                helper.RegisterGroup("RIDF", true, true);
                helper.RegisterSummary("AA Cost Rs in lakhs", SummaryOperation.Sum);
                helper.RegisterSummary("Ts Cost Rs in lakhs", SummaryOperation.Sum);
                helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum);
                helper.RegisterSummary("Tartud", SummaryOperation.Sum);
                helper.RegisterSummary("Magni", SummaryOperation.Sum);
                helper.RegisterSummary("Magilkharch", SummaryOperation.Sum);
                helper.GroupSummary += new GroupEvent(helper_Bug);
                helper.ApplyGroupSort();
                dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterNABARD");
                foreach (DataRow dr in dt.Rows)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            Session["Report_LekhasirshNabard"] = GridView1;

            
        }        

        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Nabard_MPR_Report.xls"));
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
                Cell_Header.Text = "Sr.No";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "District";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Taluka";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Name of Work";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "PIC.No";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "AA Cost Rs in lakhs";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Ts Cost Rs in lakhs";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Ts No and Date";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Expenditure up to Mar " + ddlkamacheYear.SelectedItem.Text + " in Lakhs";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Budget Provision in " + ddlkamacheYear.SelectedItem.Text + " Rs in lakhs";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Demand for " + ddlkamacheYear.SelectedItem.Text + " Rs in lakhs";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Expenditure up to 9/2016 during year " + ddlkamacheYear.SelectedItem.Text + " Rs in Lakhs";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Physical progress of work";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "Probable date of Completion";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "PCR submitted or not";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);
               
                Cell_Header = new TableCell();
                Cell_Header.Text = "Remark";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                GridView1.Controls[0].Controls.AddAt(0, HeaderRow);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void ReportTypebtn_Click(object sender, EventArgs e)
        {
            Btnkam = ddlReportType.Text == "संपूर्ण" ? "संपूर्ण" : ddlReportType.Text;
            //OrderBy = "संपूर्ण";
            whereColumn = "संपूर्ण";
            dataload();
            ListMenu.Style.Add("display", "none");
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
            GridView1.DataBind();
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
        public void lekha()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select RDF_NO from BudgetMasterNABARD where RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lblshirsh.Text = dr["RDF_NO"].ToString();
            }
        }
        public void Upvibhag()
        {
            ddlUpvibhag.Items.Clear();
            ddlUpvibhag.Items.Add("निवडा");
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select Upvibhag FROM BudgetMasterNABARD  Group By Upvibhag" : "select a.Upvibhag FROM BudgetMasterNABARD as a join NABARDProvision as b on a.Workid=b.Workid where a.RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Upvibhag ";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
        //SqlDataAdapter sda = new SqlDataAdapter("select Upvibhag from BudgetMasterNABARD where RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' Group By Upvibhag", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlUpvibhag.Items.Add(dr["Upvibhag"].ToString());
            }
           // ddlUpvibhag.Items.Add("संपूर्ण");
        }
        public void Shakhabhiyanta()
        {
            ddlshakhaabhiyanta.Items.Clear();
            ddlshakhaabhiyanta.Items.Add("निवडा");
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  UpabhyantaName FROM BudgetMasterNABARD  Group By UpabhyantaName" : "select a.UpabhyantaName FROM BudgetMasterNABARD as a join NABARDProvision as b on a.Workid=b.Workid where a.RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By UpabhyantaName ";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            //SqlDataAdapter sda = new SqlDataAdapter("select UpabhyantaName from BudgetMasterNABARD where RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' Group By ShakhaAbhyantaName", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlshakhaabhiyanta.Items.Add(dr["UpabhyantaName"].ToString());
            }
           // ddlshakhaabhiyanta.Items.Add("संपूर्ण");
        }
        public void WorkId()
        {
            ddlworkId.Items.Clear();
            ddlworkId.Items.Add("निवडा");
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select WorkId FROM BudgetMasterNABARD" : "select a.WorkId FROM BudgetMasterNABARD as a join NABARDProvision as b on a.Workid=b.Workid where a.RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
          //  SqlDataAdapter sda = new SqlDataAdapter("select WorkId from BudgetMasterNABARD where RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' Group By WorkId", con);
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select ThekedaarName FROM BudgetMasterNABARD Group By ThekedaarName" : "select a.ThekedaarName FROM BudgetMasterNABARD as a join NABARDProvision as b on a.Workid=b.Workid where a.RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By ThekedaarName ";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            //SqlDataAdapter sda = new SqlDataAdapter("select ThekedaarName from BudgetMasterNABARD where RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' Group By ThekedaarName", con);
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  Sadyasthiti FROM BudgetMasterNABARD  Group By Sadyasthiti" : "select a.Sadyasthiti FROM BudgetMasterNABARD as a join NABARDProvision as b on a.Workid=b.Workid where a.RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Sadyasthiti ";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
           // SqlDataAdapter sda = new SqlDataAdapter("select Sadyasthiti from BudgetMasterNABARD where RDF_NO=N'" + ddlReportType.SelectedItem.Text + "' Group By Sadyasthiti", con);
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
            whereColumn = "a.[Upvibhag]=N";
            WhereColumnValue = ddlUpvibhag.Text;
            dataload();
            ListMenu.Style.Add("display", "none");
        }
        protected void btnShakhaAbhiyanta_Click(object sender, EventArgs e)
        {
            whereColumn = "a.[UpabhyantaName]=N";
            WhereColumnValue = ddlshakhaabhiyanta.Text;
            dataload();
            ListMenu.Style.Add("display", "none");
        }
        protected void btnWorkId_Click(object sender, EventArgs e)
        {
            whereColumn = "a.[WorkId]=N";
            WhereColumnValue = ddlworkId.Text;
            dataload();
            ListMenu.Style.Add("display", "none");
        }
        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            whereColumn = "a.[ThekedaarName]=N";
            WhereColumnValue = ddlthekedar.Text;
            dataload();
            ListMenu.Style.Add("display", "none");
        }
        protected void btnkamachisadyasthiti_Click(object sender, EventArgs e)
        {
            whereColumn = "a.[Sadyasthiti]=N";
            WhereColumnValue = ddlsadyasthiti.Text;
            dataload();
            ListMenu.Style.Add("display", "none");
        }

       

    }
}