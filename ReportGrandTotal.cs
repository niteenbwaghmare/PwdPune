using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace PWdEEBudget
{
    public class ReportGrandTotal
    {
        //Variable for MasterNabard_Report
        public decimal AACost { get; set; }
        public decimal TsCost { get; set; }
        public decimal ExpUptoMarch { get; set; }
        public decimal BudgetProvision { get; set; }
        public decimal Demand { get; set; }
        public decimal ExpUpto_8 { get; set; }
        public decimal PrashaskiyAmt { get; set; }
        public decimal TantrikAmt { get; set; }

        public decimal Wbm1 { get; set; }
        public decimal Wbm2 { get; set; }
        public decimal Wbm3 { get; set; }

        public decimal Bbm { get; set; }
        public decimal Karpet { get; set; }
        public decimal Surface { get; set; }
        public decimal SecPro { get; set; }
        public decimal TirdPro { get; set; }
        public decimal ForthPro { get; set; }
        public decimal TotalPro { get; set; }
        public decimal AkunKharch { get; set; }
        public decimal TenderAmount { get; set; }
        public decimal CdWork { get; set; }


        //For All Report
        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }

        //For masterNabard_Report
        public int AACost_Index { get; set; }
        public int TsCost_index { get; set; }
        public int Expmar_Index { get; set; }
        public int Budget_Index { get; set; }
        public int Demand_Index { get; set; }
        public int Exp_8_index { get; set; }
        public int TenderAmount_index { get; set; }
        public int CdWork_Index { get; set; }

        public int Wbm1_index { get; set; }
        public int Wbm2_index { get; set; }
        public int Wbm3_index { get; set; }
        public int Bbm_index { get; set; }
        public int Karpet_index { get; set; }
        public int Surface_index { get; set; }
        public int SecPro_index { get; set; }
        public int TirdPro_index { get; set; }
        public int ForthPro_index { get; set; }
        public int TotalPro_index { get; set; } 
        public int AkunKharch_index { get; set; }
        
        //for All report
        public int Apr_index { get; set; }
        public int May_index { get; set; }
        public int Jun_index { get; set; }
        public int Jul_index { get; set; }
        public int Aug_index { get; set; }
        public int sep_index { get; set; }
        public int Oct_index { get; set; }
        public int Nov_index { get; set; }
        public int Dec_index { get; set; }
        public int Jan_index { get; set; }
        public int Feb_index { get; set; }
        public int Mar_index { get; set; }

        //For MasterBuilding_Report

        public decimal MarchAkher { get; set; }
        public decimal ArthsankalpTartud { get; set; }
        public decimal VitritTartud { get; set; }
        public decimal ExpUp { get; set; }
        public decimal Magni { get; set; }
        public decimal EkunKamavarilKharch { get; set; }
        public decimal YearExp { get; set; }
        public decimal VidyutikarnPrama { get; set; }
        public decimal Vidyutikarnvitarit { get; set; }
        public decimal OtherExp { get; set; }


        public int MarchAkher_Index { get; set; }
        public int ArthsankalpTartud_Index { get; set; }
        public int VitritTartud_Index { get; set; }
        public int ExpUp_Index { get; set; }
        public int Magni_Index { get; set; }
        public int EkunKamavarilKharch_Index { get; set; }
        public int YearExp_Index { get; set; }
        public int VidyutikarnPrama_Index { get; set; }
        public int Vidyutikarnvitarit_Index { get; set; }
        public int OtherExp_Index { get; set; }
        public int Total_index { get; set; }
        public int PrashaskiyAmt_index { get; set; }
        public int TantrikAmt_index { get; set; }



        // for Road 
        public decimal ManjurAmt { get; set; }
        public decimal MarchEndingExpn { get; set; }
        public decimal UrvaritAmt { get; set; }
        public decimal Takunone { get; set; }
        public decimal Takuntwo { get; set; }
        public decimal Tartud { get; set; }
        public decimal AkunAnudan { get; set; }
        public decimal Magilkharch { get; set; }

        public decimal C { get; set; }
        public decimal P { get; set; }
        public decimal NS { get; set; }
        public decimal ES { get; set; }
        public decimal TS { get; set; }
        public decimal Vidyutprama { get; set; }
        public decimal Vidyutvitarit { get; set; }
        public decimal Itarkhrch { get; set; }

        public decimal Chalukharch { get; set; }
        public decimal TisriTartud { get; set; }
        public decimal ChothiTartud { get; set; }
       
        // for Road

        public int ManjurAmt_index { get; set; }
        public int MarchEndingExpn_index { get; set; }
        public int UrvaritAmt_index { get; set; }
        public int Takunone_index { get; set; }
        public int Takuntwo_index { get; set; }
        public int Tartud_index { get; set; }
        public int AkunAnudan_index { get; set; }
        public int Magilkharch_index { get; set; }       
        public int Vidyutprama_index { get; set; }
        public int Vidyutvitarit_index { get; set; }
        public int Itarkhrch_index { get; set; }
        public int C_index { get; set; }
        public int P_index { get; set; }
        public int NS_index { get; set; }
        public int ES_index { get; set; }
        public int TS_index { get; set; }

        public int Chalukharch_index { get; set; }
        public int TisriTartud_index { get; set; }
        public int ChothiTartud_index { get; set; }
       
        //Gat_A GrandTotal

        public decimal JobAmt { get; set; }
        public decimal DabrichePariman { get; set; }
        public decimal DabrichiAmt { get; set; }
        public decimal ShilakDayitv { get; set; }
        public decimal ShilakDayitvASlyas { get; set; }
        public decimal DayitvAslyasAmt { get; set; }
        public decimal VidyutikarnKamchiKimat { get; set; }
        public decimal VidyutiKarnchaKharch { get; set; }
        public decimal DabrichKharch { get; set; }
        public decimal KharchSanAkher { get; set; }
        public decimal VaparDambPariman { get; set; }

        //Gat_A Index
        public int VaparDambPariman_index { get; set; }
        public int JobAmt_Index { get; set; }
        public int DabrichePariman_Index { get; set; }
        public int DabrichiAmt_index { get; set; }
        public int ShilakDayitv_Index { get; set; }
        public int DayitvAslyasAmt_Index { get; set; }
        public int VidyutikarnKamchiKimat_Index { get; set; }
        public int VidyutiKarnchaKharch_index { get; set; }
        public int DabrichKharch_index { get; set; }
        public int ShilakDayitvASlyas_index { get; set; }
        public int ArthsankalpBab_index { get; set; }
        public int KharchSanAkher_index { get; set; }

        // Gat_B /Gat_C /Gat_F Grand Total


        public decimal PikRol { get; set; }
        public decimal NavinKhandikarnex { get; set; }
        public decimal B_M_Karpet { get; set; }
        public decimal MM_20_Karpet { get; set; }
        public decimal SarfhesDresing { get; set; }
        public decimal RundiKaran { get; set; }
        public decimal PulMoYa { get; set; }
        public decimal DurusthichaPratiKharch { get; set; }

  //Gat_B/C/F Index

        public int PikRol_Index { get; set; }
        public int NavinKhandikarn_index { get; set; }
        public int B_M_Karpet_index { get; set; }
        public int MM_20_Karpet_index { get; set; }
        public int SarfhesDresing_index { get; set; }
        public int RundiKaran_index { get; set; }
        public int PulMoYa_index { get; set; }
        public int DurusthichaPratiKharch_index { get; set; }


        //Gat_D
        public decimal UpghatPrawanThikanParent { get; set; }
        public decimal ExpdFrom { get; set; } 
        public decimal NividaRakkam { get; set; }
        public int ExpdFrom_index { get; set; }
        public int UpghatPrawanThikanParent_index { get; set; }
        public int NividaRakkam_index { get; set; }

        //D_Fund
        public decimal Madhil_16_17ShilakTev { get; set; }
        public decimal VitaritThev { get; set; }

        public int Madhil_16_17ShilakTev_index { get; set; }
        public int VitaritThev_index { get; set; }

        //Gat_FBC
        public decimal Anya { get; set; }

        public decimal KamchiKimat { get; set; }

        public decimal Deykachi { get; set; }

        public int Anya_index { get; set; }

        public int KamchiKimat_index { get; set; }

        public int Deykachi_index { get; set; }

        //D_Fund
        public decimal ShillakThev { get; set; }
        public decimal VitritThev { get; set; }
        public int ShillakThev_index { get; set; }
        public int VitritThev_index { get; set; }


        //This Method For masertNabard_Report
        public void index(string[] dr)
        {

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr == null)
                {

                }
                //For MasterNabard_Report
                if (dr[i].ToString() == "AA cost Rs in lakhs")
                {
                    AACost_Index = i;
                }
                else if (dr[i].ToString() == "वापर डांबरीचे परिमाण")
                {
                    VaparDambPariman_index = i;
                }
                else if (dr[i].ToString() == "वर्क आयडी" || dr[i].ToString() == "Work Id" || dr[i].ToString() == "WorkId")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "Technical Sanction Cost Rs in Lakh")
                {
                    TsCost_index = i;
                }
                else if (dr[i].ToString() == "Expenditure up to MAR 2016 Rs in Lakhs" || dr[i].ToString() == "Expenditure up to MAR" || dr[i].ToString() == "Expenditure up to MAR 2017")
                {
                    Expmar_Index = i;
                }
                else if (dr[i].ToString() == "Budget Provision in 16-17 Rs in Lakhs" || dr[i].ToString() == "Budget Provision in 2017-18 Rs in Lakhs")
                {
                    Budget_Index = i;
                }
                else if (dr[i].ToString() == "Demand for 2016-17 Rs in Lakhs" || dr[i].ToString() == "Demand for 2017-2018 Rs in Lakhs" || dr[i].ToString() == "Demand for 2017-18 Rs in Lakhs")
                {
                    Demand_Index = i;
                }
                else if (dr[i].ToString() == "Expenditure up to 8/2016 during year 16-17 Rs in Lakhs" || dr[i].ToString() == "Expenditure up to 8/2017 during year17-18 Rs in Lakhs")
                {
                    Exp_8_index = i;
                }

                    // Nabard SReport

                else if (dr[i].ToString() == "WBMI Km")
                {
                    Wbm1_index = i;
                }
                else if (dr[i].ToString() == "WBMII Km")
                {
                    Wbm2_index = i;
                }
                else if (dr[i].ToString() == "WBMIII Km")
                {
                    Wbm3_index = i;
                }
                else if (dr[i].ToString() == "BBM Km")
                {
                    Bbm_index = i;
                }
                else if (dr[i].ToString() == "Carpet Km")
                {
                    Karpet_index = i;
                }
                else if (dr[i].ToString() == "Surface Km")
                {
                    Surface_index = i;
                }
                else if (dr[i].ToString() == "Second Provision")
                {
                    SecPro_index = i;
                }
                else if (dr[i].ToString() == "Third Provision")
                {
                    TirdPro_index = i;
                }
                else if (dr[i].ToString() == "Fourth Provision")
                {
                    ForthPro_index = i;
                }
                else if (dr[i].ToString() == "Total Provision")
                {
                    TotalPro_index = i;
                }
                else if (dr[i].ToString() == "Total Grand")
                {
                    AkunAnudan_index = i;
                }
                else if (dr[i].ToString() == "Current Cost")
                {
                    Chalukharch_index = i;
                }
                else if (dr[i].ToString() == "Previous Cost")
                {
                    Magilkharch_index = i;
                }
                else if (dr[i].ToString() == "Total Expense")
                {
                    AkunKharch_index = i;
                }

                else if (dr[i].ToString() == "Tender Amount")
                {
                    TenderAmount_index = i;
                }
                else if (dr[i].ToString() == "CD_Works_No")
                {
                    CdWork_Index = i;
                }

                //For All
                else if (dr[i].ToString() == "Apr")
                {
                    Apr_index = i;
                }
                else if (dr[i].ToString() == "May")
                {
                    May_index = i;
                }
                else if (dr[i].ToString() == "Jun")
                {
                    Jun_index = i;

                }
                else if (dr[i].ToString() == "Jul")
                {
                    Jul_index = i;
                }
                else if (dr[i].ToString() == "Aug")
                {
                    Aug_index = i;
                }
                else if (dr[i].ToString() == "Sep")
                {
                    sep_index = i;
                }
                else if (dr[i].ToString() == "Oct")
                {
                    Oct_index = i;
                }
                else if (dr[i].ToString() == "Nov")
                {
                    Nov_index = i;
                }
                else if (dr[i].ToString() == "Dec")
                {
                    Dec_index = i;
                }
                else if (dr[i].ToString() == "Jan")
                {
                    Jan_index = i;
                }
                else if (dr[i].ToString() == "Feb")
                {
                    Feb_index = i;
                }
                else if (dr[i].ToString() == "Mar")
                {
                    Mar_index = i;

                }

                    //For MasterBuilding_Report
                else if (dr[i].ToString() == "मार्च अखेर खर्च" || dr[i].ToString() == "मार्च अखेर खर्च 2017")
                {
                    MarchAkher_Index = i;

                }
                else if (dr[i].ToString() == "अर्थसंकल्पीय तरतूद")
                {
                    ArthsankalpTartud_Index = i;

                }
                else if (dr[i].ToString() == "वितरित तरतूद")
                {
                    VitritTartud_Index = i;

                }
                else if (dr[i].ToString() == "Expenditure Up")
                {
                    ExpUp_Index = i;

                }
                else if (dr[i].ToString() == "मागणी")
                {
                    Magni_Index = i;
                }
                else if (dr[i].ToString() == "एकुण कामावरील खर्च")
                {
                    EkunKamavarilKharch_Index = i;

                }
                else if (dr[i].ToString() == "प्रशासकीय मान्यता रक्कम")
                {
                    PrashaskiyAmt_index = i;

                }
                else if (dr[i].ToString() == "तांत्रिक मान्यता रक्कम")
                {
                    TantrikAmt_index = i;

                }
                else if (dr[i].ToString() == "वर्षभरातील खर्च" || dr[i].ToString() == "सन २०१६-१७ मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन २०१७-१८ मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन 2017-2018 मधील माहे एप्रिल/मे अखेर खर्च" || dr[i].ToString() == "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च")
                {
                    YearExp_Index = i;

                }

                else if (dr[i].ToString() == "विद्युतीकरणावरील प्रमा")
                {
                    VidyutikarnPrama_Index = i;
                    //for road
                    Vidyutprama_index = i;

                }
                else if (dr[i].ToString() == "विद्युतीकरणावरील वितरित")
                {
                    Vidyutikarnvitarit_Index = i;
                    //for road
                    Vidyutvitarit_index = i;

                }
                else if (dr[i].ToString() == "इतर खर्च" || dr[i].ToString() == "अन्"  )
                {
                    OtherExp_Index = i;
                    //for road
                    Itarkhrch_index = i;                                        
                }
                else if (dr[i].ToString() == "अन्य")
                {
                    Anya_index = i;
                }
                // for  Road
                else if (dr[i].ToString() == "मंजूर अंदाजित किंमत" || dr[i].ToString() == "मंजूर किंमत" || dr[i].ToString() == "Estimated Cost Approved")
                {
                    ManjurAmt_index = i;

                }
                else if (dr[i].ToString() == "सुरवाती पासून मार्च २०१६ अखेरचा खर्च" || dr[i].ToString() == "सुरवाती पासून मार्च २०१७ अखेरचा खर्च" || dr[i].ToString() == "सुरवाती पासून मार्च 2016 अखेरचा खर्च" || dr[i].ToString() == "सुरवाती पासून मार्च 2017 अखेरचा खर्च")
                {
                    MarchEndingExpn_index = i;

                }
                else if (dr[i].ToString() == "उर्वरित किंमत" || dr[i].ToString() == "Remaining Cost")
                {
                    UrvaritAmt_index = i;

                }
                else if (dr[i].ToString() == "२०१६-१७ मधील अर्थसंकल्पीय तरतूद मार्च २०१६" || dr[i].ToString() == "प्रथम तिमाही तरतूद" || dr[i].ToString() == "२०१७-१८ मधील अर्थसंकल्पीय तरतूद मार्च २०१७ " || dr[i].ToString() == "2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017" || dr[i].ToString() == "First Provision" || dr[i].ToString() == "२०१७-१८ मधील अर्थसंकल्पीय तरतूद मार्च २०१७")  
                {
                    Takunone_index = i;

                }
                else if (dr[i].ToString() == "२०१६-१७ मधील अर्थसंकल्पीय तरतूद जुलै २०१६" || dr[i].ToString() == "द्वितीय तिमाही तरतूद" || dr[i].ToString() == "२०१७-१८ मधील अर्थसंकल्पीय तरतूद जुलै २०१७" || dr[i].ToString() == "2017-18 मधील अर्थसंकल्पीय तरतूद जुलै 2017")
                {
                    Takuntwo_index = i;

                }
                else if (dr[i].ToString() == "तृतीय तिमाही तरतूद")
                {
                    TisriTartud_index = i;

                }
                else if (dr[i].ToString() == "चतुर्थ तिमाही तरतूद" || dr[i].ToString() == "चतुर्थ तिमाही तरतूद")
                {
                    ChothiTartud_index = i;

                }

                else if (dr[i].ToString() == "चालू खर्च" || dr[i].ToString() == "चालु खर्च")
                {
                    Chalukharch_index = i;
                    ExpUp_Index = i;

                }
                else if (dr[i].ToString() == "एकूण अर्थसंकल्पीय तरतूद" || dr[i].ToString() == "अर्थसंकल्पीय तरतूद")
                {
                    Tartud_index = i;

                }
                else if (dr[i].ToString() == "२०१६-१७ मधील वितरीत तरतूद" || dr[i].ToString() == "२०१७-१८ मधील वितरीत तरतूद" || dr[i].ToString() == "2017-18 मधील वितरीत तरतूद") 
                {
                    AkunAnudan_index = i;

                }
                else if (dr[i].ToString() == "२०१६-१७ मधील माहे ९/२०१६ अखेरचा" || dr[i].ToString() == "२०१७-१८ मधील माहे ९/२०१७ अखेरचा" || dr[i].ToString() == "मागील खर्च")
                {
                    Magilkharch_index = i;

                }
                else if (dr[i].ToString() == "२०१६-१७ साठी मागणी" || dr[i].ToString() == "२०१७-१८ साठी मागणी" || dr[i].ToString() == "2017-18 साठी मागणी")
                {
                    Magni_Index = i;

                }
                else if (dr[i].ToString() == "C")
                {
                    C_index = i;

                }
                else if (dr[i].ToString() == "P")
                {
                    P_index = i;

                }
                else if (dr[i].ToString() == "NS")
                {
                    NS_index = i;

                }
                else if (dr[i].ToString() == "ES")
                {
                    ES_index = i;
                }
                else if (dr[i].ToString() == "TS")
                {
                    TS_index = i;
                }
                //Master Gat_A

                else if (dr[i].ToString() == "जॉब रक्कम")
                {
                    JobAmt_Index = i;

                }
                else if (dr[i].ToString() == "डांबरीचे परिमाण")
                {
                    DabrichePariman_Index = i;

                }
                else if (dr[i].ToString() == "डांबरीची रक्कम")
                {
                    DabrichiAmt_index = i;

                }
                else if (dr[i].ToString() == "शिल्लक दायित्व रु")
                {
                    ShilakDayitv_Index = i;

                }
                else if (dr[i].ToString() == "दायित्व असल्यास रक्कम रु")
                {
                    DayitvAslyasAmt_Index = i;

                }
                else if (dr[i].ToString() == "विद्युतीकरण कामाची किंमत")
                {
                    VidyutikarnKamchiKimat_Index = i;

                }
                else if (dr[i].ToString() == "डांबरीचा खर्च")
                {
                    DabrichKharch_index = i;

                }
                else if (dr[i].ToString() == "विद्युतीकरणाचा खर्च")
                {
                    VidyutiKarnchaKharch_index = i;

                }
                else if (dr[i].ToString() == "अर्थसंकल्पीय बाब")
                {
                    ArthsankalpBab_index = i;

                }
                else if (dr[i].ToString() == "खर्च सन 2016 - 17  06/2016 अखेर" || dr[i].ToString() == "खर्च सन 2017 - 18  06/2017 अखेर")
                {
                    KharchSanAkher_index = i;

                }

            //Gat_B /Gat_C/Gat_F
                else if (dr[i].ToString() == "पीक व रोल")
                {
                    PikRol_Index = i;

                }
                else if (dr[i].ToString() == "देयकाची सद्यस्थिती")
                {
                    Deykachi_index = i;

                }
                else if (dr[i].ToString() == "कामाची किंमत")
                {
                    KamchiKimat_index = i;

                }
                else if (dr[i].ToString() == "नवीन खडीकरण")
                {
                    NavinKhandikarn_index = i;

                }
                else if (dr[i].ToString() == "बी एम व कारपेट सिलकोट सह" || dr[i].ToString() == "बी.एम व कारपेट सिलकोट सह")
                {
                    B_M_Karpet_index = i;

                }
                else if (dr[i].ToString() == "20 मीमी कारपेटसिलकोट सह")
                {
                    MM_20_Karpet_index = i;

                }
                else if (dr[i].ToString() == "सरफेस ड्रेसिंग")
                {
                    SarfhesDresing_index = i;

                }
                else if (dr[i].ToString() == "रुंदी करण")
                {
                    RundiKaran_index = i;

                }
                else if (dr[i].ToString() == "पूल/ मो-या")
                {
                    PulMoYa_index = i;

                }
                else if (dr[i].ToString() == "दुरुस्तीचा प्रती खर्च")
                {
                    DurusthichaPratiKharch_index = i;

                }
                    //Gat_D
                else if (dr[i].ToString() == "अपघात प्रवण ठिकाण पर्यंत")
                {
                    UpghatPrawanThikanParent_index = i;
                }
                else if (dr[i].ToString() == "Expenditure From" || dr[i].ToString() == "मागील खर्च")
                {
                    ExpdFrom_index = i;

                }
                else if (dr[i].ToString() == "निविदा रक्कम % कमी / जास्त")
                {
                    NividaRakkam_index = i;

                }
                //D_Fund

                else if (dr[i].ToString() == "16-17 वितरीत ठेव" || dr[i].ToString() == "17-18 वितरीत ठेव" || dr[i].ToString() == "१६-१७ वितरीत ठेव" || dr[i].ToString() == "2017-18 वितरीत ठेव")
                {
                    VitaritThev_index = i;
                    //Sreport d_Fund
                    VitritThev_index = i;
                }
                else if (dr[i].ToString() == "16-17 मधील शिल्लक ठेव" || dr[i].ToString() == "17-18 मधील शिल्लक ठेव" || dr[i].ToString() == "2017-18 मधील शिल्लक ठेव")
                {
                    Madhil_16_17ShilakTev_index = i;
                    //Sreport d_Fund
                    ShillakThev_index = i;
                }


            }
        }
    }
   
    //road And Annuty
    public class RoadGrandTotal
    {
        public decimal ManjurAmt { get; set; }
        public decimal MarchEndingExpn { get; set; }
        public decimal UrvaritAmt { get; set; }
        public decimal Takunone { get; set; }
        public decimal Takuntwo { get; set; }
        public decimal Tartud { get; set; }
        public decimal AkunAnudan { get; set; }
        public decimal Magilkharch { get; set; }
        public decimal Magni { get; set; }
        public decimal C { get; set; }
        public decimal P { get; set; }
        public decimal ES { get; set; }
        public decimal TS { get; set; }
        public decimal NS { get; set; }
        public decimal Vidyutprama { get; set; }
        public decimal Vidyutvitarit { get; set; }
        public decimal Itarkhrch { get; set; }

        public decimal Chalukharch { get; set; }
        public decimal TisriTartud { get; set; }
        public decimal ChothiTartud { get; set; }
        public decimal EkunKamavarilKharch { get; set; }
        public decimal YearExp { get; set; }

        //New 
        public decimal PrashaskiyAmt { get; set; }
        public decimal TantrikAmt { get; set; }

        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }
        public decimal NividaRakkam { get; set; }


        public int ManjurAmt_index { get; set; }
        public int MarchEndingExpn_index { get; set; }
        public int UrvaritAmt_index { get; set; }
        public int Takunone_index { get; set; }
        public int Takuntwo_index { get; set; }
        public int Tartud_index { get; set; }
        public int AkunAnudan_index { get; set; }
        public int Magilkharch_index { get; set; }
        public int Magni_Index { get; set; }
        public int P_index { get; set; }
        public int NS_index { get; set; }
        public int Vidyutprama_index { get; set; }
        public int Vidyutvitarit_index { get; set; }
        public int Itarkhrch_index { get; set; }
        public int C_index { get; set; }
        public int ES_index { get; set; }
        public int TS_index { get; set; }


        public int Chalukharch_index { get; set; }
        public int TisriTartud_index { get; set; }
        public int ChothiTartud_index { get; set; }
        public int EkunKamavarilkharch_index { get; set; }
        public int YearExp_index { get; set; }

        public int Apr_index { get; set; }
        public int May_index { get; set; }
        public int Jun_index { get; set; }
        public int Jul_index { get; set; }
        public int Aug_index { get; set; }
        public int sep_index { get; set; }
        public int Oct_index { get; set; }
        public int Nov_index { get; set; }
        public int Dec_index { get; set; }
        public int Jan_index { get; set; }
        public int Feb_index { get; set; }
        public int Mar_index { get; set; }
        public int Total_index { get; set; }
        public int NividaRakkam_index { get; set; }
        public decimal ExpeUp { get; set; }

        public int ExpeUp_index { get; set; }
        //new 
        public int PrashaskiyAmt_index { get; set; }
        public int TantrikAmt_index { get; set; }

        public void index(string[] dr)
        {

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr == null)
                {

                }
                else if (dr[i].ToString() == "वर्क आयडी")
                {
                    Total_index = i;
                }

                else if (dr[i].ToString() == "Expenditure Up")
                {
                    ExpeUp_index = i;
                }
                
                else if (dr[i].ToString() == "मंजूर अंदाजित किंमत")
                {
                    ManjurAmt_index = i;

                }
                else if (dr[i].ToString() == "सुरवाती पासून मार्च २०१६ अखेरचा खर्च" || dr[i].ToString() == "सुरवाती पासून मार्च २०१७ अखेरचा खर्च" || dr[i].ToString() == "मार्च अखेर खर्च" || dr[i].ToString() == "मार्च अखेर खर्च 2017" || dr[i].ToString() == "सुरवाती पासून मार्च 2017 अखेरचा खर्च")
                {
                    MarchEndingExpn_index = i;

                }
                else if (dr[i].ToString() == "उर्वरित किंमत")
                {
                    UrvaritAmt_index = i;

                }
                else if (dr[i].ToString() == "२०१६-१७ मधील अर्थसंकल्पीय तरतूद मार्च २०१६" || dr[i].ToString() == "२०१७-१८ मधील अर्थसंकल्पीय तरतूद मार्च २०१७" || dr[i].ToString() == "2017-18 मधील अर्थसंकल्पीय तरतूद मार्च 2017")
                {
                    Takunone_index = i;

                }
                else if (dr[i].ToString() == "२०१६-१७ मधील अर्थसंकल्पीय तरतूद जुलै २०१६" || dr[i].ToString() == "२०१७-१८ मधील अर्थसंकल्पीय तरतूद जुलै २०१७" || dr[i].ToString() == "2016-17 मधील अर्थसंकल्पीय तरतूद जुलै 2016" || dr[i].ToString() == "2017-18 मधील अर्थसंकल्पीय तरतूद जुलै 2017")
                {
                    Takuntwo_index = i;

                }
                else if (dr[i].ToString() == "तृतीय तिमाही तरतूद")
                {
                    TisriTartud_index = i;

                }
                else if (dr[i].ToString() == "चतुर्थ तिमाही तरतूद" ||dr[i].ToString()=="चतुर्थ तिमाही तरतूद")
                {
                    ChothiTartud_index = i;

                }
                else if (dr[i].ToString() == "एकुण कामावरील खर्च")
                {
                    EkunKamavarilkharch_index = i;

                }
                else if (dr[i].ToString() == "वर्षभरातील खर्च" || dr[i].ToString() == "सन २०१६-१७ मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन २०१७-१८ मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च")
                {
                    YearExp_index = i;

                }
                else if (dr[i].ToString() == "चालू खर्च" || dr[i].ToString() == "चालु खर्च")
                {
                    Chalukharch_index = i;

                }
                else if (dr[i].ToString() == "एकूण अर्थसंकल्पीय तरतूद")
                {
                    Tartud_index = i;

                }
                else if (dr[i].ToString() == "२०१६-१७ मधील वितरीत तरतूद" || dr[i].ToString() == "२०१७-१८ मधील वितरीत तरतूद" || dr[i].ToString() == "2017-18 मधील वितरीत तरतूद")
                {
                    AkunAnudan_index = i;

                }
                else if (dr[i].ToString() == "२०१६-१७ मधील माहे ९/२०१६ अखेरचा" || dr[i].ToString() == "२०१७-१८ मधील माहे ९/२०१७ अखेरचा" || dr[i].ToString() == "2017-18 मधील माहे 9/2017 अखेरचा" || dr[i].ToString() == "मागील खर्च" || dr[i].ToString() == "2016-17 मधील माहे 9/2016 अखेरचा")
                {
                    Magilkharch_index = i;

                }
                else if (dr[i].ToString() == "२०१६-१७ साठी मागणी" || dr[i].ToString() == "२०१७-१८ साठी मागणी" || dr[i].ToString() == "2016-17 साठी मागणी" || dr[i].ToString() == "2017-18 साठी मागणी")
                {
                    Magni_Index = i;

                }
                else if (dr[i].ToString() == "विद्युतीकरणावरील प्रमा")
                {

                    Vidyutprama_index = i;

                }
                else if (dr[i].ToString() == "विद्युतीकरणावरील वितरित")
                {

                    Vidyutvitarit_index = i;

                }
                else if (dr[i].ToString() == "इतर खर्च")
                {

                    Itarkhrch_index = i;
                }
                else if (dr[i].ToString() == "C")
                {
                    C_index = i;

                }
                else if (dr[i].ToString() == "P")
                {
                    P_index = i;

                }
                else if (dr[i].ToString() == "NS")
                {
                    NS_index = i;

                }
                else if (dr[i].ToString() == "ES")
                {
                    ES_index = i;
                }
                else if (dr[i].ToString() == "TS")
                {
                    TS_index = i;
                }
                else if (dr[i].ToString() == "Apr")
                {
                    Apr_index = i;
                }
                else if (dr[i].ToString() == "May")
                {
                    May_index = i;
                }
                else if (dr[i].ToString() == "Jun")
                {
                    Jun_index = i;

                }
                else if (dr[i].ToString() == "Jul")
                {
                    Jul_index = i;
                }
                else if (dr[i].ToString() == "Aug")
                {
                    Aug_index = i;
                }
                else if (dr[i].ToString() == "Sep")
                {
                    sep_index = i;
                }
                else if (dr[i].ToString() == "Oct")
                {
                    Oct_index = i;
                }
                else if (dr[i].ToString() == "Nov")
                {
                    Nov_index = i;
                }
                else if (dr[i].ToString() == "Dec")
                {
                    Dec_index = i;
                }
                else if (dr[i].ToString() == "Jan")
                {
                    Jan_index = i;
                }
                else if (dr[i].ToString() == "Feb")
                {
                    Feb_index = i;
                }
                else if (dr[i].ToString() == "Mar")
                {
                    Mar_index = i;

                }
                else if (dr[i].ToString() == "निविदा रक्कम % कमी / जास्त")
                {
                    NividaRakkam_index = i;

                }
                    //New index
                else if (dr[i].ToString() == "प्रशासकीय मान्यता रक्कम")
                {
                    PrashaskiyAmt_index = i;

                }
                else if (dr[i].ToString() == "तांत्रिक मान्यता रक्कम")
                {
                    TantrikAmt_index = i;

                }
            }

        }

    }

    public class BulidGrandTotal
    {
        public decimal MarchAkher { get; set; }
        public decimal ArthsankalpTartud { get; set; }
        public decimal VitritTartud { get; set; }
        public decimal ExpUp { get; set; }
        public decimal Magni { get; set; }
        public decimal EkunKamavarilKharch { get; set; }
        public decimal YearExp { get; set; }
        public decimal VidyutikarnPrama { get; set; }
        public decimal Vidyutikarnvitarit { get; set; }
        public decimal OtherExp { get; set; }
        public decimal Takunone { get; set; }
        public decimal Takuntwo { get; set; }
        public decimal Takunthree { get; set; }
        public decimal Takunfour { get; set; }

        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }


        public int MarchAkher_Index { get; set; }
        public int ArthsankalpTartud_Index { get; set; }
        public int VitritTartud_Index { get; set; }
        public int ExpUp_Index { get; set; }
        public int Magni_Index { get; set; }
        public int EkunKamavarilKharch_Index { get; set; }
        public int YearExp_Index { get; set; }
        public int VidyutikarnPrama_Index { get; set; }
        public int Vidyutikarnvitarit_Index { get; set; }
        public int OtherExp_Index { get; set; }
        public int Total_index { get; set; }

        public int Takunone_index { get; set; }
        public int Takuntwo_index { get; set; }
        public int Takunthree_index { get; set; }
        public int Takunfour_index { get; set; }

        public int MagileKharch_index { get; set; }

        public decimal MagileKharch { get; set; }
        public int Apr_index { get; set; }
        public int May_index { get; set; }
        public int Jun_index { get; set; }
        public int Jul_index { get; set; }
        public int Aug_index { get; set; }
        public int sep_index { get; set; }
        public int Oct_index { get; set; }
        public int Nov_index { get; set; }
        public int Dec_index { get; set; }
        public int Jan_index { get; set; }
        public int Feb_index { get; set; }
        public int Mar_index { get; set; }


        public void index(string[] dr)
        {

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr == null)
                {

                }
                else if (dr[i].ToString() == "मार्च अखेर खर्च")
                {
                    MarchAkher_Index = i;

                }
                else if (dr[i].ToString() == "वर्क आयडी" || dr[i].ToString() == "Work Id")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "अर्थसंकल्पीय तरतूद")
                {
                    ArthsankalpTartud_Index = i;

                }
                else if (dr[i].ToString() == "वितरित तरतूद")
                {
                    VitritTartud_Index = i;

                }
                else if (dr[i].ToString() == "Expenditure Up" || dr[i].ToString() == "चालु खर्च")
                {
                    ExpUp_Index = i;

                }
                else if (dr[i].ToString() == "मागील खर्च")
                {
                    MagileKharch_index = i;

                }
                else if (dr[i].ToString() == "मागणी")
                {
                    Magni_Index = i;
                }
                else if (dr[i].ToString() == "एकुण कामावरील खर्च")
                {
                    EkunKamavarilKharch_Index = i;

                }
                else if (dr[i].ToString() == "वर्षभरातील खर्च" || dr[i].ToString() == "सन २०१६-१७ मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च")
                {
                    YearExp_Index = i;

                }

                else if (dr[i].ToString() == "विद्युतीकरणावरील प्रमा")
                {
                    VidyutikarnPrama_Index = i;


                }
                else if (dr[i].ToString() == "विद्युतीकरणावरील वितरित")
                {
                    Vidyutikarnvitarit_Index = i;


                }
                else if (dr[i].ToString() == "प्रथम तिमाही तरतूद")
                {
                    Takunone_index = i;

                }
                else if (dr[i].ToString() == "द्वितीय तिमाही तरतूद")
                {
                    Takuntwo_index = i;

                }
                else if (dr[i].ToString() == "तृतीय तिमाही तरतूद")
                {
                    Takunthree_index = i;

                }
                else if (dr[i].ToString() == "चतुर्थ तिमाही तरतूद")
                {
                    Takunfour_index = i;

                }
                else if (dr[i].ToString() == "इतर खर्च")
                {
                    OtherExp_Index = i;

                }
                else if (dr[i].ToString() == "Apr")
                {
                    Apr_index = i;
                }
                else if (dr[i].ToString() == "May")
                {
                    May_index = i;
                }
                else if (dr[i].ToString() == "Jun")
                {
                    Jun_index = i;

                }
                else if (dr[i].ToString() == "Jul")
                {
                    Jul_index = i;
                }
                else if (dr[i].ToString() == "Aug")
                {
                    Aug_index = i;
                }
                else if (dr[i].ToString() == "Sep")
                {
                    sep_index = i;
                }
                else if (dr[i].ToString() == "Oct")
                {
                    Oct_index = i;
                }
                else if (dr[i].ToString() == "Nov")
                {
                    Nov_index = i;
                }
                else if (dr[i].ToString() == "Dec")
                {
                    Dec_index = i;
                }
                else if (dr[i].ToString() == "Jan")
                {
                    Jan_index = i;
                }
                else if (dr[i].ToString() == "Feb")
                {
                    Feb_index = i;
                }
                else if (dr[i].ToString() == "Mar")
                {
                    Mar_index = i;

                }
            }
        }
    }

    public class ResiBuildGrandTotal
    {
        public decimal MarchAkher { get; set; }
        public decimal ArthsankalpTartud { get; set; }
        public decimal VitritTartud { get; set; }
        public decimal ExpUp { get; set; }
        public decimal Magni { get; set; }
        public decimal EkunKamavarilKharch { get; set; }
        public decimal YearExp { get; set; }
        public decimal VidyutikarnPrama { get; set; }
        public decimal Vidyutikarnvitarit { get; set; }
        public decimal OtherExp { get; set; }

        public decimal Takunone { get; set; }
        public decimal Takuntwo { get; set; }
        public decimal Takunthree { get; set; }
        public decimal Takunfour { get; set; }

        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }


        public int MarchAkher_Index { get; set; }
        public int ArthsankalpTartud_Index { get; set; }
        public int VitritTartud_Index { get; set; }
        public int ExpUp_Index { get; set; }
        public int Magni_Index { get; set; }
        public int EkunKamavarilKharch_Index { get; set; }
        public int YearExp_Index { get; set; }
        public int VidyutikarnPrama_Index { get; set; }
        public int Vidyutikarnvitarit_Index { get; set; }
        public int OtherExp_Index { get; set; }

        public int Takunone_index { get; set; }
        public int Takuntwo_index { get; set; }
        public int Takunthree_index { get; set; }
        public int Takunfour_index { get; set; }

        public int Total_index { get; set; }
        public int Apr_index { get; set; }
        public int May_index { get; set; }
        public int Jun_index { get; set; }
        public int Jul_index { get; set; }
        public int Aug_index { get; set; }
        public int sep_index { get; set; }
        public int Oct_index { get; set; }
        public int Nov_index { get; set; }
        public int Dec_index { get; set; }
        public int Jan_index { get; set; }
        public int Feb_index { get; set; }
        public int Mar_index { get; set; }


        public void index(string[] dr)
        {

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr == null)
                {

                }
                else if (dr[i].ToString() == "वर्क आयडी" || dr[i].ToString() == "Work Id")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "मार्च अखेर खर्च")
                {
                    MarchAkher_Index = i;

                }
                else if (dr[i].ToString() == "अर्थसंकल्पीय तरतूद")
                {
                    ArthsankalpTartud_Index = i;

                }
                else if (dr[i].ToString() == "वितरित तरतूद")
                {
                    VitritTartud_Index = i;

                }
                else if (dr[i].ToString() == "Expenditure Up" || dr[i].ToString() == "चालू खर्च")
                {
                    ExpUp_Index = i;

                }
                else if (dr[i].ToString() == "मागणी")
                {
                    Magni_Index = i;
                }
                else if (dr[i].ToString() == "एकुण कामावरील खर्च")
                {
                    EkunKamavarilKharch_Index = i;

                }
                else if (dr[i].ToString() == "वर्षभरातील खर्च" || dr[i].ToString() == "सन २०१६-१७ मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन २०१७-१८ मधील माहे एप्रिल/मे अखेरचा खर्च")
                {
                    YearExp_Index = i;

                }

                else if (dr[i].ToString() == "विद्युतीकरणावरील प्रमा")
                {
                    VidyutikarnPrama_Index = i;


                }
                else if (dr[i].ToString() == "विद्युतीकरणावरील वितरित")
                {
                    Vidyutikarnvitarit_Index = i;


                }
                else if (dr[i].ToString() == "इतर खर्च")
                {
                    OtherExp_Index = i;

                }
                else if (dr[i].ToString() == "प्रथम तिमाही तरतूद")
                {
                    Takunone_index = i;

                }
                else if (dr[i].ToString() == "द्वितीय तिमाही तरतूद")
                {
                    Takuntwo_index = i;

                }
                else if (dr[i].ToString() == "तृतीय तिमाही तरतूद")
                {
                    Takunthree_index = i;

                }
                else if (dr[i].ToString() == "चतुर्थ तिमाही तरतूद")
                {
                    Takunfour_index = i;
                }
                else if (dr[i].ToString() == "Apr")
                {
                    Apr_index = i;
                }
                else if (dr[i].ToString() == "May")
                {
                    May_index = i;
                }
                else if (dr[i].ToString() == "Jun")
                {
                    Jun_index = i;

                }
                else if (dr[i].ToString() == "Jul")
                {
                    Jul_index = i;
                }
                else if (dr[i].ToString() == "Aug")
                {
                    Aug_index = i;
                }
                else if (dr[i].ToString() == "Sep")
                {
                    sep_index = i;
                }
                else if (dr[i].ToString() == "Oct")
                {
                    Oct_index = i;
                }
                else if (dr[i].ToString() == "Nov")
                {
                    Nov_index = i;
                }
                else if (dr[i].ToString() == "Dec")
                {
                    Dec_index = i;
                }
                else if (dr[i].ToString() == "Jan")
                {
                    Jan_index = i;
                }
                else if (dr[i].ToString() == "Feb")
                {
                    Feb_index = i;
                }
                else if (dr[i].ToString() == "Mar")
                {
                    Mar_index = i;

                }
            }
        }
    }

    public class NonResiBuildGrandTotal
    {
        public decimal MarchAkher { get; set; }
        public decimal ArthsankalpTartud { get; set; }
        public decimal VitritTartud { get; set; }
        public decimal ExpUp { get; set; }
        public decimal Magni { get; set; }
        public decimal EkunKamavarilKharch { get; set; }
        public decimal YearExp { get; set; }
        public decimal VidyutikarnPrama { get; set; }
        public decimal Vidyutikarnvitarit { get; set; }
        public decimal OtherExp { get; set; }

        public decimal Takunone { get; set; }
        public decimal Takuntwo { get; set; }
        public decimal Takunthree { get; set; }
        public decimal Takunfour { get; set; }
        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }


        public int MarchAkher_Index { get; set; }
        public int ArthsankalpTartud_Index { get; set; }
        public int VitritTartud_Index { get; set; }
        public int ExpUp_Index { get; set; }
        public int Magni_Index { get; set; }
        public int EkunKamavarilKharch_Index { get; set; }
        public int YearExp_Index { get; set; }
        public int VidyutikarnPrama_Index { get; set; }
        public int Vidyutikarnvitarit_Index { get; set; }
        public int OtherExp_Index { get; set; }

        public int Takunone_index { get; set; }
        public int Takuntwo_index { get; set; }
        public int Takunthree_index { get; set; }
        public int Takunfour_index { get; set; }

        public int Total_index { get; set; }
        public int Apr_index { get; set; }
        public int May_index { get; set; }
        public int Jun_index { get; set; }
        public int Jul_index { get; set; }
        public int Aug_index { get; set; }
        public int sep_index { get; set; }
        public int Oct_index { get; set; }
        public int Nov_index { get; set; }
        public int Dec_index { get; set; }
        public int Jan_index { get; set; }
        public int Feb_index { get; set; }
        public int Mar_index { get; set; }


        public void index(string[] dr)
        {

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr == null)
                {

                }
                else if (dr[i].ToString() == "मार्च अखेर खर्च")
                {
                    MarchAkher_Index = i;

                }
                else if (dr[i].ToString() == "वर्क आयडी" || dr[i].ToString() == "Work Id")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "अर्थसंकल्पीय तरतूद")
                {
                    ArthsankalpTartud_Index = i;

                }
                else if (dr[i].ToString() == "वितरित तरतूद")
                {
                    VitritTartud_Index = i;

                }
                else if (dr[i].ToString() == "Expenditure Up")
                {
                    ExpUp_Index = i;

                }
                else if (dr[i].ToString() == "मागणी")
                {
                    Magni_Index = i;
                }
                else if (dr[i].ToString() == "एकुण कामावरील खर्च")
                {
                    EkunKamavarilKharch_Index = i;

                }
                else if (dr[i].ToString() == "वर्षभरातील खर्च" || dr[i].ToString() == "सन २०१६-१७ मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च")
                {
                    YearExp_Index = i;

                }

                else if (dr[i].ToString() == "विद्युतीकरणावरील प्रमा")
                {
                    VidyutikarnPrama_Index = i;


                }
                else if (dr[i].ToString() == "विद्युतीकरणावरील वितरित")
                {
                    Vidyutikarnvitarit_Index = i;


                }
                else if (dr[i].ToString() == "इतर खर्च")
                {
                    OtherExp_Index = i;

                }
                else if (dr[i].ToString() == "प्रथम तिमाही तरतूद")
                {
                    Takunone_index = i;

                }
                else if (dr[i].ToString() == "द्वितीय तिमाही तरतूद")
                {
                    Takuntwo_index = i;

                }
                else if (dr[i].ToString() == "तृतीय तिमाही तरतूद")
                {
                    Takunthree_index = i;

                }
                else if (dr[i].ToString() == "चतुर्थ तिमाही तरतूद")
                {
                    Takunfour_index = i;

                }
                else if (dr[i].ToString() == "Apr")
                {
                    Apr_index = i;
                }
                else if (dr[i].ToString() == "May")
                {
                    May_index = i;
                }
                else if (dr[i].ToString() == "Jun")
                {
                    Jun_index = i;

                }
                else if (dr[i].ToString() == "Jul")
                {
                    Jul_index = i;
                }
                else if (dr[i].ToString() == "Aug")
                {
                    Aug_index = i;
                }
                else if (dr[i].ToString() == "Sep")
                {
                    sep_index = i;
                }
                else if (dr[i].ToString() == "Oct")
                {
                    Oct_index = i;
                }
                else if (dr[i].ToString() == "Nov")
                {
                    Nov_index = i;
                }
                else if (dr[i].ToString() == "Dec")
                {
                    Dec_index = i;
                }
                else if (dr[i].ToString() == "Jan")
                {
                    Jan_index = i;
                }
                else if (dr[i].ToString() == "Feb")
                {
                    Feb_index = i;
                }
                else if (dr[i].ToString() == "Mar")
                {
                    Mar_index = i;
                }
            }
        }
    }

    public class GatATotal
    {
        public decimal JobRakkam { get; set; }
        public decimal DambPariman { get; set; }
        public decimal DamRakkam { get; set; }
        public decimal ShillakDayitvaRu { get; set; }
        public decimal ShillakDayitvaAsRu { get; set; }
        public decimal MarAkherKharch { get; set; }
        public decimal ArthTartud { get; set; }
        public decimal VitritTartud { get; set; }
        public decimal ExpenUp { get; set; }
        public decimal VidyutKamchi { get; set; }
        public decimal Vidyutkharch { get; set; }
        public decimal DambKharch { get; set; }
        public decimal Magni { get; set; }
        public decimal AkunKamaKharch { get; set; }
        public decimal VarshBharKharch { get; set; }
        public decimal NividaRakkam { get; set; }

        public decimal Takunone { get; set; }
        public decimal Takuntwo { get; set; }
        public decimal Takunthree { get; set; }
        public decimal Takunfour { get; set; }
        public decimal ItarKharch { get; set; }
        public decimal KharchSan { get; set; }
      
        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }

        public decimal VaparDambPariman { get; set; }

        public int VaparDambPariman_index { get; set; }
        public int JobRakkam_index { get; set; }
        public int DambPariman_index { get; set; }
        public int DamRakkam_index { get; set; }
        public int ShillakDayitvaRu_index { get; set; }
        public int ShillakDayitvaAsRu_index { get; set; }
        public int MarAkherKharch_index { get; set; }
        public int ArthTartud_index { get; set; }
        public int VitritTartud_index { get; set; }
        public int ExpenUp_index { get; set; }
        public int VidyutKamchi_index { get; set; }
        public int Vidyutkharch_index { get; set; }
        public int DambKharch_index { get; set; }
        public int Magni_index { get; set; }
        public int AkunKamaKharch_index { get; set; }
        public int VarshBharKharch_index { get; set; }
        public int NividaRakkam_index { get; set; }
        public int Takunone_index { get; set; }
        public int Takuntwo_index { get; set; }
        public int Takunthree_index { get; set; }
        public int Takunfour_index { get; set; }
        public int ItarKharch_index { get; set; }
        public int KharchSan_index { get; set; }

        public int Apr_index { get; set; }
        public int May_index { get; set; }
        public int Jun_index { get; set; }
        public int Jul_index { get; set; }
        public int Aug_index { get; set; }
        public int sep_index { get; set; }
        public int Oct_index { get; set; }
        public int Nov_index { get; set; }
        public int Dec_index { get; set; }
        public int Jan_index { get; set; }
        public int Feb_index { get; set; }
        public int Mar_index { get; set; }
        public int Total_index;
        public int MagileKharch_index { get; set; }
        public decimal  MagileKharch { get; set; }
        public void index(string[] dr)
        {

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr == null)
                {

                }
                else if (dr[i].ToString() == "वर्क आयडी" || dr[i].ToString() == "Work Id")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "निविदा रक्कम % कमी / जास्त")
                {
                    NividaRakkam_index = i;

                }
                else if (dr[i].ToString() == "जॉब रक्कम")
                {
                    JobRakkam_index = i;

                }
                else if (dr[i].ToString() == "डांबरीचे परिमाण")
                {
                    DambPariman_index = i;

                }
                else if (dr[i].ToString() == "वापर डांबरीचे परिमाण")
                {
                    VaparDambPariman_index = i;

                }
                else if (dr[i].ToString() == "डांबरीची रक्कम")
                {
                    DamRakkam_index = i;

                }
                else if (dr[i].ToString() == "शिल्लक दायित्व रु")
                {
                    ShillakDayitvaRu_index = i;

                }
                else if (dr[i].ToString() == "दायित्व असल्यास रक्कम रु")
                {
                    ShillakDayitvaAsRu_index = i;
                }
                else if (dr[i].ToString() == "मार्च अखेर खर्च")
                {
                    MarAkherKharch_index = i;

                }
                else if (dr[i].ToString() == "अर्थसंकल्पीय तरतूद")
                {
                    ArthTartud_index = i;

                }

                else if (dr[i].ToString() == "वितरित तरतूद")
                {
                    VitritTartud_index = i;


                }
                else if (dr[i].ToString() == "Expenditure Up" || dr[i].ToString() == "चालु खर्च")
                {
                    ExpenUp_index = i;


                }
                else if (dr[i].ToString() == "मागील खर्च")
                {

                    MagileKharch_index = i;

                }
                else if (dr[i].ToString() == "विद्युतीकरण कामाची किंमत")
                {
                    VidyutKamchi_index = i;

                }
                else if (dr[i].ToString() == "विद्युतीकरणाचा खर्च")
                {
                    Vidyutkharch_index = i;

                }
                else if (dr[i].ToString() == "डांबरीचा खर्च")
                {
                    DambKharch_index = i;

                }
                else if (dr[i].ToString() == "मागणी")
                {
                    Magni_index = i;

                }
                else if (dr[i].ToString() == "एकुण कामावरील खर्च")
                {
                    AkunKamaKharch_index = i;

                }
                else if (dr[i].ToString() == "वर्षभरातील खर्च" || dr[i].ToString() == "सन २०१६-१७ मधील माहे एप्रिल/मे अखेरचा खर्च")
                {
                    VarshBharKharch_index = i;

                }

                else if (dr[i].ToString() == "प्रथम तिमाही तरतूद")
                {
                    Takunone_index = i;

                }
                else if (dr[i].ToString() == "द्वितीय तिमाही तरतूद")
                {
                    Takuntwo_index = i;

                }
                else if (dr[i].ToString() == "तृतीय तिमाही तरतूद")
                {
                    Takunthree_index = i;

                }
                else if (dr[i].ToString() == "चतुर्थ तिमाही तरतूद")
                {
                    Takunfour_index = i;

                }
                else if (dr[i].ToString() == "इतर खर्च")
                {
                    ItarKharch_index = i;

                }
                else if (dr[i].ToString() == "खर्च सन 2016 - 17  06/2016 अखेर")
                {
                    KharchSan_index = i;

                }

                else if (dr[i].ToString() == "Apr")
                {
                    Apr_index = i;
                }
                else if (dr[i].ToString() == "May")
                {
                    May_index = i;
                }
                else if (dr[i].ToString() == "Jun")
                {
                    Jun_index = i;

                }
                else if (dr[i].ToString() == "Jul")
                {
                    Jul_index = i;
                }
                else if (dr[i].ToString() == "Aug")
                {
                    Aug_index = i;
                }
                else if (dr[i].ToString() == "Sep")
                {
                    sep_index = i;
                }
                else if (dr[i].ToString() == "Oct")
                {
                    Oct_index = i;
                }
                else if (dr[i].ToString() == "Nov")
                {
                    Nov_index = i;
                }
                else if (dr[i].ToString() == "Dec")
                {
                    Dec_index = i;
                }
                else if (dr[i].ToString() == "Jan")
                {
                    Jan_index = i;
                }
                else if (dr[i].ToString() == "Feb")
                {
                    Feb_index = i;
                }
                else if (dr[i].ToString() == "Mar")
                {
                    Mar_index = i;

                }
            }
        }
    }

    public class CRFGrandTotal
    {
        public decimal AAmount { get; set; }
        public decimal TSAmount { get; set; }
        public decimal SantionAmount { get; set; }
        public decimal ManjurAmt { get; set; }  
        public decimal MarchEnding { get; set; }
        public decimal UrvaritAmt { get; set; }  
        public decimal Takunone { get; set; }
        public decimal Takuntwo { get; set; }
        public decimal Takunthree { get; set; }
        public decimal Takunfour { get; set; }
        public decimal Tartud { get; set; }
        public decimal Akunanudan { get; set; }
        public decimal Chalukharch { get; set; }
        public decimal Maghilkharch { get; set; }
        public decimal Magni { get; set; }
        public decimal VarshbharatilKharch { get; set; }
        public decimal AikunKharch { get; set; }

        public decimal WideScope { get; set; }
        public decimal WideCommulative { get; set; }
        public decimal WideTarget { get; set; }
        public decimal WideAchivement { get; set; }

        public decimal BTScope { get; set; }
        public decimal BTCommulative { get; set; }
        public decimal BTTarget { get; set; }
        public decimal BTAchivement { get; set; }

        public decimal CDScope { get; set; }
        public decimal CDCommulative { get; set; }
        public decimal CDTarget { get; set; }
        public decimal CDAchivement { get; set; }

        public decimal MinorScope { get; set; }
        public decimal MinorCommulative { get; set; }
        public decimal MinorTarget { get; set; }
        public decimal MinorAchivement { get; set; }

        public decimal MjorScope { get; set; }
        public decimal MajorCommulative { get; set; }
        public decimal MajorTarget { get; set; }
        public decimal MajorAchivement { get; set; }

        public decimal OtherExpen { get; set; }
        public decimal ElectriCost { get; set; }
        public decimal ElectriExpen { get; set; }
        public decimal TenderAmount { get; set; }

        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }
        public decimal C { get; set; }
        public decimal P { get; set; }
        public decimal NS { get; set; }
        public decimal ES { get; set; }
        public decimal TS { get; set; }

        public int TenderAmount_index { get; set; }
        public int AAmount_index { get; set; }
        public int TSAmount_index { get; set; }
        public int SantionAmount_index { get; set; }
        public int ManjurAmt_index { get; set; }  
        public int MarchEnding_index { get; set; }
        public int UrvaritAmt_index { get; set; }
        public int Takunone_index { get; set; }
        public int Takuntwo_index { get; set; }
        public int Takunthree_index { get; set; }
        public int Takunfour_index { get; set; }
        public int Tartud_index { get; set; }
        public int Akunanudan_index { get; set; }
        public int Chalukharch_index { get; set; }
        public int Maghilkharch_index { get; set; }
        public int Magni_index { get; set; }
        public int VarshbharatilKharch_index { get; set; }
        public int AikunKharch_index { get; set; }

        public int WideScope_index { get; set; }
        public int WideCommulative_index { get; set; }
        public int WideTarget_index { get; set; }
        public int WideAchivement_index { get; set; }

        public int BTScope_index { get; set; }
        public int BTCommulative_index { get; set; }
        public int BTTarget_index { get; set; }
        public int BTAchivement_index { get; set; }

        public int CDScope_index { get; set; }
        public int CDCommulative_index { get; set; }
        public int CDTarget_index { get; set; }
        public int CDAchivement_index { get; set; }

        public int MinorScope_index { get; set; }
        public int MinorCommulative_index { get; set; }
        public int MinorTarget_index { get; set; }
        public int MinorAchivement_index { get; set; }

        public int MjorScope_index { get; set; }
        public int MajorCommulative_index { get; set; }
        public int MajorTarget_index { get; set; }
        public int MajorAchivement_index { get; set; }

        public int OtherExpen_index { get; set; }
        public int ElectriCost_index { get; set; }
        public int ElectriExpen_index { get; set; }

        public int Apr_index { get; set; }
        public int May_index { get; set; }
        public int Jun_index { get; set; }
        public int Jul_index { get; set; }
        public int Aug_index { get; set; }
        public int sep_index { get; set; }
        public int Oct_index { get; set; }
        public int Nov_index { get; set; }
        public int Dec_index { get; set; }
        public int Jan_index { get; set; }
        public int Feb_index { get; set; }
        public int Mar_index { get; set; }
        public int Total_index { get; set; }
        public int C_index { get; set; }
        public int P_index { get; set; }
        public int NS_index { get; set; }
        public int ES_index { get; set; }
        public int TS_index { get; set; }

        public void index(string[] dr)
        {

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr == null)
                {

                }
                else if (dr[i].ToString() == "C")
                {
                    C_index = i;

                }
                else if (dr[i].ToString() == "P")
                {
                    P_index = i;

                }
                else if (dr[i].ToString() == "NS")
                {
                    NS_index = i;

                }
                else if (dr[i].ToString() == "ES")
                {
                    ES_index = i;
                }
                else if (dr[i].ToString() == "TS")
                {
                    TS_index = i;
                }
                else if (dr[i].ToString() == "वर्क आयडी" || dr[i].ToString() == "Work Id")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "Tender Amount")
                {
                    TenderAmount_index = i;

                }
                else if (dr[i].ToString() == "A A Amount")
                {
                    AAmount_index = i;

                }
                else if (dr[i].ToString() == "T S Amount")
                {
                    TSAmount_index = i;

                }
                else if (dr[i].ToString() == "SanctionAmount")
                {
                    SantionAmount_index = i;

                }
                else if (dr[i].ToString() == "Estimated Cost Approved")
                {
                    ManjurAmt_index = i;

                }
                else if (dr[i].ToString() == "MarchEndingExpn")
                {
                    MarchEnding_index = i;

                }
                else if (dr[i].ToString() == "Remaining Cost")
                {
                    UrvaritAmt_index = i;

                }
                else if (dr[i].ToString() == "First Provision")
                {
                    Takunone_index = i;
                }
                else if (dr[i].ToString() == "Second Provision")
                {
                    Takuntwo_index = i;

                }
                else if (dr[i].ToString() == "Third Provision")
                {
                    Takunthree_index = i;

                }

                else if (dr[i].ToString() == "Fourth Provision")
                {
                    Takunfour_index = i;


                }
                else if (dr[i].ToString() == "Grand Provision")
                {
                    Tartud_index = i;


                }
                else if (dr[i].ToString() == "Total Grand")
                {
                    Akunanudan_index = i;

                }
                else if (dr[i].ToString() == "Current Cost")
                {
                    Chalukharch_index = i;

                }
                else if (dr[i].ToString() == "Previous Cost")
                {
                    Maghilkharch_index = i;

                }
                else if (dr[i].ToString() == "Demand")
                {
                    Magni_index = i;

                }
                else if (dr[i].ToString() == "Annual Expense")
                {
                    VarshbharatilKharch_index = i;

                }
                else if (dr[i].ToString() == "Total Expense")
                {
                    AikunKharch_index = i;
                }


                else if (dr[i].ToString() == "W.B.M Wide Phy Scope")
                {
                    WideScope_index = i;
                }
                else if (dr[i].ToString() == "W.B.M Wide Commulative")
                {
                    WideCommulative_index = i;
                }
                else if (dr[i].ToString() == "W.B.M Wide Target")
                {
                    WideTarget_index = i;
                }
                else if (dr[i].ToString() == "W.B.M Wide Achievement")
                {
                    WideAchivement_index = i;
                }


                else if (dr[i].ToString() == "B.T Phy Scope")
                {
                    BTScope_index = i;
                }
                else if (dr[i].ToString() == "B.T Commulative")
                {
                    BTCommulative_index = i;
                }
                else if (dr[i].ToString() == "B.T Target")
                {
                    BTTarget_index = i;
                }
                else if (dr[i].ToString() == "B.T Achievement")
                {
                    BTAchivement_index = i;
                }


                else if (dr[i].ToString() == "C.D Phy Scope")
                {
                    CDScope_index = i;
                }
                else if (dr[i].ToString() == "C.D Commulative")
                {
                    CDCommulative_index = i;
                }
                else if (dr[i].ToString() == "C.D Target")
                {
                    CDTarget_index = i;
                }
                else if (dr[i].ToString() == "C.D Achievement")
                {
                    CDAchivement_index = i;
                }


                else if (dr[i].ToString() == "Minor Bridges Phy Scope(Nos)")
                {
                    MinorScope_index = i;
                }
                else if (dr[i].ToString() == "Minor Bridges Commulative(Nos)")
                {
                    MinorCommulative_index = i;
                }
                else if (dr[i].ToString() == "Minor Bridges Target(Nos)")
                {
                    MinorTarget_index = i;
                }
                else if (dr[i].ToString() == "Minor Bridges Achievement(Nos)")
                {
                    MinorAchivement_index = i;
                }


                else if (dr[i].ToString() == "Major Bridges Phy Scope(Nos)")
                {
                    MjorScope_index = i;
                }
                else if (dr[i].ToString() == "Major Bridges Commulative(Nos)")
                {
                    MajorCommulative_index = i;
                }
                else if (dr[i].ToString() == "Major Bridges Target(Nos)")
                {
                    MajorTarget_index = i;
                }
                else if (dr[i].ToString() == "Major Bridges Achievement(Nos)")
                {
                    MajorAchivement_index = i;
                }


                else if (dr[i].ToString() == "Other Expense")
                {
                    OtherExpen_index = i;
                }
                else if (dr[i].ToString() == "Electricity Cost")
                {
                    ElectriCost_index = i;
                }
                else if (dr[i].ToString() == "Electricity Expense")
                {
                    ElectriExpen_index = i;
                }



                else if (dr[i].ToString() == "Apr")
                {
                    Apr_index = i;
                }
                else if (dr[i].ToString() == "May")
                {
                    May_index = i;
                }
                else if (dr[i].ToString() == "Jun")
                {
                    Jun_index = i;

                }
                else if (dr[i].ToString() == "Jul")
                {
                    Jul_index = i;
                }
                else if (dr[i].ToString() == "Aug")
                {
                    Aug_index = i;
                }
                else if (dr[i].ToString() == "Sep")
                {
                    sep_index = i;
                }
                else if (dr[i].ToString() == "Oct")
                {
                    Oct_index = i;
                }
                else if (dr[i].ToString() == "Nov")
                {
                    Nov_index = i;
                }
                else if (dr[i].ToString() == "Dec")
                {
                    Dec_index = i;
                }
                else if (dr[i].ToString() == "Jan")
                {
                    Jan_index = i;
                }
                else if (dr[i].ToString() == "Feb")
                {
                    Feb_index = i;
                }
                else if (dr[i].ToString() == "Mar")
                {
                     Mar_index = i;

                }
                else if (dr[i].ToString() == "WorkId")
                {
                    Total_index = i;

                }
            }
        }
    }

    public class DpdcGrandTotal
    {
        public decimal AkunAndajit { get; set; }
        public decimal MarchAkher { get; set; }
        public decimal SanMadil { get; set; }
        public decimal UrvritKimmat { get; set; }
        public decimal KaritaPrasta { get; set; }
        public decimal KamNihay { get; set; }
        public decimal VitritTartud { get; set; }
        public decimal KharchSan { get; set; }
        public decimal Magni { get; set; }
        public decimal Purn { get; set; }
        public decimal Pragatit { get; set; }
        public decimal NividaStar { get; set; }

        public decimal DusriTartud { get; set; }
        public decimal TisriTartud { get; set; }
        public decimal chothiTartud { get; set; }
        
        public decimal ExpUp { get; set; }
        public decimal AkunKharch { get; set; }

        public decimal VitritTar { get; set; }
        public decimal VarshKharch { get; set; }
        public decimal VidyuatPram { get; set; }
        public decimal VidyutVitrit { get; set; }
        public decimal Itarkharch { get; set; }

        public decimal PrashaskiyAmt { get; set; }
        public decimal TantrikAmt { get; set; }

        public decimal C { get; set; }
        public decimal P { get; set; }
        public decimal NS { get; set; }
        public decimal ES { get; set; }
        public decimal TS { get; set; }
      

        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }
        public decimal NividaRakkam { get; set; }
        public decimal Estimated { get; set; }
        public decimal NotStarted { get; set; }
        

        public int AkunAndajit_index { get; set; }
        public int MarchAkher_index { get; set; }
        public int SanMadil_index { get; set; }
        public int UrvritKimmat_index { get; set; }
        public int KaritaPrasta_index { get; set; }
        public int KamNihay_index { get; set; }
        public int VitritTartud_index { get; set; }
        public int KharchSan_index { get; set; }
        public int Magni_index { get; set; }
        public int Purn_index { get; set; }
        //New
        public int Pragatit_index { get; set; }
        public int NividaStar_index { get; set; }
        public int Estimated_index { get; set; }
        public int NotStarted_index { get; set; }
        public int DusriTartud_index { get; set; }
        public int TisriTartud_index { get; set; }
        public int chothiTartud_index { get; set; }
        
        public int ExpUp_index { get; set; }
        public int AkunKharch_index { get; set; }
        public int VarshKharch_index { get; set; }
        public int VitritTar_index { get; set; }
        public int VidyuatPram_index { get; set; }
        public int VidyutVitrit_index { get; set; }
        public int Itarkharch_index { get; set; }

        public int Apr_index { get; set; }
        public int May_index { get; set; }
        public int Jun_index { get; set; }
        public int Jul_index { get; set; }
        public int Aug_index { get; set; }
        public int sep_index { get; set; }
        public int Oct_index { get; set; }
        public int Nov_index { get; set; }
        public int Dec_index { get; set; }
        public int Jan_index { get; set; }
        public int Feb_index { get; set; }
        public int Mar_index { get; set; }
        public int Total_index { get; set; }
        public int NividaRakkam_index { get; set; }

        //new 
        public int PrashaskiyAmt_index { get; set; }
        public int TantrikAmt_index { get; set; }

        public int C_index { get; set; }
        public int P_index { get; set; }
        public int NS_index { get; set; }
        public int ES_index { get; set; }
        public int TS_index { get; set; }

        public void index(string[] dr)
        {

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr == null)
                {

                }
                else if (dr[i].ToString() == "वर्क आयडी" || dr[i].ToString() == "Work Id")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "एकूण अंदाजित किंमत (अलिकडील सुधारित)")
                {
                    AkunAndajit_index = i;

                }
                else if (dr[i].ToString() == "मार्च 2016  अखेर पर्यंतचा एकूण खर्च" || dr[i].ToString() == "मार्च अखेर खर्च" || dr[i].ToString() == "मार्च अखेर खर्च 2017")
                {
                    MarchAkher_index = i;

                }
                else if (dr[i].ToString() == "सन 2016-17 मधील अपेक्षित खर्च" || dr[i].ToString() == "सन 2017-2018 मधील अपेक्षित खर्च")
                {
                    SanMadil_index = i;

                }
                else if (dr[i].ToString() == "उर्वरित किंमत (6-(8+9))" || dr[i].ToString() == "उर्वरित किंमत")
                {
                    UrvritKimmat_index = i;

                }
                else if (dr[i].ToString() == "2016-17 करीता प्रस्तावित तरतूद" || dr[i].ToString() == "2017-2018 करीता प्रस्तावित तरतूद")
                {
                    KaritaPrasta_index = i;
                }
                else if (dr[i].ToString() == "काम निहाय तरतूद सन 2016-17" || dr[i].ToString() == "काम निहाय तरतूद सन 2017-2018")
                {
                    KamNihay_index = i;

                }
                else if (dr[i].ToString() == "वितरीत तरतूद सन 2016-17" || dr[i].ToString() == "वितरीत तरतूद सन 2017-2018")
                {
                    VitritTartud_index = i;

                }

                else if (dr[i].ToString() == "खर्च सन 2016 - 17 06/16 अखेर"||dr[i].ToString() =="मागील खर्च")
                {
                    KharchSan_index = i;


                }
                else if (dr[i].ToString() == "मागणी 2016-17" || dr[i].ToString() == "मागणी 2017-2018" || dr[i].ToString() == "मागणी 2017-18")
                {
                    Magni_index = i;


                }
                else if (dr[i].ToString() == "पुर्ण" ||  dr[i].ToString() == "C" )
                {
                    Purn_index = i;

                }
                else if (dr[i].ToString() == "प्रगतीत" || dr[i].ToString() == "P" )
                {
                    Pragatit_index = i;

                }
                else if (dr[i].ToString() == "निविदा स्तर" || dr[i].ToString() == "TS")
                {
                    NividaStar_index = i;

                }
                else if (dr[i].ToString() == "ES")
                {
                    Estimated_index = i;

                }
                else if (dr[i].ToString() == "NS")
                {
                    NotStarted_index = i;

                }
                else if (dr[i].ToString() == "द्वितीय तिमाही तरतूद")
                {
                    DusriTartud_index = i;

                }
                else if (dr[i].ToString() == "तृतीय तिमाही तरतूद")
                {
                    TisriTartud_index = i;

                }
                else if (dr[i].ToString() == "चतुर्थ तिमाही तरतूद")
                {
                    chothiTartud_index = i;

                }
                else if (dr[i].ToString() == "वितरित तरतूद")
                {
                    VitritTar_index = i;

                }
                else if (dr[i].ToString() == "Expenditure Up" || dr[i].ToString() == "चालू खर्च")
                {
                    ExpUp_index = i;

                }
                else if (dr[i].ToString() == "एकुण कामावरील खर्च")
                {
                    AkunKharch_index = i;

                }
                else if (dr[i].ToString() == "वर्षभरातील खर्च" || dr[i].ToString() == "सन २०१६-१७ मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च")
                {
                    VarshKharch_index = i;

                }
                else if (dr[i].ToString() == "विद्युतीकरणावरील प्रमा")
                {
                    VidyuatPram_index = i;

                }
                else if (dr[i].ToString() == "विद्युतीकरणावरील वितरित")
                {
                    VidyutVitrit_index = i;
                }

                else if (dr[i].ToString() == "इतर खर्च")
                {
                    Itarkharch_index = i;

                }

                

                else if (dr[i].ToString() == "Apr")
                {
                    Apr_index = i;
                }
                else if (dr[i].ToString() == "May")
                {
                    May_index = i;
                }
                else if (dr[i].ToString() == "Jun")
                {
                    Jun_index = i;

                }
                else if (dr[i].ToString() == "Jul")
                {
                    Jul_index = i;
                }
                else if (dr[i].ToString() == "Aug")
                {
                    Aug_index = i;
                }
                else if (dr[i].ToString() == "Sep")
                {
                    sep_index = i;
                }
                else if (dr[i].ToString() == "Oct")
                {
                    Oct_index = i;
                }
                else if (dr[i].ToString() == "Nov")
                {
                    Nov_index = i;
                }
                else if (dr[i].ToString() == "Dec")
                {
                    Dec_index = i;
                }
                else if (dr[i].ToString() == "Jan")
                {
                    Jan_index = i;
                }
                else if (dr[i].ToString() == "Feb")
                {
                    Feb_index = i;
                }
                else if (dr[i].ToString() == "Mar")
                {
                    Mar_index = i;

                }

                else if (dr[i].ToString() == "वर्क आयडी")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "निविदा रक्कम % कमी / जास्त")
                {
                    NividaRakkam_index = i;

                }
                //New index
                else if (dr[i].ToString() == "प्रशासकीय मान्यता रक्कम")
                {
                    PrashaskiyAmt_index = i;

                }
                else if (dr[i].ToString() == "तांत्रिक मान्यता रक्कम")
                {
                    TantrikAmt_index = i;

                } else if (dr[i].ToString() == "C")
                {
                    C_index = i;

                }
                else if (dr[i].ToString() == "P")
                {
                    P_index = i;

                }
                else if (dr[i].ToString() == "NS")
                {
                    NS_index = i;

                }
                else if (dr[i].ToString() == "ES")
                {
                    ES_index = i;
                }
                else if (dr[i].ToString() == "TS")
                {
                    TS_index = i;
                }
            }
        }
    }
     
    public class MlaGrandTotal
    {
        public decimal MarchAkher { get; set; }
        public decimal SanMadil { get; set; }
        public decimal UrvritKimmat { get; set; }
        public decimal KamNihay { get; set; }
        public decimal VitritTartud { get; set; }
        public decimal KharchSan { get; set; }
        public decimal Magni { get; set; }
        public decimal Purn { get; set; }
        public decimal Pragatit { get; set; }
        public decimal NividaStar { get; set; }
        public decimal AkunKame { get; set; }
        public decimal PrashaskiyAmt { get; set; }
        public decimal TantrikAmt { get; set; }

        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }

        //new column
        public decimal TakunOne { get; set; }
        public decimal TakunTow { get; set; }
        public decimal TakunTree { get; set; }
        public decimal TakunFour { get; set; }
        public decimal ChaluKharch { get; set; }
        public decimal YearExp { get; set; }
        public decimal AkunKamavarilKharch { get; set; }
        public decimal VidyutiPrma { get; set; }
        public decimal VidyutiVitarit { get; set; }        
        public decimal ItarKharch { get; set; }
        public decimal AkunAnudan { get; set; }
        public decimal NividaKimmat { get; set; }
        public decimal NividaRakkam { get; set; }
        public decimal NotStarted { get; set; }
        public decimal Estimated { get; set; }



        public int MarchAkher_index { get; set; }
        public int SanMadil_index { get; set; }
        public int UrvritKimmat_index { get; set; }
        public int KamNihay_index { get; set; }
        public int VitritTartud_index { get; set; }
        public int KharchSan_index { get; set; }
        public int Magni_index { get; set; }
        public int Purn_index { get; set; }
        public int Pragatit_index { get; set; }
        public int NividaStar_index { get; set; }
        public int NividaKimmat_index { get; set; }

        public int AkunKame_index { get; set; }
        public int Apr_index { get; set; }
        public int May_index { get; set; }
        public int Jun_index { get; set; }
        public int Jul_index { get; set; }
        public int Aug_index { get; set; }
        public int sep_index { get; set; }
        public int Oct_index { get; set; }
        public int Nov_index { get; set; }
        public int Dec_index { get; set; }
        public int Jan_index { get; set; }
        public int Feb_index { get; set; }
        public int Mar_index { get; set; }
        public int Total_index { get; set; }

        //new column index
        public int TakunOne_index { get; set; }
        public int TakunTow_index { get; set; }
        public int TakunTree_index { get; set; }
        public int TakunFour_index { get; set; }
        public int ChaluKharch_index { get; set; }
        public int YearExp_index { get; set; }
        public int AkunKamavarilKharch_index { get; set; }
        public int VidyutiPrma_index { get; set; }
        public int VidyutiVitarit_index { get; set; }      
        public int ItarKharch_index { get; set; }
        public int AkunAnudan_index { get; set; }
        public int NividaRakkam_Index { get; set; }
        public int PrashaskiyAmt_index { get; set; }
        public int TantrikAmt_index { get; set; }
        public int Estimated_index { get; set; }
        public int NotStarted_index { get; set; }

        public void index(string[] dr)
        {

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr == null)
                {

                }
                else if (dr[i].ToString() == "वर्क आयडी" || dr[i].ToString() == "Work Id")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "मार्च 2016  अखेर पर्यंतचा एकूण खर्च" || dr[i].ToString() == "मार्च अखेर खर्च" || dr[i].ToString() == "मार्च अखेर खर्च 2017")
                {
                    MarchAkher_index = i;

                }
                else if (dr[i].ToString() == "सन2016-17 मधील अपेक्षित खर्च" || dr[i].ToString() == "सन2017-2018 मधील अपेक्षित खर्च" || dr[i].ToString() == "सन 2017-2018 मधील अपेक्षित खर्च")
                {
                    SanMadil_index = i;

                }
                else if (dr[i].ToString() == "उर्वरित किंमत (6-(8+9))")
                {
                    UrvritKimmat_index = i;

                }
                else if (dr[i].ToString() == "काम निहाय तरतूद सन 2016-17" || dr[i].ToString() == "काम निहाय तरतूद सन 2017-2018")
                {
                    KamNihay_index = i;
                }
                else if (dr[i].ToString() == "वितरीत तरतूद सन 2016-17" || dr[i].ToString() == "वितरीत तरतूद सन 2017-2018")
                {
                    VitritTartud_index = i;

                }
                else if (dr[i].ToString() == "खर्च सन 2016 - 17  06/2016 अखेर" || dr[i].ToString() == "खर्च सन 2017-2018  06/2017 अखेर" || dr[i].ToString() == "सन 2016 - 17  06/2016 अखेर खर्च")
                {

                    KharchSan_index = i;
                }

                else if (dr[i].ToString() == "मागणी 2016-17" || dr[i].ToString() == "मागणी 2017-2018" || dr[i].ToString() == "मागणी 2017-18")
                {

                    Magni_index = i;

                }
                else if (dr[i].ToString() == "पुर्ण" || dr[i].ToString() == "C")
                {
                    Purn_index = i;

                }
                else if (dr[i].ToString() == "प्रगतीत" || dr[i].ToString() == "P")
                {
                    Pragatit_index = i;

                }
                else if (dr[i].ToString() == "निविदा स्तर" || dr[i].ToString() == "TS")
                {
                    NividaStar_index = i;

                }
                else if ( dr[i].ToString() == "NS")
                {
                    NotStarted_index = i;

                }
                else if ( dr[i].ToString() == "ES")
                {
                    Estimated_index = i;

                }
                else if (dr[i].ToString() == "एकूण कामे")
                {
                    AkunKame_index = i;

                }

                    //new column
                //New Column
                else if (dr[i].ToString() == "निविदा रक्कम % कमी / जास्त")
                {
                    NividaRakkam_Index = i;
                }
                else if (dr[i].ToString() == "प्रथम तिमाही तरतूद")
                {
                    TakunOne_index = i;
                }
                else if (dr[i].ToString() == "द्वितीय तिमाही तरतूद")
                {
                    TakunTow_index = i;
                }
                else if (dr[i].ToString() == "तृतीय तिमाही तरतूद")
                {
                    TakunTree_index = i;
                }
                else if (dr[i].ToString() == "चतुर्थ तिमाही तरतूद")
                {
                    TakunFour_index = i;
                }
                else if (dr[i].ToString() == "एकुण उपलब्ध अनुदान")
                {
                    ChaluKharch_index = i;
                    AkunAnudan_index = i;
                }
                else if (dr[i].ToString() == "एकुण कामावरील खर्च")
                {
                    AkunKamavarilKharch_index = i;
                }
                else if (dr[i].ToString() == "वर्षभरातील खर्च" || dr[i].ToString() == "सन २०१६-१७ मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन 2017-18 मधील माहे एप्रिल/मे अखेरचा खर्च")
                {
                    YearExp_index = i;
                }
                else if (dr[i].ToString() == "विद्युतप्रमा")
                {
                    VidyutiPrma_index = i;
                }
                else if (dr[i].ToString() == "विद्युत वितरीत")
                {
                    VidyutiVitarit_index = i;
                }
                else if (dr[i].ToString() == "इतर खर्च")
                {
                    ItarKharch_index = i;
                }
                    

                else if (dr[i].ToString() == "Apr")
                {
                    Apr_index = i;
                }
                else if (dr[i].ToString() == "May")
                {
                    May_index = i;
                }
                else if (dr[i].ToString() == "Jun")
                {
                    Jun_index = i;

                }
                else if (dr[i].ToString() == "Jul")
                {
                    Jul_index = i;
                }
                else if (dr[i].ToString() == "Aug")
                {
                    Aug_index = i;
                }
                else if (dr[i].ToString() == "Sep")
                {
                    sep_index = i;
                }
                else if (dr[i].ToString() == "Oct")
                {
                    Oct_index = i;
                }
                else if (dr[i].ToString() == "Nov")
                {
                    Nov_index = i;
                }
                else if (dr[i].ToString() == "Dec")
                {
                    Dec_index = i;
                }
                else if (dr[i].ToString() == "Jan")
                {
                    Jan_index = i;
                }
                else if (dr[i].ToString() == "Feb")
                {
                    Feb_index = i;
                }
                else if (dr[i].ToString() == "Mar")
                {
                    Mar_index = i;

                }
                else if (dr[i].ToString()=="वर्क आयडी")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "निविदा किंमत")
                {
                    NividaKimmat_index = i;
                }
                //New index
                else if (dr[i].ToString() == "प्रशासकीय मान्यता रक्कम")
                {
                    PrashaskiyAmt_index = i;

                }
                else if (dr[i].ToString() == "तांत्रिक मान्यता रक्कम")
                {
                    TantrikAmt_index = i;

                }
            }
        }
    }

    public class MpGrandTotal
    {
        public decimal NividaKimmat { get; set; }
        public decimal Anudan { get; set; }
        public decimal UplbdaAnudan { get; set; }
        public decimal AkunAnudan { get; set; }
        public decimal AkherKharch { get; set; }
        public decimal AkunKharch { get; set; }
        public decimal Magni { get; set; }
        public decimal Purn { get; set; }
        public decimal Pragatit { get; set; }
        public decimal NividaStar { get; set; }
        public decimal AkunKame { get; set; }
        public decimal PrashaskiyAmt { get; set; }
        public decimal TantrikAmt { get; set; }

        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }

        //New Column
        public decimal TakunOne { get; set; }
        public decimal TakunTwo { get; set; }
        public decimal TakunTree { get; set; }
        public decimal TakunFour { get; set; }
        public decimal ArthsankalpTartud { get; set; }
        public decimal VitaritTartud { get; set; }
        public decimal YearExp { get; set; }
        public decimal VidyutiPrma { get; set; }
        public decimal VidyutVitarit { get; set; }
        public decimal ItarKharch { get; set; }
        public decimal UrvritKimmat { get; set; }
        public decimal ApekshitKharch { get; set; }
        public decimal NividaRakkam { get; set; }
        public decimal NotStarted { get; set; }
        public decimal Estimated { get; set; }

        public int NividaRakkam_Index { get; set; }
        public int NividaKimmat_index { get; set; }
        public int Anudan_index { get; set; }
        public int UplbdaAnudan_index { get; set; }
        public int AkunAnudan_index { get; set; }
        public int AkherKharch_index { get; set; }
        public int AkunKharch_index { get; set; }
        public int Magni_index { get; set; }
        public int Purn_index { get; set; }
        public int Pragatit_index { get; set; }
        public int NotStarted_index { get; set; }
        public int Estimated_index { get; set; }

        public int NividaStar_index { get; set; }
        public int AkunKame_index { get; set; }
        public int Apr_index { get; set; }
        public int May_index { get; set; }
        public int Jun_index { get; set; }
        public int Jul_index { get; set; }
        public int Aug_index { get; set; }
        public int sep_index { get; set; }
        public int Oct_index { get; set; }
        public int Nov_index { get; set; }
        public int Dec_index { get; set; }
        public int Jan_index { get; set; }
        public int Feb_index { get; set; }
        public int Mar_index { get; set; }

        public int Total_index { get; set; }

        //new Column
        public int TakunOne_index { get; set; }
        public int TakunTwo_index { get; set; }
        public int TakunTree_index { get; set; }
        public int TakunFour_index { get; set; }
        public int ArthsankalpTartud_index { get; set; }
        public int VitaritTartud_index { get; set; }
        public int YearExp_index { get; set; }
        public int VidyutiPrma_index { get; set; }
        public int VidyutVitarit_index { get; set; }
        public int ItarKharch_index { get; set; }
        public int UrvritKimmat_index { get; set; }
        public int ApekshitKharch_index { get; set; }
        public int PrashaskiyAmt_index { get; set; }
        public int TantrikAmt_index { get; set; }

        public void index(string[] dr)
        {

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr == null)
                {

                }
                else if (dr[i].ToString() == "वर्क आयडी" || dr[i].ToString() == "Work Id")
                {
                    Total_index = i;
                }
                else if (dr[i].ToString() == "निविदा किंमत")
                {
                    NividaKimmat_index = i;

                }
                else if (dr[i].ToString() == "वर्ष 2015-16 मधील उपलब्ध अनुदान लक्ष" || dr[i].ToString() == "मार्च अखेर खर्च" || dr[i].ToString() == "मार्च अखेर खर्च 2017")
                {
                    Anudan_index = i;

                }
                else if (dr[i].ToString() == "वर्ष 2016-17 मधील चालु महिन्या  अखेर उपलब्ध अनुदान" || dr[i].ToString() == "वर्ष 2017-2018 मधील चालु महिन्या  अखेर उपलब्ध अनुदान")
                {
                    UplbdaAnudan_index = i;

                }
                else if (dr[i].ToString() == "एकुण उपलब्ध अनुदान")
                {
                    AkunAnudan_index = i;
                }
                else if (dr[i].ToString() == "वर्ष 2016-17मधील चालू महीन्या (6/2016) अखेर खर्च लक्ष" || dr[i].ToString() == "वर्ष 2017-2018मधील चालू महीन्या (6/2017) अखेर खर्च लक्ष" || dr[i].ToString() == "मागील खर्च")
                {
                    AkherKharch_index = i;

                }
                else if (dr[i].ToString() == "सन2016-17 मधील अपेक्षित खर्च" || dr[i].ToString() == "सन2017-2018 मधील अपेक्षित खर्च" || dr[i].ToString() == "सन 2017-18 मधील अपेक्षित खर्च")
                {
                    ApekshitKharch_index = i;

                }
                else if (dr[i].ToString() == "उर्वरित किंमत (6-(8+9))")
                {
                    UrvritKimmat_index = i;

                }
                else if (dr[i].ToString() == "एकुण खर्च")
                {

                    AkunKharch_index = i;
                }

                else if (dr[i].ToString() == "मागणी  रु. लक्ष 2016-17" || dr[i].ToString() == "मागणी  रु. लक्ष 2017-2018" || dr[i].ToString() == "मागणी  2017-18")
                {

                    Magni_index = i;

                }
                else if (dr[i].ToString() == "पुर्ण" || dr[i].ToString() == "C")
                {
                    Purn_index = i;

                }
                else if (dr[i].ToString() == "प्रगतीत" || dr[i].ToString() == "P")
                {
                    Pragatit_index = i;

                }
                else if (dr[i].ToString() == "निविदा स्तर" || dr[i].ToString() == "TS")
                {
                    NividaStar_index = i;

                }
                else if (dr[i].ToString() == "एकूण कामे")
                {
                    AkunKame_index = i;

                }
                else if (dr[i].ToString() == "ES")
                {
                    Estimated_index = i;

                }
                else if (dr[i].ToString() == "NS")
                {
                    NotStarted_index = i;

                }

                    //New Column

                else if (dr[i].ToString() == "प्रथम तिमाही तरतूद")
                {
                    TakunOne_index = i;
                }
                else if (dr[i].ToString() == "द्वितीय तिमाही तरतूद")
                {
                    TakunTwo_index = i;
                }
                else if (dr[i].ToString() == "तृतीय तिमाही तरतूद")
                {
                    TakunTree_index = i;
                }
                else if (dr[i].ToString() == "चतुर्थ तिमाही तरतूद")
                {
                    TakunFour_index = i;
                }

                else if (dr[i].ToString() == "एकूण अर्थसंकल्पीय तरतूद")
                {
                    ArthsankalpTartud_index= i;

                }
                else if (dr[i].ToString() == "२०१६-१७ मधील वितरीत तरतूद" || dr[i].ToString() == "2017-18 मधील वितरीत तरतूद")
                {
                    VitaritTartud_index = i;

                }

                else if (dr[i].ToString() == "वर्षभरातील खर्च" || dr[i].ToString() == "सन २०१६-१७ मधील माहे एप्रिल/मे अखेरचा खर्च" || dr[i].ToString() == "सन 2017-2018 मधील माहे एप्रिल/मे अखेरचा खर्च")
                { 
                    YearExp_index = i;
                }
                else if (dr[i].ToString() == "विद्युतप्रमा")
                {
                    VidyutiPrma_index = i;
                }
                else if (dr[i].ToString() == "विद्युत वितरीत")
                {
                    VidyutVitarit_index = i;
                }
                else if (dr[i].ToString() == "इतर खर्च")
                {
                    ItarKharch_index = i;
                }
                else if (dr[i].ToString() == "निविदा रक्कम % कमी / जास्त")
                {
                    NividaRakkam_Index = i;
                }




                else if (dr[i].ToString() == "Apr")
                {
                    Apr_index = i;
                }
                else if (dr[i].ToString() == "May")
                {
                    May_index = i;
                }
                else if (dr[i].ToString() == "Jun")
                {
                    Jun_index = i;

                }
                else if (dr[i].ToString() == "Jul")
                {
                    Jul_index = i;
                }
                else if (dr[i].ToString() == "Aug")
                {
                    Aug_index = i;
                }
                else if (dr[i].ToString() == "Sep")
                {
                    sep_index = i;
                }
                else if (dr[i].ToString() == "Oct")
                {
                    Oct_index = i;
                }
                else if (dr[i].ToString() == "Nov")
                {
                    Nov_index = i;
                }
                else if (dr[i].ToString() == "Dec")
                {
                    Dec_index = i;
                }
                else if (dr[i].ToString() == "Jan")
                {
                    Jan_index = i;
                }
                else if (dr[i].ToString() == "Feb")
                {
                    Feb_index = i;
                }
                else if (dr[i].ToString() == "Mar")
                {
                    Mar_index = i;

                }
                else if (dr[i].ToString()=="वर्क आयडी")
                {
                    Total_index = i;
                }
                //New index
                else if (dr[i].ToString() == "प्रशासकीय मान्यता रक्कम")
                {
                    PrashaskiyAmt_index = i;

                }
                else if (dr[i].ToString() == "तांत्रिक मान्यता रक्कम")
                {
                    TantrikAmt_index = i;

                }
               
            }
        }
    }


}