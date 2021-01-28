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
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public Task<Department> GetDepartmentByCode(string balcode)
        {
            return unitOfWork.Ind.GetDepartmentByCode(x => x.Name == balcode);

        }
        public async Task<bool> AddDepartment(Department balsheet)
        {
            unitOfWork.Ind.Create(balsheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return unitOfWork.Ind.All();
        }


        public Task<Department> GetDepartmentById(int id)
        {
            return unitOfWork.Ind.Find(id);
        }

        public async Task<bool> UpdateDepartment(Department balsheet)
        {
            unitOfWork.Ind.Update(balsheet);
            return await unitOfWork.Done();
        }

        public void RemoveDepartment(Department bl_sheet)
        {
            unitOfWork.Ind.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public Department GetDepartmentByDesc(string desc)
        {
            return unitOfWork.Ind.GetDepartmentByDesc(desc);
        }

        public List<DepartmentView> GetDepartmentForReport()
        {
            return unitOfWork.Ind.GetDepartmentForReport();
        }
    }
}
