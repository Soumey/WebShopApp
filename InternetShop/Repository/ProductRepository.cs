using InternetShop.Data;
using InternetShop.Interfaces;
using InternetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool Delete(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();

        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Product> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _context.Products.Where(p => p.ProductName.Contains(name)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public bool Update(Product product)
        {
            _context.Update(product);
            return Save();
        }
    }
}
