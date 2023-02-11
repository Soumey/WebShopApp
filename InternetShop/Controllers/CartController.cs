using InternetShop.Data;
using InternetShop.Interfaces;
using InternetShop.Models;
using InternetShop.Repository;
using InternetShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPhotoService _photoService;
        public CartController(ApplicationDbContext context,ICartRepository cartRepository, IProductRepository productRepository, IPhotoService photoService)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Cart> carts=await _cartRepository.GetAll();
            return View(carts);
        }
        //public async Task<IActionResult> Detail(int id)
        //{
        //    Cart cart = await _cartRepository.GetByIdAsync(id);
        //    return View(cart);
        //}
    }
}
