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
using System.Globalization;

using PWdEEBudget.SMS_CRUD;
using System.Web.SessionState;
using System.Web.Configuration;
using DataLayer;
using System.Drawing;
namespace PWdEEBudget
{
    public partial class MasterBudgetCRF : System.Web.UI.Page, IHttpHandler, IRequiresSessionState
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        SqlConnection conMDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnMDBString"].ToString());
        static SqlQueryOrConnection ObjsqlQueryOrCon = new SqlQueryOrConnection();
        string FormPassword = WebConfigurationManager.AppSettings["FormPassword"].ToString();
        clsSMS_CRUD SMSobj = new clsSMS_CRUD();
        int i;

        string a;
        string filename;
        string yeartype = "";
        int yearset;
        string mobileNumber, message, strCommandType;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLekhaName.ForeColor = Color.Black;
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    lbl1.Text = Session["id"].ToString();
                    GetID();
                    BindAll_PERSON_NAME_ddl();
                    akunanudan();
                    BindAll_Lekha_Vibhag_VarishtType("CRF");
                    Jilha();
                    totalkharch();

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                if (Request.QueryString["WorkID"] != null && Request.QueryString["WorkID"] != "0")
                {
                    txtWorkID.Text = Request.QueryString["WorkID"].ToString();
                    txtWorkID.Focus();
                    txtWorkID.AutoPostBack = true;
                    workidsearch();
                }
                if (Request.QueryString["MWorkID"] != null && Request.QueryString["MWorkID"] != "0")
                {
                    txtWorkID.Text = Request.QueryString["MWorkID"].ToString();
                    txtWorkID.Focus();
                    txtWorkID.AutoPostBack = true;
                    workidsearch();
                }
            }
        }
        public void GetID()
        {

            try
            {
                int i = 1;
                string select = "select top 1 Akrmank from BudgetMasterCRF order by Akrmank desc";
                SqlDataAdapter sda = new SqlDataAdapter(select, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    i = Convert.ToInt32(dr[0].ToString());
                    i++;
                }
                lblId.Text = i.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //This method for  Get All Name List Of UpAbhiyant, Abhiyanta,Thekedar,Khasdar and Amdar
        public void BindAll_PERSON_NAME_ddl()
        {
            DataSet ds = new DataSet();
            //Create DropDownList ID Array
            DropDownList[] ddlIds = { ddlabhiyanta, ddlupabhiyanta, ddlThekedarName, ddlkhasdarachename, ddlaamdarachename };
            string[,] TextField = { { "Abhiyanta_Name", "Abhiyanta_MobileNo" }, { "UpAbhiyanta_Name", "UpAbhiyanta_MobileNo" }, { "Thekedar_Name", "Thekedar_MobileNo" }, { "Khasdar_Name", "Khasdar_Name" }, { "Amdar_Name", "Amdar_Name" } };
            ds = ObjsqlQueryOrCon.GetAllName_ByPost();
            int j = 0;
            //Get ID Of DropDownList Control from ddlIds[i] And Bind 
            for (int i = 0; i < ddlIds.Length; i++)
            {
                ddlIds[i].Items.Clear();
                ddlIds[i].DataSource = ds.Tables[TextField[i, j].Split('_')[0]];
                ddlIds[i].DataTextField = TextField[i, j];
                ddlIds[i].DataValueField = TextField[i, j + 1];
                ddlIds[i].DataBind();
                ddlIds[i].Items.Insert(0, new ListItem("कृपया नाव निवडा", "0000000000:निवडा"));
            }
            //ds = ViewState["Person_ds"] as DataSet;

        }
        protected void BindAll_Lekha_Vibhag_VarishtType(string type)
        {
            DataSet ds = new DataSet();
            //Call SP one time GetLekh_Vibhag_VarishtType("Building") Method and Get Lekhashirsh With Code And All UpVibhag, VarishtType List Collection
            ds = ObjsqlQueryOrCon.GetLekh_Vibhag_VarishtType(type);
            //Create DropDownList IDs Array
            DropDownList[] ddlIds = { ddlsubtype, ddlupvibhag, ddllekhashirsh };
            string[,] TextField = { { "VarishtType", "VarishtType" }, { "UpVibhag", "UpVibhag" }, { "code", "LekhaShirsh" } };
            int j = 0;
            //Get ID Of DropDownList Control And Bind 
            for (int i = 0; i < ddlIds.Length; i++)
            {
                ddlIds[i].Items.Clear();
                ddlIds[i].DataSource = ds.Tables[TextField[i, j + 1]];
                ddlIds[i].DataTextField = TextField[i, j];
                ddlIds[i].DataValueField = TextField[i, j + 1];
                ddlIds[i].DataBind();
                ddlIds[i].Items.Insert(0, new ListItem("निवडा", "निवडा"));
            }

        }


        protected void txtarthsankalpiyyear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = txtarthsankalpiyyear.Text;
                if (query.Length > 4)
                {
                    query = query.Substring(0, query.Length - 5);
                }

                if (txtarthsankalpiyyear.Text != "")
                {
                    yearset = Convert.ToInt32(query);
                    txtarthsankalpiyyear.Text = query + "-" + (yearset + 1);
                    yeartype = txtarthsankalpiyyear.Text;
                    lekhayeartartud.Text = yeartype;
                    lekhamarchanudan.Text = yeartype;
                    lekhayearanudan.Text = yeartype;
                    lekhamarchkharch.Text = yearset.ToString();
                    lekhayearmagil.Text = yeartype;
                    lekhayearchalu.Text = yeartype;
                    lableyearaikunkharch.Text = yeartype;
                    totalvitritanudan.Text = yeartype;
                    lblcumulative.Text = yearset.ToString();
                    lbltarget.Text = yeartype;
                    lblachievement.Text = yeartype;
                    auditdateset();
                    yearfetchdata();
                    fetchdate();
                    MonthCal();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void auditdateset()
        {
            AuditDate.Items.Clear();
            if (txtarthsankalpiyyear.Text != "")
            {
                AuditDate.Items.Add(txtarthsankalpiyyear.Text);
            }
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from CRFProvision where WorkID=N'" + txtWorkID.Text.Trim() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AuditDate.Items.Add(dr["Arthsankalpiyyear"].ToString());
                }
            }
            else
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select Arthsankalpiyyear from BudgetMasterCRF where WorkID=N'" + txtWorkID.Text.Trim() + "'", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                foreach (DataRow dr in dt.Rows)
                {
                    AuditDate.Items.Add(dr["Arthsankalpiyyear"].ToString());
                }

            }

        }
        protected void ddlThekedarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblThekedarMobNo.Text = ddlThekedarName.SelectedItem.Value.Split(':')[0];
        }

        protected void ddllekhashirsh_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLekhaName.Text = ddllekhashirsh.SelectedItem.Value;
            lblLekhaName.ForeColor = lblLekhaName.Text.Trim() == "लेखाशीर्ष निवडा" ? Color.Red : Color.Black;
        }

        public void Jilha()
        {
            ddldist.Items.Clear();
            ddldist.Items.Add("Pune");
            ddltaluka.Items.Clear();
            ddltaluka.Items.Add("");
            ddltaluka.Items.Add("Daund".ToString());
            ddltaluka.Items.Add("Baramati".ToString());
            ddltaluka.Items.Add("Indapur".ToString());
            ddltaluka.Items.Add("Shirur".ToString());
        }
        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void sendSms()
        {
            //Your authentication key
            string authKey = "87340AUVjSPCh55892127";
            //Multiple mobiles numbers separated by comma
            string msg;
            string mobileNumber = txtabhiyantamobile.Text + ",\n" + txtupabhiyantamobile.Text + ",\n" + lblThekedarMobNo.Text;
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = "PWDEPB";
            //Your message to send, Add URL encoding here.


            msg = "Welcome to PWD East Pune\n Scheme Name: Budget CRF \n Work Name:" + txtkamachenav.Text + "\n  Lekhashirsh:" + ddllekhashirsh.Text + " \n Website:http://www.eepwdeastpunebudget.com \n Help:info@eepwdeastpunebudget.com";
            //Prepare you post parameters

            string message = HttpUtility.UrlEncode(msg);
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "default");

            try
            {
                //Call Send SMS API
                string sendSMSUri = "http://smsgateway.elitesoftwares.co.in/sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();


            }
            catch (SystemException ex)
            {
                throw;
            }
        }

        protected void txtthekedardinak_TextChanged(object sender, EventArgs e)
        {

        }



        protected void ddlsubtype2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtkamachimudat_TextChanged(object sender, EventArgs e)
        {

            try
            {
                txtkamachimudat.Text = ConvertDigits(txtkamachimudat.Text);
                txtkaryarambhdinak.Text = ConvertDigits(txtkaryarambhdinak.Text);
                txtkampurndinak.Text = ConvertDigits(txtkampurndinak.Text);

                if (txtkaryarambhdinak.Text != "" && txtkamachimudat.Text != "")
                {
                    string d = txtkaryarambhdinak.Text;
                    // DateTime dt = DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dt = Convert.ToDateTime(d, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    DateTime before3days = dt.AddMonths(Convert.ToInt32(txtkamachimudat.Text));
                    txtkampurndinak.Text = before3days.ToString("dd/MM/yyyy");
                }
            }
            catch
            {
                Response.Write("<script>alert('Enter Correct Value.....!!!!!!')</script>");
            }
        }

        protected void txtkaryarambhdinak_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtkaryarambhdinak.Text = ConvertDigits(txtkaryarambhdinak.Text);
                txtkamachimudat.Text = ConvertDigits(txtkamachimudat.Text);
                txtkampurndinak.Text = ConvertDigits(txtkampurndinak.Text);

                if (txtkaryarambhdinak.Text != "" && txtkamachimudat.Text != "")
                {
                    string d = txtkaryarambhdinak.Text;
                    // DateTime dt = DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dt = Convert.ToDateTime(d, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    DateTime before3days = dt.AddMonths(Convert.ToInt32(txtkamachimudat.Text));
                    txtkampurndinak.Text = before3days.ToString("dd/MM/yyyy");
                }
            }
            catch
            {
                Response.Write("<script>alert('Enter Correct Value.....!!!!!!')</script>");
            }
        }

        protected void ddlabhiyanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtabhiyantamobile.Text = ddlabhiyanta.SelectedItem.Value.Split(':')[0];

        }

        protected void ddlupabhiyanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtupabhiyantamobile.Text = ddlupabhiyanta.SelectedItem.Value.Split(':')[0];

        }

        protected void ddlakun1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void akunanudan()
        {
            try
            {
                ddlakun1.Items.Clear();
                ddlakun2.Items.Clear();
                ddlakun3.Items.Clear();
                ddlakun4.Items.Clear();
                ddlmagilmonth.Items.Clear();
                ddlchalukharch.Items.Clear();
                Billpayment.Items.Clear();
                ddlakun1.Items.Add(" ");
                ddlakun2.Items.Add(" ");
                ddlakun3.Items.Add(" ");
                ddlakun4.Items.Add(" ");
                ddlmagilmonth.Items.Add(" ");
                ddlchalukharch.Items.Add(" ");
                Billpayment.Items.Add(" ");
                SqlDataAdapter sda = new SqlDataAdapter("select Month from Month", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    ddlakun1.Items.Add(dr["Month"].ToString());
                    ddlakun2.Items.Add(dr["Month"].ToString());
                    ddlakun3.Items.Add(dr["Month"].ToString());
                    ddlakun4.Items.Add(dr["Month"].ToString());
                    ddlmagilmonth.Items.Add(dr["Month"].ToString());
                    ddlchalukharch.Items.Add(dr["Month"].ToString());
                    Billpayment.Items.Add(dr["Month"].ToString());
                }
                SqlDataAdapter sda1 = new SqlDataAdapter("select Name from BillStatus", con);
                DataTable dtt = new DataTable();
                sda1.Fill(dtt);
                ddlbillone.Items.Clear();
                ddlbilltwo.Items.Clear();
                ddlbillthree.Items.Clear();
                foreach (DataRow drr in dtt.Rows)
                {
                    ddlbillone.Items.Add(drr["Name"].ToString());
                    ddlbilltwo.Items.Add(drr["Name"].ToString());
                    ddlbillthree.Items.Add(drr["Name"].ToString());
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void workidsearch()
        {
            try
            {
                txtWorkID.Text = txtWorkID.Text.Split(':')[0];
                DataTable dt = new DataTable();
                //In this Method Passing 2 parameter one is StoredProcedure Name, and second is WorkId 
                //                    Feach_Master_Data("StoredProcedure Name" , "WorkId")
                dt = ObjsqlQueryOrCon.Feach_Master_Data("CRF", txtWorkID.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    txtarthsankalpiyyear.Text = "";
                    auditdateset();
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtarthsankalpiyyear.Text = dr["Arthsankalpiyyear"].ToString();
                        lblId.Text = dr["Akrmank"].ToString();
                        ddldist.SelectedItem.Text = dr["Dist"].ToString();
                        ddltaluka.SelectedItem.Text = dr["Taluka"].ToString();
                        txtarthsankalpiybab.Text = dr["ArthsankalpiyBab"].ToString();
                        ddlupvibhag.SelectedIndex = ddlupvibhag.Items.IndexOf(ddlupvibhag.Items.FindByText(dr["Upvibhag"].ToString()));
                        ddllekhashirsh.SelectedIndex = ddllekhashirsh.Items.IndexOf(ddllekhashirsh.Items.FindByText(dr["LekhaShirsh"].ToString()));
                        lblLekhaName.Text = dr["LekhaShirshName"].ToString();
                        ddlsubtype.SelectedIndex = ddlsubtype.Items.IndexOf(ddlsubtype.Items.FindByText(dr["SubType"].ToString()));
                        ddlabhiyanta.SelectedIndex = ddlabhiyanta.Items.IndexOf(ddlabhiyanta.Items.FindByText(dr["ShakhaAbhyantaName"].ToString()));
                        txtabhiyantamobile.Text = dr["ShakhaAbhiyantMobile"].ToString();
                        ddlupabhiyanta.SelectedIndex = ddlupabhiyanta.Items.IndexOf(ddlupabhiyanta.Items.FindByText(dr["UpabhyantaName"].ToString()));
                        txtupabhiyantamobile.Text = dr["UpAbhiyantaMobile"].ToString();
                        ddlkhasdarachename.SelectedIndex = ddlkhasdarachename.Items.IndexOf(ddlkhasdarachename.Items.FindByText(dr["KhasdaracheName"].ToString()));
                        ddlaamdarachename.SelectedIndex = ddlaamdarachename.Items.IndexOf(ddlaamdarachename.Items.FindByText(dr["AmdaracheName"].ToString()));
                        txtkamachenav.Text = dr["KamacheName"].ToString();
                        txtkamachavav.Text = dr["Kamachavav"].ToString();
                        txtprashaskiykramank.Text = dr["PrashaskiyKramank"].ToString();
                        txtprashaskiydinak.Text = dr["PrashaskiyDate"].ToString();
                        txtprashaskiykimat.Text = dr["PrashaskiyAmt"].ToString();
                        txttantrikkramank.Text = dr["TrantrikKrmank"].ToString();
                        txttantarikdinak.Text = dr["TrantrikDate"].ToString();
                        txttantarikkimat.Text = dr["TrantrikAmt"].ToString();
                        ddlThekedarName.SelectedIndex = ddlThekedarName.Items.IndexOf(ddlThekedarName.Items.FindByText(dr["ThekedaarName"].ToString()));
                        lblThekedarMobNo.Text = dr["ThekedarMobile"].ToString();
                        txtNividaKramank.Text = dr["NividaKrmank"].ToString();
                        txtNividaKimat.Text = dr["NividaAmt"].ToString();
                        txtkaryarambhaadesh.Text = dr["karyarambhadesh"].ToString();
                        txtkaryarambhdinak.Text = dr["NividaDate"].ToString();
                        txtkamachimudat.Text = dr["kamachiMudat"].ToString();
                        txtkampurndinak.Text = dr["KamPurnDate"].ToString();
                        txtjobno.Text = dr["JobNo"].ToString();
                        txtRoadNo.Text = dr["RoadNo"].ToString();
                        txtRoadLength.Text = dr["RoadLength"].ToString();
                        txtsanctiondate.Text = dr["SanctionDate"].ToString();
                        txtsanctionAmt.Text = dr["SanctionAmount"].ToString();
                        txtAPhysical.Text = dr["APhysicalScope"].ToString();
                        txtACumulative.Text = dr["ACommulative"].ToString();
                        txtATarget.Text = dr["ATarget"].ToString();
                        txtAAchievement.Text = dr["AAchievement"].ToString();
                        txtBPhysical.Text = dr["BPhysicalScope"].ToString();
                        txtBCumulative.Text = dr["BCommulative"].ToString();
                        txtBTarget.Text = dr["BTarget"].ToString();
                        txtBAchievement.Text = dr["BAchievement"].ToString();
                        txtCPhysical.Text = dr["CPhysicalScope"].ToString();
                        txtCCumulative.Text = dr["CCommulative"].ToString();
                        txtCTarget.Text = dr["CTarget"].ToString();
                        txtCAchievement.Text = dr["CAchievement"].ToString();
                        txtDPhysical.Text = dr["DPhysicalScope"].ToString();
                        txtDCumulative.Text = dr["DCommulative"].ToString();
                        txtDTarget.Text = dr["DTarget"].ToString();
                        txtDAchievement.Text = dr["DAchievement"].ToString();
                        txtEMajor.Text = dr["EPhysicalScope"].ToString();
                        txtECumulative.Text = dr["ECommulative"].ToString();
                        txtETarget.Text = dr["ETarget"].ToString();
                        txtEAchievement.Text = dr["EAchievement"].ToString();
                        ddlsadyasthiti.SelectedIndex = ddlsadyasthiti.Items.IndexOf(ddlsadyasthiti.Items.FindByText(dr["Sadyasthiti"].ToString()));
                        txtpahnikramank.Text = dr["Pahanikramank"].ToString();
                        txtpahnimudye.Text = dr["PahaniMudye"].ToString();
                        txtshera.Text = dr["Shera"].ToString();
                    }
                }
                else
                {
                    AuditDate.Items.Clear();
                    txtarthsankalpiyyear.Text = "";
                    lblId.Text = "";
                    ddltaluka.SelectedIndex = 0;
                    txtarthsankalpiybab.Text = "";
                    ddlupvibhag.SelectedIndex = 0;
                    ddllekhashirsh.SelectedIndex = 0;
                    lblLekhaName.Text = "";
                    ddlsubtype.SelectedIndex = 0;
                    ddlabhiyanta.SelectedIndex = 0;
                    txtabhiyantamobile.Text = "";
                    ddlupabhiyanta.SelectedIndex = 0;
                    txtupabhiyantamobile.Text = "";
                    ddlkhasdarachename.SelectedIndex = 0;
                    ddlaamdarachename.SelectedIndex = 0;
                    txtkamachenav.Text = "";
                    txtkamachavav.Text = "";
                    txtprashaskiykramank.Text = "";
                    txtprashaskiydinak.Text = "";
                    txtprashaskiykimat.Text = 0.ToString();
                    txttantrikkramank.Text = "";
                    txttantarikdinak.Text = "";
                    txttantarikkimat.Text = 0.ToString();
                    ddlThekedarName.SelectedIndex = 0;
                    lblThekedarMobNo.Text = "";
                    txtNividaKramank.Text = "";
                    txtNividaKimat.Text = 0.ToString();
                    txtkaryarambhaadesh.Text = "";
                    txtkaryarambhdinak.Text = "";
                    txtkamachimudat.Text = "";
                    txtkampurndinak.Text = "";
                    txtjobno.Text = "";
                    txtRoadNo.Text = "";
                    txtRoadLength.Text = "";
                    txtsanctiondate.Text = "";
                    txtsanctionAmt.Text = 0.ToString();
                    txtAPhysical.Text = 0.ToString();
                    txtACumulative.Text = 0.ToString();
                    txtATarget.Text = 0.ToString();
                    txtAAchievement.Text = 0.ToString();
                    txtBPhysical.Text = 0.ToString();
                    txtBCumulative.Text = 0.ToString();
                    txtBTarget.Text = 0.ToString();
                    txtBAchievement.Text = 0.ToString();
                    txtCPhysical.Text = 0.ToString();
                    txtCCumulative.Text = 0.ToString();
                    txtCTarget.Text = 0.ToString();
                    txtCAchievement.Text = 0.ToString();
                    txtDPhysical.Text = 0.ToString();
                    txtDCumulative.Text = 0.ToString();
                    txtDTarget.Text = 0.ToString();
                    txtDAchievement.Text = 0.ToString();
                    txtEMajor.Text = 0.ToString();
                    txtECumulative.Text = 0.ToString();
                    txtETarget.Text = 0.ToString();
                    txtEAchievement.Text = 0.ToString();
                    ddlsadyasthiti.SelectedIndex = 0;
                    txtpahnikramank.Text = "";
                    txtpahnimudye.Text = "";
                    txtshera.Text = "";
                }
                yearfetchdata();
                fetchdate();
                MonthCal();
                Akherkharchdatafetch();
                totalkharch();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            return ObjsqlQueryOrCon.GetCompletionListOfWorkID(prefixText, "CRF");

        }
        protected void txtWorkID_TextChanged(object sender, EventArgs e)
        {
            txtWorkID.Text = txtWorkID.Text.Split(':')[0];
            workidsearch();
        }

        public void totalkharch()
        {
            txtchalukharch.Text = ConvertDigits(txtchalukharch.Text);
            txtmagilkharch.Text = ConvertDigits(txtmagilkharch.Text);
            txtvarshbharatilkharch.Text = ConvertDigits(txtvarshbharatilkharch.Text);
            txtmarchakherkharch.Text = ConvertDigits(txtmarchakherkharch.Text);
            txtOtherExp.Text = ConvertDigits(txtOtherExp.Text);
            txtElectExpen.Text = ConvertDigits(txtElectExpen.Text);


            if (txtchalukharch.Text != "" && txtmagilkharch.Text != "")
            {
                txtvarshbharatilkharch.Text = (Convert.ToDecimal(txtchalukharch.Text) + Convert.ToDecimal(txtmagilkharch.Text)).ToString();
            }
            if (txtmarchakherkharch.Text != "" && txtOtherExp.Text != "" && txtElectExpen.Text != "" && txtvarshbharatilkharch.Text != "")
            {
                txtaikunkharch.Text = (Convert.ToDecimal(txtmarchakherkharch.Text) + Convert.ToDecimal(txtvarshbharatilkharch.Text) + Convert.ToDecimal(txtOtherExp.Text) + Convert.ToDecimal(txtElectExpen.Text)).ToString();
            }
        }
        public void totalanudan()
        {
            txtjan.Text = ConvertDigits(txtjan.Text);
            txtfeb.Text = ConvertDigits(txtfeb.Text);
            txtmar.Text = ConvertDigits(txtmar.Text);
            txtapr.Text = ConvertDigits(txtapr.Text);
            txtmay.Text = ConvertDigits(txtmay.Text);
            txtjun.Text = ConvertDigits(txtjun.Text);
            txtjul.Text = ConvertDigits(txtjul.Text);
            txtaug.Text = ConvertDigits(txtaug.Text);
            txtsep.Text = ConvertDigits(txtsep.Text);
            txtoct.Text = ConvertDigits(txtoct.Text);
            txtnov.Text = ConvertDigits(txtjan.Text);
            txtdec.Text = ConvertDigits(txtdec.Text);

            if (txtjan.Text != "" && txtfeb.Text != "" && txtmar.Text != "" && txtapr.Text != "" && txtmay.Text != "" && txtjun.Text != "" && txtjul.Text != "" && txtaug.Text != "" && txtsep.Text != "" && txtoct.Text != "" && txtnov.Text != "" && txtdec.Text != "")
            {
                txtaikunanudan.Text = (Convert.ToDecimal(txtjan.Text) + Convert.ToDecimal(txtfeb.Text) + Convert.ToDecimal(txtmar.Text) + Convert.ToDecimal(txtapr.Text) + Convert.ToDecimal(txtmay.Text) + Convert.ToDecimal(txtjun.Text) + Convert.ToDecimal(txtjul.Text) + Convert.ToDecimal(txtaug.Text) + Convert.ToDecimal(txtsep.Text) + Convert.ToDecimal(txtoct.Text) + Convert.ToDecimal(txtnov.Text) + Convert.ToDecimal(txtdec.Text)).ToString();
            }
        }

        protected void AuditDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtarthsankalpiyyear.Text != "")
            {
                yeartype = AuditDate.SelectedItem.Text;
                lekhayeartartud.Text = yeartype;
                lekhamarchanudan.Text = yeartype;
                lekhayearanudan.Text = yeartype;
                lekhamarchkharch.Text = AuditDate.Text.Substring(0, AuditDate.Text.Length - 5);
                lekhayearmagil.Text = yeartype;
                lekhayearchalu.Text = yeartype;
                lableyearaikunkharch.Text = yeartype;
                totalvitritanudan.Text = yeartype;
            }
            yearfetchdata();
            fetchdate();
            Akherkharchdatafetch();
            totalkharch();
        }

        public void Akherkharchdatafetch()
        {
            int k = 0;
            SqlDataAdapter sda = new SqlDataAdapter("select *from(select ROW_NUMBER() over(order by Arthsankalpiyyear) AS Number,Arthsankalpiyyear from CRFProvision where WorkID='" + txtWorkID.Text + "')as p where p.Arthsankalpiyyear='" + AuditDate.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                k = Convert.ToInt32(dr["Number"].ToString());
            }
            if (k == 0 || k == 1)
            {
                SqlDataAdapter sdak = new SqlDataAdapter("select MarchEndingExpn from CRFProvision where WorkID='" + txtWorkID.Text + "' and Arthsankalpiyyear='" + AuditDate.Text + "'", con);
                DataTable dtk = new DataTable();
                sdak.Fill(dtk);
                foreach (DataRow drk in dtk.Rows)
                {
                    txtmarchakherkharch.Text = drk["MarchEndingExpn"].ToString();
                }
            }
            else
            {
                k--;
                SqlDataAdapter sda1 = new SqlDataAdapter("select * from(select ROW_NUMBER() over(order by Arthsankalpiyyear) AS Number,Arthsankalpiyyear,AikunKharch from CRFProvision where WorkID='" + txtWorkID.Text + "')as p where p.Number='" + k + "'", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    txtmarchakherkharch.Text = dr1["AikunKharch"].ToString();
                }
                k++;
            }
        }
        public void yearfetchdata()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from CRFProvision where Arthsankalpiyyear=N'" + AuditDate.Text.Trim() + "' and Workid=N'" + txtWorkID.Text.Trim() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TextBox[] txtIds = { txtmudatvadhdinak, txtcost, txtmarchakherkharch, txtakun1, txtakun2, txtakun3, txtakun4, txtjan, txtfeb, txtmar, txtapr, txtmay, txtjun, txtjul, txtaug, txtsep, txtoct, txtnov, txtdec, txtchalukharch, txtmagilkharch, txtmagni, txtOtherExp, txtElectExpen, txtElectCost, txtpahnikramank, txtpahnimudye, txtshera, txtkamachenav, txtkamachavav, txtprashaskiykramank, txtprashaskiydinak, txtprashaskiykimat, txttantrikkramank, txttantarikdinak, txttantarikkimat, txtNividaKramank, txtNividaKimat, txtkaryarambhaadesh, txtkaryarambhdinak, txtkamachimudat, txtkampurndinak, txtjobno, txtsanctiondate, txtsanctionAmt, txtRoadNo, txtRoadLength, txtAPhysical, txtACumulative, txtATarget, txtAAchievement, txtBPhysical, txtBCumulative, txtBTarget, txtBAchievement, txtCPhysical, txtCCumulative, txtCTarget, txtCAchievement, txtDPhysical, txtDCumulative, txtDTarget, txtDAchievement, txtEMajor, txtECumulative, txtETarget, txtEAchievement, };
            DropDownList[] ddlIds = { ddlakun1, ddlakun2, ddlakun3, ddlakun4, ddlchalukharch, ddlmagilmonth, ddlsadyasthiti, ddlThekedarName };
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString() == 0.ToString())
                {
                    for (int i = 0; i < txtIds.Length; i++)
                    {
                        txtIds[i].Enabled = true;
                    }

                    for (int i = 0; i < ddlIds.Length; i++)
                    {
                        ddlIds[i].Enabled = true;
                    }
                    txtmudatvadhdinak.Enabled = true;
                    //  Billpayment.Enabled = true;
                    txtcost.Enabled = true;
                    txtmarchakherkharch.Enabled = true;
                    ddlakun1.Enabled = true;
                    txtakun1.Enabled = true;
                    ddlakun2.Enabled = true;
                    txtakun2.Enabled = true;
                    ddlakun3.Enabled = true;
                    txtakun3.Enabled = true;
                    ddlakun4.Enabled = true;
                    txtakun4.Enabled = true;
                    txtjan.Enabled = true;
                    txtfeb.Enabled = true;
                    txtmar.Enabled = true;
                    txtapr.Enabled = true;
                    txtmay.Enabled = true;
                    txtjun.Enabled = true;
                    txtjul.Enabled = true;
                    txtaug.Enabled = true;
                    txtsep.Enabled = true;
                    txtoct.Enabled = true;
                    txtnov.Enabled = true;
                    txtdec.Enabled = true;
                    ddlchalukharch.Enabled = true;
                    txtchalukharch.Enabled = true;
                    ddlmagilmonth.Enabled = true;
                    txtmagilkharch.Enabled = true;
                    txtmagni.Enabled = true;
                    txtOtherExp.Enabled = true;
                    txtElectExpen.Enabled = true;
                    txtElectCost.Enabled = true;
                    ddlsadyasthiti.Enabled = true;
                    txtpahnikramank.Enabled = true;
                    txtpahnimudye.Enabled = true;
                    txtshera.Enabled = true;
                    //Department Engineer
                    txtkamachenav.Enabled = true;
                    txtkamachavav.Enabled = true;
                    txtprashaskiykramank.Enabled = true;
                    txtprashaskiydinak.Enabled = true;
                    txtprashaskiykimat.Enabled = true;
                    txttantrikkramank.Enabled = true;
                    txttantarikdinak.Enabled = true;
                    txttantarikkimat.Enabled = true;

                    //Tender Information
                    ddlThekedarName.Enabled = true;
                    txtNividaKramank.Enabled = true;
                    txtNividaKimat.Enabled = true;
                    txtkaryarambhaadesh.Enabled = true;
                    txtkaryarambhdinak.Enabled = true;
                    txtkamachimudat.Enabled = true;
                    txtkampurndinak.Enabled = true;

                    //Physical Target
                    txtjobno.Enabled = true;
                    txtsanctiondate.Enabled = true;
                    txtsanctionAmt.Enabled = true;
                    txtRoadNo.Enabled = true;
                    txtRoadLength.Enabled = true;
                    txtAPhysical.Enabled = true;
                    txtACumulative.Enabled = true;
                    txtATarget.Enabled = true;
                    txtAAchievement.Enabled = true;
                    txtBPhysical.Enabled = true;
                    txtBCumulative.Enabled = true;
                    txtBTarget.Enabled = true;
                    txtBAchievement.Enabled = true;
                    txtCPhysical.Enabled = true;
                    txtCCumulative.Enabled = true;
                    txtCTarget.Enabled = true;
                    txtCAchievement.Enabled = true;
                    txtDPhysical.Enabled = true;
                    txtDCumulative.Enabled = true;
                    txtDTarget.Enabled = true;
                    txtDAchievement.Enabled = true;
                    txtEMajor.Enabled = true;
                    txtECumulative.Enabled = true;
                    txtETarget.Enabled = true;
                    txtEAchievement.Enabled = true;
                }
                else
                {
                    txtmudatvadhdinak.Enabled = false;
                    //   Billpayment.Enabled = false;
                    txtcost.Enabled = false;
                    txtmarchakherkharch.Enabled = false;
                    ddlakun1.Enabled = false;
                    txtakun1.Enabled = false;
                    ddlakun2.Enabled = false;
                    txtakun2.Enabled = false;
                    ddlakun3.Enabled = false;
                    txtakun3.Enabled = false;
                    ddlakun4.Enabled = false;
                    txtakun4.Enabled = false;
                    txtjan.Enabled = false;
                    txtfeb.Enabled = false;
                    txtmar.Enabled = false;
                    txtapr.Enabled = false;
                    txtmay.Enabled = false;
                    txtjun.Enabled = false;
                    txtjul.Enabled = false;
                    txtaug.Enabled = false;
                    txtsep.Enabled = false;
                    txtoct.Enabled = false;
                    txtnov.Enabled = false;
                    txtdec.Enabled = false;
                    ddlchalukharch.Enabled = false;
                    txtchalukharch.Enabled = false;
                    ddlmagilmonth.Enabled = false;
                    txtmagilkharch.Enabled = false;
                    txtmagni.Enabled = false;
                    txtOtherExp.Enabled = false;
                    txtElectExpen.Enabled = false;
                    txtElectCost.Enabled = false;

                    ddlsadyasthiti.Enabled = false;
                    txtpahnikramank.Enabled = false;
                    txtpahnimudye.Enabled = false;
                    txtshera.Enabled = false;
                    //Department Engineer
                    txtkamachenav.Enabled = false;
                    txtkamachavav.Enabled = false;
                    txtprashaskiykramank.Enabled = false;
                    txtprashaskiydinak.Enabled = false;
                    txtprashaskiykimat.Enabled = false;
                    txttantrikkramank.Enabled = false;
                    txttantarikdinak.Enabled = false;
                    txttantarikkimat.Enabled = false;

                    //Tender Information
                    ddlThekedarName.Enabled = false;
                    txtNividaKramank.Enabled = false;
                    txtNividaKimat.Enabled = false;
                    txtkaryarambhaadesh.Enabled = false;
                    txtkaryarambhdinak.Enabled = false;
                    txtkamachimudat.Enabled = false;
                    txtkampurndinak.Enabled = false;

                    //Physical Target
                    txtjobno.Enabled = false;
                    txtsanctiondate.Enabled = false;
                    txtsanctionAmt.Enabled = false;
                    txtRoadNo.Enabled = false;
                    txtRoadLength.Enabled = false;
                    txtAPhysical.Enabled = false;
                    txtACumulative.Enabled = false;
                    txtATarget.Enabled = false;
                    txtAAchievement.Enabled = false;
                    txtBPhysical.Enabled = false;
                    txtBCumulative.Enabled = false;
                    txtBTarget.Enabled = false;
                    txtBAchievement.Enabled = false;
                    txtCPhysical.Enabled = false;
                    txtCCumulative.Enabled = false;
                    txtCTarget.Enabled = false;
                    txtCAchievement.Enabled = false;
                    txtDPhysical.Enabled = false;
                    txtDCumulative.Enabled = false;
                    txtDTarget.Enabled = false;
                    txtDAchievement.Enabled = false;
                    txtEMajor.Enabled = false;
                    txtECumulative.Enabled = false;
                    txtETarget.Enabled = false;
                    txtEAchievement.Enabled = false;
                }
            }
        }
        public void fetchdate()
        {
            DataTable dt = new DataTable();
            dt = ObjsqlQueryOrCon.FeachProvisionData("CRF", AuditDate.Text.Trim(), txtWorkID.Text.Trim());

            if (dt.Rows.Count != 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    txtmudatvadhdinak.Text = dr["MudatVadhiDate"].ToString();
                    //   Billpayment.Text = dr["DeyakachiSadyasthiti"].ToString();
                    txtcost.Text = dr["ManjurAmt"].ToString();
                    txtmarchakherkharch.Text = dr["MarchEndingExpn"].ToString();
                    txturvaritamt.Text = dr["UrvaritAmt"].ToString();
                    ddlakun1.SelectedItem.Text = dr["DTakunone"].ToString();
                    txtakun1.Text = dr["Takunone"].ToString();
                    ddlakun2.SelectedItem.Text = dr["DTakuntwo"].ToString();
                    txtakun2.Text = dr["Takuntwo"].ToString();
                    ddlakun3.SelectedItem.Text = dr["DTakunthree"].ToString();
                    txtakun3.Text = dr["Takunthree"].ToString();
                    ddlakun4.SelectedItem.Text = dr["DTakunfour"].ToString();
                    txtakun4.Text = dr["Takunfour"].ToString();
                    txttartud.Text = dr["Tartud"].ToString();
                    txtjan.Text = dr["Jan"].ToString();
                    txtfeb.Text = dr["Feb"].ToString();
                    txtmar.Text = dr["Mar"].ToString();
                    txtapr.Text = dr["Apr"].ToString();
                    txtmay.Text = dr["May"].ToString();
                    txtjun.Text = dr["Jun"].ToString();
                    txtjul.Text = dr["Jul"].ToString();
                    txtaug.Text = dr["Aug"].ToString();
                    txtsep.Text = dr["Sep"].ToString();
                    txtoct.Text = dr["Oct"].ToString();
                    txtnov.Text = dr["Nov"].ToString();
                    txtdec.Text = dr["Dec"].ToString();
                    txtaikunanudan.Text = dr["AkunAnudan"].ToString();
                    ddlchalukharch.SelectedItem.Text = dr["Chalumonth"].ToString();
                    txtchalukharch.Text = dr["Chalukharch"].ToString();
                    ddlmagilmonth.SelectedItem.Text = dr["Magilmonth"].ToString();
                    txtmagilkharch.Text = dr["Magilkharch"].ToString();
                    txtmagni.Text = dr["Magni"].ToString();
                    txtvarshbharatilkharch.Text = dr["VarshbharatilKharch"].ToString();
                    txtaikunkharch.Text = dr["AikunKharch"].ToString();
                    txtOtherExp.Text = dr["OtherExpen"].ToString();
                    txtElectExpen.Text = dr["ExpenExpen"].ToString();
                    txtElectCost.Text = dr["ExpenCost"].ToString();
                }
            }
            if (dt.Rows.Count == 0)
            {
                txtmudatvadhdinak.Text = 0.ToString();
                //  Billpayment.Text = 0.ToString();
                txtcost.Text = 0.ToString();
                txtmarchakherkharch.Text = 0.ToString();
                txturvaritamt.Text = 0.ToString();
                ddlakun1.SelectedIndex = 0;
                txtakun1.Text = 0.ToString();
                ddlakun2.SelectedIndex = 0;
                txtakun2.Text = 0.ToString();
                ddlakun3.SelectedIndex = 0;
                txtakun3.Text = 0.ToString();
                ddlakun4.SelectedIndex = 0;
                txtakun4.Text = 0.ToString();
                txttartud.Text = 0.ToString();
                txtjan.Text = 0.ToString();
                txtfeb.Text = 0.ToString();
                txtmar.Text = 0.ToString();
                txtapr.Text = 0.ToString();
                txtmay.Text = 0.ToString();
                txtjun.Text = 0.ToString();
                txtjul.Text = 0.ToString();
                txtaug.Text = 0.ToString();
                txtsep.Text = 0.ToString();
                txtoct.Text = 0.ToString();
                txtnov.Text = 0.ToString();
                txtdec.Text = 0.ToString();
                txtaikunanudan.Text = 0.ToString();
                ddlchalukharch.SelectedIndex = 0;
                txtchalukharch.Text = 0.ToString();
                ddlmagilmonth.SelectedIndex = 0;
                txtmagilkharch.Text = 0.ToString();
                txtmagni.Text = 0.ToString();
                txtvarshbharatilkharch.Text = 0.ToString();
                txtaikunkharch.Text = 0.ToString();
                txtOtherExp.Text = 0.ToString();
                txtElectExpen.Text = 0.ToString();
                txtElectCost.Text = 0.ToString();
            }
        }
        public void MonthCal()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select [FirstValue],[SecondValue],[ThirdValue],[BillOne],[BillTwo],[BillThree] from StatusBillPayment where Arthsankalpiyyear=N'" + AuditDate.Text.Trim() + "' and Workid=N'" + txtWorkID.Text.Trim() + "' and MonthSelect=N'" + Billpayment.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtfirst.Text = dr["FirstValue"].ToString();
                    txtsecond.Text = dr["SecondValue"].ToString();
                    txtthird.Text = dr["ThirdValue"].ToString();
                    ddlbillone.SelectedItem.Text = dr["BillOne"].ToString();
                    ddlbilltwo.SelectedItem.Text = dr["BillTwo"].ToString();
                    ddlbillthree.SelectedItem.Text = dr["BillThree"].ToString();
                }
            }
            if (dt.Rows.Count == 0)
            {
                txtfirst.Text = 0.ToString();
                txtsecond.Text = 0.ToString();
                txtthird.Text = 0.ToString();
                ddlbillone.SelectedIndex = 0;
                ddlbilltwo.SelectedIndex = 0;
                ddlbillthree.SelectedIndex = 0;
            }

        }
        protected void txtsecurity_TextChanged(object sender, EventArgs e)
        {
            if (AuditDate.SelectedIndex != -1)
            {
                if (txtsecurity.Text == FormPassword.ToString())
                {
                    txtmudatvadhdinak.Enabled = true;
                    //Billpayment.Enabled = true;
                    txtcost.Enabled = true;
                    txtmarchakherkharch.Enabled = true;
                    ddlakun1.Enabled = true;
                    txtakun1.Enabled = true;
                    ddlakun2.Enabled = true;
                    txtakun2.Enabled = true;
                    ddlakun3.Enabled = true;
                    txtakun3.Enabled = true;
                    ddlakun4.Enabled = true;
                    txtakun4.Enabled = true;
                    txtjan.Enabled = true;
                    txtfeb.Enabled = true;
                    txtmar.Enabled = true;
                    txtapr.Enabled = true;
                    txtmay.Enabled = true;
                    txtjun.Enabled = true;
                    txtjul.Enabled = true;
                    txtaug.Enabled = true;
                    txtsep.Enabled = true;
                    txtoct.Enabled = true;
                    txtnov.Enabled = true;
                    txtdec.Enabled = true;
                    ddlchalukharch.Enabled = true;
                    txtchalukharch.Enabled = true;
                    ddlmagilmonth.Enabled = true;
                    txtmagilkharch.Enabled = true;
                    txtmagni.Enabled = true;
                    txtOtherExp.Enabled = true;
                    txtElectExpen.Enabled = true;
                    txtElectCost.Enabled = true;
                    ddlsadyasthiti.Enabled = true;
                    txtpahnikramank.Enabled = true;
                    txtpahnimudye.Enabled = true;
                    txtshera.Enabled = true;
                }
                else
                {
                    txtmudatvadhdinak.Enabled = false;
                    // Billpayment.Enabled = false;
                    txtcost.Enabled = false;
                    txtmarchakherkharch.Enabled = false;
                    ddlakun1.Enabled = false;
                    txtakun1.Enabled = false;
                    ddlakun2.Enabled = false;
                    txtakun2.Enabled = false;
                    ddlakun3.Enabled = false;
                    txtakun3.Enabled = false;
                    ddlakun4.Enabled = false;
                    txtakun4.Enabled = false;
                    txtjan.Enabled = false;
                    txtfeb.Enabled = false;
                    txtmar.Enabled = false;
                    txtapr.Enabled = false;
                    txtmay.Enabled = false;
                    txtjun.Enabled = false;
                    txtjul.Enabled = false;
                    txtaug.Enabled = false;
                    txtsep.Enabled = false;
                    txtoct.Enabled = false;
                    txtnov.Enabled = false;
                    txtdec.Enabled = false;
                    ddlchalukharch.Enabled = false;
                    txtchalukharch.Enabled = false;
                    ddlmagilmonth.Enabled = false;
                    txtmagilkharch.Enabled = false;
                    txtmagni.Enabled = false;
                    txtOtherExp.Enabled = false;
                    txtElectExpen.Enabled = false;
                    txtElectCost.Enabled = false;
                    ddlsadyasthiti.Enabled = false;
                    txtpahnikramank.Enabled = false;
                    txtpahnimudye.Enabled = false;
                    txtshera.Enabled = false;
                }
            }
        }
        public void roadtypee()
        {

        }
        public void billstatus()
        {
            int bll = 0;

            if (txtfirst.Text != 0.ToString() || txtfirst.Text != "")
            {
                bll++;
            }
            if (txtsecond.Text != 0.ToString() || txtsecond.Text != "")
            {
                bll++;
            }
            if (txtthird.Text != 0.ToString() || txtthird.Text != "")
            {
                bll++;
            }
            lblbillno.Text = bll.ToString();
        }
        protected void BtnSav_Click(object sender, EventArgs e)
        {
            try
            {
                txtElectCost.Text = ConvertDigits(txtElectCost.Text);
                txtmagni.Text = ConvertDigits(txtmagni.Text);
                txtsanctionAmt.Text = ConvertDigits(txtsanctionAmt.Text);
                txtNividaKimat.Text = ConvertDigits(txtNividaKimat.Text);
                txtprashaskiykimat.Text = ConvertDigits(txtprashaskiykimat.Text);
                txttantarikkimat.Text = ConvertDigits(txttantarikkimat.Text);


                string a = "", b = "", c = "";
                GetID();
                billstatus();
                if (con.State != ConnectionState.Open)
                    con.Open();
                if (conMDB.State != ConnectionState.Open)
                    conMDB.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from BudgetMasterCRF WHERE WorkId=N'" + txtWorkID.Text.Trim() + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlCommand cmd = new SqlCommand();
                SqlCommand cmd1 = new SqlCommand();
                SqlCommand cmd2 = new SqlCommand();
                SqlCommand cmdMDB = new SqlCommand();
                SqlCommand cmdMDB1 = new SqlCommand();
                SqlCommand cmdMDB2 = new SqlCommand();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString() == 0.ToString())
                    {
                        string strMasterInsertQuery = "INSERT INTO [BudgetMasterCRF] ([WorkId],[Arthsankalpiyyear],[Akrmank],[Type],[Dist],[Taluka],[ArthsankalpiyBab],[Upvibhag],[LekhaShirsh],[LekhaShirshName],[SubType],[ShakhaAbhyantaName],[ShakhaAbhiyantMobile],[UpabhyantaName],[UpAbhiyantaMobile],[KhasdaracheName],[AmdaracheName],[KamacheName],[Kamachavav],[PrashaskiyKramank],[PrashaskiyDate],[PrashaskiyAmt],[TrantrikKrmank],[TrantrikDate],[TrantrikAmt],[ThekedaarName],[ThekedarMobile],[NividaKrmank],[NividaAmt],[karyarambhadesh],[NividaDate],[kamachiMudat],[KamPurnDate],[JobNo],[RoadNo],[RoadLength],[SanctionDate],[SanctionAmount],[APhysicalScope],[ACommulative],[ATarget] ,[AAchievement],[BPhysicalScope],[BCommulative],[BTarget],[BAchievement],[CPhysicalScope] ,[CCommulative] ,[CTarget] ,[CAchievement] ,[DPhysicalScope],[DCommulative],[DTarget],[DAchievement],[EPhysicalScope],[ECommulative] ,[ETarget],[EAchievement],[Sadyasthiti],[Pahanikramank],[PahaniMudye],[Shera],[Img1],[Img2],[Img3],[SubDivision]) VALUES(N'" + txtWorkID.Text.Trim() + "',N'" + txtarthsankalpiyyear.Text + "',N'" + Convert.ToInt32(lblId.Text) + "',N'CRF',N'" + ddldist.SelectedItem.Text + "',N'" + ddltaluka.SelectedItem.Text + "',N'" + txtarthsankalpiybab.Text + "',N'" + ddlupvibhag.SelectedItem.Text + "',N'" + ddllekhashirsh.SelectedItem.Text + "',N'" + lblLekhaName.Text + "',N'" + ddlsubtype.SelectedItem.Text + "',N'" + ddlabhiyanta.SelectedItem.Text + "',N'" + txtabhiyantamobile.Text + "',N'" + ddlupabhiyanta.SelectedItem.Text + "',N'" + txtupabhiyantamobile.Text + "',N'" + ddlkhasdarachename.SelectedItem.Text + "',N'" + ddlaamdarachename.SelectedItem.Text + "',N'" + txtkamachenav.Text + "',N'" + txtkamachavav.Text + "',N'" + txtprashaskiykramank.Text + "',N'" + txtprashaskiydinak.Text + "',N'" + txtprashaskiykimat.Text + "',N'" + txttantrikkramank.Text + "',N'" + txttantarikdinak.Text + "',N'" + txttantarikkimat.Text + "',N'" + ddlThekedarName.SelectedItem.Text + "',N'" + lblThekedarMobNo.Text + "',N'" + txtNividaKramank.Text + "',N'" + txtNividaKimat.Text + "',N'" + txtkaryarambhaadesh.Text + "',N'" + txtkaryarambhdinak.Text + "',N'" + txtkamachimudat.Text + "',N'" + txtkampurndinak.Text + "',N'" + txtjobno.Text + "',N'" + txtRoadNo.Text + "',N'" + txtRoadLength.Text + "',N'" + txtsanctiondate.Text + "',N'" + Convert.ToDecimal(txtsanctionAmt.Text) + "',N'" + Convert.ToDecimal(txtAPhysical.Text) + "',N'" + Convert.ToDecimal(txtACumulative.Text) + "',N'" + Convert.ToDecimal(txtATarget.Text) + "',N'" + Convert.ToDecimal(txtAAchievement.Text) + "',N'" + Convert.ToDecimal(txtBPhysical.Text) + "',N'" + Convert.ToDecimal(txtBCumulative.Text) + "',N'" + Convert.ToDecimal(txtBTarget.Text) + "',N'" + Convert.ToDecimal(txtBAchievement.Text) + "',N'" + Convert.ToDecimal(txtCPhysical.Text) + "',N'" + Convert.ToDecimal(txtCCumulative.Text) + "',N'" + Convert.ToDecimal(txtCTarget.Text) + "',N'" + Convert.ToDecimal(txtCAchievement.Text) + "',N'" + Convert.ToDecimal(txtDPhysical.Text) + "',N'" + Convert.ToDecimal(txtDCumulative.Text) + "',N'" + Convert.ToDecimal(txtDTarget.Text) + "',N'" + Convert.ToDecimal(txtDAchievement.Text) + "',N'" + Convert.ToDecimal(txtEMajor.Text) + "',N'" + Convert.ToDecimal(txtECumulative.Text) + "',N'" + Convert.ToDecimal(txtETarget.Text) + "',N'" + Convert.ToDecimal(txtEAchievement.Text) + "',N'" + ddlsadyasthiti.SelectedItem.Text + "',N'" + txtpahnikramank.Text + "',N'" + txtpahnimudye.Text + "',N'" + txtshera.Text + "',N'" + a + "',N'" + b + "',N'" + c + "','PuneEast')";
                        string strProvisionInsertQuery = "INSERT INTO [CRFProvision] ([WorkId],[Arthsankalpiyyear],[MudatVadhiDate],[DeyakachiSadyasthiti],[ManjurAmt],[MarchEndingExpn],[UrvaritAmt],[DTakunone],[Takunone],[DTakuntwo],[Takuntwo],[DTakunthree],[Takunthree],[DTakunfour],[Takunfour],[Tartud],[Jan],[Feb],[Mar],[Apr],[May],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec],[AkunAnudan],[Chalumonth],[Chalukharch],[Magilmonth],[Magilkharch],[Magni],[VarshbharatilKharch],[AikunKharch],[OtherExpen] ,[ExpenCost],[ExpenExpen],[SubDivision]) VALUES('" + txtWorkID.Text.Trim() + "','" + txtarthsankalpiyyear.Text + "',N'" + txtmudatvadhdinak.Text + "',N'" + Billpayment.Text + "',N'" + Convert.ToDecimal(txtcost.Text) + "',N'" + Convert.ToDecimal(txtmarchakherkharch.Text) + "',N'" + Convert.ToDecimal(txturvaritamt.Text) + "',N'" + ddlakun1.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun1.Text) + "', N'" + ddlakun2.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun2.Text) + "',N'" + ddlakun3.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun3.Text) + "',N'" + ddlakun4.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun4.Text) + "',N'" + Convert.ToDecimal(txttartud.Text) + "',N'" + Convert.ToDecimal(txtjan.Text) + "',N'" + Convert.ToDecimal(txtfeb.Text) + "',N'" + Convert.ToDecimal(txtmar.Text) + "',N'" + Convert.ToDecimal(txtapr.Text) + "',N'" + Convert.ToDecimal(txtmay.Text) + "',N'" + Convert.ToDecimal(txtjun.Text) + "',N'" + Convert.ToDecimal(txtjul.Text) + "',N'" + Convert.ToDecimal(txtaug.Text) + "',N'" + Convert.ToDecimal(txtsep.Text) + "',N'" + Convert.ToDecimal(txtoct.Text) + "',N'" + Convert.ToDecimal(txtnov.Text) + "',N'" + Convert.ToDecimal(txtdec.Text) + "',N'" + Convert.ToDecimal(txtaikunanudan.Text) + "',N'" + ddlchalukharch.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtchalukharch.Text) + "',N'" + ddlmagilmonth.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtmagilkharch.Text) + "',N'" + Convert.ToDecimal(txtmagni.Text) + "',N'" + Convert.ToDecimal(txtvarshbharatilkharch.Text) + "',N'" + Convert.ToDecimal(txtaikunkharch.Text) + "',N'" + Convert.ToDecimal(txtOtherExp.Text) + "',N'" + Convert.ToDecimal(txtElectCost.Text) + "',N'" + Convert.ToDecimal(txtElectExpen.Text) + "','PuneEast')";
                        cmd = new SqlCommand(strMasterInsertQuery, con);
                        cmd1 = new SqlCommand(strProvisionInsertQuery, con);

                        cmdMDB = new SqlCommand(strMasterInsertQuery, conMDB);
                        cmdMDB1 = new SqlCommand(strProvisionInsertQuery, conMDB);
                        strCommandType = "Inserted";
                    }
                    else
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter("select Count(*) from CRFProvision where Arthsankalpiyyear=N'" + AuditDate.Text + "' and WorkId=N'" + txtWorkID.Text.Trim() + "'", con);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            string strMasterUpdateQuery = "UPDATE BudgetMasterCRF SET [Dist]=N'" + ddldist.SelectedItem.Text + "',[Taluka]=N'" + ddltaluka.SelectedItem.Text + "',[ArthsankalpiyBab]=N'" + txtarthsankalpiybab.Text + "',[Upvibhag]=N'" + ddlupvibhag.SelectedItem.Text + "',[SubType]=N'" + ddlsubtype.SelectedItem.Text + "',[LekhaShirsh]=N'" + ddllekhashirsh.SelectedItem.Text + "',[LekhaShirshName]=N'" + lblLekhaName.Text + "',[ShakhaAbhyantaName]=N'" + ddlabhiyanta.SelectedItem.Text + "',[ShakhaAbhiyantMobile]=N'" + txtabhiyantamobile.Text + "',[UpabhyantaName]=N'" + ddlupabhiyanta.SelectedItem.Text + "',[UpAbhiyantaMobile]=N'" + txtupabhiyantamobile.Text + "',[KhasdaracheName]=N'" + ddlkhasdarachename.SelectedItem.Text + "',[AmdaracheName]=N'" + ddlaamdarachename.SelectedItem.Text + "',[KamacheName]=N'" + txtkamachenav.Text + "',[Kamachavav]=N'" + txtkamachavav.Text + "',[PrashaskiyKramank]=N'" + txtprashaskiykramank.Text + "',[PrashaskiyDate]=N'" + txtprashaskiydinak.Text + "',[PrashaskiyAmt]=N'" + txtprashaskiykimat.Text + "',[TrantrikKrmank]=N'" + txttantrikkramank.Text + "',[TrantrikDate]=N'" + txttantarikdinak.Text + "',[TrantrikAmt]=N'" + txttantarikkimat.Text + "',[ThekedaarName]=N'" + ddlThekedarName.SelectedItem.Text + "',[ThekedarMobile]=N'" + lblThekedarMobNo.Text + "',[NividaKrmank]=N'" + txtNividaKramank.Text + "',[NividaAmt]=N'" + txtNividaKimat.Text + "',[karyarambhadesh]=N'" + txtkaryarambhaadesh.Text + "',[NividaDate]=N'" + txtkaryarambhdinak.Text + "',[kamachiMudat]=N'" + txtkamachimudat.Text + "',[KamPurnDate]=N'" + txtkampurndinak.Text + "',[JobNo]=N'" + txtjobno.Text + "',[RoadNo]=N'" + txtRoadNo.Text + "',[RoadLength]=N'" + txtRoadLength.Text + "',[SanctionDate]=N'" + txtsanctiondate.Text + "',[SanctionAmount]=N'" + Convert.ToDecimal(txtsanctionAmt.Text) + "',[APhysicalScope]=N'" + Convert.ToDecimal(txtAPhysical.Text) + "',[ACommulative]=N'" + Convert.ToDecimal(txtACumulative.Text) + "',[ATarget]=N'" + Convert.ToDecimal(txtATarget.Text) + "' ,[AAchievement]=N'" + Convert.ToDecimal(txtAAchievement.Text) + "',[BPhysicalScope]=N'" + Convert.ToDecimal(txtBPhysical.Text) + "',[BCommulative]='" + Convert.ToDecimal(txtBCumulative.Text) + "',[BTarget]=N'" + Convert.ToDecimal(txtBTarget.Text) + "',[BAchievement]=N'" + Convert.ToDecimal(txtBAchievement.Text) + "',[CPhysicalScope]=N'" + Convert.ToDecimal(txtCPhysical.Text) + "' ,[CCommulative]=N'" + Convert.ToDecimal(txtCCumulative.Text) + "' ,[CTarget]=N'" + Convert.ToDecimal(txtCTarget.Text) + "' ,[CAchievement]=N'" + Convert.ToDecimal(txtCAchievement.Text) + "' ,[DPhysicalScope]=N'" + Convert.ToDecimal(txtDPhysical.Text) + "',[DCommulative]=N'" + Convert.ToDecimal(txtDCumulative.Text) + "',[DTarget]=N'" + Convert.ToDecimal(txtDTarget.Text) + "',[DAchievement]=N'" + Convert.ToDecimal(txtDAchievement.Text) + "',[EPhysicalScope]=N'" + Convert.ToDecimal(txtDPhysical.Text) + "',[ECommulative]=N'" + Convert.ToDecimal(txtECumulative.Text) + "',[ETarget]=N'" + Convert.ToDecimal(txtECumulative.Text) + "',[EAchievement]=N'" + Convert.ToDecimal(txtEAchievement.Text) + "', [Sadyasthiti]=N'" + ddlsadyasthiti.SelectedItem.Text + "',[Pahanikramank]=N'" + txtpahnikramank.Text + "',[PahaniMudye]=N'" + txtpahnimudye.Text + "',[Shera]=N'" + txtshera.Text + "' WHERE WorkId=N'" + txtWorkID.Text.Trim() + "' and [SubDivision]='PuneEast'";
                            cmd = new SqlCommand(strMasterUpdateQuery, con);
                            cmdMDB = new SqlCommand(strMasterUpdateQuery, conMDB);
                            if (dr1[0].ToString() == 0.ToString())
                            {
                                string strMasterInsertQuery = "INSERT INTO [CRFProvision] ([WorkId],[Arthsankalpiyyear],[MudatVadhiDate],[DeyakachiSadyasthiti],[ManjurAmt],[MarchEndingExpn],[UrvaritAmt],[DTakunone],[Takunone],[DTakuntwo],[Takuntwo],[DTakunthree],[Takunthree],[DTakunfour],[Takunfour],[Tartud],[Jan],[Feb],[Mar],[Apr],[May],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec],[AkunAnudan],[Chalumonth],[Chalukharch],[Magilmonth],[Magilkharch],[Magni],[VarshbharatilKharch],[AikunKharch],[OtherExpen] ,[ExpenCost],[ExpenExpen],[SubDivision]) VALUES('" + txtWorkID.Text.Trim() + "','" + txtarthsankalpiyyear.Text + "',N'" + txtmudatvadhdinak.Text + "',N'" + Billpayment.Text + "',N'" + Convert.ToDecimal(txtcost.Text) + "',N'" + Convert.ToDecimal(txtmarchakherkharch.Text) + "',N'" + Convert.ToDecimal(txturvaritamt.Text) + "',N'" + ddlakun1.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun1.Text) + "', N'" + ddlakun2.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun2.Text) + "',N'" + ddlakun3.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun3.Text) + "',N'" + ddlakun4.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun4.Text) + "',N'" + Convert.ToDecimal(txttartud.Text) + "',N'" + Convert.ToDecimal(txtjan.Text) + "',N'" + Convert.ToDecimal(txtfeb.Text) + "',N'" + Convert.ToDecimal(txtmar.Text) + "',N'" + Convert.ToDecimal(txtapr.Text) + "',N'" + Convert.ToDecimal(txtmay.Text) + "',N'" + Convert.ToDecimal(txtjun.Text) + "',N'" + Convert.ToDecimal(txtjul.Text) + "',N'" + Convert.ToDecimal(txtaug.Text) + "',N'" + Convert.ToDecimal(txtsep.Text) + "',N'" + Convert.ToDecimal(txtoct.Text) + "',N'" + Convert.ToDecimal(txtnov.Text) + "',N'" + Convert.ToDecimal(txtdec.Text) + "',N'" + Convert.ToDecimal(txtaikunanudan.Text) + "',N'" + ddlchalukharch.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtchalukharch.Text) + "',N'" + ddlmagilmonth.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtmagilkharch.Text) + "',N'" + Convert.ToDecimal(txtmagni.Text) + "',N'" + Convert.ToDecimal(txtvarshbharatilkharch.Text) + "',N'" + Convert.ToDecimal(txtaikunkharch.Text) + "',N'" + txtOtherExp.Text + "',N'" + txtElectCost.Text + "',N'" + txtElectExpen.Text + "','PuneEast')";
                                cmd1 = new SqlCommand(strMasterInsertQuery, con);
                                cmdMDB1 = new SqlCommand(strMasterInsertQuery, conMDB);

                                cmd2 = new SqlCommand("INSERT INTO [StatusBillPayment] ([WorkID],[Arthsankalpiyyear],[MonthSelect],[FirstValue],[SecondValue],[ThirdValue],[BillOne],[BillTwo],[BillThree]) VALUES(N'" + txtWorkID.Text + "',N'" + AuditDate.Text + "',N'" + Billpayment.Text + "',N'" + txtfirst.Text + "',N'" + txtsecond.Text + "',N'" + txtthird.Text + "',N'" + ddlbillone.Text + "',N'" + ddlbilltwo.Text + "',N'" + ddlbillthree.Text + "')", con);
                            }
                            else
                            {
                                strMasterUpdateQuery = "UPDATE [CRFProvision] SET [MudatVadhiDate]=N'" + txtmudatvadhdinak.Text + "',[DeyakachiSadyasthiti]=N'" + Billpayment.Text + "',[ManjurAmt]=N'" + txtcost.Text + "',[MarchEndingExpn]=N'" + Convert.ToDecimal(txtmarchakherkharch.Text) + "',[UrvaritAmt]=N'" + txturvaritamt.Text + "',[DTakunone]=N'" + ddlakun1.SelectedItem.Text + "',[Takunone]=N'" + Convert.ToDecimal(txtakun1.Text) + "',[DTakuntwo]=N'" + ddlakun2.SelectedItem.Text + "',[Takuntwo]=N'" + Convert.ToDecimal(txtakun2.Text) + "',[DTakunthree]=N'" + ddlakun3.SelectedItem.Text + "',[Takunthree]=N'" + Convert.ToDecimal(txtakun3.Text) + "',[DTakunfour]=N'" + ddlakun4.Text + "',[Takunfour]=N'" + Convert.ToDecimal(txtakun4.Text) + "',[Tartud]=N'" + Convert.ToDecimal(txttartud.Text) + "',[Jan]=N'" + Convert.ToDecimal(txtjan.Text) + "',[Feb]=N'" + Convert.ToDecimal(txtfeb.Text) + "',[Mar]=N'" + Convert.ToDecimal(txtmar.Text) + "',[Apr]=N'" + Convert.ToDecimal(txtapr.Text) + "',[May]=N'" + Convert.ToDecimal(txtmay.Text) + "',[Jun]=N'" + Convert.ToDecimal(txtjun.Text) + "',[Jul]=N'" + Convert.ToDecimal(txtjul.Text) + "',[Aug]=N'" + Convert.ToDecimal(txtaug.Text) + "',[Sep]=N'" + Convert.ToDecimal(txtsep.Text) + "',[Oct]=N'" + Convert.ToDecimal(txtoct.Text) + "',[Nov]=N'" + Convert.ToDecimal(txtnov.Text) + "',[Dec]=N'" + Convert.ToDecimal(txtdec.Text) + "',[AkunAnudan]=N'" + Convert.ToDecimal(txtaikunanudan.Text) + "',[Chalumonth]=N'" + ddlchalukharch.SelectedItem.Text + "',[Chalukharch]=N'" + Convert.ToDecimal(txtchalukharch.Text) + "',[Magilmonth]=N'" + ddlmagilmonth.SelectedItem.Text + "',[Magilkharch]=N'" + Convert.ToDecimal(txtmagilkharch.Text) + "',[Magni]=N'" + Convert.ToDecimal(txtmagni.Text) + "',[VarshbharatilKharch]=N'" + Convert.ToDecimal(txtvarshbharatilkharch.Text) + "',[AikunKharch]=N'" + Convert.ToDecimal(txtaikunkharch.Text) + "',[OtherExpen]=N'" + txtOtherExp.Text + "' ,[ExpenCost]=N'" + txtElectCost.Text + "',[ExpenExpen]=N'" + txtElectExpen.Text + "' where Arthsankalpiyyear=N'" + AuditDate.Text.Trim() + "' and WorkId=N'" + txtWorkID.Text.Trim() + "' and [SubDivision]='PuneEast'";
                                cmd1 = new SqlCommand(strMasterUpdateQuery, con);
                                cmdMDB1 = new SqlCommand(strMasterUpdateQuery, conMDB);

                                SqlDataAdapter sdap = new SqlDataAdapter("SELECT [WorkID],[Arthsankalpiyyear],[MonthSelect] FROM [StatusBillPayment]  where [Arthsankalpiyyear]=N'" + AuditDate.Text.Trim() + "' and [WorkID]=N'" + txtWorkID.Text.Trim() + "' and [MonthSelect]=N'" + Billpayment.Text + "'", con);
                                DataTable dtp = new DataTable();
                                sdap.Fill(dtp);
                                if (dtp.Rows.Count != 0)
                                {
                                    cmd2 = new SqlCommand("UPDATE [StatusBillPayment] SET [FirstValue]=N'" + txtfirst.Text + "',[SecondValue]=N'" + txtsecond.Text + "',[ThirdValue]=N'" + txtthird.Text + "',[BillOne]=N'" + ddlbillone.SelectedItem.Text + "',[BillTwo]=N'" + ddlbilltwo.SelectedItem.Text + "',[BillThree]=N'" + ddlbillthree.SelectedItem.Text + "' where [Arthsankalpiyyear]=N'" + AuditDate.Text.Trim() + "' and [WorkID]=N'" + txtWorkID.Text.Trim() + "' and [MonthSelect]=N'" + Billpayment.Text + "'", con);
                                }
                                else
                                {
                                    cmd2 = new SqlCommand("INSERT INTO [StatusBillPayment] ([WorkID],[Arthsankalpiyyear],[MonthSelect],[FirstValue],[SecondValue],[ThirdValue],[BillOne],[BillTwo],[BillThree]) VALUES(N'" + txtWorkID.Text + "',N'" + AuditDate.Text + "',N'" + Billpayment.Text + "',N'" + txtfirst.Text + "',N'" + txtsecond.Text + "',N'" + txtthird.Text + "',N'" + ddlbillone.Text + "',N'" + ddlbilltwo.Text + "',N'" + ddlbillthree.Text + "')", con);
                                }
                            }
                        }
                        strCommandType = "Updated";
                    }
                    if (cmd.ExecuteNonQuery() > 0 && cmdMDB.ExecuteNonQuery() > 0)
                    {
                        cmd1.ExecuteNonQuery();
                        cmdMDB1.ExecuteNonQuery();
                        //For Insert/Update SMS Record
                        SMSobj.workid = txtWorkID.Text.Trim();
                        SMSobj.shakhaabhyantaname = ddlabhiyanta.SelectedItem.Text.Trim();
                        SMSobj.shakhaabhyantamobile = txtabhiyantamobile.Text.Trim();
                        SMSobj.upabhyantaname = ddlupabhiyanta.SelectedItem.Text.Trim();
                        SMSobj.upabhyantamobile = txtupabhiyantamobile.Text.Trim();
                        SMSobj.kamachename = txtkamachenav.Text.Trim();
                        SMSobj.thekedarname = ddlThekedarName.SelectedItem.Text.Trim();
                        SMSobj.thekedarmobile = lblThekedarMobNo.Text.Trim();
                        SMSobj.kampurndate = txtkampurndinak.Text.Trim();
                        SMSobj.mudatvaddate = txtmudatvadhdinak.Text.Trim();

                        SMSobj.InsertSMSRecord();

                        mobileNumber = txtabhiyantamobile.Text + ",\n" + txtupabhiyantamobile.Text + ",\n" + lblThekedarMobNo.Text;
                        string AddedDate = DateTime.Now.ToString("dd/MM/yyyy");
                        var yArray = mobileNumber.ToString().Split(',').Select(m => m.Trim()).ToArray();
                        message = "WorkId:" + txtWorkID.Text + " Type:2515_GramVikas Inserted Date:" + AddedDate + " Administratative-Date:" + txtprashaskiydinak.Text + " Work-Complition-Date:" + txtkampurndinak.Text + ". This work has been " + strCommandType + " into DBS Software in which your name has been mentioned.";
                        foreach (String strno in yArray)
                        {
                            SMSobj.SendSMS(strno, message);
                        }
                       // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Saved SuccessFully')", true);
                        //sendSms();
                        if (Request.QueryString["WorkID"] != null && Request.QueryString["WorkID"] != "0")
                        {
                            Response.Redirect("MasterCRFReport.aspx", false);
                        }
                        else if (Request.QueryString["MWorkID"] != null && Request.QueryString["MWorkID"] != "0")
                        {
                            Response.Redirect("SReport.aspx", false);
                        }
                        else
                        {
                            Response.Write("<script>alert('Record " + strCommandType + " Succesfully..!!!')</script>");
                            Server.Transfer("MasterBudgetCRF.aspx", false);

                            // Response.Redirect(Request.Url.AbsoluteUri);

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public void tartudtotal()
        {
            txtakun1.Text = ConvertDigits(txtakun1.Text);
            txtakun2.Text = ConvertDigits(txtakun2.Text);
            txtakun3.Text = ConvertDigits(txtakun3.Text);
            txtakun4.Text = ConvertDigits(txtakun4.Text);

            if (txtakun1.Text != "" && txtakun2.Text != "" && txtakun3.Text != "" && txtakun4.Text != "")
            {
                txttartud.Text = (Convert.ToDecimal(txtakun1.Text) + Convert.ToDecimal(txtakun2.Text) + Convert.ToDecimal(txtakun3.Text) + Convert.ToDecimal(txtakun4.Text)).ToString();
            }
        }

        protected void txtchalukharch_TextChanged(object sender, EventArgs e)
        {
            txtchalukharch.Text = ConvertDigits(txtchalukharch.Text);
            totalkharch();
        }

        protected void txtmagilkharch_TextChanged(object sender, EventArgs e)
        {
            txtmagilkharch.Text = ConvertDigits(txtmagilkharch.Text);
            totalkharch();
        }

        protected void txtakun1_TextChanged(object sender, EventArgs e)
        {
            txtakun1.Text = ConvertDigits(txtakun1.Text);
            tartudtotal();
        }

        protected void txtakun2_TextChanged(object sender, EventArgs e)
        {
            txtakun2.Text = ConvertDigits(txtakun2.Text);
            tartudtotal();
        }

        protected void txtakun3_TextChanged(object sender, EventArgs e)
        {
            txtakun3.Text = ConvertDigits(txtakun3.Text);
            tartudtotal();
        }

        protected void txtakun4_TextChanged(object sender, EventArgs e)
        {
            txtakun4.Text = ConvertDigits(txtakun4.Text);
            tartudtotal();
        }

        protected void txtmarchakherkharch_TextChanged(object sender, EventArgs e)
        {
            txtmarchakherkharch.Text = ConvertDigits(txtmarchakherkharch.Text);
            txtcost.Text = ConvertDigits(txtcost.Text);
            txturvaritamt.Text = ConvertDigits(txturvaritamt.Text);

            if (txtcost.Text != "" && txtcost.Text != " " && txtmarchakherkharch.Text != "" && txtmarchakherkharch.Text != " ")
            {
                txturvaritamt.Text = (Convert.ToDecimal(txtcost.Text) - Convert.ToDecimal(txtmarchakherkharch.Text)).ToString();
            }
            txtmarchakherkharch.Text = ConvertDigits(txtmarchakherkharch.Text);
            totalkharch();
        }


        protected void txtjan_TextChanged(object sender, EventArgs e)
        {
            txtjan.Text = ConvertDigits(txtjan.Text);
            totalanudan();
        }

        protected void txtfeb_TextChanged(object sender, EventArgs e)
        {
            txtfeb.Text = ConvertDigits(txtfeb.Text);
            totalanudan();
        }

        protected void txtmar_TextChanged(object sender, EventArgs e)
        {
            txtmar.Text = ConvertDigits(txtmar.Text);
            totalanudan();
        }

        protected void txtapr_TextChanged(object sender, EventArgs e)
        {
            txtapr.Text = ConvertDigits(txtapr.Text);
            totalanudan();
        }

        protected void txtmay_TextChanged(object sender, EventArgs e)
        {
            txtmay.Text = ConvertDigits(txtmay.Text);
            totalanudan();
        }

        protected void txtjun_TextChanged(object sender, EventArgs e)
        {
            txtjun.Text = ConvertDigits(txtjun.Text);
            totalanudan();
        }

        protected void txtjul_TextChanged(object sender, EventArgs e)
        {
            txtjul.Text = ConvertDigits(txtjul.Text);
            totalanudan();
        }

        protected void txtaug_TextChanged(object sender, EventArgs e)
        {
            txtaug.Text = ConvertDigits(txtaug.Text);
            totalanudan();
        }

        protected void txtsep_TextChanged(object sender, EventArgs e)
        {
            txtsep.Text = ConvertDigits(txtsep.Text);
            totalanudan();
        }

        protected void txtoct_TextChanged(object sender, EventArgs e)
        {
            txtoct.Text = ConvertDigits(txtoct.Text);
            totalanudan();
        }

        protected void txtnov_TextChanged(object sender, EventArgs e)
        {
            txtnov.Text = ConvertDigits(txtnov.Text);
            totalanudan();
        }

        protected void txtdec_TextChanged(object sender, EventArgs e)
        {
            txtdec.Text = ConvertDigits(txtdec.Text);
            totalanudan();
        }

        public void MonthCalculation()
        {
            txtfirst.Text = ConvertDigits(txtfirst.Text);
            txtsecond.Text = ConvertDigits(txtsecond.Text);
            txtthird.Text = ConvertDigits(txtthird.Text);


            if (txtfirst.Text == "")
            {
                txtfirst.Text = 0.ToString();
            }
            if (txtsecond.Text == "")
            {
                txtsecond.Text = 0.ToString();
            }
            if (txtthird.Text == "")
            {
                txtthird.Text = 0.ToString();
            }
            if (Billpayment.SelectedIndex == 1)
            {
                txtjan.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 2)
            {
                txtfeb.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 3)
            {
                txtmar.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 4)
            {
                txtapr.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 5)
            {
                txtmay.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 6)
            {
                txtjun.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 7)
            {
                txtjul.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 8)
            {
                txtaug.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 9)
            {
                txtsep.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 10)
            {
                txtoct.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 11)
            {
                txtnov.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }
            if (Billpayment.SelectedIndex == 12)
            {
                txtdec.Text = (Convert.ToDecimal(txtfirst.Text) + Convert.ToDecimal(txtsecond.Text) + Convert.ToDecimal(txtthird.Text)).ToString();
            }

        }

        protected void txtfirst_TextChanged(object sender, EventArgs e)
        {
            txtfirst.Text = ConvertDigits(txtfirst.Text);
            MonthCalculation();
        }

        protected void txtsecond_TextChanged(object sender, EventArgs e)
        {
            txtsecond.Text = ConvertDigits(txtsecond.Text);
            MonthCalculation();
        }

        protected void txtthird_TextChanged(object sender, EventArgs e)
        {
            txtthird.Text = ConvertDigits(txtthird.Text);
            MonthCalculation();
        }
        public void fetchdatacrf()
        {
            SqlDataAdapter sda = new SqlDataAdapter("  select [Jan],[Feb],[Mar],[Apr],[May],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec] from CRFProvision where WorkID='" + txtWorkID.Text + "' and Arthsankalpiyyear='" + AuditDate.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtjan.Text = dr["Jan"].ToString();
                txtfeb.Text = dr["Feb"].ToString();
                txtmar.Text = dr["Mar"].ToString();
                txtapr.Text = dr["Apr"].ToString();
                txtmay.Text = dr["May"].ToString();
                txtjun.Text = dr["Jun"].ToString();
                txtjul.Text = dr["Jul"].ToString();
                txtaug.Text = dr["Aug"].ToString();
                txtsep.Text = dr["Sep"].ToString();
                txtoct.Text = dr["Oct"].ToString();
                txtnov.Text = dr["Nov"].ToString();
                txtdec.Text = dr["Dec"].ToString();
            }
        }
        protected void Billpayment_SelectedIndexChanged(object sender, EventArgs e)
        {

            fetchdatacrf();
            if (Billpayment.SelectedIndex == 0 || Billpayment.SelectedIndex == 13)
            {
                txtfirst.Text = 0.ToString();
                txtsecond.Text = 0.ToString();
                txtthird.Text = 0.ToString();
                ddlbillone.SelectedIndex = 0;
                ddlbilltwo.SelectedIndex = 0;
                ddlbillthree.SelectedIndex = 0;
            }
            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from StatusBillPayment where WorkID='" + txtWorkID.Text + "' and arthsankalpiyyear='" + AuditDate.Text + "' and MonthSelect='" + Billpayment.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtfirst.Text = dr["FirstValue"].ToString();
                        txtsecond.Text = dr["SecondValue"].ToString();
                        txtthird.Text = dr["ThirdValue"].ToString();
                        ddlbillone.SelectedItem.Text = dr["BillOne"].ToString();
                        ddlbilltwo.SelectedItem.Text = dr["BillTwo"].ToString();
                        ddlbillthree.SelectedItem.Text = dr["BillThree"].ToString();
                        MonthCalculation();
                    }
                }
                else
                {
                    txtfirst.Text = 0.ToString();
                    txtsecond.Text = 0.ToString();
                    txtthird.Text = 0.ToString();
                    ddlbillone.SelectedIndex = 0;
                    ddlbilltwo.SelectedIndex = 0;
                    ddlbillthree.SelectedIndex = 0;
                }
            }

        }

        protected void txtOtherExp_TextChanged(object sender, EventArgs e)
        {
            txtOtherExp.Text = ConvertDigits(txtOtherExp.Text);
            totalkharch();
        }

        protected void txtElectExpen_TextChanged(object sender, EventArgs e)
        {
            txtElectExpen.Text = ConvertDigits(txtElectExpen.Text);
            totalkharch();
        }

        protected void txtvarshbharatilkharch_TextChanged(object sender, EventArgs e)
        {
            txtvarshbharatilkharch.Text = ConvertDigits(txtvarshbharatilkharch.Text);
            totalkharch();
        }


        public static string ConvertDigits(string s)
        {
            return ObjsqlQueryOrCon.ConvertDigits(s);
        }

        protected void txtcost_TextChanged(object sender, EventArgs e)
        {
            txtcost.Text = ConvertDigits(txtcost.Text);
            txtmarchakherkharch.Text = ConvertDigits(txtmarchakherkharch.Text);
            txturvaritamt.Text = ConvertDigits(txturvaritamt.Text);

            if (txtcost.Text != "" && txtcost.Text != " " && txtmarchakherkharch.Text != "" && txtmarchakherkharch.Text != " ")
            {
                txturvaritamt.Text = (Convert.ToDecimal(txtcost.Text) - Convert.ToDecimal(txtmarchakherkharch.Text)).ToString();
            }
        }

        protected void txtDeptEngPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtDeptEngPassword.Text == FormPassword.ToString())
            {
                //Department Engineer
                txtkamachenav.Enabled = true;
                txtkamachavav.Enabled = true;
                txtprashaskiykramank.Enabled = true;
                txtprashaskiydinak.Enabled = true;
                txtprashaskiykimat.Enabled = true;
                txttantrikkramank.Enabled = true;
                txttantarikdinak.Enabled = true;
                txttantarikkimat.Enabled = true;
            }
            else
            {
                //Department Engineer
                txtkamachenav.Enabled = false;
                txtkamachavav.Enabled = false;
                txtprashaskiykramank.Enabled = false;
                txtprashaskiydinak.Enabled = false;
                txtprashaskiykimat.Enabled = false;
                txttantrikkramank.Enabled = false;
                txttantarikdinak.Enabled = false;
                txttantarikkimat.Enabled = false;
            }
        }

        protected void txtTenderPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtTenderPassword.Text == FormPassword.ToString())
            {
                //Tender Information
                ddlThekedarName.Enabled = true;
                txtNividaKramank.Enabled = true;
                txtNividaKimat.Enabled = true;
                txtkaryarambhaadesh.Enabled = true;
                txtkaryarambhdinak.Enabled = true;
                txtkamachimudat.Enabled = true;
                txtkampurndinak.Enabled = true;
            }
            else
            {
                //Tender Information
                ddlThekedarName.Enabled = false;
                txtNividaKramank.Enabled = false;
                txtNividaKimat.Enabled = false;
                txtkaryarambhaadesh.Enabled = false;
                txtkaryarambhdinak.Enabled = false;
                txtkamachimudat.Enabled = false;
                txtkampurndinak.Enabled = false;
            }
        }

        protected void txtPhyTargetPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPhyTargetPass.Text == FormPassword.ToString())
            {
                //Physical Target
                txtjobno.Enabled = true;
                txtsanctiondate.Enabled = true;
                txtsanctionAmt.Enabled = true;
                txtRoadNo.Enabled = true;
                txtRoadLength.Enabled = true;
                txtAPhysical.Enabled = true;
                txtACumulative.Enabled = true;
                txtATarget.Enabled = true;
                txtAAchievement.Enabled = true;
                txtBPhysical.Enabled = true;
                txtBCumulative.Enabled = true;
                txtBTarget.Enabled = true;
                txtBAchievement.Enabled = true;
                txtCPhysical.Enabled = true;
                txtCCumulative.Enabled = true;
                txtCTarget.Enabled = true;
                txtCAchievement.Enabled = true;
                txtDPhysical.Enabled = true;
                txtDCumulative.Enabled = true;
                txtDTarget.Enabled = true;
                txtDAchievement.Enabled = true;
                txtEMajor.Enabled = true;
                txtECumulative.Enabled = true;
                txtETarget.Enabled = true;
                txtEAchievement.Enabled = true;
            }
            else
            {
                txtjobno.Enabled = false;
                txtsanctiondate.Enabled = false;
                txtsanctionAmt.Enabled = false;
                txtRoadNo.Enabled = false;
                txtRoadLength.Enabled = false;
                txtAPhysical.Enabled = false;
                txtACumulative.Enabled = false;
                txtATarget.Enabled = false;
                txtAAchievement.Enabled = false;
                txtBPhysical.Enabled = false;
                txtBCumulative.Enabled = false;
                txtBTarget.Enabled = false;
                txtBAchievement.Enabled = false;
                txtCPhysical.Enabled = false;
                txtCCumulative.Enabled = false;
                txtCTarget.Enabled = false;
                txtCAchievement.Enabled = false;
                txtDPhysical.Enabled = false;
                txtDCumulative.Enabled = false;
                txtDTarget.Enabled = false;
                txtDAchievement.Enabled = false;
                txtEMajor.Enabled = false;
                txtECumulative.Enabled = false;
                txtETarget.Enabled = false;
                txtEAchievement.Enabled = false;
            }
        }
    }
}