using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Models;
using OnlineClearanceWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.Services
{
    public class LocalGovtService : ILocalGovtService
    {
        private readonly IUnitOfWork unitOfWork;
        public LocalGovtService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public Task<LocalGovernment> GetLocalGovernmentByCode(string balcode)
        {
            return unitOfWork.LocalGovernments.GetLocalGovernmentByCode(x => x.Name == balcode);

        }
        public async Task<bool> AddLocalGovernment(LocalGovernment balsheet)
        {
            unitOfWork.LocalGovernments.Create(balsheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<LocalGovernment> GetLocalGovernments()
        {
            return unitOfWork.LocalGovernments.All();
        }


        public Task<LocalGovernment> GetLocalGovernmentById(int id)
        {
            return unitOfWork.LocalGovernments.Find(id);
        }

        public async Task<bool> UpdateLocalGovernment(LocalGovernment balsheet)
        {
            unitOfWork.LocalGovernments.Update(balsheet);
            return await unitOfWork.Done();
        }

        public void RemoveLocalGovernment(LocalGovernment bl_sheet)
        {
            unitOfWork.LocalGovernments.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public LocalGovernment GetLocalGovernmentByDesc(string desc)
        {
            return unitOfWork.LocalGovernments.GetLocalGovernmentByDesc(desc);
        }

        //public List<LocalGovernmentView> GetLocalGovernmentForReport()
        //{
        //    return unitOfWork.LocalGovernments.GetLocalGovernmentForReport();
        //}
    }
}
