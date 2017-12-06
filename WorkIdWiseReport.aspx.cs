using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWdEEBudget
{
    public partial class WorkIdWiseReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
        static string type = string.Empty;
        AllHeadReportClass allreport = new AllHeadReportClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ArthsankalpiyYear();
                dropdatainsert();
            }
            doSomethingWith(ddlType);
        }

        public void ArthsankalpiyYear()
        {
            ddlArthsankalpiyYear.Items.Clear();
            ddlArthsankalpiyYear.DataSource = allreport.ArthsankalpiyYear();
            ddlArthsankalpiyYear.DataTextField = "Arthsankalpiyyear";
            ddlArthsankalpiyYear.DataValueField = "Arthsankalpiyyear";
            ddlArthsankalpiyYear.DataBind();
            ddlArthsankalpiyYear.Items.Insert(0, new ListItem("Select"));
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

        public static void doSomethingWith(DropDownList dropDown)
        {
            type = dropDown.SelectedItem.Text; 
            
        }

        public void datasearching()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            SqlDataAdapter sd;
            string wherecond = "  where a.workID='" + txtoldWorkID.Text + "' and b.[Arthsankalpiyyear]='" + ddlArthsankalpiyYear.SelectedItem.Text + "'  ";
            string buildquery = "SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName] ORDER BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag]) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[SubType] as 'विभाग',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव',a.[AmdaracheName] as 'आमदारांचे नाव',a.[KhasdaracheName] as 'खासदारांचे नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश',cast(mahapwdd_EEPwdEastPuneDB.GetNumeric(case when mahapwdd_EEPwdEastPuneDB.GetNumeric([NividaAmt])!='' then mahapwdd_EEPwdEastPuneDB.GetNumeric([NividaAmt])else '0.0' end) as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[Chalukharch] as 'चालु खर्च',b.[Magilkharch] as 'मागील खर्च',b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Takunone] as 'प्रथम तिमाही तरतूद',b.[Takuntwo] as 'द्वितीय तिमाही तरतूद',b.[Takunthree] as 'तृतीय तिमाही तरतूद',b.[Takunfour] as 'चतुर्थ तिमाही तरतूद',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',b.[AkunAnudan] as 'वितरित तरतूद',b.[Magni] as 'मागणी',b.[Vidyutprama] as 'विद्युतीकरणावरील प्रमा',b.[Vidyutvitarit] as 'विद्युतीकरणावरील वितरित',b.[Itarkhrch] as 'इतर खर्च',b.[Dviguni] as 'दवगुनी ज्ञापने',a.[Pahanikramank] as 'पाहणी क्रमांक',a.[PahaniMudye] as 'पाहणीमुद्ये',b.[DeyakachiSadyasthiti] as 'देयकाची सद्यस्थिती',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा'  ";

            if (ddlType.SelectedItem.Text == "Building")
            {
                sd = new SqlDataAdapter( buildquery+ " from BudgetMasterBuilding as a join BuildingProvision as b on a.WorkID=b.WorkID " + wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            else if (ddlType.SelectedItem.Text == "CRF")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag]desc) as 'SrNo', a.[WorkId] as 'WorkId',a.[ArthsankalpiyBab] as 'Budget of Item',a.[Arthsankalpiyyear] as 'Budget of Year',a.[KamacheName] as 'Name of Work',a.[LekhaShirsh] as 'Head',a.[LekhaShirshName] as 'Headwise',a.[Type] as 'Type',a.[SubType] as 'SubType',a.[Upvibhag] as 'Sub Division',a.[Taluka] as 'Taluka',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'Sectional Engineer',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'Deputy Engineer',a.[AmdaracheName] as 'MLA',a.[KhasdaracheName] as 'MP',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor',a.[PrashaskiyKramank] as 'Administrative No',a.[PrashaskiyDate] as 'A A Date',a.[PrashaskiyAmt] as 'A A Amount',a.[TrantrikKrmank] as 'Technical Sanction No',a.[TrantrikDate] as 'T S Date',a.[TrantrikAmt] as 'T S Amount',a.[Kamachavav] as 'Scope of Work',a.[karyarambhadesh] as 'Work Order',a.[NividaKrmank] as 'Tender No',cast(a.[NividaAmt] as decimal(10,2)) as 'Tender Amount',a.[NividaDate] as 'Tender Date',a.[kamachiMudat] as 'Work Order Date',a.[KamPurnDate] as 'Work Completion Date',b.[MudatVadhiDate] as 'Extension Month',a.[SanctionDate] as 'SanctionDate',a.[SanctionAmount] as 'SanctionAmount',b.[ManjurAmt] as 'Estimated Cost Approved',b.[MarchEndingExpn] as 'MarchEndingExpn',b.[UrvaritAmt] as 'Remaining Cost',b.[VarshbharatilKharch] as 'Annual Expense',b.[Magilmonth] as 'Previous Month',b.[Magilkharch] as 'Previous Cost',b.[Chalumonth] as 'Current Month',b.[Chalukharch] as 'Current Cost',b.[AikunKharch] as 'Total Expense',b.[DTakunone] as 'First Provision Month',b.[Takunone] as 'First Provision',b.[DTakuntwo] as 'Second Provision Month',b.[Takuntwo] as 'Second Provision',b.[DTakunthree] as 'Third Provision Month',b.[Takunthree] as 'Third Provision',b.[DTakunfour] as 'Fourth Provision Month',b.[Takunfour] as 'Fourth Provision',b.[Tartud] as 'Grand Provision',b.[AkunAnudan] as 'Total Grand',b.[Magni] as 'Demand',b.[OtherExpen] as 'Other Expense',b.[ExpenCost] as 'Electricity Cost',b.[ExpenExpen] as 'Electricity Expense',a.[JobNo] as 'JobNo',a.[RoadNo] as 'Road Category',a.[RoadLength] as 'RoadLength',a.[APhysicalScope] as 'W.B.M Wide Phy Scope',a.[ACommulative] as 'W.B.M Wide Commulative',a.[ATarget] as 'W.B.M Wide Target',a.[AAchievement] as 'W.B.M Wide Achievement',a.[BPhysicalScope] as 'B.T Phy Scope',a.[BCommulative] as 'B.T Commulative',a.[BTarget] as 'B.T Target',a.[BAchievement] as 'B.T Achievement',a.[CPhysicalScope] as 'C.D Phy Scope',a.[CCommulative] as 'C.D Commulative',a.[CTarget] as 'C.D Target',a.[CAchievement] as 'C.D Achievement',a.[DPhysicalScope] as 'Minor Bridges Phy Scope(Nos)',a.[DCommulative] as 'Minor Bridges Commulative(Nos)',a.[DTarget] as 'Minor Bridges Target(Nos)',a.[DAchievement] as 'Minor Bridges Achievement(Nos)',a.[EPhysicalScope] as 'Major Bridges Phy Scope(Nos)',a.[ECommulative] as 'Major Bridges Commulative(Nos)',a.[ETarget] as 'Major Bridges Target(Nos)',a.[EAchievement] as 'Major Bridges Achievement(Nos)',b.[DeyakachiSadyasthiti] as 'Bill Status',a.[Pahanikramank] as 'Observation No',a.[PahaniMudye] as 'Observation Memo',a.[Sadyasthiti] as 'Status',a.[Shera] as 'Remark' from BudgetMasterCRF as a join CRFProvision as b on a.WorkID=b.WorkID " +wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "Nabard")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[RDF_SrNo] ORDER BY a.[Upvibhag]) as 'SrNo', a.[WorkId] as 'Work Id',a.[RDF_NO] as 'RIDF NO', a.[RDF_SrNo] as 'SrNo',a.[Arthsankalpiyyear] as 'Budget of Year',a.Dist as 'District',a.[Taluka] as 'Taluka',a.[ArthsankalpiyBab] as 'Budget of Item',a.[KamacheName]as 'Name of Work',a.[Kamachavav] as 'Scope of Work',a.[LekhaShirshName] as 'Headwise',a.[SubType] as 'Division',a.[Upvibhag] as 'Sub Division',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'Sectional Engineer',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'Deputy Engineer',a.[AmdaracheName] as 'MLA',a.[KhasdaracheName] as 'MP',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'Contractor',a.[PrashaskiyKramank] as 'Administrative No',a.[PrashaskiyDate] as 'A A Date',a.[PIC_NO] as 'PIC No',cast(a.[PrashaskiyAmt] as decimal(10,2)) as 'AA cost Rs in lakhs',cast(a.[TrantrikAmt]as decimal(10,2))as 'Technical Sanction Cost Rs in Lakh',a.[TrantrikKrmank]+' '+a.[TrantrikDate] as 'Technical Sanction No and Date',a.[NividaKrmank] as 'Tender No',cast(a.[NividaAmt] as decimal(10,2)) as 'Tender Amount',a.[karyarambhadesh] as 'Work Order',a.[NividaDate] as 'Tender Date',a.[kamachiMudat] as 'Work Order Date',a.[KamPurnDate] as 'Work Completion Date',b.[MudatVadhiDate] as 'Extension Month',b.[ManjurAmt] as 'Estimated Cost Approved',b.[MarchEndingExpn] as 'Expenditure up to MAR 2017',b.[UrvaritAmt] as 'Remaining Cost',b.[Chalukharch] as 'Current Cost',b.[Magilkharch] as 'Previous Cost',b.[VarshbharatilKharch] as 'Expenditure up to 8/2016 during year 16-17 Rs in Lakhs',b.[AikunKharch] as 'Total Expense',b.[Takunone] as 'Budget Provision in 2017-18 Rs in Lakhs',b.[Takuntwo] as 'Second Provision',b.[Takunthree] as 'Third Provision',b.[Takunfour] as 'Fourth Provision',b.[Tartud] as 'Total Provision',b.[AkunAnudan] as 'Total Grand',b.[Magni] as 'Demand for 2017-18 Rs in Lakhs',a.[PahaniMudye] as 'Observation Memo',a.[Pahanikramank] as 'Probable date of completion',b.[DeyakachiSadyasthiti] as 'Bill Status',a.[Sadyasthiti] as 'Physical Progress of work',a.[Road_No] as 'Road Category',a.[LengthRoad] as 'Road Length',a.[RoadType] as 'Road Type',a.[WBMI_km] as 'WBMI Km',a.[WBMII_km] as 'WBMII Km',a.[WBMIII_km] as 'WBMIII Km',a.[BBM_km] as 'BBM Km',a.[Carpet_km] as 'Carpet Km',a.[Surface_km] as 'Surface Km',cast(a.[CD_Works_No] as decimal(10,2))  as 'CD_Works_No',a.[PCR] as 'PCR submitted or not',a.[Shera] as 'Remark' from BudgetMasterNABARD as a join NABARDProvision as b on a.WorkID=b.WorkID  " + wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "Road")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName]ORDER BY a.LekhaShirshName desc,a.[Arthsankalpiyyear],a.[Taluka],a.[upvibhag]) as 'अ.क्र', a.[WorkId] as 'वर्क आयडी',a.PageNo as 'पान क्र',a.ArthsankalpiyBab as 'बाब क्र',a.JulyBab as 'जुलै/ बाब क्र./पान क्र.',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[SubType] as 'विभाग',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव',a.[AmdaracheName] as 'आमदारांचे नाव',a.[KhasdaracheName] as 'खासदारांचे नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'सुरवाती पासून मार्च 2017 अखेरचा खर्च',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[VarshbharatilKharch] as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च',b.[Magilkharch] as 'मागील खर्च',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Takunone] as'2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017',b.[Takuntwo] as '2017-18 मधील अर्थसंकल्पीय तरतूद जुलै 2017',b.[Takunthree] as'तृतीय तिमाही तरतूद',b.[Takunfour] as 'चतुर्थ तिमाही तरतूद',b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद',b.[AkunAnudan] as '2017-18 मधील वितरीत तरतूद',b.[Magni] as '2017-18 साठी मागणी',b.[Vidyutprama] as 'विद्युतीकरणावरील प्रमा',b.[Vidyutvitarit] as 'विद्युतीकरणावरील वितरित',b.[Itarkhrch] as 'इतर खर्च',b.[Dviguni] as 'दवगुनी ज्ञापने',a.[PahaniMudye] as 'पाहणीमुद्ये',a.[Pahanikramank] as 'पाहणी क्रमांक',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterRoad as a join RoadProvision as b on a.WorkID=b.WorkID  "+wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "DPDC")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear], a.[Upvibhag] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka]desc) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[LekhaShirshName] as 'योजनेचे नाव',b.[ComputerCRC] as 'सीआरसी (संगणक) संकेतांक',b.[ObjectCode] as 'उद्यीष्ट संकेतांक(ऑब्जेक्ट कोड)',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'योजनेचे / कामाचे नांव',a.[SubType] as 'विभाग',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव',a.[AmdaracheName] as 'आमदारांचे नाव',a.[KhasdaracheName] as 'खासदारांचे नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',a.[karyarambhadesh] as 'कार्यारंभ आदेश',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण होण्याचा अपेक्षित दिनांक',convert(nvarchar(max),a.[NividaAmt])+' '+convert(nvarchar(max),b.[MudatVadhiDate]) as 'सुधारित अंदाजित किंमतीचा दिनांक',CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN '1' END as nvarchar(max)) as 'एकूण कामे',b.[DeyakachiSadyasthiti] as 'देयकाची सद्यस्थिती',b.[ManjurAmt] as 'एकूण अंदाजित किंमत (अलिकडील सुधारित)',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'सन 2017-2018 मधील अपेक्षित खर्च',b.[Chalukharch] as 'चालू खर्च',b.[Magilkharch] as 'मागील खर्च',b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Takunone] as 'उर्वरित किंमत (6-(8+9))',b.[Takuntwo] as 'द्वितीय तिमाही तरतूद',b.[Takunthree] as 'तृतीय तिमाही तरतूद',b.[Takunfour] as 'चतुर्थ तिमाही तरतूद',b.[Tartud] as '2017-2018 करीता प्रस्तावित तरतूद',b.[Tartud]as 'काम निहाय तरतूद सन 2017-2018',b.[AkunAnudan] as 'वितरित तरतूद',b.[Magni] as 'मागणी 2017-2018',b.[Vidyutprama] as 'विद्युतीकरणावरील प्रमा',b.[Vidyutvitarit] as 'विद्युतीकरणावरील वितरित',b.[Jun] as 'वितरीत तरतूद सन 2017-2018',b.[Itarkhrch] as 'इतर खर्च',b.[Dviguni] as 'दवगुनी ज्ञापने',a.[PahaniMudye] as 'पाहणीमुद्ये',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'पुर्ण',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'प्रगतीत',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'निविदा स्तर',a.[Shera] as 'शेरा' from BudgetMasterDPDC as a join DPDCProvision as b on a.WorkID=b.WorkID  "+wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "MLA")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[AmdaracheName] order by  a.[AmdaracheName],a.[Arthsankalpiyyear],a.[Taluka],a.[PageNo]) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष',a.[PageNo] as 'प्रकार',a.[Taluka] as 'तालुका',a.[KamacheName] as 'कामाचे नाव',a.[Upvibhag] as 'उपविभाग',a.[AmdaracheName] as 'आमदारांचे नाव',a.[KhasdaracheName] as 'खासदारांचे नाव',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यांरभ आदेश/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',b.[MudatVadhiDate] as 'मुदतवाढ दिनांक',CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN 1 ELSE 0 END as decimal(10,0)) as 'एकूण कामे',b.[ManjurAmt] as 'सन 2017-2018 मधील अपेक्षित खर्च',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत (6-(8+9))',b.[Chalukharch] as 'एकुण उपलब्ध अनुदान',b.[Magilkharch] as 'सन 2016 - 17  06/2016 अखेर खर्च',b.[VarshbharatilKharch] as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Takunone] as 'प्रथम तिमाही तरतूद',b.[Takuntwo] as 'द्वितीय तिमाही तरतूद',b.[Takunthree] as 'तृतीय तिमाही तरतूद',b.[Takunfour] as 'चतुर्थ तिमाही तरतूद',b.[Tartud] as 'काम निहाय तरतूद सन 2017-2018',b.[AkunAnudan] as 'वितरीत तरतूद सन 2017-2018',b.[Magni] as 'मागणी 2017-18',b.[Vidyutprama] as 'विद्युतप्रमा',b.[Vidyutvitarit] as 'विद्युत वितरीत',b.[Itarkhrch] as 'इतर खर्च',b.[Dviguni] as 'द्वीगुणी',a.[PahaniMudye] as 'पाहणीमुद्ये',a.[Pahanikramank] as 'पाहणी क्रमांक',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'पुर्ण',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'प्रगतीत',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'निविदा स्तर',a.[Shera] as 'शेरा' from BudgetMasterMLA as a join MLAProvision as b on a.WorkID=b.WorkID  " + wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "MP")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[KhasdaracheName] order by a.[KhasdaracheName],a.[Arthsankalpiyyear],a.[Taluka],a.[PageNo] ) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Taluka] as 'तालुका',a.[AmdaracheName] as 'आमदारांचे नाव',a.[KhasdaracheName] as 'खासदारांचे नाव',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय बाब क्र./प्रथम समाविष्ट झालेल्या वर्ष',a.[PageNo] as 'प्रकार',a.[Type] as 'जिल्हा/योजना',a.[KamacheName] as 'कामाचे नाव',a.[Upvibhag] as 'उपविभाग',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यांरभ आदेश/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN a.[LekhaShirsh] = N'५०५४४२४६'  THEN 1 ELSE 0 END as decimal(10,0)) as 'एकूण कामे',b.[MudatVadhiDate] as 'मुदतवाढ दिनांक',b.[ManjurAmt] as 'सन 2017-18 मधील अपेक्षित खर्च',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत (6-(8+9))',b.[Chalukharch] as 'एकुण उपलब्ध अनुदान',b.[Takunone] as 'प्रथम तिमाही तरतूद',b.[Takuntwo] as 'द्वितीय तिमाही तरतूद',b.[Takunthree] as 'तृतीय तिमाही तरतूद',b.[Takunfour] as 'चतुर्थ तिमाही तरतूद',b.[Magilkharch] as 'मागील खर्च',b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च',b.[AikunKharch] as 'एकुण खर्च',b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद',b.[AkunAnudan] as '2017-18 मधील वितरीत तरतूद',b.[Magni] as 'मागणी  2017-18',b.[Vidyutprama] as 'विद्युतप्रमा',b.[Vidyutvitarit] as 'विद्युत वितरीत',b.[Itarkhrch] as 'इतर खर्च',b.[Dviguni] as 'द्वीगुणी',a.[Pahanikramank] as 'पाहणी क्रमांक',a.[PahaniMudye] as 'पाहणीमुद्ये',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'पुर्ण',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'प्रगतीत',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'निविदा स्तर',a.[Shera] as 'शेरा' from BudgetMasterMP as a join MPProvision as b on a.WorkID=b.WorkID  "+wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "Deposit")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag]desc) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[SubType] as 'विभाग',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव',a.[AmdaracheName] as 'आमदारांचे नाव',a.[KhasdaracheName] as 'खासदारांचे नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश',a.[NividaAmt] as 'निविदा रक्कम % कमी / जास्त',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[VarshbharatilKharch] as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च',b.[Magilkharch] as 'मागील खर्च',b.[Chalukharch] as 'चालू खर्च',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Takunone] as 'प्रथम तिमाही तरतूद',b.[Takuntwo] as 'द्वितीय तिमाही तरतूद',b.[Takunthree] as 'तृतीय तिमाही तरतूद',b.[Takunfour] as 'चतुर्थ तिमाही तरतूद',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',b.[AkunAnudan] as 'वितरित तरतूद',b.[Magni] as 'मागणी',b.[Vidyutprama] as 'विद्युतीकरणावरील प्रमा',b.[Vidyutvitarit] as 'विद्युतीकरणावरील वितरित',b.[Itarkhrch] as 'इतर खर्च',b.ShilakThev as '2017-18 मधील शिल्लक ठेव',b.VitariThev as '2017-18 वितरीत ठेव',b.[Dviguni] as 'दवगुनी ज्ञापने',a.[PahaniMudye] as 'पाहणीमुद्ये',a.[Pahanikramank] as 'पाहणी क्रमांक',b.[DeyakachiSadyasthiti] as 'देयकाची सद्यस्थिती',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterDepositFund as a join DepositFundProvision as b on a.WorkID=b.WorkID "+wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "3054_Gat_A")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear] ORDER BY a.[Arthsankalpiyyear],    CASE WHEN ISNUMERIC(a.[ArthsankalpiyBab]) = 1 THEN 0 ELSE 1 END,    CASE WHEN ISNUMERIC(a.[ArthsankalpiyBab]) = 1 THEN CAST(a.[ArthsankalpiyBab] AS INT) ELSE 0 END,a.[ArthsankalpiyBab],a.[Upvibhag],a.taluka) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[SubType] as 'विभाग',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव',a.[AmdaracheName] as 'आमदारांचे नाव',a.[KhasdaracheName] as 'खासदारांचे नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'कार्यारंभ आदेश',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[Chalukharch] as 'चालू खर्च',b.[Magilkharch] as 'मागील खर्च',b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Takunone] as 'प्रथम तिमाही तरतूद',b.[Takuntwo] as 'द्वितीय तिमाही तरतूद',b.[Takunthree] as 'तृतीय तिमाही तरतूद',b.[Takunfour] as 'चतुर्थ तिमाही तरतूद',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',b.[AkunAnudan] as 'वितरित तरतूद',b.[Magni] as 'मागणी',b.[VidyutikaranAmt] as 'विद्युतीकरण कामाची किंमत',b.[VidyutikaranExpen] as 'विद्युतीकरणाचा खर्च',a.[GAadeshKramank] as 'आदेश क्र',a.[GUpshirsh] as 'उपशिर्ष',a.[GJobKramank] as 'जॉब क्र',a.[GJobRakkam] as 'जॉब रक्कम',a.[GDambarichePariman] as 'डांबरीचे परिमाण',a.[GDambarichiRakkam] as 'डांबरीची रक्कम',a.[GDurustichaprakar] as 'दुरुस्तीचा प्रकार',cast(a.[GVaperDambarichePariman] as decimal(10,2)) as 'वापर डांबरीचे परिमाण',a.[GKampurnKarnyachaDinak] as 'डांबरीचे काम पूर्ण दिनांक',a.[GKampurnJhalyachaDinak] as 'डांबरीचे काम पूर्ण झाल्याच्या दिनांक',a.[GDeyakSadarKelyachaDinak] as 'विभागात देयक सादर दिनांक',a.[GParitKelyachaDinak] as 'विभागात देयक पारित दिनांक',b.[ShilakDayitvAmt] as 'शिल्लक दायित्व रु',b.[DayitvAvshyakYesNo] as 'दायित्व आवश्यकता आहे / नाही',b.[DayitvAmt] as 'दायित्व असल्यास रक्कम रु',b.[DambarichaExpen] as 'डांबरीचा खर्च',b.[Itarkhrch] as 'इतर खर्च',b.[Dviguni] as 'द्वीगुणी',a.[Pahanikramank] as 'पाहणीक्रमांक',a.[PahaniMudye] as 'पाहणीमुद्ये',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterGAT_A as a join GAT_AProvision as b on a.WorkID=b.WorkID  " +wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "3054_Gat_FBC")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka]) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.Type as 'योजनेचे नाव',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[SubType] as 'विभाग',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव',a.[AmdaracheName] as 'आमदारांचे नाव',a.[KhasdaracheName] as 'खासदारांचे नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate]) as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate]) as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',a.[karyarambhadesh] as 'कार्यारंभ आदेश',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate]) as 'निविदा क्र/दिनांक',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',a.[GJobKramank] as 'जॉब क्रमांक',a.[GRoadKramank] as 'रस्ता संवर्ग/ क्रमांक',a.[GRoadPrushthbhag] as 'अस्तीत्वातील रस्त्याचा पृष्ठभाग',a.[GRoll] as 'पीक व रोल',a.[GlengthStarted] as 'लांबी किमी. पासून',a.[GlengthUpto] as 'लांबी किमी. पर्यंत',a.[GlengthTotal] as 'लांबी किमी. एकूण',a.[GNewKhadikaran] as 'नवीन खडीकरण',a.[GBM_Carpet] as 'बी एम व कारपेट सिलकोट सह',a.[G20_MM] as '20 मीमी कारपेटसिलकोट सह',a.[GSurface] as 'सरफेस ड्रेसिंग',a.[GRundikaran] as 'रुंदी करण',a.[GBridge_Morya] as 'पूल/ मो-या',a.[GRepairExpn] as 'दुरुस्तीचा प्रती खर्च',a.[GAnya] as 'अन्य',b.[KamachiKimat] as 'कामाची किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[Magilkharch] as 'मागील खर्च',b.[Chalukharch] as 'चालू खर्च',b.[VarshbharatilKharch] as 'सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Takunone] as 'प्रथम तिमाही तरतूद',b.[Takuntwo] as 'द्वितीय तिमाही तरतूद',b.[Takunthree] as 'तृतीय तिमाही तरतूद',b.[Takunfour] as 'चतुर्थ तिमाही तरतूद',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',b.[AkunAnudan] as 'वितरित तरतूद',b.[Magni] as 'मागणी',b.[VidyutikaranAmt] as 'विद्युतीकरणावरील प्रमा',b.[VidyutikaranExpen] as 'विद्युतीकरणावरील वितरित',b.[Itarkhrch] as 'इतर खर्च',b.[Dviguni] as 'दवगुनी ज्ञापने',a.[PahaniMudye] as 'पाहणीमुद्ये',a.[Pahanikramank] as 'पाहणी क्रमांक',b.[Sadyasthiti] as 'देयकाची सद्यस्थिती',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterGAT_FBC as a join GAT_FBCProvision as b on a.WorkID=b.WorkID  " + wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.SelectedItem.Text == "3054_Gad_D")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[LekhaShirshName],a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka]desc) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखशीर्ष नाव',a.[SubType] as 'विभाग',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',a.[ArthsankalpiyBab] as 'अर्थसंकल्पीय बाब',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile]) as 'शाखा अभियंता नाव',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile]) as 'उपअभियंता नाव',a.[AmdaracheName] as 'आमदारांचे नाव',a.[KhasdaracheName] as 'खासदारांचे नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',a.[karyarambhadesh] as 'कार्यारंभ आदेश',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[Chalukharch] as 'चालू खर्च',b.[Magilkharch] as 'मागील खर्च',b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Takunone] as 'प्रथम तिमाही तरतूद',b.[Takuntwo] as 'द्वितीय तिमाही तरतूद',b.[Takunthree] as 'तृतीय तिमाही तरतूद',b.[Takunfour] as 'चतुर्थ तिमाही तरतूद',b.[Tartud]as 'अर्थसंकल्पीय तरतूद',b.[AkunAnudan] as 'वितरित तरतूद',b.[Magni] as 'मागणी',b.[VidyutikaranAmt] as 'विद्युतीकरण कामाची किंमत',b.[VidyutikaranExpen] as 'विद्युतीकरणाचा खर्च',a.[ForDepartment] as 'शासनाने नेमुन दिलेले प्रादेशिक विभागासाठीचे लक्ष',a.[DepartmentDecided] as 'प्रादेशिक विभागाने निश्चित केलेले लक्ष',a.[FromAccident] as 'अपघात प्रवण ठिकाण पासुन',a.[AccidentExecuted] as 'अपघात प्रवण ठिकाण पर्यंत',a.[AccidentKaryvahi] as 'अपघात कार्यवाही',b.[Itarkhrch] as 'इतर खर्च',b.[Dviguni] as 'दवगुनी ज्ञापने',a.[Pahanikramank] as 'पाहणीक्रमांक',a.[PahaniMudye] as 'पाहणीमुद्ये',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterGAT_D as a join GAT_DProvision as b on a.WorkID=b.WorkID  " +wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.Text == "2515_GramVikas")
            {
                sd = new SqlDataAdapter( buildquery + " from [BudgetMaster2515] as a join [2515Provision] as b on a.WorkID=b.WorkID "+wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.Text == "Residential_Building")
            {
                sd = new SqlDataAdapter( buildquery+"  from BudgetMasterResidentialBuilding as a join ResidentialBuildingProvision as b on a.WorkID=b.WorkID "+wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.Text == "NonResidential_Building")
            {
                sd = new SqlDataAdapter(buildquery+" from BudgetMasterNonResidentialBuilding as a join NonResidentialBuildingProvision as b on a.WorkID=b.WorkID  "+wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (ddlType.Text == "Annuity")
            {
                sd = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(PARTITION BY a.[Arthsankalpiyyear],a.[Upvibhag] ORDER BY a.[Arthsankalpiyyear],a.[upvibhag],a.[Taluka] desc) as 'अ क्र', a.[WorkId] as 'वर्क आयडी',a.PageNo as 'पेज क्र',a.ArthsankalpiyBab as 'बाब क्र',a.JulyBab as 'जुलै/ बाब क्र./पान क्र.',a.[Arthsankalpiyyear] as 'अर्थसंकल्पीय वर्ष',a.[KamacheName] as 'कामाचे नाव',a.[LekhaShirshName] as 'लेखाशीर्ष नाव',a.[SubType] as 'विभाग',a.[Upvibhag] as 'उपविभाग',a.[Taluka] as 'तालुका',convert(nvarchar(max),a.[ShakhaAbhyantaName])+' '+convert(nvarchar(max),a.[ShakhaAbhiyantMobile])as 'शाखा अभियंता नाव',convert(nvarchar(max),a.[UpabhyantaName])+' '+convert(nvarchar(max),a.[UpAbhiyantaMobile])as 'उपअभियंता नाव',a.[AmdaracheName] as 'आमदारांचे नाव',a.[KhasdaracheName] as 'खासदारांचे नाव',convert(nvarchar(max),a.[ThekedaarName])+' '+convert(nvarchar(max),a.[ThekedarMobile]) as 'ठेकेदार नाव',convert(nvarchar(max),a.[PrashaskiyKramank])+' '+convert(nvarchar(max),a.[PrashaskiyAmt])+' '+convert(nvarchar(max),a.[PrashaskiyDate])as 'प्रशासकीय मान्यता क्र/रक्कम/दिनांक',convert(nvarchar(max),a.[TrantrikKrmank])+' '+convert(nvarchar(max),a.[TrantrikAmt])+' '+convert(nvarchar(max),a.[TrantrikDate])as 'तांत्रिक मान्यता क्र/रक्कम/दिनांक',a.[Kamachevav] as 'कामाचा वाव',convert(nvarchar(max),a.[NividaKrmank])+' '+convert(nvarchar(max),a.[NividaDate])as 'निविदा क्र/दिनांक',cast(a.[NividaAmt] as decimal(10,2)) as 'निविदा रक्कम % कमी / जास्त',a.[karyarambhadesh] as 'कार्यारंभ आदेश',a.[kamachiMudat] as 'बांधकाम कालावधी',a.[KamPurnDate] as 'काम पूर्ण तारीख',CAST(CASE WHEN b.[MudatVadhiDate] = ' ' or b.[MudatVadhiDate] = '0' THEN N'होय' ELSE N'नाही' END as nvarchar(max)) as 'मुदतवाढ बाबत',b.[ManjurAmt] as 'मंजूर अंदाजित किंमत',b.[MarchEndingExpn] as 'मार्च अखेर खर्च 2017',b.[UrvaritAmt] as 'उर्वरित किंमत',b.[Chalukharch] as 'चालु खर्च',b.[Magilkharch] as 'मागील खर्च',b.[VarshbharatilKharch] as 'सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च',b.[AikunKharch] as 'एकुण कामावरील खर्च',b.[Takunone] as'2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017',b.[Takuntwo] as '2016-17 मधील अर्थसंकल्पीय तरतूद जुलै 2016',b.[Takunthree] as 'तृतीय तिमाही तरतूद',b.[Takunfour] as 'चतुर्थ तिमाही तरतूद',b.[Tartud] as 'एकूण अर्थसंकल्पीय तरतूद',b.[Magni] as '2016-17 साठी मागणी',b.[Vidyutprama] as 'विद्युतीकरणावरील प्रमा',b.[Vidyutvitarit] as 'विद्युतीकरणावरील वितरित',b.[Itarkhrch] as 'इतर खर्च',b.[Dviguni] as 'दवगुनी ज्ञापने',a.[Pahanikramank] as 'पाहणी क्रमांक',a.[PahaniMudye] as 'पाहणीमुद्ये',b.[DeyakachiSadyasthiti] as 'देयकाची सद्यस्थिती',CAST(CASE WHEN a.[Sadyasthiti] = 'Completed'  THEN 1 ELSE 0 END as decimal(10,0)) as 'C',CAST(CASE WHEN a.[Sadyasthiti] = 'Processing'  THEN 1 ELSE 0 END as decimal(10,0)) as 'P',CAST(CASE WHEN a.[Sadyasthiti] = 'Not Started'  THEN 1 ELSE 0 END as decimal(10,0)) as 'NS',convert(nvarchar(max),a.[Sadyasthiti])+' '+convert(nvarchar(max),a.[Shera]) as 'शेरा' from BudgetMasterAunty as a join AuntyProvision as b on a.WorkID=b.WorkID  " + wherecond, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Sorry Record not found...!!!')</script>");
            }
            Session["SReportPanel"] = Panel1;
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

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MasterReport" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            // BindGridAll();
            UpdatePanel2.RenderControl(htw);
            //GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/exportedfiles/");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }
            Session["filename"] = "WorkIdWiseReport.xls";
            if (File.Exists(path + Session["filename"].ToString()))
            {
                File.Delete(path + Session["filename"].ToString()); // DELETE THE FILE BEFORE CREATING A NEW ONE.           
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "WorkIdWiseReport.xls");
                    //RenderAllGrid(sw, htw);
                    Panel1.RenderControl(htw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }
            Response.Redirect("SendMail.aspx");
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string gridHTML = string.Empty;
            if (GridView1.Rows.Count != 0)
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
                string Header = "<h2>Building</h2>";
                Session["BuildGridHTML"] = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                //string gridHTML = Header + sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");

            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            string style = "<style type = 'text/css'>thead {display:table-header-group;} tfoot{display:table-footer-group;}</style>";
            sb.Append(style + Session["BuildGridHTML"]);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();");
            sb.Append("};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            Session["BuildGridHTML"] = null;
            sb.Clear();

            if (GridView1.Rows.Count != 0)
            {
                GridView1.DataBind();
            }
        }
    }
}