namespace ShopMeneger.Domain.Entityes
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }



        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCount { get; set; }



        public virtual Category Category { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
