using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace PWdEEBudget.ScreatAdmin
{
    public class clsScreatAdmin
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        public int id { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string post { get; set; }
        public string userid { get; set; }
        public string password { get; set; }
        public string strSqlCommand { get; set; }
        public void ScreatAdminUpdate(SqlConnection connection)
        {
            cmd = new SqlCommand("update SCreateAdmin set Name=@name,MobileNo=@mobile,Email=@email,Post=@post,UserId=@userid,Password=@password where ID=@id and [SubDivision]=N'PuneEast'", connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@post", post);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@id", id);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void ScreatAdminDelete(SqlConnection connection)
        {
            cmd = new SqlCommand("delete from SCreateAdmin where ID=@id and [SubDivision]=N'PuneEast'", connection);
            cmd.Parameters.AddWithValue("@id", id);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public DataSet BindPost()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                ds = new DataSet();
                SqlCommand objcmd = new SqlCommand("[GetAllPost_SP]", con);
                objcmd.CommandType = CommandType.StoredProcedure;                
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(ds);

                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Post"></param>
        /// <returns></returns>
        public DataSet BindNameByPost(string Post)
        {           
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                ds = new DataSet();
                SqlCommand objcmd = new SqlCommand("[GetNameMobByPost_SP]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@Post", Post);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(ds);

                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ComplaintId"></param>
        /// <returns></returns>
        public DataSet BindAnsGrid(string ComplaintId)
        {
            //[GetComplaintDetails_SP]
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                ds = new DataSet();
                SqlCommand objcmd = new SqlCommand("[GetComplaintDetails_SP]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@ComplaintId", ComplaintId);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(ds);

                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            
        }


        public DataTable GetAllUserProfileDetails()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                dt = new DataTable();
                SqlCommand objcmd = new SqlCommand("[GetAllUserDetails_SP]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(dt);

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}