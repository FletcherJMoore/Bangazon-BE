using System.ComponentModel.DataAnnotations;

namespace Bangazon_BE.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Closed { get; set; }
        public ICollection<Product>? Products { get; set; }
        public decimal? TotalCost
        {
            get
            {
                if (Products != null)
                {
                    return Products.Sum(product => product.PricePerUnit);

                }
                return null;
            }

        }
    }
}
