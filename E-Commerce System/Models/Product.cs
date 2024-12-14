using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_System.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public List<Cart> Carts { get; set; } = new List<Cart>();
    }
}
