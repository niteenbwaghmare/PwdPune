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
    public partial class Reset : System.Web.UI.Page
    {
        string newpasswd, confirmPswd, email;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        SqlCommand cmd = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = Request.QueryString["Parameter"].ToString();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            newpasswd = txtnewPswd.Text;
            confirmPswd = txtConfirmNPswd.Text;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Update_SCreateAdmin";
                if (newpasswd == confirmPswd)
                {

                    cmd.Parameters.Add("@pswd", SqlDbType.VarChar).Value = txtConfirmNPswd.Text.Trim();
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Label1.Text.Trim();

                    cmd.Connection = con;

                    SqlCommand cmd1 = new SqlCommand("update Login set Password='"+txtConfirmNPswd.Text.Trim()+"' where UserId='"+Label1.Text.Trim()+"'", con);
                                        con.Open();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    Response.Write("Record updated successfully");

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

            Response.Redirect("SuperAdminPanel.aspx");

        }
    }
}