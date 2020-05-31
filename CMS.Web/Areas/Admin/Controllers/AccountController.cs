using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Web.Areas.Admin.Models;
using CMS.Web.Services;

namespace CMS.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account/login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginInfo)
        {
            var adminService = new AdminService();
            var  isLoggedIn = adminService.login(loginInfo.Email, loginInfo.Password);
            if (isLoggedIn)
            {
                return RedirectToAction("Index", "Default");

            }
            else
            {
                loginInfo.Massage = "Wrong Email Or Password";
                return View(loginInfo);
            }

        }
    }
}