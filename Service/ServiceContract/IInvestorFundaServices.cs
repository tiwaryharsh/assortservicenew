using ServiceDTO;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using static ServiceDTO.InvestFunda;

namespace Service
{


    [ServiceContract]
    public interface IInvestorFundaServices
    {


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Login/{UEmail}/{password}/{Type}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<ULogin> GetLogin(string UEmail, string password, string Type);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetUserDetailsByID/{UserID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<ULogin> GetUserDetailsByID(string UserID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UpdateUserDetails", Method = "POST", ResponseFormat = WebMessageFormat.Json)]

        Response<string> UpdateUserDetails(ULogin request);



        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AssignUClient", Method = "POST", ResponseFormat = WebMessageFormat.Json)]

        Response<string> AssignUClient(AssignUClient request);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "DeleteJob/{jobID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<string> DeleteJob(string jobID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ActDeactOperClient/{ClID}/{Status}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<string> ActDeactOperClient(string ClID, string Status);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CreateUpdateIssu", Method = "POST", ResponseFormat = WebMessageFormat.Json)]

        Response<string> CreateUpdateIssue(Issue request);




        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CreateUpdateIssueWidthEmail", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<string> CreateUpdateIssueWidthEmail();

        //[OperationContract]
        //[WebGet(UriTemplate = "CreateUpdateIssueWidthEmail/{request}",
        //   RequestFormat = WebMessageFormat.Json,
        //   ResponseFormat = WebMessageFormat.Json)]
        // Response<string> CreateUpdateIssueWidthEmail(string request);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetIssue/{IssueID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<Issue>> GetIssue(string IssueID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetIssueRep", Method = "POST", ResponseFormat = WebMessageFormat.Json)]

        Response<List<Issue>> GetIssueRep(EmailRep request);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetIssueByClient/{ClientID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<Issue>> GetIssueByClient(string ClientID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AddUpdateTemporaryStaffing", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> AddUpdateTemporaryStaffing(TemporaryStaffing request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetLocation", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<Location>> GetLocation();


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCompany", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<Location>> GetCompany();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetUserList", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<ULogin>> GetUserList();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetJobList", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<GetJobs> GetJobList();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetIssueList", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<GetIssueDetails> GetIssueList();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetJobAutoComplete/{LikeData}/{SearchData}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<GetJobs> GetJobAutoComplete(string LikeData, string SearchData);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetJobClientList/{ClientID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<List<JobList>> GetJobClientList(string ClientID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetJobListByID/{JobID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<GetJobs> GetJobListByID(string JobID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAppliedJobListByID/{JobID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<GetAppliedJobsList> GetAppliedJobListByID(string JobID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ShortlitedCandidateList", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<GetAppliedJobsList> ShortlitedCandidateList();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetSkillsCategory", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<SkillsCategory>> GetSkillsCategory();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetSkillsName", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<SkillsName>> GetSkillsName();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetIndustryList", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<IndustryLists>> GetIndustryList();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "InsertShortListedCandidate", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> InsertShortListedCandidate(List<ShortlistedCandidate> ShortlistedCandidate);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UpdatePassword/{UEmail}/{password}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<ULogin> UpdatePassworduser(string UEmail, string password);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Forgotpassword/{UEmail}/{UPassword}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<string> Forgotpassword(string UEmail, string UPassword);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UserRegistration", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> UserRegistration(RegistrationData request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AddClient", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> AddClient(AddClient request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AddRelationshipManager", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> AddRelationshipManager(AddRelationshipManager request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetclientList/{ClientID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<AddClient>> GetclientList(string ClientID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetOtherDetails/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<AddOtherDetails>> GetOtherDetails(string ID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetRelationshipManager/{Rm_ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<AddRelationshipManager>> GetRelationshipManager(string Rm_ID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetIssueViaRm/{Rm_ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<Issue>> GetIssueViaRm(string Rm_ID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetDashBoard/{ID}/{Type}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<DashBoardData>> GetDashBoard(string ID, string Type);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetIssueViaRmList/{Rm_ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<Issue>> GetIssueViaRmList(string Rm_ID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetDocsList/{ClientID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<GetDocsListCl>> GetDocsList(string ClientID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCardClient/{ClientID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]

        Response<List<AddCardClient>> GetCardClient(string ClientID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AddLocation", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> AddLocation(AddLocation request);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AddCardClient", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> AddCardClient(AddCardClient request);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AddIndustry", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> AddIndustry(AddIndustry request);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AddOtherDetails", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> AddOtherDetails(AddOtherDetails request);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AddSkillCategoryName", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> AddSkillCategoryName(AddSkillCategoryName request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AddSkillName", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> AddSkillName(AddSkillName request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ApplyJob/{CandidateID}/{JobID}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> ApplyJob(string CandidateID, string JobID);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UpdateCandidateResume/{CandidateID}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> UpdateCandidateResume(Stream documentPath, string CandidateID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UpdateCandidateImage/{CandidateID}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> UpdateCandidateImage(Stream documentPath, string CandidateID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteRM/{RMID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        Response<string> deleteRM(string RMID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteClient/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        Response<string> deleteClient(string ID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "uploadCandidateList/{CandidateID}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> uploadCandidateList(Stream documentPath, string CandidateID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "uploadClientDocs/{ClientID}/{DocType}/{DocName}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> UpdateClientDocs(Stream documentPath, string ClientID, string DocType, string DocName);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UpdateClientAgrement/{ClientID}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> UpdateClientAgrement(Stream documentPath, string ClientID);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UpdateIssueStatus", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> UpdateIssueStatus(updateIssueStatus IssueStatus);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AddCompany", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> AddCompany(AddCompany request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CreateJob", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> CreateJob(CreateJob request);



    }
}
