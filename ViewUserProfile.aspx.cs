using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PWdEEBudget.ScreatAdmin;

namespace PWdEEBudget
{
    public partial class ViewUserProfile : System.Web.UI.Page
    {

        SqlConnection con;
        SqlConnection conMDB;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt = new DataTable();
        string strcmd = string.Empty;       
        clsScreatAdmin SAdminObj = new clsScreatAdmin();
        static bool PostFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            conMDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnMDBString"].ToString());
            if (!Page.IsPostBack)
            {
                ddlPost1.DataSource = SAdminObj.BindPost();
                ddlPost1.DataTextField = "Post";
                ddlPost1.DataValueField = "Post";
                ddlPost1.DataBind();
                ddlPost1.Items.Insert(0, new ListItem("Select Post", "0"));
                ddlPost1.Items.Insert(ddlPost1.Items.Count, new ListItem("All"));
                GridBind();
                if (Session["id"] != null)
                {
                    Label1.Text = Session["id"].ToString();
                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
               // Session["id"] = Label1.Text;
                
            }


        }
        public void GridBind()
        {

            dt = SAdminObj.GetAllUserProfileDetails();
            ViewState["Userdt"] = dt;
            grdvUserAdmin.DataSource = dt;
            grdvUserAdmin.DataBind();

        }

        public void SortGridByPost()
        {
            DataTable dt_sort = ((DataTable)ViewState["Userdt"]).Select("Post like '%" + ddlPost1.SelectedItem.Text + "%'").CopyToDataTable();
                //AsEnumerable().Where(row => row.Field<String>("Post") == ddlPost1.SelectedItem.Text).CopyToDataTable();
            grdvUserAdmin.DataSource = dt_sort;
            grdvUserAdmin.DataBind();
        }

        protected void grdvUserAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvUserAdmin.PageIndex = e.NewPageIndex;
            GridBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendMail.aspx");
        }

        protected void grdvUserAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  

            grdvUserAdmin.EditIndex = e.NewEditIndex;
            GridBind();

        }

        protected void grdvUserAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdvUserAdmin.EditIndex = -1;
            GridBind();
        }

        protected void grdvUserAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // [ID],[Name],[MobileNo],[Email],[Post],[UserId],[Password]FROM [SCreateAdmin]";

            //Label oldName = ((Label)e.Row.FindControl("Name"));
            string strSqlQuery;
            SAdminObj.id = Convert.ToInt16(((Label)grdvUserAdmin.Rows[e.RowIndex].FindControl("lblId")).Text);
            SAdminObj.name = ((TextBox)grdvUserAdmin.Rows[e.RowIndex].FindControl("txtName")).Text;

            SAdminObj.mobile = ((TextBox)grdvUserAdmin.Rows[e.RowIndex].FindControl("txtMobile")).Text;
            SAdminObj.email = ((TextBox)grdvUserAdmin.Rows[e.RowIndex].FindControl("txtEmail")).Text;
            SAdminObj.post = ((DropDownList)grdvUserAdmin.Rows[e.RowIndex].FindControl("DDLPost")).SelectedValue;
            SAdminObj.userid = ((TextBox)grdvUserAdmin.Rows[e.RowIndex].FindControl("txtUserId")).Text;
            SAdminObj.password = ((TextBox)grdvUserAdmin.Rows[e.RowIndex].FindControl("txtPassword")).Text;

            string oldName = Convert.ToString(((Label)grdvUserAdmin.Rows[e.RowIndex].FindControl("oldNamelbl")).Text);
            SAdminObj.ScreatAdminUpdate(con);
            SAdminObj.ScreatAdminUpdate(conMDB);
            List<string> ListTblNames = new List<string>() { "BudgetMasterBuilding", "BudgetMasterCRF", "BudgetMasterDepositFund", "BudgetMasterDPDC", "BudgetMasterGAT_A", "BudgetMasterGAT_D", "BudgetMasterGAT_FBC", "BudgetMasterMLA", "BudgetMasterMP", "BudgetMasterNABARD", "BudgetMasterNonResidentialBuilding", "BudgetMasterResidentialBuilding", "BudgetMasterRoad", "BudgetMasterAunty", "BudgetMaster2515" };
            if (con.State != ConnectionState.Open)
                con.Open();
            if (conMDB.State != ConnectionState.Open)
                conMDB.Open();
            if (SAdminObj.post == "Sectional Engineer" || SAdminObj.post == "Assistant Engineer Class-2")
            {
                foreach (string item in ListTblNames)
                {
                    strSqlQuery = "UPDATE " + item + " SET " + item + ".[ShakhaAbhyantaName]=N'" + SAdminObj.name + "'," + item + ".[ShakhaAbhiyantMobile]='" + SAdminObj.mobile + "' WHERE " + item + ".[ShakhaAbhyantaName]=N'" + oldName + "' and " + item + ".[SubDivision]=N'PuneEast'";
                    SqlCommand cmdMaster = new SqlCommand(strSqlQuery, con);
                    SqlCommand cmdMaster2 = new SqlCommand(strSqlQuery, conMDB);
                    int MasterrowAffected = cmdMaster.ExecuteNonQuery();
                    int MasterrowAffected2 = cmdMaster2.ExecuteNonQuery();
                }
                strSqlQuery = "UPDATE SendSms_tbl SET SendSms_tbl.[ShakhaAbhyantaName]=N'" + SAdminObj.name + "',SendSms_tbl.[ShakhaAbhiyantMobile]='" + SAdminObj.mobile + "' WHERE SendSms_tbl.[ShakhaAbhyantaName]=N'" + oldName + "' and SendSms_tbl.[SubDivision]=N'PuneEast'";
                SqlCommand cmdSmstbl = new SqlCommand(strSqlQuery, con);
                SqlCommand cmdSmstbl2 = new SqlCommand(strSqlQuery, conMDB);
                int SmsrowAffected = cmdSmstbl.ExecuteNonQuery();
                int SmsrowAffected2 = cmdSmstbl2.ExecuteNonQuery();
            }
            if (SAdminObj.post == " Deputy Engineer" || SAdminObj.post == "Deputy Engineer" || SAdminObj.post == "Assistant Engineer Class-1")
            {
                foreach (string item in ListTblNames)
                {
                    strSqlQuery = "UPDATE " + item + " SET " + item + ".[UpabhyantaName]=N'" + SAdminObj.name + "'," + item + ".[UpAbhiyantaMobile]='" + SAdminObj.mobile + "' WHERE " + item + ".[UpabhyantaName]=N'" + oldName + "' and " + item + ".[SubDivision]=N'PuneEast'";
                    SqlCommand cmdMaster = new SqlCommand(strSqlQuery, con);
                    int MasterrowAffected = cmdMaster.ExecuteNonQuery();
                    SqlCommand cmdMaster2 = new SqlCommand(strSqlQuery, conMDB);
                    int MasterrowAffected2 = cmdMaster2.ExecuteNonQuery();
                }
                strSqlQuery = "UPDATE SendSms_tbl SET SendSms_tbl.[UpabhyantaName]=N'" + SAdminObj.name + "',SendSms_tbl.[UpAbhiyantaMobile]='" + SAdminObj.mobile + "' WHERE SendSms_tbl.[UpabhyantaName]=N'" + oldName + "' and SendSms_tbl.[SubDivision]=N'PuneEast'";
                SqlCommand cmdSmstbl4 = new SqlCommand(strSqlQuery, con);
                int SmsrowAffected = cmdSmstbl4.ExecuteNonQuery();
                SqlCommand cmdSmstbl5 = new SqlCommand(strSqlQuery, conMDB);
                int SmsrowAffected2 = cmdSmstbl5.ExecuteNonQuery();
            }

            if (SAdminObj.post == "Contractor")
            {
                foreach (string item in ListTblNames)
                {
                    strSqlQuery = "UPDATE " + item + " SET " + item + ".[ThekedaarName]=N'" + SAdminObj.name + "'," + item + ".[ThekedarMobile]='" + SAdminObj.mobile + "' WHERE " + item + ".[ThekedaarName]=N'" + oldName + "' and " + item + ".[SubDivision]=N'PuneEast'";
                    SqlCommand cmdMaster = new SqlCommand(strSqlQuery, con);
                    int MasterrowAffected = cmdMaster.ExecuteNonQuery();
                    SqlCommand cmdMaster6 = new SqlCommand(strSqlQuery, conMDB);
                    int MasterrowAffected2 = cmdMaster6.ExecuteNonQuery();
                }
                strSqlQuery = "UPDATE SendSms_tbl SET SendSms_tbl.[ThekedaarName]=N'" + SAdminObj.name + "',SendSms_tbl.[ThekedarMobile]='" + SAdminObj.mobile + "' WHERE SendSms_tbl.[ThekedaarName]=N'" + oldName + "' and SendSms_tbl.[SubDivision]=N'PuneEast'";
                SqlCommand cmdSmstbl3 = new SqlCommand(strSqlQuery, con);
                int SmsrowAffected3 = cmdSmstbl3.ExecuteNonQuery();
                SqlCommand cmdSmstbl7 = new SqlCommand(strSqlQuery, conMDB);
                int SmsrowAffected4 = cmdSmstbl7.ExecuteNonQuery();

            }

            if (SAdminObj.post == "MLA")
            {
                foreach (string item in ListTblNames)
                {
                    strSqlQuery = "UPDATE " + item + " SET " + item + ".[AmdaracheName]=N'" + SAdminObj.name + "' WHERE " + item + ".[AmdaracheName]=N'" + oldName + "' and " + item + ".[SubDivision]=N'PuneEast'";
                    SqlCommand cmdMaster = new SqlCommand(strSqlQuery, con);
                    int MasterrowAffected = cmdMaster.ExecuteNonQuery();
                    SqlCommand cmdMaster1 = new SqlCommand(strSqlQuery, conMDB);
                    int MasterrowAffected1 = cmdMaster1.ExecuteNonQuery();
                }

            }

            if (SAdminObj.post == "MP")
            {
                foreach (string item in ListTblNames)
                {
                    strSqlQuery = "UPDATE " + item + " SET " + item + ".[KhasdaracheName]=N'" + SAdminObj.name + "' WHERE " + item + ".[KhasdaracheName]=N'" + oldName + "' and " + item + ".[SubDivision]=N'PuneEast'";
                    SqlCommand cmdMaster = new SqlCommand(strSqlQuery, con);
                    int MasterrowAffected = cmdMaster.ExecuteNonQuery();
                    SqlCommand cmdMaster1 = new SqlCommand(strSqlQuery, conMDB);
                    int MasterrowAffected1 = cmdMaster1.ExecuteNonQuery();
                }

            }

            con.Close();
            grdvUserAdmin.EditIndex = -1;
            GridBind();
        }

        protected void grdvUserAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SAdminObj.id = Convert.ToInt16(((Label)grdvUserAdmin.Rows[e.RowIndex].FindControl("Label4")).Text);
            SAdminObj.ScreatAdminDelete(con);
            SAdminObj.ScreatAdminDelete(conMDB);
            GridBind();
        }

        protected void grdvUserAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && grdvUserAdmin.EditIndex == e.Row.RowIndex)
            {

                DropDownList ddlPost = (DropDownList)e.Row.FindControl("DDLPost");
                Label lblPost = (Label)grdvUserAdmin.FindControl("lblPost");
                HiddenField hdnPost = (HiddenField)e.Row.FindControl("hdnPost");
                ddlPost.DataSource = SAdminObj.BindPost();
                ddlPost.DataTextField = "Post";
                ddlPost.DataValueField = "Post";
                ddlPost.DataBind();
                ddlPost.Items.FindByValue(hdnPost.Value).Selected = true;
            }
        }

        protected void ddlPost1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostFlag = true;
            if (ddlPost1.SelectedItem.Text == "All" || ddlPost1.SelectedItem.Text == "Select Post")
            {
                grdvUserAdmin.DataSource = (DataTable)ViewState["Userdt"];
                grdvUserAdmin.DataBind();
            }
            else
            {
                SortGridByPost();
            }
           // GridBind();
        }
    }
}