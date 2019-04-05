using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DinasDemo.Interfaces;
using DinasDemo.Models;
using DinasDemo.ViewModels;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DinasDemo.Controllers
{   [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var item = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = item;
            ShoppingCartViewModel sCVM = new ShoppingCartViewModel {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(sCVM);
        }
        public IActionResult AddToShoppingCart(int Id)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(c => c.Id==Id);
            if (selectedProduct!=null)
            {
                _shoppingCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(c => c.Id == productId);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
