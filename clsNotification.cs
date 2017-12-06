using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PWdEEBudget
{
    public class clsNotification
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());

        string type = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        public string Notification(string notificationId)
        {
            //


            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                DataTable dt = new DataTable();
                SqlCommand objcmd = new SqlCommand("[NotificationId_SP]", conn);
                objcmd.Parameters.AddWithValue("@notificationId", notificationId);
                objcmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(objcmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    type = dr[0].ToString() + dr[1].ToString() + dr[2].ToString() + dr[3].ToString() + dr[4].ToString() + dr[5].ToString() + dr[6].ToString() + dr[7].ToString() + dr[8].ToString() + dr[9].ToString() + dr[10].ToString();
                }

                return type;


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}