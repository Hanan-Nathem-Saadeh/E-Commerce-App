using FastMarket.Auth.Models;
using FastMarket.Models;
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

                new Product { Id = 1, Name = "Liner & Colossal Kajal", Price = 15.5m, Description = "Maybelline New York Colossal Bold Liner & Colossal Kajal - EYE KIT COMBO (Pack Of 2), 0.35 gm + 3 ml", Amount = 150, ImageUri= new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png")},
                new Product { Id = 2, Name = "Blushes", Price = 20.00m, Description = "URBANMAC Premium Synthetic Kabuki Foundation Face Powder Blush Eyeshadow Brush Makeup Brush Kit with Blender Sponge and Brush Cleaner - Makeup Brushes Set", Amount = 120, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") },
                new Product { Id = 3, Name = "Foundation ", Price = 50.00m, Description = "Coloressence Full Coverage Waterproof Lightweight Matte Formula Opaque Lotion High Definition Foundation (HDF-2) with Set of 2 Blending Sponge", Amount = 250, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") },
                new Product { Id = 4, Name = "Concealer ", Price = 35.00m, Description = "Wiffy Concealer Base Palette 15 In 1 Cream Kit Concealer", Amount = 60 },
                new Product { Id = 5, Name = "Product1", Amount = 30, Description = "Description1", Price = 100, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") },
                new Product { Id = 6, Name = "Product2", Amount = 40, Description = "Description2", Price = 350, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") },
                new Product { Id = 7, Name = "Product3", Amount = 50, Description = "Description3", Price = 200, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") },
                new Product { Id = 8, Name = "Product4", Amount = 60, Description = "Description4", Price = 230, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") },
                new Product { Id = 9, Name = "Product5", Amount = 70, Description = "Description5", Price = 105, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") },
                new Product { Id = 10, Name = "Product10", Amount = 70, Description = "Description10", Price = 105, ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") }


            );

            modelBuilder.Entity<Categories>().HasData(
              new Categories { Id = 1, Name = "Beauty", Details = "Beauty Category contain multiple product like Blushes,Foundation,Gloss...." },
              new Categories { Id = 2, Name = "Clothes", Details = "Clothes Category contain multiple product like jeens,T-shirt,dress...." },
              new Categories { Id = 3, Name = "Mobiles", Details = "Mobiles Category contain multiple product like IPhones,Samsung,Nokia...." },
              new Categories { Id = 4, Name = "Computers & accessories", Details = "Computers & accessories Category contain multiple product like PC,Labtop,Headphones...." },
              new Categories { Id = 5, Name = "TV & Home Entertainment", Details = "TV & Home Entertainmen Category contain multiple product like DishTV HD,Samsung TV, LG" },
              new Categories { Id = 6, Name = "Furniture", Details = "Furniture Category contain multiple product like Beds ,Beds Covers, Sofa" }

            );


            modelBuilder.Entity<CategoriesProduct>().HasData(

                new CategoriesProduct {CategoriesId =1 , ProductId = 1 },
                new CategoriesProduct { CategoriesId = 1, ProductId = 2 },
                new CategoriesProduct { CategoriesId = 1, ProductId = 3 },
                new CategoriesProduct { CategoriesId = 2, ProductId = 4 },
                new CategoriesProduct { CategoriesId = 2, ProductId = 5 },
                new CategoriesProduct { CategoriesId = 3, ProductId = 6 },
                new CategoriesProduct { CategoriesId = 3, ProductId = 7 },
                new CategoriesProduct { CategoriesId = 4, ProductId = 8 },
                new CategoriesProduct { CategoriesId = 4, ProductId = 9 },
                new CategoriesProduct { CategoriesId = 5, ProductId = 10 }



                );





        }
    }
}
