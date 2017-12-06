using System;

using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Web;

using Quartz;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PWdEEBudget.MyAssociationPortal.BusinessLayer;
using System.Globalization;

namespace PWdEEBudget.QuartZExample
{
    public class SendBDaySMS : IJob
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);


        public void Execute(IJobExecutionContext context)
        {
            // BirthdayMessage();
            RenDateMsg();
        }

        /// <summary>  
        /// Sending Scheduler email to user using Quartz.Net  
        /// </summary>  
        /// <param name="recepientEmail">  
        /// <param name="subject">  
        /// <param name="body">  

        public void RenDateMsg()
        {
            MyAssociation k = new MyAssociation();

            string curdate = DateTime.Now.ToString("MMM dd yyyy");

            ArrayList objAL_Month = new ArrayList();
            ArrayList objAL_Day15 = new ArrayList();
            ArrayList objAL_Day7 = new ArrayList();
            ArrayList objAL_Day3 = new ArrayList();
            ArrayList objAL_Day1 = new ArrayList();
            ArrayList objAL_today = new ArrayList();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select SmsId,WorkId,ShakhaAbhyantaName, ShakhaAbhiyantMobile, UpabhyantaName, UpAbhiyantaMobile, KamacheName, ThekedaarName, ThekedarMobile,convert(date,KamPurnDate,105) as KamPurnDate,MudatVadDate,Message,BeforMonth,Befor_15Days,Befor_7Days,Befor_3Days,Befor_1Day,SameDays from SendSms_tbl where convert(date,KamPurnDate,105) between CONVERT(date,GETDATE(),105) and convert(date,dateadd(day,31,GETDATE()),105)", con);
            cmd.Parameters.AddWithValue("@date", curdate);
            try
            {


                SqlDataReader reader1 = cmd.ExecuteReader();

                if (reader1 != null)
                {
                    while (reader1.Read())
                    {
                        string Message = string.Empty;
                        string UId = reader1["SmsId"].ToString();
                        string WorkId = reader1["WorkId"].ToString();
                        string ShakhaAbhyantaName = reader1["ShakhaAbhyantaName"].ToString();
                        string ShakhaAbhyantMobile = reader1["ShakhaAbhiyantMobile"].ToString();
                        string UpabhyantaName = reader1["UpabhyantaName"].ToString();
                        string UpbhyantaMobile = reader1["UpAbhiyantaMobile"].ToString();
                        string KamacheName = reader1["KamacheName"].ToString();
                        string ThekedaarName = reader1["ThekedaarName"].ToString();
                        string ThekedaarMobile = reader1["ThekedarMobile"].ToString();
                        string KamPurnDate1 = reader1["KamPurnDate"].ToString();
                        string MudatVadDate = reader1["MudatVadDate"].ToString();
                        string KamPurnDate = string.Empty;

                        Message = "Welcome to Division Budget Software\r\n";
                        Message += "P.W.(East) Division Pune\r\n";
                        
                        Message += "Work Id: " + WorkId + "\r\n";
                      
                        Message += "Stipulated Date of completion: " + KamPurnDate1 + "\r\n";
                        
                        

                        int BeforMonth = Convert.ToInt16(reader1["BeforMonth"]);
                        int Befor_15Days = Convert.ToInt16(reader1["Befor_15Days"]);
                        int Befor_7Days = Convert.ToInt16(reader1["Befor_7Days"]);
                        int Befor_3Days = Convert.ToInt16(reader1["Befor_3Days"]);
                        int Befor_1Day = Convert.ToInt16(reader1["Befor_1Day"]);
                        int SameDays = Convert.ToInt16(reader1["SameDays"]);

                        //DateTime dt = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        //For Currant Date
                       
                        if (KamPurnDate1 == "" || KamPurnDate1=="0"||KamPurnDate1==null)
                        {

                        }
                        else
                        {
                           string oldstr = reader1["KamPurnDate"].ToString();
                          // KamPurnDate = DateTime.ParseExact(oldstr, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

                           DateTime dtsame = Convert.ToDateTime(oldstr);

                            string dtsame1 = dtsame.ToString("MMM dd yyy");
                            // DateTime dtSameDay = Convert.ToDateTime(date);

                            //For Before 1 Month
                            DateTime dt = Convert.ToDateTime(oldstr);
                            dt = dt.AddMonths(-1);
                            string dtMonth = dt.ToString("MMM dd yyyy");

                            //For Before 15 Day
                            DateTime dt1 = Convert.ToDateTime(oldstr);
                            dt1 = dt1.AddDays(-15);
                            string dtDay15 = dt1.ToString("MMM dd yyyy");

                            //For Before 7 Day
                            DateTime dt2 = Convert.ToDateTime(oldstr);
                            dt2 = dt2.AddDays(-7);
                            string dtDay7 = dt2.ToString("MMM dd yyyy");

                            //For Before 3 Day  
                            DateTime dt3 = Convert.ToDateTime(oldstr);
                            dt3 = dt3.AddDays(-3);
                            string dtDay3 = dt3.ToString("MMM dd yyyy");

                            //For Before 1 Day
                            DateTime dt4 = Convert.ToDateTime(oldstr);
                            dt4 = dt4.AddDays(-1);
                            string dtDay1 = dt4.ToString("MMM dd yyyy");


                            //For Sending Message One Month Before 
                            if (dtMonth == curdate && BeforMonth == 0)
                            {
                                Message += "Remaining Days: 30 Days\r\n";
                                Message += "Please submit Extension proposal\r\n";
                            
                                Message += "WebSite Url:  http://www.pwdpune.sghitech.co.in";
                                
                                k.SendSMS(Message, ThekedaarMobile, UpbhyantaMobile, ShakhaAbhyantMobile);

                                objAL_Month.Add(UId);


                            }
                            //For Sending Message Before 15 Days
                            else if (curdate == dtDay15 && Befor_15Days == 0)
                            {
                                Message += "Remaining Days: 15 Days\r\n";
                                Message += "Please submit Extension proposal\r\n";

                                Message += "WebSite Url:   http://www.pwdpune.sghitech.co.in";
                                k.SendSMS(Message, ThekedaarMobile, UpbhyantaMobile, ShakhaAbhyantMobile);
                                objAL_Day15.Add(UId);
                            }
                            //For Sending Message Before 7 day 
                            else if (curdate == dtDay7 && Befor_7Days == 0)
                            {
                                Message += "Remaining Days: 07 Days\r\n";
                                Message += "Please submit Extension proposal\r\n";

                                Message += "WebSite Url:   http://www.pwdpune.sghitech.co.in";
                                k.SendSMS(Message, ThekedaarMobile, UpbhyantaMobile, ShakhaAbhyantMobile);


                                objAL_Day7.Add(UId);

                            }
                            //For Sending Message Before 3 day
                            else if (curdate == dtDay3 && Befor_3Days == 0)
                            {
                                Message += "Remaining Days: 03 Days\r\n";
                                Message += "Please submit Extension proposal\r\n";

                                Message += "WebSite Url:  http://www.pwdpune.sghitech.co.in";
                                k.SendSMS(Message, ThekedaarMobile, UpbhyantaMobile, ShakhaAbhyantMobile);

                                objAL_Day3.Add(UId);
                            }
                            //   For Sending Message Before 1 Day
                            else if (curdate == dtDay1 && Befor_1Day == 0)
                            {
                                Message += "Remaining Days: 1 Day\r\n";
                                Message += "Please submit Extension proposal\r\n";

                                Message += "WebSite Url:  http://www.pwdpune.sghitech.co.in";
                                k.SendSMS(Message, ThekedaarMobile, UpbhyantaMobile, ShakhaAbhyantMobile);
                                objAL_Day1.Add(UId);
                            }
                            //For Sending Message On Currante date
                            else if (curdate == dtsame1 && SameDays == 0)
                            {
                                Message += "Today is: Last date\r\n";
                                Message += "Please submit Extension proposal\r\n";

                                Message += "WebSite Url:  http://www.pwdpune.sghitech.co.in";
                                k.SendSMS(Message, ThekedaarMobile, UpbhyantaMobile, ShakhaAbhyantMobile);

                                objAL_today.Add(UId);
                            }
                        }

                    }

                    reader1.Close();
                    foreach (string usrid in objAL_Month)
                    {
                        string userid = usrid;


                        SqlCommand upcmd = new SqlCommand("update [SendSms_tbl] set BeforMonth=@mon where SmsId = '" + userid + "'", con);
                        upcmd.Parameters.AddWithValue("@mon", 1);

                        upcmd.ExecuteNonQuery();
                    }
                    foreach (string usrid in objAL_Day15)
                    {
                        string userid = usrid;


                        SqlCommand upcmd = new SqlCommand("update [SendSms_tbl] set Befor_15Days=@hm where SmsId = '" + userid + "'", con);
                        upcmd.Parameters.AddWithValue("@hm", 1);

                        upcmd.ExecuteNonQuery();
                    }
                    foreach (string usrid in objAL_Day7)
                    {
                        string userid = usrid;


                        SqlCommand upcmd = new SqlCommand("update [SendSms_tbl] set Befor_7Days=@weak where SmsId = '" + userid + "'", con);
                        upcmd.Parameters.AddWithValue("@weak", 1);

                        upcmd.ExecuteNonQuery();
                    }
                    foreach (string usrid in objAL_Day3)
                    {
                        string userid = usrid;


                        SqlCommand upcmd = new SqlCommand("update [SendSms_tbl] set Befor_3Days=@threeday where SmsId = '" + userid + "'", con);
                        upcmd.Parameters.AddWithValue("@threeday", 1);

                        upcmd.ExecuteNonQuery();
                    }

                    foreach (string usrid in objAL_Day1)
                    {
                        string userid = usrid;

                        SqlCommand upcmd = new SqlCommand("update [SendSms_tbl] set Befor_1Day=@oneday where SmsId = '" + userid + "'", con);
                        upcmd.Parameters.AddWithValue("@oneday", 1);

                        upcmd.ExecuteNonQuery();
                    }
                    foreach (string usrid in objAL_today)
                    {
                        string userid = usrid;

                        SqlCommand upcmd = new SqlCommand("update [SendSms_tbl] set SameDays=@today where SmsId = '" + userid + "'", con);
                        upcmd.Parameters.AddWithValue("@today", 1);

                        upcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            con.Close();
        }
    }
}