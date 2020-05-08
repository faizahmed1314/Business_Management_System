using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.BAL;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PurchaseController : Controller
    {
        

        PurchaseManager _purchaseManager=new PurchaseManager();
        //
        // GET: /Purchase/

        public ActionResult Index()
        {
            var purchase = _purchaseManager.GetAllPurchases();
            return View(purchase);
        }
        public ActionResult Create()
        
        {
            var model = new Purchase();
            model.ProductLookUp = _purchaseManager.GetProductSelectListItems();
            model.SupplierLookUp = _purchaseManager.GetSupplierSelectListItems();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Purchase purchase)
        {
            purchase.ProductLookUp = _purchaseManager.GetProductSelectListItems();
            purchase.SupplierLookUp = _purchaseManager.GetSupplierSelectListItems();

            if (ModelState.IsValid && purchase.PurchaseDetailses != null && purchase.PurchaseDetailses.Count > 0)
            {
               var isSaved= _purchaseManager.Save(purchase);
                if (isSaved)
                {
                    return View(purchase);

                }
                //return RedirectToAction("Index");
            }
            return View(purchase);
        }

        public JsonResult IsBillNoExist(string bill)
        {
            var data = _purchaseManager.IsBillNoExist(bill);
            if (data != null)
            {
                return Json("Sorry! This bill no is exist.");
            }
            return Json(false);
        }

        

        public JsonResult GetByProductId(int id)
        {
            var product = _purchaseManager.GetProductById(id);

            var jsonData = product.Select(c => new {c.Id, c.Code});
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
	}
}