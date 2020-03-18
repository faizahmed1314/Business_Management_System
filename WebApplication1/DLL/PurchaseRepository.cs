using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.DLL
{
    public class PurchaseRepository
    {
        BmsContext _db=new BmsContext();

        public List<Purchase> GetAlLPurchases()
        {
            return _db.Purchases.ToList();
        }

        public bool Save(Purchase purchase)
        {
            _db.Purchases.Add(purchase);
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public List<Product> GetProductById(int id)
        {
           var product= _db.Products.Where(c => c.Id == id).ToList();
            return product;
        }

        public List<Supplier> GetAllSupplier()
        {
            return _db.Suppliers.ToList();
        }

        public List<Product> GetAllProduct()
        {
           return _db.Products.ToList();
        }
    }
}