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
using System.Text;

namespace PWdEEBudget
{
    public partial class DBSDivisionWiseReport : System.Web.UI.Page
    {
        SqlConnection con;        
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            DataTable dt_UnSort = new DataTable();

            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand objcmd = new SqlCommand("[DivisionWiseCount_SP]", con);
                objcmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(dt_UnSort);

                //Make a Division Groups & Sum Of Groups (GroupBy  Upvibhag)
                var result = dt_UnSort.AsEnumerable().GroupBy(dr => dr.Field<string>("Upvibhag")).Select(group => new { Upvibhag = group.Key, Count = group.Sum(col => col.Field<int>("Count")) });

                DataTable dt_Sorted = dt_UnSort.Clone();
                foreach (var grp in result)
                {
                    dt_Sorted.Rows.Add(grp.Upvibhag, grp.Count);
                }
                //Add New Row At the End Of Datatable For Showing Grand Total(एकुण)
                DataRow dr_New = dt_Sorted.NewRow();
                dr_New["Upvibhag"] = "एकुण";
                dr_New["Count"] = dt_Sorted.Compute("Sum(Count)", "");
                dt_Sorted.Rows.Add(dr_New);
                //Bind a GridView With Sorted dt
                GridView1.DataSource = dt_Sorted;
                GridView1.DataBind();
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=DBS_Division/" + DateTime.Now + ".xls");
            Response.ContentType = "application/excel";

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            Session["filename"] = "DBSDivisionWiseReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "DBSDivisionWiseReport.xls");
                    GridView1.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }

            Response.Redirect("SendMail.aspx");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
            GridView1.Attributes["style"] = "border-collapse:separate";
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                {
                    row.Attributes["style"] = "page-break-after:always;";
                }
            }
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            string style = "<style type = 'text/css'>thead {display:table-header-group;} tfoot{display:table-footer-group;}</style>";
            sb.Append(style + gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();");
            sb.Append("};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            BindGrid();
        }
    }
}