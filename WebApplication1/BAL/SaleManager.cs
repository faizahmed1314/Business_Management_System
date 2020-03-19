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

        public bool Update(Customer customer)
        {
            return _saleRepository.Update(customer);
        }
        public List<PurchaseDetails> GetByProductId(int id)
        {
            return _saleRepository.GetByProductId(id);
        }

        public List<Customer> GetByCustomerId(int id)
        {
            return _saleRepository.GetByCustomerId(id);
        } 

        public List<SelectListItem> GetProductSelectListItems()
        {
            return _saleRepository.GetProductSelectListItems();
        }

        public List<SelectListItem> GetCustomerSelectListItems()
        {
            return _saleRepository.GetCustomerSelectListItems();
        } 
    
    }
}