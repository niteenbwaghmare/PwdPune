using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class MPR_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImgBuildingMPR_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshBuilding.aspx");
        }

        protected void ImgRoad_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshRoad.aspx");
        }

        protected void ImgNabard_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshNabard.aspx");
        }

        protected void ImgDPDC_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshDPDC.aspx");
        }

        protected void ImageMP_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshMP.aspx");
        }

        protected void ImageMLA_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshMLA.aspx");
        }

        protected void ImgDeposit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshDepositeContributionFund.aspx");
        }

        protected void ImageGat_A_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshGAT_A.aspx");
        }
       

        protected void ImageGat_D_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshGAT_D.aspx");
        }

        protected void ImageAunty_Click(object sender, ImageClickEventArgs e)
        {
           
        }

        protected void ImageGat_F_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshGAT_F.aspx");
        }

        protected void ImageGat_B_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshGAT_B.aspx");
        }

        protected void ImageGat_C_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshGAT_C.aspx");
        }

        protected void ImgCRF_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshCRF.aspx");
        }

        protected void ImageResidentialBuliding_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshResidentialBuilding.aspx");
        }

        protected void ImageNonResidentialBuliding_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_LekhasirshNonResidentialBuilding.aspx");
        }

        protected void ImageGramvikas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_Lekhasirsh2515.aspx");
        }
    }
}