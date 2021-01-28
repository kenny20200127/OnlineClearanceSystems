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
    public class IncidentTypeRepository:Repository<IncidentType>,IIncidentTypeRepository
    {
        private readonly ITrafficMgtDbContext context;
        public IncidentTypeRepository(ITrafficMgtDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<IncidentType> GetIncidentTypeByCode(Expression<Func<IncidentType, bool>> predicate)
        {
            return await context.IncidentTypes.FirstOrDefaultAsync(predicate);
        }

        public IncidentType GetIncidentTypeByDesc(string desc)
        {
            return context.IncidentTypes.FirstOrDefault(x => x.Description.ToUpper() == desc.ToUpper()); 
        }

        public List<IncidentTypeView> GetIncidentTypeForReport()
        {
            string ReportIncidentname = context.ReportedIncidents.FirstOrDefault().FirstName;
            string address = context.ReportedIncidents.FirstOrDefault().Address;

            return (from p in context.IncidentTypes
                    select new IncidentTypeView
                    {
                     
                        name = p.Name,
                        description = p.Description
                    }).ToList();
        }
    }
}
