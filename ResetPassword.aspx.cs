using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        string txt;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        SqlCommand cmd = new SqlCommand();
        string SendSMSContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnGetOTP_Click(object sender, EventArgs e)
        {
            string MobileNo = string.Empty;
            if (Request.Cookies["ReceivedMobileNo"].Value != null)
            {
                MobileNo = Request.Cookies["ReceivedMobileNo"].Value;
                if (txtMobileNumber.Text != MobileNo)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Mobile Number')</script>");
                }
                else
                {
                    string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
                    string numbers = "1234567890";

                    string characters = numbers;
                    //if (rbType.SelectedItem.Value == "1")
                    //{
                    //    characters += alphabets + small_alphabets + numbers;
                    //}
                    int length = int.Parse("6");
                    string otp = string.Empty;
                    for (int i = 0; i < length; i++)
                    {
                        string character = string.Empty;
                        do
                        {
                            int index = new Random().Next(0, characters.Length);
                            character = characters.ToCharArray()[index].ToString();
                        } while (otp.IndexOf(character) != -1);
                        otp += character;
                    }
                    Response.Cookies["OTP"].Value = otp;
                    Response.Cookies["OTP"].Expires = DateTime.Now.AddMinutes(10);
                    SendSMSContent = "OTP";
                    SendSMS(MobileNo, otp);
                    DivSendOTP.Style.Add("Display", "none");
                    DivValidateOTP.Style.Add("Display", "block");
                }
            }


        }

        public void SendSMS(string contact, string OTP) //sms sending 
        {
            try
            {
                string senderid = "EEesPN";
                string userid = "sghitech";
                //string authkey = "72BB2C15-7EA2-4951-BCF2-AC2C1CB4D468";
                string authkey = "136969AqSChbw2jT85876374f";
                string type = "Unicode";
                string message = string.Empty;
                if (SendSMSContent == "OTP")
                {
                    message = "Use " + OTP + " as OTP to verify your identity and change your password.Do not share OTP with anyone";
                }
                else if (SendSMSContent == "Password")
                {
                    message = "Your Password is " + OTP + " Do not share this with anyone";
                }
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

        protected void btnSubmitOTP_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["OTP"].Value != null)
            {
                if (txtOTP.Text == Request.Cookies["OTP"].Value)
                {
                    string MobileNo = Request.Cookies["ReceivedMobileNo"].Value;
                    string Password = Request.Cookies["ReceivedPassword"].Value;
                    SendSMSContent = "Password";
                    SendSMS(MobileNo, Password);
                    DivSendOTP.Style.Add("Display", "block");
                    DivValidateOTP.Style.Add("Display", "none");
                    Response.Redirect("ResetPassword.aspx", false);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid OTP.Please Enter Valid OTP.')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('OTP is expired.Please try again...!')</script>");
            }
        }

        protected void txtUserId_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select UserId,MobileNo,Password from SCreateAdmin where UserId ='" + txtUserId.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (txtUserId.Text == dr[0].ToString())
                    {
                        Response.Cookies["ReceivedUserName"].Value = dr[0].ToString();
                        Response.Cookies["ReceivedMobileNo"].Value = dr[1].ToString();
                        Response.Cookies["ReceivedPassword"].Value = dr[2].ToString();
                        Response.Cookies["ReceivedUserName"].Expires = DateTime.Now.AddMinutes(10);
                        Response.Cookies["ReceivedMobileNo"].Expires = DateTime.Now.AddMinutes(10);
                        Response.Cookies["ReceivedPassword"].Expires = DateTime.Now.AddMinutes(10);
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid UserId.Please Enter valid UserId...!')</script>");
            }
        }
    }
}