using Managing_Teacher_Work.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.ViewModels
{
    public class ClassViewModel
    {
        public ClassViewModel()
        {
            GetTeacher();
            GetScience();
        }
        public ClassViewModel(int classID, string name, string address, int teacherID, int scienceID)
        {
            ID = classID;
            Name = name;
            Address = address;
            TeacherID = teacherID;
            ScienceID = scienceID;
            GetTeacher();
            GetScience();

        }

        public int ID { get; set; }

        public string Name { get; set; }
      
        public string Address { get; set; }
        public int TeacherID { get; set; }
        public int ScienceID { get; set; }
        public string TeacherName { get; set; }
        public string ScienceName { get; set; }
        public void GetTeacher()
        {
            if (TeacherID > 0)
            {
                using (MTWDbContext db = new MTWDbContext())
                {
                    this.TeacherName = db.Teacher.Find(this.TeacherID) != null ?
                        db.Teacher.Find(this.TeacherID).Name_Teacher : string.Empty;
                }
            }
        }
        public void GetScience()
        {
            if (ScienceID > 0)
            {
                using (MTWDbContext db = new MTWDbContext())
                {
                    this.ScienceName = db.Science.Find(this.ScienceID) != null ?
                        db.Science.Find(this.ScienceID).Name : string.Empty;
                }
            }
        }
    }
}