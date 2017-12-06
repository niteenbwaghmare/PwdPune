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
    public partial class Setting_AddMLA : System.Web.UI.Page
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
                ShowData();
            }
            GetID();

            if (ddlMLAType.SelectedItem.Text == "Choose")
            {
                ddlsabha.Items.Clear();
            }

        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Setting");
        }
        public void GetID()
        {

            int i = 1;
            string select = "select top 1 AKrmank from SettingAddMLA order by Akrmank desc";
            SqlDataAdapter sda = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                i = Convert.ToInt32(dr[0].ToString());
                i++;
            }
            lblId.Text = i.ToString();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO SettingAddMLA(Akrmank,MLAType,Name,PName)VALUES('" + lblId.Text + "','" + ddlMLAType.SelectedItem.Text + "', N'" + txtName.Text + "',N'" + ddlsabha.SelectedItem.Text + "')", con);
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>alert('Value succesfully Inserted.....!!!!!!')</script>");
                    GetID();
                    ShowData();
                    txtName.Text = "";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Setting.aspx");
        }

        protected void ddlMLAType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMLAType.SelectedItem.Text == "Amdar")
            {
                ddlsabha.Items.Clear();
                ddlsabha.Items.Add("VidhanSabha MLA");
                ddlsabha.Items.Add("Vidhan Parishad MLA");
            }
            if (ddlMLAType.SelectedItem.Text == "Khasdar")
            {
                ddlsabha.Items.Clear();
                ddlsabha.Items.Add("Lok Sabha MP");
                ddlsabha.Items.Add("Rajya Sabha MP");
            }
            if (ddlMLAType.SelectedItem.Text == "Choose")
            {
                ddlsabha.Items.Clear();
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }
        protected void ShowData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT AKrmank,MLAType,Name FROM SettingAddMLA", con);
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
            string AKrmank = GridView1.DataKeys[e.RowIndex].Values["AKrmank"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from [SettingAddMLA] where AKrmank='" + AKrmank + "'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {

            }
            ShowData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            string AKrmank = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string MLAType = (GridView1.Rows[e.RowIndex].FindControl("lblMLAType") as Label).Text;
            string Name = (GridView1.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text;
            //((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName")).Text;

            string oldName = Convert.ToString(((Label)GridView1.Rows[e.RowIndex].FindControl("oldNamelbl")).Text);
            GridView1.EditIndex = -1;
            con.Open();

            SqlCommand cmd = new SqlCommand("update SettingAddMLA set Name=N'" + Name + "'  where AKrmank='" + AKrmank + "'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {

                List<string> ListTblNames = new List<string>() { "BudgetMasterBuilding", "BudgetMasterCRF", "BudgetMasterDepositFund", "BudgetMasterDPDC", "BudgetMasterGAT_A", "BudgetMasterGAT_D", "BudgetMasterGAT_FBC", "BudgetMasterMLA", "BudgetMasterMP", "BudgetMasterNABARD", "BudgetMasterNonResidentialBuilding", "BudgetMasterResidentialBuilding", "BudgetMasterRoad", "BudgetMasterAunty", "BudgetMaster2515" };
                if (MLAType == "Amdar")
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    foreach (string item in ListTblNames)
                    {
                        SqlCommand cmdMaster = new SqlCommand("UPDATE " + item + " SET " + item + ".[AmdaracheName]=N'" + Name + "' WHERE " + item + ".[AmdaracheName]=N'" + oldName + "'", con);
                        int MasterrowAffected = cmdMaster.ExecuteNonQuery();
                    }

                }
                if (MLAType == "Khasdar")
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    foreach (string item in ListTblNames)
                    {
                        SqlCommand cmdMaster = new SqlCommand("UPDATE " + item + " SET " + item + ".[KhasdaracheName]=N'" + Name + "' WHERE " + item + ".[KhasdaracheName]=N'" + oldName + "'", con);
                        int MasterrowAffected = cmdMaster.ExecuteNonQuery();
                    }
                }
                ShowData();
                lblStatus.Text = "<b style='color:green'>Record updated successfully!!!</b>";
            }
            con.Close();
        }


    }
}