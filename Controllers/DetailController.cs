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
            ViewData["uid"] = uid;
            return View();
        }
    }
}
