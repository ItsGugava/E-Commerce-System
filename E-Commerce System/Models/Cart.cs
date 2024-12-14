namespace E_Commerce_System.Models
{
    public class Cart
    {
        public string AppUserId { get; set; }
        public int ProductId { get; set; }

        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
    }
}
