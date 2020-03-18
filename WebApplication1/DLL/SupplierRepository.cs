using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.DLL
{
    public class SupplierRepository
    {
        BmsContext _db = new BmsContext();

        public List<Supplier> GetAllSuppliers()
        {
            return _db.Suppliers.ToList();
        }

        public bool Save(Supplier supplier)
        {
            _db.Suppliers.Add(supplier);
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
        public Supplier GetSupplierById(int id)
        {
            var supplier = _db.Suppliers.Where(x => x.Id == id).FirstOrDefault();
            return supplier;
        }

        public bool Update(Supplier supplier)
        {
            _db.Entry(supplier).State = EntityState.Modified;
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(Supplier supplier)
        {

            _db.Suppliers.Remove(supplier);
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}