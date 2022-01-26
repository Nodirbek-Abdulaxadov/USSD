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
        public async Task<SubCategory> GetSubCategory(int id)
        {
            var json = await _dbContext.SubCategories
                .Include(p => p.Products)
                .FirstOrDefaultAsync(op => op.Id == id);
            return json;
        }

        public Task<List<SubCategory>> GetSubCategories()
        {
            return _dbContext.SubCategories.ToListAsync();
        }

        public Task<List<SubCategory>> GetSubCategoriesJson()
        {
            var json = _dbContext.SubCategories
                .Include(product => product.Products)
                .ToListAsync();

            return json;
        }

        public Task<List<SubCategory>> GetAllByCategoryId(int categoryId)
        {
            return _dbContext.SubCategories.Where(sc => sc.CategoryId == categoryId).ToListAsync();
        }
    }
}
