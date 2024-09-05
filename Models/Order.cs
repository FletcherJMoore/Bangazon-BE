using System.ComponentModel.DataAnnotations;
using Bangazon_BE.API;

namespace Bangazon_BE.Models
{
    public class Orders
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string? PaymentType { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Shipping {  get; set; }
        public bool Closed { get; set; }
        public List<Product>? Products { get; set; }
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
