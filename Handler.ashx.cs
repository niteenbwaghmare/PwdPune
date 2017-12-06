using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace PWdEEBudget
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>public class MyAshxClass : IHttpHandler, IRequiresSessionState
    public class Handler : IHttpHandler, IRequiresSessionState
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        System.Web.HttpContext img { get; set; }

       // UploadImage uplodaimg = new UploadImage();
        
        public void ProcessRequest(HttpContext context)
        {
            
            try
            {
               
                
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Select [Image] from ImageGallary where ImageId=@WorkID ";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    //SqlParameter ImageID = new SqlParameter("@WorkID", SqlDbType.NVarChar);
                    //ImageID.Value = context.Request.QueryString["WorkID"];


                    cmd.Parameters.Add("@WorkID",SqlDbType.Int).Value = context.Request.QueryString["WorkID"];
                    con.Open();
                //cmd.Prepare();
                    cmd.CommandTimeout = 600;
                   SqlDataReader dReader = cmd.ExecuteReader();
                   
                    dReader.Read();
                    if (!DBNull.Value.Equals(dReader["Image"]))
                    {
                        context.Response.BinaryWrite((byte[])dReader["Image"]);

                    }
                   
                    dReader.Close();
                    img = context;
               
                //if (ImageID1.Value!=null)
                //{
                //    SqlCommand cmd = new SqlCommand();
                //    cmd.CommandText = "Select [Img1],[Img2],[Img3] from BudgetMasterAunty where WorkID =@WorkID1";
                //    cmd.CommandType = CommandType.Text;
                //    cmd.Connection = con;


                //    cmd.Parameters.Add(ImageID1);
                //    con.Open();
                //    SqlDataReader dReader = cmd.ExecuteReader();
                //    dReader.Read();
                //    if (!DBNull.Value.Equals(dReader["Img2"]))
                //    {
                //        context.Response.BinaryWrite((byte[])dReader["Img2"]);

                //    }
                //    dReader.Close();
                //}

                //if (ImageID2.Value!=null)
                //{
                //    SqlCommand cmd = new SqlCommand();
                //    cmd.CommandText = "Select [Img1],[Img2],[Img3] from BudgetMasterAunty where WorkID =@WorkID2";
                //    cmd.CommandType = CommandType.Text;
                //    cmd.Connection = con;


                //    cmd.Parameters.Add(ImageID2);
                //    con.Open();
                //    SqlDataReader dReader = cmd.ExecuteReader();
                //    dReader.Read();
                //    if (!DBNull.Value.Equals(dReader["Img3"]))
                //    {
                //        context.Response.BinaryWrite((byte[])dReader["Img3"]);

                //    }
                //    dReader.Close();
                //}
            //cmd.Parameters.Add(ImageID1);
            //cmd.Parameters.Add(ImageID2);
            
           
          
            //if (!DBNull.Value.Equals(dReader["Image"]))
            //{
            //    context.Response.BinaryWrite((byte[])dReader["Image"]);
            //    dReader.Close();
            //    con.Close();
            //}

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
               //s dReader.Close();
                con.Close();

            }
      }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}