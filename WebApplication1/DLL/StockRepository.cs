using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.DLL
{
    public class StockRepository
    {
        BmsContext _db = new BmsContext();

        public List<PurchaseDetails> GetAllPurchaseDetails()
        {
            return _db.PurchaseDetailses.ToList();
        }

        public List<PurchaseDetails> SearchPurchaseDetails(string product, string category)
        {
            var data = _db.PurchaseDetailses.Where(c => c.Product.Name == product || c.Product.Category.Name == category).ToList();
            return data;
            
        }
        public int availableQuantitySum(int id)
        {
            int sum = 0;

            var datalist = _db.PurchaseDetailses.Where(c => c.ProductId == id).ToList();

            foreach (var q in datalist)
            {
                sum += q.Quantity;
            }
            return sum;

        }
    }
}