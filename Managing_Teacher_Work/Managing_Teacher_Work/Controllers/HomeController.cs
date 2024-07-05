using Managing_Teacher_Work.DAO;
using Managing_Teacher_Work.Models;
using Managing_Teacher_Work.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Managing_Teacher_Work.SQLEDM;

namespace Managing_Teacher_Work.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        MTWDbContext db = new MTWDbContext();
      /// <summary>
      /// Đổ dữ liệu ra View qua ViewModel
      /// </summary>
      /// <returns></returns>
        public ActionResult Index()
        {
           
            var listCW = new List<CalendarWorkingViewModel>();
            db.CalendarWorking.ToList().ForEach(S =>
            {
                listCW.Add(new CalendarWorkingViewModel(S.ID, S.Name_CalendarWorking, S.Description, S.DateStart, S.DateEnd, S.Address, S.TeacherID, S.WorkID, S.TypeCalendarID, S.WorkState, S.Status));
            });
            ViewBag.listCW = listCW;
            var dao = new CalendarWorkingDao();
            var model = dao.ListAll();
            
          
            return View(model);
        }
        /// <summary>
        /// Render danh sách menu 
        /// </summary>
        /// <returns></returns>
        public PartialViewResult DanhSachMenu()
        {
            List<Menu> listMenu = db.Menu.OrderByDescending(x=>x.CreatedDate).ToList();
            ViewBag.listMenu = listMenu;
            return PartialView();
        }
        public ActionResult ManageTeacher()
        {
            //var TeacherList = db.Teacher.Where(x => x.ID > 0).OrderByDescending(y => y.CreatedDate).ToList();
            //ViewBag.TeacherList = TeacherList;
            var listScience = db.Science.Where(x => x.ID > 0).OrderByDescending(y => y.CreatedDate).ToList();
            ViewBag.listScience = listScience;
            return View();
        }
        public ActionResult ManageStudent()
        {
            var listClass = new List<ClassViewModel>();
            db.Class.ToList().ForEach(item =>
            {
                listClass.Add(new ClassViewModel(item.ID, item.Name, item.Address, item.TeacherID, item.ScienceID));
            });

            ViewBag.listClass = listClass;
            return View();
        }
     
        public ActionResult ManageClass()
        {
            return View();
        }
      
       
        public ActionResult CalendarNote()
        {
            return View();
        }
        public ActionResult CalNote()
        {
            return View();
        }
        public ActionResult Extention()
        {
            return View();
        }
        public ActionResult ListStudent(long idclass)
        {
            var studentDao = new StudentDao();
            var classDao = new ClassDao();
            var ClassDetails = classDao.GetClassById(idclass);
            ViewBag.ClassDetails = ClassDetails;
            var ListStudentOfClass = studentDao.GetListStudentByClassId(idclass);
            ViewBag.ListStudent = ListStudentOfClass;
            return View();
        }
        public ActionResult ListTeacher(long idscience)
        {
            var teacherDao = new TeacherDao();
            var scienceDao = new ScienseDao();
            var science = scienceDao.GetScienceById(idscience);
            ViewBag.science = science;
            var listTeacher = teacherDao.GetListTeacherByScienceID(idscience);
            ViewBag.listTeacher = listTeacher;


            return View();
        }
        
     /// <summary>
     /// Lấy thông tin chi tiết lịch công tác theo id
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>
        public ActionResult CalendarWorkingDetails(int id)
        {
            var cw = new CalendarWorkingDao().ViewDetails(id);
            ViewBag.Cw = cw;
            ViewBag.teacher = new TeacherDao().ViewDetails(cw.TeacherID);
            ViewBag.work = new WorkDao().ViewDetailsWork(cw.WorkID);
            ViewBag.typecalendar = new TypeCalendarDao().ViewDetailTypeCalendar(cw.TypeCalendarID);
            return View();
        }
        /// <summary>
        /// Trang chi tiết cấp 2 theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CalendarWorkingDetails_Level2(int id)
        {
            var cw = new CalendarWorkingDao().ViewDetails(id);
            ViewBag.Calendarworking = cw;
            ViewBag.teacher = new TeacherDao().ViewDetails(cw.TeacherID);
            ViewBag.work = new WorkDao().ViewDetailsWork(cw.WorkID);
            ViewBag.typecalendar = new TypeCalendarDao().ViewDetailTypeCalendar(cw.TypeCalendarID);
            return View();
        }
        /// <summary>
        /// Lấy thông tin ghi chú công việc bằng Ajax
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEvents()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var events = dc.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        /// <summary>
        /// Cập nhật ghi chú công việc bằng Ajax
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                if (e.EventID > 0)
                {
                 
                    var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Events.Add(e);
                }

                dc.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }
        /// <summary>
        /// Xoá ghi chú sự kiện
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}