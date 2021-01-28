using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClearanceCore.Core.IRepositories
{
    public interface IStatesRepository : IRepository<States>
    {
        Task<States> GetStatesByCode(Expression<Func<States, bool>> predicate);
        States GetStatesByDesc(string desc);
       // List<StatesView> GetStatesForReport();
    }
}
