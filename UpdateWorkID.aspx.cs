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

namespace PWdEEBudget
{
    public partial class UpdateWorkID : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        clsSMS_CRUD SMSobj = new clsSMS_CRUD();
        string mobileNumber, message, strCommandType;
        static string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropdatainsert();
                datacode();
            }
            gettype(ddlType);
        }
        public static void gettype(DropDownList dropDown)
        {
            type = dropDown.SelectedItem.Text;
        }
        public void dropdatainsert()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Type FROM [SettingType] order by ID", con);
            DataTable dp = new DataTable();
            sda.Fill(dp);
            ddlType.Items.Clear();
            foreach (DataRow dr in dp.Rows)
            {
                ddlType.Items.Add(dr["Type"].ToString());
            }
        }

        protected void txtBudgetWorkID_TextChanged(object sender, EventArgs e)
        {
            datasearching();
        }

        public void datasearching()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            SqlDataAdapter sd;
            DataTable dt = new DataTable();
            if (ddlType.SelectedItem.Text == "Building")
            {
                sd = new SqlDataAdapter("Select distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type],a.[Dist],a.[Taluka],a.[Upvibhag],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName] ,a.[AmdaracheName],a.[SubType],a.[LekhaShirsh] ,a.[LekhaShirshName] ,a.[ArthsankalpiyBab],a.[KamacheName],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[Kamachevav],a.[ThekedaarName] ,a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch] ,b.[Vidyutprama],b.[Vidyutvitarit],b.[Dviguni],b.[Itarkhrch], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);               
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "CRF")
            {
                sd = new SqlDataAdapter("select distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[JobNo],a.[RoadNo],a.[RoadLength],a.[SanctionDate],a.[SanctionAmount],a.[APhysicalScope],a.[ACommulative],a.[ATarget] ,a.[AAchievement],a.[BPhysicalScope],a.[BCommulative],a.[BTarget],a.[BAchievement],a.[CPhysicalScope] ,a.[CCommulative] ,a.[CTarget] ,a.[CAchievement] ,a.[DPhysicalScope],a.[DCommulative],a.[DTarget],a.[DAchievement],a.[EPhysicalScope],a.[ECommulative] ,a.[ETarget],a.[EAchievement],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[OtherExpen] ,b.[ExpenCost],b.[ExpenExpen], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterCRF as a join CRFProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);               
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "Nabard")
            {
                sd = new SqlDataAdapter("select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type],a.[Dist] ,a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[Lekhashirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName] ,a.[Kamachavav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate] ,a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile] ,a.[NividaKrmank] ,a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[RDF_NO],a.[PIC_NO],a.[PCR],a.[Road_No],a.[LengthRoad],a.[RoadType],a.[WBMI_km],a.[WBMII_km],a.[WBMIII_km],a.[BBM_km],a.[Carpet_km],a.[Surface_km],a.[CD_Works_No],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],a.[Sadyasthiti] ,a.[Pahanikramank] ,a.[PahaniMudye] ,a.[Shera] from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);              
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "Road")
            {
                sd = new SqlDataAdapter("Select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type],a.[Dist],a.[Taluka],a.[Upvibhag],a.[PageNo],a.[ArthsankalpiyBab],a.[JulyBab],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName] ,a.[UpAbhiyantaMobile] ,a.[KhasdaracheName] ,a.[AmdaracheName],a.[KamacheName],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[Kamachevav],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[Vidyutprama],b.[Vidyutvitarit],b.[Dviguni],b.[Itarkhrch], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterRoad as a join RoadProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);               
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "DPDC")
            {
                sd = new SqlDataAdapter("Select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName] ,a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate] ,a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt] ,a.[ThekedaarName] ,a.[ThekedarMobile] ,a.[NividaKrmank] ,a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[ComputerCRC],b.[ObjectCode],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[Vidyutprama],b.[Vidyutvitarit],b.[Dviguni],b.[Itarkhrch],a.[Sadyasthiti],a.[CompletedDate],a.[PahaniMudye],a.[Shera] from BudgetMasterDPDC as a join DPDCProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);               
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "MLA")
            {
                sd = new SqlDataAdapter("Select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type],a.[Dist],a.[Taluka],a.[Upvibhag],a.[PageNo],a.[ArthsankalpiyBab],a.[JulyBab],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName] ,a.[UpAbhiyantaMobile] ,a.[KhasdaracheName] ,a.[AmdaracheName],a.[KamacheName],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[Kamachevav],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate], b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[Vidyutprama],b.[Vidyutvitarit],b.[Dviguni],b.[Itarkhrch], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterMLA as a join MLAProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);               
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "MP")
            {
                sd = new SqlDataAdapter("Select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type],a.[Dist],a.[Taluka],a.[Upvibhag],a.[PageNo],a.[ArthsankalpiyBab],a.[JulyBab],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName] ,a.[UpAbhiyantaMobile] ,a.[KhasdaracheName] ,a.[AmdaracheName],a.[KamacheName],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[Kamachevav],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[DeyakachiSadyasthiti],b.[ManjurAmt],b.[MarchEndingExpn],b.[UrvaritAmt],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[Vidyutprama],b.[Vidyutvitarit],b.[Dviguni],b.[Itarkhrch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterMP as a join MPProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);               
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "Deposit")
            {
                sd = new SqlDataAdapter("Select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type],a.[Dist],a.[Taluka],a.[Upvibhag],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName] ,a.[AmdaracheName],a.[SubType],a.[VibhagType],a.[LekhaShirsh] ,a.[LekhaShirshName] ,a.[ArthsankalpiyBab],a.[KamacheName],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[Kamachevav],a.[ThekedaarName] ,a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[ShilakThev],b.[VitariThev],b.[DeyakachiSadyasthiti],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch] ,b.[Vidyutprama],b.[Vidyutvitarit],b.[Dviguni],b.[Itarkhrch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterDepositFund as a join DepositFundProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);               
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "3054_Gat_A")
            {
                sd = new SqlDataAdapter("Select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type] ,a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate] ,a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName] ,a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[GAadeshKramank],a.[GUpshirsh],a.[GJobKramank],a.[GJobRakkam],a.[GDambarichePariman],a.[GDambarichiRakkam],a.[GDurustichaprakar],a.[GVaperDambarichePariman],a.[GKampurnKarnyachaDinak],a.[GKampurnJhalyachaDinak],a.[GDeyakSadarKelyachaDinak] ,a.[GParitKelyachaDinak],b.[MudatVadhiDate],b.[ShilakDayitvAmt],b.[MarchEndingExpn],b.[DayitvAvshyakYesNo],b.[DayitvAmt],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch] ,b.[VidyutikaranAmt],b.[VidyutikaranExpen],b.[DambarichaExpen],b.[Dviguni],b.[Itarkhrch], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterGAT_A as a join GAT_AProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);              
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "3054_Gat_FBC")
            {
                sd = new SqlDataAdapter("Select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type],a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate],a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName],a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[GJobKramank],a.[GRoadKramank],a.[GRoadPrushthbhag],a.[GRoll],a.[GlengthStarted],a.[GlengthUpto],a.[GlengthTotal],a.[GNewKhadikaran],a.[GBM_Carpet],a.[G20_MM],a.[GSurface],a.[GRundikaran],a.[GBridge_Morya],a.[GRepairExpn],a.[GAnya],b.[MudatVadhiDate],b.[KamachiKimat],b.[MarchEndingExpn],b.[UrvaritAmt],b.[Sadyasthiti],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[VidyutikaranAmt],b.[VidyutikaranExpen],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[Dviguni],b.[Itarkhrch],a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);             
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "3054_Gad_D")
            {
                sd = new SqlDataAdapter("select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type] ,a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate] ,a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName] ,a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],a.[ForDepartment],a.[DepartmentDecided],a.[FromAccident],a.[AccidentExecuted],b.[MudatVadhiDate],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[VidyutikaranAmt],b.[VidyutikaranExpen],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[Dviguni],b.[Itarkhrch], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterGAT_D as a join GAT_DProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);              
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.Text == "2515_GramVikas")
            {
                sd = new SqlDataAdapter("select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type] ,a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate] ,a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName] ,a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[Dviguni],b.[Itarkhrch], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from [BudgetMaster2515] as a join [2515Provision] as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);              
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.Text == "Residential_Building")
            {
                sd = new SqlDataAdapter("select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type] ,a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate] ,a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName] ,a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[Dviguni],b.[Itarkhrch], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterResidentialBuilding as a join ResidentialBuildingProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);               
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.Text == "NonResidential_Building")
            {
                sd = new SqlDataAdapter("select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type] ,a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate] ,a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName] ,a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[Dviguni],b.[Itarkhrch], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterNonResidentialBuilding as a join NonResidentialBuildingProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);               
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.Text == "Annuity")
            {
                sd = new SqlDataAdapter("select Distinct a.[WorkId],a.[Arthsankalpiyyear],a.[Akrmank],a.[Type] ,a.[Dist],a.[Taluka],a.[ArthsankalpiyBab],a.[Upvibhag],a.[LekhaShirsh],a.[LekhaShirshName],a.[SubType],a.[ShakhaAbhyantaName],a.[ShakhaAbhiyantMobile],a.[UpabhyantaName],a.[UpAbhiyantaMobile],a.[KhasdaracheName],a.[AmdaracheName],a.[KamacheName],a.[Kamachevav],a.[PrashaskiyKramank],a.[PrashaskiyDate] ,a.[PrashaskiyAmt],a.[TrantrikKrmank],a.[TrantrikDate],a.[TrantrikAmt],a.[ThekedaarName] ,a.[ThekedarMobile],a.[NividaKrmank],a.[NividaAmt],a.[karyarambhadesh],a.[NividaDate],a.[kamachiMudat],a.[KamPurnDate],b.[MudatVadhiDate],b.[MarchEndingExpn],b.[DTakunone],b.[Takunone],b.[DTakuntwo],b.[Takuntwo],b.[DTakunthree],b.[Takunthree],b.[DTakunfour],b.[Takunfour],b.[Tartud],b.[Jan],b.[Feb],b.[Mar],b.[Apr],b.[May],b.[Jun],b.[Jul],b.[Aug],b.[Sep],b.[Oct],b.[Nov],b.[Dec],b.[AkunAnudan],b.[Chalumonth],b.[Chalukharch],b.[Magilmonth],b.[Magilkharch],b.[Magni],b.[VarshbharatilKharch],b.[AikunKharch],b.[Dviguni],b.[Itarkhrch], a.[Sadyasthiti],a.[Pahanikramank],a.[PahaniMudye],a.[Shera] from BudgetMasterAunty as a join AuntyProvision as b on a.WorkID=b.WorkID where a.workID='" + txtoldWorkID.Text + "' and a.[SubDivision]=N'PuneEast'", con);               
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                Response.Redirect("Setting.aspx");
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    mobileNumber = dr["ShakhaAbhiyantMobile"] + ",\n" + dr["UpAbhiyantaMobile"] + ",\n" + dr["ThekedarMobile"];
                    ViewState["mobileNumber"] = mobileNumber;
                }
            }
        }

        protected void txtoldWorkID_TextChanged(object sender, EventArgs e)
        {
            datasearching();
        }
        string p;

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());


            SqlDataAdapter sdaa = new SqlDataAdapter("SELECT coalesce(B.WorkID, C.WorkID, N.WorkID, R.WorkID, G_A.WorkID, G_FBC.WorkID, G_D.WorkID, D.WorkID, DP.WorkID, MLA.WorkID,MP.WorkID,RB.WorkID,NRB.WorkID,An.WorkID,GV.WorkID)as WorkID,coalesce(B.KamacheName, C.KamacheName, N.KamacheName, R.KamacheName, G_A.KamacheName, G_FBC.KamacheName, G_D.KamacheName, D.KamacheName, DP.KamacheName, MLA.KamacheName,MP.KamacheName,RB.KamacheName,NRB.KamacheName,An.KamacheName,GV.KamacheName)as KamacheName FROM BudgetMasterBuilding B FULL OUTER JOIN BudgetMasterCRF C ON B.WorkID=C.WorkID full outer join BudgetMasterNABARD N on B.WorkID= N.WorkID  full outer join BudgetMasterRoad R on B.WorkID=R.WorkID full outer join BudgetMasterGAT_A G_A on B.WorkID=G_A.WorkID full outer join BudgetMasterGAT_FBC G_FBC on B.WorkID=G_FBC.WorkID full outer join BudgetMasterGAT_D G_D on B.WorkID=G_D.WorkID  full outer join BudgetMasterDepositFund D on B.WorkID=D.WorkID  full outer join BudgetMasterDPDC DP on B.WorkID=DP.WorkID  full outer join BudgetMasterMLA MLA on B.WorkID=MLA.WorkID  full outer join BudgetMasterMP MP on B.WorkID=MP.WorkID full outer join BudgetMasterResidentialBuilding RB on B.WorkID=RB.WorkID  full outer join BudgetMasterNonResidentialBuilding NRB on B.WorkID=NRB.WorkID full outer join BudgetMasterAunty An on B.WorkID=An.WorkID  full outer join BudgetMaster2515 GV on B.WorkID=GV.WorkID where B.WorkID like '" + prefixText + "%' and B.Type='" + type + "' or C.workID like '" + prefixText + "%' and C.Type='" + type + "' or N.workID  like '" + prefixText + "%' and N.Type='" + type + "' or R.workID like '" + prefixText + "%' and R.Type='" + type + "' or G_A.workID like '" + prefixText + "%' and G_A.Type='" + type + "' or G_FBC.workID like '" + prefixText + "%' and G_FBC.Type='" + type + "' or G_D.workID like '" + prefixText + "%' and G_D.Type='" + type + "'  or D.workID like '" + prefixText + "%' and D.Type='" + type + "' or DP.workID like '" + prefixText + "%' and DP.Type='" + type + "' or MLA.workID like '" + prefixText + "%' and MLA.Type='" + type + "'  or MP.workID like '" + prefixText + "%' and MP.Type='" + type + "' or RB.workID like '" + prefixText + "%' and RB.Type='" + type + "' or NRB.workID like '" + prefixText + "%' and NRB.Type='" + type + "' or GV.workID like '" + prefixText + "%' and GV.Type='" + type + "' or An.workID like '" + prefixText + "%' and An.Type='" + type + "'", conn);

            sdaa.Fill(dt);
            List<string> countryNames = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                countryNames.Add(dr["WorkID"].ToString());
            }
            return countryNames;
        }
        public void datacode()
        {
            if (RadioButton1.Checked == true)
            {
                txtNewWorkID.Enabled = true;
                txtOldYear.Enabled = false;
                txtNewYear.Enabled = false;
            }
            else
            {
                txtNewWorkID.Enabled = false;
                txtOldYear.Enabled = true;
                txtNewYear.Enabled = true;
            }

        }
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            datacode();
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            datacode();
            if (RadioButton2.Checked == true)
            {
                datasearching();
            }
        }
        public void UpdateWorkId(string MasterTbl, string ProvisionTbl, string SmsTbl)
        {
            SqlCommand cmd = new SqlCommand("Update " + MasterTbl + " set WorkID='" + txtNewWorkID.Text + "' where WorkID='" + txtoldWorkID.Text + "' and [SubDivision]=N'PuneEast'", con);
            SqlCommand cmd1 = new SqlCommand("Update " + ProvisionTbl + " set WorkID='" + txtNewWorkID.Text + "' where WorkID='" + txtoldWorkID.Text + "' and [SubDivision]=N'PuneEast'", con);
            SqlCommand cmd2 = new SqlCommand("Update " + SmsTbl + " set WorkID='" + txtNewWorkID.Text + "' where WorkID='" + txtoldWorkID.Text + "' and [SubDivision]=N'PuneEast'", con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();               
                string AddedDate = DateTime.Now.ToString("dd/MM/yyyy");
                if (mobileNumber == null)
                    mobileNumber = ViewState["mobileNumber"].ToString();
                var yArray = mobileNumber.ToString().Split(',').Select(m => m.Trim()).ToArray();
                message = "WorkId:" + txtoldWorkID.Text + " has been updated into DBS Software in which your name has been mentioned.Your New WorkId is:"+txtNewWorkID.Text+"";
                foreach (String strno in yArray)
                {
                    SMSobj.SendSMS(strno, message);
                } 
                lblStatus.Text = "<b style='color:green'>WorkId updated successfully!!!</b>";
            }
        }
        public void UpdateArthSankalpiyYear(string MasterTbl, string ProvisionTbl)
        {
            SqlCommand cmd = new SqlCommand("Update " + MasterTbl + " set [Arthsankalpiyyear]='" + txtNewYear.Text + "' where WorkID='" + txtoldWorkID.Text + "' AND   [Arthsankalpiyyear]='" + txtOldYear.Text + "' and [SubDivision]=N'PuneEast'", con);
            SqlCommand cmd1 = new SqlCommand("Update " + ProvisionTbl + " set [Arthsankalpiyyear]='" + txtNewYear.Text + "' where WorkID='" + txtoldWorkID.Text + "' AND   [Arthsankalpiyyear]='" + txtOldYear.Text + "' and [SubDivision]=N'PuneEast'", con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                cmd1.ExecuteNonQuery();
                string AddedDate = DateTime.Now.ToString("dd/MM/yyyy");
                if (mobileNumber == null)
                    mobileNumber = ViewState["mobileNumber"].ToString();
                var yArray = mobileNumber.ToString().Split(',').Select(m => m.Trim()).ToArray();
                message = "Budget Year of WorkId:" + txtoldWorkID.Text + " has been updated into DBS Software in which your name has been mentioned.old Budget Year was:" + txtOldYear.Text + " and New Budget Year is:" + txtNewYear.Text + "";
                foreach (String strno in yArray)
                {
                    SMSobj.SendSMS(strno, message);
                } 
                lblStatus.Text = "<b style='color:green'>Arthsankalpiyyear updated successfully!!!</b>";
                //lblStatus.Enabled = false;
                Response.Write("<script>alert('Updated Successfully......!');</script>");
            }
        }
        protected void btnWorkid_Click(object sender, EventArgs e)
        {
            con.Open();
            if (RadioButton1.Checked == true)
            {
                if (ddlType.SelectedItem.Text == "CRF")
                {
                    UpdateWorkId("BudgetMasterCRF", "CRFProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "Building")
                {
                    UpdateWorkId("BudgetMasterBuilding", "BuildingProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "Nabard")
                {
                    UpdateWorkId("BudgetMasterNABARD", "NABARDProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "Road")
                {
                    UpdateWorkId("BudgetMasterRoad", "RoadProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "DPDC")
                {
                    UpdateWorkId("BudgetMasterDPDC", "DPDCProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "MLA")
                {
                    UpdateWorkId("BudgetMasterMLA", "MLAProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "MP")
                {
                    UpdateWorkId("BudgetMasterMP", "MPProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "3054_Gat_A")
                {
                    UpdateWorkId("BudgetMasterGAT_A", "GAT_AProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "3054_Gat_FBC")
                {
                    UpdateWorkId("BudgetMasterGAT_FBC", "GAT_FBCProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "3054_Gad_D")
                {
                    UpdateWorkId("BudgetMasterGAT_D", "GAT_DProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "Deposit")
                {
                    UpdateWorkId("BudgetMasterDepositFund", "DepositFundProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "Residential_Building")
                {
                    UpdateWorkId("BudgetMasterResidentialBuilding", "ResidentialBuildingProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "NonResidential_Building")
                {
                    UpdateWorkId("BudgetMasterNonResidentialBuilding", "NonResidentialBuildingProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "Annuity")
                {
                    UpdateWorkId("BudgetMasterAunty", "AuntyProvision", "SendSms_tbl");
                }
                else if (ddlType.SelectedItem.Text == "2515_GramVikas")
                {
                    UpdateWorkId("BudgetMaster2515", "[2515Provision]", "SendSms_tbl");
                }
            }

            if (RadioButton2.Checked == true)
            {
                if (ddlType.SelectedItem.Text == "CRF")
                {
                    UpdateArthSankalpiyYear("BudgetMasterCRF", "CRFProvision");
                }
                else if (ddlType.SelectedItem.Text == "Building")
                {
                    UpdateArthSankalpiyYear("BudgetMasterBuilding", "BuildingProvision");
                }
                else if (ddlType.SelectedItem.Text == "Nabard")
                {
                    UpdateArthSankalpiyYear("BudgetMasterNABARD", "NABARDProvision");
                }
                else if (ddlType.SelectedItem.Text == "Road")
                {
                    UpdateArthSankalpiyYear("BudgetMasterRoad", "RoadProvision");
                }
                else if (ddlType.SelectedItem.Text == "DPDC")
                {
                    UpdateArthSankalpiyYear("BudgetMasterDPDC", "DPDCProvision");
                }
                else if (ddlType.SelectedItem.Text == "MLA")
                {
                    UpdateArthSankalpiyYear("BudgetMasterMLA", "MLAProvision");
                }
                else if (ddlType.SelectedItem.Text == "MP")
                {
                    UpdateArthSankalpiyYear("BudgetMasterMP", "MPProvision");
                }
                else if (ddlType.SelectedItem.Text == "3054_Gat_A")
                {
                    UpdateArthSankalpiyYear("BudgetMasterGAT_A", "GAT_AProvision");
                }
                else if (ddlType.SelectedItem.Text == "3054_Gat_FBC")
                {
                    UpdateArthSankalpiyYear("BudgetMasterGAT_FBC", "GATFBCProvision");
                }
                else if (ddlType.SelectedItem.Text == "3054_Gad_D")
                {
                    UpdateArthSankalpiyYear("BudgetMasterGAT_D", "GAT_DProvision");
                }
                else if (ddlType.SelectedItem.Text == "Deposit")
                {
                    UpdateArthSankalpiyYear("BudgetMasterDepositFund", "DepositFundProvision");
                }
                else if (ddlType.SelectedItem.Text == "Residential_Building")
                {
                    UpdateArthSankalpiyYear("BudgetMasterResidentialBuilding", "ResidentialBuildingProvision");
                }
                else if (ddlType.SelectedItem.Text == "NonResidential_Building")
                {
                    UpdateArthSankalpiyYear("BudgetMasterNonResidentialBuilding", "NonResidentialBuildingProvision");
                }
                else if (ddlType.SelectedItem.Text == "Annuity")
                {
                    UpdateArthSankalpiyYear("BudgetMasterAunty", "AuntyProvision");
                }
                else if (ddlType.SelectedItem.Text == "2515_GramVikas")
                {
                    UpdateArthSankalpiyYear("[BudgetMaster2515]", "[2515Provision]");
                }
            }

            con.Close();
            datasearching();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void txtOldYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = txtOldYear.Text;
                if (query.Length > 4)
                {
                    query = query.Substring(0, query.Length - 5);
                }

                if (txtOldYear.Text != "")
                {
                    int yearset = Convert.ToInt32(query);
                    txtOldYear.Text = query + "-" + (yearset + 1);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void txtNewYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = txtNewYear.Text;
                if (query.Length > 4)
                {
                    query = query.Substring(0, query.Length - 5);
                }

                if (txtNewYear.Text != "")
                {
                    int yearset = Convert.ToInt32(query);
                    txtNewYear.Text = query + "-" + (yearset + 1);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}