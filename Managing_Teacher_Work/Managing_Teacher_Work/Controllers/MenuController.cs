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
    public class MenuController : BaseController
    {
        // GET: Menu
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi;
        public ActionResult Index()
        {
            List<Menu> listMenu = db.Menu.OrderByDescending(x=>x.CreatedDate).ToList();
            ViewBag.listMenu = listMenu;

            return View();
        }
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.Menu.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);



        }

        public ActionResult Add(Menu model, string submit)
        {
            if (submit == "Thêm")
            {


                isThemMoi = true;
                if (model != null)
                {
                    model.Name = model.Name.ToString().Trim();
                    if(model.Description!=null)
                    {
                        model.Description = model.Description;
                    }
                   
                    model.MenuUrl = model.MenuUrl.ToString().Trim();

                    model.MenuICon = model.MenuICon.ToString().Trim();
                    model.Enable = model.Enable;
                    model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);

                    db.Menu.Add(model);
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
                    var list = db.Menu.SingleOrDefault(x => x.ID == model.ID);
                    list.Name = model.Name.ToString().Trim();
                    if (model.Description != null)
                    {
                        list.Description = model.Description.ToString();
                    }
                    
                    list.MenuUrl = model.MenuUrl.ToString().Trim();
                    list.MenuICon = model.MenuICon.ToString().Trim();
                    list.Enable = model.Enable;
                    list.ModifiedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                    db.SaveChanges();
                    model = null;
                }
                SetAlert("Cập nhật thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Tìm")
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    List<Menu> list = GetData().Where(s => s.Name.Contains(model.Name)).ToList();
                    return View("Index", list);
                }
                else
                {
                    List<Menu> list = GetData();
                    return View("Index", list);
                }
            }
            else
            {
                List<Menu> list = GetData().OrderBy(s => s.Name).ToList();
                return View("Index", list);
            }
        }
        public List<Menu> GetData()
        {
            return db.Menu.ToList();


        }
        public ActionResult Delete(int id)
        {
            new MenuDao().Delete(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }

    }
}