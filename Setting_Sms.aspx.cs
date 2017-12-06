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
    public partial class Setting_Sms : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        string a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    a = Session["id"].ToString();
                    nameFetch();
                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
                //Session["id"] = a;
            }
           
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Setting");
        }
        public void nameFetch()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select Fname+' '+LName as Name,Post from SCreateAdmin where UserId='" + a + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lblName.Text = dr[0].ToString();
                lblPost.Text = dr[1].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO SMS(Name,Post,Date,SMS)VALUES('" + lblName.Text + "','" + lblPost.Text + "','" + txtDate.Text + "','" + txtSMS.Text + "')", con);
               
                cmd.CommandType = CommandType.Text;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>alert('Value succesfully Inserted.....!!!!!!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}