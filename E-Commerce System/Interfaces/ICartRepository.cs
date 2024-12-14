using E_Commerce_System.Models;

namespace E_Commerce_System.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> AddToCartAsync(Cart cart);
        Task<bool> ClearAllAsync(string appUserId);
        Task<bool> DeleteByIdAsync(Cart cart);
        Task<List<Cart>> GetAllAsync(string appUserId);
    }
}
