using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PWdEEBudget;
using System.Web.Security;


namespace PWdEEBudget
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        MembershipUser u;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["UserList"] != null)
            {
               
             
                gridOnlineUser.DataSource = Application["UserList"] as List<string>;
                gridOnlineUser.DataBind();
            }
        }
    }
}