using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace PWdEEBudget
{

    public class clsGraphicsReport
    {
        public decimal[] arr = new decimal[10];


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        
        //This Method For bind A MasterReport Graph (Graphicles Reports)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MasterTbl"></param>
        /// <param name="ProvisionTbl"></param>
        /// <param name="WhereCondition"></param>
        public void GraphicsReports(string MasterTbl, string ProvisionTbl, string WhereCondition)
        {
            //[Dynamic_SP1]
            DataSet ds = new DataSet();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                SqlCommand objcmd = new SqlCommand("[BindMasterChartGraph_SP]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@MasterTbl", MasterTbl);
                objcmd.Parameters.AddWithValue("@ProvisionTbl", ProvisionTbl);
                objcmd.Parameters.AddWithValue("@WhereCondition", WhereCondition);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(ds,"Graph");
                for (int i = 0; i < ds.Tables["Graph"].Rows.Count; i++)
                {

                    if (ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "Completed" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "पूर्ण")
                    {

                        arr[0] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TotalWork"]);
                        arr[6] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["EstimatedCost"]);
                        arr[7] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TSCost"]);
                        arr[8] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["BudgetProvision"]);
                        arr[9] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["Expenditure"]);

                    }
                    else if (ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "Incomplete" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "अपूर्ण")
                    {

                        arr[1] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TotalWork"]);
                        arr[6] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["EstimatedCost"]);
                        arr[7] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TSCost"]);
                        arr[8] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["BudgetProvision"]);
                        arr[9] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["Expenditure"]);

                    }
                    else if (ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "Inprogress" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "Processing" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "Current" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "चालू" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "प्रगतीत")
                    {

                        arr[2] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TotalWork"]);
                        arr[6] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["EstimatedCost"]);
                        arr[7] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TSCost"]);
                        arr[8] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["BudgetProvision"]);
                        arr[9] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["Expenditure"]);
                    }
                    else if (ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "Tender Stage" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "निविदा स्तर")
                    {

                        arr[3] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TotalWork"]);
                        arr[6] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["EstimatedCost"]);
                        arr[7] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TSCost"]);
                        arr[8] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["BudgetProvision"]);
                        arr[9] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["Expenditure"]);

                    }
                    else if (ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "Estimated Stage" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "अंदाजपत्रकिय स्थर" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "अंदाजपत्रकिय स्तर")
                    {

                        arr[4] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TotalWork"]);
                        arr[6] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["EstimatedCost"]);
                        arr[7] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TSCost"]);
                        arr[8] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["BudgetProvision"]);
                        arr[9] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["Expenditure"]);

                    }
                    else if (ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "Not Started" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "सुरू करणे" || ds.Tables["Graph"].Rows[i]["WorkStatus"].ToString().Trim() == "सुरु न झालेली")
                    {
                        arr[5] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TotalWork"]);
                        arr[6] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["EstimatedCost"]);
                        arr[7] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["TSCost"]);
                        arr[8] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["BudgetProvision"]);
                        arr[9] += Convert.ToDecimal(ds.Tables["Graph"].Rows[i]["Expenditure"]);


                    }
                }
               // return ds;
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