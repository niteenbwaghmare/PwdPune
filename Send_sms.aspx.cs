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
namespace PWdEEBudget
{
    public partial class Send_sms : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string WorkId = Request.QueryString["WorkID"].ToString();
            con.Open();
            if (!Page.IsPostBack)
            {
                BindData();
                string Path = System.Web.HttpContext.Current.Request.UrlReferrer.AbsolutePath;
                System.IO.FileInfo Info = new System.IO.FileInfo(Path);
                string pageName = Info.Name;
                Session["pageName"] = pageName;
            }

        }
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
        
        protected void Button1_Click(object sender, EventArgs e)
        {
              string contact = txtmobileno.Text;
            string message = txtdescription.Text;
            var yArray = txtmobileno.Text.ToString().Split(',').Select(m => m.Trim()).ToArray();

            foreach (String strno in yArray)
            {
                SendSMS(strno, message);
            }
            string senderid = "EEesPN";
           
            SqlCommand cmd = new SqlCommand("insert into SendSms(SenderId,MobileNo,Description)values('" + senderid.ToString() + "','" + txtmobileno.Text + "',N'" + txtdescription.Text + "')", con);
           
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                lblStatus.Text = "<b style='color:green'>SMS Sent Successfully!!!</b>";
               
                string QueryString = Request.Url.ToString();

                if (Session["pageName"].ToString() == "MasterBuildingReport.aspx")
                {
                    Response.Redirect("MasterBuildingReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterCRFReport.aspx")
                {
                    Response.Redirect("MasterCRFReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterDepositeFundReport.aspx")
                {
                    Response.Redirect("MasterDepositeFundReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterDPDCReport.aspx")
                {
                    Response.Redirect("MasterDPDCReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterGat_AReport.aspx")
                {
                    Response.Redirect("MasterGat_AReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterGAT_BReport.aspx")
                {
                    Response.Redirect("MasterGAT_BReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterGAT_CReport.aspx")
                {
                    Response.Redirect("MasterGAT_CReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterGAT_DReport.aspx")
                {
                    Response.Redirect("MasterGAT_DReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterGAT_FReport.aspx")
                {
                    Response.Redirect("MasterGAT_FReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterMLAReport.aspx")
                {
                    Response.Redirect("MasterMLAReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterMPReport.aspx")
                {
                    Response.Redirect("MasterMPReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterNabardReport.aspx")
                {
                    Response.Redirect("MasterNabardReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterRoadReport.aspx")
                {
                    Response.Redirect("MasterRoadReport.aspx");
                }
                else if (Session["pageName"].ToString() == "MasterAuntyReport.aspx")
                {
                    Response.Redirect("MasterAuntyReport.aspx");
                }
                else if (Session["pageName"].ToString() == "SReport.aspx")
                {
                    Response.Redirect("SReport.aspx");
                }
                else
                {
                    string PrevPage = Session["pageName"].ToString();
                    Response.Redirect(PrevPage);
                }
            }
            else
            {
                lblStatus.Text = "<b style='color:red'>SMS Sending failed!!!</b>";
            }
            con.Close();
            //gridshow();

        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperAdminPanel.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<ListItem> selected = DropDownCheckBoxes1.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            foreach (ListItem oItem in selected)
            {
                if (oItem.Selected)
                {
                    txtmobileno.Text += oItem.Value + ",";
                }

            }
            DropDownCheckBoxes1.Items.Clear();
        }

        protected void BindData()
        {
            DataSet ds = new DataSet();
            DataSet GetNamesDS = new DataSet();
            string ShakhaAbhyantaName = string.Empty;
            string UpabhyantaName = string.Empty;
            string ThekedaarName = string.Empty;
            string blank = " ";
            string UrlWorId = Request.QueryString["WorkID"].ToString();
            string Value;
            txtdescription.Text = "WorkId:" + UrlWorId + " ";
            string Path = System.Web.HttpContext.Current.Request.UrlReferrer.AbsolutePath;
            System.IO.FileInfo Info = new System.IO.FileInfo(Path);
            string pageName = Info.Name;
            string QueryString = Request.Url.ToString();
            string pathUrl = Session["pathUrl"].ToString();
            if (pageName == "MasterBuildingReport.aspx" || pathUrl=="Building")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames.ToString(), con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterCRFReport.aspx" || pathUrl=="CRF")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterCRF as a join CRFProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterNabardReport.aspx" || pathUrl=="Nabard")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterRoadReport.aspx" || pathUrl=="Road")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterRoad as a join RoadProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterDPDCReport.aspx" || pathUrl=="DPDC")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterDPDC as a join DPDCProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterDepositeFundReport.aspx" || pathUrl=="Deposit Fund")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterDepositFund as a join DepositFundProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterMPReport.aspx" || pathUrl=="MP")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterMP as a join MPProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterMPReport.aspx" || pathUrl=="MP")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterMP as a join MPProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterMLAReport.aspx" || pathUrl=="MLA")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterMLA as a join MLAProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterGat_AReport.aspx" || pathUrl=="GAT_A")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterGAT_A as a join GAT_AProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            //else if (pageName == "MasterGAT_BReport.aspx")
            //{
            //    string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
            //    SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
            //    GetNamesDA.Fill(GetNamesDS);
            //}

            else if (pageName == "MasterGat_FReport.aspx" || pageName == "MasterGAT_BReport.aspx" || pageName == "MasterGAT_CReport.aspx" || pathUrl == "गट एफ" || pathUrl == "गट बी" || pathUrl == "गट सी")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterGat_DReport.aspx"||pathUrl=="GAT_D")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterGAT_D as a join GAT_DProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "MasterAuntyReport.aspx"||pathUrl=="Annuty")
            {
                string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterAunty as a join AuntyProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                GetNamesDA.Fill(GetNamesDS);
            }

            else if (pageName == "SReport.aspx")
            {
                 Value = Request.QueryString["Value"].ToString();
                if (Value == "GridBuilding")
                {
                    string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                    SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                    GetNamesDA.Fill(GetNamesDS);
                }
                if (Value.ToString() == "GridCRF")
                {
                    string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterCRF as a join CRFProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                    SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                    GetNamesDA.Fill(GetNamesDS);
                }
                if (Value.ToString() == "GridNabard")
                {
                    string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                    SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                    GetNamesDA.Fill(GetNamesDS);
                }
                if (Value.ToString() == "GridRoad")
                {
                    string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterRoad as a join RoadProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                    SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                    GetNamesDA.Fill(GetNamesDS);
                }
                if (Value.ToString() == "GridDPDC")
                {
                    string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterDPDC as a join DPDCProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                    SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                    GetNamesDA.Fill(GetNamesDS);
                }
                if (Value.ToString() == "GridMLA")
                {
                    string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterMLA as a join MLAProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                    SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                    GetNamesDA.Fill(GetNamesDS);
                }
                if (Value.ToString() == "GridMP")
                {
                    string GetNames = "select a.ShakhaAbhyantaName as ShakhaAbhyantaName,a.UpabhyantaName as UpabhyantaName,a.ThekedaarName as ThekedaarName from BudgetMasterMP as a join MPProvision as b on a.WorkId=b.WorkId where a.WorkId='" + UrlWorId + "'";
                    SqlDataAdapter GetNamesDA = new SqlDataAdapter(GetNames, con);
                    GetNamesDA.Fill(GetNamesDS);
                }
            }
            if (GetNamesDS.Tables.Count > 0)
            {
                if (GetNamesDS.Tables[0].Rows.Count > 0)
                {
                    ShakhaAbhyantaName = GetNamesDS.Tables[0].Rows[0]["ShakhaAbhyantaName"].ToString();
                    UpabhyantaName = GetNamesDS.Tables[0].Rows[0]["UpabhyantaName"].ToString();
                    ThekedaarName = GetNamesDS.Tables[0].Rows[0]["ThekedaarName"].ToString();
                }


                string cmdstr = "select Name,MobileNo from SCreateAdmin where Name=N'" + ShakhaAbhyantaName.ToString() + "' OR Name=N'" + UpabhyantaName.ToString() + "' OR Name=N'" + ThekedaarName.ToString() + "'";
                SqlDataAdapter adp = new SqlDataAdapter(cmdstr, con);
                adp.Fill(ds);



                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropDownCheckBoxes1.Items.Clear();
                    DropDownCheckBoxes1.DataSource = ds.Tables[0];
                    DropDownCheckBoxes1.DataTextField = "Name";
                    DropDownCheckBoxes1.DataValueField = "MobileNo";
                    DropDownCheckBoxes1.DataBind();                  
                }
            }
            else
            {
                Response.Redirect(pageName,false);
            }
        }
    }
}