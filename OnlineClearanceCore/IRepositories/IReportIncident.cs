using EdoTrafficMgtCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EdoTrafficMgtCore.Core.IRepositories
{
    public interface IReportIncident:IRepository<ReportedIncidents>
    {
        Task<ReportedIncidents> GetReportedIncidentByCode(Expression<Func<ReportedIncidents, bool>> predicate);
        ReportedIncidents GetReportedIncidents();
        List<ReportedIncidents> GetReportedIncidentByCase();
    }
}
