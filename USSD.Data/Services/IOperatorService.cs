using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USSD.Data.Models;

namespace USSD.Data.Services
{
    public interface IOperatorService
    {
        Task<List<Operator>> GetOperatorsJson();
        Task<List<Operator>> GetOperators();
        Task<Operator> GetOperator(int id);
        Task<Operator> AddOperator(Operator operatr);
        Task<Operator> UpdateOperator(Operator operatr);
        Task DeleteOperator(int id);
    }
}
