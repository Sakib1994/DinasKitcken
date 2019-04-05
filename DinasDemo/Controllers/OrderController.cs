using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DinasDemo.Interfaces;
using DinasDemo.Models;
using DinasDemo.Data;
using Microsoft.EntityFrameworkCore;
using DinasDemo.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DinasDemo.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly ApplicationDbContext _context;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, ApplicationDbContext context)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Checkout()
        {
            return View();
        }
        // Post: /<controller>/
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("","Your Cart is Empty, Add some Product to cart first.");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View();
        }
        public IActionResult CheckoutComplete()
        {
            return View();
        }
        public IActionResult List()
        {
            var orders = _orderRepository.GetOrders();
            return View(orders);
        }
        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(c=>c.OrderLines)
                .Where(i=>i.OrderId == id).SingleOrDefault();
            var pro = new List<ProductOrder>();
            foreach (var item in order.OrderLines)
            {
                pro.Add(new ProductOrder {
                    ProductName = _context.Products.Where(c => c.Id == item.ProductId).SingleOrDefault().Name,
                    Amount = item.Amount,
                    Price = item.Price
                });
            }
            var orderVM = new OrderViewModel {
                OrderId=order.OrderId,
                Name = order.Name,
                AddressLine1=order.AddressLine1,
                Division=order.Division,
                PhoneNumber=order.PhoneNumber,
                Email=order.Email,
                OrderTotal=order.OrderTotal,
                OrderPlaced=order.OrderPlaced,
                Products = pro
            };
            
            return View(orderVM);
        }
    }
}
