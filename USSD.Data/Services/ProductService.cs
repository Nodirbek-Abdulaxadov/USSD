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
            _dbContext.Products.Add(operatr);
            NewUpdate();
            _dbContext.SaveChanges();
            return Task.FromResult(operatr);
        }

        public async Task DeleteProduct(int id)
        {
            _dbContext.Products.Remove(_dbContext.Products.FirstOrDefault(o => o.Id == id));
            NewUpdate();
            _dbContext.SaveChanges();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(op => op.Id == id);
        }

        public Task<List<Product>> GetProducts()
        {
            return _dbContext.Products.Skip(10).Take(10).ToListAsync();
        }

        public async Task<List<Product>> GetProductsBySubCategory(int subId)
        {
            var result = await _dbContext.Products.Where(p => p.SubCategoryId == subId).ToListAsync();
            return result;
        }

        public Task<Product> UpdateProduct(Product operatr)
        {
            _dbContext.Products.Update(operatr);
            NewUpdate();
            _dbContext.SaveChanges();
            return Task.FromResult(operatr);
        }

        public void NewUpdate()
        {
            CheckModel checkModel = _dbContext.CheckUpdates.FirstOrDefault(p => p.Id == 777);
            checkModel.DatabaseVersion++;
            checkModel.LastUpdated = DateTime.Now.ToString();
            _dbContext.CheckUpdates.Update(checkModel);
            _dbContext.SaveChanges();
        }
    }
}
