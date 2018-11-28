using System;
using System.Collections.Generic;
using System.Text;

namespace Polynomial.Demoscene.DemozooApi
{
    public class ApiDataNotFoundException : Exception
    {
        public ApiDataNotFoundException(string message, string url) : base(message)
        {
            this.Url = url;
        }

        public string Url { get; private set; }
    }
}
