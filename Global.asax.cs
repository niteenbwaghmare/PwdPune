using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Quartz;
using Quartz.Impl;

using PWdEEBudget.QuartZExample;
using System.Net.Mail;
using System.Web.Configuration;
using System.IO;

namespace PWdEEBudget
{
    public class Global : System.Web.HttpApplication
    {
        Login log = new Login();
        protected void Application_Start(object sender, EventArgs e)
        {
            JobScheduler.Start();
            //var userList = new List<string>();
            //Application["UserList"] = userList;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Session.Timeout = 90;

            //var userName = Membership.GetUser().UserName;

            //List<string> userList;
            //if (Application["UserList"] != null)
            //{
            //    userList = (List<string>)Application["UserList"];
            //}
            //else
            //    userList = new List<string>();
            //userList.Add(userName);
            //Application["UserList"] = userList; 

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HttpUnhandledException httpUnhandledException =
      new HttpUnhandledException(Server.GetLastError().Message, Server.GetLastError());
            SendEmailWithErrors(httpUnhandledException.GetHtmlErrorMessage());
        }

        private static void SendEmailWithErrors(string result)
        {
            try
            {
                string Username = WebConfigurationManager.AppSettings["UserId"].ToString();
                string Password = WebConfigurationManager.AppSettings["Password"].ToString();
                MailMessage Message = new MailMessage();
                Message.To.Add(new MailAddress(Username));
                Message.From = new MailAddress(Username);
                Message.Subject = "Exception raised";
                Message.IsBodyHtml = true;
                Message.Body = result;
                System.Net.NetworkCredential objNetworkCredential = new System.Net.NetworkCredential(Username, Password);
                SmtpClient objSmtpClient = new SmtpClient();
                objSmtpClient.Host = "smtp.gmail.com";
                objSmtpClient.Port = 587;
                objSmtpClient.Credentials = objNetworkCredential;
                objSmtpClient.EnableSsl = true;
                //objSmtpClient.Send(Message);

            }
            catch (System.Web.HttpException ehttp)
            {
                // Write o the event log.
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}