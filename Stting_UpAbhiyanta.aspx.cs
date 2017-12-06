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
    public partial class Stting_UpAbhiyanta : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    Label1.Text = Session["id"].ToString();
                    GetID();
                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
                Session["id"] = Label1.Text;
            }
        }
        public void GetID()
        {

            int i = 0;
            string select = "select top 1 Akrmank from SettingUpAbhiyanta order by Akrmank desc";
            SqlDataAdapter sda = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                i = Convert.ToInt32(dr[0].ToString());
                i++;
                Txtno.Text = i.ToString();
            }


        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Setting");
        }
        protected void Btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO SettingUpAbhiyanta(AKrmank,Name)VALUES('" + Txtno.Text + "',N'" + Txtnm.Text + "')",con);
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>alert('Value succesfully Inserted.....!!!!!!')</script>");
                    GetID();
                    Txtnm.Text = "";
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