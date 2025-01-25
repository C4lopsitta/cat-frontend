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
        public static async Task<List<Cat>>? ReadAllCats()
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
    }
}
