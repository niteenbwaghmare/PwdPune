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
    public partial class Report_LekhasirshDepositeContributionFund : System.Web.UI.Page
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
            SqlDataAdapter sda = new SqlDataAdapter("  select LekhaShirsh from SettingLekhaShirsh where Type='Diposit'", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterDepositFund", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from DepositFundProvision Group By Arthsankalpiyyear", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlArthYear.Items.Add(dr["Arthsankalpiyyear"].ToString());
            }
        }

        public void lekha()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select lekhaShirsh from BudgetMasterDepositFund where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "'", con);
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
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY [lekhashirsh] ORDER BY [SubType]) as 'SrNo',a.[SubType] as subtype ,a.[KamacheName] as kamachenaav,a.[PrashaskiyAmt] as PrashaskiyAmt ,a.[PrashaskiyKramank]+' '+convert(nvarchar(max),a.[PrashaskiyDate])as prashaskiy,a.[TrantrikAmt] as TrantrikAmt,a.[TrantrikKrmank]+' '+convert(nvarchar(max), a.[TrantrikDate]) as tantrik,a.[ThekedaarName] as thename,convert(nvarchar(max),a.[NividaKrmank]) +' '+convert(nvarchar(max),a.[NividaDate])as karyarambhadesh,a.[NividaAmt] as nivamt,a.[kamachiMudat] +' month' as kammudat,b.[MarchEndingExpn] as marchexpn,b.[ShilakThev] as ShilakThev,b.[VitariThev] as Vitaritthev,b.[Magilkharch] as magch,b.[AikunKharch] as aknkharch,CAST(CASE WHEN MudatVadhiDate = ' ' or MudatVadhiDate = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as mudatvadh,[Vidyutprama] as vidprama,b.[Vidyutvitarit] as vidtarit,b.[Dviguni] as dvini, a.[Pahanikramank] as pankr,convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as shera,convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) +convert(nvarchar(max),a.[ShakhaAbhyantaName]) +' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as abhiyanta from BudgetMasterDepositFund as a join DepositFundProvision as b on a.WorkID=b.WorkID where b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";
            if (Btnkam == "संपूर्ण")
            {
                if (ddlReportType.SelectedItem.Text == "संपूर्ण" || ddlkamacheYear.Text == "संपूर्ण")
                {
                    string[] cols = new string[2];
                    cols[0] = "subtype";
                    cols[1] = "subtype";
                    helper.RegisterGroup("subtype", true, true);

                    helper.RegisterSummary("vidtarit", SummaryOperation.Sum, "subtype");
                    helper.RegisterSummary("vidtarit", SummaryOperation.Sum);
                    helper.RegisterSummary("vidprama", SummaryOperation.Sum, "subtype");
                    helper.RegisterSummary("vidprama", SummaryOperation.Sum);
                    helper.RegisterSummary("aknkharch", SummaryOperation.Sum, "subtype");
                    helper.RegisterSummary("aknkharch", SummaryOperation.Sum);
                    helper.RegisterSummary("magch", SummaryOperation.Sum, "subtype");
                    helper.RegisterSummary("magch", SummaryOperation.Sum);
                    helper.RegisterSummary("Vitaritthev", SummaryOperation.Sum, "subtype");
                    helper.RegisterSummary("Vitaritthev", SummaryOperation.Sum);
                    helper.RegisterSummary("ShilakThev", SummaryOperation.Sum, "subtype");
                    helper.RegisterSummary("ShilakThev", SummaryOperation.Sum);
                    helper.RegisterSummary("marchexpn", SummaryOperation.Sum, "subtype");
                    helper.RegisterSummary("marchexpn", SummaryOperation.Sum);
                    helper.GroupSummary += new GroupEvent(helper_Bug);
                    helper.ApplyGroupSort();
                    dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query + " order by " + OrderBy, "BudgetMasterDepositFund");
                    foreach (DataRow dr in dt.Rows)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                    }

                 }

            }
            else
            {
                string[] cols = new string[2];
                cols[0] = "subtype";
                cols[1] = "subtype";
                helper.RegisterGroup("subtype", true, true);
                helper.RegisterSummary("vidtarit", SummaryOperation.Sum);
                helper.RegisterSummary("vidprama", SummaryOperation.Sum);
                helper.RegisterSummary("aknkharch", SummaryOperation.Sum);
                helper.RegisterSummary("magch", SummaryOperation.Sum);
                helper.RegisterSummary("Vitaritthev", SummaryOperation.Sum);
                helper.RegisterSummary("ShilakThev", SummaryOperation.Sum);
                helper.RegisterSummary("marchexpn", SummaryOperation.Sum);

                helper.GroupSummary += new GroupEvent(helper_Bug);
                helper.ApplyGroupSort();
                dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterDepositFund");
                foreach (DataRow dr in dt.Rows)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,false); </script>", false);

            Session["LekhasirshDepositeContributionFundRpt"] = GridView1;                 
       
          
        }
       
        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            Btnkam = ddlkamacheYear.Text == "संपूर्ण" ? "संपूर्ण" : ddlkamacheYear.Text;
            OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
            whereColumn = "संपूर्ण";
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            pri = "print";
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DepositContributionFund_MPR_Report.xls"));
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
                OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
                whereColumn = "संपूर्ण";
            }
            else if (ddlReportType.SelectedItem.Text != "निवडा")
            {
                Btnkam = ddlReportType.Text == "संपूर्ण" ? "संपूर्ण" : ddlReportType.Text;
                OrderBy = "a.[Arthsankalpiyyear]";
                whereColumn = "संपूर्ण";
            }
            else if (ddlUpvibhag.SelectedItem.Text != "निवडा")
            {
                OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
                whereColumn = "a.[Upvibhag]=N";
                WhereColumnValue = ddlUpvibhag.Text;
            }
            else if (ddlshakhaabhiyanta.SelectedItem.Text != "निवडा")
            {
                OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
                whereColumn = "a.[UpabhyantaName]=N";
                WhereColumnValue = ddlshakhaabhiyanta.Text;
            }
            else if (ddlworkId.SelectedItem.Text != "निवडा")
            {
                OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
                whereColumn = "a.[WorkId]=N";
                WhereColumnValue = ddlworkId.Text;
            }
            else if (ddlthekedar.SelectedItem.Text != "निवडा")
            {
                OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
                whereColumn = "a.[ThekedaarName]=N";
                WhereColumnValue = ddlthekedar.Text;
            }
            else if (ddlsadyasthiti.SelectedItem.Text != "निवडा")
            {
                OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
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
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();

                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "अ.क्र";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.RowSpan = 2;
                //Cell_Header.Text = "विभाग";
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.ForeColor = Color.White;
                //Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                //headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "कामाचे नाव";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "प्रशासकीय मान्यता रक्कम (रु.लाखात)";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "प्रशासकीय मान्यता क्रमांक/दिनांक";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "तांत्रिक मान्यता रक्कम ";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "तांत्रिक मान्यता क्रमांक/दिनांक";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "ठेकेदाराचे नाव";
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
                Cell_Header.Text = "निविदा रक्कम % कमी/ जास्त";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "बांधकाम कालावधी";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "मार्च " + ddlkamacheYear.SelectedValue.Substring(0, 4) + " अखेर खर्च";
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " मधील शिल्लक ठेव";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " वितरीत ठेव";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                //Cell_Header = new TableCell();
                //Cell_Header.RowSpan = 2;
                //Cell_Header.Text = "Expenditure from 4/" + ddlArthsankalpiyYear.SelectedValue.Substring(0, 4) + " to 8/" + ddlArthsankalpiyYear.SelectedValue.Substring(0, 4);
                //Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                //Cell_Header.ForeColor = Color.White;
                //Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                //headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "सन" + ddlkamacheYear.SelectedValue.Substring(0, 4) + "मधील माहे 11/" + ddlkamacheYear.SelectedValue.Substring(0, 4) + " अखेर पर्यंत खर्च ";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "एकूण कामावरील खर्च";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "मुदत वाढ बाबत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.ColumnSpan = 2;
                Cell_Header.Text = "विद्युतीकरणावरील खर्च";
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                TableCell headerCell1 = new TableCell();
                TableCell headerCell2 = new TableCell();

                headerCell1.Text = "प्रमा";
                headerCell2.Text = "वितरित";
                headerCell1.HorizontalAlign = HorizontalAlign.Center;
                headerCell1.ForeColor = Color.White;
                headerCell1.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerCell2.HorizontalAlign = HorizontalAlign.Center;
                headerCell2.ForeColor = Color.White;
                headerCell2.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell1);
                headerRow2.Cells.Add(headerCell2);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "दवगुनी ज्ञापने";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "हस्तांतरण दिनांक/उपयोगिता प्रमाणपत्र बाबत";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "सद्यस्थिती/शेरा";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "उपअभियंता नाव/शाखा अभियंता नाव आणि मोबाईल";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                GridView1.Controls[0].Controls.AddAt(0, headerRow2);
                GridView1.Controls[0].Controls.AddAt(0, headerRow1);
            }
        }
        int tempcounter = 0;

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[2].Visible = true;

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    tempcounter = tempcounter + 1;
            //    if (tempcounter == 10)
            //    {
            //        e.Row.Attributes.Add("style", "page-break-after: always;");
            //        tempcounter = 0;
            //    }
            //}
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "DepositContributionFund_MPR_Report.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "DepositContributionFund_MPR_Report.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }

            Response.Redirect("SendMail.aspx");
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


        protected void ReportTypebtn_Click(object sender, EventArgs e)
        {
            Btnkam = ddlReportType.Text == "संपूर्ण" ? "संपूर्ण" : ddlReportType.Text;
            OrderBy = "a.[Arthsankalpiyyear]";
            whereColumn = "संपूर्ण";
            dataload();
            ListMenu.Style.Add("display", "none");

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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select Upvibhag FROM BudgetMasterDepositFund  Group By Upvibhag" : "select a.Upvibhag FROM BudgetMasterDepositFund as a join DepositFundProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Upvibhag";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);           
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  UpabhyantaName FROM BudgetMasterDepositFund  Group By UpabhyantaName" : "select a.UpabhyantaName FROM BudgetMasterDepositFund as a join DepositFundProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By UpabhyantaName";
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select WorkId FROM BudgetMasterDepositFund" : "select a.WorkId FROM BudgetMasterDepositFund as a join DepositFundProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select ThekedaarName FROM BudgetMasterDepositFund Group By ThekedaarName" : "select a.ThekedaarName FROM BudgetMasterDepositFund as a join DepositFundProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By ThekedaarName";
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  Sadyasthiti FROM BudgetMasterDepositFund  Group By Sadyasthiti" : "select a.Sadyasthiti FROM BudgetMasterDepositFund as a join DepositFundProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By Sadyasthiti";
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
            OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";            
            whereColumn = "a.[Upvibhag]=N";
            WhereColumnValue = ddlUpvibhag.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnShakhaAbhiyanta_Click(object sender, EventArgs e)
        {
            OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
            whereColumn = "a.[UpabhyantaName]=N";
            WhereColumnValue = ddlshakhaabhiyanta.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnWorkId_Click(object sender, EventArgs e)
        {
            OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
            whereColumn = "a.[WorkId]=N";
            WhereColumnValue = ddlworkId.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
            whereColumn = "a.[ThekedaarName]=N";
            WhereColumnValue = ddlthekedar.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnkamachisadyasthiti_Click(object sender, EventArgs e)
        {
            OrderBy = "a.[SubType]desc, a.[lekhashirsh]asc";
            whereColumn = "a.[Sadyasthiti]=N";
            WhereColumnValue = ddlsadyasthiti.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }

       
    }
}