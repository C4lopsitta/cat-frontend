using cat_frontend.Models;
using CatAPILib;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            //var signIn = UserEndpoints.RegisterUser(new CatAPILib.Models.User(
            //        "torxdani1+test03@gmail.com",
            //        "dani123123",
            //        "!!CiaLALAL1212",
            //        "localhost:8000/user/confirm/",
            //        "no.",
            //        "la/a"
            //    )).Result;

            //string confirmId = "825c73f4b1bd406ea32e8ef5e3489049035947839b77b56ff588652a";
            //var confirm = UserEndpoints.ValidateNewUserAccount(signIn!["uid"], confirmId);
            var responseVal = UserEndpoints.GetAllUsers().Result;

            if(responseVal == null)
            {
                ViewData["errore"] = "AAAAAAAAAAAAAAAAAAAAAAAAAA";
            }
            else
            {
                foreach(CatAPILib.Models.User user in responseVal)
                {
                    ViewData["uid"] += user.uid+ " ";
                    ViewData["username"] += user.username + " ";
                    ViewData["image"] += user.image + " ";
                    ViewData["imageMime"] += user.imageMime + " ";
                    ViewData["description"] += user.description + " ";
                    ViewData["pronouns"] += user.pronouns + " ";

                    foreach(string cat in user.cats!)
                    {
                        ViewData["cats"] += cat;
                    }

                }


            }

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
