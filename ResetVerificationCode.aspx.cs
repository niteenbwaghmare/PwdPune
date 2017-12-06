using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;

namespace PWdEEBudget
{
    public partial class ResetVerificationCode : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        SqlCommand cmd = new SqlCommand();
        string uname, mobno, msg;
        int n;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public int generateCode()
        {

            int _min = 000;
            int _max = 999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);

        }

        public void sendSms(string message, string mobnumber)
        {

            string authKey = "87340AUVjSPCh55892127";
            string senderid = "PWDEPB";
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobnumber);
            sbPostData.AppendFormat("&message={0}", HttpUtility.UrlEncode(message));
            sbPostData.AppendFormat("&sender={0}", senderid);
            sbPostData.AppendFormat("&route={0}", "default");
            try
            {
                string sendSMSUri = "http://smsgateway.elitesoftwares.co.in/sendhttp.php";

                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);

                UTF8Encoding encoding = new UTF8Encoding();

                byte[] data = encoding.GetBytes(sbPostData.ToString());

                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                reader.Close();
                response.Close();
            }
            catch (SystemException ex)
            {
                Response.Write(ex);

            }


        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            //emailid = txtEmailid.Text.Trim();

            try
            {
                con.Open();
                SqlParameter user = new SqlParameter("@uid", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };

                SqlParameter usermobile = new SqlParameter("@mobileno", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_UsercheckExist";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@email", txtEmailid.Text);

                cmd.Parameters.Add(user);
                cmd.Parameters.Add(usermobile);

                cmd.ExecuteScalar();



                uname = user.Value.ToString();
                mobno = usermobile.Value.ToString();
                con.Close();
                n = generateCode();
                msg = n.ToString();
                sendSms(msg, mobno);
                Label1.Text = n.ToString();


            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            //if (n.Equals(Convert.ToInt32(txtcode.Text)))
            if (Label1.Text == txtcode.Text)
            {
                Response.Redirect("Reset.aspx?Parameter=" + txtEmailid.Text);
            }
        }
    }
}