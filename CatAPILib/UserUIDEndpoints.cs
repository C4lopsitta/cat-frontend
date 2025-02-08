using CatAPILib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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

        public static async Task<User?> UpdateUser(User user)
        {
            var jsonString = "";

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, URIBuilder.BuildDomain($"/users/{user.uid}"));

                //TODO: Add request header (bearer token for authorization)

                request.Content = JsonContent.Create(new
                {
                    description = user.description,
                    pronouns = user.pronouns,
                    image = user.image,
                    imageMime = user.imageMime
                });

                var response = await client.SendAsync(request);
                jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var ret = JsonConvert.DeserializeObject<User>(jsonString);

                return ret!;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<bool?> DeleteUser(string uid)
        {

            var jsonString = "";

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Delete, URIBuilder.BuildDomain($"/users/{uid}"));

                var response = await client.SendAsync(request);
                jsonString = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                var respJson = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);
                if (respJson["success"] == bool.TrueString)
                    return true;
                else return false;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
}
