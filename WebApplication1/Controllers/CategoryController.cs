using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BAL;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels.Category;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager=new CategoryManager();
        //
        // GET: /Category/
        public ActionResult Index()
        {
            var categoryList = _categoryManager.GetAllCategories();
            return View(categoryList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreateVm entity)
        {
            var category = new Category()
            {
                Name = entity.Name,
                Code = entity.Code
            };
            
            if (ModelState.IsValid)
            {
                var checkName = _categoryManager.IsNameNoExist(category.Name);
                var checkCode = _categoryManager.IsCodeNoExist(category.Code);
                if (checkName!=null || checkCode!=null)
                {
                    return View(entity);
                }
                var isSaved=_categoryManager.Save(category);
                if (isSaved)
                {
                    TempData["save"] = "Category created successfully";
                    return RedirectToAction("Index");
                }
                
            }
            return View(entity);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var category = _categoryManager.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            

            if (ModelState.IsValid)
            {
                var checkName = _categoryManager.IsNameNoExist(category.Name);
               
                if (checkName != null)
                {
                    ViewBag.Message = "Sorry! This name is already exist";
                    return View(category);
                    
                }
                var isUpdated=_categoryManager.UpdateCategory(category);
                if (isUpdated)
                {
                    TempData["Edit"] = "Category updated successfully";
                    return RedirectToAction("Index");
                }
                
            }
            return View(category);
        }

       [HttpPost]
        public ActionResult Delete(int id)
        {
            
             var isDeleted=_categoryManager.DeleteCategory(id);
            if (isDeleted)
            {
                TempData["delete"] = "Category deleted!";
                return RedirectToAction("Index");
            }
                return RedirectToAction("Index");

        }
        public JsonResult IsCodeNoExist(string code)
        {
            var data = _categoryManager.IsCodeNoExist(code);
            if (data != null)
            {
                return Json("Sorry! This code no is exist.");
            }
            return Json(false);
        }
        public JsonResult IsNameNoExist(string name)
        {
            var data = _categoryManager.IsNameNoExist(name);
            if (data != null)
            {
                return Json("Sorry! This name is already exist.");
            }
            return Json(false);
        }


    }
}