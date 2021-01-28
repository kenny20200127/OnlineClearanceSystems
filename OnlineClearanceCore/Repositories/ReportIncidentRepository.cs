using EdoTrafficMgtCore.Core.Data;
using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EdoTrafficMgtCore.Core.Repositories
{
    public class ReportIncidentRepository:Repository<ReportedIncidents>,IReportIncident
    {
        private readonly ITrafficMgtDbContext context;
        public ReportIncidentRepository(ITrafficMgtDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ReportedIncidents> GetReportedIncidentByCode(Expression<Func<ReportedIncidents, bool>> predicate)
        {
            return await context.ReportedIncidents.FirstOrDefaultAsync(predicate);
        }

        public ReportedIncidents GetReportedIncidents()
        {
            return context.ReportedIncidents.FirstOrDefault();

        }
        public  List<ReportedIncidents> GetReportedIncidentByCase()
        {
            var list= context.ReportedIncidents.Where(x => x.decision == false);
            return list.ToList();
        }

    }
}
