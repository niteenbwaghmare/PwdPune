using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Net;

namespace PWdEEBudget.SMS_CRUD
{
    public class clsSMS_CRUD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        SqlConnection conMDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnMDBString"].ConnectionString);
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        DataTable dt;
        SqlCommand cmd, cmd1, cmd2, cmdMDB;
        string strcmd = string.Empty;

        public int smsid { get; set; }
        public string workid { get; set; }
        public string shakhaabhyantaname { get; set; }
        public string shakhaabhyantamobile { get; set; }
        public string upabhyantaname { get; set; }
        public string upabhyantamobile { get; set; }
        public string kamachename { get; set; }
        public string thekedarname { get; set; }
        public string thekedarmobile { get; set; }
        public string kampurndate { get; set; }
        public string Message { get; set; }
        public string mudatvaddate { get; set; }

        public void InsertSMSRecord()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                if (conMDB.State != ConnectionState.Open)
                    conMDB.Open();
                if (kampurndate == '0'.ToString())
                {
                    kampurndate = "";
                }
                cmd = new SqlCommand("Select WorkId from SendSms_tbl where WorkId= '" + workid + "'", con);
                if ((dr = cmd.ExecuteReader()).HasRows)
                {
                    dr.Read();
                    if (workid == dr["WorkId"].ToString())
                    {
                        dr.Close();

                        UpdateSMSRecord(workid);
                    }

                }
                else
                {
                    dr.Close();
                    string strQuery = "Insert into SendSms_tbl(WorkId,ShakhaAbhyantaName,ShakhaAbhiyantMobile,UpabhyantaName,UpAbhiyantaMobile,KamacheName,ThekedaarName,ThekedarMobile,KamPurnDate,MudatVadDate,SubDivision)values('" + workid + "',N'" + shakhaabhyantaname + "',N'" + shakhaabhyantamobile + "',N'" + upabhyantaname + "',N'" + upabhyantamobile + "',N'" + kamachename + "',N'" + thekedarname + "',N'" + thekedarmobile + "',N'" + kampurndate + "',N'" + mudatvaddate + "','PuneEast')";
                    cmd1 = new SqlCommand(strQuery, con);
                    cmdMDB = new SqlCommand(strQuery, conMDB);
                    //con.Open();
                    //cmd = new SqlCommand(strcmd, con);
                    cmd1.ExecuteNonQuery();
                    cmdMDB.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                con.Close();
            }


        }


        public void UpdateSMSRecord(string workid)
        {
            string sqlQuery = "update SendSms_tbl set ShakhaAbhyantaName=@ShakhaAbName,ShakhaAbhiyantMobile=@ShakhaAbMobile,UpabhyantaName=@upAbhName,UpAbhiyantaMobile=@upAbhMobile,KamacheName=@kamacheName,ThekedaarName=@thekedarName,ThekedarMobile=@thekedarMobile,KamPurnDate=@kampurnDate,MudatVadDate=@mudatvatDate,BeforMonth=@beforemonth,Befor_15Days=@befor_15day,Befor_7Days=@before_7day,Befor_3Days=@before_3day,Befor_1Day=@before_1day,SameDays=@sameday where WorkId=@workId and SubDivision='PuneEast'";
            cmd2 = new SqlCommand(sqlQuery, con);
            cmdMDB = new SqlCommand(sqlQuery, con);

            cmd2.Parameters.AddWithValue("@ShakhaAbName", shakhaabhyantaname);
            cmd2.Parameters.AddWithValue("@ShakhaAbMobile", shakhaabhyantamobile);
            cmd2.Parameters.AddWithValue("@upAbhName", upabhyantaname);
            cmd2.Parameters.AddWithValue("@upAbhMobile", upabhyantamobile);
            cmd2.Parameters.AddWithValue("@kamacheName", kamachename);
            cmd2.Parameters.AddWithValue("@thekedarName", thekedarname);
            cmd2.Parameters.AddWithValue("@thekedarMobile", thekedarmobile);
            cmd2.Parameters.AddWithValue("@kampurnDate", kampurndate);
            cmd2.Parameters.AddWithValue("@mudatvatDate", mudatvaddate);
            cmd2.Parameters.AddWithValue("@beforemonth", 0);
            cmd2.Parameters.AddWithValue("@befor_15day", 0);
            cmd2.Parameters.AddWithValue("@before_7day", 0);
            cmd2.Parameters.AddWithValue("@before_3day", 0);
            cmd2.Parameters.AddWithValue("@before_1day", 0);
            cmd2.Parameters.AddWithValue("@sameday", 0);
            cmd2.Parameters.AddWithValue("@workId", workid);

            cmdMDB.Parameters.AddWithValue("@ShakhaAbName", shakhaabhyantaname);
            cmdMDB.Parameters.AddWithValue("@ShakhaAbMobile", shakhaabhyantamobile);
            cmdMDB.Parameters.AddWithValue("@upAbhName", upabhyantaname);
            cmdMDB.Parameters.AddWithValue("@upAbhMobile", upabhyantamobile);
            cmdMDB.Parameters.AddWithValue("@kamacheName", kamachename);
            cmdMDB.Parameters.AddWithValue("@thekedarName", thekedarname);
            cmdMDB.Parameters.AddWithValue("@thekedarMobile", thekedarmobile);
            cmdMDB.Parameters.AddWithValue("@kampurnDate", kampurndate);
            cmdMDB.Parameters.AddWithValue("@mudatvatDate", mudatvaddate);
            cmdMDB.Parameters.AddWithValue("@beforemonth", 0);
            cmdMDB.Parameters.AddWithValue("@befor_15day", 0);
            cmdMDB.Parameters.AddWithValue("@before_7day", 0);
            cmdMDB.Parameters.AddWithValue("@before_3day", 0);
            cmdMDB.Parameters.AddWithValue("@before_1day", 0);
            cmdMDB.Parameters.AddWithValue("@sameday", 0);
            cmdMDB.Parameters.AddWithValue("@workId", workid);
            if (con.State != ConnectionState.Open)
                con.Open();
            if (conMDB.State != ConnectionState.Open)
                conMDB.Open();
            cmd2.ExecuteNonQuery();
            cmdMDB.ExecuteNonQuery();


        }
        //Send SMS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="message"></param>
        public void SendSMS(string contact, string message) //sms sending 
        {
            try
            {
                string senderid = "EEesPN";
                string userid = "sghitech";
                //string authkey = "72BB2C15-7EA2-4951-BCF2-AC2C1CB4D468";
                string authkey = "136969AqSChbw2jT85876374f";
                string type = "Unicode";
                //string URL = "http://dndsms.perfectsms.in/SecureApi.aspx?usr=" + userid + "&key=" + authkey + "&smstype=" + type + "&to=" + contact + "&msg=" + message + "&rout=Transactional&from=" + senderid + "";
                string URL = "http://www.bulksms99.in/api/sendhttp.php?authkey=" + authkey + "&mobiles=" + contact + "&message=" + message + "&sender=" + senderid + "&route=4&unicode=1";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "GET";
                request.Timeout = 30000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }
        //BindChart Method for Binding a Chart On Home Page
        public DataTable BindChart()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand objcmd = new SqlCommand("[BindChart_SP]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                dt = new DataTable();
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