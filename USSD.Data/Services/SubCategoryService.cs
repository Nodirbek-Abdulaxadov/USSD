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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly AppDbContext _dbContext;

        public SubCategoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<SubCategory> AddSubCategory(SubCategory subCategory)
        {
            _dbContext.SubCategories.AddAsync(subCategory);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(subCategory);
        }

        public async Task DeleteSubCategory(int id)
        {
            _dbContext.SubCategories.Remove(await _dbContext.SubCategories.FirstOrDefaultAsync(o => o.Id == id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SubCategory> GetSubCategory(int id)
        {
            return await _dbContext.SubCategories.FirstOrDefaultAsync(op => op.Id == id);
        }

        public Task<List<SubCategory>> GetSubCategories()
        {
            return _dbContext.SubCategories.ToListAsync();
        }

        public Task<SubCategory> UpdateSubCategory(SubCategory subCategory)
        {
            _dbContext.SubCategories.Update(subCategory);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(subCategory);
        }

        public Task<List<SubCategory>> GetSubCategoriesJson()
        {
            var json = _dbContext.SubCategories
                .Include(product => product.Products)
                .ToListAsync();

            return json;
        }
    }
}
