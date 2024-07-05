using Managing_Teacher_Work.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class MenuDao
    {
        MTWDbContext db = null;

        public MenuDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<Menu> Listpg(int page, int pageSize)
        {
            return db.Menu.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Menu> ListAll()
        {
            return db.Menu.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Menu.Find(id);
                db.Menu.Remove(user);
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