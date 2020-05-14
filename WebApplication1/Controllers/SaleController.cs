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
    public class SaleController : Controller
    {
        SaleManager _saleManager=new SaleManager();


        //
        // GET: /Sale/
       
        public ActionResult Create()
        {
            var model = new Sale();
            //model.CustomerLookup = _saleManager.GetCustomerSelectListItems();
            //model.ProductLookup = _saleManager.GetProductSelectListItems();
            //return View(model);
            return View();
        }
        
        [HttpPost]

        public ActionResult Create(Sale sale,string ItemName, double? GrandTotalValue)
        {
            
            //sale.CustomerLookup = _saleManager.GetCustomerSelectListItems();
            //sale.ProductLookup = _saleManager.GetProductSelectListItems();

            if (sale.SaleDetailses != null && sale.SaleDetailses.Count > 0)
            {
                
                sale.DateTime = DateTime.Now;
                var save = _saleManager.Save(sale);
                if (save)
                {
                    Customer customer = _saleManager.GetCustomerById(sale.CustomerId);
                    customer.LoyaltyPoint = (int)(customer.LoyaltyPoint + (GrandTotalValue / 1000));
                    var isUpdated = _saleManager.UpdateCustomer(customer);
                    //product quantity update korte hobe
                    //Product product = _saleManager.GetProductByName(ItemName);
                    //var isUpdatedProduct = _saleManager.UpdateProduct(product);

                    TempData["save"] = "Product sale successfully";
                    return View();
                }
                TempData["delete"]= "Sale not successfully";
            }
            return View();
        }

        
        public JsonResult GetQuantityByProductId(int id)
        {

            var dataList = _saleManager.GetQuantityByProductId(id);
            var jsonData = dataList.Select(c => new {c.Id,c.Quantity });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

       
        public JsonResult GetLoyaltyPointByCustomerId(int id)
        {
            var customer = _saleManager.GetLoyaltyPointByCustomerId(id);
            var jsonData = customer.Select(c => new { c.Id, c.LoyaltyPoint });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetAllCustomer()
        {
            var dataList = _saleManager.GetAllCustomer();
            var jsonData = dataList.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllProduct()
        {
            var dataList = _saleManager.GetAllProduct();
            var jsonData = dataList.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


    }
}