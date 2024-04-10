namespace ShopMeneger.Domain.Entityes
{
    public class ShopCategory
    {
        public Guid ShopCategoryId { get; set; }
        public Guid ShopId { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual Category Category { get; set; }
    }
}
