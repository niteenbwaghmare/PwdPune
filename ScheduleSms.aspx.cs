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
    public partial class ScheduleSms : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());

        string u1, s1, t1, yn, kn, le;
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
                //Session["id"] = Label1.Text;
            }
            showdata();
           
        }
        public void showdata()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select WorkId,ThekKamPurnDate from BudgetMaster", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DateTime enddate = Convert.ToDateTime(dr[1].ToString()).AddDays(-8);
                string firstdate = enddate.ToString("dd/MM/yyyy");
                DateTime today = DateTime.Now;
                string seconddate = today.ToString("dd/MM/yyyy");
                if (firstdate == seconddate)
                {
                    SqlDataAdapter sda1 = new SqlDataAdapter("select UpAbhiyantaMobile,ShakhaAbhiyantMobile,ThekedarMobile,YojnecheName,KamacheName,LekhaShirsh from BudgetMaster where ThekKamPurnDate='"+dr[0]+ "'", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                }
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            sendsmsdate();
        }
        public void sendsmsdate()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select WorkId,ThekKamPurnDate from BudgetMaster", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int j = 0;

            foreach (DataRow dr in dt.Rows)
            {
                DateTime enddate = Convert.ToDateTime(dr[1].ToString()).AddDays(-8);
                string firstdate = enddate.ToString("dd/MM/yyyy");
                DateTime today = DateTime.Now;
                string seconddate = today.ToString("dd/MM/yyyy");
                if (firstdate == seconddate)
                {
                    j++;
                    if (j == 1)
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter("select UpAbhiyantaMobile,ShakhaAbhiyantMobile,ThekedarMobile,YojnecheName,KamacheName,LekhaShirsh from BudgetMaster where WorkId='" + dr[0] + "'", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        u1 = dr1[0].ToString();
                        s1 = dr1[1].ToString();
                        t1 = dr1[2].ToString();
                        yn = dr1[3].ToString();
                        kn = dr1[4].ToString();
                        le = dr1[5].ToString();
                    }
                    sendSms();
                 }
                    
                }
            }
        }
        public void sendSms()
        {
            //Your authentication key
           // string authKey = "87340AUVjSPCh55892127";
            string authkey = "136969AqSChbw2jT85876374f";
            //Multiple mobiles numbers separated by comma
            string msg;

            string mobileNumber = u1 + "," + s1 + "," + t1;
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = "PWDEPB";
            //Your message to send, Add URL encoding here.


            msg = "Welcome to PWD East Pune\n  Yojneche Name: " + yn + "\n Work Name:" + kn + "\n  Lekhashirsh:" + le + " \n Website:http://www.eepwdeastpunebudget.com \n Help:info@eepwdeastpunebudget.com";
            //Prepare you post parameters

            string message = HttpUtility.UrlEncode(msg);
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authkey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "4");
            sbPostData.AppendFormat("&unicode={0}", "1");

            try
            {                
                //Call Send SMS API
                string sendSMSUri = "http://www.bulksms99.in/api/sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();


            }
            catch (SystemException ex)
            {

            }
        }
    }
}