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
    public partial class SubDivision : System.Web.UI.MasterPage
    {

        string a;
        string UserName;
        SqlConnection con = null;
        string alive = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            //  Session["sessiontime"] = DateTime.Now;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["id"] != null || Session.Timeout > 5)
                {

                   

                    if (Session["id"] != null)
                    {
                        a = Session["id"].ToString();
                    }
                    //else
                    //{
                    //    Session["id"] = "PwdExecutiveEngineer1";
                    //    a = "PwdExecutiveEngineer1";
                    //}

                    //  alive = Session["id"].ToString();
                    nameFetch();
                    Img();
                    GetUserName();
                    lblUserName.Text = UserName;
                    //Notification();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                // Session["id"] = a;
            }

        }


       
        public void GetUserName()
        {
            string UserId = Session["id"].ToString();
            string strGetNameQuery = "select Name from SCreateAdmin where UserId='" + UserId + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(strGetNameQuery, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    UserName = dr[0].ToString();
                }


            }
        }
        public void Img()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select Fname+' '+LName as Name,Post from SCreateAdmin where UserId='" + a + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[1].ToString() == "Executive Engineer")
                {
                    imgUser.Src = "Fileuploded/AVINASH DHONDGE-Logo.jpg";
                }
                else
                {
                    imgUser.Src = "logo/user-icon3.png";
                }
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {

            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

        }
        protected void logout_OnClick(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            Response.Redirect("Login.aspx");
        }
        public void exit()
        {
            Session.Abandon();

            Response.Redirect("Login.aspx");
        }
        public void nameFetch()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select Fname+' '+LName as Name,Post from SCreateAdmin where UserId='" + a + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }
        
        
    }

}

