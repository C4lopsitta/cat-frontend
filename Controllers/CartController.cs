using Microsoft.AspNetCore.Mvc;

namespace cat_frontend.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}
