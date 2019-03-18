using ServiceDataAccessLayer;
using ServiceDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Caching;
using static ServiceDTO.InvestFunda;


namespace ServiceBusinessLayer
{
    public class businessLayer
    {
        private static CacheItemRemovedCallback OnCacheRemove = null;

        protected void Application_Start(object sender, EventArgs e)
        {
            AddTask("DoStuff", 60);
        }

        private void AddTask(string name, int seconds)
        {
            OnCacheRemove = new CacheItemRemovedCallback(CacheItemRemoved);
            HttpRuntime.Cache.Insert(name, seconds, null,
                DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable, OnCacheRemove);
        }

        public void CacheItemRemoved(string k, object v, CacheItemRemovedReason r)
        {
            // do stuff here if it matches our taskname, like WebRequest
            // re-add our task so it recurs
            AddTask(k, Convert.ToInt32(v));
        }
        public ULogin Login(string UEmail, string password, string Type)
        {
            DataSet Dset = new DataSet();
            ULogin response = new ULogin();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {
                Dset = dataAcessLayer.GetLogin(UEmail, password, Type);
                if (Dset.Tables[0].Rows.Count > 0)
                {
                    response.EmailID = (Dset.Tables[0].Rows[0]["EmailID"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["EmailID"]);
                    response.FName = (Dset.Tables[0].Rows[0]["FName"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["FName"]);
                    response.LName = (Dset.Tables[0].Rows[0]["LName"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["LName"]);
                    response.Gender = (Dset.Tables[0].Rows[0]["Gender"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["Gender"]);
                    response.DOB = (Dset.Tables[0].Rows[0]["DOB"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["DOB"]);
                    response.JobHeader = (Dset.Tables[0].Rows[0]["JobHeader"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["JobHeader"]);
                    response.MobileNo = (Dset.Tables[0].Rows[0]["MobileNo"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["MobileNo"]);
                    response.UR_ID = (Dset.Tables[0].Rows[0]["CandidateID"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["CandidateID"]);
                    response.ResumeUrl = (Dset.Tables[0].Rows[0]["ResumeUrl"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["ResumeUrl"]);
                    response.present_location = (Dset.Tables[0].Rows[0]["present_location"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["present_location"]);
                    response.experience = (Dset.Tables[0].Rows[0]["experience"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["experience"]);
                    response.expected_ctc = (Dset.Tables[0].Rows[0]["expected_ctc"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["expected_ctc"]);
                    response.skills = (Dset.Tables[0].Rows[0]["skills"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["skills"]);
                    response.Candidate_Image = (Dset.Tables[0].Rows[0]["Candidate_Image"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["Candidate_Image"]);

                }

            }
            catch (Exception EX)
            {

            }

            return response;
        }
        public ULogin GetUserDetailsByID(string UserID)
        {
            DataSet Dset = new DataSet();
            ULogin response = new ULogin();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {
                Dset = dataAcessLayer.GetUserDetailsByID(UserID);
                if (Dset.Tables[0].Rows.Count > 0)
                {
                    response.EmailID = (Dset.Tables[0].Rows[0]["EmailID"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["EmailID"]);
                    response.FName = (Dset.Tables[0].Rows[0]["FName"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["FName"]);
                    response.LName = (Dset.Tables[0].Rows[0]["LName"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["LName"]);
                    response.Gender = (Dset.Tables[0].Rows[0]["Gender"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["Gender"]);
                    response.JobHeader = (Dset.Tables[0].Rows[0]["JobHeader"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["JobHeader"]);
                    response.MobileNo = (Dset.Tables[0].Rows[0]["MobileNo"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["MobileNo"]);
                    response.UR_ID = (Dset.Tables[0].Rows[0]["CandidateID"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["CandidateID"]);
                    response.ResumeUrl = (Dset.Tables[0].Rows[0]["ResumeUrl"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["ResumeUrl"]);
                    response.present_location = (Dset.Tables[0].Rows[0]["present_location"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["present_location"]);
                    response.experience = (Dset.Tables[0].Rows[0]["experience"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["experience"]);
                    response.expected_ctc = (Dset.Tables[0].Rows[0]["expected_ctc"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["expected_ctc"]);
                    response.skills = (Dset.Tables[0].Rows[0]["skills"] is DBNull) ? String.Empty : Convert.ToString(Dset.Tables[0].Rows[0]["skills"]);


                }

            }
            catch (Exception EX)
            {

            }

            return response;
        }
        public ULogin UpdateBusinessPassword(string UEmail, string password)
        {
            DataSet Dset = new DataSet();
            ULogin response = new ULogin();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {
                Dset = dataAcessLayer.UpdatePassword(UEmail, password);
                if (Dset.Tables[0].Rows.Count > 0)
                {

                    response.FName = "Thanks for updating password";


                }

            }
            catch (Exception EX)
            {

            }

            return response;
        }
        public List<ULogin> GetBusinessUserList()
        {
            DataSet Dset = new DataSet();
            List<ULogin> getUserList = new List<ULogin>();
            ULogin response = new ULogin();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetUserList();
                if (dt_userList.Rows.Count > 0)
                {
                    getUserList = (from DataRow dr in dt_userList.Rows
                                   select new ULogin
                                   {


                                       EmailID = (dr["EmailID"] is DBNull) ? String.Empty : Convert.ToString(dr["EmailID"]),
                                       FName = (dr["FName"] is DBNull) ? String.Empty : Convert.ToString(dr["FName"]),
                                       LName = (dr["LName"] is DBNull) ? String.Empty : Convert.ToString(dr["LName"]),
                                       Gender = (dr["Gender"] is DBNull) ? String.Empty : Convert.ToString(dr["Gender"]),
                                       JobHeader = (dr["JobHeader"] is DBNull) ? String.Empty : Convert.ToString(dr["JobHeader"]),
                                       MobileNo = (dr["MobileNo"] is DBNull) ? String.Empty : Convert.ToString(dr["MobileNo"]),
                                       UR_ID = (dr["CandidateID"] is DBNull) ? String.Empty : Convert.ToString(dr["CandidateID"]),
                                       ResumeUrl = (dr["ResumeUrl"] is DBNull) ? String.Empty : Convert.ToString(dr["ResumeUrl"]),
                                       Assort_StaffID = (dr["Assort_StaffID"] is DBNull) ? String.Empty : Convert.ToString(dr["Assort_StaffID"])


                                   }).ToList();

                }
                return getUserList;


            }
            catch (Exception EX)
            {

            }

            return getUserList;
        }

        public List<DashBoardData> GetDashBoard(string ID, string Type)
        {
            DataSet Dset = new DataSet();
            List<DashBoardData> getDashboardDetails = new List<DashBoardData>();
            DashBoardData response = new DashBoardData();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetDashBoard(ID, Type);
                if (dt_userList.Rows.Count > 0)
                {
                    getDashboardDetails = (from DataRow dr in dt_userList.Rows
                                           select new DashBoardData
                                           {
                                               NoOfEscalaion = (dr["NoOfEscalaion"] is DBNull) ? string.Empty : Convert.ToString(dr["NoOfEscalaion"]).Trim(),
                                               STATES = (dr["STATES"] is DBNull) ? string.Empty : Convert.ToString(dr["STATES"]).Trim()
                                           }).ToList();

                }
                return getDashboardDetails;


            }
            catch (Exception EX)
            {

            }

            return getDashboardDetails;
        }


        public List<AddCardClient> GetCardClientBusiness(string ClientID)
        {
            DataSet Dset = new DataSet();
            List<AddCardClient> getIssueDetails = new List<AddCardClient>();
            Issue response = new Issue();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetCardClient(ClientID);
                if (dt_userList.Rows.Count > 0)
                {
                    getIssueDetails = (from DataRow dr in dt_userList.Rows
                                       select new AddCardClient
                                       {
                                           ClientID = (dr["ClientID"] is DBNull) ? string.Empty : Convert.ToString(dr["ClientID"]).Trim(),
                                           Label1 = (dr["Label1"] is DBNull) ? string.Empty : Convert.ToString(dr["Label1"]).Trim(),
                                           Text1 = (dr["Text1"] is DBNull) ? string.Empty : Convert.ToString(dr["Text1"]).Trim(),
                                           Label2 = (dr["Label2"] is DBNull) ? string.Empty : Convert.ToString(dr["Label2"]).Trim(),
                                           Text2 = (dr["Text2"] is DBNull) ? string.Empty : Convert.ToString(dr["Text2"]).Trim(),
                                           Label3 = (dr["Label3"] is DBNull) ? string.Empty : Convert.ToString(dr["Label3"]).Trim(),
                                           Text3 = (dr["Text3"] is DBNull) ? string.Empty : Convert.ToString(dr["Text3"]).Trim(),
                                           Label4 = (dr["Label4"] is DBNull) ? string.Empty : Convert.ToString(dr["Label4"]).Trim(),
                                           Text4 = (dr["Text4"] is DBNull) ? string.Empty : Convert.ToString(dr["Text4"]).Trim()


                                       }).ToList();

                }
                return getIssueDetails;


            }
            catch (Exception EX)
            {

            }

            return getIssueDetails;
        }
        public List<GetDocsListCl> GetDocsList(string ClientID)
        {
            DataSet Dset = new DataSet();
            List<GetDocsListCl> getIssueDetails = new List<GetDocsListCl>();
            Issue response = new Issue();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetDocsList(ClientID);
                if (dt_userList.Rows.Count > 0)
                {
                    getIssueDetails = (from DataRow dr in dt_userList.Rows
                                       select new GetDocsListCl
                                       {
                                           DocsID = (dr["DocsID"] is DBNull) ? string.Empty : Convert.ToString(dr["DocsID"]).Trim(),
                                           DocsType = (dr["DocsType"] is DBNull) ? string.Empty : Convert.ToString(dr["DocsType"]).Trim(),
                                           DocsUrl = (dr["DocsUrl"] is DBNull) ? string.Empty : Convert.ToString(dr["DocsUrl"]).Trim(),
                                           DocsName = (dr["DocsName"] is DBNull) ? string.Empty : Convert.ToString(dr["DocsName"]).Trim(),
                                           Clientid = (dr["Clientid"] is DBNull) ? string.Empty : Convert.ToString(dr["Clientid"]).Trim()


                                       }).ToList();

                }
                return getIssueDetails;


            }
            catch (Exception EX)
            {

            }

            return getIssueDetails;
        }
        public List<Issue> GetIssueViaRmList(string Rm_ID)
        {
            DataSet Dset = new DataSet();
            List<Issue> getIssueDetails = new List<Issue>();
            Issue response = new Issue();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetIssueViaRmList(Rm_ID);
                if (dt_userList.Rows.Count > 0)
                {
                    getIssueDetails = (from DataRow dr in dt_userList.Rows
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
                                          // EmailID = (dr["EmailMessageID"] is DBNull) ? string.Empty : Convert.ToString(dr["EmailMessageID"]).Trim(),


                                       }).ToList();

                }
                return getIssueDetails;


            }
            catch (Exception EX)
            {

            }

            return getIssueDetails;
        }
        public List<Issue> GetIssueViaRm(string Rm_ID)
        {
            DataSet Dset = new DataSet();
            List<Issue> getIssueDetails = new List<Issue>();
            Issue response = new Issue();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetIssueViaRm(Rm_ID);
                if (dt_userList.Rows.Count > 0)
                {
                    getIssueDetails = (from DataRow dr in dt_userList.Rows
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
                                          // EmailID = (dr["EmailMessageID"] is DBNull) ? string.Empty : Convert.ToString(dr["EmailMessageID"]).Trim(),


                                       }).ToList();

                }
                return getIssueDetails;


            }
            catch (Exception EX)
            {

            }

            return getIssueDetails;
        }

        public List<Issue> GetIssueByClient(string ClientID)
        {
            DataSet Dset = new DataSet();
            List<Issue> getIssueDetails = new List<Issue>();
            Issue response = new Issue();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetIssueByClient(ClientID);
                if (dt_userList.Rows.Count > 0)
                {
                    getIssueDetails = (from DataRow dr in dt_userList.Rows
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
                                           //EmailID = (dr["EmailMessageID"] is DBNull) ? string.Empty : Convert.ToString(dr["EmailMessageID"]).Trim(),


                                       }).ToList();

                }
                return getIssueDetails;


            }
            catch (Exception EX)
            {

            }

            return getIssueDetails;
        }

        public List<Issue> GetIssueRep(EmailRep EmailID)
        {
            DataSet Dset = new DataSet();
            List<Issue> getIssueDetails = new List<Issue>();
            Issue response = new Issue();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetIssueRep(EmailID);
                if (dt_userList.Rows.Count > 0)
                {
                    getIssueDetails = (from DataRow dr in dt_userList.Rows
                                       select new Issue
                                       {

                                           IssueSubject = (dr["IssueSubject"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueSubject"]).Trim(),
                                           IssueBody = (dr["IssueBody"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueBody"]).Trim(),
                                           ClientEmail = (dr["IssueFrom"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueFrom"]).Trim(),


                                       }).ToList();

                }
                return getIssueDetails;


            }
            catch (Exception EX)
            {

            }

            return getIssueDetails;
        }
        public List<Issue> GetIssue(string IssueID)
        {
            DataSet Dset = new DataSet();
            List<Issue> getIssueDetails = new List<Issue>();
            Issue response = new Issue();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetIssue(IssueID);
                if (dt_userList.Rows.Count > 0)
                {
                    getIssueDetails = (from DataRow dr in dt_userList.Rows
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
                                           RMName = (dr["RMName"] is DBNull) ? string.Empty : Convert.ToString(dr["RMName"]).Trim(),
                                           RMUniqueID = (dr["RMUiqueID"] is DBNull) ? string.Empty : Convert.ToString(dr["RMUiqueID"]).Trim(),
                                          // EmailID = (dr["EmailMessageID"] is DBNull) ? string.Empty : Convert.ToString(dr["EmailMessageID"]).Trim(),


                                       }).ToList();

                }
                return getIssueDetails;


            }
            catch (Exception EX)
            {

            }

            return getIssueDetails;
        }

        public List<Location> GetBusinessCompany()
        {
            DataSet Dset = new DataSet();
            List<Location> getUserLocation = new List<Location>();
            Location response = new Location();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetCompanyList();
                if (dt_userList.Rows.Count > 0)
                {
                    getUserLocation = (from DataRow dr in dt_userList.Rows
                                       select new Location
                                       {
                                           LocationID = (dr["CompanyID"] is DBNull) ? string.Empty : Convert.ToString(dr["CompanyID"]).Trim(),
                                           Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),



                                       }).ToList();

                }
                return getUserLocation;


            }
            catch (Exception EX)
            {

            }

            return getUserLocation;
        }
        public List<Location> GetBusinessLocation()
        {
            DataSet Dset = new DataSet();
            List<Location> getUserLocation = new List<Location>();
            Location response = new Location();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetLocationList();
                if (dt_userList.Rows.Count > 0)
                {
                    getUserLocation = (from DataRow dr in dt_userList.Rows
                                       select new Location
                                       {
                                           LocationID = (dr["LocationID"] is DBNull) ? string.Empty : Convert.ToString(dr["LocationID"]).Trim(),
                                           Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),



                                       }).ToList();

                }
                return getUserLocation;


            }
            catch (Exception EX)
            {

            }

            return getUserLocation;
        }
        public List<AddOtherDetails> GetOtherDetails(string ID)
        {
            DataSet Dset = new DataSet();
            List<AddOtherDetails> getClientList = new List<AddOtherDetails>();
            AddClient response = new AddClient();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {
                DataTable dt_userList = dataAcessLayer.GetOtherDetails(ID);
                if (dt_userList.Rows.Count > 0)
                {
                    getClientList = (from DataRow dr in dt_userList.Rows
                                     select new AddOtherDetails

                                     {
                                         Agreements_Dates = (dr["Agreements_Dates"] is DBNull) ? string.Empty : Convert.ToString(dr["Agreements_Dates"]).Trim(),
                                         CLRA_Status = (dr["CLRA_Status"] is DBNull) ? string.Empty : Convert.ToString(dr["CLRA_Status"]).Trim(),
                                         Exits = (dr["Exits"] is DBNull) ? string.Empty : Convert.ToString(dr["Exits"]).Trim(),
                                         HealthRpt = (dr["HealthRpt"] is DBNull) ? string.Empty : Convert.ToString(dr["HealthRpt"]).Trim(),
                                         ID = (dr["ID"] is DBNull) ? string.Empty : Convert.ToString(dr["ID"]).Trim(),
                                         Invoices = (dr["Invoices"] is DBNull) ? string.Empty : Convert.ToString(dr["Invoices"]).Trim(),
                                         Joinees = (dr["Joinees"] is DBNull) ? string.Empty : Convert.ToString(dr["Joinees"]).Trim(),
                                         Location = (dr["Location"] is DBNull) ? string.Empty : Convert.ToString(dr["Location"]).Trim(),
                                         NoOfEmpl = (dr["NoOfEmpl"] is DBNull) ? string.Empty : Convert.ToString(dr["NoOfEmpl"]).Trim(),
                                         NoOfEmplPF_ESIC = (dr["NoOfEmplPF_ESIC"] is DBNull) ? string.Empty : Convert.ToString(dr["NoOfEmplPF_ESIC"]).Trim(),
                                         open_positions_share = (dr["open_positions_share"] is DBNull) ? string.Empty : Convert.ToString(dr["open_positions_share"]).Trim(),


                                     }).ToList();

                }
                return getClientList;


            }
            catch (Exception EX)
            {

            }

            return getClientList;
        }

        public Response<string> addClientDashboard(addClientDash request)
        {


            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.addClientDash(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;

        }

        public List<addClientDash> GetClientDashList(string ClientID)
        {


            DataSet Dset = new DataSet();
            List<addClientDash> IssueList = new List<addClientDash>();
            addClientDash response = new addClientDash();
            try
            {

                DataAccessLayer dataAcessLayer = new DataAccessLayer();

                DataTable DSet = dataAcessLayer.GetClientDashList(ClientID);
                GlobalValidation obj_Global = new GlobalValidation();
                if (DSet.Rows.Count > 0)
                {
                    IssueList = (from DataRow dr in DSet.Rows
                                 select new addClientDash
                                 {
                                     ClientID = (dr["ClientID"] is DBNull) ? string.Empty : Convert.ToString(dr["ClientID"]).Trim(),
                                     ClientDash = (dr["ClientDash"] is DBNull) ? string.Empty : Convert.ToString(dr["ClientDash"]).Trim()

                                 }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return IssueList;
        }

        public List<AddClient> GetBusinessClientList(string ClientID)
        {
            DataSet Dset = new DataSet();
            List<AddClient> getClientList = new List<AddClient>();
            AddClient response = new AddClient();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetClientList(ClientID);
                if (dt_userList.Rows.Count > 0)
                {
                    getClientList = (from DataRow dr in dt_userList.Rows
                                     select new AddClient

                                     {
                                         Assort_ClientID = (dr["Assort_ClientID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientID"]).Trim(),
                                         Assort_ClientName = (dr["Assort_ClientName"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientName"]).Trim(),
                                         Assort_ClientPassword = (dr["Assort_ClientPassword"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientPassword"]).Trim(),
                                         Assort_StartContractDate = (dr["Assort_StartContractDate"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_StartContractDate"]).Trim(),
                                         Assort_EndContractDate = (dr["Assort_EndContarctDate"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_EndContarctDate"]).Trim(),
                                         Assort_ClientUserID = (dr["Assort_ClientUserID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientUserID"]).Trim(),
                                         Assort_CurrentlyOutsourcedAgency1 = (dr["Assort_CurrentlyOutsourcedAgency1"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_CurrentlyOutsourcedAgency1"]).Trim(),
                                         Assort_CurrentlyOutsourcedAgency2 = (dr["Assort_CurrentlyOutsourcedAgency2"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_CurrentlyOutsourcedAgency2"]).Trim(),
                                         Assort_CurrentlyOutsourcedAgency3 = (dr["Assort_CurrentlyOutsourcedAgency3"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_CurrentlyOutsourcedAgency3"]).Trim(),
                                         Assort_CurrentlyOutsourcedAgency4 = (dr["Assort_CurrentlyOutsourcedAgency4"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_CurrentlyOutsourcedAgency4"]).Trim(),
                                         Assort_CurrentlyOutsourcedAgency5 = (dr["Assort_CurrentlyOutsourcedAgency5"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_CurrentlyOutsourcedAgency5"]).Trim(),
                                         Assort_AveragemarkupForIntelligence = (dr["Assort_AveragemarkupForIntelligence"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_AveragemarkupForIntelligence"]).Trim(),
                                         Assort_Temporarystaffing = (dr["Assort_Temporarystaffing"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_Temporarystaffing"]).Trim(),
                                         Assort_Reasonforchangeisuue = (dr["Assort_Reasonforchangeisuue"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_Reasonforchangeisuue"]).Trim(),
                                         Assort_TotalstafftooutsourceRecruit = (dr["Assort_TotalstafftooutsourceRecruit"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_TotalstafftooutsourceRecruit"]).Trim(),
                                         Assort_TotalstafftooutsourceOutsource = (dr["Assort_TotalstafftooutsourceOutsource"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_TotalstafftooutsourceOutsource"]).Trim(),
                                         Assort_MinSalary = (dr["Assort_MinSalary"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_MinSalary"]).Trim(),
                                         Assort_MaxSal = (dr["Assort_MaxSal"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_MaxSal"]).Trim(),
                                         Assort_InsuranceCoverage = (dr["Assort_InsuranceCoverage"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_InsuranceCoverage"]).Trim(),
                                         Assort_JobDescription = (dr["Assort_JobDescription"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_JobDescription"]).Trim(),
                                         Assort_Paymenttermforpermanentplacementsignof = (dr["Assort_Paymenttermforpermanentplacementsignof"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_Paymenttermforpermanentplacementsignof"]).Trim(),

                                         industry = (dr["industry"] is DBNull) ? string.Empty : Convert.ToString(dr["industry"]).Trim(),
                                         turn_over = (dr["turn_over"] is DBNull) ? string.Empty : Convert.ToString(dr["turn_over"]).Trim(),
                                         client_website = (dr["client_website"] is DBNull) ? string.Empty : Convert.ToString(dr["client_website"]).Trim(),
                                         client_linkedin = (dr["client_linkedin"] is DBNull) ? string.Empty : Convert.ToString(dr["client_linkedin"]).Trim(),
                                         permaBuiseness13 = (dr["permaBuiseness13"] is DBNull) ? string.Empty : Convert.ToString(dr["permaBuiseness13"]).Trim(),
                                         replacement_period = (dr["replacement_period"] is DBNull) ? string.Empty : Convert.ToString(dr["replacement_period"]).Trim(),
                                         terms_of_payment_forSharing = (dr["terms_of_payment_forSharing"] is DBNull) ? string.Empty : Convert.ToString(dr["terms_of_payment_forSharing"]).Trim(),
                                         cash_and_carry = (dr["cash_and_carry"] is DBNull) ? string.Empty : Convert.ToString(dr["cash_and_carry"]).Trim(),
                                         upfront = (dr["upfront"] is DBNull) ? string.Empty : Convert.ToString(dr["upfront"]).Trim(),
                                         complince = (dr["complince"] is DBNull) ? string.Empty : Convert.ToString(dr["complince"]).Trim(),
                                         Assort_ClientContactPersonName = (dr["Assort_ClientContactPersonName"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientContactPersonName"]).Trim(),
                                         Assort_ClientEmail = (dr["Assort_ClientEmail"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientEmail"]).Trim(),
                                         Assort_ClientPNumber = (dr["Assort_ClientPNumber"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientPNumber"]).Trim(),
                                         Assort_ClientManagerName = (dr["Assort_ClientManagerName"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientManagerName"]).Trim(),
                                         Assort_ClientContactID = (dr["Assort_ClientContactID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientContactID"]).Trim(),


                                         ClientagrementUrl = (dr["ClientagrementUrl"] is DBNull) ? string.Empty : Convert.ToString(dr["ClientagrementUrl"]).Trim(),
                                       //  isActive = (dr["isActive"] is DBNull) ? string.Empty : Convert.ToString(dr["isActive"]).Trim()

                                     }).ToList();

                }
                return getClientList;


            }
            catch (Exception EX)
            {

            }

            return getClientList;
        }
        public List<IndustryLists> GetBusinessIndustryList()
        {
            DataSet Dset = new DataSet();
            List<IndustryLists> getIndustryList = new List<IndustryLists>();
            IndustryLists response = new IndustryLists();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetIndustryList();
                if (dt_userList.Rows.Count > 0)
                {
                    getIndustryList = (from DataRow dr in dt_userList.Rows
                                       select new IndustryLists
                                       {
                                           IndustryID = (dr["IndustryID"] is DBNull) ? string.Empty : Convert.ToString(dr["IndustryID"]).Trim(),
                                           Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),




                                       }).ToList();

                }
                return getIndustryList;


            }
            catch (Exception EX)
            {

            }

            return getIndustryList;
        }


        public List<AddRelationshipManager> GetRelationshipManager(string Rm_ID)
        {
            DataSet Dset = new DataSet();
            List<AddRelationshipManager> getRM = new List<AddRelationshipManager>();
            AddRelationshipManager response = new AddRelationshipManager();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetRelationshipManager(Rm_ID);
                if (dt_userList.Rows.Count > 0)
                {
                    getRM = (from DataRow dr in dt_userList.Rows
                             select new AddRelationshipManager
                             {
                                 Assort_ClientContactPersonName = (dr["Assort_ClientContactPersonName"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientContactPersonName"]).Trim(),
                                 Assort_ClientEmail = (dr["Assort_ClientEmail"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientEmail"]).Trim(),
                                 Assort_ClientPNumber = (dr["Assort_ClientPNumber"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientPNumber"]).Trim(),
                                 Assort_ClientManagerName = (dr["Assort_ClientManagerName"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientManagerName"]).Trim(),
                                 Assort_ClientContactID = (dr["Assort_ClientContactID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientContactID"]).Trim(),
                                 AssortClientManager1Email = (dr["AssortClientManager1Email"] is DBNull) ? string.Empty : Convert.ToString(dr["AssortClientManager1Email"]).Trim(),
                                 AssortClientManager2Email = (dr["AssortClientManager2Email"] is DBNull) ? string.Empty : Convert.ToString(dr["AssortClientManager2Email"]).Trim(),
                                 AssortClientManager1Name = (dr["AssortClientManager1Name"] is DBNull) ? string.Empty : Convert.ToString(dr["AssortClientManager1Name"]).Trim(),
                                 AssortClientManager2Name = (dr["AssortClientManager2Name"] is DBNull) ? string.Empty : Convert.ToString(dr["AssortClientManager2Name"]).Trim(),
                                 AssortClientManagerUniqueCode = (dr["AssortClientManagerUniqueCode"] is DBNull) ? string.Empty : Convert.ToString(dr["AssortClientManagerUniqueCode"]).Trim()



                             }).ToList();

                }
                return getRM;


            }
            catch (Exception EX)
            {

            }

            return getRM;
        }

        public List<JobList> GetJobClientList(string ClientID)
        {
            DataSet Dset = new DataSet();
            List<JobList> getJobClientList = new List<JobList>();
            JobList response = new JobList();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetJobClientList(ClientID);
                if (dt_userList.Rows.Count > 0)
                {
                    getJobClientList = (from DataRow dr in dt_userList.Rows
                                        select new JobList
                                        {
                                            JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                            IsJobActive = (dr["IsJobActive"] is DBNull) ? string.Empty : Convert.ToString(dr["IsJobActive"]).Trim(),
                                            Job_Description = (dr["Job_Description"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Description"]).Trim(),
                                            Job_Exp_Max = (dr["Job_Exp_Max"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Exp_Max"]).Trim(),
                                            Job_Exp_Min = (dr["Job_Exp_Min"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Exp_Min"]).Trim(),
                                            Job_PostedBy = (dr["Job_PostedBy"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_PostedBy"]).Trim(),
                                            Job_PostedDate = (dr["Job_PostedDate"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_PostedDate"]).Trim(),
                                            Job_Title = (dr["Job_Title"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Title"]).Trim(),
                                            Job_Type = (dr["Job_Type"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Type"]).Trim(),
                                            CompanyName = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                            Job_Sal_Max = (dr["Job_Sal_Max"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Sal_Max"]).Trim(),
                                            Job_Sal_Min = (dr["Job_Sal_Min"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Sal_Min"]).Trim(),
                                            IsDelete = (dr["IsDelete"] is DBNull) ? string.Empty : Convert.ToString(dr["IsDelete"]).Trim()
                                        }).ToList();

                }
                return getJobClientList;


            }
            catch (Exception EX)
            {

            }

            return getJobClientList;
        }
        public List<SkillsName> GetBusinessSkillsName()
        {
            DataSet Dset = new DataSet();
            List<SkillsName> getUserSkillsName = new List<SkillsName>();
            SkillsName response = new SkillsName();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetSkillsNameList();
                if (dt_userList.Rows.Count > 0)
                {
                    getUserSkillsName = (from DataRow dr in dt_userList.Rows
                                         select new SkillsName
                                         {
                                             Assort_skillCategoryID = (dr["Assort_skillCategoryID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_skillCategoryID"]).Trim(),
                                             Assort_skillID = (dr["Assort_skillID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_skillID"]).Trim(),
                                             Assort_skillName = (dr["Assort_skillName"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_skillName"]).Trim(),



                                         }).ToList();

                }
                return getUserSkillsName;


            }
            catch (Exception EX)
            {

            }

            return getUserSkillsName;
        }
        public List<SkillsCategory> GetBusinessSkillsCategory()
        {
            DataSet Dset = new DataSet();
            List<SkillsCategory> getUserSkillsCategory = new List<SkillsCategory>();
            SkillsCategory response = new SkillsCategory();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetSkillsCategoryList();
                if (dt_userList.Rows.Count > 0)
                {
                    getUserSkillsCategory = (from DataRow dr in dt_userList.Rows
                                             select new SkillsCategory
                                             {
                                                 Assort_skillCategoryID = (dr["Assort_skillCategoryID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_skillCategoryID"]).Trim(),
                                                 Assort_skillCategoryName = (dr["Assort_skillCategoryName"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_skillCategoryName"]).Trim(),



                                             }).ToList();

                }
                return getUserSkillsCategory;


            }
            catch (Exception EX)
            {

            }

            return getUserSkillsCategory;
        }

        public Response<string> UserRegistration(RegistrationData request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.UserRegistration(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> AddClient(AddClient request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AddClient(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> Forgotpassword(string UEmail, string UPassword)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.Forgotpassword(UEmail, UPassword);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 2, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        string body = string.Empty;
                        using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/forgotPassword.html")))
                        {
                            body = reader.ReadToEnd();
                        }
                        body = body.Replace("{EmailID}", UEmail);
                        body = body.Replace("{Year}", "2017");
                        body = body.Replace("{otp}", UPassword);

                        sendEmail(UEmail, "", body);

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }


        public bool sendEmail(string to, string cc, string body)
        {
            // string Body = "<table style='width:100%'><tr><td align='center'><img src='http://dev.assortstaffing.com/img/logo5.png'></td></tr><tr><td><table><tr><td><img src='https://www.google.co.in/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwjCusfk5Y7WAhWB6Y8KHSghAZcQjRwIBw&url=http%3A%2F%2Fmedren.aas.duke.edu%2Fjmems%2F&psig=AFQjCNHQfrYy8ZRJJ6Q7H5_fIhTFZswtMQ&ust=1504726656197480'></td><td>" + body + "</td></tr></table></td></tr><tr><td align='center'>Office No-202, 17 A, 1st floor, Mehta Estate, Opp Chintamani Plaza,Chakala, Andheri -Kurla Road,Andheri East ,Mumbai -400093,Maharashtra Board Line No.: 022 - 49213100 </td></tr></table>";

            try
            {
                using (var mail = new MailMessage("support-info@assortstaffing.com", to))
                {

                    mail.Subject = "Reset your password";
                    mail.Body = body;
                    if (cc != "")
                    {
                        mail.CC.Add(cc);
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
            catch
            {
                using (var mail = new MailMessage("support-info@assortstaffing.com", to))
                {

                    mail.Subject = "Reset your password";
                    mail.Body = body;
                    if (cc != "")
                    {
                        mail.CC.Add(cc);
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
        public Response<string> AddRelationshipManager(AddRelationshipManager request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AddRelationshipManager(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }


        public Response<string> ActDeactOperClient(string ClID, string Status)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.ActDeactOperClient(ClID, Status);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }
        public Response<string> DeleteJob(string JobID)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.DeleteJob(JobID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }
        public Response<string> AddUpdateTemporaryStaffing(TemporaryStaffing request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AddUpdateTemporaryStaffing(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> CreateUpdateIssue(Issue request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.CreateUpdateIssue(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> CreateUpdateIssueFromEmailReply(Issue request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.CreateUpdateIssueFromEmailReply(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }
        public Response<string> CreateUpdateIssueFromEmail(Issue request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.CreateUpdateIssueFromEmail(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> AssignUClient(AssignUClient request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AssignUClient(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> UserDetailsUpdate(ULogin request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.UserDetailsUpDateDB(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        private DataTable genertateShortlistedCandidateToTable(List<ShortlistedCandidate> ShortlistedCandidate)
        {
            string[] ShortListedItemColum =
            {
                 "JobID",
                 "CandidateID"
            };
            DataTable dtShortlisted = new DataTable();
            dtShortlisted = GlobalValidation.ConvertToDatatype(ShortlistedCandidate);
            for (int i = dtShortlisted.Columns.Count - 1; i >= 0; i--)
            {
                if (!(ShortListedItemColum.Contains(dtShortlisted.Columns[i].ColumnName)))
                    dtShortlisted.Columns.Remove(dtShortlisted.Columns[i].ColumnName);
            }
            return dtShortlisted;
        }

        public Response<string> InsertShortListedCandidate(List<ShortlistedCandidate> ShortlistedCandidate)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {
                DataTable dtShortlistedCandidate = genertateShortlistedCandidateToTable(ShortlistedCandidate);
                DSet = dataAcessLayer.ShortlistedCandidate(dtShortlistedCandidate);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }
        public Response<string> CreatejobBuisiness(CreateJob request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.CreateJobDataAccess(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> UpdateIssueStatus(updateIssueStatus IssueStatus)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.UpdateIssueStatus(IssueStatus);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }


        public Response<string> UpdateClientAgrement(string resumePath, string ClientID)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.UpdateClientAgrement(resumePath, ClientID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }


        public Response<string> UpdateCandidateImage(string ImagePath, string CandidateID)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.UpdateCandidateImage(ImagePath, CandidateID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }
        public Response<string> UpdateCandidateResume(string resumePath, string CandidateID)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.UpdateCandidateResume(resumePath, CandidateID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> UpdateClientDocs(string DocsUrl, string ClientID, string DocType, string DocName)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.UpdateClientDocs(DocsUrl, ClientID, DocType, DocName);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }
        public Response<string> ApplyJobBuisiness(string CandidateID, string JobID)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.ApplyJobDataAccess(CandidateID, JobID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }



        public Response<string> AddSkillNameBuisiness(AddSkillName request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AddSkillNameDataAccess(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }
        public Response<string> AddSkillCategoryBuisiness(AddSkillCategoryName request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AddSkillCategoryDataAccess(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }



        public Response<string> AddCardClientBuisiness(AddCardClient request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AddCardClientDataAccess(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }
        public Response<string> AddLocationBuisiness(AddLocation request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AddLocationDataAccess(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> AddIndustryBuisiness(AddIndustry request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AddIndustryDataAccess(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public List<newsAndMedia> GetnewsAndMedia()
        {
            DataSet Dset = new DataSet();
            List<newsAndMedia> getNewsList = new List<newsAndMedia>();
            newsAndMedia response = new newsAndMedia();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetnewsAndMedia();
                if (dt_userList.Rows.Count > 0)
                {
                    getNewsList = (from DataRow dr in dt_userList.Rows
                                   select new newsAndMedia

                                   {
                                       newsDate = (dr["newsDate"] is DBNull) ? string.Empty : Convert.ToString(dr["newsDate"]).Trim(),
                                       newsHeading = (dr["newsHeading"] is DBNull) ? string.Empty : Convert.ToString(dr["newsHeading"]).Trim(),
                                       newsDisc = (dr["newsDisc"] is DBNull) ? string.Empty : Convert.ToString(dr["newsDisc"]).Trim(),
                                       newsID = (dr["newsID"] is DBNull) ? string.Empty : Convert.ToString(dr["newsID"]).Trim(),
                                       newsImage = (dr["newsImage"] is DBNull) ? string.Empty : Convert.ToString(dr["newsImage"]).Trim()

                                   }).ToList();

                }
                return getNewsList;


            }
            catch (Exception EX)
            {

            }

            return getNewsList;
        }
        public List<Blogs> GetBlogs()
        {
            DataSet Dset = new DataSet();
            List<Blogs> getBlogList = new List<Blogs>();
            Blogs response = new Blogs();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DataTable dt_userList = dataAcessLayer.GetBlogs();
                if (dt_userList.Rows.Count > 0)
                {
                    getBlogList = (from DataRow dr in dt_userList.Rows
                                   select new Blogs

                                   {
                                       blogDisc = (dr["blogDisc"] is DBNull) ? string.Empty : Convert.ToString(dr["blogDisc"]).Trim(),
                                       blogHeading = (dr["blogHeading"] is DBNull) ? string.Empty : Convert.ToString(dr["blogHeading"]).Trim(),
                                       blogID = (dr["blogID"] is DBNull) ? string.Empty : Convert.ToString(dr["blogID"]).Trim(),
                                       blogImage = (dr["blogImage"] is DBNull) ? string.Empty : Convert.ToString(dr["blogImage"]).Trim(),
                                       blogPublishDate = (dr["blogPublishDate"] is DBNull) ? string.Empty : Convert.ToString(dr["blogPublishDate"]).Trim(),
                                       blogShortDisc = (dr["blogShortDisc"] is DBNull) ? string.Empty : Convert.ToString(dr["blogShortDisc"]).Trim()

                                   }).ToList();

                }
                return getBlogList;


            }
            catch (Exception EX)
            {

            }

            return getBlogList;
        }

        public Response<string> newsAndMediaPost(newsAndMedia request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.newsAndMediaPost(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> blogPost(Blogs request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.blogPost(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }


        public Response<string> AddOtherDetails(AddOtherDetails request)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AddOtherDetails(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> deleteClient(string ID)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.deleteClient(ID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }
        public Response<string> deleteRM(string RMID)
        {



            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.deleteRM(RMID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> deleteBlog(string BLOGID)
        {
            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.deleteBlog(BLOGID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }


        public Response<string> deleteNews(string NEWSID)
        {
            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.deleteNews(NEWSID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<string> AddCompanyBuisiness(AddCompany request)
        {

            Response<string> response = new Response<string>();
            DataSet DSet = new DataSet();
            DataAccessLayer dataAcessLayer = new DataAccessLayer();
            try
            {

                DSet = dataAcessLayer.AddCompanyDataAccess(request);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 1, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;
                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    response.Status = "Success";
                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        response.Result = Convert.ToString(DSet.Tables[0].Rows[0][1].ToString());

                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return response;
        }

        public Response<GetJobs> GetBusinessJobListByID(string JobID)
        {
            Response<GetJobs> response = new Response<GetJobs>();

            GetJobs GetJobsData = null;
            try
            {

                List<JobList> JobListData = new List<JobList>();
                List<IndustryList> IndustryListData = new List<IndustryList>();
                List<SkillsList> SkillsListData = new List<SkillsList>();
                List<LocationList> LocationListData = new List<LocationList>();
                List<CompanyList> CompanyListData = new List<CompanyList>();

                DataAccessLayer dataAcessLayer = new DataAccessLayer();
                DataSet DSet = dataAcessLayer.GetJobListsByID(JobID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 6, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;

                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    GetJobsData = new GetJobs();
                    response.Status = "Success";



                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        JobListData = (from DataRow dr in DSet.Tables[0].Rows
                                       select new JobList
                                       {
                                           JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                           IsJobActive = (dr["IsJobActive"] is DBNull) ? string.Empty : Convert.ToString(dr["IsJobActive"]).Trim(),
                                           Job_Description = (dr["Job_Description"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Description"]).Trim(),
                                           Job_Exp_Max = (dr["Job_Exp_Max"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Exp_Max"]).Trim(),
                                           Job_Exp_Min = (dr["Job_Exp_Min"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Exp_Min"]).Trim(),
                                           Job_PostedBy = (dr["Job_PostedBy"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_PostedBy"]).Trim(),
                                           Job_PostedDate = (dr["Job_PostedDate"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_PostedDate"]).Trim(),
                                           Job_Title = (dr["Job_Title"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Title"]).Trim(),
                                           Job_Type = (dr["Job_Type"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Type"]).Trim(),
                                           CompanyName = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                           Job_Location = (dr["Job_Location"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Location"]).Trim(),
                                           Job_Sal_Max = (dr["Job_Sal_Max"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Sal_Max"]).Trim(),

                                           SkillList = (dr["Job_Skill"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Skill"]).Trim(),
                                           Job_Sal_Min = (dr["Job_Sal_Min"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Sal_Min"]).Trim(),
                                           IsDelete = (dr["IsDelete"] is DBNull) ? string.Empty : Convert.ToString(dr["IsDelete"]).Trim()
                                       }).ToList();
                    }

                    if (DSet.Tables[1].Rows.Count > 0)
                    {
                        IndustryListData = (from DataRow dr in DSet.Tables[1].Rows
                                            select new IndustryList
                                            {
                                                JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                                Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                                IndustryID = (dr["IndustryID"] is DBNull) ? string.Empty : Convert.ToString(dr["IndustryID"]).Trim()

                                            }).ToList();
                    }
                    if (DSet.Tables[2].Rows.Count > 0)
                    {
                        SkillsListData = (from DataRow dr in DSet.Tables[2].Rows
                                          select new SkillsList
                                          {
                                              JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                              Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                              Assort_skillID = (dr["Assort_skillID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_skillID"]).Trim()

                                          }).ToList();
                    }
                    if (DSet.Tables[3].Rows.Count > 0)
                    {
                        LocationListData = (from DataRow dr in DSet.Tables[3].Rows
                                            select new LocationList
                                            {
                                                JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                                Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                                LocationID = (dr["LocationID"] is DBNull) ? string.Empty : Convert.ToString(dr["LocationID"]).Trim()

                                            }).ToList();
                    }
                    if (DSet.Tables[4].Rows.Count > 0)
                    {
                        CompanyListData = (from DataRow dr in DSet.Tables[4].Rows
                                           select new CompanyList
                                           {
                                               CompanyID = (dr["CompanyID"] is DBNull) ? string.Empty : Convert.ToString(dr["CompanyID"]).Trim(),
                                               Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                               CompanyUrl = (dr["CompanyUrl"] is DBNull) ? string.Empty : Convert.ToString(dr["CompanyUrl"]).Trim(),
                                               Company_CEO = (dr["Company_CEO"] is DBNull) ? string.Empty : Convert.ToString(dr["Company_CEO"]).Trim(),
                                               Company_HeadQuartr = (dr["Company_HeadQuarte"] is DBNull) ? string.Empty : Convert.ToString(dr["Company_HeadQuarte"]).Trim(),
                                               Company_PhoneNo = (dr["Company_PhoneNo"] is DBNull) ? string.Empty : Convert.ToString(dr["Company_PhoneNo"]).Trim()



                                           }).ToList();
                    }

                }

                GetJobsData.JobLists = JobListData;
                GetJobsData.IndustryLists = IndustryListData;
                GetJobsData.SkillsLists = SkillsListData;
                GetJobsData.LocationLists = LocationListData;
                GetJobsData.CompanyLists = CompanyListData;
                response.Result = GetJobsData;
            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public Response<GetAppliedJobsList> GetShortlitedCandidateList()
        {
            Response<GetAppliedJobsList> response = new Response<GetAppliedJobsList>();

            GetAppliedJobsList GetJobsData = null;
            try
            {

                List<GetAppliedJobs> JobListData = new List<GetAppliedJobs>();

                DataAccessLayer dataAcessLayer = new DataAccessLayer();
                DataSet DSet = dataAcessLayer.GetShortlitedCandidateList();
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 2, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;

                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    GetJobsData = new GetAppliedJobsList();
                    response.Status = "Success";



                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        JobListData = (from DataRow dr in DSet.Tables[0].Rows
                                       select new GetAppliedJobs
                                       {
                                           JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                           Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                           CandidateID = (dr["CandidateID"] is DBNull) ? string.Empty : Convert.ToString(dr["CandidateID"]).Trim(),
                                           AppliedDate = (dr["Job_PostedDate"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_PostedDate"]).Trim(),
                                           Title = (dr["Job_Title"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Title"]).Trim()
                                       }).ToList();
                    }



                }
                GetJobsData.getAppliedJobs = JobListData;
                response.Result = GetJobsData;
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public Response<GetAppliedJobsList> GetBusinessAppliedJobList(string JobID)
        {
            Response<GetAppliedJobsList> response = new Response<GetAppliedJobsList>();

            GetAppliedJobsList GetJobsData = null;
            try
            {

                List<GetAppliedJobs> JobListData = new List<GetAppliedJobs>();
                List<GetAppliedJobs> ClientListData = new List<GetAppliedJobs>();
                List<GetAppliedJobs> RMListData = new List<GetAppliedJobs>();
                DataAccessLayer dataAcessLayer = new DataAccessLayer();
                DataSet DSet = dataAcessLayer.GetAppliedJobListsByID(JobID);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 4, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;


                GetJobsData = new GetAppliedJobsList();
                response.Status = "Success";



                if (DSet.Tables[0].Rows.Count > 0)
                {
                    JobListData = (from DataRow dr in DSet.Tables[0].Rows
                                   select new GetAppliedJobs
                                   {
                                       JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                       Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                       CandidateID = (dr["CandidateID"] is DBNull) ? string.Empty : Convert.ToString(dr["CandidateID"]).Trim(),
                                       AppliedDate = (dr["Job_PostedDate"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_PostedDate"]).Trim(),
                                       Title = (dr["Job_Title"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Title"]).Trim()
                                   }).ToList();
                }
                if (DSet.Tables[1].Rows.Count > 0)
                {
                    GetJobsData.getTotalRegistration = (from DataRow dr in DSet.Tables[1].Rows
                                                        select new GetAppliedJobs
                                                        {
                                                            TotalRegistration = (dr["TotalRegistration"] is DBNull) ? string.Empty : Convert.ToString(dr["TotalRegistration"]).Trim(),
                                                        }).ToList();
                }
                if (DSet.Tables[2].Rows.Count > 0)
                {
                    GetJobsData.getTotalJobs = (from DataRow dr in DSet.Tables[2].Rows
                                                select new GetAppliedJobs
                                                {
                                                    TotalAppliedJob = (dr["TotalAppliedJob"] is DBNull) ? string.Empty : Convert.ToString(dr["TotalAppliedJob"]).Trim(),
                                                }).ToList();
                }

                if (DSet.Tables[3].Rows.Count > 0)
                {
                    ClientListData = (from DataRow dr in DSet.Tables[3].Rows
                                      select new GetAppliedJobs
                                      {
                                          Totalclient = (dr["TotalClient"] is DBNull) ? string.Empty : Convert.ToString(dr["TotalClient"]).Trim()
                                      }).ToList();
                }
                JobListData.AddRange(ClientListData);
                if (DSet.Tables[4].Rows.Count > 0)
                {
                    RMListData = (from DataRow dr in DSet.Tables[4].Rows
                                  select new GetAppliedJobs
                                  {
                                      TotalRM = (dr["TotalRM"] is DBNull) ? string.Empty : Convert.ToString(dr["TotalRM"]).Trim()
                                  }).ToList();
                }

                JobListData.AddRange(RMListData);

                GetJobsData.getAppliedJobs = JobListData;
                response.Result = GetJobsData;
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public Response<GetJobs> GetJobAutoComplete(string LikeData, string SearchData)
        {
            Response<GetJobs> response = new Response<GetJobs>();

            GetJobs GetJobsData = null;
            try
            {

                List<JobList> JobListData = new List<JobList>();
                List<IndustryList> IndustryListData = new List<IndustryList>();
                List<SkillsList> SkillsListData = new List<SkillsList>();
                List<LocationList> LocationListData = new List<LocationList>();
                List<CompanyList> CompanyListData = new List<CompanyList>();

                DataAccessLayer dataAcessLayer = new DataAccessLayer();
                DataSet DSet = dataAcessLayer.GetJobAutoComplete(LikeData, SearchData);
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 6, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;

                if (obj_Global.Success == false)
                {
                    response.Status = "Failure";
                }
                else
                {
                    GetJobsData = new GetJobs();
                    response.Status = "Success";



                    if (DSet.Tables[0].Rows.Count > 0)
                    {
                        JobListData = (from DataRow dr in DSet.Tables[0].Rows
                                       select new JobList
                                       {
                                           JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                           IsJobActive = (dr["IsJobActive"] is DBNull) ? string.Empty : Convert.ToString(dr["IsJobActive"]).Trim(),
                                           Job_Description = (dr["Job_Description"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Description"]).Trim(),
                                           Job_Exp_Max = (dr["Job_Exp_Max"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Exp_Max"]).Trim(),
                                           Job_Exp_Min = (dr["Job_Exp_Min"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Exp_Min"]).Trim(),
                                           Job_Sal_Max = (dr["Job_Sal_Max"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Sal_Max"]).Trim(),
                                           Job_Sal_Min = (dr["Job_Sal_Min"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Sal_Min"]).Trim(),
                                           Job_PostedBy = (dr["Job_PostedBy"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_PostedBy"]).Trim(),
                                           Job_PostedDate = (dr["Job_PostedDate"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_PostedDate"]).Trim(),
                                           Job_Title = (dr["Job_Title"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Title"]).Trim(),
                                           Job_Type = (dr["Job_Type"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Type"]).Trim(),
                                           CompanyName = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                           CompanyID = (dr["CompanyID"] is DBNull) ? string.Empty : Convert.ToString(dr["CompanyID"]).Trim(),
                                           LocationID = (dr["LocationID"] is DBNull) ? string.Empty : Convert.ToString(dr["LocationID"]).Trim()

                                       }).ToList();
                    }

                    if (DSet.Tables[1].Rows.Count > 0)
                    {
                        IndustryListData = (from DataRow dr in DSet.Tables[1].Rows
                                            select new IndustryList
                                            {
                                                JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                                Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                                IndustryID = (dr["IndustryID"] is DBNull) ? string.Empty : Convert.ToString(dr["IndustryID"]).Trim()

                                            }).ToList();
                    }
                    if (DSet.Tables[2].Rows.Count > 0)
                    {
                        SkillsListData = (from DataRow dr in DSet.Tables[2].Rows
                                          select new SkillsList
                                          {
                                              JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                              Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                              Assort_skillID = (dr["Assort_skillID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_skillID"]).Trim()

                                          }).ToList();
                    }
                    if (DSet.Tables[3].Rows.Count > 0)
                    {
                        LocationListData = (from DataRow dr in DSet.Tables[3].Rows
                                            select new LocationList
                                            {
                                                JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                                Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                                LocationID = (dr["LocationID"] is DBNull) ? string.Empty : Convert.ToString(dr["LocationID"]).Trim()

                                            }).ToList();
                    }
                    if (DSet.Tables[4].Rows.Count > 0)
                    {
                        CompanyListData = (from DataRow dr in DSet.Tables[4].Rows
                                           select new CompanyList
                                           {
                                               CompanyID = (dr["CompanyID"] is DBNull) ? string.Empty : Convert.ToString(dr["CompanyID"]).Trim(),
                                               Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                               CompanyUrl = (dr["CompanyUrl"] is DBNull) ? string.Empty : Convert.ToString(dr["CompanyUrl"]).Trim(),
                                               Company_CEO = (dr["Company_CEO"] is DBNull) ? string.Empty : Convert.ToString(dr["Company_CEO"]).Trim(),
                                               Company_HeadQuartr = (dr["Company_HeadQuarte"] is DBNull) ? string.Empty : Convert.ToString(dr["Company_HeadQuarte"]).Trim(),
                                               Company_PhoneNo = (dr["Company_PhoneNo"] is DBNull) ? string.Empty : Convert.ToString(dr["Company_PhoneNo"]).Trim()



                                           }).ToList();
                    }

                }

                GetJobsData.JobLists = JobListData;
                GetJobsData.IndustryLists = IndustryListData;
                GetJobsData.SkillsLists = SkillsListData;
                GetJobsData.LocationLists = LocationListData;
                GetJobsData.CompanyLists = CompanyListData;
                response.Result = GetJobsData;
            }
            catch (Exception ex)
            {

            }
            return response;
        }


        public List<GetRmViaDepCls> GetRmEmailViaDep(string Dept)
        {


            DataSet Dset = new DataSet();
            List<GetRmViaDepCls> IssueList = new List<GetRmViaDepCls>();
            GetRmViaDepCls response = new GetRmViaDepCls();
            try
            {

                DataAccessLayer dataAcessLayer = new DataAccessLayer();

                DataTable DSet = dataAcessLayer.GetRmEmailViaDep(Dept);
                GlobalValidation obj_Global = new GlobalValidation();
                if (DSet.Rows.Count > 0)
                {
                    IssueList = (from DataRow dr in DSet.Rows
                                 select new GetRmViaDepCls
                                 {
                                     EmailID = (dr["Assort_ClientEmail"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientEmail"]).Trim(),
                                     ID = (dr["Assort_ClientContactID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_ClientContactID"]).Trim()

                                 }).ToList();
                }


                return IssueList;


            }
            catch (Exception ex)
            {

            }
            return IssueList;
        }
        public List<GetIssueDetails> GetIssueDetails()
        {


            DataSet Dset = new DataSet();
            List<GetIssueDetails> IssueList = new List<GetIssueDetails>();
            GetIssueDetails response = new GetIssueDetails();
            try
            {

                DataAccessLayer dataAcessLayer = new DataAccessLayer();
                DataTable DSet = dataAcessLayer.GetIssueDetails();
                GlobalValidation obj_Global = new GlobalValidation();
                if (DSet.Rows.Count > 0)
                {
                    IssueList = (from DataRow dr in DSet.Rows
                                 select new GetIssueDetails
                                 {
                                     HourDif = (dr["HourDif"] is DBNull) ? string.Empty : Convert.ToString(dr["HourDif"]).Trim(),
                                     IssueCreatetime = (dr["IssueCreatetime"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueCreatetime"]).Trim(),
                                     IssueSubject = (dr["IssueSubject"] is DBNull) ? string.Empty : Convert.ToString(dr["IssueSubject"]).Trim(),
                                     ClientEmail = (dr["ClientEmail"] is DBNull) ? string.Empty : Convert.ToString(dr["ClientEmail"]).Trim(),
                                     RmEmailID = (dr["RmEmailID"] is DBNull) ? string.Empty : Convert.ToString(dr["RmEmailID"]).Trim(),
                                     RmManager1 = (dr["RmManager1"] is DBNull) ? string.Empty : Convert.ToString(dr["RmManager1"]).Trim(),
                                     RmManager2 = (dr["RmManager2"] is DBNull) ? string.Empty : Convert.ToString(dr["RmManager2"]).Trim(),

                                 }).ToList();
                }


                return IssueList;


            }
            catch (Exception ex)
            {

            }
            return IssueList;
        }
        public Response<GetJobs> GetBusinessJobList()
        {
            Response<GetJobs> response = new Response<GetJobs>();

            GetJobs GetJobsData = null;
            try
            {

                List<JobList> JobListData = new List<JobList>();
                List<IndustryList> IndustryListData = new List<IndustryList>();
                List<SkillsList> SkillsListData = new List<SkillsList>();
                List<LocationList> LocationListData = new List<LocationList>();
                List<CompanyList> CompanyListData = new List<CompanyList>();

                DataAccessLayer dataAcessLayer = new DataAccessLayer();
                DataSet DSet = dataAcessLayer.GetJobLists();
                GlobalValidation obj_Global = new GlobalValidation();
                obj_Global.validateDBResponse(DSet, 6, 0);
                response.ResponseCode = obj_Global.ResponseCode;
                response.ResponseMessage = obj_Global.ResponseMessage;


                GetJobsData = new GetJobs();
                response.Status = "Success";



                if (DSet.Tables[0].Rows.Count > 0)
                {
                    JobListData = (from DataRow dr in DSet.Tables[0].Rows
                                   select new JobList
                                   {
                                       JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                       IsJobActive = (dr["IsJobActive"] is DBNull) ? string.Empty : Convert.ToString(dr["IsJobActive"]).Trim(),
                                       Job_Description = (dr["Job_Description"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Description"]).Trim(),
                                       Job_Exp_Max = (dr["Job_Exp_Max"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Exp_Max"]).Trim(),
                                       Job_Exp_Min = (dr["Job_Exp_Min"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Exp_Min"]).Trim(),
                                       Job_Sal_Max = (dr["Job_Sal_Max"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Sal_Max"]).Trim(),
                                       Job_Sal_Min = (dr["Job_Sal_Min"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Sal_Min"]).Trim(),
                                       Job_PostedBy = (dr["Job_PostedBy"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_PostedBy"]).Trim(),
                                       Job_PostedDate = (dr["Job_PostedDate"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_PostedDate"]).Trim(),
                                       Job_Title = (dr["Job_Title"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Title"]).Trim(),
                                       Job_Type = (dr["Job_Type"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Type"]).Trim(),
                                       CompanyName = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                       Job_Location = (dr["Job_Location"] is DBNull) ? string.Empty : Convert.ToString(dr["Job_Location"]).Trim(),
                                       CompanyID = (dr["CompanyID"] is DBNull) ? string.Empty : Convert.ToString(dr["CompanyID"]).Trim(),
                                       IsDelete = (dr["IsDelete"] is DBNull) ? string.Empty : Convert.ToString(dr["IsDelete"]).Trim()

                                   }).ToList();
                }

                if (DSet.Tables[1].Rows.Count > 0)
                {
                    IndustryListData = (from DataRow dr in DSet.Tables[1].Rows
                                        select new IndustryList
                                        {
                                            JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                            Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                            IndustryID = (dr["IndustryID"] is DBNull) ? string.Empty : Convert.ToString(dr["IndustryID"]).Trim()

                                        }).ToList();
                }
                if (DSet.Tables[2].Rows.Count > 0)
                {
                    SkillsListData = (from DataRow dr in DSet.Tables[2].Rows
                                      select new SkillsList
                                      {
                                          JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                          Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                          Assort_skillID = (dr["Assort_skillID"] is DBNull) ? string.Empty : Convert.ToString(dr["Assort_skillID"]).Trim()

                                      }).ToList();
                }
                if (DSet.Tables[3].Rows.Count > 0)
                {
                    LocationListData = (from DataRow dr in DSet.Tables[3].Rows
                                        select new LocationList
                                        {
                                            JobID = (dr["JobID"] is DBNull) ? string.Empty : Convert.ToString(dr["JobID"]).Trim(),
                                            Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                            LocationID = (dr["LocationID"] is DBNull) ? string.Empty : Convert.ToString(dr["LocationID"]).Trim()

                                        }).ToList();
                }
                if (DSet.Tables[4].Rows.Count > 0)
                {
                    CompanyListData = (from DataRow dr in DSet.Tables[4].Rows
                                       select new CompanyList
                                       {
                                           CompanyID = (dr["CompanyID"] is DBNull) ? string.Empty : Convert.ToString(dr["CompanyID"]).Trim(),
                                           Name = (dr["Name"] is DBNull) ? string.Empty : Convert.ToString(dr["Name"]).Trim(),
                                           CompanyUrl = (dr["CompanyUrl"] is DBNull) ? string.Empty : Convert.ToString(dr["CompanyUrl"]).Trim(),
                                           Company_CEO = (dr["Company_CEO"] is DBNull) ? string.Empty : Convert.ToString(dr["Company_CEO"]).Trim(),
                                           Company_HeadQuartr = (dr["Company_HeadQuarte"] is DBNull) ? string.Empty : Convert.ToString(dr["Company_HeadQuarte"]).Trim(),
                                           Company_PhoneNo = (dr["Company_PhoneNo"] is DBNull) ? string.Empty : Convert.ToString(dr["Company_PhoneNo"]).Trim()



                                       }).ToList();
                }



                GetJobsData.JobLists = JobListData;
                GetJobsData.IndustryLists = IndustryListData;
                GetJobsData.SkillsLists = SkillsListData;
                GetJobsData.LocationLists = LocationListData;
                GetJobsData.CompanyLists = CompanyListData;
                response.Result = GetJobsData;
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
