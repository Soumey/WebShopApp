using InternetShop.Data;
using InternetShop.Interfaces;
using InternetShop.Models;
using InternetShop.Repository;
using InternetShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IPhotoService _photoService;

        public HomeController( IProductRepository productRepository, IPhotoService photoService ,ICartRepository cartRepository)
        {
            
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _photoService = photoService;
        }




        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index() //C
        {
            IEnumerable<Product> products =await _productRepository.GetAll(); // M
            return View(products); //V
        }
        public async Task<IActionResult> Detail(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            return View(product);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel productVM )
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(productVM.ProductImage);
                var product = new Product
                {
                    ProductName = productVM.ProductName, 
                    ProductDescription = productVM.ProductDescription,
                    ProductCount= productVM.ProductCount,
                    ProductPrice=productVM.ProductPrice,
                    ProductImage=result.Url.ToString()
                    
                };
                _productRepository.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(productVM);
            
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            var product=await _productRepository.GetByIdAsync(id);
            if(product==null) return View("Error");

            var productVM = new EditProductViewModel
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                URL = product.ProductImage,
                ProductCount = product.ProductCount,
                ProductPrice = product.ProductPrice
            };
           
            return View(productVM);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditProductViewModel productVM)
        {
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Failed to edit club");
                    return View("Edit", productVM);
                }
                var uProduct = await _productRepository.GetByIdAsyncNoTracking(id);

                if (uProduct == null)
                {
                    return View("Error");
                }

                var photoResult = await _photoService.AddPhotoAsync(productVM.ProductImage);
                if (photoResult.Error != null)
                {
                    ModelState.AddModelError("Image", "Photo upload failed");
                    return View(productVM);
                }

                if (!string.IsNullOrEmpty(uProduct.ProductImage))
                {
                    _ = _photoService.DeletePhotoAsync(uProduct.ProductImage);
                }
                var product = new Product
                {
                    Id = id,
                    ProductName = productVM.ProductName,
                    ProductDescription = productVM.ProductDescription,
                    ProductImage=photoResult.Url.ToString(),
                    ProductCount = productVM.ProductCount,
                    ProductPrice = productVM.ProductPrice
                };

                _productRepository.Update(product);

                return RedirectToAction("Index");
            }

           

        }

        public async Task<IActionResult> AddToCart(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            Cart cart = new()
            {
                Count = 1,
                ProductId = product.Id,
                ProductImage = product.ProductImage,
                ProductPrice = product.ProductPrice,
                ProductName = product.ProductName,
                ProductCount = product.ProductCount

            };
            _cartRepository.Add(cart);
            _cartRepository.Save();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFromCart(int id)
        {
            Cart cart = await _cartRepository.GetByIdAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            
           
            _cartRepository.Delete(cart);
            _cartRepository.Save();
            return RedirectToAction("Index");

           
            //Cart cart = new()
            //{
            //    Count = 1,
            //    ProductId = product.Id,
            //    ProductImage = product.ProductImage,
            //    ProductPrice = product.ProductPrice,
            //    ProductName = product.ProductName,
            //    ProductCount = product.ProductCount

            //};
            //_cartRepository.Add(cart);
            //_cartRepository.Save();
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _productRepository.GetByIdAsync(id);
            if (productDetails == null) return View("Error");
            return View(productDetails);

        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productDetails = await _productRepository.GetByIdAsync(id);
            if (productDetails == null) return View("Error");
            _productRepository.Delete(productDetails);
            return RedirectToAction("Index");
        }

        
        
    }
}