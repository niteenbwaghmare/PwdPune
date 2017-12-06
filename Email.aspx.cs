using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    
    public partial class Email : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
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
        }
        protected void SendEmail(object sender, EventArgs e)
        {
            using (MailMessage mm = new MailMessage(txtEmail.Text, txtTo.Text))
            {
                mm.Subject = txtSubject.Text;
                mm.Body = txtBody.Text;
                if (fuAttachment.HasFile)
                {
                    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                }
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.sghitech.co.in";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(txtEmail.Text, txtPassword.Text);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            }
            store();
        }
        public void store()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Email(Reciver,Subject,Sender)VALUES('" + txtTo.Text + "','" + txtSubject.Text + "','" + txtEmail.Text + "')", con);

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

        protected void btnSave_Click(object sender, EventArgs e)
        {


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }
    }
}