using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PWdEEBudget
{
    public partial class EmailReport : System.Web.UI.Page
    {
        SqlConnection cn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataSet ds = null;

        string strSqlCommand = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

            if (!Page.IsPostBack)
            {
                ViewState["SortOn"] = "ID";
                ViewState["SortBy"] = "Asc";
                BindEmpData();
            }

        }
        void BindEmpData()
        {
            strSqlCommand = "select * from SentMailReport Order By " + ViewState["SortOn"].ToString() + " " + ViewState["SortBy"].ToString();
            da = new SqlDataAdapter(strSqlCommand, cn);
            ds = new DataSet();
            da.Fill(ds, "SentMailReport");

            GridView1.DataSource = ds.Tables["SentMailReport"];
            GridView1.DataBind();
            Session["GridData"] = GridView1;

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindEmpData();
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["SortOn"] = e.SortExpression;
            if (ViewState["SortBy"].ToString() == "Asc")
                ViewState["SortBy"] = "desc";
            else
                ViewState["SortBy"] = "Asc";
            BindEmpData();
        }
    }
}