using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Managing_Teacher_Work.SQLEDM;

namespace Managing_Teacher_Work.DAO
{
    public class EventDao
    {
        MyDatabaseEntities db = null;

        public EventDao()
        {
            db = new MyDatabaseEntities();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Events.Find(id);
                db.Events.Remove(user);
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