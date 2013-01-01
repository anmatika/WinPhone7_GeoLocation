using System;
using RestSharp;

namespace Location
{
    public class LocationApi
    {
        const string BaseUrl = "http://localhost:52998/";

        readonly string _userId;
        readonly string _secretKey;

        public LocationApi(string userId, string secretKey)
        {
            _userId = userId;
            _secretKey = secretKey;
        }

        public void ExecuteAsyncPost<T>(RestRequest request, Action<T> callback) where T : new()
        {
            var client = new RestClient
                             {
                                 BaseUrl = BaseUrl,
                                 Authenticator = new HttpBasicAuthenticator(_userId, _secretKey)
                             };

            request.AddHeader("Content-type", "application/json");

            request.AddParameter("UserId", _userId, ParameterType.HttpHeader); // used on every request
            client.ExecuteAsyncPost<T>(request, (response, handle) =>
                                                    {
                                                        T t = response.Data;
                                                        callback(t);
                                                    }, "POST");
        }
    }
}