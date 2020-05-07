﻿using System;
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
                bool isSaved=_categoryManager.Save(category);
                TempData["save"] = "Successfully Saved";
                return RedirectToAction("Index");
            }
            return View(category);
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
                _categoryManager.UpdateCategory(category);
                TempData["Edit"] = "Category updated successfully";
                return RedirectToAction("Index");
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


    }
}