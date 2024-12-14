using E_Commerce_System.Dtos.Category;
using E_Commerce_System.Models;

namespace E_Commerce_System.Mappers
{
    public static class CategoryMapper
    {
        public static Category FromCreateDtoToCategory(this CreateCategoryRequestDto createDto)
        {
            return new Category
            {
                CategoryName = createDto.CategoryName
            };
        }

        public static CategoryDto FromCategoryToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
        }
    }
}
