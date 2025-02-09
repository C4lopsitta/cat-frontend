using cat_frontend.Models;
using CatAPILib;
using CatAPILib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace cat_frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexKawaii()
        {
            /*User user = new User(
                "ruben.puledda+joanne@itiscuneo.eu",
                "ciao",
                "Ciaociao123!smadonnoLA@",
                "https://example.com/confirm",
                "ciao descr",
                "ci/ao");
            var newUser = CatAPILib.UserEndpoints.RegisterUser(user).Result;
            Console.WriteLine("mammt");*/

            var cosetto = CatAPILib.UserEndpoints.ValidateNewUserAccount("1de30391bc8b4abab6e17c44ce562761", "df9025078954e12538a7bd857d553e542be8835b9ca435532353ae73").Result!;
            Console.WriteLine("\"{\\\"username\\\":\\\"ciao\\\",\\\"email\\\":\\\"ruben.puledda+joanne@itiscuneo.eu\\\",\\\"uid\\\":\\\"1de30391-bc8b-4aba-b6e1-7c44ce562761\\\"}\"");

            ViewData["cats"] = CatEndpoints.ReadAllCats()!.Result;
            var response = CatAPILib.UserEndpoints.AuthenticateUser("ciao", "ciao", null);
            string token = response.Result!["token"];
            HttpContext.Session.SetString("token", token);
            ViewData["token"] = HttpContext.Session.GetString("token");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
