using System.ComponentModel.DataAnnotations;

namespace E_Commerce_System.Dtos.Category
{
    public class CreateCategoryRequestDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string CategoryName { get; set; }
    }
}
