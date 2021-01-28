using EdoTrafficMgtCore.Core.Data;
using EdoTrafficMgtCore.Core.Entities;
using EdoTrafficMgtCore.Models;
using EdoTrafficMgtWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoTrafficMgtWeb.Services
{
    public class StatesService : IStatesService
    {
        private readonly IUnitOfWork unitOfWork;
        public StatesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public Task<States> GetStatesByCode(string balcode)
        {
            return unitOfWork.States.GetStatesByCode(x => x.Name == balcode);

        }
        public async Task<bool> AddStates(States balsheet)
        {
            unitOfWork.States.Create(balsheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<States> GetStatess()
        {
            return unitOfWork.States.All();
        }


        public Task<States> GetStatesById(int id)
        {
            return unitOfWork.States.Find(id);
        }

        public async Task<bool> UpdateStates(States balsheet)
        {
            unitOfWork.States.Update(balsheet);
            return await unitOfWork.Done();
        }

        public void RemoveStates(States bl_sheet)
        {
            unitOfWork.States.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public States GetStatesByDesc(string desc)
        {
            return unitOfWork.States.GetStatesByDesc(desc);
        }

        //public List<StatesView> GetStatesForReport()
        //{
        //    return unitOfWork.States.GetStatesForReport();
        //}
    }
}
