using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            model.ProductLookUp = GetProductSelectListItems();
            model.SupplierLookUp = GetSupplierSelectListItems();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Purchase purchase)
        {
            purchase.ProductLookUp = GetProductSelectListItems();
            purchase.SupplierLookUp = GetSupplierSelectListItems();

            if (ModelState.IsValid && purchase.PurchaseDetailses != null && purchase.PurchaseDetailses.Count > 0)
            {
               var isSaved= _purchaseManager.Save(purchase);
                if (isSaved)
                    return View(purchase);
                //return RedirectToAction("Index");
            }
            return View(purchase);
        }

        public List<SelectListItem> GetSupplierSelectListItems()
        {
            var dataList = _purchaseManager.GetAllSupplier();
            var supplierSelectListItems = new List<SelectListItem>();
            supplierSelectListItems.AddRange(GetDefaultSelectListItem());
            if (dataList != null && dataList.Count>0)
            {
                foreach (var supplier in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = supplier.Name;
                    selectListItem.Value = supplier.Id.ToString();
                    supplierSelectListItems.Add(selectListItem);
                }
            }
            return supplierSelectListItems;
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

        public List<SelectListItem> GetProductSelectListItems()
        {
            var dataList = _purchaseManager.GetAllProduct();
            var productSelectListItems = new List<SelectListItem>();
            productSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                
                foreach (var product in dataList)
                {
                    var selectListItem = new SelectListItem();

                    selectListItem.Text = product.Name;
                    selectListItem.Value = product.Id.ToString();

                    productSelectListItems.Add(selectListItem);
                }
            }
            return productSelectListItems;
        }

        public JsonResult GetByProductId(int id)
        {
            var product = _purchaseManager.GetProductById(id);
            var jsonData = product.Select(c => new {c.Id, c.Code});
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
	}
}