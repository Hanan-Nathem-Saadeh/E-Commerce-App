using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastMarket.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public List<CategoriesProduct> categoriesProducts { get; set; }

        public List<CartProduct> cartProducts { get; set; }
    }
}
