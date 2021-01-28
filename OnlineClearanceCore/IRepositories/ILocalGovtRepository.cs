using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EdoTrafficMgtCore.Core.IRepositories
{
    public interface ILocalGovtRepository : IRepository<LocalGovernment>
    {
        Task<LocalGovernment> GetLocalGovernmentByCode(Expression<Func<LocalGovernment, bool>> predicate);
        LocalGovernment GetLocalGovernmentByDesc(string desc);
       // List<LocalGovernmentView> GetLocalGovernmentForReport();
    }
}
