using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CatAPILib
{
    public class ManageUserCart
    {

        public static async Task<Dictionary<string,dynamic>?> GetCart(string uid, string token)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, URIBuilder.BuildDomain($"/users/{uid}/cart"));

                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {token}");

                var response = await client.SendAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();
                
                var respJson = JsonConvert.DeserializeObject<Dictionary<string,dynamic>?>(jsonString);

                return respJson;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<Dictionary<string,dynamic>?> AddItem(string uid, string catUid, string token)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, URIBuilder.BuildDomain($"/users/{uid}/cart"));

                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {token}");

                request.Content = JsonContent.Create(new
                {
                    catUid = catUid,
                });


                var response = await client.SendAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var respJson = JsonConvert.DeserializeObject<Dictionary<string,dynamic>?>(jsonString);

                return respJson;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<Dictionary<string,dynamic>?> DeleteItems(string uid, string[] catUids, string token)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Delete, URIBuilder.BuildDomain($"/users/{uid}/cart"));

                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {token}");

                request.Content = JsonContent.Create(new
                {
                    cats = catUids,
                });


                var response = await client.SendAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var respJson = JsonConvert.DeserializeObject<Dictionary<string,dynamic>?>(jsonString);

                return respJson;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<Dictionary<string,dynamic>?> Checkout(string uid, Models.Card card, string token)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, URIBuilder.BuildDomain($"/users/{uid}/cart/checkout"));

                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {token}");

                request.Content = JsonContent.Create(new
                {
                    card = new 
                    {
                        number = card.number,
                        cvv = card.cvv,
                        cardholder = card.cardholder,
                        expiration = card.expiration
                    }
                });


                var response = await client.SendAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var respJson = JsonConvert.DeserializeObject<Dictionary<string,dynamic>?>(jsonString);

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
