namespace Bangazon_BE.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public int PaymentTypeId { get; set; }    }
}
