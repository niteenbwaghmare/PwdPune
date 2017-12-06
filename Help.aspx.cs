using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class Help : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string PrevMPage = Request.QueryString["PrevMPage"].ToString();
            //if (Request.UrlReferrer != null)
            //{
            //    string previousPageUrl = Request.UrlReferrer.AbsoluteUri;
            //    string previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);
            //}
            //if (PrevMPage == "ImageUpload")
            //{
            //    Page.MasterPageFile = "~/ImageUpload.Master";
            //}
            //else
            //{
            //    MasterPageFile = "~/SuperAdmin.Master";
            //}
            //string FileName = Page.PreviousPage.AppRelativeVirtualPath;
            //string MasterFileName = Page.PreviousPage.Master.ToString();
            //FileName = FileName.Substring(FileName.LastIndexOf("/") + 1);



        }
        //protected void page_preinit(object sender, EventArgs e)
        //{
        //    string PrevMPage = Request.QueryString["PrevMPage"].ToString();
        //    if (PrevMPage == "ImageUpload")
        //    {
        //        Page.MasterPageFile = "~/ImageUpload.Master";
        //    }
        //    else
        //    {
        //        Page.MasterPageFile = "~/SuperAdmin.Master";
        //    }
            
        //}      
        protected void page_preinit(object sender, EventArgs e)
        {
            if (!IsPostBack || Request.QueryString["PrevMPage"] == "ImageUpload" || Request.QueryString["PrevMPage"] == "Admin" || Request.QueryString["PrevMPage"] == "Contractor" || Request.QueryString["PrevMPage"] == "SubDivision" || Request.QueryString["PrevMPage"] == "MPMLA")
            {
               
                if (Request.QueryString["PrevMPage"] != null)
                {
                    string PrevMPage = Request.QueryString["PrevMPage"].ToString();
                    if (PrevMPage == "ImageUpload")
                    {
                        Page.MasterPageFile = "~/ImageUpload.Master";
                    }
                    else if (PrevMPage == "Admin")
                    {
                        Page.MasterPageFile = "~/Admin.Master";
                    }
                    else if (PrevMPage == "Contractor")
                    {
                        Page.MasterPageFile = "~/Contractor.Master";
                    }
                    else if (PrevMPage == "SubDivision")
                    {
                        Page.MasterPageFile = "~/SubDivision.Master";
                    }
                    else if (PrevMPage == "MPMLA")
                    {
                        Page.MasterPageFile = "~/MPMLA.Master";
                    }
                    else
                    {
                        Page.MasterPageFile = "~/SuperAdmin.Master";
                    }
                }
            }
        }      
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.sghitech.co.in/");
        }
    }
}