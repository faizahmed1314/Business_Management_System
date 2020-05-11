using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BAL;
using WebApplication1.DatabaseContext;

namespace WebApplication1.Controllers
{
    public class StockController : Controller
    {
        StockManager _stockManager = new StockManager();
        // GET: Stock
        public ActionResult Index()
        {
            var datalist = _stockManager.GetAllPurchaseDetails();
            return View(datalist);
        }
        [HttpPost]
        public ActionResult Index(string product, string category)
        {

            var allData = _stockManager.GetAllPurchaseDetails();
            if (!string.IsNullOrEmpty(product) || !string.IsNullOrEmpty(category))
            {
                var data = _stockManager.SearchPurchaseDetails(product, category);
                if (data == null)
                {
                    return View(allData);
                }
                return View(data);
            }
            return View(allData);

        }

        
    }
}