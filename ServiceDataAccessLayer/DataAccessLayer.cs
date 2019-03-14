using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Service.GlobalVariables;
using ServiceDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Mail;
using static ServiceDTO.InvestFunda;


namespace ServiceDataAccessLayer
{
    public class DataAccessLayer
    {
        DateTime dateAndTime = DateTime.Now;


        public DataSet GetLogin(string UserEmail, string UserPassword, string Type)
        {
            DataSet DSet = new DataSet();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_LOGIN))
                {
                    DB.AddInParameter(DBCommand, DBConstants.UEMAIL, DbType.String, UserEmail);
                    DB.AddInParameter(DBCommand, "Password", DbType.String, UserPassword);
                    DB.AddInParameter(DBCommand, "UType", DbType.String, Type);
                    DSet = DB.ExecuteDataSet(DBCommand);
                }
            }
            catch (Exception EX)
            {

            }

            return DSet;
        }
        public DataSet GetUserDetailsByID(string UserID)
        {
            DataSet DSet = new DataSet();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETUSERDETAILS))
                {
                    DB.AddInParameter(DBCommand, "UserID", DbType.String, UserID);
                    DSet = DB.ExecuteDataSet(DBCommand);
                }
            }
            catch (Exception EX)
            {

            }

            return DSet;
        }
        public DataSet UpdatePassword(string Email, string UserPassword)
        {
            DataSet DSet = new DataSet();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_UPDATEPASSWORD))
                {
                    DB.AddInParameter(DBCommand, DBConstants.UEMAIL, DbType.String, Email);
                    DB.AddInParameter(DBCommand, DBConstants.UPASSWORD, DbType.String, UserPassword);
                    DSet = DB.ExecuteDataSet(DBCommand);
                }
            }
            catch (Exception EX)
            {

            }

            return DSet;
        }

        public DataSet ShortlistedCandidate(DataTable dtShortlistedCandidate)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_INSERTSHORTLISTED))
                {
                    DASHDB.AddInParameter(DbCommand, "udt_ShortListedCandidate", SqlDbType.Structured, dtShortlistedCandidate);

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet CreateJobDataAccess(CreateJob request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_CREATEJOB))
                {

                    DASHDB.AddInParameter(DbCommand, "Job_Title", DbType.String, Convert.ToString(request.Job_Title));
                    DASHDB.AddInParameter(DbCommand, "CompanyID", DbType.String, Convert.ToString(request.CompanyID));
                    DASHDB.AddInParameter(DbCommand, "Job_Exp_Min", DbType.String, Convert.ToString(request.Job_Exp_Min));
                    DASHDB.AddInParameter(DbCommand, "Job_Exp_Max", DbType.String, Convert.ToString(request.Job_Exp_Max));
                    DASHDB.AddInParameter(DbCommand, "Job_Sal_Min", DbType.String, Convert.ToString(request.Job_Sal_Min));
                    DASHDB.AddInParameter(DbCommand, "Job_Sal_Max", DbType.String, Convert.ToString(request.Job_Sal_Max));
                    DASHDB.AddInParameter(DbCommand, "Job_Description", DbType.String, Convert.ToString(request.Job_Description));
                    DASHDB.AddInParameter(DbCommand, "Job_PostedBy", DbType.String, Convert.ToString(request.Job_PostedBy));
                    DASHDB.AddInParameter(DbCommand, "Job_Type", DbType.String, Convert.ToString(request.Job_Type));
                    DASHDB.AddInParameter(DbCommand, "IndustryID", DbType.String, Convert.ToString(request.IndustryID));
                    DASHDB.AddInParameter(DbCommand, "LocationID", DbType.String, Convert.ToString(request.LocationID));
                    DASHDB.AddInParameter(DbCommand, "JobID", DbType.String, Convert.ToString(request.JobID));
                    DASHDB.AddInParameter(DbCommand, "IsPostedByClient", DbType.String, Convert.ToString(request.IsPostedByClient));
                    DASHDB.AddInParameter(DbCommand, "SkillsList", DbType.String, Convert.ToString(request.SkillsList));
                    //DASHDB.AddInParameter(DbCommand, "udt_Skill1", DbType.String, Convert.ToString(request.SkillsList));




                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }

        public DataSet UpdateClientAgrement(string resumePath, string ClientID)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_UPDATECLIENTAGREMENT))
                {

                    DASHDB.AddInParameter(DbCommand, "ClientID", DbType.String, Convert.ToString(ClientID));
                    DASHDB.AddInParameter(DbCommand, "Agrementurl", DbType.String, Convert.ToString(resumePath));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }

        public DataSet UpdateCandidateImage(string imagePath, string CandidateID)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_UPDATEPROFILEIMAGE))
                {

                    DASHDB.AddInParameter(DbCommand, "Candidate_Image", DbType.String, Convert.ToString(imagePath));
                    DASHDB.AddInParameter(DbCommand, "CandidateID", DbType.String, Convert.ToString(CandidateID));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet UpdateCandidateResume(string resumePath, string CandidateID)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_UPDATERESUME))
                {

                    DASHDB.AddInParameter(DbCommand, "ResumeUrl", DbType.String, Convert.ToString(resumePath));
                    DASHDB.AddInParameter(DbCommand, "CandidateID", DbType.String, Convert.ToString(CandidateID));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }

        public DataSet UpdateClientDocs(string resumePath, string ClientID, string DocsType, string DocsName)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_CLIENTDOCS))
                {

                    DASHDB.AddInParameter(DbCommand, "DocsUrl", DbType.String, Convert.ToString(resumePath));
                    DASHDB.AddInParameter(DbCommand, "Clientid", DbType.String, Convert.ToString(ClientID));
                    DASHDB.AddInParameter(DbCommand, "DocsType", DbType.String, Convert.ToString(DocsType));
                    DASHDB.AddInParameter(DbCommand, "DocsName", DbType.String, Convert.ToString(DocsName));
                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet UpdateIssueStatus(updateIssueStatus IssueStatus)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_UPDATEISSUESTATUS))
                {

                    DASHDB.AddInParameter(DbCommand, "IssueID", DbType.String, Convert.ToString(IssueStatus.IssueID));
                    DASHDB.AddInParameter(DbCommand, "Status", DbType.String, Convert.ToString(IssueStatus.Status));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                    SendEmailOfUpdate(IssueStatus.IssueID, IssueStatus.Status);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public void SendEmailOfUpdate(string IssueID, string Status)
        {
            DataTable tempDt = GetIssue(IssueID);
            List<Issue> getIssueDetails = new List<Issue>();
            if (tempDt.Rows.Count > 0)
            {
                getIssueDetails = (from DataRow dr in tempDt.Rows
                                   select new Issue
                                   {
                                       IssueID = (dr["IssueID"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueID"]).Trim(),
                                       IssuedTo = (dr["IssuedTo"] is DBNull) ? string.Empty : Convert.ToString(dr["IssuedTo"]).Trim(),
                                       ClientID = (dr["ClientID"] is DBNull) ? string.Empty : Convert.ToString(dr["ClientID"]).Trim(),
                                       IssueSubject = (dr["IssueSubject"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueSubject"]).Trim(),
                                       IssueBody = (dr["IssueBody"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueBody"]).Trim(),
                                       IssueAttachmentUrl = (dr["IssueAttachmentUrl"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueAttachmentUrl"]).Trim(),
                                       IssuState = (dr["IssuState"] is DBNull) ? string.Empty : Convert.ToString(dr["IssuState"]).Trim(),
                                       IssueCreateTime = (dr["IssueCreateTime"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueCreateTime"]).Trim(),
                                       EventType = (dr["EventType"] is DBNull) ? string.Empty : Convert.ToString(dr["EventType"]).Trim(),
                                       ClientEmail = (dr["IssueFrom"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueFrom"]).Trim(),



                                   }).ToList();

            }
            bool isEmailSent = sendEmail(getIssueDetails[0].IssuedTo, getIssueDetails[0].ClientEmail, getIssueDetails[0].IssueSubject, getIssueDetails[0].IssueBody, Status, IssueID);
        }
        public DataSet ApplyJobDataAccess(string CandidateID, string JobID)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_APPLYJOB))
                {

                    DASHDB.AddInParameter(DbCommand, "JobID", DbType.String, Convert.ToString(JobID));
                    DASHDB.AddInParameter(DbCommand, "CandidateID", DbType.String, Convert.ToString(CandidateID));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }



        public DataSet AddCardClientDataAccess(AddCardClient request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_ADDCLIENTCARD))
                {

                    DASHDB.AddInParameter(DbCommand, "Label1", DbType.String, Convert.ToString(request.Label1));
                    DASHDB.AddInParameter(DbCommand, "Text1", DbType.String, Convert.ToString(request.Text1));
                    DASHDB.AddInParameter(DbCommand, "Label2", DbType.String, Convert.ToString(request.Label2));
                    DASHDB.AddInParameter(DbCommand, "Text2", DbType.String, Convert.ToString(request.Text2));
                    DASHDB.AddInParameter(DbCommand, "Label3", DbType.String, Convert.ToString(request.Label3));
                    DASHDB.AddInParameter(DbCommand, "Text3", DbType.String, Convert.ToString(request.Text3));
                    DASHDB.AddInParameter(DbCommand, "Label4", DbType.String, Convert.ToString(request.Label4));
                    DASHDB.AddInParameter(DbCommand, "Text4", DbType.String, Convert.ToString(request.Text4));
                    DASHDB.AddInParameter(DbCommand, "ClientID", DbType.String, Convert.ToString(request.ClientID));
                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet AddLocationDataAccess(AddLocation request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_ADDLOCATION))
                {

                    DASHDB.AddInParameter(DbCommand, "LocationName", DbType.String, Convert.ToString(request.LocationName));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }

        public DataSet AddIndustryDataAccess(AddIndustry request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_ADDINDUSTRY))
                {

                    DASHDB.AddInParameter(DbCommand, "LName", DbType.String, Convert.ToString(request.Name));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }


        public DataSet AddSkillNameDataAccess(AddSkillName request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_ADDMASTER_SKILLSNAME))
                {

                    DASHDB.AddInParameter(DbCommand, "LName", DbType.String, Convert.ToString(request.Name));
                    DASHDB.AddInParameter(DbCommand, "Assort_skillCategoryID", DbType.String, Convert.ToString(request.SkillCategoryID));
                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet AddSkillCategoryDataAccess(AddSkillCategoryName request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_ADDMASTER_SKILLSCATEGORY))
                {

                    DASHDB.AddInParameter(DbCommand, "LName", DbType.String, Convert.ToString(request.Name));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }

        public DataSet deleteClient(string ID)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_DELETECLIENT))
                {

                    DASHDB.AddInParameter(DbCommand, "ID", DbType.String, Convert.ToString(ID));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet deleteRM(string RMID)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_DELETERM))
                {

                    DASHDB.AddInParameter(DbCommand, "RMID", DbType.String, Convert.ToString(RMID));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet AddCompanyDataAccess(AddCompany request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_ADDCOMPANY))
                {

                    DASHDB.AddInParameter(DbCommand, "Name", DbType.String, Convert.ToString(request.CompanyName));
                    DASHDB.AddInParameter(DbCommand, "Company_HeadQuarte", DbType.String, Convert.ToString(request.CompanyHeadQuarter));
                    DASHDB.AddInParameter(DbCommand, "Company_CEO", DbType.String, Convert.ToString(request.CEO));
                    DASHDB.AddInParameter(DbCommand, "Company_PhoneNo", DbType.String, Convert.ToString(request.PhoneNumber));

                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet UserRegistration(RegistrationData request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_USERREGISTRATION))
                {

                    DASHDB.AddInParameter(DbCommand, DBConstants.UR_FIRST_NAME, DbType.String, Convert.ToString(request.UR_First_Name));
                    DASHDB.AddInParameter(DbCommand, DBConstants.UR_LAST_NAME, DbType.String, Convert.ToString(request.UR_Last_Name));
                    DASHDB.AddInParameter(DbCommand, DBConstants.UR_EMAIL, DbType.String, Convert.ToString(request.UR_Email));
                    DASHDB.AddInParameter(DbCommand, DBConstants.UR_MOBILE, DbType.String, Convert.ToString(request.UR_Mobile));
                    DASHDB.AddInParameter(DbCommand, DBConstants.UR_PASSWORD, DbType.String, Convert.ToString(request.UR_Password));


                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }

        public DataSet Forgotpassword(string UEmail, string UPassword)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_FORGOTPASSWORD))
                {
                    DASHDB.AddInParameter(DbCommand, "EmailId", DbType.String, Convert.ToString(UEmail));


                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet AddRelationshipManager(AddRelationshipManager request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_INSERTRM))
                {
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientContactPersonName", DbType.String, Convert.ToString(request.Assort_ClientContactPersonName));
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientEmail", DbType.String, Convert.ToString(request.Assort_ClientEmail));
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientPNumber", DbType.String, Convert.ToString(request.Assort_ClientPNumber));
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientManagerName", DbType.String, Convert.ToString(request.Assort_ClientManagerName));
                    //RM ID
                    string id = request.Assort_ClientContactID == null ? "" : request.Assort_ClientContactID;
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientContactID", DbType.String, Convert.ToString(id));


                    DASHDB.AddInParameter(DbCommand, "AssortClientManager1Email", DbType.String, Convert.ToString(request.AssortClientManager1Email));
                    DASHDB.AddInParameter(DbCommand, "AssortClientManager2Email", DbType.String, Convert.ToString(request.AssortClientManager2Email));
                    DASHDB.AddInParameter(DbCommand, "AssortClientManager1Name", DbType.String, Convert.ToString(request.AssortClientManager1Name));
                    DASHDB.AddInParameter(DbCommand, "AssortClientManager2Name", DbType.String, Convert.ToString(request.AssortClientManager2Name));
                    DASHDB.AddInParameter(DbCommand, "AssortClientManagerUniqueCode", DbType.String, Convert.ToString(request.AssortClientManagerUniqueCode));
                    DASHDB.AddInParameter(DbCommand, "Relationship_Password", DbType.String, Convert.ToString(request.Relationship_Password));
                    //DASHDB.AddInParameter(DbCommand, "Assort_department", DbType.String, Convert.ToString(request.Assort_department));
                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet AddClient(AddClient request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_INSERTCLIENT))
                {

                    DASHDB.AddInParameter(DbCommand, "Assort_ClientID", DbType.String, Convert.ToString(request.Assort_ClientID));
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientName", DbType.String, Convert.ToString(request.Assort_ClientName));
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientUserID", DbType.String, Convert.ToString(request.Assort_ClientUserID));
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientPassword", DbType.String, Convert.ToString(request.Assort_ClientPassword));
                    DASHDB.AddInParameter(DbCommand, "Assort_AveragemarkupForIntelligence", DbType.String, Convert.ToString(request.Assort_AveragemarkupForIntelligence));
                    DASHDB.AddInParameter(DbCommand, "Assort_CurrentlyOutsourcedAgency1", DbType.String, Convert.ToString(request.Assort_CurrentlyOutsourcedAgency1));
                    DASHDB.AddInParameter(DbCommand, "Assort_CurrentlyOutsourcedAgency2", DbType.String, Convert.ToString(request.Assort_CurrentlyOutsourcedAgency2));
                    DASHDB.AddInParameter(DbCommand, "Assort_CurrentlyOutsourcedAgency3", DbType.String, Convert.ToString(request.Assort_CurrentlyOutsourcedAgency3));
                    DASHDB.AddInParameter(DbCommand, "Assort_CurrentlyOutsourcedAgency4", DbType.String, Convert.ToString(request.Assort_CurrentlyOutsourcedAgency4));
                    DASHDB.AddInParameter(DbCommand, "Assort_CurrentlyOutsourcedAgency5", DbType.String, Convert.ToString(request.Assort_CurrentlyOutsourcedAgency5));
                    DASHDB.AddInParameter(DbCommand, "Assort_EndContractDate", DbType.String, Convert.ToString(request.Assort_EndContractDate));
                    DASHDB.AddInParameter(DbCommand, "Assort_InsuranceCoverage", DbType.String, Convert.ToString(request.Assort_InsuranceCoverage));


                    DASHDB.AddInParameter(DbCommand, "Assort_JobDescription", DbType.String, Convert.ToString(request.Assort_JobDescription));
                    DASHDB.AddInParameter(DbCommand, "Assort_MaxSal", DbType.String, Convert.ToString(request.Assort_MaxSal));
                    DASHDB.AddInParameter(DbCommand, "Assort_MinSalary", DbType.String, Convert.ToString(request.Assort_MinSalary));
                    DASHDB.AddInParameter(DbCommand, "Assort_Paymenttermforpermanentplacementsignof", DbType.String, Convert.ToString(request.Assort_Paymenttermforpermanentplacementsignof));
                    DASHDB.AddInParameter(DbCommand, "Assort_Reasonforchangeisuue", DbType.String, Convert.ToString(request.Assort_Reasonforchangeisuue));

                    DASHDB.AddInParameter(DbCommand, "Assort_StartContractDate", DbType.String, Convert.ToString(request.Assort_StartContractDate));
                    DASHDB.AddInParameter(DbCommand, "Assort_Temporarystaffing", DbType.String, Convert.ToString(request.Assort_Temporarystaffing));
                    DASHDB.AddInParameter(DbCommand, "Assort_TotalstafftooutsourceRecruit", DbType.String, Convert.ToString(request.Assort_TotalstafftooutsourceRecruit));
                    DASHDB.AddInParameter(DbCommand, "Assort_TotalstafftooutsourceOutsource", DbType.String, Convert.ToString(request.Assort_TotalstafftooutsourceOutsource));


                    DASHDB.AddInParameter(DbCommand, "industry", DbType.String, Convert.ToString(request.industry));
                    DASHDB.AddInParameter(DbCommand, "turn_over", DbType.String, Convert.ToString(request.turn_over));
                    DASHDB.AddInParameter(DbCommand, "client_website", DbType.String, Convert.ToString(request.client_website));
                    DASHDB.AddInParameter(DbCommand, "client_linkedin", DbType.String, Convert.ToString(request.client_linkedin));
                    DASHDB.AddInParameter(DbCommand, "permaBuiseness13", DbType.String, Convert.ToString(request.permaBuiseness13));
                    DASHDB.AddInParameter(DbCommand, "replacement_period", DbType.String, Convert.ToString(request.replacement_period));
                    DASHDB.AddInParameter(DbCommand, "terms_of_payment_forSharing", DbType.String, Convert.ToString(request.terms_of_payment_forSharing));
                    DASHDB.AddInParameter(DbCommand, "cash_and_carry", DbType.String, Convert.ToString(request.cash_and_carry));
                    DASHDB.AddInParameter(DbCommand, "upfront", DbType.String, Convert.ToString(request.upfront));
                    DASHDB.AddInParameter(DbCommand, "complince", DbType.String, Convert.ToString(request.complince));


                    DASHDB.AddInParameter(DbCommand, "Assort_ClientContactPersonName", DbType.String, Convert.ToString(request.Assort_ClientContactPersonName));
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientEmail", DbType.String, Convert.ToString(request.Assort_ClientEmail));
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientPNumber", DbType.String, Convert.ToString(request.Assort_ClientPNumber));
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientManagerName", DbType.String, Convert.ToString(request.Assort_ClientManagerName));
                    //RM ID
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientContactID", DbType.String, Convert.ToString(request.Assort_ClientContactID));
                    DASHDB.AddInParameter(DbCommand, "ClientagrementUrl", DbType.String, Convert.ToString(""));


                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }



        public DataSet ActDeactOperClient(string ClID, string Status)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_ACTDEACTOPERCLIENT))
                {

                    DASHDB.AddInParameter(DbCommand, "ClID", DbType.String, Convert.ToString(ClID));
                    DASHDB.AddInParameter(DbCommand, "Status", DbType.String, Convert.ToString(Status));


                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet DeleteJob(string JobID)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_DELETEJOB))
                {

                    DASHDB.AddInParameter(DbCommand, "JobID", DbType.String, Convert.ToString(JobID));



                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet AddUpdateTemporaryStaffing(TemporaryStaffing request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_INSERTTEMPORARYSTAFFING))
                {

                    DASHDB.AddInParameter(DbCommand, "TempporaryID", DbType.String, Convert.ToString(request.TempporaryID));
                    DASHDB.AddInParameter(DbCommand, "Assort_ClientID", DbType.String, Convert.ToString(request.Assort_ClientID));
                    DASHDB.AddInParameter(DbCommand, "staffID", DbType.String, Convert.ToString(request.staffID));
                    DASHDB.AddInParameter(DbCommand, "FirstName", DbType.String, Convert.ToString(request.FirstName));
                    DASHDB.AddInParameter(DbCommand, "LastName", DbType.String, Convert.ToString(request.LastName));
                    DASHDB.AddInParameter(DbCommand, "Gender", DbType.String, Convert.ToString(request.Gender));
                    DASHDB.AddInParameter(DbCommand, "DOJ", DbType.String, Convert.ToString(request.DOJ));
                    DASHDB.AddInParameter(DbCommand, "Reporting_Manager", DbType.String, Convert.ToString(request.Reporting_Manager));
                    DASHDB.AddInParameter(DbCommand, "Salaried", DbType.String, Convert.ToString(request.Salaried));
                    DASHDB.AddInParameter(DbCommand, "Costcenter", DbType.String, Convert.ToString(request.Costcenter));
                    DASHDB.AddInParameter(DbCommand, "Unitcode", DbType.String, Convert.ToString(request.Unitcode));
                    DASHDB.AddInParameter(DbCommand, "Permanent_Address1", DbType.String, Convert.ToString(request.Permanent_Address1));
                    DASHDB.AddInParameter(DbCommand, "Permanent_Address_Citycode", DbType.String, Convert.ToString(request.Permanent_Address_Citycode));
                    DASHDB.AddInParameter(DbCommand, "Permanent_Address_Zipcode", DbType.String, Convert.ToString(request.Permanent_Address_Zipcode));
                    DASHDB.AddInParameter(DbCommand, "PFNo", DbType.String, Convert.ToString(request.PFNo));
                    DASHDB.AddInParameter(DbCommand, "PFLimit", DbType.String, Convert.ToString(request.PFLimit));
                    DASHDB.AddInParameter(DbCommand, "Pan_No", DbType.String, Convert.ToString(request.Pan_No));
                    DASHDB.AddInParameter(DbCommand, "Email", DbType.String, Convert.ToString(request.Email));
                    DASHDB.AddInParameter(DbCommand, "Mob_No", DbType.String, Convert.ToString(request.Mob_No));
                    DASHDB.AddInParameter(DbCommand, "Settlement_Date", DbType.String, Convert.ToString(request.Settlement_Date));
                    DASHDB.AddInParameter(DbCommand, "Project_income_till_date", DbType.String, Convert.ToString(request.Project_income_till_date));
                    DASHDB.AddInParameter(DbCommand, "Passport_No", DbType.String, Convert.ToString(request.Passport_No));
                    DASHDB.AddInParameter(DbCommand, "Passport_Issue_Office", DbType.String, Convert.ToString(request.Passport_Issue_Office));
                    DASHDB.AddInParameter(DbCommand, "Passport_Issue_Date", DbType.String, Convert.ToString(request.Passport_Issue_Date));
                    DASHDB.AddInParameter(DbCommand, "Passport_Expiry_Date", DbType.String, Convert.ToString(request.Passport_Expiry_Date));
                    DASHDB.AddInParameter(DbCommand, "Contract_SDate", DbType.String, Convert.ToString(request.Contract_SDate));
                    DASHDB.AddInParameter(DbCommand, "Contract_EDate", DbType.String, Convert.ToString(request.Contract_EDate));
                    DASHDB.AddInParameter(DbCommand, "Emergency_Contact1_Name", DbType.String, Convert.ToString(request.Emergency_Contact1_Name));
                    DASHDB.AddInParameter(DbCommand, "Emergency_Contact1_Relation", DbType.String, Convert.ToString(request.Emergency_Contact1_Relation));
                    DASHDB.AddInParameter(DbCommand, "Emergency_Contact1_Address", DbType.String, Convert.ToString(request.Emergency_Contact1_Address));
                    DASHDB.AddInParameter(DbCommand, "Emergency_Contact1_Mobile_No", DbType.String, Convert.ToString(request.Emergency_Contact1_Mobile_No));
                    DASHDB.AddInParameter(DbCommand, "Confirm_Status", DbType.String, Convert.ToString(request.Confirm_Status));
                    DASHDB.AddInParameter(DbCommand, "Bonus_Coverage", DbType.String, Convert.ToString(request.Bonus_Coverage));
                    DASHDB.AddInParameter(DbCommand, "BloodGroup_Code", DbType.String, Convert.ToString(request.BloodGroup_Code));


                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }

        public DataSet CreateUpdateIssue(Issue request)
        {
            int x = Globals.GlobalIntID;
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_CREATEUPDATEISSUE))
                {
                    Globals.SetGlobalIntID(x + 1);
                    long alwaysIncrementeduniqueNum = Globals.GlobalIntID;

                    string UUID = "ASS:" + alwaysIncrementeduniqueNum + "/" + dateAndTime.ToString("dd/MM/yyyy");


                    DASHDB.AddInParameter(DbCommand, "IssueID", DbType.String, UUID);
                    DASHDB.AddInParameter(DbCommand, "IssuedTo", DbType.String, Convert.ToString(request.IssuedTo));
                    DASHDB.AddInParameter(DbCommand, "ClientID", DbType.String, Convert.ToString(request.ClientID));
                    DASHDB.AddInParameter(DbCommand, "IssueSubject", DbType.String, Convert.ToString(request.IssueSubject));
                    DASHDB.AddInParameter(DbCommand, "IssueBody", DbType.String, Convert.ToString(request.IssueBody));
                    DASHDB.AddInParameter(DbCommand, "IssueAttachmentUrl", DbType.String, Convert.ToString(request.IssueAttachmentUrl));
                    DASHDB.AddInParameter(DbCommand, "IssuState", DbType.String, Convert.ToString(request.IssuState));
                    DASHDB.AddInParameter(DbCommand, "IsReminder", DbType.String, Convert.ToString(request.IsReminder));
                    DASHDB.AddInParameter(DbCommand, "EventType", DbType.String, Convert.ToString(request.EventType));


                    DSet = DASHDB.ExecuteDataSet(DbCommand);
                    bool isSentEmail = sendEmail(request.IssuedTo, request.ClientEmailID, request.IssueSubject, request.IssueBody, request.IssuState, UUID);
                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }

        public DataSet CreateUpdateIssueFromEmailReply(Issue request)
        {
            int x = Globals.GlobalIntID;
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_CREATEISSUEFROMEMAILRE))
                {


                    DASHDB.AddInParameter(DbCommand, "IssueSubject", DbType.String, Convert.ToString(request.IssueSubject));
                    DASHDB.AddInParameter(DbCommand, "IssueBody", DbType.String, Convert.ToString(request.IssueBody));
                    DASHDB.AddInParameter(DbCommand, "EmailMessageID", DbType.String, Convert.ToString(request.RepEmailID));
                    DASHDB.AddInParameter(DbCommand, "NewEmailMessageID", DbType.String, Convert.ToString(request.EmailID));
                    DASHDB.AddInParameter(DbCommand, "IssueFrom", DbType.String, Convert.ToString(request.ClientEmail));
                    DSet = DASHDB.ExecuteDataSet(DbCommand);


                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet CreateUpdateIssueFromEmail(Issue request)
        {

            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_CREATEUPDATEISSUEFROMEMAIL))
                {

                    DASHDB.AddInParameter(DbCommand, "IssueID", DbType.String, Convert.ToString(request.UUID));
                    DASHDB.AddInParameter(DbCommand, "IssuedTo", DbType.String, Convert.ToString(request.IssuedTo));
                    DASHDB.AddInParameter(DbCommand, "ClientID", DbType.String, Convert.ToString(request.ClientID));
                    DASHDB.AddInParameter(DbCommand, "IssueSubject", DbType.String, Convert.ToString(request.IssueSubject));
                    DASHDB.AddInParameter(DbCommand, "IssueBody", DbType.String, Convert.ToString(request.IssueBody));
                    DASHDB.AddInParameter(DbCommand, "IssueAttachmentUrl", DbType.String, Convert.ToString(request.IssueAttachmentUrl));
                    DASHDB.AddInParameter(DbCommand, "IssuState", DbType.String, Convert.ToString(request.IssuState));
                    DASHDB.AddInParameter(DbCommand, "IsReminder", DbType.String, Convert.ToString(request.IsReminder));
                    DASHDB.AddInParameter(DbCommand, "EventType", DbType.String, Convert.ToString(request.EventType));
                    DASHDB.AddInParameter(DbCommand, "ReciveDate", DbType.String, Convert.ToString(request.ReciveDate));
                    DASHDB.AddInParameter(DbCommand, "IssueFrom", DbType.String, Convert.ToString(request.ClientEmail));
                    DASHDB.AddInParameter(DbCommand, "EmailMessageID", DbType.String, Convert.ToString(request.EmailID));
                    DSet = DASHDB.ExecuteDataSet(DbCommand);
                    if (DSet.Tables.Count > 0)
                    {
                        bool isSentEmail = sendEmail(request.IssuedTo, request.ClientEmail, request.IssueSubject, request.IssueBody, request.IssuState, request.UUID);
                        // bool isSendEmail1 = sendEmail(request.ClientEmail, request.ClientEmailID, request.IssueSubject, request.IssueBody, request.IssuState, UUID);
                    }

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public bool sendEmail(string to, string cc, string subject, string body, string state, string UUID)
        {
            // string Body = "<table style='width:100%'><tr><td align='center'><img src='http://dev.assortstaffing.com/img/logo5.png'></td></tr><tr><td><table><tr><td><img src='https://www.google.co.in/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwjCusfk5Y7WAhWB6Y8KHSghAZcQjRwIBw&url=http%3A%2F%2Fmedren.aas.duke.edu%2Fjmems%2F&psig=AFQjCNHQfrYy8ZRJJ6Q7H5_fIhTFZswtMQ&ust=1504726656197480'></td><td>" + body + "</td></tr></table></td></tr><tr><td align='center'>Office No-202, 17 A, 1st floor, Mehta Estate, Opp Chintamani Plaza,Chakala, Andheri -Kurla Road,Andheri East ,Mumbai -400093,Maharashtra Board Line No.: 022 - 49213100 </td></tr></table>";


            using (var mail = new MailMessage("support-info@assortstaffing.com", to))
            {

                string body1 = string.Empty;

                string sb = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\">" +
"    <tr>" +
"        <td></td>" +
"        <td bgcolor=\"#FFFFFF \">" +
"            <div style=\"padding: 15px; max-width: 600px;margin: 0 auto;display: block; border-radius: 0px;padding: 0px; border: 1px solid #e33939;\">" +
"                <table style=\"width: 100%;background: white ;\">" +
"                    <tr>" +
"                        <td></td>" +
"                        <td>" +
"                            <div>" +
"                                <table width=\"100%\">" +
"                                    <tr>" +
"                                        <td rowspan=\"2\" style=\"text-align:center;padding:10px;\"> <img style=\"float:left;width:150px \" src=\"http://assortstaffing.com/img/logo5.png\" /> </td>" +
"                                    </tr>" +
"                                </table>" +
"                            </div>" +
"                        </td>" +
"                        <td></td>" +
"                    </tr>" +
"                </table>" +
"                <table style=\"padding: 10px;font-size:14px; width:100%;\">" +
"                    <tr>" +
"                        <td style=\"padding:10px;font-size:14px; width:100%;\">" +
"                            <p>Dear Sir/Madam,</p>" +
"                            <p><br /> Your Escalation For \" [Email_Subject] \" had been ended , your Escalation id is '[uniqueID]' .Our Support team has resolved issue. Kindly help us to know that your issue has been resolved or not by selecting the below option. Please select one to confirm </p>" +
"                            <p> </p>" +
"                        </td>" +
"                    </tr>" +
"                    <tr>" +
"                        <td style=\"padding:10px;font-size:14px; width:50%;\">" +
"                            <table style=\"background:red;height: 45px;padding: 10px;font-size: 16px;font-family: cursive;color: white;border-radius: 4px;\">" +
"                                <tr style=\"width:100%\">" +
"                                    <td style=\"width:100%\">" +
"                                        Issue has been resolved ?" +
"                                    </td>" +
"                                </tr>" +
"                            </table>" +
"                            <table>" +
"                                <tr style=\"width:100%\">" +
"                                    <td style=\"width:80%\">" +
"                                        <a href=\"http://assortstaffing.com/review.html?status=yes&email=[email]&id=[uid]\" style=\"font-size:16px; font-weight: bold; font-family: Helvetica, Arial, sans-serif; text-decoration: none; line-height:40px;display:inline-block;padding: 4px;border-radius: 4px;\">" +
"                                            <span style=\"color: #e54545\">" +
"                            Yes</span></a>" +
"                                    </td>" +
"                                    <td>" +
"                                        <a href=\"http://assortstaffing.com/review.html?status=no&email=[email]&id=[uid]\" style=\"font-size:16px; font-weight: bold; font-family: Helvetica, Arial, sans-serif; text-decoration: none; line-height:40px;; display:inline-block;padding: 4px;border-radius: 4px;\">" +
"                                            <span style=\"color: #e54545\">" +
"                            No</span></a>" +
"                                    </td>" +
"                                </tr>" +
"                            </table>" +
"                        </td>" +
"                    </tr>" +
"                    <tr>" +
"                        <td style=\"padding:10px;font-size:14px; width:100%;\">" +
"                            <p>Thanks for choosing Assortstaffing,</p>" +
"                            <p>Assort Staffing Team.</p>" +
"                        </td>" +
"                    </tr>" +
"                    <tr>" +
"                        <td>" +
"                            <div align=\"center\" style=\"font-size:12px; margin-top:20px; padding:5px; width:100%; background:#eee;\"> © [Year] <a href=\"http://assortstaffing.com\" target=\"_blank\" style=\"color:#333; text-decoration: none;\">assortstaffing.com</a> </div>" +
"                        </td>" +
"                    </tr>" +
"                </table>";

                if (state == "END" || state == "IN REVIEW")
                {
                    body = sb;
                    body = body.Replace("[Email_Subject]", subject);
                    body = body.Replace("[email]", cc);
                    body = body.Replace("[uid]", UUID);
                    body = body.Replace("[uniqueID]", UUID);
                    body = body.Replace("[Year]", Convert.ToString(DateTime.Now.Year));
                    mail.Subject = subject + "(" + state + ")";
                    mail.Body = body;
                    mail.To.Add(cc);
                    mail.IsBodyHtml = true;
                    var smtp = new SmtpClient();
                    smtp.Host = "mail.assortstaffing.com";
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("support-info@assortstaffing.com", "*viO928t");
                    smtp.Port = 25;
                    smtp.Send(mail);
                    return true;
                }
                else
                {
                    body = "<table style=\"width: 100%;\">        <tr>            <td></td>            <td bgcolor=\"#FFFFFF \">                <div style=\"padding: 15px; max-width: 600px;margin: 0 auto;display: block; border-radius: 0px;padding: 0px; border: 1px solid #e33939;\">                    <table style=\"width: 100%;background: white ;\">                        <tr>                            <td></td>                            <td>                                <div>                                    <table width=\"100%\">                                        <tr>                                            <td rowspan=\"2\" style=\"text-align:center;padding:10px;\">                                                <img style=\"float:left;width:150px \" src=\"http://assortstaffing.com/img/logo5.png\" />                                            </td>                                        </tr>                                    </table>                                </div>                            </td>                            <td></td>                        </tr>                    </table>                    <table style=\"padding: 10px;font-size:14px; width:100%;\">                        <tr>                            <td style=\"padding:10px;font-size:14px; width:100%;\">                                <p>Dear Sir/Madam,</p>                                <p><br />                                    Your Escalation For \" [Email_Subject] \" is in process , your Escalation id is '[uniqueID]' .Our Support team is working to resolve the issue.                                                                 </p>                                <p> </p>                                <p>Thanks for choosing Assortstaffing,</p>                                <p>Assort Staffing Team.</p>                            </td>                        </tr>                        <tr>                            <td>                                <div align=\"center\" style=\"font-size:12px; margin-top:20px; padding:5px; width:100%; background:#eee;\">                                    © [Year] <a href=\"http://assortstaffing.com\" target=\"_blank\" style=\"color:#333; text-decoration: none;\">assortstaffing.com</a>                                </div>                            </td>                        </tr>                    </table> ";
                    body = body.Replace("[Email_Subject]", subject);
                    body = body.Replace("[uniqueID]", UUID);
                    body = body.Replace("[Year]", Convert.ToString(DateTime.Now.Year));
                    mail.Subject = subject + "(" + state + ")";
                    mail.Body = body;
                    string[] items = cc.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] items1 = to.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string value in items)
                    {
                        mail.CC.Add(value);
                    }
                    foreach (string value in items1)
                    {
                        mail.Bcc.Add(value);
                    }
                    mail.IsBodyHtml = true;
                    var smtp = new SmtpClient();
                    smtp.Host = "mail.assortstaffing.com";
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("support-info@assortstaffing.com", "*viO928t");
                    smtp.Port = 25;
                    smtp.Send(mail);
                    return true;
                }




            }
        }

        public DataSet AssignUClient(AssignUClient request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_ASSIGNUTOCLINET))
                {


                    DASHDB.AddInParameter(DbCommand, "UserID", DbType.String, Convert.ToString(request.UserID));
                    DASHDB.AddInParameter(DbCommand, "ClientID", DbType.String, Convert.ToString(request.ClientID));
                    DASHDB.AddInParameter(DbCommand, "JobID", DbType.String, Convert.ToString(request.JobID));


                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet UserDetailsUpDateDB(ULogin request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_USERPROFILEUPDATE))
                {

                    DASHDB.AddInParameter(DbCommand, DBConstants.UR_FIRST_NAME, DbType.String, Convert.ToString(request.FName));
                    DASHDB.AddInParameter(DbCommand, DBConstants.UR_LAST_NAME, DbType.String, Convert.ToString(request.LName));
                    DASHDB.AddInParameter(DbCommand, DBConstants.UR_MOBILE, DbType.String, Convert.ToString(request.MobileNo));
                    DASHDB.AddInParameter(DbCommand, "ResumeUrl", DbType.String, Convert.ToString(request.ResumeUrl));
                    DASHDB.AddInParameter(DbCommand, "JobHeader", DbType.String, Convert.ToString(request.JobHeader));
                    DASHDB.AddInParameter(DbCommand, "Gender", DbType.String, Convert.ToString(request.Gender));
                    DASHDB.AddInParameter(DbCommand, "UR_ID", DbType.String, Convert.ToString(request.UR_ID));
                    DASHDB.AddInParameter(DbCommand, "DOB", DbType.String, Convert.ToString(request.DOB));
                    DASHDB.AddInParameter(DbCommand, "present_location", DbType.String, Convert.ToString(request.present_location));
                    DASHDB.AddInParameter(DbCommand, "experience", DbType.String, Convert.ToString(request.experience));
                    DASHDB.AddInParameter(DbCommand, "expected_ctc", DbType.String, Convert.ToString(request.expected_ctc));
                    DASHDB.AddInParameter(DbCommand, "skills", DbType.String, Convert.ToString(request.skills));


                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }


        public DataTable GetCompanyList()
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETCOMPANY))
                {
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetLocationList()
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETLOCATION))
                {
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }

        public DataSet AddOtherDetails(AddOtherDetails request)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_CREATEUPDATEOTHER))
                {
                    DASHDB.AddInParameter(DbCommand, "ID", DbType.String, Convert.ToString(request.ID));
                    DASHDB.AddInParameter(DbCommand, "NoOfEmpl", DbType.String, Convert.ToString(request.NoOfEmpl));
                    DASHDB.AddInParameter(DbCommand, "Location", DbType.String, Convert.ToString(request.Location));
                    DASHDB.AddInParameter(DbCommand, "NoOfEmplPF_ESIC", DbType.String, Convert.ToString(request.NoOfEmplPF_ESIC));
                    DASHDB.AddInParameter(DbCommand, "HealthRpt", DbType.String, Convert.ToString(request.HealthRpt));
                    DASHDB.AddInParameter(DbCommand, "Exits", DbType.String, Convert.ToString(request.Exits));
                    DASHDB.AddInParameter(DbCommand, "CLRA_Status", DbType.String, Convert.ToString(request.CLRA_Status));
                    DASHDB.AddInParameter(DbCommand, "open_positions_share", DbType.String, Convert.ToString(request.open_positions_share));
                    DASHDB.AddInParameter(DbCommand, "Joinees", DbType.String, Convert.ToString(request.Joinees));
                    DASHDB.AddInParameter(DbCommand, "Invoices", DbType.String, Convert.ToString(request.Invoices));
                    DASHDB.AddInParameter(DbCommand, "Agreements_Dates", DbType.String, Convert.ToString(request.Agreements_Dates));


                    DSet = DASHDB.ExecuteDataSet(DbCommand);

                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }

        public DataTable GetOtherDetails(string ID)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETOTHERDETAILS))
                {
                    DB.AddInParameter(DBCommand, "ID", DbType.String, Convert.ToString(ID));
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetDashBoard(string ID, string Type)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETDASHBOARD))
                {
                    DB.AddInParameter(DBCommand, "ID", DbType.String, Convert.ToString(ID));
                    DB.AddInParameter(DBCommand, "Type", DbType.String, Convert.ToString(Type));
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }

        public DataTable GetCardClient(string ClientID)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETCLIENTCARDSDETAILS))
                {
                    DB.AddInParameter(DBCommand, "ClientID", DbType.String, Convert.ToString(ClientID));
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetDocsList(string ClientID)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETDOCSLIST))
                {
                    DB.AddInParameter(DBCommand, "Clientid", DbType.String, Convert.ToString(ClientID));
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetIssueViaRmList(string Rm_ID)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETISSUERMVIAIDLIST))
                {
                    DB.AddInParameter(DBCommand, "RmID", DbType.String, Convert.ToString(Rm_ID));
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetIssueViaRm(string Rm_ID)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETISSUERMVIAID))
                {
                    DB.AddInParameter(DBCommand, "RmID", DbType.String, Convert.ToString(Rm_ID));
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }

        public DataTable GetIssueByClient(string ClientID)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETISSUEBYCLIENT))
                {
                    DB.AddInParameter(DBCommand, "ClientID", DbType.String, Convert.ToString(ClientID));
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetIssueRep(EmailRep EmailID)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETISSUEREMEMAIL))
                {
                    DB.AddInParameter(DBCommand, "EmailID", DbType.String, Convert.ToString(EmailID.EmailID));
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetIssue(string IssueID)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETISSUE))
                {
                    DB.AddInParameter(DBCommand, "IssueID", DbType.String, Convert.ToString(IssueID));
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetUserList()
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETUSER))
                {
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }

        public DataSet GetJobListsByID(string JobID)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETJOBSLISTBYID))
                {

                    DB.AddInParameter(DBCommand, "JobID", DbType.String, JobID);
                    DSet = DB.ExecuteDataSet(DBCommand);
                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }

        public DataSet GetShortlitedCandidateList()
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_LISTSHORTLISTEDCANDIDATE))
                {

                    DSet = DB.ExecuteDataSet(DBCommand);
                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet GetAppliedJobListsByID(string JobID)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_LISTAPPLYJOBCANDIDATE))
                {

                    DB.AddInParameter(DBCommand, "JobID", DbType.String, JobID);
                    DSet = DB.ExecuteDataSet(DBCommand);
                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }


        public DataSet GetJobAutoComplete(string LikeData, string SearchData)
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();
                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_GETDATAJOBLIKE))
                {
                    DASHDB.AddInParameter(DbCommand, "LikeData", DbType.String, Convert.ToString(LikeData));
                    DASHDB.AddInParameter(DbCommand, "SearchData", DbType.String, Convert.ToString(SearchData));
                    DSet = DASHDB.ExecuteDataSet(DbCommand);
                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }
        public DataSet GetJobLists()
        {
            DataSet DSet = new DataSet();

            try
            {
                DataTable DtRegistartion = new DataTable();

                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_GETJOBSLIST))
                {

                    DSet = DASHDB.ExecuteDataSet(DbCommand);
                }
            }
            catch (Exception EX)
            {

            }
            return DSet;
        }


        public DataTable GetClientList(string ClientID)
        {

            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DASHDB = new SqlDatabase(DBConnection.GetDBConnection());
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());

                using (DbCommand DbCommand = DASHDB.GetStoredProcCommand(DBConstants.SP_GETCLIENTLIST))
                {
                    DASHDB.AddInParameter(DbCommand, "ClientID", DbType.String, Convert.ToString(ClientID));
                    DataSet DSet = DB.ExecuteDataSet(DbCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetIndustryList()
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETINDUSTRY))
                {
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }


        public DataTable GetRelationshipManager(string Rm_ID)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETRM))
                {
                    DB.AddInParameter(DBCommand, "RMID", DbType.String, Convert.ToString(Rm_ID));
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }

        public DataTable GetJobClientList(string ClientID)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETJOBSCLIENTLIST))
                {
                    DB.AddInParameter(DBCommand, "ClientID", DbType.String, ClientID);
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetSkillsNameList()
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETSKILLSNAME))
                {
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetSkillsCategoryList()
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETSKILLSCATEGORY))
                {
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }


        public DataTable GetRmEmailViaDep(string Dep)
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETRMDEP))
                {
                    DB.AddInParameter(DBCommand, "Dep", DbType.String, Dep);
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }
        public DataTable GetIssueDetails()
        {
            DataTable dt_UserList = new DataTable();
            try
            {
                SqlDatabase DB = new SqlDatabase(DBConnection.GetDBConnection());
                using (DbCommand DBCommand = DB.GetStoredProcCommand(DBConstants.SP_GETESCALATIONDETAILS))
                {
                    DataSet DSet = DB.ExecuteDataSet(DBCommand);
                    if (DSet.Tables.Count > 0)
                        dt_UserList = DSet.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {

            }

            return dt_UserList;
        }

    }
}
