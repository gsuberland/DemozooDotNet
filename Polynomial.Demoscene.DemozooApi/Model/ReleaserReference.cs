using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi
{
    class ReleaserReference : IApiReference
    {
        [DeserializeAs(Name = "url")]
        public string ApiUrl { get; private set; }

        public Releaser Releaser { get { return DemozooApi.Dereference<Releaser>(this); } }

        public long ID { get; private set; }

        public string Name { get; private set; }

        public bool? IsGroup { get; private set; }
    }
}
