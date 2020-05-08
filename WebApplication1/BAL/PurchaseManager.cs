using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DLL;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository=new PurchaseRepository();

        public List<Purchase> GetAllPurchases()
        {
            return _purchaseRepository.GetAlLPurchases();
        }

        public bool Save(Purchase purchase)
        {
            return _purchaseRepository.Save(purchase);
        }

        public List<Product> GetProductById(int id)
        {
            return _purchaseRepository.GetProductById(id);
        }

        public List<Supplier> GetAllSupplier()
        {
            return _purchaseRepository.GetAllSupplier();
        }

        public List<Product> GetAllProduct()
        {
            return _purchaseRepository.GetAllProduct();
        }

        public Purchase IsBillNoExist(string bill)
        {
            return _purchaseRepository.IsBillNoExist(bill);
        }

        public List<SelectListItem> GetSupplierSelectListItems()
        {
            return _purchaseRepository.GetSupplierSelectListItems();
        }
        public List<SelectListItem> GetProductSelectListItems()
        {
            return _purchaseRepository.GetProductSelectListItems();
        }
    }
}