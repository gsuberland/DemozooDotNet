using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi
{
    interface IDemozooApiReference
    {
        [DeserializeAs(Name = "url")]
        string ApiUrl { get; }
    }
}
