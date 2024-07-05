using Managing_Teacher_Work.DAO;
using Managing_Teacher_Work.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class WorkController : BaseController
    {
        // GET: Work
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi;
        public ActionResult Index()
        {
            List<Work> listWork = db.Work.ToList();
            ViewBag.listWork = listWork;

            return View();
        }
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.Work.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);



        }

        public ActionResult Add(Work model, string submit)
        {
            if (submit == "Thêm")
            {


                isThemMoi = true;
                if (model != null)
                {
                    model.Name_Work = model.Name_Work.ToString();
                    model.Description_Work = model.Description_Work.ToString();
                    model.Details_Work = model.Details_Work.ToString();
                    model.DateWorkStart = model.DateWorkStart;
                    model.DateWorkEnd = model.DateWorkEnd;
                    if(model.Note!=null)
                    {
                        model.Note = model.Note.ToString();
                    }
                   
                    model.Status = model.Status;
                    model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                    db.Work.Add(model);
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
                    var list = db.Work.SingleOrDefault(x => x.ID == model.ID);
                    list.Name_Work = model.Name_Work??"";
                    list.Description_Work = model.Description_Work.ToString()??"";
                    list.Details_Work = model.Details_Work.ToString()??"";
                    list.DateWorkStart = model.DateWorkStart;
                    list.DateWorkEnd = model.DateWorkEnd;
                    if (model.Note != null)
                    {
                        list.Note = model.Note.ToString();
                    }

                   
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
                if (!string.IsNullOrEmpty(model.Name_Work))
                {
                    List<Work> list = GetData().Where(s => s.Name_Work.Contains(model.Name_Work)).ToList();
                    return View("Index", list);
                }
                else
                {
                    List<Work> list = GetData();
                    return View("Index", list);
                }
            }
            else
            {
                List<Work> list = GetData().OrderBy(s => s.Name_Work).ToList();
                return View("Index", list);
            }
        }
        public List<Work> GetData()
        {
            return db.Work.ToList();


        }
        public ActionResult Delete(int id)
        {
            new WorkDao().Delete(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }

    }
}