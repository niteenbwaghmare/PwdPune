﻿using System;
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
    public partial class MasterBudgetFBC : System.Web.UI.Page, IHttpHandler, IRequiresSessionState
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
                    akunanudan();
                    BindAll_Lekha_Vibhag_VarishtType("3054_Gat_FBC");
                    Jilha();
                    BindAll_PERSON_NAME_ddl();

                }
                else
                {
                    Response.Redirect("Login.aspx");
                    //    Session["id"] = lbl1.Text;
                }
                if (Request.QueryString["MWorkID"] != null && Request.QueryString["MWorkID"] != "0")
                {
                    txtWorkID.Text = Request.QueryString["MWorkID"].ToString();
                    txtWorkID.Focus();
                    txtWorkID.AutoPostBack = true;
                    workidsearch();
                }
                if (Request.QueryString["FWorkID"] != null && Request.QueryString["FWorkID"] != "0")
                {
                    txtWorkID.Text = Request.QueryString["FWorkID"].ToString();
                    txtWorkID.Focus();
                    txtWorkID.AutoPostBack = true;
                    workidsearch();
                }

                if (Request.QueryString["BWorkID"] != null && Request.QueryString["BWorkID"] != "0")
                {
                    txtWorkID.Text = Request.QueryString["BWorkID"].ToString();
                    txtWorkID.Focus();
                    txtWorkID.AutoPostBack = true;
                    workidsearch();
                }

                if (Request.QueryString["CWorkID"] != null && Request.QueryString["CWorkID"] != "0")
                {
                    txtWorkID.Text = Request.QueryString["CWorkID"].ToString();
                    txtWorkID.Focus();
                    txtWorkID.AutoPostBack = true;
                    workidsearch();
                }
                if (Request.QueryString["WorkID"] != null && Request.QueryString["WorkID"] != "0")
                {
                    txtWorkID.Text = Request.QueryString["WorkID"].ToString();
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

        public void GetID()
        {

            try
            {
                int i = 1;
                string select = "select top 1 Akrmank from BudgetMasterGAT_FBC order by Akrmank desc";
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

        public void auditdateset()
        {
            AuditDate.Items.Clear();
            if (txtarthsankalpiyyear.Text != "")
            {
                AuditDate.Items.Add(txtarthsankalpiyyear.Text);
            }
            SqlDataAdapter sda = new SqlDataAdapter("select Arthsankalpiyyear from GAT_FBCProvision where WorkID=N'" + txtWorkID.Text.Trim() + "'", con);
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
                SqlDataAdapter sda1 = new SqlDataAdapter("select Arthsankalpiyyear from BudgetMasterGAT_FBC where WorkID=N'" + txtWorkID.Text.Trim() + "'", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                foreach (DataRow dr in dt.Rows)
                {
                    AuditDate.Items.Add(dr["Arthsankalpiyyear"].ToString());
                }

            }

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
        protected void ddlThekedarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblThekedarMobNo.Text = ddlThekedarName.SelectedItem.Value.Split(':')[0];
        }
        protected void ddlabhiyanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtabhiyantamobile.Text = ddlabhiyanta.SelectedItem.Value.Split(':')[0];
        }

        protected void ddlupabhiyanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtupabhiyantamobile.Text = ddlupabhiyanta.SelectedItem.Value.Split(':')[0];
        }

        protected void ddllekhashirsh_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLekhaName.Text = ddllekhashirsh.SelectedItem.Value;
            lblLekhaName.ForeColor = lblLekhaName.Text.Trim() == "लेखाशीर्ष निवडा" ? Color.Red : Color.Black;
        }

        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    ddltaluka.Items.Clear();
            //    ddltaluka.Items.Add(" ");
            //    SqlDataAdapter sda = new SqlDataAdapter("select Taluka from SettingTaluka where Jilha=N'" + ddldist.SelectedItem.Text + "'", con);
            //    DataTable dt = new DataTable();
            //    sda.Fill(dt);
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        ddltaluka.Items.Add(dr["Taluka"].ToString());
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
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


            msg = "Welcome to PWD East Pune\n Scheme Name: Budget " + ddlyojna.Text + " \n Work Name:" + txtkamachenav.Text + "\n  Lekhashirsh:" + ddllekhashirsh.Text + " \n Website:http://www.eepwdeastpunebudget.com \n Help:info@eepwdeastpunebudget.com";
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
                //In this Method Passing 2 parameter one is StoredProcedure Name, and second is WorkId 
                //                    Feach_Master_Data("StoredProcedure Name" , "WorkId")
                dt = ObjsqlQueryOrCon.Feach_Master_Data("Gat_FBC", txtWorkID.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    txtarthsankalpiyyear.Text = "";
                    auditdateset();
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtarthsankalpiyyear.Text = dr["Arthsankalpiyyear"].ToString();
                        lblId.Text = dr["Akrmank"].ToString();
                        ddlyojna.SelectedItem.Text = dr["Type"].ToString();
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
                        txtkamachavav.Text = dr["Kamachevav"].ToString();
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
                        txtJobNumber.Text = dr["GJobKramank"].ToString();
                        txtRoadNumber.Text = dr["GRoadKramank"].ToString();
                        ddlprushthbhag.SelectedItem.Text = dr["GRoadPrushthbhag"].ToString();
                        txtRoll.Text = dr["GRoll"].ToString();
                        txtLengthStarted.Text = dr["GlengthStarted"].ToString();
                        txtLengthUpto.Text = dr["GlengthUpto"].ToString();
                        txtLengthTotal.Text = dr["GlengthTotal"].ToString();
                        txtNewKhadikaran.Text = dr["GNewKhadikaran"].ToString();
                        txtBMC.Text = dr["GBM_Carpet"].ToString();
                        txt20MM.Text = dr["G20_MM"].ToString();
                        txtSurface.Text = dr["GSurface"].ToString();
                        txtRundikaran.Text = dr["GRundikaran"].ToString();
                        txtBridge_Morya.Text = dr["GBridge_Morya"].ToString();
                        txtRepair.Text = dr["GRepairExpn"].ToString();
                        txtanya.Text = dr["GAnya"].ToString();
                        ddlsadyasthiti.SelectedIndex = ddlsadyasthiti.Items.IndexOf(ddlsadyasthiti.Items.FindByText(dr["Sadyasthiti"].ToString()));
                        txtpahnikramank.Text = dr["Pahanikramank"].ToString();
                        txtpahnimudye.Text = dr["PahaniMudye"].ToString();
                        txtshera.Text = dr["Shera"].ToString();
                    }
                }
                else
                {
                    txtarthsankalpiyyear.Text = "";
                    ddlyojna.SelectedIndex = 0;
                    //ddldist.SelectedIndex = 0;
                    ddltaluka.SelectedIndex = 0;
                    txtarthsankalpiybab.Text = 0.ToString();
                    ddlupvibhag.SelectedIndex = 0;
                    ddllekhashirsh.SelectedIndex = 0;
                    lblLekhaName.Text = "";
                    ddlsubtype.SelectedIndex = 0;
                    ddlabhiyanta.SelectedIndex = 0;
                    txtabhiyantamobile.Text = 0.ToString();
                    ddlupabhiyanta.SelectedIndex = 0;
                    txtupabhiyantamobile.Text = 0.ToString();
                    ddlkhasdarachename.SelectedIndex = 0;
                    ddlaamdarachename.SelectedIndex = 0;
                    txtkamachenav.Text = "";
                    txtkamachavav.Text = "";
                    txtprashaskiykramank.Text = 0.ToString();
                    txtprashaskiydinak.Text = 0.ToString();
                    txtprashaskiykimat.Text = 0.ToString();
                    txttantrikkramank.Text = 0.ToString();
                    txttantarikdinak.Text = 0.ToString();
                    txttantarikkimat.Text = 0.ToString();
                    ddlThekedarName.SelectedIndex = 0;
                    lblThekedarMobNo.Text = 0.ToString();
                    txtNividaKramank.Text = 0.ToString();
                    txtNividaKimat.Text = 0.ToString();
                    txtkaryarambhaadesh.Text = 0.ToString();
                    txtkaryarambhdinak.Text = 0.ToString();
                    txtkamachimudat.Text = 0.ToString();
                    txtkampurndinak.Text = 0.ToString();
                    txtJobNumber.Text = 0.ToString();
                    txtRoadNumber.Text = 0.ToString();
                    ddlprushthbhag.SelectedIndex = 0;
                    txtRoll.Text = 0.ToString();
                    txtLengthStarted.Text = 0.ToString();
                    txtLengthUpto.Text = 0.ToString();
                    txtLengthTotal.Text = 0.ToString();
                    txtNewKhadikaran.Text = 0.ToString();
                    txtBMC.Text = 0.ToString();
                    txt20MM.Text = 0.ToString();
                    txtSurface.Text = 0.ToString();
                    txtRundikaran.Text = 0.ToString();
                    txtBridge_Morya.Text = 0.ToString();
                    txtRepair.Text = 0.ToString();
                    txtanya.Text = 0.ToString();
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
        {
            return ObjsqlQueryOrCon.GetCompletionListOfWorkID(prefixText, "Gat_FBC");
        }
        protected void txtWorkID_TextChanged(object sender, EventArgs e)
        {
            //GetID();
            //fetchName();
            //akunanudan();
            //lekhashirsh();
            //upvibhag();
            //Type();
            //VarishtType();
            //Jilha();
            //UpAbhyanta();
            //Abhyanta();
            //Khasdar();
            //Amdar();
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
            txtvidyutamt.Text = ConvertDigits(txtvidyutamt.Text);
            txtvidyatexpen.Text = ConvertDigits(txtvidyatexpen.Text);
            txtitarkhrch.Text = ConvertDigits(txtitarkhrch.Text);

            if (txtchalukharch.Text != "" && txtmagilkharch.Text != "")
            {
                txtvarshbharatilkharch.Text = (Convert.ToDecimal(txtchalukharch.Text) + Convert.ToDecimal(txtmagilkharch.Text)).ToString();
            }
            if (txtmarchakherkharch.Text != "" && txtvidyutamt.Text != "" && txtvidyatexpen.Text != "" && txtitarkhrch.Text != "")
            {
                txtaikunkharch.Text = (Convert.ToDecimal(txtmarchakherkharch.Text) + Convert.ToDecimal(txtvarshbharatilkharch.Text) + Convert.ToDecimal(txtvidyutamt.Text) + Convert.ToDecimal(txtvidyatexpen.Text) + Convert.ToDecimal(txtitarkhrch.Text)).ToString();
            }

        }

        protected void txtVidyutprama_TextChanged(object sender, EventArgs e)
        {
            txtvidyutamt.Text = ConvertDigits(txtvidyutamt.Text);
            totalkharch();
        }
        protected void txtVidyutvitarit_TextChanged(object sender, EventArgs e)
        {
            txtvidyatexpen.Text = ConvertDigits(txtvidyatexpen.Text);
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

            txtmarchakherkharch.Text = ConvertDigits(txtmarchakherkharch.Text);
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
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from GAT_FBCProvision where Arthsankalpiyyear=N'" + AuditDate.Text.Trim() + "' and Workid=N'" + txtWorkID.Text.Trim() + "'", con);
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
                    txtvidyutamt.Enabled = true;
                    txtvidyatexpen.Enabled = true;
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

                    //FBC
                    txtJobNumber.Enabled = true;
                    txtRoadNumber.Enabled = true;
                    ddlprushthbhag.Enabled = true;
                    txtRoll.Enabled = true;
                    txtLengthStarted.Enabled = true;
                    txtLengthUpto.Enabled = true;
                    txtLengthTotal.Enabled = true;
                    txtNewKhadikaran.Enabled = true;
                    txtBMC.Enabled = true;
                    txt20MM.Enabled = true;
                    txtSurface.Enabled = true;
                    txtRundikaran.Enabled = true;
                    txtBridge_Morya.Enabled = true;
                    txtRepair.Enabled = true;
                    txtanya.Enabled = true;
                    txtNewKhadikaran.Enabled = true;
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
                    txtitarkhrch.Enabled = false;
                    ddlsadyasthiti.Enabled = false;
                    txtpahnikramank.Enabled = false;
                    txtdnyapane.Enabled = false;
                    txtpahnimudye.Enabled = false;
                    txtshera.Enabled = false;
                    txtvidyutamt.Enabled = false;
                    txtvidyatexpen.Enabled = false;
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

                    //FBC
                    txtJobNumber.Enabled = false;
                    txtRoadNumber.Enabled = false;
                    ddlprushthbhag.Enabled = false;
                    txtRoll.Enabled = false;
                    txtLengthStarted.Enabled = false;
                    txtLengthUpto.Enabled = false;
                    txtLengthTotal.Enabled = false;
                    txtNewKhadikaran.Enabled = false;
                    txtBMC.Enabled = false;
                    txt20MM.Enabled = false;
                    txtSurface.Enabled = false;
                    txtRundikaran.Enabled = false;
                    txtBridge_Morya.Enabled = false;
                    txtRepair.Enabled = false;
                    txtanya.Enabled = false;
                    txtNewKhadikaran.Enabled = false;
                }
            }
        }
        public void fetchdate()
        {

            DataTable dt = new DataTable();
            dt = ObjsqlQueryOrCon.FeachProvisionData("Gat_FBC", AuditDate.Text.Trim(), txtWorkID.Text.Trim());


            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtmudatvadhdinak.Text = dr["MudatVadhiDate"].ToString();
                    txtcost.Text = dr["KamachiKimat"].ToString();
                    txtmarchakherkharch.Text = dr["MarchEndingExpn"].ToString();
                    txturvaritamt.Text = dr["UrvaritAmt"].ToString();
                    Billpayment.Text = dr["Sadyasthiti"].ToString();
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
                    txtvidyutamt.Text = dr["VidyutikaranAmt"].ToString();
                    txtvidyatexpen.Text = dr["VidyutikaranExpen"].ToString();
                    txtdnyapane.Text = dr["Dviguni"].ToString();
                    txtitarkhrch.Text = dr["Itarkhrch"].ToString();
                }
            }
            if (dt.Rows.Count == 0)
            {
                txtmudatvadhdinak.Text = 0.ToString();
                txtcost.Text = 0.ToString();
                txtmarchakherkharch.Text = 0.ToString();
                txturvaritamt.Text = 0.ToString();
                Billpayment.Text = 0.ToString();
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
                txtvidyutamt.Text = 0.ToString();
                txtvidyatexpen.Text = 0.ToString();
                txtdnyapane.Text = 0.ToString();
                txtitarkhrch.Text = 0.ToString();
            }
        }
        protected void txtsecurity_TextChanged(object sender, EventArgs e)
        {
            if (AuditDate.SelectedIndex != -1)
            {
                if (txtsecurity.Text == FormPassword.ToString())
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
                    txtvidyutamt.Enabled = true;
                    txtvidyatexpen.Enabled = true;
                    txtitarkhrch.Enabled = true;
                    ddlsadyasthiti.Enabled = true;
                    txtpahnikramank.Enabled = true;
                    txtdnyapane.Enabled = true;
                    txtpahnimudye.Enabled = true;
                    txtshera.Enabled = true;
                    txtvidyutamt.Enabled = true;
                    txtvidyatexpen.Enabled = true;
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
                    txtvidyutamt.Enabled = false;
                    txtvidyatexpen.Enabled = false;
                    txtitarkhrch.Enabled = false;
                    ddlsadyasthiti.Enabled = false;
                    txtpahnikramank.Enabled = false;
                    txtdnyapane.Enabled = false;
                    txtpahnimudye.Enabled = false;
                    txtshera.Enabled = false;
                    txtvidyutamt.Enabled = false;
                    txtvidyatexpen.Enabled = false;
                }
            }
        }

        protected void BtnSav_Click(object sender, EventArgs e)
        {
            try
            {
                txtarthsankalpiybab.Text = ConvertDigits(txtarthsankalpiybab.Text);
                txtkamachenav.Text = ConvertDigits(txtkamachenav.Text);
                txtkamachavav.Text = ConvertDigits(txtkamachavav.Text);
                txtprashaskiykramank.Text = ConvertDigits(txtprashaskiykramank.Text);
                txtprashaskiydinak.Text = ConvertDigits(txtprashaskiydinak.Text);
                txtprashaskiykimat.Text = ConvertDigits(txtprashaskiykimat.Text);
                txttantrikkramank.Text = ConvertDigits(txttantrikkramank.Text);
                txttantarikdinak.Text = ConvertDigits(txttantarikdinak.Text);
                txttantarikkimat.Text = ConvertDigits(txttantarikkimat.Text);
                txtNividaKramank.Text = ConvertDigits(txtNividaKramank.Text);
                txtNividaKimat.Text = ConvertDigits(txtNividaKimat.Text);
                txtkaryarambhaadesh.Text = ConvertDigits(txtkaryarambhaadesh.Text);
                txtJobNumber.Text = ConvertDigits(txtJobNumber.Text);
                txtRoadNumber.Text = ConvertDigits(txtRoadNumber.Text);
                txtRoll.Text = ConvertDigits(txtRoll.Text);
                txtLengthStarted.Text = ConvertDigits(txtLengthStarted.Text);
                txtLengthUpto.Text = ConvertDigits(txtLengthUpto.Text);
                txtLengthTotal.Text = ConvertDigits(txtLengthTotal.Text);
                txtNewKhadikaran.Text = ConvertDigits(txtNewKhadikaran.Text);
                txtBMC.Text = ConvertDigits(txtBMC.Text);
                txt20MM.Text = ConvertDigits(txt20MM.Text);
                txtSurface.Text = ConvertDigits(txtSurface.Text);
                txtRundikaran.Text = ConvertDigits(txtRundikaran.Text);
                txtBridge_Morya.Text = ConvertDigits(txtBridge_Morya.Text);
                txtRepair.Text = ConvertDigits(txtRepair.Text);
                txtanya.Text = ConvertDigits(txtanya.Text);
                txtmudatvadhdinak.Text = ConvertDigits(txtmudatvadhdinak.Text);
                Billpayment.Text = ConvertDigits(Billpayment.Text);
                txtmagni.Text = ConvertDigits(txtmagni.Text);
                txtpahnikramank.Text = ConvertDigits(txtpahnikramank.Text);
                txtpahnimudye.Text = ConvertDigits(txtpahnimudye.Text);
                txtdnyapane.Text = ConvertDigits(txtdnyapane.Text);
                txtshera.Text = ConvertDigits(txtshera.Text);

                string a = "", b = "", c = "";
                GetID();
                if (con.State != ConnectionState.Open)
                    con.Open();
                if (conMDB.State != ConnectionState.Open)
                    conMDB.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from BudgetMasterGAT_FBC WHERE WorkId='" + txtWorkID.Text.Trim() + "'", con);
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
                        string strMasterInsertQuery = "INSERT INTO [BudgetMasterGAT_FBC] ([WorkId],[Arthsankalpiyyear],[Akrmank],[Type],[Dist],[Taluka],[ArthsankalpiyBab],[Upvibhag],[LekhaShirsh],[LekhaShirshName],[SubType],[ShakhaAbhyantaName],[ShakhaAbhiyantMobile],[UpabhyantaName],[UpAbhiyantaMobile],[KhasdaracheName],[AmdaracheName],[KamacheName],[Kamachevav],[PrashaskiyKramank],[PrashaskiyDate],[PrashaskiyAmt],[TrantrikKrmank],[TrantrikDate],[TrantrikAmt],[ThekedaarName],[ThekedarMobile],[NividaKrmank],[NividaAmt],[karyarambhadesh],[NividaDate],[kamachiMudat],[KamPurnDate],[GJobKramank],[GRoadKramank],[GRoadPrushthbhag],[GRoll],[GlengthStarted],[GlengthUpto],[GlengthTotal],[GNewKhadikaran],[GBM_Carpet],[G20_MM],[GSurface],[GRundikaran],[GBridge_Morya],[GRepairExpn],[GAnya],[Sadyasthiti],[Pahanikramank],[PahaniMudye],[Shera],[Img1],[Img2],[Img3],[SubDivision]) VALUES(N'" + txtWorkID.Text.Trim() + "',N'" + txtarthsankalpiyyear.Text + "',N'" + Convert.ToInt32(lblId.Text) + "',N'" + ddlyojna.SelectedItem.Text + "',N'" + ddldist.SelectedItem.Text + "', N'" + ddltaluka.SelectedItem.Text + "',N'" + txtarthsankalpiybab.Text + "',N'" + ddlupvibhag.SelectedItem.Text + "', N'" + ddllekhashirsh.SelectedItem.Text + "',N'" + lblLekhaName.Text + "',N'" + ddlsubtype.SelectedItem.Text + "',N'" + ddlabhiyanta.SelectedItem.Text + "',N'" + txtabhiyantamobile.Text + "',N'" + ddlupabhiyanta.SelectedItem.Text + "',N'" + txtupabhiyantamobile.Text + "',N'" + ddlkhasdarachename.SelectedItem.Text + "',N'" + ddlaamdarachename.SelectedItem.Text + "',N'" + txtkamachenav.Text + "',N'" + txtkamachavav.Text + "',N'" + txtprashaskiykramank.Text + "',N'" + txtprashaskiydinak.Text + "',N'" + txtprashaskiykimat.Text + "',N'" + txttantrikkramank.Text + "',N'" + txttantarikdinak.Text + "',N'" + txttantarikkimat.Text + "',N'" + ddlThekedarName.SelectedItem.Text + "',N'" + lblThekedarMobNo.Text + "',N'" + txtNividaKramank.Text + "',N'" + txtNividaKimat.Text + "',N'" + txtkaryarambhaadesh.Text + "',N'" + txtkaryarambhdinak.Text + "',N'" + txtkamachimudat.Text + "',N'" + txtkampurndinak.Text + "',N'" + txtJobNumber.Text + "',N'" + txtRoadNumber.Text + "',N'" + ddlprushthbhag.SelectedItem.Text + "',N'" + txtRoll.Text + "',N'" + txtLengthStarted.Text + "',N'" + txtLengthUpto.Text + "',N'" + txtLengthTotal.Text + "',N'" + Convert.ToDecimal(txtNewKhadikaran.Text) + "',N'" + Convert.ToDecimal(txtBMC.Text) + "',N'" + Convert.ToDecimal(txt20MM.Text) + "',N'" + Convert.ToDecimal(txtSurface.Text) + "',N'" + Convert.ToDecimal(txtRundikaran.Text) + "',N'" + Convert.ToDecimal(txtBridge_Morya.Text) + "',N'" + Convert.ToDecimal(txtRepair.Text) + "',N'" + Convert.ToDecimal(txtanya.Text) + "',N'" + ddlsadyasthiti.SelectedItem.Text + "',N'" + txtpahnikramank.Text + "',N'" + txtpahnimudye.Text + "',N'" + txtshera.Text + "',N'" + a + "',N'" + b + "',N'" + c + "','PuneEast')";
                        string strProvisionInsertQuery = "INSERT INTO [GAT_FBCProvision] ([WorkId],[Arthsankalpiyyear],[MudatVadhiDate],[KamachiKimat],[MarchEndingExpn],[UrvaritAmt],[Sadyasthiti],[DTakunone],[Takunone],[DTakuntwo],[Takuntwo],[DTakunthree],[Takunthree],[DTakunfour],[Takunfour],[Tartud],[Jan],[Feb],[Mar],[Apr],[May],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec],[AkunAnudan],[Chalumonth],[Chalukharch],[Magilmonth],[Magilkharch],[VidyutikaranAmt],[VidyutikaranExpen],[Magni],[VarshbharatilKharch],[AikunKharch],[Dviguni],[Itarkhrch],[SubDivision]) VALUES('" + txtWorkID.Text.Trim() + "','" + txtarthsankalpiyyear.Text + "',N'" + txtmudatvadhdinak.Text + "',N'" + Convert.ToDecimal(txtcost.Text) + "',N'" + Convert.ToDecimal(txtmarchakherkharch.Text) + "',N'" + Convert.ToDecimal(txturvaritamt.Text) + "',N'" + Billpayment.Text + "',N'" + ddlakun1.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun1.Text) + "', N'" + ddlakun2.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun2.Text) + "',N'" + ddlakun3.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun3.Text) + "',N'" + ddlakun4.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun4.Text) + "',N'" + Convert.ToDecimal(txttartud.Text) + "',N'" + Convert.ToDecimal(txtjan.Text) + "',N'" + Convert.ToDecimal(txtfeb.Text) + "',N'" + Convert.ToDecimal(txtmar.Text) + "',N'" + Convert.ToDecimal(txtapr.Text) + "',N'" + Convert.ToDecimal(txtmay.Text) + "',N'" + Convert.ToDecimal(txtjun.Text) + "',N'" + Convert.ToDecimal(txtjul.Text) + "',N'" + Convert.ToDecimal(txtaug.Text) + "',N'" + Convert.ToDecimal(txtsep.Text) + "',N'" + Convert.ToDecimal(txtoct.Text) + "',N'" + Convert.ToDecimal(txtnov.Text) + "',N'" + Convert.ToDecimal(txtdec.Text) + "',N'" + Convert.ToDecimal(txtaikunanudan.Text) + "',N'" + ddlchalukharch.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtchalukharch.Text) + "',N'" + ddlmagilmonth.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtmagilkharch.Text) + "',N'" + Convert.ToDecimal(txtvidyutamt.Text) + "',N'" + Convert.ToDecimal(txtvidyatexpen.Text) + "',N'" + Convert.ToDecimal(txtmagni.Text) + "',N'" + Convert.ToDecimal(txtvarshbharatilkharch.Text) + "',N'" + Convert.ToDecimal(txtaikunkharch.Text) + "',N'" + txtdnyapane.Text + "',N'" + Convert.ToDecimal(txtitarkhrch.Text) + "','PuneEast')";
                        cmd = new SqlCommand(strMasterInsertQuery, con);
                        cmd1 = new SqlCommand(strProvisionInsertQuery, con);

                        cmdMDB = new SqlCommand(strMasterInsertQuery, conMDB);
                        cmdMDB1 = new SqlCommand(strProvisionInsertQuery, conMDB);
                        strCommandType = "Inserted";
                    }
                    else
                    {
                        SqlDataAdapter sda1 = new SqlDataAdapter("select Count(*) from GAT_FBCProvision where Arthsankalpiyyear=N'" + AuditDate.Text.Trim() + "' and WorkId=N'" + txtWorkID.Text.Trim() + "'", con);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            string strMasterUpdateQuery = "UPDATE BudgetMasterGAT_FBC SET [Type]=N'" + ddlyojna.SelectedItem.Text + "',[Dist]=N'" + ddldist.SelectedItem.Text + "',[Taluka]=N'" + ddltaluka.SelectedItem.Text + "',[ArthsankalpiyBab]=N'" + txtarthsankalpiybab.Text + "',[Upvibhag]=N'" + ddlupvibhag.SelectedItem.Text + "',[LekhaShirsh]=N'" + ddllekhashirsh.Text + "',[LekhaShirshName]=N'" + lblLekhaName.Text + "',[SubType]=N'" + ddlsubtype.SelectedItem.Text + "',[ShakhaAbhyantaName]=N'" + ddlabhiyanta.SelectedItem.Text + "',[ShakhaAbhiyantMobile]=N'" + txtabhiyantamobile.Text + "',[UpabhyantaName]=N'" + ddlupabhiyanta.SelectedItem.Text + "',[UpAbhiyantaMobile]=N'" + txtupabhiyantamobile.Text + "',[KhasdaracheName]=N'" + ddlkhasdarachename.SelectedItem.Text + "',[AmdaracheName]=N'" + ddlaamdarachename.SelectedItem.Text + "',[KamacheName]=N'" + txtkamachenav.Text + "',[Kamachevav]=N'" + txtkamachavav.Text + "',[PrashaskiyKramank]=N'" + txtprashaskiykramank.Text + "',[PrashaskiyDate]=N'" + txtprashaskiydinak.Text + "',[PrashaskiyAmt]=N'" + Convert.ToDecimal(txtprashaskiykimat.Text) + "',[TrantrikKrmank]=N'" + txttantrikkramank.Text + "',[TrantrikDate]=N'" + txttantarikdinak.Text + "',[TrantrikAmt]=N'" + Convert.ToDecimal(txttantarikkimat.Text) + "',[ThekedaarName]=N'" + ddlThekedarName.SelectedItem.Text + "',[ThekedarMobile]=N'" + lblThekedarMobNo.Text + "',[NividaKrmank]=N'" + txtNividaKramank.Text + "',[NividaAmt]=N'" + Convert.ToDecimal(txtNividaKimat.Text) + "',[karyarambhadesh]=N'" + txtkaryarambhaadesh.Text + "',[NividaDate]=N'" + txtkaryarambhdinak.Text + "',[kamachiMudat]=N'" + txtkamachimudat.Text + "',[KamPurnDate]=N'" + txtkampurndinak.Text + "',[GJobKramank]=N'" + txtJobNumber.Text + "',[GRoadKramank]=N'" + txtRoadNumber.Text + "',[GRoadPrushthbhag]=N'" + ddlprushthbhag.SelectedItem.Text + "',[GRoll]=N'" + txtRoll.Text + "',[GlengthStarted]=N'" + txtLengthStarted.Text + "',[GlengthUpto]=N'" + txtLengthUpto.Text + "',[GlengthTotal]=N'" + txtLengthTotal.Text + "',[GNewKhadikaran]=N'" + Convert.ToDecimal(txtNewKhadikaran.Text) + "',[GBM_Carpet]=N'" + Convert.ToDecimal(txtBMC.Text) + "',[G20_MM]=N'" + Convert.ToDecimal(txt20MM.Text) + "',[GSurface]=N'" + Convert.ToDecimal(txtSurface.Text) + "',[GRundikaran]=N'" + Convert.ToDecimal(txtRundikaran.Text) + "',[GBridge_Morya]=N'" + Convert.ToDecimal(txtBridge_Morya.Text) + "',[GRepairExpn]=N'" + Convert.ToDecimal(txtRepair.Text) + "',[GAnya]=N'" + Convert.ToDecimal(txtanya.Text) + "',[Sadyasthiti]=N'" + ddlsadyasthiti.SelectedItem.Text + "',[Pahanikramank]=N'" + txtpahnikramank.Text + "',[PahaniMudye]=N'" + txtpahnikramank.Text + "',[Shera]=N'" + txtshera.Text + "' WHERE WorkId=N'" + txtWorkID.Text.Trim() + "' and [SubDivision]='PuneEast'";
                            cmd = new SqlCommand(strMasterUpdateQuery, con);
                            cmdMDB = new SqlCommand(strMasterUpdateQuery, conMDB);

                            if (dr1[0].ToString() == 0.ToString())
                            {
                                string strMasterInsertQuery = "INSERT INTO [GAT_FBCProvision] ([WorkId],[Arthsankalpiyyear],[MudatVadhiDate],[KamachiKimat],[MarchEndingExpn],[UrvaritAmt],[Sadyasthiti],[DTakunone],[Takunone],[DTakuntwo],[Takuntwo],[DTakunthree],[Takunthree],[DTakunfour],[Takunfour],[Tartud],[Jan],[Feb],[Mar],[Apr],[May],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec],[AkunAnudan],[Chalumonth],[Chalukharch],[Magilmonth],[Magilkharch],[VidyutikaranAmt],[VidyutikaranExpen],[Magni],[VarshbharatilKharch],[AikunKharch],[Dviguni],[Itarkhrch],[SubDivision]) VALUES('" + txtWorkID.Text.Trim() + "','" + txtarthsankalpiyyear.Text + "',N'" + txtmudatvadhdinak.Text + "',N'" + Convert.ToDecimal(txtcost.Text) + "',N'" + Convert.ToDecimal(txtmarchakherkharch.Text) + "',N'" + Convert.ToDecimal(txturvaritamt.Text) + "',N'" + Billpayment.Text + "',N'" + ddlakun1.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun1.Text) + "', N'" + ddlakun2.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun2.Text) + "',N'" + ddlakun3.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun3.Text) + "',N'" + ddlakun4.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtakun4.Text) + "',N'" + Convert.ToDecimal(txttartud.Text) + "',N'" + Convert.ToDecimal(txtjan.Text) + "',N'" + Convert.ToDecimal(txtfeb.Text) + "',N'" + Convert.ToDecimal(txtmar.Text) + "',N'" + Convert.ToDecimal(txtapr.Text) + "',N'" + Convert.ToDecimal(txtmay.Text) + "',N'" + Convert.ToDecimal(txtjun.Text) + "',N'" + Convert.ToDecimal(txtjul.Text) + "',N'" + Convert.ToDecimal(txtaug.Text) + "',N'" + Convert.ToDecimal(txtsep.Text) + "',N'" + Convert.ToDecimal(txtoct.Text) + "',N'" + Convert.ToDecimal(txtnov.Text) + "',N'" + Convert.ToDecimal(txtdec.Text) + "',N'" + Convert.ToDecimal(txtaikunanudan.Text) + "',N'" + ddlchalukharch.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtchalukharch.Text) + "',N'" + ddlmagilmonth.SelectedItem.Text + "',N'" + Convert.ToDecimal(txtmagilkharch.Text) + "',N'" + Convert.ToDecimal(txtvidyutamt.Text) + "',N'" + Convert.ToDecimal(txtvidyatexpen.Text) + "',N'" + Convert.ToDecimal(txtmagni.Text) + "',N'" + Convert.ToDecimal(txtvarshbharatilkharch.Text) + "',N'" + Convert.ToDecimal(txtaikunkharch.Text) + "',N'" + txtdnyapane.Text + "',N'" + Convert.ToDecimal(txtitarkhrch.Text) + "','PuneEast')";
                                cmd1 = new SqlCommand(strMasterInsertQuery, con);
                                cmdMDB1 = new SqlCommand(strMasterInsertQuery, conMDB);
                            }
                            else
                            {
                                strMasterUpdateQuery = "UPDATE [GAT_FBCProvision] SET [MudatVadhiDate]=N'" + txtmudatvadhdinak.Text + "',[KamachiKimat]=N'" + txtkamachimudat.Text + "',[MarchEndingExpn]=N'" + Convert.ToDecimal(txtmarchakherkharch.Text) + "',[UrvaritAmt]=N'" + Convert.ToDecimal(txturvaritamt.Text) + "',[Sadyasthiti]=N'" + Billpayment.Text + "',[DTakunone]=N'" + ddlakun1.SelectedItem.Text + "',[Takunone]=N'" + Convert.ToDecimal(txtakun1.Text) + "',[DTakuntwo]=N'" + ddlakun2.SelectedItem.Text + "',[Takuntwo]=N'" + Convert.ToDecimal(txtakun2.Text) + "',[DTakunthree]=N'" + ddlakun3.SelectedItem.Text + "',[Takunthree]=N'" + Convert.ToDecimal(txtakun3.Text) + "',[DTakunfour]=N'" + ddlakun4.SelectedItem.Text + "',[Takunfour]=N'" + Convert.ToDecimal(txtakun4.Text) + "',[Tartud]=N'" + Convert.ToDecimal(txttartud.Text) + "',[Jan]=N'" + Convert.ToDecimal(txtjan.Text) + "',[Feb]=N'" + Convert.ToDecimal(txtfeb.Text) + "',[Mar]=N'" + Convert.ToDecimal(txtmar.Text) + "',[Apr]=N'" + Convert.ToDecimal(txtapr.Text) + "',[May]=N'" + Convert.ToDecimal(txtmay.Text) + "',[Jun]=N'" + Convert.ToDecimal(txtjun.Text) + "',[Jul]=N'" + Convert.ToDecimal(txtjul.Text) + "',[Aug]=N'" + Convert.ToDecimal(txtaug.Text) + "',[Sep]=N'" + Convert.ToDecimal(txtsep.Text) + "',[Oct]=N'" + Convert.ToDecimal(txtoct.Text) + "',[Nov]=N'" + Convert.ToDecimal(txtnov.Text) + "',[Dec]=N'" + Convert.ToDecimal(txtdec.Text) + "',[AkunAnudan]=N'" + Convert.ToDecimal(txtaikunanudan.Text) + "',[Chalumonth]=N'" + ddlchalukharch.SelectedItem.Text + "',[Chalukharch]=N'" + Convert.ToDecimal(txtchalukharch.Text) + "',[Magilmonth]=N'" + ddlmagilmonth.SelectedItem.Text + "',[Magilkharch]=N'" + Convert.ToDecimal(txtmagilkharch.Text) + "',[VidyutikaranAmt]=N'" + Convert.ToDecimal(txtvidyutamt.Text) + "',[VidyutikaranExpen]=N'" + Convert.ToDecimal(txtvidyatexpen.Text) + "',[Magni]=N'" + Convert.ToDecimal(txtmagni.Text) + "',[VarshbharatilKharch]=N'" + Convert.ToDecimal(txtvarshbharatilkharch.Text) + "',[AikunKharch]=N'" + Convert.ToDecimal(txtaikunkharch.Text) + "',[Dviguni]=N'" + txtdnyapane.Text + "',[Itarkhrch]=N'" + Convert.ToDecimal(txtitarkhrch.Text) + "' where Arthsankalpiyyear=N'" + AuditDate.Text.Trim() + "' and WorkId=N'" + txtWorkID.Text.Trim() + "' and [SubDivision]='PuneEast'";
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
                        //For SMS Record
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
                        if (Request.QueryString["FWorkID"] != null && Request.QueryString["FWorkID"] != "0")
                        {
                            Response.Redirect("MasterGAT_FReport.aspx", false);
                        }

                        else if (Request.QueryString["BWorkID"] != null && Request.QueryString["BWorkID"] != "0")
                        {
                            Response.Redirect("MasterGAT_BReport.aspx", false);
                        }

                        else if (Request.QueryString["CWorkID"] != null && Request.QueryString["CWorkID"] != "0")
                        {
                            Response.Redirect("MasterGAT_CReport.aspx", false);
                        }

                        else if (Request.QueryString["MWorkID"] != null && Request.QueryString["MWorkID"] != "0")
                        {
                            Response.Redirect("SReport.aspx", false);
                        }
                        else
                        {
                            //Response.Redirect("MasterBudgetMenu.aspx");

                            Response.Write("<script>alert('Record " + strCommandType + " Succesfully..!!!')</script>");
                            Server.Transfer("MasterBudgetGat_FBC.aspx", false);
                            //Response.Redirect(Request.Url.AbsoluteUri);
                            //Response.Redirect("MasterBudgetFBC.aspx");
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
            if (txtPrakalpPassword.Text == FormPassword.ToString())
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
            if (txtnividashakha.Text == FormPassword.ToString())
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

        protected void txtFBCpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtFBCpassword.Text == FormPassword.ToString())
            {

                txtJobNumber.Enabled = true;
                txtRoadNumber.Enabled = true;
                ddlprushthbhag.Enabled = true;
                txtRoll.Enabled = true;
                txtLengthStarted.Enabled = true;
                txtLengthUpto.Enabled = true;
                txtLengthTotal.Enabled = true;
                txtNewKhadikaran.Enabled = true;
                txtBMC.Enabled = true;
                txt20MM.Enabled = true;
                txtSurface.Enabled = true;
                txtRundikaran.Enabled = true;
                txtBridge_Morya.Enabled = true;
                txtRepair.Enabled = true;
                txtanya.Enabled = true;
                txtNewKhadikaran.Enabled = true;

            }
            else
            {
                txtJobNumber.Enabled = false;
                txtRoadNumber.Enabled = false;
                ddlprushthbhag.Enabled = false;
                txtRoll.Enabled = false;
                txtLengthStarted.Enabled = false;
                txtLengthUpto.Enabled = false;
                txtLengthTotal.Enabled = false;
                txtNewKhadikaran.Enabled = false;
                txtBMC.Enabled = false;
                txt20MM.Enabled = false;
                txtSurface.Enabled = false;
                txtRundikaran.Enabled = false;
                txtBridge_Morya.Enabled = false;
                txtRepair.Enabled = false;
                txtanya.Enabled = false;
                txtNewKhadikaran.Enabled = false;
            }
        }
    }
}