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
    public partial class Report_LekhasirshGAT_B : System.Web.UI.Page
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
            SqlDataAdapter sda = new SqlDataAdapter("select LekhaShirsh from SettingLekhaShirsh where Type='3054_Gat_FBC'", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterGAT_FBC", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from GAT_FBCProvision Group By Arthsankalpiyyear", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlArthYear.Items.Add(dr["Arthsankalpiyyear"].ToString());
            }
        }
        public void lekha()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select lekhaShirsh from [BudgetMasterGAT_FBC] where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "'", con);
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
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY [lekhashirsh] ORDER BY [SubType]) as 'SrNo',a.[LekhaShirsh] as 'lekhashirsh',a.[LekhaShirshName] as 'LekhaShirshName',a.[KamacheName] as kamachenav,a.[GRoadKramank] as RastaKr,a.[GlengthStarted] as Pasun,a.[GlengthUpto] as Pryant,a.[GlengthTotal] as Ekun,a.[GRoadPrushthbhag] as Prustbhag,a.[GRoll] as Pikroll,a.[GNewKhadikaran] as navinkhdikarn,a.[GBM_Carpet] as BMCarpet,a.[G20_MM] as mmcarpetsah,a.[GSurface]as serface,a.[GRundikaran] as rundikarn,a.[GBridge_Morya]as Pull,a.[GAnya] as anya,a.[GRepairExpn] as DurustichaKhrch,b.[KamachiKimat]as kamchikinmat,a.[GJobKramank]as jobkr,a.Shera as shera  from [BudgetMasterGAT_FBC] as a join [GAT_FBCProvision] as b on a.WorkID=b.WorkID where a.[Type]=N'गट बी' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";
            
            if (Btnkam == "संपूर्ण")
            {
                if (ddlReportType.SelectedItem.Text == "संपूर्ण" || ddlkamacheYear.Text == "संपूर्ण")
                {
                    string[] cols = new string[2];
                    cols[0] = "LekhaShirshName";
                    cols[1] = "lekhashirsh";
                    helper.RegisterGroup(cols, true, true);

                    helper.RegisterSummary("kamchikinmat", SummaryOperation.Sum, "LekhaShirshName+lekhashirsh");
                    helper.RegisterSummary("kamchikinmat", SummaryOperation.Sum);
                    helper.RegisterSummary("DurustichaKhrch", SummaryOperation.Sum, "LekhaShirshName+lekhashirsh");
                    helper.RegisterSummary("DurustichaKhrch", SummaryOperation.Sum);
                    helper.GroupSummary += new GroupEvent(helper_Bug);
                    helper.ApplyGroupSort();
                    dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterGAT_FBC");
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
                cols[0] = "lekhashirsh";
                cols[1] = "LekhaShirshName";
                helper.RegisterGroup(cols, true, true);

                helper.RegisterSummary("kamchikinmat", SummaryOperation.Sum);
                helper.RegisterSummary("DurustichaKhrch", SummaryOperation.Sum);                
                helper.GroupSummary += new GroupEvent(helper_Bug);
                helper.ApplyGroupSort();
                dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterGAT_FBC");
                foreach (DataRow dr in dt.Rows)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,false); </script>", false);

            Session["LekhasirshGAT_BRpt"] = GridView1;



        }

        protected void btnKamacheYear_Click(object sender, EventArgs e)
        {
            //kamchedataload();
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "GatB_MPR_Report.xls"));
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
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell Cell_Header = new TableCell();
                Cell_Header.RowSpan = 3;
                Cell_Header.Text = "अ.क्र";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 3;
                Cell_Header.Text = "कामाची सक्षिप्त नावे";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 3;
                Cell_Header.Text = "रस्ता संवर्ग व क्र";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.ColumnSpan = 3;
                Cell_Header.Text = "लांबी किमी.";
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                TableCell headerCell1 = new TableCell();
                TableCell headerCell2 = new TableCell();
                TableCell headerCell3 = new TableCell();

                headerCell1.Text = "पासुन";
                headerCell2.Text = "पर्यंत";
                headerCell3.Text = "एकूण";
                headerCell1.HorizontalAlign = HorizontalAlign.Center;
                headerCell1.RowSpan = 2;
                headerCell1.ForeColor = Color.White;
                headerCell1.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerCell2.HorizontalAlign = HorizontalAlign.Center;
                headerCell2.RowSpan = 2;
                headerCell2.ForeColor = Color.White;
                headerCell2.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerCell3.HorizontalAlign = HorizontalAlign.Center;
                headerCell3.RowSpan = 2;
                headerCell3.ForeColor = Color.White;
                headerCell3.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell1);
                headerRow2.Cells.Add(headerCell2);
                headerRow2.Cells.Add(headerCell3);


                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 3;
                Cell_Header.Text = "अस्तीत्वातील रस्त्याचा पृष्ठभाग खडीचा/ डांबरी";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.ColumnSpan = 8;
                Cell_Header.Text = "प्रस्तावित दुरुस्तीचा प्रकार";
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);


                TableCell headerCell4 = new TableCell();
                TableCell headerCell5 = new TableCell();
                TableCell headerCell6 = new TableCell();
                TableCell headerCell7 = new TableCell();
                TableCell headerCell8 = new TableCell();
                TableCell headerCell9 = new TableCell();

                headerCell4.Text = "खडीकरण";
                headerCell4.ColumnSpan = 2;
                headerCell4.HorizontalAlign = HorizontalAlign.Center;
                headerCell4.ForeColor = Color.White;
                headerCell4.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell4);

                TableCell headerCell10 = new TableCell();
                TableCell headerCell11 = new TableCell();

                headerCell10.Text = "पीक व रोल";
                headerCell11.Text = "नवीन खडी करण";
                headerCell10.HorizontalAlign = HorizontalAlign.Center;
                headerCell10.ForeColor = Color.White;
                headerCell10.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerCell11.HorizontalAlign = HorizontalAlign.Center;
                headerCell11.ForeColor = Color.White;
                headerCell11.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow3.Cells.Add(headerCell10);
                headerRow3.Cells.Add(headerCell11);

                headerCell5.Text = "बी.एम व कारपेट सिलकोट सह";
                headerCell5.HorizontalAlign = HorizontalAlign.Center;
                headerCell5.RowSpan = 2;
                headerCell5.ForeColor = Color.White;
                headerCell5.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell5);

                headerCell6.Text = "डांबरी नुतनीकरण";
                headerCell6.ColumnSpan = 2;
                headerCell6.HorizontalAlign = HorizontalAlign.Center;
                headerCell6.ForeColor = Color.White;
                headerCell6.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell6);

                TableCell headerCell12 = new TableCell();
                TableCell headerCell13 = new TableCell();

                headerCell12.Text = "20 मीमी कारपेटसिलकोट सह";
                headerCell13.Text = "सरफेस ड्रेसिंग";
                headerCell12.HorizontalAlign = HorizontalAlign.Center;
                headerCell12.ForeColor = Color.White;
                headerCell12.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerCell13.HorizontalAlign = HorizontalAlign.Center;
                headerCell13.ForeColor = Color.White;
                headerCell13.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow3.Cells.Add(headerCell12);
                headerRow3.Cells.Add(headerCell13);

                headerCell7.Text = "रुंदी करण करणे";
                headerCell8.Text = "पूल/मो-या";
                headerCell9.Text = "अन्य";
                headerCell7.HorizontalAlign = HorizontalAlign.Center;
                headerCell7.RowSpan = 2;
                headerCell7.ForeColor = Color.White;
                headerCell7.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerCell8.HorizontalAlign = HorizontalAlign.Center;
                headerCell8.RowSpan = 2;
                headerCell8.ForeColor = Color.White;
                headerCell8.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerCell9.HorizontalAlign = HorizontalAlign.Center;
                headerCell9.RowSpan = 2;
                headerCell9.ForeColor = Color.White;
                headerCell9.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow2.Cells.Add(headerCell7);
                headerRow2.Cells.Add(headerCell8);
                headerRow2.Cells.Add(headerCell9);



                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 3;
                //Cell_Header.ColumnSpan = 3;
                Cell_Header.Text = "दुरुस्तीचा प्रती खर्च किमी. खर्च रु. लक्ष";
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);


                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 3;
                Cell_Header.Text = "कामाची किंमत रु.लक्ष";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 3;
                Cell_Header.Text = "जॉब क्रमांक";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);



                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 3;
                Cell_Header.Text = "शेरा";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);


                GridView1.Controls[0].Controls.AddAt(0, headerRow3);
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

            Session["filename"] = "GatB_MPR_Report.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "GatB_MPR_Report.xls");
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
            //OrderBy = "संपूर्ण";
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select Upvibhag FROM BudgetMasterGAT_FBC  Group By Upvibhag" : "select a.Upvibhag FROM BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkID=b.WorkID where [Type]=N'गट बी' and a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By a.Upvibhag";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            //SqlDataAdapter sda = new SqlDataAdapter("select Upvibhag from BudgetMasterGAT_FBC where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' Group By Upvibhag", con);
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  UpabhyantaName FROM BudgetMasterGAT_FBC  Group By UpabhyantaName" : "select a.UpabhyantaName FROM BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkID=b.WorkID where a.[Type]=N'गट बी' and a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By a.UpabhyantaName";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            //SqlDataAdapter sda = new SqlDataAdapter("select UpabhyantaName from BudgetMasterGAT_FBC where [Type]=N'गट बी' and  lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' Group By ShakhaAbhyantaName", con);
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select WorkId FROM BudgetMasterGAT_FBC" : "select a.WorkId FROM BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkID=b.WorkID where a.[Type]=N'गट बी' and a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            // SqlDataAdapter sda = new SqlDataAdapter("select WorkId from BudgetMasterGAT_FBC where [Type]=N'गट बी' and  lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' Group By WorkId", con);
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select ThekedaarName FROM BudgetMasterGAT_FBC Group By ThekedaarName" : "select a.ThekedaarName FROM BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkID=b.WorkID where a.[Type]=N'गट बी' and a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By a.ThekedaarName";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            // SqlDataAdapter sda = new SqlDataAdapter("select ThekedaarName from BudgetMasterGAT_FBC where [Type]=N'गट बी' and  lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' Group By ThekedaarName", con);
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
            ddlist = ddlReportType.Text == "संपूर्ण" ? "select  Sadyasthiti FROM BudgetMasterGAT_FBC  Group By Sadyasthiti" : "select a.Sadyasthiti FROM BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkID=b.WorkID where a.[Type]=N'गट बी' and a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' Group By a.Sadyasthiti";
            SqlDataAdapter sda = new SqlDataAdapter(ddlist, con);
            //SqlDataAdapter sda = new SqlDataAdapter("select Sadyasthiti from BudgetMasterGAT_FBC where [Type]=N'गट बी' and  lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' Group By Sadyasthiti", con);
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
            whereColumn = "a.[Upvibhag]=N";
            WhereColumnValue = ddlUpvibhag.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnShakhaAbhiyanta_Click(object sender, EventArgs e)
        {
            //shakhaabhiyantaData();
            whereColumn = "a.[UpabhyantaName]=N";
            WhereColumnValue = ddlshakhaabhiyanta.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnWorkId_Click(object sender, EventArgs e)
        {
            //workIdData();
            whereColumn = "a.[WorkId]=N";
            WhereColumnValue = ddlworkId.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnthekedar_Click(object sender, EventArgs e)
        {
            //thekedarData();
            whereColumn = "a.[ThekedaarName]=N";
            WhereColumnValue = ddlthekedar.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }
        protected void btnkamachisadyasthiti_Click(object sender, EventArgs e)
        {
            //sadyasthitiData();
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