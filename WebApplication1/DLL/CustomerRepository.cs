using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.DLL
{
    
    public class CustomerRepository
    {
        BmsContext _db=new BmsContext();

        public List<Customer> GetAllCustomers()
        {
            return _db.Customers.ToList();
        } 

        public bool Save(Customer customer)
        {
            _db.Customers.Add(customer);
            var rowAffected=_db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
        public Customer GetCustomerById(int id)
        {
            var customer = _db.Customers.Where(x => x.Id == id).FirstOrDefault();
            return customer;
        }

        public bool Update(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Modified;
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(Customer customer)
        {

            _db.Customers.Remove(customer);
            var rowAffected=_db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}