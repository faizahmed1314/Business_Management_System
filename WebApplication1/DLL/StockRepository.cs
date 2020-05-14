using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels.Stock;

namespace WebApplication1.DLL
{
    public class StockRepository
    {
        BmsContext _db = new BmsContext();

        public List<StockVm> GetAllStockDetails()
        {
            var result = from pd in _db.PurchaseDetailses
                         join p in _db.Products on pd.ProductId equals p.Id
                         join sd in _db.SaleDetailses on p.Id equals sd.Id
                         select new StockVm
                         {
                             Name = p.Name,
                             Code = p.Code,
                             ReOrderLevel = p.ReOrderLevel,
                             Category = p.Category.Name,
                             ExpireDate = pd.ExpireDate,
                             StockIn = pd.Quantity,
                             StockOut = sd.Quantity,
                             OpeningBalance = p.Quantity,
                             ClosingBalance = p.Quantity - sd.Quantity
                         };

            return (result.ToList());
        }
        public List<StockVm> SearchStockDetails(string product, string category)
        {
            var result = from pd in _db.PurchaseDetailses
                         join p in _db.Products.Where(c=>c.Name==product||c.Category.Name==category) on pd.ProductId equals p.Id
                         join sd in _db.SaleDetailses on p.Id equals sd.Id
                         select new StockVm
                         {
                             Name = p.Name,
                             Code = p.Code,
                             ReOrderLevel = p.ReOrderLevel,
                             Category = p.Category.Name,
                             ExpireDate = pd.ExpireDate,
                             StockIn = pd.Quantity,
                             StockOut = sd.Quantity,
                             OpeningBalance = p.Quantity,
                             ClosingBalance = p.Quantity - sd.Quantity
                         };

            return (result.ToList());
        }

        
        
    }
}