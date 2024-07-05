using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Managing_Teacher_Work.Models;
using PagedList;

namespace Managing_Teacher_Work.DAO
{
    public class CalendarWorkingDao
    {
        MTWDbContext db = null;

        public CalendarWorkingDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<CalendarWorking> Listpg(int page, int pageSize)
        {
            return db.CalendarWorking.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<CalendarWorking> ListAll()
        {
            return db.CalendarWorking.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.CalendarWorking.Find(id);
                db.CalendarWorking.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public CalendarWorking ViewDetails(int id)
        {
            return db.CalendarWorking.Find(id);
        }
    }
}