using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PWdEEBudget.SMS_CRUD;
using System.Web.SessionState;
using System.Web.Configuration;
using DataLayer;
using System.Drawing;
namespace PWdEEBudget
{
    public partial class MasterBudget2515 : System.Web.UI.Page, IHttpHandler, IRequiresSessionState
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        SqlConnection conMDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnMDBString"].ToString());
      static  SqlQueryOrConnection ObjsqlQueryOrCon = new SqlQueryOrConnection();

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
                   // lbl1.Text = Session["id"].ToString();
                    GetID();                    
                    akunanudan();
                    BindAll_Lekha_Vibhag_VarishtType("2515_GramVikas");
                    Jilha();
                    BindAll_PERSON_NAME_ddl();
                   
                }
                else
                {
                    Response.Redirect("Login.aspx");
                    //    Session["id"] = lbl1.Text;
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

        public static string ConvertDigits(string s)
        {
            return ObjsqlQueryOrCon.ConvertDigits(s);
        }


        //This method for  Get All Name List Of UpAbhiyant, Abhiyanta,Thekedar,Khasdar and Amdar
        public void BindAll_PERSON_NAME_ddl()
        {
            DataSet ds = new DataSet();
            //Create Array of DropDownList IDs
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


        public void GetID()
        {
            try
            {
                int i = 1;
                string select = "select top 1 Akrmank from [BudgetMaster2515] order by Akrmank desc";
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
                    apekshitkharch.Text = yeartype;
                    lekhayeartartud.Text = yeartype;
                    lekhamarchanudan.Text = yeartype;
                    lekhayearanudan.Text = yeartype;
                    lekhamarchkharch.Text = yearset.ToString();
                    lekhayearmagil.Text = yeartype;
                    lekhayearchalu.Text = yeartype;
                    lableyearaikunkharch.Text = yeartype;
                    totalvitritanudan.Text = yeartype;
                    auditdateset();
                    yearfetchdata();
                    fetchdate();
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
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from [2515Provision] where WorkID=N'" + txtWorkID.Text.Trim() + "'", con);
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
                SqlDataAdapter sda1 = new SqlDataAdapter("select Arthsankalpiyyear from [BudgetMaster2515] where WorkID=N'" + txtWorkID.Text.Trim() + "'", con);
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


            msg = "Welcome to PWD East Pune\n Scheme Name: MLA  \n Work Name:" + txtkamachenav.Text + "\n  Lekhashirsh:" + ddllekhashirsh.Text + " \n Website:http://www.eepwdeastpunebudget.com \n Help:info@eepwdeastpunebudget.com";
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
                    //DateTime dt = DateTime.ParseExact(d, @"dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture);
                    DateTime dt = Convert.ToDateTime(d,System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
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
                ddlakun1.Items.Add(" ");
                ddlakun2.Items.Add(" ");
                ddlakun3.Items.Add(" ");
                ddlakun4.Items.Add(" ");
                ddlmagilmonth.Items.Add(" ");
                ddlchalukharch.Items.Add(" ");
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
                dt = ObjsqlQueryOrCon.Feach_Master_Data("GramVikas", txtWorkID.Text.Trim());
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
                        ddlupvibhag.SelectedIndex = ddlupvibhag.Items.IndexOf(ddlupvibhag.Items.FindByText(dr["Upvibhag"].ToString()));
                        prakar.SelectedItem.Text = dr["PageNo"].ToString();
                        txtarthsankalpiybab.Text = dr["ArthsankalpiyBab"].ToString();
                        txtjulybab.Text = dr["JulyBab"].ToString();
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
                        txtprashaskiykramank.Text = dr["PrashaskiyKramank"].ToString();
                        txtprashaskiydinak.Text = dr["PrashaskiyDate"].ToString();
                        txtprashaskiykimat.Text = dr["PrashaskiyAmt"].ToString();
                        txttantrikkramank.Text = dr["TrantrikKrmank"].ToString();
                        txttantarikdinak.Text = dr["TrantrikDate"].ToString();
                        txttantarikkimat.Text = dr["TrantrikAmt"].ToString();
                        txtkamachavav.Text = dr["Kamachevav"].ToString();
                        ddlThekedarName.SelectedIndex = ddlThekedarName.Items.IndexOf(ddlThekedarName.Items.FindByText(dr["ThekedaarName"].ToString()));
                        lblThekedarMobNo.Text = dr["ThekedarMobile"].ToString();
                        txtNividaKramank.Text = dr["NividaKrmank"].ToString();
                        txtNividaKimat.Text = dr["NividaAmt"].ToString();
                        txtkaryarambhaadesh.Text = dr["karyarambhadesh"].ToString();
                        txtkaryarambhdinak.Text = dr["NividaDate"].ToString();
                        txtkamachimudat.Text = dr["kamachiMudat"].ToString();
                        txtkampurndinak.Text = dr["KamPurnDate"].ToString();
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

                    ddltaluka.SelectedIndex = 0;
                    ddlupvibhag.SelectedIndex = 0;
                    prakar.SelectedIndex = 0;
                    txtarthsankalpiybab.Text = "";
                    txtjulybab.Text = "";
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
                    txtprashaskiykramank.Text = "";
                    txtprashaskiydinak.Text = "";
                    txtprashaskiykimat.Text = 0.ToString();
                    txttantrikkramank.Text = "";
                    txttantarikdinak.Text = "";
                    txttantarikkimat.Text = 0.ToString();
                    txtkamachavav.Text = "";
                    ddlThekedarName.SelectedIndex = 0;
                    lblThekedarMobNo.Text = "";
                    txtNividaKramank.Text = "";
                    txtNividaKimat.Text = 0.ToString();
                    txtkaryarambhaadesh.Text = "";
                    txtkaryarambhdinak.Text = "";
                    txtkamachimudat.Text = "";
                    txtkampurndinak.Text = "";
                    ddlsadyasthiti.SelectedIndex = 0;
                    txtpahnikramank.Text = "";
                    txtpahnimudye.Text = "";
                    txtshera.Text = "";
                }
                yearfetchdata();
                fetchdate();

            }
            catch (Exception)
            {

                throw;
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {  //return WorkID And WorkName List using like 'prefixWorkid%' ,'HeadType'
            return ObjsqlQueryOrCon.GetCompletionListOfWorkID(prefixText, "GramVikas");
        }
        protected void txtWorkID_TextChanged(object sender, EventArgs e)
        {
            txtWorkID.Text = txtWorkID.Text.Split(':')[0];
            workidsearch();
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

        public void totalkharch()
        {
            txtchalukharch.Text = ConvertDigits(txtchalukharch.Text);
            txtmagilkharch.Text = ConvertDigits(txtmagilkharch.Text);
            txtvarshbharatilkharch.Text = ConvertDigits(txtvarshbharatilkharch.Text);
            txtmarchakherkharch.Text = ConvertDigits(txtmarchakherkharch.Text);
            txtVidyutprama.Text = ConvertDigits(txtVidyutprama.Text);
            txtVidyutvitarit.Text = ConvertDigits(txtVidyutvitarit.Text);
            txtitarkhrch.Text = ConvertDigits(txtitarkhrch.Text);

            if (txtchalukharch.Text != "" && txtmagilkharch.Text != "")
            {
                txtvarshbharatilkharch.Text = (Convert.ToDecimal(txtchalukharch.Text) + Convert.ToDecimal(txtmagilkharch.Text)).ToString();
            }
            if (txtmarchakherkharch.Text != "" && txtVidyutprama.Text != "" && txtVidyutvitarit.Text != "" && txtitarkhrch.Text != "")
            {
                txtaikunkharch.Text = (Convert.ToDecimal(txtmarchakherkharch.Text) + Convert.ToDecimal(txtvarshbharatilkharch.Text) + Convert.ToDecimal(txtVidyutprama.Text) + Convert.ToDecimal(txtVidyutvitarit.Text) + Convert.ToDecimal(txtitarkhrch.Text)).ToString();
            }

        }

        protected void txtVidyutprama_TextChanged(object sender, EventArgs e)
        {
            txtVidyutprama.Text = ConvertDigits(txtVidyutprama.Text);
            totalkharch();
        }

        protected void txtVidyutvitarit_TextChanged(object sender, EventArgs e)
        {
            txtVidyutvitarit.Text = ConvertDigits(txtVidyutvitarit.Text);
            totalkharch();
        }

        protected void txtitarkhrch_TextChanged(object sender, EventArgs e)
        {
            txtitarkhrch.Text = ConvertDigits(txtitarkhrch.Text);
            totalkharch();
        }

        protected void txtmagilkharch_TextChanged(object sender, EventArgs e)
        {
            txtmagilkharch.Text = ConvertDigits(txtmagilkharch.Text);
            totalkharch();
        }

        protected void txtchalukharch_TextChanged(object sender, EventArgs e)
        {
            txtchalukharch.Text = ConvertDigits(txtchalukharch.Text);
            totalkharch();
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
            totalkharch();
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
        }

        public void yearfetchdata()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from [2515Provision] where Arthsankalpiyyear=N'" + AuditDate.Text.Trim() + "' and Workid=N'" + txtWorkID.Text.Trim() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString() == 0.ToString())
                {
                    txtmudatvadhdinak.Enabled = true;
                    Billpayment.Enabled = true;
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
                    txtVidyutprama.Enabled = true;
                    txtVidyutvitarit.Enabled = true;
                    txtitarkhrch.Enabled = true;
                    ddlsadyasthiti.Enabled = true;
                    txtpahnikramank.Enabled = true;
                    txtdnyapane.Enabled = true;
                    txtpahnimudye.Enabled = true;
                    txtshera.Enabled = true;
                    //PrakalpShakha
                    txtkamachenav.Enabled = true;
                    txtkamachavav.Enabled = true;
                    txtprashaskiykramank.Enabled = true;
                    txtprashaskiydinak.Enabled = true;
                    txtprashaskiykimat.Enabled = true;
                    txttantrikkramank.Enabled = true;
                    txttantarikdinak.Enabled = true;
                    txttantarikkimat.Enabled = true;

                    //NividaShakha
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
                    txtmudatvadhdinak.Enabled = false;
                    Billpayment.Enabled = false;
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
                    txtVidyutprama.Enabled = false;
                    txtVidyutvitarit.Enabled = false;
                    txtitarkhrch.Enabled = false;
                    ddlsadyasthiti.Enabled = false;
                    txtpahnikramank.Enabled = false;
                    txtdnyapane.Enabled = false;
                    txtpahnimudye.Enabled = false;
                    txtshera.Enabled = false;
                    //PrakalpShakha
                    txtkamachenav.Enabled = false;
                    txtkamachavav.Enabled = false;
                    txtprashaskiykramank.Enabled = false;
                    txtprashaskiydinak.Enabled = false;
                    txtprashaskiykimat.Enabled = false;
                    txttantrikkramank.Enabled = false;
                    txttantarikdinak.Enabled = false;
                    txttantarikkimat.Enabled = false;

                    //NividaShakha
                    ddlThekedarName.Enabled = false;
                    txtNividaKramank.Enabled = false;
                    txtNividaKimat.Enabled = false;
                    txtkaryarambhaadesh.Enabled = false;
                    txtkaryarambhdinak.Enabled = false;
                    txtkamachimudat.Enabled = false;
                    txtkampurndinak.Enabled = false;
                }
            }
        }

        public void fetchdate()
        {
            DataTable dt = new DataTable();
            dt = ObjsqlQueryOrCon.FeachProvisionData("GramVikas", AuditDate.Text.Trim(), txtWorkID.Text.Trim());

            if (dt.Rows.Count != 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    txtmudatvadhdinak.Text = dr["MudatVadhiDate"].ToString();
                    Billpayment.Text = dr["DeyakachiSadyasthiti"].ToString();
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
                    txtVidyutprama.Text = dr["Vidyutprama"].ToString();
                    txtVidyutvitarit.Text = dr["Vidyutvitarit"].ToString();
                    txtdnyapane.Text = dr["Dviguni"].ToString();
                    txtitarkhrch.Text = dr["Itarkhrch"].ToString();
                }
                if (dt.Rows.Count == 0)
                {
                    txtmudatvadhdinak.Text = 0.ToString();
                    Billpayment.Text = 0.ToString();
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
                    txtVidyutprama.Text = 0.ToString();
                    txtVidyutvitarit.Text = 0.ToString();
                    txtdnyapane.Text = 0.ToString();
                    txtitarkhrch.Text = 0.ToString();
                }
            }
        }

        protected void txtsecurity_TextChanged(object sender, EventArgs e)
        {
            if (AuditDate.SelectedIndex != -1)
            {
                if (FormPassword.ToString() == FormPassword.ToString())
                {
                    txtmudatvadhdinak.Enabled = true;
                    Billpayment.Enabled = true;
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
                    txtVidyutprama.Enabled = true;
                    txtVidyutvitarit.Enabled = true;
                    txtitarkhrch.Enabled = true;
                    ddlsadyasthiti.Enabled = true;
                    txtpahnikramank.Enabled = true;
                    txtdnyapane.Enabled = true;
                    txtpahnimudye.Enabled = true;
                    txtshera.Enabled = true;
                }
                else
                {
                    txtmudatvadhdinak.Enabled = false;
                    Billpayment.Enabled = false;
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
                    txtVidyutprama.Enabled = false;
                    txtVidyutvitarit.Enabled = false;
                    txtitarkhrch.Enabled = false;
                    ddlsadyasthiti.Enabled = false;
                    txtpahnikramank.Enabled = false;
                    txtdnyapane.Enabled = false;
                    txtpahnimudye.Enabled = false;
                    txtshera.Enabled = false;

                }
            }
        }

        protected void BtnSav_Click(object sender, EventArgs e)
        {
            try
            {

                txtprashaskiykramank.Text = ConvertDigits(txtprashaskiykramank.Text);
                txtprashaskiydinak.Text = ConvertDigits(txtprashaskiydinak.Text);
                txtprashaskiykimat.Text = ConvertDigits(txtprashaskiykimat.Text);
                txttantrikkramank.Text = ConvertDigits(txttantrikkramank.Text);
                txttantarikdinak.Text = ConvertDigits(txttantarikdinak.Text);
                txttantarikkimat.Text = ConvertDigits(txttantarikkimat.Text);
                txtnividashakha.Text = ConvertDigits(txtnividashakha.Text);
                txtNividaKramank.Text = ConvertDigits(txtNividaKramank.Text);
                txtNividaKimat.Text = ConvertDigits(txtNividaKimat.Text);
                txtkaryarambhaadesh.Text = ConvertDigits(txtkaryarambhaadesh.Text);
                txtmudatvadhdinak.Text = ConvertDigits(txtmudatvadhdinak.Text);
                txturvaritamt.Text = ConvertDigits(txturvaritamt.Text);
                Billpayment.Text = ConvertDigits(Billpayment.Text);
                txtarthsankalpiybab.Text = ConvertDigits(txtarthsankalpiybab.Text);
                txtjulybab.Text = ConvertDigits(txtjulybab.Text);
                txtkamachenav.Text = ConvertDigits(txtkamachenav.Text);
                txtkamachavav.Text = ConvertDigits(txtkamachavav.Text);
                txtmagni.Text = ConvertDigits(txtmagni.Text);
                txtpahnikramank.Text = ConvertDigits(txtpahnikramank.Text);
                txtpahnimudye.Text = ConvertDigits(txtpahnimudye.Text);
                txtshera.Text = ConvertDigits(txtshera.Text);

                string a = "", b = "", c = "";
                GetID();
                if (con.State != ConnectionState.Open)
                    con.Open();
                if (conMDB.State != ConnectionState.Open)
                    conMDB.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from [BudgetMaster2515] WHERE WorkId='" + txtWorkID.Text.Trim() + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlCommand cmd = new SqlCommand();
                SqlCommand cmd1 = new SqlCommand();
                SqlCommand cmdMDB = new SqlCommand();
                SqlCommand cmdMDB1 = new SqlCommand();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString() == 0.ToString())
                    {
                        string strMasterInsertQuery = "INSERT INTO [BudgetMaster2515] ([WorkId],[Arthsankalpiyyear],[Akrmank],[Type],[Dist],[Taluka],[Upvibhag],[PageNo],[ArthsankalpiyBab],[JulyBab],[LekhaShirsh],[LekhaShirshName],[SubType],[ShakhaAbhyantaName],[ShakhaAbhiyantMobile],[UpabhyantaName] ,[UpAbhiyantaMobile] ,[KhasdaracheName] ,[AmdaracheName],[KamacheName],[PrashaskiyKramank],[PrashaskiyDate],[PrashaskiyAmt],[TrantrikKrmank],[TrantrikDate],[TrantrikAmt],[Kamachevav],[ThekedaarName],[ThekedarMobile],[NividaKrmank],[NividaAmt],[karyarambhadesh],[NividaDate],[kamachiMudat],[KamPurnDate],[Sadyasthiti],[Pahanikramank],[PahaniMudye],[Shera],[Img1],[Img2],[Img3],[SubDivision]) VALUES(N'" + txtWorkID.Text.Trim() + "',N'" + txtarthsankalpiyyear.Text + "',N'" + Convert.ToInt32(lblId.Text) + "',N'2515_GramVikas',N'" + ddldist.SelectedItem.Text + "', N'" + ddltaluka.SelectedItem.Text + "',N'" + ddlupvibhag.SelectedItem.Text + "',N'" + prakar.SelectedItem.Text + "',N'" + txtarthsankalpiybab.Text + "',N'" + txtjulybab.Text + "',N'" + ddllekhashirsh.SelectedItem.Text + "',N'" + lblLekhaName.Text + "',N'" + ddlsubtype.SelectedItem.Text + "',N'" + ddlabhiyanta.SelectedItem.Text + "',N'" + txtabhiyantamobile.Text + "',N'" + ddlupabhiyanta.SelectedItem.Text + "',N'" + txtupabhiyantamobile.Text + "',N'" + ddlkhasdarachename.SelectedItem.Text + "',N'" + ddlaamdarachename.SelectedItem.Text + "',N'" + txtkamachenav.Text + "',N'" + txtprashaskiykramank.Text + "',N'" + txtprashaskiydinak.Text + "',N'" + txtprashaskiykimat.Text + "',N'" + txttantrikkramank.Text + "',N'" + txttantarikdinak.Text + "',N'" + txttantarikkimat.Text + "',N'" + txtkamachavav.Text + "',N'" + ddlThekedarName.SelectedItem.Text + "',N'" + lblThekedarMobNo.Text + "',N'" + txtNividaKramank.Text + "',N'" + txtNividaKimat.Text + "',N'" + txtkaryarambhaadesh.Text + "',N'" + txtkaryarambhdinak.Text + "',N'" + txtkamachimudat.Text + "',N'" + txtkampurndinak.Text + "',N'" + ddlsadyasthiti.SelectedItem.Text + "',N'" + txtpahnikramank.Text + "',N'" + txtpahnimudye.Text + "',N'" + txtshera.Text + "',N'" + a + "',N'" + b + "',N'" + c + "','PuneEast')";
                        string strProvisionInsertQuery = "INSERT INTO [2515Provision] ([WorkId],[Arthsankalpiyyear],[MudatVadhiDate],[DeyakachiSadyasthiti],[ManjurAmt],[MarchEndingExpn],[UrvaritAmt],[DTakunone],[Takunone],[DTakuntwo],[Takuntwo],[DTakunthree],[Takunthree],[DTakunfour],[Takunfour],[Tartud],[Jan],[Feb],[Mar],[Apr],[May],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec],[AkunAnudan],[Chalumonth],[Chalukharch],[Magilmonth],[Magilkharch],[Magni],[VarshbharatilKharch],[AikunKharch],[Vidyutprama],[Vidyutvitarit],[Dviguni],[Itarkhrch],[SubDivision]) VALUES('" + txtWorkID.Text.Trim() + "','" + txtarthsankalpiyyear.Text + "',N'" + txtmudatvadhdinak.Text + "',N'" + Billpayment.Text + "',N'" + Convert.ToDecimal(txtcost.Text) + "',N'" + Convert.ToDecimal(txtmarchakherkharch.Text) + "',N'" + Convert.ToDecimal(txturvaritamt.Text) + "',N'" + ddlakun1.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun1.Text) + "', N'" + ddlakun2.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun2.Text) + "',N'" + ddlakun3.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun3.Text) + "',N'" + ddlakun4.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun4.Text) + "',N'" + Convert.ToDecimal(txttartud.Text) + "',N'" + Convert.ToDecimal(txtjan.Text) + "',N'" + Convert.ToDecimal(txtfeb.Text) + "',N'" + Convert.ToDecimal(txtmar.Text) + "',N'" + Convert.ToDecimal(txtapr.Text) + "',N'" + Convert.ToDecimal(txtmay.Text) + "',N'" + Convert.ToDecimal(txtjun.Text) + "',N'" + Convert.ToDecimal(txtjul.Text) + "',N'" + Convert.ToDecimal(txtaug.Text) + "',N'" + Convert.ToDecimal(txtsep.Text) + "',N'" + Convert.ToDecimal(txtoct.Text) + "',N'" + Convert.ToDecimal(txtnov.Text) + "',N'" + Convert.ToDecimal(txtdec.Text) + "',N'" + Convert.ToDecimal(txtaikunanudan.Text) + "',N'" + ddlchalukharch.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtchalukharch.Text) + "',N'" + ddlmagilmonth.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtmagilkharch.Text) + "',N'" + Convert.ToDecimal(txtmagni.Text) + "',N'" + Convert.ToDecimal(txtvarshbharatilkharch.Text) + "',N'" + Convert.ToDecimal(txtaikunkharch.Text) + "',N'" + Convert.ToDecimal(txtVidyutprama.Text) + "',N'" + Convert.ToDecimal(txtVidyutvitarit.Text) + "',N'" + txtdnyapane.Text + "',N'" + Convert.ToDecimal(txtitarkhrch.Text) + "','PuneEast')";                        
                        cmd = new SqlCommand(strMasterInsertQuery, con);
                        cmd1 = new SqlCommand(strProvisionInsertQuery, con);

                        cmdMDB = new SqlCommand(strMasterInsertQuery, conMDB);
                        cmdMDB1 = new SqlCommand(strProvisionInsertQuery, conMDB);
                        strCommandType = "Inserted";
                    }
                    else
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter("select Count(*) from [2515Provision] where Arthsankalpiyyear=N'" + AuditDate.Text.Trim() + "' and WorkId=N'" + txtWorkID.Text.Trim() + "'", con);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            string strMasterUpdateQuery = "UPDATE [BudgetMaster2515] SET [Dist]=N'" + ddldist.SelectedItem.Text + "',[Taluka]=N'" + ddltaluka.SelectedItem.Text + "',[Upvibhag]=N'" + ddlupvibhag.SelectedItem.Text + "',[PageNo]=N'" + prakar.SelectedItem.Text + "',[ArthsankalpiyBab]=N'" + txtarthsankalpiybab.Text + "',[JulyBab]=N'" + txtjulybab.Text + "',[LekhaShirsh]=N'" + ddllekhashirsh.SelectedItem.Text + "',[LekhaShirshName]=N'" + lblLekhaName.Text + "',[SubType]=N'" + ddlsubtype.SelectedItem.Text + "',[ShakhaAbhyantaName]=N'" + ddlabhiyanta.SelectedItem.Text + "',[ShakhaAbhiyantMobile]=N'" + txtabhiyantamobile.Text + "',[UpabhyantaName]=N'" + ddlupabhiyanta.SelectedItem.Text + "',[UpAbhiyantaMobile]=N'" + txtupabhiyantamobile.Text + "',[KhasdaracheName]=N'" + ddlkhasdarachename.SelectedItem.Text + "',[AmdaracheName]=N'" + ddlaamdarachename.SelectedItem.Text + "',[KamacheName]=N'" + txtkamachenav.Text + "',[PrashaskiyKramank]=N'" + txtprashaskiykramank.Text + "',[PrashaskiyDate]=N'" + txtprashaskiydinak.Text + "',[PrashaskiyAmt]=N'" + txtprashaskiykimat.Text + "',[TrantrikKrmank]=N'" + txttantrikkramank.Text + "',[TrantrikDate]=N'" + txttantarikdinak.Text + "',[TrantrikAmt]=N'" + txttantarikkimat.Text + "',[Kamachevav]=N'" + txtkamachavav.Text + "',[ThekedaarName]=N'" + ddlThekedarName.SelectedItem.Text + "',[ThekedarMobile]=N'" + lblThekedarMobNo.Text + "',[NividaKrmank]=N'" + txtNividaKramank.Text + "',[NividaAmt]=N'" + txtNividaKimat.Text + "',[karyarambhadesh]=N'" + txtkaryarambhaadesh.Text + "',[NividaDate]=N'" + txtkaryarambhdinak.Text + "',[kamachiMudat]=N'" + txtkamachimudat.Text + "',[KamPurnDate]=N'" + txtkampurndinak.Text + "',[Sadyasthiti]=N'" + ddlsadyasthiti.Text + "',[Pahanikramank]=N'" + txtpahnikramank.Text + "',[PahaniMudye]=N'" + txtpahnimudye.Text + "',[Shera]=N'" + txtshera.Text + "',[SubDivision]='PuneEast' WHERE WorkId=N'" + txtWorkID.Text.Trim() + "' and [SubDivision]='PuneEast'";
                            cmd = new SqlCommand(strMasterUpdateQuery, con);
                            cmdMDB = new SqlCommand(strMasterUpdateQuery, conMDB);                            
                            if (dr1[0].ToString() == 0.ToString())
                            {
                                string strMasterInsertQuery = "INSERT INTO [2515Provision] ([WorkId],[Arthsankalpiyyear],[MudatVadhiDate],[DeyakachiSadyasthiti],[ManjurAmt],[MarchEndingExpn],[UrvaritAmt],[DTakunone],[Takunone],[DTakuntwo],[Takuntwo],[DTakunthree],[Takunthree],[DTakunfour],[Takunfour],[Tartud],[Jan],[Feb],[Mar],[Apr],[May],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec],[AkunAnudan],[Chalumonth],[Chalukharch],[Magilmonth],[Magilkharch],[Magni],[VarshbharatilKharch],[AikunKharch],[Vidyutprama],[Vidyutvitarit],[Dviguni],[Itarkhrch],[SubDivision]) VALUES('" + txtWorkID.Text.Trim() + "','" + txtarthsankalpiyyear.Text + "',N'" + txtmudatvadhdinak.Text + "',N'" + Billpayment.Text + "',N'" + Convert.ToDecimal(txtcost.Text) + "',N'" + Convert.ToDecimal(txtmarchakherkharch.Text) + "',N'" + Convert.ToDecimal(txturvaritamt.Text) + "',N'" + ddlakun1.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun1.Text) + "', N'" + ddlakun2.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun2.Text) + "',N'" + ddlakun3.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun3.Text) + "',N'" + ddlakun4.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun4.Text) + "',N'" + Convert.ToDecimal(txttartud.Text) + "',N'" + Convert.ToDecimal(txtjan.Text) + "',N'" + Convert.ToDecimal(txtfeb.Text) + "',N'" + Convert.ToDecimal(txtmar.Text) + "',N'" + Convert.ToDecimal(txtapr.Text) + "',N'" + Convert.ToDecimal(txtmay.Text) + "',N'" + Convert.ToDecimal(txtjun.Text) + "',N'" + Convert.ToDecimal(txtjul.Text) + "',N'" + Convert.ToDecimal(txtaug.Text) + "',N'" + Convert.ToDecimal(txtsep.Text) + "',N'" + Convert.ToDecimal(txtoct.Text) + "',N'" + Convert.ToDecimal(txtnov.Text) + "',N'" + Convert.ToDecimal(txtdec.Text) + "',N'" + Convert.ToDecimal(txtaikunanudan.Text) + "',N'" + ddlchalukharch.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtchalukharch.Text) + "',N'" + ddlmagilmonth.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtmagilkharch.Text) + "',N'" + Convert.ToDecimal(txtmagni.Text) + "',N'" + Convert.ToDecimal(txtvarshbharatilkharch.Text) + "',N'" + Convert.ToDecimal(txtaikunkharch.Text) + "',N'" + Convert.ToDecimal(txtVidyutprama.Text) + "',N'" + Convert.ToDecimal(txtVidyutvitarit.Text) + "',N'" + txtdnyapane.Text + "',N'" + Convert.ToDecimal(txtitarkhrch.Text) + "','PuneEast')";
                                cmd1 = new SqlCommand(strMasterInsertQuery, con);
                                cmdMDB1 = new SqlCommand(strMasterInsertQuery, conMDB);                                
                            }
                            else
                            {
                                strMasterUpdateQuery = "UPDATE [2515Provision] SET [MudatVadhiDate]=N'" + txtmudatvadhdinak.Text + "',[DeyakachiSadyasthiti]=N'" + Billpayment.Text + "',[ManjurAmt]=N'" + txtcost.Text + "',[MarchEndingExpn]=N'" + txtmarchakherkharch.Text + "',[UrvaritAmt]=N'" + txturvaritamt.Text + "',[DTakunone]=N'" + ddlakun1.SelectedItem.Text + "',[Takunone]=N'" + txtakun1.Text + "',[DTakuntwo]=N'" + ddlakun2.SelectedItem.Text + "',[Takuntwo]=N'" + txtakun2.Text + "',[DTakunthree]=N'" + ddlakun3.SelectedItem.Text + "',[Takunthree]=N'" + txtakun3.Text + "',[DTakunfour]=N'" + ddlakun4.Text + "',[Takunfour]=N'" + txtakun4.Text + "',[Tartud]=N'" + txttartud.Text + "',[Jan]=N'" + txtjan.Text + "',[Feb]=N'" + txtfeb.Text + "',[Mar]=N'" + txtmar.Text + "',[Apr]=N'" + txtapr.Text + "',[May]=N'" + txtmay.Text + "',[Jun]=N'" + txtjun.Text + "',[Jul]=N'" + txtjul.Text + "',[Aug]=N'" + txtaug.Text + "',[Sep]=N'" + txtsep.Text + "',[Oct]=N'" + txtoct.Text + "',[Nov]=N'" + txtnov.Text + "',[Dec]=N'" + txtdec.Text + "',[AkunAnudan]=N'" + txtaikunanudan.Text + "',[Chalumonth]=N'" + ddlchalukharch.SelectedItem.Text + "',[Chalukharch]=N'" + txtchalukharch.Text + "',[Magilmonth]=N'" + ddlmagilmonth.SelectedItem.Text + "',[Magilkharch]=N'" + txtmagilkharch.Text + "',[Magni]=N'" + txtmagni.Text + "',[VarshbharatilKharch]=N'" + txtvarshbharatilkharch.Text + "',[AikunKharch]=N'" + txtaikunkharch.Text + "',[Vidyutprama]=N'" + Convert.ToDecimal(txtVidyutprama.Text) + "',[Vidyutvitarit]=N'" + Convert.ToDecimal(txtVidyutvitarit.Text) + "',[Dviguni]=N'" + txtdnyapane.Text + "',[Itarkhrch]=N'" + Convert.ToDecimal(txtitarkhrch.Text) + "' where Arthsankalpiyyear=N'" + AuditDate.Text.Trim() + "' and WorkId=N'" + txtWorkID.Text.Trim() + "' and [SubDivision]='PuneEast'";
                                cmd1 = new SqlCommand(strMasterUpdateQuery, con);
                                cmdMDB1 = new SqlCommand(strMasterUpdateQuery, conMDB);                               
                            }
                        }
                        strCommandType = "Updated";
                    }
                    if (cmd.ExecuteNonQuery() > 0 && cmdMDB.ExecuteNonQuery() > 0)
                    {
                        cmd1.ExecuteNonQuery();                        
                        cmdMDB1.ExecuteNonQuery();

                        //For Inser/update SMS Record
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
                        if (Request.QueryString["WorkID"] != null && Request.QueryString["WorkID"] != "0")
                        {
                            Response.Redirect("Master2515Report.aspx");
                        }
                        else if (Request.QueryString["MWorkID"] != null && Request.QueryString["MWorkID"] != "0")
                        {
                            Response.Redirect("SReport.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Record " + strCommandType + " Succesfully..!!!')</script>");
                            Server.Transfer("MasterBudget2515.aspx", false);
                        }
                    }

                }
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

        protected void txtPrakalpPassword_TextChanged(object sender, EventArgs e)
        {
            if (FormPassword.ToString() == FormPassword.ToString())
            {
                //PrakalpShakha
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
                //PrakalpShakha
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

        protected void txtnividashakha_TextChanged(object sender, EventArgs e)
        {
            if (FormPassword.ToString() == FormPassword.ToString())
            {
                //NividaShakha
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
                //NividaShakha
                ddlThekedarName.Enabled = false;
                txtNividaKramank.Enabled = false;
                txtNividaKimat.Enabled = false;
                txtkaryarambhaadesh.Enabled = false;
                txtkaryarambhdinak.Enabled = false;
                txtkamachimudat.Enabled = false;
                txtkampurndinak.Enabled = false;
            }
        }
    }
}