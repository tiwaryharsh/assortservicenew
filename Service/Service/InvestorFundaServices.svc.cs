using Limilabs.Client.POP3;
using Limilabs.Mail;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using OpenPop.Mime;
using OpenPop.Pop3;
using Service.GlobalVariables;
using ServiceBusinessLayer;
using ServiceDTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using static ServiceDTO.InvestFunda;
using Excel = Microsoft.Office.Interop.Excel;

namespace Service
{


    public class InvestorFundaServices : IInvestorFundaServices
    {
        DateTime dateAndTime = DateTime.Now;

        [Serializable]
        public class Email
        {
            public Email()
            {
                this.Attachments = new List<Attachment>();
            }
            public int MessageNumber { get; set; }
            public string From { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public DateTime DateSent { get; set; }
            public List<Attachment> Attachments { get; set; }
        }
        [Serializable]
        public class Attachment
        {
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public byte[] Content { get; set; }
        }
        public static List<Message> FetchAllMessages()
        {
            // The client disconnects from the server when being disposed
            using (Pop3Client client = new Pop3Client())
            {

                Uri myUri = new Uri("http://ccc");
                string host = myUri.Host;
                // Connect to the server
                client.Connect("mail.assortstaffing.com", 110, false);

                // Authenticate ourselves towards the server
                client.Authenticate("info@assortstaffing.com", "Lz*zf893");

                // Get the number of messages in the inbox
                int messageCount = client.GetMessageCount();

                // We want to download all messages
                List<Message> allMessages = new List<Message>(messageCount);

                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                // Most servers give the latest message the highest number
                for (int i = messageCount; i > 0; i--)
                {
                    allMessages.Add(client.GetMessage(i));
                }

                // Now return the fetched messages
                return allMessages;
            }
        }

        private void Read_Emails()
        {
            List<Message> Mss = FetchAllMessages();

            using (Pop3 pop3 = new Pop3())
            {

                pop3.Connect("pop3.assortstaffing.com");  // or ConnectSSL for SSL
                MessagePart plainText = Mss[0].FindFirstPlainTextVersion();
                pop3.Login("info@assortstaffing.com", "Lz*zf893");
                if (plainText != null)
                {
                    // The message had a text/plain version - show that one
                    string body = plainText.GetBodyAsText();
                }
                MessagePart xml = Mss[0].FindFirstMessagePartWithMediaType("text/xml");
                if (xml != null)
                {
                    // Get out the XML string from the email
                    string xmlString = xml.GetBodyAsText();

                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

                    // Load in the XML read from the email
                    doc.LoadXml(xmlString);

                    // Save the xml to the filesystem
                    doc.Save("test.xml");
                }
                // Receive all messages and display the subject 
                MailBuilder builder = new MailBuilder();
                List<string> uids = pop3.GetAll();
                foreach (string uid in uids)
                {
                    IMail email = new MailBuilder()
                        .CreateFromEml(pop3.GetMessageByUID(uid));

                    Console.WriteLine(email.Subject);
                    string data = Convert.ToString(email.Date);
                }
            }


        }
        public Response<ULogin> GetLogin(string UEmail, string password, string Type)
        {

            Response<ULogin> response = null;
            ULogin Logindetails = new ULogin();
            try
            {
                businessLayer businessLayer = new businessLayer();
                Logindetails = businessLayer.Login(UEmail, password, Type);
                response = new Response<ULogin>(Logindetails);
                if (Logindetails != null)
                {
                    if (response.Result.UR_ID != "" && response.Result.UR_ID != null && response.Result.FName != null && response.Result.LName != null)
                    {
                        response.ResponseCode = 0;
                        response.Status = "Login Successfully";
                        response.ResponseMessage = "Success";
                    }
                    else
                    {
                        response.ResponseCode = 1;
                        response.Status = "Faliure";
                        response.ResponseMessage = "Login details not available";
                    }
                }

            }
            catch (Exception ex)
            {
                response = new Response<ULogin>(Logindetails);
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<ULogin> GetUserDetailsByID(string UserID)
        {

            Response<ULogin> response = null;
            ULogin Logindetails = new ULogin();
            try
            {
                businessLayer businessLayer = new businessLayer();
                Logindetails = businessLayer.GetUserDetailsByID(UserID);
                response = new Response<ULogin>(Logindetails);
                if (Logindetails != null)
                {
                    if (response.Result.UR_ID != "" && response.Result.UR_ID != null && response.Result.FName != null && response.Result.LName != null)
                    {
                        response.ResponseCode = 0;
                        response.Status = "Login Successfully";
                        response.ResponseMessage = "Success";
                    }
                    else
                    {
                        response.ResponseCode = 1;
                        response.Status = "Faliure";
                        response.ResponseMessage = "Login details not available";
                    }
                }

            }
            catch (Exception ex)
            {
                response = new Response<ULogin>(Logindetails);
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        public Response<List<Location>> GetLocation()
        {
            //Read_Emails();
            Response<List<Location>> response = new Response<List<Location>>();
            List<Location> UserListLocation = new List<Location>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                UserListLocation = businessLayer.GetBusinessLocation();
                response.Result = UserListLocation;
                if (UserListLocation != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Login Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Login details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<Location>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        public Response<List<Location>> GetCompany()
        {

            Response<List<Location>> response = new Response<List<Location>>();
            List<Location> UserListLocation = new List<Location>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                UserListLocation = businessLayer.GetBusinessCompany();
                response.Result = UserListLocation;
                if (UserListLocation != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Login Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Login details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<Location>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        public Response<List<Issue>> GetIssue(string IssueID)
        {

            Response<List<Issue>> response = new Response<List<Issue>>();
            List<Issue> IssueList = new List<Issue>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                IssueList = businessLayer.GetIssue(IssueID);
                response.Result = IssueList;
                if (IssueList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "get details Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Details not found";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<Issue>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }


        public Response<List<Issue>> GetIssueRep(EmailRep EmailID)
        {

            Response<List<Issue>> response = new Response<List<Issue>>();
            List<Issue> IssueList = new List<Issue>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                IssueList = businessLayer.GetIssueRep(EmailID);
                response.Result = IssueList;
                if (IssueList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "get details Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Details not found";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<Issue>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<List<Issue>> GetIssueByClient(string ClientID)
        {

            Response<List<Issue>> response = new Response<List<Issue>>();
            List<Issue> IssueList = new List<Issue>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                IssueList = businessLayer.GetIssueByClient(ClientID);
                response.Result = IssueList;
                if (IssueList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "get details Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Details not found";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<Issue>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<List<Issue>> GetIssueViaRm(string Rm_ID)
        {

            Response<List<Issue>> response = new Response<List<Issue>>();
            List<Issue> IssueList = new List<Issue>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                IssueList = businessLayer.GetIssueViaRm(Rm_ID);
                response.Result = IssueList;
                if (IssueList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "get details Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Details not found";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<Issue>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<List<DashBoardData>> GetDashBoard(string ID, string Type)
        {

            Response<List<DashBoardData>> response = new Response<List<DashBoardData>>();
            List<DashBoardData> DashboardList = new List<DashBoardData>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                DashboardList = businessLayer.GetDashBoard(ID, Type);
                response.Result = DashboardList;
                if (DashboardList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Dashboard details Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Details not found";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<DashBoardData>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<List<AddCardClient>> GetCardClient(string ClientID)
        {

            Response<List<AddCardClient>> response = new Response<List<AddCardClient>>();
            List<AddCardClient> IssueList = new List<AddCardClient>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                IssueList = businessLayer.GetCardClientBusiness(ClientID);
                response.Result = IssueList;
                if (IssueList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "get details Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Details not found";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<AddCardClient>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        public Response<List<GetDocsListCl>> GetDocsList(string ClientID)
        {

            Response<List<GetDocsListCl>> response = new Response<List<GetDocsListCl>>();
            List<GetDocsListCl> IssueList = new List<GetDocsListCl>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                IssueList = businessLayer.GetDocsList(ClientID);
                response.Result = IssueList;
                if (IssueList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "get details Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Details not found";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<GetDocsListCl>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        public Response<List<Issue>> GetIssueViaRmList(string Rm_ID)
        {

            Response<List<Issue>> response = new Response<List<Issue>>();
            List<Issue> IssueList = new List<Issue>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                IssueList = businessLayer.GetIssueViaRmList(Rm_ID);
                response.Result = IssueList;
                if (IssueList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "get details Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Details not found";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<Issue>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        public Response<List<ULogin>> GetUserList()
        {

            Response<List<ULogin>> response = new Response<List<ULogin>>();
            List<ULogin> UserList = new List<ULogin>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                UserList = businessLayer.GetBusinessUserList();
                response.Result = UserList;
                if (UserList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "User Details Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Login details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<ULogin>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<List<SkillsCategory>> GetSkillsCategory()
        {

            Response<List<SkillsCategory>> response = new Response<List<SkillsCategory>>();
            List<SkillsCategory> UserListSkillsCategory = new List<SkillsCategory>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                UserListSkillsCategory = businessLayer.GetBusinessSkillsCategory();
                response.Result = UserListSkillsCategory;
                if (UserListSkillsCategory != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Skills Category Fetched Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Skills Category details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<SkillsCategory>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }


        public Response<List<IndustryLists>> GetIndustryList()
        {

            Response<List<IndustryLists>> response = new Response<List<IndustryLists>>();
            List<IndustryLists> IndustryList = new List<IndustryLists>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                IndustryList = businessLayer.GetBusinessIndustryList();
                response.Result = IndustryList;
                if (IndustryList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Industry Name Fetched Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Industry Name details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<IndustryLists>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<List<AddOtherDetails>> GetOtherDetails(string ID)
        {

            Response<List<AddOtherDetails>> response = new Response<List<AddOtherDetails>>();
            List<AddOtherDetails> ClientList = new List<AddOtherDetails>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                ClientList = businessLayer.GetOtherDetails(ID);
                response.Result = ClientList;
                if (ClientList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Industry Name Fetched Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Industry Name details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<AddOtherDetails>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<string> addClientDashboard(addClientDash request)
        {
            Response<string> response = new Response<string>();

            try
            {
                int x = Globals.GlobalClientCode;
                DateTime dateTime = DateTime.UtcNow.Date;
                if (dateTime.ToString("yyyy|MM|dd") != Convert.ToString(Globals.GlobalCurrentDate))
                {
                    Globals.SetGlobalDate(dateTime.ToString("MMyyyy"));
                }
                string UniqueString = Convert.ToString(Globals.GlobalCurrentDate) + Convert.ToString(x);



                businessLayer businessLayer = new businessLayer();
                response = businessLayer.addClientDashboard(request);
                if (response.ResponseCode == 3)
                {
                    Globals.SetGlobalClientCode(x + 1);
                    addClientDashboard(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {
                        Globals.SetGlobalClientCode(x + 1);

                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public List<addClientDash> GetClientDashListDVal1(string ClientID)
        {
            List<addClientDash> objResponse = new List<addClientDash>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetClientDashList(ClientID);

            return objResponse;
        }

        public Response<List<AddClient>> GetclientList(string ClientID)
        {

            Response<List<AddClient>> response = new Response<List<AddClient>>();
            List<AddClient> ClientList = new List<AddClient>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                ClientList = businessLayer.GetBusinessClientList(ClientID);
                response.Result = ClientList;
                if (ClientList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Industry Name Fetched Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Industry Name details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<AddClient>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<List<AddRelationshipManager>> GetRelationshipManager(string Rm_ID)
        {

            Response<List<AddRelationshipManager>> response = new Response<List<AddRelationshipManager>>();
            List<AddRelationshipManager> RMList = new List<AddRelationshipManager>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                RMList = businessLayer.GetRelationshipManager(Rm_ID);
                response.Result = RMList;
                if (RMList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Relationship Fetched Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Relationship details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<AddRelationshipManager>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        public Response<List<SkillsName>> GetSkillsName()
        {

            Response<List<SkillsName>> response = new Response<List<SkillsName>>();
            List<SkillsName> UserListSkillsName = new List<SkillsName>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                UserListSkillsName = businessLayer.GetBusinessSkillsName();
                response.Result = UserListSkillsName;
                if (UserListSkillsName != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Skills Name Fetched Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Skills Name details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<SkillsName>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        public Response<List<JobList>> GetJobClientList(string ClientID)
        {

            Response<List<JobList>> response = new Response<List<JobList>>();
            List<JobList> ClientJobList = new List<JobList>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                ClientJobList = businessLayer.GetJobClientList(ClientID);
                response.Result = ClientJobList;
                if (ClientJobList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Job Fetched Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Job  details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<JobList>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        public Response<ULogin> UpdatePassworduser(string UEmail, string password)
        {

            Response<ULogin> response = null;
            ULogin Logindetails = new ULogin();
            try
            {
                businessLayer businessLayer = new businessLayer();
                Logindetails = businessLayer.UpdateBusinessPassword(UEmail, password);
                response = new Response<ULogin>(Logindetails);
                if (Logindetails != null)
                {
                    if (response.Result.UR_ID != "" && response.Result.UR_ID != null)
                    {
                        response.ResponseCode = 0;
                        response.Status = "Password Updated Successfully";
                        response.ResponseMessage = "Success";
                    }
                    else
                    {
                        response.ResponseCode = 1;
                        response.Status = "Faliure";
                        response.ResponseMessage = "Login details not available";
                    }
                }

            }
            catch (Exception ex)
            {
                response = new Response<ULogin>(Logindetails);
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        public Response<string> UserRegistration(RegistrationData request)
        {
            Response<string> response = new Response<string>();

            try
            {
                int x = Globals.GlobalClientCode;
                DateTime dateTime = DateTime.UtcNow.Date;
                if (dateTime.ToString("yyyy|MM|dd") != Convert.ToString(Globals.GlobalCurrentDate))
                {
                    Globals.SetGlobalDate(dateTime.ToString("MMyyyy"));
                }
                string UniqueString = Convert.ToString(Globals.GlobalCurrentDate) + Convert.ToString(x);



                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UserRegistration(request);
                if (response.ResponseCode == 3)
                {
                    Globals.SetGlobalClientCode(x + 1);
                    UserRegistration(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {
                        Globals.SetGlobalClientCode(x + 1);
                        response.ResponseMessage = "Thanks for registering with us " + request.UR_First_Name;
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> AddClient(AddClient request)
        {
            Response<string> response = new Response<string>();

            try
            {
                int x = Globals.GlobalClientCode;
                DateTime dateTime = DateTime.UtcNow.Date;
                if (dateTime.ToString("yyyy|MM|dd") != Convert.ToString(Globals.GlobalCurrentDate))
                {
                    Globals.SetGlobalDate(dateTime.ToString("MMyyyy"));
                }
                string UniqueString = Convert.ToString(Globals.GlobalCurrentDate) + Convert.ToString(x);



                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AddClient(request);
                if (response.ResponseCode == 3)
                {
                    Globals.SetGlobalClientCode(x + 1);
                    AddClient(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {
                        Globals.SetGlobalClientCode(x + 1);

                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> Forgotpassword(string UEmail, string UPassword)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.Forgotpassword(UEmail, UPassword);
                if (response.ResponseCode == 3)
                {

                    Forgotpassword(UEmail, UPassword);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {


                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        public Response<string> AddRelationshipManager(AddRelationshipManager request)
        {
            Response<string> response = new Response<string>();

            try
            {
                int x = Globals.GlobalClientCode;
                DateTime dateTime = DateTime.UtcNow.Date;
                if (dateTime.ToString("yyyy|MM|dd") != Convert.ToString(Globals.GlobalCurrentDate))
                {
                    Globals.SetGlobalDate(dateTime.ToString("MMyyyy"));
                }
                string UniqueString = Convert.ToString(Globals.GlobalCurrentDate) + Convert.ToString(x);



                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AddRelationshipManager(request);
                if (response.ResponseCode == 3)
                {
                    Globals.SetGlobalClientCode(x + 1);
                    AddRelationshipManager(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {
                        Globals.SetGlobalClientCode(x + 1);

                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> newsAndMediaPost(newsAndMedia request)
        {
            Response<string> response = new Response<string>();

            try
            {
                int x = Globals.GlobalClientCode;
                DateTime dateTime = DateTime.UtcNow.Date;
                if (dateTime.ToString("yyyy|MM|dd") != Convert.ToString(Globals.GlobalCurrentDate))
                {
                    Globals.SetGlobalDate(dateTime.ToString("MMyyyy"));
                }
                string UniqueString = Convert.ToString(Globals.GlobalCurrentDate) + Convert.ToString(x);



                businessLayer businessLayer = new businessLayer();
                response = businessLayer.newsAndMediaPost(request);
                if (response.ResponseCode == 3)
                {
                    Globals.SetGlobalClientCode(x + 1);
                    newsAndMediaPost(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {
                        Globals.SetGlobalClientCode(x + 1);

                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> blogPost(Blogs request)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.blogPost(request);
                if (response.ResponseCode == 3)
                {


                    blogPost(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<List<newsAndMedia>> GetnewsAndMedia()
        {

            Response<List<newsAndMedia>> response = new Response<List<newsAndMedia>>();
            List<newsAndMedia> NewsList = new List<newsAndMedia>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                NewsList = businessLayer.GetnewsAndMedia();
                response.Result = NewsList;
                if (NewsList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "News And Media Fetched Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "News And Media details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<newsAndMedia>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<List<Blogs>> GetBlogs()
        {

            Response<List<Blogs>> response = new Response<List<Blogs>>();
            List<Blogs> BlogList = new List<Blogs>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                BlogList = businessLayer.GetBlogs();
                response.Result = BlogList;
                if (BlogList != null)
                {

                    response.ResponseCode = 0;
                    response.Status = "Blog Fetched Successfully";
                    response.ResponseMessage = "Success";

                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Faliure";
                    response.ResponseMessage = "Blog details not available";
                }

            }
            catch (Exception ex)
            {
                response = new Response<List<Blogs>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public Response<string> AssignUClient(AssignUClient request)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AssignUClient(request);
                if (response.ResponseCode == 3)
                {

                    AssignUClient(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Assigned Succesfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> UpdateUserDetails(ULogin request)
        {
            Response<string> response = new Response<string>();

            try
            {
                int x = Globals.GlobalClientCode;
                DateTime dateTime = DateTime.UtcNow.Date;
                if (dateTime.ToString("yyyy|MM|dd") != Convert.ToString(Globals.GlobalCurrentDate))
                {
                    Globals.SetGlobalDate(dateTime.ToString("MMyyyy"));
                }
                string UniqueString = Convert.ToString(Globals.GlobalCurrentDate) + Convert.ToString(x);



                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UserDetailsUpdate(request);
                if (response.ResponseCode == 3)
                {
                    Globals.SetGlobalClientCode(x + 1);
                    UpdateUserDetails(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {
                        Globals.SetGlobalClientCode(x + 1);
                        response.ResponseMessage = "Thanks for registering with us " + request.FName;
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        public static List<Message> FetchAllMessagesFromEmail(string hostname, int port, bool useSsl, string username, string password)
        {
            // The client disconnects from the server when being disposed
            using (Pop3Client client = new Pop3Client())
            {


                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // Get the number of messages in the inbox
                int messageCount = client.GetMessageCount();

                // We want to download all messages
                List<Message> allMessages = new List<Message>(messageCount);

                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                // Most servers give the latest message the highest number
                try
                {
                    for (int i = messageCount; i > messageCount - 6; i--)
                    {
                        allMessages.Add(client.GetMessage(i));
                    }
                }
                catch
                {

                }


                // Now return the fetched messages
                return allMessages;
            }
        }
        public Response<string> CreateUpdateIssueWidthEmail()
        {

            sendEmailIt();
            return sendEmailSales();
        }

        public Response<string> sendEmailSales()
        {
            Response<string> response = new Response<string>();

            try
            {
                Issue request = new Issue();
                List<Message> Mess = FetchAllMessagesFromEmail("mail.assortstaffing.com", 110, false, "sales@assortstaffing.com", "xiqS853#");
                for (var i = 0; i < 5; i++)
                {
                    int x = Globals.GlobalIntID;
                    Globals.SetGlobalIntID(x + 1);
                    long alwaysIncrementeduniqueNum = Globals.GlobalIntID;

                    string UUID = "ASS:" + alwaysIncrementeduniqueNum + "/" + dateAndTime.ToString("dd/MM/yyyy");


                    List<GetRmViaDepCls> Mst = GetRmEmailViaDep("sales");

                    for (var j = 0; j < Mst.Count; j++)
                    {
                        request.ClientEmail = Convert.ToString(Mess[i].Headers.From);
                        request.ClientEmail = request.ClientEmail.Split('<')[1].Split('>')[0];
                        request.IssueSubject = Convert.ToString(Mess[i].Headers.Subject);
                        request.IssuedTo = Mst[j].EmailID;
                        request.ClientID = Mst[j].ID;
                        request.EmailID = Mess[i].Headers.MessageId;


                        MessagePart plainText = Mess[i].FindFirstPlainTextVersion();
                        if (plainText != null)
                        {
                            // The message had a text/plain version - show that one
                            string body = plainText.GetBodyAsText();
                            request.IssueBody = body;
                        }
                        else
                        {
                            request.IssueBody = "";
                        }
                        request.IssueAttachmentUrl = "";
                        request.IssuState = "OPEN";
                        request.IsReminder = "0";
                        request.EventType = "CREATE";
                        request.ReciveDate = Convert.ToString(Mess[i].Headers.Date);
                        businessLayer businessLayer = new businessLayer();
                        if (Mess[i].Headers.References.Count > 0)
                        {
                            request.RepEmailID = Convert.ToString(Mess[i].Headers.InReplyTo[0]);
                            response = businessLayer.CreateUpdateIssueFromEmailReply(request);
                        }
                        else
                        {
                            response = businessLayer.CreateUpdateIssueFromEmail(request);
                        }
                    }





                }




            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> sendEmailIt()
        {
            Response<string> response = new Response<string>();

            try
            {
                Issue request = new Issue();
                List<Message> Mess = FetchAllMessagesFromEmail("mail.assortstaffing.com", 110, false, "it@assortstaffing.com", "Nk8d4j$6");
                for (var i = 0; i < 5; i++)
                {
                    int x = Globals.GlobalIntID;
                    Globals.SetGlobalIntID(x + 1);
                    long alwaysIncrementeduniqueNum = Globals.GlobalIntID;

                    string UUID = "ASS:" + alwaysIncrementeduniqueNum + "/" + dateAndTime.ToString("dd/MM/yyyy");


                    List<GetRmViaDepCls> Mst = GetRmEmailViaDep("it");
                    string emails = "",
                           ids = "";
                    for (var j = 0; j < Mst.Count; j++)
                    {
                        emails = emails + "," + Mst[j].EmailID;
                        ids = ids + "," + Mst[j].ID;
                    }
                    request.ClientEmail = Convert.ToString(Mess[i].Headers.From);

                    request.ClientEmail = request.ClientEmail.Split('<')[1].Split('>')[0];
                    request.IssueSubject = Convert.ToString(Mess[i].Headers.Subject);
                    request.IssuedTo = emails;
                    request.UUID = UUID;
                    request.ClientID = ids;
                    request.EmailID = Mess[i].Headers.MessageId;


                    MessagePart plainText = Mess[i].FindFirstPlainTextVersion();
                    if (plainText != null)
                    {
                        // The message had a text/plain version - show that one
                        string body = plainText.GetBodyAsText();
                        request.IssueBody = body;
                    }
                    else
                    {
                        request.IssueBody = "";
                    }
                    request.IssueAttachmentUrl = "";
                    request.IssuState = "OPEN";
                    request.IsReminder = "0";
                    request.EventType = "CREATE";
                    request.ReciveDate = Convert.ToString(Mess[i].Headers.Date);
                    businessLayer businessLayer = new businessLayer();
                    if (Mess[i].Headers.References.Count > 0)
                    {
                        request.RepEmailID = Convert.ToString(Mess[i].Headers.InReplyTo[0]);
                        response = businessLayer.CreateUpdateIssueFromEmailReply(request);
                    }
                    else
                    {
                        response = businessLayer.CreateUpdateIssueFromEmail(request);
                    }




                }




            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }


        public List<GetRmViaDepCls> GetRmEmailViaDep(string Dept)
        {
            List<GetRmViaDepCls> objResponse = new List<GetRmViaDepCls>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetRmEmailViaDep(Dept);

            return objResponse;
        }

        public Response<string> CreateUpdateIssue(Issue request)
        {
            Response<string> response = new Response<string>();

            try
            {
                int x = Globals.GlobalClientCode;
                DateTime dateTime = DateTime.UtcNow.Date;
                if (dateTime.ToString("yyyy|MM|dd") != Convert.ToString(Globals.GlobalCurrentDate))
                {
                    Globals.SetGlobalDate(dateTime.ToString("MMyyyy"));
                }
                string UniqueString = Convert.ToString(Globals.GlobalCurrentDate) + Convert.ToString(x);



                businessLayer businessLayer = new businessLayer();
                response = businessLayer.CreateUpdateIssue(request);
                if (response.ResponseCode == 3)
                {
                    Globals.SetGlobalClientCode(x + 1);
                    CreateUpdateIssue(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {
                        Globals.SetGlobalClientCode(x + 1);
                        response.ResponseMessage = "Thanks for creating issue ";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> DeleteJob(string jobID)
        {
            Response<string> response = new Response<string>();

            try
            {

                businessLayer businessLayer = new businessLayer();
                response = businessLayer.DeleteJob(jobID);
                if (response.ResponseCode == 3)
                {
                    DeleteJob(jobID);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Job Deleted successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> ActDeactOperClient(string ClID, string Status)
        {
            Response<string> response = new Response<string>();

            try
            {

                businessLayer businessLayer = new businessLayer();
                response = businessLayer.ActDeactOperClient(ClID, Status);
                if (response.ResponseCode == 3)
                {
                    ActDeactOperClient(ClID, Status);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Job Deleted successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        public Response<string> AddUpdateTemporaryStaffing(TemporaryStaffing request)
        {
            Response<string> response = new Response<string>();

            try
            {

                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AddUpdateTemporaryStaffing(request);
                if (response.ResponseCode == 3)
                {
                    AddUpdateTemporaryStaffing(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Thanks for update and add temporary staffing";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        public Response<string> CreateJob(CreateJob request)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.CreatejobBuisiness(request);
                if (response.ResponseCode == 3)
                {

                    CreateJob(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Job Created Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        public Response<string> UpdateIssueStatus(updateIssueStatus IssueStatus)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UpdateIssueStatus(IssueStatus);
                if (response.ResponseCode == 3)
                {

                    UpdateIssueStatus(IssueStatus);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Applied Job Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> UpdateClientAgrement(Stream documentPath, string ClientID)
        {
            Response<string> response = new Response<string>();

            try
            {
                MultipartParser parser = Upload(documentPath);



                // Variables for the cloud storage objects.
                CloudStorageAccount cloudStorageAccount;
                CloudBlobClient blobClient;
                CloudBlobContainer blobContainer;
                BlobContainerPermissions containerPermissions;
                CloudBlob blob;
                cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=investorfundafile;AccountKey=XTWc5jDFzrI5rX4jEAvXYWRMeSnS5ngrZYlPhv9phyYQXi4PEkg3CIjNnVCbLPCuDy161MYdtJEAPhqv3TeEtg==");
                blobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container1 = blobClient.GetContainerReference("investorfunda");

                // Create the container if it doesn't already exist.
                container1.CreateIfNotExists();

                containerPermissions = new BlobContainerPermissions();
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;

                // MESSAGE SENT
                container1.SetPermissions(containerPermissions);
                long ticks = DateTime.Now.Ticks;
                byte[] bytes = BitConverter.GetBytes(ticks);
                string id = Convert.ToBase64String(bytes)
                                        .Replace('+', '_')
                                        .Replace('/', '-')
                                        .TrimEnd('=');
                CloudBlockBlob blockBlob = container1.GetBlockBlobReference(id + "_" + parser.Filename);
                blockBlob.Properties.ContentType = parser.ContentType;
                Stream stream = new MemoryStream(parser.FileContents);
                blockBlob.UploadFromStream(stream);
                string documentPathAzure = blockBlob.Uri.AbsoluteUri;
                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UpdateClientAgrement(documentPathAzure, ClientID);

                response.ResponseMessage = "Thanks for registering with us ";
            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> UpdateCandidateResume(Stream documentPath, string CandidateID)
        {
            Response<string> response = new Response<string>();

            try
            {
                MultipartParser parser = Upload(documentPath);



                // Variables for the cloud storage objects.
                CloudStorageAccount cloudStorageAccount;
                CloudBlobClient blobClient;
                CloudBlobContainer blobContainer;
                BlobContainerPermissions containerPermissions;
                CloudBlob blob;
                cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=investorfundafile;AccountKey=XTWc5jDFzrI5rX4jEAvXYWRMeSnS5ngrZYlPhv9phyYQXi4PEkg3CIjNnVCbLPCuDy161MYdtJEAPhqv3TeEtg==");
                blobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container1 = blobClient.GetContainerReference("investorfunda");

                // Create the container if it doesn't already exist.
                container1.CreateIfNotExists();

                containerPermissions = new BlobContainerPermissions();
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;

                // MESSAGE SENT
                container1.SetPermissions(containerPermissions);
                long ticks = DateTime.Now.Ticks;
                byte[] bytes = BitConverter.GetBytes(ticks);
                string id = Convert.ToBase64String(bytes)
                                        .Replace('+', '_')
                                        .Replace('/', '-')
                                        .TrimEnd('=');
                CloudBlockBlob blockBlob = container1.GetBlockBlobReference(id + "_" + parser.Filename);
                blockBlob.Properties.ContentType = parser.ContentType;
                Stream stream = new MemoryStream(parser.FileContents);
                blockBlob.UploadFromStream(stream);
                string documentPathAzure = blockBlob.Uri.AbsoluteUri;





                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UpdateCandidateResume(documentPathAzure, CandidateID);

                response.ResponseMessage = "Thanks for registering with us ";
            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> deleteClient(string ID)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.deleteClient(ID);
                if (response.ResponseCode == 3)
                {

                    deleteClient(ID);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Applied Job Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> deleteRM(string RMID)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.deleteRM(RMID);
                if (response.ResponseCode == 3)
                {

                    deleteRM(RMID);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Applied Job Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> deleteNews(string NEWSID)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.deleteNews(NEWSID);
                if (response.ResponseCode == 3)
                {

                    deleteRM(NEWSID);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Deleted news Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> deleteBlog(string BLOGID)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.deleteBlog(BLOGID);
                if (response.ResponseCode == 3)
                {

                    deleteBlog(BLOGID);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Deleted blog Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> UpdateCandidateImage(Stream documentPath, string CandidateID)
        {
            Response<string> response = new Response<string>();

            try
            {
                MultipartParser parser = Upload(documentPath);



                // Variables for the cloud storage objects.
                CloudStorageAccount cloudStorageAccount;
                CloudBlobClient blobClient;
                CloudBlobContainer blobContainer;
                BlobContainerPermissions containerPermissions;
                CloudBlob blob;
                cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=investorfundafile;AccountKey=XTWc5jDFzrI5rX4jEAvXYWRMeSnS5ngrZYlPhv9phyYQXi4PEkg3CIjNnVCbLPCuDy161MYdtJEAPhqv3TeEtg==");
                blobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container1 = blobClient.GetContainerReference("investorfunda");

                // Create the container if it doesn't already exist.
                container1.CreateIfNotExists();

                containerPermissions = new BlobContainerPermissions();
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;

                // MESSAGE SENT
                container1.SetPermissions(containerPermissions);
                long ticks = DateTime.Now.Ticks;
                byte[] bytes = BitConverter.GetBytes(ticks);
                string id = Convert.ToBase64String(bytes)
                                        .Replace('+', '_')
                                        .Replace('/', '-')
                                        .TrimEnd('=');
                CloudBlockBlob blockBlob = container1.GetBlockBlobReference(id + "_" + parser.Filename);
                blockBlob.Properties.ContentType = parser.ContentType;
                Stream stream = new MemoryStream(parser.FileContents);
                blockBlob.UploadFromStream(stream);
                string documentPathAzure = blockBlob.Uri.AbsoluteUri;





                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UpdateCandidateImage(documentPathAzure, CandidateID);

                response.ResponseMessage = "Thanks for registering with us ";
            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public void readExcel(string documentPathAzure)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            InsertCandExcel InCandExc = new InsertCandExcel();

            string str;
            int rCnt;
            int cCnt;
            int rw = 0;
            int cl = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(documentPathAzure, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;


            for (rCnt = 2; rCnt <= rw; rCnt++)
            {
                for (cCnt = 1; cCnt <= cl; cCnt++)
                {
                    str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;

                    if (cCnt == 1)
                    {
                        InCandExc.Empcode = str;

                    }
                    else if (cCnt == 2)
                    {
                        InCandExc.StaffId = str;
                    }
                    else if (cCnt == 3)
                    {
                        InCandExc.FirstName = str;
                    }
                    else if (cCnt == 4)
                    {
                        InCandExc.MiddleName = str;
                    }
                    else if (cCnt == 5)
                    {
                        InCandExc.LastName = str;
                    }
                    else if (cCnt == 6)
                    {
                        InCandExc.Gender = str;
                    }
                    else if (cCnt == 7)
                    {
                        InCandExc.FatherName = str;
                    }

                    else if (cCnt == 8)
                    {
                        InCandExc.DOJ = str;
                    }
                    else if (cCnt == 9)
                    {
                        InCandExc.DOA = str;
                    }
                    else if (cCnt == 10)
                    {
                        InCandExc.DOB = str;
                    }
                    else if (cCnt == 11)
                    {
                        InCandExc.Leave_TemplateID = str;
                    }
                    else if (cCnt == 12)
                    {
                        InCandExc.Leave_AssignDate = str;
                    }
                    else if (cCnt == 13)
                    {
                        InCandExc.Reporting_Manager = str;
                    }
                    else if (cCnt == 14)
                    {
                        InCandExc.Reporting_HR = str;
                    }
                    else if (cCnt == 15)
                    {
                        InCandExc.EmailID_CC = str;
                    }
                    else if (cCnt == 16)
                    {
                        InCandExc.Nationality = str;
                    }
                    else if (cCnt == 17)
                    {
                        InCandExc.Effective_From = str;
                    }
                    else if (cCnt == 18)
                    {
                        InCandExc.Deptcode = str;
                    }
                    else if (cCnt == 19)
                    {
                        InCandExc.SubDept = str;
                    }

                    else if (cCnt == 20)
                    {
                        InCandExc.Desigcode = str;
                    }
                    else if (cCnt == 21)
                    {
                        InCandExc.Gradecode = str;
                    }
                    else if (cCnt == 22)
                    {
                        InCandExc.Categorycode = str;
                    }
                    else if (cCnt == 23)
                    {
                        InCandExc.LevelCode = str;
                    }
                    else if (cCnt == 24)
                    {
                        InCandExc.Salaried = str;
                    }
                    else if (cCnt == 25)
                    {
                        InCandExc.Costcenter = str;
                    }
                    else if (cCnt == 26)
                    {
                        InCandExc.Unitcode = str;
                    }
                    else if (cCnt == 27)
                    {
                        InCandExc.Amount_Paid_In = str;
                    }
                    else if (cCnt == 28)
                    {
                        InCandExc.Contact_Address1 = str;
                    }
                    else if (cCnt == 29)
                    {
                        InCandExc.Contact_Address2 = str;
                    }
                    else if (cCnt == 30)
                    {
                        InCandExc.Contact_Address_Citycode = str;
                    }
                    else if (cCnt == 31)
                    {
                        InCandExc.Contact_Address_Zipcode = str;
                    }
                    else if (cCnt == 32)
                    {
                        InCandExc.Permanent_Address1 = str;
                    }
                    else if (cCnt == 33)
                    {
                        InCandExc.Permanent_Address2 = str;
                    }
                    else if (cCnt == 34)
                    {
                        InCandExc.Permanent_Address_Citycode = str;
                    }
                    else if (cCnt == 35)
                    {
                        InCandExc.Permanent_Address_Zipcode = str;
                    }
                    else if (cCnt == 36)
                    {
                        InCandExc.ESIAPP = str;
                    }
                    else if (cCnt == 37)
                    {
                        InCandExc.ESINo = str;
                    }
                    else if (cCnt == 38)
                    {
                        InCandExc.ESI_Dispensory_Name = str;
                    }

                    else if (cCnt == 39)
                    {
                        InCandExc.Deduct_ESI_on_OT = str;
                    }
                    else if (cCnt == 40)
                    {
                        InCandExc.PFAPP = str;
                    }
                    else if (cCnt == 41)
                    {
                        InCandExc.PFNo = str;
                    }
                    else if (cCnt == 42)
                    {
                        InCandExc.PFLimit = str;
                    }
                    else if (cCnt == 43)
                    {
                        InCandExc.PensionNo = str;
                    }
                    else if (cCnt == 44)
                    {
                        InCandExc.Pan_No = str;
                    }
                    else if (cCnt == 45)
                    {
                        InCandExc.PT_App = str;
                    }
                    else if (cCnt == 46)
                    {
                        InCandExc.Labour_Welfare_Fund_Applicable = str;
                    }
                    else if (cCnt == 47)
                    {
                        InCandExc.Mob_No = str;
                    }
                    else if (cCnt == 48)
                    {
                        InCandExc.Finalized = str;
                    }
                    else if (cCnt == 49)
                    {
                        InCandExc.Settlement_Date = str;
                    }
                    else if (cCnt == 50)
                    {
                        InCandExc.DOL = str;
                    }
                    else if (cCnt == 51)
                    {
                        InCandExc.DolForm10 = str;
                    }
                    else if (cCnt == 52)
                    {
                        InCandExc.Project_income_till_date = str;
                    }
                    else if (cCnt == 53)
                    {
                        InCandExc.Passport_No = str;
                    }
                    else if (cCnt == 54)
                    {
                        InCandExc.Passport_Issue_Office = str;
                    }
                    else if (cCnt == 55)
                    {
                        InCandExc.Passport_Issue_Date = str;
                    }
                    else if (cCnt == 56)
                    {
                        InCandExc.Passport_Expiry_Date = str;
                    }
                    else if (cCnt == 57)
                    {
                        InCandExc.DOC = str;
                    }
                    else if (cCnt == 58)
                    {
                        InCandExc.DOG = str;
                    }
                    else if (cCnt == 59)
                    {
                        InCandExc.DOJForm5 = str;
                    }
                    else if (cCnt == 60)
                    {
                        InCandExc.Contract_SDate = str;
                    }
                    else if (cCnt == 61)
                    {
                        InCandExc.Contract_EDate = str;
                    }
                    else if (cCnt == 62)
                    {
                        InCandExc.ParentMedClaim = str;
                    }
                    else if (cCnt == 63)
                    {
                        InCandExc.Password = str;

                    }

                    else if (cCnt == 64)
                    {
                        InCandExc.MaritalStatus = str;
                    }
                    else if (cCnt == 65)
                    {
                        InCandExc.MarriageDate = str;
                    }
                    else if (cCnt == 66)
                    {
                        InCandExc.SpouseName = str;
                    }
                    else if (cCnt == 67)
                    {
                        InCandExc.Spouse_Date_of_Birth = str;
                    }
                    else if (cCnt == 68)
                    {
                        InCandExc.Total_Number_of_Children = str;

                    }
                    else if (cCnt == 69)
                    {
                        InCandExc.Total_Number_of_School_Going_Children = str;

                    }
                    else if (cCnt == 70)
                    {
                        InCandExc.Total_Number_of_Children_In_Hostel = str;

                    }
                    else if (cCnt == 71)
                    {
                        InCandExc.No_of_dependent = str;

                    }
                    else if (cCnt == 72)
                    {
                        InCandExc.Emergency_Contact1_Name = str;

                    }
                    else if (cCnt == 73)
                    {
                        InCandExc.Emergency_Contact1_Relation = str;

                    }
                    else if (cCnt == 74)
                    {
                        InCandExc.Emergency_Contact1_Address = str;

                    }

                    else if (cCnt == 75)
                    {
                        InCandExc.Emergency_Contact1_Email = str;

                    }
                    else if (cCnt == 76)
                    {
                        InCandExc.Emergency_Contact1_Landline_No = str;


                    }
                    else if (cCnt == 77)
                    {
                        InCandExc.Emergency_Contact1_Mobile_No = str;

                    }
                    else if (cCnt == 78)
                    {
                        InCandExc.Emergency_Contact2_Name = str;

                    }
                    else if (cCnt == 79)
                    {
                        InCandExc.Emergency_Contact2_Relation = str;

                    }
                    else if (cCnt == 80)
                    {
                        InCandExc.Emergency_Contact2_Email = str;

                    }
                    else if (cCnt == 81)
                    {
                        InCandExc.Emergency_Contact2_Landline_No = str;

                    }
                    else if (cCnt == 82)
                    {
                        InCandExc.Emergency_Contact2_Mobile_No = str;

                    }
                    else if (cCnt == 83)
                    {
                        InCandExc.Field1 = str;

                    }
                    else if (cCnt == 84)
                    {
                        InCandExc.Field2 = str;

                    }
                    else if (cCnt == 85)
                    {
                        InCandExc.Field3 = str;

                    }
                    else if (cCnt == 86)
                    {
                        InCandExc.Field4 = str;

                    }
                    else if (cCnt == 87)
                    {
                        InCandExc.Field5 = str;

                    }
                    else if (cCnt == 88)
                    {
                        InCandExc.Field6 = str;

                    }

                    else if (cCnt == 89)
                    {
                        InCandExc.OT_App = str;

                    }
                    else if (cCnt == 90)
                    {
                        InCandExc.Attendance_Rule_Not_Applicable = str;

                    }
                    else if (cCnt == 91)
                    {
                        InCandExc.OT_Temp_For_Normal_Days = str;

                    }
                    else if (cCnt == 92)
                    {
                        InCandExc.OT_Temp_For_Weekly_Off = str;

                    }
                    else if (cCnt == 93)
                    {
                        InCandExc.OT_Temp_For_Holidays = str;

                    }
                    else if (cCnt == 94)
                    {
                        InCandExc.Struct_Comb = str;

                    }
                    else if (cCnt == 95)
                    {
                        InCandExc.OT_Comb = str;

                    }
                    else if (cCnt == 96)
                    {
                        InCandExc.HRA_RENT = str;

                    }
                    else if (cCnt == 97)
                    {
                        InCandExc.Confirm_Status = str;

                    }
                    else if (cCnt == 98)
                    {
                        InCandExc.Bonus_Coverage = str;

                    }
                    else if (cCnt == 99)
                    {
                        InCandExc.Plant_Incentive_App = str;

                    }
                    else if (cCnt == 100)
                    {
                        InCandExc.Plant_Incentive_Per = str;

                    }
                    else if (cCnt == 101)
                    {
                        InCandExc.Retirement_Flag = str;

                    }
                    else if (cCnt == 102)
                    {
                        InCandExc.Customized_PF_Option = str;

                    }
                    else if (cCnt == 103)
                    {
                        InCandExc.Customized_ESI_Option = str;

                    }
                    else if (cCnt == 104)
                    {
                        InCandExc.Customized_LWF_Option = str;

                    }
                    else if (cCnt == 105)
                    {
                        InCandExc.OT_Part_of_Gross = str;

                    }
                    else if (cCnt == 106)
                    {
                        InCandExc.Customized_OT_Part_of_Gross = str;

                    }
                    else if (cCnt == 107)
                    {
                        InCandExc.Customized_ESI_deduction_on_OT = str;

                    }
                    else if (cCnt == 108)
                    {
                        InCandExc.Notice_Days = str;

                    }
                    else if (cCnt == 109)
                    {
                        InCandExc.Pension_Limit = str;

                    }

                    else if (cCnt == 110)
                    {
                        InCandExc.Expat = str;

                    }
                    else if (cCnt == 111)
                    {
                        InCandExc.Minimum_Hours_For_Saturday_Full_Day_Working = str;


                    }
                    else if (cCnt == 112)
                    {
                        InCandExc.BloodGroup_Code = str;

                    }

                }



            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }

        public Response<string> UpdateClientDocs(Stream documentPath, string ClientID, string DocType, string DocName)
        {
            Response<string> response = new Response<string>();

            try
            {
                MultipartParser parser = Upload(documentPath);



                // Variables for the cloud storage objects.
                CloudStorageAccount cloudStorageAccount;
                CloudBlobClient blobClient;
                CloudBlobContainer blobContainer;
                BlobContainerPermissions containerPermissions;
                CloudBlob blob;
                cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=investorfundafile;AccountKey=XTWc5jDFzrI5rX4jEAvXYWRMeSnS5ngrZYlPhv9phyYQXi4PEkg3CIjNnVCbLPCuDy161MYdtJEAPhqv3TeEtg==");
                blobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container1 = blobClient.GetContainerReference("investorfunda");

                // Create the container if it doesn't already exist.
                container1.CreateIfNotExists();

                containerPermissions = new BlobContainerPermissions();
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;

                // MESSAGE SENT
                container1.SetPermissions(containerPermissions);
                long ticks = DateTime.Now.Ticks;
                byte[] bytes = BitConverter.GetBytes(ticks);
                string id = Convert.ToBase64String(bytes)
                                        .Replace('+', '_')
                                        .Replace('/', '-')
                                        .TrimEnd('=');
                CloudBlockBlob blockBlob = container1.GetBlockBlobReference(id + "_" + parser.Filename);
                blockBlob.Properties.ContentType = parser.ContentType;
                Stream stream = new MemoryStream(parser.FileContents);
                blockBlob.UploadFromStream(stream);
                string documentPathAzure = blockBlob.Uri.AbsoluteUri;
                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UpdateClientDocs(documentPathAzure, ClientID, DocType, DocName);

                response.ResponseMessage = "Thanks for registering with us ";
            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        public Response<string> uploadCandidateList(Stream documentPath, string Candidate)
        {
            Response<string> response = new Response<string>();

            try
            {
                MultipartParser parser = Upload(documentPath);



                // Variables for the cloud storage objects.
                CloudStorageAccount cloudStorageAccount;
                CloudBlobClient blobClient;
                CloudBlobContainer blobContainer;
                BlobContainerPermissions containerPermissions;
                CloudBlob blob;
                cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=investorfundafile;AccountKey=XTWc5jDFzrI5rX4jEAvXYWRMeSnS5ngrZYlPhv9phyYQXi4PEkg3CIjNnVCbLPCuDy161MYdtJEAPhqv3TeEtg==");
                blobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container1 = blobClient.GetContainerReference("investorfunda");

                // Create the container if it doesn't already exist.
                container1.CreateIfNotExists();

                containerPermissions = new BlobContainerPermissions();
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;

                // MESSAGE SENT
                container1.SetPermissions(containerPermissions);
                long ticks = DateTime.Now.Ticks;
                byte[] bytes = BitConverter.GetBytes(ticks);
                string id = Convert.ToBase64String(bytes)
                                        .Replace('+', '_')
                                        .Replace('/', '-')
                                        .TrimEnd('=');
                CloudBlockBlob blockBlob = container1.GetBlockBlobReference(id + "_" + parser.Filename);
                blockBlob.Properties.ContentType = parser.ContentType;
                Stream stream = new MemoryStream(parser.FileContents);
                blockBlob.UploadFromStream(stream);
                string documentPathAzure = blockBlob.Uri.AbsoluteUri;
                readExcel(documentPathAzure);
                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UpdateCandidateResume(documentPathAzure, Candidate);

                response.ResponseMessage = "Thanks for registering with us ";
            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        public MultipartParser Upload(Stream stream)
        {
            //const string FUNCTION_NAME = "Upload ";
            try
            {
                MultipartParser parser = new MultipartParser(stream);
                if (parser.Success)
                {
                    return parser;
                }
                else
                {
                    return null;
                }
            }
            catch //(Exception ex)
            {
                return null;
            }
        }
        public Response<string> ApplyJob(string CandidateID, string JobID)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.ApplyJobBuisiness(CandidateID, JobID);
                if (response.ResponseCode == 3)
                {

                    ApplyJob(CandidateID, JobID);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Applied Job Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> AddLocation(AddLocation request)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AddLocationBuisiness(request);
                if (response.ResponseCode == 3)
                {

                    AddLocation(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Add Job Added Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }


        public Response<string> AddCardClient(AddCardClient request)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AddCardClientBuisiness(request);
                if (response.ResponseCode == 3)
                {

                    AddCardClient(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Add Card Added Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> AddSkillCategoryName(AddSkillCategoryName request)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AddSkillCategoryBuisiness(request);
                if (response.ResponseCode == 3)
                {

                    AddSkillCategoryName(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Add Job Added Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> AddSkillName(AddSkillName request)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AddSkillNameBuisiness(request);
                if (response.ResponseCode == 3)
                {

                    AddSkillName(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Add Job Added Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> AddIndustry(AddIndustry request)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AddIndustryBuisiness(request);
                if (response.ResponseCode == 3)
                {

                    AddIndustry(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Add Job Added Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> AddOtherDetails(AddOtherDetails request)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AddOtherDetails(request);
                if (response.ResponseCode == 3)
                {

                    AddOtherDetails(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = "Add Others Details Added Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> AddCompany(AddCompany request)
        {
            Response<string> response = new Response<string>();

            try
            {


                businessLayer businessLayer = new businessLayer();
                response = businessLayer.AddCompanyBuisiness(request);
                if (response.ResponseCode == 3)
                {

                    AddCompany(request);
                }
                else
                {
                    if (response.ResponseCode == 0)
                    {

                        response.ResponseMessage = " Added Company Successfully";
                    }
                }

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        public Response<GetJobs> GetJobAutoComplete(string LikeData, string SearchData)
        {
            Response<GetJobs> objResponse = new Response<GetJobs>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetJobAutoComplete(LikeData, SearchData);

            return objResponse;
        }
        public Response<GetJobs> GetJobList()
        {
            Response<GetJobs> objResponse = new Response<GetJobs>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetBusinessJobList();

            return objResponse;
        }
        public List<GetIssueDetails> GetIssueList()
        {
            List<GetIssueDetails> objResponse = new List<GetIssueDetails>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetIssueDetails();

            return objResponse;
        }
        public Response<GetAppliedJobsList> GetAppliedJobListByID(string JobID)
        {
            Response<GetAppliedJobsList> objResponse = new Response<GetAppliedJobsList>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetBusinessAppliedJobList(JobID);

            return objResponse;
        }
        public Response<GetAppliedJobsList> ShortlitedCandidateList()
        {
            Response<GetAppliedJobsList> objResponse = new Response<GetAppliedJobsList>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetShortlitedCandidateList();

            return objResponse;
        }

        public Response<GetJobs> GetJobListByID(string JobID)
        {
            Response<GetJobs> objResponse = new Response<GetJobs>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetBusinessJobListByID(JobID);

            return objResponse;
        }

        public Response<string> InsertShortListedCandidate(List<ShortlistedCandidate> ShortlistedCandidate)
        {
            Response<string> response = new Response<string>();

            try
            {
                businessLayer businessLayer = new businessLayer();
                response = businessLayer.InsertShortListedCandidate(ShortlistedCandidate);

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        public bool sendEmail(string to, string subject, string body)
        {
            using (var mail = new MailMessage("info@assortstaffing.com", to))
            {

                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;
                var smtp = new SmtpClient();
                smtp.Host = "mail.assortstaffing.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("info@assortstaffing.com", "Lz*zf893");
                smtp.Port = 587;
                smtp.Send(mail);
                return true;
            }
        }
    }
}
