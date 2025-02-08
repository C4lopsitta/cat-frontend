using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using CatAPILib.Models;
using Newtonsoft.Json;

namespace CatAPILib
{
    class CatEndpoints
    {
        public static async Task<List<Cat>?> ReadAllCats()
        {
            var jsonString = "";

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, URIBuilder.BuildDomain("/cats"));

                var response = await client.SendAsync(request);
                jsonString = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                var cats = JsonConvert.DeserializeObject<List<Cat>>(jsonString);
                return cats;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return JsonConvert.DeserializeObject<List<Cat>>(jsonString)!;
            }
        }

        public static async Task<Cat?> ReadCat(string uid) {

            var jsonString = "";

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, URIBuilder.BuildDomain($"/cats/{uid}"));

                var response = await client.SendAsync(request);
                jsonString = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                var cat = JsonConvert.DeserializeObject<Cat>(jsonString);
                return cat;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return JsonConvert.DeserializeObject<Cat>(jsonString)!;
            }
        }

        public static async Task<Dictionary<string, dynamic>>? CreateCat(Cat cat){
            var jsonString = "";

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, URIBuilder.BuildDomain("/cats/create"));

                //TODO: Add request header (bearer token for authorization)

                request.Content = JsonContent.Create(new
                {
                    name = cat.name,
                    age = cat.age,
                    description = cat.description,
                    whenLastSeen = cat.whenLastSeen,
                    whereLastSeen = cat.whereLastSeen,
                    race = cat.race,
                    furColor = cat.furColor,
                    weight = cat.weight,
                    isStray = cat.isStray,
                    image = cat.image,
                    imageMime = cat.imageMime,
                });

                var response = await client.SendAsync(request);
                jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var ret = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);

                return ret!;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString)!;
            }
        }

        public static async Task<Dictionary<string, dynamic>?> UpdateCat(Cat cat)
        {
            var jsonString = "";

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, URIBuilder.BuildDomain($"/cats/{cat.uid}"));

                //TODO: Add request header (bearer token for authorization)

                request.Content = JsonContent.Create(new
                {
                    name = cat.name,
                    age = cat.age,
                    description = cat.description,
                    whenLastSeen = cat.whenLastSeen,
                    whereLastSeen = cat.whereLastSeen,
                    race = cat.race,
                    furColor = cat.furColor,
                    weight = cat.weight,
                    isStray = cat.isStray,
                    image = cat.image,
                    imageMime = cat.imageMime,
                });

                var response = await client.SendAsync(request);
                jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var ret = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);

                return ret!;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString)!;
            }
        }

        public static async Task<bool?> DeleteCat(string uid)
        {

            var jsonString = "";

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Delete, URIBuilder.BuildDomain($"/cats/{uid}"));

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

        public static async Task<Dictionary<string, dynamic>?> SellCat(string uid, int price)
        {
            var jsonString = "";

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, URIBuilder.BuildDomain($"/cats/{uid}/sell"));

                //TODO: Add request header (bearer token for authorization)

                request.Content = JsonContent.Create(new
                {
                    price = price
                });

                var response = await client.SendAsync(request);
                jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var ret = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);

                return ret!;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
