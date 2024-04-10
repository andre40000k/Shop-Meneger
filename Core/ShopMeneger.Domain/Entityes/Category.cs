namespace ShopMeneger.Domain.Entityes
{
    public class Category
    {
        public Guid CategoryId { get; set; }



        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }



        public virtual IEnumerable<ShopCategory> ShopCategories { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
