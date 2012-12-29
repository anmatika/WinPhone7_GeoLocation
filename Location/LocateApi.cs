//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using RestSharp;

//namespace Location
//{
//    public class LocateApi
//    {
//        const string BaseUrl = "http://localhost:50590/Phone/PhoneRequest";

//        readonly string _accountSid;
//        readonly string _secretKey;

//        public LocateApi(string accountSid, string secretKey)
//        {
//            _accountSid = accountSid;
//            _secretKey = secretKey;
//        }

//        public T Execute<T>(RestRequest request) where T : new()
//        {
//            T t;
//            var client = new RestClient
//                             {
//                                 BaseUrl = BaseUrl,
//                                 Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey)
//                             };
//            request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment); // used on every request
//            var response = client.ExecuteAsyncPost(request, (restResponse, handle) =>
//                                                                {
//                                                                    t = restResponse.;
//                                                                }, "POST");
            
            
//        }

//        public Call GetCall(string callSid)
//        {
//            var request = new RestRequest {Resource = "Accounts/{AccountSid}/Calls/{CallSid}", RootElement = "Call"};

//            request.AddParameter("CallSid", callSid, ParameterType.UrlSegment);

//            return Execute<Call>(request);
//        }
//    }

//    public class Call
//    {
//        public string Sid { get; set; }
//        public DateTime DateCreated { get; set; }
//        public DateTime DateUpdated { get; set; }
//        public string CallSegmentSid { get; set; }
//        public string AccountSid { get; set; }
//        public string Called { get; set; }
//        public string Caller { get; set; }
//        public string PhoneNumberSid { get; set; }
//        public int Status { get; set; }
//        public DateTime StartTime { get; set; }
//        public DateTime EndTime { get; set; }
//        public int Duration { get; set; }
//        public decimal Price { get; set; }
//        public int Flags { get; set; }
//    }

    
//}
