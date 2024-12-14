using System.ComponentModel.DataAnnotations;

namespace E_Commerce_System.Dtos.Product
{
    public class CreateProductRequestDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Range(0.01, 1000000)]
        public decimal UnitPrice { get; set; }
    }
}
