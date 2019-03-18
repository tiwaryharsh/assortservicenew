using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServiceDTO
{
    public class InvestFunda
    {
        [DataContract]
        public class Login
        {
            [DataMember]
            public string LoginID { get; set; }
            [DataMember]
            public string LoginName { get; set; }
        }

        [DataContract]
        public class AssignUClient
        {
            [DataMember]
            public string JobID { get; set; }
            [DataMember]
            public string ClientID { get; set; }
            [DataMember]
            public string UserID { get; set; }
        }


        [DataContract]
        public class ULogin
        {
            [DataMember]
            public string Candidate_Image { get; set; }
            [DataMember]
            public string ResumeUrl { get; set; }
            [DataMember]
            public string Assort_StaffID { get; set; }
            [DataMember]
            public string UR_ID { get; set; }
            [DataMember]
            public string JobHeader { get; set; }
            [DataMember]
            public string EmailID { get; set; }
            [DataMember]
            public string Gender { get; set; }
            [DataMember]
            public string DOB { get; set; }

            [DataMember]
            public string FName { get; set; }
            [DataMember]
            public string LName { get; set; }
            [DataMember]
            public string MobileNo { get; set; }
            [DataMember]
            public string present_location { get; set; }
            [DataMember]
            public string experience { get; set; }
            [DataMember]
            public string expected_ctc { get; set; }
            [DataMember]
            public string skills { get; set; }
        }
        [DataContract]
        public class EmailRep
        {
            [DataMember]
            public string EmailID { get; set; }
        }



        [DataContract]
        public class GetDocsListCl
        {
            [DataMember]
            public string DocsID { get; set; }

            [DataMember]
            public string DocsUrl { get; set; }

            [DataMember]
            public string DocsType { get; set; }

            [DataMember]
            public string Clientid { get; set; }
            [DataMember]
            public string DocsName { get; set; }
        }


        [DataContract]
        public class Issue
        {
            [DataMember]
            public string UUID { get; set; }
            [DataMember]
            public string RMName { get; set; }
            [DataMember]
            public string RMUniqueID { get; set; }
            [DataMember]
            public string IssueID { get; set; }
            [DataMember]
            public string ClientEmail { get; set; }
            [DataMember]
            public string IssuedTo { get; set; }
            [DataMember]
            public string ClientID { get; set; }
            [DataMember]
            public string ClientEmailID { get; set; }
            [DataMember]
            public string IssueSubject { get; set; }
            [DataMember]
            public string IssueBody { get; set; }
            [DataMember]
            public string IssueAttachmentUrl { get; set; }
            [DataMember]
            public string IssuState { get; set; }
            [DataMember]
            public string IsReminder { get; set; }
            [DataMember]
            public string EventType { get; set; }
            [DataMember]
            public string IssueCreateTime { get; set; }

            [DataMember]
            public string ReciveDate { get; set; }

            [DataMember]
            public string EmailID { get; set; }
            [DataMember]
            public string RepEmailID { get; set; }
        }


        [DataContract]
        public class TemporaryStaffing
        {
            [DataMember]
            public string Reporting_Manager { get; set; }
            [DataMember]
            public string TempporaryID { get; set; }
            [DataMember]
            public string staffID { get; set; }
            [DataMember]
            public string FirstName { get; set; }
            [DataMember]
            public string MiddleName { get; set; }
            [DataMember]
            public string LastName { get; set; }
            [DataMember]
            public string Gender { get; set; }
            [DataMember]
            public string DOJ { get; set; }
            [DataMember]
            public string Pan_NoReporting_Manager { get; set; }

            [DataMember]
            public string Salaried { get; set; }
            [DataMember]
            public string Costcenter { get; set; }
            [DataMember]
            public string Unitcode { get; set; }
            [DataMember]
            public string Permanent_Address1 { get; set; }
            [DataMember]
            public string Permanent_Address_Citycode { get; set; }
            [DataMember]
            public string Permanent_Address_Zipcode { get; set; }
            [DataMember]
            public string PFNo { get; set; }
            [DataMember]
            public string PFLimit { get; set; }
            [DataMember]
            public string Pan_No { get; set; }
            [DataMember]
            public string PT_App { get; set; }
            [DataMember]
            public string Email { get; set; }
            [DataMember]
            public string Mob_No { get; set; }
            [DataMember]
            public string Settlement_Date { get; set; }
            [DataMember]
            public string Project_income_till_date { get; set; }
            [DataMember]
            public string Passport_No { get; set; }
            [DataMember]
            public string Passport_Issue_Office { get; set; }
            [DataMember]
            public string Passport_Issue_Date { get; set; }
            [DataMember]
            public string Passport_Expiry_Date { get; set; }
            [DataMember]
            public string Contract_SDate { get; set; }
            [DataMember]
            public string Contract_EDate { get; set; }
            [DataMember]
            public string Emergency_Contact1_Name { get; set; }
            [DataMember]
            public string Emergency_Contact1_Relation { get; set; }
            [DataMember]
            public string Emergency_Contact1_Address { get; set; }
            [DataMember]
            public string Emergency_Contact1_Mobile_No { get; set; }
            [DataMember]
            public string Confirm_Status { get; set; }
            [DataMember]
            public string Bonus_Coverage { get; set; }
            [DataMember]
            public string BloodGroup_Code { get; set; }
            [DataMember]
            public string Assort_ClientID { get; set; }
        }


        [DataContract]
        public class DashBoardData
        {
            [DataMember]
            public string NoOfEscalaion { get; set; }

            [DataMember]
            public string STATES { get; set; }

        }

        [DataContract]
        public class Location
        {
            [DataMember]
            public string LocationID { get; set; }
            [DataMember]
            public string Name { get; set; }

        }
        [DataContract]
        public class updateIssueStatus
        {
            [DataMember]
            public string IssueID { get; set; }
            [DataMember]
            public string Status { get; set; }

        }

        [DataContract]
        public class InsertCandExcel
        {
            [DataMember]
            public string StaffId { get; set; }

            [DataMember]
            public string DOA { get; set; }
            [DataMember]
            public string Empcode { get; set; }
            [DataMember]
            public string Contact_Address_CitycodeStaffId { get; set; }
            [DataMember]
            public string FirstName { get; set; }
            [DataMember]
            public string MiddleName { get; set; }
            [DataMember]
            public string LastName { get; set; }
            [DataMember]
            public string Gender { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string DOJ { get; set; }
            [DataMember]
            public string DOB { get; set; }

            [DataMember]
            public string Leave_TemplateID { get; set; }
            [DataMember]
            public string Leave_AssignDate { get; set; }
            [DataMember]
            public string Reporting_Manager { get; set; }
            [DataMember]
            public string Reporting_HR { get; set; }
            [DataMember]
            public string EmailID_CC { get; set; }
            [DataMember]
            public string Nationality { get; set; }
            [DataMember]
            public string Effective_From { get; set; }
            [DataMember]
            public string Deptcode { get; set; }
            [DataMember]
            public string SubDept { get; set; }
            [DataMember]
            public string Desigcode { get; set; }
            [DataMember]
            public string Gradecode { get; set; }

            [DataMember]
            public string Categorycode { get; set; }
            [DataMember]
            public string LevelCode { get; set; }
            [DataMember]
            public string Salaried { get; set; }
            [DataMember]
            public string Costcenter { get; set; }
            [DataMember]
            public string Unitcode { get; set; }
            [DataMember]
            public string Amount_Paid_In { get; set; }
            [DataMember]
            public string Contact_Address1 { get; set; }
            [DataMember]
            public string Contact_Address2 { get; set; }
            [DataMember]
            public string Contact_Address_Citycode { get; set; }
            [DataMember]
            public string Contact_Address_Zipcode { get; set; }
            [DataMember]
            public string Permanent_Address1 { get; set; }
            [DataMember]
            public string Permanent_Address2 { get; set; }
            [DataMember]
            public string Permanent_Address_Citycode { get; set; }
            [DataMember]
            public string Permanent_Address_Zipcode { get; set; }
            [DataMember]
            public string ESIAPP { get; set; }
            [DataMember]
            public string ESINo { get; set; }
            [DataMember]
            public string ESI_Dispensory_Name { get; set; }
            [DataMember]
            public string Deduct_ESI_on_OT { get; set; }

            [DataMember]
            public string PFAPP { get; set; }
            [DataMember]
            public string PFNo { get; set; }
            [DataMember]
            public string PFLimit { get; set; }
            [DataMember]
            public string PensionNo { get; set; }
            [DataMember]
            public string Pan_No { get; set; }
            [DataMember]
            public string PT_App { get; set; }
            [DataMember]
            public string Labour_Welfare_Fund_Applicable { get; set; }
            [DataMember]
            public string Email { get; set; }
            [DataMember]
            public string Mob_No { get; set; }
            [DataMember]
            public string Finalized { get; set; }
            [DataMember]
            public string Settlement_Date { get; set; }
            [DataMember]
            public string DOL { get; set; }
            [DataMember]
            public string DolForm10 { get; set; }
            [DataMember]
            public string Project_income_till_date { get; set; }
            [DataMember]
            public string Passport_No { get; set; }


            [DataMember]
            public string Passport_Issue_Office { get; set; }
            [DataMember]
            public string Passport_Issue_Date { get; set; }

            [DataMember]
            public string Passport_Expiry_Date { get; set; }
            [DataMember]
            public string DOC { get; set; }
            [DataMember]
            public string DOG { get; set; }
            [DataMember]
            public string DOJForm5 { get; set; }
            [DataMember]
            public string Contract_SDate { get; set; }
            [DataMember]
            public string Contract_EDate { get; set; }
            [DataMember]
            public string ParentMedClaim { get; set; }
            [DataMember]
            public string Password { get; set; }
            [DataMember]
            public string MaritalStatus { get; set; }
            [DataMember]
            public string MarriageDate { get; set; }
            [DataMember]
            public string SpouseName { get; set; }
            [DataMember]
            public string Spouse_Date_of_Birth { get; set; }
            [DataMember]
            public string Total_Number_of_Children { get; set; }
            [DataMember]
            public string Total_Number_of_School_Going_Children { get; set; }
            [DataMember]
            public string Total_Number_of_Children_In_Hostel { get; set; }
            [DataMember]
            public string No_of_dependent { get; set; }
            [DataMember]
            public string Emergency_Contact1_Name { get; set; }
            [DataMember]
            public string Emergency_Contact1_Relation { get; set; }
            [DataMember]
            public string Emergency_Contact1_Address { get; set; }
            [DataMember]
            public string Emergency_Contact1_Email { get; set; }
            [DataMember]
            public string Emergency_Contact1_Landline_No { get; set; }
            [DataMember]
            public string Emergency_Contact1_Mobile_No { get; set; }
            [DataMember]
            public string Emergency_Contact2_Name { get; set; }
            [DataMember]
            public string Emergency_Contact2_Relation { get; set; }
            [DataMember]
            public string Emergency_Contact2_Address { get; set; }
            [DataMember]
            public string Emergency_Contact2_Email { get; set; }
            [DataMember]
            public string Emergency_Contact2_Landline_No { get; set; }
            [DataMember]
            public string Emergency_Contact2_Mobile_No { get; set; }
            [DataMember]
            public string Field1 { get; set; }
            [DataMember]
            public string Field2 { get; set; }
            [DataMember]
            public string Field3 { get; set; }
            [DataMember]
            public string Field4 { get; set; }
            [DataMember]
            public string Field5 { get; set; }
            [DataMember]
            public string Field6 { get; set; }

            [DataMember]
            public string OT_App { get; set; }
            [DataMember]
            public string Attendance_Rule_Not_Applicable { get; set; }
            [DataMember]
            public string OT_Temp_For_Normal_Days { get; set; }
            [DataMember]
            public string OT_Temp_For_Weekly_Off { get; set; }
            [DataMember]
            public string OT_Temp_For_Holidays { get; set; }
            [DataMember]
            public string Struct_Comb { get; set; }
            [DataMember]
            public string Shift_Comb { get; set; }
            [DataMember]
            public string OT_Comb { get; set; }
            [DataMember]
            public string HRA_RENT { get; set; }
            [DataMember]
            public string Confirm_Status { get; set; }
            [DataMember]
            public string Bonus_Coverage { get; set; }
            [DataMember]
            public string Plant_Incentive_App { get; set; }
            [DataMember]
            public string Plant_Incentive_Per { get; set; }
            [DataMember]
            public string Retirement_Flag { get; set; }
            [DataMember]
            public string Customized_PF_Option { get; set; }
            [DataMember]
            public string Customized_ESI_Option { get; set; }
            [DataMember]
            public string Customized_LWF_Option { get; set; }
            [DataMember]
            public string OT_Part_of_Gross { get; set; }
            [DataMember]
            public string Customized_OT_Part_of_Gross { get; set; }
            [DataMember]
            public string Customized_ESI_deduction_on_OT { get; set; }
            [DataMember]
            public string Notice_Days { get; set; }
            [DataMember]
            public string Pension_Limit { get; set; }
            [DataMember]
            public string Expat { get; set; }
            [DataMember]
            public string Minimum_Hours_For_Saturday_Full_Day_Working { get; set; }
            [DataMember]
            public string BloodGroup_Code { get; set; }

        }

        [DataContract]
        public class GetJobs
        {
            [DataMember]
            public List<JobList> JobLists { get; set; }

            [DataMember]
            public List<IndustryList> IndustryLists { get; set; }
            [DataMember]
            public List<SkillsList> SkillsLists { get; set; }
            [DataMember]
            public List<LocationList> LocationLists { get; set; }
            [DataMember]
            public List<CompanyList> CompanyLists { get; set; }

        }

        [DataContract]
        public class GetIssueDetails
        {
            [DataMember]
            public string HourDif { get; set; }

            [DataMember]
            public string IssueCreatetime { get; set; }

            [DataMember]
            public string IssueSubject { get; set; }

            [DataMember]
            public string ClientEmail { get; set; }

            [DataMember]
            public string RmEmailID { get; set; }

            [DataMember]
            public string RmManager1 { get; set; }

            [DataMember]
            public string RmManager2 { get; set; }

        }

        [DataContract]
        public class GetRmViaDepCls
        {
            [DataMember]
            public string EmailID { get; set; }

            [DataMember]
            public string ID { get; set; }


        }

        [DataContract]
        public class GetAppliedJobsList
        {
            [DataMember]
            public List<GetAppliedJobs> getAppliedJobs { get; set; }
            [DataMember]
            public List<GetAppliedJobs> getTotalRegistration { get; set; }
            [DataMember]
            public List<GetAppliedJobs> getTotalJobs { get; set; }
        }
        [DataContract]
        public class GetAppliedJobs
        {
            [DataMember]
            public string CandidateID { get; set; }
            [DataMember]
            public string JobID { get; set; }

            [DataMember]

            public string Name { get; set; }

            [DataMember]
            public string Title { get; set; }
            [DataMember]
            public string AppliedDate { get; set; }
            [DataMember]
            public string TotalRegistration { get; set; }
            [DataMember]
            public string TotalAppliedJob { get; set; }

            [DataMember]
            public string Totalclient { get; set; }

            [DataMember]
            public string TotalRM { get; set; }

        }
        [DataContract]
        public class CompanyList
        {
            [DataMember]
            public string CompanyID { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]

            public string Company_HeadQuartr { get; set; }
            [DataMember]

            public string Company_CEO { get; set; }
            [DataMember]

            public string Company_PhoneNo { get; set; }
            [DataMember]

            public string CompanyUrl { get; set; }

        }
        [DataContract]
        public class JobList
        {
            [DataMember]
            public string JobID { get; set; }
            [DataMember]
            public string Job_Title { get; set; }
            [DataMember]
            public string Job_Exp_Min { get; set; }
            [DataMember]
            public string Job_Exp_Max { get; set; }
            [DataMember]
            public string Job_Sal_Min { get; set; }
            [DataMember]
            public string Job_Sal_Max { get; set; }
            [DataMember]
            public string Job_Description { get; set; }

            [DataMember]
            public string Job_Location { get; set; }

            [DataMember]
            public string Job_PostedDate { get; set; }
            [DataMember]
            public string IsJobActive { get; set; }
            [DataMember]
            public string Job_PostedBy { get; set; }
            [DataMember]
            public string Job_Type { get; set; }
            [DataMember]
            public string CompanyName { get; set; }

            [DataMember]
            public string CompanyID { get; set; }

            [DataMember]
            public string LocationID { get; set; }
            [DataMember]
            public string SkillList { get; set; }

            [DataMember]
            public string IsDelete { get; set; }

        }

        [DataContract]
        public class IndustryList
        {
            [DataMember]
            public string JobID { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string IndustryID { get; set; }

        }
        [DataContract]
        public class SkillsList
        {
            [DataMember]
            public string JobID { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]

            public string Assort_skillID { get; set; }

        }
        [DataContract]
        public class CreateJob
        {
            [DataMember]
            public string Job_Title { get; set; }
            [DataMember]
            public string CompanyID { get; set; }
            [DataMember]
            public string Job_Exp_Min { get; set; }
            [DataMember]
            public string Job_Exp_Max { get; set; }
            [DataMember]
            public string Job_Sal_Min { get; set; }
            [DataMember]
            public string Job_Sal_Max { get; set; }
            [DataMember]
            public string Job_Description { get; set; }
            [DataMember]
            public string Job_PostedBy { get; set; }
            [DataMember]
            public string Job_Type { get; set; }
            [DataMember]
            public string IndustryID { get; set; }
            [DataMember]
            public string LocationID { get; set; }
            [DataMember]
            public string JobID { get; set; }

            [DataMember]
            public string IsPostedByClient { get; set; }

            [DataMember]
            public string SkillsList { get; set; }

            [DataMember]
            public string LocationList { get; set; }


        }

        [DataContract]
        public class AddLocation
        {
            [DataMember]
            public string LocationName { get; set; }


        }
        [DataContract]
        public class addClientDash
        {
            [DataMember]
            public string ClientID { get; set; }
            [DataMember]
            public string ClientDash { get; set; }


        }
        [DataContract]
        public class AddCardClient
        {

            [DataMember]
            public string ClientID { get; set; }

            [DataMember]
            public string Label1 { get; set; }
            [DataMember]
            public string Text1 { get; set; }

            [DataMember]
            public string Label2 { get; set; }
            [DataMember]
            public string Text2 { get; set; }

            [DataMember]
            public string Label3 { get; set; }
            [DataMember]
            public string Text3 { get; set; }

            [DataMember]
            public string Label4 { get; set; }
            [DataMember]
            public string Text4 { get; set; }


        }

        [DataContract]
        public class AddIndustry
        {
            [DataMember]
            public string Name { get; set; }


        }

        [DataContract]
        public class AddOtherDetails
        {
            [DataMember]
            public string NoOfEmpl { get; set; }

            [DataMember]
            public string Location { get; set; }

            [DataMember]
            public string NoOfEmplPF_ESIC { get; set; }

            [DataMember]
            public string HealthRpt { get; set; }

            [DataMember]
            public string Exits { get; set; }


            [DataMember]
            public string CLRA_Status { get; set; }

            [DataMember]
            public string open_positions_share { get; set; }

            [DataMember]
            public string Joinees { get; set; }

            [DataMember]
            public string ID { get; set; }

            [DataMember]
            public string Invoices { get; set; }

            [DataMember]
            public string Agreements_Dates { get; set; }


        }

        [DataContract]
        public class AddSkillCategoryName
        {
            [DataMember]
            public string Name { get; set; }


        }
        [DataContract]
        public class AddSkillName
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string SkillCategoryID { get; set; }


        }
        [DataContract]
        public class AddCompany
        {
            [DataMember]
            public string CompanyName { get; set; }
            [DataMember]
            public string CompanyHeadQuarter { get; set; }
            [DataMember]
            public string CEO { get; set; }
            [DataMember]
            public string PhoneNumber { get; set; }


        }
        [DataContract]
        public class SkillList
        {
            [DataMember]
            public string Assort_skillID { get; set; }

        }
        [DataContract]
        public class LocationList
        {
            [DataMember]
            public string JobID { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string LocationID { get; set; }

        }


        [DataContract]
        public class SkillsCategory
        {
            [DataMember]
            public string Assort_skillCategoryID { get; set; }
            [DataMember]
            public string Assort_skillCategoryName { get; set; }

        }

        [DataContract]
        public class SkillsName
        {
            [DataMember]
            public string Assort_skillID { get; set; }
            [DataMember]
            public string Assort_skillName { get; set; }
            [DataMember]
            public string Assort_skillCategoryID { get; set; }

        }

        [DataContract]
        public class IndustryLists
        {
            [DataMember]
            public string IndustryID { get; set; }
            [DataMember]
            public string Name { get; set; }

        }


        [DataContract]
        public class ShortlistedCandidate
        {
            [DataMember]
            public string JobID { get; set; }
            [DataMember]
            public string CandidateID { get; set; }

        }

        [DataContract]
        public class getUserListAdmin
        {
            [DataMember]
            public string LoginID { get; set; }

            [DataMember]
            public string Name { get; set; }

            [DataMember]
            public string ClientCode { get; set; }
        }

        [DataContract]
        public class getUserPlanListContract
        {
            [DataMember]
            public string MonthlySIP { get; set; }
            [DataMember]
            public string PlanName { get; set; }
            [DataMember]
            public string PlanID { get; set; }
            [DataMember]
            public string MasterPlanID { get; set; }

        }
        [DataContract]
        public class Country
        {
            [DataMember]
            public string Country_ID { get; set; }
            [DataMember]
            public string Country_Name { get; set; }
        }

        [DataContract]
        public class State
        {
            [DataMember]
            public string State_ID { get; set; }
            [DataMember]
            public string State_Name { get; set; }
            [DataMember]
            public string Country_ID { get; set; }
        }

        [DataContract]
        public class City
        {
            [DataMember]
            public string City_ID { get; set; }
            [DataMember]
            public string City_Name { get; set; }
            [DataMember]
            public string State_ID { get; set; }
        }

        [DataContract]
        public class ListOfAllData
        {
            [DataMember]
            public List<Bank> BankList { get; set; }

            [DataMember]
            public List<BankAccountType> BankAccountType { get; set; }

            [DataMember]
            public List<Relationship> RelationList { get; set; }

            [DataMember]
            public List<NomineeType> NomineeTypeList { get; set; }
            [DataMember]
            public List<ClientType> ClientTypeList { get; set; }

            [DataMember]
            public List<CommunicationMode> CommunicationModeList { get; set; }

            [DataMember]
            public List<DividentPayMode> DividentPayModeList { get; set; }
        }

        [DataContract]
        public class Bank
        {
            [DataMember]
            public string Bank_ID { get; set; }
            [DataMember]
            public string Bank_Name { get; set; }
        }


        [DataContract]
        public class Relationship
        {
            [DataMember]
            public string Relationship_ID { get; set; }
            [DataMember]
            public string RelationToUser { get; set; }
        }


        [DataContract]
        public class NomineeType
        {
            [DataMember]
            public string NomineeType_ID { get; set; }
            [DataMember]
            public string NomineeTypeValue { get; set; }
        }

        [DataContract]
        public class BankAccountType
        {
            [DataMember]
            public string AccountTypeID { get; set; }
            [DataMember]
            public string AccountType { get; set; }
        }
        [DataContract]
        public class ClientType
        {
            [DataMember]
            public string ClientType_ID { get; set; }
            [DataMember]
            public string ClientType_Name { get; set; }
        }

        [DataContract]
        public class CommunicationMode
        {
            [DataMember]
            public string CommunicationMode_ID { get; set; }
            [DataMember]
            public string CommunicationMode_Name { get; set; }
        }
        [DataContract]
        public class DividentPayMode
        {
            [DataMember]
            public string DividentPayMode_ID { get; set; }
            [DataMember]
            public string DividentMode { get; set; }
        }
        [DataContract]
        public class RegistrationData
        {
            public RegistrationData()
            {
                UR_First_Name = "";
                UR_Last_Name = "";
                UR_Email = "";
                UR_Mobile = "";
                UR_Password = "";

            }
            [DataMember]
            public string UR_First_Name { get; set; }
            [DataMember]
            public string UR_Last_Name { get; set; }
            [DataMember]
            public string UR_Email { get; set; }
            [DataMember]
            public string UR_Mobile { get; set; }
            [DataMember]
            public string UR_Password { get; set; }
        }

        [DataContract]
        public class AddClient
        {
            public AddClient()
            {
                Assort_ClientID = "";
                Assort_ClientName = "";
                Assort_ClientPassword = "";
                Assort_StartContractDate = "";
                Assort_EndContractDate = "";

                Assort_ClientUserID = "";
                Assort_CurrentlyOutsourcedAgency1 = "";
                Assort_CurrentlyOutsourcedAgency2 = "";
                Assort_CurrentlyOutsourcedAgency3 = "";
                Assort_CurrentlyOutsourcedAgency4 = "";
                Assort_CurrentlyOutsourcedAgency5 = "";


                Assort_AveragemarkupForIntelligence = "";
                Assort_Temporarystaffing = "";
                Assort_Reasonforchangeisuue = "";
                Assort_TotalstafftooutsourceRecruit = "";
                Assort_TotalstafftooutsourceOutsource = "";

                Assort_MinSalary = "";
                Assort_MaxSal = "";
                Assort_JobDescription = "";
                Assort_Paymenttermforpermanentplacementsignof = "";
                Assort_InsuranceCoverage = "";


            }
            [DataMember]
            public string Assort_ClientID { get; set; }
            [DataMember]
            public string Assort_ClientName { get; set; }
            [DataMember]
            public string Assort_ClientPassword { get; set; }
            [DataMember]
            public string Assort_StartContractDate { get; set; }
            [DataMember]
            public string Assort_EndContractDate { get; set; }


            [DataMember]
            public string Assort_ClientUserID { get; set; }
            [DataMember]
            public string Assort_CurrentlyOutsourcedAgency1 { get; set; }
            [DataMember]
            public string Assort_CurrentlyOutsourcedAgency2 { get; set; }
            [DataMember]
            public string Assort_CurrentlyOutsourcedAgency3 { get; set; }
            [DataMember]
            public string Assort_CurrentlyOutsourcedAgency4 { get; set; }
            [DataMember]
            public string Assort_CurrentlyOutsourcedAgency5 { get; set; }


            [DataMember]
            public string Assort_AveragemarkupForIntelligence { get; set; }
            [DataMember]
            public string Assort_Temporarystaffing { get; set; }
            [DataMember]
            public string Assort_Reasonforchangeisuue { get; set; }
            [DataMember]
            public string Assort_TotalstafftooutsourceRecruit { get; set; }


            [DataMember]
            public string Assort_TotalstafftooutsourceOutsource { get; set; }
            [DataMember]
            public string Assort_MinSalary { get; set; }
            [DataMember]
            public string Assort_MaxSal { get; set; }
            [DataMember]
            public string Assort_JobDescription { get; set; }
            [DataMember]
            public string Assort_Paymenttermforpermanentplacementsignof { get; set; }
            [DataMember]
            public string Assort_InsuranceCoverage { get; set; }

            [DataMember]
            public string industry { get; set; }

            [DataMember]
            public string turn_over { get; set; }

            [DataMember]
            public string client_website { get; set; }

            [DataMember]
            public string client_linkedin { get; set; }

            [DataMember]
            public string permaBuiseness13 { get; set; }

            [DataMember]
            public string replacement_period { get; set; }

            [DataMember]
            public string terms_of_payment_forSharing { get; set; }

            [DataMember]
            public string cash_and_carry { get; set; }

            [DataMember]
            public string upfront { get; set; }

            [DataMember]
            public string complince { get; set; }

            [DataMember]
            public string Assort_ClientContactPersonName { get; set; }

            [DataMember]
            public string Assort_ClientEmail { get; set; }

            [DataMember]
            public string Assort_ClientPNumber { get; set; }

            [DataMember]
            public string Assort_ClientManagerName { get; set; }

            [DataMember]
            public string Assort_ClientContactID { get; set; }

            [DataMember]
            public string ClientagrementUrl { get; set; }

            [DataMember]
            public string isActive { get; set; }

        }


        [DataContract]
        public class AddRelationshipManager
        {
            [DataMember]
            public string Relationship_Password { get; set; }

            [DataMember]
            public string Assort_ClientContactPersonName { get; set; }

            [DataMember]
            public string Assort_ClientEmail { get; set; }

            [DataMember]
            public string Assort_ClientPNumber { get; set; }

            [DataMember]
            public string Assort_ClientManagerName { get; set; }

            [DataMember]
            public string Assort_ClientContactID { get; set; }

            [DataMember]
            public string AssortClientManager1Email { get; set; }
            [DataMember]
            public string AssortClientManager2Email { get; set; }
            [DataMember]
            public string AssortClientManager1Name { get; set; }
            [DataMember]
            public string AssortClientManager2Name { get; set; }
            [DataMember]
            public string AssortClientManagerUniqueCode { get; set; }
            [DataMember]
            public string Assort_department { get; set; }

        }
        [DataContract]
        public class UserDetails
        {
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string UserName { get; set; }
            [DataMember]
            public string UserRole { get; set; }
            [DataMember]
            public string UserEmail { get; set; }
        }
        [DataContract]
        public class UserDetailsInfo
        {
            //[DataMember]
            //public UserDetails userDetails  { get; set; }

            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string UserName { get; set; }
            [DataMember]
            public string UserRole { get; set; }
            [DataMember]
            public string UserEmail { get; set; }

            [DataMember]
            public string IsComplete { get; set; }

            [DataMember]
            public string ClientCodeGenerateStatus { get; set; }

            [DataMember]
            public string ClientMendateCodeGenerateStatus { get; set; }
            [DataMember]
            public string ClientPaymentCodeGenerateStatus { get; set; }
            [DataMember]
            public UserProfile UserProfileData { get; set; }
            [DataMember]
            public BankDetails BankDetailsData { get; set; }
            [DataMember]
            public DepositoryDetails DepositoryDetailsData { get; set; }
            [DataMember]
            public List<NomineeDetails> NomineeDetailsData { get; set; }
            [DataMember]
            public List<UploadDocumentDetails> UploadDocumentDetailsData { get; set; }
            [DataMember]
            public List<AddressDetails> AddressDetailsData { get; set; }


        }

        public class UserDashInvestmentInfo
        {
            [DataMember]
            public List<UserInvestmentSchemeDetails> UserInvestmentSchemeDetailsData { get; set; }



        }
        public class Admin_getAllActionDetails
        {
            [DataMember]
            public List<Admin_getAllActionList> Admin_getAllActionListData { get; set; }



        }
        [DataContract]
        public class Admin_getAllActionList
        {
            [DataMember]
            public string ISIN { get; set; }

            [DataMember]
            public string BSESchemeCode { get; set; }
            [DataMember]
            public string SchemeName { get; set; }
            [DataMember]
            public string Amount { get; set; }
            [DataMember]
            public string InvestmentType { get; set; }
            [DataMember]
            public string CurrentNav { get; set; }
            [DataMember]
            public string Date { get; set; }

            [DataMember]

            public string MasterPlanID { get; set; }
            [DataMember]

            public string MasterPlanName { get; set; }
            [DataMember]

            public string Plan_ID { get; set; }
            [DataMember]
            public string InvestmentSchemePlan_ID { get; set; }
            [DataMember]
            public string ActyionType { get; set; }

        }
        [DataContract]
        public class getUserInvestmentDetails
        {

            [DataMember]
            public List<UserInvestmentDetailsInfo> UserInvestmentDetailsData { get; set; }
            [DataMember]
            public List<UserInvestmentSchemeDetails> UserInvestmentSchemeDetailsData { get; set; }

        }

        [DataContract]
        public class UserInvestmentDetailsInfo
        {
            [DataMember]
            public string Name { get; set; }

            [DataMember]
            public string ClientCode { get; set; }
            [DataMember]
            public string UR_ID { get; set; }
            [DataMember]
            public string ClientType { get; set; }
            [DataMember]
            public string NSDLDP_ID { get; set; }
            [DataMember]
            public string CDSLBenAcNo { get; set; }

            [DataMember]
            public string NSDLBenAcNo { get; set; }
            [DataMember]
            public string UR_PANCardNo { get; set; }
            [DataMember]
            public string UR_Email { get; set; }
            [DataMember]
            public string UR_Mobile { get; set; }

        }

        [DataContract]
        public class UserInvestmentSchemeDetails
        {
            [DataMember]
            public string ISIN { get; set; }

            [DataMember]
            public string BSESchemeCode { get; set; }
            [DataMember]
            public string SchemeName { get; set; }
            [DataMember]
            public string Amount { get; set; }
            [DataMember]
            public string InvestmentType { get; set; }
            [DataMember]
            public string CurrentNav { get; set; }
            [DataMember]
            public string Date { get; set; }

            [DataMember]

            public string MasterPlanID { get; set; }
            [DataMember]

            public string MasterPlanName { get; set; }
            [DataMember]

            public string Plan_ID { get; set; }
            [DataMember]
            public string MendateID { get; set; }
            [DataMember]
            public string InvestmentSchemePlan_ID { get; set; }


        }
        [DataContract]
        public class DownloadRequest
        {
            [DataMember]
            public string FileName;
        }

        [DataContract]
        public class RemoteFileInfo
        {


            [DataMember(Order = 1)]
            public System.IO.Stream FileByteStream;

            public void Dispose()
            {
                if (FileByteStream != null)
                {
                    FileByteStream.Close();
                    FileByteStream = null;
                }
            }
        }
        [DataContract]
        public class UserProfile
        {
            [DataMember]
            public string FirstName { get; set; }
            [DataMember]
            public string MiddleName { get; set; }
            [DataMember]
            public string LastName { get; set; }
            [DataMember]
            public string EmailID { get; set; }
            [DataMember]
            public string MobileNo { get; set; }

            [DataMember]
            public string DateOfBirth { get; set; }
            [DataMember]
            public string PANNumber { get; set; }
            [DataMember]
            public string TaxStatus_ID { get; set; }
            [DataMember]
            public string TaxStatus_Name { get; set; }
            [DataMember]
            public string TaxStatusBSECode { get; set; }
            [DataMember]
            public string HoldingNature_Name { get; set; }
            [DataMember]
            public string HoldingNatureBSECode { get; set; }
            [DataMember]
            public string HoldingNature_ID { get; set; }
            [DataMember]
            public string SOW_ID { get; set; }
            [DataMember]
            public string SOW_Name { get; set; }
            [DataMember]
            public string SOWBSECode { get; set; }
            [DataMember]
            public string Income { get; set; }

            [DataMember]
            public string Gender { get; set; }
            [DataMember]
            public string Comments { get; set; }
            [DataMember]
            public string Howdidyou { get; set; }
            [DataMember]
            public string Phone { get; set; }
            [DataMember]
            public string Occupation_ID { get; set; }
            [DataMember]
            public string RegistrationDate { get; set; }

            [DataMember]
            public string ClientTypeID { get; set; }

            [DataMember]
            public string ClientTypeCode { get; set; }
            [DataMember]
            public string CommunicationModeID { get; set; }

            [DataMember]
            public string CommunicationModeCode { get; set; }

            [DataMember]
            public string UR_2ndApplicant { get; set; }

            [DataMember]
            public string UR_3rdApplicant { get; set; }


            [DataMember]
            public string UR_2ndApplicantPanCard { get; set; }

            [DataMember]
            public string UR_3rdApplicantPanCard { get; set; }
            [DataMember]
            public string AddedCartCount { get; set; }

            [DataMember]
            public string AddedFavCount { get; set; }

            [DataMember]
            public string AddedInvestment { get; set; }

            [DataMember]
            public string ClientCode { get; set; }

            [DataMember]
            public string DividentPayMode_ID { get; set; }
            [DataMember]
            public string DividentPayMode { get; set; }
            [DataMember]
            public string GuardianName { get; set; }
            [DataMember]
            public string GuardianPanCard { get; set; }
        }

        [DataContract]
        public class BlogData
        {
            [DataMember]
            public string Header { get; set; }
            [DataMember]
            public string Content { get; set; }
            [DataMember]
            public string Image { get; set; }
            [DataMember]
            public string CategoryID { get; set; }

        }
        [DataContract]
        public class newsAndMedia
        {
            [DataMember]
            public string newsID { get; set; }
            [DataMember]
            public string newsImage { get; set; }

            [DataMember]
            public string newsHeading { get; set; }
            [DataMember]
            public string newsDate { get; set; }
            [DataMember]
            public string newsDisc { get; set; }
        }

        [DataContract]
        public class Blogs
        {
            [DataMember]
            public string blogID { get; set; }
            [DataMember]
            public string blogImage { get; set; }

            [DataMember]
            public string blogHeading { get; set; }
            [DataMember]
            public string blogPublishDate { get; set; }
            [DataMember]
            public string blogDisc { get; set; }
            [DataMember]
            public string blogShortDisc { get; set; }
        }

        [DataContract]
        public class UploadedFile
        {
            [DataMember]
            public string FilePath { get; set; }

            [DataMember]
            public string FileLength
            {
                get; set;
            }

            [DataMember]
            public string FileName
            {
                get; set;

            }

            //Other information. On upload only path and size are obvious.
            //...
        }
        [DataContract]
        public class DepositoryDetails
        {
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string DepositoryDetails_ID { get; set; }
            [DataMember]
            public string ClientType { get; set; }
            [DataMember]
            public string DepositoryName { get; set; }
            [DataMember]
            public string NSDLDP_ID { get; set; }
            [DataMember]
            public string CDSLBenAcNo { get; set; }
            [DataMember]
            public string NSDLBenAcNo { get; set; }
        }

        [DataContract]
        public class BankDetails
        {
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string Bank_ID { get; set; }
            [DataMember]
            public string Bank_IFSC { get; set; }
            [DataMember]
            public string Bank_AccountTypeID { get; set; }
            [DataMember]
            public string Bank_AccountNo { get; set; }
            [DataMember]
            public string NameAsPerBank { get; set; }
            [DataMember]
            public string BankDetails_ID { get; set; }
            [DataMember]
            public string BankName { get; set; }
            [DataMember]
            public string BankAccountTypeBSECode { get; set; }
            [DataMember]
            public string Bank_AccountTypeName { get; set; }
        }
        [DataContract]
        public class NomineeDetails
        {
            //[DataMember]
            //public string Nominee_ID { get; set; }
            [DataMember]
            public string Nominee_Name { get; set; }

            //[DataMember]
            //public string Nominee_Relationship { get; set; }

            [DataMember]
            public string Nominee_RiskType { get; set; }

            [DataMember]
            public string Nominee_DOB { get; set; }

            [DataMember]
            public string Nominee_AllocationPercentage { get; set; }

            [DataMember]
            public string UR_Nominee_ID { get; set; }
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string Nominee_Relationship_Name { get; set; }

            [DataMember]
            public string Nominee_Relationship_ID { get; set; }
        }



        [DataContract]
        public class AddressDetails
        {
            [DataMember]
            public string Address_ID { get; set; }
            [DataMember]
            public string CityID { get; set; }

            [DataMember]
            public string CityName { get; set; }

            [DataMember]
            public string PinCode { get; set; }

            [DataMember]
            public string Address { get; set; }

            [DataMember]
            public string AddressType { get; set; }

            [DataMember]
            public string CountryID { get; set; }
            [DataMember]
            public string CountryName { get; set; }

            [DataMember]
            public string CountryBSECode { get; set; }
            [DataMember]
            public string StateID { get; set; }

            [DataMember]
            public string StateName { get; set; }

            [DataMember]
            public string SateBSECode { get; set; }
        }

        [DataContract]
        public class UploadDocumentDetails
        {
            [DataMember]
            public string DocumentUpload_ID { get; set; }
            [DataMember]
            public string User_ID { get; set; }

            [DataMember]
            public string IsMandatory { get; set; }
            [DataMember]
            public string DocumentType { get; set; }
            [DataMember]
            public string DocumentName { get; set; }
            [DataMember]
            public string DocumentPath { get; set; }

        }

        [DataContract]
        public class TaxStatus
        {
            [DataMember]
            public string TaxID { get; set; }
            [DataMember]
            public string TaxStatusName { get; set; }
        }
        [DataContract]
        public class HoldingNature
        {
            [DataMember]
            public string HoldingNature_ID { get; set; }
            [DataMember]
            public string Holding_Nature { get; set; }
        }
        [DataContract]
        public class SourceOfWealth
        {
            [DataMember]
            public string SourceOfWealth_ID { get; set; }
            [DataMember]
            public string SourceOf_Wealth { get; set; }
        }




        public class UserBankDetails
        {
            [DataMember]
            public string BankDetails_ID { get; set; }
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string Bank_ID { get; set; }
            [DataMember]
            public string Bank_IFSC { get; set; }
            [DataMember]
            public string Bank_AccountTypeID { get; set; }
            [DataMember]
            public string Bank_AccountNo { get; set; }
            [DataMember]
            public string NameAsPerBank { get; set; }

        }
        [DataContract]
        public class UserNomineeDetails
        {
            //[DataMember]
            //public string Nominee_ID { get; set; }
            [DataMember]
            public string Nominee_Name { get; set; }

            [DataMember]
            public string Nominee_Relationship_ID { get; set; }

            [DataMember]
            public string Nominee_RiskType { get; set; }

            [DataMember]
            public string Nominee_DOB { get; set; }

            [DataMember]
            public string Nominee_AllocationPercentage { get; set; }

            [DataMember]
            public string UR_Nominee_ID { get; set; }
            [DataMember]
            public string User_ID { get; set; }

        }

        [DataContract]
        public class UserUploadDocumentDetails
        {
            [DataMember]
            public string DocumentUpload_ID { get; set; }
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string DocumentType { get; set; }
            [DataMember]
            public string DocumentName { get; set; }
            [DataMember]
            public string DocumentPath { get; set; }
            [DataMember]
            public string IsMandatory { get; set; }
        }

        [DataContract]
        public class Plan
        {
            [DataMember]
            public string Plan_ID { get; set; }
            [DataMember]
            public string MasterPlan_ID { get; set; }
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string GoalName { get; set; }
            [DataMember]
            public string PresentAge { get; set; }
            [DataMember]
            public string GoalTimeToStart { get; set; }
            [DataMember]
            public string GoalDuration { get; set; }
            [DataMember]
            public string GoalPerYearCost { get; set; }
            [DataMember]
            public string GoalPerYearLivingCost { get; set; }
            [DataMember]
            public string GoalLumpsum { get; set; }
            [DataMember]
            public string GoalInflationRate { get; set; }
            [DataMember]
            public string GoalTotalCost { get; set; }
            [DataMember]
            public string GoalLivingTotalCost { get; set; }
            [DataMember]
            public string GoalTotalAmount { get; set; }
            [DataMember]
            public string GoalTotalLumpsumAmount { get; set; }
            [DataMember]
            public string EstimatedInflationRate { get; set; }
            [DataMember]
            public string GoalDateOfSip { get; set; }

            [DataMember]
            public string GoalRetirementYear { get; set; }
            [DataMember]
            public string GoalRetirementExpense { get; set; }
            [DataMember]
            public string GoalRetirementMonthlyExpenditure { get; set; }
            [DataMember]
            public string GoalHousePlanYear { get; set; }
            [DataMember]
            public string GoalHouseCurrentCost { get; set; }
            [DataMember]
            public string GoalHouseDownPayment { get; set; }
            [DataMember]
            public string GoalHouseLoanYear { get; set; }
            [DataMember]
            public string GoalChildMerrageBudgetAmount { get; set; }
            [DataMember]
            public string Risk { get; set; }

        }

        [DataContract]
        public class Portfolio
        {
            [DataMember]
            public string Portfolio_ID { get; set; }
            [DataMember]
            public string Plan_ID { get; set; }
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string Equity { get; set; }
            [DataMember]
            public string Debt { get; set; }
            [DataMember]
            public string Gold { get; set; }
            [DataMember]
            public string EstimatedTotalSIPAmt { get; set; }
            [DataMember]
            public string Scheme_IDs { get; set; }

        }


        [DataContract]
        public class BSEClientFields
        {
            [DataMember]
            public string Portfolio_ID { get; set; }
            [DataMember]
            public string Plan_ID { get; set; }
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string Equity { get; set; }
            [DataMember]
            public string Debt { get; set; }
            [DataMember]
            public string EstimatedTotalSIPAmt { get; set; }
            [DataMember]
            public string Scheme_IDs { get; set; }

        }

        [DataContract]
        public class InvestmentScheme
        {
            [DataMember]
            public string ISIN { get; set; }
            [DataMember]
            public string BSESchemeCode { get; set; }
            [DataMember]
            public string SchemeName { get; set; }
            [DataMember]
            public string Scheme_ID { get; set; }
            [DataMember]
            public string Amount { get; set; }
            [DataMember]
            public string DateString { get; set; }
            [DataMember]
            public string InvestmentType { get; set; }
            [DataMember]
            public string DueDate { get; set; }
            [DataMember]
            public string BSEOrderCode { get; set; }
            [DataMember]
            public string BSEPaymentStatus { get; set; }

        }
        [DataContract]
        public class InvestmentCartList
        {
            [DataMember]
            public List<InvestmentSIPCart> InvestmentSIPCartList { get; set; }
            [DataMember]
            public List<InvestmentLumpsumCart> InvestmentLumpsumCartList { get; set; }
            [DataMember]
            public List<InvestmentFavourite> InvestmentFavouriteList { get; set; }
            [DataMember]
            public List<InvestmentLumpsum> InvestmentLumpsumList { get; set; }
        }

        [DataContract]
        public class InvestmentFavourite
        {
            [DataMember]
            public string ISIN { get; set; }
            [DataMember]
            public string BSESchemeCode { get; set; }
            [DataMember]
            public string SchemeName { get; set; }
            [DataMember]
            public string Scheme_ID { get; set; }
            [DataMember]
            public string Amount { get; set; }
            [DataMember]
            public string InvestmentType { get; set; }
            [DataMember]
            public string DueDate { get; set; }
            [DataMember]
            public string InvestmentPlan_ID { get; set; }
            [DataMember]
            public string BSEOrderCode { get; set; }
        }

        [DataContract]
        public class InvestmentSIPCart
        {
            [DataMember]
            public string ISIN { get; set; }
            [DataMember]
            public string BSESchemeCode { get; set; }
            [DataMember]
            public string SchemeName { get; set; }
            [DataMember]
            public string Scheme_ID { get; set; }
            [DataMember]
            public string Amount { get; set; }
            [DataMember]
            public string InvestmentType { get; set; }
            [DataMember]
            public string DueDate { get; set; }
            [DataMember]
            public string InvestmentPlan_ID { get; set; }
            [DataMember]
            public string BSEOrderCode { get; set; }
        }

        [DataContract]
        public class InvestmentLumpsumCart
        {
            [DataMember]
            public string ISIN { get; set; }
            [DataMember]
            public string BSESchemeCode { get; set; }
            [DataMember]
            public string SchemeName { get; set; }
            [DataMember]
            public string Scheme_ID { get; set; }
            [DataMember]
            public string Amount { get; set; }
            [DataMember]
            public string InvestmentType { get; set; }
            [DataMember]
            public string DueDate { get; set; }
            [DataMember]
            public string InvestmentPlan_ID { get; set; }
            [DataMember]
            public string BSEOrderCode { get; set; }
        }

        [DataContract]
        public class InvestmentLumpsum
        {
            [DataMember]
            public string ISIN { get; set; }
            [DataMember]
            public string BSESchemeCode { get; set; }
            [DataMember]
            public string SchemeName { get; set; }
            [DataMember]
            public string Scheme_ID { get; set; }
            [DataMember]
            public string Amount { get; set; }
            [DataMember]
            public string InvestmentType { get; set; }
            [DataMember]
            public string DueDate { get; set; }
            [DataMember]
            public string InvestmentPlan_ID { get; set; }
            [DataMember]
            public string BSEOrderCode { get; set; }
        }

        [DataContract]
        #region
        public class MendateCreation
        {
            [DataMember]
            public string ClientCode { get; set; }
            [DataMember]
            public string Amount { get; set; }
            [DataMember]
            public string IFSC { get; set; }

            [DataMember]
            public string AccountNumber { get; set; }
        }


        [DataContract]
        public class XSIPRegistration
        {
            [DataMember]
            public string SchemeCode { get; set; }

            [DataMember]
            public string ClientCode { get; set; }
            [DataMember]
            public string StartDate { get; set; }
            [DataMember]
            public string FrequencyType { get; set; }

            [DataMember]
            public string InstallmentAmount { get; set; }

            [DataMember]
            public string NoOfInstallment { get; set; }


            [DataMember]
            public string Remark { get; set; }
        }
        [DataContract]
        public class UserPlan
        {
            [DataMember]
            public string HoldingNature { get; set; }
            [DataMember]
            public string UserName { get; set; }
            [DataMember]
            public string PanCardNo { get; set; }
            [DataMember]
            public List<SchemeList> SchemeListData { get; set; }

        }
        public class SchemeList
        {
            [DataMember]
            public string SchemeName { get; set; }
            [DataMember]
            public string InvSince { get; set; }
            [DataMember]
            public string InvType { get; set; }
            [DataMember]
            public string InvCost { get; set; }
            [DataMember]
            public string Units { get; set; }
            [DataMember]
            public string AvgPurNav { get; set; }
            [DataMember]
            public string CurrentNav { get; set; }
            [DataMember]
            public string CurrentValue { get; set; }
            [DataMember]
            public string GainLoss { get; set; }
            [DataMember]
            public string AvgCagr { get; set; }
            [DataMember]
            public string AbsRtn { get; set; }
            [DataMember]
            public string Action { get; set; }

        }


        [DataContract]
        public class FundHouse
        {
            [DataMember]
            public string MF_Code { get; set; }
            [DataMember]
            public string MF_FundName { get; set; }

        }

        [DataContract]
        public class UpdateSchemeDetails
        {
            [DataMember]
            public string Scheme_ID { get; set; }
            [DataMember]
            public string MF_ISIN { get; set; }
            [DataMember]
            public string MF_RTCode { get; set; }

        }

        [DataContract]
        public class NavDetails
        {
            [DataMember]
            public string mf_cocode { get; set; }
            [DataMember]
            public string mf_schcode { get; set; }
            [DataMember]
            public string navdate { get; set; }
            [DataMember]
            public string navrs { get; set; }
            [DataMember]
            public string NAVRePrice { get; set; }
            [DataMember]
            public string NAVsaPrice { get; set; }

        }

        [DataContract]
        public class AssetAllocation
        {
            [DataMember]
            public string TYPE { get; set; }
            [DataMember]
            public string INVDATE { get; set; }
            [DataMember]
            public string ASSETVALUE { get; set; }
            [DataMember]
            public string Scheme_ID { get; set; }
        }

        [DataContract]
        public class TopHolding
        {
            [DataMember]
            public string Scheme_ID { get; set; }
            [DataMember]
            public string CO_CODE { get; set; }
            [DataMember]
            public string CO_NAME { get; set; }
            [DataMember]
            public string Perc_Hold { get; set; }
            [DataMember]
            public string mktvalue { get; set; }
            [DataMember]
            public string NO_SHARES { get; set; }
            [DataMember]
            public string PortfolioDate { get; set; }
            [DataMember]
            public string AssetType { get; set; }
            [DataMember]
            public string rating { get; set; }

        }

        [DataContract]
        public class SchemeDetailsObject
        {
            [DataMember]
            public string SchemeName { get; set; }
            [DataMember]
            public string CategoryCode { get; set; }
            [DataMember]
            public string SchemeOption { get; set; }
            [DataMember]
            public string SchemeType { get; set; }
            [DataMember]
            public string mf_cocode { get; set; }
            [DataMember]
            public string Scheme_ID { get; set; }
            [DataMember]
            public string Objective { get; set; }
            [DataMember]
            public string BenchmarkName { get; set; }

            [DataMember]
            public string Return_3Mon { get; set; }
            [DataMember]
            public string Return_6Mon { get; set; }
            [DataMember]
            public string Return_1Yr { get; set; }
            [DataMember]
            public string Return_3Yr { get; set; }
            [DataMember]
            public string Return_5Yr { get; set; }
            [DataMember]
            public string LaunchDate { get; set; }
            [DataMember]
            public string AssetSize { get; set; }
            [DataMember]
            public string MinimumInvestment { get; set; }

            [DataMember]
            public string DividendPercentage_Latest { get; set; }
            [DataMember]
            public string Bonus_Latest { get; set; }
            [DataMember]
            public string FundManager { get; set; }
            [DataMember]
            public string ExitLoad { get; set; }
            [DataMember]
            public string IncrementalInvestment { get; set; }
            [DataMember]
            public string ExpRatio { get; set; }
            [DataMember]
            public string fiftytwoWHigh { get; set; }
            [DataMember]
            public string fiftytwoWHighDate { get; set; }
            [DataMember]
            public string fiftytwoWLow { get; set; }
            [DataMember]
            public string fiftytwoWLowDate { get; set; }


        }

        [DataContract]
        public class SipOrderEntry
        {
            [DataMember]
            public string TransactionCode { get; set; }
            [DataMember]
            public string UniqueReferenceNumber { get; set; }
            [DataMember]
            public string SchemeCd { get; set; }
            [DataMember]
            public string MemberId { get; set; }
            [DataMember]
            public string ClientCode { get; set; }
            [DataMember]
            public string UserId { get; set; }
            [DataMember]
            public string INTERNAL_REF_NO { get; set; }
            [DataMember]
            public string TRANS_MODE { get; set; }
            [DataMember]
            public string DPTransactionMode { get; set; }
            [DataMember]
            public string StartDate { get; set; }
            [DataMember]
            public string FREQUENCYTYPE { get; set; }
            [DataMember]
            public string FrequencyAllowed { get; set; }
            [DataMember]
            public string INSTALLMENT_AMOUNT { get; set; }
            [DataMember]
            public string NO_OF_INSTALLMENTS { get; set; }
            [DataMember]
            public string REMARKS { get; set; }
            [DataMember]
            public string FOLIO_NO { get; set; }
            [DataMember]
            public string FIRST_ORDER_FLAG { get; set; }
            [DataMember]
            public string BROKERAGE { get; set; }
            [DataMember]
            public string XSIPMANDATEID { get; set; }
            [DataMember]
            public string SUBBRCODE { get; set; }
            [DataMember]
            public string EUIN { get; set; }
            [DataMember]
            public string EUINflag { get; set; }
            [DataMember]
            public string DPC { get; set; }
            [DataMember]
            public string XSIPREG_ID { get; set; }
            [DataMember]
            public string IPAdd { get; set; }
            [DataMember]
            public string Password { get; set; }
            [DataMember]
            public string PassKey { get; set; }
            [DataMember]
            public string Param1_SubBrokerARN { get; set; }
            [DataMember]
            public string Param2_ISIPMandate_ID { get; set; }
            [DataMember]
            public string Param3 { get; set; }
        }

        #endregion
    }
}
