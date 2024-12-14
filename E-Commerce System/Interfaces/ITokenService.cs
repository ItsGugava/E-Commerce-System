using E_Commerce_System.Models;

namespace E_Commerce_System.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser appUser);
    }
}
