using Managing_Teacher_Work.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Managing_Teacher_Work.Controllers
{
    public class FontendController : BaseController
    {
        // GET: Fontend
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProfileTeacher(int id)
        {
            var teacher = new TeacherDao().ViewDetails(id);
            ViewBag.teacher = teacher;
            var science = new ScienseDao().GetScienceById(teacher.SicenceID);
            ViewBag.science = science;
            return View();
        }
        public ActionResult ProfileStudent(int id)
        {
            var dao = new StudentDao();
            var student = dao.GetStudentById(id);
            ViewBag.student = student;
            var Class = new ClassDao().GetClassById(student.ClassID);
            ViewBag.Class = Class;

            return View();

        }
    }
}