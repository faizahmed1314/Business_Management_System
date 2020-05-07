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
    public class ProductController : Controller
    {
        ProductManager _productManager=new ProductManager();
        //
        // GET: /Product/
        public ActionResult Index()
        {
            var productData = _productManager.GetAllProducts();
            return View(productData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var productData = _productManager.GetAllProducts();
            
            return View(productData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var fileByte = new byte[product.UploadFile.ContentLength];
                product.UploadFile.InputStream.Read(fileByte, 0, product.UploadFile.ContentLength);
                product.File = fileByte;
                product.FileName = product.UploadFile.FileName;

                _productManager.Save(product);
                TempData["save"] = "Successfully Saved";
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Product product = _productManager.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var fileByte = new byte[product.UploadFile.ContentLength];
                product.UploadFile.InputStream.Read(fileByte,0, product.UploadFile.ContentLength);
                product.File = fileByte;
                product.FileName = product.UploadFile.FileName;

                _productManager.Update(product);
                TempData["Edit"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Product product = _productManager.GetProductById(id);
                _productManager.Delete(product);
                TempData["delete"] = "Product deleted!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetCategoryPv()
        {
            return PartialView("Category/_CategoryCreatePv");
            //return PartialView("~/Views/Shared/Category/_CategoryCreatePv");
        }

        [HttpPost]
       
        public ActionResult CreateCategory(Category category)
        {
            var categoryItem=_productManager.CreateCategory(category); 
            return Json(categoryItem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCategory()
        {
            var dataList = _productManager.GetAllCategories();
            var jsonData = dataList.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

      
	}
}