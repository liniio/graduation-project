using Managing_Teacher_Work.DAO;
using Managing_Teacher_Work.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class ReportMonthController : BaseController
    {
        // GET: ReportMonth
        MTWDbContext db = new MTWDbContext();
        public ActionResult Statistics_Report()
        {
            //----------------------
            string maincnn = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn = new SqlConnection(maincnn);
            string condition = "select * from ReportMonth where MONTH(Date) = 1 order by Date desc";
            SqlDataAdapter sqlda = new SqlDataAdapter(condition, maincnn);
            sqlcnn.Open();
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            IEnumerable<ReportMonth> mon1 = ConvertToTankReadings(dt);

            ViewBag.mon1 = mon1;

            sqlcnn.Close();
            //---------------------
          
            string maincnn2 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn2 = new SqlConnection(maincnn2);
            string condition2 = "select * from ReportMonth where MONTH(Date) = 2 order by Date desc";
            SqlDataAdapter sqlda2 = new SqlDataAdapter(condition2, maincnn2);
            sqlcnn2.Open();
            DataTable dt2 = new DataTable();
            sqlda2.Fill(dt2);
            IEnumerable<ReportMonth> mon2 = ConvertToTankReadings(dt2);

            ViewBag.mon2 = mon2;

            sqlcnn2.Close();
            
            //---------------------

            string maincnn3 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn3 = new SqlConnection(maincnn3);
            string condition3 = "select * from ReportMonth where MONTH(Date) = 3 order by Date desc";
            SqlDataAdapter sqlda3 = new SqlDataAdapter(condition3, maincnn3);
            sqlcnn3.Open();
            DataTable dt3 = new DataTable();
            sqlda3.Fill(dt3);
            IEnumerable<ReportMonth> mon3 = ConvertToTankReadings(dt3);

            ViewBag.mon3 = mon3;

            sqlcnn3.Close();
            //--------------------
            string maincnn4 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn4 = new SqlConnection(maincnn4);
            string condition4 = "select * from ReportMonth where MONTH(Date) = 4 order by Date desc";
            SqlDataAdapter sqlda4 = new SqlDataAdapter(condition4, maincnn4);
            sqlcnn4.Open();
            DataTable dt4 = new DataTable();
            sqlda4.Fill(dt4);
            IEnumerable<ReportMonth> mon4 = ConvertToTankReadings(dt4);

            ViewBag.mon4 = mon4;

            sqlcnn4.Close();
            //--------------------
            string maincnn5 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn5 = new SqlConnection(maincnn5);
            string condition5 = "select * from ReportMonth where MONTH(Date) = 5 order by Date desc";
            SqlDataAdapter sqlda5 = new SqlDataAdapter(condition5, maincnn5);
            sqlcnn5.Open();
            DataTable dt5 = new DataTable();
            sqlda5.Fill(dt5);
            IEnumerable<ReportMonth> mon5 = ConvertToTankReadings(dt5);

            ViewBag.mon5 = mon5;

            sqlcnn5.Close();
            //--------------------
            string maincnn6 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn6 = new SqlConnection(maincnn6);
            string condition6 = "select * from ReportMonth where MONTH(Date) = 6 order by Date desc";
            SqlDataAdapter sqlda6 = new SqlDataAdapter(condition6, maincnn6);
            sqlcnn6.Open();
            DataTable dt6 = new DataTable();
            sqlda6.Fill(dt6);
            IEnumerable<ReportMonth> mon6 = ConvertToTankReadings(dt6);

            ViewBag.mon6 = mon6;

            sqlcnn6.Close();
            //--------------------
            string maincnn7 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn7 = new SqlConnection(maincnn7);
            string condition7 = "select * from ReportMonth where MONTH(Date) = 7 order by Date desc";
            SqlDataAdapter sqlda7 = new SqlDataAdapter(condition7, maincnn7);
            sqlcnn7.Open();
            DataTable dt7 = new DataTable();
            sqlda7.Fill(dt7);
            IEnumerable<ReportMonth> mon7 = ConvertToTankReadings(dt7);

            ViewBag.mon7 = mon7;

            sqlcnn7.Close();
            //--------------------
            string maincnn8 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn8 = new SqlConnection(maincnn8);
            string condition8 = "select * from ReportMonth where MONTH(Date) = 8 order by Date desc";
            SqlDataAdapter sqlda8 = new SqlDataAdapter(condition8, maincnn8);
            sqlcnn8.Open();
            DataTable dt8 = new DataTable();
            sqlda8.Fill(dt8);
            IEnumerable<ReportMonth> mon8 = ConvertToTankReadings(dt8);

            ViewBag.mon8 = mon8;

            sqlcnn8.Close();
            //--------------------
            string maincnn9 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn9 = new SqlConnection(maincnn9);
            string condition9 = "select * from ReportMonth where MONTH(Date) = 9 order by Date desc";
            SqlDataAdapter sqlda9 = new SqlDataAdapter(condition9, maincnn9);
            sqlcnn9.Open();
            DataTable dt9 = new DataTable();
            sqlda9.Fill(dt9);
            IEnumerable<ReportMonth> mon9= ConvertToTankReadings(dt9);

            ViewBag.mon9 = mon9;

            sqlcnn9.Close();
            //--------------------
            string maincnn10 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn10 = new SqlConnection(maincnn10);
            string condition10 = "select * from ReportMonth where MONTH(Date) = 10 order by Date desc";
            SqlDataAdapter sqlda10 = new SqlDataAdapter(condition10, maincnn10);
            sqlcnn10.Open();
            DataTable dt10 = new DataTable();
            sqlda10.Fill(dt10);
            IEnumerable<ReportMonth> mon10 = ConvertToTankReadings(dt10);

            ViewBag.mon10 = mon10;

            sqlcnn10.Close();
            //--------------------
            string maincnn11 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn11 = new SqlConnection(maincnn11);
            string condition11 = "select * from ReportMonth where MONTH(Date) = 11 order by Date desc";
            SqlDataAdapter sqlda11 = new SqlDataAdapter(condition11, maincnn11);
            sqlcnn11.Open();
            DataTable dt11 = new DataTable();
            sqlda11.Fill(dt11);
            IEnumerable<ReportMonth> mon11= ConvertToTankReadings(dt11);

            ViewBag.mon11 = mon11;

            sqlcnn11.Close();
            //--------------------
            string maincnn12 = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn12 = new SqlConnection(maincnn12);
            string condition12 = "select * from ReportMonth where MONTH(Date) = 12 order by Date desc";
            SqlDataAdapter sqlda12 = new SqlDataAdapter(condition12, maincnn12);
            sqlcnn12.Open();
            DataTable dt12 = new DataTable();
            sqlda12.Fill(dt12);
            IEnumerable<ReportMonth> mon12 = ConvertToTankReadings(dt12);

            ViewBag.mon12 = mon12;

            sqlcnn12.Close();
            //--------------------
            var listReportAll = db.ReportMonth.Where(x => x.ID > 0).OrderByDescending(y => y.CreatedDate).ToList();
            ViewBag.listReportAll = listReportAll;
            ViewBag.countItem = listReportAll.Count;
            return View();
        }
        private IEnumerable<ReportMonth> ConvertToTankReadings(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new ReportMonth
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = Convert.ToString(row["Name"]),
                    ClassName = Convert.ToString(row["ClassName"]),
                    Date = Convert.ToDateTime(row["Date"]),
                    Files = Convert.ToString(row["Files"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])



                };
            }

        }
        public ActionResult Index()
        {
            var dao = new ReportMonthDao();
            var listForm = db.Files.ToList();
            ViewBag.listForm = listForm;
            var listClass = db.Class.OrderBy(x => x.Name).ToList();
            ViewBag.listClass = listClass;
            var listReport = new ReportMonthDao().ListWithItem(5);
            ViewBag.listReport = listReport;
            
            return View();
        }
        public ActionResult Delete(int id)
        {
            new ReportMonthDao().Delete(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }
        public ActionResult DeleteReport(int id)
        {
            new ReportMonthDao().DeleteReport(id);
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Statistics_Report");
        }
        public ActionResult AddFiles(Files model, string submit)
        {
            if (submit == "Thêm")
            {

                if (model != null)
                {
                    model.Name = model.Name.ToString().Trim() ?? "";
                    model.FileForm = model.FileForm;
                    db.Files.Add(model);
                    db.SaveChanges();
                }
                SetAlert("Thêm thông tin thành công! :D", "success");
                return RedirectToAction("Index");

            }
            else if (submit == "Cập Nhật")
            {
              
                if (model != null)
                {
                    var list = db.Files.SingleOrDefault(x => x.ID == model.ID);
                    list.Name = model.Name;
                    list.FileForm = model.FileForm.ToString();
                    db.SaveChanges();
                    model = null;
                }
                SetAlert("Cập nhật mẫu báo cáo thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else
            {
                List<Files> list = GetData().OrderBy(s => s.Name).ToList();
                return View("Index", list);
            }
        }
        public List<Files> GetData()
        {
            return db.Files.ToList();


        }
        public List<ReportMonth> GetDataReport()
        {
            return db.ReportMonth.ToList();


        }
      
        public ActionResult SendReport(ReportMonth model, string submit)
        {
            if (submit == "Gửi")
            {

                if (model != null)
                {
                    model.Name = model.Name.ToString().Trim() ?? "";
                    model.ClassName = model.ClassName;
                    model.Date = model.Date;
                    model.Files = model.Files;
                    model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now); ;
                    db.ReportMonth.Add(model);
                    db.SaveChanges();
                }

                SetAlert("Đã gửi báo cáo tháng thành công! :D", "success");
                return RedirectToAction("Index");

            }
            else if (submit == "Cập Nhật")
            {

                if (model != null)
                {
                    var list = db.ReportMonth.SingleOrDefault(x => x.ID == model.ID);
                    list.Name = model.Name;
                    list.ClassName = model.ClassName.ToString();
                    db.SaveChanges();
                    model = null;
                }
                SetAlert("Cập nhật mẫu báo cáo thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else
            {
                List<ReportMonth> list = GetDataReport().OrderBy(s => s.Name).ToList();
                return View("Index", list);
            }
        }
    }
}