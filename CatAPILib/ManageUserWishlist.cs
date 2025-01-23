using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using CatAPILib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CatAPILib
{
    public class ManageUserWishlist
    {
        public static async Task<Wishlist> GetWishlist(string uid)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, URIBuilder.BuildDomain($"/users/{uid}/wishlist"));
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();

                
                Wishlist ret = JsonConvert.DeserializeObject<Wishlist>(jsonString)!;
               

                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Wishlist([], 0, "", 0);
            }
        }

        /*public static async Task<> UpdateWishlist() { 
        }*/
    }
}
