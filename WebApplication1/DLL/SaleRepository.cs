using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.DLL
{
    public class SaleRepository
    {
        BmsContext _db=new BmsContext();

        public bool Save(Sale sale)
        {
            _db.Sales.Add(sale);
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _db.Entry(customer).State=EntityState.Modified;
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateProduct(Product product)
        {
            var dataList=_db.SaleDetailses.Where(c => c.ProductId == product.Id).FirstOrDefault();
            if (dataList != null)
            {
                product.Quantity = product.Quantity - dataList.Quantity;
                _db.Entry(product).State = EntityState.Modified;
                var rowAffected = _db.SaveChanges();
                if (rowAffected > 0)
                {
                    return true;
                }
            }
            
            return false;
        }

        public Customer GetCustomerById(int id)
        {
            return _db.Customers.Where(c => c.Id == id).FirstOrDefault();
        }

        internal List<Customer> GetAllCustomer()
        {
            return _db.Customers.ToList();
        }

        internal List<Product> GetAllProduct()
        {
            return _db.Products.ToList();
        }

        public Product GetProductByName(string name)
        {
            return _db.Products.Where(c => c.Name == name).FirstOrDefault();
        }
        public List<Product> GetQuantityByProductId(int id)
        {
            return _db.Products.Where(c => c.Id == id).ToList();
        }


        public List<Customer> GetLoyaltyPointByCustomerId(int id)
        {
            return _db.Customers.Where(c => c.Id == id).ToList();
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
    }
}