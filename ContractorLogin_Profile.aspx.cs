using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class ContractorLogin_Profile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        int i;
        string a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    a = Session["id"].ToString();
                    imgPhoto.ImageUrl = "logo/user-icon3.png";
                    nameFetch();
                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
                Session["id"] = a;
            }
        }
        public void nameFetch()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select Name,MobileNo,Email,Post,Office,UserId,Password from [SCreateAdmin] where UserId='" + a + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                lblName.Text = dr["Name"].ToString();
                //lblName.Text = dr["MName"].ToString();
                //lblName.Text = dr["LName"].ToString();
                lblMob.Text = dr["MobileNo"].ToString();
                lblKaryalay.Text = dr["Office"].ToString();
                lblPost.Text = dr["Post"].ToString();
                lblEmail.Text = dr["Email"].ToString();
                lblUserId.Text = dr["UserId"].ToString();
                lblPassword.Text = dr["Password"].ToString();
            }
        }
    }
}