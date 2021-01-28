using EdoTrafficMgtCore.Core.Data;
using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Core.IRepositories;
using EdoTrafficMgtCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EdoTrafficMgtCore.Core.Repositories
{
    public class LocalGovtRepository:Repository<LocalGovernment>, ILocalGovtRepository
    {
        private readonly ITrafficMgtDbContext context;
        public LocalGovtRepository(ITrafficMgtDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<LocalGovernment> GetLocalGovernmentByCode(Expression<Func<LocalGovernment, bool>> predicate)
        {
            return await context.LocalGovernments.FirstOrDefaultAsync(predicate);
        }

        public LocalGovernment GetLocalGovernmentByDesc(string desc)
        {
            return context.LocalGovernments.FirstOrDefault(x => x.Description.ToUpper() == desc.ToUpper()); 
        }

        //public List<LocalGovernmentView> GetLocalGovernmentForReport()
        //{
        //    string ReportIncidentname = context.ReportedIncidents.FirstOrDefault().FirstName;
        //    string address = context.ReportedIncidents.FirstOrDefault().Address;

        //    return (from p in context.LocalGovernments
        //            select new LocalGovernmentView
        //            {
                     
        //                name = p.Name,
        //                description = p.Description
        //            }).ToList();
        //}
    }
}
