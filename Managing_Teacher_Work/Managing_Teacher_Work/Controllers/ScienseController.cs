using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Managing_Teacher_Work.Models;
using Managing_Teacher_Work.DAO;
using Newtonsoft.Json;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class ScienseController : BaseController
    {
        // GET: Sciense
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi;
        public User currentUser;
        /// <summary>
        /// Kết nối bằng condition or api có sẵn trong mvc
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            isThemMoi = true;
            ViewBag.Check = isThemMoi;
         
            string maincnn = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn = new SqlConnection(maincnn);
            string condition = "select * from Science where (1=1) order by CreatedDate desc";
            SqlDataAdapter sqlda = new SqlDataAdapter(condition, maincnn);
            sqlcnn.Open();
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            IEnumerable<Science> model = ConvertToTankReadings(dt);

            ViewBag.listSciense = model;

            sqlcnn.Close();

          
            return View();
        }/// <summary>
        /// Chuyển đổi sql IEnumberable sang sql data table
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private IEnumerable<Science> ConvertToTankReadings(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new Science
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = Convert.ToString(row["Name"]),
                    Address = Convert.ToString(row["Address"]),
                    Description = Convert.ToString(row["Description"]),
                    Founding = Convert.ToDateTime(row["Founding"])



                };
            }

        }
        /// <summary>
        /// Lấy danh sách bằng Ajax theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult getList(int id)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.Science.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
          
          
           
        }
      /// <summary>
      /// Thêm và cập nhật dữ liệu bằng modal popup
      /// </summary>
      /// <param name="model"></param>
      /// <param name="submit"></param>
      /// <returns></returns>
        public ActionResult Add(Science model, string submit)
        {
            if (submit == "Thêm")
            {     
                if (model != null)
                {
                    model.Name = model.Name.ToString().Trim()??"";
                    model.Address = model.Address.ToString().Trim()??"";
                    if(model.Description!=null)
                    {
                        model.Description = model.Description;
                    }
                   
                    model.Founding = model.Founding;
                    model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);   

                    db.Science.Add(model);
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
                    var list = db.Science.SingleOrDefault(x => x.ID == model.ID);
                    list.Name = model.Name;
                    list.Address = model.Address.ToString();
                    if(list.Description!=null)
                    {
                        list.Description = model.Description;
                    }
                    
                    list.Founding = model.Founding;
                    list.ModifiedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                    db.SaveChanges();
                    model = null;
                }
                SetAlert("Cập nhật khoa thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Tìm")
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    List<Science> list = GetData().Where(s => s.Name.Contains(model.Name)).ToList();
                    return View("Index", list);
                }
                else
                {
                    List<Science> list = GetData();
                    return View("Index", list);
                }
            }
            else
            {
                List<Science> list = GetData().OrderBy(s => s.Name).ToList();
                return View("Index", list);
            }
        }
        /// <summary>
        /// Lấy tất cả dữ liệu của table
        /// </summary>
        /// <returns></returns>
        public List<Science> GetData()
        {
            return db.Science.ToList();


        }
        /// <summary>
        /// Xoá item theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            new ScienseDao().Delete(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }
      
    }
}