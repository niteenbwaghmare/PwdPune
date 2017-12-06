using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class AutoSMSReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    Grid_Bind();
                }

            }
        }
        public void Grid_Bind()
        {
            GridSMS.DataSource = null;
            GridSMS.DataBind();           
            DataTable dt = new DataTable();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand objcmd = new SqlCommand("[AutoSMSReport_SP]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(dt);

                if (dt.Rows.Count > 1)
                {
                    GridSMS.DataSource = dt;
                    GridSMS.DataBind();
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridSMS.ClientID + "', 750, 100 , 100 ,false); </script>", false);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        protected void GridSMS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
    }
}