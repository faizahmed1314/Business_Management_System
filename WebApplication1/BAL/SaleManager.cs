using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DLL;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public class SaleManager
    {
        SaleRepository _saleRepository=new SaleRepository();

        public bool Save(Sale sale)
        {
            return _saleRepository.Save(sale);
        }

        public Customer GetCustomerById(int id)
        {
            return _saleRepository.GetCustomerById(id);
        }
        public Product GetProductByName(string name)
        {
            return _saleRepository.GetProductByName(name);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _saleRepository.UpdateCustomer(customer);
        }
        public bool UpdateProduct(Product product)
        {
            return _saleRepository.UpdateProduct(product);
        }
        public List<Product> GetQuantityByProductId(int id)
        {
            return _saleRepository.GetQuantityByProductId(id);
        }

        public List<Customer> GetLoyaltyPointByCustomerId(int id)
        {
            return _saleRepository.GetLoyaltyPointByCustomerId(id);
        } 

        public List<SelectListItem> GetProductSelectListItems()
        {
            return _saleRepository.GetProductSelectListItems();
        }

        public List<SelectListItem> GetCustomerSelectListItems()
        {
            return _saleRepository.GetCustomerSelectListItems();
        }

        internal List<Customer> GetAllCustomer()
        {
            return _saleRepository.GetAllCustomer();
        }

        internal List<Product> GetAllProduct()
        {
            return _saleRepository.GetAllProduct();
        }
    }
}