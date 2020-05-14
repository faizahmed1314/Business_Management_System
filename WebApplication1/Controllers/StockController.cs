using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BAL;
using WebApplication1.DatabaseContext;
using WebApplication1.Models.ViewModels.Stock;

namespace WebApplication1.Controllers
{
    public class StockController : Controller
    {
        BmsContext _db = new BmsContext();

        StockManager _stockManager = new StockManager();
        // GET: Stock
        public ActionResult Index()
        {
            var datalist = _stockManager.GetAllStockDetails();

            return View(datalist);
        }
        [HttpPost]
        public ActionResult Index(string product, string category)
        {

            var allData = _stockManager.GetAllStockDetails();
            if (!string.IsNullOrEmpty(product) || !string.IsNullOrEmpty(category))
            {
                var data = _stockManager.SearchStockDetails(product, category);
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