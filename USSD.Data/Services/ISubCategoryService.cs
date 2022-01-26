using System.Collections.Generic;
using System.Threading.Tasks;
using USSD.Data.Models;

namespace USSD.Data.Services
{
    public interface ISubCategoryService
    {
        Task<List<SubCategory>> GetAllByCategoryId(int categoryId);
        Task<List<SubCategory>> GetSubCategories();
        Task<List<SubCategory>> GetSubCategoriesJson();
        Task<SubCategory> GetSubCategory(int id);
    }
}
