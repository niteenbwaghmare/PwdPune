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
using PWdEEBudget.ScreatAdmin;

namespace PWdEEBudget
{
    public partial class CreateAdmin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        SqlConnection conMDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnMDBString"].ToString());
        clsScreatAdmin SAdminObj = new clsScreatAdmin();
        SqlCommand cmdMDB = new SqlCommand();
        SqlDataAdapter da;
        DataSet ds;
        string strMasterInsertQuery = string.Empty;
        string strcmd = string.Empty;
        int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    Label1.Text = Session["id"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                Session["id"] = Label1.Text;
                GridBind();
            }
        }

        public void GetID()
        {
            con.Open();
            string select = "select top 1 ID from SCreateAdmin order by ID desc";
            SqlCommand cmd1 = new SqlCommand(select, con);
            i = Convert.ToInt32(cmd1.ExecuteScalar());
            i++;
            con.Close();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string s = txtUserName.Text + " " + txtUserMName.Text + " " + txtUserLName.Text;
                SqlCommand cmd = new SqlCommand("INSERT INTO SCreateAdmin(FName,MName,LName,Name,MobileNo,Email,Post,Office,UserId,Password,SubDivision)VALUES(N'" + txtUserName.Text + "',N'" + txtUserMName.Text + "',N'" + txtUserLName.Text + "',N'" + s + "',N'" + txtMobileNo.Text + "',N'" + txtEmail.Text + "',N'" + ddlpost.Text + "',N'" + ddloffice.Text + "',N'" + lblUserId.Text + "',N'" + lblPassword.Text + "',N'PuneEast')", con);
                SqlCommand cmd1;
                SqlCommand cmd2 = new SqlCommand("INSERT INTO SCreateAdmin(FName,MName,LName,Name,MobileNo,Email,Post,Office,UserId,Password,SubDivision)VALUES(N'" + txtUserName.Text + "',N'" + txtUserMName.Text + "',N'" + txtUserLName.Text + "',N'" + s + "',N'" + txtMobileNo.Text + "',N'" + txtEmail.Text + "',N'" + ddlpost.Text + "',N'" + ddloffice.Text + "',N'" + lblUserId.Text + "',N'" + lblPassword.Text + "',N'PuneEast')", conMDB);
                if (ddlpost.SelectedItem.Text == "Executive Engineer" || ddlpost.SelectedItem.Text == "Deputy Executive Engineer" || ddlpost.SelectedItem.Text == "Deputy Engineer")
                {
                    strMasterInsertQuery = "insert into Login (UserId,Password,Status,SubDivision)values(N'" + lblUserId.Text + "',N'" + lblPassword.Text + "','Admin',N'PuneEast')";
                    cmd1 = new SqlCommand(strMasterInsertQuery, con);
                    cmdMDB = new SqlCommand(strMasterInsertQuery, conMDB);
                }
                else if (ddlpost.SelectedItem.Text == "Junior Engineer")
                {
                    strMasterInsertQuery = "insert into Login (UserId,Password,Status,SubDivision)values(N'" + lblUserId.Text + "',N'" + lblPassword.Text + "','JE',N'PuneEast')";
                    cmd1 = new SqlCommand(strMasterInsertQuery, con);
                    cmdMDB = new SqlCommand(strMasterInsertQuery, conMDB);
                }
                else if (ddlpost.SelectedItem.Text == "Contractor")
                {
                    strMasterInsertQuery = "insert into Login (UserId,Password,Status,SubDivision)values(N'" + lblUserId.Text + "',N'" + lblPassword.Text + "','CN',N'PuneEast')";
                    cmd1 = new SqlCommand(strMasterInsertQuery, con);
                    cmdMDB = new SqlCommand(strMasterInsertQuery, conMDB);
                }
                else
                {
                    strMasterInsertQuery = "insert into Login (UserId,Password,Status,SubDivision)values(N'" + lblUserId.Text + "',N'" + lblPassword.Text + "','User',N'PuneEast')";
                    cmd1 = new SqlCommand(strMasterInsertQuery, con);
                    cmdMDB = new SqlCommand(strMasterInsertQuery, conMDB);
                }
                if (cmd.ExecuteNonQuery() > 0 && cmd2.ExecuteNonQuery() > 0)
                {
                    lblStatus.Text = "<b style='color:green'>Record Inserted successfully!!!</b>";
                    cmd1.ExecuteNonQuery();
                    cmdMDB.ExecuteNonQuery();
                    sendSms();
                    cleardata();
                    GridBind();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public void cleardata()
        {
            txtUserName.Text = "";
            txtUserMName.Text = "";
            txtUserLName.Text = "";
            txtMobileNo.Text = "";
            txtEmail.Text = "";
            //ddlpost.SelectedItem.Text = "";
            ddlpost.SelectedIndex = 0;
            //ddloffice.SelectedItem.Text = "";
            ddloffice.SelectedIndex = 0;
            lblUserId.Text = "";
            lblPassword.Text = "";
        }
        protected void ddloffice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void sendSms()
        {
            //Your authentication key
            string authKey = "87340AUVjSPCh55892127";
            //Multiple mobiles numbers separated by comma
            string msg;
            string mobileNumber = txtMobileNo.Text;
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = "PWDEPB";
            //Your message to send, Add URL encoding here.


            msg = "Welcome to PWD East Pune\n  User Name: " + lblUserId.Text + "\n Password:" + lblPassword.Text + "\n Website:http://www.eepwdeastpunebudget.com \n Help:info@eepwdeastpunebudget.com";
            //Prepare you post parameters

            string message = HttpUtility.UrlEncode(msg);
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "default");

            try
            {
                //Call Send SMS API
                string sendSMSUri = "http://smsgateway.elitesoftwares.co.in/sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();
            }
            catch (SystemException ex)
            {

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }

        protected void ddlpost_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetID();
            string j = "Pwd";
            lblUserId.Text = j + ddlpost.Text.Replace(" ", "") + i;
            lblPassword.Text = txtMobileNo.Text;
        }
        public void GridBind()
        {
            //strcmd = "SELECT [ID],[Name],[MobileNo],[Email],[Post],[UserId],[Password]FROM [SCreateAdmin] order by [ID]";

            strcmd = "SELECT [ID],[Name],[MobileNo],[Email],[Post],[UserId],[Password] FROM [SCreateAdmin] order by  case Post when N'Executive Engineer' then 1 when N'Deputy Executive Engineer' then 2 when N' Deputy Engineer' then 3 when N'Deputy Engineer' then 4 when N'Assistant Engineer Class-1' then 5 when N'Assistant Engineer Class-2 Division office' then 6 when N'Assistant Engineer Class-2' then 7 when N'Sectional Engineer Division office' then 8 when N'Sectional Engineer' then 9 when N'Junior Engineer' then 10 when N'Divisional Accountant' then 11 when N'Senior Auditer' then 12 when N'Senior Clerk' then 13 when N'Junior Clerk' then 14 when N'Contractor' then 15 when N'Others' then 16 end ";


            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            da = new SqlDataAdapter(strcmd, con);
            ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SAdminObj.id = Convert.ToInt16(((Label)GridView1.Rows[e.RowIndex].FindControl("Label4")).Text);
            SAdminObj.ScreatAdminDelete(con);
            SAdminObj.ScreatAdminDelete(conMDB);
            lblStatus.Text = "<b style='color:green'>Record Deleted successfully!!!</b>";
            GridBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string strSqlQuery;
            SAdminObj.id = Convert.ToInt16(((Label)GridView1.Rows[e.RowIndex].FindControl("lblId")).Text);
            SAdminObj.name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName")).Text;
            SAdminObj.mobile = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtMobile")).Text;
            SAdminObj.email = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmail")).Text;
            SAdminObj.post = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DDLPost")).SelectedValue;
            SAdminObj.userid = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUserId")).Text;
            SAdminObj.password = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPassword")).Text;
            string oldName = Convert.ToString(((Label)GridView1.Rows[e.RowIndex].FindControl("oldNamelbl")).Text);
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
                strSqlQuery = "UPDATE SendSms_tbl SET SendSms_tbl.[ShakhaAbhyantaName]=N'" + SAdminObj.name + "',SendSms_tbl.[ShakhaAbhiyantMobile]='" + SAdminObj.mobile + "' WHERE SendSms_tbl.[ShakhaAbhyantaName]=N'" + oldName + "'";
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
                strSqlQuery = "UPDATE SendSms_tbl SET SendSms_tbl.[UpabhyantaName]=N'" + SAdminObj.name + "',SendSms_tbl.[UpAbhiyantaMobile]='" + SAdminObj.mobile + "' WHERE SendSms_tbl.[UpabhyantaName]=N'" + oldName + "'";
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
                strSqlQuery="UPDATE SendSms_tbl SET SendSms_tbl.[ThekedaarName]=N'" + SAdminObj.name + "',SendSms_tbl.[ThekedarMobile]='" + SAdminObj.mobile + "' WHERE SendSms_tbl.[ThekedaarName]=N'" + oldName + "'";
                SqlCommand cmdSmstbl3 = new SqlCommand(strSqlQuery, con);
                int SmsrowAffected3 = cmdSmstbl3.ExecuteNonQuery();
                SqlCommand cmdSmstbl7 = new SqlCommand(strSqlQuery, conMDB);
                int SmsrowAffected4 = cmdSmstbl7.ExecuteNonQuery();

            }
            lblStatus.Text = "<b style='color:green'>Record Updated successfully!!!</b>";
            GridView1.EditIndex = -1;
            GridBind();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

    }
}