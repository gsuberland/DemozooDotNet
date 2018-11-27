using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi
{
    interface IApiReference
    {
        [DeserializeAs(Name = "url")]
        string ApiUrl { get; }
    }
}
