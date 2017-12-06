using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class SuperAdmin : System.Web.UI.MasterPage
    {

        string a;
        string UserName;
        SqlConnection con = null;
        string alive = string.Empty;
        string SettingPassword = WebConfigurationManager.AppSettings["SettingPassword"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());

            if (!IsPostBack)
            {
                try
                {
                    //if (Application["UserId"] != null)

                    if (Session.Timeout > 5)
                    {

                        Session.Timeout = 90;

                        if (Session["id"] != null)
                        {
                            a = Session["id"].ToString();
                        }
                        else
                        {
                            Session["id"] = "PwdExecutiveEngineer1";
                            a = "PwdExecutiveEngineer1";
                        }
                        //a = Application["UserId"].ToString();

                        nameFetch();
                        Img();
                        GetUserName();
                        lblUserName.Text = UserName;
                        Notification();
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }

                }
                catch (NullReferenceException)
                {

                    Session["id"] = "PwdExecutiveEngineer1";
                }

                // Session["id"] = a;
            }

        }

        public void GetUserName()
        {
            string UserId = Session["id"].ToString();
            string strGetNameQuery = "select Name from SCreateAdmin where UserId='" + UserId + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(strGetNameQuery, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    UserName = dr[0].ToString();
                }
            }
        }
        public void Img()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select Fname+' '+LName as Name,Post from SCreateAdmin where UserId='" + a + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[1].ToString() == "Executive Engineer")
                {
                    imgUser.Src = "Fileuploded/AVINASH DHONDGE-Logo.jpg";
                }
                else
                {
                    imgUser.Src = "logo/user-icon3.png";
                }
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {

            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

        }

        protected void logout_OnClick(object sender, EventArgs e)
        {
            if (txtMasterPassword.Text.Trim() == SettingPassword.Trim().ToString())
            {
                btnSubmitMasterPassword_Click(sender,e);
            }
            else
            {
                Response.Cache.SetExpires(DateTime.UtcNow.AddDays(1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();

                Response.Redirect("Login.aspx");
            }
        }

        public void exit()
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        public void nameFetch()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select Fname+' '+LName as Name,Post from SCreateAdmin where UserId='" + a + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        string Type;

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());


            SqlDataAdapter sdaa = new SqlDataAdapter("SELECT coalesce(B.WorkID, C.WorkID, N.WorkID, R.WorkID, G_A.WorkID, G_FBC.WorkID, G_D.WorkID, D.WorkID, DP.WorkID, MLA.WorkID,MP.WorkID,An.WorkID)as WorkID,coalesce(B.KamacheName, C.KamacheName, N.KamacheName, R.KamacheName, G_A.KamacheName, G_FBC.KamacheName, G_D.KamacheName, D.KamacheName, DP.KamacheName, MLA.KamacheName,MP.KamacheName,An.KamacheName)as KamacheName FROM BudgetMasterBuilding B FULL OUTER JOIN BudgetMasterCRF C ON B.WorkID=C.WorkID full outer join BudgetMasterNABARD N on B.WorkID= N.WorkID  full outer join BudgetMasterRoad R on B.WorkID=R.WorkID full outer join BudgetMasterGAT_A G_A on B.WorkID=G_A.WorkID full outer join BudgetMasterGAT_FBC G_FBC on B.WorkID=G_FBC.WorkID full outer join BudgetMasterGAT_D G_D on B.WorkID=G_D.WorkID  full outer join BudgetMasterDepositFund D on B.WorkID=D.WorkID  full outer join BudgetMasterDPDC DP on B.WorkID=DP.WorkID  full outer join BudgetMasterMLA MLA on B.WorkID=MLA.WorkID  full outer join BudgetMasterMP MP on B.WorkID=MP.WorkID full outer join BudgetMasterAunty An on B.WorkID=An.WorkID full outer join BudgetMaster2515 GramV on B.Workid=GramV.Workid full outer join BudgetMasterNonResidentialBuilding NRB on B.Workid=NRB.workid full outer join BudgetMasterResidentialBuilding RB on B.Workid=RB.workid where B.WorkID like '" + prefixText + "%' or C.workID like '" + prefixText + "%' or N.workID  like '" + prefixText + "%' or R.workID like '" + prefixText + "%'  or G_A.workID like '" + prefixText + "%' or G_FBC.workID like '" + prefixText + "%' or G_D.workID like '" + prefixText + "%'  or D.workID like '" + prefixText + "%'  or DP.workID like '" + prefixText + "%'  or MLA.workID like '" + prefixText + "%'  or MP.workID like '" + prefixText + "%' or An.WorkID like '" + prefixText + "%' or GramV.Workid like '" + prefixText + "%' or NRB.Workid like '" + prefixText + "%' or RB.Workid like '" + prefixText + "%' ", conn);

            sdaa.Fill(dt);
            List<string> countryNames = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                countryNames.Add(dr["WorkID"].ToString() + ":  " + dr["KamacheName"].ToString());
            }
            return countryNames;
        }

        protected void search_TextChanged(object sender, EventArgs e)
        {
            search.Text = search.Text.Split(':')[0];
            SqlDataAdapter sda = new SqlDataAdapter(" SELECT B.Type,C.Type,N.Type,R.Type,G_A.Type,G_FBC.Type,G_D.Type,D.Type,DP.Type,MLA.Type,MP.Type,An.Type,GramV.Type,NRB.Type,RB.Type FROM BudgetMasterBuilding B  FULL OUTER JOIN BudgetMasterCRF C ON B.WorkID=C.WorkID  full outer join BudgetMasterNABARD N on B.WorkID= N.WorkID  full outer join BudgetMasterRoad R on B.WorkID=R.WorkID full outer join BudgetMasterGAT_A G_A on B.WorkID=G_A.WorkID full outer join BudgetMasterGAT_FBC G_FBC on B.WorkID=G_FBC.WorkID  full outer join BudgetMasterGAT_D G_D on B.WorkID=G_D.WorkID  full outer join BudgetMasterDepositFund D on B.WorkID=D.WorkID  full outer join BudgetMasterDPDC DP on B.WorkID=DP.WorkID  full outer join BudgetMasterMLA MLA on B.WorkID=MLA.WorkID  full outer join BudgetMasterMP MP on B.WorkID=MP.WorkID full outer join BudgetMasterAunty An on B.WorkID=An.WorkID full outer join BudgetMaster2515 GramV on B.Workid=GramV.Workid full outer join BudgetMasterNonResidentialBuilding NRB on B.Workid=NRB.workid full outer join BudgetMasterResidentialBuilding RB on B.Workid=RB.Workid where B.WorkID='" + search.Text + "' or C.WorkID='" + search.Text + "' or G_D.WorkID='" + search.Text + "' or D.WorkID='" + search.Text + "' or DP.WorkID='" + search.Text + "' or MLA.WorkID='" + search.Text + "' or MP.WorkID='" + search.Text + "' or N.WorkID='" + search.Text + "' or R.WorkID='" + search.Text + "' or G_A.WorkID='" + search.Text + "' or G_FBC.WorkID='" + search.Text + "' or An.WorkID='" + search.Text + "' or GramV.Workid=' " + search.Text + "' or NRB.Workid=' " + search.Text + "' or RB.Workid=' " + search.Text + "'", con);
            DataTable dp = new DataTable();
            sda.Fill(dp);
            foreach (DataRow dr in dp.Rows)
            {
                Type = dr[0].ToString() + dr[1].ToString() + dr[2].ToString() + dr[3].ToString() + dr[4].ToString() + dr[5].ToString() + dr[6].ToString() + dr[7].ToString() + dr[8].ToString() + dr[9].ToString() + dr[10].ToString() + dr[11].ToString() + dr[12].ToString() + dr[13].ToString() + dr[14].ToString();
            }

            if (Type == "Annuity")
            {

                Response.Redirect("MasterBudgetAunty.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "Building")
            {

                Response.Redirect("MasterBudgetBuilding.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == " NonResidential_Building")
            {

                Response.Redirect("MasterBudgetNonResidentialBuilding.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == " Residential_Building")
            {

                Response.Redirect("MasterBudgetResidentialBuilding.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "CRF")
            {
                Response.Redirect("MasterBudgetCRF.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "Nabard")
            {
                Response.Redirect("MasterBudgetNABARD.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "Road")
            {
                Response.Redirect("MasterBudgetRoad.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "DPDC")
            {
                Response.Redirect("MasterBudgetDPDC.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "MLA")
            {
                Response.Redirect("MasterBudgetMLA.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "MP" || Type == "पुणे / राज्य सभा सदस्य" || Type == "पुणे / खासदारांचा स्थानिक विकास कार्यक्रम")
            {
                Response.Redirect("MasterBudgetMP.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "Deposit Fund" || Type == "Deposit")
            {
                Response.Redirect("MasterBudgetDepositFund.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "GAT_A")
            {
                Response.Redirect("MasterBudgetGat_A.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "गट सी" || Type == "गट बी" || Type == "गट एफ")
            {
                Response.Redirect("MasterBudgetGat_FBC.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "GAT_D")
            {
                Response.Redirect("MasterBudgetGat_D.aspx?WorkID=" + search.Text + "", false);
            }
            else if (Type == "2515_GramVikas")
            {
                Response.Redirect("MasterBudget2515.aspx?WorkID=" + search.Text + "", false);
            }

            else
            {
                Response.Redirect("SuperAdminPanel.aspx", false);
            }

        }

        public void Notification()
        {
            string strcmd = string.Empty;
            DataTable dt = new DataTable();

            strcmd = "select KamPurnDate,WorkId,KamacheName from SendSms_tbl where convert(date,KamPurnDate,105) between CONVERT(date,GETDATE(),105) and convert(date,dateadd(day,20,GETDATE()),105)";
            SqlDataAdapter sda = new SqlDataAdapter(strcmd, con);
            dt = new DataTable();

            sda.Fill(dt);

            noti_Counter.InnerHtml = dt.Rows.Count.ToString();
            string table = "<table>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string noti_id = dt.Rows[i]["WorkId"].ToString();
                table += "<tr><td>";

                table += dt.Rows[i]["KamPurnDate"].ToString();
                table += "</td>";
                table += "<td><a href=SuperAdminPanel.aspx?notificationId=" + noti_id + ">";
                table += dt.Rows[i]["WorkId"].ToString();
                table += "</a></td>";
                table += "<td><a href=#>";

                table += dt.Rows[i]["KamacheName"].ToString();
                table += "</a></td>";
                table += "<td>&nbsp<a href=SuperAdminPanel.aspx?WorkId=" + noti_id + ">SMS</a></td></tr>";
            }
            table += "</table>";
            noti_disp.InnerHtml = table;
        }

        protected void btnMasterPassword_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmitMasterPassword_Click(object sender, EventArgs e)
        {
            if (txtMasterPassword.Text.Trim().ToString() == SettingPassword.Trim().ToString())
            {
                Session["SettingAccess"] = "AccessGranted";
                Response.Redirect("Setting.aspx");
            }
            else
            {
                this.Response.Redirect(this.Request.Url.ToString());
            }
        }
    }
}