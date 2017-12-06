using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PWdEEBudget.SMS_CRUD;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;

namespace PWdEEBudget
{
    public partial class DBSIndividualHeadReport : System.Web.UI.Page
    {
        clsSMS_CRUD ObjBindTable = new clsSMS_CRUD();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        SqlDataAdapter sda;
        DataTable dt;
        string strcmd = string.Empty;
        string getworkid = string.Empty;
        string Upvibhag = string.Empty;
        string Type = string.Empty;
        string count = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindTable();
            }

        }
        public void BindTable()
        {
            dt = new DataTable();
            //Call a BindChart Method in clsSmS_CRUD for Binding Chart
            dt = ObjBindTable.BindChart();

            HtmlTableCell Tblcell = new HtmlTableCell();
            string[] UpVibhagName = { "सा.बां.उपविभाग, बारामती", "सा.बां.(वैद्यकीय) उपविभाग, बारामती", "सा.बां.उपविभाग,दौंड", "सा.बां.उपविभाग, इंदापूर", "सा.बां.उपविभाग, भिगवण", "सा.बां.उपविभाग, शिरुर", "सा.बां.उपविभाग,  प्रकल्प (खा), पुणे", "सा.बां.उपविभाग, क्र. 4, पुणे", "सा.बां.उपविभाग,दौंड ( ईमारती )" };
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Upvibhag = dt.Rows[i]["Upvibhag"].ToString();
                Type = dt.Rows[i]["Type"].ToString();
                count = Convert.ToString(dt.Rows[i]["Count"]);
                if (Type == "Aunty")
                {

                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? ANBarmati : Upvibhag.Trim() == UpVibhagName[1] ? ANUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? ANDound : Upvibhag.Trim() == UpVibhagName[3] ? ANIndapur : Upvibhag.Trim() == UpVibhagName[4] ? ANBhig : Upvibhag.Trim() == UpVibhagName[5] ? ANShirur : Upvibhag.Trim() == UpVibhagName[6] ? ANPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? ANKramank : Upvibhag.Trim() == UpVibhagName[8] ? ANDoundEmart : Tblcell;
                    tableCel.InnerText = count;
                }
                else if (Type == "Building")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? BBarmati : Upvibhag.Trim() == UpVibhagName[1] ? BUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? BDound : Upvibhag.Trim() == UpVibhagName[3] ? BIndapur : Upvibhag.Trim() == UpVibhagName[4] ? BBhig : Upvibhag.Trim() == UpVibhagName[5] ? BShirur : Upvibhag.Trim() == UpVibhagName[6] ? BPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? BKramank : Upvibhag.Trim() == UpVibhagName[8] ? BDoundEmart : Tblcell;
                    tableCel.InnerText = count;
                }
                else if (Type == "CRF")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? CBarmati : Upvibhag.Trim() == UpVibhagName[1] ? CUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? CDound : Upvibhag.Trim() == UpVibhagName[3] ? CIndapur : Upvibhag.Trim() == UpVibhagName[4] ? CBhig : Upvibhag.Trim() == UpVibhagName[5] ? CShirur : Upvibhag.Trim() == UpVibhagName[6] ? CPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? CKramank : Upvibhag.Trim() == UpVibhagName[8] ? CDoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }
                else if (Type == "DepositFund")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? DFBarmati : Upvibhag.Trim() == UpVibhagName[1] ? DFUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? DFDound : Upvibhag.Trim() == UpVibhagName[3] ? DFIndapur : Upvibhag.Trim() == UpVibhagName[4] ? DFBhig : Upvibhag.Trim() == UpVibhagName[5] ? DFShirur : Upvibhag.Trim() == UpVibhagName[6] ? DFPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? DFKramank : Upvibhag.Trim() == UpVibhagName[8] ? DFDoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }
                else if (Type == "DPDC")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? DPBarmati : Upvibhag.Trim() == UpVibhagName[1] ? DPUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? DPDound : Upvibhag.Trim() == UpVibhagName[3] ? DPIndapur : Upvibhag.Trim() == UpVibhagName[4] ? DPBhig : Upvibhag.Trim() == UpVibhagName[5] ? DPShirur : Upvibhag.Trim() == UpVibhagName[6] ? DPPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? DPKramank : Upvibhag.Trim() == UpVibhagName[8] ? DPDoundEmart : Tblcell;
                    tableCel.InnerText = count;
                }
                else if (Type == "GAT_A")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? GABarmati : Upvibhag.Trim() == UpVibhagName[1] ? GAUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? GADound : Upvibhag.Trim() == UpVibhagName[3] ? GAIndapur : Upvibhag.Trim() == UpVibhagName[4] ? GABhig : Upvibhag.Trim() == UpVibhagName[5] ? GAShirur : Upvibhag.Trim() == UpVibhagName[6] ? GAPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? GAKramank : Upvibhag.Trim() == UpVibhagName[8] ? GADoundEmart : Tblcell;
                    tableCel.InnerText = count;
                   
                }

                else if (Type == "GAT_D")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? GDBarmati : Upvibhag.Trim() == UpVibhagName[1] ? GDUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? GDDound : Upvibhag.Trim() == UpVibhagName[3] ? GDIndapur : Upvibhag.Trim() == UpVibhagName[4] ? GDBhig : Upvibhag.Trim() == UpVibhagName[5] ? GDShirur : Upvibhag.Trim() == UpVibhagName[6] ? GDPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? GDKramank : Upvibhag.Trim() == UpVibhagName[8] ? GDDoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }
               
                else if (Type == "GAT_FBC")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? GFBCBarmati : Upvibhag.Trim() == UpVibhagName[1] ? GFBCUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? GFBCDound : Upvibhag.Trim() == UpVibhagName[3] ? GFBCIndapur : Upvibhag.Trim() == UpVibhagName[4] ? GFBCBhig : Upvibhag.Trim() == UpVibhagName[5] ? GFBCShirur : Upvibhag.Trim() == UpVibhagName[6] ? GFBCPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? GFBCKramank : Upvibhag.Trim() == UpVibhagName[8] ? GFBCDoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }
                
                else if (Type == "MLA")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? MLABarmati : Upvibhag.Trim() == UpVibhagName[1] ? MLAUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? MLADound : Upvibhag.Trim() == UpVibhagName[3] ? MLAIndapur : Upvibhag.Trim() == UpVibhagName[4] ? MLABhig : Upvibhag.Trim() == UpVibhagName[5] ? MLAShirur : Upvibhag.Trim() == UpVibhagName[6] ? MLAPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? MLAKramank : Upvibhag.Trim() == UpVibhagName[8] ? MLADoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }


                else if (Type == "MP")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? MPBarmati : Upvibhag.Trim() == UpVibhagName[1] ? MPUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? MPDound : Upvibhag.Trim() == UpVibhagName[3] ? MPIndapur : Upvibhag.Trim() == UpVibhagName[4] ? MPBhig : Upvibhag.Trim() == UpVibhagName[5] ? MPShirur : Upvibhag.Trim() == UpVibhagName[6] ? MPPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? MPKramank : Upvibhag.Trim() == UpVibhagName[8] ? MPDoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }
                else if (Type == "NABARD")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? NABarmati : Upvibhag.Trim() == UpVibhagName[1] ? NAUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? NADound : Upvibhag.Trim() == UpVibhagName[3] ? NAIndapur : Upvibhag.Trim() == UpVibhagName[4] ? NABhig : Upvibhag.Trim() == UpVibhagName[5] ? NAShirur : Upvibhag.Trim() == UpVibhagName[6] ? NAPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? NAKramank : Upvibhag.Trim() == UpVibhagName[8] ? NADoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }
                else if (Type == "NRB")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? NRBBarmati : Upvibhag.Trim() == UpVibhagName[1] ? NRBUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? NRBDound : Upvibhag.Trim() == UpVibhagName[3] ? NRBIndapur : Upvibhag.Trim() == UpVibhagName[4] ? NRBBhig : Upvibhag.Trim() == UpVibhagName[5] ? NRBShirur : Upvibhag.Trim() == UpVibhagName[6] ? NRBPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? NRBKramank : Upvibhag.Trim() == UpVibhagName[8] ? NRBDoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }

                else if (Type == "RB")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? RBBarmati : Upvibhag.Trim() == UpVibhagName[1] ? RBUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? RBDound : Upvibhag.Trim() == UpVibhagName[3] ? RBIndapur : Upvibhag.Trim() == UpVibhagName[4] ? RBBhig : Upvibhag.Trim() == UpVibhagName[5] ? RBShirur : Upvibhag.Trim() == UpVibhagName[6] ? RBPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? RBKramank : Upvibhag.Trim() == UpVibhagName[8] ? RBDoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }

                
                else if (Type == "Road")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? ROBarmati : Upvibhag.Trim() == UpVibhagName[1] ? ROUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? RODound : Upvibhag.Trim() == UpVibhagName[3] ? ROIndapur : Upvibhag.Trim() == UpVibhagName[4] ? ROBhig : Upvibhag.Trim() == UpVibhagName[5] ? ROShirur : Upvibhag.Trim() == UpVibhagName[6] ? ROPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? ROKramank : Upvibhag.Trim() == UpVibhagName[8] ? RODoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }

                //New Head Add
                else if (Type == "2515")
                {
                    var tableCel = Upvibhag.Trim() == UpVibhagName[0] ? GramVBarmati : Upvibhag.Trim() == UpVibhagName[1] ? GramVUpBaramati : Upvibhag.Trim() == UpVibhagName[2] ? GramVDound : Upvibhag.Trim() == UpVibhagName[3] ? GramVIndapur : Upvibhag.Trim() == UpVibhagName[4] ? GramVBhig : Upvibhag.Trim() == UpVibhagName[5] ? GramVShirur : Upvibhag.Trim() == UpVibhagName[6] ? GramVPrakalp : Upvibhag.Trim() == UpVibhagName[7] ? GramVKramank : Upvibhag.Trim() == UpVibhagName[8] ? GramVDoundEmart : Tblcell;
                    tableCel.InnerText = count;

                }
               
            }
            Session["SReportPanel"] = Panel1;
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Upvibbhag/" + DateTime.Now + ".xls");
            Response.ContentType = "application/excel";

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            lbl.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


        protected void btnImgExcel_Click(object sender, ImageClickEventArgs e)
        {


            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=IndividualHeadWork" + DateTime.Now + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //this.BindGrid(SortField);
                lbl.Font.Name = "Times New Roman";
                lbl.BackColor = Color.Transparent;
                lbl.RenderControl(hw);
                Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase));
                Response.Flush();
                Response.End();
            }
        }


        protected void btnImgSendMail_Click(object sender, ImageClickEventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }
            Session["filename"] = "DBSIndividualHeadReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "DBSIndividualHeadReport.xls");
                    //RenderAllGrid(sw, htw);
                    Panel1.RenderControl(htw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }
            Response.Redirect("SendMail.aspx");
        }
    }
}