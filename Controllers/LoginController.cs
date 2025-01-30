using Microsoft.AspNetCore.Mvc;

namespace cat_frontend.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
