using Managing_Teacher_Work.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class UserDao
    {
        MTWDbContext db = null;

        public UserDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<User> Listpg(int page, int pageSize)
        {
            return db.User.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<User> ListAll()
        {
            return db.User.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public User GetById(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.User.Single(x => x.UserName == userName);
            var data = (from a in db.Credentials
                        join b in db.GroupUser on a.UserGroupID equals b.ID
                        join c in db.Role on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credentials()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }
        public User Get(string username)
        {
            return db.User.SingleOrDefault(x => x.UserName == username);
        }
        public int Login(string username, string password, bool isLoginAdmin = false)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == Managing_Teacher_Work.CommonConstants.ADMIN_GROUP|| result.GroupID == Managing_Teacher_Work.CommonConstants.MEMBER_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == password)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == password)
                            return 1;
                        else
                            return -2;
                    }
                }
            }

        }
    }
}