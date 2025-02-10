using Microsoft.AspNetCore.Mvc;

namespace cat_frontend.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult UserDetail(string uid)
        {
            //ViewData["user"] = CatAPILib.UserEndpoints.GetUserById(uid).Result;
            return View();
        }
        public IActionResult CatDetail(string uid)
        {
            ViewData["cat"] = CatAPILib.CatEndpoints.ReadCat(uid).Result;
            return View();
        }
    }
}
