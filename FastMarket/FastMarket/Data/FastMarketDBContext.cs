//using FastMarket.Models;
//using Microsoft.EntityFrameworkCore;

//namespace FastMarket.Data
//{
//    public class FastMarketDBContext : DbContext
//    {
//        public FastMarketDBContext(DbContextOptions options) : base(options)
//        {
//        }
//        public DbSet<Cart> Carts { get; set; }
//        public DbSet<CartProduct> CartProducts { get; set; }
//        public DbSet<Categories> Categories { get; set; }
//        public DbSet<CategoriesProduct> CategoriesProducts { get; set; }
//        public DbSet<Product> Products { get; set; }
      
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {

//            base.OnModelCreating(modelBuilder);
//            modelBuilder.Entity<CartProduct>().HasKey
//                (x => new
//                {
//                    x.ProductId,
//                    x.CartId
//                });
//            modelBuilder.Entity<CategoriesProduct>().HasKey
//             (x => new
//             {
//                 x.CategoriesId,
//                 x.ProductId
//             });


//        }
//    }
//}
