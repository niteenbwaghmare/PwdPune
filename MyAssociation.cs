using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;

namespace PWdEEBudget.MyAssociationPortal.BusinessLayer
{
    public class MyAssociation
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        public void SendSMS(string message1, string ThekedaarMobile, string ShakhaAbhyantMobile, string UpbhyantaMobile)
        {
            string ExecutiveMobile = string.Empty;
            SqlDataAdapter sda = new SqlDataAdapter("select [Name],[Post],[MobileNo] from [SCreateAdmin] where [Post]='Executive Engineer' ", con);
            DataTable dtn = new DataTable();
            sda.Fill(dtn);
            foreach (DataRow dr in dtn.Rows)
            {
                ExecutiveMobile = dr["MobileNo"].ToString();
            }
            string[] contactlist = new string[4];
            contactlist[0] = ThekedaarMobile;
            contactlist[1] = ShakhaAbhyantMobile;
            contactlist[2] = UpbhyantaMobile;
            contactlist[3] = ExecutiveMobile;
            try
            {
                foreach (var contact1 in contactlist)
                {
                    if (contact1 == "0000000000" || contact1 == "")
                    {
                        //continue;
                    }
                    else
                    {
                        //string senderid = "EEesPN";
                        //string userid = "sghitech";
                        //string authkey = "72BB2C15-7EA2-4951-BCF2-AC2C1CB4D468";
                        //string type = "Unicode";
                        //string URL = "http://dndsms.perfectsms.in/SecureApi.aspx?usr=" + userid + "&key=" + authkey + "&smstype=" + type + "&to=" + contact1 + "&msg=" + message1 + "&rout=Transactional&from=" + senderid + "";
                        string senderid = "EEesPN";
                        string userid = "Sghitech";
                        //string authkey = "72BB2C15-7EA2-4951-BCF2-AC2C1CB4D468";
                        string authkey = "136969AqSChbw2jT85876374f";
                        string type = "Unicode";
                        string URL = "http://www.bulksms99.in/api/sendhttp.php?authkey="+authkey+"&mobiles="+contact1+"&message="+message1+"&sender="+senderid+"&route=4&unicode=1";                       
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                        request.KeepAlive = false;
                        request.ProtocolVersion = HttpVersion.Version10;
                        request.Method = "GET";
                        request.Timeout = 30000;
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }
    }
}