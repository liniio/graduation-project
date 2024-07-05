using Managing_Teacher_Work.SQLEDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Managing_Teacher_Work.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult EventsCalendar()
        {
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