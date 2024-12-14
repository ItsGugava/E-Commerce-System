using E_Commerce_System.Dtos.Product;
using E_Commerce_System.Extensions;
using E_Commerce_System.Interfaces;
using E_Commerce_System.Mappers;
using E_Commerce_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_System.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepo;

        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("{productId}")]
        public async Task<IActionResult> AddToCart([FromRoute] int productId)
        {
            string appUserId = User.GetId();
            Cart cart = new Cart { AppUserId = appUserId, ProductId = productId };
            await _cartRepo.AddToCartAsync(cart);
            return Ok("Product added in cart");
        }

        [Authorize(Roles = "User")]
        [HttpDelete("Clear")]
        public async Task<IActionResult> DeleteAll()
        {
            string appUserId = User.GetId();
            bool areDeleted = await _cartRepo.ClearAllAsync(appUserId);
            if (!areDeleted)
            {
                return NotFound();
            }
            return Ok("Products are deleted");
        }

        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> DeleteById([FromRoute] int productId)
        {
            string appUserId = User.GetId();
            Cart cart = new Cart { AppUserId = appUserId, ProductId = productId };
            bool isDeleted = await _cartRepo.DeleteByIdAsync(cart);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok("Product is deleted");
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string appUserId = User.GetId();
            List<Cart> carts = await _cartRepo.GetAllAsync(appUserId);
            List<ProductDto> productDtos = carts.Select(c => c.Product.FromProductToProductDto()).ToList();
            return Ok(productDtos);
        }
    }
}
