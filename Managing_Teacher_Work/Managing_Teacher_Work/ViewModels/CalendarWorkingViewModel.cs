using Managing_Teacher_Work.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.ViewModels
{
    public class CalendarWorkingViewModel
    {
        public CalendarWorkingViewModel()
        {
            GetTeacher();
            GetWork();
            GetTypeCalendar();
        }
        public CalendarWorkingViewModel(int calendarID, string name_CalendarWorking, string description, DateTime dateStart, DateTime dateEnd, string address,int teacherID,int workID,int typecalendarID, string workstate,string status)
        {
            ID = calendarID;
            Name_CalendarWorking = name_CalendarWorking;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Address = address;
            TeacherID = teacherID;
            WorkID = workID;
            TypeCalendarID = typecalendarID;
            WorkState = workstate;
            Status = status;
            GetTeacher();
            GetWork();
            GetTypeCalendar();

        }

        public int ID { get; set; }

        public string Name_CalendarWorking { get; set; }

        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Address { get; set; }
        public int TeacherID { get; set; }

        public int  WorkID { get; set; }

        public int TypeCalendarID { get; set; }
        public string WorkState { get; set; }
        public string Status { get;set; }
        public string Teacher_Name { get; set; }
        public string Work_Name { get; set; }
        public string TypeCalendar_Name { get; set; }


        public void GetTeacher()
        {
            if (TeacherID > 0)
            {
                using (MTWDbContext db = new MTWDbContext())
                {
                    this.Teacher_Name = db.Teacher.Find(this.TeacherID) != null ?
                        db.Teacher.Find(this.TeacherID).Name_Teacher : string.Empty;
                }
            }
        }
        public void GetTypeCalendar()
        {
            if (TypeCalendarID > 0)
            {
                using (MTWDbContext db = new MTWDbContext())
                {
                    this.TypeCalendar_Name = db.TypeCalendar.Find(this.TypeCalendarID) != null ?
                        db.TypeCalendar.Find(this.TypeCalendarID).TypeName : string.Empty;
                }
            }
        }
        public void GetWork()
        {
            if (WorkID > 0)
            {
                using (MTWDbContext db = new MTWDbContext())
                {
                    this.Work_Name = db.Work.Find(this.WorkID) != null ?
                        db.Work.Find(this.WorkID).Name_Work : string.Empty;
                }
            }
        }

    }
}