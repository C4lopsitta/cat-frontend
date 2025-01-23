using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAPILib
{
    public class ManageUserWishlist
    {
        public static async GetWishlist(string uid)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, URIBuilder.BuildDomain($"/users/{uid}/wishlist"));
            }
            catch(Exception ex)
            {

            }
    }
}
