namespace FastMarket.Models
{
    public class CategoriesProduct
    {
        public int CategoriesId { get; set; }
        public int ProductId { get; set; }
        public Categories Categories { get; set; }
        public Product Product { get; set; }
    }
}
