using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class MasterBudgetMenu : System.Web.UI.Page, IHttpHandler, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImgBuildingMPR_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetBuilding.aspx", false);
        }

        protected void ImgCRF_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetCRF.aspx", false);
        }

        protected void ImgNabard_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetNABARD.aspx", false);
        }

        protected void ImgRoad_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetRoad.aspx", false);
        }

        protected void ImgDPDC_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetDPDC.aspx", false);
        }

        protected void ImageMLA_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetMLA.aspx", false);
        }

        protected void ImageMP_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetMP.aspx", false);
        }

        protected void ImageGat_A_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetGat_A.aspx", false);
        }

        protected void ImageGat_FBC_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetGat_FBC.aspx", false);
        }

        protected void ImageGat_D_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetGat_D.aspx", false);
        }

        protected void ImgDeposit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetDepositFund.aspx", false);
        }

        protected void ImageAunty_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetAunty.aspx", false);
        }

        protected void ImageResidentialBuilding_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetResidentialBuilding.aspx", false);
        }

        protected void ImageNonResidentialBuilding_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudgetNonResidentialBuilding.aspx", false);
        }

        protected void ImageGamvikas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MasterBudget2515.aspx", false);
        }
    }
}