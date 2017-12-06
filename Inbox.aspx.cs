using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class Inbox : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    Label1.Text = Session["id"].ToString();
                    BindGridAll();
                }

                //else if (Session["Sid"] != null)
                //{
                //    Label1.Text = Session["Sid"].ToString();
                //    BindGridAll();
                //}

                //else if (Session["Cid"] != null)
                //{
                //    Label1.Text = Session["Cid"].ToString();
                //    BindGridAll();
                //}
                //else if (Session["Aid"] != null)
                //{
                //    Label1.Text = Session["Aid"].ToString();
                //    BindGridAll();
                //}
                else
                {

                    Response.Redirect("Login.aspx");
                }
                Session["id"] = Label1.Text;
            }

        }
        public void BindGridAll()
        {
                cmd.CommandText = "select ID,Name,Post,Date,SMS from SMS";
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
          
        }
        protected void page_preinit(object sender, EventArgs e)
        {
            if (!IsPostBack || Request.QueryString["PrevMPage"] == "ImageUpload" || Request.QueryString["PrevMPage"] == "Admin" || Request.QueryString["PrevMPage"] == "Contractor" || Request.QueryString["PrevMPage"] == "SubDivision")
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
                    else
                    {
                        Page.MasterPageFile = "~/SuperAdmin.Master";
                    }
                }
            }
        }      
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendMail.aspx");
        }
    }
}