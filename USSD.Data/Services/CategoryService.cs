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
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;

        public CategoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Category> AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return Task.FromResult(category);
        }

        public async Task DeleteCategory(int id)
        {
            _dbContext.Categories.Remove(_dbContext.Categories.FirstOrDefault(c => c.Id == id));
            _dbContext.SaveChanges();

        }

        public Task<List<Category>> GetCategories()
        {
            return _dbContext.Categories.ToListAsync();
        }

        public Task<List<Category>> GetCategoriesJson()
        {
            var json = _dbContext.Categories
                .Include(subCategory => subCategory.SubCategories)
                .ThenInclude(p => p.Products)
                .ToListAsync();

            return json;
        }

        public async Task<Category> GetCategory(int id)
        {
           var json = await _dbContext.Categories
                .Include(sc => sc.SubCategories)
                .ThenInclude(p => p.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            return json;
        }

        public Task<Category> UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
            return Task.FromResult(category);
        }
    }
}
