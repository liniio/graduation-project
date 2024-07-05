using Managing_Teacher_Work.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Managing_Teacher_Work.ViewModels;

namespace Managing_Teacher_Work.DAO
{
    public class ClassDao
    {
        MTWDbContext db = null;

        public ClassDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<Class> Listpg(int page, int pageSize)
        {
            return db.Class.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Class> ListAll()
        {
            return db.Class.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Class.Find(id);
                db.Class.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
      public Class GetClassById(long id)
        {
            return db.Class.Find(id);
        }
       
    }
}