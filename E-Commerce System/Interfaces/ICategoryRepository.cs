using E_Commerce_System.Models;

namespace E_Commerce_System.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category?> DeleteAsync(int id);
        Task<List<Category>> GetAllAsync();
    }
}
