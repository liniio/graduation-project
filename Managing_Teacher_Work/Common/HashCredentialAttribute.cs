//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//namespace Managing_Teacher_Work.Common
//{
//    public class HashCredentialAttribute : AuthorizeAttribute
//    {
//        public string RoleID { set; get; }
//        protected override bool AuthorizeCore(HttpContextBase httpContext)
//        {
//            var session = (Managing_Teacher_Work.Common.UserLogin)HttpContext.Current.Session[Managing_Teacher_Work.Common.CommonConstants.USER_SESSION];
//            if (session == null)
//            {
//                return false;
//            }

//            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.UserName); // Call another method to get rights of the user from DB

//            if (privilegeLevels.Contains(this.RoleID) || session.GroupID == Managing_Teacher_Work.CommonConstants.ADMIN_GROUP )
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
//        {
//            filterContext.Result = new ViewResult
//            {
//                ViewName = "~/Areas/Admin/Views/Shared/401.cshtml"

//            };
//        }
//        private List<string> GetCredentialByLoggedInUser(string userName)
//        {
//            var credentials = (List<string>)HttpContext.Current.Session[Managing_Teacher_Work.Common.CommonConstants.SESSION_CREDENTIALS];
//            return credentials;
//        }
//    }
//}