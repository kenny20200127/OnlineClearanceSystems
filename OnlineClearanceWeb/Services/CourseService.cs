using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public Task<Course> GetCourseByCode(string balcode)
        {
            return unitOfWork.Courses.GetCourseByCode(x => x.Name == balcode);

        }
        public async Task<bool> AddCourse(Course balsheet)
        {
            unitOfWork.Courses.Create(balsheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<Course> GetCourses()
        {
            return unitOfWork.Courses.All();
        }


        public Task<Course> GetCourseById(int id)
        {
            return unitOfWork.Courses.Find(id);
        }

        public async Task<bool> UpdateCourse(Course balsheet)
        {
            unitOfWork.Courses.Update(balsheet);
            return await unitOfWork.Done();
        }

        public void RemoveCourse(Course bl_sheet)
        {
            unitOfWork.Courses.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public IEnumerable<Course> GetCourseByDesc(string desc)
        {
            return unitOfWork.Courses.GetCourseByDesc(desc);
        }

      
    }
}
