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
            model.CustomerLookup = _saleManager.GetCustomerSelectListItems();
            model.ProductLookup = _saleManager.GetProductSelectListItems();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Sale sale, int customerId, double? GrandTotalValue)
        {
            
            sale.CustomerLookup = _saleManager.GetCustomerSelectListItems();
            sale.ProductLookup = _saleManager.GetProductSelectListItems();

            if (sale.SaleDetailses != null && sale.SaleDetailses.Count > 0)
            {
                sale.DateTime = DateTime.Now;
                var save = _saleManager.Save(sale);
                if (save)
                {
                    Customer customer = _saleManager.GetCustomerById(customerId);
                    customer.LoyaltyPoint = (int)(customer.LoyaltyPoint + GrandTotalValue) / 1000;
                    var isUpdated = _saleManager.Update(customer);
                    return View(sale);
                }
                
            }
            return View();
        }

        
        public JsonResult GetByProductId(int id)
        {

            var dataList = _saleManager.GetByProductId(id);
            var jsonData = dataList.Select(c => new {c.Quantity,c.MRP });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

       
        public JsonResult GetByCustomerId(int id)
        {
            var customer = _saleManager.GetByCustomerId(id);
            var jsonData = customer.Select(c => new { c.Id, c.LoyaltyPoint });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        
	}
}