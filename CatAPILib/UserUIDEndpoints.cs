using CatAPILib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAPILib
{
    public class UserUIDEndpoints
    {
        public static async Task<User?> GetUserById(string uid, string token)
        {
            var jsonString = "";

            try
            {
                
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, URIBuilder.BuildDomain($"/users/{uid}"));

                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {token}");

                var response = await client.SendAsync(request);
                jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var ret = JsonConvert.DeserializeObject<User>(jsonString);

                return ret;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message + jsonString);
                return null;

            }
        }

    }
}
