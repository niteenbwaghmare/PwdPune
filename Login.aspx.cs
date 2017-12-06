using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.SessionState;
using System.Net;
using System.Net.NetworkInformation;
using DataLayer;
using PWdEEBudget.SMS_CRUD;

namespace PWdEEBudget
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        clsSMS_CRUD SMSobj = new clsSMS_CRUD();
        static SqlQueryOrConnection ObjsqlQueryOrCon = new SqlQueryOrConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtUserId.Text = Request.Cookies["UserName"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                    chkRememberMe.Checked = true;
                }
            }
            if (chkRememberMe.Checked == false)
            {
                Response.Cookies["UserName"].Value = null;
                Response.Cookies["Password"].Value = null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {                
                string strUrl = ObjsqlQueryOrCon.CheckUserLogin(txtUserId.Text.Trim(), txtPassword.Text.Trim());

                if (strUrl != "Invalid Username and Password")
                {
                    GetUserComputerCredentials(txtUserId.Text.Trim(), strUrl.Split(':')[1]);
                    if (chkRememberMe.Checked)
                    {
                        Response.Cookies["UserName"].Value = txtUserId.Text.ToString();
                        Response.Cookies["Password"].Value = txtPassword.Text.ToString();
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                    }
                    Session["id"] = txtUserId.Text;
                    Session.Timeout = 90;
                    Session["id1"] = txtUserId.Text.Trim();
                    strUrl = strUrl.Split(':')[0];
                    Response.Redirect(strUrl, false);

                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
                }

            }
            catch (Exception)
            {
                Response.Write("Check Your InterNet Connection");
            }
        }


        private void GetUserComputerCredentials(string userid, string username)
        {
            //get mac address
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            // To Get IP Address
            string IPHost = Dns.GetHostName();
            string IP = Dns.GetHostEntry(IPHost).AddressList[0].ToString();
            //string IP = Request.UserHostAddress;
            string ComputerName = System.Environment.MachineName;
            HttpBrowserCapabilities browser = Request.Browser;

            //Online User History Details
            Application["UserId"] = txtUserId.Text.Trim();
            var userList = new List<string>();
            var userName = txtUserId.Text.Trim();
            if (Application["UserList"] != null)
            {
                userList = (List<string>)Application["UserList"];
            }
            else
                userList = new List<string>();
            userList.Add(userName);
            Application["UserList"] = userList;

            DateTime dos = DateTime.Now;
            string curruntdate = dos.ToString("dd/MM/yyyy");


            if (con.State != ConnectionState.Open)
                con.Open();

            string query = "Insert into [UserCredintiall]([UserName],[UserId],[loginDate],[loginTime],[SystemName],[SystemIpAddress],[SystemMacAddress],[BrowserType],[BrowserName],[BrowserPlatform]) values(N'" + username + "','" + userid + "','" + curruntdate + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','" + ComputerName + "','" + IP + "','" + sMacAddress + "','" + browser.Type + "','" + browser.Browser + "','" + browser.Platform + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            string message = "" + username + " Logged In into DBS software on " + curruntdate + "," + DateTime.Now.ToString("h:mm:ss tt") + ". Client PC Details:- Computer Name:" + ComputerName + " IP:" + IP + " Mac:" + sMacAddress + " Browser:" + browser.Type + "";
           // SMSobj.SendSMS("7972334218", message);
        }
    }
}