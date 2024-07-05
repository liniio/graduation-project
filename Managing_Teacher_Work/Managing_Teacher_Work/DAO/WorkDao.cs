using Managing_Teacher_Work.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class WorkDao
    {
        MTWDbContext db = null;

        public WorkDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<Work> Listpg(int page, int pageSize)
        {
            return db.Work.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Work> ListAll()
        {
            return db.Work.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Work.Find(id);
                db.Work.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Work ViewDetailsWork(long id)
        {
            return db.Work.Find(id);
        }
    }
}