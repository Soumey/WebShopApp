using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}
