using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Managing_Teacher_Work.Models;
using Managing_Teacher_Work.DAO;
using Newtonsoft.Json;
using System.Globalization;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class TypeCalendarController : BaseController
    {
        // GET: TypeCalendar
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi;
        public string MessageIndex;

        public ActionResult Index()
        {
            List<TypeCalendar> listTypeCalendar = db.TypeCalendar.ToList();
            ViewBag.listTypeCalendar = listTypeCalendar;

            return View();
        }
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.TypeCalendar.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);



        }

        public ActionResult Add(TypeCalendar model, string submit)
        {
            if (submit == "Thêm")
            {


                isThemMoi = true;
                if (model != null)
                {

                    model.TypeName = model.TypeName.ToString().Trim();
                    model.TypeDescription = model.TypeDescription.ToString();
                    model.Status = model.Status.ToString();
                    model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);

                    db.TypeCalendar.Add(model);
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
                    var list = db.TypeCalendar.SingleOrDefault(x => x.ID == model.ID);
                    list.TypeName = model.TypeName.ToString().Trim();
                    list.TypeDescription = model.TypeDescription.ToString();
                    list.Status = model.Status.ToString();
                    list.ModifiedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                    db.SaveChanges();
                    model = null;
                }
                SetAlert("Cập nhật thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Tìm")
            {
                if (!string.IsNullOrEmpty(model.TypeName))
                {
                    List<TypeCalendar> list = GetData().Where(s => s.TypeName.Contains(model.TypeName)).ToList();
                    return View("Index", list);
                }
                else
                {
                    List<TypeCalendar> list = GetData();
                    return View("Index", list);
                }
            }
            else
            {
                List<TypeCalendar> list = GetData().OrderBy(s => s.TypeName).ToList();
                return View("Index", list);
            }
        }
        public List<TypeCalendar> GetData()
        {
            return db.TypeCalendar.ToList();


        }
        public ActionResult Delete(int id)
        {
            new TypeCalendarDao().Delete(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }

    }
}