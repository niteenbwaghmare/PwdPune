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
    public partial class Report_MasterNabard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        float total;
        string Work;
        float total1, total2, total3, total4, total5, total6, total7, total8, total9, total10, total11, total12, total13, total14, total15, total16, total17, total18, total19, total20, total21, total22, total23, total24, total25, total26, total27, total28, total29;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RIDF();
                Year();
                kamacheYear();
            }
        }

        public void kamacheYear()
        {

            ddlKamacheYr.Items.Clear();
            ddlKamacheYr.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterNABARD", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlKamacheYr.Items.Add(dr[0].ToString());
            }
            ddlKamacheYr.Items.Add("संपूर्ण");
        }
        public void RIDF()
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
        public void Year()
        {
            ddlArthsankalpiyYear.Items.Clear();
            ddlArthsankalpiyYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from NABARDProvision", con);
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

                        SqlDataAdapter sda = new SqlDataAdapter("select BR.RDF_NO as 'RDF_NO', BR.Dist as 'District',count(BR.Type)as 'no of works',sum(BR.WBMI_km)as 'W B M I  Km',sum(BR.WBMII_km)as 'W B M II  Km',sum(BR.WBMIII_km)as 'W B M III Km',sum(BR.Surface_km)as 'Surface Dressing Km',sum(BR.BBM_km)as 'B B M Km',sum(BR.Carpet_km)as 'Carpet Km',sum(cast(BR.[CD_Works_No] as INT)) as 'C D Works Nos',sum(RP.MarchEndingExpn)as 'Expend Up to March',sum(RP.Takunone)as 'Budget Provision',sum(RP.Magni)as 'Demand',sum(RP.Magilkharch)as 'Expend up to sept' from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'Nabard' AND RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "'  group by BR.Type,BR.RDF_NO,BR.Dist", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterNabardPCR"] = GridView1;
                    }
                    else
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select BR.RDF_NO as 'RDF_NO', BR.Dist as 'District',count(BR.Type)as 'no of works',sum(BR.WBMI_km)as 'W B M I  Km',sum(BR.WBMII_km)as 'W B M II  Km',sum(BR.WBMIII_km)as 'W B M III Km',sum(BR.Surface_km)as 'Surface Dressing Km',sum(BR.BBM_km)as 'B B M Km',sum(BR.Carpet_km)as 'Carpet Km',sum(cast(BR.[CD_Works_No] as INT)) as 'C D Works Nos',sum(RP.MarchEndingExpn)as 'Expend Up to March',sum(RP.Takunone)as 'Budget Provision',sum(RP.Magni)as 'Demand',sum(RP.Magilkharch)as 'Expend up to sept' from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'Nabard' AND BR.[RDF_NO]=N'" + ddlReportType.SelectedItem.Text + "' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Type,BR.RDF_NO,BR.Dist", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterNabardPCR"] = GridView1;
                    }
                }
                else
                {

                    if (ddlReportType.SelectedItem.Text == "संपूर्ण")
                    {
                        
                        SqlDataAdapter sda = new SqlDataAdapter("select BR.RDF_NO as 'RDF_NO', BR.Dist as 'District',count(BR.Type)as 'no of works',sum(BR.WBMI_km)as 'W B M I  Km',sum(BR.WBMII_km)as 'W B M II  Km',sum(BR.WBMIII_km)as 'W B M III Km',sum(BR.Surface_km)as 'Surface Dressing Km',sum(BR.BBM_km)as 'B B M Km',sum(BR.Carpet_km)as 'Carpet Km',sum(cast(BR.[CD_Works_No] as INT)) as 'C D Works Nos',sum(RP.MarchEndingExpn)as 'Expend Up to March',sum(RP.Takunone)as 'Budget Provision',sum(RP.Magni)as 'Demand',sum(RP.Magilkharch)as 'Expend up to sept' from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'Nabard' AND RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "'  group by BR.Type,BR.RDF_NO,BR.Dist", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterNabardPCR"] = GridView1;
                    }
                    else
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select BR.RDF_NO as 'RDF_NO', BR.Dist as 'District',count(BR.Type)as 'no of works',sum(BR.WBMI_km)as 'W B M I  Km',sum(BR.WBMII_km)as 'W B M II  Km',sum(BR.WBMIII_km)as 'W B M III Km',sum(BR.Surface_km)as 'Surface Dressing Km',sum(BR.BBM_km)as 'B B M Km',sum(BR.Carpet_km)as 'Carpet Km',sum(cast(BR.[CD_Works_No] as INT)) as 'C D Works Nos',sum(RP.MarchEndingExpn)as 'Expend Up to March',sum(RP.Takunone)as 'Budget Provision',sum(RP.Magni)as 'Demand',sum(RP.Magilkharch)as 'Expend up to sept' from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'Nabard' AND BR.[RDF_NO]=N'" + ddlReportType.SelectedItem.Text + "' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Type,BR.RDF_NO,BR.Dist", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterNabardPCR"] = GridView1;
                    }

                }
                if (ddlReportType.SelectedItem.ToString() != null || ddlReportType.SelectedItem.ToString() != "निवडा")
                {
                    lblPrintUpvibhag.Text = "RIDF No.: " + ddlReportType.SelectedItem.ToString();
                }

                if (ddlArthsankalpiyYear.SelectedItem.ToString() != null || ddlArthsankalpiyYear.SelectedItem.ToString() != "निवडा")
                {
                    lblPrintArthSanalpYr.Text = "अर्थसंकल्पीय वर्ष : " + ddlArthsankalpiyYear.SelectedItem.ToString();
                }

                if (ddlKamacheYr.SelectedItem.ToString() != null || ddlKamacheYr.SelectedItem.ToString() != "निवडा")
                {
                    lblPrintKamcacheyr.Text = "कामाचे वर्ष: " + ddlKamacheYr.SelectedItem.ToString();
                }
            //}
            //else
            //{

            //    if (ddlKamacheYr.Text != "संपूर्ण")
            //    {
            //        if (ddlReportType.SelectedItem.Text == "संपूर्ण")
            //        {
                       
            //            SqlDataAdapter sda = new SqlDataAdapter("select BR.RDF_NO as 'RDF_NO', BR.Dist as 'District',count(BR.Type)as 'no of works',sum(BR.WBMI_km)as 'W B M I  Km',sum(BR.WBMII_km)as 'W B M II  Km',sum(BR.WBMIII_km)as 'W B M III Km',sum(BR.Surface_km)as 'Surface Dressing Km',sum(BR.BBM_km)as 'B B M Km',sum(BR.Carpet_km)as 'Carpet Km',sum(cast(BR.[CD_Works_No] as INT)) as 'C D Works Nos',sum(RP.MarchEndingExpn)as 'Expend Up to March',sum(RP.Takunone)as 'Budget Provision',sum(RP.Magni)as 'Demand',sum(RP.Magilkharch)as 'Expend up to sept' from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'Nabard' AND BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Type,BR.RDF_NO,BR.Dist", con);
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            GridView1.DataSource = dt;
            //            GridView1.DataBind();
            //            Session["Report_MasterNabardPCR"] = GridView1;
            //        }
            //        else
            //        {
            //            SqlDataAdapter sda = new SqlDataAdapter("select BR.RDF_NO as 'RDF_NO', BR.Dist as 'District',count(BR.Type)as 'no of works',sum(BR.WBMI_km)as 'W B M I  Km',sum(BR.WBMII_km)as 'W B M II  Km',sum(BR.WBMIII_km)as 'W B M III Km',sum(BR.Surface_km)as 'Surface Dressing Km',sum(BR.BBM_km)as 'B B M Km',sum(BR.Carpet_km)as 'Carpet Km',sum(cast(BR.[CD_Works_No] as INT)) as 'C D Works Nos',sum(RP.MarchEndingExpn)as 'Expend Up to March',sum(RP.Takunone)as 'Budget Provision',sum(RP.Magni)as 'Demand',sum(RP.Magilkharch)as 'Expend up to sept' from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'Nabard' AND BR.[RDF_NO]=N'" + ddlReportType.SelectedItem.Text + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Type,BR.RDF_NO,BR.Dist", con);
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            GridView1.DataSource = dt;
            //            GridView1.DataBind();
            //            Session["Report_MasterNabardPCR"] = GridView1;
            //        }
            //    }
            //    else
            //    {

            //        if (ddlReportType.SelectedItem.Text == "संपूर्ण")
            //        {


            //            SqlDataAdapter sda = new SqlDataAdapter("select BR.RDF_NO as 'RDF_NO', BR.Dist as 'District',count(BR.Type)as 'no of works',sum(BR.WBMI_km)as 'W B M I  Km',sum(BR.WBMII_km)as 'W B M II  Km',sum(BR.WBMIII_km)as 'W B M III Km',sum(BR.Surface_km)as 'Surface Dressing Km',sum(BR.BBM_km)as 'B B M Km',sum(BR.Carpet_km)as 'Carpet Km',sum(cast(BR.[CD_Works_No] as INT)) as 'C D Works Nos',sum(RP.MarchEndingExpn)as 'Expend Up to March',sum(RP.Takunone)as 'Budget Provision',sum(RP.Magni)as 'Demand',sum(RP.Magilkharch)as 'Expend up to sept' from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'Nabard' group by BR.Type,BR.RDF_NO,BR.Dist", con);
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            GridView1.DataSource = dt;
            //            GridView1.DataBind();
            //            Session["Report_MasterNabardPCR"] = GridView1;
            //        }
            //        else
            //        {
            //            SqlDataAdapter sda = new SqlDataAdapter("select BR.RDF_NO as 'RDF_NO', BR.Dist as 'District',count(BR.Type)as 'no of works',sum(BR.WBMI_km)as 'W B M I  Km',sum(BR.WBMII_km)as 'W B M II  Km',sum(BR.WBMIII_km)as 'W B M III Km',sum(BR.Surface_km)as 'Surface Dressing Km',sum(BR.BBM_km)as 'B B M Km',sum(BR.Carpet_km)as 'Carpet Km',sum(cast(BR.[CD_Works_No] as INT)) as 'C D Works Nos',sum(RP.MarchEndingExpn)as 'Expend Up to March',sum(RP.Takunone)as 'Budget Provision',sum(RP.Magni)as 'Demand',sum(RP.Magilkharch)as 'Expend up to sept' from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId where BR.Type=N'Nabard' AND BR.[RDF_NO]=N'" + ddlReportType.SelectedItem.Text + "' group by BR.Type,BR.RDF_NO,BR.Dist", con);
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            GridView1.DataSource = dt;
            //            GridView1.DataBind();
            //            Session["Report_MasterNabardPCR"] = GridView1;
            //        }

            //    }

            //}
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "NabardPCR_Abstract_Report.xls"));
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
                ((Label)e.Row.FindControl("lblmar")).Text = "Expend Up to March" + ddlArthsankalpiyYear.SelectedValue.Substring(0, 7) + "in Lakh";
                ((Label)e.Row.FindControl("lblProvision3")).Text = "Budget Provision in 3/" + ddlArthsankalpiyYear.SelectedValue.Substring(0, 7) + "in Lakh" ;
                //((Label)e.Row.FindControl("lblProvision7")).Text = "Budget Provision in 7/" + ddlArthsankalpiyYear.SelectedValue.Substring(0, 4);
                ((Label)e.Row.FindControl("lblExpenditure9")).Text = "Expenditure Up to 9/" + ddlArthsankalpiyYear.SelectedValue.Substring(0, 7) + "in Lakh";
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
                            Label lblNoRoadWorks = (Label)e.Row.FindControl("lblNoRoadWorks");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt111 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.RoadType=N'Road'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.RoadType", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoRoadWorks.Text = dr["cnt111"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoBridgeWorks = (Label)e.Row.FindControl("lblNoBridgeWorks");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt211 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.RoadType=N'Bridge'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.RoadType", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoBridgeWorks.Text = dr["cnt211"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoPCRSubmitted = (Label)e.Row.FindControl("lblNoPCRSubmitted");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt311 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.PCR=N'Submitted'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.PCR", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoPCRSubmitted.Text = dr["cnt311"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoPCRpending = (Label)e.Row.FindControl("lblNoPCRpending");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt411 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.PCR=N'Pending'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.PCR", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoPCRpending.Text = dr["cnt411"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt1 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Completed'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
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
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt2 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Inprogress'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
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
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt3 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Not Started'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt3"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblIncomplete = (Label)e.Row.FindControl("lblIncomplete");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt25 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Incomplete'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblIncomplete.Text = dr["cnt25"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblTenderStage = (Label)e.Row.FindControl("lblTenderStage");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt26 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Tender Stage'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblTenderStage.Text = dr["cnt26"].ToString();

                            }
                        }
                    }
                    else
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoRoadWorks = (Label)e.Row.FindControl("lblNoRoadWorks");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt112 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.RoadType=N'Road'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.RoadType", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoRoadWorks.Text = dr["cnt112"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoBridgeWorks = (Label)e.Row.FindControl("lblNoBridgeWorks");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt212 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.RoadType=N'Bridge'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.RoadType", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoBridgeWorks.Text = dr["cnt212"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoPCRSubmitted = (Label)e.Row.FindControl("lblNoPCRSubmitted");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt511 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.PCR=N'Submitted'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.PCR", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoPCRSubmitted.Text = dr["cnt511"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoPCRpending = (Label)e.Row.FindControl("lblNoPCRpending");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt611 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.PCR=N'Pending'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.PCR", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoPCRpending.Text = dr["cnt611"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt4 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard'  AND BR.Sadyasthiti=N'Completed' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
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
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt5 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard' AND BR.Sadyasthiti=N'Inprogress' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
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
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt6 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard' AND BR.Sadyasthiti=N'Not Started' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt6"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblIncomplete = (Label)e.Row.FindControl("lblIncomplete");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt27 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard' AND BR.Sadyasthiti=N'Incomplete'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblIncomplete.Text = dr["cnt27"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblTenderStage = (Label)e.Row.FindControl("lblTenderStage");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt28 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard' AND BR.Sadyasthiti=N'Tender Stage'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblTenderStage.Text = dr["cnt28"].ToString();

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
                            Label lblNoRoadWorks = (Label)e.Row.FindControl("lblNoRoadWorks");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt113 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.RoadType=N'Road'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "'  group by BR.RoadType", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoRoadWorks.Text = dr["cnt113"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoBridgeWorks = (Label)e.Row.FindControl("lblNoBridgeWorks");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt213 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.RoadType=N'Bridge'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "'  group by BR.RoadType", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoBridgeWorks.Text = dr["cnt213"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoPCRSubmitted = (Label)e.Row.FindControl("lblNoPCRSubmitted");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt711 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.PCR=N'Submitted'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.PCR", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoPCRSubmitted.Text = dr["cnt711"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoPCRpending = (Label)e.Row.FindControl("lblNoPCRpending");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt811 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.PCR=N'Pending'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "'  group by BR.PCR", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoPCRpending.Text = dr["cnt811"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt7 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Completed'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
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
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt8 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Inprogress' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
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
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt9 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Not Started' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt9"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblIncomplete = (Label)e.Row.FindControl("lblIncomplete");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt29 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Incomplete'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblIncomplete.Text = dr["cnt29"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblTenderStage = (Label)e.Row.FindControl("lblTenderStage");
                            //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt30 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Tender Stage'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblTenderStage.Text = dr["cnt30"].ToString();

                            }
                        }

                    }
                    else
                    {

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoRoadWorks = (Label)e.Row.FindControl("lblNoRoadWorks");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt114 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.RoadType=N'Road'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "'  group by BR.RoadType", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoRoadWorks.Text = dr["cnt114"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoBridgeWorks = (Label)e.Row.FindControl("lblNoBridgeWorks");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt214 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.RoadType=N'Bridge'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "'  group by BR.RoadType", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoBridgeWorks.Text = dr["cnt214"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoPCRSubmitted = (Label)e.Row.FindControl("lblNoPCRSubmitted");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt911 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.PCR=N'Submitted'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.PCR", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoPCRSubmitted.Text = dr["cnt911"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNoPCRpending = (Label)e.Row.FindControl("lblNoPCRpending");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt1011 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.PCR=N'Pending'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "'  group by BR.PCR", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNoPCRpending.Text = dr["cnt1011"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt10 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard'  AND BR.Sadyasthiti=N'Completed' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
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
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt11 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard'  AND BR.Sadyasthiti=N'Inprogress' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
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
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt12 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard'  AND BR.Sadyasthiti=N'Not Started' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt12"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblIncomplete = (Label)e.Row.FindControl("lblIncomplete");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt31 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard'  AND BR.Sadyasthiti=N'Incomplete'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblIncomplete.Text = dr["cnt31"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblTenderStage = (Label)e.Row.FindControl("lblTenderStage");
                            Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt32 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard'  AND BR.Sadyasthiti=N'Tender Stage'  and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblTenderStage.Text = dr["cnt32"].ToString();

                            }
                        }

                    }

                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {                  
                    /* Latest */
                    Label lblT2 = (Label)e.Row.FindControl("lblExpMar");
                    float qty2 = Convert.ToSingle(lblT2.Text);
                    total2 = total2 + qty2;
                    Label lblT4 = (Label)e.Row.FindControl("lblMarProvi");
                    float qty4 = Convert.ToSingle(lblT4.Text);
                    total4 = total4 + qty4;
                    Label lblT8 = (Label)e.Row.FindControl("lblExp9");
                    float qty8 = Convert.ToSingle(lblT8.Text);
                    total8 = total8 + qty8;
                    Label lblT9 = (Label)e.Row.FindControl("lblDemnd");
                    float qty9 = Convert.ToSingle(lblT9.Text);
                    total9 = total9 + qty9;
                    Label lblT10 = (Label)e.Row.FindControl("lblNoRoadWorks");
                    float qty10 = Convert.ToSingle(lblT10.Text);
                    total10 = total10 + qty10;
                    Label lblT11 = (Label)e.Row.FindControl("lblNoBridgeWorks");
                    float qty11 = Convert.ToSingle(lblT11.Text);
                    total11 = total11 + qty11;
                    Label lblT12 = (Label)e.Row.FindControl("lblCntWBMI");
                    float qty12 = Convert.ToSingle(lblT12.Text);
                    total12 = total12 + qty12;
                    Label lblT13 = (Label)e.Row.FindControl("lblCntWBMII");
                    float qty13 = Convert.ToSingle(lblT13.Text);
                    total13 = total13 + qty13;
                    Label lblT14 = (Label)e.Row.FindControl("lblCntWBMIII");
                    float qty14 = Convert.ToSingle(lblT14.Text);
                    total14 = total14 + qty14;
                    Label lblT15 = (Label)e.Row.FindControl("lblCntSurfaceDressingKm");
                    float qty15 = Convert.ToSingle(lblT15.Text);
                    total15 = total15 + qty15;
                    Label lblT16 = (Label)e.Row.FindControl("lblCntBBMKm");
                    float qty16 = Convert.ToSingle(lblT16.Text);
                    total16 = total16 + qty16;
                    Label lblT17 = (Label)e.Row.FindControl("lblCntCarpetKm");
                    float qty17 = Convert.ToSingle(lblT17.Text);
                    total17 = total17 + qty17;
                    Label lblT18 = (Label)e.Row.FindControl("lblCntCDwork");
                    float qty18 = Convert.ToSingle(lblT18.Text);
                    total18 = total18 + qty18;
                    Label lblT19 = (Label)e.Row.FindControl("lblNoPCRSubmitted");
                    float qty19 = Convert.ToSingle(lblT19.Text);
                    total19 = total19 + qty19;
                    Label lblT20 = (Label)e.Row.FindControl("lblNoPCRpending");
                    float qty20 = Convert.ToSingle(lblT20.Text);
                    total20 = total20 + qty20;


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
                    Label lblIncomplete = (Label)e.Row.FindControl("lblIncomplete");
                    float qty27 = Convert.ToSingle(lblIncomplete.Text);
                    total27 = total27 + qty27;
                    Label lblTenderStage = (Label)e.Row.FindControl("lblTenderStage");
                    float qty28 = Convert.ToSingle(lblTenderStage.Text);
                    total28 = total28 + qty28;

                   


                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {

                    /* Latest*/
                    Label lblExpMar = (Label)e.Row.FindControl("lblTotalExpMar");
                    lblExpMar.Text = total2.ToString();
                    Label lblMarProvi = (Label)e.Row.FindControl("lblTotalMarProvi");
                    lblMarProvi.Text = total4.ToString();
                    Label lblExp9 = (Label)e.Row.FindControl("lblTotalexp9");
                    lblExp9.Text = total8.ToString();
                    Label lblDemnd = (Label)e.Row.FindControl("lblTotalDemnd1");
                    lblDemnd.Text = total9.ToString();
                    Label lblNoRoadWorks = (Label)e.Row.FindControl("lblTotalRoadWorks");
                    lblNoRoadWorks.Text = total10.ToString();
                    Label lblNoBridgeWorks = (Label)e.Row.FindControl("lblTotalNoBridgeWorks");
                    lblNoBridgeWorks.Text = total11.ToString();
                    Label lblCntWBMI = (Label)e.Row.FindControl("lblTotalWBMIKm");
                    lblCntWBMI.Text = total12.ToString();
                    Label lblCntWBMII = (Label)e.Row.FindControl("lblTotalWBMIIKm");
                    lblCntWBMII.Text = total13.ToString();
                    Label lblCntWBMIII = (Label)e.Row.FindControl("lblTotalWBMIIIKm");
                    lblCntWBMIII.Text = total14.ToString();
                    Label lblSurfaceDressing = (Label)e.Row.FindControl("lblTotalSurfaceDressingKm");
                    lblSurfaceDressing.Text = total15.ToString();
                    Label lblCntBBMKm = (Label)e.Row.FindControl("lblTotalBBMKm");
                    lblCntBBMKm.Text = total16.ToString();
                    Label lblCntCarpetKm = (Label)e.Row.FindControl("lblTotalCarpetKm");
                    lblCntCarpetKm.Text = total17.ToString();
                    Label lblCntCDwork = (Label)e.Row.FindControl("lblTotalCDwork");
                    lblCntCDwork.Text = total18.ToString();
                    Label lblCntPCRpending = (Label)e.Row.FindControl("lblTotalPCRpending");
                    lblCntPCRpending.Text = total19.ToString();
                    Label lblCntPCRSubmitted = (Label)e.Row.FindControl("lblTotalPCRSubmitted");
                    lblCntPCRSubmitted.Text = total20.ToString();

                    Label lblC = (Label)e.Row.FindControl("lblSadhyasisthC1");
                    lblC.Text = total22.ToString();
                    Label lblNoWorks = (Label)e.Row.FindControl("lblTotalNoWorks");
                    lblNoWorks.Text = total23.ToString();
                    Label lblP = (Label)e.Row.FindControl("lblSadhyasisthP1");
                    lblP.Text = total25.ToString();
                    Label lblNS = (Label)e.Row.FindControl("lblSadhyasisthNS1");
                    lblNS.Text = total26.ToString();
                    Label lblIncomplete = (Label)e.Row.FindControl("lblSadhyasisthIncomplete1");
                    lblIncomplete.Text = total27.ToString();
                    Label lblTenderStage = (Label)e.Row.FindControl("lblSadhyasisthTenderStage1");
                    lblTenderStage.Text = total28.ToString();

                    
                   

                    
                }

            //}
            //else
            //{

            //    if (ddlKamacheYr.Text != "संपूर्ण")
            //    {

            //        if (ddlReportType.SelectedItem.Text != "संपूर्ण")
            //        {
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoRoadWorks = (Label)e.Row.FindControl("lblNoRoadWorks");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt115 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.RoadType=N'Road'  and BR.[Arthsankalpiyyear]='" + ddlKamacheYr.SelectedItem.ToString() + "'  group by BR.RoadType", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoRoadWorks.Text = dr["cnt115"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoBridgeWorks = (Label)e.Row.FindControl("lblNoBridgeWorks");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt215 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.RoadType=N'Bridge'  and BR.[Arthsankalpiyyear]='" + ddlKamacheYr.SelectedItem.ToString() + "'  group by BR.RoadType", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoBridgeWorks.Text = dr["cnt215"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoPCRSubmitted = (Label)e.Row.FindControl("lblNoPCRSubmitted");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt1111 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.PCR=N'Submitted'  and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.PCR", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoPCRSubmitted.Text = dr["cnt1111"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoPCRpending = (Label)e.Row.FindControl("lblNoPCRpending");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt1211 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.PCR=N'Pending'  and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "'  group by BR.PCR", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoPCRpending.Text = dr["cnt1211"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblC = (Label)e.Row.FindControl("lblC");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt13 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Completed' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblC.Text = dr["cnt13"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblP = (Label)e.Row.FindControl("lblP");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt14 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Inprogress' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblP.Text = dr["cnt14"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNS = (Label)e.Row.FindControl("lblNS");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt15 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Not Started' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNS.Text = dr["cnt15"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblIncomplete = (Label)e.Row.FindControl("lblIncomplete");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt33 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'Incomplete'  and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblIncomplete.Text = dr["cnt33"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblTenderStage = (Label)e.Row.FindControl("lblTenderStage");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt34 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'Tender Stage'  and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblTenderStage.Text = dr["cnt34"].ToString();

            //                }
            //            }

            //        }
            //        else
            //        {

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoRoadWorks = (Label)e.Row.FindControl("lblNoRoadWorks");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt116 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.RoadType=N'Road'  and BR.[Arthsankalpiyyear]='" + ddlKamacheYr.SelectedItem.ToString() + "'  group by BR.RoadType", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoRoadWorks.Text = dr["cnt116"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoBridgeWorks = (Label)e.Row.FindControl("lblNoBridgeWorks");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt216 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.RoadType=N'Bridge'  and BR.[Arthsankalpiyyear]='" + ddlKamacheYr.SelectedItem.ToString() + "'  group by BR.RoadType", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoBridgeWorks.Text = dr["cnt216"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoPCRSubmitted = (Label)e.Row.FindControl("lblNoPCRSubmitted");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt1311 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.PCR=N'Submitted'  and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.PCR", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoPCRSubmitted.Text = dr["cnt1311"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoPCRpending = (Label)e.Row.FindControl("lblNoPCRpending");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt1411 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.PCR=N'Pending'  and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "'  group by BR.PCR", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoPCRpending.Text = dr["cnt1411"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblC = (Label)e.Row.FindControl("lblC");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt16 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard'  AND BR.Sadyasthiti=N'Completed' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblC.Text = dr["cnt16"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblP = (Label)e.Row.FindControl("lblP");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt17 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard' AND BR.Sadyasthiti=N'Inprogress' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblP.Text = dr["cnt17"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNS = (Label)e.Row.FindControl("lblNS");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt18 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard' AND BR.Sadyasthiti=N'Not Started' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNS.Text = dr["cnt18"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblIncomplete = (Label)e.Row.FindControl("lblIncomplete");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt35 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard' AND BR.Sadyasthiti=N'Incomplete'  and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblIncomplete.Text = dr["cnt35"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblTenderStage = (Label)e.Row.FindControl("lblTenderStage");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt36 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard' AND BR.Sadyasthiti=N'Tender Stage'  and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblTenderStage.Text = dr["cnt36"].ToString();

            //                }
            //            }

            //        }
            //    }
            //    else
            //    {

            //        if (ddlReportType.SelectedItem.Text != "संपूर्ण")
            //        {
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoRoadWorks = (Label)e.Row.FindControl("lblNoRoadWorks");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt117 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.RoadType=N'Road' group by BR.RoadType", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoRoadWorks.Text = dr["cnt117"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoBridgeWorks = (Label)e.Row.FindControl("lblNoBridgeWorks");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt217 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.RoadType=N'Bridge' group by BR.RoadType", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoBridgeWorks.Text = dr["cnt217"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoPCRSubmitted = (Label)e.Row.FindControl("lblNoPCRSubmitted");
            //               // Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt1511 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.PCR=N'Submitted'  group by BR.PCR", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoPCRSubmitted.Text = dr["cnt1511"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoPCRpending = (Label)e.Row.FindControl("lblNoPCRpending");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt1611 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.PCR=N'Pending'  group by BR.PCR", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoPCRpending.Text = dr["cnt1611"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblC = (Label)e.Row.FindControl("lblC");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt19 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Completed'  group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblC.Text = dr["cnt19"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblP = (Label)e.Row.FindControl("lblP");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt20 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Inprogress' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblP.Text = dr["cnt20"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNS = (Label)e.Row.FindControl("lblNS");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt21 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'Not Started' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNS.Text = dr["cnt21"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblIncomplete = (Label)e.Row.FindControl("lblIncomplete");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt37 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'Incomplete'  group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblIncomplete.Text = dr["cnt37"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblTenderStage = (Label)e.Row.FindControl("lblTenderStage");
            //                //Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt38 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'Tender Stage'  group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblTenderStage.Text = dr["cnt38"].ToString();

            //                }
            //            }

            //        }
            //        else
            //        {

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoRoadWorks = (Label)e.Row.FindControl("lblNoRoadWorks");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt118 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.RoadType=N'Road' group by BR.RoadType", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoRoadWorks.Text = dr["cnt118"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoBridgeWorks = (Label)e.Row.FindControl("lblNoBridgeWorks");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.RoadType,isnull(COUNT(BR.RoadType),0) as cnt218 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.RoadType=N'Bridge' group by BR.RoadType", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoBridgeWorks.Text = dr["cnt218"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoPCRSubmitted = (Label)e.Row.FindControl("lblNoPCRSubmitted");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt1711 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.PCR=N'Submitted'  group by BR.PCR", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoPCRSubmitted.Text = dr["cnt1711"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNoPCRpending = (Label)e.Row.FindControl("lblNoPCRpending");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.PCR,isnull(COUNT(BR.PCR),0) as cnt1811 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Type=N'Nabard' and BR.RDF_NO=N'" + lblRIDF.Text + "'  AND BR.PCR=N'Pending'  group by BR.PCR", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNoPCRpending.Text = dr["cnt1811"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblC = (Label)e.Row.FindControl("lblC");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt22 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard'  AND BR.Sadyasthiti=N'Completed' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblC.Text = dr["cnt22"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblP = (Label)e.Row.FindControl("lblP");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt23 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard'  AND BR.Sadyasthiti=N'Inprogress' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblP.Text = dr["cnt23"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNS = (Label)e.Row.FindControl("lblNS");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt24 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard'  AND BR.Sadyasthiti=N'Not Started' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNS.Text = dr["cnt24"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblIncomplete = (Label)e.Row.FindControl("lblIncomplete");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt39 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard' AND BR.Sadyasthiti=N'Incomplete'  group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblIncomplete.Text = dr["cnt39"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblTenderStage = (Label)e.Row.FindControl("lblTenderStage");
            //                Label lblRIDF = (Label)e.Row.FindControl("lblRIDF");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt40 from BudgetMasterNABARD as BR join NABARDProvision as RP on BR.WorkId=RP.WorkId WHERE BR.RDF_NO=N'" + lblRIDF.Text + "' AND BR.Type=N'Nabard' AND BR.Sadyasthiti=N'Tender Stage'  group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblTenderStage.Text = dr["cnt40"].ToString();

            //                }
            //            }


            //        }

            //    }


            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        /* Latest */
            //        Label lblT2 = (Label)e.Row.FindControl("lblExpMar");
            //        float qty2 = Convert.ToSingle(lblT2.Text);
            //        total2 = total2 + qty2;
            //        Label lblT4 = (Label)e.Row.FindControl("lblMarProvi");
            //        float qty4 = Convert.ToSingle(lblT4.Text);
            //        total4 = total4 + qty4;
            //        Label lblT8 = (Label)e.Row.FindControl("lblExp9");
            //        float qty8 = Convert.ToSingle(lblT8.Text);
            //        total8 = total8 + qty8;
            //        Label lblT9 = (Label)e.Row.FindControl("lblDemnd");
            //        float qty9 = Convert.ToSingle(lblT9.Text);
            //        total9 = total9 + qty9;
            //        Label lblT10 = (Label)e.Row.FindControl("lblNoRoadWorks");
            //        float qty10 = Convert.ToSingle(lblT10.Text);
            //        total10 = total10 + qty10;
            //        Label lblT11 = (Label)e.Row.FindControl("lblNoBridgeWorks");
            //        float qty11 = Convert.ToSingle(lblT11.Text);
            //        total11 = total11 + qty11;
            //        Label lblT12 = (Label)e.Row.FindControl("lblCntWBMI");
            //        float qty12 = Convert.ToSingle(lblT12.Text);
            //        total12 = total12 + qty12;
            //        Label lblT13 = (Label)e.Row.FindControl("lblCntWBMII");
            //        float qty13 = Convert.ToSingle(lblT13.Text);
            //        total13 = total13 + qty13;
            //        Label lblT14 = (Label)e.Row.FindControl("lblCntWBMIII");
            //        float qty14 = Convert.ToSingle(lblT14.Text);
            //        total14 = total14 + qty14;
            //        Label lblT15 = (Label)e.Row.FindControl("lblCntSurfaceDressingKm");
            //        float qty15 = Convert.ToSingle(lblT15.Text);
            //        total15 = total15 + qty15;
            //        Label lblT16 = (Label)e.Row.FindControl("lblCntBBMKm");
            //        float qty16 = Convert.ToSingle(lblT16.Text);
            //        total16 = total16 + qty16;
            //        Label lblT17 = (Label)e.Row.FindControl("lblCntCarpetKm");
            //        float qty17 = Convert.ToSingle(lblT17.Text);
            //        total17 = total17 + qty17;
            //        Label lblT18 = (Label)e.Row.FindControl("lblCntCDwork");
            //        float qty18 = Convert.ToSingle(lblT18.Text);
            //        total18 = total18 + qty18;
            //        Label lblT19 = (Label)e.Row.FindControl("lblNoPCRSubmitted");
            //        float qty19 = Convert.ToSingle(lblT19.Text);
            //        total19 = total19 + qty19;
            //        Label lblT20 = (Label)e.Row.FindControl("lblNoPCRpending");
            //        float qty20 = Convert.ToSingle(lblT20.Text);
            //        total20 = total20 + qty20;


            //        Label lblC = (Label)e.Row.FindControl("lblC");
            //        float qty22 = Convert.ToSingle(lblC.Text);
            //        total22 = total22 + qty22;
            //        Label lblT23 = (Label)e.Row.FindControl("lblNoWorks");
            //        float qty23 = Convert.ToSingle(lblT23.Text);
            //        total23 = total23 + qty23;
            //        Label lblP = (Label)e.Row.FindControl("lblP");
            //        float qty25 = Convert.ToSingle(lblP.Text);
            //        total25 = total25 + qty25;
            //        Label lblNS = (Label)e.Row.FindControl("lblNS");
            //        float qty26 = Convert.ToSingle(lblNS.Text);
            //        total26 = total26 + qty26;
            //        Label lblIncomplete = (Label)e.Row.FindControl("lblIncomplete");
            //        float qty27 = Convert.ToSingle(lblIncomplete.Text);
            //        total27 = total27 + qty27;
            //        Label lblTenderStage = (Label)e.Row.FindControl("lblTenderStage");
            //        float qty28 = Convert.ToSingle(lblTenderStage.Text);
            //        total28 = total28 + qty28;




            //    }
            //    if (e.Row.RowType == DataControlRowType.Footer)
            //    {
            //        /* Latest*/
            //        Label lblExpMar = (Label)e.Row.FindControl("lblTotalExpMar");
            //        lblExpMar.Text = total2.ToString();
            //        Label lblMarProvi = (Label)e.Row.FindControl("lblTotalMarProvi");
            //        lblMarProvi.Text = total4.ToString();
            //        Label lblExp9 = (Label)e.Row.FindControl("lblTotalexp9");
            //        lblExp9.Text = total8.ToString();
            //        Label lblDemnd = (Label)e.Row.FindControl("lblTotalDemnd1");
            //        lblDemnd.Text = total9.ToString();
            //        Label lblNoRoadWorks = (Label)e.Row.FindControl("lblTotalRoadWorks");
            //        lblNoRoadWorks.Text = total10.ToString();
            //        Label lblNoBridgeWorks = (Label)e.Row.FindControl("lblTotalNoBridgeWorks");
            //        lblNoBridgeWorks.Text = total11.ToString();
            //        Label lblCntWBMI = (Label)e.Row.FindControl("lblTotalWBMIKm");
            //        lblCntWBMI.Text = total12.ToString();
            //        Label lblCntWBMII = (Label)e.Row.FindControl("lblTotalWBMIIKm");
            //        lblCntWBMII.Text = total13.ToString();
            //        Label lblCntWBMIII = (Label)e.Row.FindControl("lblTotalWBMIIIKm");
            //        lblCntWBMIII.Text = total14.ToString();
            //        Label lblSurfaceDressing = (Label)e.Row.FindControl("lblTotalSurfaceDressingKm");
            //        lblSurfaceDressing.Text = total15.ToString();
            //        Label lblCntBBMKm = (Label)e.Row.FindControl("lblTotalBBMKm");
            //        lblCntBBMKm.Text = total16.ToString();
            //        Label lblCntCarpetKm = (Label)e.Row.FindControl("lblTotalCarpetKm");
            //        lblCntCarpetKm.Text = total17.ToString();
            //        Label lblCntCDwork = (Label)e.Row.FindControl("lblTotalCDwork");
            //        lblCntCDwork.Text = total18.ToString();
            //        Label lblCntPCRpending = (Label)e.Row.FindControl("lblTotalPCRpending");
            //        lblCntPCRpending.Text = total19.ToString();
            //        Label lblCntPCRSubmitted = (Label)e.Row.FindControl("lblTotalPCRSubmitted");
            //        lblCntPCRSubmitted.Text = total20.ToString();

            //        Label lblC = (Label)e.Row.FindControl("lblSadhyasisthC1");
            //        lblC.Text = total22.ToString();
            //        Label lblNoWorks = (Label)e.Row.FindControl("lblTotalNoWorks");
            //        lblNoWorks.Text = total23.ToString();
            //        Label lblP = (Label)e.Row.FindControl("lblSadhyasisthP1");
            //        lblP.Text = total25.ToString();
            //        Label lblNS = (Label)e.Row.FindControl("lblSadhyasisthNS1");
            //        lblNS.Text = total26.ToString();
            //        Label lblIncomplete = (Label)e.Row.FindControl("lblSadhyasisthIncomplete1");
            //        lblIncomplete.Text = total27.ToString();
            //        Label lblTenderStage = (Label)e.Row.FindControl("lblSadhyasisthTenderStage1");
            //        lblTenderStage.Text = total28.ToString();


            //    }

            //}


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