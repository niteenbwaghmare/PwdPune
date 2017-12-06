using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PWdEEBudget
{
    public partial class Visitor : System.Web.UI.Page
    {
         SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    Label1.Text = Session["id"].ToString();
                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
                Session["id"] = Label1.Text;
            }
             getid();
        }
       
      
        public void getid()
        {
                try
                {
                    con.Open();
                    string select = "SELECT TOP(1) ID FROM Visitorinfo order by ID desc";

                    SqlCommand cmd1 = new SqlCommand(select, con);

                    SqlDataReader rs = cmd1.ExecuteReader();

                    while (rs.Read())
                    {
                       i = Convert.ToInt32(rs["ID"]); 
                    }
                    i = i + 1;

                    //Txtid.Text = i.ToString();


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

     

        protected void Btnok_Click1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Visitorinfo(NAME,DESIGNATION,ADDRESS,MOBILE,OFFICE,WORK,CONSULTANTPERSON,CONSULTANTDESIG,DAY,TIME)VALUES('" + Txtnm.Text + "','" + Txtdesig.Text + "','" + Txtadd.Text + "','" + Txtmob.Text + "','" + Txtoff.Text + "','" + Txtwork.Text + "','" + Txtcp.Text + "','" + Txtcd.Text + "','" + Txtday.Text+ "','" + Txttime.Text + "')", con);
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
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }
     }
 }
    
