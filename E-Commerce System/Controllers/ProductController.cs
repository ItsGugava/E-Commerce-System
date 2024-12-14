using E_Commerce_System.Dtos.Product;
using E_Commerce_System.Dtos.Quey;
using E_Commerce_System.Interfaces;
using E_Commerce_System.Mappers;
using E_Commerce_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_System.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            List<Product> products = await _productRepo.GetAllAsync(query);
            List<ProductDto> productDtos = products.Select(p => p.FromProductToProductDto()).ToList();
            return Ok(productDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Product? product = await _productRepo.GetByIdAsync(id); 
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product.FromProductToProductDto());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDto productDto)
        {
            Product product = productDto.FromCreateDtoToProduct();
            await _productRepo.CreateAsync(product);
            return Ok("Product Created");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequestDto productDto)
        {
            Product? product = await _productRepo.UpdateAsync(id, productDto);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product.FromProductToProductDto());
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Product? product = await _productRepo.DeleteAsync(id);
            if( product == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
