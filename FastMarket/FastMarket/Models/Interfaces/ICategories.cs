using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Interfaces
{
    public interface ICategories
    {

        Task<List<Categories>> GetCategories();
        Task<Categories> GetCategory(int id);
    }
}
