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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadFile != null)
                {
                    var checkName = _productManager.IsNameExist(product.Name);
                    var checkCode = _productManager.IsCodeNoExist(product.Code);
                    if (checkName != null || checkCode != null)
                    {
                        return View(product);
                    }
                    var fileByte = new byte[product.UploadFile.ContentLength];
                    product.UploadFile.InputStream.Read(fileByte, 0, product.UploadFile.ContentLength);
                    product.File = fileByte;
                    product.FileName = product.UploadFile.FileName;
                    product.Quantity = 0;
                    var isSaved = _productManager.Save(product);
                    if (isSaved)
                    {
                        TempData["save"] = "Product created successfully";
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(product);
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
                if (product.UploadFile != null)
                {
                    var fileByte = new byte[product.UploadFile.ContentLength];
                    product.UploadFile.InputStream.Read(fileByte, 0, product.UploadFile.ContentLength);
                    product.File = fileByte;
                    product.FileName = product.UploadFile.FileName;

                    var isUpdated = _productManager.Update(product);
                    if (isUpdated)
                    {
                        TempData["Edit"] = "Product updated successfully";
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Product product = _productManager.GetProductById(id);
                var isDeleted=_productManager.Delete(product);
                if (isDeleted)
                {
                    TempData["delete"] = "Product deleted!";
                    return RedirectToAction("Index");
                }
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
        public JsonResult IsCodeNoExist(string code)
        {
            var data = _productManager.IsCodeNoExist(code);
            if (data != null)
            {
                return Json("Sorry! This code no is exist.");
            }
            return Json(false);
        }
        public JsonResult IsNameExist(string name)
        {
            var data = _productManager.IsNameExist(name);
            if (data != null)
            {
                return Json("Sorry! This name is already exist.");
            }
            return Json(false);
        }
    }
}