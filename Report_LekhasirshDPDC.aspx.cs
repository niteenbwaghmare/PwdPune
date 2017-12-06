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
    public partial class Report_LekhasirshDPDC : System.Web.UI.Page
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
            SqlDataAdapter sda = new SqlDataAdapter("select LekhaShirsh from SettingLekhaShirsh where Type='DPDC'", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterDPDC", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from DPDCProvision Group By Arthsankalpiyyear", con);
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
            if (OrderBy != string.Empty)
            {
                OrderBy = "a.[Taluka]asc";
            }
            else
            {
                OrderBy = "[SubType]";
            }
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[Taluka] ORDER BY a.[WorkId]) as 'अ.क्र',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[Taluka] as 'तालुका',a.[LekhaShirsh] as 'योजनेचे नाव',b.[ComputerCRC] as 'सीआरसी (संगणक) संकेतांक', b.[ObjectCode] as 'उद्यीष्ट संकेतांक(ऑब्जेक्ट कोड)',a.[KamacheName] as 'योजनेचे / कामाचे नांव',  b.[ManjurAmt] as 'एकूण अंदाजित किंमत',convert(nvarchar(max),a.[NividaAmt])+' '+ convert(nvarchar(max),b.[MudatVadhiDate]) as 'सुधारित अंदाजित किंमतीचा दिनांक', b.[MarchEndingExpn] as 'MarchEndingExpn',b.[ManjurAmt] as 'ManjurAmt',b.[UrvaritAmt] as 'UrvaritAmt', b.[Tartud] as 'Tartud',a.[KamPurnDate] as 'काम पूर्ण होण्याचा अपेक्षित दिनांक', b.[Tartud]as 'Tartud',b.[AkunAnudan] as 'AkunAnudan', b.[Magilkharch] as 'Magilkharch',b.[Magni] as 'Magni',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,2)) as 'पुर्ण', CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,2)) as 'प्रगतीत', CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,2)) as 'निविदा स्तर',a.[Shera] as 'शेरा' FROM BudgetMasterDPDC as a join DPDCProvision as b on a.Workid=b.Workid where  b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' ";

            if (Btnkam == "संपूर्ण")
            {
                if (ddlReportType.SelectedItem.Text == "संपूर्ण" || ddlkamacheYear.SelectedItem.Text == "संपूर्ण")
                {
                    string[] cols = new string[2];
                    cols[0] = "अर्थसंकल्पीय वर्ष";
                    cols[1] = "तालुका";
                    helper.RegisterGroup(cols, true, true);

                    helper.RegisterSummary("एकूण अंदाजित किंमत", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("एकूण अंदाजित किंमत", SummaryOperation.Sum);
                    helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum);
                    helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum);
                    helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum);
                    helper.RegisterSummary("Tartud", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("Tartud", SummaryOperation.Sum);
                    helper.RegisterSummary("Tartud", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("Tartud", SummaryOperation.Sum);
                    helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum);
                    helper.RegisterSummary("Magilkharch", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("Magilkharch", SummaryOperation.Sum);
                    helper.RegisterSummary("Magni", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("Magni", SummaryOperation.Sum);
                    helper.RegisterSummary("पुर्ण", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("पुर्ण", SummaryOperation.Sum);
                    helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum);
                    helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                    helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum);
                    helper.GroupSummary += new GroupEvent(helper_Bug);
                    helper.ApplyGroupSort();
                    //ObjMPRGridBind.MPRBindGrid() Method Of MasterReportGridBind Class
                    dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterDPDC");
                }
            }
            else
            {
                string[] cols = new string[2];
                cols[0] = "अर्थसंकल्पीय वर्ष";
                cols[1] = "तालुका";
                helper.RegisterGroup(cols, true, true);

                helper.RegisterSummary("एकूण अंदाजित किंमत", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("एकूण अंदाजित किंमत", SummaryOperation.Sum);
                helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("MarchEndingExpn", SummaryOperation.Sum);
                helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("ManjurAmt", SummaryOperation.Sum);
                helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("UrvaritAmt", SummaryOperation.Sum);
                helper.RegisterSummary("Tartud", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("Tartud", SummaryOperation.Sum);
                helper.RegisterSummary("Tartud", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("Tartud", SummaryOperation.Sum);
                helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("AkunAnudan", SummaryOperation.Sum);
                helper.RegisterSummary("Magilkharch", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("Magilkharch", SummaryOperation.Sum);
                helper.RegisterSummary("Magni", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("Magni", SummaryOperation.Sum);
                helper.RegisterSummary("पुर्ण", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("पुर्ण", SummaryOperation.Sum);
                helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("प्रगतीत", SummaryOperation.Sum);
                helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum, "अर्थसंकल्पीय वर्ष+तालुका");
                helper.RegisterSummary("निविदा स्तर", SummaryOperation.Sum);
                helper.GroupSummary += new GroupEvent(helper_Bug);
                helper.ApplyGroupSort();
                //ObjMPRGridBind.MPRBindGrid() Method Of MasterReportGridBind Class
                dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterDPDC");
            }
            foreach (DataRow dr in dt.Rows)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 101 , 100 ,false); </script>", false);

            Session["LekhasirshDPDCRpt"] = GridView1;
        }
        

        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            //Kamachedataload();
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DPDC_MPR_Report.xls"));
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
                Cell_Header.Text = "अ.क्र";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "योजनेचे नाव";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "सीआरसी (संगणक) संकेतांक";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "उद्यीष्ट संकेतांक(ऑब्जेक्ट कोड)";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "योजनेचे / कामाचे नांव";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "एकूण अंदाजित किंमत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "सुधारित अंदाजित किंमतीचा दिनांक";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "मार्च " + ddlkamacheYear.SelectedItem.Text + " अखेर पर्यंतचा एकूण खर्च";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "सन " + ddlkamacheYear.SelectedItem.Text + " मधील अपेक्षित खर्च";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " मधील उर्वरित किंमत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " करीता प्रस्तावित तरतूद";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "काम पूर्ण होण्याचा अपेक्षित दिनांक";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "काम निहाय तरतूद सन " + ddlkamacheYear.SelectedItem.Text;
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "वितरीत तरतूद सन " + ddlkamacheYear.SelectedItem.Text;
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "खर्च सन " + ddlkamacheYear.SelectedItem.Text + " 06/16 अखेर";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "मागणी " + ddlkamacheYear.SelectedItem.Text;
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "पुर्ण";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "प्रगतीत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                HeaderRow.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.Text = "निविदा स्तर";
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
                e.Row.Cells[5].Visible = false;
        }
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "DPDC_MPR_Report.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "DPDC_MPR_Report.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }

            Response.Redirect("SendMail.aspx");
        }

        protected void ReportTypebtn_Click(object sender, EventArgs e)
        {
            Btnkam = ddlReportType.Text == "संपूर्ण" ? "संपूर्ण" : ddlReportType.Text;
            OrderBy = "संपूर्ण";
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

        protected void BtnExcel_Click1(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DPDC_MPR_Report.xls"));
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
            SqlDataAdapter sda = new SqlDataAdapter("select lekhaShirsh from BudgetMasterDPDC where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' ", con);
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
            SqlDataAdapter sda;
            if (ddlReportType.Text == "संपूर्ण")
            {
                sda = new SqlDataAdapter("select  Upvibhag FROM BudgetMasterDPDC Group By Upvibhag", con);
            }

            else
            {
                sda = new SqlDataAdapter("select a.Upvibhag FROM BudgetMasterDPDC as a join DPDCProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "'  and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'  Group By Upvibhag", con);
            }
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
            SqlDataAdapter sda;
            if (ddlReportType.Text == "संपूर्ण")
            {
                sda = new SqlDataAdapter("select  UpabhyantaName FROM BudgetMasterDPDC Group By UpabhyantaName", con);
            }
            else
            {
                sda = new SqlDataAdapter("select a.UpabhyantaName FROM BudgetMasterDPDC as a join DPDCProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "'  and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'  Group By UpabhyantaName", con);
            }
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
            SqlDataAdapter sda;
            if (ddlReportType.Text == "संपूर्ण")
            {
                sda = new SqlDataAdapter("select WorkId FROM BudgetMasterDPDC ", con);
            }
            else
            {
                sda = new SqlDataAdapter("select a.WorkId FROM BudgetMasterDPDC as a join DPDCProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "'  and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'", con);
            }
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
            SqlDataAdapter sda;
            if (ddlReportType.Text == "संपूर्ण")
            {
                sda = new SqlDataAdapter("select  ThekedaarName FROM BudgetMasterDPDC Group By ThekedaarName", con);
            }
            else
            {
                sda = new SqlDataAdapter("select a.ThekedaarName FROM BudgetMasterDPDC as a join DPDCProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "'  and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'  Group By ThekedaarName", con);
            }
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
                sda = new SqlDataAdapter("select Sadyasthiti FROM BudgetMasterDPDC Group By Sadyasthiti", con);
            }

            else
            {
                sda = new SqlDataAdapter("select a. Sadyasthiti FROM BudgetMasterDPDC as a join DPDCProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "'  and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'  Group By Sadyasthiti", con);
            }
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlsadyasthiti.Items.Add(dr["Sadyasthiti"].ToString());
            }
          //  ddlsadyasthiti.Items.Add("संपूर्ण");

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
           // UpvibhagData();
            whereColumn = "a.[Upvibhag]=N";
            WhereColumnValue = ddlUpvibhag.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnShakhaAbhiyanta_Click(object sender, EventArgs e)
        {
            //shakhaAbhiyantaData();
            whereColumn = "a.[UpabhyantaName]=N";
            WhereColumnValue = ddlshakhaabhiyanta.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnWorkId_Click(object sender, EventArgs e)
        {
            //WorkData();
            whereColumn = "a.[WorkId]=N";
            WhereColumnValue = ddlworkId.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            //TekedarData();
            whereColumn = "a.[ThekedaarName]=N";
            WhereColumnValue = ddlthekedar.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnkamachisadyasthiti_Click(object sender, EventArgs e)
        {
           //SadyasthitiData();
            whereColumn = "a.[Sadyasthiti]=N";
            WhereColumnValue = ddlsadyasthiti.Text;
            dataload();
           ListMenu.Style.Add("display", "none");

        }
               
    }
}