using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.Common
{
    [Serializable]
    public class UserLogin
    {
        public int ID { set; get; }
        public string UserName { set; get; }
        public string Name { set; get; }
        public string GroupID { set; get; }
    }
}