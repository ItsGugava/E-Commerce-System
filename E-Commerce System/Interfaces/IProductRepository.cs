using E_Commerce_System.Dtos.Product;
using E_Commerce_System.Dtos.Quey;
using E_Commerce_System.Models;

namespace E_Commerce_System.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(QueryObject query);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product?> UpdateAsync(int id, UpdateProductRequestDto productDto);
        Task<Product?> DeleteAsync(int id);
    }
}
