using System.Collections.Generic;
using System.Threading.Tasks;
using USSD.Data.Models;

namespace USSD.Data.Services
{
    public interface IOperatorService
    {
        Task<Operator> GetOperatorName(int id);
        Task<List<CheckModel>> GetCheckUpdates();
        Task<List<Operator>> GetOperatorsJson();
        Task<List<Operator>> GetOperators();
        Task<Operator> GetOperator(int id);
        Task<Operator> AddOperator(Operator operatr);
        Task<Operator> UpdateOperator(Operator operatr);
        void DeleteOperator(int id);
    }
}
