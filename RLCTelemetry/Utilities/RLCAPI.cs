using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace RLCTelemetry.Utilities
{
    public class RLCAPI
    {
        const string BaseURL = "http://192.168.178.23:3000";

        public RLCAPI()
        {
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = BaseURL;

            var response = client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var rlcException = new ApplicationException(message, response.ErrorException);
                throw rlcException;
            }
            return response.Data;
        }

        public RLCAPIData GetDrivers(string token)
        {
            var request = new RestRequest();
            request.Resource = "drivers.json?token={token}";
            request.RootElement = "RLCAPIData";

            request.AddParameter("token", token, ParameterType.UrlSegment);

            return Execute<RLCAPIData>(request);
        }
    }

}
