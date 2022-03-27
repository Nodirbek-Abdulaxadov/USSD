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
            _dbContext.Operators.Add(operatr);
            NewUpdate();
            _dbContext.SaveChanges();
            return Task.FromResult(operatr);
        }

        public void DeleteOperator(int id)
        {
            var p = _dbContext.Operators.FirstOrDefault(o => o.Id == id);
            _dbContext.Operators.Remove(p);
            NewUpdate();
            _dbContext.SaveChanges();
        }

        public async Task<Operator> GetOperator(int id)
        {
            var json = await _dbContext.Operators
                .Include(c => c.Categories)
                .ThenInclude(sc => sc.SubCategories)
                .ThenInclude(p => p.Products)
                .FirstOrDefaultAsync(op => op.Id == id);

            return json;
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

        public Task<List<CheckModel>> GetCheckUpdates()
        {
            return Task.FromResult(_dbContext.CheckUpdates.ToList());
        }
    }
}
