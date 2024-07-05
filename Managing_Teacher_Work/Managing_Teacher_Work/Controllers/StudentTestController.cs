using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Managing_Teacher_Work.ViewModels;
using Managing_Teacher_Work.Models;
using Managing_Teacher_Work.DAO;

namespace Managing_Teacher_Work.Controllers
{
    public class StudentTestController : Controller
    {
        // GET: StudentTest
        MTWDbContext db = new MTWDbContext();
        public ActionResult Index()
        {
            var listStudent = new List<StudentViewModel>();
            db.Student.ToList().ForEach(student =>
            {
                listStudent.Add(new StudentViewModel(student.ID, student.Name_Student, student.ClassID,student.DateOfBirth,student.Address,student.Email,student.Phone));
            });
            ViewBag.listStudent = listStudent;
            var dao = new ClassDao();
            var listClass = dao.ListAll();
            ViewBag.listClass = listClass;
            return View();
        }
    }
}