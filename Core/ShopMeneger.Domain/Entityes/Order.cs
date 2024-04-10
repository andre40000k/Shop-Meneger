namespace ShopMeneger.Domain.Entityes
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }



        public DateTime CreateAt { get; set; }



        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
