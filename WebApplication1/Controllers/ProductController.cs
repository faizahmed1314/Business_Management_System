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
                product.UploadFile.InputStream.Read(fileByte, 0, product.UploadFile.ContentLength);
                product.File = fileByte;
                product.FileName = product.UploadFile.FileName;

                _productManager.Update(product);
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
                return RedirectToAction("Create");
            }
            return RedirectToAction("Create");
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
            return Json(category,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCategory()
        {
            var dataList = _productManager.GetAllCategories();
            var jsonData = dataList.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public List<SelectListItem> GetCategorySelectListItems()
        {
            var categoryList = _productManager.GetAllCategories();

            var categorySelectListItems = new List<SelectListItem>();

            categorySelectListItems.AddRange(GetDefaultSelectListItem());

            if (categoryList != null && categoryList.Count > 0)
            {
                foreach (var category in categoryList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = category.Name;
                    selectListItem.Value = category.Id.ToString();

                    categorySelectListItems.Add(selectListItem);
                }
            }
            return categorySelectListItems;
        }



        public List<SelectListItem> GetDefaultSelectListItem()
        {
            var dataList = new List<SelectListItem>();
            var defaultSelectListItem = new SelectListItem();
            defaultSelectListItem.Text = "---Select---";
            defaultSelectListItem.Value = "";
            dataList.Add(defaultSelectListItem);
            return dataList;
        }
	}
}