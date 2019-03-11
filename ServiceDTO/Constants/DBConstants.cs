namespace ServiceDTO
{
    public class DBConstants
    {
        #region  Only Store Procedure Constants ....

        public static readonly string SP_LOGIN = "SP_Login";
        public static readonly string SP_GETUSERDETAILS = "SP_GetUserDetails";
        public static readonly string SP_GETJOBSLISTBYID = "SP_GetJobsListByID";
        public static readonly string SP_LISTAPPLYJOBCANDIDATE = "SP_ListApplyJobCandidate";
        public static readonly string SP_LISTSHORTLISTEDCANDIDATE = "SP_ListShortlistedCandidate";
        public static readonly string SP_UPDATEPASSWORD = "SP_UpdatePassword";

        public static readonly string SP_USERREGISTRATION = "SP_UserRegistration";
        public static readonly string SP_INSERTCLIENT = "SP_InsertClient";
        public static readonly string SP_FORGOTPASSWORD = "SP_ForgotPassword";
        public static readonly string SP_INSERTRM = "SP_InsertRM";
        public static readonly string SP_USERPROFILEUPDATE = "SP_UserProfileUpdate";
        public static readonly string SP_ASSIGNUTOCLINET = "SP_AssignUToClinet";
        public static readonly string SP_CREATEUPDATEISSUE = "SP_CreateUpdateIssue";
        public static readonly string SP_CREATEISSUEFROMEMAILRE = "SP_CreateIssueFromEmailRe";
        public static readonly string SP_CREATEUPDATEISSUEFROMEMAIL = "SP_CreateUpdateIssueFromEmail";
        public static readonly string SP_INSERTTEMPORARYSTAFFING = "SP_InserttemporaryStaffing";
        public static readonly string SP_DELETEJOB = "SP_DeleteJob";
        public static readonly string SP_ACTDEACTOPERCLIENT = "SP_ActDeactOperClient";
        public static readonly string SP_CREATEJOB = "SP_CreateJob";
        public static readonly string SP_INSERTSHORTLISTED = "SP_InsertShortlisted";
        public static readonly string SP_ADDLOCATION = "SP_AddLocation";
        public static readonly string SP_ADDCLIENTCARD = "SP_AddClientCard";
        public static readonly string SP_ADDINDUSTRY = "SP_AddIndustry";
        public static readonly string SP_CREATEUPDATEOTHER = "SP_CreateUpdateOther";
        public static readonly string SP_GETOTHERDETAILS = "SP_GetOtherDetails";
        public static readonly string SP_ADDMASTER_SKILLSCATEGORY = "SP_AddMaster_SkillsCategory";
        public static readonly string SP_ADDMASTER_SKILLSNAME = "SP_AddMaster_SkillsName";
        public static readonly string SP_APPLYJOB = "SP_ApplyJob";
        public static readonly string SP_UPDATEISSUESTATUS = "SP_UpdateIssueStatus";

        public static readonly string SP_UPDATEPROFILEIMAGE = "SP_UpdateProfileImage";
        public static readonly string SP_UPDATERESUME = "SP_UpdateResume";
        public static readonly string SP_CLIENTDOCS = "SP_ClientDocs";
        public static readonly string SP_UPDATECLIENTAGREMENT = "SP_UpdateClientAgrement";
        public static readonly string SP_ADDCOMPANY = "SP_AddCompany";
        public static readonly string SP_DELETERM = "SP_DeleteRM";
        public static readonly string SP_DELETECLIENT = "SP_DeleteClient";
        public static readonly string SP_GETLOCATION = "SP_GetLocation";
        public static readonly string SP_GETCOMPANY = "SP_GetCompany";
        public static readonly string SP_GETUSER = "SP_GetUser";
        public static readonly string SP_GETISSUE = "SP_GetIssue";
        public static readonly string SP_GETISSUEREMEMAIL = "SP_GetIssueRemEmail";
        public static readonly string SP_GETISSUEBYCLIENT = "SP_GetIssueByClient";
        public static readonly string SP_GETISSUERMVIAID = "SP_GetIssueRmViaID";
        public static readonly string SP_GETISSUERMVIAIDLIST = "SP_GetIssueRmViaIDList";
        public static readonly string SP_GETDOCSLIST = "SP_GetDocsList";
        public static readonly string SP_GETCLIENTCARDSDETAILS = "SP_GetClientCardsDetails";
        public static readonly string SP_GETSKILLSCATEGORY = "SP_GetSkillsCategory";

        public static readonly string SP_GETRMDEP = "SP_GetRmDep";
        public static readonly string SP_GETESCALATIONDETAILS = "SP_GetescalationDetails";
        public static readonly string SP_GETSKILLSNAME = "SP_GetSkillsName";
        public static readonly string SP_GETJOBSCLIENTLIST = "SP_GetJobsClientList";
        public static readonly string SP_GETRM = "SP_GetRM";
        public static readonly string SP_GETDASHBOARD = "SP_GetDashBoard";
        public static readonly string SP_GETINDUSTRY = "SP_GetIndustry";
        public static readonly string SP_GETCLIENTLIST = "SP_GetClientList";
        public static readonly string SP_GETJOBSLIST = "SP_GetJobsList";
        public static readonly string SP_GETDATAJOBLIKE = "SP_GetDatajobLike";
        #endregion


        #region  Other Variable

        public static readonly string UR_FIRST_NAME = "UR_First_Name";
        public static readonly string UR_LAST_NAME = "UR_Last_Name";
        public static readonly string UR_EMAIL = "UR_Email";
        public static readonly string UR_MOBILE = "UR_Mobile";
        public static readonly string UR_PASSWORD = "Password";


        //Login
        public static readonly string FName = "FName";
        public static readonly string LName = "LName";
        public static readonly string EmailID = "EmailID";

        public static readonly string UEMAIL = "UEmail";
        public static readonly string UPASSWORD = "UPassword";



        #endregion

    }
}
