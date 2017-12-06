using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

using Ionic.Zip;

namespace PWdEEBudget
{
    public partial class UploadImage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        SqlDataAdapter sd;
        SqlCommand cmd;
        DataTable dt;
        DataTable dt1;
        DataSet ds;
        public string ImageColumnName { get; set; }
        public string FromTableName { get; set; }
        public static string ddlty = string.Empty;
        string userid = string.Empty;
        string KamcheNav = string.Empty;
        string Shakhaabhyanta = string.Empty; string Upabhyanta = string.Empty; string Thekedar = string.Empty;
        string TableName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PrevPage"] != null)
            {
                Session["PrevPageOfPhotoUpload"] = Request.QueryString["PrevPage"];
            }
            if (Request.QueryString["PrevMPage"] == "Contractor")
            {
                Session["ContPrevPage"] = "ContractorUpdateReport.aspx";
            }
            if (Request.QueryString["PrevMPage"] == "SubDivision")
            {
                Session["SubDivPrevPage"] = "SubDivisionUpdateReport.aspx";
            }
            if (Session["id"] != null)
            {
                userid = Session["id"].ToString();
            }

            if (Request.UrlReferrer != null)
            {
                string previousPageUrl = Request.UrlReferrer.AbsoluteUri;
                string previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);
                Session["NonReportPageName"] = previousPageName;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["WorkID"] != null && Request.QueryString["WorkID"] != "0")
                {
                    ddlType.SelectedIndex = Convert.ToInt32(Request.QueryString["index"]);
                    txtoldWorkID.Text = Request.QueryString["WorkID"].ToString();
                    txtoldWorkID.Focus();
                    txtoldWorkID.AutoPostBack = true;
                    datasearching();
                }
            }
        }
        protected void page_preinit(object sender, EventArgs e)
        {
            if (!IsPostBack || Request.QueryString["PrevMPage"] == "ImageUpload" || Request.QueryString["PrevMPage"] == "Admin" || Request.QueryString["PrevMPage"] == "Contractor" || Request.QueryString["PrevMPage"] == "SubDivision")
            {
                if (Request.QueryString["PrevMPage"] != null)
                {
                    string PrevMPage = Request.QueryString["PrevMPage"].ToString();
                    if (PrevMPage == "ImageUpload")
                    {
                        Page.MasterPageFile = "~/ImageUpload.Master";
                    }
                    else if (PrevMPage == "Admin")
                    {
                        Page.MasterPageFile = "~/Admin.Master";
                    }
                    else if (PrevMPage == "Contractor")
                    {
                        Page.MasterPageFile = "~/Contractor.Master";
                    }
                    else if (PrevMPage == "SubDivision")
                    {
                        Page.MasterPageFile = "~/SubDivision.Master";
                    }
                    else
                    {
                        Page.MasterPageFile = "~/SuperAdmin.Master";
                    }
                }
            }
        }

        public void datasearching()
        {
            WorkDetails();
            sd = new SqlDataAdapter("select Post,Name from SCreateAdmin where UserId ='" + userid + "'", con);
            dt = new DataTable();
            sd.Fill(dt);
            SqlDataAdapter sd1;
             dt1 = new DataTable();
            txtoldWorkID.Text = txtoldWorkID.Text.Split(':')[0];
            DataList1.DataSource = null;
            DataList1.DataBind();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Post"].ToString() == "Executive Engineer" || dr["Post"].ToString() == "Deputy Executive Engineer" || dr["Post"].ToString() == "Assistant Engineer Class-2 Division office" || dr["Post"].ToString() == "Sectional Engineer Division office" || dr["Post"].ToString() == "Admin")
                    {
                        sd1 = new SqlDataAdapter("Select [ImageId], [WorkId],[Image],[Description] from ImageGallary where WorkId='" + txtoldWorkID.Text + "' and Type='" + ddlType.SelectedItem.Text + "' order by ImageId desc", con);
                        sd1.SelectCommand.CommandTimeout = 600;
                        sd1.Fill(dt1);
                    }
                    if (dr["Post"].ToString() == "Sectional Engineer" || dr["Post"].ToString() == "Assistant Engineer Class-2" || dr["Post"].ToString() == "Assistant Engineer Class-1" || dr["Post"].ToString() == " Deputy Engineer" || dr["Post"].ToString() == "Deputy Engineer" || dr["Post"].ToString() == "Contractor")
                    {
                        if (Shakhaabhyanta == dr["Name"].ToString() || Upabhyanta == dr["Name"].ToString() || Thekedar == dr["Name"].ToString())
                        {
                            sd1 = new SqlDataAdapter("Select [ImageId], [WorkId],[Image],[Description] from ImageGallary where WorkId='" + txtoldWorkID.Text + "' and Type='" + ddlType.SelectedItem.Text + "' order by ImageId desc", con);
                            sd1.SelectCommand.CommandTimeout = 600;
                            sd1.Fill(dt1);

                        }
                        else
                        {
                            Response.Write("<script>alert('Sorry you can not Seen Record of this WorkId...!!!')</script>");
                        }
                    }
                }
            }

            if (dt1.Rows.Count > 0)
            {
                lblStatus.Text = "";
                DataList1.DataSource = dt1;
                DataList1.DataBind();
                ViewState["Images"] = dt1;
                lblWorkid.Text = "प्रकार :-  " + ddlType.SelectedItem.Text + "     वर्क आयडी :-  " + txtoldWorkID.Text;
                lblKamacheName.Text = "कामाचे नाव :-  " + KamcheNav;
                foreach (DataListItem dli in DataList1.Items)
                {
                    Label Label2 = (Label)dli.FindControl("lblWorkName");
                    Label2.Text = KamcheNav;
                }
            }
            else
            {
                lblKamacheName.Text = "";
                lblWorkid.Text = "";
                lblStatus.Text = "No Data Found...!!!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void WorkDetails()
        {
            TableName = ddlType.SelectedItem.Value;
            txtoldWorkID.Text = txtoldWorkID.Text.Split(':')[0];
            SqlCommand cmd1 = new SqlCommand("select KamacheName,[ShakhaAbhyantaName],[UpabhyantaName],[ThekedaarName] from " + TableName + " where WorkId='" + txtoldWorkID.Text + "'", con);
            if (con.State != ConnectionState.Open)
                con.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();
                KamcheNav = dr1["KamacheName"].ToString();
                Shakhaabhyanta = dr1["ShakhaAbhyantaName"].ToString();
                Upabhyanta = dr1["UpabhyantaName"].ToString();
                Thekedar = dr1["ThekedaarName"].ToString();
            }
            dr1.Close();
        }

        protected void btnUplodImg_Click(object sender, EventArgs e)
        {
            WorkDetails();
            sd = new SqlDataAdapter("select Post,Name from SCreateAdmin where UserId ='" + userid + "'", con);
            dt = new DataTable();
            sd.Fill(dt);
            if (FileUpload1.HasFile)
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string description = txtImgDesc.Text;
                if (description == "")
                {
                    description = "सार्वजनिक बांधकाम पूर्व विभाग,पुणे";
                }
                int length = FileUpload1.PostedFile.ContentLength;
                byte[] imgbyte = new byte[length];
                HttpPostedFile img = FileUpload1.PostedFile;
                string contentType = FileUpload1.PostedFile.ContentType;
                //set the binary data
                img.InputStream.Read(imgbyte, 0, length);
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Post"].ToString() == "Executive Engineer" || dr["Post"].ToString() == "Deputy Executive Engineer" || dr["Post"].ToString() == "Assistant Engineer Class-2 Division office" || dr["Post"].ToString() == "Sectional Engineer Division office" || dr["Post"].ToString() == "Admin")
                        {
                            cmd = new SqlCommand("Insert into [ImageGallary]([WorkId] ,[Type],[Image],[ContentType],[Filepath],[Description]) values('" + txtoldWorkID.Text + "','" + ddlType.SelectedItem.Text + "',@Data,@Content,@Filename,N'" + description + "')", con);
                            cmd.Parameters.AddWithValue("@Data", imgbyte);
                            cmd.Parameters.AddWithValue("@Content", contentType);
                            cmd.Parameters.AddWithValue("@Filename", filename);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            Response.Write("<script>alert('Image upload succesfully...!!!')</script>");
                        }
                        if (dr["Post"].ToString() == "Sectional Engineer" || dr["Post"].ToString() == "Assistant Engineer Class-2" || dr["Post"].ToString() == "Assistant Engineer Class-1" || dr["Post"].ToString() == " Deputy Engineer" || dr["Post"].ToString() == "Deputy Engineer" || dr["Post"].ToString() == "Contractor")
                        {
                            if (Shakhaabhyanta == dr["Name"].ToString() || Upabhyanta == dr["Name"].ToString() || Thekedar == dr["Name"].ToString())
                            {
                                cmd = new SqlCommand("Insert into [ImageGallary]([WorkId] ,[Type],[Image],[ContentType],[Filepath],[Description]) values('" + txtoldWorkID.Text + "','" + ddlType.SelectedItem.Text + "',@Data,@Content,@Filename,N'" + description + "')", con);
                                cmd.Parameters.AddWithValue("@Data", imgbyte);
                                cmd.Parameters.AddWithValue("@Content", contentType);
                                cmd.Parameters.AddWithValue("@Filename", filename);
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                Response.Write("<script>alert('Image upload succesfully...!!!')</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Sorry you can not upload image this WorkId...!!!')</script>");
                            }
                        }
                    }
                }
                con.Close();
                datasearching();
            }
            con.Close();
            btnUplodImg.Enabled = false;
            if (Request.QueryString["PrevMPage"] != null)
            {
                string PrevMPage = Request.QueryString["PrevMPage"].ToString();
                Server.Transfer("UploadImage.aspx?PrevMPage=" + PrevMPage + "", false);
            }
            else
            {
                Server.Transfer("UploadImage.aspx", false);
            }
        }

        private void binddata()
        {
            throw new NotImplementedException();
        }
        protected void txtoldWorkID_TextChanged(object sender, EventArgs e)
        {
            FileUpload1.Enabled = true;
            datasearching();
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            SqlDataAdapter sdaa = new SqlDataAdapter("SELECT coalesce(B.WorkID, C.WorkID, N.WorkID, R.WorkID, G_A.WorkID, G_FBC.WorkID, G_D.WorkID, D.WorkID, DP.WorkID, MLA.WorkID,MP.WorkID,An.WorkID,GramV.Workid,NRB.Workid,RB.Workid)as WorkID,coalesce(B.KamacheName, C.KamacheName, N.KamacheName, R.KamacheName, G_A.KamacheName, G_FBC.KamacheName, G_D.KamacheName, D.KamacheName, DP.KamacheName, MLA.KamacheName,MP.KamacheName,An.KamacheName,GramV.KamacheName,NRB.KamacheName,RB.KamacheName)as KamacheName FROM BudgetMasterBuilding B FULL OUTER JOIN BudgetMasterCRF C ON B.WorkID=C.WorkID full outer join BudgetMasterNABARD N on B.WorkID= N.WorkID  full outer join BudgetMasterRoad R on B.WorkID=R.WorkID full outer join BudgetMasterGAT_A G_A on B.WorkID=G_A.WorkID full outer join BudgetMasterGAT_FBC G_FBC on B.WorkID=G_FBC.WorkID full outer join BudgetMasterGAT_D G_D on B.WorkID=G_D.WorkID  full outer join BudgetMasterDepositFund D on B.WorkID=D.WorkID  full outer join BudgetMasterDPDC DP on B.WorkID=DP.WorkID  full outer join BudgetMasterMLA MLA on B.WorkID=MLA.WorkID  full outer join BudgetMasterMP MP on B.WorkID=MP.WorkID full outer join BudgetMasterAunty An on B.WorkID=An.WorkID full outer join BudgetMaster2515 GramV on B.Workid=GramV.Workid full outer join BudgetMasterNonResidentialBuilding NRB on B.Workid=NRB.workid full outer join BudgetMasterResidentialBuilding RB on B.Workid=RB.workid  where B.WorkID like '" + prefixText + "%' and  B.Type='" + ddlty + "' or C.workID like '" + prefixText + "%' and C.Type='" + ddlty + "' or N.workID  like '" + prefixText + "%' and N.Type='" + ddlty + "' or R.workID like '" + prefixText + "%' and R.Type='" + ddlty + "'  or G_A.workID like '" + prefixText + "%' and G_A.Type='" + ddlty + "' or G_FBC.workID like '" + prefixText + "%' and G_FBC.Type='" + ddlty + "' or G_D.workID like '" + prefixText + "%' and G_D.Type='" + ddlty + "' or D.workID like '" + prefixText + "%' and D.Type='" + ddlty + "' or DP.workID like '" + prefixText + "%' and DP.Type='" + ddlty + "' or MLA.workID like '" + prefixText + "%' and MLA.Type='" + ddlty + "'  or MP.workID like '" + prefixText + "%' and MP.Type='" + ddlty + "' or An.WorkID like '" + prefixText + "%' and An.Type='" + ddlty + "' or GramV.Workid like '" + prefixText + "%' and GramV.Type='" + ddlty + "' or NRB.Workid like '" + prefixText + "%' and NRB.Type='" + ddlty + "'  or RB.Workid like '" + prefixText + "%' and RB.Type='" + ddlty + "' ", conn);

            sdaa.Fill(dt);
            List<string> countryNames = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                countryNames.Add(dr["WorkID"].ToString() + ":  " + dr["KamacheName"].ToString());
            }
            return countryNames;
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlty = ddlType.SelectedItem.Text;
            txtoldWorkID.Text = "";
            lblWorkid.Text = "";
            lblKamacheName.Text = "";
            DataList1.DataSource = null;
            DataList1.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //string NavigateURL = Request.QueryString["PrevPage"];
            if (Session["PrevPageOfPhotoUpload"] != null)
            {
                string NavigateURL = Session["PrevPageOfPhotoUpload"].ToString();
                Session["PrevPageOfPhotoUpload"] = null;
                Response.Redirect(NavigateURL);
            }
            else if (Session["ContPrevPage"] != null)
            {
                string ContPrevPage = Session["ContPrevPage"].ToString();
                Session["ContPrevPage"] = null;
                Response.Redirect(ContPrevPage);
            }
            else if (Session["SubDivPrevPage"] != null)
            {
                string SubDivPrevPage = Session["SubDivPrevPage"].ToString();
                Session["SubDivPrevPage"] = null;
                Response.Redirect(SubDivPrevPage);
            }
            else
            {
                string NonReportPage = Session["NonReportPageName"].ToString();
                Session["NonReportPageName"] = null;
                Response.Redirect(NonReportPage);
            }
        }

        protected void delImg_Click(object sender, ImageClickEventArgs e)
        {

            if (con.State != ConnectionState.Open)
                con.Open();
            ImageButton bt = (ImageButton)sender;
            DataListItem dli = (DataListItem)bt.NamingContainer;
            Label lb = (Label)dli.FindControl("lblImageId");
            int id = Convert.ToInt32(lb.Text);
            string deletequery = string.Empty;
            deletequery = "Delete from [ImageGallary] where [ImageId]=" + id;
            SqlCommand cmd = new SqlCommand(deletequery, con);
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
            }
            con.Close();
            datasearching();
        }

        protected void ImgDown_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton bt = (ImageButton)sender;
            DataListItem dli = (DataListItem)bt.NamingContainer;
            Label lb = (Label)dli.FindControl("lblImageId");
            int id = Convert.ToInt32(lb.Text);
            byte[] bytes;
            string fileName, contentType;
            if (con.State != ConnectionState.Open)
                con.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from ImageGallary where ImageId=" + id;
                cmd.Connection = con;
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["Image"];
                    contentType = sdr["ContentType"].ToString();
                    fileName = sdr["Filepath"].ToString();
                }
            }

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
            con.Close();
        }

        protected void btnDownloadAllImages_Click(object sender, EventArgs e)
        {
            string folderName = Server.MapPath("~/") + "\\Download\\";

            // Create a temp directory for the logged in user

            DirectoryInfo di = CreateUserDirectory(folderName);

            // Get images from database into a dataset on webserver

            // Store the images from dataset to a folder
            if (ViewState["Images"]!=null )
            {
                StoreImagesInFolder(ViewState["Images"]as DataTable, di.FullName);
                string fileName = ZipFolder(di.FullName);

                Download(fileName);

                di.Delete(true);
            }
            else
            {
                Response.Write("<script>alert('Sorry No images Found for this WorkId...!!!')</script>");
            }
            // Zip contents of the folder

        }

        /* Create temporary User Directory to store images and zipped file. */

        public DirectoryInfo CreateUserDirectory(string directoryPath)
        {
            // Initialize userName by GUID

            string userName = System.Guid.NewGuid().ToString("N");

            // If user is registered, use the new userName else use GUID

            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                userName = User.Identity.Name;
            }

            string userDirectoryName = directoryPath + "\\" + userName;
            DirectoryInfo di;

            // Create a directory for the user

            if (!Directory.Exists(userDirectoryName))
            {
                di = System.IO.Directory.CreateDirectory(userDirectoryName);
                return di;
            }
            else
            {
                di = new DirectoryInfo(userDirectoryName);
            }
            return di;
        }

        /* Store images in the folder */

        public void StoreImagesInFolder(DataTable datatbl, string folderName)
        {
            int i = 0;
            foreach (DataRow row in datatbl.Rows)
            {
                // Get the image caption
                i += 1;
                //string FileName = i.ToString() + row["Caption"].ToString();
                //Give a Marksheet Name Hear & .Jpg Format
                string FileName = txtoldWorkID.Text + "_" + i.ToString();
                FileStream outStream;
                if (FileName.Contains(".JPG") || FileName.Contains(".jpg"))
                {
                    outStream = File.OpenWrite(folderName + "\\" + FileName + ".jpg");
                }
                else
                {
                    outStream = File.OpenWrite(folderName + "\\" + FileName + ".JPG");
                }

                //Get the original image data

                byte[] imageData = (byte[])row["Image"];

                //Read image data into a memory stream

                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.WriteTo(outStream);

                    outStream.Flush();
                    outStream.Close();
                }
            }
        }

        /* Zip the folder */

        private string ZipFolder(string folderName)
        {
            // This call is just to get the Album name, you can skip this and name it anything, like may be use GUID again

            //System.Collections.Generic.List<Album> list = PhotoManager.GetAlbumByAlbumID(albumID);

            string albumName = "PWD_" + ddlType.SelectedItem.Text + "_" + txtoldWorkID.Text;

            //string fileName = folderName + "\\" + System.Guid.NewGuid().ToString("N".zip";
            string fileName = folderName + "\\" + albumName + ".zip";
            using (ZipFile zip = new ZipFile("MyZipFile.zip"))
            {
                // add this file into the "images" directory in the zip archive

                zip.AddDirectory(folderName);
                zip.Save(fileName);
            }

            // Return zipped file name

            return fileName;
        }

        /* Download the zipped file */

        public void Download(string fileName)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(fileName);
            //-- if the file exists on the server
            //set appropriate headers
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.Flush();
                Response.Close();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
}