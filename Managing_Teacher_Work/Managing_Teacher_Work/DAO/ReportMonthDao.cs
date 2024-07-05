using Managing_Teacher_Work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class ReportMonthDao
    {
        MTWDbContext db = null;

        public ReportMonthDao()
        {
            db = new MTWDbContext();
        }
       
        public List<ReportMonth> ListAll()
        {
            return db.ReportMonth.ToList();
        }
        public List<ReportMonth>ListWithItem(int top)
        {
            return db.ReportMonth.Where(x => x.ID > 0).OrderByDescending(y => y.CreatedDate).Take(top).ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Files.Find(id);
                db.Files.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteReport(int id)
        {
            try
            {
                var rp = db.ReportMonth.Find(id);
                db.ReportMonth.Remove(rp);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}