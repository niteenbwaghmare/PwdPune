using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;


namespace PWdEEBudget
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection cn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DataSet ds = null;

        string strSqlCommand = string.Empty;

        private bool gridLoaded;
        protected void Page_Load(object sender, EventArgs e)
        {

            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            if (!IsPostBack)
            {
                GridView EmailGrid = (GridView)Session["LekhasirshBuildingRpt"];
                GridView Report_LekhasirshCRF = (GridView)Session["Report_LekhasirshCRF"];
                GridView LekhasirshDPDCRpt = (GridView)Session["LekhasirshDPDCRpt"];
                GridView Report_LekhasirshMLA = (GridView)Session["Report_LekhasirshMLA"];
                GridView Report_LekhasirshMP = (GridView)Session["Report_LekhasirshMP"];
                GridView Report_LekhasirshNabard = (GridView)Session["Report_LekhasirshNabard"];
                GridView Report_LekhasirshRoad = (GridView)Session["Report_LekhasirshRoad"];
                GridView Report_MasterBuilding = (GridView)Session["Report_MasterBuilding"];
                GridView MasterBuildingRpt = (GridView)Session["MasterBuildingRpt"];
                GridView MasterDPDCRpt = (GridView)Session["MasterDPDCRpt"];
                GridView MasterMLARpt = (GridView)Session["MasterMLARpt"];
                GridView MasterMPRpt = (GridView)Session["MasterMPRpt"];
                GridView MasterNabardRpt = (GridView)Session["MasterNabardRpt"];
                GridView MasterRoadRpt = (GridView)Session["MasterRoadRpt"];
                GridView MasterCRFRpt = (GridView)Session["MasterCRFRpt"];
                GridView MasterGat_ARpt = (GridView)Session["MasterGat_ARpt"];
                GridView MasterGat_BRpt = (GridView)Session["MasterGat_BRpt"];
                GridView MasterGat_CRpt = (GridView)Session["MasterGat_CRpt"];
                GridView MasterGat_DRpt = (GridView)Session["MasterGat_DRpt"];
                GridView MasterGat_FRpt = (GridView)Session["MasterGat_FRpt"];
                GridView MasterANNUITYRpt = (GridView)Session["MasterANNUITYRpt"];
                GridView MasterDepositFundRpt = (GridView)Session["MasterDepositFundRpt"];
                GridView MasterNonResidentialBuildingRpt = (GridView)Session["MasterNonResidentialBuildingRpt"];
                GridView MasterResidentialBuildingRpt = (GridView)Session["MasterResidentialBuildingRpt"];
                GridView Report_MasterMP = (GridView)Session["Report_MasterMP"];
                GridView LekhasirshGAT_ARpt = (GridView)Session["LekhasirshGAT_ARpt"];
                GridView LekhasirshGAT_BRpt = (GridView)Session["LekhasirshGAT_BRpt"];
                GridView LekhasirshGAT_CRpt = (GridView)Session["LekhasirshGAT_CRpt"];
                GridView LekhasirshGAT_DRpt = (GridView)Session["LekhasirshGAT_DRpt"];
                GridView LekhasirshGAT_FRpt = (GridView)Session["LekhasirshGAT_FRpt"];
                GridView LekhasirshResBuildingRpt = (GridView)Session["LekhasirshResBuildingRpt"];
                GridView LekhasirshNonResBuildingRpt = (GridView)Session["LekhasirshNonResBuildingRpt"];
                GridView Lekhasirsh2515Rpt = (GridView)Session["Lekhasirsh2515Rpt"];
                GridView LekhasirshDepositeContributionFundRpt = (GridView)Session["LekhasirshDepositeContributionFundRpt"];
                //SReport
                GridView SReport_DPDC = (GridView)Session["SReport_DPDC"];
                GridView SReport_Road = (GridView)Session["SReport_Road"];
                GridView SReport_Nabard = (GridView)Session["SReport_Nabard"];
                GridView SReport_CRF = (GridView)Session["SReport_CRF"];
                GridView SReport_Building = (GridView)Session["SReport_Building"];
                GridView SReport_MLA = (GridView)Session["SReport_MLA"];
                GridView SReport_MP = (GridView)Session["SReport_MP"];
                GridView Report_MasterRoad = (GridView)Session["Report_MasterRoad"];

                GridView SReport_Aunty = (GridView)Session["SReport_Aunty"];
                GridView SReport_DepositeFund = (GridView)Session["SReport_DepositeFund"];
                GridView SReport_GATA = (GridView)Session["SReport_GATA"];
                GridView SReport_GATD = (GridView)Session["SReport_GATD"];
                GridView SReport_GATF = (GridView)Session["SReport_GATF"];
                GridView SReport_GATB = (GridView)Session["SReport_GATB"];
                GridView SReport_GATC = (GridView)Session["SReport_GATC"];
                GridView SReport_ResidentialBuilding = (GridView)Session["SReport_ResidentialBuilding"];
                GridView SReport_NonResidentialBuilding = (GridView)Session["SReport_NonResidentialBuilding"];
                GridView SReport_2515 = (GridView)Session["SReport_2515"];

                Panel SReportPanel = (Panel)Session["SReportPanel"];
            }
            if (this.IsPostBack)
            {

                //psw.Attributes["value"] = psw.Text;

                FileUpload1.Attributes["value"] = FileUpload1.PostedFile.FileName;

                // Maintain FileUpload value between postback
                string file;
                if (Session["FileUpload1"] == null && FileUpload1.HasFile)
                {
                    Session["FileUpload1"] = FileUpload1;
                    file = FileUpload1.FileName;
                }
                // Next time submit and Session has values but FileUpload is Blank 
                // Return the values from session to FileUpload 
                else if (Session["FileUpload1"] != null && (!FileUpload1.HasFile))
                {
                    FileUpload1 = (FileUpload)Session["FileUpload1"];
                    file = FileUpload1.FileName;
                }
                // Now there could be another sictution when Session has File but user want to change the file 
                // In this case we have to change the file in session object 
                else if (FileUpload1.HasFile)
                {
                    Session["FileUpload1"] = FileUpload1;
                    file = FileUpload1.FileName;
                }
            }
            if (!Page.IsPostBack)
            {
                ViewState["SortOn"] = "EmpId";
                ViewState["SortBy"] = "Asc";
                BindData();
            }
        }

        protected void BindData()
        {
            DataSet ds = new DataSet();
            string blank = " ";
            string cmdstr = "select Email from SCreateAdmin where not Email=' '";
            SqlDataAdapter adp = new SqlDataAdapter(cmdstr, cn);
            adp.Fill(ds);



            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownCheckBoxes1.DataSource = ds.Tables[0];
                DropDownCheckBoxes1.DataTextField = "Email";
                DropDownCheckBoxes1.DataValueField = "Email";
                DropDownCheckBoxes1.DataBind();

                //ddchkCountry.DataSource = ds.Tables[0];
                //ddchkCountry.DataTextField = "Country";
                //ddchkCountry.DataValueField = "CountryID";
                //ddchkCountry.DataBind();
            }
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                //BindEmpData();
                MailMessage objMailMessage = new MailMessage();
                //objMailMessage.From = new MailAddress("eepwdeastpune@gmail.com");
                string Username = WebConfigurationManager.AppSettings["UserId"].ToString();
                string Password = WebConfigurationManager.AppSettings["Password"].ToString();
                string MailServer = WebConfigurationManager.AppSettings["MailServerName"].ToString();
                objMailMessage.From = new MailAddress(Username);
                //string password = psw.Text.Trim();
                string[] strToMails = usrnameTo.Text.Trim().Split(',');
                if (strToMails.Length > 0)
                {
                    foreach (string toMail in strToMails)
                    {
                        objMailMessage.To.Add(new MailAddress(toMail));
                    }
                }

                objMailMessage.Subject = txtSubject.Text.Trim();
                GridView EmailGrid = (GridView)Session["LekhasirshBuildingRpt"];
                GridView Report_LekhasirshCRF = (GridView)Session["Report_LekhasirshCRF"];
                GridView LekhasirshDPDCRpt = (GridView)Session["LekhasirshDPDCRpt"];
                GridView Report_LekhasirshMLA = (GridView)Session["Report_LekhasirshMLA"];
                GridView Report_LekhasirshMP = (GridView)Session["Report_LekhasirshMP"];
                GridView Report_LekhasirshNabard = (GridView)Session["Report_LekhasirshNabard"];
                GridView Report_LekhasirshRoad = (GridView)Session["Report_LekhasirshRoad"];
                GridView Report_MasterBuilding = (GridView)Session["Report_MasterBuilding"];
                GridView MasterBuildingRpt = (GridView)Session["MasterBuildingRpt"];
                GridView MasterDPDCRpt = (GridView)Session["MasterDPDCRpt"];
                GridView MasterMLARpt = (GridView)Session["MasterMLARpt"];
                GridView MasterMPRpt = (GridView)Session["MasterMPRpt"];
                GridView MasterNabardRpt = (GridView)Session["MasterNabardRpt"];
                GridView MasterRoadRpt = (GridView)Session["MasterRoadRpt"];
                GridView MasterCRFRpt = (GridView)Session["MasterCRFRpt"];
                GridView MasterGat_ARpt = (GridView)Session["MasterGat_ARpt"];
                GridView MasterGat_BRpt = (GridView)Session["MasterGat_BRpt"];
                GridView MasterGat_CRpt = (GridView)Session["MasterGat_CRpt"];
                GridView MasterGat_DRpt = (GridView)Session["MasterGat_DRpt"];
                GridView MasterGat_FRpt = (GridView)Session["MasterGat_FRpt"];
                GridView MasterANNUITYRpt = (GridView)Session["MasterANNUITYRpt"];
                GridView MasterDepositFundRpt = (GridView)Session["MasterDepositFundRpt"];
                GridView MasterNonResidentialBuildingRpt = (GridView)Session["MasterNonResidentialBuildingRpt"];
                GridView MasterResidentialBuildingRpt = (GridView)Session["MasterResidentialBuildingRpt"];
                GridView Report_MasterMP = (GridView)Session["Report_MasterMP"];
                GridView LekhasirshGAT_ARpt = (GridView)Session["LekhasirshGAT_ARpt"];
                GridView LekhasirshGAT_BRpt = (GridView)Session["LekhasirshGAT_BRpt"];
                GridView LekhasirshGAT_CRpt = (GridView)Session["LekhasirshGAT_CRpt"];
                GridView LekhasirshGAT_DRpt = (GridView)Session["LekhasirshGAT_DRpt"];
                GridView LekhasirshGAT_FRpt = (GridView)Session["LekhasirshGAT_FRpt"];
                GridView LekhasirshResBuildingRpt = (GridView)Session["LekhasirshResBuildingRpt"];
                GridView LekhasirshNonResBuildingRpt = (GridView)Session["LekhasirshNonResBuildingRpt"];
                GridView Lekhasirsh2515Rpt = (GridView)Session["Lekhasirsh2515Rpt"];
                GridView LekhasirshDepositeContributionFundRpt = (GridView)Session["LekhasirshDepositeContributionFundRpt"];
                GridView SReport_DPDC = (GridView)Session["SReport_DPDC"];
                GridView SReport_Road = (GridView)Session["SReport_Road"];
                GridView SReport_Nabard = (GridView)Session["SReport_Nabard"];
                GridView SReport_CRF = (GridView)Session["SReport_CRF"];
                GridView SReport_Building = (GridView)Session["SReport_Building"];
                GridView SReport_MLA = (GridView)Session["SReport_MLA"];
                GridView SReport_MP = (GridView)Session["SReport_MP"];
                GridView Report_MasterRoad = (GridView)Session["Report_MasterRoad"];

                GridView SReport_Aunty = (GridView)Session["SReport_Aunty"];
                GridView SReport_DepositeFund = (GridView)Session["SReport_DepositeFund"];
                GridView SReport_GATA = (GridView)Session["SReport_GATA"];
                GridView SReport_GATD = (GridView)Session["SReport_GATD"];
                GridView SReport_GATF = (GridView)Session["SReport_GATF"];
                GridView SReport_GATB = (GridView)Session["SReport_GATB"];
                GridView SReport_GATC = (GridView)Session["SReport_GATC"];
                GridView SReport_ResidentialBuilding = (GridView)Session["SReport_ResidentialBuilding"];
                GridView SReport_NonResidentialBuilding = (GridView)Session["SReport_NonResidentialBuilding"];
                GridView SReport_2515 = (GridView)Session["SReport_2515"];
                Panel SReportPanel = (Panel)Session["SReportPanel"];
                //objMailMessage.Body = "Report From DBS Software";


                if (EmailGrid != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(EmailGrid); Session["LekhasirshBuildingRpt"] = null; }
                if (Report_LekhasirshCRF != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(Report_LekhasirshCRF); Session["Report_LekhasirshCRF"] = null; }
                if (LekhasirshDPDCRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(LekhasirshDPDCRpt); Session["LekhasirshDPDCRpt"] = null; }
                if (Report_LekhasirshMLA != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(Report_LekhasirshMLA); Session["Report_LekhasirshMLA"] = null; }
                if (Report_LekhasirshMP != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(Report_LekhasirshMP); Session["Report_LekhasirshMP"] = null; }
                if (Report_LekhasirshNabard != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(Report_LekhasirshNabard); Session["Report_LekhasirshNabard"] = null; }
                if (Report_LekhasirshRoad != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(Report_LekhasirshRoad); Session["Report_LekhasirshRoad"] = null; }
                if (Report_MasterBuilding != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(Report_MasterBuilding); Session["Report_MasterBuilding"] = null; }
                if (MasterBuildingRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterBuildingRpt); Session["MasterBuildingRpt"] = null; }
                if (MasterDPDCRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterDPDCRpt); Session["MasterDPDCRpt"] = null; }
                if (MasterMLARpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterMLARpt); Session["MasterMLARpt"] = null; }
                if (MasterMPRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterMPRpt); Session["MasterMPRpt"] = null; }
                if (MasterNabardRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterNabardRpt); Session["MasterNabardRpt"] = null; }
                if (MasterRoadRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterRoadRpt); Session["MasterRoadRpt"] = null; }
                if (MasterCRFRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterCRFRpt); Session["MasterCRFRpt"] = null; }
                if (MasterGat_ARpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterGat_ARpt); Session["MasterGat_ARpt"] = null; }
                if (MasterGat_BRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterGat_BRpt); Session["MasterGat_BRpt"] = null; }
                if (MasterGat_CRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterGat_CRpt); Session["MasterGat_CRpt"] = null; }
                if (MasterGat_DRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterGat_DRpt); Session["MasterGat_DRpt"] = null; }
                if (MasterGat_FRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterGat_FRpt); Session["MasterGat_FRpt"] = null; }
                if (MasterANNUITYRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterANNUITYRpt); Session["MasterANNUITYRpt"] = null; }
                if (MasterDepositFundRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterDepositFundRpt); Session["MasterDepositFundRpt"] = null; }
                if (MasterNonResidentialBuildingRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterNonResidentialBuildingRpt); Session["MasterNonResidentialBuildingRpt"] = null; }
                if (MasterResidentialBuildingRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(MasterResidentialBuildingRpt); Session["MasterResidentialBuildingRpt"] = null; }
                if (Report_MasterMP != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(Report_MasterMP); Session["Report_MasterMP"] = null; }
                if (LekhasirshGAT_ARpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(LekhasirshGAT_ARpt); Session["LekhasirshGAT_ARpt"] = null; }
                if (LekhasirshGAT_BRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(LekhasirshGAT_BRpt); Session["LekhasirshGAT_BRpt"] = null; }
                if (LekhasirshGAT_CRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(LekhasirshGAT_CRpt); Session["LekhasirshGAT_CRpt"] = null; }
                if (LekhasirshGAT_DRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(LekhasirshGAT_DRpt); Session["LekhasirshGAT_DRpt"] = null; }
                if (LekhasirshGAT_FRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(LekhasirshGAT_FRpt); Session["LekhasirshGAT_FRpt"] = null; }
                if (LekhasirshResBuildingRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(LekhasirshResBuildingRpt); Session["LekhasirshResBuildingRpt"] = null; }
                if (LekhasirshNonResBuildingRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(LekhasirshNonResBuildingRpt); Session["LekhasirshNonResBuildingRpt"] = null; }
                if (Lekhasirsh2515Rpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(Lekhasirsh2515Rpt); Session["Lekhasirsh2515Rpt"] = null; }
                if (LekhasirshDepositeContributionFundRpt != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(LekhasirshDepositeContributionFundRpt); Session["LekhasirshDepositeContributionFundRpt"] = null; }
                if (SReport_DPDC != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_DPDC); Session["SReport_DPDC"] = null; }
                if (SReport_Road != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_Road); Session["SReport_Road"] = null; }
                if (SReport_Nabard != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_Nabard); Session["SReport_Nabard"] = null; }
                if (SReport_CRF != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_CRF); Session["SReport_CRF"] = null; }
                if (SReport_Building != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_Building); Session["SReport_Building"] = null; }
                if (SReport_MLA != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_MLA); Session["SReport_MLA"] = null; }
                if (SReport_MP != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_MP); Session["SReport_MP"] = null; }
                if (Report_MasterRoad != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(Report_MasterRoad); Session["Report_MasterRoad"] = null; }

                if (SReport_Aunty != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_Aunty); Session["SReport_Aunty"] = null; }
                if (SReport_DepositeFund != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_DepositeFund); Session["SReport_DepositeFund"] = null; }
                if (SReport_GATA != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_GATA); Session["SReport_GATA"] = null; }
                if (SReport_GATD != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_GATD); Session["SReport_GATD"] = null; }
                if (SReport_GATF != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_GATF); Session["SReport_GATF"] = null; }
                if (SReport_GATB != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_GATB); Session["SReport_GATB"] = null; }
                if (SReport_GATC != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_GATC); Session["SReport_GATC"] = null; }
                if (SReport_ResidentialBuilding != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_ResidentialBuilding); Session["SReport_ResidentialBuilding"] = null; }
                if (SReport_NonResidentialBuilding != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_NonResidentialBuilding); Session["SReport_NonResidentialBuilding"] = null; }
                if (SReport_2515 != null) { objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_2515); Session["SReport_2515"] = null; }
                if (SReportPanel != null)
                {

                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            SReportPanel.RenderControl(hw);
                            StringReader sr = new StringReader(sw.ToString());
                            objMailMessage.Body = txtMessage.Text.Trim() + sw.ToString();
                        }
                    }

                    //objMailMessage.Body = txtMessage.Text.Trim() + GridviewToHtml(SReport_2515); 
                    Session["SReportPanel"] = null;
                }
                objMailMessage.IsBodyHtml = true;
                string path = Server.MapPath("~/exportedfiles/");
                string attachment;

                if (File.Exists(path + Session["filename"].ToString()))
                {
                    attachment = path + Session["filename"].ToString();
                    objMailMessage.Attachments.Add(new Attachment(attachment));
                }

                if (FileUpload1.HasFile)
                {
                    objMailMessage.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
                }
                //string FilePath = Server.MapPath("/exportedfiles\\");
                //FileUpload1.FindControl(FilePath);

                //FileUpload1.FileName = FilePath + "MasterReport.xls";
                objMailMessage.Priority = MailPriority.High;
                System.Net.NetworkCredential objNetworkCredential = new System.Net.NetworkCredential(Username, Password);
                SmtpClient objSmtpClient = new SmtpClient();
                objSmtpClient.Host = "smtp.gmail.com";
                objSmtpClient.Port = 587;
                objSmtpClient.Credentials = objNetworkCredential;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.Send(objMailMessage);
                lblStatus.Text = "<b style='color:green'>Email has been sent successfully!!!</b>";
                //SaveEmailReport();


                if (File.Exists(path + Session["filename"].ToString()))
                {
                    attachment = path + Session["filename"].ToString();
                    objMailMessage.Attachments.Remove(new Attachment(attachment));
                }
                //if (File.Exists(path + Session["filename"].ToString()))
                //{

                //    objMailMessage.Dispose();

                //    //DeleteFiles(); // DELETE THE FILE AFTER MAIL SENT.           
                //}
                //Session["filename"] = null;
                Session["sentvalue"] = "SendToPageUnLoad";
            }
            catch (SmtpException ex)
            {
                lblStatus.Text = "<b style='color:Red'>" + ex.Message + "</b>";
            }
        }
        //private void DeleteFiles()
        //{
        //    string path = Server.MapPath("~/exportedfiles/");

        //    string filePath = Server.MapPath("~/exportedfiles/");
        //    Array.ForEach(Directory.GetFiles(filePath), System.IO.File.Delete);
        //}

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Session["sentvalue"] != null)
                {
                    if (Session["sentvalue"].ToString() == "SendToPageUnLoad")
                    {
                        string filePath = Server.MapPath("~/exportedfiles/");
                        string attachment2 = filePath + Session["filename"].ToString();
                        var list1 = Directory.GetFiles(filePath).ToList();
                        list1.Remove(attachment2);
                        var list2 = list1.ToList();
                        var list3 = Directory.GetFiles(filePath);
                        list3 = list2.ToArray();
                        Array.ForEach(list3, System.IO.File.Delete);
                    }
                }
            }
        }
        public void SaveEmailReport()
        {
            //strSqlCommand = "Insert into MailReport(Mail_From,Mail_To,Subject,Message,Date,Time) values('" + usrnameFrom.Text.Trim() + "','" + usrnameTo.Text.Trim() + "','" + txtSubject.Text.Trim() + "','" + txtMessage.Text.Trim() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "')";
            strSqlCommand = "Insert Into SentMailReport (Mail_From,Mail_To,Subject,Message,DateTime) Values('" + usrnameFrom.Text.Trim() + "', '" + usrnameTo.Text.Trim() + "', N'" + txtSubject.Text.Trim() + "', '" + txtMessage.Text.Trim() + "','" + DateTime.Now.ToString() + "')";
            if (cn.State != ConnectionState.Open)
                cn.Open();

            cmd = new SqlCommand(strSqlCommand, cn);
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                lblSaveStatus.Text = "<b style='color:green;'>EmailReport saved successfully!!!</b>";
            }
            else
            {
                lblSaveStatus.Text = "<b style='color:Red;'>EmailReport Not Saved!!!</b>";
            }
        }
        private string GridviewToHtml(GridView EmailGrid)
        {
            System.Text.StringBuilder objStringBuilder = new System.Text.StringBuilder();
            StringWriter objStringWriter = new StringWriter(objStringBuilder);
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            EmailGrid.RenderControl(objHtmlTextWriter);
            return objStringBuilder.ToString();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<String> CountryID_list = new List<string>();
            List<String> CountryName_list = new List<string>();

            foreach (System.Web.UI.WebControls.ListItem item in DropDownCheckBoxes1.Items)
            {
                if (item.Selected)
                {
                    CountryID_list.Add(item.Value);
                    CountryName_list.Add(item.Text);
                }

                //lblCountryID.Text = "Country ID: " + String.Join(",", CountryID_list.ToArray());
                //lblCountryName.Text = "Country Name: " + String.Join(",", CountryName_list.ToArray());
            }
        }

        protected void usrnameFrom_TextChanged(object sender, EventArgs e)
        {

        }


    }
}