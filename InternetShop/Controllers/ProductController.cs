using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
