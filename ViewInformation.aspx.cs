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
    public partial class ViewInformation : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        string a, b, c,p,j;
        SqlDataAdapter sdaa = new SqlDataAdapter();
        SqlDataAdapter sdap = new SqlDataAdapter();
        DataTable dtt=new DataTable();
        DataTable dp = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                maintype();
            }
        }
        public void radio()
        {
            nullgrid();
            if (ddltype.SelectedItem.ToString() == "Building" || p == "Building")
                {
                    GridView1.DataSource = dtt;
                    GridView1.DataBind(); 
                }
            if (ddltype.SelectedItem.ToString() == "CRF" || p == "CRF")
                {
                    crfmaster.DataSource = dtt;
                    crfmaster.DataBind();
                }
            if (ddltype.SelectedItem.ToString() == "Nabard" || p == "Nabard")
                {
                    nabardmaster.DataSource = dtt;
                    nabardmaster.DataBind();
                }
            if (ddltype.SelectedItem.ToString() == "Road" || p == "Road")
                {
                    roadmaster.DataSource = dtt;
                    roadmaster.DataBind();
                }
            if (ddltype.SelectedItem.ToString() == "MLA" || p == "MLA")
                {
                    MLAmaster.DataSource = dtt;
                    MLAmaster.DataBind();
                }
            if (ddltype.SelectedItem.ToString() == "MP" || p == "MP")
                {
                    MPmaster.DataSource = dtt;
                    MPmaster.DataBind();
                }
         }
        public void radio1()
        {
            nullgrid();
            if (ddltype.SelectedItem.ToString() == "Building" || p == "Building")
            {
                GridView2.DataSource = dtt;
                GridView2.DataBind();
            }
            if (ddltype.SelectedItem.ToString() == "CRF" || p == "CRF")
            {
                crfmpr.DataSource = dtt;
                crfmpr.DataBind();
            }
            if (ddltype.SelectedItem.ToString() == "Nabard" || p == "Nabard")
            {
                nabardmpr.DataSource = dtt;
                nabardmpr.DataBind();
            }
            if (ddltype.SelectedItem.ToString() == "Road" || p == "Road")
            {
                roadmpr.DataSource = dtt;
                roadmpr.DataBind();
            }
            if (ddltype.SelectedItem.ToString() == "MLA" || p == "MLA")
            {
                MLAMPR.DataSource = dtt;
                MLAMPR.DataBind();
            }
            if (ddltype.SelectedItem.ToString() == "MP" || p == "MP")
            {
                MPMPR.DataSource = dtt;
                MPMPR.DataBind();
            }
        }
        public void masteralldata()
        {
            if (ddltype.SelectedItem.ToString() == "Building")
            {
                if (ddltype.SelectedItem.Text == "Building" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka,a.Upvibhag,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.SubType,a.LekhaShirsh,a.LekhaShirshName,a.KamacheName,a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat,a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch,b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,a.Shera,a.Img1,a.Img2,a.Img3 from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID  where a.Type=N'" + ddltype.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Building" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka,a.Upvibhag,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.SubType,a.LekhaShirsh,a.LekhaShirshName,a.KamacheName,a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat,a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch,b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,a.Shera,a.Img1,a.Img2,a.Img3 from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID  where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Building" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka,a.Upvibhag,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.SubType,a.LekhaShirsh,a.LekhaShirshName,a.KamacheName,a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat,a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch,b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,a.Shera,a.Img1,a.Img2,a.Img3 from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID  where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' order by SrNo desc", con); 
                }
                else if (ddltype.SelectedItem.Text == "Building" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka,a.Upvibhag,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.SubType,a.LekhaShirsh,a.LekhaShirshName,a.KamacheName,a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat,a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch,b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,a.Shera,a.Img1,a.Img2,a.Img3 from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID  where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and a.Workid=N'" + ddlworkid.SelectedItem.Text + "'", con); 
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
            if (ddltype.SelectedItem.ToString() == "CRF")
            {
                if (ddltype.SelectedItem.Text == "CRF" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId)as SrNo, a.[WorkId], a.[Arthsankalpiyyear],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab], a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName], a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate] ,a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[JobNo],a.[RoadNo],a.[RoadLength],a.[SanctionDate],a.[SanctionAmount],a.[APhysicalScope],a.[ACommulative],a.[ATarget],a.[AAchievement],a.[BPhysicalScope],a.[BCommulative],a.[BTarget],a.[BAchievement],a.[CPhysicalScope],a.[CCommulative],a.[CTarget],a.[CAchievement],a.[DPhysicalScope],a.[DCommulative],a.[DTarget],a.[DAchievement], a.[EPhysicalScope],a.[ECommulative],a.[ETarget],a.[EAchievement],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo], b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye] ,b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],[Jun],b.[Jul],b.[Aug] ,b.[Sep] ,b.[Oct],b.[Nov],b.[Dec],a.[Shera] ,a.[Img1],a.[Img2],a.[Img3] from [BudgetMasterCRF] as a join CRFProvision as b on a.WorkID=b.WorkID  order by SrNo", con);
                }
                else if (ddltype.SelectedItem.Text == "CRF" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId)as SrNo, a.[WorkId], a.[Arthsankalpiyyear],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab], a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName], a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate] ,a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[JobNo],a.[RoadNo],a.[RoadLength],a.[SanctionDate],a.[SanctionAmount],a.[APhysicalScope],a.[ACommulative],a.[ATarget],a.[AAchievement],a.[BPhysicalScope],a.[BCommulative],a.[BTarget],a.[BAchievement],a.[CPhysicalScope],a.[CCommulative],a.[CTarget],a.[CAchievement],a.[DPhysicalScope],a.[DCommulative],a.[DTarget],a.[DAchievement], a.[EPhysicalScope],a.[ECommulative],a.[ETarget],a.[EAchievement],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo], b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye] , b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],[Jun],b.[Jul],b.[Aug] ,b.[Sep] ,b.[Oct],b.[Nov],b.[Dec],a.[Shera] ,a.[Img1],a.[Img2],a.[Img3] from [BudgetMasterCRF] as a join CRFProvision as b on a.WorkID=b.WorkID where Type=N'" + ddltype.SelectedItem.Text + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "'", con);
                }
                else if (ddltype.SelectedItem.Text == "CRF" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId)as SrNo, a.[WorkId], a.[Arthsankalpiyyear],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab], a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName], a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate] ,a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[JobNo],a.[RoadNo],a.[RoadLength],a.[SanctionDate],a.[SanctionAmount],a.[APhysicalScope],a.[ACommulative],a.[ATarget],a.[AAchievement],a.[BPhysicalScope],a.[BCommulative],a.[BTarget],a.[BAchievement],a.[CPhysicalScope],a.[CCommulative],a.[CTarget],a.[CAchievement],a.[DPhysicalScope],a.[DCommulative],a.[DTarget],a.[DAchievement], a.[EPhysicalScope],a.[ECommulative],a.[ETarget],a.[EAchievement],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo], b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye] , b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],[Jun],b.[Jul],b.[Aug] ,b.[Sep] ,b.[Oct],b.[Nov],b.[Dec],a.[Shera] ,a.[Img1],a.[Img2],a.[Img3] from [BudgetMasterCRF] as a join CRFProvision as b on a.WorkID=b.WorkID where Type=N'" + ddltype.SelectedItem.Text + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and SubType=N'" + ddlupvibhag.SelectedItem.Text + "'", con);
                }
                else if (ddltype.SelectedItem.Text == "CRF" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId)as SrNo, a.[WorkId], a.[Arthsankalpiyyear],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab], a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName], a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate] ,a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[JobNo],a.[RoadNo],a.[RoadLength],a.[SanctionDate],a.[SanctionAmount],a.[APhysicalScope],a.[ACommulative],a.[ATarget],a.[AAchievement],a.[BPhysicalScope],a.[BCommulative],a.[BTarget],a.[BAchievement],a.[CPhysicalScope],a.[CCommulative],a.[CTarget],a.[CAchievement],a.[DPhysicalScope],a.[DCommulative],a.[DTarget],a.[DAchievement], a.[EPhysicalScope],a.[ECommulative],a.[ETarget],a.[EAchievement],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo], b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye] , b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],[Jun],b.[Jul],b.[Aug] ,b.[Sep] ,b.[Oct],b.[Nov],b.[Dec],a.[Shera], a.[Img1],a.[Img2],a.[Img3] from [BudgetMasterCRF] as a join CRFProvision as b on a.WorkID=b.WorkID where Type=N'" + ddltype.SelectedItem.Text + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and Workid=N'" + ddlworkid.SelectedItem.Text + "'", con);
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
            if (ddltype.SelectedItem.ToString() == "Nabard")
            {
                if (ddltype.SelectedItem.Text == "Nabard" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Type],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[Lekhashirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[RDF_NO],a.[PIC_NO],a.[PCR],a.[Road_No],a.[LengthRoad],a.[RoadType],a.[WBMI_km],a.[WBMII_km],a.[WBMIII_km],a.[BBM_km],a.[Carpet_km],a.[Surface_km],a.[CD_Works_No] ,b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo] ,b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera],a.[Img1],a.[Img2],a.[Img3] from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Nabard" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Type],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[Lekhashirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[RDF_NO],a.[PIC_NO],a.[PCR],a.[Road_No],a.[LengthRoad],a.[RoadType],a.[WBMI_km],a.[WBMII_km],a.[WBMIII_km],a.[BBM_km],a.[Carpet_km],a.[Surface_km],a.[CD_Works_No],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera],a.[Img1],a.[Img2],a.[Img3] from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID  where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Nabard" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Type],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[Lekhashirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[RDF_NO],a.[PIC_NO] ,a.[PCR],a.[Road_No],a.[LengthRoad],a.[RoadType],a.[WBMI_km],a.[WBMII_km],a.[WBMIII_km],a.[BBM_km],a.[Carpet_km],a.[Surface_km],a.[CD_Works_No],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera],a.[Img1],a.[Img2],a.[Img3] from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Nabard" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Type],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[Lekhashirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[RDF_NO],a.[PIC_NO],a.[PCR],a.[Road_No],a.[LengthRoad],a.[RoadType],a.[WBMI_km],a.[WBMII_km],a.[WBMIII_km],a.[BBM_km],a.[Carpet_km],a.[Surface_km],a.[CD_Works_No],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera],a.[Img1],a.[Img2],a.[Img3] from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and a.Workid=N'" + ddlworkid.SelectedItem.Text + "'", con);
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
            if (ddltype.SelectedItem.ToString() == "Road")
            {
                if (ddltype.SelectedItem.Text == "Road" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Type],a.[Dist],a.[Taluka],a.[Upvibhag],a.[PageNo],a.[ArthsankalpiyBab],[JulyBab],a.[Lekhashirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[DTakunone],  b.[Takunone],b.[DTakuntwo] ,b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],  b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug], b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan], b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera], a.[Img1],a.[Img2],a.[Img3] from BudgetMasterRoad as a  join RoadProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Road" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Type],a.[Dist],a.[Taluka],a.[Upvibhag],a.[PageNo],a.[ArthsankalpiyBab],[JulyBab],a.[Lekhashirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[DTakunone],  b.[Takunone],b.[DTakuntwo] ,b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],  b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug], b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan], b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera], a.[Img1],a.[Img2],a.[Img3] from BudgetMasterRoad as a  join RoadProvision as b on a.WorkID=b.WorkID  where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Road" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Type],a.[Dist],a.[Taluka],a.[Upvibhag],a.[PageNo],a.[ArthsankalpiyBab],[JulyBab],a.[Lekhashirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[DTakunone],  b.[Takunone],b.[DTakuntwo] ,b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],  b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug], b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan], b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera], a.[Img1],a.[Img2],a.[Img3] from BudgetMasterRoad as a  join RoadProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Road" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Type],a.[Dist],a.[Taluka],a.[Upvibhag],a.[PageNo],a.[ArthsankalpiyBab],[JulyBab],a.[Lekhashirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[DTakunone],  b.[Takunone],b.[DTakuntwo] ,b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],  b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug], b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan], b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera], a.[Img1],a.[Img2],a.[Img3] from BudgetMasterRoad as a  join RoadProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and a.Workid=N'" + ddlworkid.SelectedItem.Text + "'", con);
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
            if (ddltype.SelectedItem.ToString() == "MLA")
            {
                if (ddltype.SelectedItem.Text == "MLA" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka, a.Upvibhag,a.PageNo,a.LekhaShirsh,a.LekhaShirshName, a.SubType,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.KamacheName, a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank, a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat, a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.ManjurAmt, b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.AkunAnudan,b.Chalumonth, b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch, b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye, a.Shera,a.Img1,a.Img2,a.Img3,b.Jan,b.Feb,b.Mar,b.Apr,b.May,b.Jun,b.Jul,b.Aug,b.Sep,b.Oct,b.Nov,b.Dec from BudgetMasterMLA as a join MLAProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MLA" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka, a.Upvibhag,a.PageNo,a.LekhaShirsh,a.LekhaShirshName, a.SubType,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.KamacheName, a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank, a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat, a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.ManjurAmt, b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.AkunAnudan,b.Chalumonth, b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch, b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye, a.Shera,a.Img1,a.Img2,a.Img3,b.Jan,b.Feb,b.Mar,b.Apr,b.May,b.Jun,b.Jul,b.Aug,b.Sep,b.Oct,b.Nov,b.Dec from BudgetMasterMLA as a join MLAProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MLA" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka, a.Upvibhag,a.PageNo,a.LekhaShirsh,a.LekhaShirshName, a.SubType,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.KamacheName, a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank, a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat, a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.ManjurAmt, b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.AkunAnudan,b.Chalumonth, b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch, b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye, a.Shera,a.Img1,a.Img2,a.Img3,b.Jan,b.Feb,b.Mar,b.Apr,b.May,b.Jun,b.Jul,b.Aug,b.Sep,b.Oct,b.Nov,b.Dec from BudgetMasterMLA as a join MLAProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MLA" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka, a.Upvibhag,a.PageNo,a.LekhaShirsh,a.LekhaShirshName, a.SubType,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.KamacheName, a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank, a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat, a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.ManjurAmt, b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.AkunAnudan,b.Chalumonth, b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch, b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye, a.Shera,a.Img1,a.Img2,a.Img3,b.Jan,b.Feb,b.Mar,b.Apr,b.May,b.Jun,b.Jul,b.Aug,b.Sep,b.Oct,b.Nov,b.Dec from BudgetMasterMLA as a join MLAProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and a.Workid=N'" + ddlworkid.SelectedItem.Text + "'", con);
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
            if (ddltype.SelectedItem.ToString() == "MP")
            {
                if (ddltype.SelectedItem.Text == "MP" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka, a.Upvibhag,a.PageNo,a.LekhaShirsh,a.LekhaShirshName, a.SubType,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.KamacheName, a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank, a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat, a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.ManjurAmt, b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.AkunAnudan,b.Chalumonth, b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch, b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye, a.Shera,a.Img1,a.Img2,a.Img3,b.Jan,b.Feb,b.Mar,b.Apr,b.May,b.Jun,b.Jul,b.Aug,b.Sep,b.Oct,b.Nov,b.Dec from BudgetMasterMP as a join MPProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MP" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka, a.Upvibhag,a.PageNo,a.LekhaShirsh,a.LekhaShirshName, a.SubType,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.KamacheName, a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank, a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat, a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.ManjurAmt, b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.AkunAnudan,b.Chalumonth, b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch, b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye, a.Shera,a.Img1,a.Img2,a.Img3,b.Jan,b.Feb,b.Mar,b.Apr,b.May,b.Jun,b.Jul,b.Aug,b.Sep,b.Oct,b.Nov,b.Dec from BudgetMasterMP as a join MPProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MP" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka, a.Upvibhag,a.PageNo,a.LekhaShirsh,a.LekhaShirshName, a.SubType,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.KamacheName, a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank, a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat, a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.ManjurAmt, b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.AkunAnudan,b.Chalumonth, b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch, b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye, a.Shera,a.Img1,a.Img2,a.Img3,b.Jan,b.Feb,b.Mar,b.Apr,b.May,b.Jun,b.Jul,b.Aug,b.Sep,b.Oct,b.Nov,b.Dec from BudgetMasterMP as a join MPProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MP" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Dist,a.Taluka, a.Upvibhag,a.PageNo,a.LekhaShirsh,a.LekhaShirshName, a.SubType,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.KamacheName, a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank, a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat, a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.ManjurAmt, b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.AkunAnudan,b.Chalumonth, b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch, b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye, a.Shera,a.Img1,a.Img2,a.Img3,b.Jan,b.Feb,b.Mar,b.Apr,b.May,b.Jun,b.Jul,b.Aug,b.Sep,b.Oct,b.Nov,b.Dec from BudgetMasterMP as a join MPProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and a.Workid=N'" + ddlworkid.SelectedItem.Text + "'", con);
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
        }
        public void suballdata()
        {
            if (ddltype.SelectedItem.ToString() == "Building")
            {
                if (ddltype.SelectedItem.Text == "Building" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo,a.WorkId,b.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.LekhaShirsh,a.KamacheName,a.ThekedaarName,a.NividaKrmank,a.NividaAmt,a.NividaDate,a.KamPurnDate,b.DeyakachiSadyasthiti,b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.MagilKharch,b.Magni,b.VarshbharatilKharch,b.AikunKharch,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,a.Shera,a.Img1,a.Img2,a.Img3 FROM BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID  order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Building" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo,a.WorkId,b.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.LekhaShirsh,a.KamacheName,a.ThekedaarName,a.NividaKrmank,a.NividaAmt,a.NividaDate,a.KamPurnDate,b.DeyakachiSadyasthiti,b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.MagilKharch,b.Magni,b.VarshbharatilKharch,b.AikunKharch,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,a.Shera,a.Img1,a.Img2,a.Img3 FROM BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Building" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo,a.WorkId,b.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.LekhaShirsh,a.KamacheName,a.ThekedaarName,a.NividaKrmank,a.NividaAmt,a.NividaDate,a.KamPurnDate,b.DeyakachiSadyasthiti,b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.MagilKharch,b.Magni,b.VarshbharatilKharch,b.AikunKharch,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,a.Shera,a.Img1,a.Img2,a.Img3 FROM BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Building" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo,a.WorkId,b.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.LekhaShirsh,a.KamacheName,a.ThekedaarName,a.NividaKrmank,a.NividaAmt,a.NividaDate,a.KamPurnDate,b.DeyakachiSadyasthiti,b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.MagilKharch,b.Magni,b.VarshbharatilKharch,b.AikunKharch,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,a.Shera,a.Img1,a.Img2,a.Img3 FROM BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID  a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and a.Workid=N'" + ddlworkid.SelectedItem.Text + "'", con);           
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
            if (ddltype.SelectedItem.ToString() == "CRF")
            {
                if (ddltype.SelectedItem.Text == "CRF" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[KamacheName],a.[JobNo],a.[RoadNo],a.[RoadLength],a.[SanctionDate],a.[SanctionAmount],b.[MarchEndingExpn],b.[Tartud],b.[Chalukharch],b.[Magilkharch],b.[Magni],a.[NividaDate],a.[KamPurnDate],a.[NividaKrmank],a.[karyarambhadesh],a.[NividaAmt], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterCRF as a join CRFProvision as b on a.WorkID=b.WorkID order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "CRF" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[KamacheName],a.[JobNo],a.[RoadNo],a.[RoadLength],a.[SanctionDate],a.[SanctionAmount],b.[MarchEndingExpn],b.[Tartud],b.[Chalukharch],b.[Magilkharch],b.[Magni],a.[NividaDate],a.[KamPurnDate],a.[NividaKrmank],a.[karyarambhadesh],a.[NividaAmt], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterCRF as a join CRFProvision as b on a.WorkID=b.WorkID where Type=N'" + ddltype.SelectedItem.Text + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "'", con);
                }
                else if (ddltype.SelectedItem.Text == "CRF" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[KamacheName],a.[JobNo],a.[RoadNo],a.[RoadLength],a.[SanctionDate],a.[SanctionAmount],b.[MarchEndingExpn],b.[Tartud],b.[Chalukharch],b.[Magilkharch],b.[Magni],a.[NividaDate],a.[KamPurnDate],a.[NividaKrmank],a.[karyarambhadesh],a.[NividaAmt], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterCRF as a join CRFProvision as b on a.WorkID=b.WorkID where Type=N'" + ddltype.SelectedItem.Text + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and SubType=N'" + ddlupvibhag.SelectedItem.Text + "'", con);
                }
                else if (ddltype.SelectedItem.Text == "CRF" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId)as SrNo,a.[WorkId],a.[Arthsankalpiyyear],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[KamacheName],a.[JobNo],a.[RoadNo],a.[RoadLength],a.[SanctionDate],a.[SanctionAmount],b.[MarchEndingExpn],b.[Tartud],b.[Chalukharch],b.[Magilkharch],b.[Magni],a.[NividaDate],a.[KamPurnDate],a.[NividaKrmank],a.[karyarambhadesh],a.[NividaAmt], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterCRF as a join CRFProvision as b on a.WorkID=b.WorkID where Type=N'" + ddltype.SelectedItem.Text + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and Workid=N'" + ddlworkid.SelectedItem.Text + "'", con);
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
            if (ddltype.SelectedItem.ToString() == "Nabard")
            {
                if (ddltype.SelectedItem.Text == "Nabard" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT  ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo,a.[WorkId],b.[Arthsankalpiyyear],a.[ArthsankalpiyBab], a.[Dist],a.[Taluka],a.[KamacheName],a.[RDF_NO],a.[PIC_NO],a.[PrashaskiyAmt],a.[TrantrikAmt],a.[TrantrikKrmank],a.[TrantrikDate],b.[MarchEndingExpn],b.[Tartud],b.[Magni],b. [Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PCR],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Nabard" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT  ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo,a.[WorkId],b.[Arthsankalpiyyear],a.[ArthsankalpiyBab], a.[Dist],a.[Taluka],a.[KamacheName],a.[RDF_NO],a.[PIC_NO],a.[PrashaskiyAmt],a.[TrantrikAmt],a.[TrantrikKrmank],a.[TrantrikDate],b.[MarchEndingExpn],b.[Tartud],b.[Magni],b. [Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PCR],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID where Type=N'" + ddltype.SelectedItem.Text + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "'", con);
                }
                else if (ddltype.SelectedItem.Text == "Nabard" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT  ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo,a.[WorkId],b.[Arthsankalpiyyear],a.[ArthsankalpiyBab], a.[Dist],a.[Taluka],a.[KamacheName],a.[RDF_NO],a.[PIC_NO],a.[PrashaskiyAmt],a.[TrantrikAmt],a.[TrantrikKrmank],a.[TrantrikDate],b.[MarchEndingExpn],b.[Tartud],b.[Magni],b. [Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PCR],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID where Type=N'" + ddltype.SelectedItem.Text + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and SubType=N'" + ddlupvibhag.SelectedItem.Text + "'", con);
                }
                else if (ddltype.SelectedItem.Text == "Nabard" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT  ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo,a.[WorkId],b.[Arthsankalpiyyear],a.[ArthsankalpiyBab], a.[Dist],a.[Taluka],a.[KamacheName],a.[RDF_NO],a.[PIC_NO],a.[PrashaskiyAmt],a.[TrantrikAmt],a.[TrantrikKrmank],a.[TrantrikDate],b.[MarchEndingExpn],b.[Tartud],b.[Magni],b. [Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],a.[Sadyasthiti],a.[Pahanikramank],a.[PCR],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID where Type=N'" + ddltype.SelectedItem.Text + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and Workid=N'" + ddlworkid.SelectedItem.Text + "'", con);
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
            if (ddltype.SelectedItem.ToString() == "Road")
            {
                if (ddltype.SelectedItem.Text == "Road" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo, a.[WorkId], a.[Arthsankalpiyyear],a.[PageNo],a.[ArthsankalpiyBab],a.[JulyBab],a.[Type],a.[Upvibhag],a.[SubType],a.[LekhaShirsh], a.[KamacheName],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[Takunone],b.[Takuntwo],b.[Tartud],b.[AkunAnudan],b.[Magni],a.[Sadyasthiti],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterRoad as a join RoadProvision as b on a.WorkID=b.WorkID order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "Road" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo, a.[WorkId], a.[Arthsankalpiyyear],a.[PageNo],a.[ArthsankalpiyBab],a.[JulyBab],a.[Type],a.[Upvibhag],a.[SubType],a.[LekhaShirsh], a.[KamacheName],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[Takunone],b.[Takuntwo],b.[Tartud],b.[AkunAnudan],b.[Magni],a.[Sadyasthiti],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterRoad as a join RoadProvision as b on a.WorkID=b.WorkID where Type='" + ddltype.SelectedItem.Text + "' and Upvibhag='" + ddlvibhag.SelectedItem.Text + "'", con);
                }
                else if (ddltype.SelectedItem.Text == "Road" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo, a.[WorkId], a.[Arthsankalpiyyear],a.[PageNo],a.[ArthsankalpiyBab],a.[JulyBab],a.[Type],a.[Upvibhag],a.[SubType],a.[LekhaShirsh], a.[KamacheName],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[Takunone],b.[Takuntwo],b.[Tartud],b.[AkunAnudan],b.[Magni],a.[Sadyasthiti],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterRoad as a join RoadProvision as b on a.WorkID=b.WorkID where Type='" + ddltype.SelectedItem.Text + "' and Upvibhag='" + ddlvibhag.SelectedItem.Text + "' and SubType='" + ddlupvibhag.SelectedItem.Text + "'", con);
                }
                else if (ddltype.SelectedItem.Text == "Road" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY b.WorkId DESC)as SrNo, a.[WorkId], a.[Arthsankalpiyyear],a.[PageNo],a.[ArthsankalpiyBab],a.[JulyBab],a.[Type],a.[Upvibhag],a.[SubType],a.[LekhaShirsh], a.[KamacheName],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[Takunone],b.[Takuntwo],b.[Tartud],b.[AkunAnudan],b.[Magni],a.[Sadyasthiti],a.[Shera],a.[Img1],a.[Img2],a.[Img3] FROM BudgetMasterRoad as a join RoadProvision as b on a.WorkID=b.WorkID where Type='" + ddltype.SelectedItem.Text + "' and Upvibhag='" + ddlvibhag.SelectedItem.Text + "' and SubType='" + ddlupvibhag.SelectedItem.Text + "' and Workid='" + ddlworkid.SelectedItem.Text + "'", con);
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
            if (ddltype.SelectedItem.ToString() == "MLA")
            {
                if (ddltype.SelectedItem.Text == "MLA" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo, a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.SubType,a.LekhaShirsh,a.KamacheName,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.NividaKrmank,a.NividaDate,b.ManjurAmt,b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.Magilkharch,b.AkunAnudan,b.Magni,a.Sadyasthiti,a.Shera,a.Img1,a.Img2, a.Img3 from BudgetMasterMLA as a  join MLAProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MLA" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo, a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.SubType,a.LekhaShirsh,a.KamacheName,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.NividaKrmank,a.NividaDate,b.ManjurAmt,b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.Magilkharch,b.AkunAnudan,b.Magni,a.Sadyasthiti,a.Shera,a.Img1,a.Img2, a.Img3 from BudgetMasterMLA as a  join MLAProvision as b on a.WorkID=b.WorkID  where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MLA" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo, a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.SubType,a.LekhaShirsh,a.KamacheName,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.NividaKrmank,a.NividaDate,b.ManjurAmt,b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.Magilkharch,b.AkunAnudan,b.Magni,a.Sadyasthiti,a.Shera,a.Img1,a.Img2, a.Img3 from BudgetMasterMLA as a  join MLAProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MLA" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("select ROW_NUMBER() over  (order by b.WorkId desc)as SrNo, a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.SubType,a.LekhaShirsh,a.KamacheName,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.NividaKrmank,a.NividaDate,b.ManjurAmt,b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.Magilkharch,b.AkunAnudan,b.Magni,a.Sadyasthiti,a.Shera,a.Img1,a.Img2, a.Img3 from BudgetMasterMLA as a  join MLAProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and a.Workid=N'" + ddlworkid.SelectedItem.Text + "'", con);
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
            if (ddltype.SelectedItem.ToString() == "MP")
            {
                if (ddltype.SelectedItem.Text == "MP" && ddlvibhag.SelectedItem.Text == "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select Row_Number() Over (Order by b.WorkId desc) as SrNo, a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.SubType,a.LekhaShirsh,a.KamacheName,a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.TrantrikAmt,a.NividaAmt,a.NividaKrmank,a.NividaDate,b.ManjurAmt,b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.Magilkharch,b.AkunAnudan,b.Magni,a.Sadyasthiti,a.Shera,a.Img1,a.Img2, a.Img3 from BudgetMasterMP as a  join MPProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MP" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text == "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select Row_Number() Over (Order by b.WorkId desc) as SrNo, a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.SubType,a.LekhaShirsh,a.KamacheName,a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.TrantrikAmt,a.NividaAmt,a.NividaKrmank,a.NividaDate,b.ManjurAmt,b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.Magilkharch,b.AkunAnudan,b.Magni,a.Sadyasthiti,a.Shera,a.Img1,a.Img2, a.Img3 from BudgetMasterMP as a  join MPProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MP" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text == "निवडा")
                {
                    sdaa = new SqlDataAdapter("select Row_Number() Over (Order by b.WorkId desc) as SrNo, a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.SubType,a.LekhaShirsh,a.KamacheName,a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.TrantrikAmt,a.NividaAmt,a.NividaKrmank,a.NividaDate,b.ManjurAmt,b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.Magilkharch,b.AkunAnudan,b.Magni,a.Sadyasthiti,a.Shera,a.Img1,a.Img2, a.Img3 from BudgetMasterMP as a  join MPProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' order by SrNo desc", con);
                }
                else if (ddltype.SelectedItem.Text == "MP" && ddlvibhag.SelectedItem.Text != "निवडा" && ddlupvibhag.SelectedItem.Text != "निवडा" && ddlworkid.SelectedItem.Text != "निवडा")
                {
                    sdaa = new SqlDataAdapter("select Row_Number() Over (Order by b.WorkId desc) as SrNo, a.WorkId,a.Arthsankalpiyyear,a.ArthsankalpiyBab,a.Type,a.Upvibhag,a.SubType,a.LekhaShirsh,a.KamacheName,a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.TrantrikAmt,a.NividaAmt,a.NividaKrmank,a.NividaDate,b.ManjurAmt,b.MarchEndingExpn,b.UrvaritAmt,b.Tartud,b.Magilkharch,b.AkunAnudan,b.Magni,a.Sadyasthiti,a.Shera,a.Img1,a.Img2, a.Img3 from BudgetMasterMP as a  join MPProvision as b on a.WorkID=b.WorkID where a.Type=N'" + ddltype.SelectedItem.Text + "' and a.Upvibhag=N'" + ddlvibhag.SelectedItem.Text + "' and a.SubType=N'" + ddlupvibhag.SelectedItem.Text + "' and a.Workid=N'" + ddlworkid.SelectedItem.Text + "'", con);
                }
                sdaa.Fill(dtt);
                if (dtt.Rows.Count == 0)
                {
                    nullgrid();
                }
            }
        }
        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagepathadd();
            vibhag();
            if (rdofiftytwo.Checked == true)
            {
                masteralldata();
                radio();
            }
            if (rdothirtyfive.Checked == true)
            {
                suballdata();
                radio1();
            }
        }

        protected void ddlvibhag_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagepathadd();
            upvibhag();
            if (rdofiftytwo.Checked == true)
            {
                masteralldata();
                radio();
            }
            if (rdothirtyfive.Checked == true)
            {
                suballdata();
                radio1();
            }
        }
        public void imagepathadd()
        {
            a = "";
            b = "";
            c = "";
            SqlDataAdapter sda=new SqlDataAdapter("select ImagePath from ImagesPath where WorkID=N'"+ddlworkid.SelectedItem.ToString()+"' and ImgID=1",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                a = dr[0].ToString();
            }
            SqlDataAdapter sda1 = new SqlDataAdapter("select ImagePath from ImagesPath where WorkID=N'" + ddlworkid.SelectedItem.ToString() + "' and ImgID=2", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                b = dr1[0].ToString();
            }
            SqlDataAdapter sda2 = new SqlDataAdapter("select ImagePath from ImagesPath where WorkID=N'" + ddlworkid.SelectedItem.ToString() + "' and ImgID=3", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                c = dr2[0].ToString();
            }
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Update BudgetMasterBuilding set Img1='" + a + "',Img2='" + b + "',Img3='" + c + "' where WorkID=N'" + ddlworkid.SelectedItem.ToString() + "'", con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        protected void ddlworkid_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagepathadd();
            if (rdofiftytwo.Checked == true)
            {
                masteralldata();
                radio();
            }
            if (rdothirtyfive.Checked == true)
            {
                suballdata();
                radio1();
            }
        }
        public void maintype()
        {
            ddltype.Items.Clear();
            ddltype.Items.Add("निवडा");
            SqlDataAdapter sda = new SqlDataAdapter("select Type from SettingType", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddltype.Items.Add(dr[0].ToString());
            }
         }
        public void vibhag()
        {
            SqlDataAdapter sdac = new SqlDataAdapter();
            ddlvibhag.Items.Clear();
            ddlupvibhag.Items.Clear();
            ddlworkid.Items.Clear();
            ddlvibhag.Items.Add("निवडा");
            ddlupvibhag.Items.Add("निवडा");
            ddlworkid.Items.Add("निवडा");
            if (ddltype.Text == "Building")
            {
                sdac = new SqlDataAdapter("select Upvibhag From BudgetMasterBuilding where Type=N'" + ddltype.SelectedItem.Text + "' Group by Upvibhag", con);
            }
            if (ddltype.Text == "Nabard")
            {
                sdac = new SqlDataAdapter("select Upvibhag From BudgetMasterNABARD where Type=N'" + ddltype.SelectedItem.Text + "' Group by Upvibhag", con);
            }
            if (ddltype.Text == "Road")
            {
                sdac = new SqlDataAdapter("select Upvibhag From BudgetMasterRoad where Type=N'" + ddltype.SelectedItem.Text + "' Group by Upvibhag", con);
            }
            if (ddltype.Text == "CRF")
            {
                sdac = new SqlDataAdapter("select Upvibhag From BudgetMasterCRF where Type=N'" + ddltype.SelectedItem.Text + "' Group by Upvibhag", con);
            }
            if (ddltype.Text == "MLA")
            {
                sdac = new SqlDataAdapter("select Upvibhag From BudgetMasterMLA where Type=N'" + ddltype.SelectedItem.Text + "' Group by Upvibhag", con);
            }
            if (ddltype.Text == "MP")
            {
                sdac = new SqlDataAdapter("select Upvibhag From BudgetMasterMP where Type=N'" + ddltype.SelectedItem.Text + "' Group by Upvibhag", con);
            }
            if (ddltype.Text == "DPDC")
            {
                sdac = new SqlDataAdapter("select Upvibhag From BudgetMasterDPDC where Type=N'" + ddltype.SelectedItem.Text + "' Group by Upvibhag", con);
            }
            DataTable dt = new DataTable();
            sdac.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlvibhag.Items.Add(dr[0].ToString());
            }
            ddlvibhag.Items.Add("संपूर्ण");
        }
        public void upvibhag()
        {
            SqlDataAdapter sdac = new SqlDataAdapter();
            ddlupvibhag.Items.Clear();
            ddlworkid.Items.Clear();
            ddlworkid.Items.Add("निवडा");
            ddlupvibhag.Items.Add("निवडा");
            if (ddltype.Text == "Building")
            {
                sdac = new SqlDataAdapter("select SubType from BudgetMasterBuilding where Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "' and Type=N'" + ddltype.SelectedItem.ToString() + "' Group by SubType", con);
            }
            if (ddltype.Text == "Nabard")
            {
                sdac = new SqlDataAdapter("select SubType from BudgetMasterNABARD where Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "' and Type=N'" + ddltype.SelectedItem.ToString() + "' Group by SubType", con);
            }
            if (ddltype.Text == "Road")
            {
                sdac = new SqlDataAdapter("select SubType from BudgetMasterRoad where Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "' and Type=N'" + ddltype.SelectedItem.ToString() + "' Group by SubType", con);
            }
            if (ddltype.Text == "CRF")
            {
                sdac = new SqlDataAdapter("select SubType from BudgetMasterCRF where Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "' and Type=N'" + ddltype.SelectedItem.ToString() + "' Group by SubType", con);
            }
            if (ddltype.Text == "MLA")
            {
                sdac = new SqlDataAdapter("select SubType from BudgetMasterMLA where Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "' and Type=N'" + ddltype.SelectedItem.ToString() + "' Group by SubType", con);
            }
            if (ddltype.Text == "MP")
            {
                sdac = new SqlDataAdapter("select SubType from BudgetMasterMP where Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "' and Type=N'" + ddltype.SelectedItem.ToString() + "' Group by SubType", con);
            }
            if (ddltype.Text == "DPDC")
            {
                sdac = new SqlDataAdapter("select SubType from BudgetMasterDPDC where Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "' and Type=N'" + ddltype.SelectedItem.ToString() + "' Group by SubType", con);
            }

            DataTable dt = new DataTable();
            sdac.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlupvibhag.Items.Add(dr[0].ToString());
            }
            ddlupvibhag.Items.Add("संपूर्ण");
        }
        public void workid()
        {
            SqlDataAdapter sdac = new SqlDataAdapter();
            ddlworkid.Items.Clear();
            ddlworkid.Items.Add("निवडा");
            if (ddltype.Text == "Building")
            {
                sdac = new SqlDataAdapter("select Workid from BudgetMasterBuilding where SubType=N'" + ddlupvibhag.SelectedItem.ToString() + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "'", con);
            }
            if (ddltype.Text == "Nabard")
            {
                sdac = new SqlDataAdapter("select Workid from BudgetMasterNABARD where SubType=N'" + ddlupvibhag.SelectedItem.ToString() + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "'", con);
            }
            if (ddltype.Text == "Road")
            {
                sdac = new SqlDataAdapter("select Workid from BudgetMasterRoad where SubType=N'" + ddlupvibhag.SelectedItem.ToString() + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "'", con);
            }
            if (ddltype.Text == "CRF")
            {
                sdac = new SqlDataAdapter("select Workid from BudgetMasterCRF where SubType=N'" + ddlupvibhag.SelectedItem.ToString() + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "'", con);
            }
            if (ddltype.Text == "MLA")
            {
                sdac = new SqlDataAdapter("select Workid from BudgetMasterMLA where SubType=N'" + ddlupvibhag.SelectedItem.ToString() + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "'", con);
            }
            if (ddltype.Text == "MP")
            {
                sdac = new SqlDataAdapter("select Workid from BudgetMasterMP where SubType=N'" + ddlupvibhag.SelectedItem.ToString() + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "'", con);
            } 
            if (ddltype.Text == "DPDC")
            {
                sdac = new SqlDataAdapter("select Workid from BudgetMasterDPDC where SubType=N'" + ddlupvibhag.SelectedItem.ToString() + "' and Upvibhag=N'" + ddlvibhag.SelectedItem.ToString() + "'", con);
            }
            DataTable dt = new DataTable();
            sdac.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ddlworkid.Items.Add(dr[0].ToString());
            }
            ddlworkid.Items.Add("संपूर्ण");
        }
        protected void ddlupvibhag_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagepathadd();
            workid();
            if (rdofiftytwo.Checked == true)
            {
                masteralldata();
                radio();
            }
            if (rdothirtyfive.Checked == true)
            {
                suballdata();
                radio1();
            }
        }

        protected void rdofiftytwo_CheckedChanged(object sender, EventArgs e)
        {
            ddltype.Items.Clear();
            ddlvibhag.Items.Clear();
            ddlupvibhag.Items.Clear();
            ddlworkid.Items.Clear();
            txtsearch.Text = "";
            ddltype.Items.Add("निवडा");
            ddlvibhag.Items.Add("निवडा");
            ddlupvibhag.Items.Add("निवडा");
            ddlworkid.Items.Add("निवडा");
            radio();
            maintype();
        }

        protected void rdothirtyfive_CheckedChanged(object sender, EventArgs e)
        {
            ddltype.Items.Clear();
            ddlvibhag.Items.Clear();
            ddlupvibhag.Items.Clear();
            ddlworkid.Items.Clear();
            txtsearch.Text = "";
            ddltype.Items.Add("निवडा");
            ddlvibhag.Items.Add("निवडा");
            ddlupvibhag.Items.Add("निवडा");
            ddlworkid.Items.Add("निवडा");
            nullgrid();
            radio();
            maintype();
        }

        public void nullgrid()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();
            crfmpr.DataSource = null;
            crfmpr.DataBind();
            crfmaster.DataSource = null;
            crfmaster.DataBind();
            nabardmpr.DataSource = null;
            nabardmpr.DataBind();
            nabardmaster.DataSource = null;
            nabardmaster.DataBind();
            roadmpr.DataSource = null;
            roadmpr.DataBind();
            roadmaster.DataSource = null;
            roadmaster.DataBind();
            MLAMPR.DataSource = null;
            MLAMPR.DataBind();
            MLAmaster.DataSource = null;
            MLAmaster.DataBind();
            MPMPR.DataSource = null;
            MPMPR.DataBind();
            MPmaster.DataSource = null;
            MPmaster.DataBind();

            datasearch.DataSource = null;
            datasearch.DataBind();
        }
        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {

            sdap = new SqlDataAdapter("SELECT B.Type,C.Type,N.Type,R.Type,ML.Type,MP.Type FROM BudgetMasterBuilding B FULL OUTER JOIN BudgetMasterCRF C ON B.WorkID=C.WorkID  full outer join BudgetMasterNABARD N on B.WorkID= N.WorkID full outer join BudgetMasterRoad R on B.WorkID=R.WorkID full outer join BudgetMasterML ML on B.WorkID=ML.WorkID full outer join BudgetMasterMP on B.WorkID=MP.WorkID where B.WorkID = '" + txtsearch.Text + "' or C.workID = '" + txtsearch.Text + "' or N.workID = '" + txtsearch.Text + "' or R.workID = '" + txtsearch.Text + "'or ML.workID = '" + txtsearch.Text + "'or MP.workID = '" + txtsearch.Text + "'", con);
            sdap.Fill(dp);
            foreach (DataRow dr in dp.Rows)
            {
                p = dr[0].ToString()+dr[1].ToString()+dr[2].ToString()+dr[3].ToString();
            }
          
            if(p=="Building")
            {
                sdaa = new SqlDataAdapter("select top 1 ROW_NUMBER() over  (order by b.WorkId desc)as SrNo,a.WorkId,a.Arthsankalpiyyear,a.Akrmank,a.Type,a.Dist,a.Taluka,a.Upvibhag,a.ShakhaAbhyantaName,a.ShakhaAbhiyantMobile,a.UpabhyantaName,a.UpAbhiyantaMobile,a.KhasdaracheName,a.AmdaracheName,a.SubType,a.LekhaShirsh,a.LekhaShirshName,a.ArthsankalpiyBab,a.KamacheName,a.PrashaskiyKramank,a.PrashaskiyDate,a.PrashaskiyAmt,a.TrantrikKrmank,a.TrantrikDate,a.TrantrikAmt,a.Kamachevav,a.ThekedaarName,a.ThekedarMobile,a.NividaKrmank,a.NividaAmt,a.Karyarambhadesh,a.NividaDate,a.KamachiMudat,a.KamPurnDate,b.MudatVadhiDate,b.DeyakachiSadyasthiti,b.MarchEndingExpn,b.Tartud,b.AkunAnudan,b.Chalumonth,b.Chalukharch,b.Magilmonth,b.Magilkharch,b.VarshbharatilKharch,b.AikunKharch,b.Magni,a.Sadyasthiti,a.Pahanikramank,a.PahaniMudye,a.Shera,a.Img1,a.Img2,a.Img3 from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID  where a.WorkID='" + txtsearch.Text + "' order by SrNo desc", con);
            }
             if(p=="CRF")
            {
                sdaa=new SqlDataAdapter("select * from BudgetMasterCRF where WorkID='"+txtsearch.Text+"'",con);
            }
             if(p=="Nabard")
            {
                sdaa=new SqlDataAdapter("select * from BudgetMasterNABARD where WorkID='"+txtsearch.Text+"'",con);
            }
             if(p=="Road")
            {
                sdaa = new SqlDataAdapter("select * from BudgetMasterRoad where WorkID='" + txtsearch.Text + "'", con);
            }
             if (p == "MLA")
             {
                 sdaa = new SqlDataAdapter("select * from BudgetMasterMLA where WorkID='" + txtsearch.Text + "'", con);
             }
             if (p == "MP")
             {
                 sdaa = new SqlDataAdapter("select * from BudgetMasterMP where WorkID='" + txtsearch.Text + "'", con);
             }
             if (p == "DPDC")
             {
                 sdaa = new SqlDataAdapter("select * from BudgetMasterDPDC where WorkID='" + txtsearch.Text + "'", con);
             }
            sdaa.Fill(dtt);
            imagepathadd();
            nullgrid();
            if (rdofiftytwo.Checked == true)
            {
                radio();
            }
            if (rdothirtyfive.Checked == true)
            {
                radio1();
            }
            
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            return AutoFillProducts(prefixText);
        }

        private static List<string> AutoFillProducts(string prefixText)
        {
           using (SqlConnection conn = new SqlConnection())  
           {  
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
               
                //SqlDataAdapter sdaa=new SqlDataAdapter("select WorkId from BudgetMaster where WorkID like '"+prefixText+"%'",conn);
                SqlDataAdapter sdaa = new SqlDataAdapter("SELECT coalesce(B.WorkID,C.WorkID,N.WorkID,R.WorkID,ML.WorkID,MP.WorkID)as WorkID FROM BudgetMasterBuilding B FULL OUTER JOIN BudgetMasterCRF c ON B.WorkID=C.WorkID  full outer join BudgetMasterNABARD N on B.WorkID= N.WorkID full outer join BudgetMasterRoad R on B.WorkID=R.WorkID full outer join BudgetMasterMLA ML on B.WorkID=ML.WorkID full outer join BudgetMasterMP MP on B.WorkID=MP.WorkID where B.WorkID like '" + prefixText + "%' or C.workID like '" + prefixText + "%' or N.workID like '" + prefixText + "%' or R.workID like '" + prefixText + "%' or ML.workID like '" + prefixText + "%' or MP.workID like '" + prefixText + "%' ", conn);
                List<string> countryNames = new List<string>();
                DataTable dt=new DataTable();
                sdaa.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                     countryNames.Add(dr["WorkId"].ToString());
                }
                return countryNames;
            }
        }

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MasterReport" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            // BindGridAll();
            Panel1.RenderControl(htw);
            //GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Tell the compiler that the control is rendered
             * explicitly by overriding the VerifyRenderingInServerForm event.*/
        }
        GridView g1=new GridView();
        protected void Print(object sender, EventArgs e)
        {
            if (GridView1.DataSource != null)
            {
                g1 = GridView1;
            }
            else if (GridView2.DataSource != null)
            {
                g1 = GridView2;
            }
            else if (crfmpr.DataSource != null)
            {
                g1 = crfmpr;
            }
            else if (crfmaster.DataSource != null)
            {
                g1 = crfmaster;
            }
            else if(nabardmpr.DataSource!=null)
            {
                g1 = nabardmpr;
            }
            else if (nabardmaster.DataSource != null)
            {
                g1 = nabardmaster;
            }
            else if (roadmpr.DataSource != null)
            {
                g1 = roadmpr;
            }
            else if (roadmaster.DataSource != null)
            {
                g1 = roadmaster;
            }
            else if (MPMPR.DataSource != null)
            {
                g1 = MPMPR;
            }
            else if (MPmaster.DataSource != null)
            {
                g1 = MPmaster;
            }
            else if (MLAMPR.DataSource != null)
            {
                g1 = MLAMPR;
            }
            else if (MLAmaster.DataSource != null)
            {
                g1 = MLAmaster;
            }
            try
            {
                g1.UseAccessibleHeader = true;
                g1.HeaderRow.TableSection = TableRowSection.TableHeader;
                g1.FooterRow.TableSection = TableRowSection.TableFooter;
                g1.Attributes["style"] = "border-collapse:separate";
                foreach (GridViewRow row in g1.Rows)
                {
                    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
                    {
                        row.Attributes["style"] = "page-break-after:always;";
                    }
                }
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                g1.RenderControl(hw);
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
                g1.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        int tempcounter = 0;

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tempcounter = tempcounter + 1;
                if (tempcounter == 10)
                {
                    e.Row.Attributes.Add("style", "page-break-after: always;");
                    tempcounter = 0;
                }
            }
        }

    }
}