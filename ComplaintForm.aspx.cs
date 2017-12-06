using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using PWdEEBudget.ScreatAdmin;
using System.Text.RegularExpressions;
using PWdEEBudget.MyAssociationPortal.BusinessLayer;
using System.IO;
using System.Text;
using System.Threading;
namespace PWdEEBudget
{
    public partial class ComplaintForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        //SqlDataAdapter da;
        clsScreatAdmin objPost = new clsScreatAdmin();
        static DataSet ds;
        SqlCommand cmd;
        MyAssociation objSmS = new MyAssociation();
        static int index = 0;
        static string mob = string.Empty;
        string strcmd = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblQueryDate.Text = DateTime.Now.ToShortDateString();
            if (!Page.IsPostBack)
            {
                ds = new DataSet();
                ds = objPost.BindPost();
                ddlPost.DataSource = ds;
                ddlPost.DataTextField = "Post";
                ddlPost.DataValueField = "Post";
                ddlPost.DataBind();
                ddlPost.Items.Insert(0, new ListItem("Select Post", "0"));

            }
        }

        protected void ddlPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds = objPost.BindNameByPost(ddlPost.SelectedItem.Text.Trim());
            ddlName.DataSource = ds;
            ddlName.DataTextField = "Name";
            ddlName.DataValueField = "MobileNo";
            ddlName.DataBind();
            ddlName.Items.Insert(0, new ListItem("Select Name", "0"));

        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtName.Text = Regex.Replace(ddlName.SelectedItem.Text.Trim(), " {2,}", " ");
            txtName.Text += ":" + ddlName.SelectedItem.Value;


        }

        protected void BtnSav_Click(object sender, EventArgs e)
        {
            string[] NameOrMobileNo = txtName.Text.Split(new[] { ':' }, 2);
            string[] NameOrMobile = new string[2];
            if (NameOrMobileNo.Length > 1)
                NameOrMobile = NameOrMobileNo;
            else
            {
                NameOrMobile[0] = NameOrMobileNo[0];
                NameOrMobile[1] = "0000000000";
            }
            // string MobileNo = txtName.Text.Split(':')[1];//Take textBox Value After Colon(:) we get Mobile No Hear
            string post = ddlPost.SelectedItem.Text;
            //string name = txtName.Text.Trim().Split(':')[0];//Take TextBox Valu before Colon(:) We Get Name Hear
            string menuType = rdbMenuTag.SelectedItem.Text.Trim();
            string ErrorPage;
            if (menuType == "Setting")
            {
                ErrorPage = rdbErrorPageSetting.SelectedItem.Text.Trim();
            }
            else if (menuType == "DBS Report")
            {
                ErrorPage = rdbDBSReport.SelectedItem.Text.Trim();
            }
            else
            {
                ErrorPage = rdbErrorPageHead.SelectedItem.Text.Trim();
            }

            if (ErrorImgUpload.HasFile)
            {
                int length = ErrorImgUpload.PostedFile.ContentLength;
                byte[] imgbyte = new byte[length];
                HttpPostedFile img = ErrorImgUpload.PostedFile;
                string contentType = ErrorImgUpload.PostedFile.ContentType;
                //set the binary data
                img.InputStream.Read(imgbyte, 0, length);
                string filename = Path.GetFileName(ErrorImgUpload.PostedFile.FileName);


                strcmd = "Insert into [tblComplaint] ([Post],[Name] ,[MenuType],[Error_PageName],[Error_Description],[Error_PageUrl],[ComplaintDate],[Error_Ans],[Error_Img],[Error_imgType],[Error_imgName],[Contact_No]) OUTPUT inserted.Complaint_Id values(N'" + post + "',N'" + NameOrMobile[0] + "',N'" + menuType + "',N'" + ErrorPage + "',N'" + txtDescription.Text.Trim() + "','" + txtErrorPageUrl.Text.Trim() + "','" + lblQueryDate.Text.Trim() + "','Pending','" + imgbyte + "','" + contentType + "','" + filename + "','" + NameOrMobile[1] + "')";
            }
            else
            {

                strcmd = "Insert into [tblComplaint] ([Post],[Name] ,[MenuType],[Error_PageName],[Error_Description],[Error_PageUrl],[ComplaintDate],[Error_Ans],[Contact_No])  OUTPUT inserted.Complaint_Id values(N'" + post + "',N'" + NameOrMobile[0] + "',N'" + menuType + "',N'" + ErrorPage + "',N'" + txtDescription.Text.Trim() + "','" + txtErrorPageUrl.Text.Trim() + "','" + lblQueryDate.Text.Trim() + "','Pending','" + NameOrMobile[1] + "')";
            }
            cmd = new SqlCommand(strcmd, con);
            // int ComplaintId=0;
            if (con.State != ConnectionState.Open)
                con.Open();
            int ComplentId = (int)cmd.ExecuteScalar();
            if (ComplentId > 0)
            {
                string Message = string.Empty;


                Message = " Welcome to P.W (East) D. Pune DBS complaint portal.\n Your complaint has been registered successfully.\n Your compliant Id is: SGPEDBS_00" + ComplentId + " . \n Your compliant will be solved within 7 working days.\n Please visit to http://mahapwddbs.com to check your complaint status.";

                objSmS.SendSMS(Message, NameOrMobile[1], "", "");


                //Send Error Complaint sms to sghitech
                Message = "Alert of PWD East Pune Error \n Post:- " + post + " \n Name:- " + NameOrMobile[0] + "\n Error Page:- \n" + ErrorPage + " \nDesc:- \n" + txtDescription.Text.Trim() + "\n Url:-" + txtErrorPageUrl.Text.Trim();

                objSmS.SendSMS(Message, "9096408111", "", "");


                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Your Complaint Send Succesfully...!!!');window.location ='ComplaintForm.aspx';", true);

            }
        }

        protected void rdbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbReportType.SelectedItem.Text == "See Answer Report")
            {
                BindAnsGrid();
                GridAns.Columns[GridAns.HeaderRow.Cells.Count - 1].Visible = false;
                Print.Style.Add("display", "none");
                GridAns.Style.Add("display", "block");
            }
            else
            {
                Print.Style.Add("display", "block");
                GridAns.Style.Add("display", "none");
                pnlpopup.Style.Add("display", "none");
                mask.Style.Add("display", "none");
                DivPwd.Style.Add("display", "none");
                DivBtn.Style.Add("display", "block");

            }

        }


        protected void BindAnsGrid()
        {
            string ComplaintId = string.Empty;
            if (txtComplaintId.Text.Trim() == "")
                ComplaintId = "";
            else
                ComplaintId = "Where Complaint_Id=" + txtComplaintId.Text.Trim();
            pnlpopup.Style.Add("display", "none");
            mask.Style.Add("display", "none");
            DivBtn.Style.Add("display", "none");
            ds = new DataSet();
            ds = objPost.BindAnsGrid(ComplaintId);
            GridAns.DataSource = ds;
            GridAns.DataBind();
            DivPwd.Style.Add("display", "block");
            //  ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>Divbtn(); </script>", false);
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridAns.ClientID + "', 750, 100 , 120 ,true); </script>", false);
        }

        protected void txtComplaintId_TextChanged(object sender, EventArgs e)
        {

            if (txtComplaintId.Text != "")
            {
                BindAnsGrid();
                if (GridAns.Rows.Count >= 1)
                {
                    GridAns.Columns[GridAns.HeaderRow.Cells.Count - 1].Visible = false;

                }
                pnlpopup.Style.Add("display", "none");
                mask.Style.Add("display", "none");
                Print.Style.Add("display", "none");
                GridAns.Style.Add("display", "block");
                rdbReportType.SelectedIndex = 1;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridAns.ClientID + "', 750, 100 , 120 ,true); </script>", false);
            }
        }


        protected void GridAns_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowPopup")
            {
                LinkButton btndetails = (LinkButton)e.CommandSource;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                lblComplaintId.Text = GridAns.DataKeys[gvrow.RowIndex].Value.ToString();
                // DataRow dr = dt.Select("CustomerID=" + GridViewData.DataKeys[gvrow.RowIndex].Value.ToString())[0];
                lblErorPage.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
                lblErrorDescription.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                //txtCity.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                // Popup(true);
                lblAnsDate.Text = DateTime.Now.ToShortDateString();
                //Thread.Sleep(5000);
                pnlpopup.Style.Add("display", "block");
                mask.Style.Add("display", "block");
                index = gvrow.DataItemIndex;
                mob = ds.Tables[0].Rows[index]["Contact_No"].ToString();
            }
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            strcmd = "update [tblComplaint] set[Error_Ans]='" + txtAns.Text.Trim() + "',[Ans_ByName]='" + txtAnsBy.Text.Trim() + "',[Ans_Date]='" + lblAnsDate.Text + "' where [Complaint_Id]=" + lblComplaintId.Text.Trim();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(strcmd, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                txtAns.Text = "";
                txtAnsBy.Text = "";
                string Message = " Welcome to P.W (East) D. Pune DBS complaint portal.\n Complaint Id:- SGPEDBS_00" + lblComplaintId.Text + "\n Your Problem is Solved.\n Please visit to http://puneeast.mahapwddbs.com/DBSAnsport.aspx?ComplaintId=" + lblComplaintId.Text + " and check your complaint Answer.";
                objSmS.SendSMS(Message, mob, "", "");
                BindAnsGrid();

            }
        }

        protected void txtPwd_TextChanged(object sender, EventArgs e)
        {
            if (txtPwd.Text.Trim() == "PWDPUNE")
            {
                GridAns.Columns[GridAns.HeaderRow.Cells.Count - 1].Visible = true;
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridAns.ClientID + "', 750, 100 , 120 ,true); </script>", false);

        }
    }
}