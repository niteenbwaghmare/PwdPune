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
    public partial class Setting_Jilha : System.Web.UI.Page
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
            }
            GetID();
            //BindGrid();
            GridData();
        }
        public void GetID()
        {

            int i = 1;
            string select = "select top 1 Akrmank from SettingJilha order by Akrmank desc";
            SqlDataAdapter sda = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                i = Convert.ToInt32(dr[0].ToString());
                i++;
            }
            lblAKramak.Text = i.ToString();
        }
        //public void BindGrid()
        //{
        //    string query = "SELECT [AKrmank],[Jilha]FROM [SettingJilha]";
        //    DataTable dt = new DataTable();
        //    String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        //    SqlConnection con = new SqlConnection(strConnString);
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    SqlCommand cmd = new SqlCommand(query);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con;
        //    try
        //    {
        //        con.Open();
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO SettingJilha(AKrmank,Jilha)VALUES('" + lblAKramak.Text + "',N'" + txtjilha.Text + "')", con);
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>alert('Value succesfully Inserted.....!!!!!!')</script>");
                    GetID();
                    txtjilha.Text = "";
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
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Setting.aspx");
        }
        public void GridData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select [ID],[Jilha] from [SettingJilha]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridDist.DataSource = dt;
            GridDist.DataBind();
       }
        protected void GridDist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridDist.EditIndex = -1;
            GridData();
        }

        protected void GridDist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridDist.EditIndex = e.NewEditIndex;
            GridData();
        }
        string pName="";
        protected void GridDist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string AKrmank = GridDist.DataKeys[e.RowIndex].Values["ID"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from [SettingJilha] where ID='" + AKrmank + "'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {

            }
            GridData();
        }

        protected void GridDist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string AKrmank = GridDist.DataKeys[e.RowIndex].Value.ToString();

            string Jilha = (GridDist.Rows[e.RowIndex].FindControl("txtjilha") as TextBox).Text;

            GridDist.EditIndex = -1;
            con.Open();

            SqlCommand cmd = new SqlCommand("update SettingJilha set Jilha=N'" + Jilha + "' where ID='" + AKrmank + "'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {

            }
            con.Close();
            GridData();
        }

    }
}