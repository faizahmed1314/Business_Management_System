using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BAL;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {

        CustomerManager _customerManager = new CustomerManager();
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            var dataList = _customerManager.GetAllCustomers();
            return View(dataList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {

            if (ModelState.IsValid)
            {
                var checkEmail = _customerManager.IsEmailNoExist(customer.Email);
                var checkCode = _customerManager.IsCodeNoExist(customer.Code);
                if (checkEmail != null || checkCode != null)
                {
                    return View(customer);
                }
                if (customer.UploadFile != null)
                {
                    var fileByte = new byte[customer.UploadFile.ContentLength];
                    customer.UploadFile.InputStream.Read(fileByte, 0, customer.UploadFile.ContentLength);
                    customer.File = fileByte;
                    customer.FileName = customer.UploadFile.FileName;

                    var isSaved = _customerManager.Save(customer);
                    if (isSaved)
                    {
                        TempData["save"] = "Customer created successfully";
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _customerManager.GetCustomerById(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {

            if (ModelState.IsValid)
            {
                
                if (customer.UploadFile != null)
                {
                    var fileByte = new byte[customer.UploadFile.ContentLength];
                    customer.UploadFile.InputStream.Read(fileByte, 0, customer.UploadFile.ContentLength);
                    customer.File = fileByte;
                    customer.FileName = customer.UploadFile.FileName;

                    var isUpdated = _customerManager.Update(customer);
                    if (isUpdated)
                    {
                        TempData["Edit"] = "Category updated successfully";
                        return RedirectToAction("Index");
                    }
                }

            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id != null)
            {
                Customer customer = _customerManager.GetCustomerById(id);
                var isDeleted = _customerManager.Delete(customer);
                if (isDeleted)
                {
                    TempData["delete"] = "Customer deleted!";
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }

        public JsonResult IsCodeNoExist(string code)
        {
            var data = _customerManager.IsCodeNoExist(code);
            if (data != null)
            {
                return Json("Sorry! This code no is exist.");
            }
            return Json(false);
        }
        public JsonResult IsEmailNoExist(string email)
        {
            var data = _customerManager.IsEmailNoExist(email);
            if (data != null)
            {
                return Json("Sorry! This email is already exist.");
            }
            return Json(false);
        }
    }
}