using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.SessionState;
using System.Drawing;
using PWdEEBudget.SMS_CRUD;

using System.Web.UI.DataVisualization.Charting;
using System.Text.RegularExpressions;


namespace PWdEEBudget
{
    public partial class SuperAdminPanel : System.Web.UI.Page, IHttpHandler, IRequiresSessionState
    {


        clsNotification notificationObj = new clsNotification();
        clsSMS_CRUD objChartBind = new clsSMS_CRUD();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        SqlDataAdapter sda;
        DataTable dt;
        string strcmd = string.Empty;
        string getworkid = string.Empty;
        string Upvibhag = string.Empty;
        string Type = string.Empty;
        string count = string.Empty;
        string notification_Id = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

            if (!IsPostBack)
            {
                
                //{
                //if (Application["UserId"] != null)
                if (Session.Timeout > 5)
                {
                    //string user = Application["UserId"].ToString();
                    BindColumnChart();

                    BindddlYear();
                    BindddlUpvibhag();
                    BindddlSecEng();
                    BindChart();
                    GetAllData("BudgetMasterBuilding", "MasterBudgetBuilding.aspx");
                    BindGridview();
                    CPNS_Chart();
                    //Label1.Text = Session["id"].ToString();
                    Session["pathUrl"] = "a";
                    if (Request.QueryString["notificationId"] != null && Request.QueryString["notificationId"] != "0")
                    {
                        notification_Id = Request.QueryString["notificationId"].ToString();

                        string pathUrl = notificationObj.Notification(notification_Id);

                        if (pathUrl == "Building")
                        {

                            Response.Redirect("MasterBudgetBuilding.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else if (pathUrl == "CRF")
                        {
                            Response.Redirect("MasterBudgetCRF.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else if (pathUrl == "Nabard")
                        {
                            Response.Redirect("MasterBudgetNABARD.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else if (pathUrl == "Road")
                        {
                            Response.Redirect("MasterBudgetRoad.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else if (pathUrl == "DPDC")
                        {
                            Response.Redirect("MasterBudgetDPDC.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else if (pathUrl == "MLA")
                        {
                            Response.Redirect("MasterBudgetMLA.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else if (pathUrl == "MP")
                        {
                            Response.Redirect("MasterBudgetMP.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else if (pathUrl == "Deposit Fund")
                        {
                            Response.Redirect("MasterBudgetDepositFund.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else if (pathUrl == "GAT_A")
                        {
                            Response.Redirect("MasterBudgetGat_A.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else if (pathUrl == "GAT_FBC")
                        {
                            Response.Redirect("MasterBudgetGat_FBC.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else if (pathUrl == "GAT_D")
                        {
                            Response.Redirect("MasterBudgetGat_D.aspx?WorkID=" + notification_Id + "", false);
                        }
                        else
                        {
                            Response.Redirect("SuperAdminPanel.aspx", false);
                        }

                    }
                    else if (Request.QueryString["WorkId"] != null && Request.QueryString["WorkId"] != "0")
                    {
                        notification_Id = Request.QueryString["WorkId"].ToString();
                        Session["pathUrl"] = notificationObj.Notification(notification_Id);
                        Response.Redirect("Send_sms.aspx?WorkID=" + notification_Id + "", false);
                    }


                   
                }

                else
                {
                    Response.Redirect("Login.aspx");
                }
               
            }


        }

      

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());


            SqlDataAdapter sdaa = new SqlDataAdapter("SELECT coalesce(B.WorkID, C.WorkID, N.WorkID, R.WorkID, G_A.WorkID, G_FBC.WorkID, G_D.WorkID, D.WorkID, DP.WorkID, MLA.WorkID,MP.WorkID,An.WorkID,GramV.Workid,NRB.Workid,RB.Workid)as WorkID,coalesce(B.KamacheName, C.KamacheName, N.KamacheName, R.KamacheName, G_A.KamacheName, G_FBC.KamacheName, G_D.KamacheName, D.KamacheName, DP.KamacheName, MLA.KamacheName,MP.KamacheName,An.KamacheName,GramV.KamacheName,NRB.KamacheName,RB.KamacheName)as KamacheName FROM BudgetMasterBuilding B FULL OUTER JOIN BudgetMasterCRF C ON B.WorkID=C.WorkID full outer join BudgetMasterNABARD N on B.WorkID= N.WorkID  full outer join BudgetMasterRoad R on B.WorkID=R.WorkID full outer join BudgetMasterGAT_A G_A on B.WorkID=G_A.WorkID full outer join BudgetMasterGAT_FBC G_FBC on B.WorkID=G_FBC.WorkID full outer join BudgetMasterGAT_D G_D on B.WorkID=G_D.WorkID  full outer join BudgetMasterDepositFund D on B.WorkID=D.WorkID  full outer join BudgetMasterDPDC DP on B.WorkID=DP.WorkID  full outer join BudgetMasterMLA MLA on B.WorkID=MLA.WorkID  full outer join BudgetMasterMP MP on B.WorkID=MP.WorkID full outer join BudgetMasterAunty An on B.WorkID=An.WorkID full outer join BudgetMaster2515 GramV on B.Workid=GramV.Workid full outer join BudgetMasterNonResidentialBuilding NRB on B.Workid=NRB.workid full outer join BudgetMasterResidentialBuilding RB on B.Workid=RB.workid where B.WorkID like '" + prefixText + "%' or C.workID like '" + prefixText + "%' or N.workID  like '" + prefixText + "%' or R.workID like '" + prefixText + "%'  or G_A.workID like '" + prefixText + "%' or G_FBC.workID like '" + prefixText + "%' or G_D.workID like '" + prefixText + "%'  or D.workID like '" + prefixText + "%'  or DP.workID like '" + prefixText + "%'  or MLA.workID like '" + prefixText + "%'  or MP.workID like '" + prefixText + "%' or An.WorkID like '" + prefixText + "%' or GramV.Workid like '" + prefixText + "%' or NRB.Workid like '" + prefixText + "%' or RB.Workid like '" + prefixText + "%' ", conn);

            sdaa.Fill(dt);
            List<string> countryNames = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                countryNames.Add(dr["WorkID"].ToString() + ":  " + dr["KamacheName"].ToString());
            }
            return countryNames;
        }


        protected void GetAllData(string frmTable,string inputFrmUrl)
        {
            marquee1 = null;
            lt1.Text = string.Empty;
            sda = new SqlDataAdapter("select WorkId,KamacheName from " + frmTable, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            lblHeader.Text = frmTable;
            string s2 = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lt1.Text = string.Empty;
                s2 += "<table><tr>";
                //s2 += "<td><a href='#'>";
                getworkid = ds.Tables[0].Rows[i][0].ToString();
                s2 += "<td><a href=" + inputFrmUrl + "?WorkId=" + getworkid + ">";//QueryString
                s2 += ds.Tables[0].Rows[i][0].ToString();
                s2 += "</a></td>";
                s2 += "<td>&nbsp&nbsp&nbsp&nbsp&nbsp<a>";
                s2 += ds.Tables[0].Rows[i][1].ToString();
                s2 += "</a></td>";
                s2 += "</tr></table>";
                lt1.Text += s2.ToString();
            }
            //if (Page.IsPostBack)
            //{
            //    BindGridview();
            //    CPNS_Chart();
            //}
           

        }


     

        protected void btnBuilding_Click(object sender, EventArgs e)
        {
            GetAllData("BudgetMasterBuilding", "MasterBudgetBuilding.aspx");
           
        }

        protected void btnCRF_Click(object sender, EventArgs e)
        {
            GetAllData("BudgetMasterCRF", "MasterBudgetCRF.aspx");
           
        }

        protected void btnNabard_Click(object sender, EventArgs e)
        {
            GetAllData("BudgetMasterNABARD", "MasterBudgetNABARD.aspx");
        }

        protected void btnRoad_Click(object sender, EventArgs e)
        {
            GetAllData("BudgetMasterRoad", "MasterBudgetRoad.aspx");
           
        }

        protected void btnAunty_Click(object sender, EventArgs e)
        {
            GetAllData("BudgetMasterAunty", "MasterBudgetAunty.aspx");
        }

        protected void btnDPDC_Click(object sender, EventArgs e)
        {
           
            GetAllData("BudgetMasterDPDC", "MasterBudgetDPDC.aspx");
           
        }

        protected void btnMLA_Click(object sender, EventArgs e)
        {
            
            GetAllData("BudgetMasterMLA", "MasterBudgetMLA.aspx");
            
        }

        protected void btnMP_Click(object sender, EventArgs e)
        {
           
            GetAllData("BudgetMasterMP", "MasterBudgetMP.aspx");
            
        }

        protected void btnDFund_Click(object sender, EventArgs e)
        {
           
            GetAllData("BudgetMasterDepositFund", "MasterBudgetDepositFund.aspx");
        }

        protected void btnGataA_Click(object sender, EventArgs e)
        {
            GetAllData("BudgetMasterGAT_A", "MasterBudgetGat_A.aspx");
           
        }

        protected void btnGataD_Click(object sender, EventArgs e)
        {
            GetAllData("BudgetMasterGAT_D", "MasterBudgetGAT_D.aspx");
            
        }

        protected void btnGataFBC_Click(object sender, EventArgs e)
        {
            GetAllData("BudgetMasterGAT_FBC", "MasterBudgetGat_FBC.aspx");
        }

        protected void btnResidentialB_Click(object sender, EventArgs e)
        {
            GetAllData("BudgetMasterResidentialBuilding", "MasterBudgetResidentialBuilding.aspx");
            
        }

        protected void btnNonResidentialB_Click(object sender, EventArgs e)
        {
            GetAllData("BudgetMasterNonResidentialBuilding", "MasterBudgetNonResidentialBuilding.aspx");
            
        }

        public void BindChart()
        {
            dt = new DataTable();
            //Call a BindChart Method in clsSmS_CRUD for Binding Chart
            dt = objChartBind.BindChart();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Upvibhag = dt.Rows[i]["Upvibhag"].ToString();
                Type = dt.Rows[i]["Type"].ToString();
                count = Convert.ToString(dt.Rows[i]["Count"]);
                if (Type == "Building")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        BBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        BUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        BDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        BIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        BBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        BShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    BShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        BPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        BKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        BDoundEmart.InnerText = count;
                    }
                }
                else if (Type == "GAT_A")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        GABarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        GAUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        GADound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        GAIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        GABhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        GAShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    GAShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        GAPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        GAKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        GADoundEmart.InnerText = count;
                    }
                }
                else if (Type == "Road")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        ROBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        ROUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        RODound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        ROIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        ROBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        ROShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव ")
                    //{
                    //    ROShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        ROPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        ROKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        RODoundEmart.InnerText = count;
                    }
                }

                else if (Type == "CRF")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        CBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        CUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        CDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        CIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        CBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        CShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    CShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        CPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        CKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        CDoundEmart.InnerText = count;
                    }
                }
                else if (Type == "DepositFund")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        DFBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        DFUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        DFDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        DFIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        DFBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        DFShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    DFShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        DFPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        DFKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        DFDoundEmart.InnerText = count;
                    }
                }
                else if (Type == "DPDC")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        CBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        CUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        DPDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        DPIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        DPBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        DPShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव ")
                    //{
                    //    DPShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        DPPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        DPKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        DPDoundEmart.InnerText = count;
                    }
                }
                else if (Type == "GAT_FBC")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        GFBCBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        GFBCUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        GFBCDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        GFBCIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        GFBCBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        GFBCShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    GFBCShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        GFBCPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        GFBCKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        GFBCDoundEmart.InnerText = count;
                    }
                }
                else if (Type == "GAT_D")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        GDBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        GDUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        GDDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        GDIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        GDBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        GDShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    GDShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        GDPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        GDKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        GDDoundEmart.InnerText = count;
                    }
                }
                else if (Type == "MLA")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        MLABarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        MLAUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        MLADound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        MLAIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        MLABhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        MLAShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    MLAShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        MLAPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        MLAKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        MLADoundEmart.InnerText = count;
                    }
                }


                else if (Type == "MP")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        MPBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        MPUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        MPDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        MPIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        MPBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        MPShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    MPShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        MPPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        MPKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        MPDoundEmart.InnerText = count;
                    }
                }
                else if (Type == "NRB")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        NRBBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        NRBUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        NRBDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        NRBIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        NRBBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        NRBShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    NRBShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        NRBPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        NRBKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        NRBDoundEmart.InnerText = count;
                    }
                }

                else if (Type == "RB")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        RBBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        RBUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        RBDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        RBIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        RBBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        RbShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    RBShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        RBPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        RBKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        RBDoundEmart.InnerText = count;
                    }
                }

                else if (Type == "NABARD")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        NABarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        NAUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        NADound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        NAIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        NABhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        NAShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    NAShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        NAPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        NAKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        NADoundEmart.InnerText = count;
                    }

                }
                //New Head Add
                else if (Type == "2515")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        GramVBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        GramVUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        GramVDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        GramVIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        GramVBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        GramVShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    GramVShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        GramVPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        GramVKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        GramVDoundEmart.InnerText = count;
                    }
                }
                if (Type == "Aunty")
                {
                    if (Upvibhag == "सा.बां.उपविभाग, बारामती")
                    {
                        ANBarmati.InnerText = count;

                    }
                    else if (Upvibhag == "सा.बां.(वैद्यकीय) उपविभाग, बारामती ")
                    {
                        ANUpBaramati.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड")
                    {
                        ANDound.InnerText = count;
                    }

                    else if (Upvibhag == "सा.बां.उपविभाग, इंदापूर")
                    {
                        ANIndapur.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, भिगवण")
                    {
                        ANBhig.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, शिरुर")
                    {
                        ANShirur.InnerText = count;
                    }
                    //else if (Upvibhag == "सा.बां.उपविभाग, शिरुर,  आंबेगाव")
                    //{
                    //    ANShirurAm.InnerText = count;
                    //}

                    else if (Upvibhag == "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे")
                    {
                        ANPrakalp.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग, क्र. 4, पुणे")
                    {
                        ANKramank.InnerText = count;
                    }
                    else if (Upvibhag == "सा.बां.उपविभाग,दौंड ( ईमारती )")
                    {
                        ANDoundEmart.InnerText = count;
                    }
                }
            }

        }

        protected void btnGramvikas_Click(object sender, EventArgs e)
        {
            GetAllData("[BudgetMaster2515]", "MasterBudget2515.aspx");
           
        }
        protected void BindColumnChart()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            strcmd = "select (select  count(type) from BudgetMasterBuilding )as Building,(select  count(type)from  BudgetMasterCRF ) as CRF,(select  count(type) from BudgetMasterAunty )as Annuity,(select  count(type) from BudgetMasterDepositFund )as Deposit, (select  count(type)from  BudgetMasterDPDC ) as DPDC,(select  count(type)from  BudgetMasterGAT_A ) as Gat_A,(select  count(type)from  BudgetMasterGAT_D ) as Gat_D,(select  count(type)from  BudgetMasterGAT_FBC ) as Gat_BCF,(select  count(type)from  BudgetMasterMLA ) as MLA,(select  count(type)from  BudgetMasterMP ) as MP,(select  count(type)from  BudgetMasterNABARD ) as Nabard,(select  count(type)from  BudgetMasterRoad ) as Road,(select  count(type)from  BudgetMasterNonResidentialBuilding ) as NRB2059,(select  count(type)from  BudgetMasterResidentialBuilding ) as RB2216 ,(select count(type)from [BudgetMaster2515]) as GramVikas";
            sda = new SqlDataAdapter(strcmd, con);
            dt = new DataTable();
            sda.Fill(dt);
            //Series series = new Series();

            string[] x1 = new string[dt.Columns.Count];
            int[] y1 = new int[dt.Columns.Count];
            string[] x2 = new string[dt.Columns.Count];

            //series.ChartType = SeriesChartType.Pie;
            // int index = 0;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                int y = Convert.ToInt32(dt.Rows[0][i]);
                if (dt.Columns[i].ToString() == "NRB2059")
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = "2059";

                }
                else if (dt.Columns[i].ToString() == "RB2216")
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = "2216";
                }
                else if (dt.Columns[i].ToString() == "GramVikas")
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = "2515";
                }
                else
                {
                    x2[i] = dt.Rows[0][i].ToString();
                    y1[i] = Convert.ToInt32(dt.Rows[0][i]);
                    x1[i] = dt.Columns[i].ToString();
                }



            }
            foreach (Series s in Chart1.Series)
            {
                s.ToolTip = "State: #VALX\nTotalWork: #VALY\nPercentage: #PERCENT";

                //s.LegendText = x2.ToString();

            }
            Chart1.Series[0].Points.DataBindXY(x1, y1);
            Chart1.Series[0].Label = "#VALY";
            //Chart1.Series[0].Label= "#VALX";

            Chart1.Series[0].IsValueShownAsLabel = true;
            //Chart1.Series[0].LabelForeColor = System.Drawing.Color.Green;
            Chart1.ChartAreas[0].AxisX.Interval = 1;
            //Chart1.ChartAreas[0].AxisX.Crossing = 30;

            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -42;

            Chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Verdana", 11f);

            Chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Red;


            Chart1.Series[0].SmartLabelStyle.Enabled = false;// Remove auto property first

            Chart1.Series[0].LabelAngle = 20; // Can vary from -90 to 90;
            //Chart1.ChartAreas[0].Area3DStyle.Rotation = 10;
            Chart1.Series[0].LabelForeColor = Color.Red;
            Chart1.Series[0].Font = new Font("Verdana", 11f);
            Chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
            Chart1.Series[0].CustomProperties = "DrawingStyle=Cylinder, MaxPixelPointWidth=20";

           
        }
        DataTable Dumy_dt = new DataTable();
        protected void BindGridview()
        {
         
            Dumy_dt.Columns.Add("Head Name ");
            Dumy_dt.Columns.Add("Completed");
            Dumy_dt.Columns.Add("Incomplete");
            Dumy_dt.Columns.Add("Inprogress");
            Dumy_dt.Columns.Add("Tender Stage");
            Dumy_dt.Columns.Add("Estimated Stage");
            Dumy_dt.Columns.Add("Not Started");
            Dumy_dt.Columns.Add("No Status");
            Dumy_dt.Columns.Add("No.of.works");
            Dumy_dt.Columns.Add("Estimated Cost " + ddlYear.SelectedItem.ToString());
            Dumy_dt.Columns.Add("T.S Cost " + ddlYear.SelectedItem.ToString());
            Dumy_dt.Columns.Add("Budget Provision " + ddlYear.SelectedItem.ToString());
            Dumy_dt.Columns.Add("Expenditure " + ddlYear.SelectedItem.ToString());

            if(con.State!=ConnectionState.Open)
               con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME LIKE '%BudgetMaster%' AND TABLE_CATALOG='mahapwdd_EEPwdEastPuneDB'", con);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataTable ds = new DataTable();
            da.Fill(ds);
            DataRow dr1 = ds.NewRow();
            dr1["TABLE_NAME"] = "Total Head Abstract Report " + ddlYear.SelectedItem.ToString();
            ds.Rows.Add(dr1);
            con.Close();
            gvParentGrid.DataSource = ds;
            gvParentGrid.DataBind();

        }
        protected void BindddlYear() 
        {
            
            ddlYear.Items.Add("2015-2016");
            ddlYear.Items.Add("2016-2017");
            ddlYear.Items.Add("2017-2018");
            ddlYear.SelectedIndex = 2;
        }
        protected void BindddlUpvibhag()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            ddlupvibhag.Items.Clear();
            ddlupvibhag.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select UpVibhagacheName from SettingUpVibhag ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlupvibhag.Items.Add(dr["UpVibhagacheName"].ToString());
            }
            con.Close();
        }
        protected void BindddlSecEng()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            ddlSecEng.Items.Clear();
            ddlSecEng.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select [Name] from [SCreateAdmin] where [Post]=N'Sectional Engineer' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlSecEng.Items.Add(dr["Name"].ToString());
            }
            con.Close();
        }
        string provisionTbl = string.Empty;
        Boolean ParentFlag = false, ChildFlag = false;
        string HeadName = string.Empty;
        string PageName = string.Empty;
        protected void gvParentGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (con.State != ConnectionState.Open)
                con.Open();
                GridView gv = (GridView)e.Row.FindControl("gvChildGrid");
                
                string FromTbl = e.Row.Cells[1].Text;
                if (FromTbl.Trim() == "BudgetMasterBuilding")
                {
                    string NavigateUrl = "MasterBuildingReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                    //e.Row.Cells[1].Text = "Building";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">Building</a>";
                   
                    provisionTbl = "BuildingProvision";
                    HeadName = "Building";
                }
                else if (FromTbl.Trim() == "BudgetMasterNABARD")
                {
                    string NavigateUrl = "MasterNabardReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                   // e.Row.Cells[1].Text = "Nabard";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">Nabard</a>";
                    provisionTbl = "NABARDProvision";
                    HeadName = "Nabard";
                }
                else if (FromTbl.Trim() == "BudgetMaster2515")
                {
                    string NavigateUrl = "Master2515Report.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                    //e.Row.Cells[1].Text = "2515";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">2515</a>";
                    FromTbl = "[BudgetMaster2515]";
                    provisionTbl = "[2515Provision]";
                    HeadName = "2515";
                }
                else if (FromTbl.Trim() == "BudgetMasterRoad")
                {
                    string NavigateUrl = "MasterRoadReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                    //e.Row.Cells[1].Text = "SH & DOR";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">SH & DOR</a>";
                    provisionTbl = "RoadProvision";
                    HeadName = "Road";
                }
                else if (FromTbl.Trim() == "BudgetMasterAunty")
                {
                    string NavigateUrl = "MasterAuntyReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                    //e.Row.Cells[1].Text = "Annuity";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">Annuity</a>";
                    provisionTbl = "AuntyProvision";
                    HeadName = "Annuity";
                }
                else if (FromTbl.Trim() == "BudgetMasterCRF")
                {
                    string NavigateUrl = "MasterCRFReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                    //e.Row.Cells[1].Text = "CRF";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">CRF</a>";
                    provisionTbl = "CRFProvision";
                    HeadName = "CRF";
                }
                else if (FromTbl.Trim() == "BudgetMasterMLA")
                {
                    string NavigateUrl = "MasterMLAReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                   // e.Row.Cells[1].Text = "MLA";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">MLA</a>";
                    provisionTbl = "MLAProvision";
                    HeadName = "MLA";
                }
                else if (FromTbl.Trim() == "BudgetMasterMP")
                {
                    string NavigateUrl = "MasterMPReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                   // e.Row.Cells[1].Text = "MP";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">MP</a>";
                    provisionTbl = "MPProvision";
                    HeadName = "MP";
                }
                else if (FromTbl.Trim() == "BudgetMasterDPDC")
                {
                    string NavigateUrl = "MasterDPDCReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                    //e.Row.Cells[1].Text = "DPDC";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">DPDC</a>";
                    provisionTbl = "DPDCProvision";
                    HeadName = "DPDC";
                }
                else if (FromTbl.Trim() == "BudgetMasterGAT_A")
                {
                    string NavigateUrl = "MasterGat_AReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                    //e.Row.Cells[1].Text = "Gat_A";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">Gat_A</a>";
                    provisionTbl = "GAT_AProvision";
                    HeadName = "Gat_A";
                }
                else if (FromTbl.Trim() == "BudgetMasterGAT_FBC")
                {
                    string NavigateUrl = "MasterGat_BReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    string NavigateUrl1 = "MasterGat_CReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    string NavigateUrl2 = "MasterGat_FReport.aspx?Year=" + ddlYear.SelectedItem.ToString();

                    PageName = NavigateUrl + "&CPNS=";
                   // e.Row.Cells[1].Text = "Gat_BCF";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">Gat_B|</a> ";
                    e.Row.Cells[1].Text += " <a href=" + NavigateUrl1 + ">C|</a>  ";
                    e.Row.Cells[1].Text += " <a href=" + NavigateUrl2 + ">F</a> ";


                    provisionTbl = "GAT_FBCProvision";
                    HeadName = "Gat_BCF";
                }
                else if (FromTbl.Trim() == "BudgetMasterDepositFund")
                {
                    string NavigateUrl = "MasterDepositeFundReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";                   
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">Deposit</a>";
                    provisionTbl = "DepositFundProvision";
                    HeadName = "Deposit";
                }
                else if (FromTbl.Trim() == "BudgetMasterGAT_D")
                {
                    string NavigateUrl = "MasterGat_DReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                   // e.Row.Cells[1].Text = "Gat_D";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">Gat_D</a>";
                    provisionTbl = "GAT_DProvision";
                    HeadName = "Gat_D";
                }
                else if (FromTbl.Trim() == "BudgetMasterResidentialBuilding")
                {
                    string NavigateUrl = "MasterResidentialBulidingReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                    //e.Row.Cells[1].Text = "2216";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">2216</a>";
                    provisionTbl = "ResidentialBuildingProvision";
                    HeadName = "2216";
                }
                else if (FromTbl.Trim() == "BudgetMasterNonResidentialBuilding")
                {
                    string NavigateUrl = "MasterNonResidentialBulidingReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                    PageName = NavigateUrl + "&CPNS=";
                    //e.Row.Cells[1].Text = "2059";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">2059</a>";
                    provisionTbl = "NonResidentialBuildingProvision";
                    HeadName = "2059";
                    ParentFlag = true;
                }
                else if (FromTbl.Trim() == "Total Head Abstract Report " + ddlYear.SelectedItem.ToString())
                {
                    ChildFlag = true;
                    string NavigateUrl = "SReport17Columns.aspx?Year=" + ddlYear.SelectedItem.ToString() + "&UpV=" + ddlupvibhag.SelectedIndex;
                    PageName = NavigateUrl + "&CPNS=";
                    //e.Row.Cells[1].Text = "2059";
                    e.Row.Cells[1].Text = "<a href=" + NavigateUrl + ">Total Head Abstract Report</a>";
                    provisionTbl = "NonResidentialBuildingProvision";
                }
                if (ChildFlag)
                {
                    gv.DataSource = Dumy_dt;
                    gv.DataBind();
                }
                else
                {
                    string query = "SELECT a.[Sadyasthiti]as 'Work Status', Count(a.[Sadyasthiti])as'Total Work',sum(cast(a.[PrashaskiyAmt] as decimal(10,2))) as 'Estimated Cost',sum(cast(a.[TrantrikAmt]as decimal(10,2)))as 'T.S Cost',sum(cast(b.[Tartud]as decimal(10,2))) as ";
                    string groupby = " GROUP BY a.[Sadyasthiti] order by case a.[Sadyasthiti] when N'पूर्ण' then 1 when N'Completed' then 1 when N'Incomplete' then 2 when N'अपूर्ण' then 2 when N'प्रगतीत' then 3 when N'Inprogress' then 3 when N'Processing' then 3 when N'Current' then 3 when N'चालू' then 3  when N'Tender Stage' then 4 when N'निविदा स्तर' then 4 when N'Estimated Stage' then 5 when N'अंदाजपत्रकिय स्थर' then 5 when N'अंदाजपत्रकीय स्तर' then 5 when N'Not Started' then 6 when N'सुरु न झालेली' then 6 when N'सुरू करणे' then 7 when N'' then 8 end";
                    SqlCommand cmd;
                    if (ddlupvibhag.Text != "निवडा")
                    {
                        if (ddlSecEng.Text != "निवडा")
                        {
                            cmd = new SqlCommand(query + "'Budget Provision " + ddlYear.SelectedItem.ToString() + "',sum(cast(b.[AikunKharch]as decimal(10,2))) as 'Expenditure " + ddlYear.SelectedItem.ToString() + "' FROM " + FromTbl + " a full outer join " + provisionTbl + "  b on a.workid=b.workid where a.[Sadyasthiti]IS NOT NULL and b.Arthsankalpiyyear='" + ddlYear.SelectedItem.ToString() + "' and a.Upvibhag=N'" + ddlupvibhag.SelectedItem.ToString() + "' and a.[ShakhaAbhyantaName]=N'" + ddlSecEng.SelectedItem.ToString() + "'" + groupby, con);
                        }
                        else
                        {
                            cmd = new SqlCommand(query + " 'Budget Provision " + ddlYear.SelectedItem.ToString() + "',sum(cast(b.[AikunKharch]as decimal(10,2))) as 'Expenditure " + ddlYear.SelectedItem.ToString() + "' FROM " + FromTbl + " a full outer join " + provisionTbl + "  b on a.workid=b.workid where a.[Sadyasthiti]IS NOT NULL and b.Arthsankalpiyyear='" + ddlYear.SelectedItem.ToString() + "' and a.Upvibhag=N'" + ddlupvibhag.SelectedItem.ToString() + "'" + groupby, con);
                        }
                    }
                    else if (ddlupvibhag.Text == "निवडा" && ddlSecEng.Text != "निवडा")
                    {
                        cmd = new SqlCommand(query + "'Budget Provision " + ddlYear.SelectedItem.ToString() + "',sum(cast(b.[AikunKharch]as decimal(10,2))) as 'Expenditure " + ddlYear.SelectedItem.ToString() + "' FROM " + FromTbl + " a full outer join " + provisionTbl + "  b on a.workid=b.workid where a.[Sadyasthiti]IS NOT NULL and b.Arthsankalpiyyear='" + ddlYear.SelectedItem.ToString() + "'  and a.[ShakhaAbhyantaName]=N'" + ddlSecEng.SelectedItem.ToString() + "'" + groupby, con);
                    }
                    else
                    {
                        cmd = new SqlCommand(query + "'Budget Provision " + ddlYear.SelectedItem.ToString() + "',sum(cast(b.[AikunKharch]as decimal(10,2))) as 'Expenditure " + ddlYear.SelectedItem.ToString() + "' FROM " + FromTbl + " a full outer join " + provisionTbl + "  b on a.workid=b.workid where a.[Sadyasthiti]IS NOT NULL and b.Arthsankalpiyyear='" + ddlYear.SelectedItem.ToString() + "'  " + groupby, con);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    TotalWork = 0;
                    AACost = 0;
                    TSCost = 0;
                    TotalProvision = 0;
                    TotalExp = 0;
                    da.Fill(ds);
                    con.Close();
                    gv.DataSource = ds;
                    gv.DataBind();

                }
            }
        }



        int com, inc, inp, TS, ES, NS, NoStatus, No_OF_Works;
        decimal TotalWork=0;
        decimal AACost = 0;
        decimal TSCost = 0;
        decimal TotalProvision = 0;
        decimal TotalExp = 0;
        Boolean flag = true;
        decimal[] arr = new decimal[10];
        string[] arr1 = { "Completed", "Incomplete", "Inprogress", "Tender Stage", "Estimated Stage", "Not Started", "Estimated Cost", "T.S Cost", "Budget Provision", "Expenditure" };
        DataRow dr;
        public void CPNS_Chart()
        {
            foreach (Series s in Chart2.Series)
            {
                s.ToolTip = "State: #VALX\nTotalWork: #VALY\nPercentage: #PERCENT";
                s.LabelToolTip = "State: #VALX\nTotalWork: #VALY\nPercentage: #PERCENT";
                //s.LegendText = x2.ToString();
            }
            Chart2.Series[0].Points.DataBindXY(arr1, arr);
            Chart2.Series[0].Label = "#VALY";
            Chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            Chart1.Series[0].IsValueShownAsLabel = true;
            //Chart1.Series[0].LabelForeColor = System.Drawing.Color.Green;
           // Chart1.ChartAreas[0].AxisX.Interval = 1;
            //Chart1.ChartAreas[0].AxisX.Crossing = 30;

            Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -42;

            Chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Verdana", 11f);

            Chart2.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Red;


            Chart2.Series[0].SmartLabelStyle.Enabled = false;// Remove auto property first

            Chart2.Series[0].LabelAngle = 20; // Can vary from -90 to 90;
            //Chart1.ChartAreas[0].Area3DStyle.Rotation = 10;
            Chart2.Series[0].LabelForeColor = Color.Red;
            Chart2.Series[0].Font = new Font("Verdana", 11f);
            

        }

        protected void gvChildGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (ChildFlag)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                   
                    com += Convert.ToInt32(e.Row.Cells[1].Text != "&nbsp;" ? e.Row.Cells[1].Text : e.Row.Cells[1].Text = "0");

                    if (e.Row.Cells[2].Text != "&nbsp;")
                        inc += Convert.ToInt32(e.Row.Cells[2].Text);
                    else e.Row.Cells[2].Text = "0";
                    if (e.Row.Cells[3].Text != "&nbsp;")
                        inp += Convert.ToInt32(e.Row.Cells[3].Text);
                    else e.Row.Cells[3].Text = "0";
                    if (e.Row.Cells[4].Text != "&nbsp;")
                        TS += Convert.ToInt32(e.Row.Cells[4].Text);
                    else e.Row.Cells[4].Text = "0";
                    if (e.Row.Cells[5].Text != "&nbsp;")
                        ES += Convert.ToInt32(e.Row.Cells[5].Text);
                    else e.Row.Cells[5].Text = "0";
                    if (e.Row.Cells[6].Text != "&nbsp;")
                        NS += Convert.ToInt32(e.Row.Cells[6].Text);
                    else e.Row.Cells[6].Text = "0";
                    NoStatus += Convert.ToInt32(e.Row.Cells[7].Text != "&nbsp;" ? e.Row.Cells[7].Text : e.Row.Cells[7].Text = "0");
                    No_OF_Works += Convert.ToInt32(e.Row.Cells[8].Text);
                    AACost += Convert.ToDecimal(e.Row.Cells[9].Text);
                    TSCost += Convert.ToDecimal(e.Row.Cells[10].Text);
                    TotalProvision += Convert.ToDecimal(e.Row.Cells[11].Text);
                    TotalExp += Convert.ToDecimal(e.Row.Cells[12].Text);

                    if (e.Row.Cells[0].Text.Trim() == "Building")
                    {
                        string NavigateUrl = "MasterBuildingReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        //PageName = NavigateUrl + "&CPNS=";
                        //e.Row.Cells[1].Text = "Building";
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">Building</a>";
                        //provisionTbl = "BuildingProvision";
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Nabard")
                    {
                        string NavigateUrl = "MasterNabardReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">Nabard</a>";
                    }
                     else if (e.Row.Cells[0].Text.Trim() == "2515")
                    {
                        string NavigateUrl = "Master2515Report.aspx?Year=" + ddlYear.SelectedItem.ToString();
                       
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">2515</a>";
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Road")
                    {
                        string NavigateUrl = "MasterRoadReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">SH & DOR</a>";
                    }
                     else if (e.Row.Cells[0].Text.Trim() == "Annuity")
                    {
                        string NavigateUrl = "MasterAuntyReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">Annuity</a>";
                    }
                     else if (e.Row.Cells[0].Text.Trim() == "CRF")
                    {
                        string NavigateUrl = "MasterCRFReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">CRF</a>";
                     }
                    else  if (e.Row.Cells[0].Text.Trim() == "MLA")
                    {
                        string NavigateUrl = "MasterMLAReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">MLA</a>";
                    }
                    else  if (e.Row.Cells[0].Text.Trim() == "MP")
                    {
                        string NavigateUrl = "MasterMPReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">MP</a>";
                    }
                     else if  (e.Row.Cells[0].Text.Trim() == "DPDC")
                    {
                        string NavigateUrl = "MasterDPDCReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">DPDC</a>";
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Gat_A")
                    {
                        string NavigateUrl = "MasterGat_AReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                       
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">Gat_A</a>";
                    }
                     else if (e.Row.Cells[0].Text.Trim() == "Gat_BCF")
                    {
                        string NavigateUrl = "MasterGat_BReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        string NavigateUrl1 = "MasterGat_CReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        string NavigateUrl2 = "MasterGat_FReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                      
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">Gat_B|</a> ";
                        e.Row.Cells[0].Text += " <a href=" + NavigateUrl1 + ">C|</a>  ";
                        e.Row.Cells[0].Text += " <a href=" + NavigateUrl2 + ">F</a> ";
                    }
                     else if (e.Row.Cells[0].Text.Trim() == "Deposit")
                    {
                        string NavigateUrl = "MasterDepositeFundReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">Deposit</a>";
                    }
                    else  if (e.Row.Cells[0].Text.Trim() == "Gat_D")
                    {
                        string NavigateUrl = "MasterGat_DReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">Gat_D</a>";
                    }
                    else  if (e.Row.Cells[0].Text.Trim() == "2216")
                    {
                        string NavigateUrl = "MasterResidentialBulidingReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">2216</a>";
                    }
                    else  if (e.Row.Cells[0].Text.Trim() == "2059")
                    {
                        string NavigateUrl = "MasterNonResidentialBulidingReport.aspx?Year=" + ddlYear.SelectedItem.ToString();
                        e.Row.Cells[0].Text = "<a href=" + NavigateUrl + ">2059</a>";
                    }
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Total";


                    e.Row.Cells[1].Text = com.ToString();
                    e.Row.Cells[2].Text = inc.ToString();
                    e.Row.Cells[3].Text = inp.ToString();
                    e.Row.Cells[4].Text = TS.ToString();
                    e.Row.Cells[5].Text = ES.ToString();
                    e.Row.Cells[6].Text = NS.ToString();
                    e.Row.Cells[7].Text = NoStatus.ToString();
                    e.Row.Cells[8].Text = No_OF_Works.ToString();                    
                    e.Row.Cells[9].Text = AACost.ToString();
                    e.Row.Cells[10].Text = TSCost.ToString();
                    e.Row.Cells[11].Text = TotalProvision.ToString();
                    e.Row.Cells[12].Text = TotalExp.ToString();
                }

            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (flag)
                    {
                        dr = Dumy_dt.NewRow();
                    }
                    flag = false;

                    dr[0] = HeadName;
                    if (e.Row.Cells[0].Text.Trim() == "Completed" || e.Row.Cells[0].Text.Trim() == "पूर्ण")
                    {

                        e.Row.Cells[0].Text = "<a href=" + PageName + e.Row.Cells[0].Text.Trim() + ">पूर्ण</a>";
                        arr[0] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[1] = e.Row.Cells[1].Text;
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Incomplete" || e.Row.Cells[0].Text.Trim() == "अपूर्ण")
                    {
                        e.Row.Cells[0].Text = "<a href=" + PageName + e.Row.Cells[0].Text.Trim() + ">अपूर्ण</a>";
                        arr[1] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[2] = e.Row.Cells[1].Text;
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Inprogress" || e.Row.Cells[0].Text.Trim() == "Processing" || e.Row.Cells[0].Text.Trim() == "Current" || e.Row.Cells[0].Text.Trim() == "चालू" || e.Row.Cells[0].Text.Trim() == "प्रगतीत")
                    {
                        e.Row.Cells[0].Text = "<a href=" + PageName + e.Row.Cells[0].Text.Trim() + ">प्रगतीत</a>";
                        arr[2] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[3] = e.Row.Cells[1].Text;
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Tender Stage" || e.Row.Cells[0].Text.Trim() == "निविदा स्तर")
                    {
                        string val = e.Row.Cells[0].Text.Trim() == "Tender Stage" ? "Tender%20Stage" : "निविदा%20स्तर";
                        e.Row.Cells[0].Text = "<a href=" + PageName + val + ">निविदा स्तर</a>";
                        arr[3] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[4] = e.Row.Cells[1].Text;
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Estimated Stage" || e.Row.Cells[0].Text.Trim() == "अंदाजपत्रकिय स्थर" || e.Row.Cells[0].Text.Trim() == "अंदाजपत्रकिय स्तर")
                    {
                        string val = e.Row.Cells[0].Text.Trim() == "Estimated Stage" ? "Estimated%20Stage" : e.Row.Cells[0].Text.Trim() == "अंदाजपत्रकिय स्थर" ? "अंदाजपत्रकिय%20स्थर" : "अंदाजपत्रकिय%20स्तर";
                        e.Row.Cells[0].Text = "<a href=" + PageName + val + ">अंदाजपत्रकिय स्थर</a>";
                        arr[4] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[5] = e.Row.Cells[1].Text;
                    }
                    else if (e.Row.Cells[0].Text.Trim() == "Not Started" || e.Row.Cells[0].Text.Trim() == "सुरू करणे" || e.Row.Cells[0].Text.Trim() == "सुरु न झालेली")
                    {
                        string val = e.Row.Cells[0].Text.Trim() == "Not Started" ? "Not%20Started" : e.Row.Cells[0].Text.Trim() == "सुरू करणे" ? "सुरू%20करणे" : "सुरु%20न%20झालेली";
                        e.Row.Cells[0].Text = "<a href=" + PageName + val + ">सुरु न झालेली</a>";
                        arr[5] += Convert.ToDecimal(e.Row.Cells[1].Text);
                        dr[6] = e.Row.Cells[1].Text;
                    }
                    
                   
                    else
                    {
                        e.Row.Cells[0].Text = "<a href=" + PageName + ""+ ">सध्यास्तिथी उपलब्ध नाही</a>";
                        dr[7] = e.Row.Cells[1].Text;

                    }

                    //e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                    TotalWork += Convert.ToDecimal(e.Row.Cells[1].Text);
                    AACost += Convert.ToDecimal(e.Row.Cells[2].Text);
                    TSCost += Convert.ToDecimal(e.Row.Cells[3].Text);
                    TotalProvision += Convert.ToDecimal(e.Row.Cells[4].Text);
                    TotalExp += Convert.ToDecimal(e.Row.Cells[5].Text);
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    dr[8] = TotalWork.ToString();
                    dr[9] = AACost.ToString();
                    dr[10] = TSCost.ToString();
                    dr[11] = TotalProvision.ToString();
                    dr[12] = TotalExp.ToString();
                    Dumy_dt.Rows.Add(dr);
                    flag = true;
                    e.Row.Cells[0].Text = "एकूण";
                    e.Row.Cells[1].Text = TotalWork.ToString();
                    e.Row.Cells[2].Text = AACost.ToString();
                    e.Row.Cells[3].Text = TSCost.ToString();
                    e.Row.Cells[4].Text = TotalProvision.ToString();
                    e.Row.Cells[5].Text = TotalExp.ToString();
                    arr[6] += AACost;
                    arr[7] += TSCost;
                    arr[8] += TotalProvision;
                    arr[9] += TotalExp;
                }
            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  ddlupvibhag.Items.FindByText("निवडा").Selected = true;
         //   ddlSecEng.Items.FindByText("निवडा").Selected = true;
            BindGridview();
            CPNS_Chart();
        }

       
        protected void BtnExcel_Click1(object sender, ImageClickEventArgs e)
        {

            gvParentGrid.AllowPaging = false;
            var gvChildGrid = new GridView();
            for (var i = 0; i < gvParentGrid.Rows.Count; i++)
            {
                gvChildGrid = (GridView)gvParentGrid.Rows[i].FindControl("gvChildGrid");
                gvChildGrid.AllowPaging = false;
               // BindGrid(SortField);
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Upvibhag" + DateTime.Now + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvChildGrid.AllowPaging = false;
                //this.BindGrid(SortField);
                gvChildGrid.Font.Name = "Times New Roman";
                gvChildGrid.BackColor = Color.Transparent;
                gvChildGrid.GridLines = GridLines.Both;
                
                
                gvChildGrid.RenderControl(hw);
                Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase));
                
                Response.Flush();
                Response.End();
            }
            
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void ddlupvibhag_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlSecEng.Items.FindByText("निवडा").Selected = true;
            Session["SAP_Upvibhag"] = ddlupvibhag.Text;
            BindGridview();
            CPNS_Chart();
        }

        protected void ddlSecEng_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SAP_ShakhaAbhiyanta"] = ddlSecEng.Text;
            BindGridview();
            CPNS_Chart();
        }
        
    }
}