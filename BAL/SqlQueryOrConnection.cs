using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
namespace DataLayer
{
    public class SqlQueryOrConnection
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        DataTable dt;
        DataSet ds;

        //This Method For Get Name Of ShakhaAbhiyanta Or UpAbhiyanta
        public DataSet GetAllName_ByPost()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                ds = new DataSet();
                SqlCommand objcmd = new SqlCommand("[SP_GetAll_Name_By_Post]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.TableMappings.Add("Table", "Abhiyanta");
                objAdp.TableMappings.Add("Table1", "UpAbhiyanta");
                objAdp.TableMappings.Add("Table2", "Thekedar");
                objAdp.TableMappings.Add("Table3", "Khasdar");
                objAdp.TableMappings.Add("Table4", "Amdar");
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

        //This Method For Get All Name Of MLA & MP based on type(MLA or MP)
        public DataSet GetAllName_Of_MLA_MP(string type)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                ds = new DataSet();
                SqlCommand objcmd = new SqlCommand("[GetAll_Name_Of_MLA_MP]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@Type", type);
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
        /// <param name="HeadType"></param>
        /// <param name="ArthYear"></param>
        /// <param name="Workid"></param>
        /// <returns></returns>
        public DataTable FeachProvisionData(string HeadType, string ArthYear, string Workid)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                dt = new DataTable();
                SqlCommand objcmd = new SqlCommand("[FetchProvisionDataByType_WorkId_ArthYear]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@ArthYear", ArthYear);
                objcmd.Parameters.AddWithValue("@workid", Workid);
                objcmd.Parameters.AddWithValue("@Type", HeadType);
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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="HeadType"></param>
        /// <param name="Workid"></param>
        /// <returns></returns>
        public DataTable Feach_Master_Data(string HeadType, string Workid)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                dt = new DataTable();
                SqlCommand objcmd = new SqlCommand("[FetchMasterDataByWorkId_AndType]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@workid", Workid);
                objcmd.Parameters.AddWithValue("@Type", HeadType);
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet GetLekh_Vibhag_VarishtType(string type)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                dt = new DataTable();
                SqlCommand objcmd = new SqlCommand("[SP_GetLekha_Vibhag_Varishttype]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@Type", type);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                DataSet ds = new DataSet();
                objAdp.TableMappings.Add("Table", "VarishtType");
                objAdp.TableMappings.Add("Table1", "UpVibhag");
                objAdp.TableMappings.Add("Table2", "LekhaShirsh");
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
        /// <param name="PrefixWorkId"></param>
        /// <param name="HeadType"></param>
        /// <returns></returns>
        public List<string> GetCompletionListOfWorkID(string PrefixWorkId, string HeadType)
        {
            //dt = new DataTable();
            //SqlDataAdapter sdaa = new SqlDataAdapter("SELECT WorkID +':    '+KamacheName as 'WorkList' FROM " + frmTable + "  where WorkID like '" + PrefixWorkId + "%'", con);
            //sdaa.Fill(dt);
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                dt = new DataTable();
                SqlCommand objcmd = new SqlCommand("[GetWorkIdAndName]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@workid", PrefixWorkId);
                objcmd.Parameters.AddWithValue("@Type", HeadType);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(dt);
                List<string> WorkId_And_WorkNameList = new List<string>();
                WorkId_And_WorkNameList = dt.AsEnumerable().Select(WorkList => WorkList["WorkList"].ToString()).ToList();

                return WorkId_And_WorkNameList;
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
       /// <param name="s"></param>
       /// <returns></returns>
        public string ConvertDigits(string s)
        {
            return s
                .Replace("०", "0")
                .Replace("१", "1")
                .Replace("२", "2")
                .Replace("३", "3")
                .Replace("४", "4")
                .Replace("५", "5")
                .Replace("६", "6")
                .Replace("७", "7")
                .Replace("८", "8")
                .Replace("९", "9");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="password"></param>
        /// <returns>user Post in strUrl : and User Name</returns>
        public string CheckUserLogin(string UserId, string password)
        {
            dt = new DataTable();
            string strUrl = string.Empty;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                dt = new DataTable();
                SqlCommand objcmd = new SqlCommand("[SP_UserLogin]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@userid", UserId);
                objcmd.Parameters.AddWithValue("@pwd", password);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    strUrl = dr[2].ToString() == "Executive Engineer" || dr[2].ToString() == "Deputy Executive Engineer" || dr[2].ToString() == "Assistant Engineer Class-2 Division office" || dr[2].ToString() == "Sectional Engineer Division office" ? "SuperAdminPanel.aspx" : dr[2].ToString() == "Sectional Engineer" || dr[2].ToString() == "Assistant Engineer Class-2" || dr[2].ToString() == "Assistant Engineer Class-1" || dr[2].ToString() == " Deputy Engineer" || dr[2].ToString() == "Deputy Engineer" ? "AdminPanel.aspx" : dr[2].ToString() == "MP" || dr[2].ToString() == "MLA" ? "MLAMP_Dashboard.aspx" : dr[2].ToString() == "Contractor" ? "ThekedarPanel.aspx" : dr[2].ToString() == "Admin" ? "ImageUploadPanel.aspx" : "Invalid Username and Password";

                }
                return dt.Rows.Count > 0 ? strUrl + ":" + dt.Rows[0]["Name"].ToString() : "Invalid Username and Password";
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


        //Stored Procedure For Master Head Wise Report

        /// <summary>
        ///     Bind All DropDwonList On All MasterHeadWiseReport Form based on LekhashirshName
        ///     like MasterBuildingReport.aspx
        ///     Pass 2 parameters 1] MasterTableName and 2]Lekhashirsh name
        /// </summary>
        /// <param name="MasterTableName"> BudgetMasterBuilding </param>
        /// <param name="LekhashirshName">LekhashirshName ddl </param>
        /// <returns> data table </returns>
        public DataTable Bind_MasterReport_ddl(string MasterTableName,string LekhashirshName)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                dt = new DataTable();
                SqlCommand objcmd = new SqlCommand("[bind_MasterReport_ddl_SP]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@tableName", MasterTableName);
                objcmd.Parameters.AddWithValue("@Lekha", LekhashirshName);
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