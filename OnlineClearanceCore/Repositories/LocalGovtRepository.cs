using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Core.IRepositories;
using OnlineClearanceCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClearanceCore.Core.Repositories
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

        public IEnumerable<LocalGovernment> GetLocalGovernmentByDesc(string desc)
        {
            return context.LocalGovernments.Where(x => x.statecode == desc).ToList(); 
        }

        //public List<LocalGovernmentView> GetLocalGovernmentForReport()
        //{
        //    string ReportIncidentname = context.Students.FirstOrDefault().FirstName;
        //    string address = context.Students.FirstOrDefault().Address;

        //    return (from p in context.LocalGovernments
        //            select new LocalGovernmentView
        //            {
                     
        //                name = p.Name,
        //                description = p.Description
        //            }).ToList();
        //}
    }
}
