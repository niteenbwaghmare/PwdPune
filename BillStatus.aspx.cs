using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PWdEEBudget
{
    public partial class BillStatus : System.Web.UI.Page
    {
        SqlCommand cmd = null;
        SqlConnection cn = null;
        SqlDataReader dr = null;
        string strSqlCommand = string.Empty;
        string ProvisionTbl;
        string MasterTbl;
        string DataTextField;
        string DataValueField;
        string DDLName;
        string TodaysDate = DateTime.Now.Date.ToShortDateString();
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            if (!Page.IsPostBack)
            {
                GetPostDetails();
                GetBillToDDL();
                SetZeroToAmt();
            }
        }

        protected void ddlHeadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBudgetYear.ClearSelection();
            ResetValues();
            SetZeroToAmt();
            GetTablesDetails();
            BindWorkId();
            txtWorkName.Text = string.Empty;

        }

        public void GetTablesDetails()
        {
            switch (ddlHeadType.SelectedItem.Value)
            {
                case "Annuity":
                    MasterTbl = "BudgetMasterAunty";
                    ProvisionTbl = "AuntyProvision";
                    break;
                case "Building":
                    MasterTbl = "BudgetMasterBuilding";
                    ProvisionTbl = "BuildingProvision";
                    break;
                case "CRF":
                    MasterTbl = "BudgetMasterCRF";
                    ProvisionTbl = "CRFProvision";
                    break;
                case "DepositFund":
                    MasterTbl = "BudgetMasterDepositFund";
                    ProvisionTbl = "DepositFundProvision";
                    break;
                case "DPDC":
                    MasterTbl = "BudgetMasterDPDC";
                    ProvisionTbl = "DPDCProvision";
                    break;
                case "Gat_A":
                    MasterTbl = "BudgetMasterGAT_A";
                    ProvisionTbl = "GAT_AProvision";
                    break;
                case "Gat_FBC":
                    MasterTbl = "BudgetMasterGAT_FBC";
                    ProvisionTbl = "GAT_FBCProvision";
                    break;
                case "Gat_D":
                    MasterTbl = "BudgetMasterGAT_D";
                    ProvisionTbl = "GAT_DProvision";
                    break;
                case "Gramvikas(2515)":
                    MasterTbl = "BudgetMaster2515";
                    ProvisionTbl = "[2515Provision]";
                    break;
                case "MLA":
                    MasterTbl = "BudgetMasterMLA";
                    ProvisionTbl = "MLAProvision";
                    break;
                case "MP":
                    MasterTbl = "BudgetMasterMP";
                    ProvisionTbl = "MPProvision";
                    break;
                case "Nabard":
                    MasterTbl = "BudgetMasterNABARD";
                    ProvisionTbl = "NABARDProvision";
                    break;
                case "NonResidentialBuilding(2059)":
                    MasterTbl = "BudgetMasterNonResidentialBuilding";
                    ProvisionTbl = "NonResidentialBuildingProvision";
                    break;
                case "ResidentialBuilding(2216)":
                    MasterTbl = "BudgetMasterResidentialBuilding";
                    ProvisionTbl = "ResidentialBuildingProvision";
                    break;
                case "SH & DOR":
                    MasterTbl = "BudgetMasterRoad";
                    ProvisionTbl = "RoadProvision";
                    break;
            }
        }
        public void SetZeroToAmt()
        {
            if (txtBill1Amt.Text == "")
            {
                txtBill1Amt.Text = "0";
            }
            if (txtBill2Amt.Text == "")
            {
                txtBill2Amt.Text = "0";
            }
            if (txtBill3Amt.Text == "")
            {
                txtBill3Amt.Text = "0";
            }
            if (txtBill4Amt.Text == "")
            {
                txtBill4Amt.Text = "0";
            }
            if (txtBill5Amt.Text == "")
            {
                txtBill5Amt.Text = "0";
            }
            if (txtBill6Amt.Text == "")
            {
                txtBill6Amt.Text = "0";
            }
            if (txtBill7Amt.Text == "")
            {
                txtBill7Amt.Text = "0";
            }
            if (txtBill8Amt.Text == "")
            {
                txtBill8Amt.Text = "0";
            }
            if (txtBill9Amt.Text == "")
            {
                txtBill9Amt.Text = "0";
            }
            if (txtBillFAmt.Text == "")
            {
                txtBillFAmt.Text = "0";
            }
        }
        public void BindWorkId()
        {
            strSqlCommand = "select Distinct WorkId,KamacheName from " + MasterTbl.ToString();
            DataTextField = "WorkId";
            DataValueField = "KamacheName";
            DDLName = "ddlWorkId";
            BindDDL();
        }
        public void GetBillByNameDDL()
        {
            strSqlCommand = "select Name,MobileNo from SCreateAdmin where Post='" + ddlBillByPost.SelectedItem.Text + "'";
            DataTextField = "Name";
            DataValueField = "Name";
            DDLName = "ddlBillByName";
            BindDDL();
            txtBillByNumber.Text = string.Empty;
        }
        public void GetBillToDDL()
        {
            strSqlCommand = "select Name,MobileNo from SCreateAdmin where Post='Contractor'";
            DataTextField = "Name";
            DataValueField = "Name";
            DDLName = "ddlBillTo";
            BindDDL();
            BilToMobileNumber.Text = string.Empty;
        }
        private void BindDDL()
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmd = new SqlCommand(strSqlCommand, cn);
            dr = cmd.ExecuteReader();
            ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            DropDownList ddlName = (DropDownList)MainContent.FindControl(DDLName);
            ddlName.DataSource = dr;
            ddlName.DataTextField = DataTextField;
            ddlName.DataValueField = DataValueField;
            ddlName.DataBind();
            ddlName.Items.Insert(0, new ListItem("Select", "0"));
            dr.Close();
            cn.Close();
        }
        public void GetPostDetails()
        {
            strSqlCommand = "select Distinct Post from Post";
            DataTextField = "Post";
            DataValueField = "Post";
            DDLName = "ddlBillByPost";
            BindDDL();

        }
        public void GetBudgetYear()
        {
            strSqlCommand = "select Arthsankalpiyyear from " + ProvisionTbl + " where WorkID=N'" + ddlWorkId.SelectedItem.Text + "'";
            DataTextField = "Arthsankalpiyyear";
            DataValueField = "Arthsankalpiyyear";
            DDLName = "ddlBudgetYear";
            BindDDL();

        }
        public void ResetValues()
        {
            txtWorkName.Text = string.Empty;
            txtSanctionDate.Text = string.Empty;
            txtWorkCompleteDate.Text = string.Empty;
            txtAAcost.Text = string.Empty;
            txtExtention.Text = string.Empty;
            txtTotalExpenditure.Text = string.Empty;
            ddlBillTo.ClearSelection();
            BilToMobileNumber.Text = string.Empty;
            ddlBillByPost.ClearSelection();
            ddlBillByName.ClearSelection();
            txtBillByNumber.Text = string.Empty;
            txtBill1Amt.Text = string.Empty;
            txtBill1Date.Text = string.Empty;
            txtBill1To.Text = string.Empty;
            txtBill1By.Text = string.Empty;
            txtBill2Amt.Text = string.Empty;
            txtBill2Date.Text = string.Empty;
            txtBill2To.Text = string.Empty;
            txtBill2By.Text = string.Empty;
            txtBill3Amt.Text = string.Empty;
            txtBill3Date.Text = string.Empty;
            txtBill3To.Text = string.Empty;
            txtBill3By.Text = string.Empty;
            txtBill4Amt.Text = string.Empty;
            txtBill4Date.Text = string.Empty;
            txtBill4To.Text = string.Empty;
            txtBill4By.Text = string.Empty;
            txtBill5Amt.Text = string.Empty;
            txtBill5Date.Text = string.Empty;
            txtBill5To.Text = string.Empty;
            txtBill5By.Text = string.Empty;
            txtBill6Amt.Text = string.Empty;
            txtBill6Date.Text = string.Empty;
            txtBill6To.Text = string.Empty;
            txtBill6By.Text = string.Empty;
            txtBill7Amt.Text = string.Empty;
            txtBill7Date.Text = string.Empty;
            txtBill7To.Text = string.Empty;
            txtBill7By.Text = string.Empty;
            txtBill8Amt.Text = string.Empty;
            txtBill8Date.Text = string.Empty;
            txtBill8To.Text = string.Empty;
            txtBill8By.Text = string.Empty;
            txtBill9Amt.Text = string.Empty;
            txtBill9Date.Text = string.Empty;
            txtBill9To.Text = string.Empty;
            txtBill9By.Text = string.Empty;
            txtBillFAmt.Text = string.Empty;
            txtBillFDate.Text = string.Empty;
            txtBillFTo.Text = string.Empty;
            txtBillFBy.Text = string.Empty;
            txtTotalAmt.Text = string.Empty;
            txtWorkStatus.Text = string.Empty;
        }
        protected void ddlWorkId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetValues();
            SetZeroToAmt();
            txtWorkName.Text = ddlWorkId.SelectedItem.Value;
            GetTablesDetails();
            GetBudgetYear();
        }

        protected void ddlBillByName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtBillByNumber.Text= ddlBillByName.SelectedItem.Value;
            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select MobileNo from SCreateAdmin Where Name=N'" + ddlBillByName.SelectedItem.Text + "'", cn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    txtBillByNumber.Text = dr[0].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        protected void ddlBillByPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBillByNameDDL();
        }

        protected void ddlBillTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BilToMobileNumber.Text = ddlBillTo.SelectedItem.Value;
            try
            {
                if (ddlBillTo.SelectedItem.Text == "Select")
                {
                    BilToMobileNumber.Text = string.Empty;
                    //txtBill1To.Text = string.Empty;
                }
                else
                {
                    if (cn.State != ConnectionState.Open)
                        cn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select MobileNo from SCreateAdmin Where Name=N'" + ddlBillTo.SelectedItem.Text + "'", cn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        BilToMobileNumber.Text = dr[0].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        protected void ddlBudgetYear_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GetTablesDetails();
            try
            {
                if (ddlBudgetYear.SelectedItem.Text == "Select")
                {
                    ResetValues();
                    txtWorkName.Text = ddlWorkId.SelectedItem.Value;
                }
                else
                {
                    ResetValues();
                    txtWorkName.Text = ddlWorkId.SelectedItem.Value;
                    strSqlCommand = "select A.WorkId as WorkId,A.KamacheName as KamacheName,A.ThekedaarName as ThekedaarName,A.ThekedarMobile as ThekedarMobile,A.NividaDate as SanctionDate,A.kamachiMudat as kamachiMudat,A.KamPurnDate as KamPurnDate,B.ManjurAmt as ManjurAmt,B.AikunKharch as AikunKharch,A.Sadyasthiti as Sadyasthiti from " + MasterTbl.ToString() + " as A join " + ProvisionTbl.ToString() + " as B ON  A.WorkId=B.WorkId where  B.Arthsankalpiyyear='" + ddlBudgetYear.SelectedItem.Text + "' and A.WorKId='" + ddlWorkId.SelectedItem.Text + "'";
                    if (cn.State != ConnectionState.Open)
                        cn.Open();
                    cmd = new SqlCommand(strSqlCommand, cn);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            txtSanctionDate.Text = dr["SanctionDate"].ToString();
                            txtExtention.Text = dr["kamachiMudat"].ToString();

                            txtWorkCompleteDate.Text = dr["KamPurnDate"].ToString();
                            txtAAcost.Text = dr["ManjurAmt"].ToString();
                            txtTotalExpenditure.Text = dr["AikunKharch"].ToString();
                            txtWorkStatus.Text = dr["Sadyasthiti"].ToString();
                            string BillTo = dr["ThekedaarName"].ToString();
                            ListItem litem = ddlBillTo.Items.FindByText(BillTo);
                            int IndexId = ddlBillTo.Items.IndexOf(litem);
                            if (litem != null && IndexId != null)
                            {
                                ddlBillTo.SelectedIndex = IndexId;
                            }
                            BilToMobileNumber.Text = dr["ThekedarMobile"].ToString();
                        }

                    }
                    dr.Close();
                    GetDataFromBillStatusTbl();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (ddlBudgetYear.SelectedItem.Text != "Select")
                {
                    dr.Close();
                    cn.Close();
                }
            }
        }
        public void GetDataFromBillStatusTbl()
        {
            ListItem litem = ddlBillByPost.Items.FindByText("Executive Engineer");
            int IndexId = ddlBillByPost.Items.IndexOf(litem);
            if (litem != null && IndexId != null)
            {
                ddlBillByPost.SelectedIndex = IndexId;
                GetBillByNameDDL();
            }
            try
            {
                strSqlCommand = "select [Bill_1] as Bill_1,[Bill_1_Amt] as Bill_1_Amt,[Bill_1_Date] as Bill_1_Date,[Bill_1_To] as Bill_1_To,[Bill_1_By] as Bill_1_By,[Bill_2] as Bill_2,[Bill_2_Amt] as Bill_2_Amt,[Bill_2_Date] as Bill_2_Date,[Bill_2_To] as Bill_2_To,[Bill_2_By] as Bill_2_By,[Bill_3] as Bill_3,[Bill_3_Amt] as Bill_3_Amt,[Bill_3_Date] as Bill_3_Date,[Bill_3_To] as Bill_3_To,[Bill_3_By] as Bill_3_By,[Bill_4] as Bill_4,[Bill_4_Amt] as Bill_4_Amt,[Bill_4_Date] as Bill_4_Date,[Bill_4_To] as Bill_4_To,[Bill_4_By] as Bill_4_By,[Bill_5] as Bill_5,[Bill_5_Amt] as Bill_5_Amt,[Bill_5_Date] as Bill_5_Date,[Bill_5_To] as Bill_5_To,[Bill_5_By] as Bill_5_By,[Bill_6] as Bill_6,[Bill_6_Amt] as Bill_6_Amt,[Bill_6_Date] as Bill_6_Date,[Bill_6_To] as Bill_6_To,[Bill_6_By] as Bill_6_By,[Bill_7] as Bill_7,[Bill_7_Amt] as Bill_7_Amt,[Bill_7_Date] as Bill_7_Date,[Bill_7_To] as Bill_7_To,[Bill_7_By] as Bill_7_By,[Bill_8] as Bill_8,[Bill_8_Amt] as Bill_8_Amt,[Bill_8_Date] as Bill_8_Date,[Bill_8_To] as Bill_8_To,[Bill_8_By] as Bill_8_By,[Bill_9] as Bill_9,[Bill_9_Amt] as Bill_9_Amt,[Bill_9_Date] as Bill_9_Date,[Bill_9_To] as Bill_9_To,[Bill_9_By] as Bill_9_By,[Bill_final] as Bill_final,[Bill_final_Amt] as Bill_final_Amt,[Bill_final_Date] as Bill_final_Date,[Bill_final_To] as Bill_final_To,[Bill_final_By] as Bill_final_By,[Bill_Total] as Bill_Total from tbl_Bill_Status where  BudgetYear='" + ddlBudgetYear.SelectedItem.Text + "' and Work_Id='" + ddlWorkId.SelectedItem.Text + "'";
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                cmd = new SqlCommand(strSqlCommand, cn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        txtBill1Amt.Text = dr["Bill_1_Amt"].ToString();
                        txtBill1Date.Text = dr["Bill_1_Date"].ToString();
                        txtBill1To.Text = dr["Bill_1_To"].ToString();
                        txtBill1By.Text = dr["Bill_1_By"].ToString();

                        txtBill2Amt.Text = dr["Bill_2_Amt"].ToString();
                        txtBill2Date.Text = dr["Bill_2_Date"].ToString();
                        txtBill2To.Text = dr["Bill_2_To"].ToString();
                        txtBill2By.Text = dr["Bill_2_By"].ToString();

                        txtBill3Amt.Text = dr["Bill_3_Amt"].ToString();
                        txtBill3Date.Text = dr["Bill_3_Date"].ToString();
                        txtBill3To.Text = dr["Bill_3_To"].ToString();
                        txtBill3By.Text = dr["Bill_3_By"].ToString();

                        txtBill4Amt.Text = dr["Bill_4_Amt"].ToString();
                        txtBill4Date.Text = dr["Bill_4_Date"].ToString();
                        txtBill4To.Text = dr["Bill_4_To"].ToString();
                        txtBill4By.Text = dr["Bill_4_By"].ToString();

                        txtBill5Amt.Text = dr["Bill_5_Amt"].ToString();
                        txtBill5Date.Text = dr["Bill_5_Date"].ToString();
                        txtBill5To.Text = dr["Bill_5_To"].ToString();
                        txtBill5By.Text = dr["Bill_5_By"].ToString();

                        txtBill6Amt.Text = dr["Bill_6_Amt"].ToString();
                        txtBill6Date.Text = dr["Bill_6_Date"].ToString();
                        txtBill6To.Text = dr["Bill_6_To"].ToString();
                        txtBill6By.Text = dr["Bill_6_By"].ToString();

                        txtBill7Amt.Text = dr["Bill_7_Amt"].ToString();
                        txtBill7Date.Text = dr["Bill_7_Date"].ToString();
                        txtBill7To.Text = dr["Bill_7_To"].ToString();
                        txtBill7By.Text = dr["Bill_7_By"].ToString();

                        txtBill8Amt.Text = dr["Bill_8_Amt"].ToString();
                        txtBill8Date.Text = dr["Bill_8_Date"].ToString();
                        txtBill8To.Text = dr["Bill_8_To"].ToString();
                        txtBill8By.Text = dr["Bill_8_By"].ToString();

                        txtBill9Amt.Text = dr["Bill_9_Amt"].ToString();
                        txtBill9Date.Text = dr["Bill_9_Date"].ToString();
                        txtBill9To.Text = dr["Bill_9_To"].ToString();
                        txtBill9By.Text = dr["Bill_9_By"].ToString();

                        txtBillFAmt.Text = dr["Bill_final_Amt"].ToString();
                        txtBillFDate.Text = dr["Bill_final_Date"].ToString();
                        txtBillFTo.Text = dr["Bill_final_To"].ToString();
                        txtBillFBy.Text = dr["Bill_final_By"].ToString();

                        txtTotalAmt.Text = dr["Bill_Total"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public void txt_TextChanged(TextBox txtBillAmt, TextBox txtBillTo, TextBox txtBillBy, TextBox txtBillDate)
        {
            int n;
            double n1;
            string BillAmt = txtBillAmt.Text.Trim();
            bool isNumeric = int.TryParse(BillAmt, out n);
            bool isNumericDouble = double.TryParse(BillAmt, out n1);
            if (isNumericDouble == true)
            {
                if (Convert.ToDecimal(txtBillAmt.Text) > 0)
                {
                    if (ddlBillTo.SelectedItem.Text == "Select")
                    {
                        txtBillTo.Text = string.Empty;
                    }
                    else
                    {
                        txtBillTo.Text = ddlBillTo.SelectedItem.Text + "/" + BilToMobileNumber.Text;
                    }
                    if (ddlBillByName.SelectedItem.Text == "Select")
                    {
                        txtBillBy.Text = string.Empty;
                    }
                    else
                    {
                        txtBillBy.Text = ddlBillByName.SelectedItem.Text + "/" + txtBillByNumber.Text;
                    }
                    txtBillDate.Text = TodaysDate.ToString();
                }
                GetTotalAmt();
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('oops! Character or string Not Allowed.Enter Numeric values only...!')</script>");
            }
        }
        protected void txtBill1Amt_TextChanged(object sender, EventArgs e)
        {
            txt_TextChanged(txtBill1Amt, txtBill1To, txtBill1By, txtBill1Date);
        }
        public void GetTotalAmt()
        {
            SetZeroToAmt();
            if ((Convert.ToDecimal(txtBill1Amt.Text) >= 0) && (Convert.ToDecimal(txtBill2Amt.Text) >= 0) && (Convert.ToDecimal(txtBill3Amt.Text) >= 0) && (Convert.ToDecimal(txtBill4Amt.Text) >= 0) && (Convert.ToDecimal(txtBill5Amt.Text) >= 0) && (Convert.ToDecimal(txtBill6Amt.Text) >= 0) && (Convert.ToDecimal(txtBill7Amt.Text) >= 0) && (Convert.ToDecimal(txtBill8Amt.Text) >= 0) && (Convert.ToDecimal(txtBill9Amt.Text) >= 0) && (Convert.ToDecimal(txtBillFAmt.Text) >= 0))
            {
                txtTotalAmt.Text = (Convert.ToDecimal(txtBill1Amt.Text) + Convert.ToDecimal(txtBill2Amt.Text) + Convert.ToDecimal(txtBill3Amt.Text) + Convert.ToDecimal(txtBill4Amt.Text) + Convert.ToDecimal(txtBill5Amt.Text) + Convert.ToDecimal(txtBill6Amt.Text) + Convert.ToDecimal(txtBill7Amt.Text) + Convert.ToDecimal(txtBill8Amt.Text) + Convert.ToDecimal(txtBill9Amt.Text) + Convert.ToDecimal(txtBillFAmt.Text)).ToString();
            }
        }

        protected void txtBill2Amt_TextChanged(object sender, EventArgs e)
        {
            txt_TextChanged(txtBill2Amt, txtBill2To, txtBill2By, txtBill2Date);
        }

        protected void txtBill3Amt_TextChanged(object sender, EventArgs e)
        {
            txt_TextChanged(txtBill3Amt, txtBill3To, txtBill3By, txtBill3Date);
        }

        protected void txtBill4Amt_TextChanged(object sender, EventArgs e)
        {
            txt_TextChanged(txtBill4Amt, txtBill4To, txtBill4By, txtBill4Date);
        }

        protected void txtBill5Amt_TextChanged(object sender, EventArgs e)
        {
            txt_TextChanged(txtBill5Amt, txtBill5To, txtBill5By, txtBill5Date);
        }

        protected void txtBill6Amt_TextChanged(object sender, EventArgs e)
        {
            txt_TextChanged(txtBill6Amt, txtBill6To, txtBill6By, txtBill6Date);
        }

        protected void txtBill7Amt_TextChanged(object sender, EventArgs e)
        {
            txt_TextChanged(txtBill7Amt, txtBill7To, txtBill7By, txtBill7Date);
        }

        protected void txtBill8Amt_TextChanged(object sender, EventArgs e)
        {
            txt_TextChanged(txtBill8Amt, txtBill8To, txtBill8By, txtBill8Date);
        }

        protected void txtBill9Amt_TextChanged(object sender, EventArgs e)
        {
            txt_TextChanged(txtBill9Amt, txtBill9To, txtBill9By, txtBill9Date);
        }

        protected void txtBillFAmt_TextChanged(object sender, EventArgs e)
        {
            txt_TextChanged(txtBillFAmt, txtBillFTo, txtBillFBy, txtBillFDate);
        }
        public static string ConvertDigits(string s)
        {
            return s
                .Replace("०", "0")
                .Replace("१", "1")
                .Replace("२", "2")
                .Replace("३", "3")
                .Replace("४", "4")
                .Replace("५", "5")
                .Replace("६", "6")
                .Replace("७", "7")
                .Replace("८", "8")
                .Replace("९", "9");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                txtAAcost.Text = ConvertDigits(txtAAcost.Text);
                txtTotalExpenditure.Text = ConvertDigits(txtTotalExpenditure.Text);
                txtBill1Amt.Text = ConvertDigits(txtBill1Amt.Text);
                txtBill2Amt.Text = ConvertDigits(txtBill2Amt.Text);
                txtBill3Amt.Text = ConvertDigits(txtBill3Amt.Text);
                txtBill4Amt.Text = ConvertDigits(txtBill4Amt.Text);
                txtBill5Amt.Text = ConvertDigits(txtBill5Amt.Text);
                txtBill6Amt.Text = ConvertDigits(txtBill6Amt.Text);
                txtBill7Amt.Text = ConvertDigits(txtBill7Amt.Text);
                txtBill8Amt.Text = ConvertDigits(txtBill8Amt.Text);
                txtBill9Amt.Text = ConvertDigits(txtBill9Amt.Text);
                txtBillFAmt.Text = ConvertDigits(txtBillFAmt.Text);
                txtTotalAmt.Text = ConvertDigits(txtTotalAmt.Text);

                if (cn.State != ConnectionState.Open)
                    cn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from tbl_Bill_Status WHERE Work_Id='" + ddlWorkId.SelectedItem.Text + "' and BudgetYear='" + ddlBudgetYear.SelectedItem.Text + "'", cn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlCommand cmd = new SqlCommand();
                SqlCommand cmd1 = new SqlCommand();
                string status;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString() == 0.ToString())
                    {
                        status = "Insert";
                        cmd = new SqlCommand("INSERT INTO [tbl_Bill_Status] ([Work_Id],[HeadType],[BudgetYear],[WorkName],[Santion_Date],[Kamachi_Mudat],[KamPurn_Date],[AA_Cost],[BIll_To_Mob],[Bill_By_Post],[Bill_By_Mob],[Bill_1],[Bill_1_Amt],[Bill_1_Date] ,[Bill_2],[Bill_2_Amt],[Bill_2_Date],[Bill_3],[Bill_3_Amt],[Bill_3_Date],[Bill_4],[Bill_4_Amt],[Bill_4_Date],[Bill_5],[Bill_5_Amt],[Bill_5_Date],[Bill_6],[Bill_6_Amt],[Bill_6_Date],[Bill_7],[Bill_7_Amt],[Bill_7_Date],[Bill_8],[Bill_8_Amt],[Bill_8_Date],[Bill_9],[Bill_9_Amt],[Bill_9_Date],[Bill_final],[Bill_final_Amt],[Bill_final_Date],[Bill_1_To],[Bill_1_By],[Bill_2_To],[Bill_2_By],[Bill_3_To],[Bill_3_By],[Bill_4_To],[Bill_4_By],[Bill_5_To],[Bill_5_By],[Bill_6_To],[Bill_6_By],[Bill_7_To],[Bill_7_By],[Bill_8_To],[Bill_8_By],[Bill_9_To],[Bill_9_By],[Bill_final_To],[Bill_final_By],[Bill_Total]) VALUES(N'" + ddlWorkId.SelectedItem.Text + "',N'" + ddlHeadType.SelectedItem.Text + "',N'" + ddlBudgetYear.SelectedItem.Text + "',N'" + txtWorkName.Text + "',N'" + txtSanctionDate.Text + "',N'" + txtExtention.Text + "',N'" + txtWorkCompleteDate.Text + "',N'" + txtAAcost.Text + "',N'" + BilToMobileNumber.Text + "',N'" + ddlBillByPost.SelectedItem.Text + "',N'" + txtBillByNumber.Text + "',N'1',N'" + txtBill1Amt.Text + "',N'" + txtBill1Date.Text + "',N'2',N'" + txtBill2Amt.Text + "',N'" + txtBill2Date.Text + "',N'3',N'" + txtBill3Amt.Text + "',N'" + txtBill3Date.Text + "',N'4',N'" + txtBill4Amt.Text + "',N'" + txtBill4Date.Text + "',N'5',N'" + txtBill5Amt.Text + "',N'" + txtBill5Date.Text + "',N'6',N'" + txtBill6Amt.Text + "',N'" + txtBill6Date.Text + "',N'7',N'" + txtBill7Amt.Text + "',N'" + txtBill7Date.Text + "',N'8',N'" + txtBill8Amt.Text + "',N'" + txtBill8Date.Text + "',N'9',N'" + txtBill9Amt.Text + "',N'" + txtBill9Date.Text + "',N'Final',N'" + txtBillFAmt.Text + "',N'" + txtBillFDate.Text + "',N'" + txtBill1To.Text + "',N'" + txtBill1By.Text + "',N'" + txtBill2To.Text + "',N'" + txtBill2By.Text + "',N'" + txtBill3To.Text + "',N'" + txtBill3By.Text + "',N'" + txtBill4To.Text + "',N'" + txtBill4By.Text + "',N'" + txtBill5To.Text + "',N'" + txtBill5By.Text + "',N'" + txtBill6To.Text + "',N'" + txtBill6By.Text + "',N'" + txtBill7To.Text + "',N'" + txtBill7By.Text + "',N'" + txtBill8To.Text + "',N'" + txtBill8By.Text + "',N'" + txtBill9To.Text + "',N'" + txtBill9By.Text + "',N'" + txtBillFTo.Text + "',N'" + txtBillFBy.Text + "',N'" + txtTotalAmt.Text + "')", cn);
                    }
                    else
                    {
                        status = "Update";
                        cmd = new SqlCommand("UPDATE tbl_Bill_Status SET [WorkName]=N'" + txtWorkName.Text + "',[Santion_Date]=N'" + txtSanctionDate.Text + "',[Kamachi_Mudat]=N'" + txtExtention.Text + "',[KamPurn_Date]=N'" + txtWorkCompleteDate.Text + "',[AA_Cost]=N'" + txtAAcost.Text + "',[BIll_To_Mob]=N'" + BilToMobileNumber.Text + "',[Bill_By_Post]=N'" + ddlBillByPost.SelectedItem.Text + "',[Bill_By_Mob]=N'" + txtBillByNumber.Text + "',[Bill_1]=N'1',[Bill_1_Amt]=N'" + txtBill1Amt.Text + "',[Bill_1_Date]=N'" + txtBill1Date.Text + "' ,[Bill_2]=N'2',[Bill_2_Amt]=N'" + txtBill2Amt.Text + "',[Bill_2_Date]=N'" + txtBill2Date.Text + "',[Bill_3]=N'3',[Bill_3_Amt]=N'" + txtBill3Amt.Text + "',[Bill_3_Date]=N'" + txtBill3Date.Text + "',[Bill_4]=N'4',[Bill_4_Amt]=N'" + txtBill4Amt.Text + "',[Bill_4_Date]=N'" + txtBill4Date.Text + "',[Bill_5]=N'5',[Bill_5_Amt]=N'" + txtBill5Amt.Text + "',[Bill_5_Date]=N'" + txtBill5Date.Text + "',[Bill_6]=N'6',[Bill_6_Amt]=N'" + txtBill6Amt.Text + "',[Bill_6_Date]=N'" + txtBill6Date.Text + "',[Bill_7]=N'7',[Bill_7_Amt]=N'" + txtBill7Amt.Text + "',[Bill_7_Date]=N'" + txtBill7Date.Text + "',[Bill_8]=N'8',[Bill_8_Amt]=N'" + txtBill8Amt.Text + "',[Bill_8_Date]=N'" + txtBill8Date.Text + "',[Bill_9]=N'9',[Bill_9_Amt]=N'" + txtBill9Amt.Text + "',[Bill_9_Date]=N'" + txtBill9Date.Text + "',[Bill_final]=N'Final',[Bill_final_Amt]=N'" + txtBillFAmt.Text + "',[Bill_final_Date]='" + txtBillFDate.Text + "',[Bill_1_To]=N'" + txtBill1To.Text + "',[Bill_1_By]=N'" + txtBill1By.Text + "',[Bill_2_To]=N'" + txtBill2To.Text + "',[Bill_2_By]=N'" + txtBill2By.Text + "',[Bill_3_To]=N'" + txtBill3To.Text + "',[Bill_3_By]=N'" + txtBill3By.Text + "',[Bill_4_To]=N'" + txtBill4To.Text + "',[Bill_4_By]=N'" + txtBill4By.Text + "',[Bill_5_To]=N'" + txtBill5To.Text + "',[Bill_5_By]=N'" + txtBill5By.Text + "',[Bill_6_To]=N'" + txtBill6To.Text + "',[Bill_6_By]=N'" + txtBill6By.Text + "',[Bill_7_To]=N'" + txtBill7To.Text + "',[Bill_7_By]=N'" + txtBill7By.Text + "',[Bill_8_To]=N'" + txtBill8To.Text + "',[Bill_8_By]=N'" + txtBill8By.Text + "',[Bill_9_To]=N'" + txtBill9To.Text + "',[Bill_9_By]=N'" + txtBill9By.Text + "',[Bill_final_To]=N'" + txtBillFTo.Text + "',[Bill_final_By]=N'" + txtBillFBy.Text + "',[Bill_Total]=N'" + txtTotalAmt.Text + "' WHERE Work_Id='" + ddlWorkId.SelectedItem.Text + "' and BudgetYear='" + ddlBudgetYear.SelectedItem.Text + "' ", cn);
                    }
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        if (status == "Insert")
                        {
                            lblStatus.Text = "Record Inserted successfully!!!";
                        }
                        else if (status == "Update")
                        {
                            lblStatus.Text = "Record Updated successfully!!!";
                        }
                        // Response.Redirect("BillStatus.aspx");

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}