using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    public class ListResults<T> where T : class, new()
    {
        public long Count { get; private set; }

        [DeserializeAs(Name = "next")]
        public string NextApiUrl { get; private set; }

        [DeserializeAs(Name = "previous")]
        public string PreviousApiUrl { get; private set; }

        public ListResults<T> NextPage => string.IsNullOrEmpty(NextApiUrl) ? null : DemozooApi.GetListResults<T>(NextApiUrl);

        public ListResults<T> PreviousPage => string.IsNullOrEmpty(PreviousApiUrl) ? null : DemozooApi.GetListResults<T>(PreviousApiUrl);

        public List<T> Results { get; private set; }
    }
}
