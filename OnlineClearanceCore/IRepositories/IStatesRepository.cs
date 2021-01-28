using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EdoTrafficMgtCore.Core.IRepositories
{
    public interface IStatesRepository : IRepository<States>
    {
        Task<States> GetStatesByCode(Expression<Func<States, bool>> predicate);
        States GetStatesByDesc(string desc);
       // List<StatesView> GetStatesForReport();
    }
}
