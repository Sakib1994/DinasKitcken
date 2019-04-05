using DinasDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinasDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DinasDemo.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products => _context.Products.Include(c=>c.Category);
        public IEnumerable<Product> PreferredProducts => _context.Products.Where(c=>c.IsPreferredFood).Include(c => c.Category);

        public Product GetProductById(int id)
        {
            return _context.Products.Include(c => c.Category).FirstOrDefault(c => c.Id ==id);
        }
    }
}
