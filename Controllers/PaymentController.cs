using Microsoft.AspNetCore.Mvc;

namespace cat_frontend.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Payment()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Checkout([FromBody] string paymentCardNumber)
        {
            Console.WriteLine(paymentCardNumber);   
            return Payment();
        }
    }
}
