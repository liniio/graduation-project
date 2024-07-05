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
using Managing_Teacher_Work.Common;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class TeacherController : BaseController
    {
        // GET: Teacher
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi = true;
        public ActionResult Index()
        {
       
            string maincnn = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn = new SqlConnection(maincnn);
            string condition = "Select * from Teacher order by CreatedDate desc";
            SqlDataAdapter sqlda = new SqlDataAdapter(condition, maincnn);
            sqlcnn.Open();
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            IEnumerable<Teacher> listTeacher = ConvertToTankReadings(dt);
            //List<Teacher> listTeacher = db.Teacher.OrderByDescending(y => y.CreatedDate).ToList();
            ViewBag.listTeacher = listTeacher;
            List<Science> listScience = db.Science.OrderByDescending(y => y.CreatedDate).ToList();
            ViewBag.listScience = listScience;
            return View();
        }
        private IEnumerable<Teacher> ConvertToTankReadings(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new Teacher
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name_Teacher = Convert.ToString(row["Name_Teacher"]),
                    Phone = Convert.ToString(row["Phone"]),
                    Address = Convert.ToString(row["Address"]),

                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                    Avatar = Convert.ToString(row["Avatar"]),

                    Gender = Convert.ToString(row["Gender"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    Status = Convert.ToString(row["Status"]),
                    SicenceID = Convert.ToInt32(row["SicenceID"]),



                };
            }

        }
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.Teacher.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);



        }

        public ActionResult Add(Teacher model, string submit)
        {
            if (submit == "Thêm")
            {


                isThemMoi = true;
                if (model != null)
                {
                    model.Name_Teacher = model.Name_Teacher.ToString().Trim();
                    model.Phone = model.Phone.Trim();
                    if (model.Address != null)
                    {
                        model.Address = model.Address.ToString().Trim();
                    }

                    model.DateOfBirth = model.DateOfBirth;
                    model.Avatar = model.Avatar.ToString().Trim();
                    model.Gender = model.Gender.ToString().Trim();
                    model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                    model.Status = model.Status.ToString();
                    model.SicenceID = model.SicenceID;

                    db.Teacher.Add(model);
                    db.SaveChanges();
                    model = null;
                }
                ViewBag.checkThemMoi = isThemMoi;
                SetAlert("Thêm thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Cập Nhật")
            {
                isThemMoi = false;
                if (model != null)
                {
                    var list = db.Teacher.SingleOrDefault(x => x.ID == model.ID);
                    list.Name_Teacher = model.Name_Teacher.ToString().Trim();
                    list.Phone = model.Phone.Trim();
                    if (model.Address != null)
                    {
                        list.Address = model.Address.ToString().Trim();
                    }

                    list.DateOfBirth = model.DateOfBirth;
                    list.Avatar = model.Avatar.ToString().Trim();
                    list.Gender = model.Gender.ToString().Trim();
                    list.ModifiedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                    list.Status = model.Status.ToString().Trim();
                    list.SicenceID = model.SicenceID;
                    db.SaveChanges();
                    model = null;
                }
                SetAlert("Cập nhật thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Tìm")
            {
                if (!string.IsNullOrEmpty(model.Name_Teacher))
                {
                    List<Teacher> list = GetData().Where(s => s.Name_Teacher.Contains(model.Name_Teacher)).ToList();
                    return View("Index", list);
                }
                else
                {
                    List<Teacher> list = GetData();
                    return View("Index", list);
                }
            }
            else
            {
                List<Teacher> list = GetData().OrderBy(s => s.Name_Teacher).ToList();
                return View("Index", list);
            }
        }
        public List<Teacher> GetData()
        {
            return db.Teacher.ToList();


        }
        public ActionResult Delete(int id)
        {
            new TeacherDao().Delete(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }

    }
}