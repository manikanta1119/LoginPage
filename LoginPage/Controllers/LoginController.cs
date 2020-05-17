using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginPage.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(LoginPage.Models.UserCradential userCradential)
        {
            using (DemoEntities db = new DemoEntities())
            {
                var UserDetails = db.UserCradentials.Where(x => x.UserName == userCradential.UserName && x.Password == userCradential.Password).FirstOrDefault();
                if(UserDetails == null)
                {
                    userCradential.LoginErrorMessage = "Wrong UserName or Password";

                    return View("Index", userCradential);
                }
                else
                {
                    Session["UserId"] = UserDetails.UserID;
                    return RedirectToAction("GetCustomer", "Home");
                }
            }
                
        }


    }
}