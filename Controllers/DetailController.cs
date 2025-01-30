using Microsoft.AspNetCore.Mvc;

namespace cat_frontend.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult UserDetail()
        {
            return View();
        }
        public IActionResult CatDetail(string uid)
        {
            ViewData["cat"] = CatAPILib.CatEndpoints.ReadCat(uid).Result;
            return View();
        }
    }
}
