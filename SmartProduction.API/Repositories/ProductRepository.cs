using Microsoft.EntityFrameworkCore;
using SmartProduction.API.Data;
using SmartProduction.API.Entities;
using SmartProduction.API.Interfaces;

namespace SmartProduction.API.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);
        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
