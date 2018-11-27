using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi
{
    class ReleaserReference : IDemozooApiReference
    {
        [DeserializeAs(Name = "url")]
        public string ApiUrl { get; private set; }

        public Releaser Releaser => DemozooApi.Dereference<Releaser>(this);

        public long ID { get; private set; }

        public string Name { get; private set; }

        public bool? IsGroup { get; private set; }
    }
}
