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
    public class MixedService : IMixedService
    {
        private readonly AppDbContext _dbContext;

        public MixedService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Category>> GetCategories(int operatorid, int categoryid)
        {
            var res = _dbContext.Categories.Where(c => c.OperatorId == operatorid)
                .Where(c => c.Id == categoryid)
                .Include(c => c.SubCategories)
                .ThenInclude(sc => sc.Products).ToList();

            return Task.FromResult(res);
        }
    }
}
