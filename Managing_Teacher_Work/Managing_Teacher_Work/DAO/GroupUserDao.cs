using Managing_Teacher_Work.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class GroupUserDao
    {
        MTWDbContext db = null;

        public GroupUserDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<GroupUser> Listpg(int page, int pageSize)
        {
            return db.GroupUser.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public List<GroupUser> ListAll()
        {
            return db.GroupUser.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.GroupUser.Find(id);
                db.GroupUser.Remove(user);
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