using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EdoTrafficMgtCore.Core.IRepositories
{
    public interface IIncidentTypeRepository : IRepository<IncidentType>
    {
        Task<IncidentType> GetIncidentTypeByCode(Expression<Func<IncidentType, bool>> predicate);
        IncidentType GetIncidentTypeByDesc(string desc);
        List<IncidentTypeView> GetIncidentTypeForReport();
    }
}
