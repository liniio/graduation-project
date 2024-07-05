using Managing_Teacher_Work.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class TeacherDao
    {
        MTWDbContext db = null;

        public TeacherDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<Teacher> Listpg(int page, int pageSize)
        {
            return db.Teacher.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Teacher> ListAll()
        {
            return db.Teacher.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Teacher.Find(id);
                db.Teacher.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Teacher ViewDetails(long id)
        {
            return db.Teacher.Find(id);
        }
        public List<Teacher> GetListTeacherByScienceID(long idScience)
        {
            return db.Teacher.Where(x => x.SicenceID == idScience).OrderByDescending(y => y.CreatedDate).ToList();
        }
    }
}