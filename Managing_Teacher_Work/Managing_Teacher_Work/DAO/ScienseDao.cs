using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Managing_Teacher_Work.Models;
using PagedList;


namespace Managing_Teacher_Work.DAO
{
    public class ScienseDao
    {
        MTWDbContext db = null;

        public ScienseDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<Science> Listpg(int page, int pageSize)
        {
            return db.Science.OrderByDescending(x => x.CreatedDate ).ToPagedList(page, pageSize);
        }
        public List<Science> ListAll()
        {
            return db.Science.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Science.Find(id);
                db.Science.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Science GetScienceById(long id)
        {
            return db.Science.Find(id);
        }
    }
}