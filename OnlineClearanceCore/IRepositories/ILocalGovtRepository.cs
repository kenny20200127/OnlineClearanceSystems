using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClearanceCore.Core.IRepositories
{
    public interface ILocalGovtRepository : IRepository<LocalGovernment>
    {
        Task<LocalGovernment> GetLocalGovernmentByCode(Expression<Func<LocalGovernment, bool>> predicate);
        IEnumerable<LocalGovernment> GetLocalGovernmentByDesc(string desc);
       // List<LocalGovernmentView> GetLocalGovernmentForReport();
    }
}
