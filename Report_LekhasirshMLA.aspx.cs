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
    public partial class Report_LekhasirshMLA : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        string pri = string.Empty;
        MasterReportGridBind ObjMPRGridBind = new MasterReportGridBind();
        string whereColumn = string.Empty, WhereColumnValue = string.Empty, query = string.Empty;
        string Btnkam = string.Empty, OrderBy = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Amdar();
                KamacheYear();
                ArthsankalpiyYear();
            }
            ListMenu.Style.Add("display", "block");

        }
        private void helper_Bug(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == null) return;
            row.BackColor = Color.Bisque;
            row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            row.Cells[0].Text = "एकुण रक्कम";
        }
        public void Amdar()//
        {
            ddlReportType.Items.Clear();
            ddlReportType.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT AmdaracheName from BudgetMasterMLA", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterMLA", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from MLAProvision Group By Arthsankalpiyyear", con);
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
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "MLA_MPR_Report.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "MLA_MPR_Report.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }

            Response.Redirect("SendMail.aspx");
        }
        public void lekha()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select lekhaShirsh from BudgetMasterMLA where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lblshirsh.Text = dr["lekhaShirsh"].ToString();
            }
        }
        public void dataload()
        {

            lekha();
            if (pri != "print")
                nullgridview();
            GridViewHelper helper = new GridViewHelper(this.GridView1);
            DataTable dt = new DataTable();
            if (OrderBy != string.Empty)
            {
                OrderBy = "a.[PageNo] ORDER BY a.[AmdaracheName] ";
            }
            else
            {
                OrderBy = "a.[AmdaracheName] ORDER BY a.[PageNo]";
            }

            query = "SELECT  ROW_NUMBER() OVER(PARTITION BY " + OrderBy + ")as 'अ.क्र',a.[PageNo] as 'प्रकार',a.[AmdaracheName] as 'आमदारांचे नाव',a.[Taluka] as 'तालुका', a.[KamacheName] as 'कामाचे नाव', convert(nvarchar(max),a.[PrashaskiyAmt])as 'एकूण अंदाजित किंमत (अलिकडील सुधारित) प्रशासकीय मान्यता किंमत',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max), a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate]) as 'निविदा क्र.व दिनांक',b.[MarchEndingExpn] as 'MarchEndingExpn',b.[ManjurAmt] as 'ManjurAmt',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[Tartud] as 'Tartud',b.[AkunAnudan] as 'AkunAnudan',b.[Chalukharch] as 'Chalukharch',b.[Magni] as 'Magni', CAST(CASE WHEN a.[Sadyasthiti] = N'प्रगतीत'  THEN 1 ELSE 0 END as decimal(10,2)) as 'प्रगतीत',CAST(CASE WHEN a.[Sadyasthiti] = N'पूर्ण'  THEN 1 ELSE 0 END as decimal(10,2)) as 'पूर्ण', CAST(CASE WHEN a.[Sadyasthiti] = N'निविदा स्तर'  THEN 1 ELSE 0 END as decimal(10,2)) as 'निविदा स्तर',CAST(CASE WHEN a.[Sadyasthiti] = N'अं स्तर'  THEN 1 ELSE 0 END as decimal(10,2)) as 'अं स्तर',a.[Shera] as 'शेरा' FROM BudgetMasterMLA as a join MLAProvision as b on a.Workid=b.Workid where b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' ";

            if (Btnkam == "संपूर्ण")
            {


                if (ddlReportType.SelectedItem.Text == "संपूर्ण" || ddlkamacheYear.Text == "संपूर्ण")
                {
                    string[] cols = new string[2];
                    cols[0] = "आमदारांचे नाव";
                    cols[1] = "प्रकार";
                    helper.RegisterGroup(cols, true, true);
                    helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum);
                    helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum);
                    helper.RegisterSummary("उर्वरित किंमत", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("उर्वरित किंमत", SummaryOperation.Sum);
                    helper.RegisterSummary("Tartud", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("Tartud", SummaryOperation.Sum);
                    helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum);
                    helper.RegisterSummary("Chalukharch", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("Chalukharch", SummaryOperation.Sum);
                    helper.RegisterSummary("Magni", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("Magni", SummaryOperation.Sum);
                    helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum);
                    helper.RegisterSummary("पूर्ण", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("पूर्ण", SummaryOperation.Sum);
                    helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum);
                    helper.RegisterSummary("अं स्तर", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                    helper.RegisterSummary("अं स्तर", SummaryOperation.Sum);
                    helper.GroupSummary += new GroupEvent(helper_Bug);
                    helper.ApplyGroupSort();

                    dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterMLA");

                }
            }
            else
            {
                string[] cols = new string[2];
                cols[0] = "आमदारांचे नाव";
                cols[1] = "प्रकार";
                helper.RegisterGroup(cols, true, true);
                helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum);
                helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum);
                helper.RegisterSummary("उर्वरित किंमत", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("उर्वरित किंमत", SummaryOperation.Sum);
                helper.RegisterSummary("Tartud", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("Tartud", SummaryOperation.Sum);
                helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum);
                helper.RegisterSummary("Chalukharch", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("Chalukharch", SummaryOperation.Sum);
                helper.RegisterSummary("Magni", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("Magni", SummaryOperation.Sum);
                helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum);
                helper.RegisterSummary("पूर्ण", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("पूर्ण", SummaryOperation.Sum);
                helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum);
                helper.RegisterSummary("अं स्तर", SummaryOperation.Sum, "आमदारांचे नाव+प्रकार");
                helper.RegisterSummary("अं स्तर", SummaryOperation.Sum);

                helper.GroupSummary += new GroupEvent(helper_Bug);
                helper.ApplyGroupSort();

                dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterMLA");

            }
            foreach (DataRow dr in dt.Rows)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 102 , 100 ,false); </script>", false);

            Session["Report_LekhasirshMLA"] = GridView1;
        }

        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            Btnkam = ddlkamacheYear.Text == "संपूर्ण" ? "संपूर्ण" : ddlkamacheYear.Text;

            OrderBy = "संपूर्ण";
            whereColumn = "संपूर्ण";
            dataload();
            //kamacheYearData();
            ListMenu.Style.Add("display", "none");

        }

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            pri = "print";
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "MLA_MPR_Report.xls"));
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
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "अ.क्र";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "योजनेचे नाव / कामाचे नाव";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "एकूण अंदाजित किंमत (अलिकडील सुधारित) प्रशासकीय मान्यता किंमत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "तांत्रिक मान्यता क्रं. व किंमत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "निविदा क्रं. व दिनांक";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "मार्च "+ ddlkamacheYear.SelectedItem.Text.Substring(0,4) +" अखेर पर्यंतचा एकूण खर्च";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "सन " + ddlkamacheYear.SelectedItem.Text + " मधील अपेक्षित खर्च";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "उर्वरित किंमत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "काम निहाय तरतूद सन " + ddlkamacheYear.SelectedItem.Text ;
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "वितरीत तरतूद सन " + ddlkamacheYear.SelectedItem.Text;
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "खर्च सन " + ddlkamacheYear.SelectedItem.Text +" 06/2016 अखेर खर्च";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "मागणी " + ddlkamacheYear.SelectedItem.Text;
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.RowSpan = 2;
                //Cell_Header.Text = "मागणी 2017-18";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.ForeColor = Color.White;
                //Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                //headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "कामाची सद्यस्थिती";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                Cell_Header.ColumnSpan = 4;
                headerRow1.Cells.Add(Cell_Header);

                TableCell headerCell1 = new TableCell();
                headerCell1.Text = "प्रगतीत";
                headerCell1.HorizontalAlign = HorizontalAlign.Center;
                headerCell1.ForeColor = Color.White;
                headerCell1.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell1);

                TableCell headerCell2 = new TableCell();
                headerCell2.Text = "पूर्ण";
                headerCell2.HorizontalAlign = HorizontalAlign.Center;
                headerCell2.ForeColor = Color.White;
                headerCell2.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell2);

                TableCell headerCell3 = new TableCell();
                headerCell3.Text = "निविदा स्तर";
                headerCell3.HorizontalAlign = HorizontalAlign.Center;
                headerCell3.ForeColor = Color.White;
                headerCell3.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell3);

                TableCell headerCell4 = new TableCell();
                headerCell4.Text = "अं स्तर";
                headerCell4.HorizontalAlign = HorizontalAlign.Center;
                headerCell4.ForeColor = Color.White;
                headerCell4.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell4);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "शेरा";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);


                GridView1.Controls[0].Controls.AddAt(0, headerRow2);
                GridView1.Controls[0].Controls.AddAt(0, headerRow1);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        protected void ReportTypebtn_Click(object sender, EventArgs e)
        {
            Btnkam = ddlReportType.Text == "संपूर्ण" ? "संपूर्ण" : ddlReportType.Text;
            OrderBy = "संपूर्ण";
            whereColumn = "संपूर्ण";
            dataload();
            ListMenu.Style.Add("display", "none");

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            dataload();
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
        public void Upvibhag()
        {
            ddlUpvibhag.Items.Clear();
            ddlUpvibhag.Items.Add("निवडा");
            SqlDataAdapter sda;
            if (ddlReportType.Text == "संपूर्ण")
            {
                sda = new SqlDataAdapter("select Upvibhag FROM BudgetMasterMLA  Group By Upvibhag ", con);
            }
            else
            {
                sda = new SqlDataAdapter("select a.Upvibhag FROM BudgetMasterMLA as a join MLAProvision as b on a.Workid=b.Workid where a.AmdaracheName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Upvibhag ", con);
            }

            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlUpvibhag.Items.Add(dr["Upvibhag"].ToString());
            }
            //ddlUpvibhag.Items.Add("संपूर्ण");
        }
        public void Shakhabhiyanta()//Not Shakhaabhiyanta it is a UpAbhiyanta
        {
            ddlshakhaabhiyanta.Items.Clear();
            ddlshakhaabhiyanta.Items.Add("निवडा");
            SqlDataAdapter sda;
            if (ddlReportType.Text == "संपूर्ण")
            {
                sda = new SqlDataAdapter("select UpabhyantaName FROM BudgetMasterMLA  Group By UpabhyantaName ", con);
            }
            else
            {
                sda = new SqlDataAdapter("select a.UpabhyantaName FROM BudgetMasterMLA as a join MLAProvision as b on a.Workid=b.Workid where a.AmdaracheName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By UpabhyantaName ", con);
            }

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
            SqlDataAdapter sda;
            if (ddlReportType.Text == "संपूर्ण")
            {
                sda = new SqlDataAdapter("select  WorkId FROM BudgetMasterMLA ", con);
            }
            else
            {
                sda = new SqlDataAdapter("select a. WorkId FROM BudgetMasterMLA as a join MLAProvision as b on a.Workid=b.Workid where a.AmdaracheName=N'" + ddlReportType.SelectedItem.Text + "'and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'", con);
            }

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
            SqlDataAdapter sda = new SqlDataAdapter("select a. ThekedaarName FROM BudgetMasterMLA as a join MLAProvision as b on a.Workid=b.Workid where a.AmdaracheName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By ThekedaarName ", con);

            //SqlDataAdapter sda = new SqlDataAdapter("select ThekedaarName from BudgetMasterMLA where AmdaracheName=N'" + ddlReportType.SelectedItem.Text + "' Group By ThekedaarName", con);
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
            SqlDataAdapter sda;
            if (ddlReportType.Text == "संपूर्ण")
            {
                sda = new SqlDataAdapter("select Sadyasthiti FROM BudgetMasterMLA  Group By Sadyasthiti ", con);
            }
            else
            {
                sda = new SqlDataAdapter("select a. Sadyasthiti FROM BudgetMasterMLA as a join MLAProvision as b on a.Workid=b.Workid where a.AmdaracheName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Sadyasthiti ", con);
            }

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
            Shakhabhiyanta();//UpAbhiyanta
            WorkId();
            Tekedar();
            Sadyasthithi();

        }
        protected void btnUpvibhag_Click(object sender, EventArgs e)
        {

            whereColumn = "a.[Upvibhag]=N";
            WhereColumnValue = ddlUpvibhag.Text;
            dataload();
            //UpvibhagData();
            ListMenu.Style.Add("display", "none");
        }
        protected void btnShakhaAbhiyanta_Click(object sender, EventArgs e)
        {
            whereColumn = "a.[UpabhyantaName]=N";
            WhereColumnValue = ddlshakhaabhiyanta.Text;
            dataload();
            //ShakhaAbhiyantaData();
            ListMenu.Style.Add("display", "none");
        }
        protected void btnWorkId_Click(object sender, EventArgs e)
        {
            whereColumn = "a.[WorkId]=N";
            WhereColumnValue = ddlworkId.Text;
            dataload();
            //workIdData();
            ListMenu.Style.Add("display", "none");
        }
        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            whereColumn = "a.[ThekedaarName]=N";
            WhereColumnValue = ddlthekedar.Text;
            dataload();
            //thekedarData();
            ListMenu.Style.Add("display", "none");
        }
        protected void btnkamachisadyasthiti_Click(object sender, EventArgs e)
        {
            whereColumn = "a.[Sadyasthiti]=N";
            WhereColumnValue = ddlsadyasthiti.Text;
            dataload();
            //sadyasthitiData();
            ListMenu.Style.Add("display", "none");
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
    }
}