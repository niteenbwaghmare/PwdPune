﻿using System;
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
    public partial class Setting_VarishtType : System.Web.UI.Page
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
                Session["id"] = Label1.Text;
                ShowData();
            }
            GetID();
          
        }
        public void GetID()
        {

            int i = 0;
            string select = "select top 1 Akrmank from SettingVarishtType order by Akrmank desc";
            SqlDataAdapter sda = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                i = Convert.ToInt32(dr[0].ToString());
                i++;
                lblAKramak.Text = i.ToString();
            }


        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO SettingVarishtType(AKrmank,VarishtType)VALUES('" + lblAKramak.Text + "',N'" + txtType.Text + "')", con);
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>alert('Value succesfully Inserted.....!!!!!!')</script>");
                    GetID();
                    ShowData();
                    txtType.Text = "";
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
        protected void ShowData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT [AKrmank],[VarishtType] FROM [SettingVarishtType]", con);
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string AKrmank = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string txtVarishtType = (GridView1.Rows[e.RowIndex].FindControl("txtVarishtType") as TextBox).Text;

            GridView1.EditIndex = -1;
            con.Open();

            SqlCommand cmd = new SqlCommand("update SettingVarishtType set VarishtType=N'" + txtVarishtType + "' where AKrmank='" + AKrmank + "'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {

            }
            con.Close();
            ShowData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string AKrmank = GridView1.DataKeys[e.RowIndex].Values["AKrmank"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from [SettingVarishtType] where AKrmank='" + AKrmank + "'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {

            }
            ShowData();

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].ForeColor = System.Drawing.Color.Blue;
            e.Row.Cells[0].BorderColor = System.Drawing.Color.Black;
        }

    }
}