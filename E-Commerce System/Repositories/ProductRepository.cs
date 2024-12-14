using E_Commerce_System.Data;
using E_Commerce_System.Dtos.Product;
using E_Commerce_System.Dtos.Quey;
using E_Commerce_System.Interfaces;
using E_Commerce_System.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_System.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            Product? product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p =>  p.Id == id);
            if (product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task<List<Product>> GetAllAsync(QueryObject query)
        {
            var products = _context.Products.Include(p => p.Category).AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.Name))
            {
                products = products.Where(p => p.Name.Contains(query.Name));
            }
            if(query.CategoryId != null)
            {
                products = products.Where(p => p.CategoryId==query.CategoryId);
            }
            int skipNum = (query.PageCount - 1) * query.PageSize;

            return await products.Skip(skipNum).Take(query.PageSize).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            Product? product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<Product?> UpdateAsync(int id, UpdateProductRequestDto productDto)
        {
            Product? product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if(product == null)
            {
                return null;
            }
            product.Name = productDto.Name;
            product.CategoryId = productDto.CategoryId;
            product.Quantity = productDto.Quantity;
            product.UnitPrice = productDto.UnitPrice;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
