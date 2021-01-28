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
    public class StatesRepository:Repository<States>,IStatesRepository
    {
        private readonly ITrafficMgtDbContext context;
        public StatesRepository(ITrafficMgtDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<States> GetStatesByCode(Expression<Func<States, bool>> predicate)
        {
            return await context.States.FirstOrDefaultAsync(predicate);
        }

        public States GetStatesByDesc(string desc)
        {
            return context.States.FirstOrDefault(x => x.Description.ToUpper() == desc.ToUpper()); 
        }

        //public List<StatesView> GetStatesForReport()
        //{
        //    string ReportIncidentname = context.ReportedIncidents.FirstOrDefault().FirstName;
        //    string address = context.ReportedIncidents.FirstOrDefault().Address;

        //    return (from p in context.Statess
        //            select new StatesView
        //            {
                     
        //                name = p.Name,
        //                description = p.Description
        //            }).ToList();
        //}
    }
}
