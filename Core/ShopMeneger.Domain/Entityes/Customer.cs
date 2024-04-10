namespace ShopMeneger.Domain.Entityes
{
    public class Customer
    {
        public Guid CustonerId { get; set; }



        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }



        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
