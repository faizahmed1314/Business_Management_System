using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SaleController : Controller
    {
        private BmsContext _db;
        public SaleController()
        {
            _db=new BmsContext();
        }
        //
        // GET: /Sale/
        public ActionResult Create()
        {
            var model = new Sale();
            model.CustomerLookup = GetCustomerSelectListItems();
            model.ProductLookup = GetProductSelectListItems();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Sale sale, int customerId, double? GrandTotalValue)
        {
            
            sale.CustomerLookup = GetCustomerSelectListItems();
            sale.ProductLookup = GetProductSelectListItems();
            if (ModelState.IsValid && sale.SaleDetailses != null && sale.SaleDetailses.Count > 0)
            {
                Customer customer = _db.Customers.Where(c => c.Id == customerId).FirstOrDefault();
                customer.LoyaltyPoint = (int)(customer.LoyaltyPoint + GrandTotalValue)/1000;
                _db.Entry(customer).State=EntityState.Modified;
                _db.SaveChanges();

                _db.Sales.Add(sale);
                var isAdded = _db.SaveChanges();
                if (isAdded > 0)
                {
                    return View();
                }
            }
            return View();
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
            var dataList = _db.Products.ToList();
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
            
            var product = _db.PurchaseDetailses.Where(c => c.ProductId == id).ToList();
            var jsonData = product.Select(c => new { c.UnitPrice, c.Quantity });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        public List<SelectListItem> GetCustomerSelectListItems()
        {
            var dataList = _db.Customers.ToList();
            var customerSelectListItems = new List<SelectListItem>();
            customerSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                
                foreach (var customer in dataList)
                {
                    var selectListItem = new SelectListItem();

                    selectListItem.Text = customer.Name;
                    selectListItem.Value = customer.Id.ToString();
                    customerSelectListItems.Add(selectListItem);
                }
            }
            return customerSelectListItems;
        }
        public JsonResult GetByCustomerId(int id)
        {
            var customer = _db.Customers.Where(c => c.Id == id).ToList();
            var jsonData = customer.Select(c => new { c.Id, c.LoyaltyPoint });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        
	}
}