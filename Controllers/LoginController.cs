using cat_frontend.CatAPILib.Models;
using CatAPILib;
using Microsoft.AspNetCore.Mvc;

namespace cat_frontend.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        /*
        [HttpPost("SendData")]
        public IActionResult SendData([FromBody] LoginBody loginBody) 
        {
            var ret = UserEndpoints.AuthenticateUser(loginBody.Email, loginBody.Password).Result;
            string token = ret["token"];
            Console.WriteLine(token);
            return RedirectToRoute("home");
        }
        */
        public IActionResult SendData(string loginEmail, string loginPw) { 
            Console.WriteLine(loginEmail);
            Console.WriteLine(loginPw);
            var ret = UserEndpoints.AuthenticateUser(loginEmail, loginPw).Result;
            if (ret != null)
            {
                string token = ret["token"];
                Console.WriteLine(token);
                HttpContext.Session.SetString("token", token);
                ViewData["token"] = HttpContext.Session.GetString("token");
                return RedirectToRoute("home");
            }
            else return Login();
        }
    }
}
