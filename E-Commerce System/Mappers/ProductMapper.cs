using E_Commerce_System.Dtos.Product;
using E_Commerce_System.Models;

namespace E_Commerce_System.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto FromProductToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Quantity = product.Quantity,
                UnitPrice = product.UnitPrice,
                CategoryName = product.Category.CategoryName
            };
        }

        public static Product FromCreateDtoToProduct(this CreateProductRequestDto createDto)
        {
            return new Product
            {
                Name = createDto.Name,
                CategoryId = createDto.CategoryId,
                Quantity = createDto.Quantity,
                UnitPrice = createDto.UnitPrice
            };
        }
    }
}
