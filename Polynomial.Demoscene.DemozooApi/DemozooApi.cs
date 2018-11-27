using RestSharp;

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
    }
}
