namespace Bangazon_BE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public List<Product> Products { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
