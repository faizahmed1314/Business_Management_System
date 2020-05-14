using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DLL;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels.Stock;

namespace WebApplication1.BAL
{
    public class StockManager
    {
        StockRepository _stockRepository = new StockRepository();

      
        public List<StockVm> GetAllStockDetails()
        {
            return _stockRepository.GetAllStockDetails();
        }
        public List<StockVm> SearchStockDetails(string product, string category)
        {
            return _stockRepository.SearchStockDetails(product, category);
        }
    }
}