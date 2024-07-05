using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Managing_Teacher_Work.Models;
using Managing_Teacher_Work.DAO;
using Newtonsoft.Json;
using System.Globalization;
using Managing_Teacher_Work.ViewModels;
using System.IO;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    
    public class CalendarWorkingController : BaseController
    {
        // GET: CalendarWorking
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi;
        public ActionResult Index()
        {
            //List<CalendarWorking> listCW = db.CalendarWorking.ToList();
            //ViewBag.listCW = listCW;
            var listCW = new List<CalendarWorkingViewModel>();
            db.CalendarWorking.ToList().ForEach(S =>
            {
                listCW.Add(new CalendarWorkingViewModel(S.ID, S.Name_CalendarWorking, S.Description, S.DateStart, S.DateEnd, S.Address, S.TeacherID, S.WorkID, S.TypeCalendarID, S.WorkState, S.Status));
            });
            ViewBag.listCW = listCW;
            List<Teacher> listTeacher = db.Teacher.ToList();
            ViewBag.listTeacher = listTeacher;
            List<Work> listWork = db.Work.ToList();
            ViewBag.listWork = listWork;
            List<TypeCalendar> listTypeCalendar = db.TypeCalendar.ToList();
            ViewBag.listTypeCalendar = listTypeCalendar;
            return View();
        }
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.CalendarWorking.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);



        }

        public ActionResult Add(CalendarWorking model, string submit)
        {
            if (submit == "Thêm")
            {


                isThemMoi = true;
                if (model != null)
                {
                    model.Name_CalendarWorking = model.Name_CalendarWorking.ToString();

                    model.Description = model.Description.ToString();
                    model.DateStart = model.DateStart;
                    model.DateEnd = model.DateEnd;
                    model.Address = model.Address != null ? model.Address : "";
                    model.TeacherID = model.TeacherID;
                    model.WorkID = model.WorkID;
                    model.TypeCalendarID = model.TypeCalendarID;
                    model.WorkState = model.WorkState;
                    model.Status = model.Status;
                    model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);

                    db.CalendarWorking.Add(model);
                    db.SaveChanges();
                    model = null;
                }
                SetAlert("Thêm thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Cập Nhật")
            {
                isThemMoi = false;
                if (model != null)
                {
                    var list = db.CalendarWorking.SingleOrDefault(x => x.ID == model.ID);
                    list.Name_CalendarWorking = model.Name_CalendarWorking;
                    list.Description = model.Description;
                    list.DateStart = model.DateStart;
                    list.DateEnd = model.DateEnd;
                    list.Address = model.Address.ToString();
                    list.TeacherID = model.TeacherID;
                    list.WorkID = model.WorkID;
                    list.TypeCalendarID = model.TypeCalendarID;
                    list.WorkState = model.WorkState;
                    list.Status = model.Status;
                    list.ModifiedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                    db.SaveChanges();
                    model = null;
                }
                SetAlert("Cập nhật thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Tìm")
            {
                if (!string.IsNullOrEmpty(model.Name_CalendarWorking))
                {
                    List<CalendarWorking> list = GetData().Where(s => s.Name_CalendarWorking.Contains(model.Name_CalendarWorking)).ToList();
                    return View("Index", list);
                }
                else
                {
                    List<CalendarWorking> list = GetData();
                    return View("Index", list);
                }
            }
            else
            {
                List<CalendarWorking> list = GetData().OrderBy(s => s.Name_CalendarWorking).ToList();
                return View("Index", list);
            }
        }
        public List<CalendarWorking> GetData()
        {
            return db.CalendarWorking.ToList();


        }
        public ActionResult Delete(int id)
        {
            new CalendarWorkingDao().Delete(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }

}