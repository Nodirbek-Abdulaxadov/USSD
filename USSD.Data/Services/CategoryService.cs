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
            _dbContext.Categories.AddAsync(category);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(category);
        }

        public async Task DeleteCategory(int id)
        {
            _dbContext.Categories.Remove(_dbContext.Categories.FirstOrDefault(c => c.Id == id));
            await _dbContext.SaveChangesAsync();
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

        public Task<Category> GetCategory(int id)
        {
            return _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<Category> UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(category);
        }
    }
}
