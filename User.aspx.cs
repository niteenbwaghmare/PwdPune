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
    public partial class User : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
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
                GridData();
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }
        public void all()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select FName,MName,LName,Office,Post,OfficeAddress,PermanemtAddress,LocalAddress,DOB,NDate,Gender,Status,Village,Taluka,Dist,Nationality,MobileNo,EmailId from [User] where UserId='"+txtid.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lblFName.Text = dr["FName"].ToString();
                lblMName.Text = dr["MName"].ToString();
                lblLName.Text = dr["LName"].ToString();
                txtOffice.Text = dr["Office"].ToString();
                txtPost.Text = dr["Post"].ToString();
                lblOffAdd.Text = dr["OfficeAddress"].ToString();
                lblPerAdd.Text = dr["PermanemtAddress"].ToString();
                lbllocalAddress.Text = dr["LocalAddress"].ToString();
                lblDOB.Text = dr["DOB"].ToString();
                lblNDate.Text = dr["NDate"].ToString();
                lblGender.Text = dr["Gender"].ToString();
                lblSatus.Text = dr["Status"].ToString();
                lblVillage.Text = dr["Village"].ToString();
                lblTaluka.Text = dr["Taluka"].ToString();
                lblDist.Text = dr["Dist"].ToString();
                lblRastiyatv.Text = dr["Nationality"].ToString();
                lblMobNo.Text = dr["MobileNo"].ToString();
                lblEmail.Text = dr["EmailId"].ToString();


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [User] SET Office='"+txtOffice.Text+"', Post='"+txtPost.Text+"'", con);
                cmd.CommandType = CommandType.Text;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>alert('Value Updated.....!!!!!!')</script>");
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

        protected void txtid_TextChanged(object sender, EventArgs e)
        {
            all();
        }
        public void GridData()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select ID,FName+' '+MName+' '+LName as Name,Office,Post,OfficeAddress,PermanemtAddress,LocalAddress,DOB,NDate,Gender,Status,Village,Taluka,Dist,Nationality,MobileNo,EmailId from [User]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ViewState["dt"] = dt;
            GridView1.DataSource = ViewState["dt"] as DataTable;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string ID = GridView1.DataKeys[e.RowIndex].Values["ID"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from [User] where ID='" + ID + "'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {

            }

            con.Close();
            GridData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lblID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string Name = (GridView1.Rows[e.RowIndex].FindControl("txtUname") as TextBox).Text;
            string Karyalay = (GridView1.Rows[e.RowIndex].FindControl("txtKaryalay") as TextBox).Text;
            string Post = (GridView1.Rows[e.RowIndex].FindControl("txtPost") as TextBox).Text;
               string Peradd = (GridView1.Rows[e.RowIndex].FindControl("txtPeradd") as TextBox).Text;
            string karyalayAdd = (GridView1.Rows[e.RowIndex].FindControl("txtkaryalayAdd") as TextBox).Text;
            string Localadd = (GridView1.Rows[e.RowIndex].FindControl("txtLocaladd") as TextBox).Text;
            string BirthDate = (GridView1.Rows[e.RowIndex].FindControl("txtBirthDate") as TextBox).Text;
            string Ndate = (GridView1.Rows[e.RowIndex].FindControl("txtNdate") as TextBox).Text;
            string Gender = (GridView1.Rows[e.RowIndex].FindControl("txtGender") as TextBox).Text;
            string Status = (GridView1.Rows[e.RowIndex].FindControl("txtStatus") as TextBox).Text;
            string Village = (GridView1.Rows[e.RowIndex].FindControl("txtVillage") as TextBox).Text;
            string Taluka = (GridView1.Rows[e.RowIndex].FindControl("txtTaluka") as TextBox).Text;
            string Dist = (GridView1.Rows[e.RowIndex].FindControl("txtDist") as TextBox).Text;
            string Rastiyatv = (GridView1.Rows[e.RowIndex].FindControl("txtRastiyatv") as TextBox).Text;
            string MobNo = (GridView1.Rows[e.RowIndex].FindControl("txtMobNo") as TextBox).Text;
            string EmailId = (GridView1.Rows[e.RowIndex].FindControl("txtEmailId") as TextBox).Text;
           
            GridView1.EditIndex = -1;
            con.Open();
            SqlCommand cmd = new SqlCommand("update User set FName+' '+MName+' '+LName as Name='" + Name + "',Office='" + Karyalay + "',Post='" + Post + "',OfficeAddress='" + karyalayAdd + "',PermanemtAddress='"+Peradd+"',LocalAddress='"+Localadd+"',DOB='"+BirthDate+"',NDate='"+Ndate+"',Gender='"+Gender+"',Status='"+Status+"',Village='"+Village+"',Taluka='"+Taluka+"',Dist='"+Dist+"',Nationality='"+Rastiyatv+"',MobileNo='"+MobNo+"',EmailId='"+EmailId+"'  where ID='" + lblID + "'", con);
            
            if (cmd.ExecuteNonQuery() > 0)
            {

            }
            con.Close();
            GridData();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridData();
        }


        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].ForeColor = System.Drawing.Color.Blue;
            e.Row.Cells[0].BorderColor = System.Drawing.Color.Black;
        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridData();
        }

    }
}