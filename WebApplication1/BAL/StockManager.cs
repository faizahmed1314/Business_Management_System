using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DLL;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public class StockManager
    {
        StockRepository _stockRepository = new StockRepository();

        public List<PurchaseDetails> GetAllPurchaseDetails()
        {
            return _stockRepository.GetAllPurchaseDetails();
        }
        public List<PurchaseDetails> SearchPurchaseDetails(string product, string category)
        {
            return _stockRepository.SearchPurchaseDetails(product, category);

        }
    }
}