using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using SharedLibrary;

namespace LocationWebPage.Controllers
{
    public class LocationController : ApiController
    {
        public HttpResponseMessage ReceiveLocation()
        {
            var jsonMediaTypeFormatter = new JsonMediaTypeFormatter();
            var userId = GetUserIdFromRequestHeader();
            var locationDto = new LocationDto {Response = "OK:" + userId};

            var responseMessage = new HttpResponseMessage(HttpStatusCode.Accepted)
                                      {
                                          Content = new ObjectContent<LocationDto>(locationDto, jsonMediaTypeFormatter,
                                                                                   new MediaTypeHeaderValue(
                                                                                       "application/json"))
                                      };
            return responseMessage;
        }

        /// <summary>
        ///     Gets the user id from the request's header
        /// </summary>
        /// <returns>The user id</returns>
        private string GetUserIdFromRequestHeader()
        {
            IEnumerable<string> values;
            string userId = string.Empty;
            if (Request.Headers.TryGetValues("UserId", out values))
            {
                userId = values.FirstOrDefault();
            }
            return userId;
        }
    }
}