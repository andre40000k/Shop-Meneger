namespace ShopMeneger.Domain.Entityes
{
    public class Shop
    {
        public Guid ShopId { get; set; }



        public string ShopName { get; set; }
        public string ShopDescription { get; set; }



        public virtual IEnumerable<ShopCategory> ShopCategorys { get; set; }
    }
}
