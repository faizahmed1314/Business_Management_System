using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public Purchase IsBillNoExist(string bill)
        {
            var purchase = _db.Purchases.Where(c => c.BillNo == bill).FirstOrDefault();
            return purchase;
        }
        public List<SelectListItem> GetSupplierSelectListItems()
        {
            var dataList = _db.Suppliers.ToList();
            var supplierSelectListItems = new List<SelectListItem>();
            supplierSelectListItems.AddRange(GetDefaultSelectListItem());
            if (dataList != null && dataList.Count > 0)
            {
                foreach (var supplier in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = supplier.Name;
                    selectListItem.Value = supplier.Id.ToString();
                    supplierSelectListItems.Add(selectListItem);
                }
            }
            return supplierSelectListItems;
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
    }
}