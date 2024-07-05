using Managing_Teacher_Work.Models;
using Managing_Teacher_Work.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class StudentDao
    {
        MTWDbContext db = null;

        public StudentDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<Student> Listpg(int page, int pageSize)
        {
            return db.Student.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Student> ListAll()
        {
            return db.Student.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Student.Find(id);
                db.Student.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Student> GetListStudentByClassId(long idClass)
        {
            return db.Student.Where(x => x.ClassID == idClass).OrderBy(x => x.Name_Student).ToList();
        }
        public Student GetStudentById(int id)
        {
            return db.Student.Find(id);
        }
        
    }
}