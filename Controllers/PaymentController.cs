using Microsoft.AspNetCore.Mvc;

namespace cat_frontend.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Payment()
        {
            return View();
        }
    }
}
