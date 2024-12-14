using Microsoft.AspNetCore.Identity;

namespace E_Commerce_System.Models
{
    public class AppUser : IdentityUser
    {
        public List<Cart> Carts { get; set; } = new List<Cart>();
    }
}
