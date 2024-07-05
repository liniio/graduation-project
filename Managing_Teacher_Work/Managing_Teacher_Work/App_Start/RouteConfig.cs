using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Managing_Teacher_Work
{
    public class RouteConfig
    {
        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
 name: "Thông tin sinh viên",
 url: "Profile-Student/{id}",
 defaults: new { controller = "Fontend", action = "ProfileStudent", id = UrlParameter.Optional },
 namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
name: "Thống kê báo cáo",
url: "Statistics-Report",
defaults: new { controller = "ReportMonth", action = "Statistics_Report", id = UrlParameter.Optional },
namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
 name: "Báo cáo tháng",
 url: "Report",
 defaults: new { controller = "ReportMonth", action = "Index", id = UrlParameter.Optional },
 namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
  name: "Thông tin cá nhân",
  url: "Profile-Teacher/{id}",
  defaults: new { controller = "Fontend", action = "ProfileTeacher", id = UrlParameter.Optional },
  namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
    name: "Chi tiết lịch công tác cấp 2",
    url: "Calendar-Working-Detail-Level2/{id}",
    defaults: new { controller = "Home", action = "CalendarWorkingDetails_Level2", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
       name: "Danh sách giáo viên theo khoa",
       url: "listteacher/{idscience}",
       defaults: new { controller = "Home", action = "ListTeacher", id = UrlParameter.Optional },
       namespaces: new[] { "Managing_Teacher_Work.Controllers" }
   );
            routes.MapRoute(
       name: "Danh sách sinh viên theo lớp",
       url: "liststudent/{idclass}",
       defaults: new { controller = "Home", action = "ListStudent", id = UrlParameter.Optional },
       namespaces: new[] { "Managing_Teacher_Work.Controllers" }
   );
            routes.MapRoute(
    name: "Nhật ký sự kiện",
    url: "Event",
    defaults: new { controller = "Event", action = "Index", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
    name: "Tiện ích",
    url: "Extention",
    defaults: new { controller = "Home", action = "Extention", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
    name: "Ghi chú công việc",
    url: "Home-ManageNote",
    defaults: new { controller = "Home", action = "CalendarNote", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
    name: "Chi tiết lịch công tác",
    url: "Calendar-Working-Detail/{id}",
    defaults: new { controller = "Home", action = "CalendarWorkingDetails", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
   name: "Danh sách lớp học",
   url: "Home-ManageClass",
   defaults: new { controller = "Home", action = "ManageClass", id = UrlParameter.Optional },
   namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
  name: "Danh sách sinh viên",
  url: "Home-ManageStudent",
  defaults: new { controller = "Home", action = "ManageStudent", id = UrlParameter.Optional },
  namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
    name: "Danh sách giáo viên",
    url: "Home-ManageTeacher",
    defaults: new { controller = "Home", action = "ManageTeacher", id = UrlParameter.Optional },
    namespaces: new[] { "Managing_Teacher_Work.Controllers" }
);
            routes.MapRoute(
     name: "Trang chủ",
     url: "Home",
     defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
     namespaces: new[] { "Managing_Teacher_Work.Controllers" }
 );
            routes.MapRoute(
      name: "Đăng xuất",
      url: "Logout-System",
      defaults: new { controller = "User", action = "Logout", id = UrlParameter.Optional },
      namespaces: new[] { "Managing_Teacher_Work.Controllers" }
  );
            routes.MapRoute(
       name: "Đăng nhập",
       url: "Login-system",
       defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
       namespaces: new[] { "Managing_Teacher_Work.Controllers" }
   );
            routes.MapRoute(
       name: "Quản lý lịch công tác",
       url: "CalendarWorkingManagement",
       defaults: new { controller = "CalendarWorking", action = "Index", id = UrlParameter.Optional },
       namespaces: new[] { "Managing_Teacher_Work.Controllers" }
   );
            routes.MapRoute(
        name: "Quản lý sinh viên",
        url: "StudentManagement",
        defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional },
        namespaces: new[] { "Managing_Teacher_Work.Controllers" }
    );
            routes.MapRoute(
        name: "Quản lý loại công việc",
        url: "TypeCalendarManagement",
        defaults: new { controller = "TypeCalendar", action = "Index", id = UrlParameter.Optional },
        namespaces: new[] { "Managing_Teacher_Work.Controllers" }
    );
            routes.MapRoute(
         name: "Quản lý lớp học",
         url: "ClassManagement",
         defaults: new { controller = "Class", action = "Index", id = UrlParameter.Optional },
         namespaces: new[] { "Managing_Teacher_Work.Controllers" }
     );
            routes.MapRoute(
           name: "Quản lý người dùng",
           url: "UserManagement",
           defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional },
           namespaces: new[] { "Managing_Teacher_Work.Controllers" }
       );
            routes.MapRoute(
            name: "Quản lý quyền",
            url: "GroupUserManagement",
            defaults: new { controller = "GroupUser", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "Managing_Teacher_Work.Controllers" }
        );
            routes.MapRoute(
             name: "Quản lý giáo viên",
             url: "TeacherManagement",
             defaults: new { controller = "Teacher", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "Managing_Teacher_Work.Controllers" }
         );
            routes.MapRoute(
             name: "Quan ly cong viec",
             url: "WorksManagement",
             defaults: new { controller = "Work", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "Managing_Teacher_Work.Controllers" }
         );
            routes.MapRoute(
              name: "Quan ly menu",
              url: "MenuManagement",
              defaults: new { controller = "Menu", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "Managing_Teacher_Work.Controllers" }
          );
            routes.MapRoute(
                name: "Quan ly khoa ",
                url: "ScicenceManagement",
                defaults: new { controller = "Sciense", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Managing_Teacher_Work.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Managing_Teacher_Work.Controllers" }
            );
        }
    }
}
