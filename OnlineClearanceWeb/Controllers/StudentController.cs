using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OnlineClearanceCore.Core.Data;
using OnlineClearanceCore.Models;
using OnlineClearanceWeb.Services;

namespace OnlineClearanceWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork unitofwork;
        public StudentController(IUnitOfWork unitofwork)
        {
                
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ApprovedStudents()
        {
            return View();
        }
        public IActionResult DeclinedStudents()
        {
            return View();
        }
        public IActionResult ViewStudents()
        {
            return View();
        }
        [HttpGet]
        public IActionResult StudentsUpload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> StudentsUpload(IFormFile formFile, CancellationToken cancellationToken)
        {
            if(formFile==null && formFile.Length <= 0)
            {

                TempData["message"] = "No File to Upload";
                return View();
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                TempData["message"] = "File not an Excel Format";

                return View();
            }

            string user = User.Identity.Name;

            var listApplication = new List<StudentVm>();
         
            //string studentnumber = HttpContext.Session.GetString("StudentNumber");
            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {

                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                    var rowCount = worksheet.Dimension.Rows;

                    string StudentId = String.IsNullOrEmpty(worksheet.Cells[1, 2].ToString()) ? "" : worksheet.Cells[1, 2].Value.ToString().Trim();
                    string FirstName = String.IsNullOrEmpty(worksheet.Cells[1, 3].ToString()) ? "" : worksheet.Cells[1, 3].Value.ToString().Trim();
                    string OtherNames = String.IsNullOrEmpty(worksheet.Cells[1, 4].ToString()) ? "" : worksheet.Cells[1, 4].Value.ToString().Trim();
                    string DOB = String.IsNullOrEmpty(worksheet.Cells[1, 5].ToString()) ? "" : worksheet.Cells[1, 5].Value.ToString().Trim();
                    string Address = String.IsNullOrEmpty(worksheet.Cells[1, 6].ToString()) ? "" : worksheet.Cells[1, 6].Value.ToString().Trim();

                    string College = String.IsNullOrEmpty(worksheet.Cells[1, 7].ToString()) ? "" : worksheet.Cells[1, 7].Value.ToString().Trim();
                    string Campus = String.IsNullOrEmpty(worksheet.Cells[1, 8].ToString()) ? "" : worksheet.Cells[1, 8].Value.ToString().Trim();
                    string department = String.IsNullOrEmpty(worksheet.Cells[1, 9].ToString()) ? "" : worksheet.Cells[1, 9].Value.ToString().Trim();
                    string CourseProgram = String.IsNullOrEmpty(worksheet.Cells[1, 10].ToString()) ? "" : worksheet.Cells[1, 10].Value.ToString().Trim();
                    string lga = String.IsNullOrEmpty(worksheet.Cells[1, 11].ToString()) ? "" : worksheet.Cells[1, 11].Value.ToString().Trim();

                    string state = String.IsNullOrEmpty(worksheet.Cells[1, 12].ToString()) ? "" : worksheet.Cells[1, 12].Value.ToString().Trim();
                    string email = String.IsNullOrEmpty(worksheet.Cells[1, 13].ToString()) ? "" : worksheet.Cells[1, 13].Value.ToString().Trim();
                    string tel = String.IsNullOrEmpty(worksheet.Cells[1, 14].ToString()) ? "" : worksheet.Cells[1, 14].Value.ToString().Trim();
                   
                    if (StudentId != "StudentId" || FirstName != "FirstName" || OtherNames != "OtherNames" || department != "department")
                    {
                        return BadRequest("File not in the Right format");
                    }

                   

                    for (int j = 2; j <= rowCount; j++)
                    {
                        var jp = new StudentVm();
                        string studentID = String.IsNullOrEmpty(worksheet.Cells[j, 2].ToString()) ? "" : worksheet.Cells[j, 2].Value.ToString().Trim();
                        string firstName = String.IsNullOrEmpty(worksheet.Cells[j, 3].ToString()) ? "" : worksheet.Cells[j, 3].Value.ToString().Trim();
                        string otherNames = String.IsNullOrEmpty(worksheet.Cells[j, 4].ToString()) ? "" : worksheet.Cells[j, 4].Value.ToString().Trim();
                        string dob = String.IsNullOrEmpty(worksheet.Cells[j, 5].ToString()) ? "" : worksheet.Cells[j, 5].Value.ToString().Trim();
                        string address = String.IsNullOrEmpty(worksheet.Cells[j, 6].ToString()) ? "" : worksheet.Cells[j, 6].Value.ToString().Trim();

                        string college = String.IsNullOrEmpty(worksheet.Cells[j, 7].ToString()) ? "" : worksheet.Cells[j, 7].Value.ToString().Trim();
                        string campus = String.IsNullOrEmpty(worksheet.Cells[j, 8].ToString()) ? "" : worksheet.Cells[j, 8].Value.ToString().Trim();
                        string departments = String.IsNullOrEmpty(worksheet.Cells[j, 9].ToString()) ? "" : worksheet.Cells[j, 9].Value.ToString().Trim();
                        string courseProgram = String.IsNullOrEmpty(worksheet.Cells[j, 10].ToString()) ? "" : worksheet.Cells[j, 10].Value.ToString().Trim();
                        string lgas = String.IsNullOrEmpty(worksheet.Cells[j, 11].ToString()) ? "" : worksheet.Cells[j, 11].Value.ToString().Trim();

                        string states = String.IsNullOrEmpty(worksheet.Cells[j, 12].ToString()) ? "" : worksheet.Cells[j, 12].Value.ToString().Trim();
                        string emails = String.IsNullOrEmpty(worksheet.Cells[j, 13].ToString()) ? "" : worksheet.Cells[j, 13].Value.ToString().Trim();
                        string tels = String.IsNullOrEmpty(worksheet.Cells[j, 14].ToString()) ? "" : worksheet.Cells[j, 14].Value.ToString().Trim();

                        if (String.IsNullOrEmpty(worksheet.Cells[j, 2].Value.ToString()) ||
                          String.IsNullOrEmpty(worksheet.Cells[j, 3].Value.ToString()) ||
                          String.IsNullOrEmpty(worksheet.Cells[j, 4].Value.ToString()) ||
                          String.IsNullOrEmpty(worksheet.Cells[j, 5].Value.ToString()))
                        {
                            jp.StudentId= studentID;
                            jp.FirstName = firstName;
                            jp.OtherNames = otherNames;
                            jp.DOB = dob;
                            jp.Address = address;
                            jp.College = college;
                            jp.department = departments;
                            jp.CourseProgram = courseProgram;
                            jp.lga = lgas;
                            jp.state = states;
                            jp.email = emails;
                            jp.tel = tels;

                        }


                        if (worksheet.Cells[j, 2].Value.ToString().Trim() != null)
                        {
                            jp.StudentId = worksheet.Cells[j, 2].Value.ToString().Trim();
                            jp.FirstName = worksheet.Cells[j, 5].Value.ToString().Trim();
                            jp.OtherNames = worksheet.Cells[j, 4].Value.ToString().Trim();

                            jp.DOB = worksheet.Cells[j, 5].Value.ToString().Trim();
                            jp.Address = worksheet.Cells[j, 6].Value.ToString().Trim();
                            jp.College = worksheet.Cells[j, 7].Value.ToString().Trim();
                            jp.department = worksheet.Cells[j, 8].Value.ToString().Trim();
                            jp.CourseProgram = worksheet.Cells[j, 9].Value.ToString().Trim(); ;
                            jp.lga = worksheet.Cells[j, 10].Value.ToString().Trim(); ;
                            jp.state = worksheet.Cells[j, 11].Value.ToString().Trim(); 
                            jp.email = worksheet.Cells[j, 12].Value.ToString().Trim();
                            jp.tel = worksheet.Cells[j, 13].Value.ToString().Trim();

                        }


                        listApplication.Add(jp);
                    }


                    StudentUpload upk = new StudentUpload(listApplication, unitofwork, user);
                    var listapplicationofrecordnotavailable = await upk.UploadInThread();
                   

                    TempData["message"] = "Uploaded Successfully";


                    if (listapplicationofrecordnotavailable.Count > 0)
                    {

                        var stream2 = new MemoryStream();

                        using (var package2 = new ExcelPackage(stream2))
                        {
                            var workSheet = package2.Workbook.Worksheets.Add("Sheet2");
                            workSheet.Cells.LoadFromCollection(listapplicationofrecordnotavailable, true);
                            package2.Save();
                        }
                        stream2.Position = 0;
                        string excelName = $"Students-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

                        //return File(stream, "application/octet-stream", excelName);  
                        return File(stream2, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                    }
                }



            }


            return RedirectToAction("Index");
        }
    }
}
