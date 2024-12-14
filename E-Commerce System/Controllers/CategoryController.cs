using E_Commerce_System.Dtos.Category;
using E_Commerce_System.Interfaces;
using E_Commerce_System.Mappers;
using E_Commerce_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_System.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto categoryDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = categoryDto.FromCreateDtoToCategory();
            await _categoryRepo.CreateAsync(category);
            return Ok(category.FromCategoryToCategoryDto());
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Category? result = await _categoryRepo.DeleteAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = await _categoryRepo.GetAllAsync();
            List<CategoryDto> result = categories.Select(c => c.FromCategoryToCategoryDto()).ToList();
            return Ok(result);
        }
    }
}
