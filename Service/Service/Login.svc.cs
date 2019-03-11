using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiceDTO;
using ServiceBusinessLayer;
using static ServiceDTO.InvestFunda;

namespace Service
{
   
    public class Login :ILogin
    {

        #region ALL GetAPIs ...............

        public Response<ULogin> GetLogin(string Uname, string password)
        {

            Response<ULogin> response = null;
            ULogin Logindetails = new ULogin();
            try
            {
                businessLayer businessLayer = new businessLayer();
                Logindetails = businessLayer.Login(Uname, password);
                response = new Response<ULogin>(Logindetails);
                if(Logindetails !=null)
                {
                    if (response.Result.LoginID != null && response.Result.Username != null && response.Result.Name != null)
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
        #endregion


        #region ALL POSTAPIs ...............


        public Response<string> UserRegistration(Dictionary<string, string> request)
        {
            Response<string> response = new Response<string>();

            try
            {
                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UserRegistration(request);

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

        public Response<List<Country>> GetCountryDetails()
        {
            throw new NotImplementedException();
        }

        public Response<List<State>> GetStateDetails(string Country_ID)
        {
            throw new NotImplementedException();
        }

        public Response<List<City>> GetCityDetails(string State_ID)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
