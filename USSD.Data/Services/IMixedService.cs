using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USSD.Data.Models;

namespace USSD.Data.Services
{
    public interface IMixedService
    {
        Task<List<Category>> GetCategories(int operatorid, int categoryid);
    }
}
