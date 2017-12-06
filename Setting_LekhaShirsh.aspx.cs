using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class Setting_LekhaShirsh : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
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
                //Session["id"] = Label1.Text;
                GetID();
                ShowData();
                typeadd();
            }
           
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Setting.aspx");
        }
        public void GetID()
        {

            int i = 1;
            SqlDataAdapter sda = new SqlDataAdapter("select top 1 id from SettingLekhaShirsh order by id desc", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                i = Convert.ToInt32(dr[0].ToString());
                i++;
            }
            lblAKrmank.Text = i.ToString();
        }

        public void typeadd()
        {
            ddlType.Items.Clear();
            ddlType.Items.Add("......निवडा.......");
            SqlDataAdapter sda = new SqlDataAdapter("select Type from SettingType", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
               ddlType.Items.Add(dr["Type"].ToString());
            }
        }
        protected void Btnsub_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (ddlType.SelectedItem.Text != "......निवडा.......")
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO SettingLekhaShirsh(Type,code,LekhaShirsh)VALUES(N'" + ddlType.SelectedItem.Text + "',N'" + txtcode.Text + "',N'" + Txttype.Text + "')", con);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        Response.Write("<script>alert('Value succesfully Inserted.....!!!!!!')</script>");
                        GetID();
                        ShowData();
                        Txttype.Text = "";
                        txtcode.Text = "";
                        typeadd();
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                }
                else
                {
                    Response.Write("<script>alert('Select the प्रकार...!!!!!!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        protected void ShowData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT [ID],[Type],[code],[LekhaShirsh] FROM [SettingLekhaShirsh]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ShowData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].ForeColor = System.Drawing.Color.Blue;
            e.Row.Cells[0].BorderColor = System.Drawing.Color.Black;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ID = GridView1.DataKeys[e.RowIndex].Values["ID"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from [SettingLekhaShirsh] where ID='" + ID + "'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {

            }
            ShowData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string Type = (GridView1.Rows[e.RowIndex].FindControl("lblType") as Label).Text;
            string code = (GridView1.Rows[e.RowIndex].FindControl("txtcode") as TextBox).Text;
            string LekhaShirsh = (GridView1.Rows[e.RowIndex].FindControl("txtLekhaShirsh") as TextBox).Text;
            string oldLekhaCode = Convert.ToString(((Label)GridView1.Rows[e.RowIndex].FindControl("oldLekhaCodelbl")).Text);
            GridView1.EditIndex = -1;
            con.Open();

            SqlCommand cmd = new SqlCommand("update SettingLekhaShirsh set code=N'" + code + "',LekhaShirsh=N'" + LekhaShirsh + "' where ID='" + ID + "'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmdMasterBtbl = new SqlCommand("UPDATE BudgetMasterBuilding SET BudgetMasterBuilding.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterBuilding.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterBuilding WHERE BudgetMasterBuilding.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);
                int MasterBrowAffected = cmdMasterBtbl.ExecuteNonQuery();

                SqlCommand cmdMasterCRFtbl = new SqlCommand("UPDATE BudgetMasterCRF SET BudgetMasterCRF.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterCRF.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterCRF WHERE BudgetMasterCRF.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);
                int MasterCRFrowAffected = cmdMasterCRFtbl.ExecuteNonQuery();

                SqlCommand cmdMasterDepositFundtbl = new SqlCommand("UPDATE BudgetMasterDepositFund  SET BudgetMasterDepositFund.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterDepositFund.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterDepositFund WHERE BudgetMasterDepositFund.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);
                int MasterDFrowAffected = cmdMasterDepositFundtbl.ExecuteNonQuery();

                SqlCommand cmdMasterDPDC = new SqlCommand("UPDATE BudgetMasterDPDC SET BudgetMasterDPDC.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterDPDC.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterDPDC WHERE BudgetMasterDPDC.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);
                int MasterDPDCrowAffected = cmdMasterDPDC.ExecuteNonQuery();

                SqlCommand cmdMasterGAT_A = new SqlCommand("UPDATE BudgetMasterGAT_A SET BudgetMasterGAT_A.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterGAT_A.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterGAT_A WHERE BudgetMasterGAT_A.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);
                int MasterGatArowAffected = cmdMasterGAT_A.ExecuteNonQuery();

                SqlCommand cmdMasterGatD = new SqlCommand("UPDATE BudgetMasterGAT_D SET BudgetMasterGAT_D.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterGAT_D.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterGAT_D WHERE BudgetMasterGAT_D.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);
                int MasterGatDrowAffected = cmdMasterGatD.ExecuteNonQuery();

                SqlCommand cmdMasterGAT_FBC = new SqlCommand("UPDATE BudgetMasterGAT_FBC SET BudgetMasterGAT_FBC.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterGAT_FBC.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterGAT_FBC WHERE BudgetMasterGAT_FBC.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);
                int MasterGatFBCrowAffected = cmdMasterGAT_FBC.ExecuteNonQuery();

                SqlCommand cmdMasterMLA = new SqlCommand("UPDATE BudgetMasterMLA SET BudgetMasterMLA.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterMLA.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterMLA WHERE BudgetMasterMLA.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);
                int MasterMLArowAffected = cmdMasterMLA.ExecuteNonQuery();

                SqlCommand cmdMasterMP = new SqlCommand("UPDATE BudgetMasterMP SET BudgetMasterMP.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterMP.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterMP WHERE BudgetMasterMP.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);

                int MasterMProwAffected = cmdMasterMP.ExecuteNonQuery();

                SqlCommand cmdMasterNabard = new SqlCommand("UPDATE BudgetMasterNABARD SET BudgetMasterNABARD.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterNABARD.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterNABARD WHERE BudgetMasterNABARD.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);

                int MasterNabardrowAffected = cmdMasterNabard.ExecuteNonQuery();

                SqlCommand cmdMasterNRB = new SqlCommand("UPDATE BudgetMasterNonResidentialBuilding SET BudgetMasterNonResidentialBuilding.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterNonResidentialBuilding.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterNonResidentialBuilding WHERE BudgetMasterNonResidentialBuilding.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);

                int MasterNRBrowAffected = cmdMasterNRB.ExecuteNonQuery();

                SqlCommand cmdMasterRB = new SqlCommand("UPDATE BudgetMasterResidentialBuilding SET BudgetMasterResidentialBuilding.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterResidentialBuilding.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterResidentialBuilding WHERE BudgetMasterResidentialBuilding.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);

                int MasterRBrowAffected = cmdMasterRB.ExecuteNonQuery();

                SqlCommand cmdMasterRoad = new SqlCommand("UPDATE BudgetMasterRoad SET BudgetMasterRoad.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterRoad.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterRoad WHERE BudgetMasterRoad.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);

                int MasterRoadrowAffected = cmdMasterRoad.ExecuteNonQuery();

                SqlCommand cmdMasterAnnuity = new SqlCommand("UPDATE BudgetMasterAunty SET BudgetMasterAunty.[LekhaShirshName]=N'" + LekhaShirsh + "',BudgetMasterAunty.[LekhaShirsh]=N'" + code + "' FROM BudgetMasterAunty WHERE BudgetMasterAunty.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);

                int MasterAnnuityrowAffected = cmdMasterAnnuity.ExecuteNonQuery();

                //SqlCommand cmdSmstbl = new SqlCommand("UPDATE SendSms_tbl SET SendSms_tbl.[LekhaShirshName]=N'" + LekhaShirsh + "',SendSms_tbl.[LekhaShirsh]=N'" + code + "' FROM SendSms_tbl,SCreateAdmin WHERE SendSms_tbl.[LekhaShirsh]=N'" + oldLekhaCode + "'", con);
                //int SmsrowAffected = cmdSmstbl.ExecuteNonQuery();
                ShowData();
                lblStatus.Text = "<b style='color:green'>Record updated successfully!!!</b>"; 
            }
            con.Close();
              
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
          
        }
       
     
    }
}