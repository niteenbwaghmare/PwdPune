<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="UserGuide.aspx.cs" Inherits="PWdEEBudget.UserGuide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container">
  <div class="row"><h2> Applications User Guide <a class="pull-right" href="Doc/Pwd UserManual.pdf"><asp:Image ID="imgdown" runat="server" ImageUrl="~/logo/download-logo.png" Height="30" Width="30"     style="margin-right: 25px;"/></a></h2></div>
  <%--<p><strong>Note:</strong> The <strong>data-parent</strong> attribute makes sure that all collapsible elements under the specified parent will be closed when one of the collapsible item is shown.</p>--%>
  <div class="panel-group" id="accordion">
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">How to Create New User Login ?</a>
        </h4>
      </div>
      <div id="collapse1" class="panel-collapse collapse">
        <div class="panel-body">
            <h3>Follow the below steps to Cerate a new user.</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
            Open Setting tab. Click on "Create Account". "Add New User" window will be open.
            <h4 style="color:#ff6a00">Step 2</h4>
              Fill Appropriate information in form and wait until Username (युझर नाव) and Password (पासवर्ड) will be generate.
            <h4 style="color:#ff6a00">Step 3</h4>
            Click on Submit (संपादित करा) button. User will Listed.
        </div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading" >
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">How to fill data in DBS Software ?</a>
        </h4>
      </div>
      <div id="collapse2" class="panel-collapse collapse">
          
        <div class="panel-body">
            <h3>Following are the steps to Fill data or Work record in DBS Software.</h3>
             <h4 style="color:#ff6a00">Step 1</h4>
            Click on "Master Budget Form". "Head Forms" window will open.
            
             <h4 style="color:#ff6a00">Step 2</h4>
            Choose required Head Name to display perticular form. 
              <h4 style="color:#ff6a00">Step 3</h4>
        Fill Appropriate information in form and then <b>Submit (संपदित करा)</b> it. You will get Message which show "Record Save Successfully....." press Ok.
        </div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse3"> To Get MPR Report</a>
        </h4>
      </div>
      <div id="collapse3" class="panel-collapse collapse"> 
        <div class="panel-body">
             <h3>Go through following steps to Get MPR Report.</h3>
             <h4 style="color:#ff6a00">Step 1</h4>
            In menu bar, Click on MPR Report tab "MPR Report" window will open.
             <h4 style="color:#ff6a00">Step 2</h4>
             Click on perticular Head name to get respecitive Report.
             <h4 style="color:#ff6a00">Step 3</h4>
            You must select <b>( अर्थसंकल्पीय वर्ष )</b> then Select <b>( कामाचे वर्ष ) </b> and Ok.
            <h4 style="color:#ff6a00">Step 4</h4>
            Report will be displayed according to selected Field.
             <h4 style="color:#ff6a00">Step 5</h4>
            Click on Print button to print the Report.
             <h4 style="color:#ff6a00">Step 6</h4>
            If you want to get report in Excel format then, click on Excel button to download the Report.
            <h4 style="color:#4800ff">Note :</h4>
            In NABARD report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष,RIDF No. <br />
            In MLA  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,आमदाराचे नाव. <br />
            In MP  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,खासदाराचे  नाव. <br />
            In CRF  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष.  <br /> 
            In SH @ DOR report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In BUILDING  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष.लेखाशीर्ष.<br /> 
            In DPDC  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In DEPOSITE  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In ANNUITY  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष.<br />
            In GAT A,B,C,D,F report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष .<br />
            In 2216 report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In 2059  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In 2515  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष.
        </div>
      </div>
    </div>
  <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse4"> To Get HeadWise Report</a>
        </h4>
      </div>
      <div id="collapse4" class="panel-collapse collapse">
           
        <div class="panel-body">
            In Headwise report, you will get Headwise Report , Edit or Delete Perticular Record, Send SMS, Upload Photo, Check Box Facility . 
            <h3>1] Following are the steps to get HeadWise Report.</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
                 In menu bar, Click on "HeadWise Report" tab. "HeadWise Report" window will open.
            <h4 style="color:#ff6a00">Step 2</h4>
           Click on perticular Head name to get respecitive Report.
             <h4 style="color:#ff6a00">Step 3</h4>
            You must select <b>(अर्थसंकल्पीय वर्ष)</b> then Select <b>(कामाचे वर्ष)</b> and <b>(लेखाशीर्ष)</b> form Dropdown list.
             <h4 style="color:#ff6a00">Step 4</h4>
            According to your requirement you can select remaining tab and you will get Report.
             <h4 style="color:#4800ff">Note :</h4>
            In NABARD report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष,RIDF No. <br />
            In MLA  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,आमदाराचे नाव. <br />
            In MP  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,खासदाराचे  नाव.<br />
            In CRF  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष.  <br /> 
            In SH @ DOR report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In BUILDING  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष.लेखाशीर्ष.<br /> 
            In DPDC  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In DEPOSITE  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In ANNUITY  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In GAT A,B,C,D,F report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In 2216 report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In 2059  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष. <br />
            In 2515  report you must select कामाचे वर्ष ,अर्थसंकल्पीय वर्ष ,लेखाशीर्ष.
             </div>
            <div class="panel-body">
              <h3>2] Following are the steps to get Report depending on Check or Uncheck Boxes.</h3>
               <h4 style="color:#ff6a00">Step 1</h4>
               To remove or add any perticular column, use check boxes. 
            <h4 style="color:#ff6a00">Step 2</h4>
           If do you want to keep all the columns as it is ,then please don't uncheck any check box.<br />
                 Example:- <br />
                 i) If do you want to  <b>remove (विभाग)</b> column please uncheck <b>(विभाग)</b> check box. It will provide you report  <b>without (विभाग)</b> column.<br />
                           ii)If do you want to <b> add (विभाग)</b> column please click on <b>(विभाग)</b> check box. It will provide you report  <b>with (विभाग)</b> column.
                <h4 style="color:#ff6a00">Note :</h4>
                 In NABARD Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव, तालुका, and RIDF NO. <br />
                 In MLA Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव,आमदाराचे नाव,प्रकार and तालुका.<br />
                 In MP Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव,खासदाराचे नाव,प्रकार and तालुका.<br />
                 In CRF Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव and तालुका.<br />
                 In SH @ DORReport Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव and तालुका.<br />
                 In BUILDING Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव and तालुका.<br />
                 In DPDC Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव and तालुका. <br />
                 In DEPOSITE Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव and तालुका.<br />
                 In ANNUITY Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव and तालुका.<br />
                 In GATB,C,D,F Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव and तालुका.<br />
                 In GAT A Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव, अर्थसंकल्पीय बाब , जॉब नंबर and तालुका.<br />
                 In 2216 Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव and तालुका.<br />
                 In 2059 Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव and तालुका.<br />
                 In 2515 Report Please Do not uncheck वर्क आयडी, लेखाशीर्ष नाव and तालुका.
          </div>
          <div class="panel-body">
              <h3>3] Following are the steps to Edit Perticular Record.</h3>
               <h4 style="color:#ff6a00">Step 1</h4>
              If do you want to Edit Perticular record Simply Check the Edit Checkbox and wait until report will reload.
            <h4 style="color:#ff6a00">Step 2</h4>
           Afterward you will get new column in report, that column will include <b>Edit</b> and <b>Select</b> button.
                 <h4 style="color:#ff6a00">Step 3</h4>
              To edit the perticular record click on edit button. You will redirect to form.
               <h4 style="color:#ff6a00">Step 4</h4>
              Fill the details which do you need to update. Click on <b>Submit (संपादित करा)</b> button to update record. Again you will redirect to previous page.
          </div>
            <div class="panel-body">
              <h3>4] Following are the steps to Delete Perticular Record</h3>
               <h4 style="color:#ff6a00">Step 1</h4>
                If do you want to <b>Delete</b> Perticular record simply check the <b>Delete</b> Checkbox.
            <h4 style="color:#ff6a00">Step 2</h4>
          It will ask you for password. Enter password, new column will be displyed in report.
           <h4 style="color:#ff6a00">Step 3</h4>
                To delete record click on <b>Delete</b> button. Record will be delete Sucessfully..!
            </div>
             <div class="panel-body">
              <h3>5] Following are the steps to Send SMS with WorkID</h3>
               <h4 style="color:#ff6a00">Step 1</h4>
                If do you want to Send SMS Simply Check the Edit Checkbox and wait until report will reload.
            <h4 style="color:#ff6a00">Step 2</h4>
           Afterward you will get new column in report, that column will include <b>Edit</b> and <b>Select</b> button.
             <h4 style="color:#ff6a00">Step 3</h4>
            To Send SMS click on <b>Select</b> button. Send SMS page will be open. 
             <h4 style="color:#ff6a00">Step 4</h4>
                Fill appropriate information and press <b>Send </b> button. 
          </div>   
      </div>
  </div>
 <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse5">To Get Master Individual Report </a>
        </h4>
      </div>
      <div id="collapse5" class="panel-collapse collapse">
        <div class="panel-body">
           In Individual Report, You will get report according to type like प्रकार, लेखाशीर्ष, उपविभाग,शाखा अभियंता,उपअभियंता,तालुका,आमदार,खासदार,ठेकेदार,अर्थसंकल्पीय वर्ष,कामाची सद्यस्थिती etc.
            <h3>Following are the steps to get Master Individual Report.</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
           In menu bar, Click on <b>Master Individual Report.</b> tab. <b>Master Individual Report.</b> window will open.
             <h4 style="color:#ff6a00">Step 2</h4>
     Select Required type, which report do you want display and Click on <b>OK</b> button you will get All Head Report.
            
        </div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse6"> To Get HeadWise Abstract Report</a>
        </h4>
      </div>
      <div id="collapse6" class="panel-collapse collapse">
           
        <div class="panel-body">
            <h3> Go through following steps to get "Headwise Abstract Report".</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
          In menu bar, Click on "Abstract Report" tab. "Abstract Report" window will open.
             <h4 style="color:#ff6a00">Step 2</h4>
            Click on perticular Abstract name to get respecitive Abstract Report.
            <h4 style="color:#ff6a00">Step 3</h4>
            First select अर्थसंकल्पीय वर्ष then Select कामाचे वर्ष and लेखाशीर्ष form Dropdown list.
        </div>
      </div>
    </div>
   <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse7">To Get DBS Report</a>
        </h4>
      </div>
      <div id="collapse7" class="panel-collapse collapse">
           
        <div class="panel-body">
            <h3>Following are the steps for getting HeadWise Report. Go through following steps.</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
           
             <h4 style="color:#ff6a00">Step 2</h4>
        </div>
      </div>
    </div>
      <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse8">How to use various Settings</a>
        </h4>
      </div>
      <div id="collapse8" class="panel-collapse collapse">
           
        <div class="panel-body">
            <h3>Following are the steps to add Taluka (तालुका) in DBS software.</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
          Click on Taluka (तालुका) button.
             <h4 style="color:#ff6a00">Step 2</h4>
            To add new Taluka first select Jilha (जिल्हा) from dropdown list. Write name of Taluka in field. Click on Ok button, Taluka will be listed in below table. 
        </div>
       
            <div class="panel-body">
            <h3>Following are the steps to add Sub-Division (उपविभाग) in DBS software.</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
          Click on Sub-Division (उपविभाग) button. 
             <h4 style="color:#ff6a00">Step 2</h4>
                Insert Sub-Division (उपविभाग) name. Click on Ok, Sub-Division (उपविभाग) will be listed in below table. 
        </div>
         
          <div class="panel-body">
              <h3>Following are the steps to add Cusumer Department(उपभोक्ता विभाग) in DBS software</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
            Click on Cusumer Department(उपभोक्ता विभाग) button. 
             <h4 style="color:#ff6a00">Step 2</h4>
               Insert Cusumer Department(उपभोक्ता विभाग) name. Click on Ok, Cusumer Department(उपभोक्ता विभाग) will be listed in below table. 
        </div>
          <div class="panel-body">
             <h3>Following are the steps to add Representative (MLA/MP) in DBS software</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
            Click on Representative (MLA/MP) button. 
             <h4 style="color:#ff6a00">Step 2</h4>
             Choose MLA/MP from dropdown list and also check which type.
             <h4 style="color:#ff6a00">Step 3</h4>
             Mention MLA/MP name in field, then Click on <b>Save</b> button.
        </div>
          <div class="panel-body">
             <h3>Following are the steps to add Head (लेखाशीर्ष) in DBS software</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
             Click on Head (लेखाशीर्ष) button. 
             <h4 style="color:#ff6a00">Step 2</h4>
              Select <b>प्रकार </b> from dropdown list. Add <b>संगणक संकेतांक क्रमांक</b> and <b>लेखाशीर्ष</b>. 
              <h4 style="color:#ff6a00">Step 3</h4>
              Then Click on Submit button. Record will be listed in Table. 
        </div>
          <div class="panel-body">
             <h3>Portal SMS in DBS software</h3>
              This facility used for sending message only Authorized User  who has permission to use DBS Software.
          
        </div>
          <div class="panel-body">
             <h3>Following are the steps to send SMS</h3>
            <h4 style="color:#ff6a00">Step 1</h4>
           Click on <b>SMS</b> button. Insert Mobile number and Description in text field.
             <h4 style="color:#ff6a00">Step 2</h4>
           Click on <b>Send</b> button. Message will be deliver to mention mobile number.
        </div>
          <div class="panel-body">
             <h3>View User Profile</h3>
          Whenever you click on <b>View User Profile</b> button then you will get profile of the person who is currently login.
          </div>
          <div class="panel-body">
            <h3> To Create Account in DBS software</h3>
    The Steps are mention in "How to Create New User Login" tab.
          
         </div>
          <div class="panel-body">
              <h3>Following are the steps to Update WorkID and Budget Year in DBS software.</h3>
              <h4 style="color:#ff6a00">Step 1</h4>
              Click on <b>Update WorkID and Budget Year</b> button. Update WorkID and Budget Year window will be open.
              <h4 style="color:#ff6a00">Step 2</h4>
              Please select type according to your requirement and enter WorkID.
              <h4 style="color:#ff6a00">Step 3</h4>
              <b><u>To Edit Work ID</u></b><br />
               i) Please select <b>Edit WorkID</b><br />
              ii) Enter new WorkID and then click on Update button.  
              <br />

               <b><u>To Edit Budget Year</u></b><br />
               i) Please select <b>Edit Budget Year</b><br />
              ii) Enter Old Budget Year, also enter New Budget year and then click on Update button.  
        </div>
            <div class="panel-body">
              <h3>Following are the steps to Upload Image in DBS software.</h3>
              <h4 style="color:#ff6a00">Step 1</h4>
              Click on <b> Upload Image</b> button. Upload Image window will be open.
              <h4 style="color:#ff6a00">Step 2</h4>
              Please select type according to your requirement and enter WorkID.
              <h4 style="color:#ff6a00">Step 3</h4>
              Select Image which you want to Upload by clicking <b>Choose Image</b> button.
                <h4 style="color:#ff6a00">Step 4</h4>
             write description of image and Press on <b>Upload</b> button. Image will be Sucessfully Uploaded.
        </div>
      </div>
    </div>
  </div> 
</div>
</asp:Content>
