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

        internal static ListResults<T> GetListResults<T>(string url) where T : class, new()
        {
            var request = new RestRequest(url);
            var response = _client.Execute<ListResults<T>>(request);
            return response.Data;
        }

        private static T GetObject<T>(string objectName, long id) where T : class, new()
        {
            var request = new RestRequest(objectName + @"/{id}/");
            request.AddUrlSegment("id", id);
            return GetGeneric<T>(request);
        }

        private static ListResults<T> GetList<T>(string objectName, long pageNumber) where T : class, new()
        {
            var request = new RestRequest(objectName + @"/");
            request.AddQueryParameter("page", pageNumber.ToString());
            return GetGeneric<ListResults<T>>(request);
        }

        private static T GetGeneric<T>(RestRequest request) where T : class, new()
        {
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

        public static ListResults<Production> GetProductions(long pageNumber)
        {
            return GetList<Production>("productions", pageNumber);
        }

        public static Party GetParty(long id)
        {
            return GetObject<Party>("parties", id);
        }

        public static Production GetProduction(long id)
        {
            return GetObject<Production>("productions", id);
        }
    }
}
