using E_Commerce_System.Data;
using E_Commerce_System.Interfaces;
using E_Commerce_System.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_System.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cart> AddToCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<bool> ClearAllAsync(string appUserId)
        {
            List<Cart> carts = await _context.Carts.Where(c => c.AppUserId.Equals(appUserId)).ToListAsync();
            if(carts.Count == 0)
            {
                return false;
            }
            _context.RemoveRange(carts);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByIdAsync(Cart cart)
        {
            Cart? cartToDelete = await _context.Carts.FirstOrDefaultAsync(c => c.AppUserId.Equals(cart.AppUserId) && c.ProductId == cart.ProductId);
            if(cartToDelete == null)
            {
                return false;
            }
            _context.Remove(cartToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cart>> GetAllAsync(string appUserId)
        {
            List<Cart> carts = await _context.Carts.Include(c => c.Product).ThenInclude(p => p.Category).Where(c => c.AppUserId.Equals(appUserId)).ToListAsync();
            return carts;
        }
    }
}
