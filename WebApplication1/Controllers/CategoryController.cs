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
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                bool isSaved=_categoryManager.Save(category);
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
        public ActionResult Edit([Bind (Include = "Id,Name,Code")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

       [HttpPost]
        public ActionResult Delete(int id)
        {
           
             _categoryManager.DeleteCategory(id);             
             return RedirectToAction("Index");
        }
        
       
	}
}