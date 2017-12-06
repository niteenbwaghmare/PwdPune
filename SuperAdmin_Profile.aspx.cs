using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class SuperAdmin_Profile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        int i;
        string a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    a = Session["id"].ToString();
                    nameFetch();
                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
                Session["id"] = a;
            }
        }
        public void nameFetch()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select Photo,UserId,FName+' '+LName as Name,Office,Post,OfficeAddress,PermanemtAddress,LocalAddress,DOB,NDate,Gender,Status,Village,Taluka,Dist,Nationality,MobileNo,EmailId from [User] where UserId='" + a + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                imgPhoto.ImageUrl = dr["Photo"].ToString();
                lblID.Text = dr["UserId"].ToString();
                lblName.Text = dr["Name"].ToString();
                //lblName.Text = dr["MName"].ToString();
                //lblName.Text = dr["LName"].ToString();
                lblKaryalay.Text = dr["Office"].ToString();
                lblPost.Text = dr["Post"].ToString();
                lblKarAdd.Text = dr["OfficeAddress"].ToString();
                lblkaymchaAdd.Text = dr["PermanemtAddress"].ToString();
                lblLocalAdd.Text = dr["LocalAddress"].ToString();
                lblDoB.Text = dr["DOB"].ToString();
                lblNodaniDate.Text = dr["NDate"].ToString();
                lblFemale.Text = dr["Gender"].ToString();
                lblStatus.Text = dr["Status"].ToString();
                lblVilage.Text = dr["Village"].ToString();
                lblTaluka.Text = dr["Taluka"].ToString();
                lblJila.Text = dr["Dist"].ToString();
                lablRastiyatv.Text = dr["Nationality"].ToString();
                lblMob.Text = dr["MobileNo"].ToString();
                lblEmail.Text = dr["EmailId"].ToString();
            }
        }
    }
}