using CatAPILib;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Web.Http;

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
            var response = UserEndpoints.AuthenticateUser(loginEmail, loginPw).Result;
            if (response != null)
            {
                string token = response["token"];
                string uid = response["uid"];
                HttpContext.Session.SetString("token", token);
                HttpContext.Session.SetString("uid", uid);

                return RedirectToRoute("home");
            }
            else return RedirectToRoute("fail");
        }

        public IActionResult Register(string registerUsername, string registerPronouns, string registerEmail, string registerPw)
        {
            var response = UserEndpoints.RegisterUser(new CatAPILib.Models.User(
                    registerEmail,
                    registerUsername,
                    registerPw,
                    "localhost:5181/Login/verify",
                    "",
                    registerPronouns
                 )).Result;
            
            if(response == null)
            {
                return RedirectToRoute("fail");
            }

            return RedirectToRoute("login");
        }

        public IActionResult Fail()
        {
            return View();
        }

        public IActionResult Verify([FromUri] CatAPILib.Models.ValidationInfo info)
        {
            var response = CatAPILib.UserEndpoints.ValidateNewUserAccount(info.userUid, info.confirmationId).Result;

            if (response != null)
            {
                string token = response["token"];
                HttpContext.Session.SetString("token", token);
                HttpContext.Session.SetString("uid", info.userUid);

                return View();
            }else return RedirectToRoute("fail");
        }
    }
}
