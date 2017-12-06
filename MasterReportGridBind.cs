using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.SessionState;

namespace PWdEEBudget
{
    public class MasterReportGridBind 
    {
        public string SessionQuery { get; set; }//this Proparty use for Stord the Query in session
        public string GroupOrOrderBy { get; set; }
        public string RIDF_Or_Lekhashirsh { get; set; }//This Proparty use for database column Name like as a.[LekhaShirshName]=N" or a.[RDF_NO]="
        public string TypeFBC { get; set; }
        public string WhereCondition { get; set; }
        public string WorkStatus { get; set; }
        public string WorkStatusUnion { get; set; }
        SqlDataAdapter da;
        DataTable dt;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="lekha"></param>
        /// <param name="ddl"></param>
        /// <param name="value"></param>
        /// <param name="ProvisionArthYear"></param>
        /// <param name="query"></param>
        /// <param name="unionquery"></param>
        /// <param name="fromBudgetTable"></param>
        /// <param name="fromProvisionTable"></param>
        /// <returns></returns>
        public DataTable BindGrid(string year, string lekha, string ddl, string value, string ProvisionArthYear, string query, string unionquery, string fromBudgetTable, string fromProvisionTable)
         {

            if (fromBudgetTable == "BudgetMasterBuilding")
            {
                GroupOrOrderBy = " group by a.[LekhaShirshName] order by a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
               // WorkStatus = ",case convert(nvarchar(max),a.[Sadyasthiti]) when N'पूर्ण' then a.[Sadyasthiti] else N'-' end as'C',case convert(nvarchar(max),a.[Sadyasthiti]) when N'प्रगतीत' then a.[Sadyasthiti] else N'-' end as'P',case convert(nvarchar(max),a.[Sadyasthiti]) when N'सुरु न झालेले ' then a.[Sadyasthiti] else N'-' end as'NS',case convert(nvarchar(max),a.[Sadyasthiti]) when N'अंदाजपत्रकिय स्थर ' then a.[Sadyasthiti] else N'-' end as'ES',case convert(nvarchar(max),a.[Sadyasthiti]) when N'निविदा स्थर ' then a.[Sadyasthiti] else N'-' end as'ST' ";
                //WorkStatusUnion = ",isNULL ('','')as'C',isNULL ('','')as'P',isNULL ('','')as'NS',isNULL ('','')as'ES',isNULL ('','')as'ST' ";
            }
            else if (fromBudgetTable == "BudgetMasterGAT_A")
            {
                GroupOrOrderBy = " group by a.[Arthsankalpiyyear],[LekhaShirshName] order by a.[Arthsankalpiyyear], a.[ArthsankalpiyBab],a.[Upvibhag],a.taluka";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (fromBudgetTable == "[BudgetMaster2515]")
            {
                GroupOrOrderBy = " group by a.[Arthsankalpiyyear], a.[upvibhag] order by a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka] desc";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterAunty")
            {
                GroupOrOrderBy = " group by a.[Arthsankalpiyyear], a.[Upvibhag]  order by a.[Arthsankalpiyyear],a.[Upvibhag],a.[Taluka]desc";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterCRF")
            {
                GroupOrOrderBy = " group by a.[Arthsankalpiyyear] order by a.[Arthsankalpiyyear],a.Upvibhag desc";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterDepositFund")
            {
                GroupOrOrderBy = " group by a.[Arthsankalpiyyear]  order by  a.[Arthsankalpiyyear],a.Upvibhag desc";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterDPDC")
            {
                GroupOrOrderBy = " group by a.[Arthsankalpiyyear], a.[Upvibhag]  ORDER BY a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka] desc";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterGAT_D")
            {
                GroupOrOrderBy = " group by a.[Arthsankalpiyyear], a.[Upvibhag]  order by a.[Arthsankalpiyyear],a.[Upvibhag],a.[Taluka]desc";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterGAT_FBC")
            {

                GroupOrOrderBy = " group by a.[Upvibhag]  order by a.[Upvibhag],a.[Arthsankalpiyyear],a.[Taluka]";
                RIDF_Or_Lekhashirsh = " a.[LekhaShirshName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterMLA")
            {                                
                GroupOrOrderBy = " group by a.[AmdaracheName] order by a.[AmdaracheName],a.[Arthsankalpiyyear],a.[Taluka],a.[PageNo]";
                RIDF_Or_Lekhashirsh = "a.[AmdaracheName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterMP")
            {
                GroupOrOrderBy = " group by a.[KhasdaracheName] order by a.[KhasdaracheName],a.[Arthsankalpiyyear],a.[Taluka],a.[PageNo]";
                RIDF_Or_Lekhashirsh = "a.[KhasdaracheName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterNABARD")
            {
                GroupOrOrderBy = " group by a.[RDF_SrNo] order by a.[RDF_SrNo],a.[Arthsankalpiyyear],a.[Upvibhag],a.taluka";
                RIDF_Or_Lekhashirsh = "a.[RDF_NO]=";
            }
            else if (fromBudgetTable == "BudgetMasterNonResidentialBuilding")
            {
                GroupOrOrderBy = " group by a.[Arthsankalpiyyear],a.[Upvibhag]  order by a.[Arthsankalpiyyear],a.[Upvibhag],a.[Taluka] desc";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterResidentialBuilding")
            {
                GroupOrOrderBy = " group by a.[Arthsankalpiyyear],a.[Upvibhag]  order by a.[Arthsankalpiyyear],a.[Upvibhag],a.[Taluka] desc";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (fromBudgetTable == "BudgetMasterRoad")
            {
                GroupOrOrderBy = " group by a.[LekhaShirshName] order by a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }




            if (ddl != "संपूर्ण" && ddl != null)
            {
                if (lekha == "सार्वजनिक बांधकाम पूर्व विभाग,पुणे" || lekha == "संपूर्ण")// संपूर्ण
                {
                    if (year != "संपूर्ण")
                    {
                        WhereCondition = " where a.Arthsankalpiyyear='" + year + "' and b.[Arthsankalpiyyear]=N'" + ProvisionArthYear + "'and " + ddl + "'" + value + "' ";
                        da = new SqlDataAdapter(query +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + unionquery +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + GroupOrOrderBy, con);
                    }
                    else
                    {
                        WhereCondition = "where b.[Arthsankalpiyyear]=N'" + ProvisionArthYear + "'and " + ddl + "'" + value + "' ";
                        da = new SqlDataAdapter(query +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + unionquery +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + GroupOrOrderBy, con);

                    }
                }
                else if (year == "संपूर्ण")
                {
                    WhereCondition = " where " + RIDF_Or_Lekhashirsh + "'" + lekha + "' and b.[Arthsankalpiyyear]=N'" + ProvisionArthYear + "'and " + ddl + "'" + value + "' ";
                    da = new SqlDataAdapter(query +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + unionquery +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + GroupOrOrderBy, con);

                }
                else
                {
                    WhereCondition = " where " + RIDF_Or_Lekhashirsh + "'" + lekha + "'and a.[Arthsankalpiyyear]=N'" + year + "' and b.[Arthsankalpiyyear]=N'" + ProvisionArthYear + "'and " + ddl + "'" + value + "' ";
                    da = new SqlDataAdapter(query +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + unionquery +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + GroupOrOrderBy, con);
                }
            }


            else if (lekha == "निवडा")//txtno.Text == "12"
            {

                if (year == "संपूर्ण")//&& txtno=="12"
                {
                    WhereCondition = " where  b.[Arthsankalpiyyear]=N'" + ProvisionArthYear + "' ";
                    da = new SqlDataAdapter(query +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + unionquery +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId  " + WhereCondition + GroupOrOrderBy, con);

                }
                else
                {
                    WhereCondition = " where a.Arthsankalpiyyear='" + year + "' and b.[Arthsankalpiyyear]=N'" + ProvisionArthYear + "' ";
                    da = new SqlDataAdapter(query +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + unionquery +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + GroupOrOrderBy, con);
                }
            }
            else
            {

                if (year == "संपूर्ण")
                {
                    if (lekha == "सार्वजनिक बांधकाम पूर्व विभाग,पुणे" || lekha == "संपूर्ण")
                    {
                        WhereCondition = " where  b.[Arthsankalpiyyear]=N'" + ProvisionArthYear + "' ";
                        da = new SqlDataAdapter(query +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + unionquery +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + GroupOrOrderBy, con);
                    }
                    else
                    {
                        WhereCondition = "where " + RIDF_Or_Lekhashirsh + "'" + lekha + "' and b.[Arthsankalpiyyear]=N'" + ProvisionArthYear + "' ";

                        da = new SqlDataAdapter(query +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + unionquery +  "from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + GroupOrOrderBy, con);
                    }
                }
                else
                {
                    WhereCondition = "where " + RIDF_Or_Lekhashirsh + "'" + lekha + "'and a.[Arthsankalpiyyear]=N'" + year + "' and b.[Arthsankalpiyyear]=N'" + ProvisionArthYear + "' ";
                    da = new SqlDataAdapter(query +  " from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + unionquery +  "from " + fromBudgetTable + " as a join " + fromProvisionTable + " as b on a.WorkId=b.WorkId " + WhereCondition + GroupOrOrderBy, con);
                }
            }
            if (da.SelectCommand.CommandText.Length > 0)
            {
                SessionQuery = da.SelectCommand.CommandText.ToString();
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }

            
       
        //This Method For MPR Report
       /// <summary>
       /// 
       /// </summary>
       /// <param name="KamacheYear">Work Year</param>
       /// <param name="Lekhashirsh">Lekhashirsh Name</param>
       /// <param name="WhereColumn">Conditions Column Name</param>
       /// <param name="WhereColumnValue">where column = value</param>
       /// <param name="query">ChkBox List maded Query</param>
       /// <param name="FromBudgetTable">MasterBudget Table Name</param>
       /// <returns></returns>
        public DataTable MPRBindGrid(string KamacheYear, string Lekhashirsh, string WhereColumn, string WhereColumnValue, string query, string FromBudgetTable)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            if (FromBudgetTable == "BudgetMasterBuilding")
            {
                GroupOrOrderBy = "  order by a.[lekhashirsh], a.[Upvibhag],a.[SubType]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (FromBudgetTable=="BudgetMasterMLA")
            {
                RIDF_Or_Lekhashirsh = "a.[AmdaracheName]=N";
                GroupOrOrderBy = " order by a.[PageNo]asc";
            }
            else if (FromBudgetTable=="BudgetMasterMP")
            {
                RIDF_Or_Lekhashirsh = "a.[KhasdaracheName]=N";
            }
            else if (FromBudgetTable == "BudgetMasterGAT_A")
            {
                //GroupOrOrderBy = "  order by a.[lekhashirsh], a.[Upvibhag],a.[SubType]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (FromBudgetTable == "BudgetMasterNonResidentialBuilding")
            {
                GroupOrOrderBy = "  order by a.[SubType]desc, a.[lekhashirsh]asc";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (FromBudgetTable == "BudgetMasterResidentialBuilding")
            {
                GroupOrOrderBy = "  order by a.[LekhaShirshName]desc,a.[Arthsankalpiyyear],a.[Taluka],a.[upvibhag]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (FromBudgetTable == "BudgetMasterGAT_FBC")
            {
                //GroupOrOrderBy = "  order by a.[LekhaShirshName]desc,a.[Arthsankalpiyyear],a.[Taluka],a.[upvibhag]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (FromBudgetTable == "BudgetMasterGAT_D")
            {
                //GroupOrOrderBy = "  order by a.[LekhaShirshName]desc,a.[Arthsankalpiyyear],a.[Taluka],a.[upvibhag]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (FromBudgetTable == "BudgetMasterRoad")
            {
                //GroupOrOrderBy = "  order by a.[LekhaShirshName]desc,a.[Arthsankalpiyyear],a.[Taluka],a.[upvibhag]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (FromBudgetTable == "BudgetMasterCRF")
            {
                //GroupOrOrderBy = "  order by a.[LekhaShirshName]desc,a.[Arthsankalpiyyear],a.[Taluka],a.[upvibhag]";
                RIDF_Or_Lekhashirsh = "a.[ArthsankalpiyBab]=N";
            }
            else if (FromBudgetTable == "BudgetMasterNABARD")
            {
                GroupOrOrderBy = "  order by a.[RDF_SrNo]";
                RIDF_Or_Lekhashirsh = "a.[RDF_NO]=N";
            }
            else if (FromBudgetTable == "BudgetMasterDepositFund")
            {
                //GroupOrOrderBy = "  order by a.[RDF_SrNo]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (FromBudgetTable == "BudgetMaster2515")
            {
                //GroupOrOrderBy = "  order by a.[RDF_SrNo]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            else if (FromBudgetTable == "BudgetMasterDPDC")
            {
                //GroupOrOrderBy = "  order by a.[RDF_SrNo]";
                RIDF_Or_Lekhashirsh = "a.[LekhaShirshName]=N";
            }
            if (WhereColumn != "संपूर्ण" && WhereColumn != null)
            {

                if (KamacheYear == "संपूर्ण")
                {
                    if (Lekhashirsh == "सार्वजनिक बांधकाम पूर्व विभाग,पुणे" || Lekhashirsh == "संपूर्ण")
                    {
                        query += " and " + WhereColumn + "'" + WhereColumnValue + "'";
                       // da = new SqlDataAdapter(query + " and " + WhereColumn + "'" + WhereColumnValue + "'", con);
                    }
                    else
                    {
                        query += " and " + RIDF_Or_Lekhashirsh + "'" + Lekhashirsh + "' and " + WhereColumn + "'" + WhereColumnValue + "'";
                       // da = new SqlDataAdapter(query + " and " + RIDF_Or_Lekhashirsh + "'" + Lekhashirsh + "' and " + WhereColumn + "'" + WhereColumnValue + "'", con);
                    }
                }

                else if (Lekhashirsh == "सार्वजनिक बांधकाम पूर्व विभाग,पुणे" || Lekhashirsh == "संपूर्ण")
                {
                    query += " and a.[Arthsankalpiyyear]=N'" + KamacheYear + "' and " + WhereColumn + "'" + WhereColumnValue + "'";
                   // da = new SqlDataAdapter(query + " and a.[Arthsankalpiyyear]=N'" + KamacheYear + "' " + WhereColumn + "' " + WhereColumnValue + "' ", con);
                }
                else
                {
                    query += " and " + RIDF_Or_Lekhashirsh + "'" + Lekhashirsh + "'and a.[Arthsankalpiyyear]=N'" + KamacheYear + "' and " + WhereColumn + "'" + WhereColumnValue + "'";
                    //da = new SqlDataAdapter(query + " and " + RIDF_Or_Lekhashirsh + "'" + Lekhashirsh + "'and a.[Arthsankalpiyyear]=N'" + KamacheYear + "' and " + WhereColumn + "'" + WhereColumnValue + "'", con);
                }
            }
            else if (Lekhashirsh == "निवडा" || Lekhashirsh == "संपूर्ण")//btnKamache Year or ReportType
            {
                query = KamacheYear == "संपूर्ण" ? query : query + " and a.[Arthsankalpiyyear]=N'" + KamacheYear + "'";
               // query += GroupOrOrderBy;
                //da = new SqlDataAdapter(query + GroupOrOrderBy, con);

            }
            else
            {
                query = KamacheYear == "संपूर्ण" ? query + " and " + RIDF_Or_Lekhashirsh + "'" + Lekhashirsh + "'" : query + " and a.[Arthsankalpiyyear]=N'" + KamacheYear + "' and " + RIDF_Or_Lekhashirsh + "'" + Lekhashirsh + "' ";
                //da = new SqlDataAdapter(query + GroupOrOrderBy, con);

            }
            if (FromBudgetTable=="BudgetMasterMLA")
            {
                query += GroupOrOrderBy;
            }
            if (FromBudgetTable == "BudgetMasterBuilding")
            {
                query += GroupOrOrderBy;
            }
            if (FromBudgetTable == "BudgetMasterNonResidentialBuilding")
            {
                query += GroupOrOrderBy;
            }
            if (FromBudgetTable == "BudgetMasterResidentialBuilding")
            {
                query += GroupOrOrderBy;
            }
            if (FromBudgetTable == "BudgetMasterNABARD")
            {
                query += GroupOrOrderBy;
            }
            
            da = new SqlDataAdapter(query, con);
            if (da.SelectCommand.CommandText.Length > 0)
            {
                SessionQuery = da.SelectCommand.CommandText.ToString();
                dt = new DataTable();
                da.Fill(dt);
                
            }
            return dt;
        }
    }
}