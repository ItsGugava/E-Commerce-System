using E_Commerce_System.Dtos.Account;
using E_Commerce_System.Interfaces;
using E_Commerce_System.Mappers;
using E_Commerce_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_System.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (_userManager.Users.Any(u => u.UserName == registerDto.UserName))
                {
                    return BadRequest("Username is used");
                }
                if (_userManager.Users.Any(u => u.Email == registerDto.Email))
                {
                    return BadRequest("Email is used");
                }

                AppUser appUser = registerDto.FromRegisterDtoToAppUser();
                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        string token = await _tokenService.CreateTokenAsync(appUser);
                        AppUserDto appUserDto = appUser.FromAppUserToAppUserDto(token);
                        return Ok(appUserDto);
                    }
                    return StatusCode(500, roleResult.Errors.ToString());
                }
                return StatusCode(500, createdUser.Errors.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AppUser? appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);
            if (appUser == null)
            {
                return Unauthorized("Invalid Username");
            } 
            var result = await _signInManager.CheckPasswordSignInAsync(appUser, loginDto.Password, false);
            if(!result.Succeeded)
            {
                return Unauthorized("Invalid Password");
            }
            string token = await _tokenService.CreateTokenAsync(appUser);
            AppUserDto appUserDto = appUser.FromAppUserToAppUserDto(token);
            return Ok(appUserDto);
        }
    }
}
