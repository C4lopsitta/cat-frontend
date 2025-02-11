using CatAPILib;
using Microsoft.AspNetCore.Mvc;

namespace cat_frontend.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult UserDetail()
        {
            string? uid = HttpContext.Session.GetString("uid");
            string? token = HttpContext.Session.GetString("token");

            if(uid != null && token != null)
            {
                CatAPILib.Models.User? user = UserUIDEndpoints.GetUserById(uid, token).Result;
                ViewData["user"] = user;
            }
            else
            {
                return RedirectToRoute("login");
            }
            
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("uid");
            HttpContext.Session.Remove("token");

            return RedirectToRoute("login");
        }

        public IActionResult CatDetail(string uid)
        {
            ViewData["cat"] = CatEndpoints.ReadCat(uid).Result;
            
            return View();
        }
    }
}
