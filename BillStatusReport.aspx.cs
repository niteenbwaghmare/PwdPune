using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Web.Script.Services;


namespace PWdEEBudget
{
    public partial class BillStatusReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        SqlDataAdapter da;

       
        string strcmd = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {


            //BindGrid();
            if (!Page.IsPostBack)
            {
                BindBudgetYear();
            }

        }

        protected void BindBudgetYear()
        {
            strcmd = "SELECT distinct[BudgetYear]as 'Year' FROM [tbl_Bill_Status]where[BudgetYear]!='' ";

            da = new SqlDataAdapter(strcmd, con);
            if (con.State != ConnectionState.Open)
                con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlArthYear.DataSource = ds;
            ddlArthYear.DataTextField = "Year";
            ddlArthYear.DataBind();
            ddlArthYear.Items.Insert(0, new ListItem("निवडा", "0"));
        }



        protected void BindGrid(string Wherecondition)
        {
            strcmd = "SELECT [HeadType]as 'HeadName', [Work_Id]as 'WorkId',[WorkName]as'Work Name',[Santion_Date]as'Sanction Date',[Kamachi_Mudat]as 'Work Validity',[KamPurn_Date]as'Work Complition Date',[Bill_1_To]+',  '+[BIll_To_Mob]as'Bill To Contractor',[Bill_By_Post]+',  '+[Bill_1_By]+',  '+[Bill_By_Mob]as'Bill By',[AA_Cost]as 'AACost' ";

            if (Wherecondition == "HeadType")
            {
                strcmd += ",[Bill_1_Amt]as'1st Bill Amt',[Bill_1_Date]as'1st Bill Date',[Bill_2_Amt]as'2nd Bill Amt',[Bill_2_Date]as '2nd Bill Date',[Bill_3_Amt]as'3rd Bill Amt',[Bill_3_Date]as'3rd Bill Date',[Bill_4_Amt]as'4th Bill Amt',[Bill_4_Date]as'4th Bill Date',[Bill_5_Amt]as '5th Bill Amt',[Bill_5_Date]as'5th Bill Date',[Bill_6_Amt]as'6th Bill Amt',[Bill_6_Date]as'6th Bill date',[Bill_7_Amt]as'7th Bill Amt',[Bill_7_Date]as'7th Bill Date',[Bill_8_Amt]as'8th Bill Amt',[Bill_8_Date]as'8th Bill Date',[Bill_9_Amt]as'9th Bill Amt',[Bill_9_Date]as'9th Bill Date',[Bill_final_Amt]as'Final Bill Amt',[Bill_final_Date]as'Final Bill Date',[Bill_Total]as' Bill Total'  FROM [tbl_Bill_Status] Where [HeadType]='" + ddlHeadName.SelectedItem.Text + "' and [BudgetYear]='" + ddlArthYear.SelectedItem.Text + "' order by [HeadType]";
            }
            else if (Wherecondition == "BillNo" && ddlBillType.SelectedItem.Text != "निवडा")
            {
                string[] str = new string[5];
                str = ddlBillType.SelectedItem.Value.Split('[', ']');
                if (ddlHeadName.SelectedItem.Text != "निवडा")
                {


                    strcmd += ddlBillType.SelectedItem.Value + "FROM [tbl_Bill_Status] Where [HeadType]='" + ddlHeadName.SelectedItem.Text + "' and [BudgetYear]='" + ddlArthYear.SelectedItem.Text + "' and " + str[1] + " > 0 order by [HeadType]";
                }
                else
                {
                    strcmd += ddlBillType.SelectedItem.Value + "FROM [tbl_Bill_Status] Where [BudgetYear]='" + ddlArthYear.SelectedItem.Text + "'  and " + str[1] + " > 0 order by [HeadType]";
                }
            }
            else
            {
                strcmd += ",[Bill_1_Amt]as'1st Bill Amt',[Bill_1_Date]as'1st Bill Date',[Bill_2_Amt]as'2nd Bill Amt',[Bill_2_Date]as '2nd Bill Date',[Bill_3_Amt]as'3rd Bill Amt',[Bill_3_Date]as'3rd Bill Date',[Bill_4_Amt]as'4th Bill Amt',[Bill_4_Date]as'4th Bill Date',[Bill_5_Amt]as '5th Bill Amt',[Bill_5_Date]as'5th Bill Date',[Bill_6_Amt]as'6th Bill Amt',[Bill_6_Date]as'6th Bill date',[Bill_7_Amt]as'7th Bill Amt',[Bill_7_Date]as'7th Bill Date',[Bill_8_Amt]as'8th Bill Amt',[Bill_8_Date]as'8th Bill Date',[Bill_9_Amt]as'9th Bill Amt',[Bill_9_Date]as'9th Bill Date',[Bill_final_Amt]as'Final Bill Amt',[Bill_final_Date]as'Final Bill Date',[Bill_Total]as' Bill Total'  FROM [tbl_Bill_Status] Where [BudgetYear]='" + ddlArthYear.SelectedItem.Text + "' order by [HeadType]";
            }
            GridViewHelper helper = new GridViewHelper(this.GridView1);
            string[] cols = new string[2];
            cols[0] = "HeadName";
            cols[1] = "AACost";
            helper.RegisterGroup("HeadName", true, true);
            helper.ApplyGroupSort();

            if (con.State != ConnectionState.Open)
                con.Open();
            da = new SqlDataAdapter(strcmd, con);
            DataSet ds = new DataSet();
            GridView1.AllowSorting = false;
            da.Fill(ds);
            GridView1.DataSource = ds;

            GridView1.DataBind();

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            // e.SortExpression = null;
        }
        protected void btnArthYear_Click(object sender, EventArgs e)
        {
            BindGrid("");
        }
        protected void btnHeadName_Click(object sender, EventArgs e)
        {
            BindGrid("HeadType");
        }
        protected void btnBillType_Click(object sender, EventArgs e)
        {
            BindGrid("BillNo");

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView1.AllowSorting = false;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnImgExcel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=BillStatus" + DateTime.Now + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //this.BindGrid(SortField);
                lbl.Font.Name = "Times New Roman";
                lbl.BackColor = Color.Transparent;
                lbl.RenderControl(hw);
                Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase));
                Response.Flush();
                Response.End();
            }


        }
        
        public void DownloadExcel1()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=BillStatus" + DateTime.Now + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //this.BindGrid(SortField);
                lbl.Font.Name = "Times New Roman";
                lbl.BackColor = Color.Transparent;
                lbl.RenderControl(hw);
                Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase));
                Response.Flush();
                Response.End();
            }
        }
       
        [WebMethod]
        [ScriptMethod]
        public static void DownloadExcel()
        {
            
            BillStatusReport obj = new BillStatusReport();
            obj.DownloadExcel1();
          
        }
    }
}
        