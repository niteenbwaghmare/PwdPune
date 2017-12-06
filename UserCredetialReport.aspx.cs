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
    public partial class UserCredetialReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        string query = "SELECT ID,[UserName],[UserId],[loginDate],[loginTime],[SystemName],[SystemIpAddress],[SystemMacAddress],[BrowserType],[BrowserName],[BrowserPlatform] from [UserCredintiall]";
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
            GridUserCred.DataSource = null;
            GridUserCred.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            sda = new SqlDataAdapter(query, con);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridUserCred.DataSource = dt;
                GridUserCred.DataBind();
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridUserCred.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
           

        }

        protected void btnSeacrchDate_Click(object sender, EventArgs e)
        {
            DateTime dos = DateTime.Parse(txtDate.Text.Trim());
            string searchdate = dos.ToString("dd/MM/yyyy");
            GridUserCred.DataSource = null;
            GridUserCred.DataBind();
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            query =query+"  where convert(date,[loginDate],105)=convert(date,'" + searchdate + "',105)";
            sda = new SqlDataAdapter(query, con);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridUserCred.DataSource = dt;
                GridUserCred.DataBind();
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridUserCred.ClientID + "', 750, 100 , 100 ,false); </script>", false);
            }
        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            Grid_Bind();
        }

    }
}