using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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
        public static async Task<Dictionary<string, dynamic>?> GetWishlist(string uid)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, URIBuilder.BuildDomain($"/users/{uid}/wishlist"));
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();

                
                var ret = JsonConvert.DeserializeObject<Dictionary<string,dynamic>?>(jsonString)!;
               
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static async Task<Dictionary<string, dynamic>?> AddItem(string uid, string catUid, string token)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, URIBuilder.BuildDomain($"/users/{uid}/wishlist"));

                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {token}");

                request.Content = JsonContent.Create(new
                {
                    catUid = catUid,
                });


                var response = await client.SendAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var respJson = JsonConvert.DeserializeObject<Dictionary<string, dynamic>?>(jsonString);

                return respJson;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<Dictionary<string, dynamic>?> DeleteItems(string uid, string[] catUids, string token)
        {

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Delete, URIBuilder.BuildDomain($"/users/{uid}/wishlist"));

                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {token}");

                request.Content = JsonContent.Create(new
                {
                    cats = catUids,
                });


                var response = await client.SendAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var respJson = JsonConvert.DeserializeObject<Dictionary<string, dynamic>?>(jsonString);

                return respJson;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
