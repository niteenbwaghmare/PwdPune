using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class DBSReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void ImgDBSDivisionReport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DBSDivisionWiseReport.aspx");
        }



        protected void ImgDBSIndividualReport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DBSIndividualHeadReport.aspx");
        }

        protected void ImgDBSAllHead_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DBSAllHeadReport.aspx");
        }

        protected void ImgDBSStatistics_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("StatisticsReport.aspx");
        }

        protected void ImgMontWiseReport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MonthWiseReport.aspx");
        }

        protected void ImageBetDateWiseReport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DateWiseRerport.aspx");
        }

        protected void ImageCostWiseReport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CostWiseReport.aspx");
        }

        protected void ImageWorkIdWiseReport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WorkIdWiseReport.aspx");
        }

        protected void ImageSMSReport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AutoSMSReport.aspx");
        }

        protected void ImageUserCred_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserCredetialReport.aspx");
        }

        protected void ImageBillStatus_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("BillStatusReport.aspx");
        }

        protected void ImageComplaint_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ComplaintForm.aspx");

        }
    }
}