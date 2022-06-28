using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FastMarket.Data;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Services
{
    public class ProductService : IProduct
    {
         IConfiguration _configration;
        private readonly FastMarketDBContext _context;

        public ProductService(FastMarketDBContext context , IConfiguration configration)
        {
            _context = context;
            _configration = configration;
        }
        // method to get all products

        public async Task<List<Product>> GetProducts()
        {

            return await _context.Products.ToListAsync();
        }
        // method to get specific products by id

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(z => z.Id == id);
        }
        // method to create new products

        public async Task<Product> Create(Product product,IFormFile file)
        {

            product.ImageUri = GetFile(file).Result;
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return product;
        }

        // method to update a products

        public async Task<Product> UpdateProduct(int id, Product product,IFormFile file)
        {
            if (file != null)
            {
            product.ImageUri=GetFile(file).Result;

            }
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
        // method to Delete a products

        public async Task Delete(int id)
        {
            Product product = await GetProduct(id);

            if (product != null)
            {
                _context.Entry(product).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }
        public async Task<Uri> GetFile(IFormFile file)
        {
            if (file == null)
            {
                Uri defaultImg = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png");
                return defaultImg;
            }
            BlobContainerClient container = new BlobContainerClient(_configration.GetConnectionString("AzureBlob"), "images");
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);

            using var stream = file.OpenReadStream();
            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            };
            if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }
          return blob.Uri;

        }

        public async  Task<bool> checkAmount(Product product)
        {
            Product productDB = await _context.Products.FirstOrDefaultAsync(item => item.Name == product.Name);
            if (productDB == null)
            {
                //modelstate.AddModelError("Item Is Sold", "Sorry about that this item has been sold.");
                return false;
            }else if (product.Amount <= 0 || product.Amount > productDB.Amount)
            {
                //modelstate.AddModelError("Out OF Range", "The number of Amount is out of range.");
                return false;
            }
            return true;
        }

      
    }
}
