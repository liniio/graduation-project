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

namespace Managing_Teacher_Work.Controllers
{
    public class ClassController : BaseController
    {
        // GET: Class
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi;
        public Teacher teacher;
        
        public ActionResult Index(string id)
        {
            
            List<Teacher> listTeacher = db.Teacher.ToList();
            ViewBag.listTeacher = listTeacher;
            List<Science> listScience = db.Science.ToList();
            ViewBag.listScience = listScience;
            var listClass = new List<ClassViewModel>();
            db.Class.ToList().ForEach(item =>
            {
                listClass.Add(new ClassViewModel(item.ID, item.Name, item.Address, item.TeacherID, item.ScienceID));
            });

            ViewBag.listClass = listClass;
          
                return View();
        }
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.Class.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);



        }

        public ActionResult Add(Class model, string submit)
        {
            if (submit == "Thêm")
            {


                isThemMoi = true;
                if (model != null)
                {
                    model.Name = model.Name.ToString();
                    model.Address = model.Address.ToString();
                    model.TeacherID = model.TeacherID;
                    model.ScienceID = model.ScienceID;
                    model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);

                    db.Class.Add(model);
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
                    var list = db.Class.SingleOrDefault(x => x.ID == model.ID);
                    list.Name = model.Name;
                    list.Address = model.Address.ToString();
                    list.TeacherID = model.TeacherID;
                    list.ScienceID   = model.ScienceID;
                    list.ModifiedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                    db.SaveChanges();
                  
                }
                SetAlert("Cập nhật thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Tìm")
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    List<Class> list = GetData().Where(s => s.Name.Contains(model.Name)).ToList();
                    return View("Index", list);
                }
                else
                {
                    List<Class> list = GetData();
                    return View("Index", list);
                }
            }
            else
            {
                List<Class> list = GetData().OrderBy(s => s.Name).ToList();
                return View("Index", list);
            }
        }
        public List<Class> GetData()
        {
            return db.Class.ToList();


        }
        public ActionResult Delete(int id)
        {
            new ClassDao().Delete(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }

    }
}