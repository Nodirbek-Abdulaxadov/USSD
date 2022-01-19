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
    public class OperatorService : IOperatorService
    {
        private readonly AppDbContext _dbContext;

        public OperatorService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Operator> AddOperator(Operator operatr)
        {
            _dbContext.Operators.AddAsync(operatr);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(operatr);
        }

        public async Task DeleteOperator(int id)
        {
            _dbContext.Operators.Remove(await _dbContext.Operators.FirstOrDefaultAsync(o => o.Id == id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Operator> GetOperator(int id)
        {
            return await _dbContext.Operators.FirstOrDefaultAsync(op => op.Id == id);
        }

        public Task<List<Operator>> GetOperators()
        {
            return _dbContext.Operators.ToListAsync();
        }

        public Task<List<Operator>> GetOperatorsJson()
        {
            var json = _dbContext.Operators
                .Include(category => category.Categories)
                .ThenInclude(sc => sc.SubCategories)
                .ThenInclude(p => p.Products)
                .ToListAsync();

            return json;
        }

        public Task<Operator> UpdateOperator(Operator operatr)
        {
            _dbContext.Operators.Update(operatr);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(operatr);
        }
    }
}
