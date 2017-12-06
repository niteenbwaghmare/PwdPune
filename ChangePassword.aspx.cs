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
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataSet ds = null;
        string strSqlCommand = string.Empty;
        string currPassword = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            if (con.State != ConnectionState.Open)
                con.Open();
            if (!Page.IsPostBack)
            {
                getPassword();
            }
        }
        protected void page_preinit(object sender, EventArgs e)
        {
            if (!IsPostBack || Request.QueryString["PrevMPage"] == "ImageUpload" || Request.QueryString["PrevMPage"] == "Admin" || Request.QueryString["PrevMPage"] == "Contractor" || Request.QueryString["PrevMPage"] == "SubDivision" || Request.QueryString["PrevMPage"] == "MPMLA")
            {

                if (Request.QueryString["PrevMPage"] != null)
                {
                    string PrevMPage = Request.QueryString["PrevMPage"].ToString();
                    if (PrevMPage == "ImageUpload")
                    {
                        Page.MasterPageFile = "~/ImageUpload.Master";
                    }
                    else if (PrevMPage == "Admin")
                    {
                        Page.MasterPageFile = "~/Admin.Master";
                    }
                    else if (PrevMPage == "Contractor")
                    {
                        Page.MasterPageFile = "~/Contractor.Master";
                    }
                    else if (PrevMPage == "SubDivision")
                    {
                        Page.MasterPageFile = "~/SubDivision.Master";
                    }
                    else if (PrevMPage == "MPMLA")
                    {
                        Page.MasterPageFile = "~/MPMLA.Master";
                    }
                    else
                    {
                        Page.MasterPageFile = "~/SuperAdmin.Master";
                    }
                }
            }
        }
        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            if ((txtNewPass.Text != "") && (txtReEnterPass.Text != "") && (txtNewPass.Text == txtReEnterPass.Text))
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string userId = Session["id"].ToString();
                strSqlCommand = "update SCreateAdmin set Password= '" + txtReEnterPass.Text.Trim() + "' where UserId='" + userId.ToString() + "'";
                cmd = new SqlCommand(strSqlCommand, con);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                { lblStatus.Text = "Password Changed successfully!!!"; }
                else
                { lblStatus.Text = "Password Not Changed!!!"; }
            }
            else
            {
                if ((txtNewPass.Text == "") || (txtReEnterPass.Text == ""))
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Please enter password.')</script>");
                }
                else if ((txtNewPass.Text != txtReEnterPass.Text))
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Password didn't matched...!')</script>");
                }
            }
        }

        public void getPassword()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select Password from SCreateAdmin where UserId ='" + Session["id"].ToString() + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        //currPassword = dr[0].ToString();
                        ViewState["currPassword"] = dr[0].ToString();
                        //if (dr[0].ToString() == psw.Text.Trim())
                        //{
                        //    txtNewPass.Enabled = true;
                        //    txtReEnterPass.Enabled = true;
                        //}
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Password...! Please enter valid password.')</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void psw_TextChanged(object sender, EventArgs e)
        {
            if (ViewState["currPassword"].ToString() == psw.Text.ToString())
            {
                txtNewPass.Enabled = true;
                txtReEnterPass.Enabled = true;
                btnChangePass.Enabled = true;
                psw.Text = ViewState["currPassword"].ToString();
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Password...! Please enter valid password.')</script>");
            }
        }
    }
}