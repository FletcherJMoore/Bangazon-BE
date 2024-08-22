using System.ComponentModel.DataAnnotations;

namespace Bangazon_BE.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string ProductImage { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Description { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
