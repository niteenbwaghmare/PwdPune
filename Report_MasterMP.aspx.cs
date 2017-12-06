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
    public partial class Report_MasterMP : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        float total;
        string Work;
        float total1, total2, total3, total4, total5, total6, total7, total8, total9, total10, total11, total12, total13, total14, total15, total16, total17, total18, total19, total20, total21, total22, total23, total24, total25, total26, total27;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Year();
                Khasdar();
            }
        }

        public void Year()
        {
            ddlArthsankalpiyYear.Items.Clear();
            ddlArthsankalpiyYear.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select DISTINCT Arthsankalpiyyear from [MPProvision]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlArthsankalpiyYear.Items.Add(dr["Arthsankalpiyyear"].ToString());
            }

        }
        public void Khasdar()
        {
            ddlKhasdar.Items.Clear();
            ddlKhasdar.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select distinct [KhasdaracheName] from [BudgetMasterMP] ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlKhasdar.Items.Add(dr["KhasdaracheName"].ToString());
            }
            ddlKhasdar.Items.Add("संपूर्ण");
        }

        //public void KhasdarReport()
        //{
        //    if (ddlKhasdar.SelectedItem.Text == "संपूर्ण")
        //    {
        //        SqlDataAdapter sda = new SqlDataAdapter("select BM.WorkId as WorkID,count(BM.[PageNo]) as 'एकूण कामे',BM.[Arthsankalpiyyear] as 'वर्ष',sum(cast(BM.[PrashaskiyAmt] as decimal(18,2))) as 'प्र.मा.किंमत रु लक्ष',sum(cast(BM.[TrantrikAmt] as decimal(18,2))) as 'ता.मा.किंमत रु लक्ष',sum(cast(BM.NividaAmt as decimal(18,2))) as 'निविदा किंमत',sum (MP.[MarchEndingExpn] ) as 'वर्ष २०१५-२०१६ मधील उपलब्ध अनुदान लक्ष',sum (MP.[Chalukharch]) as 'वर्ष मधील चालू महिन्या अखेर',sum (MP.[AkunAnudan]) as 'एकूण उपलब्ध अनुदान',sum (MP.[Magilkharch]) as 'वर्ष मधील चालू महिन्या',sum (MP.[AikunKharch]) as 'एकूण खर्च',sum(MP.[Magni]) as '२०१६-२०१७ मागणी रु खर्च'from [BudgetMasterMP]as BM join [MPProvision] as MP on BM.[WorkId]=MP.[WorkId] where MP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BM.[Arthsankalpiyyear],BM.WorkId", con);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();
        //        Session["Report_MasterMP"] = GridView1;

        //    }
        //    else
        //    {
        //        SqlDataAdapter sda = new SqlDataAdapter("select BM.WorkId as WorkID, count(BM.[PageNo]) as 'एकूण कामे',BM.[Arthsankalpiyyear] as 'वर्ष',sum(cast(BM.[PrashaskiyAmt] as decimal(18,2))) as 'प्र.मा.किंमत रु लक्ष',sum(cast(BM.[TrantrikAmt] as decimal(18,2))) as 'ता.मा.किंमत रु लक्ष',sum(cast(BM.NividaAmt as decimal(18,2))) as 'निविदा किंमत',sum (MP.[MarchEndingExpn] ) as 'वर्ष २०१५-२०१६ मधील उपलब्ध अनुदान लक्ष',sum (MP.[Chalukharch]) as 'वर्ष मधील चालू महिन्या अखेर',sum (MP.[AkunAnudan]) as 'एकूण उपलब्ध अनुदान',sum (MP.[Magilkharch]) as 'वर्ष मधील चालू महिन्या',sum (MP.[AikunKharch]) as 'एकूण खर्च',sum(MP.[Magni]) as '२०१६-२०१७ मागणी रु खर्च'from [BudgetMasterMP]as BM join [MPProvision] as MP on BM.[WorkId]=MP.[WorkId] where MP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BM.khasdarachename=N'" + ddlKhasdar.SelectedItem.ToString() + "' group by BM.[Arthsankalpiyyear],BM.WorkId", con);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();
        //        Session["Report_MasterMP"] = GridView1;
        //    }
        public void KhasdarReport()
        {

            if (ddlKhasdar.SelectedItem.Text == "संपूर्ण")
            {


                SqlDataAdapter sda = new SqlDataAdapter("select BR.[KhasdaracheName] as 'MPName',BR.Upvibhag AS 'Division',count(BR.PageNo)as 'PageNo',BR.Arthsankalpiyyear as 'Arthsankalpiyyear',sum(cast(BR.[PrashaskiyAmt] as decimal(18,2))) as 'PrashaskiyAmt',sum(cast(BR.[TrantrikAmt] as decimal(18,2))) as 'TrantrikAmt',sum(cast(BR.NividaAmt as decimal(18,2))) as 'NividaAmt',sum(RP.MarchEndingExpn)as 'MarchEndingExpn',sum (RP.[Chalukharch]) as 'Chalukharch',sum (RP.[AkunAnudan]) as 'AkunAnudan',sum (RP.[Magilkharch]) as 'Magilkharch',sum (RP.[AikunKharch]) as 'AikunKharch',sum(RP.[Magni]) as 'Magni',sum(RP.[Apr]) as 'Apr',sum(RP.[May]) as 'May',sum(RP.[Jun]) as 'Jun',sum(RP.[Jul]) as 'Jul',sum(RP.[Aug]) as 'Aug',sum(RP.[Sep]) as 'Sep',sum(RP.[Oct]) as 'Oct',sum(RP.[Nov]) as 'Nov',sum(RP.[Dec]) as 'Dec',sum(RP.[Jan]) as 'Jan',sum(RP.[Feb]) as 'Feb',sum(RP.[Mar]) as 'Mar',sum(Jan+Feb+Mar+Apr+May+Jun+Jul+Aug+Sep+Oct+Nov+Dec) as 'Total' from BudgetMasterMP as BR join MPProvision as RP on BR.WorkId=RP.WorkId where RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' group by BR.[KhasdaracheName],BR.Arthsankalpiyyear,BR.Upvibhag", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session["Report_MasterMP"] = GridView1;

            }
            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("select BR.[KhasdaracheName] as 'MPName',BR.Upvibhag AS 'Division',count(BR.PageNo)as 'PageNo',BR.Arthsankalpiyyear as 'Arthsankalpiyyear',sum(cast(BR.[PrashaskiyAmt] as decimal(18,2))) as 'PrashaskiyAmt',sum(cast(BR.[TrantrikAmt] as decimal(18,2))) as 'TrantrikAmt',sum(cast(BR.NividaAmt as decimal(18,2))) as 'NividaAmt',sum(RP.MarchEndingExpn)as 'MarchEndingExpn',sum (RP.[Chalukharch]) as 'Chalukharch',sum (RP.[AkunAnudan]) as 'AkunAnudan',sum (RP.[Magilkharch]) as 'Magilkharch',sum (RP.[AikunKharch]) as 'AikunKharch',sum(RP.[Magni]) as 'Magni',sum(RP.[Apr]) as 'Apr',sum(RP.[May]) as 'May',sum(RP.[Jun]) as 'Jun',sum(RP.[Jul]) as 'Jul',sum(RP.[Aug]) as 'Aug',sum(RP.[Sep]) as 'Sep',sum(RP.[Oct]) as 'Oct',sum(RP.[Nov]) as 'Nov',sum(RP.[Dec]) as 'Dec',sum(RP.[Jan]) as 'Jan',sum(RP.[Feb]) as 'Feb',sum(RP.[Mar]) as 'Mar',sum(Jan+Feb+Mar+Apr+May+Jun+Jul+Aug+Sep+Oct+Nov+Dec) as 'Total' from BudgetMasterMP as BR join MPProvision as RP on BR.WorkId=RP.WorkId where RP.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.ToString() + "' and BR.khasdarachename=N'" + ddlKhasdar.SelectedItem.ToString() + "' group by BR.[KhasdaracheName],BR.Arthsankalpiyyear,BR.Upvibhag", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session["Report_MasterMP"] = GridView1;
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', auto, 100 , 100 ,true); </script>", false);
            if (ddlKhasdar.SelectedItem.ToString() != null || ddlKhasdar.SelectedItem.ToString() != "निवडा")
            {
                lblPrintKhasdar.Text = "खासदार : " + ddlKhasdar.SelectedItem.ToString();
            }

            if (ddlArthsankalpiyYear.SelectedItem.ToString() != null || ddlArthsankalpiyYear.SelectedItem.ToString() != "निवडा")
            {
                lblPrintArthSanalpYr.Text = "अर्थसंकल्पीय वर्ष : " + ddlArthsankalpiyYear.SelectedItem.ToString();
            }

        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                //    ((Label)e.Row.FindControl("lblAnudan")).Text = "वर्ष" + ddlArthsankalpiyYear.SelectedItem.Text + "मधील उपलब्ध अनुदान लक्ष";
                //    ((Label)e.Row.FindControl("lblMahinaAkher")).Text = "वर्ष" + ddlArthsankalpiyYear.SelectedItem.Text + "मधील चालू महिन्या अखेर";
                //    ((Label)e.Row.FindControl("lblKhrchLaksh")).Text = "वर्ष" + ddlArthsankalpiyYear.SelectedItem.Text + "मधील चालू महिन्या (६/२०१६) अखेर खर्च लक्ष";
                //    ((Label)e.Row.FindControl("lblMagniKhrch")).Text = ddlArthsankalpiyYear.SelectedItem.Text + "मागणी रु खर्च";

            }
            ////if (e.Row.RowType == DataControlRowType.DataRow)
            ////{
            ////    Work = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
            ////}
            if (ddlKhasdar.SelectedItem.Text != "संपूर्ण")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblC = (Label)e.Row.FindControl("lblC");
                    Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                    Label Arthsankalpiyyear = (Label)e.Row.FindControl("lblyear");
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT [Sadyasthiti],isnull(COUNT([Sadyasthiti]),0) as cnt FROM BudgetMasterMP WHERE Upvibhag=N'" + lbllupvibhag.Text + "' and Arthsankalpiyyear=N'" + Arthsankalpiyyear.Text + "' And khasdarachename=N'" + ddlKhasdar.SelectedItem.ToString() + "' AND Sadyasthiti='Completed' group by [Sadyasthiti]", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblC.Text = dr["cnt"].ToString();

                    }

                    Label lblP = (Label)e.Row.FindControl("lblP");

                    SqlDataAdapter sda1 = new SqlDataAdapter("SELECT [Sadyasthiti],isnull(COUNT([Sadyasthiti]),0) as cntp FROM BudgetMasterMP WHERE Upvibhag=N'" + lbllupvibhag.Text + "' and Arthsankalpiyyear=N'" + Arthsankalpiyyear.Text + "' And khasdarachename=N'" + ddlKhasdar.SelectedItem.ToString() + "' AND Sadyasthiti='Processing' group by [Sadyasthiti]", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        lblP.Text = dr1["cntp"].ToString();

                    }

                    Label lblNStar = (Label)e.Row.FindControl("lblNS");

                    SqlDataAdapter sda2 = new SqlDataAdapter("SELECT [Sadyasthiti],isnull(COUNT([Sadyasthiti]),0) as cnts FROM BudgetMasterMP WHERE Upvibhag=N'" + lbllupvibhag.Text + "' and Arthsankalpiyyear=N'" + Arthsankalpiyyear.Text + "' And khasdarachename=N'" + ddlKhasdar.SelectedItem.ToString() + "' AND Sadyasthiti='Not Started' group by [Sadyasthiti]", con);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        lblNStar.Text = dr2["cnts"].ToString();

                    }


                    Label lblAdd = (Label)e.Row.FindControl("lblAdd");
                    lblAdd.Text = (Convert.ToInt32(lblP.Text) + Convert.ToInt32(lblC.Text) + Convert.ToInt32(lblNStar.Text)).ToString();

                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblC = (Label)e.Row.FindControl("lblC");
                    Label lbllupvibhag = (Label)e.Row.FindControl("lbllupvibhag");
                    Label lblMPName = (Label)e.Row.FindControl("lblMPName");
                    Label Arthsankalpiyyear = (Label)e.Row.FindControl("lblyear");
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT [Sadyasthiti],isnull(COUNT([Sadyasthiti]),0) as cnt FROM BudgetMasterMP WHERE Upvibhag=N'" + lbllupvibhag.Text + "' and Arthsankalpiyyear=N'" + Arthsankalpiyyear.Text + "' And khasdarachename=N'" + lblMPName.Text + "' AND  Sadyasthiti='Completed' group by [Sadyasthiti]", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblC.Text = dr["cnt"].ToString();

                    }

                    Label lblP = (Label)e.Row.FindControl("lblP");

                    SqlDataAdapter sda1 = new SqlDataAdapter("SELECT [Sadyasthiti],isnull(COUNT([Sadyasthiti]),0) as cntp FROM BudgetMasterMP WHERE Upvibhag=N'" + lbllupvibhag.Text + "' and Arthsankalpiyyear=N'" + Arthsankalpiyyear.Text + "' And khasdarachename=N'" + lblMPName.Text + "' AND Sadyasthiti='Processing' group by [Sadyasthiti]", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        lblP.Text = dr1["cntp"].ToString();

                    }

                    Label lblNStar = (Label)e.Row.FindControl("lblNS");

                    SqlDataAdapter sda2 = new SqlDataAdapter("SELECT [Sadyasthiti],isnull(COUNT([Sadyasthiti]),0) as cnts FROM BudgetMasterMP WHERE Upvibhag=N'" + lbllupvibhag.Text + "' and Arthsankalpiyyear=N'" + Arthsankalpiyyear.Text + "' And khasdarachename=N'" + lblMPName.Text + "' AND Sadyasthiti='Not Started' group by [Sadyasthiti]", con);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        lblNStar.Text = dr2["cnts"].ToString();

                    }


                    Label lblAdd = (Label)e.Row.FindControl("lblAdd");
                    lblAdd.Text = (Convert.ToInt32(lblC.Text) + Convert.ToInt32(lblNStar.Text) + Convert.ToInt32(lblP.Text)).ToString();

                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblT1 = (Label)e.Row.FindControl("lblNoWorks");
                float qty1 = Convert.ToSingle(lblT1.Text);
                total1 = total1 + qty1;
                Label lblT2 = (Label)e.Row.FindControl("lblPrashAmt");
                float qty2 = Convert.ToSingle(lblT2.Text);
                total2 = total2 + qty2;
                Label lblT3 = (Label)e.Row.FindControl("lblTantriAmt");
                float qty3 = Convert.ToSingle(lblT3.Text);
                total3 = total3 + qty3;
                Label lblT4 = (Label)e.Row.FindControl("lblNividaAmt");
                float qty4 = Convert.ToSingle(lblT4.Text);
                total4 = total4 + qty4;
                //Label lblT5 = (Label)e.Row.FindControl("lbljulProvi");
                //float qty5 = Convert.ToSingle(lblT5.Text);
                //total5 = total5 + qty5;
                //Label lblT6 = (Label)e.Row.FindControl("lblTotal");
                //float qty6 = Convert.ToSingle(lblT6.Text);
                //total6 = total6 + qty6;
                Label lblT7 = (Label)e.Row.FindControl("lblMarProvi");
                float qty7 = Convert.ToSingle(lblT7.Text);
                total7 = total7 + qty7;
                Label lblT8 = (Label)e.Row.FindControl("lblRelessed");
                float qty8 = Convert.ToSingle(lblT8.Text);
                total8 = total8 + qty8;
                Label lblT9 = (Label)e.Row.FindControl("lblExp9");
                float qty9 = Convert.ToSingle(lblT9.Text);
                total9 = total9 + qty9;
                Label lblT10 = (Label)e.Row.FindControl("lblDemnd");
                float qty10 = Convert.ToSingle(lblT10.Text);
                total10 = total10 + qty10;
                Label lblT11 = (Label)e.Row.FindControl("lblAkunKarch");
                float qty11 = Convert.ToSingle(lblT11.Text);
                total11 = total11 + qty11;
                Label lblT12 = (Label)e.Row.FindControl("lblMagni");
                float qty12 = Convert.ToSingle(lblT12.Text);
                total12 = total12 + qty12;

                Label lblT5 = (Label)e.Row.FindControl("lblApr");
                float qty5 = Convert.ToSingle(lblT5.Text);
                total5 = total5 + qty5;
                Label lblT6 = (Label)e.Row.FindControl("lblMay");
                float qty6 = Convert.ToSingle(lblT6.Text);
                total6 = total6 + qty6;
                Label lblT23 = (Label)e.Row.FindControl("lblJun");
                float qty23 = Convert.ToSingle(lblT23.Text);
                total23 = total23 + qty23;
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

                Label lblT27 = (Label)e.Row.FindControl("lblTotal");
                float qty27 = Convert.ToSingle(lblT27.Text);
                total27 = total27 + qty27;

                Label lblC = (Label)e.Row.FindControl("lblC");
                float qty22 = Convert.ToSingle(lblC.Text);
                total22 = total22 + qty22;


                Label lblP = (Label)e.Row.FindControl("lblP");
                float qty25 = Convert.ToSingle(lblP.Text);
                total25 = total25 + qty25;
                Label lblNS = (Label)e.Row.FindControl("lblNS");
                float qty26 = Convert.ToSingle(lblNS.Text);
                total26 = total26 + qty26;

                Label lblAdd = (Label)e.Row.FindControl("lblAdd");
                float qty24 = Convert.ToSingle(lblAdd.Text);
                total24 = total24 + qty24;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblNoWorks = (Label)e.Row.FindControl("lblTotalNoWorks");
                lblNoWorks.Text = total1.ToString();
                Label lblPrashAmt = (Label)e.Row.FindControl("lblTotalPrashAmt");
                lblPrashAmt.Text = total2.ToString();
                Label lblTantriAmt = (Label)e.Row.FindControl("lblTotalTantriAmt");
                lblTantriAmt.Text = total3.ToString();
                Label lblNividaAmt = (Label)e.Row.FindControl("lblTotalNividaAmt");
                lblNividaAmt.Text = total4.ToString();
                //Label lbljulProvi = (Label)e.Row.FindControl("lblTotaljulProvi");
                //lbljulProvi.Text = total5.ToString();
                //Label lblTotal = (Label)e.Row.FindControl("lblTotalTotal");
                //lblTotal.Text = total6.ToString();
                Label lblMarProvi = (Label)e.Row.FindControl("lblTotalMarProvi");
                lblMarProvi.Text = total7.ToString();
                Label lblRelessed = (Label)e.Row.FindControl("lblTotalRelessed");
                lblRelessed.Text = total8.ToString();
                Label lblExp9 = (Label)e.Row.FindControl("lblTotalexp9");
                lblExp9.Text = total9.ToString();
                Label lblDemnd = (Label)e.Row.FindControl("lblTotalDemnd1");
                lblDemnd.Text = total10.ToString();
                Label lblAkunKarch = (Label)e.Row.FindControl("lblTotalAkunKarch");
                lblAkunKarch.Text = total11.ToString();
                Label lblMagni = (Label)e.Row.FindControl("lblTotalMagni");
                lblMagni.Text = total12.ToString();


                Label lblApr = (Label)e.Row.FindControl("lblTotalApr");
                lblApr.Text = total5.ToString();
                Label lblMay = (Label)e.Row.FindControl("lblTotalMay");
                lblMay.Text = total6.ToString();
                Label lblJun = (Label)e.Row.FindControl("lblTotalJun");
                lblJun.Text = total23.ToString();
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
                Label lblTotal = (Label)e.Row.FindControl("lblTotalTotal");
                lblTotal.Text = total27.ToString();

                Label lblC = (Label)e.Row.FindControl("lblSadhyasisthC1");
                lblC.Text = total22.ToString();

                Label lblP = (Label)e.Row.FindControl("lblSadhyasisthP1");
                lblP.Text = total25.ToString();
                Label lblNS = (Label)e.Row.FindControl("lblSadhyasisthNS1");
                lblNS.Text = total26.ToString();

                Label lblAdd = (Label)e.Row.FindControl("lblAddTotal");
                lblAdd.Text = total24.ToString();
            }

        }


        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "MP_Abstract_Report.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            KhasdarReport();
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
            GridView1.DataBind();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendMail.aspx");
        }

        protected void ReportTypebtn_Click(object sender, EventArgs e)
        {
            KhasdarReport();
            System.Threading.Thread.Sleep(5000);
        }

        //protected void ArthsankalpiyYearbtn_Click(object sender, EventArgs e)
        //{
        //    Khasdar();
        //}



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

        protected void btnPrint_Click1(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "key", "PrintGridData()", true);
            KhasdarReport();
        }
    }
}