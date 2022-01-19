using System.Collections.Generic;
using System.Threading.Tasks;
using USSD.Data.Models;

namespace USSD.Data.Services
{
    public interface ISubCategoryService
    {
        Task<List<SubCategory>> GetSubCategories();
        Task<List<SubCategory>> GetSubCategoriesJson();
        Task<SubCategory> GetSubCategory(int id);
        Task<SubCategory> AddSubCategory(SubCategory subCategory);
        Task<SubCategory> UpdateSubCategory(SubCategory subCategory);
        Task DeleteSubCategory(int id);
    }
}
