using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PWdEEBudget
{
    public partial class Report_LekhasirshBuilding : System.Web.UI.Page
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
            SqlDataAdapter sda = new SqlDataAdapter("select LekhaShirsh from SettingLekhaShirsh where Type='Building'", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterBuilding", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from BuildingProvision Group By Arthsankalpiyyear", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlArthYear.Items.Add(dr["Arthsankalpiyyear"].ToString());
            }
        }
        public void Upvibhag()
        {
            ddlUpvibhag.Items.Clear();
            ddlUpvibhag.Items.Add("निवडा");
            SqlDataAdapter sda;
            if (ddlReportType.Text=="संपूर्ण")
            {
                 sda = new SqlDataAdapter("select  Upvibhag FROM BudgetMasterBuilding Group By Upvibhag", con);
            }

            else
            {
                sda = new SqlDataAdapter("select a.Upvibhag FROM BudgetMasterBuilding as a join BuildingProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'Group By Upvibhag", con);
            }
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
            SqlDataAdapter sda;
            ddlshakhaabhiyanta.Items.Clear();
            ddlshakhaabhiyanta.Items.Add("निवडा");
            if (ddlReportType.Text == "संपूर्ण")
            {
                 sda = new SqlDataAdapter("select  UpabhyantaName FROM BudgetMasterBuilding Group By UpabhyantaName", con);
            }
            else
            {
                sda = new SqlDataAdapter("select a.UpabhyantaName FROM BudgetMasterBuilding as a join BuildingProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'Group By UpabhyantaName", con);

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
                 sda = new SqlDataAdapter("select WorkId FROM BudgetMasterBuilding ", con);
            }
            else
            {
                sda = new SqlDataAdapter("select a.WorkId FROM BudgetMasterBuilding as a join BuildingProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'", con);
            }
                    
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlworkId.Items.Add(dr["WorkId"].ToString());
            }          

        }
        public void Tekedar()
        {
            ddlthekedar.Items.Clear();
            ddlthekedar.Items.Add("निवडा");
            SqlDataAdapter sda;
            if (ddlReportType.Text == "संपूर्ण")
            {
                 sda = new SqlDataAdapter("select  ThekedaarName FROM BudgetMasterBuilding Group By ThekedaarName", con);
            }
            else
            {
                sda = new SqlDataAdapter("select a.ThekedaarName FROM BudgetMasterBuilding as a join BuildingProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'Group By ThekedaarName", con);
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
                 sda = new SqlDataAdapter("select Sadyasthiti FROM BudgetMasterBuilding Group By Sadyasthiti", con);
            }

            else
            {
                 sda = new SqlDataAdapter("select a.Sadyasthiti FROM BudgetMasterBuilding as a join BuildingProvision as b on a.Workid=b.Workid where a.lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' and b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "'Group By Sadyasthiti", con);
            }
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlsadyasthiti.Items.Add(dr["Sadyasthiti"].ToString());
            }
            //ddlsadyasthiti.Items.Add("संपूर्ण");

        }
        public void lekha()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select lekhaShirsh from BudgetMasterBuilding where lekhashirshName=N'" + ddlReportType.SelectedItem.Text + "' ", con);
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


            if (OrderBy != string.Empty)
            {
                OrderBy = "[Upvibhag]asc";
            }
            else
            {
                OrderBy = "[SubType]";
            }
            query = "SELECT ROW_NUMBER() OVER(PARTITION BY [lekhashirsh] ORDER BY" + OrderBy + " ) as 'SrNo',a.[SubType] ,a.[LekhaShirsh] as 'lekhashirsh',a.[LekhaShirshName] as 'LekhaShirshName',  a.[KamacheName] as kamachenaav,convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as prashaskiy,convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max), a.[TrantrikDate]) as tantrik,a.[ThekedaarName] as thename,convert(nvarchar(max),a.[NividaKrmank]) +' '+convert(nvarchar(max),a.[NividaDate])as karyarambhadesh,a.[NividaAmt] as nivamt,a.[kamachiMudat] +' month' as kammudat,b.[MarchEndingExpn] as marchexpn,b.[Tartud] as tartud,b.[AkunAnudan] as akndan,b.[Magilkharch] as magch,b.[Chalukharch] as chalch,b.[AikunKharch] as aknkharch,CAST(CASE WHEN MudatVadhiDate = ' ' or MudatVadhiDate = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as mudatvadh,[Vidyutprama] as vidprama,b.[Vidyutvitarit] as vidtarit,b.[Dviguni] as dvini, a.[Pahanikramank] as pankr,convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as shera, N'उपविभागीय अभियंता'+' '+convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) +N' शा.अ.- '+convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as abhiyanta from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID where b.Arthsankalpiyyear='" + ddlArthYear.SelectedItem.Text + "' ";

            if (Btnkam == "संपूर्ण")
            {


                if (ddlReportType.SelectedItem.Text == "संपूर्ण" || ddlkamacheYear.SelectedItem.Text == "संपूर्ण")
                {
                    string[] cols = new string[2];
                    cols[0] = "LekhaShirshName";
                    cols[1] = "lekhashirsh";

                    helper.RegisterGroup(cols, true, true);
                    helper.RegisterSummary("vidtarit", SummaryOperation.Sum, "LekhaShirshName+lekhashirsh");
                    helper.RegisterSummary("vidtarit", SummaryOperation.Sum);
                    helper.RegisterSummary("vidprama", SummaryOperation.Sum, "LekhaShirshName+lekhashirsh");
                    helper.RegisterSummary("vidprama", SummaryOperation.Sum);
                    helper.RegisterSummary("aknkharch", SummaryOperation.Sum, "LekhaShirshName+lekhashirsh");
                    helper.RegisterSummary("aknkharch", SummaryOperation.Sum);
                    helper.RegisterSummary("chalch", SummaryOperation.Sum, "LekhaShirshName+lekhashirsh");
                    helper.RegisterSummary("chalch", SummaryOperation.Sum);
                    helper.RegisterSummary("magch", SummaryOperation.Sum, "LekhaShirshName+lekhashirsh");
                    helper.RegisterSummary("magch", SummaryOperation.Sum);
                    helper.RegisterSummary("akndan", SummaryOperation.Sum, "LekhaShirshName+lekhashirsh");
                    helper.RegisterSummary("akndan", SummaryOperation.Sum);
                    helper.RegisterSummary("tartud", SummaryOperation.Sum, "LekhaShirshName+lekhashirsh");
                    helper.RegisterSummary("tartud", SummaryOperation.Sum);
                    helper.RegisterSummary("marchexpn", SummaryOperation.Sum, "LekhaShirshName+lekhashirsh");
                    helper.RegisterSummary("marchexpn", SummaryOperation.Sum);
                    helper.GroupSummary += new GroupEvent(helper_Bug);
                    helper.ApplyGroupSort();

                    //ObjMPRGridBind.MPRBindGrid() Method Of MasterReportGridBind Class
                    dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterBuilding");

                }
            }
            else
            {
                string[] cols = new string[2];
                cols[0] = "LekhaShirshName";
                cols[1] = "lekhashirsh";
                helper.RegisterGroup(cols, true, true);
                helper.RegisterSummary("vidtarit", SummaryOperation.Sum);
                helper.RegisterSummary("vidprama", SummaryOperation.Sum);
                helper.RegisterSummary("aknkharch", SummaryOperation.Sum);
                helper.RegisterSummary("chalch", SummaryOperation.Sum);
                helper.RegisterSummary("magch", SummaryOperation.Sum);
                helper.RegisterSummary("akndan", SummaryOperation.Sum);
                helper.RegisterSummary("tartud", SummaryOperation.Sum);
                helper.RegisterSummary("marchexpn", SummaryOperation.Sum);
                helper.GroupSummary += new GroupEvent(helper_Bug);
                helper.ApplyGroupSort();
                //ObjMPRGridBind.MPRBindGrid() Method Of MasterReportGridBind Class
                dt = ObjMPRGridBind.MPRBindGrid(ddlkamacheYear.Text, ddlReportType.Text, whereColumn, WhereColumnValue, query, "BudgetMasterBuilding");
            }
                
          
            foreach (DataRow dr in dt.Rows)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();                
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            Session["LekhasirshBuildingRpt"] = GridView1;
           
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Building_MPR_Report.xls"));
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
                Cell_Header.ForeColor=Color.White;
                Cell_Header.BackColor=ColorTranslator.FromHtml("#2c3e50");
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
                Cell_Header.Text = "प्रशासकीय मान्यता रक्कम /दिनांक";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "तांत्रिक मान्यता रक्कम /दिनांक";
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
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " मधील अर्थसंकल्पीय तरतूद/ठेव";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = ddlkamacheYear.SelectedItem.Text + " वितरीत तरतूद/ठेव";
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "Expenditure from 4/" + ddlkamacheYear.SelectedValue.Substring(0, 4) + " to 8/" + ddlkamacheYear.SelectedValue.Substring(0, 4);
                Cell_Header.HorizontalAlign = HorizontalAlign.Center;
                Cell_Header.ForeColor = Color.White;
                Cell_Header.BackColor = ColorTranslator.FromHtml("#2c3e50");
                headerRow1.Cells.Add(Cell_Header);

                Cell_Header = new TableCell();
                Cell_Header.RowSpan = 2;
                Cell_Header.Text = "माहे 09/" + ddlkamacheYear.SelectedValue.Substring(0, 4) + " खर्च ";
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string Value0 = GridView1.Rows[0].Cells[0].Text.ToString();
                //string Value1 = GridView1.Rows[0].Cells[1].Text.ToString();
                //string Value2 = GridView1.Rows[0].Cells[2].Text.ToString();
                //string Value3 = GridView1.Rows[0].Cells[3].Text.ToString();
                //GridViewRow row = GridView1.Rows[0];
               
                //if (row.Cells[1].Text == "एकुण रक्कम")
                //{
                //    row.Visible = false;
                //}
                //else if (row.Cells[2].Text == "एकुण रक्कम")
                //{
                //    row.Visible = false;
                //}
                //else if (row.Cells[3].Text == "एकुण रक्कम")
                //{
                //    row.Visible = false;
                //}
                //if (GridView1.Rows[0].Cells[0].Text == "एकुण रक्कम")
                //{
                //    GridView1.Rows[0].Visible = false;
                //}
            }
          
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "Building_MPR_Report.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "Building_MPR_Report.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }

            Response.Redirect("SendMail.aspx");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            GridView gv = (GridView)Session["LekhasirshBuildingRpt"];
            gv.UseAccessibleHeader = true;
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            gv.FooterRow.TableSection = TableRowSection.TableFooter;
            gv.Attributes["style"] = "border-collapse:separate";
            foreach (GridViewRow row in gv.Rows)
            {
                if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                {
                    row.Attributes["style"] = "page-break-after:always;";
                }
            }
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
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
            OrderBy = "संपूर्ण";
            whereColumn = "संपूर्ण";
            dataload();
            ListMenu.Style.Add("display", "none");
            
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
                
        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Upvibhag();
            Shakhabhiyanta();//Shakha_UpAbhiyanta
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
            //ShakhaabhyantaData();
            //Upabhyanta
            whereColumn = "a.[UpabhyantaName]=N";
            WhereColumnValue = ddlshakhaabhiyanta.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }

        protected void btnWorkId_Click(object sender, EventArgs e)
        {
           // WorkIdData();
            whereColumn = "a.[WorkId]=N";
            WhereColumnValue = ddlworkId.Text;
            dataload();
            ListMenu.Style.Add("display", "none");

        }

        protected void btnthekedar_Click(object sender, EventArgs e)
        {
           // ThekedarData();
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
           // Sadyasthithi();
            ListMenu.Style.Add("display", "none");

        }
                
    }
}