using FastMarket.Auth.Models;
using FastMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FastMarket.Data
{
    public class FastMarketDBContext : IdentityDbContext<ApplicationUser>
    {
        public FastMarketDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<CategoriesProduct> CategoriesProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CartProduct>().HasKey
                (x => new
                {
                    x.ProductId,
                    x.CartId
                });
            modelBuilder.Entity<CategoriesProduct>().HasKey
             (x => new
             {
                 x.CategoriesId,
                 x.ProductId
             });

            modelBuilder.Entity<Product>().HasData(

                new Product { Id = 1, Name = "Liner & Colossal Kajal", Price = 15.5m, Description = "Maybelline New York Colossal Bold Liner & Colossal Kajal - EYE KIT COMBO (Pack Of 2), 0.35 gm + 3 ml", Amount = 150, ImageUri= new Uri("https://faststorestorage.blob.core.windows.net/images/R.jpg") },
                new Product { Id = 2, Name = "Blushes", Price = 20.00m, Description = "URBANMAC Premium Synthetic Kabuki Foundation Face Powder Blush Eyeshadow Brush Makeup Brush Kit with Blender Sponge and Brush Cleaner - Makeup Brushes Set", Amount = 120, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(5).jpg") },
                new Product { Id = 3, Name = "Foundation ", Price = 50.00m, Description = "Coloressence Full Coverage Waterproof Lightweight Matte Formula Opaque Lotion High Definition Foundation (HDF-2) with Set of 2 Blending Sponge", Amount = 250, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(3).jpg") },
                new Product { Id = 4, Name = "Concealer ", Price = 35.00m, Description = "Wiffy Concealer Base Palette 15 In 1 Cream Kit Concealer", Amount = 60, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(4).jpg") },
                new Product { Id = 5, Name = "Eyeshadow", Amount = 30, Description = "UCANBE 18 Colors Aromas Nude Eyeshadow Palette Long Lasting Multi Reflective Shimmer Matte Glitter Pressed Pearls Eye Shadow Makeup Pallet", Price = 100, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(1).jpg") },
                new Product { Id = 6, Name = "Brushes ", Amount = 40, Description = "BESTOPE PRO Premium Synthetic Contour Concealers Foundation Powder Eye Shadows Makeup Brushes with Champagne Gold Conical Handle, 20 Count", Price = 350, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(6).jpg") },
                new Product { Id = 7, Name = "Makeup Remover", Amount = 50, Description = "Makeup Remover Cleansing Face Wipes, Daily Cleansing Facial Towelettes to Remove Waterproof Makeup and Mascara, Alcohol-Free, Value Twin Pack, 25 Count", Price = 200, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(7).jpg") },
                new Product { Id = 8, Name = "Bejamas", Amount = 50, Description = "Simple Joys by Carter's Girls and Toddlers' 4-Piece Pajama Set (Cotton Top & Fleece Bottom)", Price = 432, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(8).jpg") },
                new Product { Id = 9, Name = "2 Piece Pajama Set", Amount = 50, Description = "Moon and Back by Hanna Andersson Kids' Organic Holiday Family Matching 2 Piece Pajama Set", Price = 321, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(9).jpg") },
                new Product { Id = 10, Name = "Muslim Dresses for Women", Amount = 50, Description = "Muslim Dresses for Women, One-Piece Long Sleeve Islamic Prayer Dress & Prayer Rug & Beads, Islamic Set", Price = 722, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(10).jpg") },
                new Product { Id = 11, Name = "T Shirts", Amount = 50, Description = "5 Pack Men’s Active Quick Dry Crew Neck T Shirts | Athletic Running Gym Workout Short Sleeve Tee Tops Bulk", Price = 418, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(11).jpg") },
                new Product { Id = 12, Name = "Apple iPhone 13 Pro Max ", Amount = 50, Description = "Apple iPhone 13 Pro Max (256 GB, Alpine Green) [Locked] + Carrier Subscription", Price = 333, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(12).jpg") },
                new Product { Id = 13, Name = "SAMSUNG Galaxy S22", Amount = 50, Description = "SAMSUNG Galaxy S22 Cell Phone, Factory Unlocked Android Smartphone, 256GB, 8K Camera & Video, Brightest Display Screen, Long Battery Life, Fast 4nm Processor, US Version, Green", Price = 543, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(13).jpg") },
                new Product { Id = 14, Name = "Nokia XR20 5G", Amount = 50, Description = "Nokia XR20 5G | Android 11 | Unlocked Smartphone | Dual SIM | US Version | 6/128GB | 6.67-Inch Screen | 48MP Dual Camera | Granite", Price = 432, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(14).jpg") },
                new Product { Id = 15, Name = "Business Laptop", Amount = 50, Description = "Newest HP Pavilion Business Laptop, 15.6 Full HD Display, 11th Gen Intel i7-1165G7(Up to 4.7GHz), 16GB RAM, 1TB PCIe SSD, Intel Iris Xe Graphics, Backlit KB, Fingerprint, Bluetooth, Windows 11 Pro", Price = 200, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(15).jpg") },
                new Product { Id = 16, Name = "Touch-Screen - Intel Pentium ", Amount = 50, Description = "New Microsoft Surface Go 2 - 10.5 Touch-Screen - Intel Pentium - 4GB Memory - 64GB - Wifi - Platinum (Latest Model)", Price = 345, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(16).jpg") },
                new Product { Id = 17, Name = "HP Chromebook 14-inch HD Touchscreen Laptop", Amount = 50, Description = "HP Chromebook 14-inch HD Touchscreen Laptop, Intel Celeron N4000, 4 GB RAM, 32 GB eMMC, Chrome (14a-na0080nr, Forest Teal)", Price = 734, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(17).jpg") },
                new Product { Id = 18, Name = "YITAHOME 6 Pieces Patio Furniture Set", Amount = 50, Description = "YITAHOME 6 Pieces Patio Furniture Set, Outdoor Conversation Set, Outside Sectional Sofa PE Rattan Wicker Set with Table and Cushion for Porch Lawn Garden and Poolside, Gray Gradient", Price = 456, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(18).jpg") },
                new Product { Id = 19, Name = "Chairs Conversation Set Metal Frame Furniture", Amount = 50, Description = "LOKATSE HOME Outdoor 2 Piece Patio Chairs Conversation Set Metal Frame Furniture with Cushion, Blue", Price = 254, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(19).jpg") },
                new Product { Id = 20, Name = "Bed", Amount = 50, Description = "DHP Dakota Upholstered Platform Bed with Underbed Storage Drawers and Diamond Button Tufted Headboard and Footboard, No Box Spring Needed, Queen, White Faux Leather", Price = 512, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/R(20).jpg") }
                
            );

            modelBuilder.Entity<Categories>().HasData(
              new Categories { Id = 1, Name = "Beauty", Details = "Beauty Category contain multiple product like Blushes,Foundation,Gloss...." },
              new Categories { Id = 2, Name = "Clothes", Details = "Clothes Category contain multiple product like jeens,T-shirt,dress...." },
              new Categories { Id = 3, Name = "Mobiles", Details = "Mobiles Category contain multiple product like IPhones,Samsung,Nokia...." },
              new Categories { Id = 4, Name = "Computers & accessories", Details = "Computers & accessories Category contain multiple product like PC,Labtop,Headphones...." },
            
              new Categories { Id = 5, Name = "Furniture", Details = "Furniture Category contain multiple product like Beds ,Beds Covers, Sofa" }

            );


            modelBuilder.Entity<CategoriesProduct>().HasData(

                new CategoriesProduct {CategoriesId =1 , ProductId = 1 },
                new CategoriesProduct { CategoriesId = 1, ProductId = 2 },
                new CategoriesProduct { CategoriesId = 1, ProductId = 3 },
                new CategoriesProduct { CategoriesId = 1, ProductId = 4 },
                new CategoriesProduct { CategoriesId = 1, ProductId = 5 },
                new CategoriesProduct { CategoriesId = 1, ProductId = 6 },
                new CategoriesProduct { CategoriesId = 1, ProductId = 7 },
                new CategoriesProduct { CategoriesId = 2, ProductId = 8 },
                new CategoriesProduct { CategoriesId = 2, ProductId = 9 },
                new CategoriesProduct { CategoriesId = 2, ProductId = 10 },
                new CategoriesProduct { CategoriesId = 2, ProductId = 11 },
                new CategoriesProduct { CategoriesId = 3, ProductId = 12 },
                new CategoriesProduct { CategoriesId = 3, ProductId = 13 },
                new CategoriesProduct { CategoriesId = 3, ProductId = 14 },
                new CategoriesProduct { CategoriesId = 4, ProductId = 15 },
                new CategoriesProduct { CategoriesId = 4, ProductId = 16 },
                new CategoriesProduct { CategoriesId = 4, ProductId = 17 },
                new CategoriesProduct { CategoriesId = 5, ProductId = 18 },
                new CategoriesProduct { CategoriesId = 5, ProductId = 19 },
                new CategoriesProduct { CategoriesId = 5, ProductId = 20 }
               



                );

            SeedRole(modelBuilder, "Administrator");
            SeedRole(modelBuilder, "Editor");
            SeedRole(modelBuilder, "Users");
            //modelBuilder.Entity<ApplicationUser>().HasData(
            //    new ApplicationUser {UserName = "fuad",Email="fx.m@gmail.com",PasswordHash  }
            //    );
        }
        private void SeedRole(ModelBuilder modelBuilder, string roleName)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);
        }
    }
}
