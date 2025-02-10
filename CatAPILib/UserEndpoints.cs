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
    public class UserEndpoints
    {
        public static async Task<List<User>?> GetAllUsers()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, URIBuilder.BuildDomain("/users"));

                var response = await client.SendAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var ret = JsonConvert.DeserializeObject<List<User>>(jsonString);

                return ret!;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
                
            }
        }

        public static async Task<Dictionary<string, dynamic>?> RegisterUser(User user)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, URIBuilder.BuildDomain("/users/register"));
                request.Content = JsonContent.Create(new
                {
                    email = user.email,
                    username = user.username,
                    password = user.password,
                    emailConfirmationBaseUrl = user.emailConfirmationBaseUrl,
                    description = user.description,
                    pronouns = user.pronouns
                });

                var response = await client.SendAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();

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


        public static async Task<Dictionary<string, dynamic>?> ValidateNewUserAccount(string uid, string confirmationId)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, URIBuilder.BuildDomain($"/users/{uid}/validate"));
                request.Content = JsonContent.Create(new
                {
                    confirmationId = confirmationId
                });

                var response = await client.SendAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var ret = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);

                return ret!;
            }
            catch (HttpRequestException e)
            {
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
    

    public static async Task<Dictionary<string, dynamic>?> AuthenticateUser(string email, string password, int? tfa = null)
        {
            {
                try
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Post, URIBuilder.BuildDomain($"/users/authenticate"));
                    
                    request.Content = JsonContent.Create(new
                    {
                        email = email,
                        password = password,
                        tfa = (tfa!=null)? tfa : 0

                    });


                    var response = await client.SendAsync(request);
                    var jsonString = await response.Content.ReadAsStringAsync();

                    response.EnsureSuccessStatusCode();

                    var ret = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);

                    return ret!;
                }
                catch (HttpRequestException e)
                {
                    {
                        Console.WriteLine(e.Message);
                        return null;
                    }
                }
            }
        }
    } 
}