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
    public partial class Report_LekhasirshMP : System.Web.UI.Page
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
                Khasdar();
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
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "MP_MPR_Report.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "MP_MPR_Report.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }

            Response.Redirect("SendMail.aspx");
        }
        public void Khasdar()
        {
            ddlReportType.Items.Clear();
            ddlReportType.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT KhasdaracheName from BudgetMasterMP", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterMP", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from MPProvision Group By Arthsankalpiyyear", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlArthYear.Items.Add(dr["Arthsankalpiyyear"].ToString());
            }
        }

        public void nullgridview()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        public void dataload()
        {
            lekha();
            if (pri != "print")
                nullgridview();
            GridViewHelper helper = new GridViewHelper(this.GridView1);
            DataTable dt = new DataTable();
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[KhasdaracheName] ORDER BY a.[PageNo])as 'अ.क्र.' ,a.[PageNo] as 'प्रकार' ,a.[Taluka] as 'तालुका' ,a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब.क्र./प्रथम समाविष्ठ झाल्याचे वर्ष' ,a.[Type] as 'जिल्हा / योजना' ,a.[KhasdaracheName] as 'खासदाराचे नाव' ,a.[KamacheName] as 'कामाचे नाव' ,convert(nvarchar(max), a.[PrashaskiyKramank])+'/'+convert(nvarchar(max),a.[PrashaskiyDate]) as 'प्र.मा.क्र/दिनांक' ,cast(a.[PrashaskiyAmt] as decimal(18,2)) as 'प्रमाकिंमतलक्ष' ,cast(a.[TrantrikAmt] as decimal(18,2)) as 'तामाकिंमतलक्ष',convert(nvarchar(max),a.[TrantrikKrmank])+'/'+convert(nvarchar(max),a.[TrantrikDate]) as 'ता.मा.क्र/दिनांक',cast(a.[NividaAmt] as decimal(18,2))as 'निविदा किंमत' ,a.[NividaKrmank] as 'कार्यारंभ आदेश' ,b.[ManjurAmt] as 'ManjurAmt' ,b.[MarchEndingExpn] as 'MarchEndingExpn',b.[UrvaritAmt] as 'UrvaritAmt', b.[Chalukharch] as 'Chalukharch',b.[VarshbharatilKharch] as 'VarshbharatilKharch',b.[Magni] as 'मागणी रु.लक्ष',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(18,2)) as 'पूर्ण',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(18,2)) as 'प्रगतीत',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(18,2)) as 'निविदा स्तर',a.[Shera] as 'शेरा' from BudgetMasterMP as a join MPProvision as b on a.WorkId=b.WorkId where b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";

            if (Btnkam == "संपूर्ण")
            {
                if (ddlReportType.SelectedItem.Text == "संपूर्ण" || ddlkamacheYear.Text == "संपूर्ण")
                {
                    string[] cols = new string[2];
                    cols[0] = "खासदाराचे नाव";
                    cols[1] = "प्रकार";
                    helper.RegisterGroup(cols, true, true);
                    helper.RegisterSummary("प्रमाकिंमतलक्ष", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("प्रमाकिंमतलक्ष", SummaryOperation.Sum);
                    helper.RegisterSummary("तामाकिंमतलक्ष", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("तामाकिंमतलक्ष", SummaryOperation.Sum);
                    helper.RegisterSummary("निविदा किंमत", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("निविदा किंमत", SummaryOperation.Sum);
                    helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum);
                    helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum);
                    helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum);
                    helper.RegisterSummary("Chalukharch", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("Chalukharch", SummaryOperation.Sum);
                    helper.RegisterSummary("VarshbharatilKharch", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("VarshbharatilKharch", SummaryOperation.Sum);
                    helper.RegisterSummary("पूर्ण", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("पूर्ण", SummaryOperation.Sum);
                    helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum);
                    helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                    helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum);

                    helper.GroupSummary += new GroupEvent(helper_Bug);
                    helper.ApplyGroupSort();

                    dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterMP");

                }
            }
            else
            {
                string[] cols = new string[2];
                cols[0] = "खासदाराचे नाव";
                cols[1] = "प्रकार";
                helper.RegisterGroup(cols, true, true);
                helper.RegisterSummary("प्रमाकिंमतलक्ष", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("प्रमाकिंमतलक्ष", SummaryOperation.Sum);
                helper.RegisterSummary("तामाकिंमतलक्ष", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("तामाकिंमतलक्ष", SummaryOperation.Sum);
                helper.RegisterSummary("निविदा किंमत", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("निविदा किंमत", SummaryOperation.Sum);
                helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum);
                helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum);
                helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum);
                helper.RegisterSummary("Chalukharch", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("Chalukharch", SummaryOperation.Sum);
                helper.RegisterSummary("VarshbharatilKharch", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("VarshbharatilKharch", SummaryOperation.Sum);
                helper.RegisterSummary("पूर्ण", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("पूर्ण", SummaryOperation.Sum);
                helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum);
                helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum, "खासदाराचे नाव+प्रकार");
                helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum);
                helper.GroupSummary += new GroupEvent(helper_Bug);
                helper.ApplyGroupSort();
                dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterMP");
            }
            foreach (DataRow dr in dt.Rows)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            Session["Report_LekhasirshMP"] = GridView1;

            
        }
       
        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            Btnkam = ddlkamacheYear.Text == "संपूर्ण" ? "संपूर्ण" : ddlkamacheYear.Text;
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "MP_MPR_Report.xls"));
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
                Cell_Header.Text = "अ.क्र.";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "तालुका";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "अर्थसंकल्पीय बाब.क्र./प्रथम समाविष्ठ झाल्याचे वर्ष";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "जिल्हा / योजना";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "कामाचे नाव";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "प्र.मा.क्र/दिनांक";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "प्र.मा.किंमत रु.लक्ष";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "ता.मा.किंमत लक्ष";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "ता.मा.क्र/दिनांक";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "निविदा किंमत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "कार्यारंभ आदेश";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " वर्ष मधील उपलब्ध अनुदान लक्ष";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " वर्ष मधील चालु महिन्या अखेर उपलब्ध अनुदान";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "एकुण उपलब्ध अनुदान";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " वर्ष मधील चालू महिन्या अखेर खर्च लक्ष";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                Cell_Header.ColumnSpan = 1;
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "एकुण खर्च";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "मागणी रु.लक्ष";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);
               
                Cell_Header = new TableCell();
                Cell_Header.Text = "कामाची सद्यस्थिती";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                Cell_Header.ColumnSpan = 3;
                headerRow1.Cells.Add(Cell_Header);

                TableCell headerCell1 = new TableCell();
                headerCell1.Text = "पूर्ण";
                headerCell1.HorizontalAlign = HorizontalAlign.Center;
                headerCell1.ForeColor = Color.White;
                headerCell1.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell1);

                TableCell headerCell2 = new TableCell();
                headerCell2.Text = "प्रगतीत";
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
        public void lekha()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select lekhaShirsh from BudgetMasterMP where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lblshirsh.Text = dr["lekhaShirsh"].ToString();
            }
        }
        public void Upvibhag()
        {
           
            
            ddlUpvibhag.Items.Clear();
            ddlUpvibhag.Items.Add("निवडा");
           
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select Upvibhag FROM BudgetMasterMP  Group By Upvibhag" : "select a.Upvibhag FROM BudgetMasterMP as a join MPProvision as b on a.Workid=b.Workid where a.KhasdaracheName=N'" + ddlReportType.SelectedItem.Text + "'  and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Upvibhag";

            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);            
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlUpvibhag.Items.Add(dr["Upvibhag"].ToString());
            }
           //ddlUpvibhag.Items.Add("संपूर्ण");
        }
        public void Shakhabhiyanta()//This Method for UpAbhiyanta not For ShakhaAbhiyanta
        {
            ddlshakhaabhiyanta.Items.Clear();
            ddlshakhaabhiyanta.Items.Add("निवडा");

            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  UpabhyantaName FROM BudgetMasterMP  Group By UpabhyantaName" : "select a.UpabhyantaName FROM BudgetMasterMP as a join MPProvision as b on a.Workid=b.Workid where a.KhasdaracheName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By UpabhyantaName";


            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);           
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select WorkId FROM BudgetMasterMP" : "select a.WorkId FROM BudgetMasterMP as a join MPProvision as b on a.Workid=b.Workid where a.KhasdaracheName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";

            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);           
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

            ddlist = ddlReportType.Text == "संपूर्ण" ? "select ThekedaarName FROM BudgetMasterMP Group By ThekedaarName" : "select a.ThekedaarName FROM BudgetMasterMP as a join MPProvision as b on a.Workid=b.Workid where a.KhasdaracheName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By ThekedaarName";

            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
         
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  Sadyasthiti FROM BudgetMasterMP  Group By Sadyasthiti" : "select a.Sadyasthiti FROM BudgetMasterMP as a join MPProvision as b on a.Workid=b.Workid where a.KhasdaracheName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Sadyasthiti";

            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);          
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
           // UpvibhagData();
            dataload();
            ListMenu.Style.Add("display", "none");
        }
        protected void btnShakhaAbhiyanta_Click(object sender, EventArgs e)
        {
            whereColumn = "a.[UpabhyantaName]=N";
            WhereColumnValue = ddlshakhaabhiyanta.Text;
            dataload();
            //shakhaabhiyantaData();
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
           // SadyasthitiData();
            ListMenu.Style.Add("display", "none");
        }

        private void BindWhereColumnNameValue()
        {
            if (ddlkamacheYear.SelectedItem.Text != "निवडा")
            {
                Btnkam = ddlkamacheYear.Text == "संपूर्ण" ? "संपूर्ण" : ddlkamacheYear.Text;        
                whereColumn = "संपूर्ण";
            }
            else if (ddlReportType.SelectedItem.Text != "निवडा")
            {
                Btnkam = ddlReportType.Text == "संपूर्ण" ? "संपूर्ण" : ddlReportType.Text;
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