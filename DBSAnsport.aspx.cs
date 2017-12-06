using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PWdEEBudget.ScreatAdmin;

namespace PWdEEBudget
{
    public partial class DBSAnsport : System.Web.UI.Page
    {
        clsScreatAdmin objPost = new clsScreatAdmin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ComplaintId"]!=null)
                {
                    GridAns.DataSource = objPost.BindAnsGrid("where [Complaint_Id]='" + Request.QueryString["ComplaintId"].ToString() + "'");
                    GridAns.DataBind();
                }
            }
        }
    }
}