using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class SUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["id"] != null)
            //    {
            //        Label1.Text = Session["id"].ToString();
            //    }
            //    else
            //    {

            //        Response.Redirect("Login.aspx");
            //    }
            //    Session["id"] = Label1.Text;
            //}
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
           
        }

        protected void ImgBuildingMPR_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterBuilding.aspx");
        }

        protected void ImgCRF_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterCRF.aspx");
        }

        protected void ImgNabard_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterNabard.aspx");
        }

        protected void ImgRoad_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterRoad.aspx");
        }

        protected void ImgDPDC_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterDPDC.aspx");
        }

        protected void ImageMLA_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterMLA.aspx");
        }

        protected void ImageMP_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterMP.aspx");
        }

        protected void ImgDeposit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterDepositFund.aspx");
        }

        protected void ImageGat_A_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterGATA.aspx");
        }

       

        protected void ImageGat_D_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterGAT_D.aspx");
        }

        protected void ImageAunty_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterAnnuity.aspx");
        }

        protected void ImageGat_B_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterGAT_B.aspx");
        }

        protected void ImageGat_C_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterGAT_C.aspx");
        }

        protected void ImageGat_F_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterGAT_F.aspx");
        }

        protected void ImageNR_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterNonResidentialBuilding.aspx");
        }

        protected void ImageRB_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterResidentialBuilding.aspx");
        }

        protected void ImageNabardMain_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_MasterNabardMain.aspx");
        }

        protected void ImageGramVikas2515_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Report_Master2515Gramvikas.aspx");
        }

    }
}