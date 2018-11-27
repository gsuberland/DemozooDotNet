﻿using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    class ExternalLink
    {
        [DeserializeAs(Name = "link_class")]
        public string LinkClass { get; private set; }
        public string URL { get; private set; }
    }
}
