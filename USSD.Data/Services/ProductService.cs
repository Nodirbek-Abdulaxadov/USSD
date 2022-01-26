using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USSD.Data.DataLayer;
using USSD.Data.Models;

namespace USSD.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Product> AddProduct(Product operatr)
        {
            _dbContext.Products.AddAsync(operatr);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(operatr);
        }

        public async Task DeleteProduct(int id)
        {
            _dbContext.Products.Remove(await _dbContext.Products.FirstOrDefaultAsync(o => o.Id == id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(op => op.Id == id);
        }

        public Task<List<Product>> GetProducts()
        {
            return _dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProductsBySubCategory(int subId)
        {
            var result = await _dbContext.Products.Where(p => p.SubCategoryId == subId).ToListAsync();
            return result;
        }

        public Task<Product> UpdateProduct(Product operatr)
        {
            _dbContext.Products.Update(operatr);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(operatr);
        }
    }
}
