using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PWdEEBudget.MyAssociationPortal.BusinessLayer;
namespace PWdEEBudget
{
    public partial class demo : System.Web.UI.Page
    {
        MyAssociation objSendSMS = new MyAssociation();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Img_btn_downloadApp_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AndroidApplication/DBS.apk");
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnsendLink_Click(object sender, EventArgs e)
        {
            string Message = string.Empty;
            Message = "Welcome to Pune PWD DBS Software\n";
            Message += "Click here to download DBS App:- \n";
            Message += " http://pwdpune.sghitech.co.in/AndroidApplication/DBS.apk";
            objSendSMS.SendSMS(Message, txtMobileNo.Text.Trim(), "", "");
        }
    }
}