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
    public partial class SettingSMS : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();

        }
        public void SendSMS(string contact, string message) //sms sending 
        {
            try
            {
                string senderid = "EEesPN";
                string userid = "sghitech";
                //string authkey = "72BB2C15-7EA2-4951-BCF2-AC2C1CB4D468";
                string authkey = "136969AqSChbw2jT85876374f";
                string type = "Unicode";
                //string URL = "http://dndsms.perfectsms.in/SecureApi.aspx?usr=" + userid + "&key=" + authkey + "&smstype=" + type + "&to=" + contact + "&msg=" + message + "&rout=Transactional&from=" + senderid + "";
                string URL = "http://www.bulksms99.in/api/sendhttp.php?authkey=" + authkey + "&mobiles=" + contact + "&message=" + message + "&sender=" + senderid + "&route=4&unicode=1";   

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "GET";
                request.Timeout = 30000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string contact = txtmobileno.Text;
            string message = txtdescription.Text;
            var yArray = txtmobileno.Text.ToString().Split(',').Select(m => m.Trim()).ToArray();

            foreach (String strno in yArray)
            {
                SendSMS(strno, message);
            }
            string senderid = "EEesPN";
            
           
            SqlCommand cmd = new SqlCommand("insert into SendSms(SenderId,MobileNo,Description)values('" + senderid.ToString() + "','" + txtmobileno.Text + "',N'" + txtdescription.Text + "')", con);
            
            cmd.ExecuteNonQuery();
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                lblStatus.Text = "<b style='color:green'>SMS Sent Successfully!!!</b>";
            }
            else
            {
                lblStatus.Text = "<b style='color:red'>SMS Sending failed!!!</b>";
            }
            con.Close();
            //gridshow();

        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Setting.aspx");
        }
    }
}