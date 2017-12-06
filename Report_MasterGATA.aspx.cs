using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class Report_MasterGATA : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        float total;
        string Work;
        float total1, total2, total3, total4, total5, total6, total7, total8, total9, total10, total11, total12, total13, total14, total15, total16, total17, total18, total19, total20, total21, total22, total23, total24, total25, total26,total27;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Upvibhag();
                Year();
                kamacheYear();
            }
        }

        public void kamacheYear()
        {

            ddlKamacheYr.Items.Clear();
            ddlKamacheYr.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterGAT_A", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlKamacheYr.Items.Add(dr[0].ToString());
            }
            ddlKamacheYr.Items.Add("संपूर्ण");
        }
        public void Upvibhag()
        {
            ddlReportType.Items.Clear();
            ddlReportType.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Upvibhag from BudgetMasterGAT_A", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlReportType.Items.Add(dr[0].ToString());
            }
            ddlReportType.Items.Add("संपूर्ण");

        }
        public void Year()
        {
            ddlArthsankalpiyYear.Items.Clear();
            ddlArthsankalpiyYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from GAT_AProvision", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlArthsankalpiyYear.Items.Add(dr[0].ToString());
            }
            //ddlArthsankalpiyYear.Items.Add("संपूर्ण");
        }
        public void UpvibhagAll()
        {
            //if (ddlArthsankalpiyYear.Text != "संपूर्ण")
            //{
                if (ddlKamacheYr.Text != "संपूर्ण")
                {
                    if (ddlReportType.SelectedItem.Text == "संपूर्ण")
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select count(BR.Type)as 'no of works',BR.Upvibhag as 'Division',sum(BR.GJobRakkam)as 'AA cost',sum(cast(BR.[TrantrikAmt] as decimal(10,2))) as 'TantrikAmt',sum(BR.GDambarichePariman)as 'GDambarichePariman',sum(BR.GDambarichiRakkam)as 'GDambarichiRakkam',sum(cast(BR.[NividaAmt] as decimal(10,2)))as 'NividaAmt',sum(RP.[MarchEndingExpn]+RP.[VarshbharatilKharch]+RP.[VidyutikaranAmt]+RP.[VidyutikaranExpen]+RP.[Itarkhrch]) as 'Kamavaril akun kharch',sum(RP.DambarichaExpen)as 'DambarichaExpen',sum(RP.AikunKharch)as 'AikunKharch',sum(RP.[Apr]) as 'Apr',sum(RP.[May]) as 'May',sum(RP.[Jun]) as 'Jun',sum(RP.[Jul]) as 'Jul',sum(RP.[Aug]) as 'Aug',sum(RP.[Sep]) as 'Sep',sum(RP.[Oct]) as 'Oct',sum(RP.[Nov]) as 'Nov',sum(RP.[Dec]) as 'Dec',sum(RP.[Jan]) as 'Jan',sum(RP.[Feb]) as 'Feb',sum(RP.[Mar]) as 'Mar',sum(Jan+Feb+Mar+Apr+May+Jun+Jul+Aug+Sep+Oct+Nov+Dec) as 'Total' from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'GAT_A' AND RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "'  group by BR.Type,BR.Upvibhag", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterGAT_A"] = GridView1;
                    }
                    else
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select count(BR.Type)as 'no of works',BR.Upvibhag as 'Division',sum(BR.GJobRakkam)as 'AA cost',sum(cast(BR.[TrantrikAmt] as decimal(10,2))) as 'TantrikAmt',sum(BR.GDambarichePariman)as 'GDambarichePariman',sum(BR.GDambarichiRakkam)as 'GDambarichiRakkam',sum(cast(BR.[NividaAmt] as decimal(10,2)))as 'NividaAmt',sum(RP.[MarchEndingExpn]+RP.[VarshbharatilKharch]+RP.[VidyutikaranAmt]+RP.[VidyutikaranExpen]+RP.[Itarkhrch]) as 'Kamavaril akun kharch',sum(RP.DambarichaExpen)as 'DambarichaExpen',sum(RP.AikunKharch)as 'AikunKharch',sum(RP.[Apr]) as 'Apr',sum(RP.[May]) as 'May',sum(RP.[Jun]) as 'Jun',sum(RP.[Jul]) as 'Jul',sum(RP.[Aug]) as 'Aug',sum(RP.[Sep]) as 'Sep',sum(RP.[Oct]) as 'Oct',sum(RP.[Nov]) as 'Nov',sum(RP.[Dec]) as 'Dec',sum(RP.[Jan]) as 'Jan',sum(RP.[Feb]) as 'Feb',sum(RP.[Mar]) as 'Mar',sum(Jan+Feb+Mar+Apr+May+Jun+Jul+Aug+Sep+Oct+Nov+Dec) as 'Total' from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'GAT_A' AND [Upvibhag]=N'" + ddlReportType.SelectedItem.Text + "' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Type,BR.Upvibhag", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterGAT_A"] = GridView1;
                    }
                }
                else
                {

                    if (ddlReportType.SelectedItem.Text == "संपूर्ण")
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select count(BR.Type)as 'no of works',BR.Upvibhag as 'Division',sum(BR.GJobRakkam)as 'AA cost',sum(cast(BR.[TrantrikAmt] as decimal(10,2))) as 'TantrikAmt',sum(BR.GDambarichePariman)as 'GDambarichePariman',sum(BR.GDambarichiRakkam)as 'GDambarichiRakkam',sum(cast(BR.[NividaAmt] as decimal(10,2)))as 'NividaAmt',sum(RP.[MarchEndingExpn]+RP.[VarshbharatilKharch]+RP.[VidyutikaranAmt]+RP.[VidyutikaranExpen]+RP.[Itarkhrch]) as 'Kamavaril akun kharch',sum(RP.DambarichaExpen)as 'DambarichaExpen',sum(RP.AikunKharch)as 'AikunKharch',sum(RP.[Apr]) as 'Apr',sum(RP.[May]) as 'May',sum(RP.[Jun]) as 'Jun',sum(RP.[Jul]) as 'Jul',sum(RP.[Aug]) as 'Aug',sum(RP.[Sep]) as 'Sep',sum(RP.[Oct]) as 'Oct',sum(RP.[Nov]) as 'Nov',sum(RP.[Dec]) as 'Dec',sum(RP.[Jan]) as 'Jan',sum(RP.[Feb]) as 'Feb',sum(RP.[Mar]) as 'Mar',sum(Jan+Feb+Mar+Apr+May+Jun+Jul+Aug+Sep+Oct+Nov+Dec) as 'Total' from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'GAT_A' AND RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "'  group by BR.Type,BR.Upvibhag", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterGAT_A"] = GridView1;
                    }
                    else
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select count(BR.Type)as 'no of works',BR.Upvibhag as 'Division',sum(BR.GJobRakkam)as 'AA cost',sum(cast(BR.[TrantrikAmt] as decimal(10,2))) as 'TantrikAmt',sum(BR.GDambarichePariman)as 'GDambarichePariman',sum(BR.GDambarichiRakkam)as 'GDambarichiRakkam',sum(cast(BR.[NividaAmt] as decimal(10,2)))as 'NividaAmt',sum(RP.[MarchEndingExpn]+RP.[VarshbharatilKharch]+RP.[VidyutikaranAmt]+RP.[VidyutikaranExpen]+RP.[Itarkhrch]) as 'Kamavaril akun kharch',sum(RP.DambarichaExpen)as 'DambarichaExpen',sum(RP.AikunKharch)as 'AikunKharch',sum(RP.[Apr]) as 'Apr',sum(RP.[May]) as 'May',sum(RP.[Jun]) as 'Jun',sum(RP.[Jul]) as 'Jul',sum(RP.[Aug]) as 'Aug',sum(RP.[Sep]) as 'Sep',sum(RP.[Oct]) as 'Oct',sum(RP.[Nov]) as 'Nov',sum(RP.[Dec]) as 'Dec',sum(RP.[Jan]) as 'Jan',sum(RP.[Feb]) as 'Feb',sum(RP.[Mar]) as 'Mar',sum(Jan+Feb+Mar+Apr+May+Jun+Jul+Aug+Sep+Oct+Nov+Dec) as 'Total' from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'GAT_A' AND [Upvibhag]=N'" + ddlReportType.SelectedItem.Text + "' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Type,BR.Upvibhag", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterGAT_A"] = GridView1;
                    }

                }

                if (ddlReportType.SelectedItem.ToString() != null || ddlReportType.SelectedItem.ToString() != "निवडा")
                {
                    lblPrintUpvibhag.Text = "उपविभाग : " + ddlReportType.SelectedItem.ToString();
                }

                if (ddlArthsankalpiyYear.SelectedItem.ToString() != null || ddlArthsankalpiyYear.SelectedItem.ToString() != "निवडा")
                {
                    lblPrintArthSanalpYr.Text = "अर्थसंकल्पीय वर्ष : " + ddlArthsankalpiyYear.SelectedItem.ToString();
                }

                if (ddlKamacheYr.SelectedItem.ToString() != null || ddlKamacheYr.SelectedItem.ToString() != "निवडा")
                {
                    lblPrintKamcacheyr.Text = "कामाचे वर्ष: " + ddlKamacheYr.SelectedItem.ToString();
                }
            
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', auto, 100 , 100 ,true); </script>", false);
        }

        protected void Print(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
            }
        }
        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "GAT_A_Abstract_Report.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            UpvibhagAll();
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
            /* Verifies that the control is rendered */
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendMail.aspx");
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Lekhasirsh11();

            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Label)e.Row.FindControl("lblmar")).Text = "TantrikAmt" + ddlArthsankalpiyYear.SelectedValue.Substring(0, 7);
                ((Label)e.Row.FindControl("lblProvision3")).Text = "GDambarichiRakkam in 3/" + ddlArthsankalpiyYear.SelectedValue.Substring(0, 7);
                //((Label)e.Row.FindControl("lblProvision7")).Text = "GDambarichiRakkam in 7/" + ddlArthsankalpiyYear.SelectedValue.Substring(0, 4);
                ((Label)e.Row.FindControl("lblExpenditure9")).Text = "Expenditure Up to 9/" + ddlArthsankalpiyYear.SelectedValue.Substring(0, 7);
                //((Label)e.Row.FindControl("lblDemand")).Text = "Demand for " + ddlArthsankalpiyYear.SelectedItem.Text;
                //((Label)e.Row.FindControl("lbllekha")).Text = a;
            }
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Work = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
            //}
            //if (ddlArthsankalpiyYear.Text != "संपूर्ण")
            //{
                if (ddlKamacheYr.Text != "संपूर्ण")
                {

                    if (ddlReportType.SelectedItem.Text != "संपूर्ण")
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt1 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'GAT_A' and BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'पूर्ण'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblC.Text = dr["cnt1"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblP = (Label)e.Row.FindControl("lblP");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt2 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'GAT_A' and BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'चालू'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblP.Text = dr["cnt2"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNS = (Label)e.Row.FindControl("lblNS");
                            Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt3 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'GAT_A' and BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Not Started'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt3"].ToString();

                            }
                        }

                    }
                    else
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt4 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lbllupvibhag.Text + "' AND BR.Type=N'GAT_A'  AND BR.Sadyasthiti=N'पूर्ण' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblC.Text = dr["cnt4"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblP = (Label)e.Row.FindControl("lblP");
                            Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt5 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lbllupvibhag.Text + "' AND BR.Type=N'GAT_A' AND BR.Sadyasthiti=N'चालू' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblP.Text = dr["cnt5"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNS = (Label)e.Row.FindControl("lblNS");
                            Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt6 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lbllupvibhag.Text + "' AND BR.Type=N'GAT_A' AND BR.Sadyasthiti=N'Not Started' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt6"].ToString();

                            }
                        }


                    }
                }
                else
                {

                    if (ddlReportType.SelectedItem.Text != "संपूर्ण")
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt7 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'GAT_A' and BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'पूर्ण'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblC.Text = dr["cnt7"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblP = (Label)e.Row.FindControl("lblP");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt8 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'GAT_A' and BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'चालू' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblP.Text = dr["cnt8"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNS = (Label)e.Row.FindControl("lblNS");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt9 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'GAT_A' and BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Not Started' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt9"].ToString();

                            }
                        }

                    }
                    else
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt10 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lbllupvibhag.Text + "' AND BR.Type=N'GAT_A'  AND BR.Sadyasthiti=N'पूर्ण' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblC.Text = dr["cnt10"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblP = (Label)e.Row.FindControl("lblP");
                            Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt11 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lbllupvibhag.Text + "' AND BR.Type=N'GAT_A'  AND BR.Sadyasthiti=N'चालू' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblP.Text = dr["cnt11"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNS = (Label)e.Row.FindControl("lblNS");
                            Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt12 from BudgetMasterGAT_A as BR join GAT_AProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lbllupvibhag.Text + "' AND BR.Type=N'GAT_A'  AND BR.Sadyasthiti=N'Not Started' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt12"].ToString();

                            }
                        }


                    }

                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblT1 = (Label)e.Row.FindControl("lblAACost");
                    float qty1 = Convert.ToSingle(lblT1.Text);
                    total1 = total1 + qty1;
                    Label lblT2 = (Label)e.Row.FindControl("lblExpMar");
                    float qty2 = Convert.ToSingle(lblT2.Text);
                    total2 = total2 + qty2;
                    Label lblT3 = (Label)e.Row.FindControl("lblBalCost");
                    float qty3 = Convert.ToSingle(lblT3.Text);
                    total3 = total3 + qty3;
                    Label lblT4 = (Label)e.Row.FindControl("lblMarProvi");
                    float qty4 = Convert.ToSingle(lblT4.Text);
                    total4 = total4 + qty4;
                    //Label lblT5 = (Label)e.Row.FindControl("lbljulProvi");
                    //float qty5 = Convert.ToSingle(lblT5.Text);
                    //total5 = total5 + qty5;
                    Label lblT6 = (Label)e.Row.FindControl("lblTotal");
                    float qty6 = Convert.ToSingle(lblT6.Text);
                    total6 = total6 + qty6;
                    Label lblT7 = (Label)e.Row.FindControl("lblRelessed");
                    float qty7 = Convert.ToSingle(lblT7.Text);
                    total7 = total7 + qty7;
                    Label lblT27 = (Label)e.Row.FindControl("lblDambarichaExp");
                    float qty27 = Convert.ToSingle(lblT27.Text);
                    total27 = total27 + qty27;
                    Label lblT8 = (Label)e.Row.FindControl("lblExp9");
                    float qty8 = Convert.ToSingle(lblT8.Text);
                    total8 = total8 + qty8;
                    Label lblT9 = (Label)e.Row.FindControl("lblDemnd");
                    float qty9 = Convert.ToSingle(lblT9.Text);
                    total9 = total9 + qty9;
                    Label lblT10 = (Label)e.Row.FindControl("lblApr");
                    float qty10 = Convert.ToSingle(lblT10.Text);
                    total10 = total10 + qty10;
                    Label lblT11 = (Label)e.Row.FindControl("lblMay");
                    float qty11 = Convert.ToSingle(lblT11.Text);
                    total11 = total11 + qty11;
                    Label lblT12 = (Label)e.Row.FindControl("lblJun");
                    float qty12 = Convert.ToSingle(lblT12.Text);
                    total12 = total12 + qty12;
                    Label lblT13 = (Label)e.Row.FindControl("lblJul");
                    float qty13 = Convert.ToSingle(lblT13.Text);
                    total13 = total13 + qty13;
                    Label lblT14 = (Label)e.Row.FindControl("lblAug");
                    float qty14 = Convert.ToSingle(lblT14.Text);
                    total14 = total14 + qty14;
                    Label lblT15 = (Label)e.Row.FindControl("lblSep");
                    float qty15 = Convert.ToSingle(lblT15.Text);
                    total15 = total15 + qty15;
                    Label lblT16 = (Label)e.Row.FindControl("lblOct");
                    float qty16 = Convert.ToSingle(lblT16.Text);
                    total16 = total16 + qty16;
                    Label lblT17 = (Label)e.Row.FindControl("lblNov");
                    float qty17 = Convert.ToSingle(lblT17.Text);
                    total17 = total17 + qty17;
                    Label lblT18 = (Label)e.Row.FindControl("lblDec");
                    float qty18 = Convert.ToSingle(lblT18.Text);
                    total18 = total18 + qty18;
                    Label lblT19 = (Label)e.Row.FindControl("lblJan");
                    float qty19 = Convert.ToSingle(lblT19.Text);
                    total19 = total19 + qty19;
                    Label lblT20 = (Label)e.Row.FindControl("lblFeb");
                    float qty20 = Convert.ToSingle(lblT20.Text);
                    total20 = total20 + qty20;
                    Label lblT21 = (Label)e.Row.FindControl("lblMar1");
                    float qty21 = Convert.ToSingle(lblT21.Text);
                    total21 = total21 + qty21;
                    Label lblC = (Label)e.Row.FindControl("lblC");
                    float qty22 = Convert.ToSingle(lblC.Text);
                    total22 = total22 + qty22;
                    Label lblT23 = (Label)e.Row.FindControl("lblNoWorks");
                    float qty23 = Convert.ToSingle(lblT23.Text);
                    total23 = total23 + qty23;
                    Label lblP = (Label)e.Row.FindControl("lblP");
                    float qty25 = Convert.ToSingle(lblP.Text);
                    total25 = total25 + qty25;
                    Label lblNS = (Label)e.Row.FindControl("lblNS");
                    float qty26 = Convert.ToSingle(lblNS.Text);
                    total26 = total26 + qty26;
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblAACost = (Label)e.Row.FindControl("lblTotalAACost");
                    lblAACost.Text = total1.ToString();
                    Label lblExpMar = (Label)e.Row.FindControl("lblTotalExpMar");
                    lblExpMar.Text = total2.ToString();
                    Label lblBalCost = (Label)e.Row.FindControl("lblTotalBalCost");
                    lblBalCost.Text = total3.ToString();
                    Label lblMarProvi = (Label)e.Row.FindControl("lblTotalMarProvi");
                    lblMarProvi.Text = total4.ToString();
                    //Label lbljulProvi = (Label)e.Row.FindControl("lblTotaljulProvi");
                    //lbljulProvi.Text = total5.ToString();
                    Label lblTotal = (Label)e.Row.FindControl("lblTotalTotal");
                    lblTotal.Text = total6.ToString();
                    Label lblRelessed = (Label)e.Row.FindControl("lblTotalRelessed");
                    lblRelessed.Text = total7.ToString();
                    Label lblDambarichaExp = (Label)e.Row.FindControl("lblTotalDambarichaExp");
                    lblDambarichaExp.Text = total27.ToString();
                    Label lblExp9 = (Label)e.Row.FindControl("lblTotalexp9");
                    lblExp9.Text = total8.ToString();
                    Label lblDemnd = (Label)e.Row.FindControl("lblTotalDemnd1");
                    lblDemnd.Text = total9.ToString();
                    Label lblApr = (Label)e.Row.FindControl("lblTotalApr");
                    lblApr.Text = total10.ToString();
                    Label lblMay = (Label)e.Row.FindControl("lblTotalMay");
                    lblMay.Text = total11.ToString();
                    Label lblJun = (Label)e.Row.FindControl("lblTotalJun");
                    lblJun.Text = total12.ToString();
                    Label lblJul = (Label)e.Row.FindControl("lblTotalJul");
                    lblJul.Text = total13.ToString();
                    Label lblAug = (Label)e.Row.FindControl("lblTotalAug");
                    lblAug.Text = total14.ToString();
                    Label lblSep = (Label)e.Row.FindControl("lblTotalSep");
                    lblSep.Text = total15.ToString();
                    Label lblOct = (Label)e.Row.FindControl("lblTotalOct");
                    lblOct.Text = total16.ToString();
                    Label lblNov = (Label)e.Row.FindControl("lblTotalNov");
                    lblNov.Text = total17.ToString();
                    Label lblDec = (Label)e.Row.FindControl("lblTotalDec");
                    lblDec.Text = total18.ToString();
                    Label lblJan = (Label)e.Row.FindControl("lblTotalJan");
                    lblJan.Text = total19.ToString();
                    Label lblFeb = (Label)e.Row.FindControl("lblTotalFeb");
                    lblFeb.Text = total20.ToString();
                    Label lblMar1 = (Label)e.Row.FindControl("lblTotalMar1");
                    lblMar1.Text = total21.ToString();
                    Label lblC = (Label)e.Row.FindControl("lblSadhyasisthC1");
                    lblC.Text = total22.ToString();
                    Label lblNoWorks = (Label)e.Row.FindControl("lblTotalNoWorks");
                    lblNoWorks.Text = total23.ToString();
                    //Label lblBudgetHead = (Label)e.Row.FindControl("lblTotalBudgetHead");
                    //lblBudgetHead.Text = total24.ToString();
                    Label lblP = (Label)e.Row.FindControl("lblSadhyasisthP1");
                    lblP.Text = total25.ToString();
                    Label lblNS = (Label)e.Row.FindControl("lblSadhyasisthNS1");
                    lblNS.Text = total26.ToString();



                }

            
        }

        protected void ReportTypebtn_Click(object sender, EventArgs e)
        {
            //ViewState["LekhaShirsh"] = "";

            //UpvibhagAll();
            //Lekhasirsh11();
            //System.Threading.Thread.Sleep(5000);
            //ViewState["LekhaShirsh"] = ddlReportType.SelectedItem.ToString();
            UpvibhagAll();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
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

        protected void btnPrint_Click1(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "PrintGridData()", true);

        }
    }
}