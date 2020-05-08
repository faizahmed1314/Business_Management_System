using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BAL;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        BmsContext _db=new BmsContext();

        AccountManager _accountManager=new AccountManager();
        //
        // GET: /Account/
        public ActionResult Index()
        {
            var allUser = _accountManager.GetAllUser();
            return View(allUser);
        }

        public ActionResult Home()
        {
            ViewBag.Message = "Small Business Management System";
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                var save = _accountManager.Save(user);
                if (save)
                {
                    TempData["save"] = "Registration successful";
                    return RedirectToAction("Index", "Account");
                }
            }
            
            return View(user);
        }

        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RegisteredUser user)
        {
            
                var obj =_accountManager.IsLogin(user);
                if (obj != null)
                {
                    Session["UserId"] = obj.Id.ToString();
                    Session["UserName"] = obj.UserName.ToString();
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("","User name and password is incorrect!");
                }
            
            return View(user);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Register", "Account");
        }

        public JsonResult IsUserNameExist(string username)
        {
            var data = _accountManager.IsUserNameExist(username);
            if (data != null)
            {
                return Json("Sorry! This user name  already taken.");
            }
            return Json(false);
        }


    }
}