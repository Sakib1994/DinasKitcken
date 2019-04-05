using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DinasDemo.Data;
using DinasDemo.Models;
using DinasDemo.Interfaces;
using DinasDemo.ViewModels;

namespace DinasDemo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductsController(ICategoryRepository categoryRepository,
            IProductRepository productRepository, ApplicationDbContext context)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ingredient,Description,Price,ImageUrl,ImageThumbnailUrl,IsPreferredFood,InStock,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ingredient,Description,Price,ImageUrl,ImageThumbnailUrl,IsPreferredFood,InStock,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        [Route("Products/List/{category?}")]
        public IActionResult List(string category)
        {
            string _category = category;
            var product = _productRepository.Products;
            if (_category == null)
            {
                var ProductVM = new ProductViewModel { Products = product, CurrentCategory = "All Category" };
                return View(ProductVM);
            }
            else
            {
                var categories = _categoryRepository.Categories;
                foreach (var item in categories)
                {
                    if (item.CategoryName == _category)
                    {
                        var ProductVM = new ProductViewModel
                        {
                            Products = product.Where(c => c.CategoryId == item.Id),
                            CurrentCategory = _category
                        };
                        return View(ProductVM);
                    }
                }
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Search(string search = null)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var products = await _context.Products
                    .Where(c => c.Name.Contains(search) || c.Ingredient.Contains(search))
                    .ToListAsync();
                var categories = _categoryRepository.Categories;
                var ProductVM = new ProductViewModel { Products = products, CurrentCategory = "All Category" };
                return View(ProductVM);
            }
            return BadRequest();
        }

        public async Task<IActionResult> Detail(int id)
        {
            Product product = await _context.Products.Where(c => c.Id == id).SingleOrDefaultAsync();
            return View(product);
        }
    }
}
