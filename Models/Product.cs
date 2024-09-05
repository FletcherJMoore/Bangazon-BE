using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Bangazon_BE.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductImage { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal PricePerUnit { get; set; }
        public int QuantityAvailable { get; set; }
        public List<Orders> Orders { get; set;}
        public DateTime ReleaseDate { get; set; }

    }
}
