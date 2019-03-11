using ServiceDTO;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using static ServiceDTO.InvestFunda;

namespace Service
{

    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Login/{Uname}/{password}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<ULogin> GetLogin(string Uname, string password);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UserRegistration", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> UserRegistration(Dictionary<string, string> request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCountryDetails", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<List<Country>> GetCountryDetails();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetStateDetails/{Country_ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<List<State>> GetStateDetails(string Country_ID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCityDetails/{State_ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<List<City>> GetCityDetails(string State_ID);
    }
}
