
using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Models;
using OnlineClearanceWeb.IServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.Services
{
    public class StudentUpload
    {
        private readonly List<StudentVm> Captures;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService userService;
        private string user;

        public StudentUpload(List<StudentVm> Captures, IUnitOfWork unitOfWork,string _user, IUserService userService)
        {
            this.Captures = Captures;
            this.unitOfWork = unitOfWork;
            user = _user;
            this.userService = userService;

        }

        public async Task<List<StudentVm>> UploadInThread()
        {

            var res = new List<StudentVm>();
         
           
            foreach (var s in Captures)
            {

                    unitOfWork.Students.Create(new Student
                    {
                        StudentId = s.StudentId,
                        FirstName = s.FirstName,
                        OtherNames = s.OtherNames,
                        DOB = Convert.ToDateTime(s.DOB),
                        Address = s.Address,
                        College = s.College,
                        Campus=s.Campus,
                        department = s.department,
                        CourseProgram = s.CourseProgram,
                        lga = s.lga,
                        state = s.state,
                        email = s.email,
                        tel = s.tel,
                        datecreated = DateTime.Now,
                        createdby = user

                    });

             
                var newUser = new User
                {
                    FirstName = s.FirstName,
                    LastName = s.OtherNames,
                    UpdatedOn = DateTime.Now,
                    Email = s.email,
                    CreatedOn = DateTime.Now,
                    UserName = s.email,
                    IsActive = true,
                };
                int[] Roles = { 2 };
                var createdUser = await userService.CreateUser(newUser,Roles, s.StudentId, 1);
                if (createdUser.Success)
                {
                    res.Add(s);
                    continue;
                }
                    
                }

            await unitOfWork.Done();

            return res;
        }

       

        public string getDay(int day)
        {
            string result = "";
            if (day == 1)
                result = "01";
            else if (day == 2)
                result = "02";
            else if (day == 3)
                result = "03";
            else if (day == 4)
                result = "04";
            else if (day == 5)
                result = "05";
            else if (day == 6)
                result = "06";
            else if (day == 7)
                result = "07";
            else if (day == 8)
                result = "08";
            else if (day == 9)
                result = "09";
            else
                result = day.ToString();
           

            return result;


        }

        public string getMonth(int day)
        {
            string result = "";
            if (day == 1)
                result = "01";
            if (day == 2)
                result = "02";
            if (day == 3)
                result = "03";
            if (day == 4)
                result = "04";
            if (day == 5)
                result = "05";
            if (day == 6)
                result = "06";
            if (day == 7)
                result = "07";
            if (day == 8)
                result = "08";
            if (day == 9)
                result = "09";
            if (day == 10)
                result = "10";
            if (day == 11)
                result = "11";
            if (day == 12)
                result = "12";

            return result;


        }


    }
}
