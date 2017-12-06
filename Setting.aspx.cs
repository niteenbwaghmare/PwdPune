using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class Setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string PrevPage;
            if (!IsPostBack)
            {
                PrevPage = Request.ServerVariables["HTTP_REFERER"];
                if (Session["id"] != null)
                {
                    Label1.Text = Session["id"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                if (PrevPage == null || Session["SettingAccess"] == null)
                {
                    Response.Redirect("SuperAdminPanel.aspx", false);
                }
                else
                {
                    Session["SettingAccess"] = null;
                }
                //Session["id"] = Label1.Text;

            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }
        protected void abhiyanta_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Setting_KaryakariAbhiyanta.aspx");
        }

        protected void upabhiyanta_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Stting_UpAbhiyanta.aspx");
        }

        protected void leader_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Setting_AddMLA.aspx");
        }

        protected void lekhashirsh_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Setting_LekhaShirsh.aspx");
        }

        protected void type_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Setting_VarishtType.aspx");
        }

        protected void dist_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Setting_Jilha.aspx");
        }

        protected void taluka_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Setting_Taluka.aspx");
        }

        protected void sms_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SettingSMS.aspx");
        }

        protected void portalsms_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Setting_Sms.aspx");
        }

        protected void createadmin_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CreateAdmin.aspx");
        }

        protected void userprofile_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewUserProfile.aspx");
        }

        protected void userinfo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("User.aspx");
        }

        protected void ImgUpvibhag_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Setting_UpVibhag.aspx");

        }

        protected void UpdateWorkID_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UpdateWorkID.aspx");
        }

        protected void UploadImg_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UploadImage.aspx");
        }

      

        protected void btnBillGenerate_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("BillStatus.aspx");
        }
    }
}