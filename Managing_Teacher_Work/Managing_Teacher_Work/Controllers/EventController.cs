using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Managing_Teacher_Work.SQLEDM;
using Managing_Teacher_Work.DAO;

namespace Managing_Teacher_Work.Controllers
{
    public class EventController : BaseController
    {
        // GET: Event
        MyDatabaseEntities db = new MyDatabaseEntities();
        public ActionResult Index()
        {
            var model = db.Events.Where(x=>x.EventID > 0).OrderByDescending(y=>y.Start).ToList();
            ViewBag.listEvent = model;
            return View();
        }
        public ActionResult Delete(int id)
        {
            new EventDao().Delete(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }
    }
}