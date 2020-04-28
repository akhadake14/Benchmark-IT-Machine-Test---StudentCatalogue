using StudentCatalogue.BLL;
using StudentCatalogue.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp_MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            SqlServerDB sqlServerDB = new SqlServerDB();
            var students = sqlServerDB.StudentList();
            return View(students);
        }

        public ActionResult SaveStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudent(Student clsStudentData)
        {
            SqlServerDB sqlServerDB = new SqlServerDB();
            var students = sqlServerDB.SaveStudentData(clsStudentData);
            return View();
        }

        public ActionResult SecondHighestPocketMoneyStudent()
        {
            SqlServerDB sqlServerDB = new SqlServerDB();
            var student = sqlServerDB.SecondHighestPocketMoneyStudent();
            return View(student);
        }
    }
}