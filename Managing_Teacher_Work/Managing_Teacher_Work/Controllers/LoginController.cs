using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Managing_Teacher_Work.Models;
using Managing_Teacher_Work.DAO;
using Managing_Teacher_Work.Common;

namespace Managing_Teacher_Work.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
       public bool alertLogin = false;
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord), true);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.ID = user.ID;
                    userSession.Name = user.Name;
                    userSession.GroupID = user.GroupID;

                    var listCredentials = dao.GetListCredential(model.UserName);
                    Session.Add(Managing_Teacher_Work.Common.CommonConstants.USER_SESSION, listCredentials);
                    Session.Add(Managing_Teacher_Work.Common.CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ////ModelState.AddModelError("", "Tài khoản không tồn tại");
                    //Response.Write("<script>window.alert('Tài khoản không tồn tại trong hệ thống !');window.location = '/Login-system/'</script>");
                    alertLogin = true;
                    ViewBag.alertLogin = alertLogin;
                    //ModelState.AddModelError("", "Tài khoản không tồn tại trong hệ thống !");
                    Redirect("Login/Index");
                    ViewBag.Mes = "Sai mật khẩu hoặc tài khoản. Vui lòng kiểm tra lại!";
                }
                else if (result == -1)
                {
                    //Response.Write("<script>" +
                    //    "window.alert('Tài khoản đã bị khoá !);window.location = '/Login-system/'</script>");
                    alertLogin = true;
                    ViewBag.alertLogin = alertLogin;
                    //ModelState.AddModelError("", "Tài khoản đã bị khoá !");
                    ViewBag.Mes = "Tài khoản đã bị khoá!";
                }
                else if (result == -2)
                {
                    alertLogin = true;
                    ViewBag.alertLogin = alertLogin;
                    //ModelState.AddModelError("", "Sai mật khẩu hoặc tài khoản. Vui lòng thử lại!");
                    ViewBag.Mes = "Sai mật khẩu hoặc tài khoản. Vui lòng kiểm tra lại!";
                    //Response.Write("<script>window.alert('Tài khoản hoặc mật khẩu không chính xác !');window.location = '/Login-system/'</script>");
                }
               

                else
                {
                    alertLogin = true;
                    ViewBag.alertLogin = alertLogin;
                    //ModelState.AddModelError("", "Đăng nhập không thành công");
                    ViewBag.Mes = "Đăng nhập không thành công";
                    //Response.Write("<script>window.location = '/Home/'</script>");
                }
            }

            return View("Index");
        }
    }
}