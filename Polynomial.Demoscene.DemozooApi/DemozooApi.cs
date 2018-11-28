using RestSharp;
using Polynomial.Demoscene.DemozooApi.Model;

namespace Polynomial.Demoscene.DemozooApi
{
    public static class DemozooApi
    {
        private static RestClient _client = new RestClient(@"https://demozoo.org/api/v1/");

        internal static T Dereference<T>(IDemozooApiReference reference) where T : class, new()
        {
            var request = new RestRequest(reference.ApiUrl);
            var response = _client.Execute<T>(request);
            return response.Data;
        }

        private static T GetGeneric<T>(string objectName, long id) where T : class, new()
        {
            var request = new RestRequest(objectName + @"/{id}/");
            request.AddUrlSegment("id", id);
            var response = _client.Execute<T>(request);
            if (!response.IsSuccessful)
            {
                string message;
                switch (response.ResponseStatus)
                {
                    case ResponseStatus.Error:
                        message = "A transport error occurred.";
                        break;
                    case ResponseStatus.Completed:
                        message = $"The server returned an error status: {response.StatusDescription} ({response.StatusCode})";
                        break;
                    case ResponseStatus.Aborted:
                        message = "The operation was aborted.";
                        break;
                    default:
                        message = "An unknown error occurred.";
                        break;
                }
                throw new ApiDataNotFoundException(message, response.Request.Resource);
            }
            return response.Data;
        }

        public static Party GetParty(long id)
        {
            return GetGeneric<Party>("parties", id);
        }

        public static Production GetProduction(long id)
        {
            return GetGeneric<Production>("productions", id);
        }
    }
}
