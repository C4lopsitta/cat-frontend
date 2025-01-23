using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAPILib
{
    internal class URIBuilder
    {
        public static string domain = "https://kittens.robaldo.dev/api/v1";

        public static string BuildDomain(string path)
        {
            return domain + path;
        }
    }
}
