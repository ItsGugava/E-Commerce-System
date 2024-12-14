using E_Commerce_System.Dtos.Account;
using E_Commerce_System.Models;

namespace E_Commerce_System.Mappers
{
    public static class AccountMapper
    {
        public static AppUser FromRegisterDtoToAppUser(this RegisterDto registerDto)
        {
            return new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName
            };
        }

        public static AppUserDto FromAppUserToAppUserDto(this AppUser appUser, string token)
        {
            return new AppUserDto
            {
                Token = token,
                UserName = appUser.UserName
            };
        }
    }
}
