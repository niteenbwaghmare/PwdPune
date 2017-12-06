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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Drawing;


namespace PWdEEBudget
{
    public partial class Report_MasterGAT_D : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        float total;
        string Work;
        float total22, total23, total24, total25, total26, total27;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Year();
                subtype();
                kamacheYear();
            }
        }
        public void kamacheYear()
        {

            ddlKamacheYr.Items.Clear();
            ddlKamacheYr.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from BudgetMasterGAT_D", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlKamacheYr.Items.Add(dr[0].ToString());
            }
            ddlKamacheYr.Items.Add("संपूर्ण");
        }
        public void Year()
        {
            ddlArthsankalpiyYear.Items.Clear();
            ddlArthsankalpiyYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from GAT_DProvision", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlArthsankalpiyYear.Items.Add(dr[0].ToString());
            }
            //ddlArthsankalpiyYear.Items.Add("संपूर्ण");
        }
        public void subtype()
        {
            ddlReportType.Items.Clear();
            ddlReportType.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Upvibhag from BudgetMasterGAT_D ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlReportType.Items.Add(dr[0].ToString());
            }
            ddlReportType.Items.Add("संपूर्ण");
        }
        public void LekhasirshAll()
        {
            //if (ddlArthsankalpiyYear.Text != "संपूर्ण")
            //{
                if (ddlKamacheYr.Text != "संपूर्ण")
                {
                    if (ddlReportType.SelectedItem.Text == "संपूर्ण")
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select BR.Upvibhag as 'Upvibhag',count(BR.Type)as 'NoOfWorks' from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId where RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "'  group by BR.SubType,BR.LekhaShirsh,BR.Upvibhag", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterBuilding"] = GridView1;
                    }
                    else
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select BR.Upvibhag as 'Upvibhag',count(BR.Type)as 'NoOfWorks' from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId where [LekhaShirshName]=N'" + ddlReportType.SelectedItem.Text + "' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.SubType,BR.LekhaShirsh,BR.Upvibhag", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterBuilding"] = GridView1;
                    }
                }
                else
                {
                    if (ddlReportType.SelectedItem.Text == "संपूर्ण")
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select BR.Upvibhag as 'Upvibhag',count(BR.Type)as 'NoOfWorks' from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId where RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "'  group by BR.SubType,BR.LekhaShirsh,BR.Upvibhag", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterBuilding"] = GridView1;
                    }
                    else
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select BR.Upvibhag as 'Upvibhag',count(BR.Type)as 'NoOfWorks' from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId where [LekhaShirshName]=N'" + ddlReportType.SelectedItem.Text + "' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.SubType,BR.LekhaShirsh,BR.Upvibhag", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Report_MasterBuilding"] = GridView1;
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
            //}
            //else
            //{
            //    if (ddlKamacheYr.Text != "संपूर्ण")
            //    {
            //        if (ddlReportType.SelectedItem.Text == "संपूर्ण")
            //        {
            //            SqlDataAdapter sda = new SqlDataAdapter("select BR.Upvibhag as 'Upvibhag',count(BR.Type)as 'NoOfWorks' from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId where BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "'  group by BR.SubType,BR.LekhaShirsh,BR.Upvibhag", con);
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            GridView1.DataSource = dt;
            //            GridView1.DataBind();
            //            Session["Report_MasterBuilding"] = GridView1;
            //        }
            //        else
            //        {
            //            SqlDataAdapter sda = new SqlDataAdapter("select BR.Upvibhag as 'Upvibhag',count(BR.Type)as 'NoOfWorks' from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId where [LekhaShirshName]=N'" + ddlReportType.SelectedItem.Text + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.SubType,BR.LekhaShirsh,BR.Upvibhag", con);
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            GridView1.DataSource = dt;
            //            GridView1.DataBind();
            //            Session["Report_MasterBuilding"] = GridView1;
            //        }
            //    }
            //    else
            //    {
            //        if (ddlReportType.SelectedItem.Text == "संपूर्ण")
            //        {
            //            SqlDataAdapter sda = new SqlDataAdapter("select BR.Upvibhag as 'Upvibhag',count(BR.Type)as 'NoOfWorks' from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId group by BR.SubType,BR.LekhaShirsh,BR.Upvibhag", con);
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            GridView1.DataSource = dt;
            //            GridView1.DataBind();
            //            Session["Report_MasterBuilding"] = GridView1;
            //        }
            //        else
            //        {
            //            SqlDataAdapter sda = new SqlDataAdapter("select BR.Upvibhag as 'Upvibhag',count(BR.Type)as 'NoOfWorks' from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId where [LekhaShirshName]=N'" + ddlReportType.SelectedItem.Text + "' group by BR.SubType,BR.LekhaShirsh,BR.Upvibhag", con);
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            GridView1.DataSource = dt;
            //            GridView1.DataBind();
            //            Session["Report_MasterBuilding"] = GridView1;
            //        }
            //    }
            //}


            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', auto, 100 , 100 ,true); </script>", false);
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendMail.aspx");
        }




        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    Label lblUpVibhag = (Label)e.Row.FindControl("lblUpVibhag");
            //}
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

                            Label lblAStar = (Label)e.Row.FindControl("lblAStar");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt1 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId  WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'अंदाजपत्रकिय स्थर ' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblAStar.Text = dr["cnt1"].ToString();
                            }
                        }


                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNS = (Label)e.Row.FindControl("lblNS");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt2 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'निविदा स्तर' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt2"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblP = (Label)e.Row.FindControl("lblP");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt3 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'प्रगतीत' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblP.Text = dr["cnt3"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt4 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'पूर्ण' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblC.Text = dr["cnt4"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNOTS = (Label)e.Row.FindControl("lblNOTS");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt5 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'सुरू करणे' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNOTS.Text = dr["cnt5"].ToString();

                            }
                        }
                    }
                    else
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {

                            Label lblAStar = (Label)e.Row.FindControl("lblAStar");
                            Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt6 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId  WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'अंदाजपत्रकिय स्थर ' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblAStar.Text = dr["cnt6"].ToString();
                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNS = (Label)e.Row.FindControl("lblNS");
                            Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt7 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'निविदा स्तर' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt7"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblP = (Label)e.Row.FindControl("lblP");
                            Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt8 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'प्रगतीत' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblP.Text = dr["cnt8"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt9 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'पूर्ण' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblC.Text = dr["cnt9"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNOTS = (Label)e.Row.FindControl("lblNOTS");
                            Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt10 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'सुरू करणे' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNOTS.Text = dr["cnt10"].ToString();

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

                            Label lblAStar = (Label)e.Row.FindControl("lblAStar");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt11 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId  WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'अंदाजपत्रकिय स्थर ' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblAStar.Text = dr["cnt11"].ToString();
                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNS = (Label)e.Row.FindControl("lblNS");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt12 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'निविदा स्तर' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt12"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblP = (Label)e.Row.FindControl("lblP");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt13 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'प्रगतीत' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblP.Text = dr["cnt13"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt14 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'पूर्ण' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblC.Text = dr["cnt14"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNOTS = (Label)e.Row.FindControl("lblNOTS");
                            //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt15 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'सुरू करणे' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNOTS.Text = dr["cnt15"].ToString();

                            }
                        }
                    }
                    else
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {

                            Label lblAStar = (Label)e.Row.FindControl("lblAStar");
                            Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt16 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId  WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'अंदाजपत्रकिय स्थर ' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblAStar.Text = dr["cnt16"].ToString();
                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNS = (Label)e.Row.FindControl("lblNS");
                            Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt17 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'निविदा स्तर' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNS.Text = dr["cnt17"].ToString();

                            }
                        }

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblP = (Label)e.Row.FindControl("lblP");
                            Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt18 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'प्रगतीत' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblP.Text = dr["cnt18"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblC = (Label)e.Row.FindControl("lblC");
                            Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt19 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'पूर्ण' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblC.Text = dr["cnt19"].ToString();

                            }
                        }
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblNOTS = (Label)e.Row.FindControl("lblNOTS");
                            Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt20 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'सुरू करणे' and RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                lblNOTS.Text = dr["cnt20"].ToString();

                            }
                        }
                    }





                }


                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lblC = (Label)e.Row.FindControl("lblC");
                    float qty22 = Convert.ToSingle(lblC.Text);
                    total22 = total22 + qty22;

                    Label lblT23 = (Label)e.Row.FindControl("lblNoOfWorks");
                    float qty23 = Convert.ToSingle(lblT23.Text);
                    total23 = total23 + qty23;


                    Label lblP = (Label)e.Row.FindControl("lblP");
                    float qty25 = Convert.ToSingle(lblP.Text);
                    total25 = total25 + qty25;
                    Label lblNS = (Label)e.Row.FindControl("lblNS");
                    float qty26 = Convert.ToSingle(lblNS.Text);
                    total26 = total26 + qty26;

                    Label lblNOTS = (Label)e.Row.FindControl("lblNOTS");
                    float qty27 = Convert.ToSingle(lblNOTS.Text);
                    total27 = total27 + qty27;

                    Label lblAStar = (Label)e.Row.FindControl("lblAStar");
                    float qty24 = Convert.ToSingle(lblAStar.Text);
                    total24 = total24 + qty24;





                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblC = (Label)e.Row.FindControl("lblSadhyasisthC1");
                    lblC.Text = total22.ToString();
                    //Label lblNoWorks = (Label)e.Row.FindControl("lblTotalNoWorks");
                    //lblNoWorks.Text = total23.ToString();
                    //Label lblBudgetHead = (Label)e.Row.FindControl("lblTotalBudgetHead");
                    //lblBudgetHead.Text = total24.ToString();
                    Label lblP = (Label)e.Row.FindControl("lblSadhyasisthP1");
                    lblP.Text = total25.ToString();
                    Label lblNS = (Label)e.Row.FindControl("lblSadhyasisthNS1");
                    lblNS.Text = total26.ToString();
                    Label lblNOTS = (Label)e.Row.FindControl("lblSadhyasisthNOTS1");
                    lblNOTS.Text = total27.ToString();
                    Label lblAStar = (Label)e.Row.FindControl("lblSadhyasisthAstar1");
                    lblAStar.Text = total24.ToString();

                    Label lblT23 = (Label)e.Row.FindControl("lblTotalWork");
                    lblT23.Text = total23.ToString();
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

            //                Label lblAStar = (Label)e.Row.FindControl("lblAStar");
            //                //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt21 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId  WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'अंदाजपत्रकिय स्थर ' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblAStar.Text = dr["cnt21"].ToString();
            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNS = (Label)e.Row.FindControl("lblNS");
            //                //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt22 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'निविदा स्तर' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNS.Text = dr["cnt22"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblP = (Label)e.Row.FindControl("lblP");
            //                //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt23 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'प्रगतीत' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblP.Text = dr["cnt23"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblC = (Label)e.Row.FindControl("lblC");
            //                //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt24 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'पूर्ण' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblC.Text = dr["cnt24"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNOTS = (Label)e.Row.FindControl("lblNOTS");
            //                //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt25 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'सुरू करणे' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNOTS.Text = dr["cnt25"].ToString();

            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {

            //                Label lblAStar = (Label)e.Row.FindControl("lblAStar");
            //                Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt26 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId  WHERE  BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'अंदाजपत्रकिय स्थर ' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblAStar.Text = dr["cnt26"].ToString();
            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNS = (Label)e.Row.FindControl("lblNS");
            //                Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt27 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'निविदा स्तर' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNS.Text = dr["cnt27"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblP = (Label)e.Row.FindControl("lblP");
            //                Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt28 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'प्रगतीत'  and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblP.Text = dr["cnt28"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblC = (Label)e.Row.FindControl("lblC");
            //                Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt29 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'पूर्ण' and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblC.Text = dr["cnt29"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNOTS = (Label)e.Row.FindControl("lblNOTS");
            //                Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt30 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'सुरू करणे'  and BR.Arthsankalpiyyear='" + ddlKamacheYr.SelectedItem.ToString() + "' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNOTS.Text = dr["cnt30"].ToString();

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

            //                Label lblAStar = (Label)e.Row.FindControl("lblAStar");
            //                //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt31 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId  WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'अंदाजपत्रकिय स्थर ' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblAStar.Text = dr["cnt31"].ToString();
            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNS = (Label)e.Row.FindControl("lblNS");
            //                //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt32 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'निविदा स्तर' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNS.Text = dr["cnt32"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblP = (Label)e.Row.FindControl("lblP");
            //                //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt33 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'प्रगतीत' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblP.Text = dr["cnt33"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblC = (Label)e.Row.FindControl("lblC");
            //                //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt34 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "'  AND BR.Sadyasthiti=N'पूर्ण' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblC.Text = dr["cnt34"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNOTS = (Label)e.Row.FindControl("lblNOTS");
            //                //Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt35 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + ddlReportType.SelectedItem.ToString() + "' AND BR.Sadyasthiti=N'सुरू करणे' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNOTS.Text = dr["cnt35"].ToString();

            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {

            //                Label lblAStar = (Label)e.Row.FindControl("lblAStar");
            //                Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt36 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId  WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'अंदाजपत्रकिय स्थर '  group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblAStar.Text = dr["cnt36"].ToString();
            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNS = (Label)e.Row.FindControl("lblNS");
            //                Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt37 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'निविदा स्तर' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNS.Text = dr["cnt37"].ToString();

            //                }
            //            }

            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblP = (Label)e.Row.FindControl("lblP");
            //                Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt38 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'प्रगतीत'  group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblP.Text = dr["cnt38"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblC = (Label)e.Row.FindControl("lblC");
            //                Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt39 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'पूर्ण' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblC.Text = dr["cnt39"].ToString();

            //                }
            //            }
            //            if (e.Row.RowType == DataControlRowType.DataRow)
            //            {
            //                Label lblNOTS = (Label)e.Row.FindControl("lblNOTS");
            //                Label lblUpvibhag = (Label)e.Row.FindControl("lblUpvibhag");
            //                SqlDataAdapter sda = new SqlDataAdapter("SELECT BR.Sadyasthiti,isnull(COUNT(BR.Sadyasthiti),0) as cnt40 from BudgetMasterGAT_D as BR join GAT_DProvision as RP on BR.WorkId=RP.WorkId WHERE BR.Upvibhag=N'" + lblUpvibhag.Text + "' AND BR.Sadyasthiti=N'सुरू करणे' group by BR.Sadyasthiti", con);
            //                DataTable dt = new DataTable();
            //                sda.Fill(dt);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    lblNOTS.Text = dr["cnt40"].ToString();

            //                }
            //            }
            //        }

            //    }


            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {

            //        Label lblC = (Label)e.Row.FindControl("lblC");
            //        float qty22 = Convert.ToSingle(lblC.Text);
            //        total22 = total22 + qty22;

            //        Label lblT23 = (Label)e.Row.FindControl("lblNoOfWorks");
            //        float qty23 = Convert.ToSingle(lblT23.Text);
            //        total23 = total23 + qty23;


            //        Label lblP = (Label)e.Row.FindControl("lblP");
            //        float qty25 = Convert.ToSingle(lblP.Text);
            //        total25 = total25 + qty25;
            //        Label lblNS = (Label)e.Row.FindControl("lblNS");
            //        float qty26 = Convert.ToSingle(lblNS.Text);
            //        total26 = total26 + qty26;

            //        Label lblNOTS = (Label)e.Row.FindControl("lblNOTS");
            //        float qty27 = Convert.ToSingle(lblNOTS.Text);
            //        total27 = total27 + qty27;

            //        Label lblAStar = (Label)e.Row.FindControl("lblAStar");
            //        float qty24 = Convert.ToSingle(lblAStar.Text);
            //        total24 = total24 + qty24;





            //    }
            //    if (e.Row.RowType == DataControlRowType.Footer)
            //    {
            //        Label lblC = (Label)e.Row.FindControl("lblSadhyasisthC1");
            //        lblC.Text = total22.ToString();
            //        //Label lblNoWorks = (Label)e.Row.FindControl("lblTotalNoWorks");
            //        //lblNoWorks.Text = total23.ToString();
            //        //Label lblBudgetHead = (Label)e.Row.FindControl("lblTotalBudgetHead");
            //        //lblBudgetHead.Text = total24.ToString();
            //        Label lblP = (Label)e.Row.FindControl("lblSadhyasisthP1");
            //        lblP.Text = total25.ToString();
            //        Label lblNS = (Label)e.Row.FindControl("lblSadhyasisthNS1");
            //        lblNS.Text = total26.ToString();
            //        Label lblNOTS = (Label)e.Row.FindControl("lblSadhyasisthNOTS1");
            //        lblNOTS.Text = total27.ToString();
            //        Label lblAStar = (Label)e.Row.FindControl("lblSadhyasisthAstar1");
            //        lblAStar.Text = total24.ToString();

            //        Label lblT23 = (Label)e.Row.FindControl("lblTotalWork");
            //        lblT23.Text = total23.ToString();
            //    }
            //}

        }
        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "GAT_D_Abstract_Report.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            LekhasirshAll();
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


        protected void ReportTypebtn_Click(object sender, EventArgs e)
        {
            LekhasirshAll();
            System.Threading.Thread.Sleep(5000);
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
            GridView1.AllowPaging = false;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "PrintGridData()", true);
            LekhasirshAll();
        }
    }
}