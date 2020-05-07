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

        //public ActionResult Create(Customer customer)
        //{
        //    try
        //    {
        //        if (customer.UploadFile != null)
        //        {
        //            var fileByte = new byte[customer.UploadFile.ContentLength];
        //            customer.UploadFile.InputStream.Read(fileByte, 0, customer.UploadFile.ContentLength);
        //            customer.File = fileByte;
        //            customer.FileName = customer.UploadFile.FileName;



        //            _db.Customers.Add(customer);
        //            int save = _db.SaveChanges();
        //            if (save > 0)
        //            {
        //                ViewBag.isSuccess = "Saved";
        //                //return View("Index");
        //            }
        //            else
        //            {
        //                ViewBag.Fail = "Not Saved";
        //            }
        //            var dataList = _db.Customers.ToList();
        //            if (dataList != null)
        //            {
        //                return View(dataList);
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {

        //        ViewBag.Fail = exception.Message;
        //    }
        //    return View();
        //}

        [HttpPost]

        public ActionResult Create(Customer customer)
        {

            if (ModelState.IsValid)
            {
                var fileByte = new byte[customer.UploadFile.ContentLength];
                customer.UploadFile.InputStream.Read(fileByte, 0, customer.UploadFile.ContentLength);
                customer.File = fileByte;
                customer.FileName = customer.UploadFile.FileName;

                _customerManager.Save(customer);
                TempData["save"] = "Successfully Saved";
                return RedirectToAction("Index");


            }
            return View("Create");
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
                var fileByte = new byte[customer.UploadFile.ContentLength];
                customer.UploadFile.InputStream.Read(fileByte, 0, customer.UploadFile.ContentLength);
                customer.File = fileByte;
                customer.FileName = customer.UploadFile.FileName;

                _customerManager.Update(customer);
                TempData["Edit"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id != null)
            {
                Customer customer = _customerManager.GetCustomerById(id);
                _customerManager.Delete(customer);
                TempData["delete"] = "Customer deleted!";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}