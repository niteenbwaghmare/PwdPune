using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class MasterReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ImgBuildingMPR_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBuildingReport.aspx", false);
            //Server.Transfer("MasterBuildingReport.aspx");
        }

        protected void ImgRoad_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterRoadReport.aspx", false);
        }

        protected void ImgNabard_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterNabardReport.aspx", false);
        }

        protected void ImgDPDC_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterDPDCReport.aspx", false);
        }

        protected void ImageMP_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterMPReport.aspx", false);
        }

        protected void ImageMLA_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterMLAReport.aspx", false);
        }

        protected void ImgCRF_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterCRFReport.aspx", false);
        }

        protected void ImageGat_A_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterGat_AReport.aspx", false);
        }

       
        protected void ImageGat_D_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterGat_DReport.aspx", false);
        }

        protected void ImgDeposit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterDepositeFundReport.aspx", false);
        }

        protected void ImageAunty_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterAuntyReport.aspx", false);
        }

        protected void ImageGat_B_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterGAT_BReport.aspx", false);
        }

        protected void ImageGat_C_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterGAT_CReport.aspx", false);
        }

        protected void ImageGat_F_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterGat_FReport.aspx", false);
        }

        protected void ImageResidentialBuliding_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterResidentialBulidingReport.aspx", false);
        }

        protected void ImageNonResidentialBuliding_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterNonResidentialBulidingReport.aspx", false);
        }

        protected void ImageGramvikas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Master2515Report.aspx", false);
        }
    }
}