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
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager=new SupplierManager();
        //
        // GET: /Supplier/
        public ActionResult Index()
        {
            var supplier = _supplierManager.GetAllSuppliers();
           return View(supplier);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var fileByte = new byte[supplier.UploadFile.ContentLength];
                supplier.UploadFile.InputStream.Read(fileByte, 0, supplier.UploadFile.ContentLength);
                supplier.File = fileByte;
                supplier.FileName = supplier.UploadFile.FileName;

                _supplierManager.Save(supplier);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            Supplier supplier = _supplierManager.GetSupplierById(id);
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {

            if (ModelState.IsValid)
            {
                var fileByte = new byte[supplier.UploadFile.ContentLength];
                supplier.UploadFile.InputStream.Read(fileByte, 0, supplier.UploadFile.ContentLength);
                supplier.File = fileByte;
                supplier.FileName = supplier.UploadFile.FileName;

                _supplierManager.Update(supplier);
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            Supplier supplier = _supplierManager.GetSupplierById(id);
            _supplierManager.Delete(supplier);
            return RedirectToAction("Index");
        }

        
	}
}